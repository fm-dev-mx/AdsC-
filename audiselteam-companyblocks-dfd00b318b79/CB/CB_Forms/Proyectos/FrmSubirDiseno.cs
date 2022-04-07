using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CB_Base.Classes;
using System.Net;
using FluentFTP;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swdocumentmgr;
using System.Threading;
using System.Management;

namespace CB
{

    public partial class FrmSubirDiseno : Ventana
    {
        SolidWorksProyecto swp = new SolidWorksProyecto();
        Modulo ModuloCargado = new Modulo();
        string Alcance = string.Empty;
        decimal IdProyecto = 0.0m;
        int Subensamble = 0;
        string RaizFtp = "";
        public List<ArchivoSolidWorks> ArchivosLocales = new List<ArchivoSolidWorks>();
        public bool FtpConectado = false;
        public string CarpetaLocal = "";
        public FtpClient ClienteFtp = new FtpClient();
        public double InicioTrabajo = 0;
        public bool AnalisisCompleto = false;
        public int TotalConflictos = 0;
        SolidWorksAPI SW = null;
        List<ManagementObject> ProcesosSolidWorks = new List<ManagementObject>();
        bool CerrarSesionSW = false;

        string recuperarArchivoPathLocal = string.Empty;
        string recuperarArchivoPathRemoto = string.Empty;

        public FrmSubirDiseno(decimal proyecto, int subensamble, string carpetaLocal, string alcance="MODULO", SolidWorksAPI sw=null)
        {
            InitializeComponent();
            IdProyecto = proyecto;
            Subensamble = subensamble;
            CarpetaLocal = carpetaLocal;
            TxtCarpetaLocal.Text = CarpetaLocal;
            Alcance = alcance;
            SW = sw;
        }

        private void FrmSubirDiseno_Load(object sender, EventArgs e)
        {
            SplitEstatus.Panel1Collapsed = true;
            WindowState = FormWindowState.Maximized;

            Proyecto prj = new Proyecto();
            prj.CargarDatos(IdProyecto);

            if(prj.TieneFilas())
            {
                LblProyecto.Text = Convert.ToDecimal(prj.Fila().Celda("id")).ToString("F2") + " - " + prj.Fila().Celda("nombre").ToString();
            }

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", IdProyecto);
            parametros.Add("@subensamble", Subensamble);
            ModuloCargado.SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble", parametros);

            if(Alcance == "MODULO")
            {
                LblTitulo.Text = "SUBIR DISEÑO DEL MODULO AL SERVIDOR";
                if (ModuloCargado.TieneFilas())
                {
                    LblModulo.Text = ModuloCargado.Fila().Celda("subensamble").ToString().PadLeft(2, '0') + " - " + ModuloCargado.Fila().Celda("nombre").ToString();
                }
                Progreso.Visible = true;
                DgvModuloLocal.Rows.Clear();
                LblModulo.Visible = true;
            }
            else
            {
                LblTitulo.Text = "SUBIR DISEÑO DEL PROYECTO AL SERVIDOR";
                LblModulo.Visible = false;
            }
            BkgInicializar.RunWorkerAsync();
        }

        public void CargarArchivosLocales(string raiz, string alcance = "MODULO", string extensiones = "*.sldprt, *.sldasm, *.slddrw")
        {
            string[] archivos = null;
            archivos = Directory.GetFiles(raiz, "*.*", SearchOption.AllDirectories).Where(s => extensiones.Contains(Path.GetExtension(s).ToLower())).ToArray();

            foreach (string ruta in archivos)
            {
                ArchivoSolidWorks archivo = new ArchivoSolidWorks();

                try
                {
                    if (alcance == "MODULO")
                        archivo.CargarMetadatos(ruta, Path.GetDirectoryName(raiz));
                    else
                        archivo.CargarMetadatos(ruta, raiz);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                string carpetaArchivo = Path.GetFileName(Path.GetDirectoryName(archivo.RutaCompleta));

                if (!archivo.Nombre.StartsWith("~$") && carpetaArchivo != ".svn")
                    ArchivosLocales.Add(archivo);
            }
        }

        private void BkgInicializar_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgInicializar.ReportProgress(20, "Conectando con SolidWorks... ");
            // Crear nueva conexion con SolidWorks
            try
            {
                if (SW == null)
                {
                    // Cierra cualquier proceso vinculado con solidworks
                    ProcesosSolidWorks = BuscarProcesos("sldworks");
                    if (ProcesosSolidWorks.Count > 0)
                    {
                        DialogResult respuesta = MessageBox.Show("Estás a punto de conectarte con SolidWorks, asegúrate de guardar tus cambios y cerrar todos los archivos que tengas abiertos... cuando estés listo presiona OK.", "Conectando a SolidWorks", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        if (respuesta != System.Windows.Forms.DialogResult.OK)
                        {
                            BkgInicializar.ReportProgress(100, "Conexión con SolidWorks cancelada por el usuario" + System.Environment.NewLine);
                            return;
                        }
                        BkgInicializar.ReportProgress(50, System.Environment.NewLine + "Cerrando otras instancias de SolidWorks... " + System.Environment.NewLine + "Reconectando con SolidWorks... ");
                        TerminarProcesos(ProcesosSolidWorks);
                        System.Threading.Thread.Sleep(2000);
                    }
                    SW = new SolidWorksAPI();
                    CerrarSesionSW = true;
                }
            }
            catch(Exception ex)
            {
                BkgInicializar.ReportProgress(100, "[ERROR] Imposible terminar otras instancias de SolidWorks, vuelva a intentarlo." + System.Environment.NewLine + ex.ToString() + System.Environment.NewLine);
                return;
            }
     
            // Verificar conexion con SolidWorks
            if (SW.Aplicacion == null)
            {
                BkgInicializar.ReportProgress(100, "[ERROR]" + System.Environment.NewLine);
                Thread.Sleep(4000);
                return;
            }
            else
                BkgInicializar.ReportProgress(20, "[OK]" + System.Environment.NewLine);

            // Realizar conexion FTP
            BkgInicializar.ReportProgress(50, "Conectando con servidor FTP... ");
            string strProyecto = IdProyecto.ToString("F2").PadLeft(6, '0').Replace(".", "_");
            RaizFtp = strProyecto + "/M" + strProyecto;

            if (Global.TipoConexion == "LOCAL")
            {
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
            }
            else
            {
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;
                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
            }

            // Verificar conexion con servidor FTP
            try
            {
                ClienteFtp.Connect();

                BkgInicializar.ReportProgress(100, "[OK]" + System.Environment.NewLine);
            }
            catch (Exception ex)
            {
                BkgInicializar.ReportProgress(100, "[ERROR]" + System.Environment.NewLine + ex.ToString() + System.Environment.NewLine);
                return;
            }
        }

        private void BkgInicializar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(SW.Aplicacion == null)
            {
                MessageBox.Show("No ha sido posible conectarse con SolidWorks, imposible actualizar módulo.", "Error SolidWorks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Verificar conexion con servidor FTP
            if(!ClienteFtp.IsConnected)
            {
                MessageBox.Show("No ha sido posible conectarse con el servidor FTP, imposible actualizar módulo.", "Error FTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Mostrar contenido de carpeta remota
            if (Alcance == "MODULO")
                swp.SeleccionarProyectoSubensamble(IdProyecto, Subensamble);
            else if(Alcance == "PROYECTO")
                swp.SeleccionarProyecto(IdProyecto);

            swp.Filas().ForEach(delegate(Fila f)
            {
                DgvModuloRemoto.Rows.Add(f.Celda("nombre_archivo").ToString(), f.Celda("kilobytes").ToString());
            });
            DgvModuloRemoto.Sort(DgvModuloRemoto.Columns["nombre_archivo_remoto"], ListSortDirection.Ascending);

            SplitEstatus.Panel1Collapsed = false;
            BkgAnalizarCarpeta.RunWorkerAsync();
        }

        private void BkgInicializar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtEstatus.AppendText(e.UserState.ToString());
        }

        private void BkgAnalizarCarpeta_DoWork(object sender, DoWorkEventArgs e)
        {
            TotalConflictos = 0;
            AnalisisCompleto = false;
            InicioTrabajo = Global.MillisegundosEpoch();
            int i = 0;
            ProgresoAnalisisCarpeta progresoAnalisis;

            progresoAnalisis = new ProgresoAnalisisCarpeta("Analizando carpeta local... ", null);
            BkgAnalizarCarpeta.ReportProgress(0, progresoAnalisis);

            try
            {
                CargarArchivosLocales(CarpetaLocal, Alcance, "*.sldprt, *.sldasm, *.slddrw");

                i = 0;
                ArchivosLocales.ForEach(delegate(ArchivoSolidWorks archivo)
                {
                    if(Alcance == "PROYECTO")
                    {
                        string[] divisionesPath = archivo.RutaParcial.Split('\\');

                        if (divisionesPath.Count() > 0)
                        {
                            string strSubensamble = divisionesPath[1];

                            if (strSubensamble.Length == 2)
                                Subensamble = Convert.ToInt32(strSubensamble);
                            else Subensamble = 0;
                        }
                        else Subensamble = 0;
                    }

                    archivo.DeterminarEstatusServidor(IdProyecto, Subensamble);
                    i++;
                    progresoAnalisis = new ProgresoAnalisisCarpeta(string.Empty, archivo);
                    BkgAnalizarCarpeta.ReportProgress(Global.CalcularPorcentaje(i, ArchivosLocales.Count), progresoAnalisis);
                });

                BkgAnalizarCarpeta.ReportProgress(0, null);

                List<Fila> indiceRemoto = new List<Fila>();
                if (Alcance == "MODULO")
                    indiceRemoto = SolidWorksProyecto.Modelo().SeleccionarProyectoSubensamble(IdProyecto, Subensamble);
                else if(Alcance == "PROYECTO")
                    indiceRemoto = SolidWorksProyecto.Modelo().SeleccionarProyecto(IdProyecto);

                i = 0;
                indiceRemoto.ForEach(delegate(Fila f)
                {
                    string dirCarpetaLocal = CarpetaLocal;

                    if (Alcance == "MODULO")
                        dirCarpetaLocal = Path.GetDirectoryName(CarpetaLocal);

                    string registroRemoto = dirCarpetaLocal + f.Celda("nombre_archivo").ToString();

                    BkgAnalizarCarpeta.ReportProgress(Global.CalcularPorcentaje(i, indiceRemoto.Count), null);
                    if (!File.Exists(registroRemoto))
                    {
                        ArchivoSolidWorks archivoBorrado = new ArchivoSolidWorks();
                        archivoBorrado.CargarMetadatos(f.Celda("nombre_archivo").ToString(), dirCarpetaLocal);

                        archivoBorrado.EstatusServidor = "BORRADO";

                        if(!ArchivoEnListaLocal(archivoBorrado.Nombre))
                        {
                            ArchivosLocales.Add(archivoBorrado);

                            progresoAnalisis = new ProgresoAnalisisCarpeta("", archivoBorrado);
                            BkgAnalizarCarpeta.ReportProgress(Global.CalcularPorcentaje(i, indiceRemoto.Count), progresoAnalisis);
                        }
                    }
                    i++;
                });
                AnalisisCompleto = true;
                progresoAnalisis = new ProgresoAnalisisCarpeta("[OK]" + System.Environment.NewLine, null);
                BkgAnalizarCarpeta.ReportProgress(100, progresoAnalisis);
            }
            catch(Exception ex)
            {
                string msg = "Se produjo un error al intentar abrir los archivos, asegúrate de guardar tus cambios y cerrar en SolidWorks el ensamble ";
                msg += "y todas las piezas relacionadas con el módulo antes de volver a sincronizar." + System.Environment.NewLine + System.Environment.NewLine;
                msg += ex.ToString();
                MessageBox.Show(msg, "Error al sincronizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public bool ArchivoEnListaLocal(string nombreArchivo)
        {
            foreach(ArchivoSolidWorks archivo in ArchivosLocales)
            {
                if(archivo.Nombre == nombreArchivo)
                    return true;
            }
            return false;
        }

        public List<ManagementObject> BuscarProcesos(string nombre = "sldworks")
        {
            List<ManagementObject> procesosEncontrados = new List<ManagementObject>();
            ManagementClass MgmtClass = new ManagementClass("Win32_Process");

            foreach (ManagementObject mo in MgmtClass.GetInstances())
            {
                string nombreProceso = mo["Name"].ToString().ToLower();

                if (nombreProceso.Contains("sldworks"))
                {
                    procesosEncontrados.Add(mo);
                }
            }
            return procesosEncontrados;
        }

        public void TerminarProcesos(List<ManagementObject> procesos)
        {
            foreach (ManagementObject mo in procesos)
            {
                mo.InvokeMethod("Terminate", null);
            }
        }

        private void BkgAnalizarCarpeta_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value = e.ProgressPercentage;

            if (e.UserState == null)
                return;
            
            ProgresoAnalisisCarpeta progresoAnalisis = (ProgresoAnalisisCarpeta)e.UserState;

            if (progresoAnalisis.Mensaje != string.Empty)
                TxtEstatus.AppendText(progresoAnalisis.Mensaje);

            if(progresoAnalisis.Archivo != null)
            {
                string msgConflicto = string.Empty;

                if (progresoAnalisis.Archivo.Conflicto != null)
                    msgConflicto = progresoAnalisis.Archivo.Conflicto.ToString();

                DgvModuloLocal.Rows.Add(progresoAnalisis.Archivo.RutaParcial, 
                                        progresoAnalisis.Archivo.Kilobytes(), 
                                        progresoAnalisis.Archivo.EstatusServidor,
                                        msgConflicto);
                DgvModuloLocal.FirstDisplayedScrollingRowIndex = DgvModuloLocal.Rows.Count - 1;

                DataGridViewCellStyle estiloCeldaEstatus = DgvModuloLocal.Rows[DgvModuloLocal.RowCount - 1].Cells["estatus"].Style;

                switch(progresoAnalisis.Archivo.EstatusServidor)
                {
                    case "NUEVO":
                        estiloCeldaEstatus.BackColor = Color.Blue;
                        estiloCeldaEstatus.ForeColor = Color.White;
                        break;

                    case "MODIFICADO":
                        estiloCeldaEstatus.BackColor = Color.Yellow;
                        estiloCeldaEstatus.ForeColor = Color.Black;
                        break;

                    case "CONGELADO":
                        estiloCeldaEstatus.BackColor = Color.LightBlue;
                        estiloCeldaEstatus.ForeColor = Color.Black;
                        break;

                    case "SINCRONIZADO":
                        estiloCeldaEstatus.BackColor = Color.Green;
                        estiloCeldaEstatus.ForeColor = Color.White;
                        break;

                    case "EN CONFLICTO":
                        estiloCeldaEstatus.BackColor = Color.Red;
                        estiloCeldaEstatus.ForeColor = Color.White;
                        TotalConflictos++;
                        break;

                    case "BORRADO":
                        estiloCeldaEstatus.BackColor = Color.Orange;
                        estiloCeldaEstatus.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void BkgAnalizarCarpeta_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnalisisCompleto)
            {
                DgvModuloLocal.Sort(DgvModuloLocal.Columns["nombre_archivo"], ListSortDirection.Ascending);
                Progreso.Visible = false;
                string TiempoTranscurrido = ((Global.MillisegundosEpoch() - InicioTrabajo) / 1000.0).ToString("F2");
            
                if (TotalConflictos > 0)
                {
                    LblTotalConflictos.Text = TotalConflictos + " CONFLICTOS ENCONTRADOS";
                    LblTotalConflictos.Visible = true;
                    BtnSubir.Enabled = false;
                }
                else
                {
                    LblTotalConflictos.Visible = false;
                    BtnSubir.Enabled = true;
                }
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void BkgSubir_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgSubir.ReportProgress(0, "Comenzando a subir archivos..." + System.Environment.NewLine);
            try
            {
                InicioTrabajo = Global.MillisegundosEpoch();
                ProgresoSincronizacion prog = null;

                int i = 0;
                ArchivosLocales.ForEach(delegate(ArchivoSolidWorks archivo)
                {
                    if (!e.Cancel)
                    { 
                        string nombre = string.Empty;
                        string rutaParcial = string.Empty;
                        archivo.ClienteFtp = ClienteFtp;

                        if (Alcance == "PROYECTO")
                        {
                            string[] divisionesPath = archivo.RutaParcial.Split('\\');

                            if (divisionesPath.Count() > 0)
                            {
                                string strSubensamble = divisionesPath[1];

                                if (strSubensamble.Length == 2)
                                    Subensamble = Convert.ToInt32(strSubensamble);
                                else Subensamble = 0;
                            }
                            else Subensamble = 0;
                        }

                        string nombreDrawingSubensamble = "M" + IdProyecto.ToString().Replace(".", "_").PadLeft(6, '0');
                        nombreDrawingSubensamble += "-" + Subensamble.ToString().PadLeft(2, '0') + ".SLDDRW";
                        string nombreSubensamble = Path.ChangeExtension(nombreDrawingSubensamble, ".SLDASM");

                        BkgSubir.ReportProgress(Global.CalcularPorcentaje(i, ArchivosLocales.Count), archivo.Nombre.ToUpper() + "... ");

                        switch (archivo.EstatusServidor)
                        {
                            case "SINCRONIZADO":
                            case "CONGELADO":
                                swp.BuscarArchivo(IdProyecto, Subensamble, archivo.RutaParcial);
                                if (swp.TieneFilas())
                                {
                                    swp.Fila().ModificarCelda("estatus_sincronizacion", "SINCRONIZADO");
                                    swp.GuardarDatos();
                                }
                                archivo.SoloLectura(true);
                                break;

                            case "NUEVO":
                                //swp.RegistrarArchivo(IdProyecto, Subensamble, archivo);
                                try
                                {
                                    ClienteFtp.UploadFile(archivo.RutaCompleta, RaizFtp + archivo.RutaParcial, FtpExists.Overwrite, true, FtpVerify.Retry);

                                    if (ClienteFtp.FileExists(RaizFtp + archivo.RutaParcial))
                                    {
                                        //Si existe 1 o varios registros del mismo archivo los barramos y
                                        //creamos uno nuevo
                                        swp.ExisteRegistro(IdProyecto, Subensamble, archivo).ForEach(delegate (Fila f)
                                        {
                                            SolidWorksProyecto borrarRegistro = new SolidWorksProyecto();
                                            borrarRegistro.CargarDatos(Convert.ToInt32(f.Celda("id")));
                                            borrarRegistro.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                                            borrarRegistro.GuardarDatos();
                                        });

                                        swp.RegistrarArchivo(IdProyecto, Subensamble, archivo);
                                        archivo.EstatusServidor = "SINCRONIZADO";
                                        archivo.SoloLectura(true);
                                    }
                                    else
                                    {
                                        throw new System.ArgumentException("Error al subir el archivo " + archivo.RutaParcial + "  al servidor", "FluentFTP");
                                    }

                                }
                                catch (Exception ex)
                                {
                                    e.Cancel = true;
                                    //borramos todos lo creado en caso de error
                                    if (ClienteFtp.FileExists(RaizFtp + archivo.RutaParcial))
                                        ClienteFtp.DeleteFile(RaizFtp + archivo.RutaParcial);

                                    swp.ExisteRegistro(IdProyecto, Subensamble, archivo).ForEach(delegate (Fila f)
                                    {
                                        SolidWorksProyecto borrarRegistro = new SolidWorksProyecto();
                                        borrarRegistro.CargarDatos(Convert.ToInt32(f.Celda("id")));
                                        borrarRegistro.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                                        borrarRegistro.GuardarDatos();
                                    });

                                    MessageBox.Show("Falla al subir el archivo " + archivo.RutaParcial + ", se abortará el proceso. Verifica conexión a internet y vuelve a intentar", "Falla al subir archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;

                            case "MODIFICADO":
                                try
                                {
                                    // swp.ActualizarArchivo(IdProyecto, Subensamble, archivo.RutaParcial, archivo);
                                    archivo.BorrarArchivosCache(RaizFtp);
                                    ClienteFtp.UploadFile(archivo.RutaCompleta, RaizFtp + archivo.RutaParcial, FtpExists.Overwrite, true, FtpVerify.Retry);

                                    if (ClienteFtp.FileExists(RaizFtp + archivo.RutaParcial))
                                    {
                                        swp.ActualizarArchivo(IdProyecto, Subensamble, archivo.RutaParcial, archivo);

                                        archivo.EstatusServidor = "SINCRONIZADO";
                                        archivo.SoloLectura(true);
                                    }
                                    else
                                    {
                                        throw new System.ArgumentException("Error al modificar el archivo " + archivo.RutaParcial, "FluentFTP");
                                    }
                                }
                                catch
                                {
                                    e.Cancel = true;
                                    MessageBox.Show("Falla al modificar el archivo " + archivo.RutaParcial + ", se abortará el proceso. Verifica la conexión a internet y vuelve a intentar", "Falla al modificar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                
                                break;

                            case "BORRADO":
                                //swp.BorrarArchivo(IdProyecto, Subensamble, archivo.RutaParcial);
                                //archivo.BorrarArchivosCache(RaizFtp);
                                string rutaArchivoBorrar = RaizFtp + archivo.RutaParcial.Replace("\\", "/");
                                if (ClienteFtp.FileExists(rutaArchivoBorrar))
                                    ClienteFtp.DeleteFile(rutaArchivoBorrar);

                                if (!ClienteFtp.FileExists(rutaArchivoBorrar))
                                {
                                    swp.BorrarArchivo(IdProyecto, Subensamble, archivo.RutaParcial);
                                    archivo.BorrarArchivosCache(RaizFtp);
                                }
                                break;
                        }

                        string msg = "[OK]";
                        if (e.Cancel)
                            msg = "[ERROR]";

                        BkgSubir.ReportProgress(Global.CalcularPorcentaje(i, ArchivosLocales.Count), msg + System.Environment.NewLine);
                        prog = new ProgresoSincronizacion(i, archivo.EstatusServidor);
                        i++;
                        BkgSubir.ReportProgress(Global.CalcularPorcentaje(i, ArchivosLocales.Count), prog);
                        prog = null;
                    }
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnSubir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres enviar los cambios del módulo local al servidor?", "Sincronizar módulo con servidor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(resp != System.Windows.Forms.DialogResult.Yes)
            {
                TxtEstatus.AppendText("Sincronización cancelada por el usuario..." + System.Environment.NewLine);
                return;
            }
            
            BtnSubir.Enabled = false;
            BtnSalir.Enabled = false;
            Progreso.Visible = true;
            DgvModuloRemoto.Rows.Clear();
            BkgSubir.RunWorkerAsync();
        }

        private void BkgSubir_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
                ModuloSincronizado();
            else
            {
                Close();
            }
        }

        public void ModuloSincronizado()
        {
            Progreso.Visible = true;
            DgvModuloLocal.Rows.Clear();

            string msg = "Los archivos fueron sincronizados correctamente en el servidor. Tu copia local fue colocada en modo ";
            msg += "de sólo lectura; para volver a modificar el diseño obtén la versión más reciente utilizando la función Exportar.";
            MessageBox.Show(msg, "Archivos sincronizados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(Alcance == "MODULO")
            {
                // desbloquea el modulo
                ModuloCargado.Fila().ModificarCelda("bloqueo_mecanico", 0);
                ModuloCargado.GuardarDatos();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if(Alcance == "PROYECTO")
            {
                // desbloquea el proyecto
                Proyecto prj = new Proyecto();
                prj.CargarDatos(IdProyecto);
                prj.Fila().ModificarCelda("bloqueo_mecanico", 0);
                prj.GuardarDatos();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();

                // desbloquea modulos vinculados con el proyecto
                Modulo mod = new Modulo();
                mod.SeleccionarProyecto(IdProyecto);

                mod.Filas().ForEach(delegate(Fila f)
                {
                    f.ModificarCelda("bloqueo_mecanico", 0);
                });
                mod.GuardarDatos();
            } 
            
            for (int i = 0; i < ArchivosLocales.Count; ++i)
            {
                ArchivosLocales[i] = null;
            }
            ArchivosLocales = null;
            
            Close();
        }

        private void BkgSubir_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoSincronizacion progresoSincronizacion = null;
            
            if(e.UserState is ProgresoSincronizacion)
            {
                progresoSincronizacion = (ProgresoSincronizacion)e.UserState;

                DgvModuloLocal.Rows[progresoSincronizacion.IndiceArchivoLocal].Cells["estatus"].Value = progresoSincronizacion.EstatusServidor;
                DgvModuloLocal.Rows[progresoSincronizacion.IndiceArchivoLocal].Cells["estatus"].Style.BackColor = Color.Green;
                DgvModuloLocal.Rows[progresoSincronizacion.IndiceArchivoLocal].Cells["estatus"].Style.ForeColor = Color.White;
                DgvModuloLocal.FirstDisplayedScrollingRowIndex = progresoSincronizacion.IndiceArchivoLocal;
            }
            else if(e.UserState is string)
            {
                TxtEstatus.AppendText(e.UserState.ToString());
            }
            Progreso.Value = e.ProgressPercentage;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ArchivosLocales.Count; ++i)
            {
                ArchivosLocales[i] = null;
            }
            ArchivosLocales = null;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void TxtCarpetaLocal_TextChanged(object sender, EventArgs e)
        {
            BtnSubir.Enabled = TxtCarpetaLocal.Text != "";
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmSubirDiseno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SW != null && CerrarSesionSW)
                SW.Terminar();
        }

        private void DgvModuloLocal_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string tipoArchivo = Path.GetExtension(DgvModuloLocal.SelectedRows[0].Cells["nombre_archivo"].Value.ToString());
            string celdaEstatus = DgvModuloLocal.SelectedRows[0].Cells["estatus"].Value.ToString();

            if (tipoArchivo != ".SLDASM")
            {
                if (celdaEstatus == "MODIFICADO" || celdaEstatus == "EN CONFLICTO")
                    compararToolStripMenuItem.Enabled = true;
                else
                    compararToolStripMenuItem.Enabled = false;
            }

            if (celdaEstatus == "BORRADO")
                recuperarToolStripMenuItem.Enabled = true;
            else
                recuperarToolStripMenuItem.Enabled = false;

            DgvModuloLocal.ContextMenuStrip = OpcionesCambios;
        }

        private void compararToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pathArchivoLocal = string.Empty;
            string pathArchivoRemoto = string.Empty;
            string rutaParcial = string.Empty;
            string estatusArchivo = string.Empty;

            if(DgvModuloLocal.SelectedRows.Count == 0)
                return;

            rutaParcial = DgvModuloLocal.SelectedRows[0].Cells["nombre_archivo"].Value.ToString();
            estatusArchivo = DgvModuloLocal.SelectedRows[0].Cells["estatus"].Value.ToString();

            pathArchivoRemoto = RaizFtp + rutaParcial;

            if (Alcance == "MODULO")
                pathArchivoLocal = Path.GetDirectoryName(CarpetaLocal) + rutaParcial;
            else if(Alcance == "PROYECTO")
                pathArchivoLocal = CarpetaLocal + rutaParcial;

            FrmCompararSolidWorks comparar = new FrmCompararSolidWorks(pathArchivoLocal, pathArchivoRemoto, estatusArchivo, ClienteFtp, SW);
            
            if(comparar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(estatusArchivo == "EN CONFLICTO")
                {
                    TotalConflictos--;
                    LblTotalConflictos.Text = TotalConflictos + " CONFLICTOS ENCONTRADOS";
                }

                DgvModuloLocal.SelectedRows[0].Cells["estatus"].Value = comparar.EstatusArchivo;
                DgvModuloLocal.SelectedRows[0].Cells["tamano"].Value = comparar.Kilobytes;
                DgvModuloLocal.SelectedRows[0].Cells["conflicto"].Value = "";
                DgvModuloLocal.SelectedRows[0].Cells["estatus"].Style.BackColor = Color.Green;
                DgvModuloLocal.SelectedRows[0].Cells["estatus"].Style.ForeColor = Color.White;
            }
        }

        private void recuperarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recuperarToolStripMenuItem.Enabled = false;
            string rutaParcial = string.Empty;

            if (DgvModuloLocal.SelectedRows.Count == 0)
                return;

            rutaParcial = DgvModuloLocal.SelectedRows[0].Cells["nombre_archivo"].Value.ToString();

            if (Alcance == "MODULO")
                recuperarArchivoPathLocal = Path.GetDirectoryName(CarpetaLocal) + rutaParcial;
            else if (Alcance == "PROYECTO")
                recuperarArchivoPathLocal = CarpetaLocal + rutaParcial;

            recuperarArchivoPathRemoto = RaizFtp + rutaParcial;

            string msg = "¿Seguro que quieres recuperar el archivo '" + Path.GetFileName(rutaParcial) + "'?";
            DialogResult resp = MessageBox.Show(msg, "Recuperar archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            TxtEstatus.AppendText("Recuperando archivo '" + Path.GetFileName(rutaParcial) + "'... ");
            BkgRecuperarArchivo.RunWorkerAsync();
        }

        private void BkgRecuperarArchivo_DoWork(object sender, DoWorkEventArgs e)
        {
            ClienteFtp.DownloadFile(recuperarArchivoPathLocal, recuperarArchivoPathRemoto, true, FtpVerify.Retry);
        }

        private void BkgRecuperarArchivo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TxtEstatus.AppendText("[OK]" + System.Environment.NewLine);
            DgvModuloLocal.SelectedRows[0].Cells["estatus"].Value = "SINCRONIZADO";
            DgvModuloLocal.SelectedRows[0].Cells["tamano"].Value = "?";
            DgvModuloLocal.SelectedRows[0].Cells["conflicto"].Value = "";
            DgvModuloLocal.SelectedRows[0].Cells["estatus"].Style.BackColor = Color.Green;
            DgvModuloLocal.SelectedRows[0].Cells["estatus"].Style.ForeColor = Color.White;
            recuperarToolStripMenuItem.Enabled = true;
        }

        private void LblTotalConflictos_TextChanged(object sender, EventArgs e)
        {
            if(TotalConflictos <= 0)
            {
                LblTotalConflictos.Visible = false;
                BtnSubir.Enabled = true;
            }
            else
            {
                LblTotalConflictos.Visible = true;
                BtnSubir.Enabled = false;
            }
        }
    }

    public class ProgresoAnalisisCarpeta
    {
        public string Mensaje;
        public ArchivoSolidWorks Archivo;

        public ProgresoAnalisisCarpeta(string mensaje, ArchivoSolidWorks archivo)
        {
            Mensaje = mensaje;
            Archivo = archivo;
        }
    }

    public class ProgresoSincronizacion
    {
        public int IndiceArchivoLocal;
        public string EstatusServidor;

        public ProgresoSincronizacion(int indice, string estatusServidor)
        {
            IndiceArchivoLocal = indice;
            EstatusServidor = estatusServidor;
        }
    }

}

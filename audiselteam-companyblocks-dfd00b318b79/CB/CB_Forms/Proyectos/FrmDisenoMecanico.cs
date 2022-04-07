using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.Classes;
using System.IO;
using FluentFTP;
using System.Net;
using System.Management;

namespace CB
{
    public partial class FrmDisenoMecanico : Form
    {
        decimal IdProyecto = 0;
        string RaizFtp = string.Empty;
        string RaizProyecto = string.Empty;
        string StrProyecto = string.Empty;
        string UsuarioBloqueoMecanico = string.Empty;
        string FechaBloqueoMecanico = string.Empty;
        int BloqueoMecanicoDiseno = 0;
        FrmBajarDiseno VentanaBajarDiseno = null;
        SolidWorksAPI SW = null;
        List<ManagementObject> ProcesosSolidWorks = new List<ManagementObject>();
        FtpClient ClienteFtp = new FtpClient();

        bool FtpConectado = false;
        bool BloqueoMecanico = false;
        bool DisenoLiberado = false;
        bool SoloLectura = false;
        bool BloqueoParcial = false;
        bool LiberacionParcial = false;
        int ModulosAprobados = 0;

        public FrmDisenoMecanico(decimal idProyecto)
        {
            InitializeComponent();
            IdProyecto = idProyecto;
            StrProyecto = IdProyecto.ToString("F2").PadLeft(6, '0').Replace(".", "_");
            RaizProyecto = "/M" + StrProyecto;
            RaizFtp = StrProyecto + RaizProyecto;
            BtnLiberar.Enabled = Global.VerificarPrivilegio("PROYECTOS", "LIBERAR PROYECTO");
        }

        private void FrmDisenoMecanico_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            SplitEstatusDiseno.Panel1Collapsed = true;
            Proyecto prj = new Proyecto();
            prj.CargarDatos(IdProyecto);
            LblTitulo.Text = "DISEÑO MECANICO DEL PROYECTO " + IdProyecto.ToString("F2") + " - " + prj.Fila().Celda("nombre");
            BkgInicializarDiseno.RunWorkerAsync();

            BtnBajar.Enabled = Global.VerificarPrivilegio("DISEÑO", "BAJAR PROYECTO");
            BtnSubir.Enabled = Global.VerificarPrivilegio("DISEÑO", "SUBIR PROYECTO");
        }

        public void AgregarElementoArbolDiseno(Fila archivoActual)
        {
            string rutaParcial = archivoActual.Celda("nombre_archivo").ToString();
            string estatusRevision = archivoActual.Celda("estatus_revision").ToString();
            string estatusAprobacion = archivoActual.Celda("estatus_aprobacion").ToString();
            string estatusSincronizacion = archivoActual.Celda("estatus_sincronizacion").ToString();
            
            List<string> elementos = rutaParcial.Split('\\').ToList();

            if (elementos.Count == 0)
                return;

            elementos.Remove("");

            string idSiguienteNodo = String.Empty;
            string idUltimoNodo = string.Empty;
            TreeNode UltimoNodo = null;
            TreeNode[] Nodos = null;
            bool bloqueoMecanicoParcial = false;
            bool moduloAprobado = false;
            string bloqueoParcialUsuario = "";

            elementos.ForEach(delegate(string siguienteNodo)
            {
                idSiguienteNodo = idUltimoNodo + "\\" + siguienteNodo;
                Nodos = TvDiseno.Nodes.Find(idSiguienteNodo, true);
                string extension = Path.GetExtension(siguienteNodo).ToLower();

                // Bloqueo y aprobacion del modulo
                int subensamble = 0;
                if (int.TryParse(siguienteNodo, out subensamble))
                {
                    Modulo mod = new Modulo();
                    mod.SeleccionarProyectoSubensamble(IdProyecto, subensamble);
                    if (mod.TieneFilas())
                    {
                        moduloAprobado = mod.Fila().Celda("estatus_aprobacion").ToString() == "APROBADO";
                        bloqueoMecanicoParcial = Convert.ToBoolean(mod.Fila().Celda("bloqueo_mecanico").ToString());
                        bloqueoParcialUsuario = mod.Fila().Celda("usuario_bloqueo_mecanico").ToString();
                    }
                }

                if (Nodos.Length == 0)
                {
                    if (UltimoNodo == null)
                        UltimoNodo = TvDiseno.Nodes.Add(idSiguienteNodo, siguienteNodo);
                    else
                        UltimoNodo = UltimoNodo.Nodes.Add(idSiguienteNodo, siguienteNodo);

                    if (extension == string.Empty)
                    {
                        if ((BloqueoMecanicoDiseno > 0 || bloqueoMecanicoParcial) && (UltimoNodo.Text == subensamble.ToString().PadLeft(2, '0')))
                        {
                            UltimoNodo.ImageIndex = 10;
                            UltimoNodo.SelectedImageIndex = 10;

                            //agregar tooltip
                            //bloqueo Mecanico
                            if (BloqueoMecanicoDiseno > 0)
                                UltimoNodo.ToolTipText = "Diseño bloqueado por " + UsuarioBloqueoMecanico.ToTitleCase();
                            //bloqueo parcial
                            else if (bloqueoMecanicoParcial)
                                UltimoNodo.ToolTipText = "Parcialmente bloqueado por " + bloqueoParcialUsuario.ToTitleCase();

                            TvDiseno.ShowNodeToolTips = true;
                        }
                        else if(moduloAprobado && (UltimoNodo.Text == subensamble.ToString().PadLeft(2, '0')))
                        {
                            UltimoNodo.ImageIndex = 11;
                            UltimoNodo.SelectedImageIndex = 11;
                        }
                        else
                        {
                            UltimoNodo.ImageIndex = 0;
                            UltimoNodo.SelectedImageIndex = 0;
                        }
                    }
                    else
                    {
                        ConfigurarIconoSolidWorks(UltimoNodo, extension, estatusRevision, estatusAprobacion, estatusSincronizacion);
                    }
                    idUltimoNodo = UltimoNodo.Name;
                }
                else
                {
                    UltimoNodo = Nodos[0];
                    idUltimoNodo = Nodos[0].Name;
                    ConfigurarIconoSolidWorks(UltimoNodo, extension, estatusRevision, estatusAprobacion, estatusSincronizacion);
                }
            });
        }

        public void ConfigurarIconoSolidWorks(TreeNode nodo, string extension, string estatusRevision, string estatusAprobacion, string estatusSincronizacion)
        {
            switch (extension)
            {
                case ".sldprt":
                    if (estatusSincronizacion == "SINCRONIZADO")
                    {
                        nodo.ImageIndex = 1;
                        nodo.SelectedImageIndex = 1;
                    }
                    else if (estatusSincronizacion == "MODIFICADO")
                    {
                        nodo.ImageIndex = 8;
                        nodo.SelectedImageIndex = 8;
                    }
                    else if (estatusSincronizacion == "NUEVO")
                    {
                        nodo.ImageIndex = 9;
                        nodo.SelectedImageIndex = 9;
                    }
                    break;

                case ".sldasm":
                    nodo.ImageIndex = 2;
                    nodo.SelectedImageIndex = 2;
                    break;

                case ".slddrw":
                    if (estatusRevision == "PENDIENTE")
                    {
                        nodo.ImageIndex = 4;
                        nodo.SelectedImageIndex = 4;
                    }
                    else if (estatusRevision == "RECHAZADO")
                    {
                        nodo.ImageIndex = 5;
                        nodo.SelectedImageIndex = 5;
                    }
                    else if (estatusRevision == "ACEPTADO")
                    {
                        if(estatusAprobacion == "PENDIENTE")
                        {
                            nodo.ImageIndex = 6;
                            nodo.SelectedImageIndex = 6;
                        }
                        else if(estatusAprobacion == "APROBADO")
                        {
                            nodo.ImageIndex = 7;
                            nodo.SelectedImageIndex = 7;
                        }
                    }
                    else
                    {
                        nodo.ImageIndex = 3;
                        nodo.SelectedImageIndex = 3;
                    }
                    break;
            }
        }

        private void BkgDescargarDiseno_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Fila> archivosDiseno = SolidWorksProyecto.Modelo().SeleccionarProyecto(IdProyecto);
            int i = 0;
            string idProyectoDiseno = string.Empty;

            Proyecto proyectoDiseno = new Proyecto();
            Dictionary<string, object> parametrosProyecto = new Dictionary<string, object>();
            parametrosProyecto.Add("@id", IdProyecto.ToString("F2"));
            proyectoDiseno.SeleccionarDatos("id=@id", parametrosProyecto);
            if (proyectoDiseno.TieneFilas())
            {
                BloqueoMecanicoDiseno = Convert.ToInt32(proyectoDiseno.Fila().Celda("bloqueo_mecanico"));
                UsuarioBloqueoMecanico = proyectoDiseno.Fila().Celda("usuario_bloqueo_mecanico").ToString();
            }
            
            archivosDiseno.ForEach(delegate(Fila f)
            {
                i++;
                string nombre_archivo = f.Celda("nombre_archivo").ToString();
                nombre_archivo = RaizProyecto.Replace("/", "\\") + nombre_archivo;
                f.ModificarCelda("nombre_archivo", nombre_archivo);
                BkgDescargarDiseno.ReportProgress(Global.CalcularPorcentaje(i, archivosDiseno.Count()), f);
            });

            List<Fila> subproyectos = Proyecto.Modelo().Subproyectos(IdProyecto);

            subproyectos.ForEach(delegate(Fila subprj)
            {
                decimal idSubproyecto = Convert.ToDecimal(subprj.Celda("id"));

                archivosDiseno = SolidWorksProyecto.Modelo().SeleccionarProyecto(idSubproyecto);
                i = 0;
                archivosDiseno.ForEach(delegate(Fila f)
                {
                    i++;
                    string nombre_archivo = f.Celda("nombre_archivo").ToString();
                    string raizSubproyecto = "M" + idSubproyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0');
                    nombre_archivo = RaizProyecto.Replace("/", "\\") + "\\" + raizSubproyecto + nombre_archivo;
                    f.ModificarCelda("nombre_archivo", nombre_archivo);
                    BkgDescargarDiseno.ReportProgress(Global.CalcularPorcentaje(i, archivosDiseno.Count()), f);
                });
            });
        }

        private void BkgDescargarDiseno_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Fila f = (Fila)e.UserState;
            AgregarElementoArbolDiseno((Fila)e.UserState);
            ProgresoDiseno.Value = e.ProgressPercentage;
        }

        private void BkgDescargarDiseno_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TxtEstatusDiseno.AppendText("Datos de los archivos descargados correctamente!" + Environment.NewLine);
            ProgresoDiseno.Visible = false;

            Proyecto prj = new Proyecto();
            prj.CargarDatos(IdProyecto);

            BloqueoMecanico = Convert.ToBoolean(prj.Fila().Celda("bloqueo_mecanico"));
            UsuarioBloqueoMecanico = prj.Fila().Celda("usuario_bloqueo_mecanico").ToString();
            FechaBloqueoMecanico = Global.FechaATexto(prj.Fila().Celda("fecha_bloqueo_mecanico"));
            DisenoLiberado = prj.Fila().Celda("estatus_liberacion").ToString() == "LIBERADO";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", IdProyecto);
            parametros.Add("@estatus_aprobacion", "PENDIENTE");

            if (BloqueoMecanico)
            {
                LblEstatusProyecto.Text = "Diseño bloqueado por " + UsuarioBloqueoMecanico;
                LblEstatusProyecto.Text += " @ " + FechaBloqueoMecanico;
                LblEstatusProyecto.ForeColor = Color.Red;
                PicEstatusProyecto.Image = CB_Base.Properties.Resources.locked_48;

                if (Global.UsuarioActual.NombreCompleto() != UsuarioBloqueoMecanico)
                    BtnSubir.Enabled = false;
                else
                    BtnSubir.Enabled = Global.VerificarPrivilegio("DISEÑO", "SUBIR PROYECTO");
            }
            //else if(DisenoCongelado)
            //{
            //    LblEstatusProyecto.Text = "Diseño congelado";
            //    LblEstatusProyecto.ForeColor = Color.Black;
            //    PicEstatusProyecto.Image = CB_Base.Properties.Resources.ice_48; 
            //    BtnSubir.Enabled = false;
            //    BtnBajar.Enabled = Global.VerificarPrivilegio("DISEÑO", "BAJAR PROYECTO");
            //}
            else
            {
                ModulosAprobados = 0;
                Modulo mod = new Modulo();
                mod.SeleccionarProyecto(IdProyecto);

                mod.Filas().ForEach(delegate(Fila f)
                {
                    //bloqueo parcial
                    if (Convert.ToBoolean(f.Celda("bloqueo_mecanico")))
                        BloqueoParcial = true;

                    if (f.Celda("estatus_liberacion").ToString() == "LIBERADO")
                        LiberacionParcial = true;

                    if (f.Celda("estatus_aprobacion").ToString() == "APROBADO")
                        ModulosAprobados++;
                });

                if(BloqueoParcial)
                {
                    LblEstatusProyecto.Text = "Diseño bloqueado parcialmente";
                    LblEstatusProyecto.ForeColor = Color.Red;
                    BtnSubir.Enabled = false;
                    BtnBajar.Enabled = Global.VerificarPrivilegio("DISEÑO", "BAJAR PROYECTO");
                    PicEstatusProyecto.Image = CB_Base.Properties.Resources.locked_48;
                }
                else if(ModulosAprobados > 0)
                {
                    LblEstatusProyecto.Text = "Diseño congelado en " + ModulosAprobados + " módulos";
                    LblEstatusProyecto.ForeColor = Color.Black;
                    PicEstatusProyecto.Image = CB_Base.Properties.Resources.ice_48;
                    BtnSubir.Enabled = true;
                    BtnBajar.Enabled = Global.VerificarPrivilegio("DISEÑO", "BAJAR PROYECTO");
                }
                else if(LiberacionParcial)
                {
                    LblEstatusProyecto.Text = "Diseño liberado parcialmente por el cliente";
                    LblEstatusProyecto.ForeColor = Color.Black;
                    PicEstatusProyecto.Image = CB_Base.Properties.Resources.draft_48;
                    BtnSubir.Enabled = Global.VerificarPrivilegio("DISEÑO", "SUBIR PROYECTO");
                    BtnBajar.Enabled = Global.VerificarPrivilegio("DISEÑO", "BAJAR PROYECTO");
                }
                else
                {
                    LblEstatusProyecto.Text = "Diseño sin liberar por el cliente";
                    LblEstatusProyecto.ForeColor = Color.Black;
                    BtnBajar.Enabled = Global.VerificarPrivilegio("DISEÑO", "BAJAR PROYECTO");
                    BtnSubir.Enabled = Global.VerificarPrivilegio("DISEÑO", "SUBIR PROYECTO");
                    PicEstatusProyecto.Image = CB_Base.Properties.Resources.draft_48;
                }
            }
            LblEstatusProyecto.Visible = true;
            SoloLectura = (BloqueoMecanico && (Global.UsuarioActual.NombreCompleto() != UsuarioBloqueoMecanico)) || BloqueoParcial || (ModulosAprobados>0);
        }


     

        private void BkgInicializarDiseno_DoWork(object sender, DoWorkEventArgs e)
        {
            // Cierra cualquier proceso vinculado con solidworks
            ProcesosSolidWorks = Global.BuscarProcesos("sldworks");

            if (ProcesosSolidWorks.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("Estás a punto de conectarte con SolidWorks, asegúrate de guardar tus cambios y cerrar todos los archivos que tengas abiertos... cuando estés listo presiona OK.", "Conectando a SolidWorks", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (respuesta != System.Windows.Forms.DialogResult.OK)
                {
                    BkgInicializarDiseno.ReportProgress(100, "Conexión con SolidWorks cancelada por el usuario" + System.Environment.NewLine);
                    return;
                }
                BkgInicializarDiseno.ReportProgress(50, "Cerrando otras instancias de SolidWorks... ");
                Global.TerminarProcesos(ProcesosSolidWorks);
                System.Threading.Thread.Sleep(2000);
                BkgInicializarDiseno.ReportProgress(100, "[OK]" + System.Environment.NewLine);
            }      
            
            // Crear nueva conexion con SolidWorks
            BkgInicializarDiseno.ReportProgress(0, "Conectando con SolidWorks... ");
            SW = new SolidWorksAPI();

            // Verificar conexion con SolidWorks
            if (SW.Aplicacion == null)
                BkgInicializarDiseno.ReportProgress(50, "[ERROR]" + System.Environment.NewLine);
            else
                BkgInicializarDiseno.ReportProgress(0, "[OK]" + System.Environment.NewLine);

            // Conectar con servidor FTP
            BkgInicializarDiseno.ReportProgress(0, "Conectando con servidor FTP... ");
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

                BkgInicializarDiseno.ReportProgress(100, "[OK]" + System.Environment.NewLine);
                FtpConectado = true;
            }
            catch (Exception ex)
            {
                BkgInicializarDiseno.ReportProgress(100, "[ERROR]" + System.Environment.NewLine + ex.ToString());
                FtpConectado = false;
            }
        }
               
        private void BkgInicializarDiseno_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDiseno.Value = e.ProgressPercentage;
            TxtEstatusDiseno.AppendText(e.UserState.ToString());
        }

        private void BkgInicializarDiseno_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (FtpConectado)
            {
                SplitEstatusDiseno.Panel1Collapsed = false;
                TxtEstatusDiseno.Visible = false;
                BkgDescargarDiseno.RunWorkerAsync();
            }
        }

        private void BtnSubir_Click(object sender, EventArgs e)
        {
            if (VentanaBajarDiseno != null)
            {
                if (VentanaBajarDiseno.Visible)
                {
                    MessageBox.Show("Espera a terminar de bajar el diseño para continuar!", "Subir diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string carpetaProyecto = "M" + IdProyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0');
  

            if (BuscadorCarpetas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string carpetaSeleccionada = Path.GetFileName(BuscadorCarpetas.SelectedPath);
                string carpetaBase = Path.GetFileName(BuscadorCarpetas.SelectedPath);

                if (carpetaBase == carpetaProyecto && BuscadorCarpetas.SelectedPath != string.Empty)
                {
                    FrmSubirDiseno ventanaSubirDiseno = new FrmSubirDiseno(IdProyecto, 0, BuscadorCarpetas.SelectedPath, "PROYECTO", SW);

                    if (ventanaSubirDiseno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ProgresoDiseno.Visible = true;
                        TvDiseno.Nodes.Clear();
                        BkgDescargarDiseno.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("La carpeta seleccionada no coincide con el proyecto " + carpetaProyecto, "Carpeta equivocada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnSubir_Click(sender, e);
                }
            }
        }

        private void BtnBajar_Click(object sender, EventArgs e)
        {
            if(VentanaBajarDiseno != null)
            {
                if (VentanaBajarDiseno.Visible)
                {
                    MessageBox.Show("Ya estas bajando el diseño!", "Bajar diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string carpetaProyecto = "M" + IdProyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0');

            if (BloqueoMecanico)
            {
                string msg = "Este proyecto esta bloqueado por " + UsuarioBloqueoMecanico;
                msg += ", se descargará una copia en modo de sólo lectura.";
                DialogResult resp = MessageBox.Show(msg, "Proyecto bloqueado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (resp != System.Windows.Forms.DialogResult.OK)
                    return;
            }
            else if(BloqueoParcial)
            {
                string msg = "Este proyecto esta bloqueado parcialmente, se descargará una copia en modo de sólo lectura.";
                DialogResult resp = MessageBox.Show(msg, "Proyecto bloqueado parcialmente", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (resp != System.Windows.Forms.DialogResult.OK)
                    return;
            }
            else if(ModulosAprobados > 0)
            {
                string msg = ModulosAprobados + " módulos de este proyecto ya fueron aprobados y su diseño está congelado, se descargará una copia en modo de sólo lectura.";
                DialogResult resp = MessageBox.Show(msg, "Proyecto congelado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (resp != System.Windows.Forms.DialogResult.OK)
                    return;
            }

            if (BuscadorCarpetas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Path.GetFileName(BuscadorCarpetas.SelectedPath) == carpetaProyecto)
                {
                    VentanaBajarDiseno = new FrmBajarDiseno(ClienteFtp, BuscadorCarpetas.SelectedPath, RaizFtp, IdProyecto, 0, BloqueoMecanico, SoloLectura);
                    if(VentanaBajarDiseno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BkgDescargarDiseno.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("La carpeta seleccionada no corresponde al proyecto " + carpetaProyecto, "Carpeta equivocada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnBajar_Click(sender, e);
                }
            }
        }

        private void BtnLiberar_Click(object sender, EventArgs e)
        {
            if (BtnLiberar.ContextMenuStrip != null)
            {
                imprimirFormatoToolStripMenuItem.Enabled = !DisenoLiberado;
                liberarDisenoToolStripMenuItem.Enabled = !DisenoLiberado;
                evidenciaDeLiberacionToolStripMenuItem.Enabled = DisenoLiberado;
                BtnLiberar.ContextMenuStrip.Show(BtnLiberar, BtnLiberar.PointToClient(Cursor.Position));
            }
        }

        private void imprimirFormatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string carpetaSolidos = "C:\\CompanyBlocks\\Solidos";
            string strProyecto = IdProyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0');
            string strSubensamble = "00";
            carpetaSolidos += "\\M" + strProyecto;
            string rutaSubensamble = carpetaSolidos + "\\M" + strProyecto + "-" + strSubensamble + ".SLDASM";

            VentanaBajarDiseno = new FrmBajarDiseno(ClienteFtp, carpetaSolidos, RaizFtp, IdProyecto, 0, true, true);

            if (VentanaBajarDiseno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string msg = string.Empty;

                if (!File.Exists(rutaSubensamble))
                {
                    msg = "El subensamble '" + Path.GetFileName(rutaSubensamble) + "' no fue encontrado en el diseño, imposible generar vista previa.";
                    MessageBox.Show(msg, "Subensamble no existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmGenerarVistaPreviaSubensamble generarVistaPrevia = new FrmGenerarVistaPreviaSubensamble(rutaSubensamble, SW);

                if (generarVistaPrevia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if(generarVistaPrevia.VistaPrevia == null)
                    {
                        msg = "Ocurrió un error al generar la vista previa del subensamble, vuelve a intentarlo.";
                        MessageBox.Show(msg, "Error al generar vista previa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    FrmImprimirFormatoLiberacionDiseno imprimirLiberacion = new FrmImprimirFormatoLiberacionDiseno(generarVistaPrevia.VistaPrevia, IdProyecto, false);
                    imprimirLiberacion.Show();
                }
            }
        }

        private void FrmDisenoMecanico_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SW != null)
            {
                if (SW.Aplicacion != null)
                    SW.Terminar();
                ProcesosSolidWorks = Global.BuscarProcesos("sldworks");
                Global.TerminarProcesos(ProcesosSolidWorks);
            }
        }

        private void liberarDisenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLiberarDisenoMecanico liberar = new FrmLiberarDisenoMecanico(IdProyecto);

            if (liberar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BkgDescargarDiseno.RunWorkerAsync();
            }
        }

        private void evidenciaDeLiberacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!DisenoLiberado)
            {
                MessageBox.Show("El diseño fue liberado parcialmente, obtén la evidencia de liberación de cada módulo.", "Diseño liberado parcialmente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Proyecto prj = new Proyecto();
            prj.CargarDatos(IdProyecto);

            if(prj.TieneFilas())
            {
                int idEvidencia = Convert.ToInt32(prj.Fila().Celda("evidencia_liberacion"));

                if(idEvidencia > 0)
                {
                    EvidenciaLiberacionModulo evidencia = new EvidenciaLiberacionModulo();
                    evidencia.CargarDatos(idEvidencia);

                    if (evidencia.TieneFilas())
                    {
                        byte[] archivoEvidencia = (byte[])evidencia.Fila().Celda("archivo");

                        FrmVisorPDF visor = new FrmVisorPDF(archivoEvidencia, "EVIDENCIA DE LIBERACION DE DISEÑO MECANICO M" + IdProyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0') + "-00");
                        visor.Show();
                    }
                    else
                        MessageBox.Show("El archivo no fue encontrado!", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("El archivo no fue encontrado!", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("El proyecto no fue encontrado!", "Proyecto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void subirSubensamblePrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreSubensamble = "M" + IdProyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0') + "-00.SLDASM";
            BuscadorSubensamblePrincipal.FileName = nombreSubensamble;

            if(BuscadorSubensamblePrincipal.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                if(BuscadorSubensamblePrincipal.FileName != nombreSubensamble)
                {
                    MessageBox.Show("El archivo seleccionado no corresponde al subensamble principal del proyecto.", "Archivo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    subirSubensamblePrincipalToolStripMenuItem_Click(null, null);
                    return;
                }

            }
        }
    }
}

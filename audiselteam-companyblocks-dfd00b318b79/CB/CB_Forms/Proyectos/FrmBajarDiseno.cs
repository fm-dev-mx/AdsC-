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

namespace CB
{
    public partial class FrmBajarDiseno : Form
    {
        bool PausarDescarga = false;
        bool ErrorDescarga = false;
        bool BloqueoMecanico = false;
        decimal IdProyecto = 0;
        int Subensamble = 0;
        string CarpetaLocal = string.Empty;
        bool SoloLectura = false;
        List<Fila> archivosIndice = new List<Fila>();
        FtpClient ClienteFtp = null;
        string RaizFtp = string.Empty;

        public FrmBajarDiseno(FtpClient clienteFtp, string carpetaLocal, string raizFtp, decimal idProyecto, int subensamble=0, bool bloqueoMecanico=false, bool soloLectura=false)
        {
            InitializeComponent();
            CarpetaLocal = carpetaLocal;
            IdProyecto = idProyecto;
            Subensamble = subensamble;
            SoloLectura = soloLectura;
            ClienteFtp = clienteFtp;
            RaizFtp = raizFtp;
            BloqueoMecanico = bloqueoMecanico;
        }

        private void BkgBajarDiseno_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!BkgBajarDiseno.CancellationPending && !PausarDescarga)
            {
                ErrorDescarga = false;
                BkgBajarDiseno.ReportProgress(0, "Leyendo indice de la base de datos...");

                if (Subensamble == 0)
                    archivosIndice = SolidWorksProyecto.Modelo().SeleccionarProyecto(IdProyecto);
                else
                    archivosIndice = SolidWorksProyecto.Modelo().SeleccionarProyectoSubensamble(IdProyecto, Subensamble);
                ArchivoSolidWorks archivo = null;

                try
                {
                    int i = 1;
                    foreach(Fila f in archivosIndice)
                    {
                        while (PausarDescarga && !BkgBajarDiseno.CancellationPending) { }

                        if (BkgBajarDiseno.CancellationPending)
                            break;

                        string msg = f.Celda("nombre_archivo").ToString();
                        BkgBajarDiseno.ReportProgress(Global.CalcularPorcentaje(i - 1, archivosIndice.Count), msg);

                        string estatusArchivo = "";
                        string pathArchivo = string.Empty;

                        if (Subensamble == 0)
                            pathArchivo = CarpetaLocal + f.Celda("nombre_archivo").ToString();
                        else
                            pathArchivo = Path.GetDirectoryName(CarpetaLocal) + f.Celda("nombre_archivo").ToString();

                        archivo = new ArchivoSolidWorks();

                        // intentamos cargar el archivo desde la carpeta local
                        archivo.CargarMetadatos(pathArchivo, Path.GetDirectoryName(CarpetaLocal));
                        //archivo.CargarDatos();

                        // si el archivo existe en la carpeta local, determinamos su estatus en el server y habilitamos su escritura....
                        if (File.Exists(archivo.RutaCompleta))
                        {
                            estatusArchivo = archivo.DeterminarEstatusServidor(IdProyecto, Subensamble);
                            archivo.SoloLectura(false);
                        }

                        // si el archivo no existe en la carpeta local o, si el archivo fue modificado 
                        // en la copia local vs. servidor, descargamos del servidor y escribimos en la copia local
                        if (estatusArchivo == "" || estatusArchivo == "MODIFICADO")
                        {
                            if (ClienteFtp.FileExists(RaizFtp + f.Celda("nombre_archivo").ToString()))
                            {
                                (new FileInfo(pathArchivo)).Directory.Create();
                                ClienteFtp.DownloadFile(pathArchivo, RaizFtp + f.Celda("nombre_archivo").ToString());
                            }
                        }

                        // cargamos los metadatos del archivo nuevo o actualizado
                        archivo.CargarMetadatos(pathArchivo, Path.GetDirectoryName(CarpetaLocal));

                        if (File.Exists(archivo.RutaCompleta))
                        {
                            if (SoloLectura)
                                archivo.SoloLectura(true);
                            else
                                archivo.SoloLectura(false);
                        }
                        archivo = null;

                        BkgBajarDiseno.ReportProgress(Global.CalcularPorcentaje(i, archivosIndice.Count), msg);
                        i++;
                    }
                    archivo = null;
                    ErrorDescarga = false;
                }
                catch (Exception ex)
                {
                    ErrorDescarga = true;
                    archivo = null;
                    string msg = "Se produjo un error al intentar escribir los archivos, asegúrate de cerrar en SolidWorks el ensamble ";
                    msg += "y todas las piezas relacionadas con el módulo antes de volver a bajar los archivos." + Environment.NewLine;
                    msg += ex.ToString();
                    MessageBox.Show(msg, "Error al bajar los archivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BkgBajar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string archivoActual = string.Empty;

            if (e.UserState != null)
                archivoActual = e.UserState.ToString();

            LblProgreso.Text = "Bajando diseño mecánico... [" + e.ProgressPercentage + "%]";
            LblArchivoActual.Text = archivoActual;
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgBajar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ErrorDescarga)
            {
                // Verifica si el proyecto no tiene bloqueo mecanico y si el usuario tiene privilegio
                // para subir el proyecto para decidir si se aplica bloqueo
                if (!SoloLectura && !BloqueoMecanico && Global.VerificarPrivilegio("DISEÑO", "SUBIR PROYECTO"))
                {
                    if(Subensamble == 0)
                    {
                        // bloquea proyecto
                        Proyecto prj = new Proyecto();
                        prj.CargarDatos(IdProyecto);
                        prj.Fila().ModificarCelda("bloqueo_mecanico", 1);
                        prj.Fila().ModificarCelda("usuario_bloqueo_mecanico", Global.UsuarioActual.NombreCompleto());
                        prj.Fila().ModificarCelda("fecha_bloqueo_mecanico", DateTime.Now);
                        prj.GuardarDatos();

                        // bloquea modulos vinculados con el proyecto
                        Modulo mod = new Modulo();
                        mod.SeleccionarProyecto(IdProyecto);

                        mod.Filas().ForEach(delegate(Fila f)
                        {
                            f.ModificarCelda("bloqueo_mecanico", 1);
                            f.ModificarCelda("usuario_bloqueo_mecanico", Global.UsuarioActual.NombreCompleto());
                            f.ModificarCelda("fecha_bloqueo_mecanico", DateTime.Now);
                        });
                        mod.GuardarDatos();
                    }
                    else
                    {
                        Modulo ModuloCargado = new Modulo();
                        ModuloCargado.SeleccionarProyectoSubensamble(IdProyecto, Subensamble);
                        if (ModuloCargado.TieneFilas())
                        {
                            ModuloCargado.Fila().ModificarCelda("bloqueo_mecanico", 1);
                            ModuloCargado.Fila().ModificarCelda("usuario_bloqueo_mecanico", Global.UsuarioActual.NombreCompleto());
                            ModuloCargado.Fila().ModificarCelda("fecha_bloqueo_mecanico", DateTime.Now);
                            ModuloCargado.GuardarDatos();
                        }
                    }
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;

            Close();
        }

        private void FrmBajarDiseno_Load(object sender, EventArgs e)
        {
            BkgBajarDiseno.RunWorkerAsync();
        }

        public DialogResult Cancelar()
        {
            DialogResult cancelar = MessageBox.Show("Seguro que quieres cancelar la descarga?", "Cancelar descarga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cancelar == System.Windows.Forms.DialogResult.Yes)
            {
                BkgBajarDiseno.CancelAsync();
            }
            
            return cancelar;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmBajarDiseno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Progreso.Value == 100 || ErrorDescarga)
                return;

            PausarDescarga = true;
            if (Cancelar() == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            else
            {
                e.Cancel = true;
                PausarDescarga = false;
            }
        }

    }
}

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
using FluentFTP;
using System.IO;
using SolidWorks.Interop.swconst;

namespace CB
{
    public partial class FrmCompararSolidWorks : Ventana
    {
        public string Kilobytes = string.Empty;
        public string EstatusArchivo = string.Empty;
        byte[] VistaPreviaLocal = null;
        byte[] VistaPreviaRemota = null;
        string TipoArchivo = string.Empty;
        string NombreArchivo = string.Empty;
        string PathArchivoLocal = string.Empty;
        string PathArchivoRemoto = string.Empty;
        string PathTemporalSolido = string.Empty;
        string PathTemporalDrawing = string.Empty;
        SolidWorksAPI SW = null;
        swStandardViews_e Vista = swStandardViews_e.swIsometricView;
        FtpClient ClienteFtp = null;

        public FrmCompararSolidWorks(string pathArchivoLocal, string pathArchivoRemoto, string estatusArchivo, FtpClient clienteFtp, SolidWorksAPI sw)
        {
            InitializeComponent();
            PathArchivoLocal = pathArchivoLocal;
            PathArchivoRemoto = pathArchivoRemoto;
            ClienteFtp = clienteFtp;
            SW = sw; 
            NombreArchivo = Path.GetFileName(PathArchivoRemoto);
            TipoArchivo = Path.GetExtension(PathArchivoRemoto).ToUpper();
            LblNombreArchivo.Text = NombreArchivo;
            EstatusArchivo = estatusArchivo;

            if (TipoArchivo == ".SLDDRW")
            {
                CmbVista.Visible = false;
                LblVista.Visible = false;
            }
            CmbVista.Enabled = false;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmCompararSolidWorks_Load(object sender, EventArgs e)
        {
            TxtEstatus.AppendText("Descargando archivos... ");
            Progreso.Visible = true;
            BkgDescargarArchivos.RunWorkerAsync();

            LblEstatus.Text = EstatusArchivo;
            switch(EstatusArchivo)
            {
                case "MODIFICADO":
                    LblEstatus.BackColor = Color.Yellow;
                    LblEstatus.ForeColor = Color.Black;
                    break;

                case "SINCRONIZADO":
                    LblEstatus.BackColor = Color.Green;
                    LblEstatus.ForeColor = Color.White;
                    break;

                case "EN CONFLICTO":
                    LblEstatus.BackColor = Color.Red;
                    LblEstatus.ForeColor = Color.White;
                    break;
            }
        }

        public void DescargarArchivoRemoto(BackgroundWorker bkg)
        {
            bkg.ReportProgress(0);
            if(TipoArchivo == ".SLDPRT")
            {
                bkg.ReportProgress(50);
                PathTemporalSolido = Path.GetTempPath() + NombreArchivo;

                // descargar solido unicamente
                ClienteFtp.DownloadFile(PathTemporalSolido, PathArchivoRemoto, true, FtpVerify.Retry);
                bkg.ReportProgress(100);
            }
            else if(TipoArchivo == ".SLDDRW")
            {
                PathTemporalDrawing = Path.GetTempPath() + NombreArchivo;
                PathTemporalSolido = Path.GetTempPath() + Path.ChangeExtension(NombreArchivo, "SLDPRT");

                // descargar drawing
                ClienteFtp.DownloadFile(PathTemporalDrawing, PathArchivoRemoto, true, FtpVerify.Retry);

                // descargar solido
                ClienteFtp.DownloadFile(PathTemporalSolido, Path.ChangeExtension(PathArchivoRemoto, "SLDPRT"), true, FtpVerify.Retry);
            }
        }

        private void BkgDescargarArchivos_DoWork(object sender, DoWorkEventArgs e)
        {
            DescargarArchivoRemoto(BkgDescargarArchivos);
        }

        private void BkgDescargarArchivos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgDescargarArchivos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progreso.Visible = false;
            TxtEstatus.AppendText("[OK]" + Environment.NewLine);
            if (TipoArchivo == ".SLDPRT")
                CmbVista.Enabled = true;
            else
            {
                Progreso.Visible = true;
                TxtEstatus.AppendText("Generando vista previa... ");
                BkgGenerarVistasPrevias.RunWorkerAsync();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void FrmCompararSolidWorks_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete(PathTemporalDrawing);
                File.Delete(PathTemporalSolido);
            }
            catch (Exception ex) 
            {
                TxtEstatus.AppendText(ex.ToString() + Environment.NewLine);
            }
        }

        private void BkgGenerarVistasPrevias_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BkgGenerarVistasPrevias.ReportProgress(0);
                if (TipoArchivo == ".SLDPRT")
                {
                    SW.VistaPrevia(PathTemporalSolido, swDocumentTypes_e.swDocPART, out VistaPreviaRemota, Vista);
                    BkgGenerarVistasPrevias.ReportProgress(50);
                    SW.VistaPrevia(PathArchivoLocal, swDocumentTypes_e.swDocPART, out VistaPreviaLocal, Vista);
                    BkgGenerarVistasPrevias.ReportProgress(100);
                }
                else if (TipoArchivo == ".SLDDRW")
                {
                    byte[] pdfLocal = null;
                    byte[] pdfRemoto = null;

                    SW.DrawingAPDF(PathArchivoLocal, out pdfLocal);

                    if(pdfLocal != null)
                        File.WriteAllBytes(Path.GetTempPath() + "pdfLocal.pdf", pdfLocal);
                    else
                    {
                        MessageBox.Show("Error al generar vista previa del archivo local.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BtnConservarArchivoLocal.Enabled = false;
                    }

                    BkgGenerarVistasPrevias.ReportProgress(25);

                    SW.DrawingAPDF(PathTemporalDrawing, out pdfRemoto);

                    if(pdfRemoto != null)
                        File.WriteAllBytes(Path.GetTempPath() + "pdfRemoto.pdf", pdfRemoto);
                    else
                    {
                        MessageBox.Show("Error al generar vista previa del archivo remoto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BtnConservarArchivoRemoto.Enabled = false;
                    }
                    
                    BkgGenerarVistasPrevias.ReportProgress(50);

                    VistaPreviaLocal = FormatosPDF.MiniaturaPDF(Path.GetTempPath() + "pdfLocal.pdf", 0, 0, 300);
                    BkgGenerarVistasPrevias.ReportProgress(75);

                    VistaPreviaRemota = FormatosPDF.MiniaturaPDF(Path.GetTempPath() + "pdfRemoto.pdf", 0, 0, 300);
                    BkgGenerarVistasPrevias.ReportProgress(100);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BkgGenerarVistasPrevias_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgGenerarVistasPrevias_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MemoryStream msLocal = null;
                MemoryStream msRemota = null;

                if(VistaPreviaLocal != null)
                    msLocal = new MemoryStream(VistaPreviaLocal);

                if(VistaPreviaRemota != null)
                    msRemota = new MemoryStream(VistaPreviaRemota);

                if (msLocal != null)
                    PicArchivoLocal.Image = Image.FromStream(msLocal);

                if (msRemota != null)
                    PicArchivoRemoto.Image = Image.FromStream(msRemota);

                if (TipoArchivo != ".SLDDRW")
                    CmbVista.Enabled = true;

                Progreso.Visible = false;

                if(msRemota != null && msLocal != null)
                    TxtEstatus.AppendText("[OK]" + Environment.NewLine);
                else
                    TxtEstatus.AppendText("[ERROR]" + Environment.NewLine);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CmbVista_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CmbVista.Text)
            {
                case "ISOMETRICO":
                default:
                    Vista = swStandardViews_e.swIsometricView;
                    break;

                case "FRONTAL":
                    Vista = swStandardViews_e.swFrontView;
                    break;

                case "LATERAL IZQUIERDA":
                    Vista = swStandardViews_e.swLeftView;
                    break;

                case "LATERAL DERECHA":
                    Vista = swStandardViews_e.swRightView;
                    break;

                case "INFERIOR":
                    Vista = swStandardViews_e.swBottomView;
                    break;

                case "POSTERIOR":
                    Vista = swStandardViews_e.swBackView;
                    break;
            }

            Progreso.Visible = true;
            CmbVista.Enabled = false;
            TxtEstatus.AppendText("Generando vista previa... ");
            BkgGenerarVistasPrevias.RunWorkerAsync();
        }

        private void BtnConservarArchivoLocal_Click(object sender, EventArgs e)
        {
            string msg = "¿Seguro que quieres sobreescribir el archivo en el servidor?" + Environment.NewLine + Environment.NewLine;
            msg += "ATENCION!" + Environment.NewLine + Environment.NewLine;
            msg += "Es probable que se genere un problema si ya se envió a producción un plano .PDF correspondiente a este archivo " + TipoArchivo + " ";
            msg += "y este último sufrió modificaciones geométricas.";


            DialogResult respuesta = MessageBox.Show(msg, "Conservar archivo local", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != System.Windows.Forms.DialogResult.Yes)
                return;

            TxtEstatus.AppendText("Sobreescribiendo archivo en el servidor con el archivo local... ");

            // subir archivo local al servidor (sobreescribir)
            ClienteFtp.UploadFile(PathArchivoLocal, PathArchivoRemoto, FtpExists.Overwrite, true, FtpVerify.Retry);

            // cargar metadatos del archivo local
            ArchivoSolidWorks archivo = new ArchivoSolidWorks();
            archivo.CargarMetadatos(PathArchivoLocal, PathArchivoLocal);
            Kilobytes = archivo.Kilobytes();

            // reflejar cambios en el indice de la base de datos
            SolidWorksProyecto swp = new SolidWorksProyecto();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre_archivo", NombreArchivo);
            swp.SeleccionarDatos("nombre_archivo LIKE '%" + NombreArchivo +"'", parametros);

            if(swp.TieneFilas())
            {
                swp.Fila().ModificarCelda("checksum_md5", archivo.ChecksumMd5);
                swp.Fila().ModificarCelda("kilobytes", Kilobytes);
                swp.GuardarDatos();
            }
            EstatusArchivo = "SINCRONIZADO";

            TxtEstatus.AppendText("[OK]" + Environment.NewLine);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnConservarArchivoRemoto_Click(object sender, EventArgs e)
        {
            string msg = "¿Seguro que quieres sobreescribir el archivo local?" + Environment.NewLine + Environment.NewLine;
            msg += "ATENCION!" + Environment.NewLine + Environment.NewLine;
            msg += "Toma en cuenta que se perderán los cambios realizados y no podrán recuperarse.";

            DialogResult respuesta = MessageBox.Show(msg, "Conservar archivo remoto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != System.Windows.Forms.DialogResult.Yes)
                return;

            TxtEstatus.AppendText("Sobreescribiendo archivo local... ");

            // cargar metadatos del archivo local
            ArchivoSolidWorks archivo = new ArchivoSolidWorks();
            archivo.CargarMetadatos(PathArchivoLocal, PathArchivoLocal);
            archivo.SoloLectura(false);
            Kilobytes = archivo.Kilobytes();

            // sobreescribir archivo local
            ClienteFtp.DownloadFile(PathArchivoLocal, PathArchivoRemoto, true, FtpVerify.Retry);

            EstatusArchivo = "SINCRONIZADO";
            TxtEstatus.AppendText("[OK]" + Environment.NewLine);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

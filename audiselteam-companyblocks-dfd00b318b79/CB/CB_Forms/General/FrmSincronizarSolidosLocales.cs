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

namespace CB
{
    public partial class FrmSincronizarSolidosLocales : Form
    {
        FtpClient ClienteFtp = new FtpClient();
        List<Fila> IndiceArchivosRemotos = new List<Fila>();
        List<ArchivoSolidWorks> ArchivosLocales = new List<ArchivoSolidWorks>();
        decimal Proyecto = 0;
        string RaizProyecto = string.Empty;
        string RaizFtp = string.Empty;
        string StrProyecto = string.Empty;
        int TotalSincronizados = 0;
        int TotalModificados = 0;
        int TotalSinDescargar = 0;

        public FrmSincronizarSolidosLocales(decimal proyecto, string raizProyecto)
        {
            InitializeComponent();
            Proyecto = proyecto;
            RaizProyecto = raizProyecto;
            StrProyecto = proyecto.ToString("F2").Replace('.', '_').PadLeft(6, '0');
            RaizFtp = StrProyecto + "\\M" + StrProyecto + "\\"; 
        }

        private void FrmSincronizarArchivosFabricacion_Load(object sender, EventArgs e)
        {
            TxtEstatus.AppendText("Analizando carpeta local... ");
            BkgDescargarIndice.RunWorkerAsync();
        }

        private void BkgDescargarIndice_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", Proyecto);
            IndiceArchivosRemotos = SolidWorksProyecto.Modelo().SeleccionarDatos("proyecto=@proyecto", parametros, "*", BkgDescargarIndice);
        }

        private void BkgDescargarIndice_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgDescargarIndice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progreso.Value = 0;
            BkgAnalizarArchivos.RunWorkerAsync();
        }

        private void BkgAnalizarArchivos_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            IndiceArchivosRemotos.ForEach(delegate(Fila f)
            {
                BkgAnalizarArchivos.ReportProgress(Global.CalcularPorcentaje(i, IndiceArchivosRemotos.Count), null);

                string nombreArchivo = f.Celda("nombre_archivo").ToString();
                string checksumMd5 = f.Celda("checksum_md5").ToString();
                string kilobytes = f.Celda("kilobytes").ToString();

                ArchivoSolidWorks archivo = new ArchivoSolidWorks();
                archivo.CargarMetadatos(RaizProyecto + nombreArchivo, RaizProyecto);

                if(File.Exists(archivo.RutaCompleta))
                {
                    if (archivo.ChecksumMd5 == checksumMd5)
                    {
                        archivo.EstatusServidor = "SINCRONIZADO";
                        TotalSincronizados++;
                    }
                    else
                    {
                        archivo.EstatusServidor = "MODIFICADO";
                        TotalModificados++;
                    }
                }
                else
                {
                    archivo.EstatusServidor = "SIN DESCARGAR";
                    TotalSinDescargar++;
                }

                ArchivosLocales.Add(archivo);
                i++;
                BkgAnalizarArchivos.ReportProgress(Global.CalcularPorcentaje(i, IndiceArchivosRemotos.Count), archivo);
            });
        }

        private void BkgAnalizarArchivos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value = e.ProgressPercentage;
            if (e.UserState == null)
                return;

            ArchivoSolidWorks archivo = (ArchivoSolidWorks)e.UserState;
            DgvSincronizacion.Rows.Add(archivo.RutaParcial, archivo.EstatusServidor);

            DataGridViewCellStyle estiloCeldaEstatus = DgvSincronizacion.Rows[DgvSincronizacion.RowCount-1].Cells["estatus"].Style;
            switch (archivo.EstatusServidor)
            {
                case "SIN DESCARGAR":
                    estiloCeldaEstatus.BackColor = Color.Gray;
                    estiloCeldaEstatus.ForeColor = Color.White;
                    break;

                case "SINCRONIZADO":
                    estiloCeldaEstatus.BackColor = Color.Green;
                    estiloCeldaEstatus.ForeColor = Color.White;
                    break;

                case "MODIFICADO":
                    estiloCeldaEstatus.BackColor = Color.Yellow;
                    estiloCeldaEstatus.ForeColor = Color.Black;
                    break;
            }
        }

        private void BkgAnalizarArchivos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TxtEstatus.AppendText("[OK]" + Environment.NewLine);
            Progreso.Value = 0;

            if (TotalSinDescargar > 0 || TotalModificados > 0)
            {
                BkgDescargarArchivos.RunWorkerAsync();
            }
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BkgDescargarArchivos_DoWork(object sender, DoWorkEventArgs e)
        {
            // Realizar conexion FTP
            BkgDescargarArchivos.ReportProgress(50, "Conectando con servidor FTP... ");

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
                BkgDescargarArchivos.ReportProgress(100, "[OK]" + System.Environment.NewLine);
            }
            catch (Exception ex)
            {
                BkgDescargarArchivos.ReportProgress(100, "[ERROR]" + System.Environment.NewLine + ex.ToString() + System.Environment.NewLine);
                return;
            }
            BkgDescargarArchivos.ReportProgress(100, "Descargando archivos; esto puede tardar varios minutos, por favor espere..." + System.Environment.NewLine);

            int i = 0;
            ArchivosLocales.ForEach(delegate(ArchivoSolidWorks archivoSolid) {

                switch(archivoSolid.EstatusServidor)
                {
                    case "SIN DESCARGAR":
                    case "MODIFICADO":
                        DescargarArchivo(archivoSolid, i);
                        break;
                }
                i++;
            });
        }

        public void DescargarArchivo(ArchivoSolidWorks archivo, int indice)
        {
            ProgresoSincronizacion ps = null;
            ps = new ProgresoSincronizacion(indice, "DESCARGANDO...");
            BkgDescargarArchivos.ReportProgress(Global.CalcularPorcentaje(indice, ArchivosLocales.Count), ps);

            (new FileInfo(RaizProyecto + archivo.RutaParcial)).Directory.Create();
            ClienteFtp.DownloadFile(RaizProyecto + archivo.RutaParcial, RaizFtp + archivo.RutaParcial, true, FtpVerify.Retry);
            
            ps = new ProgresoSincronizacion(indice, "SINCRONIZADO");
            BkgDescargarArchivos.ReportProgress(Global.CalcularPorcentaje(indice, ArchivosLocales.Count), ps);
        }

        private void BkgDescargarArchivos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoSincronizacion ps = null;
            if (e.UserState is ProgresoSincronizacion)
            {
                ps = (ProgresoSincronizacion)e.UserState;

                DgvSincronizacion.Rows[ps.IndiceArchivoLocal].Cells["estatus"].Value = ps.EstatusServidor;
                DgvSincronizacion.FirstDisplayedScrollingRowIndex = ps.IndiceArchivoLocal;

                DataGridViewCellStyle estiloCeldaEstatus = DgvSincronizacion.Rows[ps.IndiceArchivoLocal].Cells["estatus"].Style;
                switch(ps.EstatusServidor)
                {
                    case "SINCRONIZADO":
                        estiloCeldaEstatus.BackColor = Color.Green;
                        estiloCeldaEstatus.ForeColor = Color.White;
                        break;

                    case "DESCARGANDO...":
                        estiloCeldaEstatus.BackColor = Color.LightBlue;
                        estiloCeldaEstatus.ForeColor = Color.Black;
                        break;
                }
            }
            else if (e.UserState is string)
                TxtEstatus.AppendText(e.UserState.ToString());
        }

        private void BkgDescargarArchivos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

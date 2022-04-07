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
    public partial class FrmBajarArchivos : Form
    {
        bool DetenerDescarga = false;
        string CarpetaRemota = string.Empty;
        List<Fila> archivosIndice = new List<Fila>();
        string NombreArchivo = string.Empty;
        public string PathLocal = string.Empty;
        string PathEspecifico = string.Empty;

        public FrmBajarArchivos(string carpetaRemota, string nombreArchivo, string pathEspecifico = "")
        {
            InitializeComponent();
            CarpetaRemota = carpetaRemota;
            NombreArchivo = nombreArchivo;
            PathEspecifico = pathEspecifico;
        }

        private void FrmBajarDiseno_Load(object sender, EventArgs e)
        {
            BkgBajarDiseno.RunWorkerAsync();
        }

        private void BkgBajarDiseno_DoWork(object sender, DoWorkEventArgs e)
        {
            PathLocal = ServidorFtp.DescargarDirectorio(CarpetaRemota, NombreArchivo, BkgBajarDiseno, e);
        }

        private void BkgBajar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string archivoActual = string.Empty;

            if (e.UserState != null)
                archivoActual = e.UserState.ToString();

            LblProgreso.Text = "Bajando archivos... [" + e.ProgressPercentage + "%]";
            LblArchivoActual.Text = archivoActual;
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgBajar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled )
            {
                MessageBox.Show("Se descargaron los archivos de forma exitosa.", "Descarga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
            {
                BtnCancelar.Text = "Salir";
                LblArchivoActual.Text = "Descarga cancelada";
            }
        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            if (BkgBajarDiseno.IsBusy)
            {
                DialogResult cancelar = MessageBox.Show("Seguro que quieres cancelar la descarga?", "Cancelar descarga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cancelar == System.Windows.Forms.DialogResult.Yes)
                {
                    BkgBajarDiseno.CancelAsync();
                }
            }
            else
                Close();
        }
    }
}

using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmDescargarArchivos : Form
    {
        FtpClient ClienteFtp;
        List<string> PathsArchivosFtp;

        public FrmDescargarArchivos(List<string> pathsFtp, FtpClient clienteFtp)
        {
            InitializeComponent();
            PathsArchivosFtp = pathsFtp;
            ClienteFtp = clienteFtp;
        }

        private void FrmDescargarArchivos_Load(object sender, EventArgs e)
        {
            BkgDescarga.RunWorkerAsync();
        }

        private void BkgDescarga_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach(string path in PathsArchivosFtp)
            {

            }
        }

        private void BkgDescarga_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void BkgDescarga_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}

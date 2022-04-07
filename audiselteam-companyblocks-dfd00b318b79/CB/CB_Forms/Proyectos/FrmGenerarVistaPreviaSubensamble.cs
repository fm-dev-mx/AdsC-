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
using SolidWorks.Interop.swconst;

namespace CB
{
    public partial class FrmGenerarVistaPreviaSubensamble : Form
    {
        string RutaSubenamble = string.Empty;
        public byte[] VistaPrevia = null;
        SolidWorksAPI SW = null;

        public FrmGenerarVistaPreviaSubensamble(string rutaSubensamble, SolidWorksAPI sw)
        {
            InitializeComponent();
            RutaSubenamble = rutaSubensamble;

            if(sw == null)
            {
                MessageBox.Show("Se debe proporcionar una conexion al API de SolidWorks antes de generar la vista previa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            SW = sw;
        }

        private void BkgVistaPrevia_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BkgVistaPrevia.CancellationPending)
                return;

            SW.VistaPrevia(RutaSubenamble, swDocumentTypes_e.swDocASSEMBLY, out VistaPrevia, swStandardViews_e.swIsometricView);
        }

        private void BkgVistaPrevia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            BkgVistaPrevia.CancelAsync();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void FrmGenerarVistaPreviaSubensamble_Load(object sender, EventArgs e)
        {
            BkgVistaPrevia.RunWorkerAsync();
        }
    }
}

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


namespace CB
{
    public partial class FrmGenerarReporte : Form
    {
        public FrmGenerarReporte()
        {
            InitializeComponent();
        }

        private void BkgGenerarReporte_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ReportesExcel.GenerarreporteProveedores(BkgGenerarReporte);
        }

        private void BkgGenerarReporte_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblReporte.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgGenerarReporte_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() != string.Empty)
                MessageBox.Show("Evaluación guardada en " + e.Result);
            else
                MessageBox.Show("Reporte cancelado ");

            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("¿Desea cancelar el reporte?","Cancelar reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            if (BkgGenerarReporte.IsBusy)
            {
                BkgGenerarReporte.CancelAsync();
            }
            else
                Close();
        }

        private void FrmGenerarReporte_Load(object sender, EventArgs e)
        {
            BkgGenerarReporte.RunWorkerAsync();
        }
    }
}

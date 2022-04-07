using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmCerrarProceso : Form
    {
        List<System.Management.ManagementObject> Procesos;
        string NombrePrograma = string.Empty;

        public FrmCerrarProceso(List<System.Management.ManagementObject> procesos, string nombrePrograma)
        {
            InitializeComponent();
            Procesos = procesos;
            NombrePrograma = nombrePrograma;
        }

        private void FrmCerrarProceso_Load(object sender, EventArgs e)
        {
            TxtMensaje.Text = "Se encontró una instancia del programa " + NombrePrograma.ToLower() + " abierto, para continuar guarde sus cambios y de click en continuar.";
            LblProgreso.Text = "Cerrando otras instancias de " + NombrePrograma + "... ";
            Progreso.Value = 0;
        }

        private void BkgCerrarProcesos_DoWork(object sender, DoWorkEventArgs e)
        {
             BkgCerrarProcesos.ReportProgress(50, "Cerrando otras instancias de " + NombrePrograma + "... ");

             int avance = 0;
             foreach (System.Management.ManagementObject mo in Procesos)
             {
                 mo.InvokeMethod("Terminate", null);
                 avance++;
                 BkgCerrarProcesos.ReportProgress(Global.CalcularPorcentaje(avance, Procesos.Count), "Cerrando otras instancias de " + NombrePrograma + "... ");
             }
        }

        private void BkgCerrarProcesos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value = e.ProgressPercentage;
            LblProgreso.Text = e.UserState.ToString();
        }

        private void BkgCerrarProcesos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            BkgCerrarProcesos.RunWorkerAsync();
        }
    }
}

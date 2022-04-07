using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentFTP;
using System.Net;
using System.IO;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmTerminalFabricacion : Form
    {
        FrmEscanear Escanear;
        FrmProcesosFabricacionAsignados VentanaOpcionesProceso;
        FtpClient ClienteFtp = null;
        TextBox TextoEstatusFtp = new TextBox();
        
        string Tipo = string.Empty;
        string RutaParcialSinExtension = string.Empty;
        string RaizFtp = string.Empty;
        string ProgresoTerminal = string.Empty;
        int IdOperador = 0;
        int IdPlano = 0;
        int Counter = 180;

        public FrmTerminalFabricacion()
        {
            InitializeComponent();
            PanelVentana.BackColor = Color.Black;
            TextoEstatusFtp.ReadOnly = true;
            TextoEstatusFtp.Multiline = true;
            TextoEstatusFtp.BackColor = Color.Black;
            TextoEstatusFtp.ForeColor = Color.Aqua;
            TextoEstatusFtp.Dock = DockStyle.Fill;

            TextoEstatusFtp.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);

            PanelVentana.Controls.Add(TextoEstatusFtp);
        }

        private void PanelVentana_Paint(object sender, PaintEventArgs e)
        {
            if (Escanear == null)
                return;

            if (Escanear.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                IdOperador = Convert.ToInt32(Escanear.TextoEscaneado);
                PlanoProceso planoProcesos = new PlanoProceso();
                planoProcesos.BuscarProcesoAsignado(IdOperador);
                PanelVentana.Controls.Clear();
                Escanear.DialogResult = System.Windows.Forms.DialogResult.None;
                Escanear.Close();

                if (planoProcesos.TieneFilas())
                {
                    PanelVentana.Controls.Add(TextoEstatusFtp);
                    TextoEstatusFtp.Text = string.Empty;
                    IdPlano = Convert.ToInt32(planoProcesos.Fila().Celda("plano"));
                    BkgConectarFtp.RunWorkerAsync();
                }
                else
                {
                    //Si no tiene un proceso asignado pedir al usuario escanee su gafete
                    MostrarVentanaEscaneo(TipoEscaneo.IdEmpleado);
                    MessageBox.Show("El gafete escaneado no tiene ningún proceso asignado", "No hay procesos asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(Escanear.DialogResult == System.Windows.Forms.DialogResult.Abort)
            {
                FrmMonitorFabricacion2 fabricacion = (FrmMonitorFabricacion2)Application.OpenForms["FrmMonitorFabricacion2"];
                fabricacion.Show();

                FrmPrincipal principal = (FrmPrincipal)Application.OpenForms["FrmPrincipal"];
                principal.Show();

                this.Close();
            }



            if (VentanaOpcionesProceso != null)
            {
                DialogResult opciones = VentanaOpcionesProceso.DialogResult;
                if (opciones == System.Windows.Forms.DialogResult.OK && Escanear.DialogResult == System.Windows.Forms.DialogResult.None)
                {
                    opciones = System.Windows.Forms.DialogResult.None;
                    MostrarVentanaEscaneo(TipoEscaneo.IdEmpleado);
                    VentanaOpcionesProceso = null;
                }
                opciones = System.Windows.Forms.DialogResult.None;
            }
        }

        private void FrmTerminalFabricacion_Load(object sender, EventArgs e)
        {
            MostrarVentanaEscaneo(TipoEscaneo.IdEmpleado);

            //ocultars forms
            FrmMonitorFabricacion2 fabricacion = (FrmMonitorFabricacion2)Application.OpenForms["FrmMonitorFabricacion2"];
            if (fabricacion.Visible)
                fabricacion.Hide();

            FrmPrincipal principal = (FrmPrincipal)Application.OpenForms["FrmPrincipal"];
            if (principal.Visible)
                principal.Hide();
 
        }

        private void MostrarVentanaEscaneo(TipoEscaneo tipo)
        {
            this.PanelVentana.Controls.Clear();
            Escanear = new FrmEscanear(tipo);
            Escanear.TopLevel = false;
            Escanear.AutoScroll = true;
            Escanear.WindowState = FormWindowState.Maximized;
            this.PanelVentana.Controls.Add(Escanear);
            Escanear.Show();
        }

        private void MostrarOpcionesProceso(int idPlano)
        {
            this.PanelVentana.Controls.Clear();
            VentanaOpcionesProceso = new FrmProcesosFabricacionAsignados(IdOperador, ClienteFtp);
            VentanaOpcionesProceso.TopLevel = false;
            VentanaOpcionesProceso.AutoScroll = true;
            VentanaOpcionesProceso.WindowState = FormWindowState.Maximized;
            this.PanelVentana.Controls.Add(VentanaOpcionesProceso);
            VentanaOpcionesProceso.Show();
        }

        private void BkgConectarFtp_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgConectarFtp.ReportProgress(10, "Obteniendo información de conexión... ");
            ClienteFtp = new FtpClient();
            
            if (Global.TipoConexion == "LOCAL")
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
            else
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;
            BkgConectarFtp.ReportProgress(15, "Obteniendo información de conexión... [OK]");

            BkgConectarFtp.ReportProgress(50, "Validando credenciales... ");

            ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                           Global.UsuarioActual.Fila().Celda("password").ToString());

            BkgConectarFtp.ReportProgress(65, "Validando credenciales... [OK]");
            BkgConectarFtp.ReportProgress(80, "Conectando con servidor FTP...");
            if (!ClienteFtp.IsConnected)
            {
                // Verificar conexion con servidor FTP
                try
                {
                    ClienteFtp.Connect();
                    BkgConectarFtp.ReportProgress(100, "Conectando con servidor FTP... [OK]");

                }
                catch //(Exception ex)
                {
                    BkgConectarFtp.ReportProgress(100, "Error de conexión con servidor FTP");
                    return;
                }
            }
        }

        private void BkgConectarFtp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MostrarOpcionesProceso(IdPlano);
            VentanaOpcionesProceso.DialogResult = System.Windows.Forms.DialogResult.None;
        }

        private void BkgConectarFtp_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TextoEstatusFtp.AppendText(e.UserState.ToString() + Environment.NewLine);
        }

        private void FrmTerminalFabricacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClienteFtp != null && ClienteFtp.IsConnected)
            {
                ClienteFtp.Disconnect();
                ClienteFtp.Dispose();
                ClienteFtp = null;
            }
        }
    }
}

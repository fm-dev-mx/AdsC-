using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CB_Base.Classes;
using System.Reflection;
using SharpSvn;
using System.IO;
using CB_Base.CB_Classes;

// Prueba remotod
namespace CB
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        void IniciarSesion(string correo, string password)
        {
            if (Global.ConnectionString != "Error")
            {
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                    int idUsuario = Usuario.Modelo().ValidarCredenciales(correo, password);

                    if (idUsuario > 0)
                    {
                        Global.UsuarioActual.CargarDatos(idUsuario);

                        if (Convert.ToInt32(Global.UsuarioActual.Fila().Celda("activo")) == 0)
                        {
                            MessageBox.Show("No tienes permitido el inicio de sesión");
                            this.Close();
                        }
                        if (config.AppSettings.Settings["bd_modo"] != null)
                        {
                            config.AppSettings.Settings["bd_modo"].Value = CmbTipoConexion.Text;
                            config.Save();
                        }
                        else
                            CrearBdModoKey();

                        CrearArchivosCacheKey();

                        Global.PrivilegiosActuales.SeleccionarDeRol(Global.UsuarioActual.Fila().Celda("rol").ToString());
                        Global.ConfiguracionActual.CargarConfiguracionCorreo();
                        NotificacionesCorreo.Correo = Global.ConfiguracionActual;
                        Notificaciones.NotificarGenerales();
                        FrmPrincipal principal = new FrmPrincipal();
                        this.Visible = false;
                        principal.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        LblEstatus.ForeColor = Color.Red;
                        LblEstatus.Text = "Datos incorrectos";
                        LblEstatus.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Favor de crear la configuración inicial del sistema, si usted ya configuró el sistema anteriormente verifique la configuración.", "Configuración de la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmConfiguracion config = new FrmConfiguracion();
                config.ShowDialog();
            }
                
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                IniciarSesion(txtCorreo.Text, txtPassword.Text);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                IniciarSesion(txtCorreo.Text, txtPassword.Text);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            CrearBdModoKey();

            if (config.AppSettings.Settings["bd_modo"] != null)
            {
                CmbTipoConexion.SelectedItem = config.AppSettings.Settings["bd_modo"].Value;
            }
            else
                CmbTipoConexion.SelectedIndex = 0;

            Global.ConnectionString = Global.CrearConexion(CmbTipoConexion.Text);

            if (config.AppSettings.Settings["correo_usuario"] != null)
            {
                txtCorreo.Text = config.AppSettings.Settings["correo_usuario"].Value;
                txtPassword.Focus();
            }
        }

        private void CmbTipoConexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.ConnectionString = Global.CrearConexion(CmbTipoConexion.Text);
        }

        public void CrearBdModoKey()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            if (config.AppSettings.Settings["bd_modo"] == null)
                config.AppSettings.Settings.Add("bd_modo", "LOCAL");

            config.Save();
        }

         public void CrearArchivosCacheKey()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            if (config.AppSettings.Settings["diseno_archivos_cache"] == null)
            {
                config.AppSettings.Settings.Add("diseno_archivos_cache", "True");              
            }

            config.Save();
        }

        private void LinkConfiguracion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmConfiguracion configuracion = new FrmConfiguracion();
            configuracion.Show();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            BtnIngresar.Enabled = false;
            IniciarSesion(txtCorreo.Text, txtPassword.Text);
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            BtnIngresar.Enabled = txtCorreo.Text != string.Empty && txtPassword.Text != string.Empty;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            BtnIngresar.Enabled = txtCorreo.Text != string.Empty && txtPassword.Text != string.Empty;
        }

        private void BtnTestPdf_Click(object sender, EventArgs e)
        {
            //PDFMakerNovo gestorPdf = new PDFMakerNovo();
            //gestorPdf.CrearFormatoCotizacion(4, @"SGC\COTIZACIONES\", 0);
        }

        private void BtnRTF_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

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

namespace CB
{
    public partial class FrmConfigurarCorreo : Form
    {
        public FrmConfigurarCorreo()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            try
            {
                if (config.AppSettings.Settings["correo_usuario"] == null)
                    config.AppSettings.Settings.Add("correo_usuario", TxtUsuario.Text);
                else
                    config.AppSettings.Settings["correo_usuario"].Value = TxtUsuario.Text;

                if (config.AppSettings.Settings["correo_password"] == null)
                    config.AppSettings.Settings.Add("correo_password", TxtPassword.Text);
                else
                    config.AppSettings.Settings["correo_password"].Value = TxtPassword.Text;

                if (config.AppSettings.Settings["correo_servidor"] == null)
                    config.AppSettings.Settings.Add("correo_servidor", TxtServidor.Text);
                else
                    config.AppSettings.Settings["correo_servidor"].Value = TxtServidor.Text;

                if (config.AppSettings.Settings["correo_puerto"] == null)
                    config.AppSettings.Settings.Add("correo_puerto", TxtPuerto.Text);
                else
                    config.AppSettings.Settings["correo_puerto"].Value = TxtPuerto.Text;

                if (config.AppSettings.Settings["correo_firma"] == null)
                    config.AppSettings.Settings.Add("correo_firma", TxtFirma.Text);
                else
                    config.AppSettings.Settings["correo_firma"].Value = TxtFirma.Text;

                config.Save();

                MessageBox.Show("Configuración guardada correctamente!");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmConfigurarCorreo_Load(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                if (config.AppSettings.Settings["correo_usuario"] != null)
                    TxtUsuario.Text = config.AppSettings.Settings["correo_usuario"].Value;

                if (config.AppSettings.Settings["correo_password"] != null)
                    TxtPassword.Text = config.AppSettings.Settings["correo_password"].Value;

                if (config.AppSettings.Settings["correo_servidor"] != null)
                    TxtServidor.Text = config.AppSettings.Settings["correo_servidor"].Value;

                if (config.AppSettings.Settings["correo_puerto"] != null)
                    TxtPuerto.Text = config.AppSettings.Settings["correo_puerto"].Value;

                if (config.AppSettings.Settings["correo_firma"] != null)
                    TxtFirma.Text = config.AppSettings.Settings["correo_firma"].Value;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

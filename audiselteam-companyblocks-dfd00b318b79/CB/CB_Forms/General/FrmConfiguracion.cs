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
using System.Net;
using CB_Base.Classes;
using iTextSharp.text.pdf.parser;
using System.Text.RegularExpressions;
using System.IO;

namespace CB
{
    public partial class FrmConfiguracion : Ventana
    {
        Configuration Config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            CargarConfiguracion();
        }

        public void CargarConfiguracion()
        {
            try
            {
                //correo
                if (Config.AppSettings.Settings["correo_usuario"] != null)
                    TxtUsuario.Text = Config.AppSettings.Settings["correo_usuario"].Value;

                if (Config.AppSettings.Settings["correo_password"] != null)
                    TxtPassword.Text = Config.AppSettings.Settings["correo_password"].Value;

                if (Config.AppSettings.Settings["correo_servidor"] != null)
                    TxtServidor.Text = Config.AppSettings.Settings["correo_servidor"].Value;

                if (Config.AppSettings.Settings["correo_puerto"] != null)
                    TxtPuerto.Text = Config.AppSettings.Settings["correo_puerto"].Value;

                if (Config.AppSettings.Settings["correo_firma"] != null)
                    TxtFirma.Text = Config.AppSettings.Settings["correo_firma"].Value;

                //BD
                if (Config.AppSettings.Settings["bd_ip_local"] != null)
                    TxtBDServidorLocal.Text = Config.AppSettings.Settings["bd_ip_local"].Value;

                if (Config.AppSettings.Settings["bd_ip_remota"] != null)
                    TxtBDServidorRemoto.Text = Config.AppSettings.Settings["bd_ip_remota"].Value;

                if (Config.AppSettings.Settings["bd_dataBase"] != null)
                    TxtBDNombre.Text = Config.AppSettings.Settings["bd_dataBase"].Value;

                if (Config.AppSettings.Settings["bd_usuario"] != null)
                    TxtBDUsuario.Text = Config.AppSettings.Settings["bd_usuario"].Value;

                if (Config.AppSettings.Settings["bd_password"] != null)
                    TxtBDPassword.Text = Config.AppSettings.Settings["bd_password"].Value;

                if (Config.AppSettings.Settings["bd_puerto"] != null)
                    TxtBDPuerto.Text = Config.AppSettings.Settings["bd_puerto"].Value;

                //FTP
                if (Config.AppSettings.Settings["ftp_servidor_local"] != null)
                    TxtFtpHost.Text = Config.AppSettings.Settings["ftp_servidor_local"].Value;

                if (Config.AppSettings.Settings["ftp_servidor_remoto"] != null)
                    TxtFtpIpServidor.Text = Config.AppSettings.Settings["ftp_servidor_remoto"].Value;

                if (Config.AppSettings.Settings["ftp_puerto"] != null)
                    TxtFtpPuerto.Text = Config.AppSettings.Settings["ftp_puerto"].Value;

                //Diseño
                if (Config.AppSettings.Settings["diseno_archivos_cache"] != null)
                {
                    if (Config.AppSettings.Settings["diseno_archivos_cache"].Value == "True")
                        ChkBCache.Checked = true;
                    else
                        ChkBCache.Checked = false;
                }

                //SSL
                if (Config.AppSettings.Settings["configurar_ssl"] != null)
                {
                    if (Config.AppSettings.Settings["configurar_ssl"].Value == "True")
                        ChkSsl.Checked = true;
                    else
                        ChkSsl.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarConfiguracion();
        }

        private void GuardarConfiguracion()
        {
            IPAddress ip = null;
            if (!IPAddress.TryParse(TxtBDServidorLocal.Text, out ip))
            {
                MessageBox.Show("La dirección IP local no es válida, verifique la dirección IP.", "IP no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ip = null;
            if (!IPAddress.TryParse(TxtBDServidorRemoto.Text, out ip))
            {
                MessageBox.Show("La dirección IP remota no es válida, verifique la dirección IP.", "IP no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((TxtBDServidorRemoto.Text != "" || TxtBDServidorLocal.Text != "") && TxtBDNombre.Text != "" && TxtBDPuerto.Text != "" && TxtBDUsuario.Text != "" && TxtBDPassword.Text != "")
            {
                try
                {
                    //guardar BD
                    if (Config.AppSettings.Settings["bd_ip_remota"] == null)
                        Config.AppSettings.Settings.Add("bd_ip_remota", TxtBDServidorRemoto.Text);
                    else
                        Config.AppSettings.Settings["bd_ip_remota"].Value = TxtBDServidorRemoto.Text;

                    if (Config.AppSettings.Settings["bd_ip_local"] == null)
                        Config.AppSettings.Settings.Add("bd_ip_local", TxtBDServidorLocal.Text);
                    else
                        Config.AppSettings.Settings["bd_ip_local"].Value = TxtBDServidorLocal.Text;

                    if (Config.AppSettings.Settings["bd_dataBase"] == null)
                        Config.AppSettings.Settings.Add("bd_dataBase", TxtBDNombre.Text);
                    else
                        Config.AppSettings.Settings["bd_dataBase"].Value = TxtBDNombre.Text;

                    if (Config.AppSettings.Settings["bd_puerto"] == null)
                        Config.AppSettings.Settings.Add("bd_puerto", TxtBDPuerto.Text);
                    else
                        Config.AppSettings.Settings["bd_puerto"].Value = TxtBDPuerto.Text;

                    if (Config.AppSettings.Settings["bd_usuario"] == null)
                        Config.AppSettings.Settings.Add("bd_usuario", TxtBDUsuario.Text);
                    else
                        Config.AppSettings.Settings["bd_usuario"].Value = TxtBDUsuario.Text;

                    if (Config.AppSettings.Settings["bd_password"] == null)
                        Config.AppSettings.Settings.Add("bd_password", TxtBDPassword.Text);
                    else
                        Config.AppSettings.Settings["bd_password"].Value = TxtBDPassword.Text;

                    //Guardar correo
                    if (Config.AppSettings.Settings["correo_usuario"] == null)
                        Config.AppSettings.Settings.Add("correo_usuario", TxtUsuario.Text);
                    else
                        Config.AppSettings.Settings["correo_usuario"].Value = TxtUsuario.Text;

                    if (Config.AppSettings.Settings["correo_password"] == null)
                        Config.AppSettings.Settings.Add("correo_password", TxtPassword.Text);
                    else
                        Config.AppSettings.Settings["correo_password"].Value = TxtPassword.Text;

                    if (Config.AppSettings.Settings["correo_servidor"] == null)
                        Config.AppSettings.Settings.Add("correo_servidor", TxtServidor.Text);
                    else
                        Config.AppSettings.Settings["correo_servidor"].Value = TxtServidor.Text;

                    if (Config.AppSettings.Settings["correo_puerto"] == null)
                        Config.AppSettings.Settings.Add("correo_puerto", TxtPuerto.Text);
                    else
                        Config.AppSettings.Settings["correo_puerto"].Value = TxtPuerto.Text;

                    if (Config.AppSettings.Settings["correo_firma"] == null)
                        Config.AppSettings.Settings.Add("correo_firma", TxtFirma.Text);
                    else
                        Config.AppSettings.Settings["correo_firma"].Value = TxtFirma.Text;

                    //SSL
                    if (Config.AppSettings.Settings["configurar_ssl"] == null)
                    {
                        if (ChkSsl.Checked)
                            Config.AppSettings.Settings.Add("configurar_ssl", "True");
                        else
                            Config.AppSettings.Settings.Add("configurar_ssl", "False");
                    }
                    else
                    {
                        if (ChkSsl.Checked)
                            Config.AppSettings.Settings["configurar_ssl"].Value = "True";
                        else
                            Config.AppSettings.Settings["configurar_ssl"].Value = "False";
                    }
                    //guardar ftp

                    if (Config.AppSettings.Settings["ftp_servidor_local"] == null)
                        Config.AppSettings.Settings.Add("ftp_servidor_local", TxtFtpHost.Text);
                    else
                        Config.AppSettings.Settings["ftp_servidor_local"].Value = TxtFtpHost.Text;

                    if (Config.AppSettings.Settings["ftp_servidor_remoto"] == null)
                        Config.AppSettings.Settings.Add("ftp_servidor_remoto", TxtFtpIpServidor.Text);
                    else
                        Config.AppSettings.Settings["ftp_servidor_remoto"].Value = TxtFtpIpServidor.Text;

                    if (Config.AppSettings.Settings["ftp_puerto"] == null)
                        Config.AppSettings.Settings.Add("ftp_puerto", TxtFtpPuerto.Text);
                    else
                        Config.AppSettings.Settings["ftp_puerto"].Value = TxtFtpPuerto.Text;

                    Config.Save();

                    DialogResult result = MessageBox.Show("Configuración de la base de datos guardada correctamente, debe reiniciar el sistema para que surta efecto los cambios. ¿Desea reiniciar el sistema?.", "Reiniciar sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                        Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Favor de llenar todos los campos.");
        }

        private void BtnGuardarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Config.AppSettings.Settings["correo_usuario"] == null)
                    Config.AppSettings.Settings.Add("correo_usuario", TxtUsuario.Text);
                else
                    Config.AppSettings.Settings["correo_usuario"].Value = TxtUsuario.Text;

                if (Config.AppSettings.Settings["correo_password"] == null)
                    Config.AppSettings.Settings.Add("correo_password", TxtPassword.Text);
                else
                    Config.AppSettings.Settings["correo_password"].Value = TxtPassword.Text;

                if (Config.AppSettings.Settings["correo_servidor"] == null)
                    Config.AppSettings.Settings.Add("correo_servidor", TxtServidor.Text);
                else
                    Config.AppSettings.Settings["correo_servidor"].Value = TxtServidor.Text;

                if (Config.AppSettings.Settings["correo_puerto"] == null)
                    Config.AppSettings.Settings.Add("correo_puerto", TxtPuerto.Text);
                else
                    Config.AppSettings.Settings["correo_puerto"].Value = TxtPuerto.Text;

                if (Config.AppSettings.Settings["correo_firma"] == null)
                    Config.AppSettings.Settings.Add("correo_firma", TxtFirma.Text);
                else
                    Config.AppSettings.Settings["correo_firma"].Value = TxtFirma.Text;

                //SSL
                if (Config.AppSettings.Settings["configurar_ssl"] == null)
                {
                    if (ChkSsl.Checked)
                        Config.AppSettings.Settings.Add("configurar_ssl", "True");
                    else
                        Config.AppSettings.Settings.Add("configurar_ssl", "False");
                }
                else
                {
                    if (ChkSsl.Checked)
                        Config.AppSettings.Settings["configurar_ssl"].Value = "True";
                    else
                        Config.AppSettings.Settings["configurar_ssl"].Value = "False";
                }

                Config.Save();

                DialogResult result = MessageBox.Show("Configuración del correo guardado correctamente, debe reiniciar el sistema para que surta efecto los cambios. ¿Desea reiniciar el sistema?.", "Reiniciar sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                    Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGuardarFtp_Click(object sender, EventArgs e)
        {
            try
            {
                if (Config.AppSettings.Settings["ftp_servidor_local"] == null)
                    Config.AppSettings.Settings.Add("ftp_servidor_local", TxtFtpHost.Text);
                else
                    Config.AppSettings.Settings["ftp_servidor_local"].Value = TxtFtpHost.Text;

                if (Config.AppSettings.Settings["ftp_servidor_remoto"] == null)
                    Config.AppSettings.Settings.Add("ftp_servidor_remoto", TxtFtpIpServidor.Text);
                else
                    Config.AppSettings.Settings["ftp_servidor_remoto"].Value = TxtFtpIpServidor.Text;

                if (Config.AppSettings.Settings["ftp_puerto"] == null)
                    Config.AppSettings.Settings.Add("ftp_puerto", TxtFtpPuerto.Text);
                else
                    Config.AppSettings.Settings["ftp_puerto"].Value = TxtFtpPuerto.Text;

                Config.Save();

                DialogResult result = MessageBox.Show("Configuración del servidor FTP guardada correctamente, debe reiniciar el sistema para que surta efecto los cambios. ¿Desea reiniciar el sistema?.", "Reiniciar sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                    Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void BtnSalirCorreo_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void TxtBDPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtBDServidorRemoto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
        }

        private void TxtBDServidorLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        public void Salir()
        {
            Close();
        }

        private void BtnSalirBD_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void TxtPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtFtpPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Config.AppSettings.Settings["diseno_archivos_cache"] == null)
                {
                    if (ChkBCache.Checked)
                        Config.AppSettings.Settings.Add("diseno_archivos_cache", "True");
                    else
                        Config.AppSettings.Settings.Add("diseno_archivos_cache", "False");
                }
                else
                {
                    if (ChkBCache.Checked)
                        Config.AppSettings.Settings["diseno_archivos_cache"].Value = "True";
                    else
                        Config.AppSettings.Settings["diseno_archivos_cache"].Value = "False";
                }

                Config.Save();

                DialogResult result = MessageBox.Show("Configuración de diseño guardada correctamente, debe reiniciar el sistema para que surta efecto los cambios. ¿Desea reiniciar el sistema?.", "Reiniciar sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                    Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDisenoSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void TxtFirma_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "config files (*.txt)|*.config|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    if (System.IO.Path.GetFileName(openFileDialog.FileName) != "audisel.exe.config")
                    {
                        MessageBox.Show("Debe seleccionar el archivo de configuración de la aplicación",
                            "Seleccione el archivo de configuración",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    string[] textoArchivo = File.ReadAllLines(openFileDialog.FileName);
                    CargarInformacion(textoArchivo);
                }
            }
        }

        private void CargarInformacion(string[] archivoOriginal)
        {
            try
            {
                string[] archivo = LimpiarTexto(archivoOriginal);

                //correo
                string[] correoServidor = Array.Find(archivo, element => element.Contains("correo_servidor")).Split('=');
                if (correoServidor.Length == 3)
                    TxtServidor.Text = correoServidor[2];

                string[] correoPuerto = Array.Find(archivo, element => element.Contains("correo_puerto")).Split('=');
                if (correoPuerto.Length == 3)
                    TxtPuerto.Text = correoPuerto[2];

                //BD
                string[] bdIpLocal = Array.Find(archivo, element => element.Contains("bd_ip_local")).Split('=');
                if(bdIpLocal.Length ==3)
                    TxtBDServidorLocal.Text = bdIpLocal[2];

                string[] bdIpRemota = Array.Find(archivo, element => element.Contains("bd_ip_remota")).Split('=');
                if (bdIpRemota.Length == 3)
                    TxtBDServidorRemoto.Text = bdIpRemota[2];

                string[] bdDataBase = Array.Find(archivo, element => element.Contains("bd_dataBase")).Split('=');
                if (bdDataBase.Length == 3)
                    TxtBDNombre.Text = bdDataBase[2];

                string[] bdUsuario = Array.Find(archivo, element => element.Contains("bd_usuario")).Split('=');
                if (bdUsuario.Length == 3)
                    TxtBDUsuario.Text = bdUsuario[2];

                string[] bdPassword = Array.Find(archivo, element => element.Contains("bd_password")).Split('=');
                if (bdPassword.Length == 3)
                    TxtBDPassword.Text = bdPassword[2];

                string[] bdPuerto = Array.Find(archivo, element => element.Contains("bd_puerto")).Split('=');
                if (bdPuerto.Length == 3)
                    TxtBDPuerto.Text = bdPuerto[2];

                //FTP
                string[] ftpServidorLocal = Array.Find(archivo, element => element.Contains("ftp_servidor_local")).Split('=');
                if (ftpServidorLocal.Length == 3)
                    TxtFtpHost.Text = ftpServidorLocal[2].Replace("ftp:", "ftp://");

                string[] ftpServidorRemoto = Array.Find(archivo, element => element.Contains("ftp_servidor_remoto")).Split('=');
                if (ftpServidorRemoto.Length == 3)
                    TxtFtpIpServidor.Text = ftpServidorRemoto[2].Replace("ftp:", "ftp://");

                string[] ftpPuerto = Array.Find(archivo, element => element.Contains("ftp_puerto")).Split('=');
                if (ftpPuerto.Length == 3)
                    TxtFtpPuerto.Text = ftpPuerto[2];

                //Diseño
                ChkBCache.Checked = false;

                //SS
                ChkSsl.Checked = false;

                GuardarConfiguracion();

            }
            catch 
            {
                MessageBox.Show("Favor de solicitar el archivo de configuración",
                    "Archivo incorrecto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private string[] LimpiarTexto(string[] archivo)
        {
            List<string> archivoLimpio = new List<string>();
            foreach (string item in archivo)
            {
                archivoLimpio.Add(item.Replace("\\", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("/","").TrimStart().TrimEnd());
            }

            return archivoLimpio.ToArray();
        }
    }
}

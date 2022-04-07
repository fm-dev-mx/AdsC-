using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace CB_Base.Classes
{
    public class Configuracion
    {
        // Correo
        public string CorreoUsuario = "";
        public string CorreoPassword = "";
        public string CorreoServidor = "";
        public string CorreoPuerto = "";
        public string CorreoFirma = "";
        public string ConfigurarSsl = "";
        public bool CorreoConfiguracionValida = false;

        // Base de datos
        public string BdUsuario = "";
        public string BdPassword = "";
        public string BdServidorLocal = "";
        public string BdServidorRemoto = "";
        public string BdPuerto = "";
        public string BdNombre = "";
        public bool BdConfiguracionValida = false;

        // Servidor FTP
        public string FtpServidorLocal = "";
        public string FtpServidorRemoto = "";
        public string FtpPuerto = "";
        public bool FtpConfiguracionValida = false;

        // Diseño
        public string DisenoArchivosCache = "";
        public bool DisenoConfiguracionValida = false;

        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        public void CargarConfiguracionCorreo()
        {
            CorreoConfiguracionValida = false;

            if(config.AppSettings.Settings["correo_usuario"] != null)
                CorreoUsuario = config.AppSettings.Settings["correo_usuario"].Value;
            else
                return;

            if(config.AppSettings.Settings["correo_password"] != null)
                CorreoPassword = config.AppSettings.Settings["correo_password"].Value;
            else
                return;

            if(config.AppSettings.Settings["correo_servidor"] != null)
                CorreoServidor = config.AppSettings.Settings["correo_servidor"].Value;
            else
                return;

            if(config.AppSettings.Settings["correo_puerto"] != null)
                CorreoPuerto = config.AppSettings.Settings["correo_puerto"].Value;
            else
                return;

            if (config.AppSettings.Settings["correo_firma"] != null)
            {
                CorreoFirma = config.AppSettings.Settings["correo_firma"].Value;
                CorreoFirma = CorreoFirma.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(@"\", "").Replace("\"", "'");
            }
            
            //ssl
            if (config.AppSettings.Settings["configurar_ssl"] != null && config.AppSettings.Settings["configurar_ssl"].Value != "")
                ConfigurarSsl = config.AppSettings.Settings["configurar_ssl"].Value;
            else
                return;

            CorreoConfiguracionValida = true;
        }

        public void CargarConfiguracionBd()
        {
            // BD
            if (config.AppSettings.Settings["bd_usuario"] != null && config.AppSettings.Settings["bd_usuario"].Value != "")
                BdUsuario = config.AppSettings.Settings["bd_usuario"].Value;
            else
                return;

            if (config.AppSettings.Settings["bd_password"] != null && config.AppSettings.Settings["bd_password"].Value != "")
                BdPassword = config.AppSettings.Settings["bd_password"].Value;
            else
                return;

            if (config.AppSettings.Settings["bd_ip_local"] != null && config.AppSettings.Settings["bd_ip_local"].Value != "")
                BdServidorLocal = config.AppSettings.Settings["bd_ip_local"].Value;
            else
                return;

            if (config.AppSettings.Settings["bd_ip_remota"] != null && config.AppSettings.Settings["bd_ip_remota"].Value != "")
                BdServidorRemoto = config.AppSettings.Settings["bd_ip_remota"].Value;
            else
                return;

            if (config.AppSettings.Settings["bd_puerto"] != null && config.AppSettings.Settings["bd_puerto"].Value != "")
                BdPuerto = config.AppSettings.Settings["bd_puerto"].Value;
            else
                return;

            if (config.AppSettings.Settings["bd_dataBase"] != null && config.AppSettings.Settings["bd_dataBase"].Value != "")
                BdNombre = config.AppSettings.Settings["bd_dataBase"].Value;
            else
                return;

            BdConfiguracionValida = true;

        }

        public void CargarConfiguracionFtp()
        {
            if (config.AppSettings.Settings["ftp_servidor_local"] != null && config.AppSettings.Settings["ftp_servidor_local"].Value != "")
                FtpServidorLocal = config.AppSettings.Settings["ftp_servidor_local"].Value;
            else
                return;

            if (config.AppSettings.Settings["ftp_servidor_remoto"] != null && config.AppSettings.Settings["ftp_servidor_remoto"].Value != "")
                FtpServidorRemoto = config.AppSettings.Settings["ftp_servidor_remoto"].Value;
            else
                return;

            if (config.AppSettings.Settings["ftp_puerto"] != null && config.AppSettings.Settings["ftp_puerto"].Value != "")
                FtpPuerto = config.AppSettings.Settings["ftp_puerto"].Value;
            else
                return;

            FtpConfiguracionValida = true;

        }

        public void CargarConfiguracionDiseno()
        {
            if (config.AppSettings.Settings["diseno_archivos_cache"] != null && config.AppSettings.Settings["diseno_archivos_cache"].Value != "")
                DisenoArchivosCache = config.AppSettings.Settings["diseno_archivos_cache"].Value;
            else
                return;

            DisenoConfiguracionValida = true;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//necesarios para correo
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using MailKit;
using MimeKit;
using MailKit.Security;
using Google.Apis.Auth;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace CB_Base.Classes
{
    public static class GmailAuth2
    {
        public static Configuracion ConfiguracionActual = new Configuracion();
        public static List<string> SmtpInformacion = new List<string>();

        public static int EnviarCorreoConOAuth2(string asunto, string contenido, string para, List<string> copiasVisibles = null, List<Attachment> adjuntos = null, List<string> copiasOcultas = null)
        {
            /*
            * errores:
            * 0 = No Error
            * 1 = Configuración de correo no valida 
            * 2 = El token de acceso ha sido actualizado debe de intentar de nuevo mandar el correo
            * 3 = El token de acceso ha expirado y no ha podido ser actualizado
            * 4 = No fue posible enviar el correo
            * 5 = Las credenciales de Gmail no corresponden con el correo configurado
            * 6 = Petición cancelada
            */

            int idError = 0;

            ConfiguracionActual.CargarConfiguracionCorreo();

            // Configuración de correo no valida 
            if (!ConfiguracionActual.CorreoConfiguracionValida)
                return 1;

            //solicitando autorización OAuth 2.0
            string[] scopes = new string[] { "https://mail.google.com/", Oauth2Service.Scope.UserinfoEmail};


            //***********controlar que no se quede en el limbo en caso que el usuario cierre la página o no haga nada (pagina web donde pide autenticarse)
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(60));  // Se tiene 60 segundos para detectar si se dejó abierta la pagina de inicio de sesión o si se cerró la página
            CancellationToken ct = cts.Token;


            //Creamos las credenciales de OAuth 2.0 con el token y palabra secreta
            UserCredential credential = null;
            try
            {
                
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = "916916614040-o0dl9sf8njfm247s9be5fd3o72td44eo.apps.googleusercontent.com",  //Cambiar token en caso de hacer cambios al Api en google https://console.developers.google.com/apis/credentials?project=companyblocks-266616
                        ClientSecret = "qZPBufe0ZdWXeBZeRjDBGaBB",                                              //Cambiar secret en caso de cambios en google https://console.developers.google.com/apis/credentials?project=companyblocks-266616
                    },
                     scopes,
                     "XXXX",
                     ct
                    //CancellationToken.None
                     ).Result;

                if (ct.IsCancellationRequested)
                    return 6;
            }
            catch//(Exception ex)
            {
                //página cerrada o tiempo expirado
                return 6;
            }

            //***********controlar que no se quede en el limbo en caso que el usuario cierre la página o no haga nada (pagina web donde pide autenticarse)

            //verificamos si el token ha expirado, si lo ha hecho puede refrescarse e intebtar de nuevo
            if (credential.Token.IsExpired(credential.Flow.Clock))
            {
                //Token refrescado
                if (credential.RefreshTokenAsync(CancellationToken.None).Result)
                    return  2;
                else //El acceso a token ha expirado y no ha sido posible actualizarlo
                    return  3;
            }
            else //Acceso correcto al token
                idError = 0;

            try
            {
                BodyBuilder builder = new BodyBuilder();
                MimeMessage message = new MimeMessage();
                Oauth2Service oauthService = new Oauth2Service(new BaseClientService.Initializer() { HttpClientInitializer = credential });

                // UserInfo.Get puede fallar en modo debug (un bug de Google API).
                // si esto sucede use "Start sin debugear".
                Userinfoplus userInfo = oauthService.Userinfo.Get().ExecuteAsync().Result;
                string userEmail = userInfo.Email;
                

                if(userEmail != ConfiguracionActual.CorreoUsuario)
                {
                    //Las credenciales de Gmail no corresponden con el correo configurado
                    credential.RevokeTokenAsync(CancellationToken.None);
                    credential.Token = null;
                    return 5;
                }

                MailKit.Net.Smtp.SmtpClient smtp = new MailKit.Net.Smtp.SmtpClient();
                try
                {
                    smtp.CheckCertificateRevocation = false;
                    smtp.Connect("smtp.gmail.com", Convert.ToInt32(ConfiguracionActual.CorreoPuerto), MailKit.Security.SecureSocketOptions.Auto); //StartTls 
                }
                catch
                {
                    SmtpInformacion.Clear();
                    SmtpInformacion.Add("correo" + " " + ConfiguracionActual.CorreoUsuario);
                    SmtpInformacion.Add("puerto" + " " + ConfiguracionActual.CorreoPuerto);
                    SmtpInformacion.Add("SecureSocketOptions" + " " + MailKit.Security.SecureSocketOptions.StartTls.ToString());
                    return 7;
                }

                try
                {
                    var oauth2 = new SaslMechanismOAuth2(userEmail, credential.Token.AccessToken);
                    smtp.Authenticate(oauth2);
                }
                catch
                {
                    return 8;
                }

                //Contenido del  correo
                message.From.Add(new MailboxAddress(Global.UsuarioActual.NombreCompleto(), userEmail));
                message.To.Add (new MailboxAddress (para, para));
                message.Subject = asunto;
                builder.HtmlBody = contenido;

                //Copias visibles en el correo
                if (copiasVisibles != null)
                {
                    foreach (string correoEnCopia in copiasVisibles)
                        message.To.Add(new MailboxAddress(correoEnCopia, correoEnCopia));
                }

                //copias ocultas
                if (copiasOcultas != null)
                {
                    foreach (string correosOcultos in copiasOcultas)
                        message.Bcc.Add(new MailboxAddress(correosOcultos, correosOcultos));
                }

                //Archivos adjuntos
                if (adjuntos != null)
                {
                    adjuntos.ForEach(delegate(Attachment att)
                    {
                        builder.Attachments.Add(att.Name, att.ContentStream);
                    });
                }

                //ponemos el cuerpo del mensaje
                message.Body = builder.ToMessageBody();
                smtp.Send(message);
                smtp.Disconnect(true);
            }
            catch(Exception ex)
            {
                return 4;
            }

             return idError;
        }
    }
}

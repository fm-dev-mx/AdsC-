using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;


namespace CB_Base.Classes
{
    static class NotificacionesCorreo
    {
        static public Configuracion Correo = new Configuracion();
     
        public static void NotificarOrdenTrabajo(int idOrden, List<string> copias = null)
        {
            if (!Correo.CorreoConfiguracionValida)
                return;


            PlanoCotizacion ordenTrabajo = new PlanoCotizacion();
            ordenTrabajo.CargarDatos(idOrden);
            int idPlano = Convert.ToInt32(ordenTrabajo.Fila().Celda("plano"));

            Proveedor proveedor = new Proveedor();
            proveedor.CargarDatos(Convert.ToInt32(ordenTrabajo.Fila().Celda("proveedor")));

            ProveedorContacto contacto = new ProveedorContacto();
            contacto.CargarDatos( Convert.ToInt32(proveedor.Fila().Celda("contacto")) );

            MailMessage mail = new MailMessage(Correo.CorreoUsuario, contacto.Fila().Celda("correo").ToString() );
            SmtpClient client = new SmtpClient();
            Attachment att;

            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(idPlano);

            ArchivoPlano archivo = new ArchivoPlano();
            archivo.SeleccionarDePlano(idPlano);

            byte[] adjunto = (byte[])archivo.Fila().Celda("archivo");

            if (adjunto != null)
            {
                att = new Attachment(new MemoryStream(adjunto), plano.Fila().Celda("nombre_archivo").ToString() + ".PDF");
                mail.Attachments.Add(att);

                att = new Attachment(new MemoryStream(FormatosPDF.DimensionesCriticas(idPlano, proveedor.Fila().Celda("nombre").ToString())), "DIMENSIONES CRITICAS " + plano.Fila().Celda("nombre_archivo").ToString() + ".pdf");
                mail.Attachments.Add(att);
            }

            client.Port = Convert.ToInt32(Correo.CorreoPuerto);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            if(copias != null )
            {
                copias.ForEach(delegate(string correo)
                {
                    mail.CC.Add(correo);
                });
            }
          
            client.Credentials = new System.Net.NetworkCredential(Correo.CorreoUsuario, Correo.CorreoPassword);


            client.Host = Correo.CorreoServidor;
            mail.Subject = "Orden de trabajo #" + idOrden.ToString() + ", plano " + plano.Fila().Celda("nombre_archivo");
            mail.Body = "<h3>Orden de trabajo</h3>"; 
            mail.Body += "Estimado proveedor,<br><br>";
            mail.Body += "<p>Favor de proceder con la fabricación de las piezas indicadas en el plano " + plano.Fila().Celda("nombre_archivo").ToString();
            mail.Body += ".PDF, correspondientes a la oden de trabajo #" + idOrden.ToString() + ", recuerde llenar el formato de dimensiones críticas que se encuentra adjunto.</p><br>";
            mail.Body += "<b>Precio final (MXN):</b> $" + ordenTrabajo.Fila().Celda("precio_final").ToString() + "<br>";
            mail.Body += "<b>Tiempo de entrega:</b> " + ordenTrabajo.Fila().Celda("tiempo_final").ToString() + " día(s)<br><br>";
            mail.Body += "Atentamente:<br>";
            mail.Body += Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");
            mail.BodyEncoding = Encoding.UTF8;
            
            mail.IsBodyHtml = true;
            
            client.Send(mail);
        }

    }
}

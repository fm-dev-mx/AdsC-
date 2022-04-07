using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CB_Base.Classes
{
    public static class Notificaciones
    {
        public static NotifyIcon Icono = new NotifyIcon();

        public static void Notificar(string titulo, string contenido, ToolTipIcon icono, int tiempo = 1000)
        {
            Icono.Visible = true;
            Icono.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Icono.BalloonTipIcon = icono;
            Icono.BalloonTipText = contenido;
            Icono.BalloonTipTitle = titulo;
            Icono.ShowBalloonTip(tiempo);
        }

        public static void NotificarEventos()
        {
            int idUsuario = (int) Global.UsuarioActual.Fila().Celda("id");
            
            string rolUsuario = Global.UsuarioActual.Fila().Celda("rol").ToString();
            EventoNotificacion eventoNotificacion = new EventoNotificacion();

            Evento.Modelo().BorrarAnteriores(3);

            if (!eventoNotificacion.Existe(idUsuario))
            {
                Fila parametros = new Fila();
                parametros.AgregarCelda("usuario", idUsuario);
                parametros.AgregarCelda("id_evento", 0);
                EventoNotificacion.Modelo().Insertar(parametros);
            }
            else
            {
                int id = 0;
                int ultimaNotificacion = 0;

                eventoNotificacion.SeleccionarDatos(idUsuario);
 
                id = (int)eventoNotificacion.Fila().Celda("id_evento");
                Evento.Modelo().Filtrar(rolUsuario, id).ForEach(delegate(Fila notificacion)
                {
                    string titulo = notificacion.Celda("titulo").ToString();
                    string contenido = notificacion.Celda("contenido").ToString();
                    ultimaNotificacion = (int)notificacion.Celda("id");

                    Notificar(titulo, contenido, ToolTipIcon.Info);
                    Task.Delay(10000);
                });

                if (ultimaNotificacion > 0)
                {
                   eventoNotificacion.SeleccionarDatos(idUsuario);
                   eventoNotificacion.Fila().ModificarCelda("id_evento", ultimaNotificacion);
                   eventoNotificacion.GuardarDatos();
                }
            }
        }
        public static void NotificarGenerales()
        {
            //switch (Global.UsuarioActual.Fila().Celda("rol").ToString())
            //{
            //    case "DISEÑADOR MECANICO":
            //    case "LIDER AUXILIAR DE DISEÑO":
            //           //PlanosSinRevisar();
            //        break;

            //    case "LIDER DE PROYECTO":
            //        PlanosSinRevisar();
            //        break;
            //}
        }

    }
}

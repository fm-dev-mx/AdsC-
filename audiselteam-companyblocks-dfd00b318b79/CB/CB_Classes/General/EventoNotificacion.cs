using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class EventoNotificacion : ModeloMySql
    {
        public EventoNotificacion()
        {
            Tabla = "evento_notificacion";
        }

        static public EventoNotificacion Modelo()
        {
            return new EventoNotificacion();
        }
        public bool Existe(int idUsuarioActual)
        {
            Dictionary<string, object> parametro = new Dictionary<string, object>();
            parametro.Add("@id_usuario", idUsuarioActual);

            SeleccionarDatos("usuario = @id_usuario",parametro);
            return TieneFilas();
        }
        public List<Fila> Filtrar(string RolUsuario, int ultimaNotificacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rolUsuario", RolUsuario);
            parametros.Add("@ultimaNotificacion", ultimaNotificacion);

            SeleccionarDatos("rol=@rolUsuario AND id > @ultimaNotificacion",parametros);
            return Filas();
        }
        public List<Fila> SeleccionarDatos(int idUsuario)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", idUsuario);
            SeleccionarDatos("usuario=@usuario", parametros);
            return Filas();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Evento : ModeloMySql
    {
        public Evento()
        {
            Tabla = "eventos";
        }

        static public Evento Modelo()
        {
            return new Evento();
        }
        public List<Fila> Filtrar(string RolUsuario, int ultimaNotificacion)
        {
            string nombreUsuario = Global.UsuarioActual.NombreCompleto();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rolUsuario", RolUsuario);
            parametros.Add("@ultimaNotificacion", ultimaNotificacion);
            parametros.Add("@usuario_creacion", nombreUsuario);

            string filtroRol = "";
            if (Global.UsuarioActual.Fila().Celda("rol").ToString() != "SUPERUSER")
                filtroRol = "rol=@rolUsuario AND ";

            SeleccionarDatos(filtroRol + "id > @ultimaNotificacion AND usuario_creacion != @usuario_creacion",parametros);
            return Filas();
        }
        public void BorrarAnteriores(int dias=10)
        {
            string interval = "INTERVAL " + dias + " DAY";
            string sql = "set sql_safe_updates = 0; delete from " + Tabla + " where fecha_creacion < date_sub(now(), " + interval + "); set sql_safe_updates = 1;";
            ConstruirQuery(sql);
            EjecutarQuery();
            Cerrar();
        }
        public void Crear(string tituloNotificacion, string contenido, string rol, string rolDestino = "")
        {
            var fecha = DateTime.Now;
            string nombre = Global.UsuarioActual.NombreCompleto();

            Fila InsertarNotificaion = new Fila();
            InsertarNotificaion.AgregarCelda("titulo", tituloNotificacion);
            InsertarNotificaion.AgregarCelda("contenido", contenido);
            InsertarNotificaion.AgregarCelda("rol", rol);
            InsertarNotificaion.AgregarCelda("fecha_creacion", fecha);
            InsertarNotificaion.AgregarCelda("usuario_creacion", nombre);
            if (rolDestino != string.Empty)
                InsertarNotificaion.AgregarCelda("rol_destinatario", rolDestino);
            Evento.Modelo().Insertar(InsertarNotificaion);
        }

        public List<Fila> SeleccionarUltimasNotificaciones()
        {
            string query = "SELECT * FROM " + Tabla + " ORDER BY id DESC LIMIT 0,20";
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
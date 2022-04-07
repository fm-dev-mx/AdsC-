using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Mantenimiento: ModeloMySql
    {
        public Mantenimiento()
        {
            Tabla = "mantenimientos";
        }

        static public Mantenimiento Modelo()
        {
            return new Mantenimiento();
        }

        public List<Fila> SeleccionarMantenimiento(int idEquipo, string tipoEquipo, string tipoMantenimiento, int ordenTrabajo = 0)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tipoMantenimiento", tipoMantenimiento);
            parametros.Add("@tipoEquipo", tipoEquipo);
            parametros.Add("@equipo", idEquipo);
            parametros.Add("@estatus", "PENDIENTE");
            parametros.Add("@ordenTrabajo", ordenTrabajo);
            string query = "tipo_mantenimiento=@tipoMantenimiento and tipo_equipo=@tipoEquipo and estatus=@estatus and equipo=@equipo ";

            if (ordenTrabajo > 0)
                query += " and orden_trabajo=@ordenTrabajo ";
            return SeleccionarDatos(query + "order by id desc", parametros);
        }

        public List<Fila> CargarUltimoMantenimientoTerminado(int idEquipo, string tipoEquipo, string tipoMantenimiento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tipoMantenimiento", tipoMantenimiento);
            parametros.Add("@tipoEquipo", tipoEquipo);
            parametros.Add("@equipo", idEquipo);
            parametros.Add("@estatus", "TERMINADO");
            return SeleccionarDatos("tipo_mantenimiento=@tipoMantenimiento and tipo_equipo=@tipoEquipo and estatus=@estatus and equipo=@equipo order by id desc limit 1", parametros);
        }

        public List<Fila> CargarMantenimientoCorrectivoOrdenTrabajo(int idEquipo, string tipoEquipo, string tipoMantenimiento, int idOrdenTrabajo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tipoMantenimiento", "CORRECTIVO");
            parametros.Add("@tipoEquipo", tipoEquipo);
            parametros.Add("@equipo", idEquipo);
            parametros.Add("@estatus", "TERMINADO");
            parametros.Add("@idOrdenTrabajo", idOrdenTrabajo);
            return SeleccionarDatos("tipo_mantenimiento=@tipoMantenimiento and tipo_equipo=@tipoEquipo and estatus=@estatus and equipo=@equipo and orden_trabajo=@idOrdenTrabajo", parametros);
        }

        public List<Fila> CargarHistorialMantenimiento( string tipoEquipo)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE tipo_equipo=@tipoEquipo and estatus=@estatus";

            ConstruirQuery(sql);
            AgregarParametro("@tipoEquipo", tipoEquipo);
            AgregarParametro("@estatus", "TERMINADO");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarHistorialMantenimientoEquipo(string tipoMantenimiento, string tipoEquipo, int idEquipo)
        {
            string sql = "";
            if (tipoMantenimiento == "TODOS" && tipoEquipo == "TODOS")
                sql = "SELECT * FROM " + Tabla + " WHERE equipo=@equipo and estatus=@estatus";
            else if (tipoMantenimiento != "TODOS" && tipoEquipo == "TODOS")
                sql = "SELECT * FROM " + Tabla + " WHERE tipo_mantenimiento=@tipoMantenimiento and equipo=@equipo and estatus=@estatus";
            else if (tipoMantenimiento != "TODOS" && tipoEquipo != "TODOS")
                sql = "SELECT * FROM " + Tabla + " WHERE tipo_mantenimiento=@tipoMantenimiento and tipo_equipo=@tipoEquipo and equipo=@equipo and estatus=@estatus";
            else if (tipoMantenimiento == "TODOS" && tipoEquipo != "TODOS")
                sql = "SELECT * FROM " + Tabla + " WHERE tipo_equipo=@tipoEquipo and equipo=@equipo and estatus=@estatus";

            ConstruirQuery(sql);
            AgregarParametro("@tipoMantenimiento", tipoMantenimiento);
            AgregarParametro("@tipoEquipo", tipoEquipo);
            AgregarParametro("@equipo", idEquipo);
            AgregarParametro("@estatus", "TERMINADO");
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

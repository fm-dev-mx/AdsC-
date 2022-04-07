using System.Collections.Generic;

namespace CB_Base.Classes
{
    class Accion : ModeloMySql
    {
        public Accion()
        {
            Tabla = "acciones";
        }

        static public Accion Modelo()
        {
            return new Accion();
        }

        public List<Fila> Cargar(int id)
        {
            string sql = "SELECT acciones.id AS id_accion, acciones.tipo AS tipo_accion, ";
            sql += "tareas_topicos.* FROM " + Tabla + " WHERE id=@id INNER JOIN tareas_topicos ON tareas_topicos.id=acciones.tarea";
            ConstruirQuery(sql);
            AgregarParametro("@id", id);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarNoConformidad(int noConformidad, string tipo = "TODAS")
        {
            string sql = "SELECT acciones.id AS id_accion, acciones.tipo AS tipo_accion, acciones.tarea AS tarea_accion, ";
            sql += "tareas_topicos.* FROM " + Tabla + " ";
            sql += "INNER JOIN tareas_topicos ON tareas_topicos.id=acciones.tarea WHERE acciones.no_conformidad=@noConformidad";

            if (tipo != "TODAS")
                sql += " AND tipo=@tipo";

            ConstruirQuery(sql);
            AgregarParametro("@noConformidad", noConformidad);
            AgregarParametro("@tipo", tipo);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarAccionesNoNotificadas(int noConformidad)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE acciones.no_conformidad=@noConformidad and acciones.notificacion=@notificacion";

            ConstruirQuery(sql);
            AgregarParametro("@noConformidad", noConformidad);
            AgregarParametro("@notificacion", 0);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarTarea(int tarea)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE tarea=@tarea";

            ConstruirQuery(sql);
            AgregarParametro("@tarea", tarea);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarAcciones(int noConformidad)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE acciones.no_conformidad=@noConformidad";

            ConstruirQuery(sql);
            AgregarParametro("@noConformidad", noConformidad);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarAccionesPorIndicador(int idIndicador, string filtroEstatus, string filtroEfectividad)
        {
            string sql = "SELECT acciones.id as idAcciones, acciones.indicador, acciones.tipo, acciones.fecha_creacion, acciones.usuario_creacion, acciones.efectividad, acciones.fecha_evaluacion, " +
                         "tareas_topicos.id, tareas_topicos.estatus, tareas_topicos.descripcion, tareas_topicos.fecha_promesa, "+
                         "tareas_responsables.responsable " +
                         "FROM " + Tabla + " "+
                         "inner join tareas_topicos on tareas_topicos.id = acciones.tarea " +
                         "inner join tareas_responsables on tareas_responsables.tarea = tareas_topicos.id " +
                         "where acciones.indicador=@indicador";

            if (filtroEstatus != "" && filtroEstatus != "TODO")
                sql += " and tareas_topicos.estatus=@estatus";

            if(filtroEfectividad != "" && filtroEfectividad != "TODO")
                sql += " and acciones.efectividad=@efectividad";

            ConstruirQuery(sql);
            AgregarParametro("@indicador", idIndicador);
            AgregarParametro("@estatus", filtroEstatus);
            AgregarParametro("@efectividad", filtroEfectividad);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarAccionYTareas(int IdAccion)
        {
            string sql = "SELECT acciones.id, acciones.tipo, acciones.indicador, " +
                         "tareas_topicos.descripcion, tareas_topicos.estatus, tareas_topicos.fecha_promesa " +
                         "FROM " + Tabla + " " +
                         "Inner join tareas_topicos on tareas_topicos.id = acciones.tarea " +
                         "where acciones.id = @idAccion";

            ConstruirQuery(sql);
            AgregarParametro("@idAccion", IdAccion);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

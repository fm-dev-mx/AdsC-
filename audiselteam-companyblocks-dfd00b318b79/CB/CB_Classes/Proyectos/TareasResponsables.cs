using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TareasResponsables : ModeloMySql
    {
        public TareasResponsables()
        {
            Tabla = "tareas_responsables";
        }

        static public TareasResponsables Modelo()
        {
            return new TareasResponsables();
        }

        public List<Fila> SeleccionarTarea(int idTarea)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE tarea=@tarea";
            ConstruirQuery(sql);
            AgregarParametro("@tarea", idTarea);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarTareasDeUsuario(int idResponsable, bool mostrarTerminado)
        {
            string sql = string.Empty;
            sql += "select ";
            sql += "tareas_topicos.id, ";
            sql += "topicos.proyecto, ";
            sql += "tareas_topicos.nombre, ";
            sql += "tareas_topicos.descripcion, ";
            sql += "tareas_topicos.fecha_promesa, ";
            sql += "tareas_topicos.prioridad, ";
            sql += "tareas_topicos.estatus, ";
            sql += "tareas_involucrados.nombre_usuario ";
            sql += "from tareas_topicos ";
            sql += "INNER JOIN topicos on topicos.id = tareas_topicos.topico ";
            sql += "INNER JOIN tareas_involucrados ON tareas_involucrados.tarea = tareas_topicos.id ";
            sql += "where tareas_topicos.id in (select tarea from tareas_responsables where id_responsable = @idResponsable) ";
            sql += "OR tareas_involucrados.id_usuario = @idResponsable ";


            if (!mostrarTerminado)
                sql += "and tareas_topicos.estatus not in ('TERMINADO', 'REVISADO')";

            ConstruirQuery(sql);
            AgregarParametro("@idResponsable", idResponsable);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> HorasTrabajo(int idResponsable, bool mostrarTerminado)
        {
            string sql = string.Empty;
            sql += "select ";
            sql += "sum(tareas_topicos.horas) as horas ";
            sql += "from tareas_topicos ";
            sql += "INNER JOIN topicos on topicos.id = tareas_topicos.topico ";
            sql += "INNER JOIN tareas_involucrados ON tareas_involucrados.tarea = tareas_topicos.id ";
            sql += "where tareas_topicos.id in (select tarea from tareas_responsables where id_responsable = @idResponsable) ";
            sql += "OR tareas_involucrados.id_usuario = @idResponsable ";


            if (!mostrarTerminado)
                sql += "and tareas_topicos.estatus not in ('TERMINADO', 'REVISADO')";

            ConstruirQuery(sql);
            AgregarParametro("@idResponsable", idResponsable);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

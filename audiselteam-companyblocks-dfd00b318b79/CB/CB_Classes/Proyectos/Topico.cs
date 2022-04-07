using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class Topico : ModeloMySql
    {
        public Topico()
        {
            Tabla = "topicos";
        }

        static public Topico Modelo()
        {
            return new Topico();
        }

        public List<Fila> CargarTareasTopicosEnTopicos(string proyecto, string estatus, string fechaDesde, string fechaHasta)
        {
            string sql = "";

            if(estatus=="TODOS")
                sql = "SELECT proyecto FROM " + Tabla + " inner join tareas_topicos on tareas_topicos.topico = topicos.id where date(fecha_creacion) between @desde and @hasta and topicos.proyecto =@proyecto";
            else
                sql = "SELECT proyecto FROM " + Tabla + " inner join tareas_topicos on tareas_topicos.topico = topicos.id where date(fecha_creacion) between @desde and @hasta and topicos.proyecto =@proyecto and tareas_topicos.estatus=@estatus";
            
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@desde", fechaDesde);
            AgregarParametro("@hasta", fechaHasta);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarTareasDeProyecto(decimal proyecto, bool mostrarRevisados)
        {
            string sql = "";
            sql += "select tareas_topicos.id, ";
            sql += "topicos.fecha_creacion as Junta_sinc,";
            sql += "tareas_topicos.nombre as tarea_nombre,";
            sql += "tareas_topicos.estatus,";
            sql += "tareas_topicos.prioridad,";
            sql += "tareas_topicos.descripcion, tareas_topicos.estatus_tiempo,";
            sql += "topicos.id as id_topico ,";
            sql += "tareas_topicos.fecha_promesa ";
            sql += "from topicos ";
            sql += "INNER JOIN tareas_topicos ON tareas_topicos.topico = topicos.id ";
            sql += "where topicos.proyecto =@proyecto ";
            if(!mostrarRevisados)
                sql += " and tareas_topicos.estatus NOT IN ('REVISADO')";
            sql += " ORDER BY tareas_topicos.prioridad desc;";

            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarTopicosDeProyecto(decimal proyecto)
        {
            string sql = "";
            sql = "SELECT * FROM " + Tabla + " WHERE proyecto=@proyecto";
          
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

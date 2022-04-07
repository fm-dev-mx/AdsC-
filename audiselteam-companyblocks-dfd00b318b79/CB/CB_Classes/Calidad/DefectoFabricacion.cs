using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class DefectoFabricacion : ModeloMySql
    {
        public DefectoFabricacion()
        {
            Tabla = "defectos_fabricacion";
        }

        static public DefectoFabricacion Modelo()
        {
            return new DefectoFabricacion();
        }

        public List<Fila> SeleccionarDefectosPorPlanos(int idPlano)
        {
            string query = "SELECT ";
            query += "  defectos_fabricacion.id,";
            query += "  planos_procesos.proceso,";
            query += "  planos_procesos.operador,";
            query += "  defectos_fabricacion.detalles_defecto,";
            query += "  tipos_defectos.tipos as tipo_defecto,";
            query += "  defectos_fabricacion.cantidad_ok,";
            query += "  defectos_fabricacion.cantidad_nok,";
            query += "  planos_proyectos.nombre_archivo,";
            query += "  planos_proyectos.id as id_proyecto,";
            query += "  planos_proyectos.proyecto,";
            query += "  planos_proyectos.estatus,";
            query += "  proyectos.nombre as nombre_proyecto ";
            query += "from defectos_fabricacion ";
            query += "INNER JOIN planos_procesos ON planos_procesos.id = defectos_fabricacion.proceso_fabricacion ";
            query += "INNER JOIN tipos_defectos ON tipos_defectos.id = defectos_fabricacion.tipo_defecto ";
            query += "INNER JOIN planos_proyectos ON planos_proyectos.id =  planos_procesos.plano ";
            query += "INNER JOIN proyectos ON proyectos.id = planos_proyectos.proyecto ";
            query += "WHERE planos_proyectos.id = @idPlano;";

            ConstruirQuery(query);
            AgregarParametro("@idPlano", idPlano);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarDefectos(DateTime desde, DateTime hasta, string herramentista, string estatus, string proyecto)
        {
            string query = "SELECT ";
            query += "  defectos_fabricacion.id,";
            query += "  planos_proyectos.id as id_proyecto,";
            query += "  planos_proyectos.proyecto,";
            query += "  planos_proyectos.nombre_archivo,";
            query += "  planos_proyectos.estatus,";
            query += "  proyectos.nombre as nombre_proyecto ";
            query += "from defectos_fabricacion ";
            query += "INNER JOIN planos_procesos ON planos_procesos.id = defectos_fabricacion.proceso_fabricacion ";
            query += "INNER JOIN tipos_defectos ON tipos_defectos.id = defectos_fabricacion.tipo_defecto ";
            query += "INNER JOIN planos_proyectos ON planos_proyectos.id =  planos_procesos.plano ";
            query += "INNER JOIN proyectos ON proyectos.id = planos_proyectos.proyecto ";
            query += "WHERE DATE(defectos_fabricacion.fecha_creacion) BETWEEN DATE(@desde) AND DATE(@hasta) ";

            if (herramentista != "TODOS")
                query += " AND planos_procesos.operador = @herramentista";

            if(estatus == "DEFECTO")
                query += " AND planos_proyectos.estatus = 'DEFECTO' ";
            else
                query += " AND planos_proyectos.estatus != 'DEFECTO' ";

            if(proyecto != "TODOS")
            {
                string[] strProyecto = proyecto.Split('-');
                proyecto = strProyecto[0];
                query += " AND planos_proyectos.proyecto = @ProyectoDefecto ";
            }

            query += "GROUP BY id_proyecto";

            ConstruirQuery(query);
            AgregarParametro("@desde", desde.Date);
            AgregarParametro("@hasta", hasta.Date);
            AgregarParametro("@herramentista", herramentista);
            AgregarParametro("@ProyectoDefecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarDefectosDePlano(int idPlano)
        {
            string query = "SELECT ";
            query += "  defectos_fabricacion.id,";
            query += "  planos_procesos.proceso,";
            query += "  defectos_fabricacion.detalles_defecto,";
            query += "  tipos_defectos.tipos as tipo_defecto,";
            query += "  defectos_fabricacion.cantidad_ok,";
            query += "  defectos_fabricacion.cantidad_nok ";
            query += "from defectos_fabricacion ";
            query += "INNER JOIN planos_procesos ON planos_procesos.id = defectos_fabricacion.proceso_fabricacion ";
            query += "INNER JOIN tipos_defectos ON tipos_defectos.id = defectos_fabricacion.tipo_defecto ";
            query += "WHERE defectos_fabricacion.plano=@idPlano";

            ConstruirQuery(query);
            AgregarParametro("@idPlano", idPlano);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProyectosConDefectos()
        {
            string query = "select ";
            query += "defectos_fabricacion.plano, ";
            query += "planos_proyectos.proyecto, ";
            query += "proyectos.nombre ";
            query += "from defectos_fabricacion ";
            query += "INNER JOIN planos_proyectos ON planos_proyectos.id = defectos_fabricacion.plano ";
            query += "INNER JOIN proyectos ON proyectos.id = planos_proyectos.proyecto ";
            query += "GROUP BY planos_proyectos.proyecto;";

            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

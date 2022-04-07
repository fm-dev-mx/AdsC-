using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class ProyectoProceso : ModeloMySql
    {

        public ProyectoProceso()
        {
            Tabla = "proyectos_procesos";
        }

        static public ProyectoProceso Modelo()
        {
            return new ProyectoProceso();
        }
        
        public List<Fila> SeleccionarProyecto(decimal idProyecto)
        {
            string sql = string.Empty;

            sql += "SELECT proyectos_procesos.*, procesos.nombre AS nombre_proceso FROM proyectos_procesos ";
            sql += "INNER JOIN procesos ON procesos.id=proyectos_procesos.proceso ";
            sql += "WHERE proyecto=@proyecto ORDER BY fecha_inicio ASC";

            ConstruirQuery(sql);
            AgregarParametro("@proyecto", idProyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProyectoProceso(decimal idProyecto, int idProceso)
        {
            ConstruirQuery("SELECT * FROM proyectos_procesos WHERE proyecto=@proyecto AND proceso=@proceso");
            AgregarParametro("@proyecto", idProyecto);
            AgregarParametro("@proceso", idProceso);
            EjecutarQuery();
            return LeerFilas();
        } 

        public List<Fila> SeleccionarMetaComprasExistente(decimal idProyecto, int idProceso)
        {
            ConstruirQuery("SELECT * FROM proyectos_procesos WHERE proyecto=@proyecto AND proceso=@proceso AND DATE(fecha_fin) >= DATE(Now())");
            AgregarParametro("@proyecto", idProyecto);
            AgregarParametro("@proceso", idProceso);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

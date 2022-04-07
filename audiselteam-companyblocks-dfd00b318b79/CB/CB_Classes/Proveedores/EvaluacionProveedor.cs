using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class EvaluacionProveedor : ModeloMySql
    {
        public EvaluacionProveedor()
        {
            Tabla = "evaluaciones_proveedores";    
        }

        static public EvaluacionProveedor Modelo()
        {
            return new EvaluacionProveedor();
        }

        public List<Fila> VerificarEvaluacionPendiente(int idProveedor)
        {
            string sql = "SELECT * from " + Tabla + " where proveedor=@proveedor and resultado=0";
            ConstruirQuery(sql);
            AgregarParametro("@proveedor", idProveedor);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> PromedioEvaluaciones(int idEvaluado)
        {
            string sql = "SELECT AVG(resultado) as promedio_resultado from " + Tabla + " where proveedor=@id and fecha!=''";
            ConstruirQuery(sql);
            AgregarParametro("@id", idEvaluado);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Evaluaciones(int idEvaluado)
        {
            string sql = "SELECT * from " + Tabla + " where proveedor=@id";
            ConstruirQuery(sql);
            AgregarParametro("@id", idEvaluado);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Seleccionar3UltimasEvaluaciones(int idProveedor)
        {
            string sql = "SELECT * from " + Tabla + " where proveedor=@id ORDER BY id desc limit 3";
            ConstruirQuery(sql);
            AgregarParametro("@id", idProveedor);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarEvaluacionDePeriodo(string fechaInicio, string fechaFin)
        {
            string sql = string.Empty;

            sql += "select "; 
	        sql += "    evaluaciones_proveedores.id,"; 
            sql += "    proveedores.nombre,";
            //sql += "    habilidades.habilidad,";
            //sql += "    evaluaciones_habilidades_proveedores.puntuacion,";
            sql += "    evaluaciones_proveedores.resultado,";
            sql += "    proveedores.categoria,";
            sql += "    evaluaciones_proveedores.fecha "; 
            sql += "from "; 
	        sql += "    evaluaciones_proveedores "; 
            sql += "INNER JOIN "; 
	        sql += "    proveedores ON proveedores.id = evaluaciones_proveedores.proveedor "; 
           //  sql += "INNER JOIN ";
	       //  sql += "    evaluaciones_habilidades_proveedores ON evaluaciones_habilidades_proveedores.evaluacion = evaluaciones_proveedores.id ";
           //  sql += "INNER JOIN ";
           //  sql += "    habilidades ON habilidades.id = evaluaciones_habilidades_proveedores.habilidad ";
            sql += "WHERE ";
            sql += "    DATE(evaluaciones_proveedores.fecha) BETWEEN DATE('" + fechaInicio + "') AND DATE('" + fechaFin + "');"; 

            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

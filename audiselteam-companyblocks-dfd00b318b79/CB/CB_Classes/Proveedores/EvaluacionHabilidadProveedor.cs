using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class EvaluacionHabilidadProveedor : ModeloMySql
    {
        public EvaluacionHabilidadProveedor()
        {
            Tabla = "evaluaciones_habilidades_proveedores";
        }

        static public EvaluacionHabilidadProveedor Modelo()
        {
            return new EvaluacionHabilidadProveedor();
        }

        public List<Fila> SeleccionarEvaluaciones(int idEvaluacion, int intHabilidad)
        {
            string sql = "SELECT * from " + Tabla + " where evaluacion=@idEvaluacion and habilidad=@habilidad";
            ConstruirQuery(sql);
            AgregarParametro("@idEvaluacion", idEvaluacion);
            AgregarParametro("@habilidad", intHabilidad);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarHabilidades(int idEvaluacion)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE evaluacion=@evaluacion";
            ConstruirQuery(sql);
            AgregarParametro("@evaluacion", idEvaluacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarHabilidadesPuntuacion(int idEvaluacion)
        {
            string sql = "select habilidades.habilidad, evaluaciones_habilidades_proveedores.puntuacion from evaluaciones_habilidades_proveedores ";
            sql += "INNER JOIN habilidades ON habilidades.id = evaluaciones_habilidades_proveedores.habilidad ";
            sql += "WHERE evaluacion = @idEvaluacion;";

            ConstruirQuery(sql);
            AgregarParametro("@idEvaluacion", idEvaluacion);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

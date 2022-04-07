using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class EvaluacionHabilidad : ModeloMySql
    {
        public EvaluacionHabilidad()
        {
            Tabla = "evaluaciones_habilidades";
        }

        static public EvaluacionHabilidad Modelo()
        {
            return new EvaluacionHabilidad();
        }

        public List<Fila> SeleccionarHabilidades(int idEvaluacion)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE evaluacion=@evaluacion and habilidad_topico=0"; //group by habilidad " ;
            ConstruirQuery(sql);
            AgregarParametro("@evaluacion", idEvaluacion);
            EjecutarQuery();
            return LeerFilas();           
        }

        public List<Fila> SeleccionarHabilidadesId(int idEvaluacion, int idHabilidad)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE evaluacion=@evaluacion and habilidad=@idHabilidad";
            ConstruirQuery(sql);
            AgregarParametro("@evaluacion", idEvaluacion);
            AgregarParametro("@idHabilidad", idHabilidad);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarHabilidad(int idEvaluacion, int idHabilidad)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE evaluacion=@evaluacion and habilidad=@idHabilidad and habilidad_topico=0";
            ConstruirQuery(sql);
            AgregarParametro("@evaluacion", idEvaluacion);
            AgregarParametro("@idHabilidad", idHabilidad);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarHabilidadesTopico(int idEvaluacion, int idHabilidad, int idTopico)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE evaluacion=@evaluacion and habilidad=@idHabilidad and habilidad_topico=@topico";
            ConstruirQuery(sql);
            AgregarParametro("@evaluacion", idEvaluacion);
            AgregarParametro("@idHabilidad", idHabilidad);
            AgregarParametro("@topico", idTopico);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

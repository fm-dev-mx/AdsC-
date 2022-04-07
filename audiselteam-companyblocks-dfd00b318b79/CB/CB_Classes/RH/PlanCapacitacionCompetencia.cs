using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PlanCapacitacionCompetencia : ModeloMySql
    {
        public PlanCapacitacionCompetencia()
        {
            Tabla = "planes_capacitacion_competencias";
        }

        static public PlanCapacitacionCompetencia Modelo()
        {
            return new PlanCapacitacionCompetencia();
        }

        public List<Fila> BuscarCompetencia(int idCompetencia)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idCompetencia", idCompetencia);

            return SeleccionarDatos("competencia=@idCompetencia", parametros);
        }

        public List<Fila> SeleccionarCompetencias(int idPlanCapacitacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@planCapacitacion", idPlanCapacitacion);

            return SeleccionarDatos("plan_capacitacion=@planCapacitacion", parametros);
        }

        public List<Fila> SeleccionarHabilidades(int idPlanCapacitacion, string tipo)
        {
            string query = "SELECT habilidades.id as idCompetencia, habilidades.habilidad, planes_capacitacion_competencias.id as id_competencias FROM habilidades inner join planes_capacitacion_competencias on planes_capacitacion_competencias.competencia = habilidades.id where planes_capacitacion_competencias.plan_capacitacion=@idPlanCapacitacion and habilidades.tipo=@tipo";
            ConstruirQuery(query);
            AgregarParametro("@idPlanCapacitacion", idPlanCapacitacion);
            AgregarParametro("@tipo", tipo);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarPlanesCapacitacion(List<int> competencias, DateTime fechaDe, DateTime fechaHasta)
        {
            string strParametro = string.Empty;
            if(competencias.Count <= 0)
                return null;

            foreach (int idCompetencia in competencias)
            {
                if (strParametro != "")
                    strParametro += " or ";
               // if (strParametro == "")
               //     strParametro += "(";
                strParametro += "competencia=" + idCompetencia;
            }
            
           // strParametro += ")  and date(planes_capacitacion.fecha_modificacion) >=@fechaDe and date(planes_capacitacion.fecha_modificacion) <=@fechaHasta ";
            string query = "SELECT planes_capacitacion.id, planes_capacitacion.nombre, planes_capacitacion.descripcion, planes_capacitacion.duracion, planes_capacitacion.material, planes_capacitacion.usuario_creacion, planes_capacitacion.fecha_creacion, planes_capacitacion.usuario_modificacion, planes_capacitacion.fecha_modificacion, " +
                           " planes_capacitacion_competencias.plan_capacitacion FROM planes_capacitacion" + 
                           " inner join planes_capacitacion_competencias ON planes_capacitacion_competencias.plan_capacitacion = planes_capacitacion.id" +
                           " WHERE " + strParametro;
            ConstruirQuery(query);
            //AgregarParametro("@fechaDe", fechaDe.Date);
            //AgregarParametro("@fechaHasta", fechaHasta.Date);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Evaluacion : ModeloMySql
    {
        public Evaluacion()
        {
            Tabla = "evaluaciones";
        }

        static public Evaluacion Modelo()
        {
            return new Evaluacion();
        }

        public List<Fila> PromedioEvaluaciones(int idEvaluado)
        {
            string sql = "SELECT AVG(resultado) as promedio_resultado from " + Tabla + " where evaluado=@id and fecha!=''";
            ConstruirQuery(sql);
            AgregarParametro("@id", idEvaluado);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Evaluaciones(int idEvaluado)
        {
            string sql = "SELECT * from " + Tabla + " where evaluado=@id";
            ConstruirQuery(sql);
            AgregarParametro("@id", idEvaluado);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> VerificarEvaluacionPendiente(int idEvaluado, int idEvaluador)
        {
            string sql = "SELECT * from " + Tabla + " where evaluado=@idEvaluado and evaluador=@idEvaluador and resultado=0";
            ConstruirQuery(sql);
            AgregarParametro("@idEvaluado", idEvaluado);
            AgregarParametro("@idEvaluador", idEvaluador);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarResponsablesCapacitacion(DateTime fechaActual, int idHabilidad)
        {
            string fechaDe = string.Empty;
            string fechaHasta = string.Empty;

           if(fechaActual.Date >= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01").Date && fechaActual <= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-06-30").Date)
           {
               fechaDe = DateTime.Now.Year.ToString() + "-01-01";
               fechaHasta = DateTime.Now.Year.ToString() + "-06-30";
           }
           else 
           {
               fechaDe = DateTime.Now.Year.ToString() + "-07-01";
               fechaHasta = DateTime.Now.Year.ToString() + "-12-31";
           }

           string sql = "SELECT evaluaciones.evaluado, usuarios.nombre, usuarios.paterno " +
                         "FROM audisel.evaluaciones_habilidades " +
                         "INNER JOIN audisel.evaluaciones ON evaluaciones_habilidades.evaluacion=evaluaciones.id " +
                         "INNER JOIN audisel.usuarios ON evaluaciones.evaluado = usuarios.id " +
                         "where date(evaluaciones.fecha) between '" + fechaDe + "' and '" + fechaHasta + "' and evaluaciones_habilidades.habilidad=@idHabilidad and evaluaciones_habilidades.habilidad_topico=0 and usuarios.activo=1 and evaluaciones_habilidades.puntuacion > 80 group by evaluaciones.evaluado";
            
            ConstruirQuery(sql);
            AgregarParametro("@idHabilidad", idHabilidad);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarParticipantesCapacitacion(DateTime fechaActual, int idHabilidad)
        {
            string fechaDe = string.Empty;
            string fechaHasta = string.Empty;

            if (fechaActual.Date >= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01").Date && fechaActual <= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-06-30").Date)
            {
                fechaDe = DateTime.Now.Year.ToString() + "-01-01";
                fechaHasta = DateTime.Now.Year.ToString() + "-06-30";
            }
            else
            {
                fechaDe = DateTime.Now.Year.ToString() + "-07-01";
                fechaHasta = DateTime.Now.Year.ToString() + "-12-31";
            }

            string sql = "SELECT evaluaciones.evaluado, usuarios.nombre, usuarios.paterno " +
                          "FROM audisel.evaluaciones_habilidades " +
                          "INNER JOIN audisel.evaluaciones ON evaluaciones_habilidades.evaluacion=evaluaciones.id " +
                          "INNER JOIN audisel.usuarios ON evaluaciones.evaluado = usuarios.id " +
                          "where date(evaluaciones.fecha) between '" + fechaDe + "' and '" + fechaHasta + "' and evaluaciones_habilidades.habilidad=@idHabilidad and evaluaciones_habilidades.habilidad_topico=0 and usuarios.activo=1 and evaluaciones_habilidades.puntuacion < 80 group by evaluaciones.evaluado";

            ConstruirQuery(sql);
            AgregarParametro("@idHabilidad", idHabilidad);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

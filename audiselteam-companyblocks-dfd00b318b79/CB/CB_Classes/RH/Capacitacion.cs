using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Capacitacion : ModeloMySql
    {
        public Capacitacion()
        {
            Tabla = "capacitaciones";
        }

        static public Capacitacion Modelo()
        {
            return new Capacitacion();
        }

        public List<Fila> BuscarPlanCapacitacion(int evento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@evento", evento);

            return SeleccionarDatos("evento=@evento", parametros);
        }

        public List<Fila> BuscarEvento(int planCapacitacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@planCapacitacion", planCapacitacion);

            return SeleccionarDatos("plan_capacitacion=@planCapacitacion", parametros);
        }

        public List<Fila> SeleccionarResponsable(int evento)
        {
            string sql = "SELECT capacitaciones.plan_capacitacion, usuarios.nombre, usuarios.paterno " +
                         "FROM audisel.capacitaciones " +
                         "INNER JOIN audisel.usuarios on usuarios.id = capacitaciones.responsable " +
                         "WHERE evento=@evento";
            ConstruirQuery(sql);
            AgregarParametro("@evento", evento);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

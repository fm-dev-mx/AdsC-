using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PlanCapacitacion : ModeloMySql
    {
        public PlanCapacitacion()
        {
            Tabla = "planes_capacitacion";
        }

        static public PlanCapacitacion Modelo()
        {
            return new PlanCapacitacion();
        }

        public List<Fila> BuscarPlanCapacitacion(string planCapacitacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", planCapacitacion);

            return SeleccionarDatos("nombre=@nombre", parametros);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PracticaCapacitacion : ModeloMySql
    {
        public PracticaCapacitacion()
        {
            Tabla = "practicas_capacitaciones";
        }

        static public PracticaCapacitacion Modelo()
        {
            return new PracticaCapacitacion();
        }

        public List<Fila> SeleccionarPracticas(int planCapacitacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@planCapacitacion", planCapacitacion);

            return SeleccionarDatos("plan_capacitacion=@planCapacitacion", parametros);
        }
    }
}

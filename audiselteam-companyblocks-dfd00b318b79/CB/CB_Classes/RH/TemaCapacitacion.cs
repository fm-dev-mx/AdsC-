using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TemaCapacitacion : ModeloMySql
    {
        public TemaCapacitacion()
        {
            Tabla = "temas_capacitaciones";
        }

        static public TemaCapacitacion Modelo()
        {
            return new TemaCapacitacion();
        }

        public List<Fila> SeleccionarTemas(int planCapacitacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@planCapacitacion", planCapacitacion);

            return SeleccionarDatos("plan_capacitacion=@planCapacitacion", parametros);
        }
    }
}

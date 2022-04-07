using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class AnexoCapacitacion : ModeloMySql
    {
        public AnexoCapacitacion()
        {
            Tabla = "anexos_capacitaciones";
        }

        static public AnexoCapacitacion Modelo()
        {
            return new AnexoCapacitacion();
        }

        public List<Fila> BuscarAnexo(int planCapacitacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@planCapacitacion", planCapacitacion);

            return SeleccionarDatos("plan_capacitacion=@planCapacitacion", parametros);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Vehiculo : ModeloMySql
    {
        public Vehiculo()
        {
            Tabla = "vehiculos";
        }

        static public Vehiculo Modelo()
        {
            return new Vehiculo();
        }

        public List<Fila> SeleccionarResponsable(string responsable)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@responsable", responsable);
            return SeleccionarDatos("responsable=@responsable", parametros);
        }
    }
}

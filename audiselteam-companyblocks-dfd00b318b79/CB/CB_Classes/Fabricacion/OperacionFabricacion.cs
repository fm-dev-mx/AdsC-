using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class OperacionFabricacion : ModeloMySql
    {
        public OperacionFabricacion()
        {
            Tabla = "operaciones_fabricacion";
        }

        static public OperacionFabricacion Modelo()
        {
            return new OperacionFabricacion();
        }

        public List<Fila> SeleccionarOperaciones(string NombreProceso)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proceso", NombreProceso);
            return SeleccionarDatos("nombre_proceso=@proceso", parametros);
        }

        public List<Fila> SeleccionarOperacionNombe(string NombreProceso, string NombreOperacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proceso", NombreProceso);
            parametros.Add("@operacion", NombreOperacion);
            return SeleccionarDatos("nombre_proceso=@proceso and nombre_operacion=@operacion", parametros);
        }
    }
}

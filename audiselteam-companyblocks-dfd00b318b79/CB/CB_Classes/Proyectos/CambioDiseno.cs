using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CambioDiseno : ModeloMySql
    {

        public CambioDiseno()
        {
            Tabla = "cambios_diseno";
        }

        static public CambioDiseno Modelo()
        {
            return new CambioDiseno();
        }

        public List<Fila> SeleccionarProyecto(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            return SeleccionarDatos("proyecto=@proyecto", parametros);
        }

        public List<Fila> SeleccionarNoConformidad(int noConformidad)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nc", noConformidad);
            return SeleccionarDatos("no_conformidad=@nc", parametros);
        }
    }
}

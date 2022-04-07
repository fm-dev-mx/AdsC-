using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RequerimientoRestriccion : ModeloMySql
    {

        public RequerimientoRestriccion()
        {
            Tabla = "requerimientos_restricciones";
        }

        static public RequerimientoRestriccion Modelo()
        {
            return new RequerimientoRestriccion();
        }

        public List<Fila> SeleccionarRequerimiento(int idRequerimiento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@requerimiento", idRequerimiento);
            return SeleccionarDatos("requerimiento=@requerimiento", parametros);
        }

    }
}

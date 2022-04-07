using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RequerimientoResponsable : ModeloMySql
    {

        public RequerimientoResponsable()
        {
            Tabla = "requerimientos_responsables";
        }

        static public RequerimientoResponsable Modelo()
        {
            return new RequerimientoResponsable();
        }

        public List<Fila> SeleccionarRequerimiento(int idRequerimiento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@requerimiento", idRequerimiento);
            return SeleccionarDatos("requerimiento=@requerimiento", parametros);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RequerimientoKeyitem : ModeloMySql
    {

        public RequerimientoKeyitem()
        {
            Tabla = "requerimientos_keyitems";
        }

        static public RequerimientoKeyitem Modelo()
        {
            return new RequerimientoKeyitem();
        }

        public List<Fila> SeleccionarRequerimiento(int requerimiento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@requerimiento", requerimiento);
            return SeleccionarDatos("requerimiento=@requerimiento", parametros);
        }
        public List<Fila> SinRevisar(int idRequerimiento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@requerimiento", idRequerimiento);
            parametros.Add("@estatus_revision", "PENDIENTE");
            return SeleccionarDatos("requerimiento=@requerimiento AND estatus_revision=@estatus_revision", parametros);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RequerimientoAdjunto : ModeloMySql
    {

        public RequerimientoAdjunto()
        {
            Tabla = "requerimientos_adjuntos";
        }

        static public RequerimientoAdjunto Modelo()
        {
            return new RequerimientoAdjunto();
        }

        public List<Fila> SeleccionarRequerimiento(int idRequerimiento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@requerimiento", idRequerimiento);
            return SeleccionarDatos("requerimiento=@requerimiento", parametros);
        }

    }
}
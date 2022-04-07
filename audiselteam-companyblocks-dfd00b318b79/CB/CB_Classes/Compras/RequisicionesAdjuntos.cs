using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RequisicionesAdjuntos : ModeloMySql
    {
        public RequisicionesAdjuntos()
        {
            Tabla = "requisiciones_adjuntos";
        }

        static public RequisicionesAdjuntos Modelo()
        {
            return new RequisicionesAdjuntos();
        }

        public List<Fila> SeleccionarRequisiciones(int requisicion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("requisicion", requisicion);
            return SeleccionarDatos("requisicion_compra=@requisicion", parametros);
        }
    }

}

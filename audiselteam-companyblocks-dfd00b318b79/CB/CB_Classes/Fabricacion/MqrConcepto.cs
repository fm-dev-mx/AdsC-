using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MqrConcepto : ModeloMySql
    {
        public MqrConcepto()
        {
            Tabla = "mqr_conceptos";
        }

        static public MqrConcepto Modelo()
        {
            return new MqrConcepto();
        }

        public List<Fila> SeleccionarOrdenConceptoMqr(int ordenConcepto, int mqr)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Clear();
            parametros.Add("@concepto", ordenConcepto);
            parametros.Add("@mqr", mqr);
            return SeleccionarDatos("concepto=@concepto AND mqr=@mqr", parametros);
        }
    }
}

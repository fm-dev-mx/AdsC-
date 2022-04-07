using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CB_Base.Classes
{
    class ArchivoRfq : ModeloMySql
    {

        public ArchivoRfq()
        {
            Tabla = "archivos_rfqs";
        }

        static public ArchivoRfq Modelo()
        {
            return new ArchivoRfq();
        }

        public List<Fila> SeleccionarRfq(int rfq)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("rfq", rfq);
            return SeleccionarDatos("rfq=@rfq", parametros);
        }

    }
}

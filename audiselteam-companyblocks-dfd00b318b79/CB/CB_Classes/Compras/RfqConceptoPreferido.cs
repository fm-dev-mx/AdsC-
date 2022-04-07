using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RfqConceptoPreferido : ModeloMySql
    {
        public RfqConceptoPreferido()
        {
            Tabla = "rfq_conceptos_preferidos";
        }

        static public RfqConceptoPreferido Modelo()
        {
            return new RfqConceptoPreferido();
        }

        public List<Fila> BuscarRfqPorNumeroParte(string numeroParte)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE numero_parte=@numeroParte limit 1";
            ConstruirQuery(query);
            AgregarParametro("@numeroParte", numeroParte);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
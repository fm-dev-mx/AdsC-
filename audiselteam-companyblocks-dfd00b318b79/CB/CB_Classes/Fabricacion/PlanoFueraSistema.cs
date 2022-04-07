using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PlanoFueraSistema : ModeloMySql
    {

        public PlanoFueraSistema()
        {
            Tabla = "planos_fuera_sistema";
        }

        static public PlanoFueraSistema Modelo()
        {
            return new PlanoFueraSistema();
        }

        public List<Fila> PlanosFabricadosFueraDeSistema(DateTime desde, DateTime hasta)
        {
            string query = "select * from " + Tabla + " where DATE(fecha_creacion) between DATE(@desde) and DATE(@hasta);";
            ConstruirQuery(query);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

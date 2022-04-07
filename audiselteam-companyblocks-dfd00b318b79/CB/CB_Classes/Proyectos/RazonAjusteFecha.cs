using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RazonAjusteFecha : ModeloMySql
    {
        public RazonAjusteFecha()
        {
            Tabla = "razones_ajustes_fechas";
        }

        static public RazonAjusteFecha Modelo()
        {
            return new RazonAjusteFecha();
        }

        public List<Fila> SeleccionarRazones()
        {
            string sql = "SELECT * FROM " + Tabla + " ORDER BY razon ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

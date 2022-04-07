using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class OrdenConcepto : ModeloMySql
    {
        public OrdenConcepto()
        {
            Tabla = "ordenes_conceptos";
        }

        static public OrdenConcepto Modelo()
        {
            return new OrdenConcepto();
        }

        public List<Fila> SeleccionarDeOrden(int idOrden)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Clear();
            parametros.Add("@orden", idOrden);
            return SeleccionarDatos("orden=@orden", parametros);
        }
    }
}

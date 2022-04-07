using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class EstadisticaKPI
    {
        public string Categoria = string.Empty;

        public Dictionary<string, object> Valores = new Dictionary<string,object>();

        public EstadisticaKPI(Dictionary<string, object> valoresEstadistica, string categoriaEstadistica="General")
        {
            Valores = valoresEstadistica;
            Categoria = categoriaEstadistica;
        }

    }
}

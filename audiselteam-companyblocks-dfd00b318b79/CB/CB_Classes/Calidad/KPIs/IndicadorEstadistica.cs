using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class IndicadorEstadistica : ModeloMySql
    {

        public IndicadorEstadistica()
        {
            Tabla = "indicadores_estadisticas";
        }

        static public IndicadorEstadistica Modelo()
        {
            return new IndicadorEstadistica();
        }

        public List<Fila> SeleccionarIndicador(int idIndicador)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@indicador", idIndicador);
            return SeleccionarDatos("indicador=@indicador", parametros);
        }
    }
}

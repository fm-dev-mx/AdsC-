using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProbabilidadRiesgo : ModeloMySql
    {
        public ProbabilidadRiesgo()
        {
            Tabla = "probabilidades_riesgo";
        }

        static public ProbabilidadRiesgo Modelo()
        {
            return new ProbabilidadRiesgo();
        }

        public List<Fila> Todas()
        {
            return SeleccionarDatos("");
        }
    }
}

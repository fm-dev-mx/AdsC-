using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProbabilidadConsecuencia : ModeloMySql
    {
        public ProbabilidadConsecuencia()
        {
            Tabla = "probabilidades_consecuencias";
        }

        static public ProbabilidadConsecuencia Modelo()
        {
            return new ProbabilidadConsecuencia();
        }
    }
}

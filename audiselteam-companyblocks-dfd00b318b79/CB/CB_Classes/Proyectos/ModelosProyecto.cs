using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ModelosProyecto : ModeloMySql
    {
        public ModelosProyecto()
        {
            Tabla = "modelo_proyecto";
        }

        static public ModelosProyecto Modelo()
        {
            return new ModelosProyecto();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TipoProyecto : ModeloMySql
    {
        public TipoProyecto()
        {
            Tabla = "tipos_proyectos";       
        }

        static public TipoProyecto Modelo()
        {
            return new TipoProyecto();
        }
    }
}

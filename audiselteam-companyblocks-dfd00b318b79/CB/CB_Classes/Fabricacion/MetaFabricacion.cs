using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MetaFabricacion : ModeloMySql
    {
        public MetaFabricacion()
        {
            Tabla = "metas_fabricacion";
        }

        static public MetaFabricacion Modelo()
        {
            return new MetaFabricacion();
        }
    }
}

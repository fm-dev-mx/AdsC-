using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class SolidoMaterial: ModeloMySql
    {
        public SolidoMaterial()
        {
            Tabla = "solidos_material";
        }

        static public SolidoMaterial Modelo()
        {
            return new SolidoMaterial();
        }
    }
}

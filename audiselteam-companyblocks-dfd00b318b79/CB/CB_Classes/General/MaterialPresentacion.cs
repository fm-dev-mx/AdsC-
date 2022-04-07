using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MaterialPresentacion : ModeloMySql
    {
        public MaterialPresentacion() {
            Tabla = "material_presentaciones";
        }

        static public MaterialPresentacion Modelo()
        {
            return new MaterialPresentacion();
        }
    }
}

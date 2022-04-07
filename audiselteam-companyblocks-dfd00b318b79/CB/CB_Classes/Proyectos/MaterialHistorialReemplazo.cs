using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MaterialHistorialReemplazo : ModeloMySql
    {
        public MaterialHistorialReemplazo()
        {
            Tabla = "material_historial_reemplazos";
        }

        public static MaterialHistorialReemplazo Modelo()
        {
            return new MaterialHistorialReemplazo();
        }
    
    }
}

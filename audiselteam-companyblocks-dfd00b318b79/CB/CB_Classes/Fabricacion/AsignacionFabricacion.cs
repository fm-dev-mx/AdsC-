using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class AsignacionFabricacion : ModeloMySql
    {
        public AsignacionFabricacion()
        {
            Tabla = "asignaciones_fabricacion";
        }

        static public AsignacionFabricacion Modelo()
        {
            return new AsignacionFabricacion();
        }
    }
}

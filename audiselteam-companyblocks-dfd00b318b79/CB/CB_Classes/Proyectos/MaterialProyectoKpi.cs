using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MaterialProyectoKpi : ModeloMySql
    {
        public MaterialProyectoKpi()
        {
            Tabla = "material_proyecto_kpi";
        }

        static public MaterialProyectoKpi Modelo()
        {
            return new MaterialProyectoKpi();
        }
    }
}

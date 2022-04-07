using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PoProyecto: ModeloMySql
    {
        public PoProyecto()
        {
            Tabla = "po_proyectos";
        }

        public static PoProyecto Modelo()
        {
            return new PoProyecto();
        }
    }
}

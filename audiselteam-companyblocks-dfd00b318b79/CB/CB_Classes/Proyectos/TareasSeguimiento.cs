using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TareasSeguimiento : ModeloMySql
    {
        public TareasSeguimiento()
        {
            Tabla = "tareas_seguimientos";
        }

        static public TareasSeguimiento Modelo()
        {
            return new TareasSeguimiento();
        }
    }
}

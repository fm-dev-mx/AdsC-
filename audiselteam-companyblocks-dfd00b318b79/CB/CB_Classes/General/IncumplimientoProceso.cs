using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class IncumplimientoProceso : ModeloMySql
    {
       

        public IncumplimientoProceso()
        {
            Tabla = "incumplimiento_procesos";
        }

        static public IncumplimientoProceso Modelo()
        {
            return new IncumplimientoProceso();
        }
    

    }
}

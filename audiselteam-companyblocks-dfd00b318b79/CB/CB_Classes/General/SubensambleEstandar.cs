using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class SubensambleEstandar : ModeloMySql
    {
        public SubensambleEstandar()
        {
            Tabla = "subensamble_estandar";
        }

        static public SubensambleEstandar Modelo()
        {
            return new SubensambleEstandar();
        }
    }
}

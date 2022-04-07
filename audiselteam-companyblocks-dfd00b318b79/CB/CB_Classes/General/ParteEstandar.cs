using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ParteEstandar : ModeloMySql
    {
        public ParteEstandar()
        {
            Tabla = "partes_estandar";
        }

        static public ParteEstandar Modelo()
        {
            return new ParteEstandar();
        }
    }
}

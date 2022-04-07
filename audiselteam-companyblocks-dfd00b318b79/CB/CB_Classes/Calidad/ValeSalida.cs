using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ValeSalida : ModeloMySql
    {
        public ValeSalida()
        {
            Tabla = "vales_salida";
        }

        static public ValeSalida Modelo()
        {
            return new ValeSalida();
        }
    }
}

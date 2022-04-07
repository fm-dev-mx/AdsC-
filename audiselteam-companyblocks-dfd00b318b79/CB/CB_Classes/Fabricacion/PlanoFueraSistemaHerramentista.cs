using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PlanoFueraSistemaHerramentista : ModeloMySql
    {

        public PlanoFueraSistemaHerramentista()
        {
            Tabla = "planos_fuera_sistema_herramentistas";
        }

        static public PlanoFueraSistemaHerramentista Modelo()
        {
            return new PlanoFueraSistemaHerramentista();
        }
    }
}

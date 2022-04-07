using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ValeSalidaPieza : ModeloMySql
    {
        public ValeSalidaPieza()
        {
            Tabla = "vale_salida_pieza";
        }

        static public ValeSalidaPieza Modelo()
        {
            return new ValeSalidaPieza();
        }
    }
}

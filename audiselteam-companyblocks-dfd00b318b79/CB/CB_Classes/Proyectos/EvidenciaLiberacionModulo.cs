using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class EvidenciaLiberacionModulo : ModeloMySql
    {
        public EvidenciaLiberacionModulo()
        {
            Tabla = "evidencias_liberacion_modulos";
        }

        static public EvidenciaLiberacionModulo Modelo()
        {
            return new EvidenciaLiberacionModulo();
        }
    }
}

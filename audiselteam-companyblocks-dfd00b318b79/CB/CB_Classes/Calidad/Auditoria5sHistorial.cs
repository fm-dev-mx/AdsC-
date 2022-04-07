using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Auditoria5sHistorial : ModeloMySql
    {
        public Auditoria5sHistorial()
        {
            Tabla = "auditoria_5s_historial";
        }

        static public Auditoria5sHistorial Modelo()
        {
            return new Auditoria5sHistorial();
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ListaIncumplimiento : ModeloMySql
    {        

        public ListaIncumplimiento()
        {
            Tabla = "lista_incumplimientos";
        }

        static public ListaIncumplimiento Modelo()
        {
            return new ListaIncumplimiento();
        }
    }
}

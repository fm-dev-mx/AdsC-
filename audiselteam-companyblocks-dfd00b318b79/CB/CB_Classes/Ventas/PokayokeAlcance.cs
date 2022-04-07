using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PokayokeAlcance : ModeloMySql
    {
        public PokayokeAlcance()
        {
            Tabla = "pokayokes_alcance";
        }

        static public PokayokeAlcance Modelo()
        {
            return new PokayokeAlcance();
        }
    }
}

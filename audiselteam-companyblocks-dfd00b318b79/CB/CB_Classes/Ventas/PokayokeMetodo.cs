using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PokayokeMetodo : ModeloMySql
    {
        public PokayokeMetodo()
        {
            Tabla = "pokayokes_metodos";
        }

        static public PokayokeMetodo Modelo()
        {
            return new PokayokeMetodo();
        }
    }
}

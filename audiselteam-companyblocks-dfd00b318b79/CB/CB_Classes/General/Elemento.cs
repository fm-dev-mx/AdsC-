using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB
{
    class Elemento : ModeloMySql
    {

        public Elemento()
        {
            Tabla = "elementos";
        }

        static public Elemento Modelo()
        {
            return new Elemento();
        }

        public List<Fila> SeleccionarModulo(int idModulo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", idModulo);
            return SeleccionarDatos("modulo=@modulo", parametros);
        }

    }
}

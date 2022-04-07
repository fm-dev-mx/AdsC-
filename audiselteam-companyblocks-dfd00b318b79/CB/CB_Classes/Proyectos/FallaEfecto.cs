using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class FallaEfecto : ModeloMySql
    {
        public FallaEfecto()
        {
            Tabla = "fallas_efectos";
        }

        static public FallaEfecto Modelo()
        {
            return new FallaEfecto();
        }

        public List<Fila> SeleccionarModoFalla(int idModoFalla)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modo_falla", idModoFalla);
            return SeleccionarDatos("modo_falla=@modo_falla", parametros);
        }
    }
}

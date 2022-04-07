using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class ModoFalla: ModeloMySql
    {
        public ModoFalla()
        {
            Tabla = "modos_falla";
        }

        static public ModoFalla Modelo()
        {
            return new ModoFalla();
        }


        public List<Fila> SeleccionarModulo(int modulo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("modulo", modulo);
            return SeleccionarDatos("modulo=@modulo", parametros);
        }
        public List<Fila> SeleccionarModuloNuevo(int modulo, string nombre)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("modulo", modulo);
            parametros.Add("nombre", nombre);
            return SeleccionarDatos("modulo=@modulo AND nombre=@nombre", parametros);
        }
    }
}

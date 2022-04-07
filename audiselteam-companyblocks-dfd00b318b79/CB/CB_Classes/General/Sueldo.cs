using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Sueldo : ModeloMySql
    {
        public Sueldo()
        {
            Tabla = "sueldos";
        }

        static public Sueldo Modelo()
        {
            return new Sueldo();
        }

        public List<Fila> BuscarSueldo(int usuario)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("usuario", usuario);
            return SeleccionarDatos("usuario=@usuario", parametros);
        }
    }
}

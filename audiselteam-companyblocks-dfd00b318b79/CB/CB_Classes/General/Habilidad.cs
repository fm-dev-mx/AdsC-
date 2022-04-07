using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Habilidad : ModeloMySql
    {
        public Habilidad()
        {
            Tabla = "habilidades";
        }

        static public Habilidad Modelo()
        {
            return new Habilidad();
        }
 
        public List<Fila> SeleccionarTipo(string tipo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tipo", tipo);
            return SeleccionarDatos("tipo=@tipo ORDER BY habilidad", parametros);
        }

        public List<Fila> SeleccionarHabilidad(string habilidad)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@habilidad", habilidad);
            return SeleccionarDatos("habilidad=@habilidad", parametros);
        }
    }
}

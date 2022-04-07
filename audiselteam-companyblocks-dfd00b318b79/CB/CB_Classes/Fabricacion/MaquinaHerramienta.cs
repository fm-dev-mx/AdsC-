using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MaquinaHerramienta : ModeloMySql
    {

        public MaquinaHerramienta()
        {
            Tabla = "maquinas_herramientas";
        }

        static public MaquinaHerramienta Modelo()
        {
            return new MaquinaHerramienta();
        }

        public Fila SeleccionarNombre(string nombre)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", nombre);
            SeleccionarDatos("nombre=@nombre", parametros);
            return Fila();
        }

        public List<Fila> SeleccionarNombreOperador(string nombre)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@operador", nombre);
            return SeleccionarDatos("operador=@operador or responsable=@operador", parametros);
        }
    }
}

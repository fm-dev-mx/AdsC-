using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class EquipoComputoUsuario : ModeloMySql
    {
        public EquipoComputoUsuario()
        {
            Tabla = "equipo_computo_usuarios";
        }

        static public EquipoComputoUsuario Modelo()
        {
            return new EquipoComputoUsuario();
        }

        public List<Fila> SeleccionarUsuario(int idEquipo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@equipo", idEquipo);
            return SeleccionarDatos("equipo=@equipo", parametros);
        }

        public List<Fila> CargarEquiposDeUsuario(int usuario)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", usuario);
            return SeleccionarDatos("usuario=@usuario", parametros);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RazonBajaUsuario : ModeloMySql
    {
        public RazonBajaUsuario()
        {
            Tabla = "razones_baja_usuarios";
        }

        static public RazonBajaUsuario Modelo()
        {
            return new RazonBajaUsuario();
        }

        public List<Fila> SeleccionarRazones()
        {
            string query = "SELECT * FROM " + Tabla;
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();         
        }
    }
}

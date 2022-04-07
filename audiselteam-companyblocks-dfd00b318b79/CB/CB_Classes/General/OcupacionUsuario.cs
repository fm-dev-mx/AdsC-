using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class OcupacionUsuario : ModeloMySql
    {
        public OcupacionUsuario()
        {
            Tabla = "ocupacion_usuarios";
        }

        static public OcupacionUsuario Modelo()
        {
            return new OcupacionUsuario();
        }

        public List<Fila> SeleccionarDatos(int usuario)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE usuario=@usuario AND fecha_desocupado is null";

            ConstruirQuery(sql);
            AgregarParametro("@usuario", usuario);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

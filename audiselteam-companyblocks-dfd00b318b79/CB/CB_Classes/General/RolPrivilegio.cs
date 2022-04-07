using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RolPrivilegio : ModeloMySql
    {

        public RolPrivilegio()
        {
            Tabla = "roles_privilegios";
        }

        static public RolPrivilegio Modelo()
        {
            return new RolPrivilegio();
        }

        public List<Fila> SeleccionarRol(int rol)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rol", rol);
            return SeleccionarDatos("rol=@rol", parametros);
        }

        public List<Fila> SeleccionarRolPrivilegio(int rol, int privilegio)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rol", rol);
            parametros.Add("@privilegio", privilegio);
            return SeleccionarDatos("rol=@rol AND privilegio=@privilegio", parametros);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RolHabilidad: ModeloMySql
    {
        public RolHabilidad()
        {
            Tabla = "roles_habilidades";
        }

        static public RolHabilidad Modelo()
        {
            return new RolHabilidad();
        }
        public List<Fila> SeleccionarHabilidad(int rol)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rol", rol);
            return SeleccionarDatos("rol=@rol", parametros);
        }

        public List<Fila> SeleccionarRolHabilidad(int rol, int habilidad)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rol", rol);
            parametros.Add("@habilidad", habilidad);
            return SeleccionarDatos("rol=@rol AND habilidad=@habilidad", parametros);
        }

    }
}

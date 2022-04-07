using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ActividadMantenimiento : ModeloMySql
    {
        public ActividadMantenimiento()
        {
            Tabla = "actividades_mantenimiento";
        }

        static public ActividadMantenimiento Modelo()
        {
            return new ActividadMantenimiento();
        }

        public List<Fila> CargarActividades(int mantenimiento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@mantenimiento", mantenimiento);
            return SeleccionarDatos("mantenimiento=@mantenimiento", parametros);
        }
    }
}

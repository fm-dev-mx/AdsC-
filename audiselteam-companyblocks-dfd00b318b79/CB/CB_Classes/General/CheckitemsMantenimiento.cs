using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CheckitemsMantenimiento: ModeloMySql
    {
        public CheckitemsMantenimiento()
        {
            Tabla = "checkitems_mantenimiento";
        }

        static public CheckitemsMantenimiento Modelo()
        {
            return new CheckitemsMantenimiento();
        }

        public List<Fila> CargarMantenimiento(int mantenimiento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@mantenimiento", mantenimiento);
            return SeleccionarDatos("mantenimiento=@mantenimiento", parametros);
        }
    }
}

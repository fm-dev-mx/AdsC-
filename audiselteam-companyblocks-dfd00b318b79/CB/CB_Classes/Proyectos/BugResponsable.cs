using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class BugResponsable : ModeloMySql
    {
        public BugResponsable()
        {
            Tabla = "bugs_responsables";
        }

        public static BugResponsable Modelo()
        {
            return new BugResponsable();
        }

        public List<Fila> SeleccionarBug(int IdBug)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@bug", IdBug);
            return SeleccionarDatos("bug=@bug", parametros);
        }
    }
}

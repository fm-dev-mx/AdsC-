using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;
namespace CB_Base.Classes
{
    class BugNota : ModeloMySql
    {
        public BugNota()
        {
            Tabla = "bugs_notas";
        }

        static public BugNota Modelo()
        {
            return new BugNota();
        }

        public List<Fila> SeleccionarBug(int idBug)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@bug", idBug);
            return SeleccionarDatos("bug=@bug", parametros);
        }
    }
}

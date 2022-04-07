using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RevisionModulo : ModeloMySql
    {

        public RevisionModulo()
        {
            Tabla = "revisiones_modulos";
        }

        static public RevisionModulo Modelo()
        {
            return new RevisionModulo();
        }

        public List<Fila> SeleccionarProyectoSubensamble(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble", parametros);
            return Filas();
        }
    }
}

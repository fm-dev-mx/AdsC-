using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PlantillaEncuestaPregunta  : ModeloMySql
    {
        public PlantillaEncuestaPregunta()
        {
            Tabla = "plantillas_encuestas_preguntas";
        }

        static public PlantillaEncuestaPregunta Modelo()
        {
            return new PlantillaEncuestaPregunta();
        }

        public List<Fila> SeleccionarPreguntas(int plantilla)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plantilla", plantilla);
            return SeleccionarDatos("plantilla=@plantilla", parametros);
        }
    }
}

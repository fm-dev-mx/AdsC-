using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class EncuestaPregunta : ModeloMySql
    {
        public EncuestaPregunta()
        {
            Tabla = "encuestas_preguntas";
        }

        static public EncuestaPregunta Modelo()
        {
            return new EncuestaPregunta();
        }

        public List<Fila> SeleccionarRespuestas(int idPlantillaPregunta, int idplantilla, int idEncuesta)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plantillaPreguntaId", idPlantillaPregunta);
            parametros.Add("@plantilla", idplantilla);
            parametros.Add("@encuesta", idEncuesta);
            return SeleccionarDatos("plantilla_pregunta_id=@plantillaPreguntaId and plantilla=@plantilla and encuesta=@encuesta", parametros);
        }
    }
}

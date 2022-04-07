using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TopicoHabilidad : ModeloMySql
    {
        public TopicoHabilidad()
        {
            Tabla = "topicos_habilidades";
        }

        static public TopicoHabilidad Modelo()
        {
            return new TopicoHabilidad();
        }

        public List<Fila> CargarTopicosHabilidad(int habilidad)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@habilidad", habilidad);
            return SeleccionarDatos("habilidad=@habilidad", parametros);
        }

        public List<Fila> SeleccionarTopico(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@id", id);
            return SeleccionarDatos("id=@id", parametros);
        }
    }
}

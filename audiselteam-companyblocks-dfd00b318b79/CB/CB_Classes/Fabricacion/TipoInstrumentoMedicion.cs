using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TipoInstrumentoMedicion : ModeloMySql
    {

        public TipoInstrumentoMedicion()
        {
            Tabla = "tipos_instrumentos_medicion";
        }

        public static TipoInstrumentoMedicion Modelo()
        {
            return new TipoInstrumentoMedicion();
        }

        public List<Fila> Todos()
        {
            return SeleccionarDatos("");
        }

    }
}

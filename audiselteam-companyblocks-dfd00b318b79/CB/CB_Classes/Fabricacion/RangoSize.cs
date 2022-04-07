using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RangoSize : ModeloMySql
    {

        public RangoSize()
        {
            Tabla = "rangos_size";
        }

        static public RangoSize Modelo()
        {
            return new RangoSize();
        }

        public string DeterminarRango(string presentacion, double size)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@presentacion", presentacion);
            parametros.Add("@size", size);

            List<Fila> f = SeleccionarDatos("presentacion=@presentacion AND (@size>min AND @size<=max)", parametros);

            if(f.Count > 0)
                return presentacion + "-" + f[0].Celda("rango").ToString();
            return "N/A";
        }

    }
}

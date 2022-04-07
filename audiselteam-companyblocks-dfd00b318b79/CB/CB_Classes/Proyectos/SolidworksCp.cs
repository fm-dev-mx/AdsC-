using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class SolidworksCp : ModeloMySql
    {
        public SolidworksCp()
        {
            Tabla = "solidworks_cp";
        }

        static public SolidworksCp Modelo()
        {
            return new SolidworksCp();
        }

        public List<Fila> SeleccionarDrawing(int drawing)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@drawing", drawing);
            return SeleccionarDatos("drawing=@drawing", parametros);
        }
    }
}

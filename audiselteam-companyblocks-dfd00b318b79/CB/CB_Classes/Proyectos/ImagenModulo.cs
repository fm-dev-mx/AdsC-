using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ImagenModulo : ModeloMySql
    {
        public ImagenModulo()
        {
            Tabla = "imagenes_modulo";
        }

        public static ImagenModulo Modelo()
        {
            return new ImagenModulo();
        }

        public List<Fila> SeleccionarVista(int idModulo, string vista)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", idModulo);
            parametros.Add("@vista", vista);
            return SeleccionarDatos("modulo=@modulo AND vista=@vista", parametros);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class SubcategoriaMaterial : ModeloMySql
    {

        public SubcategoriaMaterial()
        {
            Tabla = "subcategorias_material";
        }

        static public SubcategoriaMaterial Modelo()
        {
            return new SubcategoriaMaterial();
        }

        public List<Fila> Todas()
        {
            return SeleccionarDatos("", null);
        }

        public List<Fila> SeleccionarCategoria(string categoria)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@categoria", categoria);
            return SeleccionarDatos("categoria=@categoria", parametros);
        }
    }
}

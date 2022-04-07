using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MaterialMaquinado : ModeloMySql
    {
        public MaterialMaquinado()
        {
            Tabla = "material_maquinado";
        }

        static public MaterialMaquinado Modelo()
        {
            return new MaterialMaquinado();
        }

        public List<Fila> Categorias()
        {
            string sql = "SELECT * FROM " + Tabla + " GROUP BY categoria order by categoria asc";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> MaterialDeCategoria(string categoria)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@categoria", categoria);
            return SeleccionarDatos("categoria=@categoria", parametros);
        }

        public List<Fila> SeleccionarNombre(string nombre)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", nombre);
            return SeleccionarDatos("nombre=@nombre", parametros);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MaterialFabricante : ModeloMySql
    {
        public MaterialFabricante()
        {
            Tabla = "material_fabricantes";
        }

        static public MaterialFabricante Modelo()
        {
            return new MaterialFabricante();
        }

        public List<Fila> SeleccionarFabricante(string fabricante)
        {
            string sql = "SELECT * FROM material_fabricantes WHERE fabricante=@fabricante";
            ConstruirQuery(sql);
            AgregarParametro("@fabricante", fabricante);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

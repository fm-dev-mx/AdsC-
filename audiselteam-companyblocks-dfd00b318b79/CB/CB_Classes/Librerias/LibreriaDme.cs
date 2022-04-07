using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class LibreriaDme : ModeloMySql
    {

        public LibreriaDme()
        {
            Tabla = "librerias_dme";
        }

        static public LibreriaDme Modelo()
        {
            return new LibreriaDme();
        }

        public List<Fila> Todos()
        {
            string sql = string.Empty;

            sql += "SELECT librerias_dme.*, ";
            sql += "categorias_sub_material.nombre AS nombre_subcategoria, ";
            sql += "categorias_material.categoria AS nombre_categoria, ";
            sql += "fabricantes.nombre AS nombre_fabricante ";
            sql += "FROM librerias_dme ";
            sql += "INNER JOIN categorias_sub_material ON categorias_sub_material.id=librerias_dme.subcategoria ";
            sql += "INNER JOIN categorias_material ON categorias_material.id=categorias_sub_material.categoria ";
            sql += "INNER JOIN fabricantes ON fabricantes.id=librerias_dme.fabricante";

            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarLibreria(int idSubcategoria, int idFabricante)
        {
            string sql = string.Empty;

            sql += "select * from librerias_dme where fabricante =@idFabricante and subcategoria =@idSubcategoria;";

            ConstruirQuery(sql);
            AgregarParametro("@idSubcategoria", idSubcategoria);
            AgregarParametro("@idFabricante", idFabricante);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarCategoriaDeSubcategoriasDeLibrerias(string tipoCompra)
        {
            string sql = string.Empty;
            sql += "select ";
            sql += "    librerias_dme.subcategoria,";
            sql += "    categorias_material.id as categoria_id,";
            sql += "    categorias_material.categoria as categoria_nombre,";
            sql += "    categorias_sub_material.id as subcat_id,";
            sql += "    categorias_sub_material.nombre as subcat_nombre ";
            sql += "from librerias_dme ";
            sql += "inner join categorias_sub_material on categorias_sub_material.id = librerias_dme.subcategoria ";
            sql += "inner join categorias_material on categorias_material.id = categorias_sub_material.categoria ";
            sql += "WHERE categorias_material.tipo_compra = (select id from compras_tipos where compras_tipos.nombre =@tipoCompra) ";
            sql += "group by categorias_material.id";

            ConstruirQuery(sql);
            AgregarParametro("@tipoCompra", tipoCompra);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarSubcategoriasDeLibrerias(string idCategoria)
        {
            string sql = string.Empty;
            sql += "Select ";
	        sql += "    categorias_sub_material.id,";
            sql += "    categorias_sub_material.nombre,";
            sql += "    librerias_dme.subcategoria,";
            sql += "    categorias_sub_material.categoria ";
            sql += "from categorias_sub_material ";
            sql += "INNER JOIN librerias_dme ON librerias_dme.subcategoria = categorias_sub_material.id ";
            sql += "where categorias_sub_material.categoria = @idCategoria;";

            ConstruirQuery(sql);
            AgregarParametro("@idCategoria", idCategoria);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarFabricantesDeLibrerias(string subcategoria)
        {
            string sql = string.Empty;
            sql += "select fabricantes.id, fabricantes.nombre from librerias_dme ";
            sql += "INNER JOIN fabricantes ON fabricantes.id = librerias_dme.fabricante ";
            sql += "where subcategoria = @subcategoria ";
            sql += "group by fabricantes.id;";

            ConstruirQuery(sql);
            AgregarParametro("@subcategoria", subcategoria);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

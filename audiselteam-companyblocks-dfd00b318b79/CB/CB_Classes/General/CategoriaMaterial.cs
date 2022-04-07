using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CategoriaMaterial : ModeloMySql
    {

        public CategoriaMaterial()
        {
            Tabla = "categorias_material";
        }

        static public CategoriaMaterial Modelo()
        {
            return new CategoriaMaterial();
        }

        public List<Fila> Todas()
        {
            return SeleccionarDatos("", null);
        }

        public List<Fila> SeleccionarCategoriasMaterial(int tipoCompra, string estatusValidacion = "", int idCategoria = -1)
        {
            string query = "select categorias_material.*, count(catalogo_material.id) as total from categorias_sub_material ";

            if (estatusValidacion == string.Empty)
            {
                query += "left join catalogo_material ";
            }
            else
            {
                query += "left join (select * from catalogo_material where catalogo_material.estatus_validacion=@estatusValidacion) as catalogo_material ";
            }

            query += "on catalogo_material.subcategoria_ref = categorias_sub_material.id " +
                     "right join categorias_material " +
                     "on categorias_material.id = categorias_sub_material.categoria " +
                     "where categorias_material.tipo_compra = @tipoCompra ";

            if(idCategoria != -1)
            {
                query += "and categorias_material.id = @idCategoria ";   
            }

            query += "group by categorias_material.id order by categorias_material.categoria asc";

            ConstruirQuery(query);
            AgregarParametro("@tipoCompra", tipoCompra);
            AgregarParametro("@idCategoria", idCategoria);
            AgregarParametro("@estatusValidacion", estatusValidacion);

            EjecutarQuery();

            return LeerFilas();
        }

        public List<Fila> EliminarCategoria(int idCategoria)
        {
            string query = "call CatalogoMaterial_EliminarSubCategoriaDeCategoria(@idSubcategoria)";

            ConstruirQuery(query);
            AgregarParametro("@idSubcategoria", idCategoria);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> MoverCategoria(int idCategoriaOrigen, int idTipoDestino, string nombreCategoria)
        {
            string query = "call CatalogoMaterial_MoverCategorias(@idCategoriaOrigen, @idTipoDestino, @nombreCategoria)";

            ConstruirQuery(query);
            AgregarParametro("@idCategoriaOrigen", idCategoriaOrigen);
            AgregarParametro("@idTipoDestino", idTipoDestino);
            AgregarParametro("@nombreCategoria", nombreCategoria);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionCategoriasDeTipoCompra(int idTipo)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE tipo_compra=@idTipo";
            ConstruirQuery(query);
            AgregarParametro("@idTipo", idTipo);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarCategoriaDeLibreria(int idSubcategoria, int idTipoCompra)
        {
            string query = string.Empty;
            query += "select categorias_material.id from categorias_material ";
            query += "INNER JOIN categorias_sub_material on categorias_sub_material.categoria = categorias_material.id ";
            query += "INNER JOIN librerias_dme on librerias_dme.subcategoria = categorias_sub_material.id ";
            query += "where categorias_material.tipo_compra = @idTipoCompra and librerias_dme.subcategoria = @idSubcategoria;";

            ConstruirQuery(query);
            AgregarParametro("@idTipocOmpra", idTipoCompra);
            AgregarParametro("@idSubcategoria", idSubcategoria);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

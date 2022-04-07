using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CategoriaSubMaterial : ModeloMySql
    {

        public CategoriaSubMaterial()
        {
            Tabla = "categorias_sub_material";
        }

        static public CategoriaSubMaterial Modelo()
        {
            return new CategoriaSubMaterial();
        }

        public List<Fila> SeleccionarSubCategoriasDeCategoria(int idCategoria, string estatusValidacion = "", int idSubcategoria = -1)
        {
            string query = "select categorias_sub_material.*, count(catalogo_material.id) as total from categorias_sub_material ";

            if (estatusValidacion == string.Empty)
            {
                query += "left join catalogo_material ";
            }
            else
            {
                query += "left join (select * from catalogo_material where catalogo_material.estatus_validacion=@estatusValidacion) as catalogo_material ";
            }

            query += "on catalogo_material.subcategoria_ref = categorias_sub_material.id " +
                     "where categorias_sub_material.categoria = @idCategoria ";

            if (idSubcategoria != -1)
            {
                query += "and categorias_sub_material.id = @idSubCategoria ";
            }

            query += "group by categorias_sub_material.id order by categorias_sub_material.nombre asc";

            ConstruirQuery(query);
            AgregarParametro("@idCategoria", idCategoria);
            AgregarParametro("@idSubCategoria", idSubcategoria);
            AgregarParametro("@estatusValidacion", estatusValidacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EliminarSubCategoria(int idSubcategoria)
        {
            string query = "call CatalogoMaterial_EliminarMaterialDeSubcategoria(@idSubcategoria)";

            ConstruirQuery(query);
            AgregarParametro("@idSubcategoria", idSubcategoria);
            EjecutarQuery();
            return LeerFilas();
        }

        private int RegistroDeSubcategoriaEnCategoria(string especificacionMaterial, string categoria, string tipoCompra)
        {
            string queryCategoria = "SELECT id FROM categorias_material WHERE categoria = '" + categoria + "' and tipo_compra in (select id from compras_tipos where nombre = '" + tipoCompra + "');";
            List<Fila> resultados = new List<Fila>();
            Fila resultado = new Fila();

            ConstruirQuery(queryCategoria);
            EjecutarQuery();
            resultados = LeerFilas();

            if (resultados.Count <= 0)
            {
                string queryTipoCompra = "SELECT id FROM compras_tipos WHERE nombre = @nombreTipoCOmpra";
                ConstruirQuery(queryTipoCompra);
                AgregarParametro("@nombreTipoCOmpra", tipoCompra);
                EjecutarQuery();
                resultados = LeerFilas();

                int idTipo = resultados[0].Celda<int>("id");

                Fila nuevaCategoria = new Fila();
                nuevaCategoria.AgregarCelda("categoria", categoria);
                nuevaCategoria.AgregarCelda("tipo_compra", idTipo);

                resultado = CategoriaMaterial.Modelo().Insertar(nuevaCategoria);

            }
            else
            {
                resultado = resultados[0];
            }

            int idCategoria = resultado.Celda<int>("id");

            string query = "select id from categorias_sub_material where nombre = @tipoMaterial and categoria in (select id from categorias_material where id = @idCategoriaMaterial)";

            ConstruirQuery(query);
            AgregarParametro("@tipoMaterial", especificacionMaterial);
            AgregarParametro("@idCategoriaMaterial", idCategoria);
            EjecutarQuery();

            resultados = LeerFilas();

            if (resultados.Count <= 0)
            {
                Fila nuevaSubCategoria = new Fila();
                nuevaSubCategoria.AgregarCelda("nombre", especificacionMaterial);
                nuevaSubCategoria.AgregarCelda("categoria", idCategoria);

                resultado = CategoriaSubMaterial.Modelo().Insertar(nuevaSubCategoria);
            }
            else
            {
                resultado = resultados[0];
            }
            Convert.ToInt32(resultado.Celda("id"));
            return Convert.ToInt32(resultado.Celda("id"));
        }

        public int SeleccionarIdSubCategoriaDeProcesoPlano(string especificacionMaterial)
        {
            return RegistroDeSubcategoriaEnCategoria(especificacionMaterial, "PROCESOS DE FABRICACION", "SERVICIOS");
        }
    
        public int SeleccionarIdSubCategoriaDeMaterialMaquinado(string especificacionMaterial)
        {
            return RegistroDeSubcategoriaEnCategoria(especificacionMaterial, "MATERIAL PARA FABRICACION", "MATERIA PRIMA COMUN");
        }

        public int IdTipoCompra(int subcategoria)
        {
            string query = "select id from compras_tipos where id IN (select tipo_compra from categorias_material where id IN (select categoria from categorias_sub_material where id = @subcategoria))";
            ConstruirQuery(query);
            AgregarParametro("@subcategoria", subcategoria);
            EjecutarQuery();
            return LeerFilas()[0].Celda<int>("id");
        }

        public List<Fila> MoverSubcategoria(int idSubcategoriaOrigen, int idCategoriaDestino, string nombreSubcategoriaOrigen)
        {
            string query = "call CatalogoMaterial_MoverSubCategoria(@idSubcategoriaOrigen, @nombreSubcategoriaOrigen, @idCategoriaDestino)";

            ConstruirQuery(query);
            AgregarParametro("@idSubcategoriaOrigen", idSubcategoriaOrigen);
            AgregarParametro("@idCategoriaDestino", idCategoriaDestino);
            AgregarParametro("@nombreSubcategoriaOrigen", nombreSubcategoriaOrigen);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarTipoDeSubcategoria(int subcategoria)
        {
            string query = "select * from compras_tipos where id in (select tipo_compra from categorias_material where id in (select categoria from categorias_sub_material where id = @subcategoria))";
            ConstruirQuery(query);
            AgregarParametro("@subcategoria", subcategoria);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarSubcategoriaPorCategoria(int idCategoria)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE categoria =@idCategoria ORDER BY nombre asc";
            ConstruirQuery(query);
            AgregarParametro("@idCategoria", idCategoria);
            EjecutarQuery();
            return LeerFilas();
        }

    }
}

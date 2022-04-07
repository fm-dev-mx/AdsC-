using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class CatalogoMaterial : ModeloMySql
    {
        
        public CatalogoMaterial()
        {
            Tabla = "catalogo_material";
        }

        static public CatalogoMaterial Modelo()
        {
            return new CatalogoMaterial();
        }

        public List<Fila> Seleccionar(string categoria="TODOS", string subcategoria="TODOS", string fabricante="TODOS", string busqueda="")
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@categoria", categoria);
            parametros.Add("@subcategoria", subcategoria);
            parametros.Add("@fabricante", fabricante);
            parametros.Add("@busqueda", "%" + busqueda + "%");

            string filtroCategoria = "";
            if (categoria != "TODOS")
                filtroCategoria = " AND categoria=@categoria";

            string filtroSubcategoria = "";
            if (subcategoria != "TODOS")
                filtroSubcategoria = " AND subcategoria=@subcategoria";

            string filtroFabricante = "";
            if (fabricante != "TODOS")
                filtroFabricante = " AND fabricante=@fabricante";

            string filtroBusqueda = "";
            if(busqueda != "")
                filtroBusqueda = " AND (numero_parte LIKE @busqueda OR descripcion LIKE @busqueda)";

            return SeleccionarDatos("0<1" + filtroCategoria + filtroSubcategoria + filtroFabricante + filtroBusqueda + " ORDER BY fabricante ASC", parametros);
        }

        public List<Fila> SeleccionarNumeroDeParte(string numero_parte)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@numero_parte", numero_parte);
            return SeleccionarDatos("numero_parte=@numero_parte", parametros);
        }

        public List<Fila> Buscar(string filtro)
        {
            //if (filtro == "")
            //    return new List<Fila>();

            filtro = "%" + filtro + "%";
            string sql = "SELECT * FROM " + Tabla + " WHERE id LIKE @filtro OR categoria LIKE @filtro OR subcategoria LIKE @filtro OR numero_parte LIKE @filtro OR fabricante LIKE @filtro OR descripcion LIKE @filtro ORDER BY categoria ASC";

            ConstruirQuery(sql);
            AgregarParametro("@filtro", filtro);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Fabricantes()
        {
            string sql = "SELECT DISTINCT fabricante FROM " + Tabla + " ORDER BY fabricante ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Categorias(string[] filtrarTipoCompra)
        {
            string sql = "select distinct categoria from categorias_material";
            if (filtrarTipoCompra.Length > 0)
            {
                string tiposCompras = string.Empty;
                foreach (string  tipo in filtrarTipoCompra)
                {
                    tiposCompras += "'" + tipo + "',";
                }

                tiposCompras = tiposCompras.Remove(tiposCompras.Length - 1);
                sql += " where  tipo_compra IN (SELECT id from compras_tipos where nombre IN (" + tiposCompras + ")) ";
            }
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Modulos(decimal proyecto)
        {
            string sql = "SELECT DISTINCT material_proyecto.subensamble, modulos.nombre FROM material_proyecto INNER JOIN modulos " +
                "ON modulos.subensamble = material_proyecto.subensamble WHERE modulos.proyecto = " + proyecto + " ORDER BY material_proyecto.subensamble";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ModulosCostos(decimal proyecto)
        {
            string sql = "SELECT DISTINCT material_proyecto.subensamble, modulos.nombre FROM material_proyecto INNER JOIN modulos " +
                "ON modulos.subensamble = material_proyecto.subensamble WHERE material_proyecto.proyecto = " + proyecto + " and " +
                "modulos.proyecto = material_proyecto.proyecto AND material_proyecto.estatus_compra != 'CANCELADO' AND material_proyecto.rfq_concepto != 0 " +
                "ORDER BY material_proyecto.subensamble";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialDeTipoDeCategoriaDeSubcategoria(int idTipo, int idCategoria, int idSubcategoria)
        {
            string sql = "select catalogo_material.* from catalogo_material " +
                            "inner join categorias_sub_material on categorias_sub_material.id = catalogo_material.subcategoria_ref " +
                            "inner join categorias_material on categorias_material.id = categorias_sub_material.categoria " +
                            "inner join compras_tipos on compras_tipos.id = categorias_material.tipo_compra " +
                            "where compras_tipos.id = @idTipo and categorias_material.id = @idCategoria and categorias_sub_material.id = @idSubcategoria";

            ConstruirQuery(sql);
            AgregarParametro("@idTipo", idTipo);
            AgregarParametro("@idCategoria", idCategoria);
            AgregarParametro("@idSubcategoria", idSubcategoria);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialDeTipoDeCategoriaDeSubcategoriaDeFabricante(int idTipo, int idCategoria, int idSubcategoria, string fabricante, string estatusValidacion = "")
        {
            string sql = "select catalogo_material.* from catalogo_material " +
                            "inner join categorias_sub_material on categorias_sub_material.id = catalogo_material.subcategoria_ref " +
                            "inner join categorias_material on categorias_material.id = categorias_sub_material.categoria " +
                            "inner join compras_tipos on compras_tipos.id = categorias_material.tipo_compra " +
                            "where compras_tipos.id = @idTipo and categorias_material.id = @idCategoria and categorias_sub_material.id = @idSubcategoria " +
                            "and catalogo_material.fabricante = @fabricante";

            if (estatusValidacion.Trim() != string.Empty)
            {
                sql += " and catalogo_material.estatus_validacion = @estatusValidacion";
            }

            sql += " ORDER BY catalogo_material.numero_parte ASC";

            ConstruirQuery(sql);
            AgregarParametro("@idTipo", idTipo);
            AgregarParametro("@idCategoria", idCategoria);
            AgregarParametro("@estatusValidacion", estatusValidacion);
            AgregarParametro("@idSubcategoria", idSubcategoria);
            AgregarParametro("@fabricante", fabricante);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarFabricantesDeMaterialDeTipoDeCategoriaDeSubcategoria(int idTipo, int idCategoria, int idSubcategoria, string estatusValidacion = "")
        {
            string sql =    "select distinct catalogo_material.fabricante, count(catalogo_material.id) as total from catalogo_material " +
                            "inner join categorias_sub_material on categorias_sub_material.id = catalogo_material.subcategoria_ref " +
                            "inner join categorias_material on categorias_material.id = categorias_sub_material.categoria " +
                            "inner join compras_tipos on compras_tipos.id = categorias_material.tipo_compra " +
                            "where compras_tipos.id = @idTipo and categorias_material.id = @idCategoria and categorias_sub_material.id = @idSubcategoria ";

            if(estatusValidacion.Trim() != string.Empty)
            {
                sql += " and catalogo_material.estatus_validacion = @estatusValidacion";
            }

            sql +=  " group by fabricante " +
                    " order by catalogo_material.fabricante asc";

            ConstruirQuery(sql);
            AgregarParametro("@idTipo", idTipo);
            AgregarParametro("@idCategoria", idCategoria);
            AgregarParametro("@idSubcategoria", idSubcategoria);
            AgregarParametro("@estatusValidacion", estatusValidacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public bool CambiarEstadoValidacion(int id, string estadoValidacion, string comentario = null)
        {
            string sql = "select * from " + Tabla + " where id=@id";
            ConstruirQuery(sql);
            AgregarParametro("@id", id);
            EjecutarQuery();

            LeerFilas();

            if (TieneFilas())
            {
                Fila().ModificarCelda("estatus_validacion", estadoValidacion);
                if (comentario != null)
                    Fila().ModificarCelda("comentario_validacion", comentario);
            }
            GuardarDatos();
            return true;
        }

        public int ContarMaterialDeTipo(int tipo)
        {
            string query = "select count(*) as total from catalogo_material where subcategoria_ref in (select id from categorias_sub_material where categoria in (select id from categorias_material where tipo_compra = @tipo))";
            ConstruirQuery(query);
            AgregarParametro("@tipo", tipo);
            EjecutarQuery();
            return LeerFilas()[0].Celda<int>("total");
        }

        public int ContarMaterialDeCategoria(int categoria)
        {
            string query = "select count(*) as total from catalogo_material where subcategoria_ref in (select id from categorias_sub_material where categoria = @categoria)";
            ConstruirQuery(query);
            AgregarParametro("@categoria", categoria);
            EjecutarQuery();
            return LeerFilas()[0].Celda<int>("total");
        }

        public int ContarMaterialDeSubcategoria(int subcategoria)
        {
            string query = "select count(*) as total from catalogo_material where subcategoria_ref = @subcategoria";
            ConstruirQuery(query);
            AgregarParametro("@subcategoria", subcategoria);
            EjecutarQuery();
            return LeerFilas()[0].Celda<int>("total");
        }
    }
}

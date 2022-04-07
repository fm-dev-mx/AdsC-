using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ComprasTipos : ModeloMySql
    {
        public ComprasTipos()
        {
            Tabla = "compras_tipos";
        }

        static public ComprasTipos Modelo()
        {
            return new ComprasTipos();
        }

        public List<Fila> SeleccionarTiposMaterial(List<string> filtrarTipo = null, string estatusValidacion = "", int idTipo = -1)
        {
            if(filtrarTipo == null)
            {
                filtrarTipo = new List<string>()
                {
                    "MATERIA PRIMA COMUN",
                    "MATERIA PRIMA ESPECIAL",
                    "M.R.O.",
                    "SERVICIOS",
                    "SIN DETERMINAR"
                };
            }

            string filtro = string.Empty;
            
            foreach (string strFiltro in filtrarTipo)
                filtro += "'" + strFiltro + "',";

            filtro = filtro.Remove(filtro.Length - 1);

            string query = // "SELECT * FROM " + Tabla + " WHERE nombre IN (" + filtro + ")";
                "select compras_tipos.*, count(catalogo_material.id) as total from categorias_sub_material ";

            if (estatusValidacion == string.Empty)
            {
                query += "left join catalogo_material  ";
            }
            else
            {
                query += "left join (select * from catalogo_material where catalogo_material.estatus_validacion=@estatusValidacion) as catalogo_material ";
            }

            query += "on catalogo_material.subcategoria_ref = categorias_sub_material.id " +
                     "right join categorias_material " +
                     "on categorias_material.id = categorias_sub_material.categoria " +
                     "right join compras_tipos " +
                     "on compras_tipos.id = categorias_material.tipo_compra " +
                     "WHERE compras_tipos.nombre IN (" + filtro + ") ";

            if(idTipo != -1)
            {
                query += " AND compras_tipos.id = @idTipo ";
            }

            query += "group by compras_tipos.id order by categorias_material.id asc";

            ConstruirQuery(query);
            AgregarParametro("@idTipo", idTipo);
            AgregarParametro("@estatusValidacion", estatusValidacion);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarTipoDeCompra(string nombre)
        {
            string query = "SELECT * FROM " + Tabla  + " WHERE nombre=@nombre";
            ConstruirQuery(query);
            AgregarParametro("@nombre", nombre);
            EjecutarQuery();
            return LeerFilas();
        }

        public object BuscarTipoCompraPorReq(int idReq)
        {
            string query = "select * from compras_tipos where id IN " +
                           "( " +
                           "    select tipo_compra from categorias_material where id IN " +
                           "    ( " +
                           "        select categoria from categorias_sub_material where id IN  " +
                           "        ( " +
                           "        select subcategoria from material_proyecto where id = @idReq " +
                           "        ) " +
                           "    ) " +
                           ");";

            ConstruirQuery(query);
            AgregarParametro("@idReq", idReq);
            EjecutarQuery();
            List<Fila> lista = LeerFilas();
            if (lista.Count > 0)
                return lista[0].Celda("nombre");
            else
                return null;
        }

        public List<Fila> SeleccionarTodo()
        {
            string query = "SELECT * FROM " + Tabla + " WHERE nombre !='SIN DETERMINAR'";
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

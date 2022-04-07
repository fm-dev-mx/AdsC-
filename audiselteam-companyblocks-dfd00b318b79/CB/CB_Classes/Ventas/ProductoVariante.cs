using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProductoVariante : ModeloMySql
    {
        public ProductoVariante()
        {
            Tabla = "producto_variantes";       
        }

        static public ProductoVariante Modelo()
        {
            return new ProductoVariante();
        }

        public List<Fila> SeleccionarProductosVarianteYModelos(int idComponente, int idGeometria = 0)
        {
            string query = "SELECT producto_variantes.*, producto_modelos.nombre as nombre_modelo from producto_variantes " +
                           "left join producto_modelos on producto_modelos.id = producto_variantes.modelo_variante " +
                           "where componente = @idComponente and producto_variantes.grupo_geometria = @geometria;";

            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            AgregarParametro("@geometria", idGeometria);
            EjecutarQuery();

            return LeerFilas();
        }

        public List<Fila> SeleccionarGeometrias(int idComponente)
        {
            string query = "select distinct grupo_geometria from producto_variantes where componente = @idComponente and grupo_geometria != 0 order by grupo_geometria asc;";
            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            EjecutarQuery();

            return LeerFilas();
        }

        public List<Fila> SeleccionarUltimaGeometria(int idComponente)
        {
            string query = "select max(grupo_geometria) as grupo_geometria from producto_variantes where componente = @idComponente";

            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            EjecutarQuery();

            return LeerFilas();
        }

        public void BorrarVarianteDeLista(List<string> idVariantes)
        {
            foreach (string id in idVariantes)
            {
                string query = "DELETE FROM " + Tabla + " where id=@idVariantes";

                ConstruirQuery(query);
                AgregarParametro("@idVariantes", Convert.ToInt32(id));
                EjecutarQuery();
            }
        }
    }
}

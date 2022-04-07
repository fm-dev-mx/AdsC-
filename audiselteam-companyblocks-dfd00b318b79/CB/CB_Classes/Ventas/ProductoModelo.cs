using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProductoModelo : ModeloMySql
    {
        public ProductoModelo()
        {
            Tabla = "producto_modelos";       
        }

        static public ProductoModelo Modelo()
        {
            return new ProductoModelo();
        }

        public void BorrarModeloPorProducto(int idProducto)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM producto_modelos where producto =@idProducto; " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            EjecutarQuery();
        }

        public void BorrarModelo(int idModelo)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM producto_variantes WHERE modelo_variante=@idModelo; " +
                           "DELETE FROM prod_subensamble_variante where id_modelo = @idModelo; " +
                           "DELETE FROM producto_modelos where id =@idModelo; " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idModelo", idModelo);
            EjecutarQuery();
        }

        public List<Fila> SeleccionarModelosDeProducto(int idProducto, int idCotizacion)
        {
            string query = "select * from producto_variantes where modelo_variante IN (select id from producto_modelos where producto = @idProducto and id_cotizacion=@idCotizacion);";

            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarModelos(int idProducto, int idCotizacion)
        {
            string query = "select * from " + Tabla + " where producto = @idProducto and id_cotizacion=@idCotizacion;";

            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

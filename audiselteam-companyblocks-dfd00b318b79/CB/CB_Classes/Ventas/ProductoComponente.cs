using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProductoComponente : ModeloMySql
    {
        public ProductoComponente()
        {
            Tabla = "producto_componentes";       
        }

        static public ProductoComponente Modelo()
        {
            return new ProductoComponente();
        }

        public List<Fila> SeleccionarComponentesParaProducto(int idProducto, int idCotizacion)
        {
            string query = "SELECT * FROM producto_componentes where producto=@idProducto and id_cotizacion=@idCotizacion and id NOT IN (SELECT id_componente_el FROM prod_subensambles_componentes) AND id NOT IN (SELECT id_subensamble_el FROM prod_subensambles_subensambles);";
            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarComponentesParaEntradasProducto(int idProducto, int idCotizacion)
        {
            string query = "SELECT * FROM producto_componentes where producto=@idProducto and id_cotizacion=@idCotizacion;";
            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarComponentesParaSalidasProducto(int idProducto, int idCotizacion)
        {
            string query = "SELECT * FROM producto_componentes where producto=@idProducto and id_cotizacion=@idCotizacion;";
            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarComponentePorProducto(int idProducto)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM producto_componentes where producto =@idProducto; " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            EjecutarQuery();
        }

        public void BorrarComponente(int idComponente)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM producto_componentes where id =@idComponente; " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            EjecutarQuery();
        }
    }
}

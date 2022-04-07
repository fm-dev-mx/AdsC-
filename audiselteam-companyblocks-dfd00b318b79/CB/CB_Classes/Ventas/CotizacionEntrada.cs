using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionEntrada : ModeloMySql
    {
        public CotizacionEntrada()
        {
            Tabla = "cotizaciones_entradas";
        }

        static public CotizacionEntrada Modelo()
        {
            return new CotizacionEntrada();
        }

        public List<Fila> SeleccionarCotizacionesEntradasDeProducto(int idProducto, int idProcesoManufactura)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE id IN (SELECT cotizaciones_procesos_manufactura.cotizaciones_entradas FROM cotizaciones_procesos_manufactura WHERE cotizaciones_procesos_manufactura.producto = @idProducto) and id_cotizacion_proceso_manufactura=@idProcesoManufactura;";
            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idProcesoManufactura", idProcesoManufactura);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarEntradas(int idEntrada)
        {
            string query = "SET SQL_SAFE_UPDATES=0;";
            query += "DELETE from cotizaciones_entradas where id_cotizacion = @id;";
            query += "SET SQL_SAFE_UPDATES=1;";

            ConstruirQuery(query);
            AgregarParametro("@id", idEntrada);
            EjecutarQuery();
        }

        public List<Fila> SeleccionarEntradasDeCotizacion(int idCotizacion)
        {
            string query = "select * from " + Tabla + " where id_cotizacion=@idCotizacion;";

            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarEntrada(int idCotizacion, string nombre)
        {
            string query = "SET SQL_SAFE_UPDATES=0;";
            query += "DELETE from cotizaciones_entradas where id_cotizacion = @id and nombre=@nombre;";
            query += "SET SQL_SAFE_UPDATES=1;";

            ConstruirQuery(query);
            AgregarParametro("@id", idCotizacion);
            AgregarParametro("@nombre", nombre);
            EjecutarQuery();
        }
    }
}

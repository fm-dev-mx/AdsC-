using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionSalida : ModeloMySql
    {
        public CotizacionSalida()
        {
            Tabla = "cotizaciones_salidas";
        }

        static public CotizacionSalida Modelo()
        {
            return new CotizacionSalida();
        }

        public List<Fila> SeleccionarCotizacionesSalidaDeProducto(int idProducto, int idProcesoManufactura)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE id IN (SELECT cotizaciones_procesos_manufactura.cotizaciones_salidas FROM cotizaciones_procesos_manufactura WHERE cotizaciones_procesos_manufactura.producto = @idProducto) and id_cotizacion_proceso_manufactura=@idProcesoManufactura;";
            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idProcesoManufactura", idProcesoManufactura);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarSalidas(int idProcesoManufactura)
        {
            string query = "SET SQL_SAFE_UPDATES=0;";
            query += "DELETE from cotizaciones_salidas where id_cotizacion_proceso_manufactura = @idProcesoManufactura;";
            query += "SET SQL_SAFE_UPDATES=1;";

            ConstruirQuery(query);
            AgregarParametro("@idProcesoManufactura", idProcesoManufactura);
            EjecutarQuery();
        }

        public List<Fila> SeleccionarSalidasDeCotizacion(int idCotizacion)
        {
            string query = "select * from " + Tabla + " where id_cotizacion=@idCotizacion;";

            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarSalida(int idCotizacion, string nombre)
        {
            string query = "SET SQL_SAFE_UPDATES=0;";
            query += "DELETE from " + Tabla + " where id_cotizacion = @id and nombre=@nombre;";
            query += "SET SQL_SAFE_UPDATES=1;";

            ConstruirQuery(query);
            AgregarParametro("@id", idCotizacion);
            AgregarParametro("@nombre", nombre);
            EjecutarQuery();
        }
    }
}

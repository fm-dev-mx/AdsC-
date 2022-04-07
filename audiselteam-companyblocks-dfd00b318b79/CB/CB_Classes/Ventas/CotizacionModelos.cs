using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionModelos : ModeloMySql
    {
        public CotizacionModelos()
        {
            Tabla = "cotizaciones_modelos";
        }

        static public CotizacionModelos Modelo()
        {
            return new CotizacionModelos();
        }

        public List<Fila> SeleccionarModelosDeProcesosDeProducto(int idProcesoManufactura)
        {
            string query = "SELECT * FROM producto_modelos WHERE id IN (SELECT id_modelo FROM " + Tabla + " WHERE id_cotizacion_proceso_manufactura=@idProcesoManufactura);";
            ConstruirQuery(query);
            AgregarParametro("@idProcesoManufactura", idProcesoManufactura);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarModelos(int idCotizacion, int idModelo)
        {
            string query = "SET SQL_SAFE_UPDATES=0;";
            query += "DELETE from cotizaciones_modelos where id_cotizacion = @idCotizacion and id_modelo=@idModelo;";
            query += "SET SQL_SAFE_UPDATES=1;";

            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            AgregarParametro("@idModelo", idModelo);
            EjecutarQuery();
        }

        public List<Fila> SeleccionarModelosDeCotizacion(int idCotizacion)
        {
            string query = "select producto_modelos.nombre from " + Tabla;
            query += " INNER JOIN producto_modelos ON producto_modelos.id = cotizaciones_modelos.id_modelo ";
            query += " WHERE producto_modelos.id_cotizacion = @idCotizacion;";

            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

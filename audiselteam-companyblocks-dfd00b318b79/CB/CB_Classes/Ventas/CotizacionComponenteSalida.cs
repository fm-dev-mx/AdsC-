using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionComponenteSalida : ModeloMySql
    {
        public CotizacionComponenteSalida()
        {
            Tabla = "cotizaciones_componentes_salidas";       
        }

        static public CotizacionComponenteSalida Modelo()
        {
            return new CotizacionComponenteSalida();
        }

        public void BorrarComponentesSalidas(int idProcesoManufactura)
        {
            string query = "SET SQL_SAFE_UPDATES=0;";
            query += "DELETE FROM cotizaciones_componentes_salidas WHERE id_cotizaciones_salida = (SELECT cotizaciones_salidas.id FROM cotizaciones_salidas WHERE id_cotizacion_proceso_manufactura = @idProcesoManufactura);";
            query += "SET SQL_SAFE_UPDATES=1;";

            ConstruirQuery(query);
            AgregarParametro("@idProcesoManufactura", idProcesoManufactura);
            EjecutarQuery();
        }

        public void BorrarSalida(int idCotizacion, int idComponente)
        {
            string query = "set sql_safe_updates = 0; ";
            query += "DELETE FROM " + Tabla + " WHERE id_componente=@idComponente and id_cotizacion=@idCotizacion;";
            query += "set sql_safe_updates = 0; ";

            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
        }
    }
}

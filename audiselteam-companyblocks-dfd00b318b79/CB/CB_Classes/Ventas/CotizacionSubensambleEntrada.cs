using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionSubensambleEntrada : ModeloMySql
    {
        public CotizacionSubensambleEntrada()
        {
            Tabla = "cotizaciones_subensambles_entradas";       
        }

        static public CotizacionSubensambleEntrada Modelo()
        {
            return new CotizacionSubensambleEntrada();
        }

        public void BorrarSubensamblesEntradas(int idProcesoManufactura)
        {
            string query = "SET SQL_SAFE_UPDATES=0;";
            query += "DELETE FROM cotizaciones_subensambles_entradas WHERE id_cotizaciones_entrada = (SELECT cotizaciones_entradas.id FROM cotizaciones_entradas WHERE id_cotizacion_proceso_manufactura = @idProcesoManufactura);";
            query += "SET SQL_SAFE_UPDATES=1;";

            ConstruirQuery(query);
            AgregarParametro("@idProcesoManufactura", idProcesoManufactura);
            EjecutarQuery();
        }

        public void BorrarEntrada(int idCotizacion, int idSubensamble)
        {
            string query = "set sql_safe_updates = 0; ";
            query += "DELETE FROM " + Tabla + " WHERE id_subensamble=@idSubensamble and id_cotizacion=@idCotizacion;";
            query += "set sql_safe_updates = 0; ";

            ConstruirQuery(query);
            AgregarParametro("@idSubensamble", idSubensamble);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
        }
    }
}

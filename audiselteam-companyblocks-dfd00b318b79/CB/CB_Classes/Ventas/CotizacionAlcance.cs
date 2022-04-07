using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionAlcance : ModeloMySql
    {
        public CotizacionAlcance()
        {
            Tabla = "cotizaciones_alcance";       
        }

        static public CotizacionAlcance Modelo()
        {
            return new CotizacionAlcance();
        }

        public List<Fila> AlcanceCotizacion(int idCotizacion)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE cotizacion = @idCotizacion";
            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProcesosCotizaciones(int idCotizacion)
        {
            string query = "SELECT cotizaciones_alcance.id, cotizaciones_alcance.proceso as proceso, procesos.nombre, cotizaciones_alcance.alcance, cotizaciones_alcance.personas, cotizaciones_alcance.horas ";
            query += "FROM audisel.cotizaciones_alcance ";
            query += "INNER JOIN procesos ON procesos.id = cotizaciones_alcance.proceso ";
            query += "WHERE cotizaciones_alcance.cotizacion = @idCotizacion ";
            query += "GROUP BY procesos.id ORDER BY cotizaciones_alcance.id ASC, procesos.nombre ASC;";

            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarAlcancePorProcesoCotizacion(int idCotizacion, int idProceso)
        {
            string query = "SELECT cotizaciones_alcance.id, procesos.nombre, cotizaciones_alcance.alcance, cotizaciones_alcance.personas, cotizaciones_alcance.horas ";
            query += "FROM audisel.cotizaciones_alcance ";
            query += "INNER JOIN procesos ON procesos.id = cotizaciones_alcance.proceso ";
            query += "WHERE cotizaciones_alcance.cotizacion = @idCotizacion AND cotizaciones_alcance.proceso=@idProceso ";
            query += "ORDER BY cotizaciones_alcance.id ASC, procesos.nombre ASC;";

            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            AgregarParametro("@idProceso", idProceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SumarHorasPersonasCotizacion(int idCotizacion, int idProceso)
        {
            string query = "SELECT SUM(cotizaciones_alcance.horas) as horas, SUM(personas) as personas ";
            query += "FROM audisel.cotizaciones_alcance ";
            query += "INNER JOIN procesos ON procesos.id = cotizaciones_alcance.proceso ";
            query += "WHERE cotizaciones_alcance.cotizacion = @idCotizacion AND cotizaciones_alcance.proceso=@idProceso ";
            query += "ORDER BY cotizaciones_alcance.id ASC, procesos.nombre ASC;";

            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            AgregarParametro("@idProceso", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

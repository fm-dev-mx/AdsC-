using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionPokayoke : ModeloMySql
    {
        public CotizacionPokayoke()
        {
            Tabla = "cotizaciones_pokayokes";       
        }

        static public CotizacionPokayoke Modelo()
        {
            return new CotizacionPokayoke();
        }

        public List<Fila> SeleccionarPokayokesDeCotizacion(int idCotizacion)
        {
            string query = "select cotizaciones_pokayokes.id, cotizaciones_pokayokes.alcance, pokayokes_targets.nombre as target, pokayokes_metodos.nombre as metodo ";
            query += "from cotizaciones_pokayokes ";
            query += "INNER JOIN pokayokes_targets ON pokayokes_targets.id = cotizaciones_pokayokes.id_target ";
            query += "INNER JOIN pokayokes_metodos ON pokayokes_metodos.id = cotizaciones_pokayokes.id_metodo ";
            query += "WHERE cotizaciones_pokayokes.id_cotizacion = @idCotizacion;";
            
            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarPokayokePorId(int id)
        {
            string query = "SELECT cotizaciones_pokayokes.id, cotizaciones_pokayokes.alcance,cotizaciones_pokayokes.id_metodo, cotizaciones_pokayokes.id_target, pokayokes_targets.nombre as target, pokayokes_metodos.nombre as metodo ";
            query += "FROM cotizaciones_pokayokes ";
            query += "INNER JOIN pokayokes_targets ON pokayokes_targets.id = cotizaciones_pokayokes.id_target ";
            query += "INNER JOIN pokayokes_metodos ON pokayokes_metodos.id = cotizaciones_pokayokes.id_metodo ";
            query += "WHERE cotizaciones_pokayokes.id = @id;";

            ConstruirQuery(query);
            AgregarParametro("@id", id);
            EjecutarQuery();

            return LeerFilas();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PokayokeTarget : ModeloMySql
    {
        public PokayokeTarget()
        {
            Tabla = "pokayokes_targets";       
        }

        static public PokayokeTarget Modelo()
        {
            return new PokayokeTarget();
        }
    
        public void BorrarTargetsDeCotizacion(int idCotizacion)
        {
            string query = "SET SQL_SAFE_UPDATES = 0;";
            query += "DELETE FROM pokayokes_targets WHERE id_cotizacion=@idCotizacion;";
            query += "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
        }

        public void BorrarTarget(int id)
        {
            string query = "DELETE FROM " + Tabla + " WHERE id=@id;";

            ConstruirQuery(query);
            AgregarParametro("@id", id);
            EjecutarQuery();
        }

        public List<Fila> SeleccionarTargetPorIdPokayoke(int idPokayoke)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE id_pokayoke=@idPokayoke;";

            ConstruirQuery(query);
            AgregarParametro("@idPokayoke", idPokayoke);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

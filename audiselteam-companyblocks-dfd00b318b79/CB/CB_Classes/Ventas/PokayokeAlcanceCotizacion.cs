using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PokayokeAlcanceCotizacion : ModeloMySql
    {
        public PokayokeAlcanceCotizacion()
        {
            Tabla = "pokayokes_alcance_cotizaciones";
        }

        static public PokayokeAlcanceCotizacion Modelo()
        {
            return new PokayokeAlcanceCotizacion();
        }

        public void BorrarAlcancesVinculados(int idPokayoke)
        {
            string query = "SET SQL_SAFE_UPDATES=0;";
            query += "DELETE FROM " + Tabla + " WHERE id_pokayoke=@id;";
            query += "SET SQL_SAFE_UPDATES=1;";

            ConstruirQuery(query);
            AgregarParametro("@id", idPokayoke);
            EjecutarQuery();
        }

        public List<Fila> SeleccionarAlcancesVisculados(int idPokayoke, int idAlcance, int idMetodo, int idTarget)
        {
            string query = "select * from pokayokes_alcance_cotizaciones where id_alcance =@idAlcance and id_pokayoke =@idPokayoke and id_metodo=@idMetodo";
            if (idTarget > 0)
                query += " and id_target=@idTarget;";
            ConstruirQuery(query);
            AgregarParametro("@idAlcance", idAlcance);
            AgregarParametro("@idPokayoke", idPokayoke);
            AgregarParametro("@idMetodo", idMetodo);
            AgregarParametro("@idTarget", idTarget);
            EjecutarQuery();

            return LeerFilas();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Industria : ModeloMySql
    {
        public Industria()
        {
            Tabla = "industrias";       
        }

        static public Industria Modelo()
        {
            return new Industria();
        }

        public List<Fila> SeleccionarIndustriaOrdenAlfabetico(int idCliente)
        {
            string query = "select industrias.id as id, industrias.nombre as nombre from cliente_industrias " +
                           "Inner join industrias ON industrias.id = cliente_industrias.industria_id " +
                           "where cliente_industrias.cliente_id = @idCliente;";

            ConstruirQuery(query);
            AgregarParametro("@idCliente", idCliente);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

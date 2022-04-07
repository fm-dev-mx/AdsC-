using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ClienteIndustria : ModeloMySql
    {

        public ClienteIndustria()
        {
            Tabla = "clientes_industrias";
        }

        static public ClienteIndustria Modelo()
        {
            return new ClienteIndustria();
        }

        public List<Fila> SeleccionarCliente(int idCliente)
        {
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@idCliente", idCliente);
            return SeleccionarDatos("cliente=@idCliente", parametros);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class ClienteProducto : ModeloMySql
    {

        public ClienteProducto()
        {
            Tabla = "clientes_productos";
        }

        static public ClienteProducto Modelo()
        {
            return new ClienteProducto();
        }

        public List<Fila> Clases(int idCliente, int idIndustria)
        {
            string sql = "SELECT DISTINCT clase FROM clientes_productos WHERE cliente=@idCliente AND industria=@idIndustria";
            ConstruirQuery(sql);
            AgregarParametro("@idCliente", idCliente);
            AgregarParametro("@idIndustria", idIndustria);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

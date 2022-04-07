using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ClienteProductoComponente : ModeloMySql
    {

        public ClienteProductoComponente()
        {
            Tabla = "clientes_productos_componentes";
        }

        static public ClienteProductoComponente Modelo()
        {
            return new ClienteProductoComponente();
        }

        public List<Fila> SeleccionarProducto(int idProducto)
        {
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@idProducto", idProducto);
            return SeleccionarDatos("producto=@idProducto", parametros);
        }

    }
}

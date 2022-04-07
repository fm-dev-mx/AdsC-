using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ClienteProductoVariante : ModeloMySql
    {
        public ClienteProductoVariante()
        {
            Tabla = "cliente_producto_variante";
        }

        static public ClienteProductoVariante Modelo()
        {
            return new ClienteProductoVariante();
        }
    }
}

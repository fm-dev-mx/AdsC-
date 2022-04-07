using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ClienteProductoModelo : ModeloMySql
    {
        public ClienteProductoModelo()
        {
            Tabla = "clientes_productos_modelos";
        }

        static public ClienteProductoModelo Modelo()
        {
            return new ClienteProductoModelo();
        }

        public List<Fila> SeleccionarProducto(int idProducto)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE producto=@producto";
            ConstruirQuery(sql);
            AgregarParametro("@producto", idProducto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Familias(int idProducto)
        {
            string sql = "SELECT DISTINCT familia FROM " + Tabla + " WHERE producto=@producto";
            ConstruirQuery(sql);
            AgregarParametro("@producto", idProducto);
            EjecutarQuery();
            return LeerFilas();
        }

        public bool Existe(int idProducto, string familia, string modelo)
        {
            string sql = "SELECT *FROM " + Tabla + " WHERE producto=@producto AND familia=@familia AND modelo=@modelo";
            ConstruirQuery(sql);
            AgregarParametro("@producto", idProducto);
            AgregarParametro("@familia", familia);
            AgregarParametro("@modelo", modelo);
            EjecutarQuery();
            return LeerFilas().Count > 0;
        }
    }
}

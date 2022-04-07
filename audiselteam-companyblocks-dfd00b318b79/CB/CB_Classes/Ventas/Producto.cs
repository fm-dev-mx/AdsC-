using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Producto : ModeloMySql
    {
        public Producto()
        {
            Tabla = "producto";       
        }

        static public Producto Modelo()
        {
            return new Producto();
        }

        public List<Fila> SeleccionarProducto(int idCliente, int idIndustria = 0)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE cliente=@idCliente ORDER BY nombre asc";

            ConstruirQuery(query);
            AgregarParametro("@idCliente", idCliente);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarProducto(int idProducto, List<string> informacion)
        {
            ProductoSubensamble.Modelo().BorrarSubensambleDeProducto(idProducto);
            ProductoSubensamblesSubensamble.Modelo().BorrarSubensambleDeProducto(idProducto);
            ProductoSubensambleComponente.Modelo().BorrarSubensambleDeProducto(idProducto);
            ProductoVariante.Modelo().BorrarVarianteDeLista(informacion);
            ProductoModelo.Modelo().BorrarModeloPorProducto(idProducto);
            ProductoComponente.Modelo().BorrarComponentePorProducto(idProducto);

            string query = "DELETE FROM producto where id =@idProducto;";

            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            EjecutarQuery();
        }
    
    }
}

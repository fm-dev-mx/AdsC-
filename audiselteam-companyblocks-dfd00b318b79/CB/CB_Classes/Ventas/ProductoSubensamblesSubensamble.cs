using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProductoSubensamblesSubensamble : ModeloMySql
    {
        public ProductoSubensamblesSubensamble()
        {
            Tabla = "prod_subensambles_subensambles";       
        }

        static public ProductoSubensamblesSubensamble Modelo()
        {
            return new ProductoSubensamblesSubensamble();
        }

        public List<Fila> SeleccionarSubEnsambleDeSubensamble(int idSubensamble)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE id_subensamble=@idSubensamble";

            ConstruirQuery(query);
            AgregarParametro("@idSubensamble", idSubensamble);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarSubensambleDeProducto(int idProducto)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM prod_subensambles_subensambles where id_subensamble IN (SELECT id FROM producto_subensambles where producto =@idProducto); " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            EjecutarQuery();
        }

        public void BorrarSubensamble(int idSubensamble)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM prod_subensambles_subensambles where id_subensamble =@idSubensamble; " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idSubensamble", idSubensamble);
            EjecutarQuery();
        }

        public void BorrarSubensamblePorComponente(int idComponente)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM prod_subensambles_subensambles where id_subensamble_el =@idComponente; " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            EjecutarQuery();
        }
    }
}

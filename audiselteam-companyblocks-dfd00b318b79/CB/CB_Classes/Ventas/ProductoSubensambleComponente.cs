using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProductoSubensambleComponente : ModeloMySql
    {
        public ProductoSubensambleComponente()
        {
            Tabla = "prod_subensambles_componentes";       
        }

        static public ProductoSubensambleComponente Modelo()
        {
            return new ProductoSubensambleComponente();
        }

        public void BorrarSubensambleDeProducto(int idProducto)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM prod_subensambles_componentes where id_componente_el IN (SELECT id FROM producto_componentes where producto =@idProducto); " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            EjecutarQuery();
        }

        public void BorrarSubensamble(int idSubensamble)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM prod_subensambles_componentes where id_subensamble =@idSubensamble; " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idSubensamble", idSubensamble);
            EjecutarQuery();
        }

        public void BorrarSubensamblePorComponente(int idComponente)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM prod_subensambles_componentes where id_componente_el =@idComponente; " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            EjecutarQuery();
        }
    }
}

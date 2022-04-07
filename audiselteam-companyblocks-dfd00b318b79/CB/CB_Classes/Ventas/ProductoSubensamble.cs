using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProductoSubensamble : ModeloMySql
    {
        public ProductoSubensamble()
        {
            Tabla = "producto_subensambles";       
        }

        static public ProductoSubensamble Modelo()
        {
            return new ProductoSubensamble();
        }

        public List<Fila> SeleccionarSubensambles(int idProducto, int idCotizacion)
        {
            string query = "SELECT * FROM " + Tabla + " where producto =@idProducto and id_cotizacion=@idCotizacion";
            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarSubensamblesEntradasProducto(int idProducto, int idCotizacion)
        {
            string query = "SELECT * FROM " + Tabla + " where producto =@idProducto and id_cotizacion=@IdCotizacion;";
            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarSubensamblesSalidasProducto(int idProducto, int idCotizacion)
        {
            string query = "SELECT * FROM " + Tabla + " where producto =@idProducto and id_cotizacion=@idCotizacion;";
            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarSubensambleDeProducto(int idProducto)
        {
            string query = "SET SQL_SAFE_UPDATES = 0; " +
                           "DELETE FROM producto_subensambles where producto =@idProducto; " +
                           "SET SQL_SAFE_UPDATES = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idProducto", idProducto);
            EjecutarQuery();
        }

        public void BorrarSubensamble(int idSubensamble = 0)
        {
            string query = string.Empty;

            query = "SET FOREIGN_KEY_CHECKS = 0; " +
                "SET SQL_SAFE_UPDATES = 0; " +
                "DELETE from prod_subensambles_componentes where id_subensamble = @idSubensamble; " +
                "DELETE from prod_subensambles_subensambles where id_subensamble = @idSubensamble; " +
                "DELETE from producto_subensambles where id = @idSubensamble; " +
                "SET SQL_SAFE_UPDATES = 1; " +
                "SET FOREIGN_KEY_CHECKS = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idSubensamble", idSubensamble);
            EjecutarQuery();
        }

        public void BorrarComponente(int idComponente = 0)
        {
            string idSubensambles = string.Empty;
            string query = string.Empty;

            query = "select * from prod_subensambles_subensambles where id_subensamble_el = @idComponente;";

            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            EjecutarQuery();
            LeerFilas().ForEach(delegate(Fila f)
            {
                idSubensambles += f.Celda("id_subensamble").ToString() + ",";
                BorrarSubensamble(Convert.ToInt32(f.Celda("id_subensamble")));
            });

            query = "select * from prod_subensambles_componentes where id_componente_el = @idComponente;";

            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            EjecutarQuery();
            LeerFilas().ForEach(delegate(Fila f)
            {
                idSubensambles += f.Celda("id_subensamble").ToString() + ",";
                BorrarSubensamble(Convert.ToInt32(f.Celda("id_subensamble")));
            });

            if (idSubensambles != "")
                idSubensambles = idSubensambles.Remove(idSubensambles.Length - 1);
            else
                idSubensambles = "0";
            
            query = "SET FOREIGN_KEY_CHECKS = 0; " +
                "SET SQL_SAFE_UPDATES = 0; " +               
                "DELETE from producto_subensambles where id IN(select id_subensamble from prod_subensambles_componentes where id_componente_el = @idComponente); " +
                "DELETE from producto_subensambles where id IN(select id_subensamble from prod_subensambles_subensambles where id_subensamble_el = @idComponente); " +
                "DELETE from producto_subensambles where id IN (" + idSubensambles + "); " +
                "DELETE FROM producto_variantes where componente = @idComponente; " +
                "DELETE from producto_componentes where id =@idComponente; " +
                "SET SQL_SAFE_UPDATES = 1; " +
                "SET FOREIGN_KEY_CHECKS = 1;";

            ConstruirQuery(query);
            AgregarParametro("@idComponente", idComponente);
            EjecutarQuery();
        }

        public void BorrarSubensamblePorComponente(string nombre)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE id LIKE '%" + nombre + "%';";
            ConstruirQuery(query);
            EjecutarQuery();

            List<Fila> nombreSubensamble = LeerFilas();
            string nombreSub = string.Empty;

            nombreSubensamble.ForEach(delegate(Fila f)
            {
                nombreSub = f.Celda("nombre").ToString();
            });

            query = "SET FOREIGN_KEY_CHECKS = 0; " +
                    "SET SQL_SAFE_UPDATES = 0; " +
                    "DELETE FROM producto_subensambles where nombre LIKE '%" + nombreSub + "%'; " +
                    "SET SQL_SAFE_UPDATES = 1; " +
                    "SET FOREIGN_KEY_CHECKS = 1;";

            ConstruirQuery(query);
            EjecutarQuery();
        }
    }
}

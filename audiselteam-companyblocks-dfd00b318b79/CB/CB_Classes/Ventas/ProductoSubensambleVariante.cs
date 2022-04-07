using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProductoSubensambleVariante : ModeloMySql
    {
        public ProductoSubensambleVariante()
        {
            Tabla = "prod_subensamble_variante";
        }

        static public ProductoSubensambleVariante Modelo()
        { 
            return new ProductoSubensambleVariante();
        }

        public List<Fila> SeleccionarVariantesSubensamble(int idSubensamble)
        {
            string query = "select * from prod_subensamble_variante where id_subensamble = @idSubensamble;";
            ConstruirQuery(query);
            AgregarParametro("@idSubensamble", idSubensamble);
            EjecutarQuery();

            return LeerFilas();
        }
    }
}

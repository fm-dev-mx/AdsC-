using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ElementoTipo : ModeloMySql
    {

        public ElementoTipo()
        {
            Tabla = "elementos_tipos";
        }

        static public ElementoTipo Modelo()
        {
            return new ElementoTipo();
        }

        public List<Fila> Todos()
        {
            string sql = "SELECT * FROM " + Tabla + " ORDER BY tipo ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

    }
}

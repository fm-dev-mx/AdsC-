using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TipoDefecto : ModeloMySql
    {
        public TipoDefecto()
        {
            Tabla = "tipos_defectos";
        }

        static public TipoDefecto Modelo()
        {
            return new TipoDefecto();
        }

        public List<Fila> SeleccionarTipos()
        {
            string sql = "SELECT * FROM " + Tabla + " order by tipos asc";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TipoActividadEnsamble : ModeloMySql
    {
        public TipoActividadEnsamble()
        {
            Tabla = "tipos_actividades_ensamble";
        }

        public static TipoActividadEnsamble Modelo()
        {
            return new TipoActividadEnsamble();
        }

        public List<Fila> CargarDatos()
        {
            string sql = "SELECT tipo FROM " + Tabla;
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

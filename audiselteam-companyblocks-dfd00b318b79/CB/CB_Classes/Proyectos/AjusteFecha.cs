using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class AjusteFecha : ModeloMySql
    {
        public AjusteFecha()
        {
            Tabla = "ajustes_fechas";
        }

        static public AjusteFecha Modelo()
        {
            return new AjusteFecha();
        }

        public List<Fila> SeleccionarProyecto(decimal proyecto, int razon = 0)
        {
            string query = "proyecto=@proyecto";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);

            if (razon != 0)
            {
                query += " and razon = @razon";
                parametros.Add("@razon", razon);
            }

            return SeleccionarDatos(query, parametros);
        }

        public List<Fila> SeleccionarRazonesProyecto(decimal proyecto)
        {
            string sql = "SELECT DISTINCT(razones_ajustes_fechas.razon), " +
                         "ajustes_fechas.razon as id_razon, razones_ajustes_fechas.id " + 
                         "FROM ajustes_fechas " + 
                         "INNER JOIN razones_ajustes_fechas " + 
                         "ON razones_ajustes_fechas.id = ajustes_fechas.razon " +
                         "WHERE ajustes_fechas.proyecto=@proyecto " +
                         "ORDER BY id ASC";

            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

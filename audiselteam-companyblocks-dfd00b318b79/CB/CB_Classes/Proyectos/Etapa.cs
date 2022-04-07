using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Etapa : ModeloMySql
    {
        public Etapa()
        {
            Tabla = "etapas";
        }

        static public Etapa Modelo()
        {
            return new Etapa();
        }

        public Fila SeleccionarEtapaProyecto(int etapa, double proyecto)
        {
            string condiciones = "etapa=@etapa AND proyecto=@proyecto";
            
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@etapa", etapa);
            parametros.Add("@proyecto", proyecto);

            SeleccionarDatos(condiciones, parametros);

            return Fila();
        }

        public List<Fila> Etapas()
        {
            string sql = "SELECT DISTINCT etapa FROM " + Tabla + " ORDER BY etapa ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

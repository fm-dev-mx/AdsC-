using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CriterioRiesgo : ModeloMySql
    {
        public CriterioRiesgo()
        {
            Tabla = "criterios_riesgos";
        }

        static public CriterioRiesgo Modelo()
        {
            return new CriterioRiesgo();
        }

        public List<Fila> Perspectivas()
        {
            ConstruirQuery("SELECT DISTINCT perspectiva FROM " + Tabla);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Consecuencias(string perspectiva)
        {
            ConstruirQuery("SELECT * FROM criterios_riesgos WHERE perspectiva=@perspectiva");
            AgregarParametro("@perspectiva", perspectiva);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

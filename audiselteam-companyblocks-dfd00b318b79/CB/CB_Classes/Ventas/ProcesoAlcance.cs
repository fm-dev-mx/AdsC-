using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProcesoAlcance : ModeloMySql
    {
        public ProcesoAlcance()
        {
            Tabla = "procesos_alcances";       
        }

        static public ProcesoAlcance Modelo()
        {
            return new ProcesoAlcance();
        }

        public List<Fila> CargarAlcancesDeProceso(int idProceso)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE proceso=@idProceso";
            ConstruirQuery(query);
            AgregarParametro("@idProceso", idProceso);
            EjecutarQuery();
            return LeerFilas();
        }
    
    }
}

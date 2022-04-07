using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProcesoHerramentista : ModeloMySql
    {
        public ProcesoHerramentista()
        {
            Tabla = "procesos_herramentistas";
        }

        static public ProcesoHerramentista Modelo()
        {
            return new ProcesoHerramentista();
        }

        public List<Fila> CargarHerramentistasDeProceso(int idProceso)
        {
            string query = string.Empty;
            query = "SELECT  * FROM " + Tabla + " WHERE proceso = @idProceso";
            
            ConstruirQuery(query);
            AgregarParametro("@idProceso", idProceso);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

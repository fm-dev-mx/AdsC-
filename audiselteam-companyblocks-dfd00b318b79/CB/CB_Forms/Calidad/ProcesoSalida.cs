using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProcesoSalida : ModeloMySql 
    {
        public ProcesoSalida()
        {
            Tabla = "procesos_salidas";
        }

        static public ProcesoSalida Modelo()
        {
            return new ProcesoSalida();
        }

        public List<Fila> TiposEntregables(int idProceso)
        {
            ConstruirQuery("SELECT DISTINCT tipo_entregable FROM " + Tabla + " WHERE proceso=@idProceso");
            AgregarParametro("@idProceso", idProceso);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

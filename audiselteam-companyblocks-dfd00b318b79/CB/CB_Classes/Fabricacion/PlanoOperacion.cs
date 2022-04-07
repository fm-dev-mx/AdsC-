using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PlanoOperacion : ModeloMySql
    {
        public PlanoOperacion()
        {
            Tabla = "planos_operaciones";
        }

        static public PlanoOperacion Modelo()
        {
            return new PlanoOperacion();
        }

        public List<Fila> SeleccionarOperacion(int idPlano, int idProceso)
        {
            string sql = "SELECT operaciones_fabricacion.id as idOperacionesFabricacion, operaciones_fabricacion.nombre_proceso, operaciones_fabricacion.nombre_operacion, operaciones_fabricacion.tiempo_estandar,  planos_operaciones.cantidad_operaciones, planos_operaciones.id as idPlanoOperaciones " +
                         "FROM audisel.operaciones_fabricacion " +
                         "INNER JOIN planos_operaciones ON planos_operaciones.operacion = operaciones_fabricacion.id " +
                         "WHERE planos_operaciones.plano =@plano AND planos_operaciones.proceso =@proceso";

            ConstruirQuery(sql);
            AgregarParametro("@plano", idPlano);
            AgregarParametro("@proceso", idProceso);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ValeSalidaItem : ModeloMySql
    {
        public ValeSalidaItem()
        {
            Tabla = "vales_salida_items";
        }

        static public ValeSalidaItem Modelo()
        {
            return new ValeSalidaItem();
        }

        public List<Fila> CargarItemsVale(int idVale)
        {
            string sql = "select vales_salida_items.id as idVale, vales_salida_items.proceso, " +
                         "planos_procesos.id as idProceso, planos_procesos.requisicion_compra, planos_procesos.proceso as tratamientoProceso," +
                         "planos_proyectos.id as idPlano, planos_proyectos.nombre_archivo, planos_proyectos.cantidad, planos_proyectos.material, planos_proyectos.estatus," +
                         "tratamientos_material.categoria " +
                         "from vales_salida_items " +
                         "inner join planos_procesos on planos_procesos.id = vales_salida_items.proceso " +
                         "inner join planos_proyectos on planos_proyectos.id = planos_procesos.plano " +
                         "inner join tratamientos_material on tratamientos_material.nombre = planos_procesos.proceso " +
                         "where vales_salida_items.vale_salida=@idVale";

            ConstruirQuery(sql);
            AgregarParametro("@idVale", idVale);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class OrdenTrabajoMantenimiento : ModeloMySql
    {
        public OrdenTrabajoMantenimiento()
        {
            Tabla = "orden_mantenimiento";
        }

        static public OrdenTrabajoMantenimiento Modelo()
        {
            return new OrdenTrabajoMantenimiento();
        }

        public List<Fila> CargarOrdenMantenimiento()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatusPendiente", "PENDIENTE");
            parametros.Add("@estatusEnProceso", "EN PROCESO");
            return SeleccionarDatos("", null);
        }

        public List<Fila> MantenimientoCorrectivo(int idOrden)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "TERMINADO");
            parametros.Add("@idOrden", idOrden);
            return SeleccionarDatos("estatus=@estatus and id=@idOrden", parametros);
        }
    }
}

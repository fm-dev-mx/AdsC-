using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MovimientoAlmacen : ModeloMySql
    {
        public MovimientoAlmacen()
        {
            Tabla = "movimientos_almacen";
        }

        static public MovimientoAlmacen Modelo()
        {
            return new MovimientoAlmacen();
        }

        public List<Fila> MovimientosPendientes()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatusPendiente", "PENDIENTE");
            SeleccionarDatos("estatus = @estatusPendiente", parametros);
            return Filas();
        }

        public List<Fila> MovimientosRealizados()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatusRealizado", "REALIZADO");
            SeleccionarDatos("estatus = @estatusRealizado", parametros);
            return Filas();
        }
        
    }
}

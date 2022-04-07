using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ActividadesTiempoExtra : ModeloMySql
    {

        public ActividadesTiempoExtra()
        {
            Tabla = "actividades_tiempo_extra";
        }

        public List<Fila> BuscarProcesoFabricacion(int idProcesoFabricacion)
        {
            ConstruirQuery("SELECT * FROM " + Tabla + " WHERE proceso_fabricacion=@proceso_fabricacion");
            AgregarParametro("@proceso_fabricacion", idProcesoFabricacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> BuscarTarea(int idTarea)
        {
            ConstruirQuery("SELECT * FROM " + Tabla + " WHERE tarea=@tarea");
            AgregarParametro("@tarea", idTarea);
            EjecutarQuery();
            return LeerFilas();
        }

        public static ActividadesTiempoExtra Modelo()
        {
            return new ActividadesTiempoExtra();
        }

        public List<Fila> SeleccionarUsuario(int usuario, DateTime desde, DateTime hasta)
        {
            ConstruirQuery("SELECT * FROM " + Tabla + " WHERE usuario=@usuario AND ( DATE(fecha)>=DATE(@desde) AND DATE(fecha)<=DATE(@hasta) ) ORDER BY fecha ASC");
            AgregarParametro("@usuario", usuario);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

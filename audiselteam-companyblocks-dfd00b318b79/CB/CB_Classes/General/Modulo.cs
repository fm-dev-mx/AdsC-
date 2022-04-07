using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Modulo : ModeloMySql
    {

        public Modulo()
        {
            Tabla = "modulos";
        }

        static public Modulo Modelo()
        {
            return new Modulo();
        }

        public List<Fila> SeleccionarProyecto(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);

            return SeleccionarDatos("proyecto=@proyecto ORDER BY subensamble ASC", parametros);
        }

        public List<Fila> SeleccionarProyectoSubensamble(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);

            return SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble ORDER BY subensamble ASC", parametros);
        }

        public List<Fila> SeleccionarModulos(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@estatus", "PENDIENTE");

            return SeleccionarDatos("proyecto=@proyecto and estatus_liberacion=@estatus ORDER BY subensamble ASC", parametros);
        }

        public List<Fila> BuscarCambioDiseno(int idModulo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@id", idModulo);
            parametros.Add("@cambio", 0);

            return SeleccionarDatos("id=@id and cambio_diseno !=@cambio", parametros);
        }

        public List<Fila> SeleccionarInspeccionPendiente()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus_inspeccion", "PENDIENTE");

            return SeleccionarDatos("estatus_inspeccion=@estatus_inspeccion", parametros);
        }

        public List<Fila> ModulosSinMetaDeFabricacion(decimal idProyecto, DateTime fechaSeleccionada)
        {
            string sql = 
                "DROP TEMPORARY TABLE IF EXISTS temp_modulos_agrupacion; " +
                "CREATE TEMPORARY TABLE temp_modulos_agrupacion " +
                "SELECT distinct subensamble from planos_proyectos where proyecto = @idProyecto AND estatus IN ('PENDIENTE', 'EN PREPARACION', 'EN FABRICACION') " +
                "AND fecha_promesa_fabricacion IS NULL; " +
                "SELECT * FROM modulos WHERE proyecto = @idProyecto " +
                "and modulos.subensamble in (select subensamble from temp_modulos_agrupacion) " +
                "AND DATE(fecha_promesa_congelacion) <= DATE(@fechaSeleccionada) " +
                "AND modulos.estatus_aprobacion='APROBADO' AND modulos.fecha_promesa_fabricacion IS NULL group by modulos.id ORDER BY subensamble;";
            
            ConstruirQuery(sql);
            AgregarParametro("@idProyecto", idProyecto);
            AgregarParametro("@fechaSeleccionada", fechaSeleccionada);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ModulosSinMetaDeCongelacion(decimal idProyecto)
        {
            string sql = "SELECT * FROM modulos WHERE proyecto=@idProyecto AND fecha_promesa_congelacion IS NULL ORDER BY subensamble ASC";
            ConstruirQuery(sql);
            AgregarParametro("@idProyecto", idProyecto);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

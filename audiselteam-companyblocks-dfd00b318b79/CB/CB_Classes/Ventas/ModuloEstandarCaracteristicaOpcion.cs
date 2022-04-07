using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes 
{
    class ModuloEstandarCaracteristicaOpcion : ModeloMySql
    {
        public ModuloEstandarCaracteristicaOpcion()
        {
            Tabla = "modulos_estandar_caracteristicas_opciones";
        }

        static public ModuloEstandarCaracteristicaOpcion Modelo()
        {
            return new ModuloEstandarCaracteristicaOpcion();
        }

        public List<Fila> ObteberCostoPromedio(string caracteristica, string opcion)
        {
            string query = "SELECT AVG(costo) as costo_promedio FROM " + Tabla + " WHERE caracteristica=@caracteristica and opcion=@opcion";
            ConstruirQuery(query);
            AgregarParametro("@idCaracteristica", caracteristica);
            AgregarParametro("@idOpcion", opcion);
            EjecutarQuery();
            return LeerFilas();
        }

         public List<Fila> SeleccionarDeModuloYCotizacion(int idCotizacion, int idModulo)
        {
            string query = "SELECT modulos_estandar_caracteristicas_opciones.id, modulos_estandar_caracteristicas_opciones.caracteristica as nombre_caracteristica, modulos_estandar_caracteristicas_opciones.opcion as nombre_opcion ";
            query += "FROM modulos_estandar_caracteristicas_opciones ";
            query += "INNER JOIN modulos_estandar_cotizaciones ON modulos_estandar_cotizaciones.id = modulos_estandar_caracteristicas_opciones.id_modulo_estandar_cotizacion ";
            query += "WHERE modulos_estandar_cotizaciones.id_modulo=@idModulo AND modulos_estandar_cotizaciones.id_cotizacion=@idCotizacion;";
           
            ConstruirQuery(query);
            AgregarParametro("@idCotizacion", idCotizacion);
            AgregarParametro("@idModulo", idModulo);
            EjecutarQuery();

            return LeerFilas();
        }
    }
}

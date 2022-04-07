using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ModuloEstandarCotizacion : ModeloMySql
    {
        public ModuloEstandarCotizacion()
        {
            Tabla = "modulos_estandar_cotizaciones";
        }

        static public ModuloEstandarCotizacion Modelo()
        {
            return new ModuloEstandarCotizacion();
        }

        public List<Fila> SeleccionarCaracteristicaYOpciones(int idModulo, int idCotizacion)
        {
            string query = "select modulos_estandar_caracteristicas_opciones.caracteristica as caracteristica, modulos_estandar_caracteristicas_opciones.opcion as opcion from modulos_estandar_caracteristicas_opciones ";
            query += "INNER JOIN modulos_estandar_cotizaciones on modulos_estandar_cotizaciones.id = modulos_estandar_caracteristicas_opciones.id_modulo_estandar_cotizacion ";
            query += "WHERE modulos_estandar_cotizaciones.id_modulo = @idModulo and modulos_estandar_cotizaciones.id_cotizacion = @idCotizacion;";

            ConstruirQuery(query);
            AgregarParametro("@idModulo", idModulo);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila>SeleccionarModulosDeCotizacion(int idModulo, int idCotizacion)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE id_modulo=@idModulo AND id_cotizacion=@idCotizacion;";
            ConstruirQuery(query);
            AgregarParametro("@idModulo", idModulo);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();

            return LeerFilas();
        }
    }
}

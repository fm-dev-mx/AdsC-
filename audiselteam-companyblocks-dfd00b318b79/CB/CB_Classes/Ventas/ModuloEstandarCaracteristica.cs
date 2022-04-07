using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ModuloEstandarCaracteristica : ModeloMySql
    {
        public ModuloEstandarCaracteristica()
        {
            Tabla = "modulos_estandar_caracteristicas";
        }

        public static ModuloEstandarCaracteristica Modelo()
        {
            return new ModuloEstandarCaracteristica();
        }

        public List<Fila> SeleccionarCaracteristicasDeModulo(int idModulo, int idCotizacion)
        {
            string query = "SELECT * FROM " + Tabla + " ";
            query += "WHERE modulo_id=@idModulo and nombre NOT IN (";
            query += "SELECT caracteristica FROM modulos_estandar_caracteristicas_opciones ";
            query += "INNER JOIN modulos_estandar_cotizaciones ON modulos_estandar_cotizaciones.id = modulos_estandar_caracteristicas_opciones.id_modulo_estandar_cotizacion ";
            query += "WHERE modulos_estandar_cotizaciones.id_cotizacion=@idCotizacion and modulos_estandar_cotizaciones.id_modulo=@idModulo";
            query +=")";
            ConstruirQuery(query);
            AgregarParametro("@idModulo", idModulo);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();

            return LeerFilas();
        }

    }
}

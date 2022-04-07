using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionProcesoManufactura : ModeloMySql
    {
        public CotizacionProcesoManufactura()
        {
            Tabla = "cotizaciones_procesos_manufactura";
        }

        static public CotizacionProcesoManufactura Modelo()
        {
            return new CotizacionProcesoManufactura();
        }

        public List<Fila> SeleccionarProcesosDeProducto(int idProducto, int idCotizacion)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE producto=@producto AND id_cotizacion=@idCotizacion;";
            ConstruirQuery(query);
            AgregarParametro("@producto", idProducto);
            AgregarParametro("@idCotizacion", idCotizacion);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

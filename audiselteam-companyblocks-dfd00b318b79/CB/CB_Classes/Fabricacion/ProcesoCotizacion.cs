using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;

namespace CB_Base.Classes
{
    public class ProcesoCotizacion : ModeloMySql
    {
        public ProcesoCotizacion()
        {
            Tabla = "procesos_cotizaciones";
        }

        static public ProcesoCotizacion Modelo()
        {
            return new ProcesoCotizacion();
        }

        public List<Fila> SeleccionarProveedores(int idProceso)
        {
            string sql = "SELECT procesos_cotizaciones.id AS id_cotizacion, proveedores.id AS id_proveedor, proveedores.nombre AS nombre_proveedor, planos_procesos.proceso AS nombre_proceso FROM procesos_cotizaciones INNER JOIN planos_procesos ON planos_procesos.id = procesos_cotizaciones.proceso INNER JOIN proveedores ON procesos_cotizaciones.proveedor=proveedores.id WHERE procesos_cotizaciones.proceso=@proceso GROUP BY procesos_cotizaciones.proveedor";
            ConstruirQuery(sql);
            AgregarParametro("@proceso", idProceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarOpcionesProveedor(int idProceso, int idProveedor)
        {
            string sql = "SELECT * FROM procesos_cotizaciones WHERE proceso=@proceso AND proveedor=@proveedor";
            ConstruirQuery(sql);
            AgregarParametro("@proceso", idProceso);
            AgregarParametro("@proveedor", idProveedor);
            EjecutarQuery();
            return LeerFilas();
        }


    }
}

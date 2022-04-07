using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class TerminoPagoProveedor : ModeloMySql
    {
        public TerminoPagoProveedor()
        {
            Tabla = "terminos_pago_proveedores";
        }

        static public TerminoPagoProveedor Modelo()
        {
            return new TerminoPagoProveedor();
        }

        public List<Fila> CargarDatosPO(int po, int proveedor)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("po", po);
            parametros.Add("proveedor", proveedor);
            return SeleccionarDatos("po=@po AND proveedor=@proveedor", parametros);
        }

        public List<Fila> SeleccionarPO(int po)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("po", po);
            return SeleccionarDatos("po=@po", parametros);
        }
    }
}

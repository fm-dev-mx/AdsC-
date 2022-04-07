using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class FacturaCompra :ModeloMySql
    {
        public FacturaCompra()
        {
            Tabla = "archivos_facturas_compras";
        }
        static public FacturaCompra Modelo()
        {
            return new FacturaCompra();
        }
        public void SeleccionarFacturaPDF(int idPO)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@po", idPO);
            parametros.Add("@tipo", "PDF");
            SeleccionarDatos("id_requisicion=@po AND tipo=@tipo ", parametros);
        }

        public void SeleccionarFacturaXML(int idPO)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@po", idPO);
            parametros.Add("@tipo", "XML");
            SeleccionarDatos("id_requisicion=@po AND tipo=@tipo ", parametros);
        }
    }
}

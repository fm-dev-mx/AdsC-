using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CB_Base.Classes
{
    class FacturasFabricacion : ModeloMySql 
    {
        public FacturasFabricacion()
        {
            Tabla = "archivos_facturas_fabricacion";
        }

        static public FacturasFabricacion Modelo()
        {
            return new FacturasFabricacion();
        }

        public void SeleccionarFacturaPDF(int idPlano)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", idPlano);
            parametros.Add("@tipo", "PDF");
            SeleccionarDatos("id_plano=@plano AND tipo=@tipo ", parametros);
        }

        public void SeleccionarFacturaXML(int idPlano)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", idPlano);
            parametros.Add("@tipo", "XML");
            SeleccionarDatos("id_plano=@plano AND tipo=@tipo ", parametros);
        }
    }
}

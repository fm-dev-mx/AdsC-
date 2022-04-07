using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CB_Base.Classes
{
    class MaterialStock : ModeloMySql
    {
        public MaterialStock()
        {
            Tabla = "material_stock";
        }

        static public MaterialStock Modelo()
        {
            return new MaterialStock();
        }

        public List<Fila> MaterialAltaStock(string numeroParte)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@numero_parte", numeroParte);
            return SeleccionarDatos("numero_parte=@numero_parte", parametros);
        }
    }


}

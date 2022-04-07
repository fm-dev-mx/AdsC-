using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB
{
    class Mqr : ModeloMySql
    {

        public Mqr()
        {
            Tabla = "mqr";
        }

        static public Mqr Modelo()
        {
            return new Mqr();
        }

        public List<Fila> SeleccionarProveedorOrden(int idProveedor, int idOrden)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proveedor", idProveedor);
            parametros.Add("@orden", idOrden);
            return SeleccionarDatos("proveedor=@proveedor AND orden=@orden", parametros);
        }
    }
}

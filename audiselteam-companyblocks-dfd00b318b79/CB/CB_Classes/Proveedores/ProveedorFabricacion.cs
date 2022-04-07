using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProveedorFabricacion : ModeloMySql
    {

        public ProveedorFabricacion()
        {
            Tabla = "proveedores_fabricacion";
        }

        static public ProveedorFabricacion Modelo()
        {
            return new ProveedorFabricacion();
        }

        public List<Fila> Todos()
        {
            SeleccionarDatos("", null, "proveedor");
            return Filas();
        }
        public bool Existe(int id_proveedor)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proveedor", id_proveedor);
            SeleccionarDatos("proveedor=@proveedor", parametros);
            return TieneFilas();
        }
        public void SeleccionarProveedor(int proveedor)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proveedor", proveedor);
            SeleccionarDatos("proveedor=@proveedor", parametros);
        }
    }
}

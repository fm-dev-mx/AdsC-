using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProveedorContacto : ModeloMySql
    {

        public ProveedorContacto()
        {
            Tabla = "proveedores_contactos";
        }

        public static ProveedorContacto Modelo()
        {
            return new ProveedorContacto();
        }

        public List<Fila> CargarDeProveedor(int idProveedor)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proveedor", idProveedor);
            SeleccionarDatos("proveedor=@proveedor", parametros);
            return Filas();
        }
        public List<Fila> BorrarWeb(int idProveedor)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", "PAGINA");
            parametros.Add("@apellidos", "WEB");
            parametros.Add("@proveedor", idProveedor);

            SeleccionarDatos("nombre=@nombre AND apellidos=@apellidos AND proveedor=@proveedor", parametros);
            return Filas();
        } 
        public bool ExisteCorreo(string correo, int proveedor)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@correo", correo);
            parametros.Add("proveedor", proveedor);
            SeleccionarDatos("correo=@correo AND proveedor=@proveedor", parametros);
            return TieneFilas();
        }

        public bool ExisteProveedorWeb(int proveedor)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre","PAGINA");
            parametros.Add("@proveedor", proveedor);
            parametros.Add("@apellidos", "WEB");
            SeleccionarDatos("nombre=@nombre AND apellidos=@apellidos AND proveedor=@proveedor", parametros);
            return TieneFilas();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class ClienteContacto : ModeloMySql
    {

        public ClienteContacto()
        {
            Tabla = "clientes_contactos";
        }

        static public ClienteContacto Modelo()
        {
            return new ClienteContacto();
        }
        public List<Fila> SeleccionarDeCliente(int idCliente)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@cliente", idCliente);
            SeleccionarDatos("cliente=@cliente", parametros);
            return Filas();
        }

        public bool ExisteCorreo(string correo, int cliente)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@correo", correo);
            parametros.Add("proveedor", cliente);
            SeleccionarDatos("correo=@correo AND cliente=@cliente", parametros);
            return TieneFilas();
        }
    }
}

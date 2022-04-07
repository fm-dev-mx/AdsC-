using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Cliente : ModeloMySql
    {
        public Cliente()
        {
            Tabla = "clientes";
        }

        static public Cliente Modelo()
        {
            return new Cliente();
        }

        public List<Fila> SeleccionarPorNombre(string nombreCliente, string columnas="*")
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombreProveedor", nombreCliente);
            return SeleccionarDatos("nombre=@nombreProveedor", parametros, columnas);
        }

        public List<Fila> Todos()
        {
            //return SeleccionarDatos("", null);
            string sql = "SELECT * FROM " + Tabla + " WHERE id > 0 ORDER BY nombre ASC";

            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Buscar(string filtro)
        {
            string sql = "";

            if (filtro == "")
            {
                sql = "SELECT * FROM " + this.Tabla;
            }
            else
            {
                filtro = "%" + filtro + "%";
                sql = "SELECT * FROM " + this.Tabla + " WHERE nombre LIKE @filtro";
            }

            ConstruirQuery(sql);
            AgregarParametro("@filtro", filtro);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Fabricacion()
        {
            List<Fila> clientes = new List<Fila>();

            ProveedorFabricacion.Modelo().Todos().ForEach(delegate(Fila proveedor)
            {
                int idProveedor = Convert.ToInt32(proveedor.Celda("proveedor"));
                CargarDatos(idProveedor);
                clientes.Add(Fila());
            });

            return clientes;
        }

        public List<Fila> Activos()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@activo", 1);
            return SeleccionarDatos("activo=@activo", parametros);
        }

        public List<Fila> SeleccionarNombre(string nombre, string abreviacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", nombre);
            parametros.Add("@abreviacion", abreviacion);
            return SeleccionarDatos("nombre=@nombre AND abreviacion=@abreviacion", parametros);
        }

        public bool Existe(string razonSocial)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@razonSocial", razonSocial);
            SeleccionarDatos("razon_social=@razonSocial", parametros);
            return TieneFilas();
        }

        public bool ExisteAbreviacion(string abreviacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@abreviacion", abreviacion);
            SeleccionarDatos("abreviacion=@abreviacion", parametros);
            return TieneFilas();
        }

        public List<Fila> Filtrar(string filtro = "", int  mostrarInactivos = 0)
        {
            filtro = "%" + filtro + "%";
            string sql = "SELECT * FROM " + Tabla + " WHERE (id LIKE @filtro OR nombre LIKE @filtro) AND activo != @mostrarInactivos ORDER BY id ASC";

            ConstruirQuery(sql);
            AgregarParametro("@filtro", filtro);
            AgregarParametro("@mostrarInactivos", mostrarInactivos);
            EjecutarQuery();
            return LeerFilas();
        }
 
        public List<Fila> IndustriasDeCliente(int idCliente)
        {
            string sql = "SELECT * FROM industrias WHERE id in (SELECT industria_id FROM cliente_industrias WHERE cliente_id = @idCliente)";
            ConstruirQuery(sql);

            AgregarParametro("@idCliente", idCliente);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

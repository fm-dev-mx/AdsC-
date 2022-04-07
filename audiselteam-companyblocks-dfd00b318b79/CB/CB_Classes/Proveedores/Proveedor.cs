using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Proveedor : ModeloMySql
    {
        public Proveedor()
        {
            Tabla = "proveedores";    
        }

        static public Proveedor Modelo()
        {
            return new Proveedor();
        }

        public List<Fila> SeleccionarPorNombre(string nombreProveedor, string columnas="*")
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombreProveedor", nombreProveedor);
            return SeleccionarDatos("nombre=@nombreProveedor", parametros, columnas);
        }

        public List<Fila> Todos()
        {
            return SeleccionarDatos("", null);
        }

        public List<Fila> Buscar(string filtro)
        {
            string sql = "";

            if (filtro == "")
            {
                sql = "SELECT * FROM " + this.Tabla + " order by categoria asc, nombre asc";
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
            List<Fila> proveedores= new List<Fila>();

            ProveedorFabricacion.Modelo().Todos().ForEach(delegate(Fila proveedor)
            {
                int idProveedor = Convert.ToInt32(proveedor.Celda("proveedor"));
                CargarDatos(idProveedor);
                proveedores.Add(Fila());
            });

            return proveedores;
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

        public List<Fila> EvaluacionesProveedoresActivos()
        {
            string query = "SELECT evaluaciones_proveedores.id, proveedores.nombre, evaluaciones_proveedores.resultado, proveedores.categoria, evaluaciones_proveedores.fecha ";
            query += "FROM evaluaciones_proveedores ";
            query += "INNER JOIN proveedores ON proveedores.id = evaluaciones_proveedores.proveedor ";
            query += "WHERE proveedores.activo = 1;";

            ConstruirQuery(query);
            EjecutarQuery();

            return LeerFilas();
        }
    }
}
    
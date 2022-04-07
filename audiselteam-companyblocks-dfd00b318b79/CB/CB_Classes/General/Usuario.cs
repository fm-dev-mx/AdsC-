using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Usuario : ModeloMySql
    {
        public Usuario()
        {
            Tabla = "usuarios";
        }

        static public Usuario Modelo()
        {
            return new Usuario();
        }

        public List<Fila> Todos()
        {
            return SeleccionarDatos("");
        }

        public List<Fila> SeleccionarRol(string rol)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rol", rol);
            SeleccionarDatos("rol=@rol", parametros);
            return Filas();
        }

        public List<Fila> SeleccionarRolActivos(string rol)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rol", rol);
            parametros.Add("@activo", "1");
            return SeleccionarDatos("rol=@rol and activo=@activo", parametros);
        }

        public List<Fila> Calidad()
        {
            SeleccionarDatos("rol like '%CALIDAD%' or rol like '%OPERACIONES%' and activo=1", null);
            return Filas();
        }

        public List<Fila> RolActivo(string rol, string rolCompras, string rolLider, string operaciones, string almacen)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rol", rol);
            parametros.Add("@rolCompras", rolCompras);
            parametros.Add("@rolLider", rolLider);
            parametros.Add("@rolOperaciones", operaciones);
            parametros.Add("@rolAlmacen", almacen);
            parametros.Add("@activo", 1);

            SeleccionarDatos("(rol=@rol or rol=@rolCompras or rol=@rolLider or rol=@rolOperaciones or rol=@rolAlmacen) and activo=@activo order by nombre", parametros);
            return Filas();
        }

        public List<Fila> SeleccionarDepartamento(string departamento)
        {
            string sql = "SELECT DISTINCT usuarios.id AS llave, usuarios.*, perfiles_puestos.departamento FROM usuarios INNER JOIN perfiles_puestos ON usuarios.rol=perfiles_puestos.rol WHERE departamento=@departamento and activo=1";
            ConstruirQuery(sql);
            AgregarParametro("@departamento", departamento);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Activos()
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE activo=@activo ORDER BY nombre";
            ConstruirQuery(sql);
            AgregarParametro("@activo", 1);
            EjecutarQuery();
            return LeerFilas();
        }

        public int ValidarCredenciales(string correo, string password)
        {
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@correo", correo);
            parametros.Add("@password", Global.CalcularHashMD5(password) );
            if (SeleccionarDatos("correo=@correo AND password=@password", parametros).Count > 0)
                return Convert.ToInt32( Fila().Celda("id"));
            return 0;
        }

        public bool Existe(string correo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@correo", correo);
            SeleccionarDatos("correo=@correo", parametros);
            return TieneFilas();
        }

        public string NombreCompleto()
        {
            if(TieneFilas())
            {
                return Fila().Celda("nombre").ToString().TrimEnd().TrimStart() + " " + Fila().Celda("paterno").ToString().TrimEnd().TrimStart();
            }
            return "";
        }

        public List<Fila> BuscarPorNombre(string nombre)
        {
            string sql = "select * from audisel.usuarios WHERE concat(nombre, ' ', paterno)  =@nombreCompleto";
            ConstruirQuery(sql);
            AgregarParametro("@nombreCompleto", nombre);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarUsuariosDeNivel(string rol, int nivel)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE rol=@rol and nivel=@nivel and activo=@activo ORDER BY nombre";
            ConstruirQuery(sql);
            AgregarParametro("@activo", 1);
            AgregarParametro("@rol", rol);
            AgregarParametro("@nivel", nivel);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarUsuariosDeRolConAlmacen(string rol, int nivel)
        {
            string condicion = string.Empty;

            if (rol == "COMPRADOR")
                condicion = " WHERE rol IN ('COMPRADOR', 'RESPONSABLE DE ALMACEN') and nivel=@nivel and activo=@activo ORDER BY nombre";
            else
                condicion = " WHERE rol=@rol and nivel=@nivel and activo=@activo ORDER BY nombre";

            string sql = "SELECT * FROM " + Tabla + condicion;
            ConstruirQuery(sql);
            AgregarParametro("@activo", 1);
            AgregarParametro("@rol", rol);
            AgregarParametro("@nivel", 0);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

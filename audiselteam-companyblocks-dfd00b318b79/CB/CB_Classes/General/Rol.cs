using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Rol : ModeloMySql
    {

        public Rol()
        {
            Tabla = "roles";
        }

        static public Rol Modelo()
        {
            return new Rol();
        }

        public List<Fila> SeleccionarRol(string rol)
        {
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@rol", rol);
            return SeleccionarDatos("rol=@rol", parametros);
        }

        public List<Fila> Todos()
        {
            ConstruirQuery("SELECT * FROM " + Tabla + " ORDER BY rol ASC");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Roles()
        {
            ConstruirQuery("SELECT distinct(rol) FROM " + Tabla + " ORDER BY rol ASC");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarLideres(string departamento, bool editar = false)
        {
            string sql = "";

            if(editar)
                sql = "SELECT DISTINCT usuarios.id, perfiles_puestos.departamento, roles.nivel_maximo, usuarios.rol, usuarios.nombre, usuarios.paterno, usuarios.materno FROM roles, usuarios, perfiles_puestos WHERE roles.nivel_maximo = usuarios.nivel and perfiles_puestos.rol=usuarios.rol and usuarios.activo=1 and perfiles_puestos.departamento=@departamento"; // and roles.rol=usuarios.rol COLLATE utf8_spanish_ci";
            else
                sql = "SELECT DISTINCT usuarios.id, perfiles_puestos.departamento, roles.nivel_maximo, usuarios.rol, usuarios.nombre, usuarios.paterno, usuarios.materno FROM roles, usuarios, perfiles_puestos WHERE roles.nivel_maximo = usuarios.nivel and perfiles_puestos.rol=usuarios.rol and usuarios.activo=1 and perfiles_puestos.departamento=@departamento and usuarios.id NOT in(SELECT equipos_trabajo.lider FROM equipos_trabajo)"; //and roles.rol=usuarios.rol COLLATE utf8_spanish_ci
           
            ConstruirQuery(sql);
            AgregarParametro("@departamento", departamento);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

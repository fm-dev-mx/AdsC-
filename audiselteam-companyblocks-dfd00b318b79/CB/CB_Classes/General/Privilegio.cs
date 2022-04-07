using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Privilegio : ModeloMySql
    {

        public Privilegio()
        {
            Tabla = "privilegios";
        }

        static public Privilegio Modelo()
        {
            return new Privilegio();
        }

        public List<Fila> SeleccionarDeRol(string rol)
        {
            string sql = "SELECT privilegios.categoria, privilegios.privilegio FROM roles INNER JOIN roles_privilegios ON roles_privilegios.rol=roles.id INNER JOIN privilegios ON privilegios.id=roles_privilegios.privilegio WHERE roles.rol=@rol ORDER BY privilegios.categoria ASC, privilegios.privilegio ASC";

            ConstruirQuery(sql);
            AgregarParametro("@rol", rol);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarDeCategoria(string categoria)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@categoria", categoria);
            return SeleccionarDatos("categoria=@categoria", parametros);
        }

        public List<Fila> Categorias()
        {
            return SeleccionarDatos("", null, "DISTINCT categoria");
        }

        public void Asignar(string rol, string privilegio)
        {
            string sql = "INSERT INTO roles_privilegios ";

            ConstruirQuery(sql);
            AgregarParametro("@rol", rol);
            EjecutarQuery();
        }

    }
}

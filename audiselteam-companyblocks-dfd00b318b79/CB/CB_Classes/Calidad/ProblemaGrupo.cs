using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class ProblemaGrupo : ModeloMySql
    {

        public ProblemaGrupo()
        {
            Tabla = "problemas_grupos";
        }

        public static ProblemaGrupo Modelo()
        {
            return new ProblemaGrupo();
        }

        public List<Fila> SeleccionarProblema(int problema)
        {
            string sql = "SELECT problemas_grupos.id, problemas_grupos.integrante, usuarios.id AS id_usuario, usuarios.nombre AS nombre_usuario, usuarios.paterno AS paterno_usuario, usuarios.rol AS rol_usuario";
            sql += " FROM problemas_grupos INNER JOIN usuarios ON usuarios.id=problemas_grupos.integrante";
            sql += " WHERE problema=@problema";

            ConstruirQuery(sql);
            AgregarParametro("@problema", problema);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarIntegrante(int problema, int integrante)
        {
            string sql = "SELECT problemas_grupos.id, problemas_grupos.integrante, usuarios.nombre AS nombre_usuario, usuarios.paterno AS paterno_usuario, usuarios.rol AS rol_usuario";
            sql += " FROM problemas_grupos INNER JOIN usuarios ON usuarios.id=problemas_grupos.integrante";
            sql += " WHERE problema=@problema AND integrante=@integrante";

            ConstruirQuery(sql);
            AgregarParametro("@problema", problema);
            AgregarParametro("@integrante", integrante);
            EjecutarQuery();
            return LeerFilas();
        }

    }
}

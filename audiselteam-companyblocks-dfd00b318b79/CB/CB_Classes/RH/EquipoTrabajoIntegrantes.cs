using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class EquipoTrabajoIntegrantes: ModeloMySql
    {
        public EquipoTrabajoIntegrantes()
        {
            Tabla = "equipos_trabajo_integrantes";
        }

        static public EquipoTrabajoIntegrantes Modelo()
        {
            return new EquipoTrabajoIntegrantes();
        }

        public List<Fila> CargarIntegrantesEquipo(string departamento, int liderId)
        {
            string sql = "SELECT DISTINCT usuarios.id, usuarios.nombre, usuarios.paterno, usuarios.materno, usuarios.activo FROM usuarios INNER JOIN perfiles_puestos ON perfiles_puestos.rol=usuarios.rol WHERE perfiles_puestos.departamento=@departamento AND usuarios.activo=1 AND usuarios.id NOT IN(SELECT equipos_trabajo_integrantes.integrante FROM equipos_trabajo_integrantes)";
            ConstruirQuery(sql);
            AgregarParametro("@departamento", departamento);
            AgregarParametro("@id", liderId);
            EjecutarQuery();
            return LeerFilas();
        }



        public List<Fila> CargarEquipo(int equipo)
        {
            string sql = "SELECT usuarios.nombre, usuarios.paterno, usuarios.materno, usuarios.id, equipos_trabajo_integrantes.id as idIntegrantes FROM usuarios inner join equipos_trabajo_integrantes ON usuarios.id=equipos_trabajo_integrantes.integrante where equipos_trabajo_integrantes.equipo=@equipo";
            
            ConstruirQuery(sql);
            AgregarParametro("@equipo", equipo);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarIntegrantes(string departamento)
        {
            string sql = "SELECT DISTINCT usuarios.id, usuarios.nombre, usuarios.paterno, usuarios.materno, usuarios.rol, usuarios.nivel from usuarios, perfiles_puestos where usuarios.rol=perfiles_puestos.rol and perfiles_puestos.departamento=@departamento and usuarios.activo=1 and usuarios.id NOT in(SELECT equipos_trabajo_integrantes.integrante FROM equipos_trabajo_integrantes)";
            ConstruirQuery(sql);
            AgregarParametro("@departamento", departamento);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> BuscarEquipoPorLider(int UsuarioId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", UsuarioId);
            return SeleccionarDatos("integrante=@usuario", parametros);
        }
    }   
}

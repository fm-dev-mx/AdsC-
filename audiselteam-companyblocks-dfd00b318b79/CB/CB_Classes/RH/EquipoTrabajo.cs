using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class EquipoTrabajo : ModeloMySql
    {
        public EquipoTrabajo()
        {
            Tabla = "equipos_trabajo";
        }

        static public EquipoTrabajo Modelo()
        {
            return new EquipoTrabajo();
        }

        public List<Fila> SeleccionarLideres(string departamento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@departamento", departamento);
            return SeleccionarDatos("departamento=@departamento", parametros);
        }

        public List<Fila> CargarEquipos(string departamento, string lider)
        {
            string query = "";

            if(departamento == "TODOS" && lider == "TODOS")
                query = "SELECT equipos_trabajo.id, equipos_trabajo.departamento, usuarios.nombre, usuarios.paterno, usuarios.materno FROM equipos_trabajo, usuarios where equipos_trabajo.lider=usuarios.id Group by equipos_trabajo.id";
            else if (departamento != "TODOS" && lider == "TODOS")
                query = "SELECT equipos_trabajo.id, equipos_trabajo.departamento, usuarios.nombre, usuarios.paterno, usuarios.materno FROM equipos_trabajo, usuarios WHERE equipos_trabajo.lider=usuarios.id and equipos_trabajo.departamento=@departamento";
            else if (departamento != "TODOS" && lider != "TODOS")
                query = "SELECT equipos_trabajo.id, equipos_trabajo.departamento, usuarios.nombre, usuarios.paterno, usuarios.materno FROM equipos_trabajo, usuarios WHERE equipos_trabajo.lider=usuarios.id and equipos_trabajo.departamento=@departamento and lider=@lider";
            else if (departamento == "TODOS" && lider != "TODOS")
                query = "SELECT equipos_trabajo.id, equipos_trabajo.departamento, usuarios.nombre, usuarios.paterno, usuarios.materno FROM equipos_trabajo, usuarios WHERE equipos_trabajo.lider=usuarios.id and equipos_trabajo.lider=@lider";

            ConstruirQuery(query);
            AgregarParametro("@departamento", departamento);
            AgregarParametro("@lider", lider);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> BuscarEquipoPorLider(int UsuarioId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", UsuarioId);
            return SeleccionarDatos("lider=@usuario", parametros);
        }

    }
}

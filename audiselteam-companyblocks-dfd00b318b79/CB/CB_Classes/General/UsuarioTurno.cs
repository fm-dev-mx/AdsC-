using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class UsuarioTurno : ModeloMySql
    {
        public UsuarioTurno()
        {
            Tabla = "usuarios_turnos";
        }

        static public UsuarioTurno Modelo()
        {
            return new UsuarioTurno();
        }

        public List<Fila> CargarHorarioLaboral(int usuario)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE usuario=@usuario";

            ConstruirQuery(sql);
            AgregarParametro("@usuario", usuario);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

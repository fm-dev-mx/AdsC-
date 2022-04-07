using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class JuntaInvitado : ModeloMySql
    {
        public JuntaInvitado()
        {
            Tabla = "juntas_invitados";
        }

        static public JuntaInvitado Modelo()
        {
            return new JuntaInvitado();
        }

        public List<Fila> SeleccionaInvitado(int idEvento)
        {
            string sql = "SELECT nombre, paterno, materno FROM usuarios INNER JOIN juntas_invitados ON usuarios.id=juntas_invitados.usuario  WHERE evento=@evento";
            ConstruirQuery(sql);

            AgregarParametro("@evento", idEvento);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> BuscarInvitados(int idEvento)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE evento=@idEvento";
            ConstruirQuery(sql);
            AgregarParametro("@idEvento", idEvento);

            EjecutarQuery();
            return LeerFilas();
        }
    }
}

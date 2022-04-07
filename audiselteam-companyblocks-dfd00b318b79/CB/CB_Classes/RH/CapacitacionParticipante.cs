using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CapacitacionParticipante : ModeloMySql
    {
        public CapacitacionParticipante()
        {
            Tabla = "capacitaciones_participantes";
        }

        static public CapacitacionParticipante Modelo()
        {
            return new CapacitacionParticipante();
        }

        public List<Fila> BuscarInvitados(int capacitacion)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE capacitacion=@capacitacion";
            ConstruirQuery(sql);
            AgregarParametro("@capacitacion", capacitacion);

            EjecutarQuery();
            return LeerFilas();
        }
    }
}

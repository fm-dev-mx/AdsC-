using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Problema : ModeloMySql
    {
        public Problema()
        {
            Tabla = "problemas";
        }

        public static Problema Modelo()
        {
            return new Problema();
        }

        public List<Fila> SeleccionarTicketServicio(int idTicketServicio)
        {
            ConstruirQuery("SELECT * FROM " + Tabla + " WHERE ticket_servicio=@ticket_servicio");
            AgregarParametro("@ticket_servicio", idTicketServicio);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

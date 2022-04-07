using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TicketServicio : ModeloMySql
    {

        public TicketServicio()
        {
            Tabla = "tickets_servicio";
        }

        static public TicketServicio Modelo()
        {
            return new TicketServicio();
        }

        public List<Fila> SeleccionarTipoEstatus(string tipo, string estatus, string parteInteresada="EXTERNA")
        {
            string sql = "SELECT * FROM tickets_servicio WHERE parte_interesada=@parte_interesada";

            if (tipo != "TODOS")
                sql += " AND tipo=@tipo";

            if (estatus != "TODOS")
                sql += " AND estatus=@estatus";

            ConstruirQuery(sql);
            AgregarParametro("@tipo", tipo);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@parte_interesada", parteInteresada);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarNoConformidad(int idNoConformidad)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE no_conformidad=@noConformidad";
            ConstruirQuery(sql);
            AgregarParametro("@noConformidad", idNoConformidad);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

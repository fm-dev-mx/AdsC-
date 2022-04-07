using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class TerminoPagoCliente : ModeloMySql
    {
        public TerminoPagoCliente()
        {
            Tabla = "terminos_pago_cliente";
        }

        static public TerminoPagoCliente Modelo()
        {
            return new TerminoPagoCliente();
        }

        public List<Fila> CargarDatosProyecto(string idProyecto, int idCliente)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", idProyecto);
            parametros.Add("@cliente", idCliente);
            return SeleccionarDatos("proyecto=@proyecto AND cliente=@cliente", parametros);
        }

        public List<Fila> SeleccionarCliente(int cliente)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("cliente", cliente);
            return SeleccionarDatos("cliente=@cliente", parametros);
        }
    }
}

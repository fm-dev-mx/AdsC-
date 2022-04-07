using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class JuntaEvento : ModeloMySql
    {
        public JuntaEvento()
        {
            Tabla = "juntas_eventos";
        }

        static public JuntaEvento Modelo()
        {
            return new JuntaEvento();
        }

        public List<Fila> SeleccionarFecha(DateTime fecha, string tipo="TODOS")
        {
            string sql = "SELECT * FROM juntas_eventos WHERE DATE(fecha)=@fecha";

            if(tipo != "TODOS")
                sql += " AND tipo=@tipo";

            ConstruirQuery(sql);
            AgregarParametro("@fecha", fecha.Date);
            AgregarParametro("@tipo", tipo);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRangoFecha(DateTime fechaInicio, DateTime fechaFin, string tipo = "TODOS")
        {
            string sql = "SELECT * FROM juntas_eventos WHERE (DATE(fecha)>=@fechaInicio AND DATE(fecha)<=@fechaFin)";

            if (tipo != "TODOS")
                sql += " AND tipo=@tipo";

            ConstruirQuery(sql);
            AgregarParametro("@fechaInicio", fechaInicio.Date);
            AgregarParametro("@fechaFin", fechaFin.Date);
            AgregarParametro("@tipo", tipo);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Tipos()
        {
            ConstruirQuery("SELECT DISTINCT tipo FROM juntas_eventos ");
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

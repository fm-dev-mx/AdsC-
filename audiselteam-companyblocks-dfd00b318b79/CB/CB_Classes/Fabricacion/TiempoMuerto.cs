using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TiempoMuerto : ModeloMySql
    {
        public TiempoMuerto()
        {
            Tabla = "tiempo_muerto";
        }

        static public TiempoMuerto Modelo()
        {
            return new TiempoMuerto();
        }

        public List<Fila> CambiarEstadoTiempoMuerto(int idProceso)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE proceso=@idProceso and estatus=@estatus";

            ConstruirQuery(sql);
            AgregarParametro("@idProceso", idProceso);
            AgregarParametro("@estatus", "ACTIVO");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarTiempoMuerto(int idProceso)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE proceso=@idProceso";

            ConstruirQuery(sql);
            AgregarParametro("@idProceso", idProceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CalcularTiempoMuerto(int idProceso)
        {
            
            string sql = "SELECT fin, inicio, razon FROM audisel.tiempo_muerto where proceso=@idProceso and razon!=@razon"; 

            //donde razon != hora salida
            //agarra las horas de salida inicio y fin  y restarlas al tiempo muerto y tiempo de produccion
            ConstruirQuery(sql);
            AgregarParametro("@idProceso", idProceso);
            AgregarParametro("@razon", 9);
            AgregarParametro("@estatus", "ACTIVO");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarTiempoMuertoFechaEspecifica(int proceso, DateTime fechaDesde, DateTime fechaHasta)
        {
            string sql = string.Empty;
            sql = "SELECT * FROM " + Tabla + " WHERE (date(inicio) between @desde and @hasta) and proceso=@proceso";

            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            AgregarParametro("@desde", fechaDesde);
            AgregarParametro("@hasta", fechaHasta);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProcesosNoCerrados(int idProceso, string estatus)
        {
            string sql = "SELECT * " + Tabla + " where proceso=@idProceso and estatus=@estatus";

            ConstruirQuery(sql);
            AgregarParametro("@idProceso", idProceso);
            AgregarParametro("@estatus", estatus);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

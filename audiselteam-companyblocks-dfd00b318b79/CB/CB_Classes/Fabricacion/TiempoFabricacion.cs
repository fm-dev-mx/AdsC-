using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TiempoFabricacion : ModeloMySql
    {
        public TiempoFabricacion()
        {
            Tabla = "tiempos_fabricacion";
        }

        static public TiempoFabricacion Modelo()
        {
            return new TiempoFabricacion();
        }

        public List<Fila> CargarFechaParo(int proceso)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE proceso=@proceso and fecha_paro is @null";

            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            AgregarParametro("@null", null);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarTiempoFabricacion(int proceso)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE proceso=@proceso ";

            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarTiempoMuertoFechaEspecifica(int proceso)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE proceso=@proceso and date(fecha_inicio)=curdate() and date(fecha_paro)=curdate()";

            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarFechaInicio(int proceso, DateTime fechaInicio, DateTime fechaFin)
        {
           // string sql = "SELECT * FROM " + Tabla + " WHERE proceso=@proceso and date(fecha_inicio)=curdate() order by fecha_inicio limit 1";
            string sql = "SELECT * FROM " + Tabla + " WHERE proceso=@proceso and date(fecha_inicio) between @fechaInicio and @fechaFin";

            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            AgregarParametro("@fechaInicio", fechaInicio);
            AgregarParametro("@fechaFin", fechaFin);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

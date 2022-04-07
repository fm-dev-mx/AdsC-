using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class IndicadorProceso : ModeloMySql
    {
        public IndicadorProceso()
        {
            Tabla = "indicadores_procesos";
        }

        static public IndicadorProceso Modelo()
        {
            return new IndicadorProceso();
        }

        public List<Fila> CargarProcesos()
        {
            ConstruirQuery("SELECT DISTINCT proceso AS id_proceso, procesos.* FROM " + Tabla + " INNER JOIN procesos ON procesos.id=indicadores_procesos.proceso");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarIndicadores()
        {
            ConstruirQuery("SELECT DISTINCT nombre FROM " + Tabla);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarNombre(int proceso, string nombre)
        {
            ConstruirQuery("SELECT * FROM " + Tabla + " WHERE proceso=@proceso AND nombre=@nombre");
            AgregarParametro("@proceso", proceso);
            AgregarParametro("@nombre", nombre);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarIndicadoresDelProceso(int proceso)
        {
            ConstruirQuery("SELECT * FROM " + Tabla + " WHERE proceso=@proceso");
            AgregarParametro("@proceso", proceso);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Proceso : ModeloMySql
    {
        public Proceso()
        {
            Tabla = "procesos";
        }

        static public Proceso Modelo()
        {
            return new Proceso();
        }

        public List<Fila> SeleccionarNombre(string nombreProceso)
        {
            ConstruirQuery("SELECT * FROM " + Tabla + " WHERE nombre=@nombreProceso");
            AgregarParametro("@nombreProceso", nombreProceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Todos()
        {
            return SeleccionarDatos("");
        }

        public List<Fila> SeleccionarProcesosEnformato(int formatoIngles = 1)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE ingles=@formato order by nombre asc";
            ConstruirQuery(query);
            AgregarParametro("@formato", formatoIngles);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

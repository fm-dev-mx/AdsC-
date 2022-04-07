using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ProcesoFabricacion : ModeloMySql
    {
        public ProcesoFabricacion()
        {
            Tabla = "procesos_fabricacion";
        }

        static public ProcesoFabricacion Modelo()
        {
            return new ProcesoFabricacion();
        }

        public List<Fila> Categorias()
        {
            return SeleccionarDatos("", null, "DISTINCT categoria");
        }

        public List<Fila> DeCategoria(string categoria)
        {
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@categoria", categoria);
            return SeleccionarDatos("categoria=@categoria", parametros); 
        }

        public string BuscarCategoria(string proceso)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", proceso);
            SeleccionarDatos("nombre=@nombre", parametros, "categoria");

            if (TieneFilas())
            {
                return Fila().Celda("categoria").ToString();
            }
            else return "";
        }

        public List<Fila> BuscarProceso(string nombre)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", nombre);
            return SeleccionarDatos("nombre=@nombre", parametros);
        }

        public List<Fila> CargarProcesosDeFabricacion()
        {
            string query = "SELECT DISTINCT categoria FROM " + Tabla + " WHERE categoria not in ('INSPECCION')";
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

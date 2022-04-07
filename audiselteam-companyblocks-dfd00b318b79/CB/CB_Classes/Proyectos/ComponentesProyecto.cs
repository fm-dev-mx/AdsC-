using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ComponentesProyecto : ModeloMySql
    {
        public ComponentesProyecto()
        {
            Tabla = "componente_proyecto";
        }

        static public ComponentesProyecto Modelo()
        {
            return new ComponentesProyecto();
        }
        public List<Fila> Filtrar(decimal proyecto,string filtro = "")
        {
            filtro = "%" + filtro + "%";
            string sql = "SELECT * FROM " + Tabla + " WHERE proyecto=@proyecto AND (id LIKE @filtro OR nombre LIKE @filtro) ORDER BY id ASC";

            ConstruirQuery(sql);
            AgregarParametro("@filtro", filtro);
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarComponentes(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            SeleccionarDatos("proyecto=@proyecto", parametros);
            return Filas();
        }
    }
}

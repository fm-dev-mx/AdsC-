using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Bug : ModeloMySql
    {
        public Bug()
        {
            Tabla = "bugs";
        }

        public static Bug Modelo()
        {
            return new Bug();
        }

        public List<Fila> SeleccionarProyecto(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            return SeleccionarDatos("proyecto=@proyecto", parametros);
        }

        public List<Fila> Filtrar(decimal proyecto, string categoria = "TODOS", string estatus = "TODOS", string origen = "TODOS")
        {
            string filtroCategoria = "";
            if (categoria != "TODOS")
                filtroCategoria = " AND categoria=@categoria";

            string filtroEstatus = "";
            if (estatus != "TODOS")
                filtroEstatus = " AND estatus=@estatus";

            string filtroOrigen = "";
            if (origen != "TODOS")
                filtroOrigen = " AND origen=@origen";


            string sql = "SELECT * FROM " + Tabla + " WHERE proyecto=@proyecto" + filtroCategoria + filtroEstatus + filtroOrigen;
            ConstruirQuery(sql);

            AgregarParametro("@categoria", categoria);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@origen", origen);
            AgregarParametro("@proyecto", proyecto);

            EjecutarQuery();
            return LeerFilas();
        }

    }
}

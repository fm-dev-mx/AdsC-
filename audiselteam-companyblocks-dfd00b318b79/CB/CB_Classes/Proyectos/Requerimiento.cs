using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Requerimiento : ModeloMySql
    {

        public Requerimiento()
        {
            Tabla = "requerimientos";
        }

        static public Requerimiento Modelo()
        {
            return new Requerimiento();
        }

        public List<Fila> SeleccionarProyecto(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            return SeleccionarDatos("proyecto=@proyecto", parametros);
        }

        public List<Fila> FiltrarOficiales(decimal proyecto, string estatus="TODOS", string tipo="TODOS", string origen="TODOS", string nivelRevision="TODOS")
        {
            string filtroEstatus = " AND estatus!='SOLICITUD' AND estatus!='RECHAZADO'";
            if (estatus != "TODOS")
                filtroEstatus = " AND estatus=@estatus";

            string filtroOrigen = "";
            if(origen != "TODOS")
                filtroOrigen = " AND origen=@origen";
            
            string filtroNivelRevision = "";
            if(nivelRevision != "TODOS")
                filtroNivelRevision = " AND nivel_revision=@nivel_revision";

            string sql = "SELECT * FROM " + Tabla + " WHERE proyecto=@proyecto" + filtroEstatus + filtroOrigen + filtroNivelRevision;
            ConstruirQuery(sql);

            AgregarParametro("@categoria", estatus);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@origen", origen);
            AgregarParametro("@nivel_revision", nivelRevision);
            AgregarParametro("@proyecto", proyecto);

            EjecutarQuery();
            return LeerFilas();
        }
    }
}

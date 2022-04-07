using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class NoConformidad : ModeloMySql
    {
        public NoConformidad()
        {
            Tabla = "no_conformidades";
        }

        static public NoConformidad Modelo()
        {
            return new NoConformidad();
        }

        public List<Fila> SeleccionarNoConformidad(int plano, int proceso)
        {
            string condition = string.Empty;

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", plano);
            parametros.Add("@proceso", proceso);
            return SeleccionarDatos("plano=@plano and proceso_fabricacion=@proceso order by id desc", parametros);
        }

        public List<Fila> SeleccionarPlano(int plano, string tipo="INTERNA")
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", plano);
            parametros.Add("@tipo", tipo);
            return SeleccionarDatos("plano=@plano AND tipo=@tipo ORDER BY id DESC", parametros);
        }

        public List<Fila> SeleccionarTipo(string tipo, string estatusAnalisis="TODOS")
        {
            string query = "SELECT no_conformidades.*";

            switch (tipo)
            {
                case "CLIENTE":
                    query += ", tickets_servicio.proyecto, tickets_servicio.contacto, proyectos.id AS id_proyecto, proyectos.nombre AS nombre_proyecto, clientes_contactos.nombre AS nombre_contacto, clientes_contactos.apellidos AS apellidos_contacto";
                    query += " FROM no_conformidades";
                    query += " INNER JOIN tickets_servicio ON tickets_servicio.no_conformidad=no_conformidades.id";
                    query += " INNER JOIN proyectos ON tickets_servicio.proyecto=proyectos.id";
                    query += " INNER JOIN clientes_contactos ON proyectos.contacto=clientes_contactos.id";
                    break;
            }

            query += " WHERE no_conformidades.tipo=@tipo";

            if (estatusAnalisis != "TODOS")
                query += " AND estatus_analisis=@estatus_analisis";

            query += " ORDER BY id DESC";

            ConstruirQuery(query);
            AgregarParametro("@tipo", tipo);
            AgregarParametro("@estatus_analisis", estatusAnalisis);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarPlanoDistinto(string estatus, string tipo, string procesoOrigen="TODOS", string estatusAnalisis="TODOS")
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", estatus);
            parametros.Add("@tipo", tipo);
            parametros.Add("@estatus_analisis", estatusAnalisis);
            parametros.Add("@procesoOrigen", procesoOrigen);
            
            string query = "estatus=@estatus AND tipo=@tipo";

            if (estatusAnalisis != "TODOS")
                query += " AND estatus_analisis=@estatus_analisis";

            if(procesoOrigen != "TODOS")
            {
                query += " AND proceso_origen=@procesoOrigen";

                if(procesoOrigen == "FABRICACION")
                    query +=  " GROUP BY plano";
            }
            
            query += " ORDER BY id DESC";
            return SeleccionarDatos(query, parametros); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Encuesta : ModeloMySql
    {
        public Encuesta()
        {
            Tabla = "encuestas";
        }

        static public Encuesta Modelo()
        {
            return new Encuesta();
        }

        public List<Fila> SeleccionarEncuesta(string plantilla, string estatus, string idUsuario, BackgroundWorker bkg = null)
        {
            string condicion = "";

            if (plantilla != "" && plantilla != "TODOS")
                condicion = "encuestas.plantilla=@plantilla";

          /*  if (estatus != "" && estatus != "TODOS")
            {
                if (condicion != "")
                    condicion += " and ";

                condicion += "encuestas.estatus=@estatus";
            }*/

            if (idUsuario != "" && idUsuario != "TODOS")
            {
                if (condicion != "")
                    condicion += " and ";

                condicion += "encuestas.usuario_encuestado=@usuarioEncuestado";
            }
                

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", estatus);
            parametros.Add("@plantilla", plantilla);
            parametros.Add("@usuarioEncuestado", idUsuario);

            string columnas = "encuestas.*, (SELECT nombre from usuarios where encuestas.usuario_encuestado=usuarios.id) as encuestadoNombre";
            columnas += ", (SELECT paterno from usuarios where encuestas.usuario_encuestado=usuarios.id) as encuestadoPaterno";
            columnas += ", (SELECT nombre from usuarios where encuestas.usuario_creacion=usuarios.id) as nombreCreador";
            columnas += ", (SELECT paterno from usuarios where encuestas.usuario_creacion=usuarios.id) as paternoCreador";
            columnas += ", (SELECT nombre from plantillas_encuestas where encuestas.plantilla=plantillas_encuestas.id) as nombreEncuesta";
            return SeleccionarDatos(condicion, parametros, columnas, bkg);
        }

    }
}

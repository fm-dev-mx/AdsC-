using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TareaInvolucrados: ModeloMySql
    {
        public TareaInvolucrados()
        {
            Tabla = "tareas_involucrados";
        }

        static public TareaInvolucrados Modelo()
        {
            return new TareaInvolucrados();
        }

        public List<Fila> SeleccionarTarea(int idTarea)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE tarea=@tarea";
            ConstruirQuery(sql);
            AgregarParametro("@tarea", idTarea);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarInvolucradosDeTarea(int idTarea, string nombre)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE tarea=@tarea AND nombre_usuario in ('" + nombre + "')";
            ConstruirQuery(sql);
            AgregarParametro("@tarea", idTarea);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

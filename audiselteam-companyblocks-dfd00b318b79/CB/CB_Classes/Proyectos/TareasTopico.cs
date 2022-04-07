using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CB_Base.Classes
{
    class TareasTopico : ModeloMySql
    {
        public TareasTopico()
        {
            Tabla = "tareas_topicos";
        }

        static public TareasTopico Modelo()
        {
            return new TareasTopico();
        }

        public List<Fila> SeleccionarRangoFecha(string estatus, string desde, string hasta, string idTopico)
        {
            string sql = string.Empty;
            if(estatus !=  "TODOS")
                sql = "SELECT * FROM " + Tabla + " where topico=@topico and estatus=@estatus order by fecha_promesa desc";
            else
                sql = "SELECT * FROM " + Tabla + " where topico=@topico order by fecha_promesa desc";
            ConstruirQuery(sql);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@topico", idTopico);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarTareasAccionesIndicadores(int IdIndicador)
        {
            string sql = "SELECT * FROM " + Tabla + " where topico=@topico and tarea_principal=@indicador";
            ConstruirQuery(sql);
            AgregarParametro("@indicador", IdIndicador);
            AgregarParametro("@topico", 0);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> TareasTerminadasEnElMes(int idUsuario)
        {
            string query = string.Empty;
            query = "SELECT * FROM tareas_topicos WHERE MONTH(fecha_tarea_terminada) = MONTh(current_date()) ";
            query += "AND id IN(select tarea from tareas_responsables where id_responsable = @idUsuario);";

            ConstruirQuery(query);
            AgregarParametro("@idUsuario", idUsuario);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> TareasTerminadasEnLaSemana(int idUsuario)
        {
            string query = string.Empty;
            query = "SELECT * FROM tareas_topicos WHERE WEEK(fecha_tarea_terminada) = WEEK(current_date()) ";
            query += "AND id IN(select tarea from tareas_responsables where id_responsable = @idUsuario);";

            ConstruirQuery(query);
            AgregarParametro("@idUsuario", idUsuario);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> TareasTerminadasEnMesConEstatus(int idUsuario, string estatus)
        {
            string query = string.Empty;
            query = "SELECT * FROM tareas_topicos WHERE WEEK(fecha_tarea_terminada) = WEEK(current_date()) ";
            query += "AND id IN(select tarea from tareas_responsables where id_responsable = @idUsuario) ";
            query += "AND estatus_tiempo =@estatus ;";

            ConstruirQuery(query);
            AgregarParametro("@idUsuario", idUsuario);
            AgregarParametro("@estatus", estatus);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

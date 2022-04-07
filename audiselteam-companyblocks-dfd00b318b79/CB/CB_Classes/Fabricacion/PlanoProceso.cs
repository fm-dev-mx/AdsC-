using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PlanoProceso : ModeloMySql
    {
        public PlanoProceso()
        {
            Tabla = "planos_procesos";
        }

        static public PlanoProceso Modelo()
        {
            return new PlanoProceso();
        }

        public List<Fila> CargarDePlano(int idPlano)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE plano=@plano ORDER BY orden ASC";
            ConstruirQuery(sql);
            AgregarParametro("@plano", idPlano);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarProcesoAnterior(int idPlano, int idProceso=0)
        {
            string condicion = "";
            if (idProceso != 0)
                condicion = "AND id!=@id";
            string sql = "SELECT * FROM " + Tabla + " WHERE plano=@plano " + condicion + " ORDER BY proceso_anterior ASC";
            ConstruirQuery(sql);
            AgregarParametro("@id", idProceso);
            AgregarParametro("@plano", idPlano);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> nuevoprocesoAnterior(int idPlano, int procesoActual, int procesoAnterior)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE plano=@plano AND id!=@procesoActual AND id!=@procesoAnterior";
            ConstruirQuery(sql);
            AgregarParametro("@plano", idPlano);
            AgregarParametro("@procesoActual", procesoActual);
            AgregarParametro("@procesoAnterior", procesoAnterior);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ProcesosConEstatus(int idPlano, string estatus)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE plano=@idPlano AND estatus in (" + estatus + ")";
            ConstruirQuery(sql);
            AgregarParametro("@idPlano", idPlano);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarProceso(int idProceso)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE id=@id";
            ConstruirQuery(sql);
            AgregarParametro("@id", idProceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> PoblarProduccion(string NombreHerramentista, string fecha, string columnas, BackgroundWorker Bkg = null)
        {
            string query = "";
            if (columnas == "TODOS")
                query = "SELECT count(planos_procesos.id) as total FROM planos_procesos INNER JOIN planos_proyectos INNER JOIN archivos_planos ON planos_procesos.estatus=@estatus AND date(planos_procesos.fecha_termino)=@fechaTermino AND planos_procesos.plano=archivos_planos.plano AND planos_proyectos.id=planos_procesos.plano order by proyecto";
            else
                query = "SELECT count(planos_procesos.id)as total FROM planos_procesos INNER JOIN planos_proyectos INNER JOIN archivos_planos ON planos_procesos.estatus=@estatus AND planos_procesos.operador=@operador AND date(planos_procesos.fecha_termino)=@fechaTermino AND planos_procesos.plano=archivos_planos.plano AND planos_proyectos.id=planos_procesos.plano";

            ConstruirQuery(query);
            AgregarParametro("@estatus", "TERMINADO");
            AgregarParametro("@operador", NombreHerramentista);
            AgregarParametro("@fechaTermino", fecha);
            EjecutarQuery();
            int total = 0;

            LeerFilas().ForEach(delegate(Fila f)
            {
                total  = Convert.ToInt32(f.Celda("total"));
            });

            string sql = "";
            if (columnas == "TODOS")
                sql = "SELECT distinct(planos_procesos.id), planos_proyectos.nombre_archivo as archivo, planos_procesos.operador as herramentista, planos_procesos.proceso as proceso, planos_procesos.fecha_inicio as fechaInicio, planos_procesos.fecha_termino as fechaFin, archivos_planos.miniatura, planos_proyectos.proyecto as proyecto, archivos_planos.archivo as plano FROM planos_procesos INNER JOIN planos_proyectos INNER JOIN archivos_planos ON planos_procesos.estatus=@estatus AND date(planos_procesos.fecha_termino)=@fechaTermino AND planos_procesos.plano=archivos_planos.plano AND planos_proyectos.id=planos_procesos.plano order by proyecto";
            else
                sql = "SELECT distinct(planos_procesos.id), planos_proyectos.nombre_archivo as archivo, planos_procesos.operador as herramentista, planos_procesos.proceso as proceso, planos_procesos.fecha_inicio as fechaInicio, planos_procesos.fecha_termino as fechaFin, archivos_planos.miniatura, planos_proyectos.proyecto as proyecto, archivos_planos.archivo as plano FROM planos_procesos INNER JOIN planos_proyectos INNER JOIN archivos_planos ON planos_procesos.estatus=@estatus AND planos_procesos.operador=@operador AND date(planos_procesos.fecha_termino)=@fechaTermino AND planos_procesos.plano=archivos_planos.plano AND planos_proyectos.id=planos_procesos.plano";
            
            ConstruirQuery(sql);
            AgregarParametro("@estatus", "TERMINADO");
            AgregarParametro("@operador", NombreHerramentista);
            AgregarParametro("@fechaTermino", fecha);
            EjecutarQuery();
            
            return LeerFilas(Bkg,total);
        }

        public List<Fila> PiezasTerminadas(string fecha, BackgroundWorker Bkg = null)
        {
            string query = "SELECT count(planos_proyectos.id) as total FROM planos_proyectos INNER JOIN archivos_planos ON planos_proyectos.estatus=@estatus AND planos_proyectos.id=archivos_planos.plano AND date(planos_proyectos.fecha_terminado)=@fechaFin";

            ConstruirQuery(query);
            AgregarParametro("@estatus", "TERMINADO");
            AgregarParametro("@fechaFin", fecha);
            EjecutarQuery();
            int total = 0;

            LeerFilas().ForEach(delegate(Fila f)
            {
                total = Convert.ToInt32(f.Celda("total"));
            });

            string sql = "SELECT distinct(planos_proyectos.id), planos_proyectos.nombre_archivo as archivo, planos_proyectos.fecha_creacion as fechaInicio, planos_proyectos.fecha_terminado as fechaFin, archivos_planos.miniatura, planos_proyectos.proyecto as proyecto, planos_proyectos.cantidad as cantidad, archivos_planos.archivo as plano FROM planos_proyectos INNER JOIN archivos_planos ON planos_proyectos.estatus=@estatus AND planos_proyectos.id=archivos_planos.plano AND date(planos_proyectos.fecha_terminado)=@fechaFin";
            ConstruirQuery(sql);
            AgregarParametro("@estatus", "TERMINADO");
            AgregarParametro("@fechaFin", fecha);
            EjecutarQuery();
            return LeerFilas(Bkg, total);
        }

        public List<Fila> PiezasEntregadas(string fecha, BackgroundWorker Bkg = null)
        {
            string query = "SELECT count(planos_proyectos.id) as total FROM planos_proyectos INNER JOIN archivos_planos ON planos_proyectos.estatus=@estatus AND planos_proyectos.id=archivos_planos.plano AND date(planos_proyectos.fecha_terminado)=@fechaFin";
            ConstruirQuery(query);
            AgregarParametro("@estatus", "ENTREGADO");
            AgregarParametro("@fechaFin", fecha);
            EjecutarQuery();
            int total = 0;

            LeerFilas().ForEach(delegate(Fila f)
            {
                total = Convert.ToInt32(f.Celda("total"));
            });

            string sql = "SELECT distinct(planos_proyectos.id), planos_proyectos.nombre_archivo as archivo, planos_proyectos.fecha_creacion as fechaInicio, planos_proyectos.fecha_terminado as fechaFin, archivos_planos.miniatura, planos_proyectos.proyecto as proyecto, planos_proyectos.cantidad as cantidad, archivos_planos.archivo as plano FROM planos_proyectos INNER JOIN archivos_planos ON planos_proyectos.estatus=@estatus AND planos_proyectos.id=archivos_planos.plano AND date(planos_proyectos.fecha_terminado)=@fechaFin";
            ConstruirQuery(sql);
            AgregarParametro("@estatus", "ENTREGADO");
            AgregarParametro("@fechaFin", fecha);
            EjecutarQuery();
            return LeerFilas(Bkg, total);
        }

        public List<Fila> ProduccionEnProceso(string fecha, BackgroundWorker Bkg = null)
        {
            string query = "SELECT count(planos_procesos.id)as total FROM planos_procesos INNER JOIN planos_proyectos INNER JOIN archivos_planos ON planos_procesos.estatus=@estatus AND date(planos_procesos.fecha_inicio)=@fechaTermino AND planos_procesos.plano=archivos_planos.plano AND planos_proyectos.id=planos_procesos.plano";

            ConstruirQuery(query);
            AgregarParametro("@estatus", "EN PROCESO");
            AgregarParametro("@fechaTermino", fecha);
            EjecutarQuery();
            int total = 0;

            LeerFilas().ForEach(delegate(Fila f)
            {
                total = Convert.ToInt32(f.Celda("total"));
            });

            string sql = "SELECT distinct(planos_procesos.id), planos_proyectos.nombre_archivo as archivo, planos_procesos.operador as herramentista, planos_procesos.proceso as proceso, planos_procesos.fecha_inicio as fechaInicio, planos_procesos.fecha_termino as fechaFin, archivos_planos.miniatura, planos_proyectos.proyecto as proyecto, archivos_planos.archivo as plano FROM planos_procesos INNER JOIN planos_proyectos INNER JOIN archivos_planos ON planos_procesos.estatus=@estatus AND date(planos_procesos.fecha_inicio)=@fechaTermino AND planos_procesos.plano=archivos_planos.plano AND planos_proyectos.id=planos_procesos.plano";

            ConstruirQuery(sql);
            AgregarParametro("@estatus", "EN PROCESO");
            AgregarParametro("@fechaTermino", fecha);
            EjecutarQuery();

            return LeerFilas(Bkg, total);
        }

        public List<Fila> CargarProcesosInspeccion(string proceso, string estatus)
        {
            string sql = "SELECT * FROM planos_procesos WHERE proceso=@proceso AND estatus=@estatus";

            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            AgregarParametro("@estatus", estatus);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> BuscarCategoriaMaterial(int procesoId, string procesoEstatus)
        {
            string sql = "select planos_procesos.id as idProceso, planos_proyectos.id as idPlano, " +
                          "planos_proyectos.nombre_archivo, planos_proyectos.cantidad, planos_proyectos.material, " +
                          "planos_procesos.requisicion_compra, tratamientos_material.categoria, planos_procesos.proceso  " +
                          "from planos_procesos " +
                          "inner join planos_proyectos on planos_proyectos.id = planos_procesos.plano " +
                          "inner join tratamientos_material on tratamientos_material.nombre= planos_procesos.proceso " +
                          "where planos_procesos.id=@procesoId and planos_procesos.estatus=@procesoEstatus";

            ConstruirQuery(sql);
            AgregarParametro("@procesoId", procesoId);
            AgregarParametro("@procesoEstatus", procesoEstatus);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> BuscarProcesoAsignado(int idHerramentista)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE (estatus=@estatusAsignado or estatus=@estatusEnProceso or estatus=@estatusDetenido) and herramentista=@idHerramentista"; 

            ConstruirQuery(sql);
            AgregarParametro("@estatusAsignado", "ASIGNADO");
            AgregarParametro("@estatusEnProceso", "EN PROCESO");
            AgregarParametro("@estatusDetenido", "DETENIDO");
            AgregarParametro("@idHerramentista", idHerramentista);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarAsignacionesAgrupadoPorHerramentista()
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE herramentista !=@cero group by herramentista";

            ConstruirQuery(sql);
            AgregarParametro("@cero", "0");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarProcesosHerramentista(int idHerramentista)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE herramentista=@idHerramentista and estatus!=@terminado order by id asc";           
            ConstruirQuery(sql);
            AgregarParametro("@idHerramentista", idHerramentista);
            AgregarParametro("@terminado", "TERMINADO");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarProcesosDelHerramentista(int idHerramentista)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE herramentista=@idHerramentista";
            ConstruirQuery(sql);
            AgregarParametro("@idHerramentista", idHerramentista);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SumarCostosEstimados(int plano)
        {
            string sql = "SELECT sum(costo_estimado_fabricacion) as costo FROM " + Tabla + " where plano=@plano";
            ConstruirQuery(sql);
            AgregarParametro("@plano", plano);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SumarCostosReales(int plano)
        {
            string sql = "SELECT sum(costo_real_fabricacion) as costo FROM " + Tabla + " where plano=@plano";
            ConstruirQuery(sql);
            AgregarParametro("@plano", plano);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ContarEstatusProcesos(int plano, string estatus)
        {
            string sql = "SELECT count(estatus) as estatusProceso FROM " + Tabla + " where plano=@plano and estatus=@estatus and date(fecha_asignacion) = now()";
            ConstruirQuery(sql);
            AgregarParametro("@plano", plano);
            AgregarParametro("@estatus", estatus);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProcesosEnCursoDeUnHerramentista(int idHerramentista)
        {
            string sql = "SELECT * FROM " + Tabla + " where herramentista=@idHerramentista and estatus=@estatus";
            ConstruirQuery(sql);
            AgregarParametro("@idHerramentista", idHerramentista);
            AgregarParametro("@estatus", "EN PROCESO");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProcesosLocalesNoTerminados(int idPlano)
        {
            string sql = "SELECT * " + 
                         "FROM " + Tabla + 
                         " WHERE plano=@plano and estatus!=@estatusTerminado and requisicion_compra=@req";
            
            ConstruirQuery(sql);
            AgregarParametro("@plano", idPlano);
            AgregarParametro("@estatusTerminado", "TERMINADO");
            AgregarParametro("@req", 0);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProcesosPorPlano(int plano, string estatus)
        {
            string sql = "SELECT * FROM " + Tabla + " where plano=@plano and estatus=@estatus ";
            ConstruirQuery(sql);
            AgregarParametro("@plano", plano);
            AgregarParametro("@estatus", estatus);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProcesosDeUnPlano(int plano, string estatus, string proceso)
        {
            string sql = "SELECT * FROM " + Tabla + " where plano=@plano and estatus=@estatus and proceso=@proceso";
            ConstruirQuery(sql);
            AgregarParametro("@plano", plano);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@proceso", proceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarTiempoDeAsignaciones()
        {
            string sql = "SELECT usuarios.id, usuarios.nombre, usuarios.paterno, planos_procesos.estatus, " +
                         "SUM(if(planos_procesos.estatus = 'TERMINADO', 0, " +
                         "if(planos_procesos.estatus = 'PENDIENTE',0, " +
                         "if(planos_procesos.estatus = 'TIEMPO ESTIMADO', 0 , planos_procesos.tiempo_trabajo_estimado)))) AS suma_tiempo_estimado, " +
                         "usuarios.estatus_ocupacion " +
                         "FROM usuarios " +
                         "LEFT JOIN planos_procesos ON planos_procesos.herramentista = usuarios.id " +
                         "WHERE usuarios.rol='TECNICO HERRAMENTISTA' AND usuarios.activo = 1  group by id ";

            ConstruirQuery(sql);
            AgregarParametro("@estatusPendiente", "PENDIENTE");
            AgregarParametro("@estatusTiempoEstimado", "TIEMPO ESTIMADO");
            AgregarParametro("@estatusTerminado", "TERMINADO");
            AgregarParametro("@rol", "TECNICO HERRAMENTISTA");

            EjecutarQuery();
            return LeerFilas();
        }

        public void ReordenarProcesos(int idPlano)
        {
            string sql_reordenar = "";
            sql_reordenar += "SET @new_ordering=0; SET @ordering_inc=10; ";
            sql_reordenar += "UPDATE planos_procesos SET orden =(@new_ordering := @new_ordering + @ordering_inc) WHERE plano=@plano ORDER BY orden ASC";

            ConstruirQuery(sql_reordenar);
            AgregarParametro("@plano", idPlano);
            EjecutarQuery();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;

namespace CB_Base.Classes
{

    public class PlanoProyecto : ModeloMySql
    {

        public PlanoProyecto()
        {
            Tabla = "planos_proyectos";
        }

        static public PlanoProyecto Modelo()
        {
            return new PlanoProyecto();
        }

        public List<Fila> SeleccionarEstatus(string estatus, decimal proyecto, string subensamble="TODOS")
        {
            string sql = "SELECT planos_proyectos.*, ";
            sql += "(SELECT miniatura FROM archivos_planos WHERE archivos_planos.plano=planos_proyectos.id LIMIT 1) AS miniatura ";
            sql += " FROM planos_proyectos WHERE proyecto=@proyecto";

            if (subensamble != "TODOS")
                sql += " AND subensamble=@subensamble";
            
            if(estatus != "TODOS")
                sql += " AND estatus=@estatus";
            
            ConstruirQuery(sql);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@subensamble", subensamble);
            EjecutarQuery();
            return LeerFilas();
        }

        public ArchivoPlano Archivo(int idPlano)
        {
            ArchivoPlano plano = new ArchivoPlano();
            plano.SeleccionarDePlano(idPlano);
            return plano;
        }

        public List<Fila> SinRevisarDeProyecto(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@estatus", "PRELIMINAR");
            return SeleccionarDatos("proyecto=@proyecto AND estatus=@estatus", parametros);
        }

        public List<Fila> RechazadosDeProyecto(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@estatus", "RECHAZADO");
            return SeleccionarDatos("proyecto=@proyecto AND estatus=@estatus", parametros);
        }

        public List<Fila> AceptadosDeProyecto(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@preliminar", "PRELIMINAR");
            parametros.Add("@rechazado", "RECHAZADO");
            return SeleccionarDatos("proyecto=@proyecto AND estatus!=@preliminar AND estatus!=@rechazado", parametros);
        }

        public DataGridViewCellStyle ColorEstatusEnsamble(string estatus)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();

            switch (estatus)
            {
                case "ENSAMBLADO":
                    style.BackColor = Color.LightGreen;
                    style.ForeColor = Color.Black;
                    break;

                case "RECIBIDO":
                    style.BackColor = Color.Yellow;
                    style.ForeColor = Color.Black;
                    break;

                case "PERDIDO":
                    style.BackColor = Color.Red;
                    style.ForeColor = Color.White;
                    break;

                case "RETRABAJO":
                    style.BackColor = Color.Blue;
                    style.ForeColor = Color.White;
                    break;

                case "DESCARTADO":
                    style.BackColor = Color.LightGray;
                    style.ForeColor = Color.Black;
                    break;
            }
            return style;
        }

        public DataGridViewCellStyle ColorEstatusFabricacion(string estatus)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();

            switch (estatus)
            {
                case "PENDIENTE":
                    style.BackColor = Color.Yellow;
                    style.ForeColor = Color.Black;
                    break;

                case "EN PREPARACION":
                    style.BackColor = Color.LightCyan;
                    style.ForeColor = Color.Black;
                    break;

                case "EN FABRICACION":
                    style.BackColor = Color.Blue;
                    style.ForeColor = Color.White;
                    break;

                case "TERMINADO":
                    style.BackColor = Color.LightSeaGreen;
                    style.ForeColor = Color.Black;
                    break;

                case "ENTREGADO":
                    style.BackColor = Color.Green;
                    style.ForeColor = Color.White;
                    break;

                case "PENDIENTE DE TRATAMIENTO":
                    style.BackColor = Color.LightSteelBlue;
                    style.ForeColor = Color.Black;
                    break;
            }
            return style;
        }

        public List<Fila> Pagadas()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "PAGADA");
            parametros.Add("@proveedor", "MAQUINADO LOCAL");
            SeleccionarDatos("proveedor_maquinado!= @proveedor AND proveedor_maquinado != 'N/A' AND estatus_finanzas = @estatus", parametros);
            return Filas();
        }

        public List<Fila> Proyectos()
        {
            string sql = "SELECT DISTINCT FORMAT(planos_proyectos.proyecto, 2) AS proyecto, proyectos.nombre, proyectos.activo FROM planos_proyectos INNER JOIN proyectos ON planos_proyectos.proyecto=proyectos.id WHERE proyectos.activo=1 ORDER BY planos_proyectos.proyecto ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> TiposDeTrabajo()
        {
            string sql = "SELECT DISTINCT tipo FROM " + Tabla + " ORDER BY tipo ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ProveedoresFabricacion()
        {
            string sql = "SELECT DISTINCT proveedor_maquinado FROM " + this.Tabla + " ORDER BY proveedor_maquinado ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ProveedoresTratamiento()
        {
            string sql = "SELECT DISTINCT proveedor_tratamiento FROM " + this.Tabla + " ORDER BY proveedor_tratamiento ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusFabricacion()
        {
            string sql = "SELECT DISTINCT estatus FROM " + Tabla + " ORDER BY estatus";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusEnsamble()
        {
            string sql = "SELECT DISTINCT estatus_ensamble FROM " + Tabla + " ORDER BY estatus_ensamble ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Subensambles()
        {
            string sql = "SELECT DISTINCT subensamble FROM " + Tabla + " ORDER BY subensamble ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarPlano(string nombrePlano)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre_plano", nombrePlano);
            SeleccionarDatos("nombre_archivo=@nombre_plano", parametros);
            return Filas();
        }

        public bool Existe(decimal proyecto, string nombrePlano)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre_archivo", nombrePlano);
            parametros.Add("@proyecto", proyecto);
            SeleccionarDatos("nombre_archivo=@nombre_archivo AND proyecto=@proyecto", parametros);
            return TieneFilas();
        }

        public bool ExistePlano(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@id_plano", id);
            SeleccionarDatos("id=@id_plano", parametros);
            return TieneFilas();
        }

        public List<Fila> ProcesadosDocumentacionMecanica(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@estatus", "SIN DOCUMENTAR");
            SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND estatus!=@estatus", parametros);
            return Filas();
        }

        public List<Fila> ProcesadosRevision(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@preliminar", "PRELIMINAR");
            parametros.Add("@sin_documentar", "SIN DOCUMENTAR");
            SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND estatus!=@preliminar AND estatus!=@sin_documentar", parametros);
            return Filas();
        }

        public List<Fila> TotalPlanosSubproyecto(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@proyecto", proyecto);
            SeleccionarDatos("subensamble=@subensamble AND proyecto=@proyecto", parametros);
            return Filas();
        }

        public List<Fila> TotalPlanosTratamiento(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@tratamiento", "N/A");
            SeleccionarDatos("subensamble=@subensamble AND proyecto=@proyecto AND tratamiento!=@tratamiento", parametros);
            return Filas();
        }

        public List<Fila> PlanosTratamiento(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@pendiente_tratamiento", "PENDIENTE TRATAMIENTO");
            parametros.Add("@en_tratamiento", "EN TRATAMIENTO");
            parametros.Add("@tratamiento", "N/A");
            parametros.Add("@terminado", "TERMINADO");
            parametros.Add("@entregado", "ENTREGADO");
            SeleccionarDatos("subensamble=@subensamble AND proyecto=@proyecto AND tratamiento!=@tratamiento AND (estatus=@pendiente_tratamiento OR estatus=@en_tratamiento OR estatus=@terminado OR estatus=@entregado)", parametros);
            return Filas(); 
        }

        public List<Fila> PlanosTratamientoTerminado(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@estatus_terminado", "TERMINADO");
            parametros.Add("@estatus_entregado", "ENTREGADO");
            parametros.Add("@tratamiento", "N/A");
            SeleccionarDatos("subensamble=@subensamble AND proyecto=@proyecto AND estatus=@estatus_terminado AND estatus=@estatus_entregado", parametros);
            return Filas();
        }

        public List<Fila> AvencePlanosFabricados(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@pendiente_tratamiento", "PENDIENTE TRATAMIENTO");
            parametros.Add("@en_tratamiento", "EN TRATAMIENTO");
            parametros.Add("@terminado", "TERMINADO");
            parametros.Add("@entregado", "ENTREGADO");
            SeleccionarDatos("subensamble=@subensamble AND proyecto=@proyecto AND (estatus=@pendiente_tratamiento OR estatus=@en_tratamiento OR estatus=@terminado OR estatus=@entregado)", parametros);
            return Filas();
        }

        public List<Fila> AvancePlanosEnsamble(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@estatus_ensamble", "ENSAMBLADO");
            SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND estatus_ensamble=@estatus_ensamble", parametros);
            return Filas();
        }

        public List<Fila> PiezaListaParaEnsamble(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@entregado", "ENTREGADO");
            SeleccionarDatos("subensamble=@subensamble AND proyecto=@proyecto AND estatus=@entregado", parametros);
            return Filas();
        }
     
        public List<Fila> FabricacionTerminado()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "TERMINADO");
            return SeleccionarDatos("estatus=@estatus", parametros);
        }

        public void RegistrarPlano(ArchivoSolidWorks archivoSolid, decimal proyecto, int subensamble)
        {
            string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(archivoSolid.Nombre);

            Fila filaPlano = new Fila();

            filaPlano.AgregarCelda("proyecto", proyecto);
            filaPlano.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
            filaPlano.AgregarCelda("cantidad", 0);
            filaPlano.AgregarCelda("tipo", "N/A");
            filaPlano.AgregarCelda("material", "N/A");
            filaPlano.AgregarCelda("presentacion", "N/A");
            filaPlano.AgregarCelda("size", "N/A");
            filaPlano.AgregarCelda("tratamiento", "N/A");
            filaPlano.AgregarCelda("nombre_archivo", nombreArchivoSinExtension);
            filaPlano.AgregarCelda("estatus", "SIN DOCUMENTAR");
            filaPlano.AgregarCelda("fecha_creacion", DateTime.Now);
            filaPlano.AgregarCelda("plano_retrabajo", 0);
            filaPlano.AgregarCelda("comentarios_retrabajo", "");
            filaPlano.AgregarCelda("comentarios_ensamble", "");
            filaPlano.AgregarCelda("comentarios_revision", "");
            filaPlano.AgregarCelda("subensamble", subensamble);

            Insertar(filaPlano);
        }

        public void ActualizarPlano(string nombreArchivo, decimal proyecto)
        {
            AgregarParametro("@nombre_archivo", nombreArchivo);
            AgregarParametro("@proyecto", proyecto);

            SeleccionarDatos("proyecto=@proyecto AND nombre_archivo=@nombre_archivo");

            Filas().ForEach(delegate(Fila f)
            {
                f.ModificarCelda("estatus", "PRELIMINAR");
            });
            GuardarDatos();
        }

        public List<Fila> PiezasTratamientoEstatus(string estatusTratamiento, string estatusProceso="")
        {
            string sql = "";

            if(estatusProceso != "")
                sql = "SELECT planos_proyectos.id, planos_proyectos.estatus, planos_proyectos.nombre_archivo, planos_proyectos.vale_salida_tratamiento, planos_procesos.proceso, " +
                             "planos_procesos.id as idProceso, planos_procesos.estatus as procesoEstatus, planos_procesos.operador " + 
                             "FROM planos_proyectos " +
                             "Inner join planos_procesos ON planos_proyectos.id = planos_procesos.plano " +
                             "inner join tratamientos_material ON tratamientos_material.nombre = planos_procesos.proceso " +
                             "where planos_proyectos.estatus=@estatusTratamiento and planos_procesos.estatus=@estatusProceso"; 
            else
                sql = "SELECT planos_proyectos.id, planos_proyectos.estatus, planos_proyectos.nombre_archivo, planos_proyectos.vale_salida_tratamiento, planos_procesos.proceso, " +
                             "planos_procesos.id as idProceso, planos_procesos.estatus as procesoEstatus, planos_procesos.operador " +
                             "FROM planos_proyectos " +
                             "Inner join planos_procesos ON planos_proyectos.id = planos_procesos.plano " +
                             "inner join tratamientos_material ON tratamientos_material.nombre = planos_procesos.proceso " +
                             "where planos_proyectos.estatus=@estatusTratamiento";

            ConstruirQuery(sql);
            AgregarParametro("@estatusTratamiento", estatusTratamiento);
            AgregarParametro("@estatusProceso", estatusProceso);
            AgregarParametro("@proveedor", "proveedor");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> PiezasEntregadas(string estatusTratamiento, string estatusProceso, DateTime del, DateTime hasta, int limite)
        {
            string sql = "SELECT planos_proyectos.id, planos_proyectos.estatus, planos_proyectos.nombre_archivo, planos_procesos.proceso, " +
                            "planos_procesos.id as idProceso, planos_procesos.estatus as procesoEstatus, planos_procesos.operador " +
                            "FROM planos_proyectos " +
                            "Inner join planos_procesos ON planos_proyectos.id = planos_procesos.plano " +
                            "inner join tratamientos_material ON tratamientos_material.nombre = planos_procesos.proceso " +
                            "where planos_proyectos.estatus=@estatusTratamiento and planos_procesos.estatus=@estatusProceso and date(planos_procesos.fecha_termino) between date(@del) and date(@hasta) " +
                            " order by planos_procesos.id DESC limit @limite";
            

            ConstruirQuery(sql);
            AgregarParametro("@estatusTratamiento", estatusTratamiento);
            AgregarParametro("@estatusProceso", estatusProceso);
            AgregarParametro("@proveedor", "proveedor");
            AgregarParametro("@del", del);
            AgregarParametro("@hasta", hasta);
            AgregarParametro("@limite", limite);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> FabricacionEntregado(DateTime del, DateTime hasta, int limite)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "ENTREGADO");
            parametros.Add("@limite", limite);
            parametros.Add("@del", del);
            parametros.Add("@hasta", hasta);

            return SeleccionarDatos("estatus=@estatus and date(fecha_entrega) between date(@del) and date(@hasta) " +
                            " order by id DESC limit @limite", parametros);
        }

        public List<Fila> PiezasFabricadas()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "FABRICADO");

            return SeleccionarDatos("estatus=@estatus", parametros);
        }

        public List<Fila> SeleccionarPlanosPorEstadoFabricacion(string estatusFabricacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estado", estatusFabricacion);

            return SeleccionarDatos("estatus=@estado", parametros);
        }

        public List<Fila> SeleccionarPlanosDeModulo(decimal proyecto, int subensamble, bool mostrarNoDisponibles = false)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);

            string query = "proyecto=@proyecto and subensamble=@subensamble";
            if (mostrarNoDisponibles)
                query += " and estatus in ('PRELIMINAR', 'EN FABRICACION', 'PENDIENTE', 'EN PREPARACION')";

            return SeleccionarDatos(query, parametros);
        }

        public List<Fila> PlanosSinMetaDeFabricacion(decimal proyecto, DateTime fechaSeleccionada) 
        {
            string sql = "SELECT planos_proyectos.*, modulos.fecha_promesa_congelacion FROM planos_proyectos ";
            sql += "INNER JOIN modulos ON modulos.subensamble=planos_proyectos.subensamble ";
            sql += "WHERE modulos.proyecto =@proyecto and planos_proyectos.proyecto=@proyecto AND (planos_proyectos.estatus='PENDIENTE' OR planos_proyectos.estatus='EN PREPARACION' OR planos_proyectos.estatus='EN FABRICACION') AND DATE(modulos.fecha_promesa_congelacion) <= DATE(@fechaSeleccionada) AND planos_proyectos.fecha_promesa_fabricacion IS NULL GROUP BY planos_proyectos.id ORDER BY planos_proyectos.id ASC";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@fechaSeleccionada", fechaSeleccionada);
            EjecutarQuery();
            return LeerFilas();
        }

        public TimeSpan TiempoTrabajoEstimado(int idPlano)
        {
            string sql = string.Empty;
            sql += "SELECT SUM(tiempo_trabajo_estimado) AS tiempo_trabajo_estimado FROM planos_procesos WHERE plano=@idPlano";
            ConstruirQuery(sql);
            AgregarParametro("@idPlano", idPlano);
            EjecutarQuery();
            LeerFilas();
            
            double tiempoTrabajoEstimado = 0;

            if (TieneFilas())
                tiempoTrabajoEstimado = Convert.ToDouble(Global.ObjetoATexto(Fila().Celda("tiempo_trabajo_estimado"), "0"));

            if (tiempoTrabajoEstimado > 0)
                return TimeSpan.FromHours(tiempoTrabajoEstimado);
            else
                return new TimeSpan();
        }

        public List<Fila> BuscarPlanosDeUnProyecto(decimal proyecto, int subensamble, string estatus)
        {
            string sql = string.Empty;
            sql += "SELECT * FROM " + Tabla + " WHERE proyecto=@proyecto and subensamble=@subensamble and estatus=@estatus";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@subensamble", subensamble);
            AgregarParametro("@estatus", estatus);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> BuscarPlano(int idPlano)
        {
            string sql = string.Empty;
            sql += "SELECT * FROM " + Tabla + " WHERE (estatus='PENDIENTE' OR estatus='EN PREPARACION' OR estatus='EN FABRICACION' OR estatus='FABRICADO') AND id=@id ORDER BY id ASC";
            ConstruirQuery(sql);
            AgregarParametro("@id", idPlano);
            EjecutarQuery();
            return LeerFilas();
        } 

        public List<Fila> SeleccionarPlanosRecientes()
        {
            string query = "SELECT * FROM planos_proyectos WHERE fecha_creacion <= now() and fecha_creacion >= subdate(now(), 5)  AND estatus IN ('PENDIENTE', 'EN FABRICACION', 'EN PREPARACION')";
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusPlanosPorProyecto(decimal proyecto)
        {
            string query = string.Empty;
            query = "select " +
                    "    planos.estatus, " +
                    "    count(planos.estatus) as totales, " +
                    "    planosDos.filasTotales, " +
                    "    (count(planos.estatus) * 100) / planosDos.filasTotales as promedio " +
                    "from " +
                    "    planos_proyectos as planos " +
                    "JOIN " +
                    "( " +
                    "    select estatus, count(*) as filasTotales " +
                    " " +
                    "    from planos_proyectos " +
                    "    where proyecto = @proyecto and estatus not in ('DESCARTADO', 'POR DESCARTAR') " +
                    ") as planosDos " +
                    "where " +
                    "    planos.proyecto = @proyecto and planos.estatus not in ('DESCARTADO', 'POR DESCARTAR') " +
                    "group by " +
                    "    planos.estatus " +
                    "order by " +
                    "    promedio asc; ";

            ConstruirQuery(query);
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusPlanosProyectosPorModulos(decimal proyecto)
        {
            string query = string.Empty;
            query = "select " +
                    "    planos.subensamble, " +
                    "    modulos.nombre, " +
                    "    modulos.descripcion, " +
                    "    SUM(case when planos.estatus = 'ENTREGADO' then 1 else 0 end) as planos_entregados, " +
                    "    SUM(case when planos.estatus not in ('PENDIENTE', 'EN PREPARACION') then 1 else 0 end) as planos_fabricados, " +
                    "    count(planos.id) as planosTotales " +
                    "from " +
                    "    planos_proyectos as planos " +
                    "inner join modulos on modulos.subensamble = planos.subensamble " +
                    "where " +
                    "    planos.proyecto = @proyecto " +
                    "    and modulos.proyecto = @proyecto " +
                    "group by " +
                    "    planos.subensamble " +
                    "order by " +
                    "    planos.subensamble asc; ";

            ConstruirQuery(query);
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> PlanosRealizadosPorDia(DateTime desde, DateTime hasta)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE DATE(fecha_fabricacion_terminada) BETWEEN DATE(@desde) AND DATE(@hasta);";
            ConstruirQuery(query);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> PlanosFabricadosPorSemanaIncluyendoFueraDeSistema(DateTime desde, DateTime hasta)
        {
            string query = "SELECT";
            query += "     DAYNAME(fecha_fabricacion_terminada) as x,";
            query += "     COUNT(id) as planos_fabricados, ";
            query += "     (select count(id) from planos_fuera_sistema where date(fecha_creacion) between DATE(@desde) AND DATE(@hasta)) as planos_fuera_sistema,";
            query += "     SUM(cantidad) as piezas_totales,";
            query += "     fecha_fabricacion_terminada ";
            query += " FROM";
            query += "     planos_proyectos";
            query += " WHERE";
            query += "     DATE(fecha_fabricacion_terminada) BETWEEN DATE(@desde) AND DATE(@hasta)";
            query += " GROUP BY x";
            query += " ORDER BY fecha_fabricacion_terminada ASC;";

            ConstruirQuery(query);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> PlanosFabricadosPorMesIncluyenfoFueraDeSistema(DateTime desde, DateTime hasta)
        {
            string query = "SELECT ";
            query += "    WEEK(fecha_fabricacion_terminada) as x,";
            query += "    COUNT(id) as planos_fabricados,";
            query += "    SUM(cantidad) as piezas_totales,";
            query += "    fecha_fabricacion_terminada ";
            query += "FROM";
            query += "    planos_proyectos ";
            query += "WHERE";
            query += "    DATE(fecha_fabricacion_terminada) BETWEEN DATE(@desde) AND DATE(@hasta) ";
            query += "GROUP BY x ";
            query += "ORDER BY fecha_fabricacion_terminada ASC; ";

            ConstruirQuery(query);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> PlanosFabricadosPorAnioIncluyenfoFueraDeSistema(DateTime desde, DateTime hasta)
        {
            string query = "SELECT ";
            query += "     MONTHNAME(fecha_fabricacion_terminada) as x,";
            query += "     COUNT(id) as planos_fabricados,";
            query += "     SUM(cantidad) as piezas_totales,";
            query += "    	fecha_fabricacion_terminada";
            query += " FROM";
            query += "     planos_proyectos";
            query += " WHERE";
            query += "     DATE(fecha_fabricacion_terminada) BETWEEN DATE(@desde) AND DATE(@hasta)";
            query += " GROUP BY x";
            query += " ORDER BY fecha_fabricacion_terminada ASC; ";


            ConstruirQuery(query);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
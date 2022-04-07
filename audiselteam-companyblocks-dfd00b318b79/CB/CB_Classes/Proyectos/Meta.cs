using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Meta : ModeloMySql
    {

        public Meta()
        {
            Tabla = "metas";
        }

        static public Meta Modelo()
        {
            return new Meta();
        }

        public List<Fila> SeleccionarMetasCompras() 
        {
            return SeleccionarMetasProceso("COMPRAS");
        }

        private List<Fila> SeleccionarMetasProceso(string proceso)
        {
            string sql = "select * from metas where proceso in (select id from procesos where nombre = @nombre) AND avance < 100";
            ConstruirQuery(sql);
            AgregarParametro("@nombre", proceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMetaPorProyectoProceso(decimal proyecto, int proceso)
        {
            string sql = "SELECT * FROM metas WHERE proyecto=@proyecto AND proceso=@proceso";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@proceso", proceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarAutorizadasProceso(int proceso, string order="ASC", string orderBy = "fecha_promesa")
        {
            string sql = "SELECT * FROM metas WHERE proceso=@proceso AND estatus_autorizacion='AUTORIZADO' ORDER BY " + orderBy + " " + order;
            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMetasDeProceso(int proceso, decimal proyecto, string orden = "ASC")
        {
            string sql = "SELECT * FROM metas WHERE proceso=@proceso AND proyecto=@proyecto ORDER BY fecha_promesa " + orden + " limit 1";
            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProyectoProcesoFecha(decimal proyecto, int proceso, DateTime fechaPromesa)
        {
            string sql = "SELECT * FROM metas WHERE proyecto=@proyecto AND proceso=@proceso AND DATE(fecha_promesa)=@fecha_promesa";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@proceso", proceso);
            AgregarParametro("@fecha_promesa", fechaPromesa.Date);
            EjecutarQuery();
            return LeerFilas();
        }

        public int TotalMetasProyectoFecha(decimal proyecto, int proceso, DateTime fecha)
        {
            string sql = "SELECT COUNT(id) AS total_metas FROM metas WHERE proyecto=@proyecto AND proceso=@proceso AND DATE(fecha_promesa)=@fecha";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@fecha", fecha.Date);
            AgregarParametro("@proceso", proceso);
            EjecutarQuery();

            List<Fila> resultado = LeerFilas();

            if (resultado.Count > 0)
                return Convert.ToInt32(resultado[0].Celda("total_metas"));
            else 
                return 0;
        }

        public void BorrarMetasProceso(decimal idProyecto, int idProceso)
        {
            MetaEntregable BuscadorEntregables = new MetaEntregable();

            // buscamos las metas vinculadas con el proceso del proyecto e itera por cada una de ellas
            SeleccionarMetaPorProyectoProceso(idProyecto, idProceso).ForEach(delegate(Fila meta)
            {
                // borramos los entregables vinculados con la meta
                BuscadorEntregables.BorrarEntregablesMeta(idProyecto, Convert.ToInt32(meta.Celda("id")));
            });
            BorrarDatos(); // borramos todas las metas vinculadas con el proceso del proyecto
        }

        public void BorrarMeta(int idMeta)
        {
            MetaEntregable BuscadorEntregables = new MetaEntregable();

            // cargamos los datos de la meta
            CargarDatos(idMeta).ForEach(delegate(Fila meta)
            {
                // borramos los entregables vinculados con la meta
                BuscadorEntregables.BorrarEntregablesMeta(Convert.ToInt32(meta.Celda("proyecto")), Convert.ToInt32(meta.Celda("id")));
            });
            BorrarDatos(); // borramos la meta
        }

        public List<Fila> SeleccionarMetas(int proceso, string estatusAutorizacion, string estatusFinalizacion, DateTime desde, DateTime hasta)
        {
            string query = string.Empty;

            if (estatusFinalizacion == "SIN TERMINAR")
                query = " AND (avance < 100) ";
            else
                query = " AND avance = 100 ";

            string sql = string.Empty;
            if(estatusAutorizacion == "TODOS")
                sql ="SELECT * FROM metas WHERE proceso=@proceso and DATE(fecha_promesa) BETWEEN DATE(@desde) AND DATE(@hasta) " + query + " ORDER BY fecha_promesa DESC";
            else
                sql = "SELECT * FROM metas WHERE proceso=@proceso AND estatus_autorizacion=@estatus and DATE(fecha_promesa) BETWEEN DATE(@desde) AND DATE(@hasta) " + query + " ORDER BY fecha_promesa DESC";

            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            AgregarParametro("@estatus", estatusAutorizacion);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);

            EjecutarQuery();
            return LeerFilas();
        }

        public decimal ActualizarAvance(int idMeta)
        {
            CargarDatos(idMeta);

            switch(Fila().Celda("tipo_entregable").ToString())
            {
                case "MODULO CONGELADO":
                    return ActualizarAvanceModulosCongelados(idMeta);

                case "PARTE FABRICADA":
                    return ActualizarAvancePartesFabricadas(idMeta);

                case "MODULO FABRICADO":
                    return ActualizarAvanceModulosFabricados(idMeta);

                case "MATERIAL DE REQUISICION":
                    return ActualizarAvanceMaterialRequisicion(idMeta);

                case "MATERIAL DE FABRICANTE":
                    return ActualizarAvanceMaterialFabricante(idMeta);

                case "MATERIAL DE MODULO":
                    return ActualizarAvanceMaterialModulo(idMeta);
            }
            return 0;
        }

        protected decimal ActualizarAvanceModulosCongelados(int idMeta)
        {
            if(!TieneFilas())
            {
                throw new ArgumentException("Debes cargar los datos del modelo Meta antes de llamar el metodo CalcularAvanceModulosCongelados()");
            }

            Modulo BuscadorModulos = new Modulo();
            int totalModulos = 0;
            int modulosCongelados = 0;
            int modulosSinCongelar = 0;
        
            // itera por todos los entregables de la meta
            MetaEntregable.Modelo().SeleccionarMeta(idMeta).ForEach(delegate(Fila f)
            {
                BuscadorModulos.CargarDatos(Convert.ToInt32(f.Celda("id_entregable")));

                if (BuscadorModulos.TieneFilas())
                {
                    string estatusAprobacion = BuscadorModulos.Fila().Celda("estatus_aprobacion").ToString();

                    if (estatusAprobacion == "APROBADO")
                        modulosCongelados++;
                    else
                        modulosSinCongelar++;
                }
            });

            // calcula el total de modulos y el avance de la meta (porcentaje de modulos congelados)
            totalModulos = modulosCongelados + modulosSinCongelar;

            decimal avance = 0;

            if(totalModulos > 0)
                avance = (decimal)modulosCongelados / (decimal)totalModulos * 100;
            
            Fila().ModificarCelda("avance", avance);

            // si el avance == 100 entonces la meta fue terminada hoy
            if (avance == 100)
                Fila().ModificarCelda("fecha_terminacion", DateTime.Now);

            GuardarDatos();
            return avance;
        }   

        protected decimal ActualizarAvancePartesFabricadas(int idMeta)
        {
            if (!TieneFilas())
            {
                throw new ArgumentException("Debes cargar los datos del modelo Meta antes de llamar el metodo ActualizarAvancePartesFabricadas()");
            }

            PlanoProyecto BuscadorPlanos = new PlanoProyecto();
            int totalPartes = 0;
            int partesFabricadas = 0;
            int partesSinFabricar = 0;

            MetaEntregable.Modelo().SeleccionarMeta(idMeta).ForEach(delegate(Fila f)
            {
                // el entregable corresponde a un plano, lo cargamos...
                BuscadorPlanos.CargarDatos(Convert.ToInt32(f.Celda("id_entregable")));

                if(BuscadorPlanos.TieneFilas())
                {
                    // determinamos el total de partes sin fabricar y partes fabricadas
                    string estatus = BuscadorPlanos.Fila().Celda("estatus").ToString();
                    object fechaFabricacionTerminada = BuscadorPlanos.Fila().Celda("fecha_fabricacion_terminada");

                    if(estatus != "DESCARTADO" && estatus != "RECHAZADO" && estatus != "CANCELADO" && estatus != "POR DESCARTAR")
                    {
                        if (fechaFabricacionTerminada == null)
                            partesSinFabricar++;
                        else
                            partesFabricadas++;
                    }
                }
            });

            // calculamos el total de partes
            totalPartes = partesFabricadas + partesSinFabricar;

            // calculamos el avance
            decimal avance = 0;
            
            if(totalPartes > 0)
                avance = (decimal)partesFabricadas / (decimal)totalPartes * 100;
            
            Fila().ModificarCelda("avance", avance);

            // si el avance == 100 entonces la meta fue terminada hoy
            if (avance == 100)
                Fila().ModificarCelda("fecha_terminacion", DateTime.Now);

            GuardarDatos();
            return avance;
        }

        protected decimal ActualizarAvanceModulosFabricados(int idMeta)
        {
            if (!TieneFilas())
            {
                throw new ArgumentException("Debes cargar los datos del modelo Meta antes de llamar el metodo ActualizarAvancePartesFabricadas()");
            }

            Modulo BuscadorModulos = new Modulo();
            PlanoProyecto BuscadorPlanos = new PlanoProyecto();
            int totalPartes = 0;
            int partesFabricadas = 0;
            int partesSinFabricar = 0;

            MetaEntregable.Modelo().SeleccionarMeta(idMeta).ForEach(delegate(Fila entregable)
            {
                // el entregable corresponde a un modulo, lo cargamos...
                BuscadorModulos.CargarDatos(Convert.ToInt32(entregable.Celda("id_entregable")));

                BuscadorModulos.Filas().ForEach(delegate(Fila modulo)
                {
                    BuscadorPlanos.SeleccionarPlanosDeModulo(Convert.ToDecimal(modulo.Celda("proyecto")), 
                                                             Convert.ToInt32(modulo.Celda("subensamble"))
                                                             );

                    BuscadorPlanos.Filas().ForEach(delegate(Fila plano)
                    {
                        // determinamos el total de partes sin fabricar y partes fabricadas
                        string estatus = plano.Celda("estatus").ToString();
                        object fechaFabricacionTerminada = plano.Celda("fecha_fabricacion_terminada");

                        if (estatus != "DESCARTADO" && estatus != "CANCELADO" && estatus != "RECHAZADO" && estatus != "POR DESCARTAR")
                        {
                            if (fechaFabricacionTerminada == null)
                                partesSinFabricar++;
                            else
                                partesFabricadas++;
                        }
                    });
                });
            });

            // calculamos el total de partes
            totalPartes = partesFabricadas + partesSinFabricar;

            // calculamos el avance
            decimal avance = 0;
            
            if(totalPartes > 0)
                avance = (decimal)partesFabricadas / (decimal)totalPartes * 100;
            
            Fila().ModificarCelda("avance", avance);

            // si el avance == 100 entonces la meta fue terminada hoy
            if (avance == 100)
                Fila().ModificarCelda("fecha_terminacion", DateTime.Now);

            GuardarDatos();
            return avance;
        }

        protected decimal ActualizarAvanceMaterialRequisicion(int idMeta)
        {
            if (!TieneFilas())
            {
                throw new ArgumentException("Debes cargar los datos del modelo Meta antes de llamar el metodo ActualizarAvanceMaterialRequisicion()");
            }

            MaterialProyecto BuscadorMaterial = new MaterialProyecto();
            int totalRequisiciones = 0;
            int requisicionesRecibidas = 0;
            int requisicionesSinRecibir = 0;

            MetaEntregable.Modelo().SeleccionarMeta(idMeta).ForEach(delegate(Fila f)
            {
                // el entregable corresponde a una requisicion, la cargamos...
                BuscadorMaterial.CargarDatos(Convert.ToInt32(f.Celda("id_entregable")));

                if (BuscadorMaterial.TieneFilas())
                {
                    // determinamos el total de requisiciones recibidas vs. requisiciones sin recibir
                    string estatusCompra = BuscadorMaterial.Fila().Celda("estatus_compra").ToString();
                    object fechaRecibidoAlmacen = BuscadorMaterial.Fila().Celda("fecha_recibido_almacen");

                    if(estatusCompra != "CANCELADO")
                    {
                        if (fechaRecibidoAlmacen == null)
                            requisicionesSinRecibir++;
                        else
                            requisicionesRecibidas++;
                    }
                }
            });

            // calculamos el total de partes
            totalRequisiciones = requisicionesRecibidas + requisicionesSinRecibir;

            // calculamos el avance
            decimal avance = 0;
            
            if(totalRequisiciones > 0)
                avance = ((decimal)requisicionesRecibidas / (decimal)totalRequisiciones) * 100;
            
            Fila().ModificarCelda("avance", avance);

            // si el avance == 100 entonces la meta fue terminada hoy
            if (avance == 100)
                Fila().ModificarCelda("fecha_terminacion", DateTime.Now);

            GuardarDatos();
            return avance;
        }

        protected decimal ActualizarAvanceMaterialFabricante(int idMeta)
        {
            if (!TieneFilas())
            {
                throw new ArgumentException("Debes cargar los datos del modelo Meta antes de llamar el metodo ActualizarAvanceMaterialFabricante()");
            }

            MaterialFabricante BuscadorFabricantes = new MaterialFabricante();
            MaterialProyecto BuscadorMaterial = new MaterialProyecto();
            int totalRequisiciones = 0;
            int requisicionesRecibidas = 0;
            int requisicionesSinRecibir = 0;

            MetaEntregable.Modelo().SeleccionarMeta(idMeta).ForEach(delegate(Fila f)
            {
                // el entregable corresponde a un fabricante, lo cargamos...
                BuscadorFabricantes.CargarDatos(Convert.ToInt32(f.Celda("id_entregable")));

                if (BuscadorFabricantes.TieneFilas())
                {
                    BuscadorMaterial
                        .SeleccionarMaterialDefinidoAutorizadoDeFabricante(Convert.ToDecimal(Fila().Celda("proyecto")), BuscadorFabricantes.Fila().Celda("fabricante").ToString()) // f.celda("fabricante")
                        .ForEach(delegate(Fila material){

                        // determinamos el total de partes sin fabricar y partes fabricadas
                        string estatusCompra = material.Celda("estatus_compra").ToString();
                        object fechaRecibidoAlmacen = material.Celda("fecha_recibido_almacen");

                        if(estatusCompra != "CANCELADO")
                        {
                            if (fechaRecibidoAlmacen == null)
                                requisicionesSinRecibir++;
                            else
                                requisicionesRecibidas++;
                        }
                    });
                }
            });

            // calculamos el total de partes
            totalRequisiciones = requisicionesRecibidas + requisicionesSinRecibir;

            // calculamos el avance
            decimal avance = 0;
            
            if(totalRequisiciones > 0)
                avance = ((decimal)requisicionesRecibidas / (decimal)totalRequisiciones) * 100;
            
            Fila().ModificarCelda("avance", avance);

            // si el avance == 100 entonces la meta fue terminada hoy
            if (avance == 100)
                Fila().ModificarCelda("fecha_terminacion", DateTime.Now);

            GuardarDatos();
            return avance;
        }

        protected decimal ActualizarAvanceMaterialModulo(int idMeta)
        {
            if (!TieneFilas())
            {
                throw new ArgumentException("Debes cargar los datos del modelo Meta antes de llamar el metodo ActualizarAvanceMaterialModulo()");
            }

            Modulo BuscadorModulos = new Modulo();
            MaterialProyecto BuscadorMaterial = new MaterialProyecto();
            int totalRequisiciones = 0;
            int requisicionesRecibidas = 0;
            int requisicionesSinRecibir = 0;

            MetaEntregable.Modelo().SeleccionarMeta(idMeta).ForEach(delegate(Fila f)
            {
                // el entregable corresponde a un modulo, lo cargamos...
                BuscadorModulos.CargarDatos(Convert.ToInt32(f.Celda("id_entregable")));

                if (BuscadorModulos.TieneFilas())
                {
                    BuscadorMaterial
                        .SeleccionarMaterialDefinidoAutorizadoDeModulo(Convert.ToDecimal(Fila().Celda("proyecto")), Convert.ToInt32(BuscadorModulos.Fila().Celda("subensamble")))
                        .ForEach(delegate(Fila material)
                    {

                        // determinamos el total de partes sin fabricar y partes fabricadas
                        string estatusCompra = material.Celda("estatus_compra").ToString();
                        object fechaRecibidoAlmacen = material.Celda("fecha_recibido_almacen");

                        if (estatusCompra != "CANCELADO")
                        {
                            if (fechaRecibidoAlmacen == null)
                                requisicionesSinRecibir++;
                            else
                                requisicionesRecibidas++;
                        }
                    });
                }
            });

            // calculamos el total de partes
            totalRequisiciones = requisicionesRecibidas + requisicionesSinRecibir;

            // calculamos el avance
            decimal avance = 0;

            if (totalRequisiciones > 0)
                avance = ((decimal)requisicionesRecibidas / (decimal)totalRequisiciones) * 100;

            Fila().ModificarCelda("avance", avance);

            // si el avance == 100 entonces la meta fue terminada hoy
            if (avance == 100)
                Fila().ModificarCelda("fecha_terminacion", DateTime.Now);

            GuardarDatos();
            return avance;
        }


        public void CalcularAvanceNuevaPiezaComprada(Fila material)
        {
            // Buscar id del proceso de COMPRAS
            int idProceso = 0;
            Proceso proceso = new Proceso();
            proceso.SeleccionarNombre("COMPRAS");
            if (proceso.TieneFilas())
                idProceso = Convert.ToInt32(proceso.Fila().Celda("id"));

            // Buscar meta(s) que corresponda al mismo proyecto y mismo proceso
            SeleccionarMetaPorProyectoProceso(Convert.ToDecimal(material.Celda("proyecto")), idProceso).ForEach(delegate(Fila f)
            {
                // Buscar los entregables en metas_entregables que corresponden a esa meta
                int idMeta = Convert.ToInt32(f.Celda("id"));

                MetaEntregable entregables = new MetaEntregable();
                entregables.SeleccionarMeta(idMeta);

                if (entregables.TieneFilas())
                {
                    string tipoEntregable = entregables.Fila().Celda("tipo_entregable").ToString();
                    int idEntregable = Convert.ToInt32(entregables.Fila().Celda("id_entregable"));

                    switch (tipoEntregable)
                    {
                        case "MATERIAL DE FABRICANTE":
                            MaterialFabricante fabricante = new MaterialFabricante();
                            fabricante.CargarDatos(idEntregable);
                            if (fabricante.TieneFilas())
                            {
                                if (fabricante.Fila().Celda("fabricante") == material.Celda("fabricante"))
                                    ActualizarAvanceMaterialFabricante(idMeta);
                            }
                            break;
                        case "MATERIAL DE MODULO":
                            //buscar si corresponde al mismo proyecto y mismo subensamble
                            Modulo modulo = new Modulo();
                            modulo.CargarDatos(idEntregable);
                            if(modulo.TieneFilas())
                            {
                                decimal moduloProyecto = Convert.ToDecimal(modulo.Fila().Celda("proyecto"));
                                int subensambleModulo = Convert.ToInt32(modulo.Fila().Celda("subensamble"));
                                if(Convert.ToDecimal(material.Celda("proyecto")) == moduloProyecto && Convert.ToInt32(material.Celda("subensamble")) == subensambleModulo)
                                    ActualizarAvanceMaterialModulo(idMeta);
                            }
                            break;
                        default:
                            break;
                    }
                }
            });
        }

        public void DeterminarIdMeta(decimal proyecto, int idEntregable, int idSubensamble)
        {
            List<Fila> resultado = new List<Classes.Fila>();
            Proceso proceso = new Proceso();
            proceso.SeleccionarNombre("FABRICACION");
            string query = string.Empty;

            List<Fila> listaMetas = SeleccionarMetaPorProyectoProceso(proyecto, proceso.Fila().Celda<int>("id"));

            foreach (Fila f in listaMetas)
            {
                //PIEZA FABRICADA
                switch (f.Celda("tipo_entregable").ToString())
                {
                    case "PARTE FABRICADA":
                        query = "SELECT * FROM metas_entregables WHERE meta =@meta AND id_entregable=@idEntregable";
                        ConstruirQuery(query);
                        AgregarParametro("@idEntregable", idEntregable);
                        AgregarParametro("@meta", f.Celda<int>("id"));
                        EjecutarQuery();
                        resultado = LeerFilas();

                        if (resultado.Count > 0)
                        {
                            foreach (var fila in resultado)
                                ActualizarAvance(fila.Celda<int>("meta"));
                        }
                        break;
                    case "MODULO FABRICADO":
                        Modulo modulos = new Modulo();
                        query = "SELECT * FROM modulos WHERE proyecto=@proyecto AND subensamble =@subensamble";
                        ConstruirQuery(query);
                        AgregarParametro("@proyecto", proyecto);
                        AgregarParametro("@subensamble", idSubensamble);
                        EjecutarQuery();
                        resultado = LeerFilas();

                        foreach (var fila in resultado)
                        {
                            query = "SELECT * FROM metas_entregables WHERE meta =@meta AND id_entregable=@idEntregable";
                            ConstruirQuery(query);
                            AgregarParametro("@idEntregable", fila.Celda<int>("id"));
                            AgregarParametro("@meta", f.Celda<int>("id"));
                            EjecutarQuery();
                            resultado = LeerFilas();

                            foreach (var filavancea in resultado)
                                ActualizarAvance(filavancea.Celda<int>("meta"));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public bool MetaDeModulosContieneUrgencia(int idMeta)
        { 
            string query = "DROP TEMPORARY TABLE IF EXISTS busqueda_urgencia; " +
                            "CREATE TEMPORARY TABLE busqueda_urgencia " +
                            "(select distinct(planos_proyectos.estatus_urgencia) from metas_entregables " +
                            "left join modulos on metas_entregables.id_entregable = modulos.id " +
                            "left join planos_proyectos on planos_proyectos.subensamble = modulos.subensamble and planos_proyectos.proyecto = modulos.proyecto " +
                            "where metas_entregables.meta = @idMeta); " +
                            "SELECT EXISTS (select estatus_urgencia from busqueda_urgencia where estatus_urgencia in ('PENDIENTE','AUTORIZADO')) as existe_urgencia;";
            ConstruirQuery(query);
            AgregarParametro("@idMeta", idMeta);
            EjecutarQuery();
            return LeerFilas()[0].Celda("existe_urgencia").ToString() == "1";
        }

        public bool MetaDePlanoContieneUrgencia(int idMeta)
        {
            string query = "DROP TEMPORARY TABLE IF EXISTS busqueda_urgencia; " +
                            "CREATE TEMPORARY TABLE busqueda_urgencia " +
                            "(select distinct(planos_proyectos.estatus_urgencia) from metas_entregables " +
                            "left join planos_proyectos on planos_proyectos.id = metas_entregables.id_entregable " +
                            "where metas_entregables.meta = @idMeta); " +
                            "SELECT EXISTS (select estatus_urgencia from busqueda_urgencia where estatus_urgencia in ('PENDIENTE','AUTORIZADO')) as existe_urgencia;";
            ConstruirQuery(query);
            AgregarParametro("@idMeta", idMeta);
            EjecutarQuery();
            return LeerFilas()[0].Celda("existe_urgencia").ToString() == "1";
        }

        public List<Fila> BuscarMetaEnMetaCompra(decimal idProyecto, int idProceso, DateTime fechaMeta)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE proyecto=@proyecto AND proceso=@proceso AND tipo_entregable =@entregable AND date(fecha_promesa)= date(@fechaPromesa)";
            ConstruirQuery(query);
            AgregarParametro("@proyecto", idProyecto);
            AgregarParametro("@proceso", idProceso);
            AgregarParametro("@entregable", "MATERIAL DE REQUISICION");
            AgregarParametro("@fechaPromesa", fechaMeta);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}

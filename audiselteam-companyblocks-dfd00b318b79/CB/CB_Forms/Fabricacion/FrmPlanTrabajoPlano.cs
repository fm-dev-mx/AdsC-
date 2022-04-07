using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.Classes;
using FluentFTP;
using System.Net;
using System.IO;

namespace CB
{
    public partial class FrmPlanTrabajoPlano : Ventana
    {
        int IdPlano;
        int IdProceso = 0;
        int NumeroImpresiones = 0;
        int ValeSalidaPzaFabricada = 0;
        int ValeSalidaPzaTratamiento = 0;
        int ValeSalidaPzaEntregada = 0;
        double InicioCarga;
        bool SoloLectura = false;
        bool ProcesoCero = false;
        string ImpresoPor = "";       
        List<Filtro> Filtros = new List<Filtro>();
        List<Fila> ListaMiniatura = new List<Fila>();
        List<Fila> Proceso = new List<Fila>();
        List<Fila> PlanoProyecto = new List<Fila>();
        List<Fila> PlanoArchivo = new List<Fila>();
        List<Fila> MaterialLista = new List<Fila>();
        FtpClient ClienteFtp = new FtpClient();

        public FrmPlanTrabajoPlano(int idPlano, bool soloLectura = false, List<Filtro> filtros = null)
        {
            InitializeComponent();                 
            IdPlano = idPlano;

            SoloLectura = soloLectura;
            Filtros = filtros;
        }

        private void BkgDescargarMiniatura_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!e.Cancel)
            {
                //DescargaMiniatura
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@plano", IdPlano);
                parametros.Add("@id", IdPlano);
                ListaMiniatura = ArchivoPlano.Modelo().SeleccionarDatos("plano=@plano", parametros);

                //Descarga
                PlanoProyecto plano = new PlanoProyecto();
                PlanoProyecto = plano.SeleccionarDatos("id=@id", parametros, "*", BkgDescargarMiniatura);
            }
        }

        private void BkgDescargarMiniatura_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatusDescargar.Text = "Descargando información ... [" + e.ProgressPercentage + "%]";
            LblEstatusDescargar.Refresh();
        }

        private void BkgDescargarMiniatura_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
                ProgresoDescarga.Visible = false;
                LblEstatusDescargar.Text = " información descargada en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
                MostrarMiniatura();
                ProgresoDescarga.Value = 0;
                ProgresoDescarga.Visible = true;
                BkgDescargarProcesos.RunWorkerAsync();
            }
        }

        public void MostrarMiniatura()
        {
            ListaMiniatura.ForEach(delegate(Fila f)
            {
                object miniatura = f.Celda("miniatura");
                if (miniatura == null)
                {
                    PicMiniatura.Image = CB_Base.Properties.Resources.downloadPdf_gray;
                }
                else
                {
                    PicMiniatura.Image = (Bitmap)((new ImageConverter()).ConvertFrom((byte[])miniatura));
                }

            });
            CargarDatosPlano();
        }

        public void CargarDatosPlano()
        {
            PlanoProyecto.ForEach(delegate(Fila f)
            {
                if (f.Celda("estatus").ToString() == "DESCARTADO")
                {
                    MessageBox.Show("El plano fue descartado", "Plano descartado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                else if(f.Celda("estatus").ToString() == "POR DESCARTAR")
                {
                    BtnAgregar.Enabled = false;
                    BtnTerminarPieza.Enabled = false;

                    DialogResult resp = MessageBox.Show("Este plano debe ser descartado, presiona OK para descartarlo ahora.", "Descartar plano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    if(resp == System.Windows.Forms.DialogResult.OK)
                    {
                        PlanoProyecto plano = new PlanoProyecto();
                        plano.CargarDatos(IdPlano);

                        if (plano.TieneFilas())
                        {
                            plano.Fila().ModificarCelda("estatus", "DESCARTADO");
                            plano.Fila().ModificarCelda("estatus_ensamble", "DESCARTADO");

                            // determinar id de la meta
                            int idMeta = 0;
                            Meta meta = new Meta();
                            meta.DeterminarIdMeta(Convert.ToDecimal(plano.Fila().Celda("proyecto")), IdPlano, plano.Fila().Celda<int>("subensamble"));
                            if (meta.TieneFilas())
                            {
                                idMeta = meta.Fila().Celda<int>("meta");
                                meta.ActualizarAvance(idMeta);
                            }

                            MessageBox.Show("El plano fue descartado correctamente.", "Plano descartado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            plano.GuardarDatos();
                            Close();
                        }
                    }
                }
                string nombre = f.Celda("nombre_archivo").ToString();
                LblNumeroPlano.Text = IdPlano + " | " + nombre;
                LblEstatus.Text = f.Celda("estatus").ToString();
            });
        }

        private void BkgProcesos_DoWork(object sender, DoWorkEventArgs e)
        {
            PlanoProceso procesos = new PlanoProceso();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", IdPlano);

            Proceso = procesos.SeleccionarDatos("plano=@plano ORDER BY proceso_anterior ASC", parametros, "*", BkgDescargarProcesos);
        }

        private void BkgProcesos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatusDescargar.Text = "Descargando proceso(s) ... [" + e.ProgressPercentage + "%]";
            LblEstatusDescargar.Refresh();
        }

        private void BkgProcesos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
                ProgresoDescarga.Visible = false;
                LblEstatusDescargar.Text = Proceso.Count + " proceso(s) descargado(s) en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
                CargarProcesos();
            }
        }

        public void CargarProcesos()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvProcesos);
            DgvProcesos.Rows.Clear();
            Proceso.ForEach(delegate(Fila proceso)
            {
                object objFechaInicio = proceso.Celda("fecha_inicio");
                object objFechaTermino = proceso.Celda("fecha_termino");

                string fechaInicio = "N/A";
                if (objFechaInicio != null)
                    fechaInicio = Convert.ToDateTime(objFechaInicio).ToString("MMM dd, yyyy hh:mm:ss tt");

                string fechaTermino = "N/A";
                if (objFechaTermino != null)
                    fechaTermino = Convert.ToDateTime(objFechaTermino).ToString("MMM dd, yyyy hh:mm:ss tt");

                string categoria = string.Empty;
                ProcesoFabricacion procesoFabricacion = new ProcesoFabricacion();
                procesoFabricacion.BuscarCategoria(Global.ObjetoATexto(proceso.Celda("proceso"),""));
                if (procesoFabricacion.TieneFilas())
                    categoria = Global.ObjetoATexto(procesoFabricacion.Fila().Celda("categoria"),"");
                                
                string tiempoTotal = string.Empty;

                //Calcular el tiempo muerto
                string tiempoMuerto = string.Empty;
                if (Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "") != "" &&  Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "0.00") != "0.00")
                    tiempoMuerto = TimeSpan.FromHours(Convert.ToDouble(Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "0.00"))).ToString("h\\:mm") + " hrs";
                else
                    tiempoMuerto = "N/A";

                //calcular tiempo fabricacion
                string tiempoTrabajoReal = string.Empty;
                if (Global.ObjetoATexto(proceso.Celda("tiempo_trabajo_real"), "") != "" &&  Global.ObjetoATexto(proceso.Celda("tiempo_trabajo_real"), "0.00") != "0.00" )                
                    tiempoTrabajoReal = TimeSpan.FromHours(Convert.ToDouble(Global.ObjetoATexto(proceso.Celda("tiempo_trabajo_real"), "0.00"))).ToString("h\\:mm") + " hrs";
                else
                    tiempoTrabajoReal = "N/A";

                //calcular tiempo total
                if (Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "") != "" && Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "0.00") != "0.00")
                    tiempoTotal = (TimeSpan.FromHours(Convert.ToDouble(Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "0.00"))).Add(TimeSpan.FromHours(Convert.ToDouble(proceso.Celda("tiempo_trabajo_real"))))).ToString("h\\:mm") + " hrs"; 
                else
                    tiempoTotal = "N/A";

                string involucrados = string.Empty;
                string involucradosTiempoTotal = string.Empty;
                bool agregarSalto = true;

                ProcesoHerramentista herramentistasInvolucrados = new ProcesoHerramentista();
                herramentistasInvolucrados.CargarHerramentistasDeProceso(Convert.ToInt32(proceso.Celda("id"))).ForEach(delegate (Fila f)
                {
                    if(agregarSalto)
                    {
                        involucrados = Environment.NewLine;
                        involucradosTiempoTotal = Environment.NewLine;
                        agregarSalto = false;
                    }
                    involucrados += f.Celda("herramentista") + " - " + f.Celda("nombre_herramentista").ToString() + Environment.NewLine;
                    involucradosTiempoTotal += TimeSpan.FromHours(Convert.ToDouble(Global.ObjetoATexto(f.Celda("tiempo_trabajo"), "0.00"))).ToString("h\\:mm") + " hrs" + Environment.NewLine;
                });

                //generar id a partir de nombre completo
                string idOperador = "";
                Usuario usuarios = new Usuario();
                usuarios.BuscarPorNombre(proceso.Celda("operador").ToString());
                if (usuarios.TieneFilas())
                    idOperador = usuarios.Fila().Celda("id").ToString() + " - ";


                DgvProcesos.Rows.Add(proceso.Celda("id"),
                                     proceso.Celda("proceso"),
                                     proceso.Celda("maquina"),
                                     proceso.Celda("programador"),
                                     idOperador + proceso.Celda("operador") + involucrados.TrimEnd(),
                                     proceso.Celda("estatus"),
                                     fechaInicio,
                                     fechaTermino,
                                     proceso.Celda("comentarios"),
                                     proceso.Celda("proceso_anterior"),
                                     categoria,
                                     proceso.Celda("requisicion_compra"),
                                     tiempoMuerto,
                                     tiempoTrabajoReal + involucradosTiempoTotal.TrimEnd(),
                                     tiempoTotal + involucradosTiempoTotal.TrimEnd());
            });
            if (DgvProcesos.Rows.Count >= 1)
                BtnImprimir.Enabled = true;
            else
                BtnImprimir.Enabled = false;

            //actualizar estatus
            PlanoProyecto planoProyectos = new PlanoProyecto();
            planoProyectos.CargarDatos(IdPlano);
            if (planoProyectos.TieneFilas())
                LblEstatus.Text = planoProyectos.Fila().Celda("estatus").ToString();
            
            ConfiguracionDataGridView.Recuperar(cfg, DgvProcesos);
            borrarToolStripMenuItem.Enabled = false;
            actualizarToolStripMenuItem.Enabled = false;
            cancelarAsignacionToolStripMenuItem.Enabled = false;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (DgvProcesos.Rows.Count >= 1)
                ProcesoCero = false;

            FrmAgregarProcesoPlano agregar = new FrmAgregarProcesoPlano(IdPlano, ProcesoCero);

            PlanoProyecto p = new PlanoProyecto();
            p.CargarDatos(IdPlano);

            if(p.Fila().Celda("estatus").ToString() == "SCRAP")
            {
                MessageBox.Show("Este plano fue rechazado en la inspección y se le dió disposición como Scrap, no puedes agregar más procesos.", "Scrap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (agregar.ShowDialog() == DialogResult.OK)
            {
                // CargarProcesos(idPlano);
                InicioCarga = Global.MillisegundosEpoch();
                BkgDescargarProcesos.RunWorkerAsync();
                BtnEditarProceso.Enabled = true;
                PlanoEnPreparacion();
                PlanoFabricado();
                LblEstatus.Text = p.Fila().Celda("estatus").ToString();
            }
        }

        public void PlanoEnPreparacion()
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(IdPlano);

            if (plano.TieneFilas())
            {
                if (plano.Fila().Celda("estatus").ToString() == "PENDIENTE")
                {
                    plano.Fila().ModificarCelda("estatus", "EN PREPARACION");
                    LblEstatus.Text = "EN PREPARACION";
                    plano.GuardarDatos();
                    MessageBox.Show("El plano fue colocado EN PREPARACION.",
                                    "Plano en preparación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void PlanoFabricado()
        {
            PlanoProyecto planoProyectos = new PlanoProyecto();
            planoProyectos.CargarDatos(IdPlano);

            if(planoProyectos.TieneFilas())
            {
                if (planoProyectos.Fila().Celda("estatus").ToString() == "FABRICADO")
                {
                    DialogResult result = MessageBox.Show("El plano fue colocado como FABRICADO, ¿Desea entregar la(s) pieza(s) a inspección?.",
                                        "Plano fabricado.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {                        
                        FrmEntregarPiezaFabricada entregarPieza = new FrmEntregarPiezaFabricada();
                        entregarPieza.Show();
                    }
                }
            }
        }

        public int ProcesoSeleccionado()
        {
            if (DgvProcesos.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id"].Value);
            }
            else return 0;
        }

        private void BtnEditarProceso_Click(object sender, EventArgs e)
        {
            if (ProcesoSeleccionado() <= 0)
                return;

            FrmAgregarProcesoPlano editar = new FrmAgregarProcesoPlano(IdPlano, ProcesoCero, IdProceso);

            if (editar.ShowDialog() == DialogResult.OK)
            {
                // CargarProcesos(IdPlano);
                InicioCarga = Global.MillisegundosEpoch();
                BkgDescargarProcesos.RunWorkerAsync();

                if (DgvProcesos.Rows.Count <= 0)
                {
                    BtnEditarProceso.Enabled = false;
                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPlanTrabajoPlano_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmPlanTrabajoPlano_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            BtnEditarProceso.Enabled = DgvProcesos.Rows.Count > 0;
            BtnEditarProceso.Enabled = false;
            DgvProcesos.ScrollBars = ScrollBars.Both;
            CargarMaterial();
            PlanoProyecto planoProyecto = new PlanoProyecto();
            planoProyecto.CargarDatos(IdPlano);
            if(planoProyecto.TieneFilas())
            {
                ValeSalidaPzaFabricada = Convert.ToInt32(planoProyecto.Fila().Celda("vale_salida_inspeccion"));
                ValeSalidaPzaTratamiento = Convert.ToInt32(planoProyecto.Fila().Celda("vale_salida_tratamiento"));
                ValeSalidaPzaEntregada = Convert.ToInt32(planoProyecto.Fila().Celda("vale_salida_entrega"));

                List<string> estatusFabricados = new List<string>();
                estatusFabricados.Add("TERMINADO");
                estatusFabricados.Add("EN INSPECCION");
                estatusFabricados.Add("PENDIENTE DE TRATAMIENTO");
                estatusFabricados.Add("FABRICADO");
                estatusFabricados.Add("EN TRATAMIENTO");



                if (estatusFabricados.Any(s => (planoProyecto.Fila().Celda("estatus").ToString().Contains(s))))
                {
                    BtnEnviarAInspeccion.Enabled = false;
                }
                else
                {
                    BtnEnviarAInspeccion.Enabled = true;
                }

                if (planoProyecto.Fila().Celda("estatus").ToString() == "TERMINADO")
                {
                    BtnAgregar.Enabled = false;
                }
            }
        }

        private void DgvProcesos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < -1)
                return;

            IdProceso = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id"].Value);
            int proceso = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["proceso_anterior"].Value);

            if (proceso == 0)
                ProcesoCero = true;
            else
                ProcesoCero = false;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            PlanoProyecto proyecto = new PlanoProyecto();
            proyecto.CargarDatos(IdPlano);

            NumeroImpresiones = Convert.ToInt32(proyecto.Fila().Celda("total_impresiones"));
            Object obImpresoPor = proyecto.Fila().Celda("impreso_por");
            if (obImpresoPor != null)
                ImpresoPor = proyecto.Fila().Celda("impreso_por").ToString();

            if (NumeroImpresiones > 0)
            {
                DialogResult result = MessageBox.Show("Este plan de trabajo tiene un total de " + NumeroImpresiones + " impresiones, la última impresión fue realizada por " + ImpresoPor + ". ¿Desea imprimir el plan de trabajo?", "Plan impreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    proyecto.Fila().ModificarCelda("total_impresiones", NumeroImpresiones + 1);
                    proyecto.Fila().ModificarCelda("impreso_por", Global.UsuarioActual.NombreCompleto());
                    proyecto.GuardarDatos();
                    MostrarPDF();
                }
            }
            else
            {
                proyecto.Fila().ModificarCelda("total_impresiones", NumeroImpresiones + 1);
                proyecto.Fila().ModificarCelda("impreso_por", Global.UsuarioActual.NombreCompleto());
                proyecto.GuardarDatos();
                MostrarPDF();
            }
        }

        public void MostrarPDF()
        {
            PlanoProceso Proceso = new PlanoProceso();
            string nombreArchivo = "";
            byte[] archivo = null;

            Proceso.CargarDePlano(IdPlano);
            archivo = FormatosPDF.PlanTrabajoFabricacion(IdPlano);
            nombreArchivo = Convert.ToDecimal(Proceso.Fila().Celda("plano")).ToString();
            nombreArchivo += "-PLAN-DE-TRABAJO-" + DateTime.Now.ToString("MMM dd, yyyy");
            FrmVisorPDF pdf = new FrmVisorPDF(archivo, nombreArchivo);
            pdf.Show();
            PlanoEnPreparacion();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void DgvMaterial_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = DgvMaterial.PointToClient(Cursor.Position);

                    // Show the context menu
                    OpcionesMaterial.Show(DgvMaterial, relativeMousePosition);
                }
            }
        }

        private void seleccionarDelCatálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(IdPlano);

            List<string> filtro = new List<string>()
            {
                "M.R.O.",
                "SERVICIOS"
            };

            FrmSeleccionarMaterialFabricacion selec = new FrmSeleccionarMaterialFabricacion(IdPlano);
            //FrmSeleccionarMaterialCatalogo selec = new FrmSeleccionarMaterialCatalogo(true, false);

            if (selec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               // CrearRequisicionMaterial(selec.IdMaterial, selec.CantidadMaterial, Convert.ToInt32(plano.Fila().Celda("subensamble")));
                CargarMaterial();
                plano.Fila().ModificarCelda("estatus_material", "SOLICITADO");
                plano.GuardarDatos();
                PlanoEnPreparacion();
            }
        }

        public void CargarMaterial()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", IdPlano);

            int fila = Global.GuardarFilaSeleccionada(DgvMaterial);
            DgvMaterial.Rows.Clear();

            MaterialProyecto.Modelo().SeleccionarDatos("plano=@plano", parametros).ForEach(delegate(Fila f)
            {
                DgvMaterial.Rows.Add(f.Celda("id"), f.Celda("requisitor"), f.Celda("numero_parte"), f.Celda("descripcion"), f.Celda("piezas_requeridas"), f.Celda("estatus_compra"), f.Celda("estatus_almacen"));
            });

            if (DgvMaterial.Rows.Count > 0)
            {
                ChkMaterialStock.Checked = false;
                ChkMaterialStock.Enabled = false;
            }

            Global.RecuperarFilaSeleccionada(DgvMaterial, fila);
            cancelarToolStripMenuItem.Enabled = false;
            verDetallesToolStripMenuItem.Enabled = false;
        }

        public int CrearRequisicionMaterial(int idCatalogo, int cantidad, int subensamble)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(IdPlano);

            decimal decIdProyecto = 0;

            if (plano.TieneFilas())
            {
                decIdProyecto = Convert.ToDecimal(plano.Fila().Celda("proyecto"));
            }

            CatalogoMaterial material = new CatalogoMaterial();
            material.CargarDatos(idCatalogo);

            int total = 0;
            int piezasPaquete = Convert.ToInt32(material.Fila().Celda("piezas_paquete"));
            int piezasStock = 0;

            if (material.Fila().Celda("tipo_venta").ToString() == "POR PAQUETE")
            {
                decimal piezasEntrePaquete = (decimal)cantidad / (decimal)piezasPaquete;
                total = (int)Math.Ceiling(piezasEntrePaquete);
                piezasStock = (total * piezasPaquete) - cantidad;
            }
            else
            {
                total = cantidad;
            }

            Fila matProyecto = new Fila();

            string requisitor = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();
            string idProyecto = Convert.ToDecimal(decIdProyecto).ToString("F2");

            matProyecto.AgregarCelda("requisitor", requisitor);
            matProyecto.AgregarCelda("proyecto", idProyecto);
            matProyecto.AgregarCelda("categoria", material.Fila().Celda("categoria"));
            matProyecto.AgregarCelda("numero_parte", material.Fila().Celda("numero_parte"));
            matProyecto.AgregarCelda("fabricante", material.Fila().Celda("fabricante"));
            matProyecto.AgregarCelda("descripcion", material.Fila().Celda("descripcion"));
            matProyecto.AgregarCelda("piezas_requeridas", cantidad);
            matProyecto.AgregarCelda("piezas_stock", piezasStock);
            matProyecto.AgregarCelda("total", total);
            matProyecto.AgregarCelda("tipo_venta", material.Fila().Celda("tipo_venta"));
            matProyecto.AgregarCelda("piezas_paquete", material.Fila().Celda("piezas_paquete"));
            matProyecto.AgregarCelda("po", 0);
            matProyecto.AgregarCelda("estatus_seleccion", "DEFINIDO");
            matProyecto.AgregarCelda("estatus_compra", "PENDIENTE");
            matProyecto.AgregarCelda("accesorio_para", 0);
            matProyecto.AgregarCelda("fecha_creacion", DateTime.Now);
            matProyecto.AgregarCelda("plano", IdPlano);
            matProyecto.AgregarCelda("subensamble", subensamble);
            matProyecto.AgregarCelda("estatus_autorizacion", "AUTORIZADO");
            matProyecto.AgregarCelda("comentarios_autorizacion", "AUTORIZACION AUTOMATICA DE MATERIAL PARA MAQUINADO");
            matProyecto.AgregarCelda("usuario_autorizacion", "SISTEMA");
            matProyecto.AgregarCelda("fecha_autorizacion", DateTime.Now);

            matProyecto = MaterialProyecto.Modelo().Insertar(matProyecto);

            string titulo = "Nueva requisición de material";
            string contenido = "";
            contenido += Global.UsuarioActual.NombreCompleto();
            contenido += " creó la requisición de material #" + matProyecto.Celda("id").ToString() + " para el proyecto " + idProyecto.ToString();

            Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");

            // Calcular avance
            Meta.Modelo().CalcularAvanceNuevaPiezaComprada(matProyecto);

            return Convert.ToInt32(matProyecto.Celda("id"));
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvMaterial.SelectedRows.Count <= 0)
                return;

            int IdMaterialSeleccionado = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["id_requisicion"].Value);

            MaterialProyecto material = new MaterialProyecto();
            material.CargarDatos(IdMaterialSeleccionado);

            if (material.Fila().Celda("estatus_compra").ToString() != "PENDIENTE" && material.Fila().Celda("estatus_compra").ToString() != "EN COTIZACION")
            {
                MessageBox.Show("Este material ya ha sido procesado, comunícate con el personal de compras para notificarles la cancelación.");
                return;
            }
            else
            {
                DialogResult resp = MessageBox.Show("Seguro que quieres cancelar esta requisicion de material ?", "Cancelar requisicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp != System.Windows.Forms.DialogResult.Yes)
                    return;
            }
            /*material.Fila().ModificarCelda("estatus_compra", "CANCELADO");
            material.GuardarDatos();*/
            material.BorrarDatos(IdMaterialSeleccionado);
            material.GuardarDatos();
            CargarMaterial();
        }

        private void DgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                cancelarToolStripMenuItem.Enabled = true;
                verDetallesToolStripMenuItem.Enabled = true;
            }
        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvMaterial.SelectedRows.Count <= 0)
                return;

            int IdMaterialSeleccionado = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["id_requisicion"].Value);

            FrmDetallesMaterialProyecto mat = new FrmDetallesMaterialProyecto(IdMaterialSeleccionado);
            mat.Show();
        }

        private void DgvProcesos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DgvProcesos.SelectedRows.Count <= 0)
                return;

            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = DgvProcesos.PointToClient(Cursor.Position);

                    // Show the context menu
                    OpcionesProceso.Show(DgvProcesos, relativeMousePosition);
                }
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvProcesos.Rows.Count <= 0)
                return;

            int idProceso = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id"].Value);
            PlanoProceso proc = new PlanoProceso();
            proc.CargarDatos(idProceso);

            int idRequisicionCompra = Convert.ToInt32(proc.Fila().Celda("requisicion_compra"));

            DialogResult respuesta = MessageBox.Show("Seguro que deseas borrar el proceso seleccionado?", "Borrar proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                if (idRequisicionCompra > 0)
                {
                    MaterialProyecto mat = new MaterialProyecto();
                    mat.CargarDatos(idRequisicionCompra);

                    if (mat.TieneFilas())
                    {
                        string estatusReq = mat.Fila().Celda("estatus_compra").ToString();

                        if (estatusReq != "PENDIENTE" && estatusReq != "EN COTIZACION")
                        {
                            string msg = "Este proceso está vinculado con la requisición de compra #" + idRequisicionCompra;
                            msg += " la cual ya fue procesada. Comunícate con compras para informarles la cancelación.";
                            MessageBox.Show(msg, "Imposible borrar proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        mat.Fila().ModificarCelda("estatus_compra", "CANCELADO");
                        mat.GuardarDatos();
                    }
                }
                proc.BorrarDatos();
                InicioCarga = Global.MillisegundosEpoch();
                BkgDescargarProcesos.RunWorkerAsync();
            }
        }

        private void verRequisiciónDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvProcesos.SelectedRows.Count <= 0)
                return;

            int idProceso = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id"].Value);
            PlanoProceso proc = new PlanoProceso();
            proc.CargarDatos(idProceso);

            if (proc.TieneFilas())
            {
                int idRequisicion = Convert.ToInt32(proc.Fila().Celda("requisicion_compra"));
                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(idRequisicion);

                if (mat.TieneFilas())
                {
                    FrmDetallesMaterialProyecto detalles = new FrmDetallesMaterialProyecto(idRequisicion);
                    detalles.Show();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado una requisición de compra vinculada con este proceso de fabricación.",
                                    "Requisición no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado el proceso de fabricación.",
                                "Proceso de fabricación no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* foreach (DataGridViewRow row in DgvProcesos.Rows)
            {
                if (row.Cells["estatus"].Value.ToString() == "ASIGNADO")
                {
                    MessageBox.Show("Actualmente ya existe un proceso con el estatus ASIGNADO, para asignar uno nuevo primero debe terminar el proceso " + row.Cells["id"].Value.ToString() + " - " + row.Cells["columna_proceso"].Value.ToString(), "Asignar proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }*/

            int idProceso = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id"].Value);

            if (DgvProcesos.Rows.Count <= 0)
                return;

            PlanoProceso proc = new PlanoProceso();
            proc.CargarDatos(idProceso);


            // si idReq > 0 el proceso fue asignado con un proveedor
            int idRequisicionCompra = Convert.ToInt32(proc.Fila().Celda("requisicion_compra"));
            if (idRequisicionCompra > 0)
            {
                DialogResult resp = MessageBox.Show("Este proceso fue asignado con un proveedor, quieres consultar la requisición de compra?",
                                                    "Proceso externo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == System.Windows.Forms.DialogResult.Yes)
                {
                    MaterialProyecto mat = new MaterialProyecto();
                    mat.CargarDatos(idRequisicionCompra);

                    if (mat.TieneFilas())
                    {
                        FrmDetallesMaterialProyecto detalles = new FrmDetallesMaterialProyecto(idRequisicionCompra);
                        detalles.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado una requisición de compra vinculada con este proceso de fabricación.",
                                        "Requisición no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return;
            }

            // si el proceso fue asignado localmente (en vez de con proveedor) continuamos ejecutando el codigo aqui
            // y mostramos el form para modificar el proceso

            FrmAsignarProcesoFabricacion asignarProceso = new FrmAsignarProcesoFabricacion(idProceso, IdPlano);
            if (asignarProceso.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Modificar proceso
                if(proc.TieneFilas())
                {
                    double costoEstandar = 0;

                    //Calcular costoEstimadoFabricación = CostoHrEstandar * TiempoEstimado
                    ProcesoFabricacion procesoFabricacion = new ProcesoFabricacion();
                    procesoFabricacion.BuscarProceso(asignarProceso.Proceso);

                    if(procesoFabricacion.TieneFilas())
                        costoEstandar = Convert.ToDouble(procesoFabricacion.Fila().Celda("costo_estandar"));

                    double costoEstimadoFabricación = costoEstandar * asignarProceso.TotalTiempoEstandar;
                    string[] datosOperador = asignarProceso.Herramenstista.Split('-');
                    string operador = datosOperador[1].TrimStart();
                    int idHerramentista = Convert.ToInt32(datosOperador[0].TrimEnd());

                    proc.Fila().ModificarCelda("maquina", asignarProceso.MaquinaHerramienta);
                    proc.Fila().ModificarCelda("programador", asignarProceso.MaquinaHerramienta);
                    proc.Fila().ModificarCelda("operador", operador);
                    proc.Fila().ModificarCelda("herramentista", idHerramentista);
                    proc.Fila().ModificarCelda("comentarios", asignarProceso.ComentariosSupervisor);
                    
                    if (proc.Fila().Celda("estatus").ToString() == "PENDIENTE")
                        proc.Fila().ModificarCelda("estatus", "ASIGNADO");

                    proc.Fila().ModificarCelda("fecha_asignacion", DateTime.Now);
                    proc.Fila().ModificarCelda("tiempo_trabajo_estimado", asignarProceso.TotalTiempoEstandar);
                    proc.Fila().ModificarCelda("costo_estimado_fabricacion", costoEstimadoFabricación);
                    int complejidad = 0;

                    switch (asignarProceso.Complejidad)
                    {
                        case "NADA COMPLEJA":
                            complejidad = 1;
                            break;
                        case "POCO COMPLEJA":
                            complejidad = 2;
                            break;
                        case "COMPLEJA":
                            complejidad = 3;
                            break;
                        case "MUY COMPLEJA":
                            complejidad = 4;
                            break;
                        default:
                            break;
                    }
                    proc.Fila().ModificarCelda("nivel_complejidad", complejidad);

                    proc.GuardarDatos();

                    //guardar operaciones
                    foreach (Fila item in asignarProceso.DatosOperacion)
                    {
                        PlanoOperacion.Modelo().Insertar(item);
                    }
                }

                InicioCarga = Global.MillisegundosEpoch();
                ProgresoDescarga.Value = 0;
                ProgresoDescarga.Visible = true;
                BkgDescargarProcesos.RunWorkerAsync();
            }
        }

        private void BtnTerminarPieza_Click(object sender, EventArgs e)
        {
            bool contieneProcesoInspeccion = false;
            bool procesosTerminados = true;

            foreach (DataGridViewRow row in DgvProcesos.Rows)
            {
                if (row.Cells["col_categoria"].Value.ToString() == "INSPECCION")
                {
                    contieneProcesoInspeccion = true;                   
                }
                if (row.Cells["estatus"].Value.ToString() != "TERMINADO")
                {
                    procesosTerminados = false;
                    break;
                }
            }

            if(!contieneProcesoInspeccion || !procesosTerminados)
            {
                MessageBox.Show("Para poder terminar la pieza debe existir por lo menos un proceso de inspección y cada proceso debe tener el estatus de TERMINADO", "Terminar pieza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resp = MessageBox.Show("Seguro que quieres colocar este plano como TERMINADO?", "Terminar pieza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@plano", IdPlano);
                parametros.Add("@terminado", "TERMINADO");

                PlanoProceso proc = new PlanoProceso();
                proc.SeleccionarDatos("plano=@plano AND estatus!=@terminado", parametros);

                if (proc.TieneFilas())
                {
                    MessageBox.Show("Antes de marcar el plano como TERMINADO todos los procesos también deben estar terminados.",
                                    "Imposible terminar plano", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(IdPlano);

                if (plano.TieneFilas())
                {
                    plano.Fila().ModificarCelda("estatus", "TERMINADO");
                    LblEstatus.Text = "TERMINADO";
                    BtnAgregar.Enabled = false;
                    plano.Fila().ModificarCelda("fecha_terminado", DateTime.Now);

                    PlanoProceso costoProceso = new PlanoProceso();
                    costoProceso.SumarCostosEstimados(IdPlano);
                    if(costoProceso.TieneFilas())
                        plano.Fila().ModificarCelda("costo_estimado_fabricacion", costoProceso.Fila().Celda("costo"));

                    PlanoProceso costoReal = new PlanoProceso();
                     costoReal.SumarCostosReales(IdPlano);
                    if(costoReal.TieneFilas())
                        plano.Fila().ModificarCelda("costo_real_fabricacion", costoReal.Fila().Celda("costo"));

                    plano.GuardarDatos();
                    MessageBox.Show("El plano fue colocado como TERMINADO, coloca la pieza en el rack correspondiente.",
                                    "Plano terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnGenerarMiniatura_Click(object sender, EventArgs e)
        {
            BtnGenerarMiniatura.Enabled = false;
            Application.DoEvents();

            ArchivoPlano ap = new ArchivoPlano();
            ap.SeleccionarDePlano(IdPlano);

            if (ap.TieneFilas())
            {
                if ((byte[])ap.Fila().Celda("miniatura") != null)
                {
                    MessageBox.Show("Este plano ya tiene vista previa.", "Imposible generar vista previa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnGenerarMiniatura.Enabled = true;
                    return;
                }

                byte[] datosPlano = (byte[])ap.Fila().Celda("archivo");
                string pathPlano = Path.GetTempPath() + IdPlano + ".pdf";
                File.WriteAllBytes(pathPlano, datosPlano);
                byte[] miniatura = FormatosPDF.MiniaturaPDF(pathPlano);

                ap.Fila().ModificarCelda("miniatura", miniatura);
                ap.GuardarDatos();

                PicMiniatura.Image = (Bitmap)((new ImageConverter()).ConvertFrom((byte[])miniatura));
            }
            BtnGenerarMiniatura.Enabled = true;
        }

        private void PicMiniatura_DoubleClick(object sender, EventArgs e)
        {
            BkgDescargarPlano.RunWorkerAsync();
        }

        public void VerPDF()
        {
            byte[] archivo = null;
            string nombre = "";

            if (PlanoProyecto.Count > 0 && PlanoArchivo.Count > 0)
            {
                PlanoArchivo.ForEach(delegate(Fila f)
                {
                    archivo = (byte[])f.Celda("archivo");
                });

                PlanoProyecto.ForEach(delegate(Fila f)
                {
                    nombre = f.Celda("nombre_archivo").ToString();
                });

                FrmVisorPDF visor = new FrmVisorPDF(archivo, nombre);
                visor.Show();
            }
        }

        private void BtnVerPDF_Click(object sender, EventArgs e)
        {
            InicioCarga = Global.MillisegundosEpoch();
            ProgresoDescarga.Value = 0;
            ProgresoDescarga.Visible = true;
            BkgDescargarPlano.RunWorkerAsync();
        }

        private void BkgDescargarPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            ArchivoPlano archivoPlano = new ArchivoPlano();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", IdPlano);
            parametros.Add("@id", IdPlano);

            PlanoArchivo = archivoPlano.SeleccionarDatos("plano=@plano", parametros);

            PlanoProyecto plano = new PlanoProyecto();
            PlanoProyecto = plano.SeleccionarDatos("id=@id", parametros, "*", BkgDescargarPlano);
        }

        private void BkgDescargarPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatusDescargar.Text = "Descargando información del plano ... [" + e.ProgressPercentage + "%]";
            LblEstatusDescargar.Refresh();
        }

        private void BkgDescargarPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
            ProgresoDescarga.Visible = false;
            LblEstatusDescargar.Text = " Plano descargado en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
            VerPDF();
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            FrmDetallesPlanoFabricacion detalles = new FrmDetallesPlanoFabricacion(IdPlano);
            detalles.Show();
        }

        private void ChkMaterialStock_CheckedChanged(object sender, EventArgs e)
        {
            seleccionarDelCatálogoToolStripMenuItem.Enabled = !ChkMaterialStock.Checked;
            DgvMaterial.Enabled = !ChkMaterialStock.Checked;

            PlanoProyecto p = new PlanoProyecto();
            p.CargarDatos(IdPlano);

            if (p.TieneFilas())
            {
                if (ChkMaterialStock.Checked)
                    p.Fila().ModificarCelda("estatus_material", "EN STOCK");
                else
                    p.Fila().ModificarCelda("estatus_material", "N/A");

                p.GuardarDatos();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                PlanoProyecto p = new PlanoProyecto();
                p.CargarDatos(IdPlano);

                if (p.TieneFilas())
                {
                    if (p.Fila().Celda("estatus_material").ToString() == "EN STOCK")
                    {
                        ChkMaterialStock.Checked = true;
                    }
                }
            }
        }

        private void FrmPlanTrabajoPlano_Shown(object sender, EventArgs e)
        {
            InicioCarga = Global.MillisegundosEpoch();
            BkgDescargarMiniatura.RunWorkerAsync();
        }

        private void planificarTiempoExtraToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (DgvProcesos.SelectedRows.Count <= 0)
                return;

            int idProceso = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id"].Value);

            FrmPlanificarTiempoExtra planificar = new FrmPlanificarTiempoExtra(idProceso, 0);
            planificar.ShowDialog();
        }

        private void BtnResultadosInspeccion_Click(object sender, EventArgs e)
        {
            FrmResultadosInspeccion2 noConformidad = new FrmResultadosInspeccion2(IdPlano, IdProceso);
            noConformidad.Show();
        }

        private void MenuValeSalida_Opening(object sender, CancelEventArgs e)
        {
             piezaFabricadaToolStripMenuItem.Enabled = false;
             tratamientoDeMaterialesToolStripMenuItem.Enabled = false;
             piezasEntregadasToolStripMenuItem.Enabled = false;
                
            if(ValeSalidaPzaFabricada > 0)
                piezaFabricadaToolStripMenuItem.Enabled = true;
            if (ValeSalidaPzaTratamiento > 0)
                tratamientoDeMaterialesToolStripMenuItem.Enabled = true;
            if (ValeSalidaPzaEntregada > 0)
                piezasEntregadasToolStripMenuItem.Enabled = true;
        }

        private void piezaFabricadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
             DescargarValeFtp(ValeSalidaPzaFabricada);
        }

        private void tratamientoDeMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
             DescargarValeFtp(ValeSalidaPzaTratamiento);
        }

        private void piezasEntregadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
             DescargarValeFtp(ValeSalidaPzaEntregada);
        }

        private void DescargarValeFtp(int valeId)
        {
            byte[] datosVale = null;

            if (!ClienteFtp.IsConnected)
            {
                if (Global.TipoConexion == "LOCAL")
                    ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
                else
                    ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;

                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
                // Verificar conexion con servidor FTP
                try
                {
                    ClienteFtp.Connect();
                }
                catch
                {
                    return;
                }
            }

            if(ClienteFtp.FileExists("SGC\\VALES_SALIDA\\" + valeId + ".pdf"))
            {
                // enviar archivos a carpeta ftp
                ClienteFtp.Download(out datosVale, "SGC\\VALES_SALIDA\\" + valeId + ".pdf");
                FrmVisorPDF visorPdf = new FrmVisorPDF(datosVale, "Vale " + valeId.ToString());
                visorPdf.Show();
            }
        }

        private void BtnValeSalida_Click(object sender, EventArgs e)
        {
            MenuValeSalida.Show(BtnValeSalida, BtnValeSalida.PointToClient(Cursor.Position));
        }

        private void cancelarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int idProceso = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id"].Value.ToString());

            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar el proceso " + DgvProcesos.SelectedRows[0].Cells["id"].Value.ToString() + " - " + DgvProcesos.SelectedRows[0].Cells["columna_proceso"].Value.ToString() + "?", "Cancelar proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                PlanoProceso proceso = new PlanoProceso();
                proceso.CargarDatos(idProceso);
                if (proceso.TieneFilas())
                {
                    proceso.Fila().ModificarCelda("maquina", "N/A");
                    proceso.Fila().ModificarCelda("operador", "N/A");
                    proceso.Fila().ModificarCelda("comentarios", "");
                    proceso.Fila().ModificarCelda("estatus", "PENDIENTE");
                    proceso.Fila().ModificarCelda("fecha_inicio", null);
                    proceso.Fila().ModificarCelda("fecha_termino", null);
                    proceso.Fila().ModificarCelda("herramentista", "0");
                    proceso.Fila().ModificarCelda("tiempo_trabajo_estimado", null);
                    proceso.Fila().ModificarCelda("fecha_asignacion", null);
                    proceso.Fila().ModificarCelda("costo_estimado_fabricacion", 0); 
                    proceso.Fila().ModificarCelda("nivel_complejidad", null);
                    proceso.GuardarDatos();
                }

                //Borrar Operaciones
                PlanoOperacion operaciones = new PlanoOperacion();
                operaciones.SeleccionarOperacion(IdPlano, IdProceso).ForEach(delegate(Fila f)
                {
                    PlanoOperacion borrarOperacion = new PlanoOperacion();
                    borrarOperacion.CargarDatos(Convert.ToInt32(f.Celda("idPlanoOperaciones")));
                    borrarOperacion.BorrarDatos(Convert.ToInt32(borrarOperacion.Fila().Celda("id")));
                    borrarOperacion.GuardarDatos();
                });

                //CargarProcesos(IdPlano);
                InicioCarga = Global.MillisegundosEpoch();
                ProgresoDescarga.Value = 0;
                ProgresoDescarga.Visible = true;
                BkgDescargarProcesos.RunWorkerAsync();
            }
        }

        private void OpcionesProceso_Opening(object sender, CancelEventArgs e)
        {
            BtnEditarProceso.Enabled = true;
            borrarToolStripMenuItem.Enabled = true;
            if (DgvProcesos.SelectedRows[0].Cells["col_categoria"].Value.ToString() == "INSPECCION" || DgvProcesos.SelectedRows[0].Cells["estatus"].Value.ToString() == "TERMINADO" || DgvProcesos.SelectedRows[0].Cells["estatus"].Value.ToString() == "EN PROCESO" || DgvProcesos.SelectedRows[0].Cells["estatus"].Value.ToString() == "ASIGNADO")
                actualizarToolStripMenuItem.Enabled = false;
            else
                actualizarToolStripMenuItem.Enabled = true;

            if (DgvProcesos.SelectedRows[0].Cells["estatus"].Value.ToString() == "ASIGNADO" || DgvProcesos.SelectedRows[0].Cells["estatus"].Value.ToString() == "DETENIDO")
                cancelarAsignacionToolStripMenuItem.Enabled = true;
            else
                cancelarAsignacionToolStripMenuItem.Enabled = false;


            if (Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["columna_requisicion_compra"].Value) > 0)
                planificarTiempoExtraToolStripMenuItem.Enabled = false;
            else
                planificarTiempoExtraToolStripMenuItem.Enabled = true;

            if (DgvProcesos.SelectedRows[0].Cells["estatus"].Value.ToString() == "TERMINADO" || DgvProcesos.SelectedRows[0].Cells["estatus"].Value.ToString() == "DETENIDO")
                tiempoDeFabricaciónToolStripMenuItem.Enabled = false;
            else
                tiempoDeFabricaciónToolStripMenuItem.Enabled = true;

            BtnResultadosInspeccion.Enabled = DgvProcesos.SelectedRows[0].Cells["columna_proceso"].Value.ToString().Contains("INSPECCION");
        }

        private void BtnTiempoFabricacion_Click(object sender, EventArgs e)
        {

            int idPlano = IdPlano;
            int idMeta = 0;

            DialogResult resp = MessageBox.Show("¿Seguro que quieres Enviar este plano a calidad?", "Enviar plano a calidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                PlanoProceso proc = new PlanoProceso();
                proc.SeleccionarProcesosLocalesNoTerminados(idPlano);

                if (proc.TieneFilas())
                {
                    MessageBox.Show("Antes de enviar el plano a calidad todos los procesos deben estar terminados.",
                                    "No es posible realizar acción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PlanoProyecto planoProyecto = new PlanoProyecto();
                planoProyecto.CargarDatos(idPlano);
                if (planoProyecto.TieneFilas())
                {
                    if (planoProyecto.Fila().Celda("estatus").ToString() == "FABRICADO")
                    {
                        MessageBox.Show("Esta acción no es posible, el plano anteriormente fue colocado como FABRICADO", "Plano fabricado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    planoProyecto.Fila().ModificarCelda("estatus", "FABRICADO");
                    planoProyecto.Fila().ModificarCelda("fecha_fabricacion_terminada", DateTime.Now);
                    planoProyecto.GuardarDatos();

                    // SE crea un proceso de inspeccion
                    InsertarProcesoInspeccion(idPlano);
                    List<int> listaPlano = new List<int>();
                    listaPlano.Add(IdPlano);

                    DialogResult result = MessageBox.Show("El plano fue colocado como FABRICADO, ¿Desea entregar la(s) pieza(s) a inspección?.",
                                      "Plano fabricado.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        FrmEntregarPiezaFabricada entregarPieza = new FrmEntregarPiezaFabricada();
                        entregarPieza.Show();
                    }

                }

                // busca el id de la meta correspondiente con el plano que estamos marcando como fabricado
                MetaEntregable entregable = new MetaEntregable();
                entregable.BuscarMetaDelEntregable("PARTE FABRICADA", IdPlano);
                if(entregable.TieneFilas())
                {
                    idMeta = Convert.ToInt32(entregable.Fila().Celda("meta"));

                    //actualizar avance
                    Meta.Modelo().ActualizarAvance(idMeta);
                    //Guardar calcular eficiencia en avance
                    CalcularEficienciaAvance(idMeta);
                }

                planoProyecto.CargarDatos(IdPlano);
                if (planoProyecto.TieneFilas())
                {
                    ValeSalidaPzaFabricada = Convert.ToInt32(planoProyecto.Fila().Celda("vale_salida_inspeccion"));
                    ValeSalidaPzaTratamiento = Convert.ToInt32(planoProyecto.Fila().Celda("vale_salida_tratamiento"));
                    ValeSalidaPzaEntregada = Convert.ToInt32(planoProyecto.Fila().Celda("vale_salida_entrega"));

                    if (planoProyecto.Fila().Celda("estatus").ToString() == "TERMINADO")
                        BtnAgregar.Enabled = false;
                }
                Close();
            }
        }

        private void CalcularEficienciaAvance(int idMeta)
        {
            Meta meta = new Meta();
            meta.CargarDatos(idMeta);

            if (meta.TieneFilas())
            {
                int tiempoTranscurrido = 0;
                decimal eficiencia = 0;
                DateTime fechaAutorizacion = Convert.ToDateTime(meta.Fila().Celda("fecha_autorizacion"));
                DateTime fechaPromesa = Convert.ToDateTime(meta.Fila().Celda("fecha_promesa"));
                decimal avance = Convert.ToDecimal(meta.Fila().Celda("avance"));

                TimeSpan diferenciaTranscurrida = DateTime.Now.Date - fechaAutorizacion.Date;
                TimeSpan diferenciaAutorizacionPromesa = fechaPromesa.Date - fechaAutorizacion.Date;
                int diasTranscurridos = diferenciaTranscurrida.Days;
                int diasDelProyecto = diferenciaAutorizacionPromesa.Days;
                if (diasDelProyecto > 0)
                    tiempoTranscurrido = (diasTranscurridos * 100) / diasDelProyecto;
                else
                    tiempoTranscurrido = (diasTranscurridos * 100);

                if (tiempoTranscurrido > 0)
                    eficiencia = (avance / tiempoTranscurrido) * 100;
                else
                    eficiencia = (avance) * 100;

                Fila insertarMetaEficiencia = new Fila();
                insertarMetaEficiencia.AgregarCelda("meta", idMeta);
                insertarMetaEficiencia.AgregarCelda("avance", avance);
                insertarMetaEficiencia.AgregarCelda("fecha", DateTime.Now);
                insertarMetaEficiencia.AgregarCelda("tiempo_transcurrido", tiempoTranscurrido);
                insertarMetaEficiencia.AgregarCelda("eficiencia", eficiencia);

                MetaEficiencia.Modelo().Insertar(insertarMetaEficiencia);
            }
        }

        private void InsertarProcesoInspeccion(int idPlano)
        {
            PlanoProceso proceso = new PlanoProceso();

            Usuario usuario = new Usuario();
            usuario.SeleccionarRol("INSPECTOR DE CALIDAD");

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", idPlano);

            proceso.SeleccionarDatos("plano=@plano ORDER BY orden DESC limit 1", parametros);

            Fila insertarProcesoInspeccion = new Fila();
            insertarProcesoInspeccion.AgregarCelda("plano", idPlano);
            insertarProcesoInspeccion.AgregarCelda("proceso", "INSPECCION DE FABRICACION");
            insertarProcesoInspeccion.AgregarCelda("maquina", "LABORATORIO DE CALIDAD");
            insertarProcesoInspeccion.AgregarCelda("programador", "N/A");
            insertarProcesoInspeccion.AgregarCelda("operador", usuario.Fila().Celda("nombre").ToString() + " " + usuario.Fila().Celda("paterno").ToString());
            insertarProcesoInspeccion.AgregarCelda("estatus", "PENDIENTE");
            insertarProcesoInspeccion.AgregarCelda("proceso_anterior", proceso.Fila().Celda("id"));
            insertarProcesoInspeccion.AgregarCelda("herramentista", usuario.Fila().Celda("id"));
            insertarProcesoInspeccion.AgregarCelda("orden", Convert.ToInt32(proceso.Fila().Celda("id")) + 10);
            proceso.Insertar(insertarProcesoInspeccion);
        }

        private void tiempoDeFabricaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idProcesoSeleccionado = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id"].Value.ToString());

            FrmTiempoFabricacion agregarTiempo = new FrmTiempoFabricacion(idProcesoSeleccionado);
            if (agregarTiempo.ShowDialog() == DialogResult.OK)
            {
                PlanoProceso procesos = new PlanoProceso();
                PlanoProyecto plano = new PlanoProyecto();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@plano", IdPlano);

                Proceso = procesos.SeleccionarDatos("plano=@plano ORDER BY proceso_anterior ASC", parametros, "*");
                PlanoProyecto = plano.SeleccionarDatos("id=@id", parametros, "*");
                CargarDatosPlano();
                CargarProcesos();
            }
        }
    }
}

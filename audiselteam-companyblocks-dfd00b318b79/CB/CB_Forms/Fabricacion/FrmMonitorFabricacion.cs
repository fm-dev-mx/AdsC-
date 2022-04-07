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

namespace CB
{
    public partial class FrmMonitorFabricacion : Form
    {
        const int IntervaloActualizarAsignaciones = 1000;
        int IdPlanoCargado = 0;
        int RefrescarContador = IntervaloActualizarAsignaciones;
        int Row = 0;
        string EstatusPlanos = "";
        List<Fila> Planos = new List<Fila>();
        List<Fila> ListaAsiganacion = new List<Fila>();
        PlanoProyecto BuscadorPlanos = new PlanoProyecto();
        double InicioDescarga;

        public FrmMonitorFabricacion(List<Filtro> filtros=null)
        {
            InitializeComponent();

            if(filtros == null)
            {
                BuscadorPlanos.Filtros.Add(new Filtro("estatus", "Estatus fabricación", BuscadorPlanos.EstatusFabricacion()));
                BuscadorPlanos.Filtros[0].DesactivarTodos();
                BuscadorPlanos.Filtros[0].ModificarFiltro("PENDIENTE", true);
                BuscadorPlanos.Filtros[0].ModificarFiltro("EN PREPARACION", true);
                BuscadorPlanos.Filtros[0].ModificarFiltro("EN FABRICACION", true);
                BuscadorPlanos.Filtros[0].ModificarFiltro("TERMINADO", true);
                BuscadorPlanos.Filtros[0].ModificarFiltro("PENDIENTE DE TRATAMIENTO", true);

                BuscadorPlanos.Filtros.Add(new Filtro("proyecto", "Proyecto", BuscadorPlanos.Proyectos()));
                BuscadorPlanos.Filtros.Add(new Filtro("tipo", "Tipo de trabajo", BuscadorPlanos.TiposDeTrabajo()));
                BuscadorPlanos.Filtros.Add(new Filtro("estatus_ensamble", "Estatus ensamble", BuscadorPlanos.EstatusEnsamble()));
                BuscadorPlanos.Filtros.Add(new Filtro("subensamble", "Subensamble", BuscadorPlanos.Subensambles()));
            }
            else
            {
                BuscadorPlanos.Filtros = filtros;
            }
        }

        private void FrmMonitorFabricacion_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
            chkVistaPreviaToolStripMenuItem.Checked = false;
            ActiveControl = BtnBuscar;
            CargarAsignaciones();

            TimerRefresh = new Timer();           
            TimerRefresh.Interval = 1000;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: //asignaciones               
                    break;
                case 1: //planos
                    DescargarPlanos();
                    DgvPlanos.Sort(DgvPlanos.Columns["fecha_limite_fabricacion"], ListSortDirection.Ascending);
                    break;
                default:
                    break;
            }
        }

        private void CargarAsignaciones()
        {
            Row = 0;
            BarraProgresoAsignaciones.Value = 0;
            BarraProgresoAsignaciones.Visible = true;
            DgvAsignaciones.Rows.Clear();
            if(!BkgAsignaciones.IsBusy)
                BkgAsignaciones.RunWorkerAsync();   
        }

        private string CrearToolTip(int idPlano, int idProceso, string proceso)
        {
            PlanoProyecto planoProyecto = new PlanoProyecto();
            planoProyecto.CargarDatos(idPlano);
            if (planoProyecto.TieneFilas())
                return idPlano + " - " +  planoProyecto.Fila().Celda("nombre_archivo").ToString().Replace("_", " ") + " | " + idProceso + " - " + proceso + Environment.NewLine;
            else
                return "";
        }

        public void MostrarPlanos()
        {
            DgvPlanos.Enabled = false;
            LblEstatus.Text = "Mostrando planos, espere...";
            Application.DoEvents();

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvPlanos);
            DgvPlanos.Rows.Clear();

            Planos.ForEach(delegate(Fila plano)
            {
                int id = Convert.ToInt32(plano.Celda("id"));
                double proyecto = Convert.ToDouble(plano.Celda("proyecto"));
                string nombre_archivo = plano.Celda("nombre_archivo").ToString();
                string estatus = plano.Celda("estatus").ToString();
                string estatusMaterial = plano.Celda("estatus_material").ToString();
                string tipo = plano.Celda("tipo").ToString();
                string cantidad = plano.Celda("cantidad").ToString();

                Object objMiniatura = null;

                if(plano.TieneCelda("miniatura"))
                    objMiniatura = plano.Celda("miniatura");

                ImageConverter converter = new ImageConverter();
                byte[] miniatura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.downloadPdf_gray, typeof(byte[]));

                if (objMiniatura != null)
                    miniatura = (byte[])objMiniatura;

                object objFechaPromesaFabricacion = plano.Celda("fecha_promesa_fabricacion");
                string fechaLimiteFabricacion = "N/A";
                DataGridViewCellStyle estiloFechaLimite = new DataGridViewCellStyle();
                
               // if( objFechaPromesaFabricacion != null )
                {
                    DateTime fechaPromesaFabricacion = Convert.ToDateTime(objFechaPromesaFabricacion);
                    fechaLimiteFabricacion = fechaPromesaFabricacion.ToString("MMM dd, yyyy");

                    if (fechaPromesaFabricacion.Date < DateTime.Now.Date && estatus != "ENTREGADO")
                    {
                        estiloFechaLimite.BackColor = Color.Red;
                        estiloFechaLimite.ForeColor = Color.White;
                    }
                    else if(fechaPromesaFabricacion.Date == DateTime.Now.Date && estatus != "ENTREGADO")
                    {
                        estiloFechaLimite.BackColor = Color.Orange;
                        estiloFechaLimite.ForeColor = Color.Black;
                    } 
                    
                    if (fechaPromesaFabricacion <= DateTime.Now.AddDays(30) )
                    {
                        PlanoProceso procesos = new PlanoProceso();
                        procesos.CargarDePlano(id);

                        string listaProcesos = string.Empty;
                        procesos.Filas().ForEach(delegate(Fila f)
                        {
                            listaProcesos += f.Celda("proceso").ToString();

                            if (procesos.Fila().Celda("estatus").ToString() == "TERMINADO")
                                listaProcesos += " ✔" + Environment.NewLine;
                            else
                                listaProcesos += Environment.NewLine;
                        });

                        if (Convert.ToDecimal(proyecto) < 63)
                        {
                            DgvPlanos.Rows.Add(id, proyecto.ToString("F2"), nombre_archivo, estatus, estatusMaterial, tipo, cantidad, plano.Celda("estatus_ensamble").ToString(), fechaLimiteFabricacion, listaProcesos, miniatura);

                            DataGridViewCell cell = DgvPlanos.Rows[DgvPlanos.RowCount - 1].Cells["estatus_ensamble"];
                            cell.Style = PlanoProyecto.Modelo().ColorEstatusEnsamble(plano.Celda("estatus_ensamble").ToString());

                            DataGridViewCell cellEstatus = DgvPlanos.Rows[DgvPlanos.RowCount - 1].Cells["estatus"];
                            cellEstatus.Style = PlanoProyecto.Modelo().ColorEstatusFabricacion(plano.Celda("estatus").ToString());

                            DataGridViewCell cellFechaLimite = DgvPlanos.Rows[DgvPlanos.RowCount - 1].Cells["fecha_limite_fabricacion"];
                            cellFechaLimite.Style = estiloFechaLimite;
                        }
                    }
                }
            });

            ConfiguracionDataGridView.Recuperar(cfg, DgvPlanos);

            DgvPlanos.Enabled = true;
            LblEstatus.Text = Planos.Count + " planos descargados en " + ((Global.MillisegundosEpoch()-InicioDescarga)/1000.0).ToString("F2") + " segundos";
            //chkVistaPrevia.Enabled = true;
            //BtnActualizar.Enabled = true;
            chkVistaPreviaToolStripMenuItem.Enabled = true;
            actualizarMonitorToolStripMenuItem.Enabled = true;
        }

        private void MenuDetallesEntregado_Click(object sender, EventArgs e)
        {
            MostrarDialogoDetalles();
        }

        public void MostrarDialogoDetalles()
        {
            FrmDetallesPlanoFabricacion detalles = new FrmDetallesPlanoFabricacion(IdPlanoCargado);
            detalles.ShowDialog();
        }

        private void MenuDetallesEnTratamiento_Click(object sender, EventArgs e)
        {
            MostrarDialogoDetalles();
        }

        private void MenuDetallesEnFabricacion_Click(object sender, EventArgs e)
        {
            MostrarDialogoDetalles();
        }

        private void MenuDetallesTerminado_Click(object sender, EventArgs e)
        {
            MostrarDialogoDetalles();
        }

        private void MenuDetallesPendiente_Click(object sender, EventArgs e)
        {
            MostrarDialogoDetalles();
        }

        private void MenuDetallesEnCotizacion_Click(object sender, EventArgs e)
        {
            MostrarDialogoDetalles();
        }

        private void MenuDetallesPendienteTratamiento_Click(object sender, EventArgs e)
        {
            MostrarDialogoDetalles();
        }

        private void MenuPlanDeTrabajo_Click(object sender, EventArgs e)
        {
            FrmPlanTrabajoPlano plan = new FrmPlanTrabajoPlano(IdPlanoCargado, false, BuscadorPlanos.Filtros);
            plan.ShowDialog();
            DescargarPlanos();
        }

        private void DgvPlanos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            EstatusPlanos = DgvPlanos.SelectedRows[0].Cells["estatus"].Value.ToString();
            IdPlanoCargado = Convert.ToInt32(DgvPlanos.Rows[0].Cells["id_plano"].Value);           
        }

        private void MenuPlanDeTrabajoEnFabricacion_Click(object sender, EventArgs e)
        {
            FrmPlanTrabajoPlano plan = new FrmPlanTrabajoPlano(IdPlanoCargado, true, BuscadorPlanos.Filtros);
            plan.ShowDialog();
            DescargarPlanos();
        }

        private void rechazarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que deseas rechazar este plano y devolverlo a documentación?", "", MessageBoxButtons.YesNo);

            if(respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(IdPlanoCargado);

                plano.Fila().ModificarCelda("estatus", "RECHAZADO");
                plano.Fila().ModificarCelda("usuario_revision", "N/A");
                plano.Fila().ModificarCelda("fecha_revision", null);

                plano.GuardarDatos();

                DescargarPlanos();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmEscanearPlano scan = new FrmEscanearPlano();
            if (scan.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int idPlano = scan.Id;
                MostrarPlanTrabajo(idPlano);
            }
        }

        private void BtnFiltrarDatos_Click(object sender, EventArgs e)
        {
            FrmFiltrarDatos filtros = new FrmFiltrarDatos(BuscadorPlanos.Filtros);

            if( filtros.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                BuscadorPlanos.Filtros = filtros.Filtros;
                DescargarPlanos();
            }
        }

        private void DgvPlanos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idPlano = Convert.ToInt32(DgvPlanos.Rows[e.RowIndex].Cells[0].Value);
                MostrarPlanTrabajo(idPlano);
            }
        }

        private void chkVistaPrevia_CheckedChanged(object sender, EventArgs e)
        {
            /*if (chkVistaPrevia.Checked)
            {
                DescargarPlanos();
            }
            DgvPlanos.Columns["miniatura"].Visible = chkVistaPrevia.Checked;*/
        }

        private void DgvPlanos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
          /*  {
                if (e.Button == MouseButtons.Right)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;*/
                    PlanoProyecto plano = new PlanoProyecto();
                    Console.Write(DgvPlanos.Rows[e.RowIndex].Cells["id_plano"].Value.ToString());
                    IdPlanoCargado = Convert.ToInt32(DgvPlanos.Rows[e.RowIndex].Cells["id_plano"].Value);     
                  /*  switch (EstatusPlanos)
                    {
                        case "PENDIENTE":
                        case "EN COTIZACION":
                        case "EN PREPARACION":
                            MenuOpcionesPlanoPendiente.Show(mouseX, mouseY);
                            break;

                        case "EN FABRICACION":
                            MenuOpcionesEnFabricacion.Show(mouseX, mouseY);
                            break;

                        case "PENDIENTE DE TRATAMIENTO":
                            MenuOpcionesPendienteTratamiento.Show(mouseX, mouseY);
                            break;

                        case "TERMINADO":
                            MenuOpcionesTerminado.Show(mouseX, mouseY); 
                            break;

                        case "ENTREGADO":
                            MenuOpcionesEntregado.Show(mouseX, mouseY);
                            break;

                        case "EN TRATAMIENTO":
                            MenuOpcionesEnTratamiento.Show(mouseX, mouseY);
                            break;
                    }
                }
            }*/
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            DescargarPlanos();
        }

        private void planDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarPlanTrabajo(IdPlanoCargado);
        }

        public void MostrarPlanTrabajo(int idPlano)
        {
            FrmPlanTrabajoPlano plan = new FrmPlanTrabajoPlano(idPlano, true, BuscadorPlanos.Filtros);
            plan.ShowDialog();
            DescargarPlanos();
        }

        private void planDeTrabajoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPlanTrabajoPlano plan = new FrmPlanTrabajoPlano(IdPlanoCargado, true, BuscadorPlanos.Filtros);
            plan.ShowDialog();
            DescargarPlanos();
        }

        private void BtnActualizarProceso_Click(object sender, EventArgs e)
        {
            FrmAsignarProcesoFabricacion ap = new FrmAsignarProcesoFabricacion();

            if( ap.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                
            }
        }

        private void BtnValesSalida_Click(object sender, EventArgs e)
        {
            FrmEntregarPiezaFabricada vales = new FrmEntregarPiezaFabricada();
            vales.ShowDialog();
            DescargarPlanos();
        }

        private void planDeTrabajoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmPlanTrabajoPlano plan = new FrmPlanTrabajoPlano(IdPlanoCargado, true, BuscadorPlanos.Filtros);
            plan.ShowDialog();
            DescargarPlanos();
        }

        private void cancelarFabricacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que deseas rechazar este plano y devolverlo a documentación?", "", MessageBoxButtons.YesNo);

            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(IdPlanoCargado);

                plano.Fila().ModificarCelda("estatus", "RECHAZADO");
                plano.Fila().ModificarCelda("usuario_revision", "N/A");
                plano.Fila().ModificarCelda("fecha_revision", null);

                plano.GuardarDatos();

                DescargarPlanos();
            }
        }

        public void DescargarPlanos()
        {
            chkVistaPreviaToolStripMenuItem.Enabled = false;
            actualizarMonitorToolStripMenuItem.Enabled = false;
            ProgresoDescarga.Visible = true;
            InicioDescarga = Global.MillisegundosEpoch();
            BkgCargarPlanos.RunWorkerAsync();
        }

        private void BkgCargarPlanos_DoWork(object sender, DoWorkEventArgs e)
        {
            string columnas = "planos_proyectos.*";

            if (chkVistaPreviaToolStripMenuItem.Checked == true) 
                columnas += ", (SELECT miniatura FROM archivos_planos WHERE planos_proyectos.id=archivos_planos.plano LIMIT 1) AS miniatura";

            Planos = BuscadorPlanos.SeleccionarDatos("proyecto<63.02", null, columnas, BkgCargarPlanos);
        }

        private void BkgCargarPlanos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Descarga completa!";
            MostrarPlanos();
        }

        private void BkgCargarPlanos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            Fila lafila = (Fila)e.UserState;
            
            LblEstatus.Text = "Descargando planos... [" + e.ProgressPercentage + "%]";
        }

        private void FrmMonitorFabricacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerRefresh.Tick -= TimerRefresh_Tick;
            BkgCargarPlanos.CancelAsync();
            BkgCargarPlanos.Dispose();
        }

        private void BtnProduccion_Click(object sender, EventArgs e)
        {
            FrmProduccion prod = new FrmProduccion();
            prod.Show();
        }

        private void BtnMantenimientoCorrectivo_Click(object sender, EventArgs e)

        {
            DialogResult result = MessageBox.Show("¿Está seguro de generar una orden de mantenimiento correctivo a una máquina?", "Orden de mantenimiento correctivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                FrmGenerarOrdenMtoEquipoComputo ordenMantenimiento = new FrmGenerarOrdenMtoEquipoComputo("MAQUINARIA", "");
                ordenMantenimiento.Show();
            }
        }

        private void BtnTerminal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea entrar a la terminal de producción?, para salir de éste modo deberá ingresar su contraseña", "Modo terminal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                FrmTerminalFabricacion terminal = new FrmTerminalFabricacion();
                terminal.ShowDialog();
            }
        }

        private void TimerRefresh_Tick(object sender, EventArgs e)
        {
            RefrescarContador--;
            if(RefrescarContador == 1)
            {
                if (!BkgRefrescarAsignaciones.IsBusy)
                    BkgRefrescarAsignaciones.RunWorkerAsync();
                else
                    RefrescarContador = IntervaloActualizarAsignaciones;
            }
        }

        private void MenuOpcionesPlanoPendiente_Opening(object sender, CancelEventArgs e)
        {
            int mouseX = Cursor.Position.X;
            int mouseY = Cursor.Position.Y;

            MenuDetallesPendiente.Visible = false;
            MenuPlanDeTrabajo.Visible = false;
            cancelarFabricacónToolStripMenuItem.Visible = false;
            rechazarToolStripMenuItem.Visible = false;

            switch (EstatusPlanos)
            {
                case "PENDIENTE":
                case "EN COTIZACION":
                case "EN PREPARACION":
                    MenuDetallesPendiente.Visible = true;
                    MenuPlanDeTrabajo.Visible = true;
                    cancelarFabricacónToolStripMenuItem.Visible = true;
                    rechazarToolStripMenuItem.Visible = true;
                    break;

                case "EN FABRICACION":
                    MenuDetallesPendiente.Visible = true;
                    MenuPlanDeTrabajo.Visible = true;
                    cancelarFabricacónToolStripMenuItem.Visible = true;
                    rechazarToolStripMenuItem.Visible = false;
                    break;

                case "PENDIENTE DE TRATAMIENTO":
                    MenuDetallesPendiente.Visible = true;
                    MenuPlanDeTrabajo.Visible = true;
                    cancelarFabricacónToolStripMenuItem.Visible = true;
                    rechazarToolStripMenuItem.Visible = false;
                    break;

                case "TERMINADO":
                    MenuDetallesPendiente.Visible = true;
                    MenuPlanDeTrabajo.Visible = true;
                    cancelarFabricacónToolStripMenuItem.Visible = false;
                    rechazarToolStripMenuItem.Visible = false;
                    break;

                case "ENTREGADO":
                    MenuDetallesPendiente.Visible = true;
                    MenuPlanDeTrabajo.Visible = true;
                    cancelarFabricacónToolStripMenuItem.Visible = false;
                    rechazarToolStripMenuItem.Visible = false;
                    break;

                case "EN TRATAMIENTO":
                    MenuDetallesPendiente.Visible = true;
                    MenuPlanDeTrabajo.Visible = false;
                    cancelarFabricacónToolStripMenuItem.Visible = false;
                    rechazarToolStripMenuItem.Visible = false;
                    break;
            }
        }

        private void actualizarProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAsignarProcesoFabricacion ap = new FrmAsignarProcesoFabricacion();

            if (ap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFiltrarDatos filtros = new FrmFiltrarDatos(BuscadorPlanos.Filtros);

            if (filtros.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscadorPlanos.Filtros = filtros.Filtros;
                DescargarPlanos();
            }
        }

        private void actualizarMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescargarPlanos();
        }

        private void MenuCancelarPiezaTratamieto_Click(object sender, EventArgs e)
        {
        }

        private void cancelarFabricacónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que deseas rechazar este plano y devolverlo a documentación?", "", MessageBoxButtons.YesNo);

            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(IdPlanoCargado);

                plano.Fila().ModificarCelda("estatus", "RECHAZADO");
                plano.Fila().ModificarCelda("usuario_revision", "N/A");
                plano.Fila().ModificarCelda("fecha_revision", null);

                plano.GuardarDatos();
                DescargarPlanos();
            }
        }

        private void checkToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVistaPreviaToolStripMenuItem.Checked) //chkVistaPrevia
            {
                DescargarPlanos();
            }
            DgvPlanos.Columns["miniatura"].Visible = chkVistaPreviaToolStripMenuItem.Checked; //chkVistaPrevia
        }

        private void DgvAsignaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            int procesosEnEspera = Convert.ToInt32(DgvAsignaciones.Rows[e.RowIndex].Cells["procesos_en_espera"].Value);

            DataGridViewCell cell;
            if (procesosEnEspera == 0)
            {
                cell = DgvAsignaciones.Rows[e.RowIndex].Cells["procesos_en_espera"];
                cell.Style.BackColor = Color.LightCoral;
            }
        }

        private void DtpDesde_ValueChanged(object sender, EventArgs e)
        {
           // CargarAsignaciones();
        }

        private void DtpHasta_ValueChanged(object sender, EventArgs e)
        {
            //CargarAsignaciones();
        }

        private void CargarAsignacionesTabla(bool reportarProgreso, BackgroundWorker bkg = null)
        {
            Usuario usuario = new Usuario();
            int avance = 0;
            int porcentaje = 0;

            usuario.SeleccionarRolActivos("TECNICO HERRAMENTISTA").ForEach(delegate(Fila filaRol)
            {
                int proceso = 0;
                int procesosEnCurso = 0;
                int procesosDetenidos = 0;
                int procesosEnEspera = 0;
                int procesosTerminados = 0;
                string fechaTerminoPlanosProcesos = string.Empty;
                //string tiempoTrabajoReal = string.Empty;
                string toolTipProcesoTerminado = string.Empty;
                string toolTipProcesoEnProceso = string.Empty;
                string toolTipProcesoDetenido = string.Empty;
                string toolTipProcesoAsignado = string.Empty;

                //Calcular tiempos
                //string strTiempoMuerto = "N/A";
                //string strTiempoTotalFabricacion = "N/A";
                //string strTiempoFabricacion = "N/A";
                //TimeSpan tiempoMuerto = TimeSpan.Parse("00:00:00");
                //TimeSpan sumaFabricacion = TimeSpan.Parse("00:00:00");

                PlanoProceso planoProceso = new PlanoProceso();
                planoProceso.CargarProcesosDelHerramentista(Convert.ToInt32(filaRol.Celda("id"))).ForEach(delegate(Fila filaProceso)
                {
                    if (Global.ObjetoATexto(filaProceso.Celda("estatus"), "N/A") == "EN PROCESO")
                        procesosEnCurso++;
                    else if (Global.ObjetoATexto(filaProceso.Celda("estatus"), "N/A") == "DETENIDO")
                        procesosDetenidos++;
                    else if (Global.ObjetoATexto(filaProceso.Celda("estatus"), "N/A") == "ASIGNADO")
                        procesosEnEspera++;
                    else if (Global.ObjetoATexto(filaProceso.Celda("estatus"), "N/A") == "TERMINADO")
                        procesosTerminados++;

                    proceso = Convert.ToInt32(filaProceso.Celda("id"));
                    string herramentista = filaRol.Celda("id").ToString();

                    //calcular tiempo muerto 
                    //Horario de comida no cuenta como tiempo muerto
                    //El tiempo muerto de uso de baño cuenta a partir del minuto 10   
                    //TiempoMuerto tmpMuerto = new TiempoMuerto();
                    //tmpMuerto.CargarTiempoMuertoFechaEspecifica(proceso, Convert.ToDateTime(DtpDesde.Value), Convert.ToDateTime(DtpHasta.Value)).ForEach(delegate(Fila filaTiempoMuerto)
                    //{
                    //    DateTime fin;
                    //    if (Global.ObjetoATexto(filaTiempoMuerto.Celda("fin"), "N/A") != "N/A")
                    //        fin = Convert.ToDateTime(filaTiempoMuerto.Celda("fin"));
                    //    else
                    //        fin = DateTime.Now;

                    //    TimeSpan diferencia = fin - Convert.ToDateTime(filaTiempoMuerto.Celda("inicio").ToString());
                    //    // tiempoMuerto = tiempoMuerto.Add(diferencia);

                    //    RazonTiempoMuerto razonTiempoMurto = new RazonTiempoMuerto();
                    //    razonTiempoMurto.CargarDatos(Convert.ToInt32(filaTiempoMuerto.Celda("razon")));
                    //    if (razonTiempoMurto.TieneFilas())
                    //    {
                    //        if (razonTiempoMurto.Fila().Celda("razon").ToString() != "HORA DE COMIDA" && razonTiempoMurto.Fila().Celda("razon").ToString() != "BAÑO")
                    //            tiempoMuerto = tiempoMuerto.Add(diferencia);
                    //        else if (razonTiempoMurto.Fila().Celda("razon").ToString() == "BAÑO" || razonTiempoMurto.Fila().Celda("razon").ToString() == "HORA DE COMIDA")
                    //        {
                    //            TimeSpan tiempo = TimeSpan.Parse("00:00:00");

                    //            if (razonTiempoMurto.Fila().Celda("razon").ToString() == "BAÑO")
                    //                tiempo = TimeSpan.Parse("00:10:00");
                    //            else
                    //                tiempo = TimeSpan.Parse("01:0:00"); //HORA DE COMIDA

                    //            if (tiempo < diferencia) //TimeSpan.Parse("00:10:00")
                    //            {
                    //                TimeSpan tiempoMuertoBanio = diferencia - tiempo;//TimeSpan.Parse("00:10:00");
                    //                tiempoMuerto = tiempoMuerto.Add(tiempoMuertoBanio);
                    //            }
                    //        }
                    //    }
                    //});

                    ////fecha trabajo real de fabricación, si no tiene fecha tiempo trabajo real si no lo tiene se calcula con la fecha actual
                    //tiempoTrabajoReal = Global.ObjetoATexto(filaProceso.Celda("tiempo_trabajo_real"), "0.00").ToString();

                    //TiempoFabricacion tiempoFabricacion = new TiempoFabricacion();
                    //tiempoFabricacion.CargarFechaInicio(proceso, Convert.ToDateTime(DtpDesde.Value), Convert.ToDateTime(DtpHasta.Value));
                    //if (tiempoFabricacion.TieneFilas())
                    //{
                    //    if (tiempoTrabajoReal != "0.00")
                    //    {
                    //        TimeSpan tiempoFin = TimeSpan.FromHours(Convert.ToDouble(tiempoTrabajoReal));
                    //        sumaFabricacion = sumaFabricacion.Add(tiempoFin);
                    //    }
                    //}

                    //tooltip
                    if (filaProceso.Celda("estatus").ToString() == "TERMINADO")
                        toolTipProcesoTerminado += CrearToolTip(Convert.ToInt32(filaProceso.Celda("plano")), Convert.ToInt32(filaProceso.Celda("id")), filaProceso.Celda("proceso").ToString());
                    if (filaProceso.Celda("estatus").ToString() == "EN PROCESO")
                        toolTipProcesoEnProceso += CrearToolTip(Convert.ToInt32(filaProceso.Celda("plano")), Convert.ToInt32(filaProceso.Celda("id")), filaProceso.Celda("proceso").ToString());
                    if (filaProceso.Celda("estatus").ToString() == "DETENIDO")
                        toolTipProcesoDetenido += CrearToolTip(Convert.ToInt32(filaProceso.Celda("plano")), Convert.ToInt32(filaProceso.Celda("id")), filaProceso.Celda("proceso").ToString());
                    if (filaProceso.Celda("estatus").ToString() == "ASIGNADO")
                        toolTipProcesoAsignado += CrearToolTip(Convert.ToInt32(filaProceso.Celda("plano")), Convert.ToInt32(filaProceso.Celda("id")), filaProceso.Celda("proceso").ToString());
                });

                //if (tiempoMuerto.ToString() != "00:00:00")
                //    strTiempoMuerto = tiempoMuerto.ToString("hh\\:mm") + " Hrs";

                //if (sumaFabricacion.ToString() != "00:00:00")
                //    strTiempoTotalFabricacion = sumaFabricacion.ToString("hh\\:mm") + " Hrs";

                //if (strTiempoTotalFabricacion != "N/A" && strTiempoMuerto != "N/A")
                //    strTiempoFabricacion = (TimeSpan.Parse(strTiempoTotalFabricacion.Split(' ')[0] + ":00") - TimeSpan.Parse(strTiempoMuerto.Split(' ')[0] + ":00")).ToString("hh\\:mm") + " Hrs";
                //else
                //    strTiempoFabricacion = strTiempoTotalFabricacion;

                //Mostrar resultados
                Fila insertarAsignaciones = new Fila();
                insertarAsignaciones.AgregarCelda("id", filaRol.Celda("id").ToString());
                insertarAsignaciones.AgregarCelda("nombre", filaRol.Celda("id") + " - " + Global.ObjetoATexto(filaRol.Celda("nombre"), "N/A") + " " + Global.ObjetoATexto(filaRol.Celda("paterno"), "N/A"));
                insertarAsignaciones.AgregarCelda("procesos_en_curso", procesosEnCurso);
                insertarAsignaciones.AgregarCelda("procesos_detenidos", procesosDetenidos);
                insertarAsignaciones.AgregarCelda("procesos_en_espera", procesosEnEspera);
                insertarAsignaciones.AgregarCelda("procesos_terminados", procesosTerminados);
                insertarAsignaciones.AgregarCelda("tiempo_muerto", 0);
                insertarAsignaciones.AgregarCelda("tiempo_fabricacion", 0);
                insertarAsignaciones.AgregarCelda("tiempo_total_fabricacion", 0);
                insertarAsignaciones.AgregarCelda("tooTip_proceso_terminado", toolTipProcesoTerminado);
                insertarAsignaciones.AgregarCelda("toolTip_en_proceso", toolTipProcesoEnProceso);
                insertarAsignaciones.AgregarCelda("toolTip_proceso_detenido", toolTipProcesoDetenido);
                insertarAsignaciones.AgregarCelda("toolTip_procesoAsignado", toolTipProcesoAsignado);
                ListaAsiganacion.Add(insertarAsignaciones);

                if (reportarProgreso)
                {
                    porcentaje = Global.CalcularPorcentaje(avance, usuario.Filas().Count);
                    bkg.ReportProgress(porcentaje);
                    avance++;
                }
            });
        }

        private void BkgAsignaciones_DoWork(object sender, DoWorkEventArgs e)
        {
            ListaAsiganacion.Clear();
            CargarAsignacionesTabla(true, BkgAsignaciones);           
        }

        private void BkgAsignaciones_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BarraProgresoAsignaciones.Value = e.ProgressPercentage;
            if(DgvAsignaciones.Rows.Count <= 0 )
                LblEstatusAsignaciones.Text = "Mostrando asignaciones... [" + e.ProgressPercentage + "%]";
        }

        private void BkgAsignaciones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           try
            {
                BarraProgresoAsignaciones.Visible = false;
                BarraProgresoAsignaciones.Value = 0;

                LblEstatusAsignaciones.Text = "Asignaciones descargadas correctamente";

                ListaAsiganacion.ForEach(delegate(Fila f)
                {
                    DgvAsignaciones.Rows.Add(f.Celda("id"),
                                                f.Celda("nombre"),
                                                f.Celda("procesos_en_curso"),
                                                f.Celda("procesos_detenidos"),
                                                f.Celda("procesos_en_espera"),
                                                f.Celda("procesos_terminados"),
                                                f.Celda("tiempo_muerto"),
                                                f.Celda("tiempo_fabricacion"),
                                                f.Celda("tiempo_total_fabricacion"));



                    if (f.Celda("tooTip_proceso_terminado").ToString() != "")
                    {
                        DataGridViewCell cell = DgvAsignaciones.Rows[Row].Cells["procesos_terminados"];
                        cell.ToolTipText = f.Celda("tooTip_proceso_terminado").ToString();
                    }
                    if (f.Celda("toolTip_proceso_detenido").ToString() != "")
                    {
                        DataGridViewCell cell = DgvAsignaciones.Rows[Row].Cells["procesos_detenidos"];
                        cell.ToolTipText = f.Celda("toolTip_proceso_detenido").ToString();
                    }
                    if (f.Celda("toolTip_en_proceso").ToString() != "")
                    {
                        DataGridViewCell cell = DgvAsignaciones.Rows[Row].Cells["procesos_en_curso"];
                        cell.ToolTipText = f.Celda("toolTip_en_proceso").ToString();
                    }
                    if (f.Celda("toolTip_procesoAsignado").ToString() != "")
                    {
                        DataGridViewCell cell = DgvAsignaciones.Rows[Row].Cells["procesos_en_espera"];
                        cell.ToolTipText = f.Celda("toolTip_procesoAsignado").ToString();
                    }
                    Row++;

                    TimerRefresh.Tick += new EventHandler(TimerRefresh_Tick);
                });
            }
            catch
           {
                //se cierra el form cuando está cargando datos al DataGridView
           }
        }

        private void BkgRefrescarAsignaciones_DoWork(object sender, DoWorkEventArgs e)
        {
            ListaAsiganacion.Clear();
            CargarAsignacionesTabla(false); 
        }

        private void BkgRefrescarAsignaciones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int row = 0;

            if(DgvAsignaciones.Rows.Count != ListaAsiganacion.Count)
            {
                RefrescarContador = IntervaloActualizarAsignaciones;
                TimerRefresh.Tick -= TimerRefresh_Tick;
                ListaAsiganacion.Clear();
                CargarAsignaciones();
                
                return;
            }

            ListaAsiganacion.ForEach(delegate(Fila f)
            {
                DgvAsignaciones.Rows[row].Cells["id"].Value = Global.ObjetoATexto(f.Celda("id"), "");
                DgvAsignaciones.Rows[row].Cells["herramentista"].Value = Global.ObjetoATexto(f.Celda("nombre"), "");
                DgvAsignaciones.Rows[row].Cells["procesos_en_curso"].Value = Global.ObjetoATexto(f.Celda("procesos_en_curso"), "");
                DgvAsignaciones.Rows[row].Cells["procesos_detenidos"].Value = Global.ObjetoATexto(f.Celda("procesos_detenidos"), "");
                DgvAsignaciones.Rows[row].Cells["procesos_en_espera"].Value = Global.ObjetoATexto(f.Celda("procesos_en_espera"), "");
                DgvAsignaciones.Rows[row].Cells["procesos_terminados"].Value = Global.ObjetoATexto(f.Celda("procesos_terminados"), "");
                DgvAsignaciones.Rows[row].Cells["tiempo_muerto"].Value = Global.ObjetoATexto(f.Celda("tiempo_muerto"), "");
                DgvAsignaciones.Rows[row].Cells["tiempo_fabricacion"].Value = Global.ObjetoATexto(f.Celda("tiempo_fabricacion"), "");
                DgvAsignaciones.Rows[row].Cells["tiempo_total"].Value = Global.ObjetoATexto(f.Celda("tiempo_total_fabricacion"), "");


                if (f.Celda("tooTip_proceso_terminado").ToString() != "")
                {
                    DataGridViewCell cell = DgvAsignaciones.Rows[row].Cells["procesos_terminados"];
                    cell.ToolTipText = f.Celda("tooTip_proceso_terminado").ToString();
                }
                if (f.Celda("toolTip_proceso_detenido").ToString() != "")
                {
                    DataGridViewCell cell = DgvAsignaciones.Rows[row].Cells["procesos_detenidos"];
                    cell.ToolTipText = f.Celda("toolTip_proceso_detenido").ToString();
                }
                if (f.Celda("toolTip_en_proceso").ToString() != "")
                {
                    DataGridViewCell cell = DgvAsignaciones.Rows[row].Cells["procesos_en_curso"];
                    cell.ToolTipText = f.Celda("toolTip_en_proceso").ToString();
                }
                if (f.Celda("toolTip_procesoAsignado").ToString() != "")
                {
                    DataGridViewCell cell = DgvAsignaciones.Rows[row].Cells["procesos_en_espera"];
                    cell.ToolTipText = f.Celda("toolTip_procesoAsignado").ToString();
                }

                DataGridViewCell celdaColor = DgvAsignaciones.Rows[row].Cells["procesos_en_espera"];

                if (Convert.ToInt32(Global.ObjetoATexto(f.Celda("procesos_en_espera"), "0")) == 0)
                    celdaColor.Style.BackColor = Color.LightCoral;
                else
                    celdaColor.Style.BackColor = Color.White;

                row++;

            });
            RefrescarContador = 120;
        }

        private void BtnKpis_Click(object sender, EventArgs e)
        {
            FrmBuscadorKPIs kpis = new FrmBuscadorKPIs(1);
            kpis.Show();
        }

        private void BtnMetas_Click(object sender, EventArgs e)
        {
            FrmMetasFabricacion metas = new FrmMetasFabricacion();
            metas.Show();
        }
    }
}
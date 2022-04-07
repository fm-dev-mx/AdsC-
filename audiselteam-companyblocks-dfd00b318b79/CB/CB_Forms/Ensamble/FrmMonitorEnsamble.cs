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
    public partial class FrmMonitorEnsamble : Ventana
    {
        private int ParteSeleccionada = 0;
        private int IdTablaMaterial = 0;
        private int IdActividad = 0;
        private int ScrollPosicionEnsamble = 0;
        private int ScrollPosicionPartes = 0;
        private int ScrollPosicion = 0;
        private int ScrollPosicionActividad = 0;
 
        private string EstatusEnsamble = "";
        private string EstatusActividad = "";
        private string TipoActividad = "";
        private string EstatusAlmacen = "";
        private string UsuarioActividad = "";

        private decimal ProyectoSeleccionado = 0;
        private decimal ProyectoActividad = 0;

        private bool FilaClick = false;

        List<Fila> Planos = new List<Fila>();
        double InicioDescarga;

        List<Fila> PiezasCompradas = new List<Fila>();
       
        PlanoProyecto BuscadorPlanos = new PlanoProyecto();
        MaterialProyecto BuscadorMateriales = new MaterialProyecto();
        ActividadEnsamble BuscadorActividad = new ActividadEnsamble();
          
        public FrmMonitorEnsamble(List<Filtro> filtros = null)
        {
            InitializeComponent();
            if (filtros == null)
            {
                BuscadorPlanos.Filtros.Add(new Filtro("proyecto", "Proyecto", BuscadorPlanos.Proyectos()));
                BuscadorPlanos.Filtros[0].DesactivarTodos();

                BuscadorPlanos.Filtros.Add(new Filtro("tipo", "Tipo de trabajo", BuscadorPlanos.TiposDeTrabajo()));
                BuscadorPlanos.Filtros.Add(new Filtro("estatus", "Estatus de fabricación", BuscadorPlanos.EstatusFabricacion()));
                BuscadorPlanos.Filtros.Add(new Filtro("estatus_ensamble", "Estatus de ensamble", BuscadorPlanos.EstatusEnsamble()));
                BuscadorPlanos.Filtros.Add(new Filtro("subensamble", "Subensamble", BuscadorPlanos.Subensambles()));
                
                BuscadorMateriales.Filtros.Add(new Filtro("proyecto", "Proyecto", BuscadorMateriales.Proyectos()));
                BuscadorMateriales.Filtros[0].DesactivarTodos();
                BuscadorMateriales.Filtros.Add(new Filtro("numero_parte", "Número de parte", BuscadorMateriales.NumeroParte()));
                BuscadorMateriales.Filtros.Add(new Filtro("estatus_almacen", "Estatus de almacén", BuscadorMateriales.EstatusAlmacen()));
                BuscadorMateriales.Filtros.Add(new Filtro("estatus_ensamble", "Estatus de ensamble", BuscadorMateriales.EstatusEnsamble()));

                BuscadorActividad.Filtros.Add(new Filtro("proyecto", "Proyecto", BuscadorActividad.Proyecto()));
                BuscadorActividad.Filtros.Add(new Filtro("tipo", "Tipo de actividad", BuscadorActividad.TipoActividad()));
                BuscadorActividad.Filtros.Add(new Filtro("estatus", "Estatus de actividad", BuscadorActividad.Estatus()));
                BuscadorActividad.Filtros[2].ModificarFiltro("TERMINADO", false);

                BuscadorActividad.Filtros.Add(new Filtro("estatus_revision", "Estatus de revisión de actividad", BuscadorActividad.EstatusRevision()));
            }
            else
            {
                BuscadorPlanos.Filtros = filtros;
            }
        }

        private void FrmMonitorEnsamble1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Fix(splitContainer9);
            Fix(splitContainer6);
            Fix(splitContainer10);
            Fix(splitContainer5);
            Fix(splitContainer8);
            
            chkVistaPrevia.Checked = false;
            if (chkVistaPrevia.Checked)
                DgvPartes.Columns["miniatura"].Visible = true;

            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2.Hide();
            splitContainer3.Panel1Collapsed = false;
            splitContainer3.Panel1.Show();
        }

        public void MostrarPlano(int IdPlano)
        {
            BtnOpcionesParte.Enabled = true;
            PlanoProyecto plano = new PlanoProyecto();            
            ArchivoPlano archivo = new ArchivoPlano();

            plano.CargarDatos(IdPlano);
            archivo.SeleccionarDePlano(IdPlano);

            if(plano.TieneFilas() && archivo.TieneFilas())
            {
                Global.MostrarPDF((byte[])archivo.Fila().Celda("archivo"), plano.Fila().Celda("nombre_archivo").ToString(), null, VisorPDF);
                object objComentarios = plano.Fila().Celda("comentarios_ensamble");

                if (objComentarios != null)
                    TxtComentarios.Text = objComentarios.ToString();

                descartadoToolStripMenuItem.Enabled = plano.Fila().Celda("estatus").ToString() == "ENTREGADO";
            }
            LblCargandoPlano.Visible = false;           
        }

        public void BorrarPlano()
        {
            LblNumeroPlano.Text = "SELECCIONA UN PLANO";
            VisorPDF.LoadFile("none");
        }

        public void CargarPlanos()
        {
            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2.Hide();
            splitContainer3.Panel1Collapsed = false;
            splitContainer3.Panel1.Show();

            //string columnas = "planos_proyectos.*, ";
            //columnas += "(SELECT miniatura FROM archivos_planos WHERE planos_proyectos.id=archivos_planos.plano) AS miniatura";

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvPartes);

            DgvPartes.Rows.Clear();
            Planos.ForEach(delegate(Fila plano)
            {
                int id = Convert.ToInt32(plano.Celda("id"));
                string nombre_archivo = plano.Celda("nombre_archivo").ToString();
                string tipo = plano.Celda("tipo").ToString();
                string estatus = plano.Celda("estatus").ToString();
                string estatus_ensamble = plano.Celda("estatus_ensamble").ToString();

                Object objMiniatura = plano.Celda("miniatura");

                ImageConverter converter = new ImageConverter();
                byte[] miniatrura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.downloadPdf_gray, typeof(byte[]));

                if (objMiniatura != null)
                    miniatrura = (byte[])objMiniatura;

                DgvPartes.Rows.Add(id, nombre_archivo, tipo, estatus, estatus_ensamble, miniatrura); 

                DataGridViewCell cellEstatusEnsamble = DgvPartes.Rows[DgvPartes.RowCount - 1].Cells["estatus_ensamble"];
                cellEstatusEnsamble.Style = PlanoProyecto.Modelo().ColorEstatusEnsamble(plano.Celda("estatus_ensamble").ToString());
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvPartes);
        }

        private void CargarRequisiciones()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvEstatusEnsamble);

            DgvEstatusEnsamble.Rows.Clear();    
            PiezasCompradas.ForEach(delegate(Fila materialProyecto)
            {             
                int id_material = Convert.ToInt32(materialProyecto.Celda("id"));
                decimal proyecto = Convert.ToDecimal(materialProyecto.Celda("proyecto"));
                string requisitor = materialProyecto.Celda("requisitor").ToString();
                string numero_parte = materialProyecto.Celda("numero_parte").ToString();
                string estatus_almacen = materialProyecto.Celda("estatus_almacen").ToString();
                string estatus_Ensamble = materialProyecto.Celda("estatus_ensamble").ToString();
                string descripcion = materialProyecto.Celda("descripcion").ToString();

                object objFechaPromesa = materialProyecto.Celda("fecha_promesa_ensamble");
                string fechaPromesa = "N/A";

                if( objFechaPromesa != null )
                {
                    fechaPromesa = Convert.ToDateTime(objFechaPromesa).ToString("MMM dd, yyyy");
                }

                DgvEstatusEnsamble.Rows.Add(id_material, proyecto.ToString("F2"), requisitor, numero_parte, descripcion, estatus_almacen, estatus_Ensamble, fechaPromesa);

                DataGridViewCell cell = DgvEstatusEnsamble.Rows[DgvEstatusEnsamble.RowCount - 1].Cells["ENSAMBLE_ESTATUS"];
                cell.Style = MaterialProyecto.Modelo().ColorEstatusEnsamble(materialProyecto.Celda("estatus_ensamble").ToString());
          
            });                  
            DeshabilitarBotones();
            ConfiguracionDataGridView.Recuperar(cfg, DgvEstatusEnsamble);
        }

        void DeshabilitarBotones()
        {
            BtnEnsamblado.Enabled = false;
            BtnRecibido.Enabled = false;
            BtnPerdido.Enabled = false;
            BtnFechaPromesa.Enabled = false;
        }

        private void HabilitarBotones(string estatusAlmacen)
        {
            if (estatusAlmacen != "ENSAMBLADO")
            {
                switch (estatusAlmacen)
                {
                    case "N/A":
                    case "SIN RECIBIR":
                        BtnEnsamblado.Enabled = false;
                        BtnRecibido.Enabled = true;
                        BtnPerdido.Enabled = false;
                        break;

                    case "ENSAMBLADO":
                        BtnEnsamblado.Enabled = false;
                        BtnRecibido.Enabled = false;
                        BtnPerdido.Enabled = false;
                        break;

                    case "RECIBIDO":
                        BtnEnsamblado.Enabled = true;
                        BtnRecibido.Enabled = false;
                        BtnPerdido.Enabled = true;
                        break;

                    case "PERDIDO":
                        BtnEnsamblado.Enabled = false;
                        BtnRecibido.Enabled = true;
                        BtnPerdido.Enabled = false;
                        break;
                }
            }
            else
            {
                BtnEnsamblado.Enabled = false;
                BtnRecibido.Enabled = false;
                BtnPerdido.Enabled = false;
            }
            BtnFechaPromesa.Enabled = true;
        }

        private void CargarDatosActividad()
        {
            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvActividades);
            int id = 1;

            DgvActividades.Rows.Clear();
            BuscadorActividad.SeleccionarDatos("").ForEach(delegate(Fila actividadEnsamble)
            {
                int id_actividades = Convert.ToInt32(actividadEnsamble.Celda("id"));
                string proyecto = Convert.ToDecimal(actividadEnsamble.Celda("proyecto")).ToString("F2");               
                string tipo = actividadEnsamble.Celda("tipo").ToString();
                string descripcion = actividadEnsamble.Celda("descripcion_actividad").ToString();
                string responsable = actividadEnsamble.Celda("responsable").ToString();
                string estatus = actividadEnsamble.Celda("estatus").ToString();
                string estatus_revision = actividadEnsamble.Celda("estatus_revision").ToString();

                Object comentariosRev = actividadEnsamble.Celda("comentarios_revision");
                Object fa = actividadEnsamble.Celda("fecha_asignacion");
                Object fp = actividadEnsamble.Celda("fecha_promesa");
                Object ft = actividadEnsamble.Celda("fecha_termino");

                string comentariosRevision = "N/A";
                string fechaAsignacion = "N/A";
                string fechaPromesa = "N/A";
                string fechaTermino = "N/A";

                if (comentariosRev != null)
                    comentariosRevision = actividadEnsamble.Celda("comentarios_revision").ToString();
                              
                if(fa != null)
                    fechaAsignacion = Convert.ToDateTime(fa).ToString("MMM dd, yyyy hh:mm:ss tt");               
                
                if (fp != null)
                    fechaPromesa = Convert.ToDateTime(fp).ToString("MMM dd, yyyy hh:mm:ss tt");
                          
                if (ft != null)
                    fechaTermino = Convert.ToDateTime(ft).ToString("MMM dd, yyyy hh:mm:ss tt");

                DgvActividades.Rows.Add(id_actividades, id_actividades, proyecto, tipo, descripcion, responsable, estatus, fechaAsignacion, fechaPromesa, fechaTermino, estatus_revision, comentariosRev);

                DataGridViewCell cellEstatusActividad = DgvActividades.Rows[DgvActividades.RowCount - 1].Cells["estatus_actividad"];                
                DataGridViewCell cellEstatusRevision = DgvActividades.Rows[DgvActividades.RowCount - 1].Cells["estatus_revision"];
               
                cellEstatusActividad.Style = ActividadEnsamble.Modelo().ColorEstatusActividad(actividadEnsamble.Celda("estatus").ToString());
                cellEstatusRevision.Style = ActividadEnsamble.Modelo().ColorEstatusRevision(actividadEnsamble.Celda("estatus_revision").ToString());
                Global.RecuperarFilaSeleccionada(DgvActividades, filaSeleccionada);
                id++;               
            });

            LblTituloActividad.Text = "SELECCIONE UNA ACTIVIDAD";
        }  

        public void RevisarActividad(string estatus, string comentarios)
        {
            BuscadorActividad.CargarDatos(IdActividad);
            if (BuscadorActividad.TieneFilas())
            {
                BuscadorActividad.Fila().ModificarCelda("estatus_revision", estatus);
                BuscadorActividad.Fila().ModificarCelda("comentarios_revision", comentarios);
                BuscadorActividad.GuardarDatos();
                CargarDatosActividad();
            }
        }

        public void LimpiarDgvActividades()
        {            
            MenuAsignar.Enabled = false;
            MenuEditar.Enabled = false;
            MenuAsignar.Enabled = false;
            MenuSeguimiento.Enabled = false;
            MenuRevisar.Enabled = false;
        }

        private void BtnEnsamblado_Click(object sender, EventArgs e)
        {
            BuscadorMateriales.CargarDatos(IdTablaMaterial);
            BuscadorMateriales.Fila().ModificarCelda("estatus_ensamble", "ENSAMBLADO");
            BuscadorMateriales.GuardarDatos();
            //CargarRequisiciones();
            InicioDescarga = Global.MillisegundosEpoch();
            BkgPiezasCompradas.RunWorkerAsync();
        }

        private void BtnRecibido_Click(object sender, EventArgs e)
        {
            BuscadorMateriales.CargarDatos(IdTablaMaterial);
            BuscadorMateriales.Fila().ModificarCelda("estatus_ensamble", "RECIBIDO");
            BuscadorMateriales.GuardarDatos();
            //CargarRequisiciones();           
            InicioDescarga = Global.MillisegundosEpoch();
            BkgPiezasCompradas.RunWorkerAsync();
        }

        private void BtnPerdido_Click(object sender, EventArgs e)
        {        
            BuscadorMateriales.CargarDatos(IdTablaMaterial);
            BuscadorMateriales.Fila().ModificarCelda("estatus_ensamble", "PERDIDO");
            BuscadorMateriales.GuardarDatos();
            //CargarRequisiciones();
            InicioDescarga = Global.MillisegundosEpoch();
            BkgPiezasCompradas.RunWorkerAsync();
        }      

        private void BtnFiltrarDatos_Click(object sender, EventArgs e)
        {
            FrmFiltrarDatos filtros = new FrmFiltrarDatos(BuscadorPlanos.Filtros);
            if (filtros.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscadorPlanos.Filtros = filtros.Filtros;
                
                BorrarPlano();
                //CargarPlanos();
                InicioDescarga = Global.MillisegundosEpoch();
                BkgPiezasFabricadas.RunWorkerAsync();
            }
        }

        private void BtnFiltroPartes_Click(object sender, EventArgs e)
        {            
            FrmFiltrarDatos filtros = new FrmFiltrarDatos(BuscadorMateriales.Filtros);

            if (filtros.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscadorMateriales.Filtros = filtros.Filtros;
                //CargarRequisiciones();
                InicioDescarga = Global.MillisegundosEpoch();
                BkgPiezasCompradas.RunWorkerAsync();
            }
        }     

        private void DgvPartes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                ParteSeleccionada = Convert.ToInt32(DgvPartes.SelectedRows[0].Cells[0].Value);
                string estatusEnsamble = DgvPartes.SelectedRows[0].Cells["estatus_ensamble"].Value.ToString();
                string estatusFabricacion = DgvPartes.SelectedRows[0].Cells["estatus_fabricacion"].Value.ToString();
                FilaClick = true;
                if (estatusFabricacion == "ENTREGADO")
                {
                    switch (estatusEnsamble)
                    {
                        case "N/A":
                            ensambladoToolStripMenuItem.Enabled = false;
                            recibidoToolStripMenuItem.Enabled = false;
                            perdidoToolStripMenuItem.Enabled = false;
                            retrabajoToolStripMenuItem.Enabled = false;
                            descartadoToolStripMenuItem.Enabled = false;
                            break;
                        case "SIN RECIBIR":
                            ensambladoToolStripMenuItem.Enabled = false;
                            recibidoToolStripMenuItem.Enabled = true;
                            perdidoToolStripMenuItem.Enabled = true;
                            retrabajoToolStripMenuItem.Enabled = true;
                            break;

                        case "ENSAMBLADO":
                            ensambladoToolStripMenuItem.Enabled = false;
                            recibidoToolStripMenuItem.Enabled = false;
                            perdidoToolStripMenuItem.Enabled = true;
                            retrabajoToolStripMenuItem.Enabled = true;
                            break;

                        case "RECIBIDO":
                            ensambladoToolStripMenuItem.Enabled = true;
                            recibidoToolStripMenuItem.Enabled = false;
                            perdidoToolStripMenuItem.Enabled = true;
                            retrabajoToolStripMenuItem.Enabled = true;
                            descartadoToolStripMenuItem.Enabled = true;
                            break;

                        case "PERDIDO":
                            ensambladoToolStripMenuItem.Enabled = true;
                            recibidoToolStripMenuItem.Enabled = true;
                            perdidoToolStripMenuItem.Enabled = false;
                            retrabajoToolStripMenuItem.Enabled = true;
                            descartadoToolStripMenuItem.Enabled = true;
                            break;

                        case "RETRABAJO":
                            ensambladoToolStripMenuItem.Enabled = true;
                            recibidoToolStripMenuItem.Enabled = true;
                            perdidoToolStripMenuItem.Enabled = true;
                            retrabajoToolStripMenuItem.Enabled = false;
                            descartadoToolStripMenuItem.Enabled = true;
                            break;
                    }
                }
                else
                {
                    ensambladoToolStripMenuItem.Enabled = false;
                    recibidoToolStripMenuItem.Enabled = false;
                    perdidoToolStripMenuItem.Enabled = false;
                    retrabajoToolStripMenuItem.Enabled = false;
                    descartadoToolStripMenuItem.Enabled = false;

                }
            }
        }

        private void BtnOpcionesParte_Click(object sender, EventArgs e)
        {
            if (BtnOpcionesParte.ContextMenuStrip != null)
                BtnOpcionesParte.ContextMenuStrip.Show(BtnOpcionesParte, BtnOpcionesParte.PointToClient(Cursor.Position));
        }

        //Eventos Ensamblado
        private void ensambladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(ParteSeleccionada);
            plano.Fila().ModificarCelda("estatus_ensamble", "ENSAMBLADO");
            plano.Fila().ModificarCelda("fecha_ensamblado", DateTime.Now);
            plano.Fila().ModificarCelda("usuario_ensamblado", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
            plano.GuardarDatos();

            //CargarPlanos();
            InicioDescarga = Global.MillisegundosEpoch();
            BkgPiezasFabricadas.RunWorkerAsync();
            FilaClick = false;
        }

        public void RegresarSplitContainer2()
        {
            if (ScrollPosicionPartes != 0 && ScrollPosicionPartes < DgvPartes.Rows.Count)
                DgvPartes.FirstDisplayedScrollingRowIndex = ScrollPosicionPartes;

            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel1Collapsed = false;
            splitContainer2.Panel1.Show();
            FilaClick = false;
        }

        private void recibidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(ParteSeleccionada);
            plano.Fila().ModificarCelda("estatus_ensamble", "RECIBIDO");
            plano.Fila().ModificarCelda("fecha_recibido_ensamble", DateTime.Now);
            plano.Fila().ModificarCelda("usuario_recibido_ensamble", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
            plano.GuardarDatos();
     
            //CargarPlanos();
            InicioDescarga = Global.MillisegundosEpoch();
            BkgPiezasFabricadas.RunWorkerAsync();
            RegresarSplitContainer2();          
        }

        private void perdidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(ParteSeleccionada);
                 
            plano.Fila().ModificarCelda("estatus_ensamble", "PERDIDO");
            plano.Fila().ModificarCelda("fecha_perdido", DateTime.Now);
            plano.Fila().ModificarCelda("usuario_perdido", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
            plano.GuardarDatos();
    
            //CargarPlanos();
            InicioDescarga = Global.MillisegundosEpoch();
            BkgPiezasFabricadas.RunWorkerAsync();
            RegresarSplitContainer2(); 
        }

        private void retrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(ParteSeleccionada);
            FrmRazonRetrabajo razonRetrabajo = new FrmRazonRetrabajo(plano.Fila().Celda("comentarios_retrabajo").ToString());

            if (razonRetrabajo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                plano.Fila().ModificarCelda("estatus_ensamble", "RETRABAJO");
                plano.Fila().ModificarCelda("fecha_retrabajo", DateTime.Now);
                plano.Fila().ModificarCelda("usuario_retrabajo", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
                plano.Fila().ModificarCelda("comentarios_retrabajo", razonRetrabajo.Razon);
                plano.GuardarDatos();
                
                string titulo = "Retrabajo solicitado";
                string contenido = Global.UsuarioActual.NombreCompleto() + " solicitó un retrabajo de la pieza " + plano.Fila().Celda("nombre_archivo") + " del proyecto " + ProyectoSeleccionado;
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                Evento.Modelo().Crear(titulo, contenido, "LIDER DE PROYECTO");
            }
    
            //CargarPlanos();
            InicioDescarga = Global.MillisegundosEpoch();
            BkgPiezasFabricadas.RunWorkerAsync();
            RegresarSplitContainer2(); 
        }

        private void descartadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(ParteSeleccionada);

            if (plano.TieneFilas())
            {
                if (plano.Fila().Celda("estatus").ToString() != "ENTREGADO")
                {
                    MessageBox.Show("Solo puedes descartar piezas que ya fueron entregadas.", "Imposible descartar pieza", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult resp = MessageBox.Show("Seguro que quieres descartar la pieza seleccionada?", "Descartar pieza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp != System.Windows.Forms.DialogResult.Yes) return;
                }

                plano.Fila().ModificarCelda("estatus_ensamble", "DESCARTADO");
                plano.GuardarDatos();
                //CargarPlanos();
                InicioDescarga = Global.MillisegundosEpoch();
                BkgPiezasFabricadas.RunWorkerAsync();
                RegresarSplitContainer2(); 
            }           
        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetallesPlanoFabricacion detalles = new FrmDetallesPlanoFabricacion(ParteSeleccionada);
            detalles.ShowDialog();
        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(ParteSeleccionada);
            plano.Fila().ModificarCelda("comentarios_ensamble", TxtComentarios.Text);
            plano.GuardarDatos();
        }
        
        private void DgvEstatusEnsamble_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                int guardarScroll = 0;

                if (DgvEstatusEnsamble.SelectedRows.Count > 0)
                {
                    IdTablaMaterial = Convert.ToInt32(DgvEstatusEnsamble.SelectedRows[0].Cells["id_requisicion"].Value);
                    EstatusEnsamble = DgvEstatusEnsamble.SelectedRows[0].Cells[4].Value.ToString();
                    EstatusAlmacen = DgvEstatusEnsamble.SelectedRows[0].Cells["ESTATUS_ALMACEN"].Value.ToString();
                    LblTituloEnsamble.Text = "NUMERO DE PARTE - " + DgvEstatusEnsamble.SelectedRows[0].Cells["NUMERO_PARTE"].Value.ToString();
                    HabilitarBotones(DgvEstatusEnsamble.SelectedRows[0].Cells["ENSAMBLE_ESTATUS"].Value.ToString());

                	ScrollPosicionEnsamble = guardarScroll;              
                    if (DgvEstatusEnsamble.Rows.Count > 0)
                        guardarScroll = DgvEstatusEnsamble.FirstDisplayedCell.RowIndex;

                    ScrollPosicionEnsamble = guardarScroll;
                }
            }
        }

        //Eventos Actividades
        private void BtnFiltrosActividades_Click(object sender, EventArgs e)
        {
            FrmFiltrarDatos filtros = new FrmFiltrarDatos(BuscadorActividad.Filtros);
            
            if (filtros.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscadorActividad.Filtros = filtros.Filtros;               
                CargarDatosActividad();
            }
        }

        private void MenuNuevaActividad_Click(object sender, EventArgs e)
        {           
            FrmNuevaActividad nuevaActividad = new FrmNuevaActividad(ParteSeleccionada,"", BuscadorActividad.Filtros);
            if (nuevaActividad.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                BuscadorActividad.Filtros = nuevaActividad.Filtros;
                BuscadorActividad.Filtros[0] = new Filtro("proyecto", "Proyecto", BuscadorActividad.Proyecto());
                BuscadorActividad.Filtros[1] = new Filtro("tipo", "Tipo de actividad", BuscadorActividad.TipoActividad());
                BuscadorActividad.Filtros[2] = new Filtro("estatus", "Estatus de actividad", BuscadorActividad.Estatus());
                BuscadorActividad.Filtros[2].ActivarTodos();
                BuscadorActividad.Filtros[3] = new Filtro("estatus_revision", "Estatus de revisión de actividad", BuscadorActividad.EstatusRevision());               
                
                CargarDatosActividad();
                DgvActividades.ClearSelection();
                DgvActividades.Rows[DgvActividades.Rows.Count - 1].Selected = true;
                MenuBorrar.Enabled = false;
                LimpiarDgvActividades();
            }
        }

        private void BtnOpcionesActividades_Click(object sender, EventArgs e)
        {
            if (BtnOpcionesActividades.ContextMenuStrip != null)
                BtnOpcionesActividades.ContextMenuStrip.Show(BtnOpcionesActividades, BtnOpcionesActividades.PointToClient(Cursor.Position));
        }

        private void MenuAsignar_Click(object sender, EventArgs e)
        {
            string rol = "TECNICO DE ENSAMBLE";
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario(rol);
            if (usuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (usuario.UsuarioSeleccionado.TieneFilas())
                {
                    if (!BuscadorActividad.ExisteValorColumna("estatus", "PENDIENTE"))
                        BuscadorActividad.Filtros[2].ModificarFiltro("PENDIENTE", true);

                    string responsable = usuario.UsuarioSeleccionado.NombreCompleto();
                    BuscadorActividad.CargarDatos(IdActividad);
                    BuscadorActividad.Fila().ModificarCelda("responsable", responsable);
                    BuscadorActividad.Fila().ModificarCelda("fecha_asignacion", DateTime.Now);
                    BuscadorActividad.Fila().ModificarCelda("estatus", "PENDIENTE");
                    BuscadorActividad.Fila().ModificarCelda("fecha_promesa", DateTime.Today.AddDays(1));
                    BuscadorActividad.GuardarDatos();
                    BuscadorActividad.Filtros[2] = new Filtro("estatus", "Estatus de actividad", BuscadorActividad.Estatus());
                    BuscadorActividad.Filtros[2].ModificarFiltro("PENDIENTE", true);

                    CargarDatosActividad();
                    LimpiarDgvActividades();
                    if (ScrollPosicionActividad != 0 && ScrollPosicionActividad < DgvActividades.Rows.Count)
                        DgvActividades.FirstDisplayedScrollingRowIndex = ScrollPosicionActividad;                  
                }
            }            
        }

        private void MenuBorrar_Click(object sender, EventArgs e)
        {
            string proyectos = "";
            string texto = "";

            int actividades = 0;
            int rowCount = 0;

            foreach (DataGridViewRow row in DgvActividades.SelectedRows)
            {
                proyectos += "Proyecto: " + row.Cells["id_actividades"].Value.ToString() + "\r\n";
                actividades ++;
            }
            
            if(actividades > 1)
                texto = "¿Seguro que desea borrar estas actividades?\r\n";
            else
                 texto = "¿Seguro que desea borrar esta actividad?\r\n";

            DialogResult respuesta = MessageBox.Show(texto + proyectos, "Eliminar actividad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                if (respuesta != DialogResult.Yes)
                    return;

                foreach (DataGridViewRow row in DgvActividades.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["id_actividades"].Value);
                    BuscadorActividad.CargarDatos(id);
                    if (BuscadorActividad.TieneFilas())
                    {
                        BuscadorActividad.BorrarDatos(id);
                        BuscadorActividad.GuardarDatos();
                    }
                    rowCount++;
                }
                CargarDatosActividad();
                DgvActividades.ClearSelection();
                LimpiarDgvActividades();
                MenuBorrar.Enabled = false;
            }
        }

        private void MenuSeguimiento_Click(object sender, EventArgs e)
        {
            FrmSeguimientoEnsamble seguimiento = new FrmSeguimientoEnsamble(IdActividad,EstatusActividad,BuscadorActividad.Filtros);
            if (seguimiento.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                BuscadorActividad.Filtros = seguimiento.Filtros;
                BuscadorActividad.Filtros[2] = new Filtro("estatus", "Estatus de actividad", BuscadorActividad.Estatus());
                BuscadorActividad.Filtros[2].ActivarTodos();            

                CargarDatosActividad();
                LimpiarDgvActividades();
                 
                if (ScrollPosicionActividad != 0 && ScrollPosicionActividad < DgvActividades.Rows.Count)
                    DgvActividades.FirstDisplayedScrollingRowIndex = ScrollPosicionActividad;
            }
        }

        private void MenuEditar_Click(object sender, EventArgs e)
        {
            FrmNuevaActividad nuevaActividad = new FrmNuevaActividad(IdActividad, TipoActividad, BuscadorActividad.Filtros);
            if (nuevaActividad.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                BuscadorActividad.Filtros = nuevaActividad.Filtros;
                BuscadorActividad.Filtros[1] = new Filtro("tipo", "Tipo de actividad", BuscadorActividad.TipoActividad());
                BuscadorActividad.Filtros[2].ActivarTodos(); 
                CargarDatosActividad();
                LimpiarDgvActividades();
                
                if (ScrollPosicionActividad != 0 && ScrollPosicionActividad < DgvActividades.Rows.Count)
                    DgvActividades.FirstDisplayedScrollingRowIndex = ScrollPosicionActividad;          
            }
        }
     
        private void DgvActividades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int guardarScroll = 0;
            if (DgvActividades.SelectedRows.Count > 0)
            {
                IdActividad = Convert.ToInt32(DgvActividades.SelectedRows[0].Cells["id_actividades"].Value);
                UsuarioActividad = (DgvActividades.SelectedRows[0].Cells["responsable"].Value).ToString();
                TipoActividad = (DgvActividades.SelectedRows[0].Cells["tipo"].Value).ToString();
                EstatusActividad = (DgvActividades.SelectedRows[0].Cells["estatus_actividad"].Value).ToString();
                ProyectoActividad = Convert.ToDecimal(DgvActividades.SelectedRows[0].Cells["proyecto"].Value);
                LblTituloActividad.Text = "ACTIVIDAD #" + DgvActividades.SelectedRows[0].Cells["id_actividades"].Value.ToString();

                string responsable = (DgvActividades.SelectedRows[0].Cells["responsable"].Value).ToString();
                string estatusRevision = (DgvActividades.SelectedRows[0].Cells["estatus_revision"].Value).ToString();
                string fechaPromesa = (DgvActividades.SelectedRows[0].Cells["fecha_promesa"].Value).ToString();
                             
                if (DgvActividades.Rows.Count > 0)
                    guardarScroll = DgvActividades.FirstDisplayedCell.RowIndex;

                ScrollPosicionActividad = guardarScroll;
                BtnOpcionesActividades.Enabled = true;

                if(DgvActividades.Rows.Count >= 1)
                    MenuBorrar.Enabled = true;

                if (responsable != "N/A" && (EstatusActividad != "N/A" && EstatusActividad != "SIN ASIGNAR") && EstatusActividad != "TERMINADO")
                {
                    MenuImprimirPlan.Enabled = true;
                    MenuSeguimiento.Enabled = true;
                }
                else
                {
                    MenuImprimirPlan.Enabled = false;
                    MenuSeguimiento.Enabled = false;
                }

                if(EstatusActividad == "TERMINADO" && estatusRevision == "CUMPLE")
                {
                    MenuBorrar.Enabled = false;
                    MenuSeguimiento.Enabled = false;                  
                    MenuRevisar.Enabled = false;
                    MenuEditar.Enabled = false;
                    MenuAsignar.Enabled = false;
                }
                else if(EstatusActividad == "TERMINADO")
                {                 
                    MenuSeguimiento.Enabled = false;
                    MenuRevisar.Enabled = true;
                    MenuEditar.Enabled = false;
                    MenuAsignar.Enabled = false;
                }
                else
                {
                    //MenuBorrar.Enabled = true;                                      
                    MenuEditar.Enabled = true;
                    MenuAsignar.Enabled = true;
                    MenuRevisar.Enabled = true;
                }

                if (DgvActividades.Rows.Count >= 1)
                    MenuBorrar.Enabled = true;
            }
        }

        private void MenuImprimirPlan_Click(object sender, EventArgs e)
        {
            ActividadEnsamble actividad = new ActividadEnsamble();
            actividad.ResponsableActividad(UsuarioActividad, ProyectoActividad);
            byte[] archivo = FormatosPDF.PlanDeActividadesEnsamble(ProyectoActividad, UsuarioActividad);
            string nombreArchivo = "PLAN DE TRABAJO " + UsuarioActividad + " - " + DateTime.Now.ToString("MMM dd, yyyy");

            FrmVisorPDF pdf = new FrmVisorPDF(archivo,nombreArchivo);
            if (pdf.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                CargarDatosActividad();
                LimpiarDgvActividades();
            }
        }

        private void cumpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarComentario com = new FrmIngresarComentario();
            BuscadorActividad.CargarDatos(IdActividad);

            if (com.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (BuscadorActividad.TieneFilas())
                {                   
                    if(!BuscadorActividad.ExisteValorColumna("estatus_revision", "CUMPLE"))
                        BuscadorActividad.Filtros[3].ModificarFiltro("CUMPLE", true);

                    RevisarActividad("CUMPLE", com.Comentarios);
                    BuscadorActividad.Filtros[3] = new Filtro("estatus_revision", "Estatus de revisión", BuscadorActividad.EstatusRevision());
                    CargarDatosActividad();
                    if (ScrollPosicionActividad != 0 && ScrollPosicionActividad < DgvActividades.Rows.Count)
                        DgvActividades.FirstDisplayedScrollingRowIndex = ScrollPosicionActividad;
                }
            }
        }

        private void noCumpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarComentario com = new FrmIngresarComentario();
            BuscadorActividad.CargarDatos(IdActividad);

            if (com.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (BuscadorActividad.TieneFilas())
                {                   
                    if (!BuscadorActividad.ExisteValorColumna("estatus_revision", "NO CUMPLE"))
                        BuscadorActividad.Filtros[3].ModificarFiltro("NO CUMPLE", true);

                    RevisarActividad("NO CUMPLE", com.Comentarios);
                    BuscadorActividad.Filtros[3] = new Filtro("estatus_revision", "Estatus de revisión", BuscadorActividad.EstatusRevision());
                    CargarDatosActividad();
                     
                    if (ScrollPosicionActividad != 0 && ScrollPosicionActividad < DgvActividades.Rows.Count)
                        DgvActividades.FirstDisplayedScrollingRowIndex = ScrollPosicionActividad;
                }
            }
        }

        private void noAplicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarComentario com = new FrmIngresarComentario();
            BuscadorActividad.CargarDatos(IdActividad);

            if (com.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (BuscadorActividad.TieneFilas())
                {
                    if (!BuscadorActividad.ExisteValorColumna("estatus_revision", "NO APLICA"))
                        BuscadorActividad.Filtros[3].ModificarFiltro("NO APLICA", true);

                    RevisarActividad("NO APLICA", com.Comentarios);
                    BuscadorActividad.Filtros[3] = new Filtro("estatus_revision", "Estatus de revisión", BuscadorActividad.EstatusRevision());
                    
                    CargarDatosActividad();
                    if (ScrollPosicionActividad != 0 && ScrollPosicionActividad < DgvActividades.Rows.Count)
                        DgvActividades.FirstDisplayedScrollingRowIndex = ScrollPosicionActividad;
                }
            }
        }

        private void DgvPartes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.RowIndex >= 0)
                {
                    splitContainer3.Panel2Collapsed = false;
                    splitContainer3.Panel2.Show();
                    splitContainer3.Panel1Collapsed = true;
                    splitContainer3.Panel1.Hide();
                    splitContainer2.Panel1Collapsed = true;
                    splitContainer2.Panel1.Hide();

                    int guardarScroll = 0;
                    BorrarPlano();
                    if (DgvPartes.SelectedRows.Count == 0)
                        return;

                    ParteSeleccionada = Convert.ToInt32(DgvPartes.SelectedRows[0].Cells[0].Value);
                    string estatusFabricacion = DgvPartes.SelectedRows[0].Cells["estatus_fabricacion"].Value.ToString();
                    string estatusEnsamble = DgvPartes.SelectedRows[0].Cells["estatus_ensamble"].Value.ToString();
                    string plano = DgvPartes.SelectedRows[0].Cells["plano"].Value.ToString();
                    if (estatusFabricacion == "ENTREGADO")
                    {
                        switch (estatusEnsamble)
                        {
                            case "N/A":
                                ensambladoToolStripMenuItem.Enabled = false;
                                recibidoToolStripMenuItem.Enabled = false;
                                perdidoToolStripMenuItem.Enabled = false;
                                retrabajoToolStripMenuItem.Enabled = false;
                                descartadoToolStripMenuItem.Enabled = false;
                                break;

                            case "SIN RECIBIR":
                                ensambladoToolStripMenuItem.Enabled = false;
                                recibidoToolStripMenuItem.Enabled = true;
                                perdidoToolStripMenuItem.Enabled = true;
                                retrabajoToolStripMenuItem.Enabled = true;
                                descartadoToolStripMenuItem.Enabled = true;
                                break;

                            case "ENSAMBLADO":
                                ensambladoToolStripMenuItem.Enabled = false;
                                recibidoToolStripMenuItem.Enabled = false;
                                perdidoToolStripMenuItem.Enabled = true;
                                retrabajoToolStripMenuItem.Enabled = true;
                                descartadoToolStripMenuItem.Enabled = true;
                                break;

                            case "RECIBIDO":
                                ensambladoToolStripMenuItem.Enabled = true;
                                recibidoToolStripMenuItem.Enabled = false;
                                perdidoToolStripMenuItem.Enabled = true;
                                retrabajoToolStripMenuItem.Enabled = true;
                                descartadoToolStripMenuItem.Enabled = true;
                                break;

                            case "PERDIDO":
                                ensambladoToolStripMenuItem.Enabled = true;
                                recibidoToolStripMenuItem.Enabled = true;
                                perdidoToolStripMenuItem.Enabled = false;
                                retrabajoToolStripMenuItem.Enabled = true;
                                descartadoToolStripMenuItem.Enabled = true;
                                break;

                            case "RETRABAJO":
                                ensambladoToolStripMenuItem.Enabled = true;
                                recibidoToolStripMenuItem.Enabled = true;
                                perdidoToolStripMenuItem.Enabled = true;
                                retrabajoToolStripMenuItem.Enabled = false;
                                descartadoToolStripMenuItem.Enabled = true;
                                break;
                        }
                    }
                    else
                    {
                        ensambladoToolStripMenuItem.Enabled = false;
                        recibidoToolStripMenuItem.Enabled = false;
                        perdidoToolStripMenuItem.Enabled = false;
                        retrabajoToolStripMenuItem.Enabled = false;
                        descartadoToolStripMenuItem.Enabled = false;
                    }
                    if (DgvPartes.Rows.Count > 0)
                        guardarScroll = DgvPartes.FirstDisplayedCell.RowIndex;

                    ScrollPosicionPartes = guardarScroll;
                    LblCargandoPlano.Visible = true;
                    LblNumeroPlano.Text = "PLANO SELECCIONADO - " + plano;
                    MostrarPlano(ParteSeleccionada);
                }
            }
        }

        private void BtnOcultarDetalles_Click(object sender, EventArgs e)
        {
            BorrarPlano();
            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2.Hide();
            splitContainer3.Panel1Collapsed = false;
            splitContainer3.Panel1.Show();
            splitContainer2.Panel1Collapsed = false;
            splitContainer2.Panel1.Show();
        }

        private void chkVistaPrevia_CheckedChanged(object sender, EventArgs e)
        {
            DgvPartes.Columns["miniatura"].Visible = chkVistaPrevia.Checked;
        }

        private void DgvPartes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && FilaClick)
            {
                //ParteSeleccionada = Convert.ToInt32(DgvPartes.SelectedRows[0].Cells["id_plano"].Value);
                if (e.Button == MouseButtons.Right)
                    MenuOpcionesPieza.Show(Cursor.Position.X,Cursor.Position.Y);
            }
        }

        private void DgvActividades_SelectionChanged(object sender, EventArgs e)
        {
            if(DgvActividades.SelectedRows.Count > 1)
            {
                MenuEditar.Enabled = false;
                MenuAsignar.Enabled = false;
                MenuSeguimiento.Enabled = false;
                MenuImprimirPlan.Enabled = false;
                MenuRevisar.Enabled = false;
            }
        }

        private void DgvActividades_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo clickDgvActividades = DgvActividades.HitTest(e.X, e.Y);

            if (clickDgvActividades.Type == DataGridViewHitTestType.None)
            {
                MenuEditar.Enabled = false;
                MenuAsignar.Enabled = false;
                MenuSeguimiento.Enabled = false;
                MenuImprimirPlan.Enabled = false;
                MenuRevisar.Enabled = false;
                MenuBorrar.Enabled = false;
                DgvActividades.ClearSelection();
                LblTituloActividad.Text = "SELECCIONE UNA ACTIVIDAD";
            }
        }

        private void TcContenedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TcContenedor.SelectedIndex == 1 && EstatusEnsamble == "")
                DeshabilitarBotones();

            if (TcContenedor.SelectedIndex == 2)
                CargarDatosActividad();

            switch (TcContenedor.SelectedIndex)
            {
                case 0:
                    if (BkgPiezasFabricadas.IsBusy)
                    {
                        BkgPiezasFabricadas.WorkerSupportsCancellation = true;
                        BkgPiezasFabricadas.CancelAsync();
                    }
                    break;
                case 1:
                    if (BkgPiezasCompradas.IsBusy)
                    {
                        BkgPiezasCompradas.WorkerSupportsCancellation = true;
                        BkgPiezasCompradas.CancelAsync();
                    }
                    break;
            }
        }

        private void DgvEstatusEnsamble_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                FrmDetallesMaterialProyecto verRequerimientos = new FrmDetallesMaterialProyecto(Convert.ToInt32(DgvEstatusEnsamble.SelectedRows[0].Cells["id_requisicion"].Value.ToString()));
                verRequerimientos.ShowDialog();
            }
        }

        private void fechaPromesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
        }

        private void BtnFechaPromesa_Click(object sender, EventArgs e)
        {
        }

        private void BtnActualizarFabricadas_Click(object sender, EventArgs e)
        {
            //CargarPlanos();
            InicioDescarga = Global.MillisegundosEpoch();
            BkgPiezasFabricadas.RunWorkerAsync();
        }

        private void BtnActualizarCompradas_Click(object sender, EventArgs e)
        {
            //CargarRequisiciones();
            InicioDescarga = Global.MillisegundosEpoch();
            BkgPiezasCompradas.RunWorkerAsync();
        }

        private void BkgPiezasFabricadas_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!e.Cancel)
            {
                string columnas = "planos_proyectos.*, ";
                columnas += "(SELECT miniatura FROM archivos_planos WHERE planos_proyectos.id=archivos_planos.plano LIMIT 1) AS miniatura";

                Planos = BuscadorPlanos.SeleccionarDatos("", null, columnas, BkgPiezasFabricadas);

            }
        }

        private void BkgPiezasFabricadas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            //Fila lafila = (Fila)e.UserState;

            LblEstatus.Text = "Descargando planos... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgPiezasFabricadas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                LblEstatus.Text = Planos.Count + " planos descargados en " + ((Global.MillisegundosEpoch() - InicioDescarga) / 1000.0).ToString("F2") + " segundos"; ;
                ProgresoDescarga.Visible = false;
                CargarPlanos();
            }
        }

        private void BkgPiezasCompradas_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!e.Cancel)
            {
                //string columnas = "material_proyecto.*, ";
                PiezasCompradas = BuscadorMateriales.SeleccionarDatos("", null, "*", BkgPiezasCompradas);
            }
        }

        private void BkgPiezasCompradas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescargaPiezasCompradas.Value = e.ProgressPercentage;
            //Fila lafila = (Fila)e.UserState;

            LblEstatusPiezasCompradas.Text = "Descargando planos... [" + e.ProgressPercentage + "%]";
            LblEstatusPiezasCompradas.Refresh();
        }

        private void BkgPiezasCompradas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                LblEstatusPiezasCompradas.Text = PiezasCompradas.Count + " planos descargados en " + ((Global.MillisegundosEpoch() - InicioDescarga) / 1000.0).ToString("F2") + " segundos"; ;
                ProgresoDescargaPiezasCompradas.Visible = false;
                CargarRequisiciones();
            }
        }
    }
}   
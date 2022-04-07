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
    public partial class FrmRealizarMantenimientoCorrectivo : Form
    {
        int IdEquipo = 0;
        int OrdenMantenimiento = 0;
        int IdSeleccionado = 0;
        string TipoEquipo = string.Empty;
        bool RecargarActividad = false;

        public FrmRealizarMantenimientoCorrectivo(int idEquipo, string tipoEquipo, int ordenMantenimiento)
        {
            InitializeComponent();
            IdEquipo = idEquipo;
            TipoEquipo = tipoEquipo;
            OrdenMantenimiento = ordenMantenimiento;
        }

        private void FrmRealizarMantenimientoCorrectivo_Load(object sender, EventArgs e)
        {
            LblTitulo.Text += " A " + TipoEquipo;

            buscarMantenimiento();
            CargarInformacion();
            CargarActividad();
            CargarMaterial();
            BtnFinalizar.Enabled = HabilitarBotonFinalizar();
        }

        private void buscarMantenimiento()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            // Ya tiene un registro en la tabla de mantenimiento
            mantenimiento.SeleccionarMantenimiento(IdEquipo, TipoEquipo, "CORRECTIVO", OrdenMantenimiento).ForEach(delegate(Fila f)
            {
                int idMantenimiento = Convert.ToInt32(f.Celda("id"));
                TxtIdMantenimiento.Text = idMantenimiento.ToString().PadLeft(4, '0');
            });

            // Se crea un nuevo registro en la tabla de mantenimiento
            if (!mantenimiento.TieneFilas())
            {
                CrearMantenimiento();
            }

        }

        private void CrearMantenimiento()
        {
            Fila insertarMantenimiento = new Fila();
            insertarMantenimiento.AgregarCelda("tipo_mantenimiento", "CORRECTIVO");
            insertarMantenimiento.AgregarCelda("tipo_equipo", TipoEquipo);
            insertarMantenimiento.AgregarCelda("equipo", IdEquipo);
            insertarMantenimiento.AgregarCelda("estatus", "PENDIENTE");
            insertarMantenimiento.AgregarCelda("orden_trabajo", OrdenMantenimiento);
            int idMantenimiento = Convert.ToInt32(Mantenimiento.Modelo().Insertar(insertarMantenimiento).Celda("id"));

            OrdenTrabajoMantenimiento orden = new OrdenTrabajoMantenimiento();
            orden.CargarDatos(Convert.ToInt32(OrdenMantenimiento));
            if(orden.TieneFilas())
            {
                orden.Fila().ModificarCelda("estatus", "EN PROCESO");
                orden.GuardarDatos();
            }

            TxtIdMantenimiento.Text = idMantenimiento.ToString().PadLeft(4, '0');
        }

        private void CargarInformacion()
        {
            EquipoComputo equipoComputo = new EquipoComputo();
            equipoComputo.CargarDatos(IdEquipo);
            if (equipoComputo.TieneFilas())
            {
                TxtEquipo.Text = IdEquipo + " - " + equipoComputo.Fila().Celda("numero_serie").ToString();
            }

            OrdenTrabajoMantenimiento ordenTrabajo = new OrdenTrabajoMantenimiento();
            ordenTrabajo.CargarDatos(OrdenMantenimiento);

            TxtOrdenTrabajo.Text = OrdenMantenimiento.ToString().PadLeft(4, '0');
            TxtSolicitadoPor.Text = ordenTrabajo.Fila().Celda("solicitado_por").ToString().ToUpper();
            TxtPuntosReparar.Text = ordenTrabajo.Fila().Celda("puntos_reparacion").ToString();

        }

        private void DgvActividades_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object objEstatus = DgvActividades.Rows[e.RowIndex].Cells["estatus_actividad"].Value;
            object idActividad = DgvActividades.Rows[e.RowIndex].Cells["id_actividad"].Value;

            try
            {
                if (idActividad != null && objEstatus != null)
                {
                    //editar estatus
                    ActividadMantenimiento actividades = new ActividadMantenimiento();
                    actividades.CargarDatos(Convert.ToInt32(idActividad)).ForEach(delegate(Fila f)
                    {
                        actividades.Fila().ModificarCelda("estatus", objEstatus.ToString());
                        if (objEstatus.ToString() == "TERMINADO")
                        {
                            DialogResult result = MessageBox.Show("¿Está seguro que desea terminar la actividad seleccionada?", "Terminar actividad", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == System.Windows.Forms.DialogResult.OK)
                            {
                                actividades.Fila().ModificarCelda("fecha_terminado", DateTime.Now);
                                actividades.Fila().ModificarCelda("usuario_terminado", Global.UsuarioActual.NombreCompleto());
                            }
                            else
                                actividades.Fila().ModificarCelda("estatus", "PENDIENTE");
                        }
                        
                        actividades.GuardarDatos();
                        RecargarActividad = true;
                    });
                }
            }
            catch { /*Controlamos excepcion de edicion de fila*/}

            BtnFinalizar.Enabled = HabilitarBotonFinalizar();
        }

        private void DgvActividades_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (RecargarActividad)
               CargarActividad();
        }

        private void DgvActividades_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Convertimos a upper case lo que el usuario haya tecleado dentro de la celda
            if (DgvActividades.CurrentCell.ColumnIndex == 0 || DgvActividades.CurrentCell.ColumnIndex == 5)
            {
                if (e.Control is TextBox)
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void CargarActividad()
        {
            Application.DoEvents();
            RecargarActividad = false;

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvActividades);

            DgvActividades.Rows.Clear();
            ActividadMantenimiento actividad = new ActividadMantenimiento();

            int rowIndex = 0;
            actividad.CargarActividades(Convert.ToInt32(TxtIdMantenimiento.Text)).ForEach(delegate(Fila f)
            {
                string comentarios = "";
                object objFechaRegistro = f.Celda("fecha_registro");
                object objFechaTerminado = f.Celda("fecha_terminado");
                object objComentarios = f.Celda("comentarios");

                if (objComentarios != null)
                    comentarios = objComentarios.ToString();

                string estatus = f.Celda("estatus").ToString();

                DgvActividades.Rows.Add(f.Celda("id").ToString(), f.Celda("actividad").ToString(), Global.FechaATexto(objFechaRegistro), Global.FechaATexto(objFechaTerminado), estatus, comentarios);
               
                if (estatus == "TERMINADO")
                    DgvActividades.Rows[rowIndex].ReadOnly = true;

                rowIndex++;
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvActividades);
        }

        public void CargarMaterial()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@mantenimiento", Convert.ToInt32(TxtIdMantenimiento.Text));

            int fila = Global.GuardarFilaSeleccionada(DgvMaterial);
            DgvMaterial.Rows.Clear();

            MaterialProyecto.Modelo().SeleccionarDatos("mantenimiento=@mantenimiento", parametros).ForEach(delegate(Fila f)
            {
                DgvMaterial.Rows.Add(f.Celda("id"), f.Celda("requisitor"), f.Celda("numero_parte"), f.Celda("descripcion"), f.Celda("piezas_requeridas"), f.Celda("estatus_compra"), f.Celda("estatus_almacen"));
            });

            Global.RecuperarFilaSeleccionada(DgvMaterial, fila);
        }

        private void seleccionarDelCatálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> filtro = new List<string>()
            {
                "M.R.O.",
                "SERVICIOS"
            };

            FrmSeleccionarMaterialCatalogo2 selec = new FrmSeleccionarMaterialCatalogo2(filtro, true, false);
            //FrmSeleccionarMaterialCatalogo selec = new FrmSeleccionarMaterialCatalogo( true, false);
            if (selec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CrearRequisicionMaterial(selec.IdMaterial, selec.CantidadMaterial);
                CargarMaterial();
            }
        }

        public int CrearRequisicionMaterial(int idCatalogo, int cantidad)
        {
            CatalogoMaterial material = new CatalogoMaterial();
            material.CargarDatos(idCatalogo);

            if (Convert.ToBoolean(material.Fila().Celda("material_restringido")))
            {
                MessageBox.Show("Material restringido por líder de proyecto", "Material restringido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

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
            int idMantenimiento = Convert.ToInt32(TxtIdMantenimiento.Text);

            matProyecto.AgregarCelda("requisitor", requisitor);
            matProyecto.AgregarCelda("proyecto", 0);
            matProyecto.AgregarCelda("mantenimiento", idMantenimiento);
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
            matProyecto.AgregarCelda("estatus_autorizacion", "PENDIENTE");
            matProyecto.AgregarCelda("comentarios_autorizacion", "N/A");
            matProyecto.AgregarCelda("usuario_autorizacion", "N/A");
            matProyecto.AgregarCelda("fecha_autorizacion", DateTime.Now);
            matProyecto.AgregarCelda("subcategoria", material.Fila().Celda("subcategoria_ref"));

            matProyecto = MaterialProyecto.Modelo().Insertar(matProyecto);

            string titulo = "Nueva requisición de material";
            string contenido = "";
            contenido += Global.UsuarioActual.NombreCompleto();
            contenido += " creó la requisición de material #" + matProyecto.Celda("id").ToString() + " para el mantenimiento " + idMantenimiento.ToString();

            Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");

            return Convert.ToInt32(matProyecto.Celda("id"));
        }

        private void DgvMaterial_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvMaterial.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    seleccionarDelCatálogoToolStripMenuItem.Visible = true;
                    cancelarToolStripMenuItem.Visible = false;
                    MenuMaterial.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvMaterial_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    seleccionarDelCatálogoToolStripMenuItem.Visible = false;
                    cancelarToolStripMenuItem.Visible = true;
                    MenuMaterial.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
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
                DialogResult resp = MessageBox.Show("Si cancela la requisición seleccionada se borrará y no podrá ser recuperada, ¿Seguro que quieres cancelar esta requisicion de material?", "Cancelar requisicion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resp != System.Windows.Forms.DialogResult.Yes)
                    return;
            }

            //material.Fila().ModificarCelda("estatus_compra", "CANCELADO");
            //material.GuardarDatos();
            material.BorrarDatos(IdMaterialSeleccionado);
            material.GuardarDatos();
            CargarMaterial();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de salir del mantenimiento sin finalizar la revisión? Los avances serán guardados automaticamente", "Salir", MessageBoxButtons.OKCancel);
            if (result == System.Windows.Forms.DialogResult.OK)
                Close();
        }

        private void DgvActividades_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvActividades.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    eliminiarToolStripMenuItem.Visible = false;
                    editarToolStripMenuItem.Visible = false;
                    MenuActividad.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvActividades_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {           
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                    MenuActividad.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void eliminiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Las actividades que elimine no podrán ser recuperadas, ¿Seguro que desea eliminar la actividad seleccionada? ", "Eliminar datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.OK)
            {        
                ActividadMantenimiento actividad = new ActividadMantenimiento();
                actividad.CargarDatos(IdSeleccionado);
                actividad.BorrarDatos(IdSeleccionado);
                actividad.GuardarDatos();


                CargarActividad();
                BtnFinalizar.Enabled = HabilitarBotonFinalizar();
            }
        }

        private void DgvActividades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            object estatus = DgvActividades.Rows[e.RowIndex].Cells["estatus_actividad"].Value;
            if (estatus == null)
                estatus = "NA";

            if (estatus.ToString() == "TERMINADO")
            {
                eliminiarToolStripMenuItem.Visible = false;
                editarToolStripMenuItem.Visible = false;
            }
            else
            {
                IdSeleccionado = Convert.ToInt32(DgvActividades.Rows[e.RowIndex].Cells["id_actividad"].Value);
                eliminiarToolStripMenuItem.Visible = true;
                editarToolStripMenuItem.Visible = true;
            }

        }

        private void nuevaActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaActividadMantenimiento agregarActividad = new FrmNuevaActividadMantenimiento();
            if (agregarActividad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila insertarActividad = new Fila();
                insertarActividad.AgregarCelda("mantenimiento", Convert.ToInt32(TxtIdMantenimiento.Text));
                insertarActividad.AgregarCelda("actividad", agregarActividad.Actividad);
                insertarActividad.AgregarCelda("fecha_registro", DateTime.Now);
                insertarActividad.AgregarCelda("estatus", "PENDIENTE");
                insertarActividad.AgregarCelda("comentarios", agregarActividad.Comentarios);
                insertarActividad.AgregarCelda("usuario_registro", Global.UsuarioActual.NombreCompleto());
                ActividadMantenimiento.Modelo().Insertar(insertarActividad);
                CargarActividad();
                BtnFinalizar.Enabled = HabilitarBotonFinalizar();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaActividadMantenimiento mantenimiento = new FrmNuevaActividadMantenimiento(IdSeleccionado);
            if(mantenimiento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ActividadMantenimiento actividades = new ActividadMantenimiento();
                actividades.CargarDatos(Convert.ToInt32(IdSeleccionado)).ForEach(delegate(Fila f)
                {
                    actividades.Fila().ModificarCelda("actividad", mantenimiento.Actividad);
                    actividades.Fila().ModificarCelda("comentarios", mantenimiento.Comentarios);
                    actividades.GuardarDatos();
                    
                });
                CargarActividad();
                BtnFinalizar.Enabled = HabilitarBotonFinalizar();
            }
        }

        private bool HabilitarBotonFinalizar()
        {
            bool habilitar = false;

            foreach (DataGridViewRow row in DgvActividades.Rows)
            {
                object estatus = row.Cells["estatus_actividad"].Value;
                if (estatus != null)
                {
                    if (estatus.ToString() != "TERMINADO")
                    {
                        habilitar = false;
                        break;
                    }
                    else
                        habilitar = true;
                }
                else
                {
                    habilitar = false;
                    break;
                }
            }

            return habilitar;
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea terminar la revisión del mantenimiento correctivo?", "Terminar mantenimiento", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                Mantenimiento mantenimiento = new Mantenimiento();
                mantenimiento.CargarDatos(Convert.ToInt32(TxtIdMantenimiento.Text));
                mantenimiento.Fila().ModificarCelda("estatus", "TERMINADO");
                mantenimiento.Fila().ModificarCelda("fecha", DateTime.Now);
                mantenimiento.GuardarDatos();

                OrdenTrabajoMantenimiento orden = new OrdenTrabajoMantenimiento();
                orden.CargarDatos(Convert.ToInt32(OrdenMantenimiento));
                orden.Fila().ModificarCelda("estatus", "TERMINADO");
                orden.Fila().ModificarCelda("fecha_terminado", DateTime.Now);
                orden.Fila().ModificarCelda("usuario_terminado", Global.UsuarioActual.NombreCompleto());
                orden.GuardarDatos();

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}

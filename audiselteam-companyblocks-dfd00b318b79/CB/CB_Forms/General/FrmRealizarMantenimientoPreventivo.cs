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
    public partial class FrmRealizarMantenimientoPreventivo : Form
    {
        int IdEquipo = 0;
        string TipoEquipo = string.Empty;
        string Numero_serie = string.Empty;
        string Clase = string.Empty;
        bool EditarInformacion = false;
        public bool Finalizar = false;
        List<Fila> ListaInformacionModelo = new List<Fila>();

        
        public FrmRealizarMantenimientoPreventivo(string tipoEquipo, int idEquipo, List<Fila> cargarInformacion, string numero_serie = "numero_serie")
        {
            InitializeComponent();
            TipoEquipo = tipoEquipo;
            IdEquipo = idEquipo;
            Numero_serie = numero_serie;
            ListaInformacionModelo = cargarInformacion;
            cargarInformacion.ForEach(delegate(Fila f)
            {
                Clase = f.Celda("clase").ToString();
            });
            
        }

        private void FrmMantenimientoPreventivo_Load(object sender, EventArgs e)
        {
            LblTitulo.Text += " A " + TipoEquipo;

            //Cargar Responsable
            Usuario usuarios = new Usuario();
            usuarios.SeleccionarDatos("activo=1 order by nombre", null).ForEach(delegate(Fila f)
            {
                string nombre = string.Empty;
                object objNombre = f.Celda("nombre");
                if (objNombre != null)
                    nombre = objNombre.ToString();

                object objPaterno = f.Celda("paterno");
                if (objPaterno != null)
                    nombre += " " + objPaterno.ToString();

                CmbResponsable.Items.Add(f.Celda("id").ToString() + " - " + nombre);
            });

            buscarMantenimiento();
            CargarEquipo();            
            CargarMaterial();
        }

        private void buscarMantenimiento()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            // Ya tiene un registro en la tabla de mantenimiento
            mantenimiento.SeleccionarMantenimiento(IdEquipo, TipoEquipo, "PREVENTIVO").ForEach(delegate(Fila f)
            {
                // Si el mantenimiento está pendiente cargamos esa información
                if(f.Celda("estatus").ToString() == "PENDIENTE")
                {
                    int idMantenimiento = Convert.ToInt32(f.Celda("id"));
                    TxtIdMantenimiento.Text = idMantenimiento.ToString().PadLeft(4,'0');
                    EditarInformacion = true;
                    CargarCheckList();
                    if(DgvMantenimiento.Rows.Count <= 0)
                        CargarPuntosRevision();
                }
            });

            // Se crea un nuevo registro en la tabla de mantenimiento
            if (!mantenimiento.TieneFilas())
            {
                EditarInformacion = true;
                CrearMantenimiento();
                CargarPuntosRevision();
                GuardarAvance();
            }
        }

        private void CrearMantenimiento()
        {
            Fila insertarMantenimiento = new Fila();
            insertarMantenimiento.AgregarCelda("tipo_mantenimiento", "PREVENTIVO");
            insertarMantenimiento.AgregarCelda("tipo_equipo", TipoEquipo);
            insertarMantenimiento.AgregarCelda("equipo", IdEquipo);
            insertarMantenimiento.AgregarCelda("estatus", "PENDIENTE");
            int idMantenimiento = Convert.ToInt32(Mantenimiento.Modelo().Insertar(insertarMantenimiento).Celda("id"));

            TxtIdMantenimiento.Text = idMantenimiento.ToString().PadLeft(4, '0');
        }

        private void CargarCheckList()
        {
            CheckitemsMantenimiento checkList = new CheckitemsMantenimiento();
            MantenimientoTopico topico = new MantenimientoTopico();
            Usuario usuarios = new Usuario();

            ComboBox cmbResponsables = new ComboBox();
            usuarios.SeleccionarDatos("activo=1 order by nombre",null).ForEach(delegate(Fila f)
            {
                string nombre = string.Empty;
                object objNombre = f.Celda("nombre");
                if (objNombre != null)
                    nombre = objNombre.ToString();

                object objPaterno = f.Celda("paterno");
                if (objPaterno != null)
                    nombre += " " + objPaterno.ToString();

                cmbResponsables.Items.Add(f.Celda("id").ToString() + " - " + nombre);
            });

            int rowIndex = 0;
            checkList.CargarMantenimiento(Convert.ToInt32(TxtIdMantenimiento.Text)).ForEach(delegate(Fila f)
            {
                string comentarios = "";
                object objComentarios = f.Celda("comentarios");
                if (objComentarios != null)
                    comentarios = objComentarios.ToString();

                string estatus = "";
                object objEstatus = f.Celda("estatus");
                if (objEstatus != null)
                    estatus = objEstatus.ToString();

                string accion = "";
                object objAccion = f.Celda("accion_tomada");
                if (objAccion != null)
                    accion = objAccion.ToString();

                string responsable = "";
                object objResponsable = f.Celda("responsable");
                if (objResponsable != null)
                    responsable = objResponsable.ToString();

                topico.SeleccionarTopicosPorClase(Convert.ToInt32(f.Celda("topico")), Clase);
                if(topico.TieneFilas())
                {
                    DgvMantenimiento.Rows.Add
                    (
                        "", 
                        f.Celda("id").ToString(), 
                        topico.Fila().Celda("topico"), 
                        estatus, comentarios, accion
                    );
                    
                    ((DataGridViewComboBoxColumn)DgvMantenimiento.Columns["responsable"]).DataSource = cmbResponsables.Items;
                    if(cmbResponsables.Items.Contains(responsable))
                        DgvMantenimiento.Rows[rowIndex].Cells["responsable"].Value = responsable;
                    rowIndex++;
                }
                
            });
            BtnFinalizar.Enabled = HabilitarBotonFinalizar();
        }

        private void CargarEquipo()
        {
            ListaInformacionModelo.ForEach(delegate(Fila f)
            {
                TxtEquipo.Text = f.Celda(Numero_serie).ToString();
            });
        }

        private void CargarPuntosRevision()
        {
            MantenimientoTopico topicos = new MantenimientoTopico();
            Usuario usuarios = new Usuario();

            ComboBox cmbResponsables = new ComboBox();
            usuarios.SeleccionarDatos("activo=1",null).ForEach(delegate(Fila f)
            {
                string nombre = string.Empty;
                object objNombre = f.Celda("nombre");
                if (objNombre != null)
                    nombre = objNombre.ToString();

                object objPaterno = f.Celda("paterno");
                if (objPaterno != null)
                    nombre += " " + objPaterno.ToString();

                cmbResponsables.Items.Add(f.Celda("id").ToString() + " - " + nombre);
            });

            topicos.SeleccionarTipoMantenimiento("PREVENTIVO", TipoEquipo).ForEach(delegate(Fila f)
            {
                if (Clase == f.Celda("clase").ToString())
                {
                    DgvMantenimiento.Rows.Add(f.Celda("id").ToString(), "", f.Celda("topico").ToString());
                    ((DataGridViewComboBoxColumn)DgvMantenimiento.Columns["responsable"]).DataSource = cmbResponsables.Items;
                }
            });

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
            matProyecto.AgregarCelda("estatus_autorizacion", "AUTORIZADO");
            matProyecto.AgregarCelda("comentarios_autorizacion", "AUTORIZACION AUTOMATICA DE MATERIAL PARA MAQUINADO");
            matProyecto.AgregarCelda("usuario_autorizacion", "SISTEMA");
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

        private bool HabilitarBotonFinalizar()
        {
            bool habilitar = false;
            int estatusCount = 0;

            foreach (DataGridViewRow row in DgvMantenimiento.Rows)
            {              
                object estatus = row.Cells["estatus"].Value;
                object accion = row.Cells["accion"].Value;
                object responsable = row.Cells["responsable"].Value;

                if (estatus != null)
                {
                    if (estatus.ToString() == "BIEN" || estatus.ToString() == "MAL")
                    {
                        if (responsable != null && accion != null && responsable != "" && accion != "")
                        {
                            habilitar = true;
                            BtnFinalizar.Text = "   Finalizar";
                            estatusCount++;
                        }
                        else
                        {
                            habilitar = true;
                            BtnFinalizar.Text = "   Guardar";
                            break;
                        }
                    }
                    else if (estatus.ToString() == "NO APLICA")
                    {
                        habilitar = true;
                    }
                    else if (estatus.ToString() != null)
                    {
                        habilitar = true;
                        BtnFinalizar.Text = "   Guardar";
                        break;
                    }
                }
                else
                {
                    BtnFinalizar.Text = "   Guardar";

                    if (estatusCount == 0)
                        habilitar = false;
                    else
                        habilitar = true;
                }
            }

            return habilitar;
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (BtnFinalizar.Text.Contains("Finalizar"))
                mensaje = "¿Está seguro de finalizar la revisión del mantenimiento?";
            else if (BtnFinalizar.Text.Contains("Guardar"))
                mensaje = "¿Desea guardar el avance de la revisión?";

            DialogResult result = MessageBox.Show(mensaje, "Mantenimiento preventivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvMantenimiento.Rows)
                {
                    string comentarios = "";
                    object objComentarios = row.Cells["comentarios"].Value;
                    if (objComentarios != null)
                        comentarios = objComentarios.ToString();

                    string estatus = "";
                    object objEstatus = row.Cells["estatus"].Value;
                    if (objEstatus != null)
                        estatus = objEstatus.ToString();

                    string accion = "";
                    object objAccion = row.Cells["accion"].Value;
                    if (objAccion != null)
                        accion = objAccion.ToString();

                    string responsable = Global.UsuarioActual.NombreCompleto();
                    object objResponsable = row.Cells["responsable"].Value;
                    if (objResponsable != null)
                        responsable = objResponsable.ToString();

                    if(EditarInformacion)
                    {                       
                        int checkListId = Convert.ToInt32(row.Cells["id_item"].Value);
                        CheckitemsMantenimiento checkList = new CheckitemsMantenimiento();
                        checkList.CargarDatos(checkListId);
                        checkList.Fila().ModificarCelda("estatus", estatus);
                        checkList.Fila().ModificarCelda("comentarios", comentarios);
                        checkList.Fila().ModificarCelda("accion_tomada", accion);
                        checkList.Fila().ModificarCelda("responsable", responsable);
                        checkList.GuardarDatos();                      
                    }
                    else 
                    {
                        Fila insertarRevisionMantenimiento = new Fila();
                        insertarRevisionMantenimiento.AgregarCelda("mantenimiento", Convert.ToInt32(TxtIdMantenimiento.Text));
                        insertarRevisionMantenimiento.AgregarCelda("topico", row.Cells["id_topico"].Value.ToString());
                        insertarRevisionMantenimiento.AgregarCelda("estatus", estatus);
                        insertarRevisionMantenimiento.AgregarCelda("comentarios", comentarios);
                        insertarRevisionMantenimiento.AgregarCelda("accion_tomada", accion);
                        insertarRevisionMantenimiento.AgregarCelda("responsable", responsable);

                        CheckitemsMantenimiento.Modelo().Insertar(insertarRevisionMantenimiento);
                    }
                }

                if(BtnFinalizar.Text.Contains("Finalizar"))
                {
                    Mantenimiento finalizarMantenimiento = new Mantenimiento();
                    finalizarMantenimiento.CargarDatos(Convert.ToInt32(TxtIdMantenimiento.Text));
                    finalizarMantenimiento.Fila().ModificarCelda("estatus", "TERMINADO");
                    finalizarMantenimiento.Fila().ModificarCelda("fecha", DateTime.Now);
                    finalizarMantenimiento.GuardarDatos();

                    Finalizar = true;                   
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void DgvMantenimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnFinalizar.Enabled = HabilitarBotonFinalizar();
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
            //material.Fila().ModificarCelda("estatus_compra", "CANCELADO");
            material.BorrarDatos(IdMaterialSeleccionado);
            material.GuardarDatos();
            CargarMaterial();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (EditarInformacion)
                mensaje = "Los cambios se guardarán de forma automática";
            else
                mensaje = "¿Seguro desea salir de la revisión del mantenimiento preventivo?";

             DialogResult result = MessageBox.Show(mensaje, "Mantenimiento preventivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.OK)
            {

                if (EditarInformacion)
                {
                    foreach (DataGridViewRow row in DgvMantenimiento.Rows)
                    {
                        string comentarios = "";
                        object objComentarios = row.Cells["comentarios"].Value;
                        if (objComentarios != null)
                            comentarios = objComentarios.ToString();

                        string estatus = "";
                        object objEstatus = row.Cells["estatus"].Value;
                        if (objEstatus != null)
                            estatus = objEstatus.ToString();

                        string accion = "";
                        object objAccion = row.Cells["accion"].Value;
                        if (objAccion != null)
                            accion = objAccion.ToString();

                        string responsable = "";
                        object objResponsable = row.Cells["responsable"].Value;
                        if (objResponsable != null)
                            responsable = objResponsable.ToString();

                        if (EditarInformacion)
                        {
                            int checkListId = 0;
                            
                            if(row.Cells["id_item"].Value.ToString() != string.Empty)
                            {
                                Convert.ToInt32(row.Cells["id_item"].Value);
                                
                                CheckitemsMantenimiento checkList = new CheckitemsMantenimiento();
                                checkList.CargarDatos(checkListId);
                                checkList.Fila().ModificarCelda("estatus", estatus);
                                checkList.Fila().ModificarCelda("comentarios", comentarios);
                                checkList.Fila().ModificarCelda("accion_tomada", accion);
                                checkList.Fila().ModificarCelda("responsable", responsable);
                                checkList.GuardarDatos();
                            }
                        }
                    }
                }
              //  else
                  //  GuardarAvance();

                Close();
            }
        }

        private void GuardarAvance()
        {
            foreach (DataGridViewRow row in DgvMantenimiento.Rows)
            {
                object checkListId = row.Cells["id_item"].Value;
                if (Global.ObjetoATexto(checkListId, "") != "")
                    return;

                string comentarios = "";
                object objComentarios = row.Cells["comentarios"].Value;
                if (objComentarios != null)
                    comentarios = objComentarios.ToString();

                string estatus = "";
                object objEstatus = row.Cells["estatus"].Value;
                if (objEstatus != null)
                    estatus = objEstatus.ToString();

                string accion = "";
                object objAccion = row.Cells["accion"].Value;
                if (objAccion != null)
                    accion = objAccion.ToString();

                string responsable = "";
                object objResponsable = row.Cells["responsable"].Value;
                if (objResponsable != null)
                    responsable = objResponsable.ToString();

                Fila insertarRevisionMantenimiento = new Fila();
                insertarRevisionMantenimiento.AgregarCelda("mantenimiento", Convert.ToInt32(TxtIdMantenimiento.Text));
                insertarRevisionMantenimiento.AgregarCelda("topico", row.Cells["id_topico"].Value.ToString());
                insertarRevisionMantenimiento.AgregarCelda("estatus", estatus);
                insertarRevisionMantenimiento.AgregarCelda("comentarios", comentarios);
                insertarRevisionMantenimiento.AgregarCelda("accion_tomada", accion);
                insertarRevisionMantenimiento.AgregarCelda("responsable", responsable);

                DgvMantenimiento.Rows[row.Index].Cells["id_item"].Value = Convert.ToInt32(CheckitemsMantenimiento.Modelo().Insertar(insertarRevisionMantenimiento).Celda("id"));
                //CheckitemsMantenimiento.Modelo().Insertar(insertarRevisionMantenimiento);
            }
        }

        private void DgvMantenimiento_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvMantenimiento.CurrentCell.ColumnIndex == 4 || DgvMantenimiento.CurrentCell.ColumnIndex == 5)
            {
                if (e.Control is TextBox)
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void DgvMantenimiento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BtnFinalizar.Enabled = HabilitarBotonFinalizar();
        }

        private void CmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string responsable = CmbResponsable.Text;

            DialogResult result = MessageBox.Show("¿Está seguro que desea seleccionar a " + CmbResponsable.Text +" como responsable de todos los puntos de revisión?", "Copiar responsable", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DgvMantenimiento.Rows)
                {
                    row.Cells["responsable"].Value = responsable;
                }
            }
        }
    }
}

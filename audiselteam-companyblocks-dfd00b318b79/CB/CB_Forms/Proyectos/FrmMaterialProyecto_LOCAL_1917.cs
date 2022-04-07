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
    public partial class FrmMaterialProyecto : Form
    {
        Proyecto ProyectoCargado = new Proyecto();
        int IdMaterialSeleccionado = 0;
        int ScrollPosicion = 0;
        decimal IdProyecto = 0;
        string[] FiltroTipoCompra = new string[0];

        public FrmMaterialProyecto(decimal id, string[] filtrosTipoMaterial)
        {
            InitializeComponent();
            ProyectoCargado.CargarDatos(id);
            IdProyecto = id;
            string titulo = string.Empty;

            if (id > 0)
                titulo = "MATERIAL DEL PROYECTO " + id.ToString("F2") + " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            else
                titulo = "MATERIAL INDIRECTO Y SERVICIOS";


            LblMaterial.Text = titulo; 
            FiltroTipoCompra = filtrosTipoMaterial;
        }

        private void FrmMaterialProyecto_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarCategorias();
            CargarFabricantes();

            this.WindowState = FormWindowState.Maximized;
            CmbFiltroSeleccion.Text = "PRELIMINAR";
            CmbFiltroCompra.Text = "TODOS";
            CmbFiltroFabricante.Text = "TODOS";
            CmbFiltroRequisitor.Text = Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");
            CmbFiltroCategoria.Text = "TODOS";

            agregarMaterialToolStripMenuItem.Enabled = Global.VerificarPrivilegio("MATERIAL", "REQUISITAR MATERIAL");
            DgvMaterial.Columns["subensamble"].Visible = (IdProyecto > 0);
        }

        public void CargarUsuarios()
        {
            CmbFiltroRequisitor.Items.Clear();
            CmbFiltroRequisitor.Items.Add("TODOS");

            MaterialProyecto.Modelo().Requisitores().ForEach(delegate(Fila usuario)
            {
                CmbFiltroRequisitor.Items.Add(usuario.Celda("requisitor").ToString());    
            });
        }

        public void CargarCategorias()
        {
            CmbFiltroCategoria.Items.Clear();
            CmbFiltroCategoria.Items.Add("TODOS");

            CatalogoMaterial.Modelo().Categorias(FiltroTipoCompra).ForEach(delegate(Fila categoria)
            {
                CmbFiltroCategoria.Items.Add(categoria.Celda("categoria").ToString());
            });
        }

        public void CargarFabricantes()
        {
            CmbFiltroFabricante.Items.Clear();
            CmbFiltroFabricante.Items.Add("TODOS");

            MaterialProyecto.Modelo().Fabricantes().ForEach(delegate(Fila fabricante)
            {
                CmbFiltroFabricante.Items.Add(fabricante.Celda("fabricante").ToString());
            });
        }

       

        public void CargarMaterial(string estatusSeleccion="PRELIMINAR", string estatusAutorizacion="TODOS", string estatusCompra="TODOS", string requisitor="TODOS", string categoria="TODOS", string fabricante="TODOS")
        {
            decimal idProyecto = Convert.ToDecimal(ProyectoCargado.Fila().Celda("id"));
            List<Fila> material = new List<Fila>();

            material = MaterialProyecto.Modelo().Filtrar(idProyecto, estatusSeleccion, estatusAutorizacion, estatusCompra, requisitor, categoria, fabricante);

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvMaterial);

            DgvMaterial.Rows.Clear();
            material.ForEach(delegate(Fila mat)
            {
                string strTotal = "";

                if (mat.Celda("tipo_venta").ToString() == "POR PIEZA")
                    strTotal = mat.Celda("total").ToString() + " pieza(s)";
                else
                    strTotal = mat.Celda("total").ToString() + " paquete(s) con " + mat.Celda("piezas_paquete").ToString() + " piezas c/u";

                int accesorioPara = Convert.ToInt32(mat.Celda("accesorio_para"));
                string strAccesorioPara = "";
                if (accesorioPara > 0)
                    strAccesorioPara = "Req. #" + accesorioPara;
                else
                    strAccesorioPara = "N/A";

                Object fc = mat.Celda("fecha_creacion");
                string fechaCreacion = "N/A";
                
                if( fc != null )
                    fechaCreacion = Convert.ToDateTime(fc).ToString("MMM dd, yyyy hh:mm:ss tt");

                Object te = mat.Celda("tiempo_entrega_estimado");
                int iTiempoEstimadoEntrega = 0;
                string tiempoEstimadoEntrega = "N/A";

                Object obSubensamble = mat.Celda("subensamble");
                string  subensamble = "";
                if (obSubensamble != null)
                    subensamble = Convert.ToInt32(mat.Celda("subensamble")).ToString("D2");

                if(te != null)
                {
                    iTiempoEstimadoEntrega = Convert.ToInt32(te);

                    if(iTiempoEstimadoEntrega > 0)
                        tiempoEstimadoEntrega = te.ToString();
                }

                Object eta = mat.Celda("eta");
                string fechaEstimadaEntrega = "N/A";

                if (eta != null)
                    fechaEstimadaEntrega = Convert.ToDateTime(eta).ToString("MMM dd, yyyy");

                DgvMaterial.Rows.Add(
                                     mat.Celda("id"), 
                                     fechaCreacion, 
                                     mat.Celda("requisitor"), 
                                     mat.Celda("categoria"), 
                                     mat.Celda("numero_parte"), 
                                     mat.Celda("fabricante"), 
                                     mat.Celda("descripcion"), 
                                     mat.Celda("piezas_requeridas").ToString(), 
                                     strTotal, 
                                     strAccesorioPara, 
                                     mat.Celda("estatus_autorizacion"), 
                                     mat.Celda("estatus_compra"), 
                                     mat.Celda("estatus_almacen"), 
                                     tiempoEstimadoEntrega, 
                                     fechaEstimadaEntrega,
                                     subensamble);

                DataGridViewCell celdaNumeroParte = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["numero_parte"];
                DataGridViewCell celdaAutorizacion = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_autorizacion"];
                DataGridViewCell celdaCompra = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_compra"];
                DataGridViewCell celdaAlmacen = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_almacen"];

                if( Convert.ToInt32(mat.Celda("accesorio_para")) > 0 )
                {
                    DgvMaterial.Rows[DgvMaterial.RowCount - 1].DefaultCellStyle.ForeColor = Color.Gray;
                }

                if( celdaAutorizacion.Value.ToString() == "RECHAZADO" )
                {
                    celdaAutorizacion.Style.BackColor = Color.Red;
                    celdaAutorizacion.Style.ForeColor = Color.White;
                }
                else if( celdaAutorizacion.Value.ToString() == "AUTORIZADO" )
                {
                    celdaAutorizacion.Style.BackColor = Color.LightGreen;
                }
                if(celdaCompra.Value.ToString() == "ORDENADO")
                {
                    celdaCompra.Style.BackColor = Color.LightGreen;
                }
                if(celdaAlmacen.Value.ToString() == "RECIBIDO" || celdaAlmacen.Value.ToString() == "ENTREGADO")
                {
                    celdaAlmacen.Style.BackColor = Color.LightGreen;
                }
            });

            LblUltimaActualizacion.Text = "Ultima actualización: " + DateTime.Now.ToString("MMM dd yyyy, hh:mm:ss tt");

            ConfiguracionDataGridView.Recuperar(cfg, DgvMaterial);

            modificarCantidadToolStripMenuItem.Enabled = false;
            agregarComentarioToolStripMenuItem.Enabled = false;
            reemplazarToolStripMenuItem1.Enabled = false;
            definirToolStripMenuItem.Enabled = false;
            borrarToolStripMenuItem.Enabled = false;
            verDetallesToolStripMenuItem.Enabled = false;
            modificarCantidadSubensambleTool.Enabled = false;

            menuDefinidoIngresarComentario.Enabled = false;
            reemplazarToolStripMenuItem.Enabled = false;
            autorizarToolStripMenuItem.Enabled = false;
            rechazarToolStripMenuItem1.Enabled = false;
            detallesMaterialDefinido.Enabled = false;
            cancelarToolStripMenuItem.Enabled = false;
            cancelartoolStripMenuItem1.Enabled = false;

            if (ScrollPosicion != 0 && ScrollPosicion < DgvMaterial.Rows.Count)
                DgvMaterial.FirstDisplayedScrollingRowIndex = ScrollPosicion;   
        }

        private void CmbFiltroEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFiltroSeleccion.Text == "DEFINIDO")
            {
                CmbFiltroAutorizacion.Text = "TODOS";
                CmbFiltroAutorizacion.Enabled = true;
                CmbFiltroCompra.Enabled = true;
                BtnOpciones.ContextMenuStrip = OpcionesMaterialDefinido;
            }
            else if(CmbFiltroSeleccion.Text == "PRELIMINAR")
            {
                CmbFiltroAutorizacion.Text = "PENDIENTE";
                CmbFiltroAutorizacion.Enabled = false;
                CmbFiltroCompra.Text = "TODOS";
                CmbFiltroCompra.Enabled = false;
                BtnOpciones.ContextMenuStrip = OpcionesMaterialPreliminar;
            }

            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            BorrarDatosMaterial();
        }

        public void BorrarDatosMaterial()
        {
            //BtnOpcionesMaterial.Enabled = false;
        }

        private void DgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvMaterial.SelectedRows.Count > 0)
            {
                IdMaterialSeleccionado = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["id_req"].Value);
                string estatus_compra = DgvMaterial.SelectedRows[0].Cells["estatus_compra"].Value.ToString();
                string estatus_autorizacion = DgvMaterial.SelectedRows[0].Cells["estatus_autorizacion"].Value.ToString();

                modificarCantidadToolStripMenuItem.Enabled = true;
                agregarComentarioToolStripMenuItem.Enabled = true;
                modificarCantidadSubensambleTool.Enabled = true;
                reemplazarToolStripMenuItem1.Enabled = estatus_compra == "PENDIENTE" || estatus_compra == "EN COTIZACION";
                definirToolStripMenuItem.Enabled = Global.VerificarPrivilegio("MATERIAL", "DEFINIR MATERIAL");
                borrarToolStripMenuItem.Enabled = true;
                verDetallesToolStripMenuItem.Enabled = true;

                menuDefinidoIngresarComentario.Enabled = true;
                reemplazarToolStripMenuItem.Enabled = estatus_compra == "PENDIENTE" || estatus_compra == "EN COTIZACION";
                autorizarToolStripMenuItem.Enabled = Global.VerificarPrivilegio("MATERIAL", "AUTORIZAR MATERIAL") && estatus_autorizacion == "PENDIENTE";
                rechazarToolStripMenuItem1.Enabled = Global.VerificarPrivilegio("MATERIAL", "RECHAZAR MATERIAL") && estatus_autorizacion == "PENDIENTE";
                detallesMaterialDefinido.Enabled = true;
                cancelarToolStripMenuItem.Enabled = true;
                cancelartoolStripMenuItem1.Enabled = true;

                int guardarScroll = 0;
                if (DgvMaterial.Rows.Count > 0)
                    guardarScroll = DgvMaterial.FirstDisplayedCell.RowIndex;

                ScrollPosicion = guardarScroll;
            }

            
        }

        private void BtnOpcionesMaterial_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvMaterial.SelectedRows.Count <= 0)
                return;

            DialogResult respuesta = MessageBox.Show("Seguro que deseas borrar el material seleccionado?", "Borrar material", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if( respuesta == System.Windows.Forms.DialogResult.Yes )
            {
                foreach(DataGridViewRow row in DgvMaterial.SelectedRows)
                {
                    int idMaterial = (int)row.Cells[0].Value;

                    MaterialProyecto mat = new MaterialProyecto();
                    mat.CargarDatos(idMaterial);

                    string titulo = "Requisición borrada";
                    string contenido = Global.UsuarioActual.NombreCompleto();
                    contenido += " ha borrado la requisición de material #" + IdMaterialSeleccionado + " del proyecto " + mat.Fila().Celda("proyecto").ToString();

                    mat.BorrarDatos();
                    BorrarDatosMaterial();
                    CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);

                    Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                    Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                    Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                    Evento.Modelo().Crear(titulo, contenido, "PROGRAMADOR");
                }
            }
        }
     
        private void modificarCantidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialProyecto mat = new MaterialProyecto();
            mat.CargarDatos(IdMaterialSeleccionado);

            FrmCantidadMaterial cantidad = new FrmCantidadMaterial( (int)(mat.Fila().Celda("piezas_requeridas")) );

            if (cantidad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int total = 0;
                int piezasPaquete = Convert.ToInt32(mat.Fila().Celda("piezas_paquete"));
                int piezasStock = 0;

                if( mat.Fila().Celda("tipo_venta").ToString() == "POR PAQUETE" )
                {
                    decimal piezasEntrePaquete = (decimal)cantidad.Piezas / (decimal)piezasPaquete;
                    total = (int)Math.Ceiling(piezasEntrePaquete);
                    piezasStock = (total * piezasPaquete) - cantidad.Piezas;
                }
                else
                {
                    total = cantidad.Piezas;
                }

                mat.Fila().ModificarCelda("piezas_requeridas", cantidad.Piezas);
                mat.Fila().ModificarCelda("piezas_stock", piezasStock);
                mat.Fila().ModificarCelda("piezas_paquete", piezasPaquete);
                mat.Fila().ModificarCelda("total", total);
                mat.GuardarDatos();

                string titulo = "Cantidad modificada";
                string contenido = Global.UsuarioActual.NombreCompleto();
                contenido += " ha modificado la cantidad de la requisición de material #" + IdMaterialSeleccionado + " del proyecto " + mat.Fila().Celda("proyecto");

                Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                Evento.Modelo().Crear(titulo, contenido, "PROGRAMADOR");

                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
                //BtnOpcionesMaterial.Enabled = true;
                //MostrarDatosMaterial(IdMaterialSeleccionado);
            }
        }

        private void definirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Seguro que deseas definir el material seleccionado?", "Definir material", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        
            if( resultado == System.Windows.Forms.DialogResult.Yes )
            {
                string idProyecto = ""; 
                foreach(DataGridViewRow row in DgvMaterial.SelectedRows)
                {
                    MaterialProyecto mat = new MaterialProyecto();
                    mat.CargarDatos( Convert.ToInt32(row.Cells["id_req"].Value) );
                    mat.Fila().ModificarCelda("estatus_seleccion", "DEFINIDO");
                    idProyecto = mat.Fila().Celda("proyecto").ToString();
                    mat.GuardarDatos();
                }

                string titulo = "Material definido";
                string contenido = Global.UsuarioActual.NombreCompleto();
                contenido += " ha definido el material de la requisición #" + IdMaterialSeleccionado + " del proyecto " + idProyecto;

                Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                Evento.Modelo().Crear(titulo, contenido, "PROGRAMADOR");

                BorrarDatosMaterial();
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            }
        }

        private void autorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Seguro que deseas autorizar la compra del material seleccionado?", "Autorizar material", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if( resultado == System.Windows.Forms.DialogResult.Yes )
            {
                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos( IdMaterialSeleccionado );
                mat.Fila().ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                mat.Fila().ModificarCelda("usuario_autorizacion", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
                mat.Fila().ModificarCelda("fecha_autorizacion", DateTime.Now);
                mat.GuardarDatos();

                string titulo = "Material autorizado";
                string contenido = Global.UsuarioActual.NombreCompleto();
                contenido += " ha autorizado la requisición de material #" + IdMaterialSeleccionado + " del proyecto " + mat.Fila().Celda("proyecto").ToString();

                Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");

                BorrarDatosMaterial();
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            }
        }

        private void rechazarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRechazarMaterial rech = new FrmRechazarMaterial();

            if ( rech.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(IdMaterialSeleccionado);

                mat.Fila().ModificarCelda("estatus_autorizacion", "RECHAZADO");
                mat.Fila().ModificarCelda("estatus_compra", "N/A");
                mat.Fila().ModificarCelda("comentarios_autorizacion", rech.Comentarios);
                mat.Fila().ModificarCelda("usuario_autorizacion", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
                mat.Fila().ModificarCelda("fecha_autorizacion", DateTime.Now);
                mat.GuardarDatos();

                string titulo = "Material rechazado";
                string contenido = Global.UsuarioActual.NombreCompleto();
                contenido += " ha rechazado la requisición de material #" + IdMaterialSeleccionado + " del proyecto " + mat.Fila().Celda("proyecto");

                Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");

                BorrarDatosMaterial();
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            }
        }

        private void CmbFiltroAutorizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMaterial.Columns["estatus_autorizacion"].Visible = CmbFiltroAutorizacion.Text == "TODOS";
            
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
        }

        private void agregarComentarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresarComentario();
        }

        public void IngresarComentario()
        {
            FrmIngresarComentario com = new FrmIngresarComentario();

            if (com.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(IdMaterialSeleccionado);

                string comentarios = "";
                object comentarios_actuales = mat.Fila().Celda("comentarios_requisitor");
                if (comentarios_actuales != null)
                    comentarios += comentarios_actuales.ToString() + Environment.NewLine + Environment.NewLine; ;

                string usuario = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();

                DateTime dt = DateTime.Now;
                comentarios += "[" + usuario + " @ " + dt.ToString("MMM dd yyyy, hh:mm tt") + "] " + com.Comentarios;

                mat.Fila().ModificarCelda("comentarios_requisitor", comentarios);
                mat.GuardarDatos();

                string titulo = "Comentario de requisición";
                string contenido = Global.UsuarioActual.NombreCompleto();
                contenido += " ha capturado un comentario en la requisición de material #" + IdMaterialSeleccionado;

                Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                Evento.Modelo().Crear(titulo, contenido, "PROGRAMADOR");
            }
        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetallesMaterialProyecto det = new FrmDetallesMaterialProyecto(IdMaterialSeleccionado);
            det.ShowDialog();
        }

        private void detallesMaterialDefinido_Click(object sender, EventArgs e)
        {
            FrmDetallesMaterialProyecto det = new FrmDetallesMaterialProyecto(IdMaterialSeleccionado);
            det.ShowDialog();
        }

        private void menuDefinidoIngresarComentario_Click(object sender, EventArgs e)
        {
            IngresarComentario();
        }

        private void reemplazarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reemplazar();
        }

        public void Reemplazar()
        {
            //FrmSeleccionarMaterialCatalogo2 sel = new FrmSeleccionarMaterialCatalogo2(FiltroTipoCompra.ToList(), true, true, Convert.ToInt32(ProyectoCargado.Fila().Celda("id")));
            FrmSeleccionarMaterialCatalogo sel = new FrmSeleccionarMaterialCatalogo( true, true);
            if (sel.ShowDialog() == DialogResult.OK)
            {
                CatalogoMaterial cat = new CatalogoMaterial();
                cat.CargarDatos(sel.idMaterial);

                string tipo_venta = cat.Fila().Celda("tipo_venta").ToString();
                int piezas_paquete = Convert.ToInt32(cat.Fila().Celda("piezas_paquete"));
                int total = 0;
                int piezas_stock = 0;

                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(IdMaterialSeleccionado);

                if (tipo_venta == "POR PAQUETE")
                {
                    decimal piezasEntrePaquete = (decimal)sel.CantidadMaterial / (decimal)piezas_paquete;
                    total = (int)Math.Ceiling(piezasEntrePaquete);
                    piezas_stock = (total * piezas_paquete) - sel.CantidadMaterial;
                }
                else
                {
                    total = sel.CantidadMaterial;
                }

                if (mat.TieneFilas())
                {
                    mat.Fila().ModificarCelda("numero_parte", cat.Fila().Celda("numero_parte"));
                    mat.Fila().ModificarCelda("fabricante", cat.Fila().Celda("fabricante"));
                    mat.Fila().ModificarCelda("descripcion", cat.Fila().Celda("descripcion"));
                    mat.Fila().ModificarCelda("piezas_requeridas", sel.CantidadMaterial);
                    mat.Fila().ModificarCelda("piezas_stock", piezas_stock);
                    mat.Fila().ModificarCelda("total", total);
                    mat.Fila().ModificarCelda("tipo_venta", tipo_venta);
                    mat.Fila().ModificarCelda("piezas_paquete", piezas_paquete);
                    mat.Fila().ModificarCelda("po", 0);
                    mat.Fila().ModificarCelda("estatus_autorizacion", "PENDIENTE");
                    mat.Fila().ModificarCelda("estatus_compra", "PENDIENTE");
                    mat.Fila().ModificarCelda("requisitor", Global.UsuarioActual.NombreCompleto());
                    // mat.Fila().ModificarCelda("tipo_compra", );

                    mat.GuardarDatos();

                    string titulo = "Material reemplazado";
                    string contenido = Global.UsuarioActual.NombreCompleto();
                    contenido += " ha reemplazado la requisición de material #" + IdMaterialSeleccionado + " del proyecto " + mat.Fila().Celda("proyecto").ToString();

                    Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                    Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                    Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");

                } CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            }
        }

        private void reemplazarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reemplazar();
        }

        private void agregarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmSeleccionarMaterialCatalogo2 selec = new FrmSeleccionarMaterialCatalogo2(FiltroTipoCompra.ToList(), true, true, IdProyecto);
            FrmSeleccionarMaterialCatalogo selec = new FrmSeleccionarMaterialCatalogo( true, true);

            if( selec.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                int IdReqPrincipal =  CrearRequisicionMaterial(selec.idMaterial, selec.CantidadMaterial, selec.Subensamble);
                MaterialProyecto ReqPrincipal = new MaterialProyecto();
                ReqPrincipal.CargarDatos(IdReqPrincipal);

                int PiezasRequeridas = Convert.ToInt32(ReqPrincipal.Fila().Celda("piezas_requeridas"));

                List<Fila> accesorios = AccesorioMaterial.Modelo().TiposAccesorios(selec.idMaterial);

                if( accesorios.Count > 0 )
                {
                    FrmConfigurarAccesoriosMaterial config = new FrmConfigurarAccesoriosMaterial(selec.idMaterial, selec.CantidadMaterial);

                    if( config.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                    {
                        config.Accesorios.ForEach(delegate(Fila f)
                        {
                            int id_accesorio = Convert.ToInt32(f.Celda("id_accesorio"));
                            int piezas_requeridas_accesorio = Convert.ToInt32(f.Celda("piezas_requeridas_accesorio"));

                            CrearRequisicionMaterial(id_accesorio, piezas_requeridas_accesorio*PiezasRequeridas, selec.Subensamble, IdReqPrincipal);
                        });
                    }
                }
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            }
        }

        public int CrearRequisicionMaterial(int idCatalogo, int cantidad, int subensamble, int accesorioPara=0)
        {
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
            string idProyecto = Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2"); 

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
            matProyecto.AgregarCelda("estatus_seleccion", "PRELIMINAR");
            matProyecto.AgregarCelda("estatus_compra", "PENDIENTE");
            matProyecto.AgregarCelda("accesorio_para", accesorioPara);
            matProyecto.AgregarCelda("fecha_creacion", DateTime.Now);
            matProyecto.AgregarCelda("subensamble", subensamble);
            matProyecto.AgregarCelda("subcategoria", material.Fila().Celda("subcategoria_ref"));

            matProyecto = MaterialProyecto.Modelo().Insertar(matProyecto);

            string titulo = "Nueva requisición de material";
            string contenido = "";
            contenido += Global.UsuarioActual.NombreCompleto();
            contenido += " creó la requisición de material #" + matProyecto.Celda("id").ToString() + " para el proyecto " + idProyecto.ToString();

            Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");

            return Convert.ToInt32(matProyecto.Celda("id"));
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
        }

        private void CmbFiltroCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMaterial.Columns["estatus_compra"].Visible = CmbFiltroCompra.Text == "TODOS";
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
        }

        private void CmbFiltroRequisitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMaterial.Columns["requisitor"].Visible = CmbFiltroRequisitor.Text == "TODOS";
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
        }

        private void CmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMaterial.Columns["categoria"].Visible = CmbFiltroCategoria.Text == "TODOS";
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
        }

        private void CmbFiltroFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMaterial.Columns["fabricante"].Visible = CmbFiltroFabricante.Text == "TODOS";
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
        }

        private void DgvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmDetallesMaterialProyecto det = new FrmDetallesMaterialProyecto(IdMaterialSeleccionado);
            det.ShowDialog();
        }

        private void copiarDesdeProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCopiarMaterialProyecto copiar = new FrmCopiarMaterialProyecto(Convert.ToDecimal( ProyectoCargado.Fila().Celda("id")));
            
            if( copiar.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            }
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            material.Fila().ModificarCelda("estatus_compra", "CANCELADO");
            material.GuardarDatos();
            CargarMaterial();
        }

        private void cancelartoolStripMenuItem1_Click(object sender, EventArgs e)
        {
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
            material.Fila().ModificarCelda("estatus_compra", "CANCELADO");
            material.GuardarDatos();
            CargarMaterial();
        }

        private void modificarCantidadSubensambleTool_Click(object sender, EventArgs e)
        {
            int subensable  =  Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["Subensamble"].Value);
            FrmIngresarSubEnsamble subensamble = new FrmIngresarSubEnsamble(true, subensable);
            if(subensamble.ShowDialog() ==  System.Windows.Forms.DialogResult.OK)
            {
                MaterialProyecto material = new MaterialProyecto();
                material.CargarDatos(IdMaterialSeleccionado);

                if (material.TieneFilas())
                {
                    material.Fila().ModificarCelda("subensamble", subensamble.Subensamble);
                    material.GuardarDatos();
                }
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            }
        }

        private void OpcionesMaterialDefinido_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}

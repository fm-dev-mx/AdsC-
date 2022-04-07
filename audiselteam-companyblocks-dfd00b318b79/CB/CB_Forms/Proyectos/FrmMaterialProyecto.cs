using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmMaterialProyecto : Form
    {
        Proyecto ProyectoCargado = new Proyecto();
        MaterialProyecto BuscadorMaterial = new MaterialProyecto();

        int IdMaterialSeleccionado = 0;
        int ScrollPosicion = 0;
        decimal IdProyecto = 0;
        string[] FiltroTipoCompra = new string[0];
        bool MostrarTodasLasCategorias = false;
        bool MostrarCancelados = false;
        string[] TipoCompra = null;
        List<Fila> MaterialParaReporte = new List<Fila>();

        string[] FiltroFilatradoCompra {
            get {
                if (MostrarTodasLasCategorias && CmbFiltroTipo.Text == "TODOS")
                {
                    return new string[0];
                } 
                else 
                    if(CmbFiltroTipo.Text == "TODOS")
                {
                    return FiltroTipoCompra;
                }
                else 
                {
                    return new string[]{
                        CmbFiltroTipo.Text
                    };
                }
            }
        }

        public FrmMaterialProyecto(decimal id, string[] filtrosTipoMaterial, bool mostrarTodasLasCategorias = false)
        {
            InitializeComponent();
            ProyectoCargado.CargarDatos(id);
            IdProyecto = id;
            string titulo = string.Empty;

            if (id > 0)
                titulo = "COMPRAS DEL PROYECTO " + id.ToString("F2") + " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            else
                titulo = "COMPRAS INDIRECTAS Y SERVICIOS";

            LblMaterial.Text = titulo; 
            FiltroTipoCompra = filtrosTipoMaterial;
            MostrarTodasLasCategorias = mostrarTodasLasCategorias;
        }

        private void CargarFiltros()
        {
            //requisitor
            //fabricante
            //categoria
            //tipoCompra
            //estatus autorizacion
            //estatus seleccion
            //estatus compra
            //modulo
            BuscadorMaterial.Filtros.Add(new Filtro("requisitor", "Requisitor", BuscadorMaterial.Requisitores(IdProyecto)));
            BuscadorMaterial.Filtros[0].DesactivarTodos();
            BuscadorMaterial.Filtros.Add(new Filtro("fabricante", "Fabricante", BuscadorMaterial.Fabricantes(IdProyecto)));
            //BuscadorMaterial.Filtros.Add(new Filtro("nombre", "Subcategoría", BuscadorMaterial.CategoriasDeMaterialPorProyecto(IdProyecto)));
            //BuscadorMaterial.Filtros.Add(new Filtro("nombre", "Tipo de compra", BuscadorMaterial.TipoDeCompraDeMaterialPorProyecto(IdProyecto)));
            BuscadorMaterial.Filtros.Add(new Filtro("estatus_autorizacion", "Estatus autorización", BuscadorMaterial.EstatusAutorizacion()));
            BuscadorMaterial.Filtros[2].DesactivarTodos();
            BuscadorMaterial.Filtros[2].ModificarFiltro("AUTORIZADO", true);
            BuscadorMaterial.Filtros[2].ModificarFiltro("PENDIENTE", true);
            BuscadorMaterial.Filtros[2].ModificarFiltro("N/A", true);
            BuscadorMaterial.Filtros.Add(new Filtro("estatus_seleccion", "Estatus selección", BuscadorMaterial.EstatusSeleccion()));
            BuscadorMaterial.Filtros[3].DesactivarTodos();
            BuscadorMaterial.Filtros[3].ModificarFiltro("DEFINIDO", true);
            BuscadorMaterial.Filtros[3].ModificarFiltro("PRELIMINAR", true);
            BuscadorMaterial.Filtros.Add(new Filtro("estatus_compra", "Estatus compra", BuscadorMaterial.EstatusCompra()));
            //BuscadorMaterial.Filtros.Add(new Filtro("subensamble", "Subensamble", BuscadorMaterial.ModulosDeProyecto(IdProyecto)));
        }

        private void FrmMaterialProyecto_Load(object sender, EventArgs e)
        {
            //CargarFiltros();
            CargarEstatusCompra();
            CargarUsuarios();
            CargarCategorias();
            CargarTiposCompras();            
            CargarFabricantes();
            CargarModulos();

            this.WindowState = FormWindowState.Maximized;
            CmbFiltroSeleccion.Text = "PRELIMINAR";
            CmbFiltroCompra.Text = "TODOS";
            CmbFiltroFabricante.Text = "TODOS";
            CmbFiltroRequisitor.Text = Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");
            CmbFiltroCategoria.Text = "TODOS";
            CmbFiltroTipo.SelectedIndex = 0;
            CmbFiltroModulo.Text = "TODOS";
            DgvMaterial.Columns["total_compra"].Visible = Global.VerificarPrivilegio("ADMINISTRAR", "INFORMACION SENSIBLE");

            agregarMaterialToolStripMenuItem.Enabled = Global.VerificarPrivilegio("MATERIAL", "REQUISITAR MATERIAL");
            DgvMaterial.Columns["subensamble"].Visible = (IdProyecto > 0);
        }

        private void CargarEstatusCompra()
        {
            CmbFiltroCompra.Items.Clear();
            CmbFiltroCompra.Items.Add("TODOS");

            CmbFiltroCompra.Items.AddRange(new string[]{
                "PENDIENTE",
                "EN COTIZACION",
                "EN REVISIÓN TÉCNICA",
                "EN PLANIFICACION",
                "COMPRA RECHAZADA",
                "EN REVISION FINANCIERA",
                "COMPRA DETENIDA",
                "LISTO PARA ORDENAR",
                "ORDEN ASIGNADA",
                "ORDENADO",
                "RECIBIDO",
                "ENTREGADO"
            });

            // CmbFiltroCompra.SelectedIndex = 0;
            CmbFiltroCompra.Text = "TODOS";
        }

        public void CargarUsuarios()
        {
            CmbFiltroRequisitor.Items.Clear();
            CmbFiltroRequisitor.Items.Add("TODOS");

            MaterialProyecto.Modelo().Requisitores(IdProyecto).ForEach(delegate(Fila usuario)
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

            MaterialProyecto.Modelo().Fabricantes(IdProyecto).ForEach(delegate(Fila fabricante)
            {
                CmbFiltroFabricante.Items.Add(fabricante.Celda("fabricante").ToString());
            });
        }

        public void CargarTiposCompras()
        {
            CmbFiltroTipo.Items.Clear();
            CmbFiltroTipo.Items.Add("TODOS");

            foreach(string tipo in FiltroTipoCompra)
            {
                CmbFiltroTipo.Items.Add(tipo);
            }
        }

        public void CargarModulos()
        {
            CmbFiltroModulo.Items.Clear();
            CmbFiltroModulo.Items.Add("TODOS");            

            int ban = 0;
            CatalogoMaterial.Modelo().Modulos(IdProyecto).ForEach(delegate (Fila modulo)
            {
                if (modulo.Celda("subensamble").ToString() == "0")
                    ban++;
            });

            if(ban<=0)
                CmbFiltroModulo.Items.Add("00 - COMPRAS GENERALES");

            CatalogoMaterial.Modelo().Modulos(IdProyecto).ForEach(delegate (Fila modulo)
            {
                CmbFiltroModulo.Items.Add(modulo.Celda("subensamble").ToString().PadLeft(2, '0') + " - " + modulo.Celda("nombre").ToString());
            });
        }

        public void CargarMaterial(string estatusSeleccion="PRELIMINAR", string estatusAutorizacion="TODOS", string estatusCompra="TODOS", string requisitor="TODOS", 
            string categoria="TODOS", string fabricante="TODOS", string[] tipoCompra=null, string modulo="TODOS", bool mostrarCancelados = false)
        {
            CmbFiltroSeleccion.Enabled = false; 
            CmbFiltroAutorizacion.Enabled = false; 
            CmbFiltroCompra.Enabled = false;
            CmbFiltroRequisitor.Enabled = false;
            CmbFiltroCategoria.Enabled = false;
            CmbFiltroFabricante.Enabled = false;
            CmbFiltroModulo.Enabled = false;
            CmbFiltroTipo.Enabled = false;
            MenuGeneral.Enabled = false;
            TipoCompra = tipoCompra;
            BtnActualizar.Enabled = false;
            BtnReportes.Enabled = false;
            BarraProgresoAsignaciones.Visible = true;
            DgvMaterial.Columns["total_compra"].Visible = Global.VerificarPrivilegio("ADMINISTRAR", "INFORMACION SENSIBLE");
            DgvMaterial.Rows.Clear();

            string[] argumentos = new string[] {estatusSeleccion, estatusAutorizacion, estatusCompra, requisitor, categoria, fabricante, modulo };
            if(!BkgDescargarMaterial.IsBusy)
                BkgDescargarMaterial.RunWorkerAsync(argumentos);
            
        }

        private void BkgDescargarMaterial_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] argumentos = (string[])e.Argument;
            string estatusSeleccion = argumentos[0];
            string estatusAutorizacion = argumentos[1];
            string estatusCompra = argumentos[2];
            string requisitor = argumentos[3];
            string categoria = argumentos[4];
            string fabricante = argumentos[5];
            string modulo = argumentos[6];
            string[] tipoCompra = TipoCompra;
            bool mostrarCancelados = MostrarCancelados;
            int avance = 0;
            MaterialParaReporte.Clear();

            decimal idProyecto = Convert.ToDecimal(ProyectoCargado.Fila().Celda("id"));
            List<Fila> material = new List<Fila>();

            material = MaterialProyecto.Modelo().Filtrar(idProyecto, estatusSeleccion, estatusAutorizacion, estatusCompra, requisitor, categoria, fabricante, tipoCompra, modulo, mostrarCancelados);
            
           
            material.ForEach(delegate (Fila mat)
            {
                if (BkgDescargarMaterial.CancellationPending)
                    e.Cancel = true;

                if (!e.Cancel)
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

                    if (fc != null)
                        fechaCreacion = Convert.ToDateTime(fc).ToString("MMM dd, yyyy hh:mm:ss tt");

                    Object te = mat.Celda("tiempo_entrega_estimado");
                    int iTiempoEstimadoEntrega = 0;
                    string tiempoEstimadoEntrega = "N/A";

                    Object obSubensamble = mat.Celda("subensamble");
                    string subensamble = "";
                    if (obSubensamble != null)
                        subensamble = Convert.ToInt32(mat.Celda("subensamble")).ToString("D2");

                    if (te != null)
                    {
                        iTiempoEstimadoEntrega = Convert.ToInt32(te);

                        if (iTiempoEstimadoEntrega > 0)
                            tiempoEstimadoEntrega = te.ToString();
                    }

                    string tiempoEntregaReal = "N/A";


                    if (Convert.ToInt32(mat.Celda("rfq_concepto")) > 0)
                    {
                        RfqConcepto materialConcepto = new RfqConcepto();
                        materialConcepto.CargarDatos(Convert.ToInt32(mat.Celda("rfq_concepto")));

                        if (materialConcepto.TieneFilas())
                        {
                            if (materialConcepto.Fila().Celda<int>("tiempo_entrega") > 0)
                                tiempoEntregaReal = materialConcepto.Fila().Celda("tiempo_entrega").ToString();
                        }
                    }

                    string precioSumaFinal = "SIN CAPTURAR";

                    object objPrecioSumaFinal = mat.Celda("precio_suma_final");
                    object objPrecioMoneda = mat.Celda("precio_moneda");

                    if (objPrecioSumaFinal != null)
                    {
                        if(Convert.ToDecimal(objPrecioSumaFinal) > 0)
                        {
                            precioSumaFinal = Convert.ToDouble(objPrecioSumaFinal).ToString("C2") + " " + objPrecioMoneda.ToString();
                        }
                    }

                    Object eta = mat.Celda("eta");
                    string fechaEstimadaEntrega = "N/A";

                    if (eta != null)
                        fechaEstimadaEntrega = Convert.ToDateTime(eta).ToString("MMM dd, yyyy");

                    Fila filaInformacion = new Fila();

                    filaInformacion.AgregarCelda("id", mat.Celda("id"));
                    filaInformacion.AgregarCelda("fechaCreacion", fechaCreacion);
                    filaInformacion.AgregarCelda("requisitor", mat.Celda("requisitor"));
                    filaInformacion.AgregarCelda("categoria_real", mat.Celda("categoria_real"));
                    filaInformacion.AgregarCelda("numero_parte", mat.Celda("numero_parte"));
                    filaInformacion.AgregarCelda("fabricante", mat.Celda("fabricante"));
                    filaInformacion.AgregarCelda("descripcion", mat.Celda("descripcion"));
                    filaInformacion.AgregarCelda("piezas_requeridas", mat.Celda("piezas_requeridas"));
                    filaInformacion.AgregarCelda("strTotal", strTotal);
                    filaInformacion.AgregarCelda("precio_suma_final", precioSumaFinal);
                    filaInformacion.AgregarCelda("strAccesorioPara", strAccesorioPara);
                    filaInformacion.AgregarCelda("estatus_compra", mat.Celda("estatus_compra"));
                    filaInformacion.AgregarCelda("estatus_autorizacion", mat.Celda("estatus_autorizacion"));
                    filaInformacion.AgregarCelda("estatus_financiero", mat.Celda("estatus_financiero"));
                    filaInformacion.AgregarCelda("estatus_almacen", mat.Celda("estatus_almacen"));
                    filaInformacion.AgregarCelda("tiempoEstimadoEntrega", tiempoEstimadoEntrega);
                    filaInformacion.AgregarCelda("tiempoEntregaReal", tiempoEntregaReal);
                    filaInformacion.AgregarCelda("fechaEstimadaEntrega", fechaEstimadaEntrega);
                    filaInformacion.AgregarCelda("subensamble", subensamble);
                    filaInformacion.AgregarCelda("accesorio_para", mat.Celda("accesorio_para"));
                    filaInformacion.AgregarCelda("permitir_revision_tecnica", mat.Celda("permitir_revision_tecnica"));
                    filaInformacion.AgregarCelda("usuario_permiso", mat.Celda("usuario_permiso"));
                    avance++;

                    MaterialParaReporte.Add(filaInformacion);
                    BkgDescargarMaterial.ReportProgress(Global.CalcularPorcentaje(avance, material.Count), filaInformacion);

                }
            });
        }

        private void BkgDescargarMaterial_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (!BkgDescargarMaterial.CancellationPending)
                {
                    Fila mat = (Fila)e.UserState;
                    BarraProgresoAsignaciones.Value = e.ProgressPercentage;
                    LblEstatusAsignaciones.Text = "DESCARGANDO MATERIAL...";
                    DgvMaterial.Rows.Add(
                                              mat.Celda("id"),
                                              mat.Celda("fechaCreacion"),
                                              mat.Celda("requisitor"),
                                              mat.Celda("categoria_real"),
                                              mat.Celda("numero_parte"),
                                              mat.Celda("fabricante"),
                                              mat.Celda("descripcion"),
                                              mat.Celda("piezas_requeridas").ToString(),
                                              mat.Celda("strTotal"),
                                              mat.Celda("precio_suma_final"),
                                              mat.Celda("strAccesorioPara"),
                                              mat.Celda("estatus_compra"),
                                              mat.Celda("estatus_autorizacion"),
                                              mat.Celda("estatus_financiero"),
                                              mat.Celda("estatus_almacen"),
                                              mat.Celda("tiempoEstimadoEntrega"),
                                              mat.Celda("tiempoEntregaReal"),
                                              mat.Celda("fechaEstimadaEntrega"),
                                              mat.Celda("subensamble"),
                                              mat.Celda("permitir_revision_tecnica"),
                                              mat.Celda("usuario_permiso"));

                    DataGridViewCell celdaNumeroParte = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["numero_parte"];
                    DataGridViewCell celdaAutorizacion = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_autorizacion"];
                    DataGridViewCell celdaCompra = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_compra"];
                    DataGridViewCell celdaAlmacen = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_almacen"];
                    DataGridViewCell celdaFinanzas = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["finanzas"];

                    if (Convert.ToInt32(mat.Celda("accesorio_para")) > 0)
                    {
                        DgvMaterial.Rows[DgvMaterial.RowCount - 1].DefaultCellStyle.ForeColor = Color.Gray;
                    }

                    if (celdaAutorizacion.Value.ToString() == "RECHAZADO")
                    {
                        celdaAutorizacion.Style.BackColor = Color.Red;
                        celdaAutorizacion.Style.ForeColor = Color.White;
                    }
                    else if (celdaAutorizacion.Value.ToString() == "AUTORIZADO")
                    {
                        celdaAutorizacion.Style.BackColor = Color.LightGreen;
                    }
                    if (celdaCompra.Value.ToString() == "ORDENADO")
                    {
                        celdaCompra.Style.BackColor = Color.LightGreen;
                    }
                    if (celdaAlmacen.Value.ToString() == "RECIBIDO" || celdaAlmacen.Value.ToString() == "ENTREGADO")
                    {
                        celdaAlmacen.Style.BackColor = Color.LightGreen;
                    }
                    if (celdaFinanzas.Value.ToString() == "AUTORIZADO")
                        celdaFinanzas.Style.BackColor = Color.LightGreen;
                    else if (celdaFinanzas.Value.ToString() == "DETENIDO")
                    {
                        celdaFinanzas.Style.BackColor = Color.Red;
                        celdaFinanzas.Style.ForeColor = Color.White;
                    }
                }
            }
            catch
            {
                BkgDescargarMaterial.CancelAsync();
            }
        }


        private void BkgDescargarMaterial_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DgvMaterial.ClearSelection();
            BarraProgresoAsignaciones.Visible = false;
            BarraProgresoAsignaciones.Value = 0;
            LblEstatusAsignaciones.Text = "MATERIAL DESCARGADO";
            CmbFiltroSeleccion.Enabled = true;
            CmbFiltroAutorizacion.Enabled = true;
            CmbFiltroCompra.Enabled = true;
            CmbFiltroRequisitor.Enabled = true;
            CmbFiltroCategoria.Enabled = true;
            CmbFiltroFabricante.Enabled = true;
            CmbFiltroModulo.Enabled = true;
            CmbFiltroTipo.Enabled = true;
            BtnActualizar.Enabled = true;
            BtnReportes.Enabled = true;
            MenuGeneral.Enabled = true;
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
            

            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
            BorrarDatosMaterial();
        }

        public void BorrarDatosMaterial()
        {
            //BtnOpcionesMaterial.Enabled = false;
        }

        private void DgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (DgvMaterial.SelectedRows.Count == 1)
            {
                picMaterial.Image = null;
                IdMaterialSeleccionado = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["id_req"].Value);
                string estatus_compra = DgvMaterial.SelectedRows[0].Cells["estatus_compra"].Value.ToString();
                string estatus_autorizacion = DgvMaterial.SelectedRows[0].Cells["estatus_autorizacion"].Value.ToString();
                string numeroParte = DgvMaterial.SelectedRows[0].Cells["numero_parte"].Value.ToString();
                string fabricante = DgvMaterial.SelectedRows[0].Cells["fabricante"].Value.ToString();

                agregarComentarioToolStripMenuItem.Enabled = true;
                modificarCantidadSubensambleTool.Enabled = true;
                definirToolStripMenuItem.Enabled = Global.VerificarPrivilegio("MATERIAL", "DEFINIR MATERIAL");
                verDetallesToolStripMenuItem.Enabled = true;

                revisiónTécnicaToolStripMenuItem.Enabled = Global.VerificarPrivilegio("MATERIAL", "AUTORIZAR MATERIAL") && estatus_autorizacion == "PENDIENTE";
                //cancelarToolStripMenuItem.Enabled = true;

                if (estatus_compra == "CANCELADO")
                    cancelarToolStripMenuItem.Enabled = false;
                else
                    cancelarToolStripMenuItem.Enabled = true;

                int guardarScroll = 0;
                if (DgvMaterial.Rows.Count > 0)
                    guardarScroll = DgvMaterial.FirstDisplayedCell.RowIndex;

                ScrollPosicion = guardarScroll;

                try
                {
                    string html = GetHtmlCode(numeroParte, fabricante);
                    List<string> urls = GetUrls(html);
                    byte[] image = GetImage(urls[0]);
                    using (var ms = new MemoryStream(image))
                    {
                        picMaterial.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    picMaterial.Image = CB_Base.Properties.Resources.image_not_found;
                }

               
            }

            
        }

        private void BtnOpcionesMaterial_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
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
               // if(Convert.ToDecimal(mat.Fila().Celda("proyecto")) > 0)
                    mat.Fila().ModificarCelda("estatus_autorizacion", "PENDIENTE");
               /* else
                    mat.Fila().ModificarCelda("estatus_autorizacion", "N/A");*/

                mat.Fila().ModificarCelda("estatus_compra", "PENDIENTE");
                mat.Fila().ModificarCelda("estatus_financiero", "PENDIENTE");
                mat.GuardarDatos();

                string titulo = "Cantidad modificada";
                string contenido = Global.UsuarioActual.NombreCompleto();
                contenido += " ha modificado la cantidad de la requisición de material #" + IdMaterialSeleccionado + " del proyecto " + mat.Fila().Celda("proyecto");

                Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                Evento.Modelo().Crear(titulo, contenido, "PROGRAMADOR");

                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                    CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
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
                    if (row.Cells["estatus_compra"].Value.ToString() != "CANCELADO")
                    {
                        MaterialProyecto mat = new MaterialProyecto();
                        mat.CargarDatos(Convert.ToInt32(row.Cells["id_req"].Value));
                        mat.Fila().ModificarCelda("estatus_seleccion", "DEFINIDO");
                        idProyecto = mat.Fila().Celda("proyecto").ToString();
                        mat.GuardarDatos();

                        DateTime fechaLimiteParaSeleccionarProveedor = DateTime.Now;
                        object comprasTipo = ComprasTipos.Modelo().BuscarTipoCompraPorReq(Convert.ToInt32(mat.Fila().Celda("id")));
                        if (comprasTipo != null)
                        {
                            ComprasTipos.Modelo().SeleccionarTipoDeCompra(comprasTipo.ToString()).ForEach(delegate(Fila f)
                            {
                                CompraTipoLimiteParaOrdenar.Modelo().SeleccionarDias(Convert.ToInt32(f.Celda("id"))).ForEach(delegate(Fila tipo)
                                {
                                    fechaLimiteParaSeleccionarProveedor = fechaLimiteParaSeleccionarProveedor.AddDays(Convert.ToInt32(tipo.Celda("dias_para_ordenar")));
                                });
                            });
                        }

                        Fila insertarMaterialKpi = new Fila();
                        insertarMaterialKpi.AgregarCelda("id_material_proyecto", mat.Fila().Celda("id"));
                        insertarMaterialKpi.AgregarCelda("fecha_definido", DateTime.Now);
                        insertarMaterialKpi.AgregarCelda("fecha_limite_seleccionar_proveedor", fechaLimiteParaSeleccionarProveedor);
                        MaterialProyectoKpi.Modelo().Insertar(insertarMaterialKpi);
                    }
                }

                string titulo = "Material definido";
                string contenido = Global.UsuarioActual.NombreCompleto();
                contenido += " ha definido el material de la requisición #" + IdMaterialSeleccionado + " del proyecto " + idProyecto;

                Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                Evento.Modelo().Crear(titulo, contenido, "PROGRAMADOR");

                BorrarDatosMaterial();
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                    CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
            }
        }

        private void autorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRevisionTecnica resultado = new FrmRevisionTecnica(IdMaterialSeleccionado);
            if( resultado.ShowDialog() == System.Windows.Forms.DialogResult.Yes )
            {
                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos( IdMaterialSeleccionado );
                mat.Fila().ModificarCelda("estatus_autorizacion", resultado.EstatusAutorizacion);
                mat.Fila().ModificarCelda("usuario_autorizacion", Global.UsuarioActual.NombreCompleto());
                mat.Fila().ModificarCelda("fecha_autorizacion", DateTime.Now);
                mat.Fila().ModificarCelda("comentarios_revision_tecnica", resultado.Comentarios);
                mat.Fila().ModificarCelda("estatus_compra", resultado.EstatusCompra);
                mat.GuardarDatos();

                //si el material pertenece a un proyecto agregar meta
                if (Convert.ToInt32(mat.Fila().Celda("proyecto")) > 0)
                {
                    //  ELIMINAR CODIGO SI NO PRESENTA FALLAS 01/07/2020
                    //    ProyectoProceso proyectoProceso = new ProyectoProceso();
                    //    proyectoProceso.SeleccionarMetaComprasExistente(Convert.ToDecimal(mat.Fila().Celda("proyecto")), 3);

                    //    if (proyectoProceso.TieneFilas())
                    //    {
                    //        DialogResult result = MessageBox.Show("¿Desea colocar una meta de compra?", "Crear una meta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //        if (result == System.Windows.Forms.DialogResult.Yes)
                    //        {
                    //            if (Convert.ToDateTime(proyectoProceso.Fila().Celda("fecha_fin")).Date > DateTime.Now.Date)
                    //            {
                    //                //Si tiene meta borramos la meta para crear la meta actual
                    //                if (Convert.ToInt32(mat.Fila().Celda("meta")) > 0)
                    //                {
                    //                    mat.Fila().ModificarCelda("meta", 0);
                    //                    mat.Fila().ModificarCelda("fecha_promesa_compras", null);
                    //                    mat.GuardarDatos();
                    //                }

                    //                FrmSeleccionarFechaMetasCompras metasCompras = new FrmSeleccionarFechaMetasCompras(IdMaterialSeleccionado, Convert.ToDecimal(mat.Fila().Celda("proyecto")), DateTime.Today, Convert.ToDateTime(proyectoProceso.Fila().Celda("fecha_fin")).Date);
                    //                metasCompras.ShowDialog();
                    //                BorrarDatosMaterial();
                    //               // CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text, FiltroFilatradoCompra);
                    //            }
                    //            else
                    //                MessageBox.Show("La fecha fin del proceso de compras no es vigente, favor de ir a la opción de 'Cronograma' para ajustar la fecha fin del proceso", "Fecha no vigente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        }
                    //    }
                    //    else
                    //        MessageBox.Show("Debe de crear un proceso de compras para crear una meta, favor de ir a la opción de 'Cronograma' para agregar un proceso de compras", "Sin fecha de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    FrmSelectorFechaCompra seleccionarFechaCompra = new FrmSelectorFechaCompra(IdMaterialSeleccionado);
                    seleccionarFechaCompra.ShowDialog();
                    
                }
            }
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
        }

        private void CmbFiltroAutorizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
           // DgvMaterial.Columns["estatus_autorizacion"].Visible = CmbFiltroAutorizacion.Text == "TODOS";

            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
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
            FrmSeleccionarMaterialCatalogo2 sel = new FrmSeleccionarMaterialCatalogo2(FiltroTipoCompra.ToList(), true, true, Convert.ToInt32(ProyectoCargado.Fila().Celda("id")));
            //FrmSeleccionarMaterialCatalogo sel = new FrmSeleccionarMaterialCatalogo( true, true);
            if (sel.ShowDialog() == DialogResult.OK)
            {
                CatalogoMaterial cat = new CatalogoMaterial();
                cat.CargarDatos(sel.IdMaterial);

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
                    if (Convert.ToDecimal(mat.Fila().Celda("proyecto")) > 0)
                        mat.Fila().ModificarCelda("estatus_autorizacion", "PENDIENTE");
                    else
                        mat.Fila().ModificarCelda("estatus_autorizacion", "N/A");
                    mat.Fila().ModificarCelda("estatus_compra", "PENDIENTE");
                    mat.Fila().ModificarCelda("estatus_financiero", "PENDIENTE");
                    mat.Fila().ModificarCelda("requisitor", Global.UsuarioActual.NombreCompleto());

                    mat.GuardarDatos();

                    //Historial de remplazos
                    Fila historial = new Fila();
                    historial.AgregarCelda("requisicion", IdMaterialSeleccionado);
                    historial.AgregarCelda("numero_parte", mat.Fila().Celda("numero_parte"));
                    historial.AgregarCelda("usuario_remplazo", Global.UsuarioActual.Fila().Celda("id"));
                    historial.AgregarCelda("fecha_remplazo", DateTime.Now); ;
                    MaterialHistorialReemplazo.Modelo().Insertar(historial);

                    string titulo = "Material reemplazado";
                    string contenido = Global.UsuarioActual.NombreCompleto();
                    contenido += " ha reemplazado la requisición de material #" + IdMaterialSeleccionado + " del proyecto " + mat.Fila().Celda("proyecto").ToString();

                    Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");
                    Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                    Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");

                } 

                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
            }
        }

        private void reemplazarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reemplazar();
        }

        private void agregarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarMaterialCatalogo2 selec = new FrmSeleccionarMaterialCatalogo2(FiltroTipoCompra.ToList(), true, MostrarTodasLasCategorias, IdProyecto); 
            if( selec.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                int IdReqPrincipal =  CrearRequisicionMaterial(selec.IdMaterial, selec.CantidadMaterial, selec.Subensamble);
                if (IdReqPrincipal == 0)
                    return;

                MaterialProyecto ReqPrincipal = new MaterialProyecto();
                ReqPrincipal.CargarDatos(IdReqPrincipal);

                int PiezasRequeridas = Convert.ToInt32(ReqPrincipal.Fila().Celda("piezas_requeridas"));

                List<Fila> accesorios = AccesorioMaterial.Modelo().TiposAccesorios(selec.IdMaterial);

                if( accesorios.Count > 0 )
                {
                    FrmConfigurarAccesoriosMaterial config = new FrmConfigurarAccesoriosMaterial(selec.IdMaterial, selec.CantidadMaterial);

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

                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
            }
        }

        public int CrearRequisicionMaterial(int idCatalogo, int cantidad, int subensamble, int accesorioPara=0)
        {
            CatalogoMaterial material = new CatalogoMaterial();
            material.CargarDatos(idCatalogo);

            if(Convert.ToBoolean(material.Fila().Celda("material_restringido")))
            {
                MessageBox.Show("El material solicitado se encuentra restringido por un líder de proyecto, favor de consultarlo", "Material Restringido", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
        }

        private void CmbFiltroCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMaterial.Columns["estatus_compra"].Visible = CmbFiltroCompra.Text == "TODOS";
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
        }

        private void CmbFiltroRequisitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMaterial.Columns["requisitor"].Visible = CmbFiltroRequisitor.Text == "TODOS";
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
        }

        private void CmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMaterial.Columns["categoria"].Visible = CmbFiltroCategoria.Text == "TODOS";
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
        }

        private void CmbFiltroFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMaterial.Columns["fabricante"].Visible = CmbFiltroFabricante.Text == "TODOS";
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
        }

        private void CmbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text,
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
        }

        private void DgvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            FrmDetallesMaterialProyecto det = new FrmDetallesMaterialProyecto(IdMaterialSeleccionado);
            det.ShowDialog();
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialProyecto material = new MaterialProyecto();
            material.CargarDatos(IdMaterialSeleccionado);
            int accesorio_para = material.Fila().Celda<int>("accesorio_para");
            int numero_de_accesorios_eliminados = 0;
            string usuario = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();
            string estatusCompra = material.Fila().Celda("estatus_compra").ToString();
            string descripcion = material.Fila().Celda("descripcion").ToString();
            string numeroParte = material.Fila().Celda("numero_parte").ToString();
            string requisitor = material.Fila().Celda("requisitor").ToString();
            decimal proyecto = Convert.ToDecimal(material.Fila().Celda("proyecto"));
            int id_usuario = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"));

            var result = MessageBox.Show("Esta a punto de cancelar la requisición seleccionada, al cancelarla se borrará y no podrá ser recuperada nuevamente, ¿Desea continuar?", "Cancelar requisición!!",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //if(estatusCompra == "PENDIENTE" || estatusCompra == "EN COTIZACION")
                //{
                    MaterialProyecto borrarMaterial = new MaterialProyecto();
                    borrarMaterial.CargarDatos(IdMaterialSeleccionado);
                    borrarMaterial.BorrarDatos(IdMaterialSeleccionado);
                    borrarMaterial.GuardarDatos();

                    material.CancelarRequisicionRegistro(IdMaterialSeleccionado, id_usuario, usuario, DateTime.Now, numeroParte, descripcion, proyecto, requisitor);
                //}
               
                //Se verifica si el material tiene accesorios, para asi cancelarlos de igual manera
                if (accesorio_para == 0 && material.AccesorioPara(IdMaterialSeleccionado).Count > 0)
                {
                    DialogResult resul = MessageBox.Show("El material seleccionado tiene accesorios, si lo cancela serán borrados y no podrán ser recuperados nuevamente," +
                        "¿Desea cancelarlos?", 
                        "Cancelar accesorios", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Warning);

                    if(resul == DialogResult.Yes)
                    {
                        material.Accesorios(IdMaterialSeleccionado).ForEach(delegate (Fila accesorio)
                        {
                            string estatusCompraAccesorios = accesorio.Celda("estatus_compra").ToString();
                            if (estatusCompraAccesorios == "PENDIENTE" || estatusCompraAccesorios == "EN COTIZACION")
                            {
                                MaterialProyecto borrarMaterialAccesorio = new MaterialProyecto();
                                borrarMaterialAccesorio = new MaterialProyecto();
                                borrarMaterialAccesorio.CargarDatos(Convert.ToInt32(accesorio.Celda("id")));
                                borrarMaterialAccesorio.BorrarDatos(Convert.ToInt32(accesorio.Celda("id")));
                                borrarMaterialAccesorio.GuardarDatos();

                                descripcion = accesorio.Celda("descripcion").ToString();
                                numeroParte = accesorio.Celda("numero_parte").ToString();
                                requisitor = accesorio.Celda("requisitor").ToString();
                                proyecto = Convert.ToDecimal(accesorio.Celda("proyecto"));

                                borrarMaterialAccesorio.CancelarRequisicionRegistro(Convert.ToInt32(accesorio.Celda("id")), id_usuario, usuario, DateTime.Now, numeroParte,descripcion,proyecto,requisitor);
                            }
                           
                        });
                    }
                   
                    MessageBox.Show("Se eliminaron " + numero_de_accesorios_eliminados + " de " + material.AccesorioPara(IdMaterialSeleccionado).Count + " accesorios" +
                        " asignados a este material!");
                }
                MessageBox.Show("La requisición seleccionada fue cancelada correctamente!! ");
            }                        

            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, 
                CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text, FiltroFilatradoCompra, "TODOS", MostrarCancelados);
        }

        private void modificarCantidadSubensambleTool_Click(object sender, EventArgs e)
        {
            int subensable  =  Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["Subensamble"].Value);
            FrmIngresarSubensamble2 subensamble = new FrmIngresarSubensamble2(IdProyecto, subensable);
            if(subensamble.ShowDialog() ==  System.Windows.Forms.DialogResult.OK)
            {
                MaterialProyecto material = new MaterialProyecto();
                material.CargarDatos(IdMaterialSeleccionado);

                if (material.TieneFilas())
                {
                    material.Fila().ModificarCelda("subensamble", subensamble.Subensamble);
                    material.GuardarDatos();
                }
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, 
                    CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
            }
        }

        private void OpcionesMaterialDefinido_Opening(object sender, CancelEventArgs e)
        {
            if (DgvMaterial.SelectedRows.Count <= 0)
                return;

            string estatusCompra = DgvMaterial.SelectedRows[0].Cells["estatus_compra"].Value.ToString();

            menuDefinidoIngresarComentario.Enabled = (DgvMaterial.SelectedRows.Count > 0);
            detallesMaterialDefinido.Enabled = (DgvMaterial.SelectedRows.Count > 0);
            reemplazarToolStripMenuItem.Enabled = (estatusCompra == "PENDIENTE" || estatusCompra == "EN COTIZACION" || estatusCompra == "COMPRA RECHAZADA" || estatusCompra == "COMPRA DETENIDA");
            revisiónTécnicaToolStripMenuItem.Enabled = (DgvMaterial.SelectedRows[0].Cells["estatus_compra"].Value.ToString() == "EN REVISION TECNICA");
            cancelarDefinidoToolStripMenuItem.Enabled = !new List<string>() { "ORDENADO", "CANCELADO", "RECIBIDO", "ENTREGADO" }.Contains(DgvMaterial.SelectedRows[0].Cells["estatus_compra"].Value.ToString());
            modificarSubensambleDefinidoTool.Enabled = new List<string>() { "PENDIENTE", "EN COTIZACION", "COMPRA RECHAZADA", "COMPRA DETENIDA" }.Contains(DgvMaterial.SelectedRows[0].Cells["estatus_compra"].Value.ToString());
            modificarCantidadDefinidoToolStripMenuItem.Enabled = new List<string>() { "PENDIENTE", "EN COTIZACION", "COMPRA RECHAZADA", "COMPRA DETENIDA" }.Contains(DgvMaterial.SelectedRows[0].Cells["estatus_compra"].Value.ToString());
        }

        private void BkgEnviarCOrreo_DoWork(object sender, DoWorkEventArgs e)
        {
            Fila informacion = (Fila)e.Argument;
            try
            {
                Global.EnviarCorreo
                (
                    "Material rechazado por finanzas",
                    "El material " + informacion.Celda("numero_parte") + " ha sido rechazado por finanzas, favor de ponerte en contacto con compras.",
                    informacion.Celda("correo").ToString()
                );

                e.Result = null;
            }
            catch
            {
                e.Result = "Ha ocurrido un error, el correo no pudo ser enviado.";
            }
        }

        private void BkgEnviarCOrreo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Result != null)
                MessageBox.Show(e.Result.ToString());

            CmbFiltroAutorizacion.Enabled = true;
            CmbFiltroCategoria.Enabled = true;
            CmbFiltroCompra.Enabled = true;
            CmbFiltroFabricante.Enabled = true;
            CmbFiltroRequisitor.Enabled = true;
            CmbFiltroSeleccion.Enabled = true;
            CmbFiltroTipo.Enabled = true;
        }

        private void OpcionesMaterialPreliminar_Opening(object sender, CancelEventArgs e)
        {
            if (DgvMaterial.SelectedRows.Count <= 0)
                return;

            string estatusCompra = DgvMaterial.SelectedRows[0].Cells["estatus_compra"].Value.ToString();

            modificarCantidadToolStripMenuItem.Enabled = (estatusCompra == "PENDIENTE" || estatusCompra == "EN COTIZACION" || estatusCompra == "COMPRA RECHAZADA" || estatusCompra == "COMPRA DETENIDA");
            reemplazarToolStripMenuItem1.Enabled = (estatusCompra == "PENDIENTE" || estatusCompra == "EN COTIZACION" || estatusCompra == "COMPRA RECHAZADA" || estatusCompra == "COMPRA DETENIDA"); 


        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnReportes.ContextMenuStrip.Show(BtnReportes, BtnReportes.PointToClient(Cursor.Position));
        }

        private void CmbFiltroModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text,
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
        }

        private void mostrarCanceladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarCanceladosToolStripMenuItem.Checked)
                MostrarCancelados = true;
            else
                MostrarCancelados = false;

            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
        }

        private void MenuGeneral_Opening(object sender, CancelEventArgs e)
        {
            menuGeneralMostrarCancelados.Visible = (CmbFiltroSeleccion.Text == "DEFINIDO");
            menuGeneralSeleccionarDelCatalogo.Visible = (CmbFiltroSeleccion.Text == "PRELIMINAR");

            bool concederPermiso = false;
            int usuarioRevisionTecnica = 0;
            string estatusAutorizacion = "NO MOSTRAR";
            string estatusCompra = "NO MOSTRAR";
            string rol = Global.UsuarioActual.Fila().Celda("rol").ToString();

            if (DgvMaterial.SelectedRows.Count > 0)
            {
                estatusAutorizacion = DgvMaterial.SelectedRows[0].Cells["estatus_autorizacion"].Value.ToString();
                estatusCompra = DgvMaterial.SelectedRows[0].Cells["estatus_compra"].Value.ToString();
                concederPermiso = Convert.ToBoolean(DgvMaterial.SelectedRows[0].Cells["permitir_revision_tecnica"].Value);
                usuarioRevisionTecnica = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["usuario_revision_tecnica"].Value);
            }

            menuGeneralPlanificar.Visible = Global.VerificarPrivilegio("MATERIAL", "AUTORIZAR MATERIAL") && (CmbFiltroSeleccion.Text == "DEFINIDO") && (estatusCompra == "EN PLANIFICACION");
            menuGeneralPlanificar.Enabled = (DgvMaterial.SelectedRows.Count > 0);
            menuGeneralDefinir.Visible = ((Global.VerificarPrivilegio("MATERIAL", "DEFINIR MATERIAL")) && (CmbFiltroSeleccion.Text == "PRELIMINAR") && (DgvMaterial.SelectedRows.Count > 0));
            menuGeneralDefinir.Enabled = ((CmbFiltroSeleccion.Text == "PRELIMINAR") && (!new List<string>() { "ORDENADO", "CANCELADO", "RECIBIDO", "ENTREGADO" }.Contains(estatusCompra)) &&(DgvMaterial.SelectedRows.Count > 0));
            menuGeneralrevisionTecnica.Visible = ((Global.VerificarPrivilegio("MATERIAL", "AUTORIZAR MATERIAL")) && (estatusAutorizacion == "PENDIENTE") && (CmbFiltroSeleccion.Text == "DEFINIDO")) || (concederPermiso && usuarioRevisionTecnica == Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));
            menuGeneralrevisionTecnica.Enabled = ((estatusCompra == "EN REVISION TECNICA") && (DgvMaterial.SelectedRows.Count > 0));
            concederPermisoDeRevisiónTécnicaToolStripMenuItem.Visible = ((Global.VerificarPrivilegio("MATERIAL", "AUTORIZAR MATERIAL")) && (estatusAutorizacion == "PENDIENTE") && (CmbFiltroSeleccion.Text == "DEFINIDO") && !concederPermiso);
            denegarPermisoRevisionTecnicaToolStripMenuItem.Visible = ((Global.VerificarPrivilegio("MATERIAL", "AUTORIZAR MATERIAL")) && (estatusAutorizacion == "PENDIENTE") && (CmbFiltroSeleccion.Text == "DEFINIDO") && concederPermiso);


            menuGeneralIngresarComentario.Enabled = (DgvMaterial.SelectedRows.Count > 0);
            menuGeneralDetalles.Enabled = (DgvMaterial.SelectedRows.Count > 0);
            menuGeneralReemplazar.Enabled = ((estatusCompra == "PENDIENTE" || estatusCompra == "EN COTIZACION" || estatusCompra == "COMPRA RECHAZADA" || estatusCompra == "COMPRA DETENIDA") && (DgvMaterial.SelectedRows.Count > 0));
            menuGeneralModificarSubensamble.Enabled = ((new List<string>() { "PENDIENTE", "EN COTIZACION", "COMPRA RECHAZADA", "COMPRA DETENIDA" }.Contains(estatusCompra)) && (DgvMaterial.SelectedRows.Count > 0));
            menuGeneralModificarCantidad.Enabled = ((new List<string>() { "PENDIENTE", "EN COTIZACION", "COMPRA RECHAZADA", "COMPRA DETENIDA" }.Contains(estatusCompra)) && (DgvMaterial.SelectedRows.Count > 0));
            if(rol.Contains("LIDER DE PROYECTO") || rol.Contains("SUPERUSER"))
            {
                menuGeneralCancelar.Enabled = (DgvMaterial.SelectedRows.Count == 1);
            }
            else
                menuGeneralCancelar.Enabled = ((new List<string>() { "PENDIENTE", "EN COTIZACION", "COMPRA RECHAZADA", "COMPRA DETENIDA" }.Contains(estatusCompra)) && (DgvMaterial.SelectedRows.Count == 1));
            
            menuGeneralRegistroRápidoToolStripMenuItem.Visible = Global.VerificarPrivilegio("MATERIAL", "CREAR REQUISICION RAPIDA");
            buscarNúmeroDeParteToolStripMenuItem.Enabled = (DgvMaterial.SelectedRows.Count == 1);
        }

        private void menuGeneralMostrarCancelados_Click(object sender, EventArgs e)
        {
            FrmMostrarMaterialCancelado materialCancelado = new FrmMostrarMaterialCancelado(IdProyecto);
            materialCancelado.Show();
           /* MostrarCancelados = menuGeneralMostrarCancelados.Checked;
            CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text,
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);*/
        }

        private void planificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSelectorFechaCompra seleccionarFechaCompra = new FrmSelectorFechaCompra(IdMaterialSeleccionado);
            if(seleccionarFechaCompra.ShowDialog() == DialogResult.OK)
            {
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text,
                CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
            }
        }

        private void costosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCostosComprasProyecto costos = new FrmCostosComprasProyecto(IdProyecto);
            costos.ShowDialog();
        }

        private void estatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstatusComprasProyecto estatus = new FrmEstatusComprasProyecto(IdProyecto);
            estatus.Show();
        }

        private void exportarACSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "MATERIAL DEL PROYECTO " + ProyectoCargado.Fila().Celda("id").ToString().PadLeft(2,'0') + " - " + ProyectoCargado.Fila().Celda("nombre").ToString();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                if (!path.EndsWith(".xlsx"))
                    path += ".xlsx";

                try
                {
                    FormatosExcel.ReporteMaterialProyecto(MaterialParaReporte, path);
                    MessageBox.Show("El reporte fue generado correctamente");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("El reporte no pudo ser generado" + Environment.NewLine + ex.ToString());
                }
            }
        }

        private void MenuReportes_Opening(object sender, CancelEventArgs e)
        {
            exportarACSVToolStripMenuItem.Visible = Global.VerificarPrivilegio("ADMINISTRAR", "INFORMACION SENSIBLE");
            exportarACSVToolStripMenuItem.Enabled = (DgvMaterial.Rows.Count > 0);
        }

        private void registroRápidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarMaterialUrgente registro = new FrmRegistrarMaterialUrgente(IdProyecto);
            if(registro.ShowDialog() == DialogResult.OK)
            {
                CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text,
               CmbFiltroFabricante.Text, FiltroFilatradoCompra, CmbFiltroModulo.Text, MostrarCancelados);
            }
        }

        private void BtnFiltrarDatos_Click(object sender, EventArgs e)
        {
            FrmFiltrarDatos filtrar = new FrmFiltrarDatos(BuscadorMaterial.Filtros);

            if (filtrar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscadorMaterial.Filtros = filtrar.Filtros;
                CargarMaterialDeFiltros();
            }
        }

        private void CargarMaterialDeFiltros()
        {
            DgvMaterial.Rows.Clear();
            decimal idProyecto = Convert.ToDecimal(ProyectoCargado.Fila().Celda("id"));
            BuscadorMaterial.Filtrar2(IdProyecto, CmbFiltroCategoria.Text, TipoCompra).ForEach(delegate (Fila mat)
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

                if (fc != null)
                    fechaCreacion = Convert.ToDateTime(fc).ToString("MMM dd, yyyy hh:mm:ss tt");

                Object te = mat.Celda("tiempo_entrega_estimado");
                int iTiempoEstimadoEntrega = 0;
                string tiempoEstimadoEntrega = "N/A";

                Object obSubensamble = mat.Celda("subensamble");
                string subensamble = "";
                if (obSubensamble != null)
                    subensamble = Convert.ToInt32(mat.Celda("subensamble")).ToString("D2");

                if (te != null)
                {
                    iTiempoEstimadoEntrega = Convert.ToInt32(te);

                    if (iTiempoEstimadoEntrega > 0)
                        tiempoEstimadoEntrega = te.ToString();
                }

                string tiempoEntregaReal = "N/A";


                if (Convert.ToInt32(mat.Celda("rfq_concepto")) > 0)
                {
                    RfqConcepto materialConcepto = new RfqConcepto();
                    materialConcepto.CargarDatos(Convert.ToInt32(mat.Celda("rfq_concepto")));

                    if (materialConcepto.TieneFilas())
                    {
                        if (materialConcepto.Fila().Celda<int>("tiempo_entrega") > 0)
                            tiempoEntregaReal = materialConcepto.Fila().Celda("tiempo_entrega").ToString();
                    }
                }

                string precioSumaFinal = "SIN CAPTURAR";

                object objPrecioSumaFinal = mat.Celda("precio_suma_final");
                object objPrecioMoneda = mat.Celda("precio_moneda");

                if (objPrecioSumaFinal != null)
                {
                    if (Convert.ToDecimal(objPrecioSumaFinal) > 0)
                    {
                        precioSumaFinal = Convert.ToDouble(objPrecioSumaFinal).ToString("C2") + " " + objPrecioMoneda.ToString();
                    }
                }

                Object eta = mat.Celda("eta");
                string fechaEstimadaEntrega = "N/A";

                if (eta != null)
                    fechaEstimadaEntrega = Convert.ToDateTime(eta).ToString("MMM dd, yyyy");

                Fila filaInformacion = new Fila();

                filaInformacion.AgregarCelda("id", mat.Celda("id"));
                filaInformacion.AgregarCelda("fechaCreacion", fechaCreacion);
                filaInformacion.AgregarCelda("requisitor", mat.Celda("requisitor"));
                filaInformacion.AgregarCelda("categoria_real", mat.Celda("categoria_real"));
                filaInformacion.AgregarCelda("numero_parte", mat.Celda("numero_parte"));
                filaInformacion.AgregarCelda("fabricante", mat.Celda("fabricante"));
                filaInformacion.AgregarCelda("descripcion", mat.Celda("descripcion"));
                filaInformacion.AgregarCelda("piezas_requeridas", mat.Celda("piezas_requeridas"));
                filaInformacion.AgregarCelda("strTotal", strTotal);
                filaInformacion.AgregarCelda("precio_suma_final", precioSumaFinal);
                filaInformacion.AgregarCelda("strAccesorioPara", strAccesorioPara);
                filaInformacion.AgregarCelda("estatus_compra", mat.Celda("estatus_compra"));
                filaInformacion.AgregarCelda("estatus_autorizacion", mat.Celda("estatus_autorizacion"));
                filaInformacion.AgregarCelda("estatus_financiero", mat.Celda("estatus_financiero"));
                filaInformacion.AgregarCelda("estatus_almacen", mat.Celda("estatus_almacen"));
                filaInformacion.AgregarCelda("tiempoEstimadoEntrega", tiempoEstimadoEntrega);
                filaInformacion.AgregarCelda("tiempoEntregaReal", tiempoEntregaReal);
                filaInformacion.AgregarCelda("fechaEstimadaEntrega", fechaEstimadaEntrega);
                filaInformacion.AgregarCelda("subensamble", subensamble);
                filaInformacion.AgregarCelda("accesorio_para", mat.Celda("accesorio_para"));
                filaInformacion.AgregarCelda("permitir_revision_tecnica", mat.Celda("permitir_revision_tecnica"));
                filaInformacion.AgregarCelda("usuario_permiso", mat.Celda("usuario_permiso"));



                MaterialParaReporte.Add(filaInformacion);

                DgvMaterial.Rows.Add
                (
                    filaInformacion.Celda("id"),
                    filaInformacion.Celda("fechaCreacion"),
                    filaInformacion.Celda("requisitor"),
                    filaInformacion.Celda("categoria_real"),
                    filaInformacion.Celda("numero_parte"),
                    filaInformacion.Celda("fabricante"),
                    filaInformacion.Celda("descripcion"),
                    filaInformacion.Celda("piezas_requeridas").ToString(),
                    filaInformacion.Celda("strTotal"),
                    filaInformacion.Celda("precio_suma_final"),
                    filaInformacion.Celda("strAccesorioPara"),
                    filaInformacion.Celda("estatus_compra"),
                    filaInformacion.Celda("estatus_autorizacion"),
                    filaInformacion.Celda("estatus_financiero"),
                    filaInformacion.Celda("estatus_almacen"),
                    filaInformacion.Celda("tiempoEstimadoEntrega"),
                    filaInformacion.Celda("tiempoEntregaReal"),
                    filaInformacion.Celda("fechaEstimadaEntrega"),
                    filaInformacion.Celda("subensamble")
                );
            });
        }

        private void concederPermisoDeRevisiónTécnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuarioPermiso = new FrmSeleccionarUsuario();
            if(usuarioPermiso.ShowDialog() == DialogResult.OK)
            {
                int idMaterialSeleccionado = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["id_req"].Value);
                MaterialProyecto material = new MaterialProyecto();
                material.CargarDatos(idMaterialSeleccionado);

                if(material.TieneFilas())
                {
                    material.Fila().ModificarCelda("usuario_permiso", Convert.ToInt32(usuarioPermiso.UsuarioSeleccionado.Fila().Celda("id")));
                    material.Fila().ModificarCelda("permitir_revision_tecnica", 1);
                    material.GuardarDatos();

                    DgvMaterial.SelectedRows[0].Cells["permitir_revision_tecnica"].Value = 1;
                    DgvMaterial.SelectedRows[0].Cells["usuario_revision_tecnica"].Value = Convert.ToInt32(usuarioPermiso.UsuarioSeleccionado.Fila().Celda("id"));

                    concederPermisoDeRevisiónTécnicaToolStripMenuItem.Visible = false;
                    denegarPermisoRevisionTecnicaToolStripMenuItem.Visible = true;
                }
            }
        }

        private void denegarPermisoRevisionTecnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea denegar el permiso de revisión técnica?", "Denegar permiso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                int idMaterialSeleccionado = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["id_req"].Value);
                MaterialProyecto material = new MaterialProyecto();
                material.CargarDatos(idMaterialSeleccionado);

                if (material.TieneFilas())
                {
                    material.Fila().ModificarCelda("usuario_permiso", 0);
                    material.Fila().ModificarCelda("permitir_revision_tecnica", 0);
                    material.GuardarDatos();

                    DgvMaterial.SelectedRows[0].Cells["permitir_revision_tecnica"].Value = 0;
                    DgvMaterial.SelectedRows[0].Cells["usuario_revision_tecnica"].Value = 0;

                    concederPermisoDeRevisiónTécnicaToolStripMenuItem.Visible = true;
                    denegarPermisoRevisionTecnicaToolStripMenuItem.Visible = false;
                }
            }
        }

        private void buscarNúmeroDeParteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string numeroParte = DgvMaterial.SelectedRows[0].Cells["numero_parte"].Value.ToString().Replace(' ','+');
            string buscarNumeroParte = "https://www.google.com/search?q=" + numeroParte + "&oq=" + numeroParte + "&a";
            try
            {
                //lanzar chrome
                System.Diagnostics.Process.Start("chrome", buscarNumeroParte + " --new-window");
            }
            catch
            {
                try
                {
                    //si chrome no esta instalado buscar firefox
                    System.Diagnostics.Process.Start("firefox", "-new-window " + buscarNumeroParte);
                }
                catch
                {
                    MessageBox.Show("Esta herramienta funciona con Firefox o Chrome, favor de instalar un navegador compatible");
                }
            }
        }

        private string GetHtmlCode(string numeroParte, string fabricante)
        {
            string url = "https://www.google.com/search?q=" + numeroParte.Replace(' ', '+') + "+" + fabricante.Replace(' ', '+') + "&tbm=isch";
            string data = "";


            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html, application/xhtml+xml, */*";

            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream != null)
                {
                    using (var sr = new StreamReader(dataStream))
                    {
                        data = sr.ReadToEnd();
                    }
                }
                else
                {
                    data = null;
                }
            }

            return data;
        }

        private List<string> GetUrls(string html)
        {
            var urls = new List<string>();

            List<string> imagenesHtml = new List<string>();
            string[] htmlDividido = html.Split('<');
            foreach (string imagen in htmlDividido)
            {
                if (urls.Count > 0)
                {
                    return urls;
                }
                if (imagen.StartsWith("img class"))
                {
                    List<string> separarUrls = imagen.Split('\"').ToList();
                    string result = separarUrls.Find(x => x.ToLower().StartsWith("https://"));
                    if (result != null)
                        urls.Add(result);
                }
            }


            return urls;
        }

        private byte[] GetImage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                using (var sr = new BinaryReader(dataStream))
                {
                    byte[] bytes = sr.ReadBytes(100000000);

                    return bytes;
                }
            }
        }
    }
}

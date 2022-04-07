namespace CB
{
    partial class FrmAgregarRfq
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblRFQ = new System.Windows.Forms.Label();
            this.OpcionesRfqEnviado = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarCantidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturarCotizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desvincularCotizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desglosarCostorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarDesgloseDeCostosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vincularRequisicionesARFQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAsignarConceptos = new System.Windows.Forms.Button();
            this.BtnQuitarMaterial = new System.Windows.Forms.Button();
            this.BtnAgregarMaterial = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.ToolTipMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.PanelInformacion = new System.Windows.Forms.Panel();
            this.LblRequisitor = new System.Windows.Forms.Label();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.LblFechaCreacion = new System.Windows.Forms.Label();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvCostos = new System.Windows.Forms.DataGridView();
            this.radioNumPart = new System.Windows.Forms.RadioButton();
            this.radioProyecto = new System.Windows.Forms.RadioButton();
            this.optNumProy = new System.Windows.Forms.GroupBox();
            this.radioMxn = new System.Windows.Forms.RadioButton();
            this.radioUsd = new System.Windows.Forms.RadioButton();
            this.optTipoCambio = new System.Windows.Forms.GroupBox();
            this.DgvConceptos = new System.Windows.Forms.DataGridView();
            this.panelCostos = new System.Windows.Forms.Panel();
            this.id_concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_estimada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_disponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisiciones_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpcionesRfqEnviado.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCostos)).BeginInit();
            this.optNumProy.SuspendLayout();
            this.optTipoCambio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConceptos)).BeginInit();
            this.panelCostos.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblRFQ
            // 
            this.LblRFQ.BackColor = System.Drawing.Color.Black;
            this.LblRFQ.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblRFQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRFQ.ForeColor = System.Drawing.Color.White;
            this.LblRFQ.Location = new System.Drawing.Point(0, 0);
            this.LblRFQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRFQ.Name = "LblRFQ";
            this.LblRFQ.Size = new System.Drawing.Size(1767, 28);
            this.LblRFQ.TabIndex = 10;
            this.LblRFQ.Text = "SELECCIONA UN RFQ";
            this.LblRFQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpcionesRfqEnviado
            // 
            this.OpcionesRfqEnviado.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.OpcionesRfqEnviado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarCantidadToolStripMenuItem,
            this.capturarCotizaciónToolStripMenuItem,
            this.seleccionarCotizacionToolStripMenuItem,
            this.desvincularCotizaciónToolStripMenuItem,
            this.desglosarCostorToolStripMenuItem,
            this.ocultarDesgloseDeCostosToolStripMenuItem,
            this.vincularRequisicionesARFQToolStripMenuItem});
            this.OpcionesRfqEnviado.Name = "OpcionesRfqEnviado";
            this.OpcionesRfqEnviado.Size = new System.Drawing.Size(289, 186);
            this.OpcionesRfqEnviado.Opening += new System.ComponentModel.CancelEventHandler(this.OpcionesRfqEnviado_Opening);
            // 
            // modificarCantidadToolStripMenuItem
            // 
            this.modificarCantidadToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.modificarCantidadToolStripMenuItem.Name = "modificarCantidadToolStripMenuItem";
            this.modificarCantidadToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.modificarCantidadToolStripMenuItem.Text = "Modificar cantidad";
            this.modificarCantidadToolStripMenuItem.Click += new System.EventHandler(this.modificarCantidadToolStripMenuItem_Click);
            // 
            // capturarCotizaciónToolStripMenuItem
            // 
            this.capturarCotizaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.price;
            this.capturarCotizaciónToolStripMenuItem.Name = "capturarCotizaciónToolStripMenuItem";
            this.capturarCotizaciónToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.capturarCotizaciónToolStripMenuItem.Text = "Capturar cotización";
            this.capturarCotizaciónToolStripMenuItem.Click += new System.EventHandler(this.capturarCotizaciónToolStripMenuItem_Click);
            // 
            // seleccionarCotizacionToolStripMenuItem
            // 
            this.seleccionarCotizacionToolStripMenuItem.Image = global::CB_Base.Properties.Resources.truck_icon_48;
            this.seleccionarCotizacionToolStripMenuItem.Name = "seleccionarCotizacionToolStripMenuItem";
            this.seleccionarCotizacionToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.seleccionarCotizacionToolStripMenuItem.Text = "Seleccionar cotización";
            this.seleccionarCotizacionToolStripMenuItem.Click += new System.EventHandler(this.seleccionarCotizacionToolStripMenuItem_Click);
            // 
            // desvincularCotizaciónToolStripMenuItem
            // 
            this.desvincularCotizaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.no_vinculate;
            this.desvincularCotizaciónToolStripMenuItem.Name = "desvincularCotizaciónToolStripMenuItem";
            this.desvincularCotizaciónToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.desvincularCotizaciónToolStripMenuItem.Text = "Desvincular cotización";
            this.desvincularCotizaciónToolStripMenuItem.Click += new System.EventHandler(this.desvincularCotizaciónToolStripMenuItem_Click);
            // 
            // desglosarCostorToolStripMenuItem
            // 
            this.desglosarCostorToolStripMenuItem.Image = global::CB_Base.Properties.Resources.images;
            this.desglosarCostorToolStripMenuItem.Name = "desglosarCostorToolStripMenuItem";
            this.desglosarCostorToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.desglosarCostorToolStripMenuItem.Text = "Desglosar costos";
            this.desglosarCostorToolStripMenuItem.Click += new System.EventHandler(this.desglosarCostorToolStripMenuItem_Click);
            // 
            // ocultarDesgloseDeCostosToolStripMenuItem
            // 
            this.ocultarDesgloseDeCostosToolStripMenuItem.Image = global::CB_Base.Properties.Resources.images;
            this.ocultarDesgloseDeCostosToolStripMenuItem.Name = "ocultarDesgloseDeCostosToolStripMenuItem";
            this.ocultarDesgloseDeCostosToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.ocultarDesgloseDeCostosToolStripMenuItem.Text = "Ocultar desglose de costos";
            this.ocultarDesgloseDeCostosToolStripMenuItem.Visible = false;
            this.ocultarDesgloseDeCostosToolStripMenuItem.Click += new System.EventHandler(this.ocultarDesgloseDeCostosToolStripMenuItem_Click);
            // 
            // vincularRequisicionesARFQToolStripMenuItem
            // 
            this.vincularRequisicionesARFQToolStripMenuItem.Image = global::CB_Base.Properties.Resources.rfq__1_;
            this.vincularRequisicionesARFQToolStripMenuItem.Name = "vincularRequisicionesARFQToolStripMenuItem";
            this.vincularRequisicionesARFQToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.vincularRequisicionesARFQToolStripMenuItem.Text = "Requisiciones vinculadas a RFQ";
            this.vincularRequisicionesARFQToolStripMenuItem.Click += new System.EventHandler(this.vincularRequisicionesARFQToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnAsignarConceptos);
            this.panel1.Controls.Add(this.BtnQuitarMaterial);
            this.panel1.Controls.Add(this.BtnAgregarMaterial);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.BtnNuevo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1767, 69);
            this.panel1.TabIndex = 12;
            // 
            // BtnAsignarConceptos
            // 
            this.BtnAsignarConceptos.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAsignarConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsignarConceptos.Image = global::CB_Base.Properties.Resources.truck_icon_48;
            this.BtnAsignarConceptos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAsignarConceptos.Location = new System.Drawing.Point(1058, 0);
            this.BtnAsignarConceptos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAsignarConceptos.Name = "BtnAsignarConceptos";
            this.BtnAsignarConceptos.Size = new System.Drawing.Size(331, 69);
            this.BtnAsignarConceptos.TabIndex = 18;
            this.BtnAsignarConceptos.Text = "     Seleccionar proveedor";
            this.ToolTipMensaje.SetToolTip(this.BtnAsignarConceptos, "Asignar este proveedor a materiales proyecto");
            this.BtnAsignarConceptos.UseVisualStyleBackColor = true;
            this.BtnAsignarConceptos.Click += new System.EventHandler(this.BtnAsignarConceptos_Click);
            // 
            // BtnQuitarMaterial
            // 
            this.BtnQuitarMaterial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnQuitarMaterial.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnQuitarMaterial.Enabled = false;
            this.BtnQuitarMaterial.Image = global::CB_Base.Properties.Resources.trash_32;
            this.BtnQuitarMaterial.Location = new System.Drawing.Point(95, 0);
            this.BtnQuitarMaterial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnQuitarMaterial.Name = "BtnQuitarMaterial";
            this.BtnQuitarMaterial.Size = new System.Drawing.Size(95, 69);
            this.BtnQuitarMaterial.TabIndex = 17;
            this.ToolTipMensaje.SetToolTip(this.BtnQuitarMaterial, "Eliminar requisición");
            this.BtnQuitarMaterial.UseVisualStyleBackColor = true;
            this.BtnQuitarMaterial.Click += new System.EventHandler(this.BtnQuitarMaterial_Click);
            // 
            // BtnAgregarMaterial
            // 
            this.BtnAgregarMaterial.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnAgregarMaterial.Enabled = false;
            this.BtnAgregarMaterial.Image = global::CB_Base.Properties.Resources.next_icon_32;
            this.BtnAgregarMaterial.Location = new System.Drawing.Point(0, 0);
            this.BtnAgregarMaterial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAgregarMaterial.Name = "BtnAgregarMaterial";
            this.BtnAgregarMaterial.Size = new System.Drawing.Size(95, 69);
            this.BtnAgregarMaterial.TabIndex = 16;
            this.ToolTipMensaje.SetToolTip(this.BtnAgregarMaterial, "Agregar requisición");
            this.BtnAgregarMaterial.UseVisualStyleBackColor = true;
            this.BtnAgregarMaterial.Click += new System.EventHandler(this.BtnAgregarMaterial_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1389, 0);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(189, 69);
            this.BtnSalir.TabIndex = 19;
            this.BtnSalir.Text = "     Salir";
            this.ToolTipMensaje.SetToolTip(this.BtnSalir, "Enviar RFQ");
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.Image = global::CB_Base.Properties.Resources.mail_send_icon48;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(1578, 0);
            this.BtnNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(189, 69);
            this.BtnNuevo.TabIndex = 15;
            this.BtnNuevo.Text = "     Enviar";
            this.ToolTipMensaje.SetToolTip(this.BtnNuevo, "Enviar RFQ");
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // PanelInformacion
            // 
            this.PanelInformacion.Controls.Add(this.LblRequisitor);
            this.PanelInformacion.Controls.Add(this.LblEstatus);
            this.PanelInformacion.Controls.Add(this.LblFechaCreacion);
            this.PanelInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelInformacion.Location = new System.Drawing.Point(0, 97);
            this.PanelInformacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelInformacion.Name = "PanelInformacion";
            this.PanelInformacion.Size = new System.Drawing.Size(1767, 23);
            this.PanelInformacion.TabIndex = 120;
            // 
            // LblRequisitor
            // 
            this.LblRequisitor.AutoSize = true;
            this.LblRequisitor.Location = new System.Drawing.Point(507, 2);
            this.LblRequisitor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRequisitor.Name = "LblRequisitor";
            this.LblRequisitor.Size = new System.Drawing.Size(80, 17);
            this.LblRequisitor.TabIndex = 3;
            this.LblRequisitor.Text = "Requisitor: ";
            // 
            // LblEstatus
            // 
            this.LblEstatus.AutoSize = true;
            this.LblEstatus.Location = new System.Drawing.Point(916, 2);
            this.LblEstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(63, 17);
            this.LblEstatus.TabIndex = 2;
            this.LblEstatus.Text = "Estatus: ";
            // 
            // LblFechaCreacion
            // 
            this.LblFechaCreacion.AutoSize = true;
            this.LblFechaCreacion.Location = new System.Drawing.Point(8, 2);
            this.LblFechaCreacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFechaCreacion.Name = "LblFechaCreacion";
            this.LblFechaCreacion.Size = new System.Drawing.Size(133, 17);
            this.LblFechaCreacion.TabIndex = 0;
            this.LblFechaCreacion.Text = "Fecha de creación: ";
            // 
            // costo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costo.DefaultCellStyle = dataGridViewCellStyle1;
            this.costo.HeaderText = "Costo total";
            this.costo.MinimumWidth = 120;
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Width = 120;
            // 
            // desc_proyecto
            // 
            this.desc_proyecto.HeaderText = "Descripción proyecto";
            this.desc_proyecto.MinimumWidth = 350;
            this.desc_proyecto.Name = "desc_proyecto";
            this.desc_proyecto.ReadOnly = true;
            this.desc_proyecto.Visible = false;
            this.desc_proyecto.Width = 350;
            // 
            // proyecto
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.proyecto.DefaultCellStyle = dataGridViewCellStyle2;
            this.proyecto.HeaderText = "Proyecto";
            this.proyecto.MinimumWidth = 120;
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            this.proyecto.Visible = false;
            this.proyecto.Width = 120;
            // 
            // num_parte
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.num_parte.DefaultCellStyle = dataGridViewCellStyle3;
            this.num_parte.HeaderText = "Número de parte";
            this.num_parte.MinimumWidth = 350;
            this.num_parte.Name = "num_parte";
            this.num_parte.ReadOnly = true;
            this.num_parte.Visible = false;
            this.num_parte.Width = 350;
            // 
            // DgvCostos
            // 
            this.DgvCostos.AllowUserToAddRows = false;
            this.DgvCostos.AllowUserToDeleteRows = false;
            this.DgvCostos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCostos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCostos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvCostos.ColumnHeadersHeight = 50;
            this.DgvCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvCostos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num_parte,
            this.proyecto,
            this.desc_proyecto,
            this.costo});
            this.DgvCostos.ContextMenuStrip = this.OpcionesRfqEnviado;
            this.DgvCostos.Location = new System.Drawing.Point(-1, 0);
            this.DgvCostos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DgvCostos.MultiSelect = false;
            this.DgvCostos.Name = "DgvCostos";
            this.DgvCostos.ReadOnly = true;
            this.DgvCostos.RowHeadersVisible = false;
            this.DgvCostos.RowHeadersWidth = 51;
            this.DgvCostos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvCostos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCostos.Size = new System.Drawing.Size(1767, 256);
            this.DgvCostos.TabIndex = 121;
            // 
            // radioNumPart
            // 
            this.radioNumPart.AutoSize = true;
            this.radioNumPart.Location = new System.Drawing.Point(108, 26);
            this.radioNumPart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioNumPart.Name = "radioNumPart";
            this.radioNumPart.Size = new System.Drawing.Size(136, 21);
            this.radioNumPart.TabIndex = 0;
            this.radioNumPart.Text = "Número de parte";
            this.radioNumPart.UseVisualStyleBackColor = true;
            this.radioNumPart.CheckedChanged += new System.EventHandler(this.radioNumPart_CheckedChanged);
            // 
            // radioProyecto
            // 
            this.radioProyecto.AutoSize = true;
            this.radioProyecto.Checked = true;
            this.radioProyecto.Location = new System.Drawing.Point(11, 26);
            this.radioProyecto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioProyecto.Name = "radioProyecto";
            this.radioProyecto.Size = new System.Drawing.Size(85, 21);
            this.radioProyecto.TabIndex = 1;
            this.radioProyecto.TabStop = true;
            this.radioProyecto.Text = "Proyecto";
            this.radioProyecto.UseVisualStyleBackColor = true;
            // 
            // optNumProy
            // 
            this.optNumProy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optNumProy.Controls.Add(this.radioProyecto);
            this.optNumProy.Controls.Add(this.radioNumPart);
            this.optNumProy.Location = new System.Drawing.Point(4, 263);
            this.optNumProy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optNumProy.Name = "optNumProy";
            this.optNumProy.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optNumProy.Size = new System.Drawing.Size(277, 63);
            this.optNumProy.TabIndex = 122;
            this.optNumProy.TabStop = false;
            this.optNumProy.Text = "Agrupar:";
            // 
            // radioMxn
            // 
            this.radioMxn.AutoSize = true;
            this.radioMxn.Location = new System.Drawing.Point(8, 26);
            this.radioMxn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioMxn.Name = "radioMxn";
            this.radioMxn.Size = new System.Drawing.Size(59, 21);
            this.radioMxn.TabIndex = 0;
            this.radioMxn.Text = "MXN";
            this.radioMxn.UseVisualStyleBackColor = true;
            this.radioMxn.CheckedChanged += new System.EventHandler(this.radioMxn_CheckedChanged);
            // 
            // radioUsd
            // 
            this.radioUsd.AutoSize = true;
            this.radioUsd.Location = new System.Drawing.Point(81, 26);
            this.radioUsd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioUsd.Name = "radioUsd";
            this.radioUsd.Size = new System.Drawing.Size(58, 21);
            this.radioUsd.TabIndex = 1;
            this.radioUsd.Text = "USD";
            this.radioUsd.UseVisualStyleBackColor = true;
            this.radioUsd.CheckedChanged += new System.EventHandler(this.radioUsd_CheckedChanged);
            // 
            // optTipoCambio
            // 
            this.optTipoCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optTipoCambio.Controls.Add(this.radioUsd);
            this.optTipoCambio.Controls.Add(this.radioMxn);
            this.optTipoCambio.Location = new System.Drawing.Point(293, 263);
            this.optTipoCambio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optTipoCambio.Name = "optTipoCambio";
            this.optTipoCambio.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optTipoCambio.Size = new System.Drawing.Size(195, 64);
            this.optTipoCambio.TabIndex = 123;
            this.optTipoCambio.TabStop = false;
            this.optTipoCambio.Text = "Tipo de cambio";
            // 
            // DgvConceptos
            // 
            this.DgvConceptos.AllowUserToAddRows = false;
            this.DgvConceptos.AllowUserToDeleteRows = false;
            this.DgvConceptos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_concepto,
            this.partida,
            this.numero_parte,
            this.fabricante,
            this.descripcion,
            this.cantidad_estimada,
            this.unidades,
            this.precio_unitario,
            this.tiempo_entrega,
            this.cantidad_disponible,
            this.requisiciones_compra,
            this.material_id,
            this.estatus_compra});
            this.DgvConceptos.ContextMenuStrip = this.OpcionesRfqEnviado;
            this.DgvConceptos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvConceptos.Location = new System.Drawing.Point(0, 120);
            this.DgvConceptos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DgvConceptos.MultiSelect = false;
            this.DgvConceptos.Name = "DgvConceptos";
            this.DgvConceptos.ReadOnly = true;
            this.DgvConceptos.RowHeadersVisible = false;
            this.DgvConceptos.RowHeadersWidth = 51;
            this.DgvConceptos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvConceptos.Size = new System.Drawing.Size(1767, 711);
            this.DgvConceptos.TabIndex = 11;
            this.DgvConceptos.SelectionChanged += new System.EventHandler(this.DgvConceptos_SelectionChanged);
            // 
            // panelCostos
            // 
            this.panelCostos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCostos.Controls.Add(this.optTipoCambio);
            this.panelCostos.Controls.Add(this.optNumProy);
            this.panelCostos.Controls.Add(this.DgvCostos);
            this.panelCostos.Location = new System.Drawing.Point(1, 502);
            this.panelCostos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCostos.Name = "panelCostos";
            this.panelCostos.Size = new System.Drawing.Size(1765, 331);
            this.panelCostos.TabIndex = 124;
            this.panelCostos.Visible = false;
            // 
            // id_concepto
            // 
            this.id_concepto.Frozen = true;
            this.id_concepto.HeaderText = "ID Concepto";
            this.id_concepto.MinimumWidth = 100;
            this.id_concepto.Name = "id_concepto";
            this.id_concepto.ReadOnly = true;
            this.id_concepto.Visible = false;
            this.id_concepto.Width = 125;
            // 
            // partida
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.partida.DefaultCellStyle = dataGridViewCellStyle5;
            this.partida.Frozen = true;
            this.partida.HeaderText = "Partida";
            this.partida.MinimumWidth = 50;
            this.partida.Name = "partida";
            this.partida.ReadOnly = true;
            this.partida.Width = 50;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle6;
            this.numero_parte.Frozen = true;
            this.numero_parte.HeaderText = "Número de parte";
            this.numero_parte.MinimumWidth = 150;
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            this.numero_parte.Width = 150;
            // 
            // fabricante
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fabricante.DefaultCellStyle = dataGridViewCellStyle7;
            this.fabricante.Frozen = true;
            this.fabricante.HeaderText = "Fabricante";
            this.fabricante.MinimumWidth = 150;
            this.fabricante.Name = "fabricante";
            this.fabricante.ReadOnly = true;
            this.fabricante.Width = 150;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle8;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 150;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // cantidad_estimada
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad_estimada.DefaultCellStyle = dataGridViewCellStyle9;
            this.cantidad_estimada.HeaderText = "Cantidad estimada";
            this.cantidad_estimada.MinimumWidth = 70;
            this.cantidad_estimada.Name = "cantidad_estimada";
            this.cantidad_estimada.ReadOnly = true;
            this.cantidad_estimada.Width = 70;
            // 
            // unidades
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.unidades.DefaultCellStyle = dataGridViewCellStyle10;
            this.unidades.HeaderText = "Unidades";
            this.unidades.MinimumWidth = 120;
            this.unidades.Name = "unidades";
            this.unidades.ReadOnly = true;
            this.unidades.Width = 120;
            // 
            // precio_unitario
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio_unitario.DefaultCellStyle = dataGridViewCellStyle11;
            this.precio_unitario.HeaderText = "Precio unitario";
            this.precio_unitario.MinimumWidth = 120;
            this.precio_unitario.Name = "precio_unitario";
            this.precio_unitario.ReadOnly = true;
            this.precio_unitario.Width = 120;
            // 
            // tiempo_entrega
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo_entrega.DefaultCellStyle = dataGridViewCellStyle12;
            this.tiempo_entrega.HeaderText = "Tiempo de entrega";
            this.tiempo_entrega.MinimumWidth = 120;
            this.tiempo_entrega.Name = "tiempo_entrega";
            this.tiempo_entrega.ReadOnly = true;
            this.tiempo_entrega.Width = 120;
            // 
            // cantidad_disponible
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad_disponible.DefaultCellStyle = dataGridViewCellStyle13;
            this.cantidad_disponible.HeaderText = "Cantidad disponible";
            this.cantidad_disponible.MinimumWidth = 120;
            this.cantidad_disponible.Name = "cantidad_disponible";
            this.cantidad_disponible.ReadOnly = true;
            this.cantidad_disponible.Width = 120;
            // 
            // requisiciones_compra
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.requisiciones_compra.DefaultCellStyle = dataGridViewCellStyle14;
            this.requisiciones_compra.HeaderText = "Requisiciones de compra sin proveedor seleccionado";
            this.requisiciones_compra.MinimumWidth = 100;
            this.requisiciones_compra.Name = "requisiciones_compra";
            this.requisiciones_compra.ReadOnly = true;
            this.requisiciones_compra.Width = 125;
            // 
            // material_id
            // 
            this.material_id.HeaderText = "ID material";
            this.material_id.MinimumWidth = 6;
            this.material_id.Name = "material_id";
            this.material_id.ReadOnly = true;
            this.material_id.Visible = false;
            this.material_id.Width = 125;
            // 
            // estatus_compra
            // 
            this.estatus_compra.HeaderText = "estatus_compra";
            this.estatus_compra.MinimumWidth = 6;
            this.estatus_compra.Name = "estatus_compra";
            this.estatus_compra.ReadOnly = true;
            this.estatus_compra.Width = 125;
            // 
            // FrmAgregarRfq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1767, 831);
            this.Controls.Add(this.panelCostos);
            this.Controls.Add(this.DgvConceptos);
            this.Controls.Add(this.PanelInformacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblRFQ);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAgregarRfq";
            this.Text = "Agregar RFQ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAgregarRfq_Load);
            this.OpcionesRfqEnviado.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PanelInformacion.ResumeLayout(false);
            this.PanelInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCostos)).EndInit();
            this.optNumProy.ResumeLayout(false);
            this.optNumProy.PerformLayout();
            this.optTipoCambio.ResumeLayout(false);
            this.optTipoCambio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConceptos)).EndInit();
            this.panelCostos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblRFQ;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnQuitarMaterial;
        private System.Windows.Forms.Button BtnAgregarMaterial;
        private System.Windows.Forms.ContextMenuStrip OpcionesRfqEnviado;
        private System.Windows.Forms.ToolStripMenuItem capturarCotizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolTip ToolTipMensaje;
        private System.Windows.Forms.ToolStripMenuItem modificarCantidadToolStripMenuItem;
        private System.Windows.Forms.Panel PanelInformacion;
        private System.Windows.Forms.Label LblRequisitor;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.Label LblFechaCreacion;
        private System.Windows.Forms.Button BtnAsignarConceptos;
        private System.Windows.Forms.ToolStripMenuItem seleccionarCotizacionToolStripMenuItem;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ToolStripMenuItem desvincularCotizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desglosarCostorToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_parte;
        private System.Windows.Forms.DataGridView DgvCostos;
        private System.Windows.Forms.RadioButton radioNumPart;
        private System.Windows.Forms.RadioButton radioProyecto;
        private System.Windows.Forms.GroupBox optNumProy;
        private System.Windows.Forms.RadioButton radioMxn;
        private System.Windows.Forms.RadioButton radioUsd;
        private System.Windows.Forms.GroupBox optTipoCambio;
        private System.Windows.Forms.DataGridView DgvConceptos;
        private System.Windows.Forms.Panel panelCostos;
        private System.Windows.Forms.ToolStripMenuItem ocultarDesgloseDeCostosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vincularRequisicionesARFQToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_estimada;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_entrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_disponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisiciones_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn material_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_compra;
    }
}
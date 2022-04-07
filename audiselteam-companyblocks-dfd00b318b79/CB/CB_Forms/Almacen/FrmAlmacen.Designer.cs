namespace CB
{
    partial class FrmAlmacen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnMovimientos = new System.Windows.Forms.Button();
            this.BtnAlta = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbFiltroAlmacen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvMateriales = new System.Windows.Forms.DataGridView();
            this.Seleccionar_requisicion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATEGORIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO_PARTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FABRICANTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROYECTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REQUISITOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUS_ALMACEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD_ALMACEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuAlta = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuDesdePO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSinPO = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuBaja = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bajaMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSeleccionar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarNadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSeleccionarMaterial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMateriales)).BeginInit();
            this.contextMenuAlta.SuspendLayout();
            this.contextMenuBaja.SuspendLayout();
            this.contextMenuSeleccionar.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnSeleccionarMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.BtnMovimientos);
            this.splitContainer1.Panel1.Controls.Add(this.BtnAlta);
            this.splitContainer1.Panel1.Controls.Add(this.BtnEliminar);
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.CmbFiltroAlmacen);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvMateriales);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 689);
            this.splitContainer1.SplitterDistance = 92;
            this.splitContainer1.TabIndex = 0;
            // 
            // BtnMovimientos
            // 
            this.BtnMovimientos.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMovimientos.Image = global::CB_Base.Properties.Resources.Edit;
            this.BtnMovimientos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMovimientos.Location = new System.Drawing.Point(582, 23);
            this.BtnMovimientos.Name = "BtnMovimientos";
            this.BtnMovimientos.Size = new System.Drawing.Size(140, 69);
            this.BtnMovimientos.TabIndex = 23;
            this.BtnMovimientos.Text = "     Movimientos";
            this.BtnMovimientos.UseVisualStyleBackColor = true;
            this.BtnMovimientos.Click += new System.EventHandler(this.BtnMovimientos_Click);
            // 
            // BtnAlta
            // 
            this.BtnAlta.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlta.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.BtnAlta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAlta.Location = new System.Drawing.Point(722, 23);
            this.BtnAlta.Name = "BtnAlta";
            this.BtnAlta.Size = new System.Drawing.Size(115, 69);
            this.BtnAlta.TabIndex = 22;
            this.BtnAlta.Text = "    Alta";
            this.BtnAlta.UseVisualStyleBackColor = true;
            this.BtnAlta.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(837, 23);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(115, 69);
            this.BtnEliminar.TabIndex = 21;
            this.BtnEliminar.Text = "      Baja";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(952, 23);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(115, 69);
            this.BtnSalir.TabIndex = 20;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tipo de material:";
            // 
            // CmbFiltroAlmacen
            // 
            this.CmbFiltroAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroAlmacen.FormattingEnabled = true;
            this.CmbFiltroAlmacen.Items.AddRange(new object[] {
            "MATERIAL PROYECTOS",
            "MATERIAL STOCK"});
            this.CmbFiltroAlmacen.Location = new System.Drawing.Point(12, 49);
            this.CmbFiltroAlmacen.Name = "CmbFiltroAlmacen";
            this.CmbFiltroAlmacen.Size = new System.Drawing.Size(453, 32);
            this.CmbFiltroAlmacen.TabIndex = 18;
            this.CmbFiltroAlmacen.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroAlmacen_SelectedIndexChanged);
            this.CmbFiltroAlmacen.SelectedValueChanged += new System.EventHandler(this.CmbFiltroAlmacen_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1067, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "MONITOR DE ALMACEN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvMateriales
            // 
            this.DgvMateriales.AllowUserToAddRows = false;
            this.DgvMateriales.AllowUserToDeleteRows = false;
            this.DgvMateriales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMateriales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMateriales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar_requisicion,
            this.ID,
            this.CATEGORIA,
            this.NUMERO_PARTE,
            this.FABRICANTE,
            this.DESCRIPCION,
            this.PROYECTO,
            this.REQUISITOR,
            this.ESTATUS_ALMACEN,
            this.CANTIDAD_ALMACEN,
            this.ID_STOCK});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvMateriales.DefaultCellStyle = dataGridViewCellStyle22;
            this.DgvMateriales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMateriales.Location = new System.Drawing.Point(0, 0);
            this.DgvMateriales.MultiSelect = false;
            this.DgvMateriales.Name = "DgvMateriales";
            this.DgvMateriales.RowHeadersVisible = false;
            this.DgvMateriales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMateriales.Size = new System.Drawing.Size(1067, 593);
            this.DgvMateriales.TabIndex = 0;
            this.DgvMateriales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMateriales_CellClick);
            this.DgvMateriales.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvMateriales_MouseDown);
            // 
            // Seleccionar_requisicion
            // 
            this.Seleccionar_requisicion.FalseValue = "false";
            this.Seleccionar_requisicion.HeaderText = "Seleccionar";
            this.Seleccionar_requisicion.Name = "Seleccionar_requisicion";
            this.Seleccionar_requisicion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionar_requisicion.TrueValue = "true";
            // 
            // ID
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle13;
            this.ID.HeaderText = "Numero de Requisicion";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // CATEGORIA
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CATEGORIA.DefaultCellStyle = dataGridViewCellStyle14;
            this.CATEGORIA.HeaderText = "Categoria";
            this.CATEGORIA.Name = "CATEGORIA";
            this.CATEGORIA.ReadOnly = true;
            // 
            // NUMERO_PARTE
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NUMERO_PARTE.DefaultCellStyle = dataGridViewCellStyle15;
            this.NUMERO_PARTE.HeaderText = "Numero de Parte";
            this.NUMERO_PARTE.Name = "NUMERO_PARTE";
            this.NUMERO_PARTE.ReadOnly = true;
            // 
            // FABRICANTE
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FABRICANTE.DefaultCellStyle = dataGridViewCellStyle16;
            this.FABRICANTE.HeaderText = "Fabricante";
            this.FABRICANTE.Name = "FABRICANTE";
            this.FABRICANTE.ReadOnly = true;
            // 
            // DESCRIPCION
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DESCRIPCION.DefaultCellStyle = dataGridViewCellStyle17;
            this.DESCRIPCION.HeaderText = "Descripcion";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            // 
            // PROYECTO
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PROYECTO.DefaultCellStyle = dataGridViewCellStyle18;
            this.PROYECTO.HeaderText = "Proyecto";
            this.PROYECTO.Name = "PROYECTO";
            this.PROYECTO.ReadOnly = true;
            // 
            // REQUISITOR
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.REQUISITOR.DefaultCellStyle = dataGridViewCellStyle19;
            this.REQUISITOR.HeaderText = "Requisitor";
            this.REQUISITOR.Name = "REQUISITOR";
            this.REQUISITOR.ReadOnly = true;
            // 
            // ESTATUS_ALMACEN
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ESTATUS_ALMACEN.DefaultCellStyle = dataGridViewCellStyle20;
            this.ESTATUS_ALMACEN.HeaderText = "Estatus Almacen";
            this.ESTATUS_ALMACEN.Name = "ESTATUS_ALMACEN";
            this.ESTATUS_ALMACEN.ReadOnly = true;
            // 
            // CANTIDAD_ALMACEN
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CANTIDAD_ALMACEN.DefaultCellStyle = dataGridViewCellStyle21;
            this.CANTIDAD_ALMACEN.HeaderText = "Cantidad en Almacen";
            this.CANTIDAD_ALMACEN.Name = "CANTIDAD_ALMACEN";
            this.CANTIDAD_ALMACEN.ReadOnly = true;
            // 
            // ID_STOCK
            // 
            this.ID_STOCK.HeaderText = "Id Stock";
            this.ID_STOCK.Name = "ID_STOCK";
            this.ID_STOCK.ReadOnly = true;
            this.ID_STOCK.Visible = false;
            // 
            // contextMenuAlta
            // 
            this.contextMenuAlta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuDesdePO,
            this.toolStripMenuSinPO});
            this.contextMenuAlta.Name = "contextMenuAlta";
            this.contextMenuAlta.Size = new System.Drawing.Size(126, 48);
            // 
            // toolStripMenuDesdePO
            // 
            this.toolStripMenuDesdePO.Name = "toolStripMenuDesdePO";
            this.toolStripMenuDesdePO.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuDesdePO.Text = "Desde PO";
            this.toolStripMenuDesdePO.Click += new System.EventHandler(this.toolStripMenuDesdePO_Click);
            // 
            // toolStripMenuSinPO
            // 
            this.toolStripMenuSinPO.Name = "toolStripMenuSinPO";
            this.toolStripMenuSinPO.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuSinPO.Text = "Sin PO";
            this.toolStripMenuSinPO.Click += new System.EventHandler(this.toolStripMenuSinPO1_Click);
            // 
            // contextMenuBaja
            // 
            this.contextMenuBaja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bajaMaterialToolStripMenuItem});
            this.contextMenuBaja.Name = "contextMenuBaja";
            this.contextMenuBaja.Size = new System.Drawing.Size(143, 26);
            // 
            // bajaMaterialToolStripMenuItem
            // 
            this.bajaMaterialToolStripMenuItem.Name = "bajaMaterialToolStripMenuItem";
            this.bajaMaterialToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.bajaMaterialToolStripMenuItem.Text = "Baja Material";
            this.bajaMaterialToolStripMenuItem.Click += new System.EventHandler(this.bajaMaterialToolStripMenuItem_Click);
            // 
            // contextMenuSeleccionar
            // 
            this.contextMenuSeleccionar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarTodoToolStripMenuItem,
            this.seleccionarNadaToolStripMenuItem});
            this.contextMenuSeleccionar.Name = "contextMenuSeleccionar";
            this.contextMenuSeleccionar.Size = new System.Drawing.Size(164, 48);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.progress_default;
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo";
            this.seleccionarTodoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarTodoToolStripMenuItem_Click);
            // 
            // seleccionarNadaToolStripMenuItem
            // 
            this.seleccionarNadaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.progress_defaultModify;
            this.seleccionarNadaToolStripMenuItem.Name = "seleccionarNadaToolStripMenuItem";
            this.seleccionarNadaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seleccionarNadaToolStripMenuItem.Text = "Seleccionar nada";
            this.seleccionarNadaToolStripMenuItem.Click += new System.EventHandler(this.seleccionarNadaToolStripMenuItem_Click);
            // 
            // BtnSeleccionarMaterial
            // 
            this.BtnSeleccionarMaterial.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSeleccionarMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarMaterial.Image = global::CB_Base.Properties.Resources.order;
            this.BtnSeleccionarMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSeleccionarMaterial.Location = new System.Drawing.Point(467, 23);
            this.BtnSeleccionarMaterial.Name = "BtnSeleccionarMaterial";
            this.BtnSeleccionarMaterial.Size = new System.Drawing.Size(115, 69);
            this.BtnSeleccionarMaterial.TabIndex = 24;
            this.BtnSeleccionarMaterial.Text = "    M.R.O";
            this.BtnSeleccionarMaterial.UseVisualStyleBackColor = true;
            this.BtnSeleccionarMaterial.Click += new System.EventHandler(this.BtnSeleccionarMaterial_Click);
            // 
            // FrmAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 689);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmAlmacen";
            this.Text = "Monitor Almacen";
            this.Load += new System.EventHandler(this.FrmAlmacen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMateriales)).EndInit();
            this.contextMenuAlta.ResumeLayout(false);
            this.contextMenuBaja.ResumeLayout(false);
            this.contextMenuSeleccionar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvMateriales;
        private System.Windows.Forms.Button BtnAlta;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbFiltroAlmacen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuAlta;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDesdePO;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSinPO;
        private System.Windows.Forms.ContextMenuStrip contextMenuBaja;
        private System.Windows.Forms.ToolStripMenuItem bajaMaterialToolStripMenuItem;
        private System.Windows.Forms.Button BtnMovimientos;
        private System.Windows.Forms.ContextMenuStrip contextMenuSeleccionar;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarNadaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar_requisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO_PARTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FABRICANTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROYECTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn REQUISITOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUS_ALMACEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD_ALMACEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_STOCK;
        private System.Windows.Forms.Button BtnSeleccionarMaterial;
    }
}
namespace CB
{
    partial class FrmRevisionFinanciera
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
            this.DgvCotizacion = new System.Windows.Forms.DataGridView();
            this.id_req = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_requerida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_limite_para_ordenar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuAutorizacion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aceptarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechazarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgEnviarCorreo = new System.ComponentModel.BackgroundWorker();
            this.LblEstatusAsignaciones = new System.Windows.Forms.Label();
            this.BkgCargarInformacion = new System.ComponentModel.BackgroundWorker();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbProveedor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmbproyecto = new System.Windows.Forms.ComboBox();
            this.LblEtiqueta = new System.Windows.Forms.Label();
            this.CmbEstatus = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblRegistros = new System.Windows.Forms.Label();
            this.reg = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.DThasta = new System.Windows.Forms.DateTimePicker();
            this.LblLimite = new System.Windows.Forms.Label();
            this.NumLimite = new System.Windows.Forms.NumericUpDown();
            this.PanelDesde = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DTdesde = new System.Windows.Forms.DateTimePicker();
            this.LblMaterial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCotizacion)).BeginInit();
            this.MenuAutorizacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumLimite)).BeginInit();
            this.PanelDesde.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvCotizacion
            // 
            this.DgvCotizacion.AllowUserToAddRows = false;
            this.DgvCotizacion.AllowUserToDeleteRows = false;
            this.DgvCotizacion.AllowUserToResizeRows = false;
            this.DgvCotizacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCotizacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCotizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_req,
            this.numero_parte,
            this.categoria,
            this.proyecto,
            this.proveedor,
            this.requisitor,
            this.cantidad_requerida,
            this.precio_unitario,
            this.total,
            this.fecha_limite_para_ordenar});
            this.DgvCotizacion.ContextMenuStrip = this.MenuAutorizacion;
            this.DgvCotizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCotizacion.Location = new System.Drawing.Point(0, 143);
            this.DgvCotizacion.Name = "DgvCotizacion";
            this.DgvCotizacion.RowHeadersVisible = false;
            this.DgvCotizacion.RowHeadersWidth = 51;
            this.DgvCotizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCotizacion.Size = new System.Drawing.Size(1053, 348);
            this.DgvCotizacion.TabIndex = 2;
            this.DgvCotizacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCotizacion_CellDoubleClick);
            this.DgvCotizacion.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvCotizacion_CellFormatting);
            // 
            // id_req
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id_req.DefaultCellStyle = dataGridViewCellStyle2;
            this.id_req.HeaderText = "Requisición";
            this.id_req.MinimumWidth = 6;
            this.id_req.Name = "id_req";
            this.id_req.ReadOnly = true;
            this.id_req.Width = 125;
            // 
            // numero_parte
            // 
            this.numero_parte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle3;
            this.numero_parte.HeaderText = "# Parte";
            this.numero_parte.MinimumWidth = 150;
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            // 
            // categoria
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.categoria.DefaultCellStyle = dataGridViewCellStyle4;
            this.categoria.HeaderText = "Categoría";
            this.categoria.MinimumWidth = 120;
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            this.categoria.Width = 120;
            // 
            // proyecto
            // 
            this.proyecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proyecto.DefaultCellStyle = dataGridViewCellStyle5;
            this.proyecto.HeaderText = "Proyecto";
            this.proyecto.MinimumWidth = 250;
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            // 
            // proveedor
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proveedor.DefaultCellStyle = dataGridViewCellStyle6;
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.MinimumWidth = 120;
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            this.proveedor.Width = 120;
            // 
            // requisitor
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requisitor.DefaultCellStyle = dataGridViewCellStyle7;
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.MinimumWidth = 150;
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            this.requisitor.Width = 150;
            // 
            // cantidad_requerida
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad_requerida.DefaultCellStyle = dataGridViewCellStyle8;
            this.cantidad_requerida.HeaderText = "Cantidad requerida";
            this.cantidad_requerida.MinimumWidth = 130;
            this.cantidad_requerida.Name = "cantidad_requerida";
            this.cantidad_requerida.ReadOnly = true;
            this.cantidad_requerida.Width = 130;
            // 
            // precio_unitario
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.precio_unitario.DefaultCellStyle = dataGridViewCellStyle9;
            this.precio_unitario.HeaderText = "Precio unitario";
            this.precio_unitario.MinimumWidth = 90;
            this.precio_unitario.Name = "precio_unitario";
            this.precio_unitario.ReadOnly = true;
            this.precio_unitario.Width = 90;
            // 
            // total
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.total.DefaultCellStyle = dataGridViewCellStyle10;
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 150;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 150;
            // 
            // fecha_limite_para_ordenar
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_limite_para_ordenar.DefaultCellStyle = dataGridViewCellStyle11;
            this.fecha_limite_para_ordenar.HeaderText = "Feha límite para ordenar";
            this.fecha_limite_para_ordenar.MinimumWidth = 150;
            this.fecha_limite_para_ordenar.Name = "fecha_limite_para_ordenar";
            this.fecha_limite_para_ordenar.ReadOnly = true;
            this.fecha_limite_para_ordenar.Width = 150;
            // 
            // MenuAutorizacion
            // 
            this.MenuAutorizacion.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuAutorizacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aceptarToolStripMenuItem,
            this.rechazarToolStripMenuItem});
            this.MenuAutorizacion.Name = "MenuAutorizacion";
            this.MenuAutorizacion.Size = new System.Drawing.Size(127, 56);
            this.MenuAutorizacion.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // aceptarToolStripMenuItem
            // 
            this.aceptarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.approve;
            this.aceptarToolStripMenuItem.Name = "aceptarToolStripMenuItem";
            this.aceptarToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.aceptarToolStripMenuItem.Text = "Autorizar";
            this.aceptarToolStripMenuItem.Click += new System.EventHandler(this.aceptarToolStripMenuItem_Click);
            // 
            // rechazarToolStripMenuItem
            // 
            this.rechazarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.reject_icon;
            this.rechazarToolStripMenuItem.Name = "rechazarToolStripMenuItem";
            this.rechazarToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.rechazarToolStripMenuItem.Text = "Detener";
            this.rechazarToolStripMenuItem.Click += new System.EventHandler(this.rechazarToolStripMenuItem_Click);
            // 
            // BkgEnviarCorreo
            // 
            this.BkgEnviarCorreo.WorkerReportsProgress = true;
            this.BkgEnviarCorreo.WorkerSupportsCancellation = true;
            this.BkgEnviarCorreo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEnviarCorreo_DoWork);
            this.BkgEnviarCorreo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEnviarCorreo_RunWorkerCompleted);
            // 
            // LblEstatusAsignaciones
            // 
            this.LblEstatusAsignaciones.BackColor = System.Drawing.Color.Black;
            this.LblEstatusAsignaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusAsignaciones.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusAsignaciones.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusAsignaciones.Location = new System.Drawing.Point(0, 491);
            this.LblEstatusAsignaciones.Name = "LblEstatusAsignaciones";
            this.LblEstatusAsignaciones.Size = new System.Drawing.Size(1053, 25);
            this.LblEstatusAsignaciones.TabIndex = 112;
            this.LblEstatusAsignaciones.Text = "Estatus...";
            this.LblEstatusAsignaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BkgCargarInformacion
            // 
            this.BkgCargarInformacion.WorkerReportsProgress = true;
            this.BkgCargarInformacion.WorkerSupportsCancellation = true;
            this.BkgCargarInformacion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgCargarInformacion_DoWork);
            this.BkgCargarInformacion.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgCargarInformacion_ProgressChanged);
            this.BkgCargarInformacion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgCargarInformacion_RunWorkerCompleted);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.Location = new System.Drawing.Point(0, 23);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.CmbProveedor);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.Cmbproyecto);
            this.splitContainer2.Panel1.Controls.Add(this.LblEtiqueta);
            this.splitContainer2.Panel1.Controls.Add(this.CmbEstatus);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Panel2.Controls.Add(this.PanelDesde);
            this.splitContainer2.Size = new System.Drawing.Size(1053, 120);
            this.splitContainer2.SplitterDistance = 60;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 113;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Filtrar por proveedores:";
            // 
            // CmbProveedor
            // 
            this.CmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProveedor.FormattingEnabled = true;
            this.CmbProveedor.Items.AddRange(new object[] {
            "PENDIENTE",
            "DETENIDO",
            "AUTORIZADO"});
            this.CmbProveedor.Location = new System.Drawing.Point(449, 28);
            this.CmbProveedor.Name = "CmbProveedor";
            this.CmbProveedor.Size = new System.Drawing.Size(212, 24);
            this.CmbProveedor.TabIndex = 16;
            this.CmbProveedor.SelectedIndexChanged += new System.EventHandler(this.CmbProveedor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Filtrar por proyecto:";
            // 
            // Cmbproyecto
            // 
            this.Cmbproyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmbproyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmbproyecto.FormattingEnabled = true;
            this.Cmbproyecto.Items.AddRange(new object[] {
            "PENDIENTE",
            "DETENIDO",
            "AUTORIZADO"});
            this.Cmbproyecto.Location = new System.Drawing.Point(231, 28);
            this.Cmbproyecto.Name = "Cmbproyecto";
            this.Cmbproyecto.Size = new System.Drawing.Size(212, 24);
            this.Cmbproyecto.TabIndex = 14;
            this.Cmbproyecto.SelectedIndexChanged += new System.EventHandler(this.Cmbproyecto_SelectedIndexChanged);
            // 
            // LblEtiqueta
            // 
            this.LblEtiqueta.AutoSize = true;
            this.LblEtiqueta.Location = new System.Drawing.Point(10, 13);
            this.LblEtiqueta.Name = "LblEtiqueta";
            this.LblEtiqueta.Size = new System.Drawing.Size(93, 13);
            this.LblEtiqueta.TabIndex = 13;
            this.LblEtiqueta.Text = "Filtrar por estatus: ";
            // 
            // CmbEstatus
            // 
            this.CmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatus.FormattingEnabled = true;
            this.CmbEstatus.Items.AddRange(new object[] {
            "PENDIENTE",
            "DETENIDO",
            "AUTORIZADO"});
            this.CmbEstatus.Location = new System.Drawing.Point(13, 28);
            this.CmbEstatus.Name = "CmbEstatus";
            this.CmbEstatus.Size = new System.Drawing.Size(212, 24);
            this.CmbEstatus.TabIndex = 12;
            this.CmbEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbEstatus_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(899, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 60);
            this.panel2.TabIndex = 1;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(154, 60);
            this.BtnSalir.TabIndex = 1;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblRegistros);
            this.panel1.Controls.Add(this.reg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(872, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 57);
            this.panel1.TabIndex = 118;
            // 
            // LblRegistros
            // 
            this.LblRegistros.AutoSize = true;
            this.LblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistros.Location = new System.Drawing.Point(121, 36);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(11, 13);
            this.LblRegistros.TabIndex = 119;
            this.LblRegistros.Text = "-";
            // 
            // reg
            // 
            this.reg.AutoSize = true;
            this.reg.Location = new System.Drawing.Point(8, 36);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(92, 13);
            this.reg.TabIndex = 118;
            this.reg.Text = "Num. de registros:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.DThasta);
            this.panel3.Controls.Add(this.LblLimite);
            this.panel3.Controls.Add(this.NumLimite);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(228, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 57);
            this.panel3.TabIndex = 114;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Filtrar hasta:";
            // 
            // DThasta
            // 
            this.DThasta.Location = new System.Drawing.Point(13, 29);
            this.DThasta.MinDate = new System.DateTime(2019, 6, 6, 0, 0, 0, 0);
            this.DThasta.Name = "DThasta";
            this.DThasta.Size = new System.Drawing.Size(212, 20);
            this.DThasta.TabIndex = 18;
            this.DThasta.ValueChanged += new System.EventHandler(this.DThasta_ValueChanged);
            // 
            // LblLimite
            // 
            this.LblLimite.AutoSize = true;
            this.LblLimite.Location = new System.Drawing.Point(236, 12);
            this.LblLimite.Name = "LblLimite";
            this.LblLimite.Size = new System.Drawing.Size(39, 13);
            this.LblLimite.TabIndex = 17;
            this.LblLimite.Text = "Límite:";
            // 
            // NumLimite
            // 
            this.NumLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumLimite.Location = new System.Drawing.Point(239, 29);
            this.NumLimite.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumLimite.Name = "NumLimite";
            this.NumLimite.Size = new System.Drawing.Size(72, 22);
            this.NumLimite.TabIndex = 16;
            this.NumLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumLimite.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumLimite.ValueChanged += new System.EventHandler(this.NumLimite_ValueChanged);
            // 
            // PanelDesde
            // 
            this.PanelDesde.Controls.Add(this.label3);
            this.PanelDesde.Controls.Add(this.DTdesde);
            this.PanelDesde.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelDesde.Location = new System.Drawing.Point(0, 0);
            this.PanelDesde.Margin = new System.Windows.Forms.Padding(2);
            this.PanelDesde.Name = "PanelDesde";
            this.PanelDesde.Size = new System.Drawing.Size(228, 57);
            this.PanelDesde.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Filtrar desde:";
            // 
            // DTdesde
            // 
            this.DTdesde.Location = new System.Drawing.Point(13, 29);
            this.DTdesde.MinDate = new System.DateTime(2019, 6, 6, 0, 0, 0, 0);
            this.DTdesde.Name = "DTdesde";
            this.DTdesde.Size = new System.Drawing.Size(212, 20);
            this.DTdesde.TabIndex = 14;
            this.DTdesde.ValueChanged += new System.EventHandler(this.DTdesde_ValueChanged);
            // 
            // LblMaterial
            // 
            this.LblMaterial.BackColor = System.Drawing.Color.Black;
            this.LblMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMaterial.ForeColor = System.Drawing.Color.White;
            this.LblMaterial.Location = new System.Drawing.Point(0, 0);
            this.LblMaterial.Name = "LblMaterial";
            this.LblMaterial.Size = new System.Drawing.Size(1053, 23);
            this.LblMaterial.TabIndex = 114;
            this.LblMaterial.Text = "FINANZAS";
            this.LblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmRevisionFinanciera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 516);
            this.Controls.Add(this.DgvCotizacion);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.LblEstatusAsignaciones);
            this.Controls.Add(this.LblMaterial);
            this.Name = "FrmRevisionFinanciera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Revision financiera";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRevisionFinanciera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCotizacion)).EndInit();
            this.MenuAutorizacion.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumLimite)).EndInit();
            this.PanelDesde.ResumeLayout(false);
            this.PanelDesde.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.DataGridView DgvCotizacion;
        private System.Windows.Forms.ContextMenuStrip MenuAutorizacion;
        private System.Windows.Forms.ToolStripMenuItem aceptarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechazarToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgEnviarCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_req;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_requerida;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_limite_para_ordenar;
        private System.Windows.Forms.Label LblEstatusAsignaciones;
        private System.ComponentModel.BackgroundWorker BkgCargarInformacion;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmbproyecto;
        private System.Windows.Forms.Label LblEtiqueta;
        private System.Windows.Forms.ComboBox CmbEstatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DThasta;
        private System.Windows.Forms.Label LblLimite;
        private System.Windows.Forms.NumericUpDown NumLimite;
        private System.Windows.Forms.Panel PanelDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTdesde;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblRegistros;
        private System.Windows.Forms.Label reg;
        private System.Windows.Forms.Label LblMaterial;
    }
}
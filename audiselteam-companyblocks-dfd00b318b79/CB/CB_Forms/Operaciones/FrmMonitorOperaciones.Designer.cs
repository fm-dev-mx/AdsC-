namespace CB
{
    partial class FrmMonitorOperaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitorOperaciones));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnMaterial = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbFinalizacion = new System.Windows.Forms.ComboBox();
            this.BtnMantenimientos = new System.Windows.Forms.Button();
            this.MenuMantenimiento = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vehículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edificioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maquinaríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImgListMantenimiento = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.DtHasta = new System.Windows.Forms.DateTimePicker();
            this.DtDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbEstatusAutorizacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbProceso = new System.Windows.Forms.ComboBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvMetas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_entregable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entregable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_solicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_autorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_terminacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuMetas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aceptarMetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechazarMetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.MenuMantenimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetas)).BeginInit();
            this.MenuMetas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnMaterial);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CmbFinalizacion);
            this.panel1.Controls.Add(this.BtnMantenimientos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DtHasta);
            this.panel1.Controls.Add(this.DtDesde);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CmbEstatusAutorizacion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CmbProceso);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1497, 86);
            this.panel1.TabIndex = 0;
            // 
            // BtnMaterial
            // 
            this.BtnMaterial.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMaterial.Image = global::CB_Base.Properties.Resources.order;
            this.BtnMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMaterial.Location = new System.Drawing.Point(1060, 23);
            this.BtnMaterial.Name = "BtnMaterial";
            this.BtnMaterial.Size = new System.Drawing.Size(129, 63);
            this.BtnMaterial.TabIndex = 111;
            this.BtnMaterial.Text = "     M.R.O.";
            this.BtnMaterial.UseVisualStyleBackColor = true;
            this.BtnMaterial.Click += new System.EventHandler(this.BtnMaterial_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "Filtrar por estatus de finalización:";
            // 
            // CmbFinalizacion
            // 
            this.CmbFinalizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFinalizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFinalizacion.FormattingEnabled = true;
            this.CmbFinalizacion.Items.AddRange(new object[] {
            "SIN TERMINAR",
            "TERMINADO"});
            this.CmbFinalizacion.Location = new System.Drawing.Point(392, 49);
            this.CmbFinalizacion.Name = "CmbFinalizacion";
            this.CmbFinalizacion.Size = new System.Drawing.Size(157, 28);
            this.CmbFinalizacion.TabIndex = 95;
            this.CmbFinalizacion.SelectedIndexChanged += new System.EventHandler(this.CmbFinalizacion_SelectedIndexChanged);
            // 
            // BtnMantenimientos
            // 
            this.BtnMantenimientos.ContextMenuStrip = this.MenuMantenimiento;
            this.BtnMantenimientos.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMantenimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMantenimientos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMantenimientos.ImageIndex = 0;
            this.BtnMantenimientos.ImageList = this.ImgListMantenimiento;
            this.BtnMantenimientos.Location = new System.Drawing.Point(1189, 23);
            this.BtnMantenimientos.Name = "BtnMantenimientos";
            this.BtnMantenimientos.Size = new System.Drawing.Size(173, 63);
            this.BtnMantenimientos.TabIndex = 93;
            this.BtnMantenimientos.Text = "       Mantenimientos";
            this.BtnMantenimientos.UseVisualStyleBackColor = true;
            this.BtnMantenimientos.Click += new System.EventHandler(this.BtnMantenimientos_Click);
            // 
            // MenuMantenimiento
            // 
            this.MenuMantenimiento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehículosToolStripMenuItem,
            this.edificioToolStripMenuItem,
            this.maquinaríaToolStripMenuItem});
            this.MenuMantenimiento.Name = "MenuMantenimiento";
            this.MenuMantenimiento.Size = new System.Drawing.Size(135, 70);
            // 
            // vehículosToolStripMenuItem
            // 
            this.vehículosToolStripMenuItem.Image = global::CB_Base.Properties.Resources.truck_icon_48;
            this.vehículosToolStripMenuItem.Name = "vehículosToolStripMenuItem";
            this.vehículosToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.vehículosToolStripMenuItem.Text = "Vehículos";
            this.vehículosToolStripMenuItem.Click += new System.EventHandler(this.BtnMantenimientoCorrectivo_Click);
            // 
            // edificioToolStripMenuItem
            // 
            this.edificioToolStripMenuItem.Image = global::CB_Base.Properties.Resources.house_48;
            this.edificioToolStripMenuItem.Name = "edificioToolStripMenuItem";
            this.edificioToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.edificioToolStripMenuItem.Text = "Edificio";
            this.edificioToolStripMenuItem.Click += new System.EventHandler(this.BtnMantenimientoCorrectivoEdificio_Click);
            // 
            // maquinaríaToolStripMenuItem
            // 
            this.maquinaríaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.mantenimiento_correctivo;
            this.maquinaríaToolStripMenuItem.Name = "maquinaríaToolStripMenuItem";
            this.maquinaríaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.maquinaríaToolStripMenuItem.Text = "Maquinaría";
            this.maquinaríaToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImgListMantenimiento
            // 
            this.ImgListMantenimiento.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgListMantenimiento.ImageStream")));
            this.ImgListMantenimiento.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgListMantenimiento.Images.SetKeyName(0, "mantenimiento_48.png");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(699, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Hasta:";
            // 
            // DtHasta
            // 
            this.DtHasta.CustomFormat = "MMM dd, yyyy";
            this.DtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtHasta.Location = new System.Drawing.Point(702, 49);
            this.DtHasta.Name = "DtHasta";
            this.DtHasta.Size = new System.Drawing.Size(136, 26);
            this.DtHasta.TabIndex = 29;
            this.DtHasta.ValueChanged += new System.EventHandler(this.DtHasta_ValueChanged);
            // 
            // DtDesde
            // 
            this.DtDesde.CustomFormat = "MMM dd, yyyy";
            this.DtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtDesde.Location = new System.Drawing.Point(560, 49);
            this.DtDesde.Name = "DtDesde";
            this.DtDesde.Size = new System.Drawing.Size(136, 26);
            this.DtDesde.TabIndex = 28;
            this.DtDesde.ValueChanged += new System.EventHandler(this.DtDesde_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Desde:";
            // 
            // CmbEstatusAutorizacion
            // 
            this.CmbEstatusAutorizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatusAutorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatusAutorizacion.FormattingEnabled = true;
            this.CmbEstatusAutorizacion.Items.AddRange(new object[] {
            "TODOS",
            "PENDIENTE",
            "AUTORIZADO",
            "RECHAZADO"});
            this.CmbEstatusAutorizacion.Location = new System.Drawing.Point(229, 49);
            this.CmbEstatusAutorizacion.Name = "CmbEstatusAutorizacion";
            this.CmbEstatusAutorizacion.Size = new System.Drawing.Size(157, 28);
            this.CmbEstatusAutorizacion.TabIndex = 25;
            this.CmbEstatusAutorizacion.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filtrar por estatus autorización:";
            // 
            // CmbProceso
            // 
            this.CmbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProceso.FormattingEnabled = true;
            this.CmbProceso.Location = new System.Drawing.Point(6, 49);
            this.CmbProceso.Name = "CmbProceso";
            this.CmbProceso.Size = new System.Drawing.Size(217, 28);
            this.CmbProceso.TabIndex = 23;
            this.CmbProceso.SelectedIndexChanged += new System.EventHandler(this.CmbProceso_SelectedIndexChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1362, 23);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 63);
            this.BtnSalir.TabIndex = 22;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Filtrar por proceso:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1497, 23);
            this.LblTitulo.TabIndex = 16;
            this.LblTitulo.Text = "MONITOR DE OPERACIONES";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvMetas
            // 
            this.DgvMetas.AllowUserToAddRows = false;
            this.DgvMetas.AllowUserToDeleteRows = false;
            this.DgvMetas.AllowUserToResizeRows = false;
            this.DgvMetas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.proyecto,
            this.tipo_entregable,
            this.entregable,
            this.fecha_solicitud,
            this.fecha_promesa,
            this.requisitor,
            this.responsable,
            this.estatus_autorizacion,
            this.avance,
            this.fecha_terminacion});
            this.DgvMetas.ContextMenuStrip = this.MenuMetas;
            this.DgvMetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMetas.Location = new System.Drawing.Point(0, 86);
            this.DgvMetas.MultiSelect = false;
            this.DgvMetas.Name = "DgvMetas";
            this.DgvMetas.RowHeadersVisible = false;
            this.DgvMetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMetas.Size = new System.Drawing.Size(1497, 486);
            this.DgvMetas.TabIndex = 1;
            this.DgvMetas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvMetas_CellFormatting);
            // 
            // id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.Frozen = true;
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // proyecto
            // 
            this.proyecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proyecto.DefaultCellStyle = dataGridViewCellStyle3;
            this.proyecto.Frozen = true;
            this.proyecto.HeaderText = "Proyecto";
            this.proyecto.MinimumWidth = 230;
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            this.proyecto.Width = 230;
            // 
            // tipo_entregable
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tipo_entregable.DefaultCellStyle = dataGridViewCellStyle4;
            this.tipo_entregable.HeaderText = "Tipo de entregable";
            this.tipo_entregable.MinimumWidth = 150;
            this.tipo_entregable.Name = "tipo_entregable";
            this.tipo_entregable.ReadOnly = true;
            this.tipo_entregable.Width = 150;
            // 
            // entregable
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.entregable.DefaultCellStyle = dataGridViewCellStyle5;
            this.entregable.HeaderText = "Entregables";
            this.entregable.MinimumWidth = 350;
            this.entregable.Name = "entregable";
            this.entregable.ReadOnly = true;
            this.entregable.Width = 350;
            // 
            // fecha_solicitud
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_solicitud.DefaultCellStyle = dataGridViewCellStyle6;
            this.fecha_solicitud.HeaderText = "Fecha de solicitud";
            this.fecha_solicitud.MinimumWidth = 110;
            this.fecha_solicitud.Name = "fecha_solicitud";
            this.fecha_solicitud.ReadOnly = true;
            this.fecha_solicitud.Width = 110;
            // 
            // fecha_promesa
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_promesa.DefaultCellStyle = dataGridViewCellStyle7;
            this.fecha_promesa.HeaderText = "Fecha promesa";
            this.fecha_promesa.MinimumWidth = 110;
            this.fecha_promesa.Name = "fecha_promesa";
            this.fecha_promesa.ReadOnly = true;
            this.fecha_promesa.Width = 110;
            // 
            // requisitor
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requisitor.DefaultCellStyle = dataGridViewCellStyle8;
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.MinimumWidth = 120;
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            this.requisitor.Width = 120;
            // 
            // responsable
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable.DefaultCellStyle = dataGridViewCellStyle9;
            this.responsable.HeaderText = "Responsable";
            this.responsable.MinimumWidth = 120;
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            this.responsable.Width = 120;
            // 
            // estatus_autorizacion
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus_autorizacion.DefaultCellStyle = dataGridViewCellStyle10;
            this.estatus_autorizacion.HeaderText = "Estatus de autorización";
            this.estatus_autorizacion.MinimumWidth = 120;
            this.estatus_autorizacion.Name = "estatus_autorizacion";
            this.estatus_autorizacion.ReadOnly = true;
            this.estatus_autorizacion.Width = 120;
            // 
            // avance
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.avance.DefaultCellStyle = dataGridViewCellStyle11;
            this.avance.HeaderText = "Avance";
            this.avance.MinimumWidth = 90;
            this.avance.Name = "avance";
            this.avance.ReadOnly = true;
            this.avance.Width = 90;
            // 
            // fecha_terminacion
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_terminacion.DefaultCellStyle = dataGridViewCellStyle12;
            this.fecha_terminacion.HeaderText = "Fecha terminación";
            this.fecha_terminacion.MinimumWidth = 110;
            this.fecha_terminacion.Name = "fecha_terminacion";
            this.fecha_terminacion.ReadOnly = true;
            this.fecha_terminacion.Width = 110;
            // 
            // MenuMetas
            // 
            this.MenuMetas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aceptarMetaToolStripMenuItem,
            this.rechazarMetaToolStripMenuItem});
            this.MenuMetas.Name = "MenuMetas";
            this.MenuMetas.Size = new System.Drawing.Size(153, 70);
            this.MenuMetas.Opening += new System.ComponentModel.CancelEventHandler(this.MenuMetas_Opening);
            // 
            // aceptarMetaToolStripMenuItem
            // 
            this.aceptarMetaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.approve;
            this.aceptarMetaToolStripMenuItem.Name = "aceptarMetaToolStripMenuItem";
            this.aceptarMetaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aceptarMetaToolStripMenuItem.Text = "Autorizar";
            this.aceptarMetaToolStripMenuItem.Click += new System.EventHandler(this.aceptarCompromisoToolStripMenuItem_Click);
            // 
            // rechazarMetaToolStripMenuItem
            // 
            this.rechazarMetaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.reject_icon;
            this.rechazarMetaToolStripMenuItem.Name = "rechazarMetaToolStripMenuItem";
            this.rechazarMetaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rechazarMetaToolStripMenuItem.Text = "Rechazar";
            this.rechazarMetaToolStripMenuItem.Click += new System.EventHandler(this.rechazarCompromisoToolStripMenuItem_Click);
            // 
            // FrmMonitorOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1497, 572);
            this.Controls.Add(this.DgvMetas);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMonitorOperaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Monitor de operaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMonitorProceso_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MenuMantenimiento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetas)).EndInit();
            this.MenuMetas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ComboBox CmbEstatusAutorizacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbProceso;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvMetas;
        private System.Windows.Forms.ContextMenuStrip MenuMetas;
        private System.Windows.Forms.ToolStripMenuItem aceptarMetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechazarMetaToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtHasta;
        private System.Windows.Forms.DateTimePicker DtDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_entregable;
        private System.Windows.Forms.DataGridViewTextBoxColumn entregable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_solicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_autorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn avance;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_terminacion;
        private System.Windows.Forms.Button BtnMantenimientos;
        private System.Windows.Forms.ImageList ImgListMantenimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbFinalizacion;
        private System.Windows.Forms.Button BtnMaterial;
        private System.Windows.Forms.ContextMenuStrip MenuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem vehículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edificioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maquinaríaToolStripMenuItem;
    }
}
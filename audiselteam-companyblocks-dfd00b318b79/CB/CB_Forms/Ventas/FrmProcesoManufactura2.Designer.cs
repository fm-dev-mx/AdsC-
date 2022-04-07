namespace CB
{
    partial class FrmProcesoManufactura2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcesoManufactura2));
            this.DgvEntradas = new System.Windows.Forms.DataGridView();
            this.id_entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_entrada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvSalidas = new System.Windows.Forms.DataGridView();
            this.id_salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_salidas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.salidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvModelos = new System.Windows.Forms.DataGridView();
            this.id_modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_modelos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.modelos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.RtfDescripcion = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsbAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.TsbAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.TsbAlignRight = new System.Windows.Forms.ToolStripButton();
            this.TsbBold = new System.Windows.Forms.ToolStripButton();
            this.TsbItalika = new System.Windows.Forms.ToolStripButton();
            this.TsbSubrayar = new System.Windows.Forms.ToolStripButton();
            this.TsbTachar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.BtnHazAlgo = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.audiselColorSelector1 = new CB_Base.CB_Controles.AudiselColorSelector();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.BkgGuardarArchivo = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEntradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSalidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModelos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvEntradas
            // 
            this.DgvEntradas.AllowUserToAddRows = false;
            this.DgvEntradas.AllowUserToDeleteRows = false;
            this.DgvEntradas.AllowUserToResizeRows = false;
            this.DgvEntradas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvEntradas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.DgvEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEntradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_entrada,
            this.check_entrada,
            this.entrada,
            this.tipo_entrada});
            this.DgvEntradas.Location = new System.Drawing.Point(0, 23);
            this.DgvEntradas.Name = "DgvEntradas";
            this.DgvEntradas.RowHeadersVisible = false;
            this.DgvEntradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEntradas.Size = new System.Drawing.Size(282, 128);
            this.DgvEntradas.TabIndex = 0;
            this.DgvEntradas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEntradas_CellContentClick);
            // 
            // id_entrada
            // 
            this.id_entrada.HeaderText = "id";
            this.id_entrada.Name = "id_entrada";
            this.id_entrada.ReadOnly = true;
            this.id_entrada.Visible = false;
            // 
            // check_entrada
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.NullValue = false;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.check_entrada.DefaultCellStyle = dataGridViewCellStyle20;
            this.check_entrada.FalseValue = "false";
            this.check_entrada.HeaderText = "";
            this.check_entrada.IndeterminateValue = "";
            this.check_entrada.MinimumWidth = 50;
            this.check_entrada.Name = "check_entrada";
            this.check_entrada.ReadOnly = true;
            this.check_entrada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check_entrada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check_entrada.TrueValue = "true";
            this.check_entrada.Width = 50;
            // 
            // entrada
            // 
            this.entrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.entrada.DefaultCellStyle = dataGridViewCellStyle21;
            this.entrada.HeaderText = "Entradas";
            this.entrada.Name = "entrada";
            this.entrada.ReadOnly = true;
            // 
            // tipo_entrada
            // 
            this.tipo_entrada.HeaderText = "tipo";
            this.tipo_entrada.Name = "tipo_entrada";
            this.tipo_entrada.ReadOnly = true;
            this.tipo_entrada.Visible = false;
            // 
            // DgvSalidas
            // 
            this.DgvSalidas.AllowUserToAddRows = false;
            this.DgvSalidas.AllowUserToDeleteRows = false;
            this.DgvSalidas.AllowUserToResizeRows = false;
            this.DgvSalidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSalidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.DgvSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_salida,
            this.check_salidas,
            this.salidas,
            this.tipo_salida});
            this.DgvSalidas.Location = new System.Drawing.Point(285, 23);
            this.DgvSalidas.Name = "DgvSalidas";
            this.DgvSalidas.RowHeadersVisible = false;
            this.DgvSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSalidas.Size = new System.Drawing.Size(282, 128);
            this.DgvSalidas.TabIndex = 1;
            this.DgvSalidas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSalidas_CellContentClick);
            // 
            // id_salida
            // 
            this.id_salida.HeaderText = "id";
            this.id_salida.Name = "id_salida";
            this.id_salida.ReadOnly = true;
            this.id_salida.Visible = false;
            // 
            // check_salidas
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.NullValue = false;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.check_salidas.DefaultCellStyle = dataGridViewCellStyle23;
            this.check_salidas.FalseValue = "false";
            this.check_salidas.HeaderText = "";
            this.check_salidas.MinimumWidth = 50;
            this.check_salidas.Name = "check_salidas";
            this.check_salidas.ReadOnly = true;
            this.check_salidas.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check_salidas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check_salidas.TrueValue = "true";
            this.check_salidas.Width = 50;
            // 
            // salidas
            // 
            this.salidas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.salidas.DefaultCellStyle = dataGridViewCellStyle24;
            this.salidas.HeaderText = "Salidas";
            this.salidas.Name = "salidas";
            this.salidas.ReadOnly = true;
            // 
            // tipo_salida
            // 
            this.tipo_salida.HeaderText = "tipo";
            this.tipo_salida.Name = "tipo_salida";
            this.tipo_salida.ReadOnly = true;
            this.tipo_salida.Visible = false;
            // 
            // DgvModelos
            // 
            this.DgvModelos.AllowUserToAddRows = false;
            this.DgvModelos.AllowUserToDeleteRows = false;
            this.DgvModelos.AllowUserToResizeRows = false;
            this.DgvModelos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvModelos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.DgvModelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvModelos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_modelo,
            this.check_modelos,
            this.modelos});
            this.DgvModelos.Location = new System.Drawing.Point(570, 23);
            this.DgvModelos.Name = "DgvModelos";
            this.DgvModelos.RowHeadersVisible = false;
            this.DgvModelos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvModelos.Size = new System.Drawing.Size(282, 128);
            this.DgvModelos.TabIndex = 1;
            this.DgvModelos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvModelos_CellContentClick);
            // 
            // id_modelo
            // 
            this.id_modelo.HeaderText = "id";
            this.id_modelo.Name = "id_modelo";
            this.id_modelo.ReadOnly = true;
            this.id_modelo.Visible = false;
            // 
            // check_modelos
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.NullValue = false;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.check_modelos.DefaultCellStyle = dataGridViewCellStyle26;
            this.check_modelos.FalseValue = "false";
            this.check_modelos.HeaderText = "";
            this.check_modelos.MinimumWidth = 50;
            this.check_modelos.Name = "check_modelos";
            this.check_modelos.ReadOnly = true;
            this.check_modelos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check_modelos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check_modelos.TrueValue = "true";
            this.check_modelos.Width = 50;
            // 
            // modelos
            // 
            this.modelos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.modelos.DefaultCellStyle = dataGridViewCellStyle27;
            this.modelos.HeaderText = "Modelos";
            this.modelos.Name = "modelos";
            this.modelos.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(-3, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(859, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Descripción del proceso:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RtfDescripcion
            // 
            this.RtfDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RtfDescripcion.Location = new System.Drawing.Point(0, 203);
            this.RtfDescripcion.Name = "RtfDescripcion";
            this.RtfDescripcion.Size = new System.Drawing.Size(852, 155);
            this.RtfDescripcion.TabIndex = 11;
            this.RtfDescripcion.Text = "";
            this.RtfDescripcion.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbAlignLeft,
            this.TsbAlignCenter,
            this.TsbAlignRight,
            this.audiselColorSelector1,
            this.TsbBold,
            this.TsbItalika,
            this.TsbSubrayar,
            this.TsbTachar,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 175);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(287, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TsbAlignLeft
            // 
            this.TsbAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbAlignLeft.Image = global::CB_Base.Properties.Resources.align_center1;
            this.TsbAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbAlignLeft.Name = "TsbAlignLeft";
            this.TsbAlignLeft.Size = new System.Drawing.Size(23, 22);
            this.TsbAlignLeft.Text = "Align Left";
            this.TsbAlignLeft.Click += new System.EventHandler(this.TsbAlignLeft_Click);
            // 
            // TsbAlignCenter
            // 
            this.TsbAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbAlignCenter.Image = global::CB_Base.Properties.Resources.align_left;
            this.TsbAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbAlignCenter.Name = "TsbAlignCenter";
            this.TsbAlignCenter.Size = new System.Drawing.Size(23, 22);
            this.TsbAlignCenter.Text = "Align Center";
            this.TsbAlignCenter.Click += new System.EventHandler(this.TsbAlignCenter_Click);
            // 
            // TsbAlignRight
            // 
            this.TsbAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbAlignRight.Image = global::CB_Base.Properties.Resources.align_right;
            this.TsbAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbAlignRight.Name = "TsbAlignRight";
            this.TsbAlignRight.Size = new System.Drawing.Size(23, 22);
            this.TsbAlignRight.Text = "Align Right";
            this.TsbAlignRight.Click += new System.EventHandler(this.TsbAlignRight_Click);
            // 
            // TsbBold
            // 
            this.TsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsbBold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.TsbBold.Image = ((System.Drawing.Image)(resources.GetObject("TsbBold.Image")));
            this.TsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbBold.Name = "TsbBold";
            this.TsbBold.Size = new System.Drawing.Size(23, 22);
            this.TsbBold.Text = "N";
            this.TsbBold.Click += new System.EventHandler(this.TsbBold_Click);
            // 
            // TsbItalika
            // 
            this.TsbItalika.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsbItalika.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.TsbItalika.Image = ((System.Drawing.Image)(resources.GetObject("TsbItalika.Image")));
            this.TsbItalika.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbItalika.Name = "TsbItalika";
            this.TsbItalika.Size = new System.Drawing.Size(23, 22);
            this.TsbItalika.Text = "I";
            this.TsbItalika.Click += new System.EventHandler(this.TsbItalika_Click);
            // 
            // TsbSubrayar
            // 
            this.TsbSubrayar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsbSubrayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.TsbSubrayar.Image = ((System.Drawing.Image)(resources.GetObject("TsbSubrayar.Image")));
            this.TsbSubrayar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbSubrayar.Name = "TsbSubrayar";
            this.TsbSubrayar.Size = new System.Drawing.Size(23, 22);
            this.TsbSubrayar.Text = "S";
            this.TsbSubrayar.Click += new System.EventHandler(this.TsbSubrayar_Click);
            // 
            // TsbTachar
            // 
            this.TsbTachar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsbTachar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout);
            this.TsbTachar.Image = ((System.Drawing.Image)(resources.GetObject("TsbTachar.Image")));
            this.TsbTachar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbTachar.Name = "TsbTachar";
            this.TsbTachar.Size = new System.Drawing.Size(30, 22);
            this.TsbTachar.Text = "abc";
            this.TsbTachar.Click += new System.EventHandler(this.TsbTachar_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::CB_Base.Properties.Resources.bullets_icon_16px;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CB_Base.Properties.Resources.Zoom_In_icon_16px;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::CB_Base.Properties.Resources.Zoom_Out_icon_16px;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.BtnHazAlgo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 356);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 53);
            this.panel1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "PDF ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(590, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 53);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "    Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnHazAlgo
            // 
            this.BtnHazAlgo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnHazAlgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHazAlgo.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnHazAlgo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHazAlgo.Location = new System.Drawing.Point(723, 0);
            this.BtnHazAlgo.Name = "BtnHazAlgo";
            this.BtnHazAlgo.Size = new System.Drawing.Size(133, 53);
            this.BtnHazAlgo.TabIndex = 1;
            this.BtnHazAlgo.Text = "    Guardar";
            this.BtnHazAlgo.UseVisualStyleBackColor = true;
            this.BtnHazAlgo.Click += new System.EventHandler(this.BtnHazAlgo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblEstatus,
            this.Progress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 31);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(590, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblEstatus
            // 
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(140, 17);
            this.LblEstatus.Text = "Guardando documento...";
            // 
            // Progress
            // 
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 16);
            // 
            // audiselColorSelector1
            // 
            this.audiselColorSelector1.Color = System.Drawing.Color.Black;
            this.audiselColorSelector1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audiselColorSelector1.Image = global::CB_Base.Properties.Resources.back;
            this.audiselColorSelector1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audiselColorSelector1.Name = "audiselColorSelector1";
            this.audiselColorSelector1.Size = new System.Drawing.Size(32, 22);
            this.audiselColorSelector1.Text = "audiselColorSelector1";
            this.audiselColorSelector1.ButtonClick += new System.EventHandler(this.audiselColorSelector1_ButtonClick);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(856, 23);
            this.audiselTituloForm1.TabIndex = 7;
            this.audiselTituloForm1.Text = "PROCESO DE MANUFACTURA";
            // 
            // BkgGuardarArchivo
            // 
            this.BkgGuardarArchivo.WorkerReportsProgress = true;
            this.BkgGuardarArchivo.WorkerSupportsCancellation = true;
            this.BkgGuardarArchivo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgGuardarArchivo_DoWork);
            this.BkgGuardarArchivo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgGuardarArchivo_ProgressChanged);
            this.BkgGuardarArchivo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgGuardarArchivo_RunWorkerCompleted);
            // 
            // FrmProcesoManufactura2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 409);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.RtfDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvModelos);
            this.Controls.Add(this.DgvSalidas);
            this.Controls.Add(this.DgvEntradas);
            this.Controls.Add(this.audiselTituloForm1);
            this.Name = "FrmProcesoManufactura2";
            this.Text = "FrmProcesoManufactura2";
            this.Load += new System.EventHandler(this.FrmProcesoManufactura2_Load);
            this.Resize += new System.EventHandler(this.FrmProcesoManufactura2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEntradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSalidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModelos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.DataGridView DgvEntradas;
        private System.Windows.Forms.DataGridView DgvSalidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_salida;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_salidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn salidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_salida;
        private System.Windows.Forms.DataGridView DgvModelos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_modelo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_modelos;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_entrada;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_entrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RtfDescripcion;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsbAlignLeft;
        private System.Windows.Forms.ToolStripButton TsbAlignCenter;
        private System.Windows.Forms.ToolStripButton TsbAlignRight;
        private CB_Base.CB_Controles.AudiselColorSelector audiselColorSelector1;
        private System.Windows.Forms.ToolStripButton TsbBold;
        private System.Windows.Forms.ToolStripButton TsbItalika;
        private System.Windows.Forms.ToolStripButton TsbSubrayar;
        private System.Windows.Forms.ToolStripButton TsbTachar;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button BtnHazAlgo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblEstatus;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private System.ComponentModel.BackgroundWorker BkgGuardarArchivo;
    }
}
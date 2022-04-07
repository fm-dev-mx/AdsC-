namespace CB
{
    partial class FrmAltaAlmacenDesdePO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownPO = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DgvPartidasPO = new System.Windows.Forms.DataGridView();
            this.numero_de_partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDEN_TRABAJO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.DgvRequisicionesPO = new System.Windows.Forms.DataGridView();
            this.requisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadRecibida1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recibido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.MenuEditarCantidad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarCantidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPartidasPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequisicionesPO)).BeginInit();
            this.MenuEditarCantidad.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.BtnBuscar);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDownPO);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1272, 741);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 0;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Location = new System.Drawing.Point(283, 34);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(140, 29);
            this.BtnBuscar.TabIndex = 21;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "# PO";
            // 
            // numericUpDownPO
            // 
            this.numericUpDownPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.numericUpDownPO.Location = new System.Drawing.Point(61, 34);
            this.numericUpDownPO.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownPO.Name = "numericUpDownPO";
            this.numericUpDownPO.Size = new System.Drawing.Size(216, 29);
            this.numericUpDownPO.TabIndex = 19;
            this.numericUpDownPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownPO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownPO_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1272, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "RECIBIR MATERIAL DESDE ORDEN DE COMPRA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.DgvPartidasPO);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1272, 657);
            this.splitContainer2.SplitterDistance = 423;
            this.splitContainer2.TabIndex = 0;
            // 
            // DgvPartidasPO
            // 
            this.DgvPartidasPO.AllowUserToAddRows = false;
            this.DgvPartidasPO.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.DgvPartidasPO.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DgvPartidasPO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvPartidasPO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPartidasPO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.DgvPartidasPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPartidasPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero_de_partida,
            this.numero_parte,
            this.ORDEN_TRABAJO});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPartidasPO.DefaultCellStyle = dataGridViewCellStyle21;
            this.DgvPartidasPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPartidasPO.Location = new System.Drawing.Point(0, 23);
            this.DgvPartidasPO.MultiSelect = false;
            this.DgvPartidasPO.Name = "DgvPartidasPO";
            this.DgvPartidasPO.ReadOnly = true;
            this.DgvPartidasPO.RowHeadersVisible = false;
            this.DgvPartidasPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPartidasPO.Size = new System.Drawing.Size(423, 634);
            this.DgvPartidasPO.TabIndex = 20;
            this.DgvPartidasPO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPartidasPO_CellContentClick);
            // 
            // numero_de_partida
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numero_de_partida.DefaultCellStyle = dataGridViewCellStyle18;
            this.numero_de_partida.HeaderText = "Numero";
            this.numero_de_partida.Name = "numero_de_partida";
            this.numero_de_partida.ReadOnly = true;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle19;
            this.numero_parte.HeaderText = "Numero de Parte";
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            this.numero_parte.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ORDEN_TRABAJO
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ORDEN_TRABAJO.DefaultCellStyle = dataGridViewCellStyle20;
            this.ORDEN_TRABAJO.HeaderText = "Cantidad";
            this.ORDEN_TRABAJO.Name = "ORDEN_TRABAJO";
            this.ORDEN_TRABAJO.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "PARTIDAS DE LA PO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.DgvRequisicionesPO);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.BtnSalir);
            this.splitContainer3.Panel2.Controls.Add(this.BtnAgregar);
            this.splitContainer3.Size = new System.Drawing.Size(845, 657);
            this.splitContainer3.SplitterDistance = 645;
            this.splitContainer3.TabIndex = 0;
            // 
            // DgvRequisicionesPO
            // 
            this.DgvRequisicionesPO.AllowUserToAddRows = false;
            this.DgvRequisicionesPO.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            this.DgvRequisicionesPO.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.DgvRequisicionesPO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRequisicionesPO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.DgvRequisicionesPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRequisicionesPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requisicion,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.cantidad,
            this.cantidadRecibida1,
            this.estatus_almacen,
            this.recibido});
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvRequisicionesPO.DefaultCellStyle = dataGridViewCellStyle30;
            this.DgvRequisicionesPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvRequisicionesPO.Location = new System.Drawing.Point(0, 23);
            this.DgvRequisicionesPO.MultiSelect = false;
            this.DgvRequisicionesPO.Name = "DgvRequisicionesPO";
            this.DgvRequisicionesPO.RowHeadersVisible = false;
            this.DgvRequisicionesPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRequisicionesPO.Size = new System.Drawing.Size(645, 634);
            this.DgvRequisicionesPO.TabIndex = 20;
            this.DgvRequisicionesPO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequisicionesPO_CellClick);
            this.DgvRequisicionesPO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequisicionesPO_CellDoubleClick);
            this.DgvRequisicionesPO.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequisicionesPO_CellEndEdit);
            this.DgvRequisicionesPO.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvRequisicionesPO_CellMouseDown);
            this.DgvRequisicionesPO.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvRequisicionesPO_EditingControlShowing);
            // 
            // requisicion
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.requisicion.DefaultCellStyle = dataGridViewCellStyle24;
            this.requisicion.HeaderText = "# Requisición";
            this.requisicion.Name = "requisicion";
            this.requisicion.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn2.HeaderText = "Requisitor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewTextBoxColumn3.HeaderText = "Proyecto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle27;
            this.cantidad.HeaderText = "Cantidad requerida";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // cantidadRecibida1
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidadRecibida1.DefaultCellStyle = dataGridViewCellStyle28;
            this.cantidadRecibida1.HeaderText = "Cantidad recibida";
            this.cantidadRecibida1.Name = "cantidadRecibida1";
            this.cantidadRecibida1.ReadOnly = true;
            // 
            // estatus_almacen
            // 
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_almacen.DefaultCellStyle = dataGridViewCellStyle29;
            this.estatus_almacen.HeaderText = "Estatus almacén";
            this.estatus_almacen.Name = "estatus_almacen";
            this.estatus_almacen.ReadOnly = true;
            // 
            // recibido
            // 
            this.recibido.HeaderText = "Recibido";
            this.recibido.Name = "recibido";
            this.recibido.ReadOnly = true;
            this.recibido.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(645, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "DESGLOSE DE REQUISICIONES";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 64);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(196, 64);
            this.BtnSalir.TabIndex = 57;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(0, 0);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(196, 64);
            this.BtnAgregar.TabIndex = 56;
            this.BtnAgregar.Text = "      Confirmar         recepción";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // MenuEditarCantidad
            // 
            this.MenuEditarCantidad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarCantidadToolStripMenuItem});
            this.MenuEditarCantidad.Name = "MenuEditarCantidad";
            this.MenuEditarCantidad.Size = new System.Drawing.Size(154, 48);
            this.MenuEditarCantidad.Opening += new System.ComponentModel.CancelEventHandler(this.MenuEditarCantidad_Opening);
            // 
            // editarCantidadToolStripMenuItem
            // 
            this.editarCantidadToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarCantidadToolStripMenuItem.Name = "editarCantidadToolStripMenuItem";
            this.editarCantidadToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.editarCantidadToolStripMenuItem.Text = "Editar cantidad";
            this.editarCantidadToolStripMenuItem.Click += new System.EventHandler(this.editarCantidadToolStripMenuItem_Click);
            // 
            // FrmAltaAlmacenDesdePO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 741);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAltaAlmacenDesdePO";
            this.Text = "Recibir material desde orden de compra";
            this.Load += new System.EventHandler(this.FrmAltaAlmacenDesdePO_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPO)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPartidasPO)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequisicionesPO)).EndInit();
            this.MenuEditarCantidad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownPO;
        private System.Windows.Forms.DataGridView DgvPartidasPO;
        private System.Windows.Forms.DataGridView DgvRequisicionesPO;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_de_partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDEN_TRABAJO;
        private System.Windows.Forms.ContextMenuStrip MenuEditarCantidad;
        private System.Windows.Forms.ToolStripMenuItem editarCantidadToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadRecibida1;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_almacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn recibido;
    }
}
namespace CB
{
    partial class FrmEstimarTiempoFabricacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblMaterial = new System.Windows.Forms.Label();
            this.NumProceso = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProceso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvOperaciones = new System.Windows.Forms.DataGridView();
            this.operacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cantidad_operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustarTiemposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaOperaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.LblTiempoEstimado = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CheckProduccionSerie = new System.Windows.Forms.CheckBox();
            this.LblTiempoEstimadoTotal = new System.Windows.Forms.Label();
            this.CmbPresentacion = new System.Windows.Forms.ComboBox();
            this.CmbMaterial = new System.Windows.Forms.ComboBox();
            this.CmbDimensiones = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbComplejidad = new System.Windows.Forms.ComboBox();
            this.LblComplejidad = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.PicPlano = new System.Windows.Forms.PictureBox();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.BkgDescargarPlano = new System.ComponentModel.BackgroundWorker();
            this.MenuFactoresProceso = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajustarFactoresDelProcesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.NumProceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOperaciones)).BeginInit();
            this.MenuOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).BeginInit();
            this.MenuFactoresProceso.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblMaterial
            // 
            this.LblMaterial.BackColor = System.Drawing.Color.Black;
            this.LblMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMaterial.ForeColor = System.Drawing.Color.White;
            this.LblMaterial.Location = new System.Drawing.Point(0, 0);
            this.LblMaterial.Name = "LblMaterial";
            this.LblMaterial.Size = new System.Drawing.Size(1011, 23);
            this.LblMaterial.TabIndex = 7;
            this.LblMaterial.Text = "ESTIMAR TIEMPO DE FABRICACION";
            this.LblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblMaterial.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblMaterial_MouseDown);
            // 
            // NumProceso
            // 
            this.NumProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumProceso.Location = new System.Drawing.Point(17, 28);
            this.NumProceso.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.NumProceso.Name = "NumProceso";
            this.NumProceso.Size = new System.Drawing.Size(93, 26);
            this.NumProceso.TabIndex = 16;
            this.NumProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumProceso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumProceso_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "ID:";
            // 
            // TxtProceso
            // 
            this.TxtProceso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtProceso.ContextMenuStrip = this.MenuFactoresProceso;
            this.TxtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProceso.Location = new System.Drawing.Point(116, 28);
            this.TxtProceso.Name = "TxtProceso";
            this.TxtProceso.ReadOnly = true;
            this.TxtProceso.Size = new System.Drawing.Size(298, 29);
            this.TxtProceso.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Tipo de proceso:";
            // 
            // DgvOperaciones
            // 
            this.DgvOperaciones.AllowUserToDeleteRows = false;
            this.DgvOperaciones.AllowUserToResizeRows = false;
            this.DgvOperaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvOperaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.operacion,
            this.cantidad_operacion});
            this.DgvOperaciones.ContextMenuStrip = this.MenuOpciones;
            this.DgvOperaciones.Location = new System.Drawing.Point(15, 227);
            this.DgvOperaciones.Name = "DgvOperaciones";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvOperaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvOperaciones.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvOperaciones.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvOperaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvOperaciones.Size = new System.Drawing.Size(399, 302);
            this.DgvOperaciones.TabIndex = 47;
            this.DgvOperaciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOperaciones_CellValueChanged);
            // 
            // operacion
            // 
            this.operacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.operacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.operacion.HeaderText = "Operación";
            this.operacion.Items.AddRange(new object[] {
            "CAMBIO DE HERRAMIENTA",
            "BARRENO M6",
            "BARRENO M4",
            "RANURADO"});
            this.operacion.Name = "operacion";
            this.operacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cantidad_operacion
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad_operacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantidad_operacion.HeaderText = "Cantidad";
            this.cantidad_operacion.MinimumWidth = 50;
            this.cantidad_operacion.Name = "cantidad_operacion";
            this.cantidad_operacion.ReadOnly = true;
            this.cantidad_operacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cantidad_operacion.Width = 60;
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem,
            this.ajustarTiemposToolStripMenuItem,
            this.nuevaOperaciToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(165, 70);
            this.MenuOpciones.Opening += new System.ComponentModel.CancelEventHandler(this.MenuOpciones_Opening);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // ajustarTiemposToolStripMenuItem
            // 
            this.ajustarTiemposToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.ajustarTiemposToolStripMenuItem.Name = "ajustarTiemposToolStripMenuItem";
            this.ajustarTiemposToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.ajustarTiemposToolStripMenuItem.Text = "Ajustar tiempos";
            this.ajustarTiemposToolStripMenuItem.Click += new System.EventHandler(this.ajustarTiemposToolStripMenuItem_Click);
            // 
            // nuevaOperaciToolStripMenuItem
            // 
            this.nuevaOperaciToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevaOperaciToolStripMenuItem.Name = "nuevaOperaciToolStripMenuItem";
            this.nuevaOperaciToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.nuevaOperaciToolStripMenuItem.Text = "Nueva operación";
            this.nuevaOperaciToolStripMenuItem.Click += new System.EventHandler(this.nuevaOperaciToolStripMenuItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Lista de operaciones requeridas:";
            // 
            // LblTiempoEstimado
            // 
            this.LblTiempoEstimado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTiempoEstimado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTiempoEstimado.Location = new System.Drawing.Point(148, 537);
            this.LblTiempoEstimado.Name = "LblTiempoEstimado";
            this.LblTiempoEstimado.Size = new System.Drawing.Size(263, 22);
            this.LblTiempoEstimado.TabIndex = 51;
            this.LblTiempoEstimado.Text = "30 días 10 horas 30 minutos 00 segundos";
            this.LblTiempoEstimado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CheckProduccionSerie);
            this.splitContainer1.Panel1.Controls.Add(this.LblTiempoEstimadoTotal);
            this.splitContainer1.Panel1.Controls.Add(this.LblTiempoEstimado);
            this.splitContainer1.Panel1.Controls.Add(this.CmbPresentacion);
            this.splitContainer1.Panel1.Controls.Add(this.CmbMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.CmbDimensiones);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.CmbComplejidad);
            this.splitContainer1.Panel1.Controls.Add(this.LblComplejidad);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.DgvOperaciones);
            this.splitContainer1.Panel1.Controls.Add(this.NumProceso);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.TxtProceso);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PicPlano);
            this.splitContainer1.Panel2.Controls.Add(this.TxtEstatus);
            this.splitContainer1.Panel2.Controls.Add(this.Progreso);
            this.splitContainer1.Size = new System.Drawing.Size(1011, 726);
            this.splitContainer1.SplitterDistance = 432;
            this.splitContainer1.TabIndex = 52;
            // 
            // CheckProduccionSerie
            // 
            this.CheckProduccionSerie.AutoSize = true;
            this.CheckProduccionSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckProduccionSerie.Location = new System.Drawing.Point(14, 603);
            this.CheckProduccionSerie.Name = "CheckProduccionSerie";
            this.CheckProduccionSerie.Size = new System.Drawing.Size(146, 20);
            this.CheckProduccionSerie.TabIndex = 66;
            this.CheckProduccionSerie.Text = "Producción en serie";
            this.CheckProduccionSerie.UseVisualStyleBackColor = true;
            this.CheckProduccionSerie.CheckedChanged += new System.EventHandler(this.CheckProduccionSerie_CheckedChanged);
            // 
            // LblTiempoEstimadoTotal
            // 
            this.LblTiempoEstimadoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTiempoEstimadoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTiempoEstimadoTotal.Location = new System.Drawing.Point(148, 563);
            this.LblTiempoEstimadoTotal.Name = "LblTiempoEstimadoTotal";
            this.LblTiempoEstimadoTotal.Size = new System.Drawing.Size(263, 22);
            this.LblTiempoEstimadoTotal.TabIndex = 53;
            this.LblTiempoEstimadoTotal.Text = "30 días 10 horas 15 minutos 00 segundos";
            this.LblTiempoEstimadoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbPresentacion
            // 
            this.CmbPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPresentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPresentacion.FormattingEnabled = true;
            this.CmbPresentacion.Items.AddRange(new object[] {
            "PLACA",
            "PRISMA"});
            this.CmbPresentacion.Location = new System.Drawing.Point(15, 176);
            this.CmbPresentacion.Name = "CmbPresentacion";
            this.CmbPresentacion.Size = new System.Drawing.Size(259, 32);
            this.CmbPresentacion.TabIndex = 65;
            this.CmbPresentacion.SelectedIndexChanged += new System.EventHandler(this.CmbPresentacion_SelectedIndexChanged);
            // 
            // CmbMaterial
            // 
            this.CmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMaterial.FormattingEnabled = true;
            this.CmbMaterial.Items.AddRange(new object[] {
            "ACERO",
            "ALUMINIO",
            "PLASTICO"});
            this.CmbMaterial.Location = new System.Drawing.Point(15, 125);
            this.CmbMaterial.Name = "CmbMaterial";
            this.CmbMaterial.Size = new System.Drawing.Size(397, 32);
            this.CmbMaterial.TabIndex = 64;
            this.CmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            // 
            // CmbDimensiones
            // 
            this.CmbDimensiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDimensiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDimensiones.FormattingEnabled = true;
            this.CmbDimensiones.Items.AddRange(new object[] {
            "CHICA",
            "MEDIANA",
            "GRANDE"});
            this.CmbDimensiones.Location = new System.Drawing.Point(282, 176);
            this.CmbDimensiones.Name = "CmbDimensiones";
            this.CmbDimensiones.Size = new System.Drawing.Size(130, 32);
            this.CmbDimensiones.TabIndex = 63;
            this.CmbDimensiones.SelectedIndexChanged += new System.EventHandler(this.CmbDimensiones_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(282, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 62;
            this.label11.Text = "Dimensiones:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(12, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Presentación:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Material:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 563);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 22);
            this.label8.TabIndex = 57;
            this.label8.Text = "Tiempo total: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 537);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 22);
            this.label2.TabIndex = 56;
            this.label2.Text = "Tiempo por pieza:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbComplejidad
            // 
            this.CmbComplejidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComplejidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbComplejidad.FormattingEnabled = true;
            this.CmbComplejidad.Items.AddRange(new object[] {
            "NADA COMPLEJA",
            "POCO COMPLEJA",
            "COMPLEJA",
            "MUY COMPLEJA"});
            this.CmbComplejidad.Location = new System.Drawing.Point(15, 74);
            this.CmbComplejidad.Name = "CmbComplejidad";
            this.CmbComplejidad.Size = new System.Drawing.Size(397, 32);
            this.CmbComplejidad.TabIndex = 55;
            this.CmbComplejidad.SelectedIndexChanged += new System.EventHandler(this.CmbComplejidad_SelectedIndexChanged);
            // 
            // LblComplejidad
            // 
            this.LblComplejidad.AutoSize = true;
            this.LblComplejidad.Location = new System.Drawing.Point(16, 58);
            this.LblComplejidad.Name = "LblComplejidad";
            this.LblComplejidad.Size = new System.Drawing.Size(67, 13);
            this.LblComplejidad.TabIndex = 54;
            this.LblComplejidad.Text = "Complejidad:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnRegistrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 661);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 65);
            this.panel1.TabIndex = 52;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(18, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 53);
            this.BtnCancelar.TabIndex = 49;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Enabled = false;
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(254, 0);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(160, 53);
            this.BtnRegistrar.TabIndex = 50;
            this.BtnRegistrar.Text = "     Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // PicPlano
            // 
            this.PicPlano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicPlano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPlano.Location = new System.Drawing.Point(0, 0);
            this.PicPlano.Name = "PicPlano";
            this.PicPlano.Size = new System.Drawing.Size(575, 674);
            this.PicPlano.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicPlano.TabIndex = 0;
            this.PicPlano.TabStop = false;
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtEstatus.ForeColor = System.Drawing.Color.Lime;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 674);
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(575, 29);
            this.TxtEstatus.TabIndex = 15;
            this.TxtEstatus.Text = "Estatus...";
            this.TxtEstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 703);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(575, 23);
            this.Progreso.TabIndex = 16;
            // 
            // BkgDescargarPlano
            // 
            this.BkgDescargarPlano.WorkerReportsProgress = true;
            this.BkgDescargarPlano.WorkerSupportsCancellation = true;
            this.BkgDescargarPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPlano_DoWork);
            this.BkgDescargarPlano.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarPlano_ProgressChanged);
            this.BkgDescargarPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarPlano_RunWorkerCompleted);
            // 
            // MenuFactoresProceso
            // 
            this.MenuFactoresProceso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajustarFactoresDelProcesoToolStripMenuItem});
            this.MenuFactoresProceso.Name = "MenuFactoresProceso";
            this.MenuFactoresProceso.Size = new System.Drawing.Size(221, 26);
            // 
            // ajustarFactoresDelProcesoToolStripMenuItem
            // 
            this.ajustarFactoresDelProcesoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.produccion_48;
            this.ajustarFactoresDelProcesoToolStripMenuItem.Name = "ajustarFactoresDelProcesoToolStripMenuItem";
            this.ajustarFactoresDelProcesoToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.ajustarFactoresDelProcesoToolStripMenuItem.Text = "Ajustar factores del proceso";
            this.ajustarFactoresDelProcesoToolStripMenuItem.Click += new System.EventHandler(this.ajustarFactoresDelProcesoToolStripMenuItem_Click);
            // 
            // FrmEstimarTiempoFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 749);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmEstimarTiempoFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estimar tiempo de fabricación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmActualizarProcesoFabricacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumProceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOperaciones)).EndInit();
            this.MenuOpciones.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).EndInit();
            this.MenuFactoresProceso.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblMaterial;
        private System.Windows.Forms.NumericUpDown NumProceso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtProceso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvOperaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label LblTiempoEstimado;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.PictureBox PicPlano;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlano;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_operacion;
        private System.Windows.Forms.ComboBox CmbComplejidad;
        private System.Windows.Forms.Label LblComplejidad;
        private System.Windows.Forms.Label LblTiempoEstimadoTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbDimensiones;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbPresentacion;
        private System.Windows.Forms.ComboBox CmbMaterial;
        private System.Windows.Forms.ToolStripMenuItem ajustarTiemposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaOperaciToolStripMenuItem;
        private System.Windows.Forms.CheckBox CheckProduccionSerie;
        private System.Windows.Forms.ContextMenuStrip MenuFactoresProceso;
        private System.Windows.Forms.ToolStripMenuItem ajustarFactoresDelProcesoToolStripMenuItem;
    }
}
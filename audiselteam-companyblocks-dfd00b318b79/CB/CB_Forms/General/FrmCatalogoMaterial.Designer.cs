namespace CB
{
    partial class FrmCatalogoMaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgvMaterial = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalles = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.BtnElegirImagen = new System.Windows.Forms.Button();
            this.ImagenMaterial = new System.Windows.Forms.PictureBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.BtnOpcionesMaterial = new System.Windows.Forms.Button();
            this.MenuOpcionesMaterial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verAccesoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verDetallesDeCotizacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verEstadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblInfo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtEnlace = new System.Windows.Forms.TextBox();
            this.LblEtiquetaPiezasPorPaquete = new System.Windows.Forms.Label();
            this.NumPiezasPaquete = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbUnidades = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblNumeroParte = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TxtFiltro = new System.Windows.Forms.TextBox();
            this.BtnRegistrarMaterial = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbFiltroFabricante = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbFiltroSubcategoria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbFiltroCategoria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).BeginInit();
            this.Detalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.MenuOpcionesMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPiezasPaquete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvMaterial);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Detalles);
            this.splitContainer1.Panel2.Controls.Add(this.LblNumeroParte);
            this.splitContainer1.Size = new System.Drawing.Size(1337, 584);
            this.splitContainer1.SplitterDistance = 283;
            this.splitContainer1.TabIndex = 0;
            // 
            // DgvMaterial
            // 
            this.DgvMaterial.AllowUserToAddRows = false;
            this.DgvMaterial.AllowUserToDeleteRows = false;
            this.DgvMaterial.AllowUserToResizeRows = false;
            this.DgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.pn,
            this.fabricante});
            this.DgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMaterial.Location = new System.Drawing.Point(0, 0);
            this.DgvMaterial.Name = "DgvMaterial";
            this.DgvMaterial.ReadOnly = true;
            this.DgvMaterial.RowHeadersVisible = false;
            this.DgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMaterial.Size = new System.Drawing.Size(283, 584);
            this.DgvMaterial.TabIndex = 0;
            this.DgvMaterial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMaterial_CellClick);
            this.DgvMaterial.SelectionChanged += new System.EventHandler(this.DgvMaterial_SelectionChanged);
            // 
            // id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 60;
            // 
            // pn
            // 
            this.pn.HeaderText = "Número de parte";
            this.pn.Name = "pn";
            this.pn.ReadOnly = true;
            this.pn.Width = 140;
            // 
            // fabricante
            // 
            this.fabricante.HeaderText = "Fabricante";
            this.fabricante.Name = "fabricante";
            this.fabricante.ReadOnly = true;
            this.fabricante.Width = 140;
            // 
            // Detalles
            // 
            this.Detalles.Controls.Add(this.splitContainer3);
            this.Detalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Detalles.Location = new System.Drawing.Point(0, 23);
            this.Detalles.Name = "Detalles";
            this.Detalles.Size = new System.Drawing.Size(1050, 561);
            this.Detalles.TabIndex = 5;
            this.Detalles.TabStop = false;
            this.Detalles.UseCompatibleTextRendering = true;
            this.Detalles.Visible = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.BtnElegirImagen);
            this.splitContainer3.Panel1.Controls.Add(this.ImagenMaterial);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1044, 542);
            this.splitContainer3.SplitterDistance = 206;
            this.splitContainer3.TabIndex = 4;
            // 
            // BtnElegirImagen
            // 
            this.BtnElegirImagen.Enabled = false;
            this.BtnElegirImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElegirImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnElegirImagen.Location = new System.Drawing.Point(4, 206);
            this.BtnElegirImagen.Name = "BtnElegirImagen";
            this.BtnElegirImagen.Size = new System.Drawing.Size(126, 33);
            this.BtnElegirImagen.TabIndex = 15;
            this.BtnElegirImagen.Text = "Elegir imagen";
            this.BtnElegirImagen.UseVisualStyleBackColor = true;
            // 
            // ImagenMaterial
            // 
            this.ImagenMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImagenMaterial.Image = global::CB_Base.Properties.Resources.manu_prod;
            this.ImagenMaterial.Location = new System.Drawing.Point(0, 0);
            this.ImagenMaterial.Name = "ImagenMaterial";
            this.ImagenMaterial.Size = new System.Drawing.Size(206, 203);
            this.ImagenMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenMaterial.TabIndex = 0;
            this.ImagenMaterial.TabStop = false;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.BtnOpcionesMaterial);
            this.splitContainer4.Panel1.Controls.Add(this.LblInfo);
            this.splitContainer4.Panel1.Controls.Add(this.label8);
            this.splitContainer4.Panel1.Controls.Add(this.TxtEnlace);
            this.splitContainer4.Panel1.Controls.Add(this.LblEtiquetaPiezasPorPaquete);
            this.splitContainer4.Panel1.Controls.Add(this.NumPiezasPaquete);
            this.splitContainer4.Panel1.Controls.Add(this.label6);
            this.splitContainer4.Panel1.Controls.Add(this.label4);
            this.splitContainer4.Panel1.Controls.Add(this.CmbUnidades);
            this.splitContainer4.Panel1.Controls.Add(this.label5);
            this.splitContainer4.Panel1.Controls.Add(this.TxtFabricante);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            this.splitContainer4.Panel1.Controls.Add(this.TxtNumeroParte);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.TxtDescripcion);
            this.splitContainer4.Size = new System.Drawing.Size(834, 542);
            this.splitContainer4.SplitterDistance = 240;
            this.splitContainer4.TabIndex = 5;
            // 
            // BtnOpcionesMaterial
            // 
            this.BtnOpcionesMaterial.ContextMenuStrip = this.MenuOpcionesMaterial;
            this.BtnOpcionesMaterial.Enabled = false;
            this.BtnOpcionesMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpcionesMaterial.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnOpcionesMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpcionesMaterial.Location = new System.Drawing.Point(0, 0);
            this.BtnOpcionesMaterial.Name = "BtnOpcionesMaterial";
            this.BtnOpcionesMaterial.Size = new System.Drawing.Size(115, 45);
            this.BtnOpcionesMaterial.TabIndex = 29;
            this.BtnOpcionesMaterial.Text = "Opciones";
            this.BtnOpcionesMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpcionesMaterial.UseVisualStyleBackColor = true;
            this.BtnOpcionesMaterial.Click += new System.EventHandler(this.BtnOpcionesMaterial_Click);
            // 
            // MenuOpcionesMaterial
            // 
            this.MenuOpcionesMaterial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.verAccesoriosToolStripMenuItem,
            this.verDetallesDeCotizacionesToolStripMenuItem,
            this.solidosToolStripMenuItem,
            this.verEstadisticasToolStripMenuItem});
            this.MenuOpcionesMaterial.Name = "MenuOpcionesMaterial";
            this.MenuOpcionesMaterial.Size = new System.Drawing.Size(159, 136);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // verAccesoriosToolStripMenuItem
            // 
            this.verAccesoriosToolStripMenuItem.Enabled = false;
            this.verAccesoriosToolStripMenuItem.Image = global::CB_Base.Properties.Resources.arrows;
            this.verAccesoriosToolStripMenuItem.Name = "verAccesoriosToolStripMenuItem";
            this.verAccesoriosToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.verAccesoriosToolStripMenuItem.Text = "Accesorios";
            this.verAccesoriosToolStripMenuItem.Click += new System.EventHandler(this.verAccesoriosToolStripMenuItem_Click);
            // 
            // verDetallesDeCotizacionesToolStripMenuItem
            // 
            this.verDetallesDeCotizacionesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.details;
            this.verDetallesDeCotizacionesToolStripMenuItem.Name = "verDetallesDeCotizacionesToolStripMenuItem";
            this.verDetallesDeCotizacionesToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.verDetallesDeCotizacionesToolStripMenuItem.Text = "Ver cotizaciones";
            this.verDetallesDeCotizacionesToolStripMenuItem.Click += new System.EventHandler(this.verDetallesDeCotizacionesToolStripMenuItem_Click);
            // 
            // solidosToolStripMenuItem
            // 
            this.solidosToolStripMenuItem.Image = global::CB_Base.Properties.Resources.solidworks;
            this.solidosToolStripMenuItem.Name = "solidosToolStripMenuItem";
            this.solidosToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.solidosToolStripMenuItem.Text = "Sólidos";
            this.solidosToolStripMenuItem.Click += new System.EventHandler(this.solidosToolStripMenuItem_Click);
            // 
            // verEstadisticasToolStripMenuItem
            // 
            this.verEstadisticasToolStripMenuItem.Image = global::CB_Base.Properties.Resources.polls_48;
            this.verEstadisticasToolStripMenuItem.Name = "verEstadisticasToolStripMenuItem";
            this.verEstadisticasToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.verEstadisticasToolStripMenuItem.Text = "Ver estadisticas";
            this.verEstadisticasToolStripMenuItem.Click += new System.EventHandler(this.verEstadisticasToolStripMenuItem_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.ForeColor = System.Drawing.Color.Red;
            this.LblInfo.Location = new System.Drawing.Point(121, 0);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(387, 45);
            this.LblInfo.TabIndex = 28;
            this.LblInfo.Text = "Info";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Enlace de información:";
            // 
            // TxtEnlace
            // 
            this.TxtEnlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEnlace.Location = new System.Drawing.Point(13, 181);
            this.TxtEnlace.Name = "TxtEnlace";
            this.TxtEnlace.ReadOnly = true;
            this.TxtEnlace.Size = new System.Drawing.Size(707, 29);
            this.TxtEnlace.TabIndex = 15;
            // 
            // LblEtiquetaPiezasPorPaquete
            // 
            this.LblEtiquetaPiezasPorPaquete.AutoSize = true;
            this.LblEtiquetaPiezasPorPaquete.Location = new System.Drawing.Point(267, 112);
            this.LblEtiquetaPiezasPorPaquete.Name = "LblEtiquetaPiezasPorPaquete";
            this.LblEtiquetaPiezasPorPaquete.Size = new System.Drawing.Size(105, 13);
            this.LblEtiquetaPiezasPorPaquete.TabIndex = 13;
            this.LblEtiquetaPiezasPorPaquete.Text = "Piezas por paquete *";
            // 
            // NumPiezasPaquete
            // 
            this.NumPiezasPaquete.Enabled = false;
            this.NumPiezasPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPiezasPaquete.Location = new System.Drawing.Point(270, 127);
            this.NumPiezasPaquete.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumPiezasPaquete.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPiezasPaquete.Name = "NumPiezasPaquete";
            this.NumPiezasPaquete.ReadOnly = true;
            this.NumPiezasPaquete.Size = new System.Drawing.Size(86, 29);
            this.NumPiezasPaquete.TabIndex = 12;
            this.NumPiezasPaquete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPiezasPaquete.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo de venta *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fabricante *";
            // 
            // CmbUnidades
            // 
            this.CmbUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUnidades.Enabled = false;
            this.CmbUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUnidades.FormattingEnabled = true;
            this.CmbUnidades.Items.AddRange(new object[] {
            "POR PIEZA",
            "POR PAQUETE"});
            this.CmbUnidades.Location = new System.Drawing.Point(13, 128);
            this.CmbUnidades.Name = "CmbUnidades";
            this.CmbUnidades.Size = new System.Drawing.Size(238, 28);
            this.CmbUnidades.TabIndex = 10;
            this.CmbUnidades.SelectedIndexChanged += new System.EventHandler(this.CmbUnidades_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Descripción *";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(377, 74);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(343, 29);
            this.TxtFabricante.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Número de parte *";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(13, 74);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(343, 29);
            this.TxtNumeroParte.TabIndex = 5;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.AcceptsTab = true;
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDescripcion.Location = new System.Drawing.Point(0, 0);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.Size = new System.Drawing.Size(834, 298);
            this.TxtDescripcion.TabIndex = 0;
            // 
            // LblNumeroParte
            // 
            this.LblNumeroParte.BackColor = System.Drawing.Color.Black;
            this.LblNumeroParte.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroParte.ForeColor = System.Drawing.Color.White;
            this.LblNumeroParte.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroParte.Name = "LblNumeroParte";
            this.LblNumeroParte.Size = new System.Drawing.Size(1050, 23);
            this.LblNumeroParte.TabIndex = 3;
            this.LblNumeroParte.Text = "SELECCIONA UN NUMERO DE PARTE";
            this.LblNumeroParte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TxtFiltro);
            this.splitContainer2.Panel1.Controls.Add(this.BtnRegistrarMaterial);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.CmbFiltroFabricante);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.CmbFiltroSubcategoria);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.CmbFiltroCategoria);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1337, 678);
            this.splitContainer2.SplitterDistance = 90;
            this.splitContainer2.TabIndex = 1;
            // 
            // TxtFiltro
            // 
            this.TxtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFiltro.Location = new System.Drawing.Point(911, 42);
            this.TxtFiltro.Name = "TxtFiltro";
            this.TxtFiltro.Size = new System.Drawing.Size(289, 29);
            this.TxtFiltro.TabIndex = 12;
            this.TxtFiltro.TextChanged += new System.EventHandler(this.TxtFiltro_TextChanged);
            // 
            // BtnRegistrarMaterial
            // 
            this.BtnRegistrarMaterial.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnRegistrarMaterial.Enabled = false;
            this.BtnRegistrarMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrarMaterial.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.BtnRegistrarMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrarMaterial.Location = new System.Drawing.Point(1217, 23);
            this.BtnRegistrarMaterial.Name = "BtnRegistrarMaterial";
            this.BtnRegistrarMaterial.Size = new System.Drawing.Size(120, 67);
            this.BtnRegistrarMaterial.TabIndex = 8;
            this.BtnRegistrarMaterial.Text = "Registrar";
            this.BtnRegistrarMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRegistrarMaterial.UseVisualStyleBackColor = true;
            this.BtnRegistrarMaterial.Click += new System.EventHandler(this.BtnRegistrarMaterial_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(840, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 24);
            this.label10.TabIndex = 13;
            this.label10.Text = "Buscar:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(556, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Fabricante:";
            // 
            // CmbFiltroFabricante
            // 
            this.CmbFiltroFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroFabricante.FormattingEnabled = true;
            this.CmbFiltroFabricante.Location = new System.Drawing.Point(559, 50);
            this.CmbFiltroFabricante.Name = "CmbFiltroFabricante";
            this.CmbFiltroFabricante.Size = new System.Drawing.Size(256, 32);
            this.CmbFiltroFabricante.TabIndex = 10;
            this.CmbFiltroFabricante.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroFabricante_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1337, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "CATALOGO DE MATERIAL";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Subcategoría:";
            // 
            // CmbFiltroSubcategoria
            // 
            this.CmbFiltroSubcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroSubcategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroSubcategoria.FormattingEnabled = true;
            this.CmbFiltroSubcategoria.Location = new System.Drawing.Point(294, 50);
            this.CmbFiltroSubcategoria.Name = "CmbFiltroSubcategoria";
            this.CmbFiltroSubcategoria.Size = new System.Drawing.Size(256, 32);
            this.CmbFiltroSubcategoria.TabIndex = 6;
            this.CmbFiltroSubcategoria.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroSubcategoria_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Categoría:";
            // 
            // CmbFiltroCategoria
            // 
            this.CmbFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroCategoria.FormattingEnabled = true;
            this.CmbFiltroCategoria.Location = new System.Drawing.Point(12, 50);
            this.CmbFiltroCategoria.Name = "CmbFiltroCategoria";
            this.CmbFiltroCategoria.Size = new System.Drawing.Size(271, 32);
            this.CmbFiltroCategoria.TabIndex = 4;
            this.CmbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroCategoria_SelectedIndexChanged);
            // 
            // FrmCatalogoMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 678);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FrmCatalogoMaterial";
            this.Text = "Catálogo de material";
            this.Load += new System.EventHandler(this.FrmCatalogoMaterial_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).EndInit();
            this.Detalles.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.MenuOpcionesMaterial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumPiezasPaquete)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvMaterial;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbFiltroCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbFiltroSubcategoria;
        private System.Windows.Forms.Label LblNumeroParte;
        private System.Windows.Forms.Button BtnRegistrarMaterial;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PictureBox ImagenMaterial;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbUnidades;
        private System.Windows.Forms.NumericUpDown NumPiezasPaquete;
        private System.Windows.Forms.Label LblEtiquetaPiezasPorPaquete;
        private System.Windows.Forms.Button BtnElegirImagen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtEnlace;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.GroupBox Detalles;
        private System.Windows.Forms.Button BtnOpcionesMaterial;
        private System.Windows.Forms.ContextMenuStrip MenuOpcionesMaterial;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
        private System.Windows.Forms.ToolStripMenuItem verAccesoriosToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbFiltroFabricante;
        private System.Windows.Forms.TextBox TxtFiltro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem verDetallesDeCotizacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verEstadisticasToolStripMenuItem;

    }
}
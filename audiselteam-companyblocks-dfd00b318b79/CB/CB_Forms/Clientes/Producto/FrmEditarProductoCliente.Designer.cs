namespace CB
{
    partial class FrmEditarProductoCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarProductoCliente));
            this.TabsProducto = new System.Windows.Forms.TabControl();
            this.TabDetallesProducto = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbEditarCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbEditarIndustria = new System.Windows.Forms.ComboBox();
            this.TabModelosProducto = new System.Windows.Forms.TabPage();
            this.DgvEditarModelos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuModelos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoModeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarModeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabComponentesProducto = new System.Windows.Forms.TabPage();
            this.DgvEditarComponentes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planos_registrados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solidos_registrados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuComponentes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoComponenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarComponenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabSubensamblesProducto = new System.Windows.Forms.TabPage();
            this.DgvEditarSubensambles = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImagenesTabs = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtNombreProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnFinalizarEdicion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.eliminarComponenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarModeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabsProducto.SuspendLayout();
            this.TabDetallesProducto.SuspendLayout();
            this.TabModelosProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEditarModelos)).BeginInit();
            this.MenuModelos.SuspendLayout();
            this.TabComponentesProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEditarComponentes)).BeginInit();
            this.MenuComponentes.SuspendLayout();
            this.TabSubensamblesProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEditarSubensambles)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabsProducto
            // 
            this.TabsProducto.Controls.Add(this.TabDetallesProducto);
            this.TabsProducto.Controls.Add(this.TabModelosProducto);
            this.TabsProducto.Controls.Add(this.TabComponentesProducto);
            this.TabsProducto.Controls.Add(this.TabSubensamblesProducto);
            this.TabsProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabsProducto.ImageList = this.ImagenesTabs;
            this.TabsProducto.Location = new System.Drawing.Point(0, 82);
            this.TabsProducto.Name = "TabsProducto";
            this.TabsProducto.SelectedIndex = 0;
            this.TabsProducto.Size = new System.Drawing.Size(973, 300);
            this.TabsProducto.TabIndex = 38;
            this.TabsProducto.SelectedIndexChanged += new System.EventHandler(this.TabsProducto_SelectedIndexChanged);
            // 
            // TabDetallesProducto
            // 
            this.TabDetallesProducto.Controls.Add(this.label2);
            this.TabDetallesProducto.Controls.Add(this.TxtDescripcion);
            this.TabDetallesProducto.Controls.Add(this.label6);
            this.TabDetallesProducto.Controls.Add(this.CmbEditarCliente);
            this.TabDetallesProducto.Controls.Add(this.label5);
            this.TabDetallesProducto.Controls.Add(this.CmbEditarIndustria);
            this.TabDetallesProducto.ImageIndex = 3;
            this.TabDetallesProducto.Location = new System.Drawing.Point(4, 39);
            this.TabDetallesProducto.Name = "TabDetallesProducto";
            this.TabDetallesProducto.Padding = new System.Windows.Forms.Padding(3);
            this.TabDetallesProducto.Size = new System.Drawing.Size(965, 257);
            this.TabDetallesProducto.TabIndex = 3;
            this.TabDetallesProducto.Text = "Detalles";
            this.TabDetallesProducto.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Descripción:";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Location = new System.Drawing.Point(18, 146);
            this.TxtDescripcion.MaxLength = 500;
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(490, 124);
            this.TxtDescripcion.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Cliente:";
            // 
            // CmbEditarCliente
            // 
            this.CmbEditarCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEditarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEditarCliente.FormattingEnabled = true;
            this.CmbEditarCliente.Items.AddRange(new object[] {
            "TODOS"});
            this.CmbEditarCliente.Location = new System.Drawing.Point(18, 27);
            this.CmbEditarCliente.Name = "CmbEditarCliente";
            this.CmbEditarCliente.Size = new System.Drawing.Size(490, 32);
            this.CmbEditarCliente.TabIndex = 37;
            this.CmbEditarCliente.SelectedIndexChanged += new System.EventHandler(this.CmbEditarCliente_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Industria:";
            // 
            // CmbEditarIndustria
            // 
            this.CmbEditarIndustria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEditarIndustria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEditarIndustria.FormattingEnabled = true;
            this.CmbEditarIndustria.Items.AddRange(new object[] {
            "TODAS"});
            this.CmbEditarIndustria.Location = new System.Drawing.Point(18, 87);
            this.CmbEditarIndustria.Name = "CmbEditarIndustria";
            this.CmbEditarIndustria.Size = new System.Drawing.Size(490, 32);
            this.CmbEditarIndustria.TabIndex = 35;
            // 
            // TabModelosProducto
            // 
            this.TabModelosProducto.Controls.Add(this.DgvEditarModelos);
            this.TabModelosProducto.ImageIndex = 0;
            this.TabModelosProducto.Location = new System.Drawing.Point(4, 39);
            this.TabModelosProducto.Name = "TabModelosProducto";
            this.TabModelosProducto.Padding = new System.Windows.Forms.Padding(3);
            this.TabModelosProducto.Size = new System.Drawing.Size(965, 257);
            this.TabModelosProducto.TabIndex = 0;
            this.TabModelosProducto.Text = "Modelos";
            this.TabModelosProducto.UseVisualStyleBackColor = true;
            // 
            // DgvEditarModelos
            // 
            this.DgvEditarModelos.AllowUserToAddRows = false;
            this.DgvEditarModelos.AllowUserToResizeRows = false;
            this.DgvEditarModelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEditarModelos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.familia,
            this.dataGridViewTextBoxColumn3});
            this.DgvEditarModelos.ContextMenuStrip = this.MenuModelos;
            this.DgvEditarModelos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvEditarModelos.Location = new System.Drawing.Point(3, 3);
            this.DgvEditarModelos.MultiSelect = false;
            this.DgvEditarModelos.Name = "DgvEditarModelos";
            this.DgvEditarModelos.ReadOnly = true;
            this.DgvEditarModelos.RowHeadersVisible = false;
            this.DgvEditarModelos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEditarModelos.Size = new System.Drawing.Size(959, 251);
            this.DgvEditarModelos.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // familia
            // 
            this.familia.HeaderText = "Familia";
            this.familia.Name = "familia";
            this.familia.ReadOnly = true;
            this.familia.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Número de parte";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // MenuModelos
            // 
            this.MenuModelos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoModeloToolStripMenuItem,
            this.editarModeloToolStripMenuItem,
            this.eliminarModeloToolStripMenuItem});
            this.MenuModelos.Name = "MenuModelos";
            this.MenuModelos.Size = new System.Drawing.Size(118, 70);
            this.MenuModelos.Opening += new System.ComponentModel.CancelEventHandler(this.MenuModelos_Opening);
            // 
            // nuevoModeloToolStripMenuItem
            // 
            this.nuevoModeloToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoModeloToolStripMenuItem.Name = "nuevoModeloToolStripMenuItem";
            this.nuevoModeloToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoModeloToolStripMenuItem.Text = "Nuevo";
            this.nuevoModeloToolStripMenuItem.Click += new System.EventHandler(this.nuevoModeloToolStripMenuItem_Click);
            // 
            // editarModeloToolStripMenuItem
            // 
            this.editarModeloToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarModeloToolStripMenuItem.Name = "editarModeloToolStripMenuItem";
            this.editarModeloToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editarModeloToolStripMenuItem.Text = "Editar";
            this.editarModeloToolStripMenuItem.Click += new System.EventHandler(this.editarModeloToolStripMenuItem_Click);
            // 
            // TabComponentesProducto
            // 
            this.TabComponentesProducto.Controls.Add(this.DgvEditarComponentes);
            this.TabComponentesProducto.ImageIndex = 1;
            this.TabComponentesProducto.Location = new System.Drawing.Point(4, 39);
            this.TabComponentesProducto.Name = "TabComponentesProducto";
            this.TabComponentesProducto.Padding = new System.Windows.Forms.Padding(3);
            this.TabComponentesProducto.Size = new System.Drawing.Size(965, 257);
            this.TabComponentesProducto.TabIndex = 1;
            this.TabComponentesProducto.Text = "Componentes";
            this.TabComponentesProducto.UseVisualStyleBackColor = true;
            // 
            // DgvEditarComponentes
            // 
            this.DgvEditarComponentes.AllowUserToAddRows = false;
            this.DgvEditarComponentes.AllowUserToDeleteRows = false;
            this.DgvEditarComponentes.AllowUserToResizeRows = false;
            this.DgvEditarComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEditarComponentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.variantes,
            this.planos_registrados,
            this.solidos_registrados});
            this.DgvEditarComponentes.ContextMenuStrip = this.MenuComponentes;
            this.DgvEditarComponentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvEditarComponentes.Location = new System.Drawing.Point(3, 3);
            this.DgvEditarComponentes.Name = "DgvEditarComponentes";
            this.DgvEditarComponentes.ReadOnly = true;
            this.DgvEditarComponentes.RowHeadersVisible = false;
            this.DgvEditarComponentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEditarComponentes.Size = new System.Drawing.Size(959, 251);
            this.DgvEditarComponentes.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre del componente";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // variantes
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.variantes.DefaultCellStyle = dataGridViewCellStyle8;
            this.variantes.HeaderText = "Variantes";
            this.variantes.Name = "variantes";
            this.variantes.ReadOnly = true;
            // 
            // planos_registrados
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.planos_registrados.DefaultCellStyle = dataGridViewCellStyle9;
            this.planos_registrados.HeaderText = "Planos registrados";
            this.planos_registrados.Name = "planos_registrados";
            this.planos_registrados.ReadOnly = true;
            // 
            // solidos_registrados
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.solidos_registrados.DefaultCellStyle = dataGridViewCellStyle10;
            this.solidos_registrados.HeaderText = "Sólidos registrados";
            this.solidos_registrados.Name = "solidos_registrados";
            this.solidos_registrados.ReadOnly = true;
            // 
            // MenuComponentes
            // 
            this.MenuComponentes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoComponenteToolStripMenuItem,
            this.editarComponenteToolStripMenuItem,
            this.eliminarComponenteToolStripMenuItem});
            this.MenuComponentes.Name = "MenuComponentes";
            this.MenuComponentes.Size = new System.Drawing.Size(153, 92);
            this.MenuComponentes.Opening += new System.ComponentModel.CancelEventHandler(this.MenuComponentes_Opening);
            // 
            // nuevoComponenteToolStripMenuItem
            // 
            this.nuevoComponenteToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoComponenteToolStripMenuItem.Name = "nuevoComponenteToolStripMenuItem";
            this.nuevoComponenteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nuevoComponenteToolStripMenuItem.Text = "Nuevo";
            this.nuevoComponenteToolStripMenuItem.Click += new System.EventHandler(this.nuevoComponenteToolStripMenuItem_Click);
            // 
            // editarComponenteToolStripMenuItem
            // 
            this.editarComponenteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarComponenteToolStripMenuItem.Name = "editarComponenteToolStripMenuItem";
            this.editarComponenteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editarComponenteToolStripMenuItem.Text = "Editar";
            this.editarComponenteToolStripMenuItem.Click += new System.EventHandler(this.editarComponenteToolStripMenuItem_Click);
            // 
            // TabSubensamblesProducto
            // 
            this.TabSubensamblesProducto.Controls.Add(this.DgvEditarSubensambles);
            this.TabSubensamblesProducto.ImageIndex = 2;
            this.TabSubensamblesProducto.Location = new System.Drawing.Point(4, 39);
            this.TabSubensamblesProducto.Name = "TabSubensamblesProducto";
            this.TabSubensamblesProducto.Padding = new System.Windows.Forms.Padding(3);
            this.TabSubensamblesProducto.Size = new System.Drawing.Size(965, 257);
            this.TabSubensamblesProducto.TabIndex = 2;
            this.TabSubensamblesProducto.Text = "Subensambles";
            this.TabSubensamblesProducto.UseVisualStyleBackColor = true;
            // 
            // DgvEditarSubensambles
            // 
            this.DgvEditarSubensambles.AllowUserToAddRows = false;
            this.DgvEditarSubensambles.AllowUserToResizeColumns = false;
            this.DgvEditarSubensambles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEditarSubensambles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.DgvEditarSubensambles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvEditarSubensambles.Location = new System.Drawing.Point(3, 3);
            this.DgvEditarSubensambles.Name = "DgvEditarSubensambles";
            this.DgvEditarSubensambles.RowHeadersVisible = false;
            this.DgvEditarSubensambles.Size = new System.Drawing.Size(959, 251);
            this.DgvEditarSubensambles.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "Nombre del subensamble";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // ImagenesTabs
            // 
            this.ImagenesTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTabs.ImageStream")));
            this.ImagenesTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTabs.Images.SetKeyName(0, "index_48.png");
            this.ImagenesTabs.Images.SetKeyName(1, "puzzle_part_48.png");
            this.ImagenesTabs.Images.SetKeyName(2, "components_48.png");
            this.ImagenesTabs.Images.SetKeyName(3, "details.ico");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtNombreProducto);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BtnFinalizarEdicion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 59);
            this.panel2.TabIndex = 39;
            // 
            // TxtNombreProducto
            // 
            this.TxtNombreProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreProducto.Location = new System.Drawing.Point(11, 22);
            this.TxtNombreProducto.Name = "TxtNombreProducto";
            this.TxtNombreProducto.Size = new System.Drawing.Size(602, 29);
            this.TxtNombreProducto.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre del producto:";
            // 
            // BtnFinalizarEdicion
            // 
            this.BtnFinalizarEdicion.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizarEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizarEdicion.Image = global::CB_Base.Properties.Resources.ok_48;
            this.BtnFinalizarEdicion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizarEdicion.Location = new System.Drawing.Point(848, 0);
            this.BtnFinalizarEdicion.Name = "BtnFinalizarEdicion";
            this.BtnFinalizarEdicion.Size = new System.Drawing.Size(125, 59);
            this.BtnFinalizarEdicion.TabIndex = 0;
            this.BtnFinalizarEdicion.Text = "Finalizar";
            this.BtnFinalizarEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnFinalizarEdicion.UseVisualStyleBackColor = true;
            this.BtnFinalizarEdicion.Click += new System.EventHandler(this.BtnFinalizarEdicion_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(973, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "EDITAR PRODUCTO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eliminarComponenteToolStripMenuItem
            // 
            this.eliminarComponenteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarComponenteToolStripMenuItem.Name = "eliminarComponenteToolStripMenuItem";
            this.eliminarComponenteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarComponenteToolStripMenuItem.Text = "Eliminar";
            this.eliminarComponenteToolStripMenuItem.Click += new System.EventHandler(this.eliminarComponenteToolStripMenuItem_Click);
            // 
            // eliminarModeloToolStripMenuItem
            // 
            this.eliminarModeloToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarModeloToolStripMenuItem.Name = "eliminarModeloToolStripMenuItem";
            this.eliminarModeloToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarModeloToolStripMenuItem.Text = "Eliminar";
            this.eliminarModeloToolStripMenuItem.Click += new System.EventHandler(this.eliminarModeloToolStripMenuItem_Click);
            // 
            // FrmEditarProductoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 382);
            this.Controls.Add(this.TabsProducto);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmEditarProductoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar producto del cliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEditarProductoCliente_Load);
            this.TabsProducto.ResumeLayout(false);
            this.TabDetallesProducto.ResumeLayout(false);
            this.TabDetallesProducto.PerformLayout();
            this.TabModelosProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEditarModelos)).EndInit();
            this.MenuModelos.ResumeLayout(false);
            this.TabComponentesProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEditarComponentes)).EndInit();
            this.MenuComponentes.ResumeLayout(false);
            this.TabSubensamblesProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEditarSubensambles)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabsProducto;
        private System.Windows.Forms.TabPage TabDetallesProducto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbEditarCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbEditarIndustria;
        private System.Windows.Forms.TabPage TabModelosProducto;
        private System.Windows.Forms.DataGridView DgvEditarModelos;
        private System.Windows.Forms.TabPage TabComponentesProducto;
        private System.Windows.Forms.DataGridView DgvEditarComponentes;
        private System.Windows.Forms.TabPage TabSubensamblesProducto;
        private System.Windows.Forms.DataGridView DgvEditarSubensambles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ImageList ImagenesTabs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxtNombreProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnFinalizarEdicion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.ContextMenuStrip MenuModelos;
        private System.Windows.Forms.ToolStripMenuItem nuevoModeloToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripMenuItem editarModeloToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn variantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn planos_registrados;
        private System.Windows.Forms.DataGridViewTextBoxColumn solidos_registrados;
        private System.Windows.Forms.ContextMenuStrip MenuComponentes;
        private System.Windows.Forms.ToolStripMenuItem nuevoComponenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarComponenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarComponenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarModeloToolStripMenuItem;

    }
}
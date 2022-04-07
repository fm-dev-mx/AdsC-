namespace CB
{
    partial class FrmAgregarPo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarPo));
            this.DgvPartidasPo = new System.Windows.Forms.DataGridView();
            this.partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpcionesPOSinEnviar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.desglosarPartidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearRevisiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblPO = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnAgregarMaterial = new System.Windows.Forms.Button();
            this.BtnRemoverPartida = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.LblRevision = new System.Windows.Forms.Label();
            this.BtnBorrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbMoneda = new System.Windows.Forms.ComboBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TvMaterial = new System.Windows.Forms.TreeView();
            this.ImagenLista = new System.Windows.Forms.ImageList(this.components);
            this.CmbAutorizacion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ToolTipAgregar = new System.Windows.Forms.ToolTip(this.components);
            this.BkgEnviarCorreo = new System.ComponentModel.BackgroundWorker();
            this.PanelInformacion = new System.Windows.Forms.Panel();
            this.LblRequisitor = new System.Windows.Forms.Label();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.LblFechaCreacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPartidasPo)).BeginInit();
            this.OpcionesPOSinEnviar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PanelInformacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvPartidasPo
            // 
            this.DgvPartidasPo.AllowUserToAddRows = false;
            this.DgvPartidasPo.AllowUserToDeleteRows = false;
            this.DgvPartidasPo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvPartidasPo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPartidasPo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.partida,
            this.numero_parte,
            this.fabricante,
            this.descripcion,
            this.cantidad,
            this.precio_unitario,
            this.suma,
            this.tiempo_entrega});
            this.DgvPartidasPo.ContextMenuStrip = this.OpcionesPOSinEnviar;
            this.DgvPartidasPo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPartidasPo.Location = new System.Drawing.Point(273, 92);
            this.DgvPartidasPo.Name = "DgvPartidasPo";
            this.DgvPartidasPo.ReadOnly = true;
            this.DgvPartidasPo.RowHeadersVisible = false;
            this.DgvPartidasPo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPartidasPo.Size = new System.Drawing.Size(900, 483);
            this.DgvPartidasPo.TabIndex = 14;
            this.DgvPartidasPo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPartidasPo_CellClick);
            this.DgvPartidasPo.SelectionChanged += new System.EventHandler(this.DgvPartidasPo_SelectionChanged);
            // 
            // partida
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partida.DefaultCellStyle = dataGridViewCellStyle1;
            this.partida.Frozen = true;
            this.partida.HeaderText = "Partida";
            this.partida.Name = "partida";
            this.partida.ReadOnly = true;
            this.partida.Width = 50;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle2;
            this.numero_parte.Frozen = true;
            this.numero_parte.HeaderText = "Número de parte";
            this.numero_parte.MinimumWidth = 150;
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            this.numero_parte.Width = 150;
            // 
            // fabricante
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fabricante.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle4;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 200;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle5;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 72;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 72;
            // 
            // precio_unitario
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio_unitario.DefaultCellStyle = dataGridViewCellStyle6;
            this.precio_unitario.HeaderText = "Precio unitario";
            this.precio_unitario.MinimumWidth = 100;
            this.precio_unitario.Name = "precio_unitario";
            this.precio_unitario.ReadOnly = true;
            // 
            // suma
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suma.DefaultCellStyle = dataGridViewCellStyle7;
            this.suma.HeaderText = "Suma";
            this.suma.MinimumWidth = 100;
            this.suma.Name = "suma";
            this.suma.ReadOnly = true;
            // 
            // tiempo_entrega
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo_entrega.DefaultCellStyle = dataGridViewCellStyle8;
            this.tiempo_entrega.HeaderText = "Tiempo de entrega";
            this.tiempo_entrega.MinimumWidth = 100;
            this.tiempo_entrega.Name = "tiempo_entrega";
            this.tiempo_entrega.ReadOnly = true;
            // 
            // OpcionesPOSinEnviar
            // 
            this.OpcionesPOSinEnviar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desglosarPartidaToolStripMenuItem,
            this.crearRevisiónToolStripMenuItem,
            this.verPDFToolStripMenuItem});
            this.OpcionesPOSinEnviar.Name = "OpcionesRFQ";
            this.OpcionesPOSinEnviar.Size = new System.Drawing.Size(166, 70);
            this.OpcionesPOSinEnviar.Opening += new System.ComponentModel.CancelEventHandler(this.OpcionesPOSinEnviar_Opening);
            // 
            // desglosarPartidaToolStripMenuItem
            // 
            this.desglosarPartidaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.arrows;
            this.desglosarPartidaToolStripMenuItem.Name = "desglosarPartidaToolStripMenuItem";
            this.desglosarPartidaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.desglosarPartidaToolStripMenuItem.Text = "Desglosar partida";
            this.desglosarPartidaToolStripMenuItem.Click += new System.EventHandler(this.desglosarPartidaToolStripMenuItem_Click);
            // 
            // crearRevisiónToolStripMenuItem
            // 
            this.crearRevisiónToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.crearRevisiónToolStripMenuItem.Name = "crearRevisiónToolStripMenuItem";
            this.crearRevisiónToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.crearRevisiónToolStripMenuItem.Text = "Crear revisión";
            this.crearRevisiónToolStripMenuItem.Click += new System.EventHandler(this.crearRevisiónToolStripMenuItem_Click);
            // 
            // verPDFToolStripMenuItem
            // 
            this.verPDFToolStripMenuItem.Image = global::CB_Base.Properties.Resources.pdf_icon_png_pdf_zum_download_2;
            this.verPDFToolStripMenuItem.Name = "verPDFToolStripMenuItem";
            this.verPDFToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.verPDFToolStripMenuItem.Text = "Ver PDF";
            this.verPDFToolStripMenuItem.Click += new System.EventHandler(this.verPDFToolStripMenuItem_Click);
            // 
            // LblPO
            // 
            this.LblPO.BackColor = System.Drawing.Color.Black;
            this.LblPO.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPO.ForeColor = System.Drawing.Color.White;
            this.LblPO.Location = new System.Drawing.Point(0, 0);
            this.LblPO.Name = "LblPO";
            this.LblPO.Size = new System.Drawing.Size(1173, 23);
            this.LblPO.TabIndex = 10;
            this.LblPO.Text = "SELECCIONA UNA PO";
            this.LblPO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnAgregarMaterial);
            this.panel2.Controls.Add(this.BtnRemoverPartida);
            this.panel2.Controls.Add(this.BtnNuevo);
            this.panel2.Controls.Add(this.LblRevision);
            this.panel2.Controls.Add(this.BtnBorrar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CmbMoneda);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(273, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 50);
            this.panel2.TabIndex = 17;
            // 
            // BtnAgregarMaterial
            // 
            this.BtnAgregarMaterial.Enabled = false;
            this.BtnAgregarMaterial.Image = global::CB_Base.Properties.Resources.next_icon_32;
            this.BtnAgregarMaterial.Location = new System.Drawing.Point(81, 9);
            this.BtnAgregarMaterial.Name = "BtnAgregarMaterial";
            this.BtnAgregarMaterial.Size = new System.Drawing.Size(70, 35);
            this.BtnAgregarMaterial.TabIndex = 16;
            this.ToolTipAgregar.SetToolTip(this.BtnAgregarMaterial, "Agregar partida");
            this.BtnAgregarMaterial.UseVisualStyleBackColor = true;
            this.BtnAgregarMaterial.Click += new System.EventHandler(this.BtnAgregarMaterial_Click);
            // 
            // BtnRemoverPartida
            // 
            this.BtnRemoverPartida.Enabled = false;
            this.BtnRemoverPartida.Image = global::CB_Base.Properties.Resources.previous_icon_32;
            this.BtnRemoverPartida.Location = new System.Drawing.Point(6, 8);
            this.BtnRemoverPartida.Name = "BtnRemoverPartida";
            this.BtnRemoverPartida.Size = new System.Drawing.Size(70, 36);
            this.BtnRemoverPartida.TabIndex = 17;
            this.ToolTipAgregar.SetToolTip(this.BtnRemoverPartida, "Remover partida");
            this.BtnRemoverPartida.UseVisualStyleBackColor = true;
            this.BtnRemoverPartida.Click += new System.EventHandler(this.BtnQuitarMaterial_Click);
            this.BtnRemoverPartida.Leave += new System.EventHandler(this.BtnRemoverPartida_Leave);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.Image = global::CB_Base.Properties.Resources.mail_send_icon48;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(517, 0);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(132, 50);
            this.BtnNuevo.TabIndex = 15;
            this.BtnNuevo.Text = "     Enviar";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // LblRevision
            // 
            this.LblRevision.AutoSize = true;
            this.LblRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRevision.Location = new System.Drawing.Point(356, 11);
            this.LblRevision.Name = "LblRevision";
            this.LblRevision.Size = new System.Drawing.Size(123, 25);
            this.LblRevision.TabIndex = 18;
            this.LblRevision.Text = "Revisión #";
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBorrar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBorrar.Location = new System.Drawing.Point(649, 0);
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(129, 50);
            this.BtnBorrar.TabIndex = 19;
            this.BtnBorrar.Text = "     Cancelar";
            this.BtnBorrar.UseVisualStyleBackColor = true;
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Moneda:";
            // 
            // CmbMoneda
            // 
            this.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMoneda.FormattingEnabled = true;
            this.CmbMoneda.Items.AddRange(new object[] {
            "MXN",
            "USD",
            "EUR"});
            this.CmbMoneda.Location = new System.Drawing.Point(212, 11);
            this.CmbMoneda.Name = "CmbMoneda";
            this.CmbMoneda.Size = new System.Drawing.Size(127, 33);
            this.CmbMoneda.TabIndex = 16;
            this.CmbMoneda.SelectedIndexChanged += new System.EventHandler(this.CmbMoneda_SelectedIndexChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exitMenuIcon;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(778, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(122, 50);
            this.BtnSalir.TabIndex = 20;
            this.BtnSalir.Text = "     Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TvMaterial);
            this.panel3.Controls.Add(this.CmbAutorizacion);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 552);
            this.panel3.TabIndex = 18;
            // 
            // TvMaterial
            // 
            this.TvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvMaterial.ImageIndex = 0;
            this.TvMaterial.ImageList = this.ImagenLista;
            this.TvMaterial.Location = new System.Drawing.Point(0, 45);
            this.TvMaterial.Name = "TvMaterial";
            this.TvMaterial.SelectedImageIndex = 0;
            this.TvMaterial.Size = new System.Drawing.Size(273, 507);
            this.TvMaterial.TabIndex = 19;
            this.TvMaterial.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvMaterial_AfterSelect);
            this.TvMaterial.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMaterial_NodeMouseDoubleClick);
            // 
            // ImagenLista
            // 
            this.ImagenLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenLista.ImageStream")));
            this.ImagenLista.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenLista.Images.SetKeyName(0, "marker_icon_32.png");
            this.ImagenLista.Images.SetKeyName(1, "folder_24px.png");
            this.ImagenLista.Images.SetKeyName(2, "pdf-48.png");
            // 
            // CmbAutorizacion
            // 
            this.CmbAutorizacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbAutorizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAutorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAutorizacion.FormattingEnabled = true;
            this.CmbAutorizacion.Items.AddRange(new object[] {
            "LISTO PARA ORDENAR",
            "COMPRA DETENIDA",
            "EN REVISION FINANCIERA",
            "EN REVISION TECNICA"});
            this.CmbAutorizacion.Location = new System.Drawing.Point(0, 21);
            this.CmbAutorizacion.Name = "CmbAutorizacion";
            this.CmbAutorizacion.Size = new System.Drawing.Size(273, 24);
            this.CmbAutorizacion.TabIndex = 119;
            this.CmbAutorizacion.SelectedIndexChanged += new System.EventHandler(this.CmbAutorizacion_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 21);
            this.label4.TabIndex = 120;
            this.label4.Text = "Seleccione el tipo de compra";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BkgEnviarCorreo
            // 
            this.BkgEnviarCorreo.WorkerReportsProgress = true;
            this.BkgEnviarCorreo.WorkerSupportsCancellation = true;
            this.BkgEnviarCorreo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEnviarCorreo_DoWork);
            this.BkgEnviarCorreo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEnviarCorreo_RunWorkerCompleted);
            // 
            // PanelInformacion
            // 
            this.PanelInformacion.Controls.Add(this.LblRequisitor);
            this.PanelInformacion.Controls.Add(this.LblEstatus);
            this.PanelInformacion.Controls.Add(this.LblFechaCreacion);
            this.PanelInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelInformacion.Location = new System.Drawing.Point(273, 73);
            this.PanelInformacion.Name = "PanelInformacion";
            this.PanelInformacion.Size = new System.Drawing.Size(900, 19);
            this.PanelInformacion.TabIndex = 119;
            // 
            // LblRequisitor
            // 
            this.LblRequisitor.AutoSize = true;
            this.LblRequisitor.Location = new System.Drawing.Point(287, 2);
            this.LblRequisitor.Name = "LblRequisitor";
            this.LblRequisitor.Size = new System.Drawing.Size(60, 13);
            this.LblRequisitor.TabIndex = 3;
            this.LblRequisitor.Text = "Requisitor: ";
            // 
            // LblEstatus
            // 
            this.LblEstatus.AutoSize = true;
            this.LblEstatus.Location = new System.Drawing.Point(581, 2);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(48, 13);
            this.LblEstatus.TabIndex = 2;
            this.LblEstatus.Text = "Estatus: ";
            // 
            // LblFechaCreacion
            // 
            this.LblFechaCreacion.AutoSize = true;
            this.LblFechaCreacion.Location = new System.Drawing.Point(6, 2);
            this.LblFechaCreacion.Name = "LblFechaCreacion";
            this.LblFechaCreacion.Size = new System.Drawing.Size(102, 13);
            this.LblFechaCreacion.TabIndex = 0;
            this.LblFechaCreacion.Text = "Fecha de creación: ";
            // 
            // FrmAgregarPo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 575);
            this.Controls.Add(this.DgvPartidasPo);
            this.Controls.Add(this.PanelInformacion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.LblPO);
            this.Name = "FrmAgregarPo";
            this.Text = "Agregar PO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAgregarPo_FormClosing);
            this.Load += new System.EventHandler(this.FrmAgregarPo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPartidasPo)).EndInit();
            this.OpcionesPOSinEnviar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.PanelInformacion.ResumeLayout(false);
            this.PanelInformacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPartidasPo;
        private System.Windows.Forms.Label LblPO;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnAgregarMaterial;
        private System.Windows.Forms.Button BtnRemoverPartida;
        private System.Windows.Forms.TreeView TvMaterial;
        private System.Windows.Forms.Label LblRevision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbMoneda;
        private System.Windows.Forms.ContextMenuStrip OpcionesPOSinEnviar;
        private System.Windows.Forms.ToolStripMenuItem desglosarPartidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearRevisiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPDFToolStripMenuItem;
        private System.Windows.Forms.ImageList ImagenLista;
        private System.Windows.Forms.Button BtnBorrar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip ToolTipAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn suma;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_entrega;
        private System.ComponentModel.BackgroundWorker BkgEnviarCorreo;
        private System.Windows.Forms.Panel PanelInformacion;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.Label LblFechaCreacion;
        private System.Windows.Forms.Label LblRequisitor;
        private System.Windows.Forms.ComboBox CmbAutorizacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnSalir;

    }
}
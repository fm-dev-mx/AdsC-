namespace CB
{
    partial class FrmMonitorCompras2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitorCompras2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TvMetas = new System.Windows.Forms.TreeView();
            this.ImagenLista = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.CkbAgrupar = new System.Windows.Forms.CheckBox();
            this.CmbTipoCompra = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TvRFQs = new System.Windows.Forms.TreeView();
            this.MenuRFQ = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.crearNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmbTipoRfq = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TvPOs = new System.Windows.Forms.TreeView();
            this.MenuPo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.crearNuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CmbTipoPo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnBuscarMaterial = new System.Windows.Forms.Button();
            this.BtnFiltrarDatos = new System.Windows.Forms.Button();
            this.BtnMetas = new System.Windows.Forms.Button();
            this.BtnKpis = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BkgEnviarCorreo = new System.ComponentModel.BackgroundWorker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.MenuRequisicion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.proveedorPreferidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cotizarMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenarMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBusquedas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buscarNúmeroDeParteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarDescripciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MenuRFQ.SuspendLayout();
            this.MenuPo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.MenuRequisicion.SuspendLayout();
            this.MenuBusquedas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TvMetas);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 489);
            this.panel1.TabIndex = 1;
            // 
            // TvMetas
            // 
            this.TvMetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvMetas.ImageIndex = 0;
            this.TvMetas.ImageList = this.ImagenLista;
            this.TvMetas.Location = new System.Drawing.Point(0, 94);
            this.TvMetas.Name = "TvMetas";
            this.TvMetas.SelectedImageIndex = 0;
            this.TvMetas.ShowNodeToolTips = true;
            this.TvMetas.Size = new System.Drawing.Size(269, 395);
            this.TvMetas.TabIndex = 5;
            this.TvMetas.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TvPOs_AfterCollapse);
            this.TvMetas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvMetas_AfterSelect);
            this.TvMetas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMetas_NodeMouseClick);
            this.TvMetas.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMetas_NodeMouseDoubleClick);
            // 
            // ImagenLista
            // 
            this.ImagenLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenLista.ImageStream")));
            this.ImagenLista.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenLista.Images.SetKeyName(0, "marker_icon_32.png");
            this.ImagenLista.Images.SetKeyName(1, "folder_24px.png");
            this.ImagenLista.Images.SetKeyName(2, "pdf_clock.png");
            this.ImagenLista.Images.SetKeyName(3, "pdf-unknown-48.png");
            this.ImagenLista.Images.SetKeyName(4, "pdf_truckincognito.png");
            this.ImagenLista.Images.SetKeyName(5, "pdf-48.png");
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CkbAgrupar);
            this.panel4.Controls.Add(this.CmbTipoCompra);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(269, 52);
            this.panel4.TabIndex = 120;
            // 
            // CkbAgrupar
            // 
            this.CkbAgrupar.AutoSize = true;
            this.CkbAgrupar.Location = new System.Drawing.Point(7, 31);
            this.CkbAgrupar.Name = "CkbAgrupar";
            this.CkbAgrupar.Size = new System.Drawing.Size(131, 17);
            this.CkbAgrupar.TabIndex = 119;
            this.CkbAgrupar.Text = "Agrupar por fabricante";
            this.CkbAgrupar.UseVisualStyleBackColor = true;
            this.CkbAgrupar.CheckedChanged += new System.EventHandler(this.CkbAgrupar_CheckedChanged);
            // 
            // CmbTipoCompra
            // 
            this.CmbTipoCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbTipoCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoCompra.FormattingEnabled = true;
            this.CmbTipoCompra.Location = new System.Drawing.Point(0, 0);
            this.CmbTipoCompra.Name = "CmbTipoCompra";
            this.CmbTipoCompra.Size = new System.Drawing.Size(269, 24);
            this.CmbTipoCompra.TabIndex = 118;
            this.CmbTipoCompra.SelectedIndexChanged += new System.EventHandler(this.CmbTipoCompra_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(0, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 21);
            this.label4.TabIndex = 119;
            this.label4.Text = "Seleccione el tipo de compra:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "REQUISICIONES DE COMPRA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1030, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 489);
            this.panel2.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TvRFQs);
            this.splitContainer1.Panel1.Controls.Add(this.CmbTipoRfq);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TvPOs);
            this.splitContainer1.Panel2.Controls.Add(this.CmbTipoPo);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(226, 489);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 0;
            // 
            // TvRFQs
            // 
            this.TvRFQs.ContextMenuStrip = this.MenuRFQ;
            this.TvRFQs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvRFQs.ImageIndex = 0;
            this.TvRFQs.ImageList = this.ImagenLista;
            this.TvRFQs.Location = new System.Drawing.Point(0, 66);
            this.TvRFQs.Name = "TvRFQs";
            this.TvRFQs.SelectedImageIndex = 0;
            this.TvRFQs.Size = new System.Drawing.Size(226, 157);
            this.TvRFQs.TabIndex = 6;
            this.TvRFQs.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TvPOs_AfterCollapse);
            this.TvRFQs.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tv_NodeMouseClick);
            this.TvRFQs.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvRFQs_NodeMouseDoubleClick);
            // 
            // MenuRFQ
            // 
            this.MenuRFQ.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearNuevoToolStripMenuItem,
            this.copiarToolStripMenuItem1,
            this.descargarPDFToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuRFQ.Name = "MenuRFQ";
            this.MenuRFQ.Size = new System.Drawing.Size(139, 92);
            this.MenuRFQ.Opening += new System.ComponentModel.CancelEventHandler(this.MenuRFQ_Opening);
            // 
            // crearNuevoToolStripMenuItem
            // 
            this.crearNuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.crearNuevoToolStripMenuItem.Name = "crearNuevoToolStripMenuItem";
            this.crearNuevoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.crearNuevoToolStripMenuItem.Text = "Crear nuevo";
            this.crearNuevoToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // copiarToolStripMenuItem1
            // 
            this.copiarToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.copy2;
            this.copiarToolStripMenuItem1.Name = "copiarToolStripMenuItem1";
            this.copiarToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.copiarToolStripMenuItem1.Text = "Copiar";
            this.copiarToolStripMenuItem1.Click += new System.EventHandler(this.copiarToolStripMenuItem1_Click);
            // 
            // descargarPDFToolStripMenuItem
            // 
            this.descargarPDFToolStripMenuItem.Image = global::CB_Base.Properties.Resources.pdf_icon_png_pdf_zum_download_2;
            this.descargarPDFToolStripMenuItem.Name = "descargarPDFToolStripMenuItem";
            this.descargarPDFToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.descargarPDFToolStripMenuItem.Text = "Ver PDF";
            this.descargarPDFToolStripMenuItem.Click += new System.EventHandler(this.descargarPDFToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // CmbTipoRfq
            // 
            this.CmbTipoRfq.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbTipoRfq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoRfq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoRfq.FormattingEnabled = true;
            this.CmbTipoRfq.Items.AddRange(new object[] {
            "SIN ENVIAR",
            "ENVIADO"});
            this.CmbTipoRfq.Location = new System.Drawing.Point(0, 42);
            this.CmbTipoRfq.Name = "CmbTipoRfq";
            this.CmbTipoRfq.Size = new System.Drawing.Size(226, 24);
            this.CmbTipoRfq.TabIndex = 121;
            this.CmbTipoRfq.SelectedIndexChanged += new System.EventHandler(this.CmbTipoRfq_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(0, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 21);
            this.label5.TabIndex = 120;
            this.label5.Text = "Seleccione el tipo de RFQ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "RFQs";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TvPOs
            // 
            this.TvPOs.ContextMenuStrip = this.MenuPo;
            this.TvPOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvPOs.ImageIndex = 0;
            this.TvPOs.ImageList = this.ImagenLista;
            this.TvPOs.Location = new System.Drawing.Point(0, 66);
            this.TvPOs.Name = "TvPOs";
            this.TvPOs.SelectedImageIndex = 0;
            this.TvPOs.Size = new System.Drawing.Size(226, 196);
            this.TvPOs.TabIndex = 7;
            this.TvPOs.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TvPOs_AfterCollapse);
            this.TvPOs.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tv_NodeMouseClick);
            this.TvPOs.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvPOs_NodeMouseDoubleClick);
            // 
            // MenuPo
            // 
            this.MenuPo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearNuevaToolStripMenuItem,
            this.eliminarToolStripMenuItem1});
            this.MenuPo.Name = "MenuPo";
            this.MenuPo.Size = new System.Drawing.Size(138, 48);
            this.MenuPo.Opening += new System.ComponentModel.CancelEventHandler(this.MenuPo_Opening);
            // 
            // crearNuevaToolStripMenuItem
            // 
            this.crearNuevaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.crearNuevaToolStripMenuItem.Name = "crearNuevaToolStripMenuItem";
            this.crearNuevaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.crearNuevaToolStripMenuItem.Text = "Crear nueva";
            this.crearNuevaToolStripMenuItem.Click += new System.EventHandler(this.BtnNuevaPo_Click);
            // 
            // eliminarToolStripMenuItem1
            // 
            this.eliminarToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            this.eliminarToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.eliminarToolStripMenuItem1.Text = "Eliminar";
            this.eliminarToolStripMenuItem1.Click += new System.EventHandler(this.eliminarToolStripMenuItem1_Click);
            // 
            // CmbTipoPo
            // 
            this.CmbTipoPo.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbTipoPo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoPo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoPo.FormattingEnabled = true;
            this.CmbTipoPo.Items.AddRange(new object[] {
            "SIN ENVIAR",
            "ENVIADO",
            "CANCELADO",
            "RECIBIDO",
            "RECIBIDO PARCIALMENTE"});
            this.CmbTipoPo.Location = new System.Drawing.Point(0, 42);
            this.CmbTipoPo.Name = "CmbTipoPo";
            this.CmbTipoPo.Size = new System.Drawing.Size(226, 24);
            this.CmbTipoPo.TabIndex = 123;
            this.CmbTipoPo.SelectedIndexChanged += new System.EventHandler(this.CmbTipoPo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(0, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 21);
            this.label6.TabIndex = 122;
            this.label6.Text = "Seleccione el tipo de PO";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "POs";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnBuscarMaterial);
            this.panel3.Controls.Add(this.BtnFiltrarDatos);
            this.panel3.Controls.Add(this.BtnMetas);
            this.panel3.Controls.Add(this.BtnKpis);
            this.panel3.Controls.Add(this.BtnActualizar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1256, 73);
            this.panel3.TabIndex = 5;
            // 
            // BtnBuscarMaterial
            // 
            this.BtnBuscarMaterial.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBuscarMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarMaterial.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscarMaterial.Image")));
            this.BtnBuscarMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscarMaterial.Location = new System.Drawing.Point(615, 0);
            this.BtnBuscarMaterial.Name = "BtnBuscarMaterial";
            this.BtnBuscarMaterial.Size = new System.Drawing.Size(136, 73);
            this.BtnBuscarMaterial.TabIndex = 122;
            this.BtnBuscarMaterial.Text = "Buscar    ";
            this.BtnBuscarMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscarMaterial.UseVisualStyleBackColor = true;
            this.BtnBuscarMaterial.Click += new System.EventHandler(this.BtnBuscarMaterial_Click);
            // 
            // BtnFiltrarDatos
            // 
            this.BtnFiltrarDatos.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFiltrarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltrarDatos.Image = global::CB_Base.Properties.Resources.Filter_List_icon;
            this.BtnFiltrarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFiltrarDatos.Location = new System.Drawing.Point(751, 0);
            this.BtnFiltrarDatos.Name = "BtnFiltrarDatos";
            this.BtnFiltrarDatos.Size = new System.Drawing.Size(129, 73);
            this.BtnFiltrarDatos.TabIndex = 118;
            this.BtnFiltrarDatos.Text = "       Filtrar";
            this.BtnFiltrarDatos.UseVisualStyleBackColor = true;
            this.BtnFiltrarDatos.Click += new System.EventHandler(this.BtnFiltrarDatos_Click);
            // 
            // BtnMetas
            // 
            this.BtnMetas.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMetas.Image = global::CB_Base.Properties.Resources.marker_icon_32;
            this.BtnMetas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMetas.Location = new System.Drawing.Point(880, 0);
            this.BtnMetas.Name = "BtnMetas";
            this.BtnMetas.Size = new System.Drawing.Size(119, 73);
            this.BtnMetas.TabIndex = 117;
            this.BtnMetas.Text = "      Metas";
            this.BtnMetas.UseVisualStyleBackColor = true;
            this.BtnMetas.Click += new System.EventHandler(this.BtnMetas_Click);
            // 
            // BtnKpis
            // 
            this.BtnKpis.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnKpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnKpis.Image = global::CB_Base.Properties.Resources.polls_48;
            this.BtnKpis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKpis.Location = new System.Drawing.Point(999, 0);
            this.BtnKpis.Name = "BtnKpis";
            this.BtnKpis.Size = new System.Drawing.Size(127, 73);
            this.BtnKpis.TabIndex = 116;
            this.BtnKpis.Text = "              KPIs";
            this.BtnKpis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKpis.UseVisualStyleBackColor = true;
            this.BtnKpis.Click += new System.EventHandler(this.BtnKpis_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.update;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(1126, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(130, 73);
            this.BtnActualizar.TabIndex = 115;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BkgEnviarCorreo
            // 
            this.BkgEnviarCorreo.WorkerReportsProgress = true;
            this.BkgEnviarCorreo.WorkerSupportsCancellation = true;
            this.BkgEnviarCorreo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEnviarCorreo_DoWork);
            this.BkgEnviarCorreo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEnviarCorreo_RunWorkerCompleted);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 96);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 489);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(1020, 96);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(10, 489);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(269, 96);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(10, 489);
            this.splitter3.TabIndex = 120;
            this.splitter3.TabStop = false;
            // 
            // MenuRequisicion
            // 
            this.MenuRequisicion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveedorPreferidoToolStripMenuItem,
            this.informaciónToolStripMenuItem,
            this.cotizarMaterialToolStripMenuItem,
            this.ordenarMaterialToolStripMenuItem});
            this.MenuRequisicion.Name = "MenuRequisicion";
            this.MenuRequisicion.Size = new System.Drawing.Size(180, 92);
            // 
            // proveedorPreferidoToolStripMenuItem
            // 
            this.proveedorPreferidoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.truck_icon_48;
            this.proveedorPreferidoToolStripMenuItem.Name = "proveedorPreferidoToolStripMenuItem";
            this.proveedorPreferidoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.proveedorPreferidoToolStripMenuItem.Text = "Proveedor preferido";
            this.proveedorPreferidoToolStripMenuItem.Click += new System.EventHandler(this.proveedorPreferidoToolStripMenuItem_Click);
            // 
            // informaciónToolStripMenuItem
            // 
            this.informaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.about_icon_48;
            this.informaciónToolStripMenuItem.Name = "informaciónToolStripMenuItem";
            this.informaciónToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.informaciónToolStripMenuItem.Text = "Información";
            this.informaciónToolStripMenuItem.Click += new System.EventHandler(this.informaciónToolStripMenuItem_Click);
            // 
            // cotizarMaterialToolStripMenuItem
            // 
            this.cotizarMaterialToolStripMenuItem.Image = global::CB_Base.Properties.Resources.price;
            this.cotizarMaterialToolStripMenuItem.Name = "cotizarMaterialToolStripMenuItem";
            this.cotizarMaterialToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.cotizarMaterialToolStripMenuItem.Text = "Cotizar material";
            this.cotizarMaterialToolStripMenuItem.Click += new System.EventHandler(this.cotizarMaterialToolStripMenuItem_Click);
            // 
            // ordenarMaterialToolStripMenuItem
            // 
            this.ordenarMaterialToolStripMenuItem.Image = global::CB_Base.Properties.Resources.purchase_order;
            this.ordenarMaterialToolStripMenuItem.Name = "ordenarMaterialToolStripMenuItem";
            this.ordenarMaterialToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ordenarMaterialToolStripMenuItem.Text = "Ordenar material";
            this.ordenarMaterialToolStripMenuItem.Click += new System.EventHandler(this.ordenarMaterialToolStripMenuItem_Click);
            // 
            // MenuBusquedas
            // 
            this.MenuBusquedas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarNúmeroDeParteToolStripMenuItem,
            this.buscarDescripciónToolStripMenuItem});
            this.MenuBusquedas.Name = "MenuBusquedas";
            this.MenuBusquedas.Size = new System.Drawing.Size(217, 70);
            this.MenuBusquedas.Opening += new System.ComponentModel.CancelEventHandler(this.MenuBusquedas_Opening);
            // 
            // buscarNúmeroDeParteToolStripMenuItem
            // 
            this.buscarNúmeroDeParteToolStripMenuItem.Name = "buscarNúmeroDeParteToolStripMenuItem";
            this.buscarNúmeroDeParteToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.buscarNúmeroDeParteToolStripMenuItem.Text = "Buscar documento";
            this.buscarNúmeroDeParteToolStripMenuItem.Click += new System.EventHandler(this.buscarNúmeroDeParteToolStripMenuItem_Click);
            // 
            // buscarDescripciónToolStripMenuItem
            // 
            this.buscarDescripciónToolStripMenuItem.Name = "buscarDescripciónToolStripMenuItem";
            this.buscarDescripciónToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.buscarDescripciónToolStripMenuItem.Text = "Eliminar filtro de búsqueda";
            this.buscarDescripciónToolStripMenuItem.Click += new System.EventHandler(this.buscarDescripciónToolStripMenuItem_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(1256, 23);
            this.audiselTituloForm1.TabIndex = 118;
            this.audiselTituloForm1.Text = "MONITOR DE COMPRAS";
            // 
            // FrmMonitorCompras2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 585);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.audiselTituloForm1);
            this.IsMdiContainer = true;
            this.Name = "FrmMonitorCompras2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de compras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMonitorCompras2_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.MenuRFQ.ResumeLayout(false);
            this.MenuPo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.MenuRequisicion.ResumeLayout(false);
            this.MenuBusquedas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView TvMetas;
        private System.Windows.Forms.Button BtnKpis;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.TreeView TvRFQs;
        private System.Windows.Forms.TreeView TvPOs;
        private System.Windows.Forms.ContextMenuStrip MenuRFQ;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuPo;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem1;
        private System.Windows.Forms.ImageList ImagenLista;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.ComponentModel.BackgroundWorker BkgEnviarCorreo;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem descargarPDFToolStripMenuItem;
        private System.Windows.Forms.Button BtnMetas;
        private System.Windows.Forms.Button BtnFiltrarDatos;
        private System.Windows.Forms.ComboBox CmbTipoCompra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbTipoRfq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbTipoPo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem crearNuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearNuevoToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ContextMenuStrip MenuRequisicion;
        private System.Windows.Forms.ToolStripMenuItem proveedorPreferidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónToolStripMenuItem;
        private System.Windows.Forms.CheckBox CkbAgrupar;
        private System.Windows.Forms.Button BtnBuscarMaterial;
        private System.Windows.Forms.ContextMenuStrip MenuBusquedas;
        private System.Windows.Forms.ToolStripMenuItem buscarNúmeroDeParteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarDescripciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cotizarMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenarMaterialToolStripMenuItem;
    }
}
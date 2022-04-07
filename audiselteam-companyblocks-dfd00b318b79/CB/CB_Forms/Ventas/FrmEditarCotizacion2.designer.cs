namespace CB
{
    partial class FrmEditarCotizacion2
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Información general");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("RFQ", 13, 13);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Planos del producto", 8, 8);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Sólidos del producto", 7, 7);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Imágenes", 10, 10);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Videos", 11, 11);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Otros documentos", 12, 12);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Elementos de entrada", 6, 6, new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Alcance del proyecto", 2, 2);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Proceso de manufactura");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Módulos estándar");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Sistemas personalizados");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Resumen de costos", 14, 14);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Información general", 1, 1);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Imágenes", 10, 10);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Videos", 11, 11);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Otros documentos", 12, 12);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Elementos de entrada", 6, 6, new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Alcance del proyecto", 2, 2);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Proceso de manufactura", 3, 3);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Módulos estándar", 4, 4);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Sistemas personalizados", 5, 5);
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("023.01 - STATOR ASSY STATION", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Subproyectos", 9, 9, new System.Windows.Forms.TreeNode[] {
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("023.00 - MKC1 STATOR ASSY TEST AND LASER MARK", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode24});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarCotizacion2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TvCotizacion = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MenuRfq = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OfdSeleccionarArchivo = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.BkgSubirArchivos = new System.ComponentModel.BackgroundWorker();
            this.BkgMostrarDocumento = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarDocumento = new System.ComponentModel.BackgroundWorker();
            this.SfdGuardarArchivo = new System.Windows.Forms.SaveFileDialog();
            this.BkgEliminarDocumento = new System.ComponentModel.BackgroundWorker();
            this.MenuSolido = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subirSólidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarSólidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuModelos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarModeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarModeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgEliminarVariantes = new System.ComponentModel.BackgroundWorker();
            this.MenuComponentes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarComponenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarVarianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarComponenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVarianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerDeGrupoDeGeometriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGeometria = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarGeometriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSubensamble = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarSubensambleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarVarianteSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarSubensambleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVariantes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subirPlanoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarPlanoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.OFDSubirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BkgSubirDocumentosVariantes = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarDocumentosVariantes = new System.ComponentModel.BackgroundWorker();
            this.BkgRemoverDocumento = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.MenuRfq.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.MenuSolido.SuspendLayout();
            this.MenuModelos.SuspendLayout();
            this.MenuComponentes.SuspendLayout();
            this.MenuGeometria.SuspendLayout();
            this.MenuSubensamble.SuspendLayout();
            this.MenuVariantes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TvCotizacion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 737);
            this.panel1.TabIndex = 7;
            // 
            // TvCotizacion
            // 
            this.TvCotizacion.AllowDrop = true;
            this.TvCotizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvCotizacion.ImageIndex = 0;
            this.TvCotizacion.ImageList = this.imageList1;
            this.TvCotizacion.Location = new System.Drawing.Point(0, 0);
            this.TvCotizacion.Name = "TvCotizacion";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Node1";
            treeNode1.SelectedImageKey = "file-info-icon.png";
            treeNode1.Text = "Información general";
            treeNode2.ImageIndex = 13;
            treeNode2.Name = "Node27";
            treeNode2.SelectedImageIndex = 13;
            treeNode2.Text = "RFQ";
            treeNode3.ImageIndex = 8;
            treeNode3.Name = "Node13";
            treeNode3.SelectedImageIndex = 8;
            treeNode3.Text = "Planos del producto";
            treeNode4.ImageIndex = 7;
            treeNode4.Name = "Node15";
            treeNode4.SelectedImageIndex = 7;
            treeNode4.Text = "Sólidos del producto";
            treeNode5.ImageIndex = 10;
            treeNode5.Name = "Node16";
            treeNode5.SelectedImageIndex = 10;
            treeNode5.Text = "Imágenes";
            treeNode6.ImageIndex = 11;
            treeNode6.Name = "Node18";
            treeNode6.SelectedImageIndex = 11;
            treeNode6.Text = "Videos";
            treeNode7.ImageIndex = 12;
            treeNode7.Name = "Node19";
            treeNode7.SelectedImageIndex = 12;
            treeNode7.Text = "Otros documentos";
            treeNode8.ImageIndex = 6;
            treeNode8.Name = "Node12";
            treeNode8.SelectedImageIndex = 6;
            treeNode8.Text = "Elementos de entrada";
            treeNode9.ImageIndex = 2;
            treeNode9.Name = "Node2";
            treeNode9.SelectedImageIndex = 2;
            treeNode9.Text = "Alcance del proyecto";
            treeNode10.ImageIndex = 3;
            treeNode10.Name = "Node4";
            treeNode10.Text = "Proceso de manufactura";
            treeNode11.ImageIndex = 4;
            treeNode11.Name = "Node5";
            treeNode11.Text = "Módulos estándar";
            treeNode12.ImageIndex = 5;
            treeNode12.Name = "Node6";
            treeNode12.Text = "Sistemas personalizados";
            treeNode13.ImageIndex = 14;
            treeNode13.Name = "Node29";
            treeNode13.SelectedImageIndex = 14;
            treeNode13.Text = "Resumen de costos";
            treeNode14.ImageIndex = 1;
            treeNode14.Name = "Node26";
            treeNode14.SelectedImageIndex = 1;
            treeNode14.Text = "Información general";
            treeNode15.ImageIndex = 10;
            treeNode15.Name = "Node22";
            treeNode15.SelectedImageIndex = 10;
            treeNode15.Text = "Imágenes";
            treeNode16.ImageIndex = 11;
            treeNode16.Name = "Node23";
            treeNode16.SelectedImageIndex = 11;
            treeNode16.Text = "Videos";
            treeNode17.ImageIndex = 12;
            treeNode17.Name = "Node24";
            treeNode17.SelectedImageIndex = 12;
            treeNode17.Text = "Otros documentos";
            treeNode18.ImageIndex = 6;
            treeNode18.Name = "Node17";
            treeNode18.SelectedImageIndex = 6;
            treeNode18.Text = "Elementos de entrada";
            treeNode19.ImageIndex = 2;
            treeNode19.Name = "Node8";
            treeNode19.SelectedImageIndex = 2;
            treeNode19.Text = "Alcance del proyecto";
            treeNode20.ImageIndex = 3;
            treeNode20.Name = "Node9";
            treeNode20.SelectedImageIndex = 3;
            treeNode20.Text = "Proceso de manufactura";
            treeNode21.ImageIndex = 4;
            treeNode21.Name = "Node10";
            treeNode21.SelectedImageIndex = 4;
            treeNode21.Text = "Módulos estándar";
            treeNode22.ImageIndex = 5;
            treeNode22.Name = "Node11";
            treeNode22.SelectedImageIndex = 5;
            treeNode22.Text = "Sistemas personalizados";
            treeNode23.Name = "Node25";
            treeNode23.Text = "023.01 - STATOR ASSY STATION";
            treeNode24.ImageIndex = 9;
            treeNode24.Name = "Node7";
            treeNode24.SelectedImageIndex = 9;
            treeNode24.Text = "Subproyectos";
            treeNode25.Name = "Node0";
            treeNode25.Text = "023.00 - MKC1 STATOR ASSY TEST AND LASER MARK";
            this.TvCotizacion.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode25});
            this.TvCotizacion.SelectedImageIndex = 0;
            this.TvCotizacion.Size = new System.Drawing.Size(307, 737);
            this.TvCotizacion.TabIndex = 0;
            this.TvCotizacion.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TvCotizacion_ItemDrag);
            this.TvCotizacion.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvCotizacion_NodeMouseDoubleClick);
            this.TvCotizacion.DragDrop += new System.Windows.Forms.DragEventHandler(this.TvCotizacion_DragDrop);
            this.TvCotizacion.DragEnter += new System.Windows.Forms.DragEventHandler(this.TvCotizacion_DragEnter);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "order-history-icon.png");
            this.imageList1.Images.SetKeyName(1, "file-info-icon.png");
            this.imageList1.Images.SetKeyName(2, "help-file-icon.png");
            this.imageList1.Images.SetKeyName(3, "process.png");
            this.imageList1.Images.SetKeyName(4, "solid_assembly.png");
            this.imageList1.Images.SetKeyName(5, "custom-reports-icon.png");
            this.imageList1.Images.SetKeyName(6, "folder_24px.png");
            this.imageList1.Images.SetKeyName(7, "solidworks.png");
            this.imageList1.Images.SetKeyName(8, "pdf-48.png");
            this.imageList1.Images.SetKeyName(9, "index_48.png");
            this.imageList1.Images.SetKeyName(10, "Camera-Moto-icon.png");
            this.imageList1.Images.SetKeyName(11, "Movie-icon.png");
            this.imageList1.Images.SetKeyName(12, "Document-icon.png");
            this.imageList1.Images.SetKeyName(13, "rfq (2).png");
            this.imageList1.Images.SetKeyName(14, "Dollar-USD-icon.png");
            this.imageList1.Images.SetKeyName(15, "evaluation-48.png");
            this.imageList1.Images.SetKeyName(16, "components_48.png");
            this.imageList1.Images.SetKeyName(17, "puzzle_part_48.png");
            this.imageList1.Images.SetKeyName(18, "puzzle-48.png");
            this.imageList1.Images.SetKeyName(19, "gray-button-24.png");
            this.imageList1.Images.SetKeyName(20, "subensamble.png");
            this.imageList1.Images.SetKeyName(21, "tetris-24.png");
            this.imageList1.Images.SetKeyName(22, "order.ico");
            this.imageList1.Images.SetKeyName(23, "activities.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(307, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 737);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // MenuRfq
            // 
            this.MenuRfq.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subirToolStripMenuItem,
            this.descargarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuRfq.Name = "MenuCotizacion";
            this.MenuRfq.Size = new System.Drawing.Size(127, 70);
            // 
            // subirToolStripMenuItem
            // 
            this.subirToolStripMenuItem.Image = global::CB_Base.Properties.Resources.icono_pf_48_up;
            this.subirToolStripMenuItem.Name = "subirToolStripMenuItem";
            this.subirToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.subirToolStripMenuItem.Text = "Subir";
            this.subirToolStripMenuItem.Click += new System.EventHandler(this.subirToolStripMenuItem_Click);
            // 
            // descargarToolStripMenuItem
            // 
            this.descargarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.icono_pdf_down_48;
            this.descargarToolStripMenuItem.Name = "descargarToolStripMenuItem";
            this.descargarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.descargarToolStripMenuItem.Text = "Descargar";
            this.descargarToolStripMenuItem.Click += new System.EventHandler(this.descargarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblEstatus,
            this.Progreso});
            this.statusStrip1.Location = new System.Drawing.Point(310, 715);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1012, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblEstatus
            // 
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(44, 17);
            this.LblEstatus.Text = "estatus";
            // 
            // Progreso
            // 
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(100, 16);
            // 
            // BkgSubirArchivos
            // 
            this.BkgSubirArchivos.WorkerReportsProgress = true;
            this.BkgSubirArchivos.WorkerSupportsCancellation = true;
            this.BkgSubirArchivos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubirArchivos_DoWork);
            this.BkgSubirArchivos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubirArchivos_ProgressChanged);
            this.BkgSubirArchivos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubirArchivos_RunWorkerCompleted);
            // 
            // BkgMostrarDocumento
            // 
            this.BkgMostrarDocumento.WorkerReportsProgress = true;
            this.BkgMostrarDocumento.WorkerSupportsCancellation = true;
            this.BkgMostrarDocumento.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgMostrarDocumento_DoWork);
            this.BkgMostrarDocumento.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgMostrarDocumento_ProgressChanged);
            this.BkgMostrarDocumento.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgMostrarDocumento_RunWorkerCompleted);
            // 
            // BkgDescargarDocumento
            // 
            this.BkgDescargarDocumento.WorkerReportsProgress = true;
            this.BkgDescargarDocumento.WorkerSupportsCancellation = true;
            this.BkgDescargarDocumento.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarDocumento_DoWork);
            this.BkgDescargarDocumento.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarDocumento_ProgressChanged);
            this.BkgDescargarDocumento.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarDocumento_RunWorkerCompleted);
            // 
            // BkgEliminarDocumento
            // 
            this.BkgEliminarDocumento.WorkerReportsProgress = true;
            this.BkgEliminarDocumento.WorkerSupportsCancellation = true;
            this.BkgEliminarDocumento.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEliminarDocumento_DoWork);
            this.BkgEliminarDocumento.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgEliminarDocumento_ProgressChanged);
            this.BkgEliminarDocumento.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEliminarDocumento_RunWorkerCompleted);
            // 
            // MenuSolido
            // 
            this.MenuSolido.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuSolido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subirSólidoToolStripMenuItem,
            this.descargarSólidoToolStripMenuItem,
            this.removerToolStripMenuItem});
            this.MenuSolido.Name = "MenuVariantes";
            this.MenuSolido.Size = new System.Drawing.Size(166, 82);
            // 
            // subirSólidoToolStripMenuItem
            // 
            this.subirSólidoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.icono_stp_up_48;
            this.subirSólidoToolStripMenuItem.Name = "subirSólidoToolStripMenuItem";
            this.subirSólidoToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.subirSólidoToolStripMenuItem.Text = "Subir sólido";
            // 
            // descargarSólidoToolStripMenuItem
            // 
            this.descargarSólidoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.icono_stp_down_48;
            this.descargarSólidoToolStripMenuItem.Name = "descargarSólidoToolStripMenuItem";
            this.descargarSólidoToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.descargarSólidoToolStripMenuItem.Text = "Descargar sólido";
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Image = global::CB_Base.Properties.Resources.trash_32;
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.removerToolStripMenuItem.Text = "Remover";
            // 
            // MenuModelos
            // 
            this.MenuModelos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuModelos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarModeloToolStripMenuItem,
            this.eliminarModeloToolStripMenuItem});
            this.MenuModelos.Name = "MenuModelos";
            this.MenuModelos.Size = new System.Drawing.Size(166, 56);
            this.MenuModelos.Opening += new System.ComponentModel.CancelEventHandler(this.MenuModelos_Opening);
            // 
            // agregarModeloToolStripMenuItem
            // 
            this.agregarModeloToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarModeloToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agregarModeloToolStripMenuItem.Name = "agregarModeloToolStripMenuItem";
            this.agregarModeloToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.agregarModeloToolStripMenuItem.Text = "Agregar modelo";
            this.agregarModeloToolStripMenuItem.Click += new System.EventHandler(this.agregarModeloToolStripMenuItem_Click);
            // 
            // eliminarModeloToolStripMenuItem
            // 
            this.eliminarModeloToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarModeloToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eliminarModeloToolStripMenuItem.Name = "eliminarModeloToolStripMenuItem";
            this.eliminarModeloToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.eliminarModeloToolStripMenuItem.Text = "Eliminar modelo";
            this.eliminarModeloToolStripMenuItem.Click += new System.EventHandler(this.eliminarModeloToolStripMenuItem_Click);
            // 
            // BkgEliminarVariantes
            // 
            this.BkgEliminarVariantes.WorkerReportsProgress = true;
            this.BkgEliminarVariantes.WorkerSupportsCancellation = true;
            this.BkgEliminarVariantes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEliminarVariantes_DoWork);
            this.BkgEliminarVariantes.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgEliminarVariantes_ProgressChanged);
            this.BkgEliminarVariantes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEliminarVariantes_RunWorkerCompleted);
            // 
            // MenuComponentes
            // 
            this.MenuComponentes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuComponentes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarComponenteToolStripMenuItem,
            this.agregarVarianteToolStripMenuItem,
            this.eliminarComponenteToolStripMenuItem,
            this.eliminarVarianteToolStripMenuItem,
            this.removerDeGrupoDeGeometriaToolStripMenuItem});
            this.MenuComponentes.Name = "MenuComponentes";
            this.MenuComponentes.Size = new System.Drawing.Size(250, 134);
            this.MenuComponentes.Opening += new System.ComponentModel.CancelEventHandler(this.MenuComponentes_Opening);
            // 
            // agregarComponenteToolStripMenuItem
            // 
            this.agregarComponenteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarComponenteToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agregarComponenteToolStripMenuItem.Name = "agregarComponenteToolStripMenuItem";
            this.agregarComponenteToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.agregarComponenteToolStripMenuItem.Text = "Agregar componente";
            this.agregarComponenteToolStripMenuItem.Click += new System.EventHandler(this.agregarComponenteToolStripMenuItem_Click);
            // 
            // agregarVarianteToolStripMenuItem
            // 
            this.agregarVarianteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarVarianteToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agregarVarianteToolStripMenuItem.Name = "agregarVarianteToolStripMenuItem";
            this.agregarVarianteToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.agregarVarianteToolStripMenuItem.Text = "Agregar variante";
            this.agregarVarianteToolStripMenuItem.Click += new System.EventHandler(this.agregarVarianteToolStripMenuItem_Click);
            // 
            // eliminarComponenteToolStripMenuItem
            // 
            this.eliminarComponenteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarComponenteToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eliminarComponenteToolStripMenuItem.Name = "eliminarComponenteToolStripMenuItem";
            this.eliminarComponenteToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.eliminarComponenteToolStripMenuItem.Text = "Eliminar componente";
            this.eliminarComponenteToolStripMenuItem.Click += new System.EventHandler(this.eliminarComponenteToolStripMenuItem_Click);
            // 
            // eliminarVarianteToolStripMenuItem
            // 
            this.eliminarVarianteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarVarianteToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eliminarVarianteToolStripMenuItem.Name = "eliminarVarianteToolStripMenuItem";
            this.eliminarVarianteToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.eliminarVarianteToolStripMenuItem.Text = "Eliminar variante";
            this.eliminarVarianteToolStripMenuItem.Click += new System.EventHandler(this.eliminarVarianteToolStripMenuItem_Click);
            // 
            // removerDeGrupoDeGeometriaToolStripMenuItem
            // 
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Name = "removerDeGrupoDeGeometriaToolStripMenuItem";
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Text = "Remover de grupo de geometria";
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Click += new System.EventHandler(this.removerDeGrupoDeGeometriaToolStripMenuItem_Click);
            // 
            // MenuGeometria
            // 
            this.MenuGeometria.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuGeometria.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarGeometriaToolStripMenuItem});
            this.MenuGeometria.Name = "MenuGeometria";
            this.MenuGeometria.Size = new System.Drawing.Size(179, 30);
            // 
            // eliminarGeometriaToolStripMenuItem
            // 
            this.eliminarGeometriaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarGeometriaToolStripMenuItem.Name = "eliminarGeometriaToolStripMenuItem";
            this.eliminarGeometriaToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.eliminarGeometriaToolStripMenuItem.Text = "Eliminar geometria";
            this.eliminarGeometriaToolStripMenuItem.Click += new System.EventHandler(this.eliminarGeometriaToolStripMenuItem_Click);
            // 
            // MenuSubensamble
            // 
            this.MenuSubensamble.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuSubensamble.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarSubensambleToolStripMenuItem,
            this.agregarVarianteSubToolStripMenuItem,
            this.eliminarSubensambleToolStripMenuItem});
            this.MenuSubensamble.Name = "contextMenuStrip1";
            this.MenuSubensamble.Size = new System.Drawing.Size(195, 82);
            this.MenuSubensamble.Opening += new System.ComponentModel.CancelEventHandler(this.MenuSubensamble_Opening);
            // 
            // agregarSubensambleToolStripMenuItem
            // 
            this.agregarSubensambleToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarSubensambleToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agregarSubensambleToolStripMenuItem.Name = "agregarSubensambleToolStripMenuItem";
            this.agregarSubensambleToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.agregarSubensambleToolStripMenuItem.Text = "Agregar subensamble";
            this.agregarSubensambleToolStripMenuItem.Click += new System.EventHandler(this.agregarSubensambleToolStripMenuItem_Click);
            // 
            // agregarVarianteSubToolStripMenuItem
            // 
            this.agregarVarianteSubToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarVarianteSubToolStripMenuItem.Name = "agregarVarianteSubToolStripMenuItem";
            this.agregarVarianteSubToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.agregarVarianteSubToolStripMenuItem.Text = "Agregar variante";
            this.agregarVarianteSubToolStripMenuItem.Click += new System.EventHandler(this.agregarVarianteSubToolStripMenuItem_Click);
            // 
            // eliminarSubensambleToolStripMenuItem
            // 
            this.eliminarSubensambleToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarSubensambleToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eliminarSubensambleToolStripMenuItem.Name = "eliminarSubensambleToolStripMenuItem";
            this.eliminarSubensambleToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.eliminarSubensambleToolStripMenuItem.Text = "Eliminar subensamble";
            this.eliminarSubensambleToolStripMenuItem.Click += new System.EventHandler(this.eliminarSubensambleToolStripMenuItem_Click);
            // 
            // MenuVariantes
            // 
            this.MenuVariantes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuVariantes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subirPlanoToolStripMenuItem,
            this.descargarPlanoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.MenuVariantes.Name = "MenuVariantes";
            this.MenuVariantes.Size = new System.Drawing.Size(166, 134);
            this.MenuVariantes.Opening += new System.ComponentModel.CancelEventHandler(this.MenuVariantes_Opening);
            // 
            // subirPlanoToolStripMenuItem
            // 
            this.subirPlanoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.icono_pf_48_up;
            this.subirPlanoToolStripMenuItem.Name = "subirPlanoToolStripMenuItem";
            this.subirPlanoToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.subirPlanoToolStripMenuItem.Text = "Subir plano";
            this.subirPlanoToolStripMenuItem.Click += new System.EventHandler(this.subirPlanoToolStripMenuItem_Click);
            // 
            // descargarPlanoToolStripMenuItem
            // 
            this.descargarPlanoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.icono_pdf_down_48;
            this.descargarPlanoToolStripMenuItem.Name = "descargarPlanoToolStripMenuItem";
            this.descargarPlanoToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.descargarPlanoToolStripMenuItem.Text = "Descargar plano";
            this.descargarPlanoToolStripMenuItem.Click += new System.EventHandler(this.descargarPlanoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::CB_Base.Properties.Resources.icono_stp_up_48;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 26);
            this.toolStripMenuItem1.Text = "Subir sólido";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::CB_Base.Properties.Resources.icono_stp_down_48;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 26);
            this.toolStripMenuItem2.Text = "Descargar sólido";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::CB_Base.Properties.Resources.trash_32;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(165, 26);
            this.toolStripMenuItem3.Text = "Remover";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // OFDSubirArchivo
            // 
            this.OFDSubirArchivo.FileName = "openFileDialog1";
            // 
            // BkgSubirDocumentosVariantes
            // 
            this.BkgSubirDocumentosVariantes.WorkerReportsProgress = true;
            this.BkgSubirDocumentosVariantes.WorkerSupportsCancellation = true;
            this.BkgSubirDocumentosVariantes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubirDocumentosVariantes_DoWork);
            this.BkgSubirDocumentosVariantes.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubirDocumentosVariantes_ProgressChanged);
            this.BkgSubirDocumentosVariantes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubirDocumentosVariantes_RunWorkerCompleted);
            // 
            // BkgDescargarDocumentosVariantes
            // 
            this.BkgDescargarDocumentosVariantes.WorkerReportsProgress = true;
            this.BkgDescargarDocumentosVariantes.WorkerSupportsCancellation = true;
            this.BkgDescargarDocumentosVariantes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarDocumentosVariantes_DoWork);
            this.BkgDescargarDocumentosVariantes.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarDocumentosVariantes_ProgressChanged);
            this.BkgDescargarDocumentosVariantes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarDocumentosVariantes_RunWorkerCompleted);
            // 
            // BkgRemoverDocumento
            // 
            this.BkgRemoverDocumento.WorkerReportsProgress = true;
            this.BkgRemoverDocumento.WorkerSupportsCancellation = true;
            this.BkgRemoverDocumento.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgRemoverDocumento_DoWork);
            this.BkgRemoverDocumento.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgRemoverDocumento_ProgressChanged);
            this.BkgRemoverDocumento.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgRemoverDocumento_RunWorkerCompleted);
            // 
            // FrmEditarCotizacion2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 737);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "FrmEditarCotizacion2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar cotización";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEditarCotizacion2_Load);
            this.panel1.ResumeLayout(false);
            this.MenuRfq.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MenuSolido.ResumeLayout(false);
            this.MenuModelos.ResumeLayout(false);
            this.MenuComponentes.ResumeLayout(false);
            this.MenuGeometria.ResumeLayout(false);
            this.MenuSubensamble.ResumeLayout(false);
            this.MenuVariantes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView TvCotizacion;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip MenuRfq;
        private System.Windows.Forms.OpenFileDialog OfdSeleccionarArchivo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblEstatus;
        private System.Windows.Forms.ToolStripProgressBar Progreso;
        private System.ComponentModel.BackgroundWorker BkgSubirArchivos;
        private System.ComponentModel.BackgroundWorker BkgMostrarDocumento;
        private System.Windows.Forms.ToolStripMenuItem subirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgDescargarDocumento;
        private System.Windows.Forms.SaveFileDialog SfdGuardarArchivo;
        private System.ComponentModel.BackgroundWorker BkgEliminarDocumento;
        private System.Windows.Forms.ContextMenuStrip MenuSolido;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subirSólidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descargarSólidoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuModelos;
        private System.Windows.Forms.ToolStripMenuItem agregarModeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarModeloToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgEliminarVariantes;
        private System.Windows.Forms.ContextMenuStrip MenuComponentes;
        private System.Windows.Forms.ToolStripMenuItem agregarComponenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarVarianteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarComponenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarVarianteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerDeGrupoDeGeometriaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuGeometria;
        private System.Windows.Forms.ToolStripMenuItem eliminarGeometriaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuSubensamble;
        private System.Windows.Forms.ToolStripMenuItem agregarSubensambleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarVarianteSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarSubensambleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuVariantes;
        private System.Windows.Forms.ToolStripMenuItem subirPlanoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descargarPlanoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.OpenFileDialog OFDSubirArchivo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker BkgSubirDocumentosVariantes;
        private System.ComponentModel.BackgroundWorker BkgDescargarDocumentosVariantes;
        private System.ComponentModel.BackgroundWorker BkgRemoverDocumento;
    }
}
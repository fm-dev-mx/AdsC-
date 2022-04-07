namespace CB
{
    partial class FrmRegistroProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistroProducto));
            this.CmbCliente = new System.Windows.Forms.ComboBox();
            this.CmbIndustria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TvProductos = new System.Windows.Forms.TreeView();
            this.Imagen = new System.Windows.Forms.ImageList(this.components);
            this.MenuProductos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarNuevoProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuModelos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarModeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarModeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuComponentes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarComponenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarVarianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarComponenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVarianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerDeGrupoDeGeometriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSubensamble = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarSubensambleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarVarianteSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarSubensambleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGeometria = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarGeometriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVariantes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subirPlanoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarPlanoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subirSólidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarSólidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BkgDescargarDocumento = new System.ComponentModel.BackgroundWorker();
            this.OFDSubirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.BkgSubirArchivo = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.LblEstatusResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BkgMostrarContenido = new System.ComponentModel.BackgroundWorker();
            this.BkgRemoverDocumento = new System.ComponentModel.BackgroundWorker();
            this.BkgEliminarVariantes = new System.ComponentModel.BackgroundWorker();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.MenuProductos.SuspendLayout();
            this.MenuModelos.SuspendLayout();
            this.MenuComponentes.SuspendLayout();
            this.MenuSubensamble.SuspendLayout();
            this.MenuGeometria.SuspendLayout();
            this.MenuVariantes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbCliente
            // 
            this.CmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCliente.FormattingEnabled = true;
            this.CmbCliente.Location = new System.Drawing.Point(6, 18);
            this.CmbCliente.Name = "CmbCliente";
            this.CmbCliente.Size = new System.Drawing.Size(344, 28);
            this.CmbCliente.TabIndex = 1;
            this.CmbCliente.SelectedIndexChanged += new System.EventHandler(this.CmbCliente_SelectedIndexChanged);
            // 
            // CmbIndustria
            // 
            this.CmbIndustria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbIndustria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIndustria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbIndustria.FormattingEnabled = true;
            this.CmbIndustria.Location = new System.Drawing.Point(356, 19);
            this.CmbIndustria.Name = "CmbIndustria";
            this.CmbIndustria.Size = new System.Drawing.Size(344, 28);
            this.CmbIndustria.TabIndex = 2;
            this.CmbIndustria.SelectedIndexChanged += new System.EventHandler(this.CmbIndustria_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(355, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Industria:";
            // 
            // TvProductos
            // 
            this.TvProductos.AllowDrop = true;
            this.TvProductos.Dock = System.Windows.Forms.DockStyle.Left;
            this.TvProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TvProductos.ImageIndex = 0;
            this.TvProductos.ImageList = this.Imagen;
            this.TvProductos.Location = new System.Drawing.Point(0, 73);
            this.TvProductos.Name = "TvProductos";
            this.TvProductos.SelectedImageIndex = 0;
            this.TvProductos.Size = new System.Drawing.Size(352, 524);
            this.TvProductos.TabIndex = 5;
            this.TvProductos.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TvProductos_AfterCollapse);
            this.TvProductos.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvProductos_BeforeExpand);
            this.TvProductos.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TvProducto_ItemDrag);
            this.TvProductos.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvProductos_NodeMouseClick);
            this.TvProductos.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvProductos_NodeMouseDoubleClick);
            this.TvProductos.DragDrop += new System.Windows.Forms.DragEventHandler(this.TvProducto_DragDrop);
            this.TvProductos.DragEnter += new System.Windows.Forms.DragEventHandler(this.TvProducto_DragEnter);
            // 
            // Imagen
            // 
            this.Imagen.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Imagen.ImageStream")));
            this.Imagen.TransparentColor = System.Drawing.Color.Transparent;
            this.Imagen.Images.SetKeyName(0, "index_48.png");
            this.Imagen.Images.SetKeyName(1, "pieza_comprada.png");
            this.Imagen.Images.SetKeyName(2, "evaluation-48.png");
            this.Imagen.Images.SetKeyName(3, "components_48.png");
            this.Imagen.Images.SetKeyName(4, "subensamble.png");
            this.Imagen.Images.SetKeyName(5, "gray-button-24.png");
            this.Imagen.Images.SetKeyName(6, "puzzle_part_48.png");
            this.Imagen.Images.SetKeyName(7, "puzzle-48.png");
            this.Imagen.Images.SetKeyName(8, "order.ico");
            this.Imagen.Images.SetKeyName(9, "pdf-48.png");
            this.Imagen.Images.SetKeyName(10, "solidworks.png");
            // 
            // MenuProductos
            // 
            this.MenuProductos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarNuevoProductoToolStripMenuItem,
            this.eliminarProductoToolStripMenuItem});
            this.MenuProductos.Name = "MenuProductos";
            this.MenuProductos.Size = new System.Drawing.Size(209, 56);
            this.MenuProductos.Opening += new System.ComponentModel.CancelEventHandler(this.MenuProductos_Opening);
            // 
            // agregarNuevoProductoToolStripMenuItem
            // 
            this.agregarNuevoProductoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarNuevoProductoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agregarNuevoProductoToolStripMenuItem.Name = "agregarNuevoProductoToolStripMenuItem";
            this.agregarNuevoProductoToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.agregarNuevoProductoToolStripMenuItem.Text = "Agregar nuevo producto";
            this.agregarNuevoProductoToolStripMenuItem.Click += new System.EventHandler(this.agregarNuevoProductoToolStripMenuItem_Click);
            // 
            // eliminarProductoToolStripMenuItem
            // 
            this.eliminarProductoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarProductoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            this.eliminarProductoToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.eliminarProductoToolStripMenuItem.Text = "Eliminar producto";
            this.eliminarProductoToolStripMenuItem.Click += new System.EventHandler(this.eliminarProductoToolStripMenuItem_Click);
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
            this.eliminarVarianteToolStripMenuItem.Click += new System.EventHandler(this.eliminarVarianteToolStripMenuItem_Click_1);
            // 
            // removerDeGrupoDeGeometriaToolStripMenuItem
            // 
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Name = "removerDeGrupoDeGeometriaToolStripMenuItem";
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Text = "Remover de grupo de geometria";
            this.removerDeGrupoDeGeometriaToolStripMenuItem.Click += new System.EventHandler(this.removerDeGrupoDeGeometriaToolStripMenuItem_Click);
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
            // MenuVariantes
            // 
            this.MenuVariantes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuVariantes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subirPlanoToolStripMenuItem,
            this.descargarPlanoToolStripMenuItem,
            this.subirSólidoToolStripMenuItem,
            this.descargarSólidoToolStripMenuItem,
            this.removerToolStripMenuItem});
            this.MenuVariantes.Name = "MenuVariantes";
            this.MenuVariantes.Size = new System.Drawing.Size(166, 156);
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
            // subirSólidoToolStripMenuItem
            // 
            this.subirSólidoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.icono_stp_up_48;
            this.subirSólidoToolStripMenuItem.Name = "subirSólidoToolStripMenuItem";
            this.subirSólidoToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.subirSólidoToolStripMenuItem.Text = "Subir sólido";
            this.subirSólidoToolStripMenuItem.Click += new System.EventHandler(this.subirSólidoToolStripMenuItem_Click);
            // 
            // descargarSólidoToolStripMenuItem
            // 
            this.descargarSólidoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.icono_stp_down_48;
            this.descargarSólidoToolStripMenuItem.Name = "descargarSólidoToolStripMenuItem";
            this.descargarSólidoToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.descargarSólidoToolStripMenuItem.Text = "Descargar sólido";
            this.descargarSólidoToolStripMenuItem.Click += new System.EventHandler(this.descargarSólidoToolStripMenuItem_Click);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Image = global::CB_Base.Properties.Resources.trash_32;
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbCliente);
            this.panel1.Controls.Add(this.CmbIndustria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 50);
            this.panel1.TabIndex = 8;
            // 
            // BkgDescargarDocumento
            // 
            this.BkgDescargarDocumento.WorkerReportsProgress = true;
            this.BkgDescargarDocumento.WorkerSupportsCancellation = true;
            this.BkgDescargarDocumento.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPlano_DoWork);
            this.BkgDescargarDocumento.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarDocumento_ProgressChanged);
            this.BkgDescargarDocumento.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarDocumento_RunWorkerCompleted);
            // 
            // OFDSubirArchivo
            // 
            this.OFDSubirArchivo.FileName = "openFileDialog1";
            // 
            // BkgSubirArchivo
            // 
            this.BkgSubirArchivo.WorkerReportsProgress = true;
            this.BkgSubirArchivo.WorkerSupportsCancellation = true;
            this.BkgSubirArchivo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubirArchivo_DoWork);
            this.BkgSubirArchivo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubirArchivo_ProgressChanged);
            this.BkgSubirArchivo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubirArchivo_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblEstatus,
            this.Progress,
            this.LblEstatusResultado});
            this.statusStrip1.Location = new System.Drawing.Point(352, 575);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(507, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblEstatus
            // 
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(141, 17);
            this.LblEstatus.Text = "Descargando documento";
            // 
            // Progress
            // 
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 16);
            // 
            // LblEstatusResultado
            // 
            this.LblEstatusResultado.BackColor = System.Drawing.Color.LimeGreen;
            this.LblEstatusResultado.Name = "LblEstatusResultado";
            this.LblEstatusResultado.Size = new System.Drawing.Size(0, 17);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(352, 73);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 502);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // BkgMostrarContenido
            // 
            this.BkgMostrarContenido.WorkerReportsProgress = true;
            this.BkgMostrarContenido.WorkerSupportsCancellation = true;
            this.BkgMostrarContenido.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgMostrarContenido_DoWork);
            this.BkgMostrarContenido.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgMostrarContenido_ProgressChanged);
            this.BkgMostrarContenido.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgMostrarContenido_RunWorkerCompleted);
            // 
            // BkgRemoverDocumento
            // 
            this.BkgRemoverDocumento.WorkerReportsProgress = true;
            this.BkgRemoverDocumento.WorkerSupportsCancellation = true;
            this.BkgRemoverDocumento.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgRemoverDocumento_DoWork);
            this.BkgRemoverDocumento.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgRemoverDocumento_ProgressChanged);
            this.BkgRemoverDocumento.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgRemoverDocumento_RunWorkerCompleted);
            // 
            // BkgEliminarVariantes
            // 
            this.BkgEliminarVariantes.WorkerReportsProgress = true;
            this.BkgEliminarVariantes.WorkerSupportsCancellation = true;
            this.BkgEliminarVariantes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEliminarVariantes_DoWork);
            this.BkgEliminarVariantes.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgEliminarVariantes_ProgressChanged);
            this.BkgEliminarVariantes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEliminarVariantes_RunWorkerCompleted);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(859, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "ADMINISTRAR PRODUCTOS";
            // 
            // FrmRegistroProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 597);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TvProductos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.IsMdiContainer = true;
            this.Name = "FrmRegistroProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Producto";
            this.Load += new System.EventHandler(this.FrmRegistroProducto_Load);
            this.MenuProductos.ResumeLayout(false);
            this.MenuModelos.ResumeLayout(false);
            this.MenuComponentes.ResumeLayout(false);
            this.MenuSubensamble.ResumeLayout(false);
            this.MenuGeometria.ResumeLayout(false);
            this.MenuVariantes.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.ComboBox CmbCliente;
        private System.Windows.Forms.ComboBox CmbIndustria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView TvProductos;
        private System.Windows.Forms.ContextMenuStrip MenuProductos;
        private System.Windows.Forms.ToolStripMenuItem agregarNuevoProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarProductoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuModelos;
        private System.Windows.Forms.ToolStripMenuItem agregarModeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarModeloToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuComponentes;
        private System.Windows.Forms.ContextMenuStrip MenuSubensamble;
        private System.Windows.Forms.ToolStripMenuItem agregarComponenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarComponenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarSubensambleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarSubensambleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarVarianteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarVarianteToolStripMenuItem;
        private System.Windows.Forms.ImageList Imagen;
        private System.Windows.Forms.ToolStripMenuItem removerDeGrupoDeGeometriaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuGeometria;
        private System.Windows.Forms.ToolStripMenuItem eliminarGeometriaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuVariantes;
        private System.Windows.Forms.ToolStripMenuItem subirPlanoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descargarPlanoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subirSólidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descargarSólidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker BkgDescargarDocumento;
        private System.Windows.Forms.OpenFileDialog OFDSubirArchivo;
        private System.ComponentModel.BackgroundWorker BkgSubirArchivo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblEstatus;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private System.Windows.Forms.ToolStripStatusLabel LblEstatusResultado;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker BkgMostrarContenido;
        private System.ComponentModel.BackgroundWorker BkgRemoverDocumento;
        private System.ComponentModel.BackgroundWorker BkgEliminarVariantes;
        private System.Windows.Forms.ToolStripMenuItem agregarVarianteSubToolStripMenuItem;
    }
}
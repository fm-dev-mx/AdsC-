namespace CB
{
    partial class FrmPrincipal
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.PanelArbolProyecto = new System.Windows.Forms.Panel();
            this.TvArbolProyecto = new System.Windows.Forms.TreeView();
            this.ImagenesArbolProyecto = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNuevoProyecto = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProyectoCargar = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fabricantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdministrarProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.rHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdministrarRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.competenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdministrarUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tiempoExtraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCatalogoMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogoDeMaterialviejoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogoDeMaterialnuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogoDePartesEstandarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscelaneosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.búsquedaDeNúmeroDeParteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.búsquedaDeRequisiciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDePOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restringirNúmeroDeParteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMonitorAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMonitorCalidad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMonitorCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.fabricaciónviejoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMonitoresFabricacion = new System.Windows.Forms.ToolStripMenuItem();
            this.finanzasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMonitorEnsamble = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMonitorMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMonitorRecursosHumanos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMonitorServicioCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeCalidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblEstatusPrincipal = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnNotificaciones = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuSubproyectos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliinarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlNotificaciones = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PanelArbolProyecto.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.MenuSubproyectos.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelArbolProyecto
            // 
            this.PanelArbolProyecto.Controls.Add(this.TvArbolProyecto);
            this.PanelArbolProyecto.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelArbolProyecto.Location = new System.Drawing.Point(0, 24);
            this.PanelArbolProyecto.Name = "PanelArbolProyecto";
            this.PanelArbolProyecto.Size = new System.Drawing.Size(232, 361);
            this.PanelArbolProyecto.TabIndex = 0;
            this.PanelArbolProyecto.Visible = false;
            // 
            // TvArbolProyecto
            // 
            this.TvArbolProyecto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvArbolProyecto.ImageIndex = 0;
            this.TvArbolProyecto.ImageList = this.ImagenesArbolProyecto;
            this.TvArbolProyecto.Indent = 15;
            this.TvArbolProyecto.Location = new System.Drawing.Point(0, 0);
            this.TvArbolProyecto.Name = "TvArbolProyecto";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            this.TvArbolProyecto.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.TvArbolProyecto.SelectedImageIndex = 0;
            this.TvArbolProyecto.Size = new System.Drawing.Size(232, 361);
            this.TvArbolProyecto.TabIndex = 0;
            this.TvArbolProyecto.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvArbolProyecto_AfterSelect);
            this.TvArbolProyecto.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvArbolProyecto_NodeMouseClick);
            this.TvArbolProyecto.DoubleClick += new System.EventHandler(this.TvArbolProyecto_DoubleClick);
            // 
            // ImagenesArbolProyecto
            // 
            this.ImagenesArbolProyecto.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesArbolProyecto.ImageStream")));
            this.ImagenesArbolProyecto.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesArbolProyecto.Images.SetKeyName(0, "Xcode-01.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(1, "icons8-Folder Tree-48.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(2, "512px-Icons8_flat_folder.svg.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(3, "swdwg.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(4, "manu-prod.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(5, "red-list-ingredients-24.ico");
            this.ImagenesArbolProyecto.Images.SetKeyName(6, "solid_assembly.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(7, "product-icon.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(8, "bug-icon.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(9, "solidworks.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(10, "update-24.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(11, "change-24.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(12, "clock-32.png");
            this.ImagenesArbolProyecto.Images.SetKeyName(13, "order.ico");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(232, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 361);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectoToolStripMenuItem,
            this.inicioToolStripMenuItem,
            this.administrarToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.monitoresToolStripMenuItem,
            this.informaciToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(949, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNuevoProyecto,
            this.MenuProyectoCargar,
            this.cerrarToolStripMenuItem});
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            this.proyectoToolStripMenuItem.DropDownOpening += new System.EventHandler(this.proyectoToolStripMenuItem_DropDownOpening);
            // 
            // MenuNuevoProyecto
            // 
            this.MenuNuevoProyecto.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.MenuNuevoProyecto.Name = "MenuNuevoProyecto";
            this.MenuNuevoProyecto.Size = new System.Drawing.Size(109, 22);
            this.MenuNuevoProyecto.Text = "Nuevo";
            this.MenuNuevoProyecto.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // MenuProyectoCargar
            // 
            this.MenuProyectoCargar.Image = global::CB_Base.Properties.Resources.search_icon_48;
            this.MenuProyectoCargar.Name = "MenuProyectoCargar";
            this.MenuProyectoCargar.Size = new System.Drawing.Size(109, 22);
            this.MenuProyectoCargar.Text = "Buscar";
            this.MenuProyectoCargar.Click += new System.EventHandler(this.MenuProyectoCargar_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.fabricantesToolStripMenuItem,
            this.productoToolStripMenuItem,
            this.MenuAdministrarProveedores,
            this.rHToolStripMenuItem,
            this.tiempoExtraToolStripMenuItem});
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.administrarToolStripMenuItem.Text = "Administrar";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click_1);
            // 
            // fabricantesToolStripMenuItem
            // 
            this.fabricantesToolStripMenuItem.Name = "fabricantesToolStripMenuItem";
            this.fabricantesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.fabricantesToolStripMenuItem.Text = "Fabricantes";
            this.fabricantesToolStripMenuItem.Click += new System.EventHandler(this.fabricantesToolStripMenuItem_Click);
            // 
            // productoToolStripMenuItem
            // 
            this.productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            this.productoToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.productoToolStripMenuItem.Text = "Producto";
            this.productoToolStripMenuItem.Visible = false;
            this.productoToolStripMenuItem.Click += new System.EventHandler(this.productoToolStripMenuItem_Click);
            // 
            // MenuAdministrarProveedores
            // 
            this.MenuAdministrarProveedores.Name = "MenuAdministrarProveedores";
            this.MenuAdministrarProveedores.Size = new System.Drawing.Size(143, 22);
            this.MenuAdministrarProveedores.Text = "Proveedores";
            this.MenuAdministrarProveedores.Click += new System.EventHandler(this.MenuAdministrarProveedores_Click);
            // 
            // rHToolStripMenuItem
            // 
            this.rHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puestosToolStripMenuItem,
            this.MenuAdministrarRoles,
            this.competenciasToolStripMenuItem,
            this.MenuAdministrarUsuarios});
            this.rHToolStripMenuItem.Name = "rHToolStripMenuItem";
            this.rHToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.rHToolStripMenuItem.Text = "RH";
            // 
            // puestosToolStripMenuItem
            // 
            this.puestosToolStripMenuItem.Name = "puestosToolStripMenuItem";
            this.puestosToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.puestosToolStripMenuItem.Text = "Puestos";
            this.puestosToolStripMenuItem.Click += new System.EventHandler(this.puestosToolStripMenuItem_Click);
            // 
            // MenuAdministrarRoles
            // 
            this.MenuAdministrarRoles.Name = "MenuAdministrarRoles";
            this.MenuAdministrarRoles.Size = new System.Drawing.Size(150, 22);
            this.MenuAdministrarRoles.Text = "Roles";
            this.MenuAdministrarRoles.Click += new System.EventHandler(this.MenuAdministrarRoles_Click);
            // 
            // competenciasToolStripMenuItem
            // 
            this.competenciasToolStripMenuItem.Name = "competenciasToolStripMenuItem";
            this.competenciasToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.competenciasToolStripMenuItem.Text = "Competencias";
            this.competenciasToolStripMenuItem.Click += new System.EventHandler(this.competenciasToolStripMenuItem_Click);
            // 
            // MenuAdministrarUsuarios
            // 
            this.MenuAdministrarUsuarios.Name = "MenuAdministrarUsuarios";
            this.MenuAdministrarUsuarios.Size = new System.Drawing.Size(150, 22);
            this.MenuAdministrarUsuarios.Text = "Usuarios";
            this.MenuAdministrarUsuarios.Click += new System.EventHandler(this.MenuAdministrarUsuarios_Click);
            // 
            // tiempoExtraToolStripMenuItem
            // 
            this.tiempoExtraToolStripMenuItem.Name = "tiempoExtraToolStripMenuItem";
            this.tiempoExtraToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.tiempoExtraToolStripMenuItem.Text = "Tiempo extra";
            this.tiempoExtraToolStripMenuItem.Click += new System.EventHandler(this.tiempoExtraToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCatalogoMaterial,
            this.miscelaneosToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // MenuCatalogoMaterial
            // 
            this.MenuCatalogoMaterial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catálogoDeMaterialviejoToolStripMenuItem,
            this.catálogoDeMaterialnuevoToolStripMenuItem,
            this.catálogoDePartesEstandarToolStripMenuItem});
            this.MenuCatalogoMaterial.Name = "MenuCatalogoMaterial";
            this.MenuCatalogoMaterial.Size = new System.Drawing.Size(184, 22);
            this.MenuCatalogoMaterial.Text = "Catálogo de material";
            this.MenuCatalogoMaterial.Click += new System.EventHandler(this.MenuCatalogoMaterial_Click);
            // 
            // catálogoDeMaterialviejoToolStripMenuItem
            // 
            this.catálogoDeMaterialviejoToolStripMenuItem.Name = "catálogoDeMaterialviejoToolStripMenuItem";
            this.catálogoDeMaterialviejoToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.catálogoDeMaterialviejoToolStripMenuItem.Text = "Catálogo de material (viejo)";
            this.catálogoDeMaterialviejoToolStripMenuItem.Click += new System.EventHandler(this.catálogoDeMaterialviejoToolStripMenuItem_Click);
            // 
            // catálogoDeMaterialnuevoToolStripMenuItem
            // 
            this.catálogoDeMaterialnuevoToolStripMenuItem.Name = "catálogoDeMaterialnuevoToolStripMenuItem";
            this.catálogoDeMaterialnuevoToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.catálogoDeMaterialnuevoToolStripMenuItem.Text = "Catálogo de material (nuevo)";
            this.catálogoDeMaterialnuevoToolStripMenuItem.Click += new System.EventHandler(this.catálogoDeMaterialnuevoToolStripMenuItem_Click);
            // 
            // catálogoDePartesEstandarToolStripMenuItem
            // 
            this.catálogoDePartesEstandarToolStripMenuItem.Name = "catálogoDePartesEstandarToolStripMenuItem";
            this.catálogoDePartesEstandarToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.catálogoDePartesEstandarToolStripMenuItem.Text = "Catálogo de partes estandar";
            this.catálogoDePartesEstandarToolStripMenuItem.Click += new System.EventHandler(this.catálogoDePartesEstandarToolStripMenuItem_Click);
            // 
            // miscelaneosToolStripMenuItem
            // 
            this.miscelaneosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarioToolStripMenuItem1,
            this.configuraciónToolStripMenuItem,
            this.búsquedaDeNúmeroDeParteToolStripMenuItem,
            this.búsquedaDeRequisiciónToolStripMenuItem,
            this.toolStripMenuItem1,
            this.reporteDePOToolStripMenuItem,
            this.restringirNúmeroDeParteToolStripMenuItem});
            this.miscelaneosToolStripMenuItem.Name = "miscelaneosToolStripMenuItem";
            this.miscelaneosToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.miscelaneosToolStripMenuItem.Text = "Miscelaneos";
            // 
            // calendarioToolStripMenuItem1
            // 
            this.calendarioToolStripMenuItem1.Name = "calendarioToolStripMenuItem1";
            this.calendarioToolStripMenuItem1.Size = new System.Drawing.Size(233, 22);
            this.calendarioToolStripMenuItem1.Text = "Calendario";
            this.calendarioToolStripMenuItem1.Click += new System.EventHandler(this.calendarioToolStripMenuItem1_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.configuraciónToolStripMenuItem.Text = "Correo";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click_1);
            // 
            // búsquedaDeNúmeroDeParteToolStripMenuItem
            // 
            this.búsquedaDeNúmeroDeParteToolStripMenuItem.Name = "búsquedaDeNúmeroDeParteToolStripMenuItem";
            this.búsquedaDeNúmeroDeParteToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.búsquedaDeNúmeroDeParteToolStripMenuItem.Text = "Búsqueda de número de parte";
            this.búsquedaDeNúmeroDeParteToolStripMenuItem.Click += new System.EventHandler(this.búsquedaDeNúmeroDeParteToolStripMenuItem_Click);
            // 
            // búsquedaDeRequisiciónToolStripMenuItem
            // 
            this.búsquedaDeRequisiciónToolStripMenuItem.Name = "búsquedaDeRequisiciónToolStripMenuItem";
            this.búsquedaDeRequisiciónToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.búsquedaDeRequisiciónToolStripMenuItem.Text = "Búsqueda de requisición";
            this.búsquedaDeRequisiciónToolStripMenuItem.Click += new System.EventHandler(this.búsquedaDeRequisiciónToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(233, 22);
            this.toolStripMenuItem1.Text = "Resumen de pendientes";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.resumenDePendientesToolStripMenuItem_Click);
            // 
            // reporteDePOToolStripMenuItem
            // 
            this.reporteDePOToolStripMenuItem.Name = "reporteDePOToolStripMenuItem";
            this.reporteDePOToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.reporteDePOToolStripMenuItem.Text = "Reporte de PO";
            this.reporteDePOToolStripMenuItem.Click += new System.EventHandler(this.reporteDePOToolStripMenuItem_Click);
            // 
            // restringirNúmeroDeParteToolStripMenuItem
            // 
            this.restringirNúmeroDeParteToolStripMenuItem.Name = "restringirNúmeroDeParteToolStripMenuItem";
            this.restringirNúmeroDeParteToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.restringirNúmeroDeParteToolStripMenuItem.Text = "Restringir número de parte";
            this.restringirNúmeroDeParteToolStripMenuItem.Click += new System.EventHandler(this.restringirNúmeroDeParteToolStripMenuItem_Click);
            // 
            // monitoresToolStripMenuItem
            // 
            this.monitoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMonitorAlmacen,
            this.MenuMonitorCalidad,
            this.MenuMonitorCompras,
            this.fabricaciónviejoToolStripMenuItem,
            this.MenuMonitoresFabricacion,
            this.finanzasToolStripMenuItem,
            this.MenuMonitorEnsamble,
            this.MenuMonitorMantenimiento,
            this.procesosToolStripMenuItem,
            this.MenuMonitorRecursosHumanos,
            this.MenuMonitorServicioCliente,
            this.sistemasToolStripMenuItem,
            this.ventasToolStripMenuItem});
            this.monitoresToolStripMenuItem.Name = "monitoresToolStripMenuItem";
            this.monitoresToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.monitoresToolStripMenuItem.Text = "Monitores";
            // 
            // MenuMonitorAlmacen
            // 
            this.MenuMonitorAlmacen.Name = "MenuMonitorAlmacen";
            this.MenuMonitorAlmacen.Size = new System.Drawing.Size(176, 22);
            this.MenuMonitorAlmacen.Text = "Almacén";
            this.MenuMonitorAlmacen.Click += new System.EventHandler(this.MenuMonitorAlmacen_Click);
            // 
            // MenuMonitorCalidad
            // 
            this.MenuMonitorCalidad.Name = "MenuMonitorCalidad";
            this.MenuMonitorCalidad.Size = new System.Drawing.Size(176, 22);
            this.MenuMonitorCalidad.Text = "Calidad";
            this.MenuMonitorCalidad.Click += new System.EventHandler(this.calidadToolStripMenuItem_Click);
            // 
            // MenuMonitorCompras
            // 
            this.MenuMonitorCompras.Enabled = false;
            this.MenuMonitorCompras.Name = "MenuMonitorCompras";
            this.MenuMonitorCompras.Size = new System.Drawing.Size(176, 22);
            this.MenuMonitorCompras.Text = "Compras";
            this.MenuMonitorCompras.Click += new System.EventHandler(this.MenuMonitorCompras_Click);
            // 
            // fabricaciónviejoToolStripMenuItem
            // 
            this.fabricaciónviejoToolStripMenuItem.Name = "fabricaciónviejoToolStripMenuItem";
            this.fabricaciónviejoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.fabricaciónviejoToolStripMenuItem.Text = "Fabricación (viejo)";
            this.fabricaciónviejoToolStripMenuItem.Click += new System.EventHandler(this.fabricaciónviejoToolStripMenuItem_Click);
            // 
            // MenuMonitoresFabricacion
            // 
            this.MenuMonitoresFabricacion.Name = "MenuMonitoresFabricacion";
            this.MenuMonitoresFabricacion.Size = new System.Drawing.Size(176, 22);
            this.MenuMonitoresFabricacion.Text = "Fabricación";
            this.MenuMonitoresFabricacion.Click += new System.EventHandler(this.MenuMonitoresMaquinado_Click);
            // 
            // finanzasToolStripMenuItem
            // 
            this.finanzasToolStripMenuItem.Enabled = false;
            this.finanzasToolStripMenuItem.Name = "finanzasToolStripMenuItem";
            this.finanzasToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.finanzasToolStripMenuItem.Text = "Finanzas";
            this.finanzasToolStripMenuItem.Click += new System.EventHandler(this.finanzasToolStripMenuItem_Click);
            // 
            // MenuMonitorEnsamble
            // 
            this.MenuMonitorEnsamble.Name = "MenuMonitorEnsamble";
            this.MenuMonitorEnsamble.Size = new System.Drawing.Size(176, 22);
            this.MenuMonitorEnsamble.Text = "Ensamble";
            this.MenuMonitorEnsamble.Click += new System.EventHandler(this.MenuMonitorEnsamble_Click);
            // 
            // MenuMonitorMantenimiento
            // 
            this.MenuMonitorMantenimiento.Name = "MenuMonitorMantenimiento";
            this.MenuMonitorMantenimiento.Size = new System.Drawing.Size(176, 22);
            this.MenuMonitorMantenimiento.Text = "Mantenimiento";
            this.MenuMonitorMantenimiento.Click += new System.EventHandler(this.mantenimientoToolStripMenuItem_Click);
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.procesosToolStripMenuItem.Text = "Operaciones";
            this.procesosToolStripMenuItem.Click += new System.EventHandler(this.procesosToolStripMenuItem_Click);
            // 
            // MenuMonitorRecursosHumanos
            // 
            this.MenuMonitorRecursosHumanos.Name = "MenuMonitorRecursosHumanos";
            this.MenuMonitorRecursosHumanos.Size = new System.Drawing.Size(176, 22);
            this.MenuMonitorRecursosHumanos.Text = "Recursos Humanos";
            this.MenuMonitorRecursosHumanos.Click += new System.EventHandler(this.recursosHumanosToolStripMenuItem_Click);
            // 
            // MenuMonitorServicioCliente
            // 
            this.MenuMonitorServicioCliente.Name = "MenuMonitorServicioCliente";
            this.MenuMonitorServicioCliente.Size = new System.Drawing.Size(176, 22);
            this.MenuMonitorServicioCliente.Text = "Servicio al cliente";
            this.MenuMonitorServicioCliente.Click += new System.EventHandler(this.servicioAlClienteToolStripMenuItem_Click);
            // 
            // sistemasToolStripMenuItem
            // 
            this.sistemasToolStripMenuItem.Name = "sistemasToolStripMenuItem";
            this.sistemasToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.sistemasToolStripMenuItem.Text = "Sistemas";
            this.sistemasToolStripMenuItem.Click += new System.EventHandler(this.sistemasToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // informaciToolStripMenuItem
            // 
            this.informaciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualDeCalidadToolStripMenuItem});
            this.informaciToolStripMenuItem.Name = "informaciToolStripMenuItem";
            this.informaciToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.informaciToolStripMenuItem.Text = "Información";
            // 
            // manualDeCalidadToolStripMenuItem
            // 
            this.manualDeCalidadToolStripMenuItem.Name = "manualDeCalidadToolStripMenuItem";
            this.manualDeCalidadToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.manualDeCalidadToolStripMenuItem.Text = "Manual de calidad";
            this.manualDeCalidadToolStripMenuItem.Click += new System.EventHandler(this.manualDeCalidadToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarToolStripMenuItem,
            this.imagenToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.actualizarToolStripMenuItem.Text = "actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarMetaToolStripMenuItem_Click);
            // 
            // imagenToolStripMenuItem
            // 
            this.imagenToolStripMenuItem.Name = "imagenToolStripMenuItem";
            this.imagenToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.imagenToolStripMenuItem.Text = "imagen";
            this.imagenToolStripMenuItem.Click += new System.EventHandler(this.imagenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblEstatusPrincipal,
            this.BtnNotificaciones});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(235, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(714, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblEstatusPrincipal
            // 
            this.LblEstatusPrincipal.Name = "LblEstatusPrincipal";
            this.LblEstatusPrincipal.Size = new System.Drawing.Size(90, 21);
            this.LblEstatusPrincipal.Text = "EstatusPrincipal";
            // 
            // BtnNotificaciones
            // 
            this.BtnNotificaciones.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnNotificaciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNotificaciones.Image = ((System.Drawing.Image)(resources.GetObject("BtnNotificaciones.Image")));
            this.BtnNotificaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNotificaciones.Name = "BtnNotificaciones";
            this.BtnNotificaciones.ShowDropDownArrow = false;
            this.BtnNotificaciones.Size = new System.Drawing.Size(24, 24);
            this.BtnNotificaciones.Text = "toolStripDropDownButton1";
            this.BtnNotificaciones.Click += new System.EventHandler(this.BtnNotificaciones_Click);
            // 
            // MenuSubproyectos
            // 
            this.MenuSubproyectos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuSubproyectos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliinarToolStripMenuItem});
            this.MenuSubproyectos.Name = "MenuSubproyectos";
            this.MenuSubproyectos.Size = new System.Drawing.Size(122, 82);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Enabled = false;
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Visible = false;
            // 
            // eliinarToolStripMenuItem
            // 
            this.eliinarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliinarToolStripMenuItem.Name = "eliinarToolStripMenuItem";
            this.eliinarToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.eliinarToolStripMenuItem.Text = "Eliminar";
            this.eliinarToolStripMenuItem.Visible = false;
            // 
            // PnlNotificaciones
            // 
            this.PnlNotificaciones.AutoScroll = true;
            this.PnlNotificaciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlNotificaciones.Location = new System.Drawing.Point(767, 24);
            this.PnlNotificaciones.Name = "PnlNotificaciones";
            this.PnlNotificaciones.Size = new System.Drawing.Size(182, 335);
            this.PnlNotificaciones.TabIndex = 8;
            this.PnlNotificaciones.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "OfdBuscarImagen";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(949, 385);
            this.Controls.Add(this.PnlNotificaciones);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.PanelArbolProyecto);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "CompanyBlocks";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.PanelArbolProyecto.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MenuSubproyectos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelArbolProyecto;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem proyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuProyectoCargar;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuAdministrarProveedores;
        private System.Windows.Forms.ToolStripMenuItem monitoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuMonitoresFabricacion;
        private System.Windows.Forms.TreeView TvArbolProyecto;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblEstatusPrincipal;
        private System.Windows.Forms.ImageList ImagenesArbolProyecto;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuCatalogoMaterial;
        private System.Windows.Forms.ToolStripMenuItem MenuMonitorCompras;
        private System.Windows.Forms.ToolStripMenuItem MenuMonitorEnsamble;
        private System.Windows.Forms.ToolStripMenuItem MenuMonitorAlmacen;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevoProyecto;
        private System.Windows.Forms.ContextMenuStrip MenuSubproyectos;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliinarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuMonitorRecursosHumanos;
        private System.Windows.Forms.ToolStripMenuItem informaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeCalidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuMonitorMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem MenuMonitorCalidad;
        private System.Windows.Forms.ToolStripMenuItem MenuMonitorServicioCliente;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fabricaciónviejoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catálogoDeMaterialviejoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catálogoDeMaterialnuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton BtnNotificaciones;
        private System.Windows.Forms.Panel PnlNotificaciones;
        private System.Windows.Forms.ToolStripMenuItem finanzasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fabricantesToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem miscelaneosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem búsquedaDeRequisiciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catálogoDePartesEstandarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDePOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem calendarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiempoExtraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuAdministrarUsuarios;
        private System.Windows.Forms.ToolStripMenuItem MenuAdministrarRoles;
        private System.Windows.Forms.ToolStripMenuItem puestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem competenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem búsquedaDeNúmeroDeParteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restringirNúmeroDeParteToolStripMenuItem;
    }
}


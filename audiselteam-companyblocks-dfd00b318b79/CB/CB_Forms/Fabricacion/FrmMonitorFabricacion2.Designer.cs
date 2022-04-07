namespace CB
{
    partial class FrmMonitorFabricacion2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitorFabricacion2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnReportes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnAsignaciones = new System.Windows.Forms.Button();
            this.BtnTerminal = new System.Windows.Forms.Button();
            this.BtnKpis = new System.Windows.Forms.Button();
            this.BtnMantenimientoCorrectivo = new System.Windows.Forms.Button();
            this.BtnProduccion = new System.Windows.Forms.Button();
            this.BtnValesSalida = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.LblMaterial = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TvMetas = new System.Windows.Forms.TreeView();
            this.ImagenesTv = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.MenuModulo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actualizarModuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarMultiplesProcesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MenuPlanos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fabricacionTerminadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarUrgenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ubicarPlanoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProcesos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarSiguienteProcesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProcesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estimarTiempoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiempoDeFabricaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultadosDeInspecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgDescargarPlano = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.LblEstatusResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.BkgImprimirPlano = new System.ComponentModel.BackgroundWorker();
            this.MenuProveedor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarSiguienteProcesoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verDetallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMeta = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actualizarArbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Tool = new System.Windows.Forms.ToolTip(this.components);
            this.MenuMaterial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImagenLista = new System.Windows.Forms.ImageList(this.components);
            this.MenuProcesosPlanos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AgregarProceso = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDescartar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.descartarPlanoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlanosUrgencias = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autorizarUrgenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechazarUrgenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MenuModulo.SuspendLayout();
            this.MenuPlanos.SuspendLayout();
            this.MenuProcesos.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.MenuProveedor.SuspendLayout();
            this.MenuMeta.SuspendLayout();
            this.MenuMaterial.SuspendLayout();
            this.MenuProcesosPlanos.SuspendLayout();
            this.MenuDescartar.SuspendLayout();
            this.MenuPlanosUrgencias.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnReportes);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.BtnAsignaciones);
            this.panel1.Controls.Add(this.BtnTerminal);
            this.panel1.Controls.Add(this.BtnKpis);
            this.panel1.Controls.Add(this.BtnMantenimientoCorrectivo);
            this.panel1.Controls.Add(this.BtnProduccion);
            this.panel1.Controls.Add(this.BtnValesSalida);
            this.panel1.Controls.Add(this.BtnBuscar);
            this.panel1.Controls.Add(this.LblMaterial);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1343, 95);
            this.panel1.TabIndex = 0;
            // 
            // BtnReportes
            // 
            this.BtnReportes.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReportes.Image = global::CB_Base.Properties.Resources.Paste_32;
            this.BtnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReportes.Location = new System.Drawing.Point(105, 23);
            this.BtnReportes.Name = "BtnReportes";
            this.BtnReportes.Size = new System.Drawing.Size(142, 72);
            this.BtnReportes.TabIndex = 115;
            this.BtnReportes.Text = "     Reportes";
            this.BtnReportes.UseVisualStyleBackColor = true;
            this.BtnReportes.Click += new System.EventHandler(this.BtnReportes_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CB_Base.Properties.Resources.details;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(247, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 72);
            this.button1.TabIndex = 114;
            this.button1.Text = "     Fuera del sistema";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnAsignaciones
            // 
            this.BtnAsignaciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAsignaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsignaciones.Image = global::CB_Base.Properties.Resources.order;
            this.BtnAsignaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAsignaciones.Location = new System.Drawing.Point(389, 23);
            this.BtnAsignaciones.Name = "BtnAsignaciones";
            this.BtnAsignaciones.Size = new System.Drawing.Size(142, 72);
            this.BtnAsignaciones.TabIndex = 113;
            this.BtnAsignaciones.Text = "Asignaciones";
            this.BtnAsignaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAsignaciones.UseVisualStyleBackColor = true;
            this.BtnAsignaciones.Click += new System.EventHandler(this.BtnAsignaciones_Click);
            // 
            // BtnTerminal
            // 
            this.BtnTerminal.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTerminal.Image = global::CB_Base.Properties.Resources.terminal_48;
            this.BtnTerminal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTerminal.Location = new System.Drawing.Point(531, 23);
            this.BtnTerminal.Name = "BtnTerminal";
            this.BtnTerminal.Size = new System.Drawing.Size(121, 72);
            this.BtnTerminal.TabIndex = 107;
            this.BtnTerminal.Text = "Terminal";
            this.BtnTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTerminal.UseVisualStyleBackColor = true;
            this.BtnTerminal.Click += new System.EventHandler(this.BtnTerminal_Click);
            // 
            // BtnKpis
            // 
            this.BtnKpis.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnKpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnKpis.Image = global::CB_Base.Properties.Resources.polls_48;
            this.BtnKpis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKpis.Location = new System.Drawing.Point(652, 23);
            this.BtnKpis.Name = "BtnKpis";
            this.BtnKpis.Size = new System.Drawing.Size(121, 72);
            this.BtnKpis.TabIndex = 110;
            this.BtnKpis.Text = "              KPIs";
            this.BtnKpis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKpis.UseVisualStyleBackColor = true;
            this.BtnKpis.Click += new System.EventHandler(this.BtnKpis_Click);
            // 
            // BtnMantenimientoCorrectivo
            // 
            this.BtnMantenimientoCorrectivo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMantenimientoCorrectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMantenimientoCorrectivo.Image = global::CB_Base.Properties.Resources.mantenimiento_48;
            this.BtnMantenimientoCorrectivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMantenimientoCorrectivo.Location = new System.Drawing.Point(773, 23);
            this.BtnMantenimientoCorrectivo.Name = "BtnMantenimientoCorrectivo";
            this.BtnMantenimientoCorrectivo.Size = new System.Drawing.Size(162, 72);
            this.BtnMantenimientoCorrectivo.TabIndex = 109;
            this.BtnMantenimientoCorrectivo.Text = "Mantenimiento";
            this.BtnMantenimientoCorrectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMantenimientoCorrectivo.UseVisualStyleBackColor = true;
            this.BtnMantenimientoCorrectivo.Click += new System.EventHandler(this.BtnMantenimientoCorrectivo_Click);
            // 
            // BtnProduccion
            // 
            this.BtnProduccion.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProduccion.Image = global::CB_Base.Properties.Resources.statistic_icon;
            this.BtnProduccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProduccion.Location = new System.Drawing.Point(935, 23);
            this.BtnProduccion.Name = "BtnProduccion";
            this.BtnProduccion.Size = new System.Drawing.Size(136, 72);
            this.BtnProduccion.TabIndex = 108;
            this.BtnProduccion.Text = "Producción";
            this.BtnProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProduccion.UseVisualStyleBackColor = true;
            this.BtnProduccion.Click += new System.EventHandler(this.BtnProduccion_Click);
            // 
            // BtnValesSalida
            // 
            this.BtnValesSalida.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnValesSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValesSalida.Image = global::CB_Base.Properties.Resources.Nota;
            this.BtnValesSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnValesSalida.Location = new System.Drawing.Point(1071, 23);
            this.BtnValesSalida.Name = "BtnValesSalida";
            this.BtnValesSalida.Size = new System.Drawing.Size(136, 72);
            this.BtnValesSalida.TabIndex = 106;
            this.BtnValesSalida.Text = "     Vales de salida";
            this.BtnValesSalida.UseVisualStyleBackColor = true;
            this.BtnValesSalida.Click += new System.EventHandler(this.BtnValesSalida_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(1207, 23);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(136, 72);
            this.BtnBuscar.TabIndex = 105;
            this.BtnBuscar.Text = "Buscar    ";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // LblMaterial
            // 
            this.LblMaterial.BackColor = System.Drawing.Color.Black;
            this.LblMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMaterial.ForeColor = System.Drawing.Color.White;
            this.LblMaterial.Location = new System.Drawing.Point(0, 0);
            this.LblMaterial.Name = "LblMaterial";
            this.LblMaterial.Size = new System.Drawing.Size(1343, 23);
            this.LblMaterial.TabIndex = 112;
            this.LblMaterial.Text = "MONITOR DE FABRICACION";
            this.LblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TvMetas);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 450);
            this.panel2.TabIndex = 3;
            // 
            // TvMetas
            // 
            this.TvMetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvMetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TvMetas.ImageIndex = 0;
            this.TvMetas.ImageList = this.ImagenesTv;
            this.TvMetas.Location = new System.Drawing.Point(0, 21);
            this.TvMetas.Name = "TvMetas";
            this.TvMetas.SelectedImageIndex = 0;
            this.TvMetas.ShowNodeToolTips = true;
            this.TvMetas.Size = new System.Drawing.Size(419, 429);
            this.TvMetas.TabIndex = 2;
            this.TvMetas.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TvMetas_AfterCollapse);
            this.TvMetas.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvMetas_BeforeExpand);
            this.TvMetas.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TvMetas_AfterExpand);
            this.TvMetas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMetas_NodeMouseClick);
            this.TvMetas.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMetas_NodeMouseDoubleClick);
            // 
            // ImagenesTv
            // 
            this.ImagenesTv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTv.ImageStream")));
            this.ImagenesTv.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTv.Images.SetKeyName(0, "marker_icon_32.png");
            this.ImagenesTv.Images.SetKeyName(1, "solid_assembly.png");
            this.ImagenesTv.Images.SetKeyName(2, "pdf-icon24px.png");
            this.ImagenesTv.Images.SetKeyName(3, "question-32.png");
            this.ImagenesTv.Images.SetKeyName(4, "detenido-limite.png");
            this.ImagenesTv.Images.SetKeyName(5, "en-proceso-a-tiempo-24.png");
            this.ImagenesTv.Images.SetKeyName(6, "pendiente-tarde-24.png");
            this.ImagenesTv.Images.SetKeyName(7, "Oxygen-Icons.org-Oxygen-Actions-dialog-ok-apply.ico");
            this.ImagenesTv.Images.SetKeyName(8, "clock-32.png");
            this.ImagenesTv.Images.SetKeyName(9, "supplier-48.png");
            this.ImagenesTv.Images.SetKeyName(10, "pdf-checked-48.png");
            this.ImagenesTv.Images.SetKeyName(11, "warning-48.png");
            this.ImagenesTv.Images.SetKeyName(12, "alert-24.png");
            this.ImagenesTv.Images.SetKeyName(13, "pdf-unknown-48.png");
            this.ImagenesTv.Images.SetKeyName(14, "pdf_clock.png");
            this.ImagenesTv.Images.SetKeyName(15, "pdf_truckincognito.png");
            this.ImagenesTv.Images.SetKeyName(16, "pdf-48.png");
            this.ImagenesTv.Images.SetKeyName(17, "procesos_48.png");
            this.ImagenesTv.Images.SetKeyName(18, "pdf_reparaciones_48.png");
            this.ImagenesTv.Images.SetKeyName(19, "trash_32.png");
            this.ImagenesTv.Images.SetKeyName(20, "important-icon.png");
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "METAS DE FABRICACION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuModulo
            // 
            this.MenuModulo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarModuloToolStripMenuItem,
            this.asignarMultiplesProcesosToolStripMenuItem});
            this.MenuModulo.Name = "MenuModulo";
            this.MenuModulo.Size = new System.Drawing.Size(217, 48);
            // 
            // actualizarModuloToolStripMenuItem
            // 
            this.actualizarModuloToolStripMenuItem.Image = global::CB_Base.Properties.Resources.update;
            this.actualizarModuloToolStripMenuItem.Name = "actualizarModuloToolStripMenuItem";
            this.actualizarModuloToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.actualizarModuloToolStripMenuItem.Text = "Actualizar";
            this.actualizarModuloToolStripMenuItem.Click += new System.EventHandler(this.actualizarModuloToolStripMenuItem_Click);
            // 
            // asignarMultiplesProcesosToolStripMenuItem
            // 
            this.asignarMultiplesProcesosToolStripMenuItem.Image = global::CB_Base.Properties.Resources.order;
            this.asignarMultiplesProcesosToolStripMenuItem.Name = "asignarMultiplesProcesosToolStripMenuItem";
            this.asignarMultiplesProcesosToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.asignarMultiplesProcesosToolStripMenuItem.Text = "Asignar multiples procesos";
            this.asignarMultiplesProcesosToolStripMenuItem.Click += new System.EventHandler(this.asignarMultiplesProcesosToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(419, 95);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 450);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // MenuPlanos
            // 
            this.MenuPlanos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.actualizarToolStripMenuItem,
            this.fabricacionTerminadaToolStripMenuItem,
            this.solicitarUrgenciaToolStripMenuItem,
            this.ubicarPlanoToolStripMenuItem});
            this.MenuPlanos.Name = "MenuPlanos";
            this.MenuPlanos.Size = new System.Drawing.Size(193, 136);
            this.MenuPlanos.Opening += new System.ComponentModel.CancelEventHandler(this.MenuPlanos_Opening);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.search_icon_48;
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Image = global::CB_Base.Properties.Resources.print2;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.update;
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // fabricacionTerminadaToolStripMenuItem
            // 
            this.fabricacionTerminadaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.ok_48;
            this.fabricacionTerminadaToolStripMenuItem.Name = "fabricacionTerminadaToolStripMenuItem";
            this.fabricacionTerminadaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.fabricacionTerminadaToolStripMenuItem.Text = "Fabricación terminada";
            this.fabricacionTerminadaToolStripMenuItem.Click += new System.EventHandler(this.fabricaciónTerminadaToolStripMenuItem_Click);
            // 
            // solicitarUrgenciaToolStripMenuItem
            // 
            this.solicitarUrgenciaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.alert_24;
            this.solicitarUrgenciaToolStripMenuItem.Name = "solicitarUrgenciaToolStripMenuItem";
            this.solicitarUrgenciaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.solicitarUrgenciaToolStripMenuItem.Text = "Solicitar urgencia";
            this.solicitarUrgenciaToolStripMenuItem.Click += new System.EventHandler(this.solicitarUrgenciaToolStripMenuItem_Click);
            // 
            // ubicarPlanoToolStripMenuItem
            // 
            this.ubicarPlanoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Search_icon1;
            this.ubicarPlanoToolStripMenuItem.Name = "ubicarPlanoToolStripMenuItem";
            this.ubicarPlanoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ubicarPlanoToolStripMenuItem.Text = "Ubicar plano";
            this.ubicarPlanoToolStripMenuItem.Click += new System.EventHandler(this.ubicarPlanoToolStripMenuItem_Click);
            // 
            // MenuProcesos
            // 
            this.MenuProcesos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarSiguienteProcesoToolStripMenuItem,
            this.eliminarProcesoToolStripMenuItem,
            this.asignarToolStripMenuItem,
            this.estimarTiempoToolStripMenuItem,
            this.tiempoDeFabricaciónToolStripMenuItem,
            this.resultadosDeInspecciónToolStripMenuItem});
            this.MenuProcesos.Name = "MenuProcesos";
            this.MenuProcesos.Size = new System.Drawing.Size(213, 136);
            this.MenuProcesos.Opening += new System.ComponentModel.CancelEventHandler(this.MenuProcesos_Opening);
            // 
            // agregarSiguienteProcesoToolStripMenuItem
            // 
            this.agregarSiguienteProcesoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.agregarSiguienteProcesoToolStripMenuItem.Name = "agregarSiguienteProcesoToolStripMenuItem";
            this.agregarSiguienteProcesoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.agregarSiguienteProcesoToolStripMenuItem.Text = "Agregar siguiente proceso";
            this.agregarSiguienteProcesoToolStripMenuItem.Click += new System.EventHandler(this.agregarSiguienteProcesoToolStripMenuItem_Click);
            // 
            // eliminarProcesoToolStripMenuItem
            // 
            this.eliminarProcesoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarProcesoToolStripMenuItem.Name = "eliminarProcesoToolStripMenuItem";
            this.eliminarProcesoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.eliminarProcesoToolStripMenuItem.Text = "Eliminar proceso";
            this.eliminarProcesoToolStripMenuItem.Click += new System.EventHandler(this.eliminarProcesoToolStripMenuItem_Click);
            // 
            // asignarToolStripMenuItem
            // 
            this.asignarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.order;
            this.asignarToolStripMenuItem.Name = "asignarToolStripMenuItem";
            this.asignarToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.asignarToolStripMenuItem.Text = "Asignar";
            this.asignarToolStripMenuItem.Click += new System.EventHandler(this.asignarToolStripMenuItem_Click);
            // 
            // estimarTiempoToolStripMenuItem
            // 
            this.estimarTiempoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.clock_32;
            this.estimarTiempoToolStripMenuItem.Name = "estimarTiempoToolStripMenuItem";
            this.estimarTiempoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.estimarTiempoToolStripMenuItem.Text = "Estimar tiempo";
            this.estimarTiempoToolStripMenuItem.Click += new System.EventHandler(this.estimarTiempoToolStripMenuItem_Click);
            // 
            // tiempoDeFabricaciónToolStripMenuItem
            // 
            this.tiempoDeFabricaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.clock_32;
            this.tiempoDeFabricaciónToolStripMenuItem.Name = "tiempoDeFabricaciónToolStripMenuItem";
            this.tiempoDeFabricaciónToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.tiempoDeFabricaciónToolStripMenuItem.Text = "Tiempo de fabricación";
            this.tiempoDeFabricaciónToolStripMenuItem.Click += new System.EventHandler(this.tiempoDeFabricaciónToolStripMenuItem_Click);
            // 
            // resultadosDeInspecciónToolStripMenuItem
            // 
            this.resultadosDeInspecciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Nota;
            this.resultadosDeInspecciónToolStripMenuItem.Name = "resultadosDeInspecciónToolStripMenuItem";
            this.resultadosDeInspecciónToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.resultadosDeInspecciónToolStripMenuItem.Text = "Resultados de inspección";
            this.resultadosDeInspecciónToolStripMenuItem.Click += new System.EventHandler(this.resultadosDeInspecciónToolStripMenuItem_Click);
            // 
            // BkgDescargarPlano
            // 
            this.BkgDescargarPlano.WorkerReportsProgress = true;
            this.BkgDescargarPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPlano_DoWork);
            this.BkgDescargarPlano.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarPlano_ProgressChanged);
            this.BkgDescargarPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarPlano_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblEstatus,
            this.Progress,
            this.LblEstatusResultado});
            this.statusStrip1.Location = new System.Drawing.Point(422, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(921, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblEstatus
            // 
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(109, 17);
            this.LblEstatus.Text = "Descargando plano";
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
            // BkgImprimirPlano
            // 
            this.BkgImprimirPlano.WorkerReportsProgress = true;
            this.BkgImprimirPlano.WorkerSupportsCancellation = true;
            this.BkgImprimirPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgImprimirPlano_DoWork);
            this.BkgImprimirPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgImprimirPlano_RunWorkerCompleted);
            // 
            // MenuProveedor
            // 
            this.MenuProveedor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarSiguienteProcesoToolStripMenuItem1,
            this.verDetallesToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuProveedor.Name = "MenuProveedor";
            this.MenuProveedor.Size = new System.Drawing.Size(213, 70);
            this.MenuProveedor.Opening += new System.ComponentModel.CancelEventHandler(this.MenuProveedor_Opening);
            // 
            // agregarSiguienteProcesoToolStripMenuItem1
            // 
            this.agregarSiguienteProcesoToolStripMenuItem1.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.agregarSiguienteProcesoToolStripMenuItem1.Name = "agregarSiguienteProcesoToolStripMenuItem1";
            this.agregarSiguienteProcesoToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.agregarSiguienteProcesoToolStripMenuItem1.Text = "Agregar siguiente proceso";
            this.agregarSiguienteProcesoToolStripMenuItem1.Click += new System.EventHandler(this.agregarSiguienteProcesoToolStripMenuItem1_Click);
            // 
            // verDetallesToolStripMenuItem
            // 
            this.verDetallesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.search_icon_48;
            this.verDetallesToolStripMenuItem.Name = "verDetallesToolStripMenuItem";
            this.verDetallesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.verDetallesToolStripMenuItem.Text = "Ver detalles";
            this.verDetallesToolStripMenuItem.Click += new System.EventHandler(this.verDetallesToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.eliminarToolStripMenuItem.Text = "Cancelar requisición";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // MenuMeta
            // 
            this.MenuMeta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarArbolToolStripMenuItem});
            this.MenuMeta.Name = "MenuArbol";
            this.MenuMeta.Size = new System.Drawing.Size(127, 26);
            // 
            // actualizarArbolToolStripMenuItem
            // 
            this.actualizarArbolToolStripMenuItem.Image = global::CB_Base.Properties.Resources.update;
            this.actualizarArbolToolStripMenuItem.Name = "actualizarArbolToolStripMenuItem";
            this.actualizarArbolToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.actualizarArbolToolStripMenuItem.Text = "Actualizar";
            this.actualizarArbolToolStripMenuItem.Click += new System.EventHandler(this.actualizarMetaToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(422, 95);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(921, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Tool
            // 
            this.Tool.BackColor = System.Drawing.Color.Gold;
            this.Tool.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tool.ToolTipTitle = "Descripción guardada";
            // 
            // MenuMaterial
            // 
            this.MenuMaterial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarMaterialToolStripMenuItem,
            this.enStockToolStripMenuItem});
            this.MenuMaterial.Name = "MenuMaterial";
            this.MenuMaterial.Size = new System.Drawing.Size(163, 48);
            this.MenuMaterial.Opening += new System.ComponentModel.CancelEventHandler(this.MenuMaterial_Opening);
            // 
            // seleccionarMaterialToolStripMenuItem
            // 
            this.seleccionarMaterialToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.seleccionarMaterialToolStripMenuItem.Name = "seleccionarMaterialToolStripMenuItem";
            this.seleccionarMaterialToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.seleccionarMaterialToolStripMenuItem.Text = "Agregar material";
            this.seleccionarMaterialToolStripMenuItem.Click += new System.EventHandler(this.seleccionarMaterialToolStripMenuItem_Click);
            // 
            // enStockToolStripMenuItem
            // 
            this.enStockToolStripMenuItem.Name = "enStockToolStripMenuItem";
            this.enStockToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.enStockToolStripMenuItem.Text = "En stock";
            this.enStockToolStripMenuItem.Click += new System.EventHandler(this.enStockToolStripMenuItem_Click);
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
            // MenuProcesosPlanos
            // 
            this.MenuProcesosPlanos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregarProceso});
            this.MenuProcesosPlanos.Name = "MenuPlanos";
            this.MenuProcesosPlanos.Size = new System.Drawing.Size(196, 26);
            this.MenuProcesosPlanos.Opening += new System.ComponentModel.CancelEventHandler(this.MenuProcesosPlanos_Opening);
            // 
            // AgregarProceso
            // 
            this.AgregarProceso.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.AgregarProceso.Name = "AgregarProceso";
            this.AgregarProceso.Size = new System.Drawing.Size(195, 22);
            this.AgregarProceso.Text = "Agregar proceso inicial";
            this.AgregarProceso.Click += new System.EventHandler(this.agregarProcesoInicialToolStripMenuItem_Click);
            // 
            // MenuDescartar
            // 
            this.MenuDescartar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descartarPlanoToolStripMenuItem});
            this.MenuDescartar.Name = "MenuDescartar";
            this.MenuDescartar.Size = new System.Drawing.Size(157, 26);
            // 
            // descartarPlanoToolStripMenuItem
            // 
            this.descartarPlanoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.trash_32;
            this.descartarPlanoToolStripMenuItem.Name = "descartarPlanoToolStripMenuItem";
            this.descartarPlanoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.descartarPlanoToolStripMenuItem.Text = "Descartar plano";
            this.descartarPlanoToolStripMenuItem.Click += new System.EventHandler(this.descartarPlanoToolStripMenuItem_Click);
            // 
            // MenuPlanosUrgencias
            // 
            this.MenuPlanosUrgencias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorizarUrgenciaToolStripMenuItem,
            this.rechazarUrgenciaToolStripMenuItem,
            this.detallesToolStripMenuItem});
            this.MenuPlanosUrgencias.Name = "MenuPlanosUrgencias";
            this.MenuPlanosUrgencias.Size = new System.Drawing.Size(172, 70);
            this.MenuPlanosUrgencias.Opening += new System.ComponentModel.CancelEventHandler(this.MenuPlanosUrgencias_Opening);
            // 
            // autorizarUrgenciaToolStripMenuItem
            // 
            this.autorizarUrgenciaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.approve;
            this.autorizarUrgenciaToolStripMenuItem.Name = "autorizarUrgenciaToolStripMenuItem";
            this.autorizarUrgenciaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.autorizarUrgenciaToolStripMenuItem.Text = "Autorizar urgencia";
            this.autorizarUrgenciaToolStripMenuItem.Click += new System.EventHandler(this.autorizarUrgenciaToolStripMenuItem_Click);
            // 
            // rechazarUrgenciaToolStripMenuItem
            // 
            this.rechazarUrgenciaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.reject_icon;
            this.rechazarUrgenciaToolStripMenuItem.Name = "rechazarUrgenciaToolStripMenuItem";
            this.rechazarUrgenciaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.rechazarUrgenciaToolStripMenuItem.Text = "Rechazar urgencia";
            this.rechazarUrgenciaToolStripMenuItem.Click += new System.EventHandler(this.rechazarUrgenciaToolStripMenuItem_Click);
            // 
            // detallesToolStripMenuItem
            // 
            this.detallesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.search;
            this.detallesToolStripMenuItem.Name = "detallesToolStripMenuItem";
            this.detallesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.detallesToolStripMenuItem.Text = "Detalles";
            this.detallesToolStripMenuItem.Click += new System.EventHandler(this.detallesToolStripMenuItem_Click);
            // 
            // FrmMonitorFabricacion2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 545);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "FrmMonitorFabricacion2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de fabricación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMonitorFabricacion2_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.MenuModulo.ResumeLayout(false);
            this.MenuPlanos.ResumeLayout(false);
            this.MenuProcesos.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MenuProveedor.ResumeLayout(false);
            this.MenuMeta.ResumeLayout(false);
            this.MenuMaterial.ResumeLayout(false);
            this.MenuProcesosPlanos.ResumeLayout(false);
            this.MenuDescartar.ResumeLayout(false);
            this.MenuPlanosUrgencias.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView TvMetas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ImageList ImagenesTv;
        private System.Windows.Forms.ContextMenuStrip MenuPlanos;
        private System.Windows.Forms.ContextMenuStrip MenuProcesos;
        private System.Windows.Forms.ToolStripMenuItem agregarSiguienteProcesoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarProcesoToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlano;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estimarTiempoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarToolStripMenuItem;
        private System.Windows.Forms.Button BtnTerminal;
        private System.Windows.Forms.Button BtnKpis;
        private System.Windows.Forms.Button BtnMantenimientoCorrectivo;
        private System.Windows.Forms.Button BtnProduccion;
        private System.Windows.Forms.Button BtnValesSalida;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Label LblMaterial;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblEstatus;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private System.Windows.Forms.ToolStripStatusLabel LblEstatusResultado;
        private System.ComponentModel.BackgroundWorker BkgImprimirPlano;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuProveedor;
        private System.Windows.Forms.ToolStripMenuItem agregarSiguienteProcesoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fabricacionTerminadaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuMeta;
        private System.Windows.Forms.ToolStripMenuItem actualizarArbolToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuModulo;
        private System.Windows.Forms.ToolStripMenuItem actualizarModuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarMultiplesProcesosToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolTip Tool;
        private System.Windows.Forms.Button BtnAsignaciones;
        private System.Windows.Forms.ToolStripMenuItem resultadosDeInspecciónToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuMaterial;
        private System.Windows.Forms.ToolStripMenuItem seleccionarMaterialToolStripMenuItem;
        private System.Windows.Forms.ImageList ImagenLista;
        private System.Windows.Forms.ToolStripMenuItem enStockToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuProcesosPlanos;
        private System.Windows.Forms.ToolStripMenuItem AgregarProceso;
        private System.Windows.Forms.ContextMenuStrip MenuDescartar;
        private System.Windows.Forms.ToolStripMenuItem descartarPlanoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitarUrgenciaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuPlanosUrgencias;
        private System.Windows.Forms.ToolStripMenuItem autorizarUrgenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechazarUrgenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ubicarPlanoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiempoDeFabricaciónToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnReportes;
    }
}
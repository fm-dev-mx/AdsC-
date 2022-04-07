namespace CB
{
    partial class FrmPlanTrabajoPlano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanTrabajoPlano));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OpcionesMaterial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarDelCatálogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verDetallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.OpcionesProceso = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarAsignacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verRequisiciónDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planificarTiempoExtraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiempoDeFabricaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuValeSalida = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.piezaFabricadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tratamientoDeMaterialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.piezasEntregadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgDescargarMiniatura = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarProcesos = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarPlano = new System.ComponentModel.BackgroundWorker();
            this.LblEstatusDescargar = new System.Windows.Forms.Label();
            this.ProgresoDescarga = new System.Windows.Forms.ProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnResultadosInspeccion = new System.Windows.Forms.Button();
            this.BtnGenerarMiniatura = new System.Windows.Forms.Button();
            this.BtnVerPDF = new System.Windows.Forms.Button();
            this.BtnVerDetalles = new System.Windows.Forms.Button();
            this.PicMiniatura = new System.Windows.Forms.PictureBox();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.LblNumeroPlano = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Procesos = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DgvProcesos = new System.Windows.Forms.DataGridView();
            this.BtnEnviarAInspeccion = new System.Windows.Forms.Button();
            this.BtnValeSalida = new System.Windows.Forms.Button();
            this.BtnTerminarPieza = new System.Windows.Forms.Button();
            this.BtnEditarProceso = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.Material = new System.Windows.Forms.TabPage();
            this.DgvMaterial = new System.Windows.Forms.DataGridView();
            this.id_requisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_compras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChkMaterialStock = new System.Windows.Forms.CheckBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columna_proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramentista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proceso_anterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columna_requisicion_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_muerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_total_fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpcionesMaterial.SuspendLayout();
            this.OpcionesProceso.SuspendLayout();
            this.MenuValeSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMiniatura)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Procesos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesos)).BeginInit();
            this.Material.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpcionesMaterial
            // 
            this.OpcionesMaterial.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.OpcionesMaterial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarDelCatálogoToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.verDetallesToolStripMenuItem});
            this.OpcionesMaterial.Name = "OpcionesMaterial";
            this.OpcionesMaterial.Size = new System.Drawing.Size(207, 82);
            // 
            // seleccionarDelCatálogoToolStripMenuItem
            // 
            this.seleccionarDelCatálogoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.seleccionarDelCatálogoToolStripMenuItem.Name = "seleccionarDelCatálogoToolStripMenuItem";
            this.seleccionarDelCatálogoToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.seleccionarDelCatálogoToolStripMenuItem.Text = "Seleccionar del catálogo";
            this.seleccionarDelCatálogoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarDelCatálogoToolStripMenuItem_Click);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Enabled = false;
            this.cancelarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.cancelarToolStripMenuItem.Text = "Cancelar";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
            // 
            // verDetallesToolStripMenuItem
            // 
            this.verDetallesToolStripMenuItem.Enabled = false;
            this.verDetallesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.details;
            this.verDetallesToolStripMenuItem.Name = "verDetallesToolStripMenuItem";
            this.verDetallesToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.verDetallesToolStripMenuItem.Text = "Ver detalles";
            this.verDetallesToolStripMenuItem.Click += new System.EventHandler(this.verDetallesToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "process-icon.png");
            this.imageList1.Images.SetKeyName(1, "Iron-Ingot-icon.png");
            // 
            // OpcionesProceso
            // 
            this.OpcionesProceso.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.OpcionesProceso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarToolStripMenuItem,
            this.actualizarToolStripMenuItem,
            this.cancelarAsignacionToolStripMenuItem,
            this.verRequisiciónDeCompraToolStripMenuItem,
            this.planificarTiempoExtraToolStripMenuItem,
            this.tiempoDeFabricaciónToolStripMenuItem});
            this.OpcionesProceso.Name = "contextMenuStrip1";
            this.OpcionesProceso.Size = new System.Drawing.Size(216, 160);
            this.OpcionesProceso.Opening += new System.ComponentModel.CancelEventHandler(this.OpcionesProceso_Opening);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Enabled = false;
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Enabled = false;
            this.actualizarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.update;
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.actualizarToolStripMenuItem.Text = "Asignar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // cancelarAsignacionToolStripMenuItem
            // 
            this.cancelarAsignacionToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Block_icon;
            this.cancelarAsignacionToolStripMenuItem.Name = "cancelarAsignacionToolStripMenuItem";
            this.cancelarAsignacionToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.cancelarAsignacionToolStripMenuItem.Text = "Cancelar asignación";
            this.cancelarAsignacionToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem1_Click);
            // 
            // verRequisiciónDeCompraToolStripMenuItem
            // 
            this.verRequisiciónDeCompraToolStripMenuItem.Image = global::CB_Base.Properties.Resources.details;
            this.verRequisiciónDeCompraToolStripMenuItem.Name = "verRequisiciónDeCompraToolStripMenuItem";
            this.verRequisiciónDeCompraToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.verRequisiciónDeCompraToolStripMenuItem.Text = "Ver requisición de compra";
            this.verRequisiciónDeCompraToolStripMenuItem.Click += new System.EventHandler(this.verRequisiciónDeCompraToolStripMenuItem_Click);
            // 
            // planificarTiempoExtraToolStripMenuItem
            // 
            this.planificarTiempoExtraToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.planificarTiempoExtraToolStripMenuItem.Name = "planificarTiempoExtraToolStripMenuItem";
            this.planificarTiempoExtraToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.planificarTiempoExtraToolStripMenuItem.Text = "Planificar tiempo extra";
            this.planificarTiempoExtraToolStripMenuItem.Click += new System.EventHandler(this.planificarTiempoExtraToolStripMenuItem_Click);
            // 
            // tiempoDeFabricaciónToolStripMenuItem
            // 
            this.tiempoDeFabricaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.clock_32;
            this.tiempoDeFabricaciónToolStripMenuItem.Name = "tiempoDeFabricaciónToolStripMenuItem";
            this.tiempoDeFabricaciónToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.tiempoDeFabricaciónToolStripMenuItem.Text = "Tiempo de fabricación";
            this.tiempoDeFabricaciónToolStripMenuItem.Click += new System.EventHandler(this.tiempoDeFabricaciónToolStripMenuItem_Click);
            // 
            // MenuValeSalida
            // 
            this.MenuValeSalida.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.piezaFabricadaToolStripMenuItem,
            this.tratamientoDeMaterialesToolStripMenuItem,
            this.piezasEntregadasToolStripMenuItem});
            this.MenuValeSalida.Name = "MenuValeSalida";
            this.MenuValeSalida.Size = new System.Drawing.Size(211, 70);
            this.MenuValeSalida.Opening += new System.ComponentModel.CancelEventHandler(this.MenuValeSalida_Opening);
            // 
            // piezaFabricadaToolStripMenuItem
            // 
            this.piezaFabricadaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.piezas_fabricadas;
            this.piezaFabricadaToolStripMenuItem.Name = "piezaFabricadaToolStripMenuItem";
            this.piezaFabricadaToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.piezaFabricadaToolStripMenuItem.Text = "Pieza fabricada";
            this.piezaFabricadaToolStripMenuItem.Click += new System.EventHandler(this.piezaFabricadaToolStripMenuItem_Click);
            // 
            // tratamientoDeMaterialesToolStripMenuItem
            // 
            this.tratamientoDeMaterialesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.paint_icon1;
            this.tratamientoDeMaterialesToolStripMenuItem.Name = "tratamientoDeMaterialesToolStripMenuItem";
            this.tratamientoDeMaterialesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.tratamientoDeMaterialesToolStripMenuItem.Text = "Tratamiento de materiales";
            this.tratamientoDeMaterialesToolStripMenuItem.Click += new System.EventHandler(this.tratamientoDeMaterialesToolStripMenuItem_Click);
            // 
            // piezasEntregadasToolStripMenuItem
            // 
            this.piezasEntregadasToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.piezasEntregadasToolStripMenuItem.Name = "piezasEntregadasToolStripMenuItem";
            this.piezasEntregadasToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.piezasEntregadasToolStripMenuItem.Text = "Piezas entregadas";
            this.piezasEntregadasToolStripMenuItem.Click += new System.EventHandler(this.piezasEntregadasToolStripMenuItem_Click);
            // 
            // BkgDescargarMiniatura
            // 
            this.BkgDescargarMiniatura.WorkerReportsProgress = true;
            this.BkgDescargarMiniatura.WorkerSupportsCancellation = true;
            this.BkgDescargarMiniatura.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarMiniatura_DoWork);
            this.BkgDescargarMiniatura.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarMiniatura_ProgressChanged);
            this.BkgDescargarMiniatura.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarMiniatura_RunWorkerCompleted);
            // 
            // BkgDescargarProcesos
            // 
            this.BkgDescargarProcesos.WorkerReportsProgress = true;
            this.BkgDescargarProcesos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgProcesos_DoWork);
            this.BkgDescargarProcesos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgProcesos_ProgressChanged);
            this.BkgDescargarProcesos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgProcesos_RunWorkerCompleted);
            // 
            // BkgDescargarPlano
            // 
            this.BkgDescargarPlano.WorkerReportsProgress = true;
            this.BkgDescargarPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPlano_DoWork);
            this.BkgDescargarPlano.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarPlano_ProgressChanged);
            this.BkgDescargarPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarPlano_RunWorkerCompleted);
            // 
            // LblEstatusDescargar
            // 
            this.LblEstatusDescargar.BackColor = System.Drawing.Color.Black;
            this.LblEstatusDescargar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusDescargar.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusDescargar.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusDescargar.Location = new System.Drawing.Point(0, 545);
            this.LblEstatusDescargar.Name = "LblEstatusDescargar";
            this.LblEstatusDescargar.Size = new System.Drawing.Size(1386, 29);
            this.LblEstatusDescargar.TabIndex = 79;
            this.LblEstatusDescargar.Text = "Estatus ...";
            this.LblEstatusDescargar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoDescarga
            // 
            this.ProgresoDescarga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoDescarga.Location = new System.Drawing.Point(0, 574);
            this.ProgresoDescarga.Name = "ProgresoDescarga";
            this.ProgresoDescarga.Size = new System.Drawing.Size(1386, 23);
            this.ProgresoDescarga.TabIndex = 78;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer1.Panel1.Controls.Add(this.BtnResultadosInspeccion);
            this.splitContainer1.Panel1.Controls.Add(this.BtnGenerarMiniatura);
            this.splitContainer1.Panel1.Controls.Add(this.BtnVerPDF);
            this.splitContainer1.Panel1.Controls.Add(this.BtnVerDetalles);
            this.splitContainer1.Panel1.Controls.Add(this.PicMiniatura);
            this.splitContainer1.Panel1.Controls.Add(this.LblEstatus);
            this.splitContainer1.Panel1.Controls.Add(this.LblNumeroPlano);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1386, 549);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 31;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.close;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 447);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(291, 38);
            this.BtnSalir.TabIndex = 17;
            this.BtnSalir.Text = "         Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnResultadosInspeccion
            // 
            this.BtnResultadosInspeccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnResultadosInspeccion.Enabled = false;
            this.BtnResultadosInspeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResultadosInspeccion.Image = global::CB_Base.Properties.Resources.Nota;
            this.BtnResultadosInspeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnResultadosInspeccion.Location = new System.Drawing.Point(0, 409);
            this.BtnResultadosInspeccion.Name = "BtnResultadosInspeccion";
            this.BtnResultadosInspeccion.Size = new System.Drawing.Size(291, 38);
            this.BtnResultadosInspeccion.TabIndex = 23;
            this.BtnResultadosInspeccion.Text = "         Resultados de inspección  ";
            this.BtnResultadosInspeccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnResultadosInspeccion.UseVisualStyleBackColor = true;
            this.BtnResultadosInspeccion.Click += new System.EventHandler(this.BtnResultadosInspeccion_Click);
            // 
            // BtnGenerarMiniatura
            // 
            this.BtnGenerarMiniatura.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnGenerarMiniatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarMiniatura.Image = global::CB_Base.Properties.Resources.adjunto;
            this.BtnGenerarMiniatura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerarMiniatura.Location = new System.Drawing.Point(0, 371);
            this.BtnGenerarMiniatura.Name = "BtnGenerarMiniatura";
            this.BtnGenerarMiniatura.Size = new System.Drawing.Size(291, 38);
            this.BtnGenerarMiniatura.TabIndex = 18;
            this.BtnGenerarMiniatura.Text = "         Generar vista previa";
            this.BtnGenerarMiniatura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerarMiniatura.UseVisualStyleBackColor = true;
            this.BtnGenerarMiniatura.Click += new System.EventHandler(this.BtnGenerarMiniatura_Click);
            // 
            // BtnVerPDF
            // 
            this.BtnVerPDF.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnVerPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerPDF.Image = global::CB_Base.Properties.Resources.print2;
            this.BtnVerPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVerPDF.Location = new System.Drawing.Point(0, 333);
            this.BtnVerPDF.Name = "BtnVerPDF";
            this.BtnVerPDF.Size = new System.Drawing.Size(291, 38);
            this.BtnVerPDF.TabIndex = 19;
            this.BtnVerPDF.Text = "         Ver plano PDF";
            this.BtnVerPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVerPDF.UseVisualStyleBackColor = true;
            this.BtnVerPDF.Click += new System.EventHandler(this.BtnVerPDF_Click);
            // 
            // BtnVerDetalles
            // 
            this.BtnVerDetalles.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnVerDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerDetalles.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnVerDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVerDetalles.Location = new System.Drawing.Point(0, 295);
            this.BtnVerDetalles.Name = "BtnVerDetalles";
            this.BtnVerDetalles.Size = new System.Drawing.Size(291, 38);
            this.BtnVerDetalles.TabIndex = 21;
            this.BtnVerDetalles.Text = "         Ver detalles";
            this.BtnVerDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVerDetalles.UseVisualStyleBackColor = true;
            this.BtnVerDetalles.Click += new System.EventHandler(this.BtnVerDetalles_Click);
            // 
            // PicMiniatura
            // 
            this.PicMiniatura.Dock = System.Windows.Forms.DockStyle.Top;
            this.PicMiniatura.InitialImage = global::CB_Base.Properties.Resources.downloadPdf_gray;
            this.PicMiniatura.Location = new System.Drawing.Point(0, 46);
            this.PicMiniatura.Margin = new System.Windows.Forms.Padding(2);
            this.PicMiniatura.Name = "PicMiniatura";
            this.PicMiniatura.Size = new System.Drawing.Size(291, 249);
            this.PicMiniatura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicMiniatura.TabIndex = 0;
            this.PicMiniatura.TabStop = false;
            this.PicMiniatura.DoubleClick += new System.EventHandler(this.PicMiniatura_DoubleClick);
            // 
            // LblEstatus
            // 
            this.LblEstatus.BackColor = System.Drawing.Color.Black;
            this.LblEstatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.ForeColor = System.Drawing.Color.White;
            this.LblEstatus.Location = new System.Drawing.Point(0, 23);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(291, 23);
            this.LblEstatus.TabIndex = 22;
            this.LblEstatus.Text = "ESTATUS";
            this.LblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblNumeroPlano
            // 
            this.LblNumeroPlano.BackColor = System.Drawing.Color.Black;
            this.LblNumeroPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroPlano.ForeColor = System.Drawing.Color.White;
            this.LblNumeroPlano.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroPlano.Name = "LblNumeroPlano";
            this.LblNumeroPlano.Size = new System.Drawing.Size(291, 23);
            this.LblNumeroPlano.TabIndex = 20;
            this.LblNumeroPlano.Text = "NUMERO";
            this.LblNumeroPlano.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Procesos);
            this.tabControl1.Controls.Add(this.Material);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1092, 549);
            this.tabControl1.TabIndex = 30;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Procesos
            // 
            this.Procesos.Controls.Add(this.splitContainer2);
            this.Procesos.ImageIndex = 0;
            this.Procesos.Location = new System.Drawing.Point(4, 31);
            this.Procesos.Name = "Procesos";
            this.Procesos.Padding = new System.Windows.Forms.Padding(3);
            this.Procesos.Size = new System.Drawing.Size(1084, 514);
            this.Procesos.TabIndex = 0;
            this.Procesos.Text = "Procesos";
            this.Procesos.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.DgvProcesos);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.BtnEnviarAInspeccion);
            this.splitContainer2.Panel2.Controls.Add(this.BtnValeSalida);
            this.splitContainer2.Panel2.Controls.Add(this.BtnTerminarPieza);
            this.splitContainer2.Panel2.Controls.Add(this.BtnEditarProceso);
            this.splitContainer2.Panel2.Controls.Add(this.BtnAgregar);
            this.splitContainer2.Panel2.Controls.Add(this.BtnImprimir);
            this.splitContainer2.Size = new System.Drawing.Size(1078, 508);
            this.splitContainer2.SplitterDistance = 865;
            this.splitContainer2.TabIndex = 0;
            // 
            // DgvProcesos
            // 
            this.DgvProcesos.AllowUserToAddRows = false;
            this.DgvProcesos.AllowUserToDeleteRows = false;
            this.DgvProcesos.AllowUserToResizeRows = false;
            this.DgvProcesos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProcesos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.columna_proceso,
            this.maquina,
            this.programador,
            this.herramentista,
            this.estatus,
            this.fecha_inicio,
            this.fecha_termino,
            this.comentarios,
            this.proceso_anterior,
            this.col_categoria,
            this.columna_requisicion_compra,
            this.tiempo_muerto,
            this.tiempo_fabricacion,
            this.tiempo_total_fabricacion});
            this.DgvProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProcesos.Location = new System.Drawing.Point(0, 0);
            this.DgvProcesos.Name = "DgvProcesos";
            this.DgvProcesos.ReadOnly = true;
            this.DgvProcesos.RowHeadersVisible = false;
            this.DgvProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProcesos.Size = new System.Drawing.Size(865, 508);
            this.DgvProcesos.TabIndex = 30;
            this.DgvProcesos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProcesos_CellClick);
            this.DgvProcesos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvProcesos_CellMouseDown);
            // 
            // BtnEnviarAInspeccion
            // 
            this.BtnEnviarAInspeccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnEnviarAInspeccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnEnviarAInspeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviarAInspeccion.Image = global::CB_Base.Properties.Resources.next_icon_32;
            this.BtnEnviarAInspeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEnviarAInspeccion.Location = new System.Drawing.Point(0, 190);
            this.BtnEnviarAInspeccion.Name = "BtnEnviarAInspeccion";
            this.BtnEnviarAInspeccion.Size = new System.Drawing.Size(209, 38);
            this.BtnEnviarAInspeccion.TabIndex = 21;
            this.BtnEnviarAInspeccion.Text = "        Enviar a inspección";
            this.BtnEnviarAInspeccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEnviarAInspeccion.UseVisualStyleBackColor = true;
            this.BtnEnviarAInspeccion.Click += new System.EventHandler(this.BtnTiempoFabricacion_Click);
            // 
            // BtnValeSalida
            // 
            this.BtnValeSalida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnValeSalida.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnValeSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValeSalida.Image = global::CB_Base.Properties.Resources.Nota;
            this.BtnValeSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnValeSalida.Location = new System.Drawing.Point(0, 152);
            this.BtnValeSalida.Name = "BtnValeSalida";
            this.BtnValeSalida.Size = new System.Drawing.Size(209, 38);
            this.BtnValeSalida.TabIndex = 20;
            this.BtnValeSalida.Text = "         Vales de salida ";
            this.BtnValeSalida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnValeSalida.UseVisualStyleBackColor = true;
            this.BtnValeSalida.Click += new System.EventHandler(this.BtnValeSalida_Click);
            // 
            // BtnTerminarPieza
            // 
            this.BtnTerminarPieza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnTerminarPieza.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnTerminarPieza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTerminarPieza.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnTerminarPieza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTerminarPieza.Location = new System.Drawing.Point(0, 114);
            this.BtnTerminarPieza.Name = "BtnTerminarPieza";
            this.BtnTerminarPieza.Size = new System.Drawing.Size(209, 38);
            this.BtnTerminarPieza.TabIndex = 19;
            this.BtnTerminarPieza.Text = "         Pieza terminada ";
            this.BtnTerminarPieza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTerminarPieza.UseVisualStyleBackColor = true;
            this.BtnTerminarPieza.Click += new System.EventHandler(this.BtnTerminarPieza_Click);
            // 
            // BtnEditarProceso
            // 
            this.BtnEditarProceso.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnEditarProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditarProceso.Image = global::CB_Base.Properties.Resources.Edit;
            this.BtnEditarProceso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditarProceso.Location = new System.Drawing.Point(0, 76);
            this.BtnEditarProceso.Name = "BtnEditarProceso";
            this.BtnEditarProceso.Size = new System.Drawing.Size(209, 38);
            this.BtnEditarProceso.TabIndex = 11;
            this.BtnEditarProceso.Text = "         Editar proceso      ";
            this.BtnEditarProceso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditarProceso.UseVisualStyleBackColor = true;
            this.BtnEditarProceso.Click += new System.EventHandler(this.BtnEditarProceso_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnAgregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Image = global::CB_Base.Properties.Resources.Add_icon__2_;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(0, 38);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(209, 38);
            this.BtnAgregar.TabIndex = 10;
            this.BtnAgregar.Text = "         Agregar proceso  ";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.BtnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnImprimir.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnImprimir.Image = global::CB_Base.Properties.Resources.print3;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(0, 0);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(209, 38);
            this.BtnImprimir.TabIndex = 18;
            this.BtnImprimir.Text = "         Imprimir plan";
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.UseVisualStyleBackColor = false;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // Material
            // 
            this.Material.Controls.Add(this.DgvMaterial);
            this.Material.Controls.Add(this.panel1);
            this.Material.ImageIndex = 1;
            this.Material.Location = new System.Drawing.Point(4, 31);
            this.Material.Name = "Material";
            this.Material.Padding = new System.Windows.Forms.Padding(3);
            this.Material.Size = new System.Drawing.Size(1084, 514);
            this.Material.TabIndex = 1;
            this.Material.Text = "Material";
            this.Material.UseVisualStyleBackColor = true;
            // 
            // DgvMaterial
            // 
            this.DgvMaterial.AllowUserToAddRows = false;
            this.DgvMaterial.AllowUserToDeleteRows = false;
            this.DgvMaterial.AllowUserToResizeRows = false;
            this.DgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_requisicion,
            this.requisitor,
            this.numero_parte,
            this.descripcion,
            this.cantidad,
            this.estatus_compras,
            this.estatus_almacen});
            this.DgvMaterial.ContextMenuStrip = this.OpcionesMaterial;
            this.DgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMaterial.Location = new System.Drawing.Point(3, 40);
            this.DgvMaterial.Name = "DgvMaterial";
            this.DgvMaterial.ReadOnly = true;
            this.DgvMaterial.RowHeadersVisible = false;
            this.DgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMaterial.Size = new System.Drawing.Size(1078, 471);
            this.DgvMaterial.TabIndex = 1;
            // 
            // id_requisicion
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_requisicion.DefaultCellStyle = dataGridViewCellStyle10;
            this.id_requisicion.Frozen = true;
            this.id_requisicion.HeaderText = "# Req.";
            this.id_requisicion.Name = "id_requisicion";
            this.id_requisicion.ReadOnly = true;
            this.id_requisicion.Width = 70;
            // 
            // requisitor
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.requisitor.DefaultCellStyle = dataGridViewCellStyle11;
            this.requisitor.Frozen = true;
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            this.requisitor.Width = 150;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle12;
            this.numero_parte.Frozen = true;
            this.numero_parte.HeaderText = "Número de parte";
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            this.numero_parte.Width = 150;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle13;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // estatus_compras
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_compras.DefaultCellStyle = dataGridViewCellStyle14;
            this.estatus_compras.HeaderText = "Estatus compra";
            this.estatus_compras.Name = "estatus_compras";
            this.estatus_compras.ReadOnly = true;
            this.estatus_compras.Width = 150;
            // 
            // estatus_almacen
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_almacen.DefaultCellStyle = dataGridViewCellStyle15;
            this.estatus_almacen.HeaderText = "Estatus almacén";
            this.estatus_almacen.Name = "estatus_almacen";
            this.estatus_almacen.ReadOnly = true;
            this.estatus_almacen.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChkMaterialStock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 37);
            this.panel1.TabIndex = 0;
            // 
            // ChkMaterialStock
            // 
            this.ChkMaterialStock.AutoSize = true;
            this.ChkMaterialStock.Location = new System.Drawing.Point(15, 12);
            this.ChkMaterialStock.Name = "ChkMaterialStock";
            this.ChkMaterialStock.Size = new System.Drawing.Size(107, 17);
            this.ChkMaterialStock.TabIndex = 0;
            this.ChkMaterialStock.Text = "Material en stock";
            this.ChkMaterialStock.UseVisualStyleBackColor = true;
            this.ChkMaterialStock.CheckedChanged += new System.EventHandler(this.ChkMaterialStock_CheckedChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1386, 25);
            this.LblTitulo.TabIndex = 29;
            this.LblTitulo.Text = "PLAN DE TRABAJO PARA FABRICACION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // columna_proceso
            // 
            this.columna_proceso.Frozen = true;
            this.columna_proceso.HeaderText = "Proceso";
            this.columna_proceso.Name = "columna_proceso";
            this.columna_proceso.ReadOnly = true;
            this.columna_proceso.Width = 200;
            // 
            // maquina
            // 
            this.maquina.HeaderText = "Maquina herramienta";
            this.maquina.Name = "maquina";
            this.maquina.ReadOnly = true;
            this.maquina.Width = 200;
            // 
            // programador
            // 
            this.programador.HeaderText = "Programador";
            this.programador.Name = "programador";
            this.programador.ReadOnly = true;
            this.programador.Visible = false;
            this.programador.Width = 200;
            // 
            // herramentista
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.herramentista.DefaultCellStyle = dataGridViewCellStyle2;
            this.herramentista.HeaderText = "Herramentista";
            this.herramentista.Name = "herramentista";
            this.herramentista.ReadOnly = true;
            this.herramentista.Width = 200;
            // 
            // estatus
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 120;
            // 
            // fecha_inicio
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_inicio.DefaultCellStyle = dataGridViewCellStyle4;
            this.fecha_inicio.HeaderText = "Fecha y hora de inicio";
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.ReadOnly = true;
            this.fecha_inicio.Width = 180;
            // 
            // fecha_termino
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_termino.DefaultCellStyle = dataGridViewCellStyle5;
            this.fecha_termino.HeaderText = "Fecha y hora de finalización";
            this.fecha_termino.Name = "fecha_termino";
            this.fecha_termino.ReadOnly = true;
            this.fecha_termino.Width = 180;
            // 
            // comentarios
            // 
            this.comentarios.HeaderText = "Comentarios";
            this.comentarios.MinimumWidth = 100;
            this.comentarios.Name = "comentarios";
            this.comentarios.ReadOnly = true;
            this.comentarios.Width = 300;
            // 
            // proceso_anterior
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proceso_anterior.DefaultCellStyle = dataGridViewCellStyle6;
            this.proceso_anterior.HeaderText = "Proceso anterior";
            this.proceso_anterior.MinimumWidth = 80;
            this.proceso_anterior.Name = "proceso_anterior";
            this.proceso_anterior.ReadOnly = true;
            this.proceso_anterior.Width = 80;
            // 
            // col_categoria
            // 
            this.col_categoria.HeaderText = "Columna categoria";
            this.col_categoria.Name = "col_categoria";
            this.col_categoria.ReadOnly = true;
            this.col_categoria.Visible = false;
            // 
            // columna_requisicion_compra
            // 
            this.columna_requisicion_compra.HeaderText = "Requisicion";
            this.columna_requisicion_compra.Name = "columna_requisicion_compra";
            this.columna_requisicion_compra.ReadOnly = true;
            this.columna_requisicion_compra.Visible = false;
            // 
            // tiempo_muerto
            // 
            this.tiempo_muerto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_muerto.DefaultCellStyle = dataGridViewCellStyle7;
            this.tiempo_muerto.HeaderText = "Tiempo muerto";
            this.tiempo_muerto.MinimumWidth = 100;
            this.tiempo_muerto.Name = "tiempo_muerto";
            this.tiempo_muerto.ReadOnly = true;
            // 
            // tiempo_fabricacion
            // 
            this.tiempo_fabricacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_fabricacion.DefaultCellStyle = dataGridViewCellStyle8;
            this.tiempo_fabricacion.HeaderText = "Tiempo de fabricación";
            this.tiempo_fabricacion.MinimumWidth = 100;
            this.tiempo_fabricacion.Name = "tiempo_fabricacion";
            this.tiempo_fabricacion.ReadOnly = true;
            // 
            // tiempo_total_fabricacion
            // 
            this.tiempo_total_fabricacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_total_fabricacion.DefaultCellStyle = dataGridViewCellStyle9;
            this.tiempo_total_fabricacion.HeaderText = "Tiempo total de fabricación";
            this.tiempo_total_fabricacion.MinimumWidth = 100;
            this.tiempo_total_fabricacion.Name = "tiempo_total_fabricacion";
            this.tiempo_total_fabricacion.ReadOnly = true;
            // 
            // FrmPlanTrabajoPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 597);
            this.Controls.Add(this.LblEstatusDescargar);
            this.Controls.Add(this.ProgresoDescarga);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPlanTrabajoPlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Plan de trabajo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPlanTrabajoPlano_FormClosed);
            this.Load += new System.EventHandler(this.FrmPlanTrabajoPlano_Load);
            this.Shown += new System.EventHandler(this.FrmPlanTrabajoPlano_Shown);
            this.OpcionesMaterial.ResumeLayout(false);
            this.OpcionesProceso.ResumeLayout(false);
            this.MenuValeSalida.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicMiniatura)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Procesos.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesos)).EndInit();
            this.Material.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView DgvProcesos;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnEditarProceso;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Procesos;
        private System.Windows.Forms.TabPage Material;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip OpcionesMaterial;
        private System.Windows.Forms.ToolStripMenuItem seleccionarDelCatálogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip OpcionesProceso;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verRequisiciónDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.Button BtnTerminarPieza;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox PicMiniatura;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnGenerarMiniatura;
        private System.Windows.Forms.Button BtnVerPDF;
        private System.Windows.Forms.Label LblNumeroPlano;
        private System.Windows.Forms.Button BtnVerDetalles;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.DataGridView DgvMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_requisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_compras;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_almacen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ChkMaterialStock;
        private System.ComponentModel.BackgroundWorker BkgDescargarMiniatura;
        private System.Windows.Forms.Label LblEstatusDescargar;
        private System.Windows.Forms.ProgressBar ProgresoDescarga;
        private System.ComponentModel.BackgroundWorker BkgDescargarProcesos;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlano;
        private System.Windows.Forms.ToolStripMenuItem planificarTiempoExtraToolStripMenuItem;
        private System.Windows.Forms.Button BtnResultadosInspeccion;
        private System.Windows.Forms.Button BtnValeSalida;
        private System.Windows.Forms.ContextMenuStrip MenuValeSalida;
        private System.Windows.Forms.ToolStripMenuItem piezaFabricadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tratamientoDeMaterialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem piezasEntregadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarAsignacionToolStripMenuItem;
        private System.Windows.Forms.Button BtnEnviarAInspeccion;
        private System.Windows.Forms.ToolStripMenuItem tiempoDeFabricaciónToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna_proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn maquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn programador;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramentista;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn proceso_anterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna_requisicion_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_muerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_fabricacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_total_fabricacion;
    }
}
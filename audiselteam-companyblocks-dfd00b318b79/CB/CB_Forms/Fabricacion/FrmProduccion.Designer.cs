namespace CB
{
    partial class FrmProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduccion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ImgListElementos = new System.Windows.Forms.ImageList(this.components);
            this.BkgDescargarHerramentista = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarPlano = new System.ComponentModel.BackgroundWorker();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BkgPiezaTerminada = new System.ComponentModel.BackgroundWorker();
            this.BkgPiezaEntregada = new System.ComponentModel.BackgroundWorker();
            this.chkVistaPrevia = new System.Windows.Forms.CheckBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbCntrlElementos = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LblProcesosEstatus = new System.Windows.Forms.Label();
            this.progressBarProcesos = new System.Windows.Forms.ProgressBar();
            this.DgvProcesosTerminados = new System.Windows.Forms.DataGridView();
            this.id_produccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano_produccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto_produccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proceso_produccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramentista_produccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_finalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miniatura = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbHerramentista = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LblEstatusTerminado = new System.Windows.Forms.Label();
            this.ProgresoTerminado = new System.Windows.Forms.ProgressBar();
            this.DgvPiezaTerminada = new System.Windows.Forms.DataGridView();
            this.id_terminado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano_piezaTerminada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto_piezaTerminada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_piezaTerminada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicioPiezaTerminada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_finPiezaTerminada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miniatura_piezaTerminada = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.LblEstatusEntregado = new System.Windows.Forms.Label();
            this.ProgresoEntregado = new System.Windows.Forms.ProgressBar();
            this.DgvPiezaEntregada = new System.Windows.Forms.DataGridView();
            this.id_entregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano_entregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prpyecto_entregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_entregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicioEntregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_finEntregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miniatura_entregado = new System.Windows.Forms.DataGridViewImageColumn();
            this.DateFechaSeleccionada = new System.Windows.Forms.DateTimePicker();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DgvProcesoEnCurso = new System.Windows.Forms.DataGridView();
            this.LblEstatusProcesoEnCurso = new System.Windows.Forms.Label();
            this.ProgressProcesoEnCurso = new System.Windows.Forms.ProgressBar();
            this.BkgDescargarProcesoEnCurso = new System.ComponentModel.BackgroundWorker();
            this.id_enProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano_procesoEnCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto_procesoEnCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proceso_enCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramentista_procesoEnCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicial_procesoEnCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_finalizacion_procesoEnCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miniatura_enProceso = new System.Windows.Forms.DataGridViewImageColumn();
            this.TbCntrlElementos.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesosTerminados)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPiezaTerminada)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPiezaEntregada)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesoEnCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgListElementos
            // 
            this.ImgListElementos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgListElementos.ImageStream")));
            this.ImgListElementos.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgListElementos.Images.SetKeyName(0, "Oxygen-Icons.org-Oxygen-Actions-dialog-ok-apply.ico");
            this.ImgListElementos.Images.SetKeyName(1, "finiched-process.png");
            this.ImgListElementos.Images.SetKeyName(2, "assign-activity.png");
            this.ImgListElementos.Images.SetKeyName(3, "working.png");
            // 
            // BkgDescargarHerramentista
            // 
            this.BkgDescargarHerramentista.WorkerReportsProgress = true;
            this.BkgDescargarHerramentista.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarHerramentista_DoWork);
            this.BkgDescargarHerramentista.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarHerramentista_ProgressChanged);
            this.BkgDescargarHerramentista.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarHerramentista_RunWorkerCompleted);
            // 
            // BkgDescargarPlano
            // 
            this.BkgDescargarPlano.WorkerReportsProgress = true;
            this.BkgDescargarPlano.WorkerSupportsCancellation = true;
            this.BkgDescargarPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPlano_DoWork);
            this.BkgDescargarPlano.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarPlano_ProgressChanged);
            this.BkgDescargarPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarPlano_RunWorkerCompleted);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // BkgPiezaTerminada
            // 
            this.BkgPiezaTerminada.WorkerReportsProgress = true;
            this.BkgPiezaTerminada.WorkerSupportsCancellation = true;
            this.BkgPiezaTerminada.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgPiezaTerminada_DoWork);
            this.BkgPiezaTerminada.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgPiezaTerminada_ProgressChanged);
            this.BkgPiezaTerminada.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgPiezaTerminada_RunWorkerCompleted);
            // 
            // BkgPiezaEntregada
            // 
            this.BkgPiezaEntregada.WorkerReportsProgress = true;
            this.BkgPiezaEntregada.WorkerSupportsCancellation = true;
            this.BkgPiezaEntregada.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgPiezaEntregada_DoWork);
            this.BkgPiezaEntregada.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgPiezaEntregada_ProgressChanged);
            this.BkgPiezaEntregada.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgPiezaEntregada_RunWorkerCompleted);
            // 
            // chkVistaPrevia
            // 
            this.chkVistaPrevia.AutoSize = true;
            this.chkVistaPrevia.Checked = true;
            this.chkVistaPrevia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVistaPrevia.Location = new System.Drawing.Point(362, 58);
            this.chkVistaPrevia.Name = "chkVistaPrevia";
            this.chkVistaPrevia.Size = new System.Drawing.Size(164, 17);
            this.chkVistaPrevia.TabIndex = 94;
            this.chkVistaPrevia.Text = "Mostrar vista previa del plano";
            this.chkVistaPrevia.UseVisualStyleBackColor = true;
            this.chkVistaPrevia.CheckedChanged += new System.EventHandler(this.chkVistaPrevia_CheckedChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1245, 29);
            this.LblTitulo.TabIndex = 71;
            this.LblTitulo.Text = "PRODUCCION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Fecha:";
            // 
            // TbCntrlElementos
            // 
            this.TbCntrlElementos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbCntrlElementos.Controls.Add(this.tabPage4);
            this.TbCntrlElementos.Controls.Add(this.tabPage1);
            this.TbCntrlElementos.Controls.Add(this.tabPage2);
            this.TbCntrlElementos.Controls.Add(this.tabPage3);
            this.TbCntrlElementos.ImageList = this.ImgListElementos;
            this.TbCntrlElementos.ItemSize = new System.Drawing.Size(90, 21);
            this.TbCntrlElementos.Location = new System.Drawing.Point(0, 85);
            this.TbCntrlElementos.Name = "TbCntrlElementos";
            this.TbCntrlElementos.SelectedIndex = 0;
            this.TbCntrlElementos.Size = new System.Drawing.Size(1245, 636);
            this.TbCntrlElementos.TabIndex = 68;
            this.TbCntrlElementos.SelectedIndexChanged += new System.EventHandler(this.TbCntrlElementos_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LblProcesosEstatus);
            this.tabPage1.Controls.Add(this.progressBarProcesos);
            this.tabPage1.Controls.Add(this.DgvProcesosTerminados);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1237, 607);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Procesos terminados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LblProcesosEstatus
            // 
            this.LblProcesosEstatus.BackColor = System.Drawing.Color.Black;
            this.LblProcesosEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblProcesosEstatus.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProcesosEstatus.ForeColor = System.Drawing.Color.Lime;
            this.LblProcesosEstatus.Location = new System.Drawing.Point(3, 552);
            this.LblProcesosEstatus.Name = "LblProcesosEstatus";
            this.LblProcesosEstatus.Size = new System.Drawing.Size(1231, 29);
            this.LblProcesosEstatus.TabIndex = 75;
            this.LblProcesosEstatus.Text = "Estatus...";
            this.LblProcesosEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarProcesos
            // 
            this.progressBarProcesos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarProcesos.Location = new System.Drawing.Point(3, 581);
            this.progressBarProcesos.Name = "progressBarProcesos";
            this.progressBarProcesos.Size = new System.Drawing.Size(1231, 23);
            this.progressBarProcesos.TabIndex = 74;
            // 
            // DgvProcesosTerminados
            // 
            this.DgvProcesosTerminados.AllowUserToAddRows = false;
            this.DgvProcesosTerminados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvProcesosTerminados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesosTerminados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvProcesosTerminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProcesosTerminados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_produccion,
            this.plano_produccion,
            this.proyecto_produccion,
            this.proceso_produccion,
            this.herramentista_produccion,
            this.fecha_inicio,
            this.fecha_finalizacion,
            this.miniatura});
            this.DgvProcesosTerminados.Location = new System.Drawing.Point(3, 71);
            this.DgvProcesosTerminados.Name = "DgvProcesosTerminados";
            this.DgvProcesosTerminados.RowHeadersVisible = false;
            this.DgvProcesosTerminados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProcesosTerminados.Size = new System.Drawing.Size(1231, 510);
            this.DgvProcesosTerminados.TabIndex = 67;
            this.DgvProcesosTerminados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProcesosTerminados_CellDoubleClick);
            // 
            // id_produccion
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id_produccion.DefaultCellStyle = dataGridViewCellStyle10;
            this.id_produccion.HeaderText = "ID";
            this.id_produccion.MinimumWidth = 60;
            this.id_produccion.Name = "id_produccion";
            this.id_produccion.ReadOnly = true;
            this.id_produccion.Width = 60;
            // 
            // plano_produccion
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.plano_produccion.DefaultCellStyle = dataGridViewCellStyle11;
            this.plano_produccion.HeaderText = "Plano";
            this.plano_produccion.MinimumWidth = 200;
            this.plano_produccion.Name = "plano_produccion";
            this.plano_produccion.ReadOnly = true;
            this.plano_produccion.Width = 200;
            // 
            // proyecto_produccion
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proyecto_produccion.DefaultCellStyle = dataGridViewCellStyle12;
            this.proyecto_produccion.HeaderText = "Proyecto";
            this.proyecto_produccion.MinimumWidth = 70;
            this.proyecto_produccion.Name = "proyecto_produccion";
            this.proyecto_produccion.ReadOnly = true;
            this.proyecto_produccion.Width = 70;
            // 
            // proceso_produccion
            // 
            this.proceso_produccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proceso_produccion.DefaultCellStyle = dataGridViewCellStyle13;
            this.proceso_produccion.HeaderText = "Proceso";
            this.proceso_produccion.MinimumWidth = 200;
            this.proceso_produccion.Name = "proceso_produccion";
            this.proceso_produccion.ReadOnly = true;
            // 
            // herramentista_produccion
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.herramentista_produccion.DefaultCellStyle = dataGridViewCellStyle14;
            this.herramentista_produccion.HeaderText = "Herramentista";
            this.herramentista_produccion.MinimumWidth = 220;
            this.herramentista_produccion.Name = "herramentista_produccion";
            this.herramentista_produccion.ReadOnly = true;
            this.herramentista_produccion.Visible = false;
            this.herramentista_produccion.Width = 220;
            // 
            // fecha_inicio
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_inicio.DefaultCellStyle = dataGridViewCellStyle15;
            this.fecha_inicio.HeaderText = "Fecha y hora de inicio";
            this.fecha_inicio.MinimumWidth = 150;
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.ReadOnly = true;
            this.fecha_inicio.Width = 150;
            // 
            // fecha_finalizacion
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_finalizacion.DefaultCellStyle = dataGridViewCellStyle16;
            this.fecha_finalizacion.HeaderText = "Fecha y hora de finalización";
            this.fecha_finalizacion.MinimumWidth = 160;
            this.fecha_finalizacion.Name = "fecha_finalizacion";
            this.fecha_finalizacion.ReadOnly = true;
            this.fecha_finalizacion.Width = 160;
            // 
            // miniatura
            // 
            this.miniatura.HeaderText = "Vista previa";
            this.miniatura.MinimumWidth = 250;
            this.miniatura.Name = "miniatura";
            this.miniatura.ReadOnly = true;
            this.miniatura.Width = 250;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbHerramentista);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1231, 68);
            this.panel1.TabIndex = 66;
            // 
            // CmbHerramentista
            // 
            this.CmbHerramentista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbHerramentista.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbHerramentista.FormattingEnabled = true;
            this.CmbHerramentista.Location = new System.Drawing.Point(0, 23);
            this.CmbHerramentista.Name = "CmbHerramentista";
            this.CmbHerramentista.Size = new System.Drawing.Size(340, 32);
            this.CmbHerramentista.TabIndex = 62;
            this.CmbHerramentista.SelectedIndexChanged += new System.EventHandler(this.CmbHerramentista_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Herramentista:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LblEstatusTerminado);
            this.tabPage2.Controls.Add(this.ProgresoTerminado);
            this.tabPage2.Controls.Add(this.DgvPiezaTerminada);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1237, 607);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Piezas fabricadas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LblEstatusTerminado
            // 
            this.LblEstatusTerminado.BackColor = System.Drawing.Color.Black;
            this.LblEstatusTerminado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusTerminado.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusTerminado.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusTerminado.Location = new System.Drawing.Point(0, 555);
            this.LblEstatusTerminado.Name = "LblEstatusTerminado";
            this.LblEstatusTerminado.Size = new System.Drawing.Size(1237, 29);
            this.LblEstatusTerminado.TabIndex = 72;
            this.LblEstatusTerminado.Text = "Estatus...";
            this.LblEstatusTerminado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoTerminado
            // 
            this.ProgresoTerminado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoTerminado.Location = new System.Drawing.Point(0, 584);
            this.ProgresoTerminado.Name = "ProgresoTerminado";
            this.ProgresoTerminado.Size = new System.Drawing.Size(1237, 23);
            this.ProgresoTerminado.TabIndex = 71;
            // 
            // DgvPiezaTerminada
            // 
            this.DgvPiezaTerminada.AllowUserToAddRows = false;
            this.DgvPiezaTerminada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvPiezaTerminada.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPiezaTerminada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.DgvPiezaTerminada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPiezaTerminada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_terminado,
            this.plano_piezaTerminada,
            this.proyecto_piezaTerminada,
            this.cantidad_piezaTerminada,
            this.fecha_inicioPiezaTerminada,
            this.fecha_finPiezaTerminada,
            this.miniatura_piezaTerminada});
            this.DgvPiezaTerminada.Location = new System.Drawing.Point(0, 0);
            this.DgvPiezaTerminada.Name = "DgvPiezaTerminada";
            this.DgvPiezaTerminada.RowHeadersVisible = false;
            this.DgvPiezaTerminada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPiezaTerminada.Size = new System.Drawing.Size(1237, 584);
            this.DgvPiezaTerminada.TabIndex = 68;
            this.DgvPiezaTerminada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPiezaTerminada_CellDoubleClick);
            // 
            // id_terminado
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id_terminado.DefaultCellStyle = dataGridViewCellStyle18;
            this.id_terminado.HeaderText = "ID";
            this.id_terminado.MinimumWidth = 70;
            this.id_terminado.Name = "id_terminado";
            this.id_terminado.ReadOnly = true;
            this.id_terminado.Width = 70;
            // 
            // plano_piezaTerminada
            // 
            this.plano_piezaTerminada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.plano_piezaTerminada.DefaultCellStyle = dataGridViewCellStyle19;
            this.plano_piezaTerminada.HeaderText = "Plano";
            this.plano_piezaTerminada.MinimumWidth = 300;
            this.plano_piezaTerminada.Name = "plano_piezaTerminada";
            this.plano_piezaTerminada.ReadOnly = true;
            // 
            // proyecto_piezaTerminada
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proyecto_piezaTerminada.DefaultCellStyle = dataGridViewCellStyle20;
            this.proyecto_piezaTerminada.HeaderText = "Proyecto";
            this.proyecto_piezaTerminada.MinimumWidth = 120;
            this.proyecto_piezaTerminada.Name = "proyecto_piezaTerminada";
            this.proyecto_piezaTerminada.ReadOnly = true;
            this.proyecto_piezaTerminada.Width = 120;
            // 
            // cantidad_piezaTerminada
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad_piezaTerminada.DefaultCellStyle = dataGridViewCellStyle21;
            this.cantidad_piezaTerminada.HeaderText = "Cantidad";
            this.cantidad_piezaTerminada.MinimumWidth = 100;
            this.cantidad_piezaTerminada.Name = "cantidad_piezaTerminada";
            this.cantidad_piezaTerminada.ReadOnly = true;
            // 
            // fecha_inicioPiezaTerminada
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_inicioPiezaTerminada.DefaultCellStyle = dataGridViewCellStyle22;
            this.fecha_inicioPiezaTerminada.HeaderText = "Fecha y hora de inicio";
            this.fecha_inicioPiezaTerminada.MinimumWidth = 150;
            this.fecha_inicioPiezaTerminada.Name = "fecha_inicioPiezaTerminada";
            this.fecha_inicioPiezaTerminada.ReadOnly = true;
            this.fecha_inicioPiezaTerminada.Width = 150;
            // 
            // fecha_finPiezaTerminada
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_finPiezaTerminada.DefaultCellStyle = dataGridViewCellStyle23;
            this.fecha_finPiezaTerminada.HeaderText = "Fecha y hora de finalización";
            this.fecha_finPiezaTerminada.MinimumWidth = 160;
            this.fecha_finPiezaTerminada.Name = "fecha_finPiezaTerminada";
            this.fecha_finPiezaTerminada.ReadOnly = true;
            this.fecha_finPiezaTerminada.Width = 160;
            // 
            // miniatura_piezaTerminada
            // 
            this.miniatura_piezaTerminada.HeaderText = "Vista previa";
            this.miniatura_piezaTerminada.MinimumWidth = 250;
            this.miniatura_piezaTerminada.Name = "miniatura_piezaTerminada";
            this.miniatura_piezaTerminada.ReadOnly = true;
            this.miniatura_piezaTerminada.Width = 250;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.LblEstatusEntregado);
            this.tabPage3.Controls.Add(this.ProgresoEntregado);
            this.tabPage3.Controls.Add(this.DgvPiezaEntregada);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1237, 607);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Piezas entregadas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // LblEstatusEntregado
            // 
            this.LblEstatusEntregado.BackColor = System.Drawing.Color.Black;
            this.LblEstatusEntregado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusEntregado.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusEntregado.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusEntregado.Location = new System.Drawing.Point(0, 555);
            this.LblEstatusEntregado.Name = "LblEstatusEntregado";
            this.LblEstatusEntregado.Size = new System.Drawing.Size(1237, 29);
            this.LblEstatusEntregado.TabIndex = 72;
            this.LblEstatusEntregado.Text = "Estatus...";
            this.LblEstatusEntregado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoEntregado
            // 
            this.ProgresoEntregado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoEntregado.Location = new System.Drawing.Point(0, 584);
            this.ProgresoEntregado.Name = "ProgresoEntregado";
            this.ProgresoEntregado.Size = new System.Drawing.Size(1237, 23);
            this.ProgresoEntregado.TabIndex = 71;
            // 
            // DgvPiezaEntregada
            // 
            this.DgvPiezaEntregada.AllowUserToAddRows = false;
            this.DgvPiezaEntregada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvPiezaEntregada.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPiezaEntregada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.DgvPiezaEntregada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPiezaEntregada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_entregado,
            this.plano_entregado,
            this.prpyecto_entregado,
            this.cantidad_entregado,
            this.fecha_inicioEntregado,
            this.fecha_finEntregado,
            this.miniatura_entregado});
            this.DgvPiezaEntregada.Location = new System.Drawing.Point(0, 0);
            this.DgvPiezaEntregada.Name = "DgvPiezaEntregada";
            this.DgvPiezaEntregada.RowHeadersVisible = false;
            this.DgvPiezaEntregada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPiezaEntregada.Size = new System.Drawing.Size(1237, 584);
            this.DgvPiezaEntregada.TabIndex = 68;
            this.DgvPiezaEntregada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPiezaEntregada_CellDoubleClick);
            // 
            // id_entregado
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id_entregado.DefaultCellStyle = dataGridViewCellStyle25;
            this.id_entregado.HeaderText = "ID";
            this.id_entregado.MinimumWidth = 70;
            this.id_entregado.Name = "id_entregado";
            this.id_entregado.ReadOnly = true;
            this.id_entregado.Width = 70;
            // 
            // plano_entregado
            // 
            this.plano_entregado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.plano_entregado.DefaultCellStyle = dataGridViewCellStyle26;
            this.plano_entregado.HeaderText = "Plano";
            this.plano_entregado.MinimumWidth = 300;
            this.plano_entregado.Name = "plano_entregado";
            this.plano_entregado.ReadOnly = true;
            // 
            // prpyecto_entregado
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.prpyecto_entregado.DefaultCellStyle = dataGridViewCellStyle27;
            this.prpyecto_entregado.HeaderText = "Proyecto";
            this.prpyecto_entregado.MinimumWidth = 120;
            this.prpyecto_entregado.Name = "prpyecto_entregado";
            this.prpyecto_entregado.ReadOnly = true;
            this.prpyecto_entregado.Width = 120;
            // 
            // cantidad_entregado
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad_entregado.DefaultCellStyle = dataGridViewCellStyle28;
            this.cantidad_entregado.HeaderText = "Cantidad";
            this.cantidad_entregado.MinimumWidth = 100;
            this.cantidad_entregado.Name = "cantidad_entregado";
            this.cantidad_entregado.ReadOnly = true;
            // 
            // fecha_inicioEntregado
            // 
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_inicioEntregado.DefaultCellStyle = dataGridViewCellStyle29;
            this.fecha_inicioEntregado.HeaderText = "Fecha y hora de inicio";
            this.fecha_inicioEntregado.MinimumWidth = 150;
            this.fecha_inicioEntregado.Name = "fecha_inicioEntregado";
            this.fecha_inicioEntregado.ReadOnly = true;
            this.fecha_inicioEntregado.Width = 150;
            // 
            // fecha_finEntregado
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_finEntregado.DefaultCellStyle = dataGridViewCellStyle30;
            this.fecha_finEntregado.HeaderText = "Fecha y hora de finalización";
            this.fecha_finEntregado.MinimumWidth = 160;
            this.fecha_finEntregado.Name = "fecha_finEntregado";
            this.fecha_finEntregado.ReadOnly = true;
            this.fecha_finEntregado.Width = 160;
            // 
            // miniatura_entregado
            // 
            this.miniatura_entregado.HeaderText = "Vista previa";
            this.miniatura_entregado.MinimumWidth = 250;
            this.miniatura_entregado.Name = "miniatura_entregado";
            this.miniatura_entregado.ReadOnly = true;
            this.miniatura_entregado.Width = 250;
            // 
            // DateFechaSeleccionada
            // 
            this.DateFechaSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.DateFechaSeleccionada.Location = new System.Drawing.Point(7, 50);
            this.DateFechaSeleccionada.Name = "DateFechaSeleccionada";
            this.DateFechaSeleccionada.Size = new System.Drawing.Size(337, 29);
            this.DateFechaSeleccionada.TabIndex = 64;
            this.DateFechaSeleccionada.ValueChanged += new System.EventHandler(this.DateFechaSeleccionada_ValueChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.LblEstatusProcesoEnCurso);
            this.tabPage4.Controls.Add(this.ProgressProcesoEnCurso);
            this.tabPage4.Controls.Add(this.DgvProcesoEnCurso);
            this.tabPage4.ImageIndex = 3;
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1237, 607);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Procesos en curso";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DgvProcesoEnCurso
            // 
            this.DgvProcesoEnCurso.AllowUserToAddRows = false;
            this.DgvProcesoEnCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvProcesoEnCurso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesoEnCurso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvProcesoEnCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProcesoEnCurso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_enProceso,
            this.plano_procesoEnCurso,
            this.proyecto_procesoEnCurso,
            this.proceso_enCurso,
            this.herramentista_procesoEnCurso,
            this.fecha_inicial_procesoEnCurso,
            this.fecha_finalizacion_procesoEnCurso,
            this.miniatura_enProceso});
            this.DgvProcesoEnCurso.Location = new System.Drawing.Point(3, 3);
            this.DgvProcesoEnCurso.Name = "DgvProcesoEnCurso";
            this.DgvProcesoEnCurso.RowHeadersVisible = false;
            this.DgvProcesoEnCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProcesoEnCurso.Size = new System.Drawing.Size(1231, 581);
            this.DgvProcesoEnCurso.TabIndex = 68;
            this.DgvProcesoEnCurso.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProcesoEnCurso_CellDoubleClick);
            // 
            // LblEstatusProcesoEnCurso
            // 
            this.LblEstatusProcesoEnCurso.BackColor = System.Drawing.Color.Black;
            this.LblEstatusProcesoEnCurso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusProcesoEnCurso.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusProcesoEnCurso.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusProcesoEnCurso.Location = new System.Drawing.Point(0, 555);
            this.LblEstatusProcesoEnCurso.Name = "LblEstatusProcesoEnCurso";
            this.LblEstatusProcesoEnCurso.Size = new System.Drawing.Size(1237, 29);
            this.LblEstatusProcesoEnCurso.TabIndex = 77;
            this.LblEstatusProcesoEnCurso.Text = "Estatus...";
            this.LblEstatusProcesoEnCurso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressProcesoEnCurso
            // 
            this.ProgressProcesoEnCurso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressProcesoEnCurso.Location = new System.Drawing.Point(0, 584);
            this.ProgressProcesoEnCurso.Name = "ProgressProcesoEnCurso";
            this.ProgressProcesoEnCurso.Size = new System.Drawing.Size(1237, 23);
            this.ProgressProcesoEnCurso.TabIndex = 76;
            // 
            // BkgDescargarProcesoEnCurso
            // 
            this.BkgDescargarProcesoEnCurso.WorkerReportsProgress = true;
            this.BkgDescargarProcesoEnCurso.WorkerSupportsCancellation = true;
            this.BkgDescargarProcesoEnCurso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarProcesoEnCurso_DoWork);
            this.BkgDescargarProcesoEnCurso.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarProcesoEnCurso_ProgressChanged);
            this.BkgDescargarProcesoEnCurso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarProcesoEnCurso_RunWorkerCompleted);
            // 
            // id_enProceso
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id_enProceso.DefaultCellStyle = dataGridViewCellStyle2;
            this.id_enProceso.HeaderText = "ID";
            this.id_enProceso.MinimumWidth = 60;
            this.id_enProceso.Name = "id_enProceso";
            this.id_enProceso.ReadOnly = true;
            this.id_enProceso.Width = 60;
            // 
            // plano_procesoEnCurso
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.plano_procesoEnCurso.DefaultCellStyle = dataGridViewCellStyle3;
            this.plano_procesoEnCurso.HeaderText = "Plano";
            this.plano_procesoEnCurso.MinimumWidth = 200;
            this.plano_procesoEnCurso.Name = "plano_procesoEnCurso";
            this.plano_procesoEnCurso.ReadOnly = true;
            this.plano_procesoEnCurso.Width = 200;
            // 
            // proyecto_procesoEnCurso
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proyecto_procesoEnCurso.DefaultCellStyle = dataGridViewCellStyle4;
            this.proyecto_procesoEnCurso.HeaderText = "Proyecto";
            this.proyecto_procesoEnCurso.MinimumWidth = 70;
            this.proyecto_procesoEnCurso.Name = "proyecto_procesoEnCurso";
            this.proyecto_procesoEnCurso.ReadOnly = true;
            this.proyecto_procesoEnCurso.Width = 70;
            // 
            // proceso_enCurso
            // 
            this.proceso_enCurso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proceso_enCurso.DefaultCellStyle = dataGridViewCellStyle5;
            this.proceso_enCurso.HeaderText = "Proceso";
            this.proceso_enCurso.MinimumWidth = 200;
            this.proceso_enCurso.Name = "proceso_enCurso";
            this.proceso_enCurso.ReadOnly = true;
            // 
            // herramentista_procesoEnCurso
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.herramentista_procesoEnCurso.DefaultCellStyle = dataGridViewCellStyle6;
            this.herramentista_procesoEnCurso.HeaderText = "Herramentista";
            this.herramentista_procesoEnCurso.MinimumWidth = 220;
            this.herramentista_procesoEnCurso.Name = "herramentista_procesoEnCurso";
            this.herramentista_procesoEnCurso.ReadOnly = true;
            this.herramentista_procesoEnCurso.Width = 220;
            // 
            // fecha_inicial_procesoEnCurso
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_inicial_procesoEnCurso.DefaultCellStyle = dataGridViewCellStyle7;
            this.fecha_inicial_procesoEnCurso.HeaderText = "Fecha y hora de inicio";
            this.fecha_inicial_procesoEnCurso.MinimumWidth = 150;
            this.fecha_inicial_procesoEnCurso.Name = "fecha_inicial_procesoEnCurso";
            this.fecha_inicial_procesoEnCurso.ReadOnly = true;
            this.fecha_inicial_procesoEnCurso.Width = 150;
            // 
            // fecha_finalizacion_procesoEnCurso
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_finalizacion_procesoEnCurso.DefaultCellStyle = dataGridViewCellStyle8;
            this.fecha_finalizacion_procesoEnCurso.HeaderText = "Fecha y hora de finalización";
            this.fecha_finalizacion_procesoEnCurso.MinimumWidth = 160;
            this.fecha_finalizacion_procesoEnCurso.Name = "fecha_finalizacion_procesoEnCurso";
            this.fecha_finalizacion_procesoEnCurso.ReadOnly = true;
            this.fecha_finalizacion_procesoEnCurso.Width = 160;
            // 
            // miniatura_enProceso
            // 
            this.miniatura_enProceso.HeaderText = "Vista previa";
            this.miniatura_enProceso.MinimumWidth = 250;
            this.miniatura_enProceso.Name = "miniatura_enProceso";
            this.miniatura_enProceso.ReadOnly = true;
            this.miniatura_enProceso.Width = 250;
            // 
            // FrmProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 722);
            this.Controls.Add(this.chkVistaPrevia);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TbCntrlElementos);
            this.Controls.Add(this.DateFechaSeleccionada);
            this.Name = "FrmProduccion";
            this.Text = "Producción";
            this.Load += new System.EventHandler(this.FrmProduccion_Load);
            this.Shown += new System.EventHandler(this.FrmProduccion_Shown);
            this.TbCntrlElementos.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesosTerminados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPiezaTerminada)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPiezaEntregada)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesoEnCurso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateFechaSeleccionada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl TbCntrlElementos;
        private System.Windows.Forms.ImageList ImgListElementos;
        private System.ComponentModel.BackgroundWorker BkgDescargarHerramentista;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.CheckBox chkVistaPrevia;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DgvPiezaTerminada;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView DgvPiezaEntregada;
        private System.ComponentModel.BackgroundWorker BkgPiezaTerminada;
        private System.ComponentModel.BackgroundWorker BkgPiezaEntregada;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_terminado;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano_piezaTerminada;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto_piezaTerminada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_piezaTerminada;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicioPiezaTerminada;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_finPiezaTerminada;
        private System.Windows.Forms.DataGridViewImageColumn miniatura_piezaTerminada;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_entregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano_entregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn prpyecto_entregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_entregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicioEntregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_finEntregado;
        private System.Windows.Forms.DataGridViewImageColumn miniatura_entregado;
        private System.Windows.Forms.Label LblEstatusTerminado;
        private System.Windows.Forms.ProgressBar ProgresoTerminado;
        private System.Windows.Forms.Label LblEstatusEntregado;
        private System.Windows.Forms.ProgressBar ProgresoEntregado;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label LblProcesosEstatus;
        private System.Windows.Forms.ProgressBar progressBarProcesos;
        private System.Windows.Forms.DataGridView DgvProcesosTerminados;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_produccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano_produccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto_produccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn proceso_produccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramentista_produccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_finalizacion;
        private System.Windows.Forms.DataGridViewImageColumn miniatura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CmbHerramentista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label LblEstatusProcesoEnCurso;
        private System.Windows.Forms.ProgressBar ProgressProcesoEnCurso;
        private System.Windows.Forms.DataGridView DgvProcesoEnCurso;
        private System.ComponentModel.BackgroundWorker BkgDescargarProcesoEnCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_enProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano_procesoEnCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto_procesoEnCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn proceso_enCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramentista_procesoEnCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicial_procesoEnCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_finalizacion_procesoEnCurso;
        private System.Windows.Forms.DataGridViewImageColumn miniatura_enProceso;
    }
}
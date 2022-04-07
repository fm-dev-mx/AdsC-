namespace CB
{
    partial class FrmSubirDiseno
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
            this.Cargar = new System.Windows.Forms.OpenFileDialog();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.Guardar = new System.Windows.Forms.SaveFileDialog();
            this.BuscadorCarpetas = new System.Windows.Forms.FolderBrowserDialog();
            this.BkgInicializar = new System.ComponentModel.BackgroundWorker();
            this.BkgAnalizarCarpeta = new System.ComponentModel.BackgroundWorker();
            this.BkgSubir = new System.ComponentModel.BackgroundWorker();
            this.SplitEstatus = new System.Windows.Forms.SplitContainer();
            this.SplitCarpetas = new System.Windows.Forms.SplitContainer();
            this.DgvModuloLocal = new System.Windows.Forms.DataGridView();
            this.nombre_archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conflicto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtCarpetaLocal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvModuloRemoto = new System.Windows.Forms.DataGridView();
            this.nombre_archivo_remoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamano_remoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelControles = new System.Windows.Forms.Panel();
            this.LblTotalConflictos = new System.Windows.Forms.Label();
            this.LblModulo = new System.Windows.Forms.Label();
            this.LblProyecto = new System.Windows.Forms.Label();
            this.BtnSubir = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.OpcionesCambios = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.compararToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recuperarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgRecuperarArchivo = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.SplitEstatus)).BeginInit();
            this.SplitEstatus.Panel1.SuspendLayout();
            this.SplitEstatus.Panel2.SuspendLayout();
            this.SplitEstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCarpetas)).BeginInit();
            this.SplitCarpetas.Panel1.SuspendLayout();
            this.SplitCarpetas.Panel2.SuspendLayout();
            this.SplitCarpetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModuloLocal)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModuloRemoto)).BeginInit();
            this.PanelControles.SuspendLayout();
            this.OpcionesCambios.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cargar
            // 
            this.Cargar.FileName = "openFileDialog1";
            this.Cargar.Multiselect = true;
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // BkgInicializar
            // 
            this.BkgInicializar.WorkerReportsProgress = true;
            this.BkgInicializar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgInicializar_DoWork);
            this.BkgInicializar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgInicializar_ProgressChanged);
            this.BkgInicializar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgInicializar_RunWorkerCompleted);
            // 
            // BkgAnalizarCarpeta
            // 
            this.BkgAnalizarCarpeta.WorkerReportsProgress = true;
            this.BkgAnalizarCarpeta.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgAnalizarCarpeta_DoWork);
            this.BkgAnalizarCarpeta.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgAnalizarCarpeta_ProgressChanged);
            this.BkgAnalizarCarpeta.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgAnalizarCarpeta_RunWorkerCompleted);
            // 
            // BkgSubir
            // 
            this.BkgSubir.WorkerReportsProgress = true;
            this.BkgSubir.WorkerSupportsCancellation = true;
            this.BkgSubir.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubir_DoWork);
            this.BkgSubir.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubir_ProgressChanged);
            this.BkgSubir.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubir_RunWorkerCompleted);
            // 
            // SplitEstatus
            // 
            this.SplitEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitEstatus.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitEstatus.Location = new System.Drawing.Point(0, 0);
            this.SplitEstatus.Name = "SplitEstatus";
            this.SplitEstatus.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitEstatus.Panel1
            // 
            this.SplitEstatus.Panel1.Controls.Add(this.SplitCarpetas);
            this.SplitEstatus.Panel1.Controls.Add(this.PanelControles);
            // 
            // SplitEstatus.Panel2
            // 
            this.SplitEstatus.Panel2.Controls.Add(this.TxtEstatus);
            this.SplitEstatus.Panel2.Controls.Add(this.Progreso);
            this.SplitEstatus.Size = new System.Drawing.Size(1230, 627);
            this.SplitEstatus.SplitterDistance = 527;
            this.SplitEstatus.TabIndex = 5;
            // 
            // SplitCarpetas
            // 
            this.SplitCarpetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitCarpetas.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitCarpetas.Location = new System.Drawing.Point(0, 92);
            this.SplitCarpetas.Name = "SplitCarpetas";
            // 
            // SplitCarpetas.Panel1
            // 
            this.SplitCarpetas.Panel1.Controls.Add(this.DgvModuloLocal);
            this.SplitCarpetas.Panel1.Controls.Add(this.label4);
            this.SplitCarpetas.Panel1.Controls.Add(this.panel1);
            // 
            // SplitCarpetas.Panel2
            // 
            this.SplitCarpetas.Panel2.Controls.Add(this.DgvModuloRemoto);
            this.SplitCarpetas.Panel2.Controls.Add(this.label2);
            this.SplitCarpetas.Size = new System.Drawing.Size(1230, 435);
            this.SplitCarpetas.SplitterDistance = 811;
            this.SplitCarpetas.TabIndex = 1;
            // 
            // DgvModuloLocal
            // 
            this.DgvModuloLocal.AllowUserToAddRows = false;
            this.DgvModuloLocal.AllowUserToDeleteRows = false;
            this.DgvModuloLocal.AllowUserToResizeRows = false;
            this.DgvModuloLocal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvModuloLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvModuloLocal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre_archivo,
            this.tamano,
            this.estatus,
            this.conflicto});
            this.DgvModuloLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvModuloLocal.Location = new System.Drawing.Point(0, 23);
            this.DgvModuloLocal.MultiSelect = false;
            this.DgvModuloLocal.Name = "DgvModuloLocal";
            this.DgvModuloLocal.ReadOnly = true;
            this.DgvModuloLocal.RowHeadersVisible = false;
            this.DgvModuloLocal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvModuloLocal.Size = new System.Drawing.Size(811, 334);
            this.DgvModuloLocal.TabIndex = 0;
            this.DgvModuloLocal.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvModuloLocal_CellMouseClick);
            // 
            // nombre_archivo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre_archivo.DefaultCellStyle = dataGridViewCellStyle1;
            this.nombre_archivo.Frozen = true;
            this.nombre_archivo.HeaderText = "Archivo";
            this.nombre_archivo.Name = "nombre_archivo";
            this.nombre_archivo.ReadOnly = true;
            this.nombre_archivo.Width = 430;
            // 
            // tamano
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tamano.DefaultCellStyle = dataGridViewCellStyle2;
            this.tamano.Frozen = true;
            this.tamano.HeaderText = "Tamaño";
            this.tamano.Name = "tamano";
            this.tamano.ReadOnly = true;
            this.tamano.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // estatus
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.estatus.Frozen = true;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // conflicto
            // 
            this.conflicto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.conflicto.DefaultCellStyle = dataGridViewCellStyle4;
            this.conflicto.HeaderText = "Detalles del conflicto";
            this.conflicto.Name = "conflicto";
            this.conflicto.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(811, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "ARCHIVOS LOCALES";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtCarpetaLocal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 78);
            this.panel1.TabIndex = 1;
            // 
            // TxtCarpetaLocal
            // 
            this.TxtCarpetaLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCarpetaLocal.Location = new System.Drawing.Point(10, 26);
            this.TxtCarpetaLocal.Name = "TxtCarpetaLocal";
            this.TxtCarpetaLocal.ReadOnly = true;
            this.TxtCarpetaLocal.Size = new System.Drawing.Size(787, 24);
            this.TxtCarpetaLocal.TabIndex = 2;
            this.TxtCarpetaLocal.TextChanged += new System.EventHandler(this.TxtCarpetaLocal_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Carpeta local:";
            // 
            // DgvModuloRemoto
            // 
            this.DgvModuloRemoto.AllowUserToAddRows = false;
            this.DgvModuloRemoto.AllowUserToDeleteRows = false;
            this.DgvModuloRemoto.AllowUserToResizeRows = false;
            this.DgvModuloRemoto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvModuloRemoto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre_archivo_remoto,
            this.tamano_remoto});
            this.DgvModuloRemoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvModuloRemoto.Location = new System.Drawing.Point(0, 23);
            this.DgvModuloRemoto.MultiSelect = false;
            this.DgvModuloRemoto.Name = "DgvModuloRemoto";
            this.DgvModuloRemoto.ReadOnly = true;
            this.DgvModuloRemoto.RowHeadersVisible = false;
            this.DgvModuloRemoto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvModuloRemoto.Size = new System.Drawing.Size(415, 412);
            this.DgvModuloRemoto.TabIndex = 1;
            // 
            // nombre_archivo_remoto
            // 
            this.nombre_archivo_remoto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_archivo_remoto.HeaderText = "Nombre del archivo";
            this.nombre_archivo_remoto.Name = "nombre_archivo_remoto";
            this.nombre_archivo_remoto.ReadOnly = true;
            // 
            // tamano_remoto
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tamano_remoto.DefaultCellStyle = dataGridViewCellStyle5;
            this.tamano_remoto.HeaderText = "Tamaño";
            this.tamano_remoto.Name = "tamano_remoto";
            this.tamano_remoto.ReadOnly = true;
            this.tamano_remoto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "ARCHIVOS EN EL SERVIDOR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelControles
            // 
            this.PanelControles.Controls.Add(this.LblTotalConflictos);
            this.PanelControles.Controls.Add(this.LblModulo);
            this.PanelControles.Controls.Add(this.LblProyecto);
            this.PanelControles.Controls.Add(this.BtnSubir);
            this.PanelControles.Controls.Add(this.BtnSalir);
            this.PanelControles.Controls.Add(this.LblTitulo);
            this.PanelControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelControles.Location = new System.Drawing.Point(0, 0);
            this.PanelControles.Name = "PanelControles";
            this.PanelControles.Size = new System.Drawing.Size(1230, 92);
            this.PanelControles.TabIndex = 0;
            // 
            // LblTotalConflictos
            // 
            this.LblTotalConflictos.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTotalConflictos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalConflictos.ForeColor = System.Drawing.Color.Red;
            this.LblTotalConflictos.Location = new System.Drawing.Point(0, 70);
            this.LblTotalConflictos.Name = "LblTotalConflictos";
            this.LblTotalConflictos.Size = new System.Drawing.Size(954, 24);
            this.LblTotalConflictos.TabIndex = 25;
            this.LblTotalConflictos.Text = "N CONFLICTOS ENCONTRADOS";
            this.LblTotalConflictos.Visible = false;
            this.LblTotalConflictos.TextChanged += new System.EventHandler(this.LblTotalConflictos_TextChanged);
            // 
            // LblModulo
            // 
            this.LblModulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblModulo.Location = new System.Drawing.Point(0, 46);
            this.LblModulo.Name = "LblModulo";
            this.LblModulo.Size = new System.Drawing.Size(954, 24);
            this.LblModulo.TabIndex = 23;
            this.LblModulo.Text = "SUBENSAMBLE - NOMBRE DEL MODULO";
            // 
            // LblProyecto
            // 
            this.LblProyecto.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProyecto.Location = new System.Drawing.Point(0, 23);
            this.LblProyecto.Name = "LblProyecto";
            this.LblProyecto.Size = new System.Drawing.Size(954, 23);
            this.LblProyecto.TabIndex = 24;
            this.LblProyecto.Text = "PROYECTO";
            // 
            // BtnSubir
            // 
            this.BtnSubir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSubir.Enabled = false;
            this.BtnSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubir.Image = global::CB_Base.Properties.Resources.upload_file_48;
            this.BtnSubir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubir.Location = new System.Drawing.Point(954, 23);
            this.BtnSubir.Name = "BtnSubir";
            this.BtnSubir.Size = new System.Drawing.Size(141, 69);
            this.BtnSubir.TabIndex = 3;
            this.BtnSubir.Text = "     Subir";
            this.BtnSubir.UseVisualStyleBackColor = true;
            this.BtnSubir.Click += new System.EventHandler(this.BtnSubir_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1095, 23);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 69);
            this.BtnSalir.TabIndex = 21;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1230, 23);
            this.LblTitulo.TabIndex = 22;
            this.LblTitulo.Text = "SUBIR MODULO  AL SERVIDOR";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEstatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 0);
            this.TxtEstatus.Multiline = true;
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(1230, 73);
            this.TxtEstatus.TabIndex = 6;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 73);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(1230, 23);
            this.Progreso.TabIndex = 5;
            // 
            // OpcionesCambios
            // 
            this.OpcionesCambios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compararToolStripMenuItem,
            this.recuperarToolStripMenuItem});
            this.OpcionesCambios.Name = "OpcionesConflicto";
            this.OpcionesCambios.Size = new System.Drawing.Size(137, 48);
            // 
            // compararToolStripMenuItem
            // 
            this.compararToolStripMenuItem.Enabled = false;
            this.compararToolStripMenuItem.Name = "compararToolStripMenuItem";
            this.compararToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.compararToolStripMenuItem.Text = "Comparar...";
            this.compararToolStripMenuItem.Click += new System.EventHandler(this.compararToolStripMenuItem_Click);
            // 
            // recuperarToolStripMenuItem
            // 
            this.recuperarToolStripMenuItem.Enabled = false;
            this.recuperarToolStripMenuItem.Name = "recuperarToolStripMenuItem";
            this.recuperarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.recuperarToolStripMenuItem.Text = "Recuperar...";
            this.recuperarToolStripMenuItem.Click += new System.EventHandler(this.recuperarToolStripMenuItem_Click);
            // 
            // BkgRecuperarArchivo
            // 
            this.BkgRecuperarArchivo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgRecuperarArchivo_DoWork);
            this.BkgRecuperarArchivo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgRecuperarArchivo_RunWorkerCompleted);
            // 
            // FrmSubirDiseno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 627);
            this.Controls.Add(this.SplitEstatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSubirDiseno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronizar modulo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSubirDiseno_FormClosing);
            this.Load += new System.EventHandler(this.FrmSubirDiseno_Load);
            this.SplitEstatus.Panel1.ResumeLayout(false);
            this.SplitEstatus.Panel2.ResumeLayout(false);
            this.SplitEstatus.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitEstatus)).EndInit();
            this.SplitEstatus.ResumeLayout(false);
            this.SplitCarpetas.Panel1.ResumeLayout(false);
            this.SplitCarpetas.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCarpetas)).EndInit();
            this.SplitCarpetas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvModuloLocal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModuloRemoto)).EndInit();
            this.PanelControles.ResumeLayout(false);
            this.OpcionesCambios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog Cargar;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.SaveFileDialog Guardar;
        private System.Windows.Forms.FolderBrowserDialog BuscadorCarpetas;
        private System.Windows.Forms.SplitContainer SplitEstatus;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.SplitContainer SplitCarpetas;
        private System.Windows.Forms.DataGridView DgvModuloLocal;
        private System.Windows.Forms.DataGridView DgvModuloRemoto;
        private System.Windows.Forms.Panel PanelControles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtCarpetaLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker BkgInicializar;
        private System.ComponentModel.BackgroundWorker BkgAnalizarCarpeta;
        private System.ComponentModel.BackgroundWorker BkgSubir;
        private System.Windows.Forms.Button BtnSubir;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_archivo_remoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamano_remoto;
        private System.Windows.Forms.Label LblModulo;
        private System.Windows.Forms.Label LblProyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_archivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamano;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn conflicto;
        private System.Windows.Forms.Label LblTotalConflictos;
        private System.Windows.Forms.ContextMenuStrip OpcionesCambios;
        private System.Windows.Forms.ToolStripMenuItem compararToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recuperarToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgRecuperarArchivo;
    }
}
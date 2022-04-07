namespace CB
{
    partial class FrmPartesEstandar
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
            this.MenuSubensamble = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subirSubensamble = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarSubensambleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPartes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subirPartes = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarPartesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgDescargarSubensamble = new System.ComponentModel.BackgroundWorker();
            this.BkgSubirEnsamble = new System.ComponentModel.BackgroundWorker();
            this.BkgSubirPartes = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarPartes = new System.ComponentModel.BackgroundWorker();
            this.BkgBorrarSubensamble = new System.ComponentModel.BackgroundWorker();
            this.BkgBorrarPartes = new System.ComponentModel.BackgroundWorker();
            this.BkgEditarParte = new System.ComponentModel.BackgroundWorker();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.ProgresoDescarga = new System.Windows.Forms.ProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgvSubensamble = new System.Windows.Forms.DataGridView();
            this.imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_subensamble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_subensamble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblTituloSubensamble = new System.Windows.Forms.Label();
            this.DgvPartes = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.imagen_partes = new System.Windows.Forms.DataGridViewImageColumn();
            this.id_partes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_partes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblTituloPartes = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BkgEditarSubensamble = new System.ComponentModel.BackgroundWorker();
            this.BkgExportarParte = new System.ComponentModel.BackgroundWorker();
            this.BkgExportarSub = new System.ComponentModel.BackgroundWorker();
            this.MenuSubensamble.SuspendLayout();
            this.MenuPartes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubensamble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPartes)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuSubensamble
            // 
            this.MenuSubensamble.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subirSubensamble,
            this.borrarToolStripMenuItem,
            this.exportarSubensambleToolStripMenuItem});
            this.MenuSubensamble.Name = "MenuSubensamble";
            this.MenuSubensamble.Size = new System.Drawing.Size(191, 70);
            // 
            // subirSubensamble
            // 
            this.subirSubensamble.Image = global::CB_Base.Properties.Resources.upload;
            this.subirSubensamble.Name = "subirSubensamble";
            this.subirSubensamble.Size = new System.Drawing.Size(190, 22);
            this.subirSubensamble.Text = "Subir subensamble";
            this.subirSubensamble.Click += new System.EventHandler(this.subirToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.borrarToolStripMenuItem.Text = "Borrar subensamble";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // exportarSubensambleToolStripMenuItem
            // 
            this.exportarSubensambleToolStripMenuItem.Image = global::CB_Base.Properties.Resources.export;
            this.exportarSubensambleToolStripMenuItem.Name = "exportarSubensambleToolStripMenuItem";
            this.exportarSubensambleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exportarSubensambleToolStripMenuItem.Text = "Exportar subensamble";
            this.exportarSubensambleToolStripMenuItem.Click += new System.EventHandler(this.exportarSubensambleToolStripMenuItem_Click);
            // 
            // MenuPartes
            // 
            this.MenuPartes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subirPartes,
            this.borrarToolStripMenuItem1,
            this.exportarPartesToolStripMenuItem});
            this.MenuPartes.Name = "MenuPartes";
            this.MenuPartes.Size = new System.Drawing.Size(153, 70);
            // 
            // subirPartes
            // 
            this.subirPartes.Image = global::CB_Base.Properties.Resources.upload;
            this.subirPartes.Name = "subirPartes";
            this.subirPartes.Size = new System.Drawing.Size(152, 22);
            this.subirPartes.Text = "Subir parte";
            this.subirPartes.Click += new System.EventHandler(this.subirToolStripMenuItem1_Click);
            // 
            // borrarToolStripMenuItem1
            // 
            this.borrarToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem1.Name = "borrarToolStripMenuItem1";
            this.borrarToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.borrarToolStripMenuItem1.Text = "Borrar parte";
            this.borrarToolStripMenuItem1.Click += new System.EventHandler(this.borrarToolStripMenuItem1_Click);
            // 
            // exportarPartesToolStripMenuItem
            // 
            this.exportarPartesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.export;
            this.exportarPartesToolStripMenuItem.Name = "exportarPartesToolStripMenuItem";
            this.exportarPartesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportarPartesToolStripMenuItem.Text = "Exportar partes";
            this.exportarPartesToolStripMenuItem.Click += new System.EventHandler(this.exportarPartesToolStripMenuItem_Click);
            // 
            // BkgDescargarSubensamble
            // 
            this.BkgDescargarSubensamble.WorkerReportsProgress = true;
            this.BkgDescargarSubensamble.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarSubensamble_DoWork);
            this.BkgDescargarSubensamble.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarSubensamble_ProgressChanged);
            this.BkgDescargarSubensamble.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarSubensamble_RunWorkerCompleted);
            // 
            // BkgSubirEnsamble
            // 
            this.BkgSubirEnsamble.WorkerReportsProgress = true;
            this.BkgSubirEnsamble.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubirEnsamble_DoWork);
            this.BkgSubirEnsamble.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubirEnsamble_ProgressChanged);
            this.BkgSubirEnsamble.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubirEnsamble_RunWorkerCompleted);
            // 
            // BkgSubirPartes
            // 
            this.BkgSubirPartes.WorkerReportsProgress = true;
            this.BkgSubirPartes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubirPartes_DoWork);
            this.BkgSubirPartes.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubirPartes_ProgressChanged);
            this.BkgSubirPartes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubirPartes_RunWorkerCompleted);
            // 
            // BkgDescargarPartes
            // 
            this.BkgDescargarPartes.WorkerReportsProgress = true;
            this.BkgDescargarPartes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPartes_DoWork);
            this.BkgDescargarPartes.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarPartes_ProgressChanged);
            this.BkgDescargarPartes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarPartes_RunWorkerCompleted);
            // 
            // BkgBorrarSubensamble
            // 
            this.BkgBorrarSubensamble.WorkerReportsProgress = true;
            this.BkgBorrarSubensamble.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgBorrarSubensamble_DoWork);
            this.BkgBorrarSubensamble.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgBorrarSubensamble_ProgressChanged);
            this.BkgBorrarSubensamble.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgBorrarSubensamble_RunWorkerCompleted);
            // 
            // BkgBorrarPartes
            // 
            this.BkgBorrarPartes.WorkerReportsProgress = true;
            this.BkgBorrarPartes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgBorrarPartes_DoWork);
            this.BkgBorrarPartes.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgBorrarPartes_ProgressChanged);
            this.BkgBorrarPartes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgBorrarPartes_RunWorkerCompleted);
            // 
            // BkgEditarParte
            // 
            this.BkgEditarParte.WorkerReportsProgress = true;
            this.BkgEditarParte.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEditarParte_DoWork);
            this.BkgEditarParte.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgEditarParte_ProgressChanged);
            this.BkgEditarParte.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEditarParte_RunWorkerCompleted);
            // 
            // LblEstatus
            // 
            this.LblEstatus.BackColor = System.Drawing.Color.Black;
            this.LblEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatus.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatus.Location = new System.Drawing.Point(0, 626);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(1337, 29);
            this.LblEstatus.TabIndex = 23;
            this.LblEstatus.Text = "Estatus...";
            this.LblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoDescarga
            // 
            this.ProgresoDescarga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoDescarga.Location = new System.Drawing.Point(0, 655);
            this.ProgresoDescarga.Name = "ProgresoDescarga";
            this.ProgresoDescarga.Size = new System.Drawing.Size(1337, 23);
            this.ProgresoDescarga.TabIndex = 22;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvSubensamble);
            this.splitContainer1.Panel1.Controls.Add(this.LblTituloSubensamble);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvPartes);
            this.splitContainer1.Panel2.Controls.Add(this.LblTituloPartes);
            this.splitContainer1.Size = new System.Drawing.Size(1337, 655);
            this.splitContainer1.SplitterDistance = 552;
            this.splitContainer1.TabIndex = 21;
            // 
            // DgvSubensamble
            // 
            this.DgvSubensamble.AllowUserToAddRows = false;
            this.DgvSubensamble.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvSubensamble.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSubensamble.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imagen,
            this.ID,
            this.nombre_subensamble,
            this.descripcion_subensamble});
            this.DgvSubensamble.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSubensamble.Location = new System.Drawing.Point(0, 23);
            this.DgvSubensamble.Name = "DgvSubensamble";
            this.DgvSubensamble.RowHeadersVisible = false;
            this.DgvSubensamble.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DgvSubensamble.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSubensamble.Size = new System.Drawing.Size(552, 632);
            this.DgvSubensamble.TabIndex = 22;
            this.DgvSubensamble.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSubensamble_CellDoubleClick);
            this.DgvSubensamble.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvSubensamble_CellMouseDown);
            this.DgvSubensamble.SelectionChanged += new System.EventHandler(this.DgvSubensamble_SelectionChanged);
            this.DgvSubensamble.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvSubensamble_MouseDown);
            // 
            // imagen
            // 
            this.imagen.HeaderText = "";
            this.imagen.MinimumWidth = 70;
            this.imagen.Name = "imagen";
            this.imagen.ReadOnly = true;
            this.imagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.imagen.Width = 70;
            // 
            // ID
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ID.FillWeight = 50F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 35;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 35;
            // 
            // nombre_subensamble
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre_subensamble.DefaultCellStyle = dataGridViewCellStyle2;
            this.nombre_subensamble.HeaderText = "Nombre del archivo";
            this.nombre_subensamble.MinimumWidth = 125;
            this.nombre_subensamble.Name = "nombre_subensamble";
            this.nombre_subensamble.ReadOnly = true;
            this.nombre_subensamble.Width = 125;
            // 
            // descripcion_subensamble
            // 
            this.descripcion_subensamble.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion_subensamble.DefaultCellStyle = dataGridViewCellStyle3;
            this.descripcion_subensamble.HeaderText = "Descripción";
            this.descripcion_subensamble.MinimumWidth = 300;
            this.descripcion_subensamble.Name = "descripcion_subensamble";
            this.descripcion_subensamble.ReadOnly = true;
            // 
            // LblTituloSubensamble
            // 
            this.LblTituloSubensamble.BackColor = System.Drawing.Color.Black;
            this.LblTituloSubensamble.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTituloSubensamble.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloSubensamble.ForeColor = System.Drawing.Color.White;
            this.LblTituloSubensamble.Location = new System.Drawing.Point(0, 0);
            this.LblTituloSubensamble.Name = "LblTituloSubensamble";
            this.LblTituloSubensamble.Size = new System.Drawing.Size(552, 23);
            this.LblTituloSubensamble.TabIndex = 21;
            this.LblTituloSubensamble.Text = "SUBENSAMBLE ESTANDAR";
            this.LblTituloSubensamble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvPartes
            // 
            this.DgvPartes.AllowUserToAddRows = false;
            this.DgvPartes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvPartes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPartes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.imagen_partes,
            this.id_partes,
            this.nombre_archivo,
            this.descripcion_partes});
            this.DgvPartes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPartes.Location = new System.Drawing.Point(0, 23);
            this.DgvPartes.Name = "DgvPartes";
            this.DgvPartes.ReadOnly = true;
            this.DgvPartes.RowHeadersVisible = false;
            this.DgvPartes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPartes.Size = new System.Drawing.Size(781, 632);
            this.DgvPartes.TabIndex = 23;
            this.DgvPartes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPartes_CellContentClick);
            this.DgvPartes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPartes_CellDoubleClick);
            this.DgvPartes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvPartes_CellMouseDown);
            this.DgvPartes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvPartes_MouseDown);
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.MinimumWidth = 25;
            this.check.Name = "check";
            this.check.ReadOnly = true;
            this.check.Width = 25;
            // 
            // imagen_partes
            // 
            this.imagen_partes.HeaderText = "";
            this.imagen_partes.MinimumWidth = 75;
            this.imagen_partes.Name = "imagen_partes";
            this.imagen_partes.ReadOnly = true;
            this.imagen_partes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imagen_partes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.imagen_partes.Width = 75;
            // 
            // id_partes
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id_partes.DefaultCellStyle = dataGridViewCellStyle4;
            this.id_partes.HeaderText = "ID";
            this.id_partes.MinimumWidth = 50;
            this.id_partes.Name = "id_partes";
            this.id_partes.ReadOnly = true;
            this.id_partes.Width = 50;
            // 
            // nombre_archivo
            // 
            this.nombre_archivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre_archivo.DefaultCellStyle = dataGridViewCellStyle5;
            this.nombre_archivo.HeaderText = "Nombre del archivo";
            this.nombre_archivo.MinimumWidth = 250;
            this.nombre_archivo.Name = "nombre_archivo";
            this.nombre_archivo.ReadOnly = true;
            this.nombre_archivo.Width = 250;
            // 
            // descripcion_partes
            // 
            this.descripcion_partes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion_partes.DefaultCellStyle = dataGridViewCellStyle6;
            this.descripcion_partes.HeaderText = "Descripción";
            this.descripcion_partes.MinimumWidth = 100;
            this.descripcion_partes.Name = "descripcion_partes";
            this.descripcion_partes.ReadOnly = true;
            // 
            // LblTituloPartes
            // 
            this.LblTituloPartes.BackColor = System.Drawing.Color.Black;
            this.LblTituloPartes.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTituloPartes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloPartes.ForeColor = System.Drawing.Color.White;
            this.LblTituloPartes.Location = new System.Drawing.Point(0, 0);
            this.LblTituloPartes.Name = "LblTituloPartes";
            this.LblTituloPartes.Size = new System.Drawing.Size(781, 23);
            this.LblTituloPartes.TabIndex = 22;
            this.LblTituloPartes.Text = "PARTES DEL SUBENSAMBLE";
            this.LblTituloPartes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1337, 23);
            this.LblTitulo.TabIndex = 20;
            this.LblTitulo.Text = "CATALOGO DE PARTES ESTANDAR";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BkgEditarSubensamble
            // 
            this.BkgEditarSubensamble.WorkerReportsProgress = true;
            this.BkgEditarSubensamble.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEditarSubensamble_DoWork);
            this.BkgEditarSubensamble.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgEditarSubensamble_ProgressChanged);
            this.BkgEditarSubensamble.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEditarSubensamble_RunWorkerCompleted);
            // 
            // BkgExportarParte
            // 
            this.BkgExportarParte.WorkerReportsProgress = true;
            this.BkgExportarParte.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgExportarParte_DoWork);
            this.BkgExportarParte.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgExportarParte_ProgressChanged);
            this.BkgExportarParte.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgExportarParte_RunWorkerCompleted);
            // 
            // BkgExportarSub
            // 
            this.BkgExportarSub.WorkerReportsProgress = true;
            this.BkgExportarSub.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgExportarSub_DoWork);
            this.BkgExportarSub.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgExportarSub_ProgressChanged);
            this.BkgExportarSub.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgExportarSub_RunWorkerCompleted);
            // 
            // FrmPartesEstandar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 678);
            this.Controls.Add(this.LblEstatus);
            this.Controls.Add(this.ProgresoDescarga);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmPartesEstandar";
            this.Text = "Partes estandar";
            this.Load += new System.EventHandler(this.FrmPartesEstandar_Load);
            this.MenuSubensamble.ResumeLayout(false);
            this.MenuPartes.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubensamble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPartes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvSubensamble;
        private System.Windows.Forms.Label LblTituloSubensamble;
        private System.Windows.Forms.DataGridView DgvPartes;
        private System.Windows.Forms.Label LblTituloPartes;
        private System.Windows.Forms.ContextMenuStrip MenuSubensamble;
        private System.Windows.Forms.ContextMenuStrip MenuPartes;
        private System.ComponentModel.BackgroundWorker BkgDescargarSubensamble;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.ProgressBar ProgresoDescarga;
        private System.Windows.Forms.ToolStripMenuItem subirSubensamble;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subirPartes;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker BkgSubirEnsamble;
        private System.ComponentModel.BackgroundWorker BkgSubirPartes;
        private System.ComponentModel.BackgroundWorker BkgDescargarPartes;
        private System.ComponentModel.BackgroundWorker BkgBorrarSubensamble;
        private System.ComponentModel.BackgroundWorker BkgBorrarPartes;
        private System.ComponentModel.BackgroundWorker BkgEditarParte;
        private System.ComponentModel.BackgroundWorker BkgEditarSubensamble;
        private System.Windows.Forms.DataGridViewImageColumn imagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_subensamble;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_subensamble;
        private System.Windows.Forms.ToolStripMenuItem exportarSubensambleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarPartesToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgExportarParte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewImageColumn imagen_partes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_partes;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_archivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_partes;
        private System.ComponentModel.BackgroundWorker BkgExportarSub;
    }
}
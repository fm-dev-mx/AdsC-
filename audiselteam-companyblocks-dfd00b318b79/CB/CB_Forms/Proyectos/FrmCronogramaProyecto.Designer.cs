namespace CB
{
    partial class FrmCronogramaProyecto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuProcesos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoProcesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProcesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarFechaInicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarFechaFinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarDesdeProyectoPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCalendario = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevaMetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMetas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.borrarMetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarMetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparadorMetas = new System.Windows.Forms.SplitContainer();
            this.SeparadorCalendario = new System.Windows.Forms.SplitContainer();
            this.DgvProcesos = new System.Windows.Forms.DataGridView();
            this.id_proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicio_estandar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_fin_estandar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvCalendario = new System.Windows.Forms.DataGridView();
            this.DgvMetas = new System.Windows.Forms.DataGridView();
            this.id_meta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_entregable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entregables = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_autorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_autorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblEstatusMetas = new System.Windows.Forms.Label();
            this.ProgresoEstatusMetas = new System.Windows.Forms.ProgressBar();
            this.PanelTituloMetas = new System.Windows.Forms.Panel();
            this.BtnOcultarMetas = new System.Windows.Forms.Button();
            this.LblTituloMetas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnHistorial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BkgCargarMetas = new System.ComponentModel.BackgroundWorker();
            this.MenuProcesos.SuspendLayout();
            this.MenuCalendario.SuspendLayout();
            this.MenuMetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeparadorMetas)).BeginInit();
            this.SeparadorMetas.Panel1.SuspendLayout();
            this.SeparadorMetas.Panel2.SuspendLayout();
            this.SeparadorMetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeparadorCalendario)).BeginInit();
            this.SeparadorCalendario.Panel1.SuspendLayout();
            this.SeparadorCalendario.Panel2.SuspendLayout();
            this.SeparadorCalendario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCalendario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetas)).BeginInit();
            this.PanelTituloMetas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuProcesos
            // 
            this.MenuProcesos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProcesoToolStripMenuItem,
            this.eliminarProcesoToolStripMenuItem,
            this.modificarFechaInicioToolStripMenuItem,
            this.modificarFechaFinToolStripMenuItem,
            this.copiarDesdeProyectoPrincipalToolStripMenuItem});
            this.MenuProcesos.Name = "MenuProcesos";
            this.MenuProcesos.Size = new System.Drawing.Size(243, 114);
            this.MenuProcesos.Opening += new System.ComponentModel.CancelEventHandler(this.MenuProcesos_Opening);
            // 
            // nuevoProcesoToolStripMenuItem
            // 
            this.nuevoProcesoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoProcesoToolStripMenuItem.Name = "nuevoProcesoToolStripMenuItem";
            this.nuevoProcesoToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.nuevoProcesoToolStripMenuItem.Text = "Nuevo proceso";
            this.nuevoProcesoToolStripMenuItem.Click += new System.EventHandler(this.nuevoProcesoToolStripMenuItem_Click);
            // 
            // eliminarProcesoToolStripMenuItem
            // 
            this.eliminarProcesoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarProcesoToolStripMenuItem.Name = "eliminarProcesoToolStripMenuItem";
            this.eliminarProcesoToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.eliminarProcesoToolStripMenuItem.Text = "Eliminar proceso";
            this.eliminarProcesoToolStripMenuItem.Click += new System.EventHandler(this.eliminarProcesoToolStripMenuItem_Click);
            // 
            // modificarFechaInicioToolStripMenuItem
            // 
            this.modificarFechaInicioToolStripMenuItem.Image = global::CB_Base.Properties.Resources.calendar_48;
            this.modificarFechaInicioToolStripMenuItem.Name = "modificarFechaInicioToolStripMenuItem";
            this.modificarFechaInicioToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.modificarFechaInicioToolStripMenuItem.Text = "Modificar fecha inicio";
            this.modificarFechaInicioToolStripMenuItem.Click += new System.EventHandler(this.modificarFechaInicioToolStripMenuItem_Click);
            // 
            // modificarFechaFinToolStripMenuItem
            // 
            this.modificarFechaFinToolStripMenuItem.Image = global::CB_Base.Properties.Resources.calendar_48;
            this.modificarFechaFinToolStripMenuItem.Name = "modificarFechaFinToolStripMenuItem";
            this.modificarFechaFinToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.modificarFechaFinToolStripMenuItem.Text = "Modificar fecha fin";
            this.modificarFechaFinToolStripMenuItem.Click += new System.EventHandler(this.modificarFechaFinToolStripMenuItem_Click);
            // 
            // copiarDesdeProyectoPrincipalToolStripMenuItem
            // 
            this.copiarDesdeProyectoPrincipalToolStripMenuItem.Image = global::CB_Base.Properties.Resources.copy2;
            this.copiarDesdeProyectoPrincipalToolStripMenuItem.Name = "copiarDesdeProyectoPrincipalToolStripMenuItem";
            this.copiarDesdeProyectoPrincipalToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.copiarDesdeProyectoPrincipalToolStripMenuItem.Text = "Copiar desde proyecto principal";
            this.copiarDesdeProyectoPrincipalToolStripMenuItem.Click += new System.EventHandler(this.copiarDesdeProyectoPrincipalToolStripMenuItem_Click);
            // 
            // MenuCalendario
            // 
            this.MenuCalendario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaMetaToolStripMenuItem});
            this.MenuCalendario.Name = "MenuCalendario";
            this.MenuCalendario.Size = new System.Drawing.Size(139, 26);
            this.MenuCalendario.Opening += new System.ComponentModel.CancelEventHandler(this.MenuCalendario_Opening);
            // 
            // nuevaMetaToolStripMenuItem
            // 
            this.nuevaMetaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.marker_icon_32;
            this.nuevaMetaToolStripMenuItem.Name = "nuevaMetaToolStripMenuItem";
            this.nuevaMetaToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.nuevaMetaToolStripMenuItem.Text = "Nueva meta";
            this.nuevaMetaToolStripMenuItem.Click += new System.EventHandler(this.nuevaMetaToolStripMenuItem_Click);
            // 
            // MenuMetas
            // 
            this.MenuMetas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarMetaToolStripMenuItem,
            this.actualizarMetaToolStripMenuItem});
            this.MenuMetas.Name = "MenuMetas";
            this.MenuMetas.Size = new System.Drawing.Size(157, 48);
            this.MenuMetas.Opening += new System.ComponentModel.CancelEventHandler(this.MenuMetas_Opening);
            // 
            // borrarMetaToolStripMenuItem
            // 
            this.borrarMetaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarMetaToolStripMenuItem.Name = "borrarMetaToolStripMenuItem";
            this.borrarMetaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.borrarMetaToolStripMenuItem.Text = "Borrar meta";
            this.borrarMetaToolStripMenuItem.Click += new System.EventHandler(this.borrarMetaToolStripMenuItem_Click);
            // 
            // actualizarMetaToolStripMenuItem
            // 
            this.actualizarMetaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.update;
            this.actualizarMetaToolStripMenuItem.Name = "actualizarMetaToolStripMenuItem";
            this.actualizarMetaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.actualizarMetaToolStripMenuItem.Text = "Actualizar meta";
            this.actualizarMetaToolStripMenuItem.Click += new System.EventHandler(this.actualizarMetaToolStripMenuItem_Click);
            // 
            // SeparadorMetas
            // 
            this.SeparadorMetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SeparadorMetas.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SeparadorMetas.Location = new System.Drawing.Point(0, 88);
            this.SeparadorMetas.Name = "SeparadorMetas";
            this.SeparadorMetas.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SeparadorMetas.Panel1
            // 
            this.SeparadorMetas.Panel1.Controls.Add(this.SeparadorCalendario);
            // 
            // SeparadorMetas.Panel2
            // 
            this.SeparadorMetas.Panel2.Controls.Add(this.DgvMetas);
            this.SeparadorMetas.Panel2.Controls.Add(this.LblEstatusMetas);
            this.SeparadorMetas.Panel2.Controls.Add(this.ProgresoEstatusMetas);
            this.SeparadorMetas.Panel2.Controls.Add(this.PanelTituloMetas);
            this.SeparadorMetas.Size = new System.Drawing.Size(1080, 555);
            this.SeparadorMetas.SplitterDistance = 221;
            this.SeparadorMetas.TabIndex = 18;
            // 
            // SeparadorCalendario
            // 
            this.SeparadorCalendario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SeparadorCalendario.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SeparadorCalendario.Location = new System.Drawing.Point(0, 0);
            this.SeparadorCalendario.Name = "SeparadorCalendario";
            // 
            // SeparadorCalendario.Panel1
            // 
            this.SeparadorCalendario.Panel1.Controls.Add(this.DgvProcesos);
            // 
            // SeparadorCalendario.Panel2
            // 
            this.SeparadorCalendario.Panel2.Controls.Add(this.DgvCalendario);
            this.SeparadorCalendario.Size = new System.Drawing.Size(1080, 221);
            this.SeparadorCalendario.SplitterDistance = 405;
            this.SeparadorCalendario.TabIndex = 17;
            // 
            // DgvProcesos
            // 
            this.DgvProcesos.AllowUserToAddRows = false;
            this.DgvProcesos.AllowUserToResizeColumns = false;
            this.DgvProcesos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvProcesos.ColumnHeadersHeight = 40;
            this.DgvProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvProcesos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_proceso,
            this.proceso,
            this.fecha_inicio,
            this.fecha_fin,
            this.fecha_inicio_estandar,
            this.fecha_fin_estandar});
            this.DgvProcesos.ContextMenuStrip = this.MenuProcesos;
            this.DgvProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProcesos.Location = new System.Drawing.Point(0, 0);
            this.DgvProcesos.MultiSelect = false;
            this.DgvProcesos.Name = "DgvProcesos";
            this.DgvProcesos.ReadOnly = true;
            this.DgvProcesos.RowHeadersVisible = false;
            this.DgvProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProcesos.Size = new System.Drawing.Size(405, 221);
            this.DgvProcesos.TabIndex = 14;
            this.DgvProcesos.SelectionChanged += new System.EventHandler(this.DgvProcesos_SelectionChanged);
            // 
            // id_proceso
            // 
            this.id_proceso.Frozen = true;
            this.id_proceso.HeaderText = "ID";
            this.id_proceso.Name = "id_proceso";
            this.id_proceso.ReadOnly = true;
            this.id_proceso.Visible = false;
            // 
            // proceso
            // 
            this.proceso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proceso.HeaderText = "Proceso";
            this.proceso.Name = "proceso";
            this.proceso.ReadOnly = true;
            this.proceso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fecha_inicio
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_inicio.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecha_inicio.HeaderText = "Inicio";
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.ReadOnly = true;
            this.fecha_inicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fecha_fin
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_fin.DefaultCellStyle = dataGridViewCellStyle3;
            this.fecha_fin.HeaderText = "Fin";
            this.fecha_fin.Name = "fecha_fin";
            this.fecha_fin.ReadOnly = true;
            this.fecha_fin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fecha_inicio_estandar
            // 
            this.fecha_inicio_estandar.HeaderText = "Fecha inicio estandar";
            this.fecha_inicio_estandar.Name = "fecha_inicio_estandar";
            this.fecha_inicio_estandar.ReadOnly = true;
            this.fecha_inicio_estandar.Visible = false;
            // 
            // fecha_fin_estandar
            // 
            this.fecha_fin_estandar.HeaderText = "Fecha fin estandar";
            this.fecha_fin_estandar.Name = "fecha_fin_estandar";
            this.fecha_fin_estandar.ReadOnly = true;
            this.fecha_fin_estandar.Visible = false;
            // 
            // DgvCalendario
            // 
            this.DgvCalendario.AllowUserToAddRows = false;
            this.DgvCalendario.AllowUserToResizeColumns = false;
            this.DgvCalendario.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCalendario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvCalendario.ColumnHeadersHeight = 40;
            this.DgvCalendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvCalendario.ContextMenuStrip = this.MenuCalendario;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCalendario.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvCalendario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCalendario.Location = new System.Drawing.Point(0, 0);
            this.DgvCalendario.MultiSelect = false;
            this.DgvCalendario.Name = "DgvCalendario";
            this.DgvCalendario.ReadOnly = true;
            this.DgvCalendario.RowHeadersVisible = false;
            this.DgvCalendario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvCalendario.Size = new System.Drawing.Size(671, 221);
            this.DgvCalendario.TabIndex = 15;
            this.DgvCalendario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCalendario_CellDoubleClick);
            this.DgvCalendario.SelectionChanged += new System.EventHandler(this.DgvCalendario_SelectionChanged);
            // 
            // DgvMetas
            // 
            this.DgvMetas.AllowUserToAddRows = false;
            this.DgvMetas.AllowUserToResizeRows = false;
            this.DgvMetas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_meta,
            this.tipo_entregable,
            this.entregables,
            this.estatus_autorizacion,
            this.comentarios_autorizacion,
            this.avance});
            this.DgvMetas.ContextMenuStrip = this.MenuMetas;
            this.DgvMetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMetas.Location = new System.Drawing.Point(0, 23);
            this.DgvMetas.MultiSelect = false;
            this.DgvMetas.Name = "DgvMetas";
            this.DgvMetas.ReadOnly = true;
            this.DgvMetas.RowHeadersVisible = false;
            this.DgvMetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMetas.Size = new System.Drawing.Size(1080, 259);
            this.DgvMetas.TabIndex = 0;
            // 
            // id_meta
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id_meta.DefaultCellStyle = dataGridViewCellStyle7;
            this.id_meta.HeaderText = "ID";
            this.id_meta.Name = "id_meta";
            this.id_meta.ReadOnly = true;
            this.id_meta.Width = 60;
            // 
            // tipo_entregable
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipo_entregable.DefaultCellStyle = dataGridViewCellStyle8;
            this.tipo_entregable.HeaderText = "Tipo de entregable(s)";
            this.tipo_entregable.Name = "tipo_entregable";
            this.tipo_entregable.ReadOnly = true;
            this.tipo_entregable.Width = 180;
            // 
            // entregables
            // 
            this.entregables.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.entregables.DefaultCellStyle = dataGridViewCellStyle9;
            this.entregables.HeaderText = "Entregable(s)";
            this.entregables.Name = "entregables";
            this.entregables.ReadOnly = true;
            // 
            // estatus_autorizacion
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_autorizacion.DefaultCellStyle = dataGridViewCellStyle10;
            this.estatus_autorizacion.HeaderText = "Estatus autorización";
            this.estatus_autorizacion.Name = "estatus_autorizacion";
            this.estatus_autorizacion.ReadOnly = true;
            this.estatus_autorizacion.Width = 120;
            // 
            // comentarios_autorizacion
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios_autorizacion.DefaultCellStyle = dataGridViewCellStyle11;
            this.comentarios_autorizacion.HeaderText = "Comentarios de autorización";
            this.comentarios_autorizacion.Name = "comentarios_autorizacion";
            this.comentarios_autorizacion.ReadOnly = true;
            this.comentarios_autorizacion.Width = 300;
            // 
            // avance
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.avance.DefaultCellStyle = dataGridViewCellStyle12;
            this.avance.HeaderText = "Avance";
            this.avance.Name = "avance";
            this.avance.ReadOnly = true;
            this.avance.Width = 75;
            // 
            // LblEstatusMetas
            // 
            this.LblEstatusMetas.BackColor = System.Drawing.Color.Black;
            this.LblEstatusMetas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusMetas.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusMetas.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusMetas.Location = new System.Drawing.Point(0, 282);
            this.LblEstatusMetas.Name = "LblEstatusMetas";
            this.LblEstatusMetas.Size = new System.Drawing.Size(1080, 25);
            this.LblEstatusMetas.TabIndex = 114;
            this.LblEstatusMetas.Text = "Estatus...";
            this.LblEstatusMetas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoEstatusMetas
            // 
            this.ProgresoEstatusMetas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoEstatusMetas.Location = new System.Drawing.Point(0, 307);
            this.ProgresoEstatusMetas.Name = "ProgresoEstatusMetas";
            this.ProgresoEstatusMetas.Size = new System.Drawing.Size(1080, 23);
            this.ProgresoEstatusMetas.TabIndex = 113;
            this.ProgresoEstatusMetas.Visible = false;
            // 
            // PanelTituloMetas
            // 
            this.PanelTituloMetas.Controls.Add(this.BtnOcultarMetas);
            this.PanelTituloMetas.Controls.Add(this.LblTituloMetas);
            this.PanelTituloMetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTituloMetas.Location = new System.Drawing.Point(0, 0);
            this.PanelTituloMetas.Name = "PanelTituloMetas";
            this.PanelTituloMetas.Size = new System.Drawing.Size(1080, 23);
            this.PanelTituloMetas.TabIndex = 15;
            // 
            // BtnOcultarMetas
            // 
            this.BtnOcultarMetas.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOcultarMetas.Location = new System.Drawing.Point(984, 0);
            this.BtnOcultarMetas.Name = "BtnOcultarMetas";
            this.BtnOcultarMetas.Size = new System.Drawing.Size(96, 23);
            this.BtnOcultarMetas.TabIndex = 0;
            this.BtnOcultarMetas.Text = "Ocultar";
            this.BtnOcultarMetas.UseVisualStyleBackColor = true;
            this.BtnOcultarMetas.Click += new System.EventHandler(this.BtnOcultarMetas_Click);
            // 
            // LblTituloMetas
            // 
            this.LblTituloMetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblTituloMetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTituloMetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloMetas.ForeColor = System.Drawing.Color.White;
            this.LblTituloMetas.Location = new System.Drawing.Point(0, 0);
            this.LblTituloMetas.Name = "LblTituloMetas";
            this.LblTituloMetas.Size = new System.Drawing.Size(1080, 23);
            this.LblTituloMetas.TabIndex = 14;
            this.LblTituloMetas.Text = "METAS ESTABLECIDAS PARA ";
            this.LblTituloMetas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnActualizar);
            this.panel1.Controls.Add(this.BtnHistorial);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.FechaEntrega);
            this.panel1.Controls.Add(this.FechaInicio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 65);
            this.panel1.TabIndex = 15;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.calendar_48;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(811, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(131, 65);
            this.BtnActualizar.TabIndex = 4;
            this.BtnActualizar.Text = "          Ajustar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnHistorial
            // 
            this.BtnHistorial.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHistorial.Image = global::CB_Base.Properties.Resources.help_icon_48;
            this.BtnHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHistorial.Location = new System.Drawing.Point(942, 0);
            this.BtnHistorial.Name = "BtnHistorial";
            this.BtnHistorial.Size = new System.Drawing.Size(138, 65);
            this.BtnHistorial.TabIndex = 5;
            this.BtnHistorial.Text = "         Historial";
            this.BtnHistorial.UseVisualStyleBackColor = true;
            this.BtnHistorial.Click += new System.EventHandler(this.BtnHistorial_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entrega del proyecto:";
            // 
            // FechaEntrega
            // 
            this.FechaEntrega.Enabled = false;
            this.FechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaEntrega.Location = new System.Drawing.Point(319, 25);
            this.FechaEntrega.Name = "FechaEntrega";
            this.FechaEntrega.Size = new System.Drawing.Size(285, 26);
            this.FechaEntrega.TabIndex = 2;
            this.FechaEntrega.ValueChanged += new System.EventHandler(this.FechaEntrega_ValueChanged);
            // 
            // FechaInicio
            // 
            this.FechaInicio.Enabled = false;
            this.FechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaInicio.Location = new System.Drawing.Point(11, 25);
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Size = new System.Drawing.Size(285, 26);
            this.FechaInicio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio del proyecto:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1080, 23);
            this.LblTitulo.TabIndex = 13;
            this.LblTitulo.Text = "CRONOGRAMA DEL PROYECTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BkgCargarMetas
            // 
            this.BkgCargarMetas.WorkerReportsProgress = true;
            this.BkgCargarMetas.WorkerSupportsCancellation = true;
            this.BkgCargarMetas.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgCargarMetas_DoWork);
            this.BkgCargarMetas.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgCargarMetas_ProgressChanged);
            this.BkgCargarMetas.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgCargarMetas_RunWorkerCompleted);
            // 
            // FrmCronogramaProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 643);
            this.Controls.Add(this.SeparadorMetas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmCronogramaProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cronograma del proyecto";
            this.Load += new System.EventHandler(this.FrmCronogramaProyecto_Load);
            this.MenuProcesos.ResumeLayout(false);
            this.MenuCalendario.ResumeLayout(false);
            this.MenuMetas.ResumeLayout(false);
            this.SeparadorMetas.Panel1.ResumeLayout(false);
            this.SeparadorMetas.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SeparadorMetas)).EndInit();
            this.SeparadorMetas.ResumeLayout(false);
            this.SeparadorCalendario.Panel1.ResumeLayout(false);
            this.SeparadorCalendario.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SeparadorCalendario)).EndInit();
            this.SeparadorCalendario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCalendario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetas)).EndInit();
            this.PanelTituloMetas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridView DgvProcesos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaEntrega;
        private System.Windows.Forms.DateTimePicker FechaInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip MenuProcesos;
        private System.Windows.Forms.ToolStripMenuItem nuevoProcesoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarProcesoToolStripMenuItem;
        private System.Windows.Forms.SplitContainer SeparadorCalendario;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnHistorial;
        private System.Windows.Forms.DataGridView DgvCalendario;
        private System.Windows.Forms.ContextMenuStrip MenuCalendario;
        private System.Windows.Forms.ToolStripMenuItem nuevaMetaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicio_estandar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_fin_estandar;
        private System.Windows.Forms.SplitContainer SeparadorMetas;
        private System.Windows.Forms.DataGridView DgvMetas;
        private System.Windows.Forms.Label LblTituloMetas;
        private System.Windows.Forms.Panel PanelTituloMetas;
        private System.Windows.Forms.Button BtnOcultarMetas;
        private System.Windows.Forms.ContextMenuStrip MenuMetas;
        private System.Windows.Forms.ToolStripMenuItem borrarMetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarFechaInicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarFechaFinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarDesdeProyectoPrincipalToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_meta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_entregable;
        private System.Windows.Forms.DataGridViewTextBoxColumn entregables;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_autorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_autorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn avance;
        private System.Windows.Forms.ToolStripMenuItem actualizarMetaToolStripMenuItem;
        private System.Windows.Forms.Label LblEstatusMetas;
        private System.Windows.Forms.ProgressBar ProgresoEstatusMetas;
        private System.ComponentModel.BackgroundWorker BkgCargarMetas;
    }
}
namespace CB
{
    partial class FrmAccionesKPIs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbFiltroEfectividad = new System.Windows.Forms.ComboBox();
            this.LblEfectividad = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.CmbFiltro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtIndicador = new System.Windows.Forms.TextBox();
            this.TxtProceso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvAcciones = new System.Windows.Forms.DataGridView();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.evaluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efectivaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noEfectivaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarAcciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarAcciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarAccióToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_accion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evaluador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_evaluacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.efectividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcciones)).BeginInit();
            this.MenuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1057, 23);
            this.LblTitulo.TabIndex = 20;
            this.LblTitulo.Text = "ACCIONES CORRECTIVAS Y PREVENTIVAS DEL INDICADOR";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbFiltroEfectividad);
            this.panel1.Controls.Add(this.LblEfectividad);
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.CmbFiltro);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtIndicador);
            this.panel1.Controls.Add(this.TxtProceso);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 140);
            this.panel1.TabIndex = 21;
            // 
            // CmbFiltroEfectividad
            // 
            this.CmbFiltroEfectividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroEfectividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroEfectividad.FormattingEnabled = true;
            this.CmbFiltroEfectividad.Items.AddRange(new object[] {
            "TODO",
            "EFECTIVA",
            "NO EFECTIVA",
            "SIN EVALUAR"});
            this.CmbFiltroEfectividad.Location = new System.Drawing.Point(575, 81);
            this.CmbFiltroEfectividad.Name = "CmbFiltroEfectividad";
            this.CmbFiltroEfectividad.Size = new System.Drawing.Size(318, 32);
            this.CmbFiltroEfectividad.TabIndex = 7;
            this.CmbFiltroEfectividad.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroEfectividad_SelectedIndexChanged);
            // 
            // LblEfectividad
            // 
            this.LblEfectividad.AutoSize = true;
            this.LblEfectividad.Location = new System.Drawing.Point(572, 65);
            this.LblEfectividad.Name = "LblEfectividad";
            this.LblEfectividad.Size = new System.Drawing.Size(108, 13);
            this.LblEfectividad.TabIndex = 6;
            this.LblEfectividad.Text = "Filtrar efectividad por:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(917, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer1.Size = new System.Drawing.Size(140, 140);
            this.splitContainer1.SplitterDistance = 58;
            this.splitContainer1.TabIndex = 0;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(140, 58);
            this.BtnSalir.TabIndex = 33;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // CmbFiltro
            // 
            this.CmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltro.FormattingEnabled = true;
            this.CmbFiltro.Items.AddRange(new object[] {
            "TODO",
            "PENDIENTE",
            "EN PROCESO",
            "TERMINADO"});
            this.CmbFiltro.Location = new System.Drawing.Point(575, 26);
            this.CmbFiltro.Name = "CmbFiltro";
            this.CmbFiltro.Size = new System.Drawing.Size(318, 32);
            this.CmbFiltro.TabIndex = 5;
            this.CmbFiltro.SelectedIndexChanged += new System.EventHandler(this.CmbFiltro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filtrar acciones por:";
            // 
            // TxtIndicador
            // 
            this.TxtIndicador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIndicador.Location = new System.Drawing.Point(15, 81);
            this.TxtIndicador.Name = "TxtIndicador";
            this.TxtIndicador.ReadOnly = true;
            this.TxtIndicador.Size = new System.Drawing.Size(554, 29);
            this.TxtIndicador.TabIndex = 3;
            // 
            // TxtProceso
            // 
            this.TxtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProceso.Location = new System.Drawing.Point(15, 26);
            this.TxtProceso.Name = "TxtProceso";
            this.TxtProceso.ReadOnly = true;
            this.TxtProceso.Size = new System.Drawing.Size(554, 29);
            this.TxtProceso.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Indicador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proceso:";
            // 
            // DgvAcciones
            // 
            this.DgvAcciones.AllowUserToAddRows = false;
            this.DgvAcciones.AllowUserToDeleteRows = false;
            this.DgvAcciones.AllowUserToOrderColumns = true;
            this.DgvAcciones.AllowUserToResizeRows = false;
            this.DgvAcciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAcciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAcciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipo_accion,
            this.detalles,
            this.fecha_promes,
            this.responsable,
            this.estatus,
            this.evaluador,
            this.fecha_evaluacion,
            this.efectividad});
            this.DgvAcciones.ContextMenuStrip = this.MenuOpciones;
            this.DgvAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAcciones.Location = new System.Drawing.Point(0, 163);
            this.DgvAcciones.Name = "DgvAcciones";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAcciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DgvAcciones.RowHeadersVisible = false;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAcciones.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvAcciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAcciones.Size = new System.Drawing.Size(1057, 311);
            this.DgvAcciones.TabIndex = 22;
            this.DgvAcciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAcciones_CellClick);
            this.DgvAcciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvAcciones_CellFormatting);
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluarToolStripMenuItem,
            this.agregarAcciónToolStripMenuItem,
            this.editarAcciónToolStripMenuItem,
            this.eliminarAccióToolStripMenuItem});
            this.MenuOpciones.Name = "contextMenuStrip1";
            this.MenuOpciones.Size = new System.Drawing.Size(156, 92);
            this.MenuOpciones.Opening += new System.ComponentModel.CancelEventHandler(this.MenuOpciones_Opening);
            // 
            // evaluarToolStripMenuItem
            // 
            this.evaluarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.efectivaToolStripMenuItem,
            this.noEfectivaToolStripMenuItem});
            this.evaluarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.assign_activity;
            this.evaluarToolStripMenuItem.Name = "evaluarToolStripMenuItem";
            this.evaluarToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.evaluarToolStripMenuItem.Text = "Evaluar";
            // 
            // efectivaToolStripMenuItem
            // 
            this.efectivaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.apple_icon_60x60;
            this.efectivaToolStripMenuItem.Name = "efectivaToolStripMenuItem";
            this.efectivaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.efectivaToolStripMenuItem.Text = "Efectiva";
            this.efectivaToolStripMenuItem.Click += new System.EventHandler(this.efectivaToolStripMenuItem_Click);
            // 
            // noEfectivaToolStripMenuItem
            // 
            this.noEfectivaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.progress_defaultModify;
            this.noEfectivaToolStripMenuItem.Name = "noEfectivaToolStripMenuItem";
            this.noEfectivaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.noEfectivaToolStripMenuItem.Text = "No efectiva";
            this.noEfectivaToolStripMenuItem.Click += new System.EventHandler(this.noEfectivaToolStripMenuItem_Click);
            // 
            // agregarAcciónToolStripMenuItem
            // 
            this.agregarAcciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarAcciónToolStripMenuItem.Name = "agregarAcciónToolStripMenuItem";
            this.agregarAcciónToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.agregarAcciónToolStripMenuItem.Text = "Agregar acción";
            this.agregarAcciónToolStripMenuItem.Click += new System.EventHandler(this.agregarAcciónToolStripMenuItem_Click);
            // 
            // editarAcciónToolStripMenuItem
            // 
            this.editarAcciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarAcciónToolStripMenuItem.Name = "editarAcciónToolStripMenuItem";
            this.editarAcciónToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.editarAcciónToolStripMenuItem.Text = "Editar acción";
            this.editarAcciónToolStripMenuItem.Click += new System.EventHandler(this.editarAcciónToolStripMenuItem_Click);
            // 
            // eliminarAccióToolStripMenuItem
            // 
            this.eliminarAccióToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarAccióToolStripMenuItem.Name = "eliminarAccióToolStripMenuItem";
            this.eliminarAccióToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.eliminarAccióToolStripMenuItem.Text = "Eliminar acción";
            this.eliminarAccióToolStripMenuItem.Click += new System.EventHandler(this.eliminarAccióToolStripMenuItem_Click);
            // 
            // id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 70;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // tipo_accion
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tipo_accion.DefaultCellStyle = dataGridViewCellStyle3;
            this.tipo_accion.Frozen = true;
            this.tipo_accion.HeaderText = "Tipo de acción";
            this.tipo_accion.MinimumWidth = 150;
            this.tipo_accion.Name = "tipo_accion";
            this.tipo_accion.ReadOnly = true;
            this.tipo_accion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tipo_accion.Width = 150;
            // 
            // detalles
            // 
            this.detalles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detalles.DefaultCellStyle = dataGridViewCellStyle4;
            this.detalles.HeaderText = "Detalles";
            this.detalles.MinimumWidth = 100;
            this.detalles.Name = "detalles";
            this.detalles.ReadOnly = true;
            // 
            // fecha_promes
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_promes.DefaultCellStyle = dataGridViewCellStyle5;
            this.fecha_promes.HeaderText = "Fecha promesa";
            this.fecha_promes.MinimumWidth = 120;
            this.fecha_promes.Name = "fecha_promes";
            this.fecha_promes.ReadOnly = true;
            this.fecha_promes.Width = 120;
            // 
            // responsable
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable.DefaultCellStyle = dataGridViewCellStyle6;
            this.responsable.HeaderText = "Responsable";
            this.responsable.MinimumWidth = 150;
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            this.responsable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable.Width = 150;
            // 
            // estatus
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle7;
            this.estatus.HeaderText = "Estatus";
            this.estatus.MinimumWidth = 150;
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus.Width = 150;
            // 
            // evaluador
            // 
            this.evaluador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.evaluador.DefaultCellStyle = dataGridViewCellStyle8;
            this.evaluador.HeaderText = "Evaluador";
            this.evaluador.MinimumWidth = 170;
            this.evaluador.Name = "evaluador";
            this.evaluador.ReadOnly = true;
            this.evaluador.Width = 170;
            // 
            // fecha_evaluacion
            // 
            this.fecha_evaluacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_evaluacion.DefaultCellStyle = dataGridViewCellStyle9;
            this.fecha_evaluacion.HeaderText = "Fecha de evaluación";
            this.fecha_evaluacion.MinimumWidth = 150;
            this.fecha_evaluacion.Name = "fecha_evaluacion";
            this.fecha_evaluacion.ReadOnly = true;
            this.fecha_evaluacion.Width = 150;
            // 
            // efectividad
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.efectividad.DefaultCellStyle = dataGridViewCellStyle10;
            this.efectividad.HeaderText = "Efectividad";
            this.efectividad.MinimumWidth = 150;
            this.efectividad.Name = "efectividad";
            this.efectividad.ReadOnly = true;
            this.efectividad.Width = 150;
            // 
            // FrmAccionesKPIs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 474);
            this.Controls.Add(this.DgvAcciones);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAccionesKPIs";
            this.Text = "FrmAccionesKPIs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAccionesKPIs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcciones)).EndInit();
            this.MenuOpciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtIndicador;
        private System.Windows.Forms.TextBox TxtProceso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvAcciones;
        private System.Windows.Forms.ComboBox CmbFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem agregarAcciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarAcciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarAccióToolStripMenuItem;
        private System.Windows.Forms.ComboBox CmbFiltroEfectividad;
        private System.Windows.Forms.Label LblEfectividad;
        private System.Windows.Forms.ToolStripMenuItem evaluarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efectivaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noEfectivaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promes;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn evaluador;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_evaluacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn efectividad;
    }
}
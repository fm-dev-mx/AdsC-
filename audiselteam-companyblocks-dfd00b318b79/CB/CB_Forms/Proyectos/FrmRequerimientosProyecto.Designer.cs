namespace CB
{
    partial class FrmRequerimientosProyecto
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
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.solicitudesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbFiltroNivelRevision = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbFiltroOrigen = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnOpciones = new System.Windows.Forms.Button();
            this.LblUltimaActualizacion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbFiltroEstatus = new System.Windows.Forms.ComboBox();
            this.DgvRequerimientos = new System.Windows.Forms.DataGridView();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parametros = new System.Windows.Forms.DataGridViewImageColumn();
            this.key_items = new System.Windows.Forms.DataGridViewImageColumn();
            this.restricciones = new System.Windows.Forms.DataGridViewImageColumn();
            this.nota = new System.Windows.Forms.DataGridViewImageColumn();
            this.adjunto = new System.Windows.Forms.DataGridViewImageColumn();
            this.MenuOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequerimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solicitudesToolStripMenuItem,
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.borrarToolStripMenuItem,
            this.detallesToolStripMenuItem,
            this.reportarToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(132, 136);
            // 
            // solicitudesToolStripMenuItem
            // 
            this.solicitudesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.important_icon;
            this.solicitudesToolStripMenuItem.Name = "solicitudesToolStripMenuItem";
            this.solicitudesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.solicitudesToolStripMenuItem.Text = "Solicitudes";
            this.solicitudesToolStripMenuItem.Click += new System.EventHandler(this.solicitudesToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Enabled = false;
            this.nuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Enabled = false;
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Enabled = false;
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // detallesToolStripMenuItem
            // 
            this.detallesToolStripMenuItem.Enabled = false;
            this.detallesToolStripMenuItem.Name = "detallesToolStripMenuItem";
            this.detallesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.detallesToolStripMenuItem.Text = "Detalles";
            this.detallesToolStripMenuItem.Click += new System.EventHandler(this.detallesToolStripMenuItem_Click);
            // 
            // reportarToolStripMenuItem
            // 
            this.reportarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Custom_reports_icon;
            this.reportarToolStripMenuItem.Name = "reportarToolStripMenuItem";
            this.reportarToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.reportarToolStripMenuItem.Text = "Reportar";
            this.reportarToolStripMenuItem.Click += new System.EventHandler(this.reportarToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.CmbFiltroNivelRevision);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.CmbFiltroOrigen);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.CmbFiltroEstatus);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvRequerimientos);
            this.splitContainer1.Size = new System.Drawing.Size(1243, 507);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nivel de revisión:";
            // 
            // CmbFiltroNivelRevision
            // 
            this.CmbFiltroNivelRevision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroNivelRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroNivelRevision.FormattingEnabled = true;
            this.CmbFiltroNivelRevision.Items.AddRange(new object[] {
            "TODOS",
            "CONCEPTO",
            "DISEÑO",
            "ENSAMBLE",
            "INTEGRACION",
            "PROGRAMACION",
            "MQ1",
            "MQ2"});
            this.CmbFiltroNivelRevision.Location = new System.Drawing.Point(503, 32);
            this.CmbFiltroNivelRevision.Name = "CmbFiltroNivelRevision";
            this.CmbFiltroNivelRevision.Size = new System.Drawing.Size(223, 32);
            this.CmbFiltroNivelRevision.TabIndex = 21;
            this.CmbFiltroNivelRevision.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroNivelRevision_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Origen:";
            // 
            // CmbFiltroOrigen
            // 
            this.CmbFiltroOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroOrigen.FormattingEnabled = true;
            this.CmbFiltroOrigen.Items.AddRange(new object[] {
            "TODOS",
            "CLIENTE",
            "INTERNO"});
            this.CmbFiltroOrigen.Location = new System.Drawing.Point(260, 32);
            this.CmbFiltroOrigen.Name = "CmbFiltroOrigen";
            this.CmbFiltroOrigen.Size = new System.Drawing.Size(223, 32);
            this.CmbFiltroOrigen.TabIndex = 17;
            this.CmbFiltroOrigen.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroOrigen_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(959, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BtnActualizar);
            this.splitContainer2.Panel1.Controls.Add(this.BtnOpciones);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LblUltimaActualizacion);
            this.splitContainer2.Size = new System.Drawing.Size(284, 84);
            this.splitContainer2.SplitterDistance = 55;
            this.splitContainer2.TabIndex = 16;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.update;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(47, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(118, 55);
            this.BtnActualizar.TabIndex = 10;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnOpciones
            // 
            this.BtnOpciones.ContextMenuStrip = this.MenuOpciones;
            this.BtnOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpciones.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnOpciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpciones.Location = new System.Drawing.Point(165, 0);
            this.BtnOpciones.Name = "BtnOpciones";
            this.BtnOpciones.Size = new System.Drawing.Size(119, 55);
            this.BtnOpciones.TabIndex = 1;
            this.BtnOpciones.Text = "Opciones";
            this.BtnOpciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpciones.UseVisualStyleBackColor = true;
            this.BtnOpciones.Click += new System.EventHandler(this.BtnOpciones_Click);
            // 
            // LblUltimaActualizacion
            // 
            this.LblUltimaActualizacion.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblUltimaActualizacion.Location = new System.Drawing.Point(0, 0);
            this.LblUltimaActualizacion.Name = "LblUltimaActualizacion";
            this.LblUltimaActualizacion.Size = new System.Drawing.Size(284, 25);
            this.LblUltimaActualizacion.TabIndex = 11;
            this.LblUltimaActualizacion.Text = "Ultima actualización: XXYY";
            this.LblUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Estatus:";
            // 
            // CmbFiltroEstatus
            // 
            this.CmbFiltroEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroEstatus.FormattingEnabled = true;
            this.CmbFiltroEstatus.Items.AddRange(new object[] {
            "TODOS",
            "NO DEFINIDO",
            "DEFINIDO",
            "EN EVALUACION",
            "DESCARTADO"});
            this.CmbFiltroEstatus.Location = new System.Drawing.Point(19, 32);
            this.CmbFiltroEstatus.Name = "CmbFiltroEstatus";
            this.CmbFiltroEstatus.Size = new System.Drawing.Size(223, 32);
            this.CmbFiltroEstatus.TabIndex = 13;
            this.CmbFiltroEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroTipo_SelectedIndexChanged);
            // 
            // DgvRequerimientos
            // 
            this.DgvRequerimientos.AllowUserToAddRows = false;
            this.DgvRequerimientos.AllowUserToDeleteRows = false;
            this.DgvRequerimientos.AllowUserToResizeRows = false;
            this.DgvRequerimientos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvRequerimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRequerimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.descripcion,
            this.origen,
            this.estatus,
            this.nivel_revision,
            this.estatus_revision,
            this.parametros,
            this.key_items,
            this.restricciones,
            this.nota,
            this.adjunto});
            this.DgvRequerimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvRequerimientos.Location = new System.Drawing.Point(0, 0);
            this.DgvRequerimientos.Name = "DgvRequerimientos";
            this.DgvRequerimientos.ReadOnly = true;
            this.DgvRequerimientos.RowHeadersVisible = false;
            this.DgvRequerimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRequerimientos.Size = new System.Drawing.Size(1243, 419);
            this.DgvRequerimientos.TabIndex = 0;
            this.DgvRequerimientos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequerimientos_CellClick);
            this.DgvRequerimientos.DoubleClick += new System.EventHandler(this.DgvRequerimientos_DoubleClick);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1243, 23);
            this.LblTitulo.TabIndex = 5;
            this.LblTitulo.Text = "REQUERIMIENTOS DEL PROYECTO XXX.YY - NOMBRE";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.Frozen = true;
            this.id.HeaderText = "Req. #";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle2;
            this.nombre.Frozen = true;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 180;
            // 
            // descripcion
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle3;
            this.descripcion.Frozen = true;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 180;
            // 
            // origen
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.origen.DefaultCellStyle = dataGridViewCellStyle4;
            this.origen.Frozen = true;
            this.origen.HeaderText = "Origen";
            this.origen.Name = "origen";
            this.origen.ReadOnly = true;
            this.origen.Width = 180;
            // 
            // estatus
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle5;
            this.estatus.Frozen = true;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 180;
            // 
            // nivel_revision
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nivel_revision.DefaultCellStyle = dataGridViewCellStyle6;
            this.nivel_revision.Frozen = true;
            this.nivel_revision.HeaderText = "Nivel de revisión";
            this.nivel_revision.Name = "nivel_revision";
            this.nivel_revision.ReadOnly = true;
            this.nivel_revision.Width = 180;
            // 
            // estatus_revision
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_revision.DefaultCellStyle = dataGridViewCellStyle7;
            this.estatus_revision.Frozen = true;
            this.estatus_revision.HeaderText = "Estatus de revisión";
            this.estatus_revision.Name = "estatus_revision";
            this.estatus_revision.ReadOnly = true;
            this.estatus_revision.Width = 180;
            // 
            // parametros
            // 
            this.parametros.HeaderText = "Parametros";
            this.parametros.Name = "parametros";
            this.parametros.ReadOnly = true;
            this.parametros.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.parametros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // key_items
            // 
            this.key_items.HeaderText = "Key Item";
            this.key_items.Name = "key_items";
            this.key_items.ReadOnly = true;
            this.key_items.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.key_items.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // restricciones
            // 
            this.restricciones.HeaderText = "Restriccion";
            this.restricciones.Name = "restricciones";
            this.restricciones.ReadOnly = true;
            this.restricciones.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.restricciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // nota
            // 
            this.nota.HeaderText = "Nota";
            this.nota.Name = "nota";
            this.nota.ReadOnly = true;
            this.nota.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // adjunto
            // 
            this.adjunto.HeaderText = "Adjunto";
            this.adjunto.Name = "adjunto";
            this.adjunto.ReadOnly = true;
            this.adjunto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.adjunto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FrmRequerimientosProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 530);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmRequerimientosProyecto";
            this.Text = "Requerimientos del proyecto";
            this.Load += new System.EventHandler(this.FrmRequerimientos_Load);
            this.MenuOpciones.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequerimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbFiltroEstatus;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnOpciones;
        private System.Windows.Forms.Label LblUltimaActualizacion;
        private System.Windows.Forms.DataGridView DgvRequerimientos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbFiltroOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbFiltroNivelRevision;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitudesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel_revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_revision;
        private System.Windows.Forms.DataGridViewImageColumn parametros;
        private System.Windows.Forms.DataGridViewImageColumn key_items;
        private System.Windows.Forms.DataGridViewImageColumn restricciones;
        private System.Windows.Forms.DataGridViewImageColumn nota;
        private System.Windows.Forms.DataGridViewImageColumn adjunto;
    }
}
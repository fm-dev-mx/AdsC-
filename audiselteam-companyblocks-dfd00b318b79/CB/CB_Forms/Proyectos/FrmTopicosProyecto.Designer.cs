namespace CB
{
    partial class FrmTopicosProyecto
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevaTareaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeSincronizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvTopicos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_creacion_junta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbFiltroEstatus = new System.Windows.Forms.ComboBox();
            this.LblUltimaActualizacion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbFiltroOrigen = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MenuOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTopicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "JUNTAS DE SINCRONIZACION DEL PROYECTO XXX.YY - NOMBRE";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaTareaTool,
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.borrarToolStripMenuItem,
            this.reporteDeSincronizaciónToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(236, 114);
            this.MenuOpciones.Opening += new System.ComponentModel.CancelEventHandler(this.MenuOpciones_Opening);
            // 
            // nuevaTareaTool
            // 
            this.nuevaTareaTool.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevaTareaTool.Name = "nuevaTareaTool";
            this.nuevaTareaTool.Size = new System.Drawing.Size(235, 22);
            this.nuevaTareaTool.Text = "Nueva Junta de Sincronización";
            this.nuevaTareaTool.Click += new System.EventHandler(this.nuevaTareaTool_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo tópico";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Enabled = false;
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Enabled = false;
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // reporteDeSincronizaciónToolStripMenuItem
            // 
            this.reporteDeSincronizaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.details;
            this.reporteDeSincronizaciónToolStripMenuItem.Name = "reporteDeSincronizaciónToolStripMenuItem";
            this.reporteDeSincronizaciónToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.reporteDeSincronizaciónToolStripMenuItem.Text = "Reporte de sincronización";
            this.reporteDeSincronizaciónToolStripMenuItem.Click += new System.EventHandler(this.reporteDeSincronizaciónToolStripMenuItem_Click);
            // 
            // DgvTopicos
            // 
            this.DgvTopicos.AllowUserToAddRows = false;
            this.DgvTopicos.AllowUserToDeleteRows = false;
            this.DgvTopicos.AllowUserToResizeRows = false;
            this.DgvTopicos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvTopicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTopicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha_creacion,
            this.usuario_creacion,
            this.Titulo,
            this.estatus,
            this.fecha_creacion_junta});
            this.DgvTopicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTopicos.Location = new System.Drawing.Point(0, 0);
            this.DgvTopicos.Name = "DgvTopicos";
            this.DgvTopicos.ReadOnly = true;
            this.DgvTopicos.RowHeadersVisible = false;
            this.DgvTopicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTopicos.Size = new System.Drawing.Size(1243, 419);
            this.DgvTopicos.TabIndex = 0;
            this.DgvTopicos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTopicos_CellClick);
            this.DgvTopicos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvTopicos_CellFormatting);
            this.DgvTopicos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTopicos_CellMouseDoubleClick);
            this.DgvTopicos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTopicos_CellMouseDown);
            this.DgvTopicos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTopicos_ColumnHeaderMouseClick);
            this.DgvTopicos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvTopicos_MouseClick);
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.Frozen = true;
            this.id.HeaderText = "#";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // fecha_creacion
            // 
            this.fecha_creacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_creacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecha_creacion.Frozen = true;
            this.fecha_creacion.HeaderText = "Fecha creación";
            this.fecha_creacion.MinimumWidth = 140;
            this.fecha_creacion.Name = "fecha_creacion";
            this.fecha_creacion.ReadOnly = true;
            this.fecha_creacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fecha_creacion.Width = 140;
            // 
            // usuario_creacion
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuario_creacion.DefaultCellStyle = dataGridViewCellStyle3;
            this.usuario_creacion.Frozen = true;
            this.usuario_creacion.HeaderText = "Creado por";
            this.usuario_creacion.Name = "usuario_creacion";
            this.usuario_creacion.ReadOnly = true;
            this.usuario_creacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usuario_creacion.Width = 180;
            // 
            // Titulo
            // 
            this.Titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Titulo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Titulo.HeaderText = "Título";
            this.Titulo.Name = "Titulo";
            this.Titulo.ReadOnly = true;
            this.Titulo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // estatus
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle5;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.estatus.Visible = false;
            this.estatus.Width = 180;
            // 
            // fecha_creacion_junta
            // 
            this.fecha_creacion_junta.HeaderText = "fecha junta";
            this.fecha_creacion_junta.Name = "fecha_creacion_junta";
            this.fecha_creacion_junta.ReadOnly = true;
            this.fecha_creacion_junta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fecha_creacion_junta.Visible = false;
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
            "PENDIENTE",
            "EN PROCESO",
            "DETENIDO",
            "DESCARTADO",
            "TERMINADO"});
            this.CmbFiltroEstatus.Location = new System.Drawing.Point(19, 32);
            this.CmbFiltroEstatus.Name = "CmbFiltroEstatus";
            this.CmbFiltroEstatus.Size = new System.Drawing.Size(223, 32);
            this.CmbFiltroEstatus.TabIndex = 13;
            this.CmbFiltroEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroEstatus_SelectedIndexChanged);
            // 
            // LblUltimaActualizacion
            // 
            this.LblUltimaActualizacion.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblUltimaActualizacion.Location = new System.Drawing.Point(-1, 0);
            this.LblUltimaActualizacion.Name = "LblUltimaActualizacion";
            this.LblUltimaActualizacion.Size = new System.Drawing.Size(291, 25);
            this.LblUltimaActualizacion.TabIndex = 11;
            this.LblUltimaActualizacion.Text = "Ultima actualización: XXYY";
            this.LblUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Creado por:";
            // 
            // CmbFiltroOrigen
            // 
            this.CmbFiltroOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroOrigen.FormattingEnabled = true;
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
            this.splitContainer2.Location = new System.Drawing.Point(953, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BtnActualizar);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LblUltimaActualizacion);
            this.splitContainer2.Size = new System.Drawing.Size(290, 84);
            this.splitContainer2.SplitterDistance = 55;
            this.splitContainer2.TabIndex = 16;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.update;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(172, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(118, 55);
            this.BtnActualizar.TabIndex = 10;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.CmbFiltroOrigen);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.CmbFiltroEstatus);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvTopicos);
            this.splitContainer1.Size = new System.Drawing.Size(1243, 507);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 9;
            // 
            // FrmTopicosProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 530);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmTopicosProyecto";
            this.Text = "Sincronización del proyecto";
            this.Load += new System.EventHandler(this.FrmTopicosProyecto_Load);
            this.MenuOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTopicos)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.DataGridView DgvTopicos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbFiltroEstatus;
        private System.Windows.Forms.Label LblUltimaActualizacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbFiltroOrigen;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem reporteDeSincronizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaTareaTool;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_creacion_junta;
    }
}
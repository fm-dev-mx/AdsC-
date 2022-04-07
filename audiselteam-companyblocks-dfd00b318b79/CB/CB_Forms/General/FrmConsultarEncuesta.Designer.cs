namespace CB
{
    partial class FrmConsultarEncuesta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BkgCargarEncuestas = new System.ComponentModel.BackgroundWorker();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.CmbEstatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DgvEncuestas = new System.Windows.Forms.DataGridView();
            this.MenuEncuesta = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.irAEncuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verEncuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plantilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encuesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_encuestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEncuestas)).BeginInit();
            this.MenuEncuesta.SuspendLayout();
            this.SuspendLayout();
            // 
            // BkgCargarEncuestas
            // 
            this.BkgCargarEncuestas.WorkerReportsProgress = true;
            this.BkgCargarEncuestas.WorkerSupportsCancellation = true;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1215, 23);
            this.LblTitulo.TabIndex = 10;
            this.LblTitulo.Text = "ENCUESTAS";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbEstatus
            // 
            this.CmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatus.FormattingEnabled = true;
            this.CmbEstatus.Items.AddRange(new object[] {
            "TODOS",
            "PENDIENTE",
            "TARDE",
            "CONTESTADA"});
            this.CmbEstatus.Location = new System.Drawing.Point(15, 28);
            this.CmbEstatus.Name = "CmbEstatus";
            this.CmbEstatus.Size = new System.Drawing.Size(309, 32);
            this.CmbEstatus.TabIndex = 4;
            this.CmbEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbEstatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar por estatus:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.CmbEstatus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1215, 71);
            this.panel1.TabIndex = 11;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1078, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 71);
            this.BtnSalir.TabIndex = 131;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // DgvEncuestas
            // 
            this.DgvEncuestas.AllowUserToAddRows = false;
            this.DgvEncuestas.AllowUserToResizeRows = false;
            this.DgvEncuestas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvEncuestas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvEncuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEncuestas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.plantilla,
            this.encuesta,
            this.usuario_encuestado,
            this.usuario_creacion,
            this.comentarios,
            this.fecha_creacion,
            this.status});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvEncuestas.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvEncuestas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvEncuestas.Location = new System.Drawing.Point(0, 94);
            this.DgvEncuestas.Name = "DgvEncuestas";
            this.DgvEncuestas.RowHeadersVisible = false;
            this.DgvEncuestas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEncuestas.Size = new System.Drawing.Size(1215, 316);
            this.DgvEncuestas.TabIndex = 12;
            this.DgvEncuestas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEncuestas_CellClick);
            this.DgvEncuestas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvEncuestas_CellFormatting);
            this.DgvEncuestas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvEncuestas_CellMouseClick);
            this.DgvEncuestas.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvEncuestas_CellMouseDown);
            // 
            // MenuEncuesta
            // 
            this.MenuEncuesta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.irAEncuestaToolStripMenuItem,
            this.verEncuestaToolStripMenuItem});
            this.MenuEncuesta.Name = "MenuEncuesta";
            this.MenuEncuesta.Size = new System.Drawing.Size(141, 48);
            // 
            // irAEncuestaToolStripMenuItem
            // 
            this.irAEncuestaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.upload;
            this.irAEncuestaToolStripMenuItem.Name = "irAEncuestaToolStripMenuItem";
            this.irAEncuestaToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.irAEncuestaToolStripMenuItem.Text = "Ir a encuesta";
            this.irAEncuestaToolStripMenuItem.Click += new System.EventHandler(this.irAEncuestaToolStripMenuItem_Click);
            // 
            // verEncuestaToolStripMenuItem
            // 
            this.verEncuestaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.search_icon_48;
            this.verEncuestaToolStripMenuItem.Name = "verEncuestaToolStripMenuItem";
            this.verEncuestaToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.verEncuestaToolStripMenuItem.Text = "Ver encuesta";
            this.verEncuestaToolStripMenuItem.Click += new System.EventHandler(this.verEncuestaToolStripMenuItem_Click);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 70;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 70;
            // 
            // plantilla
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.plantilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.plantilla.HeaderText = "Plantilla";
            this.plantilla.Name = "plantilla";
            this.plantilla.ReadOnly = true;
            this.plantilla.Visible = false;
            // 
            // encuesta
            // 
            this.encuesta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.encuesta.DefaultCellStyle = dataGridViewCellStyle3;
            this.encuesta.HeaderText = "Encuesta";
            this.encuesta.Name = "encuesta";
            this.encuesta.ReadOnly = true;
            // 
            // usuario_encuestado
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usuario_encuestado.DefaultCellStyle = dataGridViewCellStyle4;
            this.usuario_encuestado.HeaderText = "Encuestado";
            this.usuario_encuestado.MinimumWidth = 180;
            this.usuario_encuestado.Name = "usuario_encuestado";
            this.usuario_encuestado.ReadOnly = true;
            this.usuario_encuestado.Width = 180;
            // 
            // usuario_creacion
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usuario_creacion.DefaultCellStyle = dataGridViewCellStyle5;
            this.usuario_creacion.HeaderText = "Usuario creación";
            this.usuario_creacion.MinimumWidth = 180;
            this.usuario_creacion.Name = "usuario_creacion";
            this.usuario_creacion.ReadOnly = true;
            this.usuario_creacion.Width = 180;
            // 
            // comentarios
            // 
            this.comentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comentarios.HeaderText = "Comentarios";
            this.comentarios.Name = "comentarios";
            this.comentarios.ReadOnly = true;
            // 
            // fecha_creacion
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_creacion.DefaultCellStyle = dataGridViewCellStyle6;
            this.fecha_creacion.HeaderText = "Fecha de creación";
            this.fecha_creacion.MinimumWidth = 180;
            this.fecha_creacion.Name = "fecha_creacion";
            this.fecha_creacion.ReadOnly = true;
            this.fecha_creacion.Width = 180;
            // 
            // status
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.status.DefaultCellStyle = dataGridViewCellStyle7;
            this.status.HeaderText = "Estatus";
            this.status.MinimumWidth = 120;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 120;
            // 
            // FrmConsultarEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 410);
            this.Controls.Add(this.DgvEncuestas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmConsultarEncuesta";
            this.Text = "FrmConsultarEncuesta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmConsultarEncuesta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEncuestas)).EndInit();
            this.MenuEncuesta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSalir;
        private System.ComponentModel.BackgroundWorker BkgCargarEncuestas;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ComboBox CmbEstatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvEncuestas;
        private System.Windows.Forms.ContextMenuStrip MenuEncuesta;
        private System.Windows.Forms.ToolStripMenuItem irAEncuestaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verEncuestaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn plantilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn encuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_encuestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}
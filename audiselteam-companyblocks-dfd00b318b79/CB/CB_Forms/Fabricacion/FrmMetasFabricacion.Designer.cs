namespace CB
{
    partial class FrmMetasFabricacion
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.NumLimite = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.CmbEstatusProgreso = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvMetas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entregable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_entregable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_solicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_compromiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_respuesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subensamble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuMetas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aceptarCompromisoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechazarCompromisoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reprogramarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumLimite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetas)).BeginInit();
            this.MenuMetas.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(1140, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "METAS DE FABRICACION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NumLimite);
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.CmbEstatusProgreso);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 78);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Límite:";
            // 
            // NumLimite
            // 
            this.NumLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumLimite.Location = new System.Drawing.Point(277, 33);
            this.NumLimite.Name = "NumLimite";
            this.NumLimite.Size = new System.Drawing.Size(61, 26);
            this.NumLimite.TabIndex = 24;
            this.NumLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumLimite.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NumLimite.ValueChanged += new System.EventHandler(this.NumLimite_ValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(999, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer1.Size = new System.Drawing.Size(141, 78);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.TabIndex = 23;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(141, 47);
            this.BtnSalir.TabIndex = 20;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // CmbEstatusProgreso
            // 
            this.CmbEstatusProgreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatusProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatusProgreso.FormattingEnabled = true;
            this.CmbEstatusProgreso.Items.AddRange(new object[] {
            "PENDIENTE",
            "EN PROCESO",
            "TERMINADO"});
            this.CmbEstatusProgreso.Location = new System.Drawing.Point(15, 33);
            this.CmbEstatusProgreso.Name = "CmbEstatusProgreso";
            this.CmbEstatusProgreso.Size = new System.Drawing.Size(256, 26);
            this.CmbEstatusProgreso.TabIndex = 22;
            this.CmbEstatusProgreso.SelectedIndexChanged += new System.EventHandler(this.CmbEstatusProgreso_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Filtrar por progreso:";
            // 
            // DgvMetas
            // 
            this.DgvMetas.AllowUserToAddRows = false;
            this.DgvMetas.AllowUserToDeleteRows = false;
            this.DgvMetas.AllowUserToResizeRows = false;
            this.DgvMetas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.entregable,
            this.tipo_entregable,
            this.fecha_solicitud,
            this.fecha_promesa,
            this.requisitor,
            this.responsable,
            this.estatus_compromiso,
            this.progreso,
            this.fecha_respuesta,
            this.comentarios,
            this.proyecto,
            this.subensamble,
            this.id_plano});
            this.DgvMetas.ContextMenuStrip = this.MenuMetas;
            this.DgvMetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMetas.Location = new System.Drawing.Point(0, 101);
            this.DgvMetas.MultiSelect = false;
            this.DgvMetas.Name = "DgvMetas";
            this.DgvMetas.ReadOnly = true;
            this.DgvMetas.RowHeadersVisible = false;
            this.DgvMetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMetas.Size = new System.Drawing.Size(1140, 345);
            this.DgvMetas.TabIndex = 8;
            // 
            // id
            // 
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // entregable
            // 
            this.entregable.Frozen = true;
            this.entregable.HeaderText = "Entregable";
            this.entregable.Name = "entregable";
            this.entregable.ReadOnly = true;
            this.entregable.Width = 300;
            // 
            // tipo_entregable
            // 
            this.tipo_entregable.HeaderText = "Tipo entregable";
            this.tipo_entregable.Name = "tipo_entregable";
            this.tipo_entregable.ReadOnly = true;
            this.tipo_entregable.Visible = false;
            // 
            // fecha_solicitud
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_solicitud.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecha_solicitud.HeaderText = "Fecha de solicitud";
            this.fecha_solicitud.Name = "fecha_solicitud";
            this.fecha_solicitud.ReadOnly = true;
            this.fecha_solicitud.Width = 95;
            // 
            // fecha_promesa
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_promesa.DefaultCellStyle = dataGridViewCellStyle3;
            this.fecha_promesa.HeaderText = "Fecha promesa";
            this.fecha_promesa.Name = "fecha_promesa";
            this.fecha_promesa.ReadOnly = true;
            this.fecha_promesa.Width = 95;
            // 
            // requisitor
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.requisitor.DefaultCellStyle = dataGridViewCellStyle4;
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            this.requisitor.Width = 150;
            // 
            // responsable
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.responsable.DefaultCellStyle = dataGridViewCellStyle5;
            this.responsable.HeaderText = "Responsable";
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            this.responsable.Width = 150;
            // 
            // estatus_compromiso
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_compromiso.DefaultCellStyle = dataGridViewCellStyle6;
            this.estatus_compromiso.HeaderText = "Estatus del compromiso";
            this.estatus_compromiso.Name = "estatus_compromiso";
            this.estatus_compromiso.ReadOnly = true;
            this.estatus_compromiso.Width = 150;
            // 
            // progreso
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.progreso.DefaultCellStyle = dataGridViewCellStyle7;
            this.progreso.HeaderText = "Progreso";
            this.progreso.Name = "progreso";
            this.progreso.ReadOnly = true;
            // 
            // fecha_respuesta
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_respuesta.DefaultCellStyle = dataGridViewCellStyle8;
            this.fecha_respuesta.HeaderText = "Fecha de respuesta";
            this.fecha_respuesta.Name = "fecha_respuesta";
            this.fecha_respuesta.ReadOnly = true;
            this.fecha_respuesta.Width = 95;
            // 
            // comentarios
            // 
            this.comentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comentarios.HeaderText = "Comentarios";
            this.comentarios.Name = "comentarios";
            this.comentarios.ReadOnly = true;
            // 
            // proyecto
            // 
            this.proyecto.HeaderText = "Proyecto";
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            this.proyecto.Visible = false;
            // 
            // subensamble
            // 
            this.subensamble.HeaderText = "Subensamble";
            this.subensamble.Name = "subensamble";
            this.subensamble.ReadOnly = true;
            this.subensamble.Visible = false;
            // 
            // id_plano
            // 
            this.id_plano.HeaderText = "Plano";
            this.id_plano.Name = "id_plano";
            this.id_plano.ReadOnly = true;
            this.id_plano.Visible = false;
            // 
            // MenuMetas
            // 
            this.MenuMetas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.aceptarCompromisoToolStripMenuItem,
            this.rechazarCompromisoToolStripMenuItem,
            this.terminarToolStripMenuItem,
            this.reprogramarToolStripMenuItem});
            this.MenuMetas.Name = "MenuMetas";
            this.MenuMetas.Size = new System.Drawing.Size(193, 136);
            this.MenuMetas.Opening += new System.ComponentModel.CancelEventHandler(this.MenuMetas_Opening);
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.nuevaToolStripMenuItem.Text = "Nueva";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // aceptarCompromisoToolStripMenuItem
            // 
            this.aceptarCompromisoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.approve;
            this.aceptarCompromisoToolStripMenuItem.Name = "aceptarCompromisoToolStripMenuItem";
            this.aceptarCompromisoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.aceptarCompromisoToolStripMenuItem.Text = "Aceptar compromiso";
            this.aceptarCompromisoToolStripMenuItem.Click += new System.EventHandler(this.aceptarCompromisoToolStripMenuItem_Click);
            // 
            // rechazarCompromisoToolStripMenuItem
            // 
            this.rechazarCompromisoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.reject_icon;
            this.rechazarCompromisoToolStripMenuItem.Name = "rechazarCompromisoToolStripMenuItem";
            this.rechazarCompromisoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.rechazarCompromisoToolStripMenuItem.Text = "Rechazar compromiso";
            this.rechazarCompromisoToolStripMenuItem.Click += new System.EventHandler(this.rechazarCompromisoToolStripMenuItem_Click);
            // 
            // terminarToolStripMenuItem
            // 
            this.terminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.terminarToolStripMenuItem.Name = "terminarToolStripMenuItem";
            this.terminarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.terminarToolStripMenuItem.Text = "Terminar";
            this.terminarToolStripMenuItem.Click += new System.EventHandler(this.terminarToolStripMenuItem_Click);
            // 
            // reprogramarToolStripMenuItem
            // 
            this.reprogramarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.update;
            this.reprogramarToolStripMenuItem.Name = "reprogramarToolStripMenuItem";
            this.reprogramarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.reprogramarToolStripMenuItem.Text = "Reprogramar";
            this.reprogramarToolStripMenuItem.Click += new System.EventHandler(this.reprogramarToolStripMenuItem_Click);
            // 
            // FrmMetasFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 446);
            this.Controls.Add(this.DgvMetas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMetasFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Metas de fabricacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMetasFabricacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumLimite)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetas)).EndInit();
            this.MenuMetas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvMetas;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ContextMenuStrip MenuMetas;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aceptarCompromisoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechazarCompromisoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminarToolStripMenuItem;
        private System.Windows.Forms.ComboBox CmbEstatusProgreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem reprogramarToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumLimite;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn entregable;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_entregable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_solicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_compromiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn progreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_respuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn subensamble;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_plano;
    }
}
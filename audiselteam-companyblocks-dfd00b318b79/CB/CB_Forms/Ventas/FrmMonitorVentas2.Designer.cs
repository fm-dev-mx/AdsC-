namespace CB
{
    partial class FrmMonitorVentas2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbFechaLimite = new System.Windows.Forms.ComboBox();
            this.CmbEstatusCotizacion = new System.Windows.Forms.ComboBox();
            this.CmbFechaCreacion = new System.Windows.Forms.ComboBox();
            this.CmbUsuario = new System.Windows.Forms.ComboBox();
            this.CmbClientes = new System.Windows.Forms.ComboBox();
            this.CmbContectoTecnico = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvVentas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_crecion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_limite_enviar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_evaluacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuVentas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevaCotizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVentas)).BeginInit();
            this.MenuVentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbFechaLimite);
            this.panel1.Controls.Add(this.CmbEstatusCotizacion);
            this.panel1.Controls.Add(this.CmbFechaCreacion);
            this.panel1.Controls.Add(this.CmbUsuario);
            this.panel1.Controls.Add(this.CmbClientes);
            this.panel1.Controls.Add(this.CmbContectoTecnico);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 103);
            this.panel1.TabIndex = 0;
            // 
            // CmbFechaLimite
            // 
            this.CmbFechaLimite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFechaLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFechaLimite.FormattingEnabled = true;
            this.CmbFechaLimite.Location = new System.Drawing.Point(571, 69);
            this.CmbFechaLimite.Name = "CmbFechaLimite";
            this.CmbFechaLimite.Size = new System.Drawing.Size(277, 28);
            this.CmbFechaLimite.TabIndex = 11;
            this.CmbFechaLimite.SelectedIndexChanged += new System.EventHandler(this.CmbContectoTecnico_SelectedIndexChanged);
            // 
            // CmbEstatusCotizacion
            // 
            this.CmbEstatusCotizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatusCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatusCotizacion.FormattingEnabled = true;
            this.CmbEstatusCotizacion.Location = new System.Drawing.Point(571, 20);
            this.CmbEstatusCotizacion.Name = "CmbEstatusCotizacion";
            this.CmbEstatusCotizacion.Size = new System.Drawing.Size(277, 28);
            this.CmbEstatusCotizacion.TabIndex = 10;
            this.CmbEstatusCotizacion.SelectedIndexChanged += new System.EventHandler(this.CmbContectoTecnico_SelectedIndexChanged);
            // 
            // CmbFechaCreacion
            // 
            this.CmbFechaCreacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFechaCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFechaCreacion.FormattingEnabled = true;
            this.CmbFechaCreacion.Location = new System.Drawing.Point(306, 69);
            this.CmbFechaCreacion.Name = "CmbFechaCreacion";
            this.CmbFechaCreacion.Size = new System.Drawing.Size(259, 28);
            this.CmbFechaCreacion.TabIndex = 9;
            this.CmbFechaCreacion.SelectedIndexChanged += new System.EventHandler(this.CmbContectoTecnico_SelectedIndexChanged);
            // 
            // CmbUsuario
            // 
            this.CmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUsuario.FormattingEnabled = true;
            this.CmbUsuario.Location = new System.Drawing.Point(306, 20);
            this.CmbUsuario.Name = "CmbUsuario";
            this.CmbUsuario.Size = new System.Drawing.Size(259, 28);
            this.CmbUsuario.TabIndex = 8;
            this.CmbUsuario.SelectedIndexChanged += new System.EventHandler(this.CmbContectoTecnico_SelectedIndexChanged);
            // 
            // CmbClientes
            // 
            this.CmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbClientes.FormattingEnabled = true;
            this.CmbClientes.Location = new System.Drawing.Point(6, 20);
            this.CmbClientes.Name = "CmbClientes";
            this.CmbClientes.Size = new System.Drawing.Size(294, 28);
            this.CmbClientes.TabIndex = 7;
            this.CmbClientes.SelectedIndexChanged += new System.EventHandler(this.CmbClientes_SelectedIndexChanged);
            // 
            // CmbContectoTecnico
            // 
            this.CmbContectoTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContectoTecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContectoTecnico.FormattingEnabled = true;
            this.CmbContectoTecnico.Location = new System.Drawing.Point(6, 69);
            this.CmbContectoTecnico.Name = "CmbContectoTecnico";
            this.CmbContectoTecnico.Size = new System.Drawing.Size(294, 28);
            this.CmbContectoTecnico.TabIndex = 6;
            this.CmbContectoTecnico.SelectedIndexChanged += new System.EventHandler(this.CmbContectoTecnico_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(568, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha límite para enviar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(568, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Estatus de cotización:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(303, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha creación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Creada por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contacto técnico:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // DgvVentas
            // 
            this.DgvVentas.AllowUserToAddRows = false;
            this.DgvVentas.AllowUserToResizeRows = false;
            this.DgvVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre_cotizacion,
            this.usuario_creacion,
            this.fecha_crecion,
            this.fecha_limite_enviar,
            this.estatus_cotizacion,
            this.estatus_evaluacion});
            this.DgvVentas.ContextMenuStrip = this.MenuVentas;
            this.DgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvVentas.Location = new System.Drawing.Point(0, 126);
            this.DgvVentas.Name = "DgvVentas";
            this.DgvVentas.RowHeadersVisible = false;
            this.DgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvVentas.Size = new System.Drawing.Size(992, 319);
            this.DgvVentas.TabIndex = 1;
            this.DgvVentas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvVentas_CellFormatting);
            // 
            // id
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle8;
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 35;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 55;
            // 
            // nombre_cotizacion
            // 
            this.nombre_cotizacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre_cotizacion.DefaultCellStyle = dataGridViewCellStyle9;
            this.nombre_cotizacion.HeaderText = "Nombre de la cotización";
            this.nombre_cotizacion.MinimumWidth = 200;
            this.nombre_cotizacion.Name = "nombre_cotizacion";
            this.nombre_cotizacion.ReadOnly = true;
            // 
            // usuario_creacion
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usuario_creacion.DefaultCellStyle = dataGridViewCellStyle10;
            this.usuario_creacion.HeaderText = "Creada por";
            this.usuario_creacion.MinimumWidth = 150;
            this.usuario_creacion.Name = "usuario_creacion";
            this.usuario_creacion.ReadOnly = true;
            this.usuario_creacion.Width = 150;
            // 
            // fecha_crecion
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_crecion.DefaultCellStyle = dataGridViewCellStyle11;
            this.fecha_crecion.HeaderText = "Fecha de creación";
            this.fecha_crecion.MinimumWidth = 150;
            this.fecha_crecion.Name = "fecha_crecion";
            this.fecha_crecion.ReadOnly = true;
            this.fecha_crecion.Width = 150;
            // 
            // fecha_limite_enviar
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_limite_enviar.DefaultCellStyle = dataGridViewCellStyle12;
            this.fecha_limite_enviar.HeaderText = "Fecha límite para enviar";
            this.fecha_limite_enviar.MinimumWidth = 150;
            this.fecha_limite_enviar.Name = "fecha_limite_enviar";
            this.fecha_limite_enviar.ReadOnly = true;
            this.fecha_limite_enviar.Width = 150;
            // 
            // estatus_cotizacion
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus_cotizacion.DefaultCellStyle = dataGridViewCellStyle13;
            this.estatus_cotizacion.HeaderText = "Estatus de cotización";
            this.estatus_cotizacion.MinimumWidth = 190;
            this.estatus_cotizacion.Name = "estatus_cotizacion";
            this.estatus_cotizacion.ReadOnly = true;
            this.estatus_cotizacion.Width = 190;
            // 
            // estatus_evaluacion
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus_evaluacion.DefaultCellStyle = dataGridViewCellStyle14;
            this.estatus_evaluacion.HeaderText = "Estatus de evaluación";
            this.estatus_evaluacion.MinimumWidth = 190;
            this.estatus_evaluacion.Name = "estatus_evaluacion";
            this.estatus_evaluacion.ReadOnly = true;
            this.estatus_evaluacion.Width = 190;
            // 
            // MenuVentas
            // 
            this.MenuVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCotizaciónToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuVentas.Name = "MenuVentas";
            this.MenuVentas.Size = new System.Drawing.Size(166, 70);
            this.MenuVentas.Opening += new System.ComponentModel.CancelEventHandler(this.MenuVentas_Opening);
            // 
            // nuevaCotizaciónToolStripMenuItem
            // 
            this.nuevaCotizaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevaCotizaciónToolStripMenuItem.Name = "nuevaCotizaciónToolStripMenuItem";
            this.nuevaCotizaciónToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.nuevaCotizaciónToolStripMenuItem.Text = "Nueva cotización";
            this.nuevaCotizaciónToolStripMenuItem.Click += new System.EventHandler(this.nuevaCotizaciónToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(992, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "MONITOR DE VENTAS";
            // 
            // FrmMonitorVentas2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 445);
            this.Controls.Add(this.DgvVentas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.Name = "FrmMonitorVentas2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMonitorVentas2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVentas)).EndInit();
            this.MenuVentas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.ComboBox CmbEstatusCotizacion;
        private System.Windows.Forms.ComboBox CmbFechaCreacion;
        private System.Windows.Forms.ComboBox CmbUsuario;
        private System.Windows.Forms.ComboBox CmbClientes;
        private System.Windows.Forms.ComboBox CmbContectoTecnico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvVentas;
        private System.Windows.Forms.ContextMenuStrip MenuVentas;
        private System.Windows.Forms.ToolStripMenuItem nuevaCotizaciónToolStripMenuItem;
        private System.Windows.Forms.ComboBox CmbFechaLimite;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_cotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_crecion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_limite_enviar;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_cotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_evaluacion;
    }
}
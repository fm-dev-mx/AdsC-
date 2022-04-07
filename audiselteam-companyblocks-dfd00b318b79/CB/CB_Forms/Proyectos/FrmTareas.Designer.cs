namespace CB
{
    partial class FrmTareas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvTareas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_topico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuTareas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarEstatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enProcesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detenidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revisadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarPrioridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urgenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requiereAtenciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.mostrarRevisadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTareas)).BeginInit();
            this.MenuTareas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvTareas
            // 
            this.DgvTareas.AllowUserToAddRows = false;
            this.DgvTareas.AllowUserToDeleteRows = false;
            this.DgvTareas.AllowUserToResizeRows = false;
            this.DgvTareas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTareas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha_creacion,
            this.responsable,
            this.tarea,
            this.estatus,
            this.prioridad,
            this.fecha_promesa,
            this.estatus_tiempo,
            this.id_topico});
            this.DgvTareas.ContextMenuStrip = this.MenuTareas;
            this.DgvTareas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTareas.Location = new System.Drawing.Point(0, 81);
            this.DgvTareas.Name = "DgvTareas";
            this.DgvTareas.RowHeadersVisible = false;
            this.DgvTareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTareas.Size = new System.Drawing.Size(936, 369);
            this.DgvTareas.TabIndex = 1;
            this.DgvTareas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvTareas_CellFormatting);
            // 
            // id
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle9;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // fecha_creacion
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_creacion.DefaultCellStyle = dataGridViewCellStyle10;
            this.fecha_creacion.HeaderText = "Fecha creación";
            this.fecha_creacion.Name = "fecha_creacion";
            this.fecha_creacion.ReadOnly = true;
            this.fecha_creacion.Width = 150;
            // 
            // responsable
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable.DefaultCellStyle = dataGridViewCellStyle11;
            this.responsable.HeaderText = "Responsable";
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            this.responsable.Width = 280;
            // 
            // tarea
            // 
            this.tarea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.tarea.DefaultCellStyle = dataGridViewCellStyle12;
            this.tarea.HeaderText = "Tarea";
            this.tarea.MinimumWidth = 100;
            this.tarea.Name = "tarea";
            this.tarea.ReadOnly = true;
            // 
            // estatus
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle13;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 150;
            // 
            // prioridad
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.prioridad.DefaultCellStyle = dataGridViewCellStyle14;
            this.prioridad.HeaderText = "Prioridad";
            this.prioridad.Name = "prioridad";
            this.prioridad.ReadOnly = true;
            this.prioridad.Width = 150;
            // 
            // fecha_promesa
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_promesa.DefaultCellStyle = dataGridViewCellStyle15;
            this.fecha_promesa.HeaderText = "Fecha promesa";
            this.fecha_promesa.Name = "fecha_promesa";
            this.fecha_promesa.ReadOnly = true;
            this.fecha_promesa.Width = 150;
            // 
            // estatus_tiempo
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus_tiempo.DefaultCellStyle = dataGridViewCellStyle16;
            this.estatus_tiempo.HeaderText = "Estatus tiempo";
            this.estatus_tiempo.Name = "estatus_tiempo";
            this.estatus_tiempo.ReadOnly = true;
            this.estatus_tiempo.Width = 150;
            // 
            // id_topico
            // 
            this.id_topico.HeaderText = "id_topico";
            this.id_topico.Name = "id_topico";
            this.id_topico.ReadOnly = true;
            this.id_topico.Visible = false;
            // 
            // MenuTareas
            // 
            this.MenuTareas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarEstatusToolStripMenuItem,
            this.editarPrioridadToolStripMenuItem,
            this.mostrarRevisadosToolStripMenuItem});
            this.MenuTareas.Name = "MenuTareas";
            this.MenuTareas.Size = new System.Drawing.Size(168, 70);
            this.MenuTareas.Opening += new System.ComponentModel.CancelEventHandler(this.MenuTareas_Opening);
            // 
            // editarEstatusToolStripMenuItem
            // 
            this.editarEstatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendienteToolStripMenuItem,
            this.enProcesoToolStripMenuItem,
            this.detenidoToolStripMenuItem,
            this.terminadoToolStripMenuItem,
            this.revisadoToolStripMenuItem});
            this.editarEstatusToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarEstatusToolStripMenuItem.Name = "editarEstatusToolStripMenuItem";
            this.editarEstatusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editarEstatusToolStripMenuItem.Text = "Editar estatus";
            this.editarEstatusToolStripMenuItem.Click += new System.EventHandler(this.editarEstatusToolStripMenuItem_Click);
            // 
            // pendienteToolStripMenuItem
            // 
            this.pendienteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.pendiente_a_tiempo_24;
            this.pendienteToolStripMenuItem.Name = "pendienteToolStripMenuItem";
            this.pendienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pendienteToolStripMenuItem.Text = "Pendiente";
            this.pendienteToolStripMenuItem.Click += new System.EventHandler(this.pendienteToolStripMenuItem_Click);
            // 
            // enProcesoToolStripMenuItem
            // 
            this.enProcesoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.en_proceso_a_tiempo_24;
            this.enProcesoToolStripMenuItem.Name = "enProcesoToolStripMenuItem";
            this.enProcesoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enProcesoToolStripMenuItem.Text = "En proceso";
            this.enProcesoToolStripMenuItem.Click += new System.EventHandler(this.enProcesoToolStripMenuItem_Click);
            // 
            // detenidoToolStripMenuItem
            // 
            this.detenidoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.detenido_a_tiempo;
            this.detenidoToolStripMenuItem.Name = "detenidoToolStripMenuItem";
            this.detenidoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.detenidoToolStripMenuItem.Text = "Detenido";
            this.detenidoToolStripMenuItem.Click += new System.EventHandler(this.detenidoToolStripMenuItem_Click);
            // 
            // terminadoToolStripMenuItem
            // 
            this.terminadoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.terminado_a_tiempo_24;
            this.terminadoToolStripMenuItem.Name = "terminadoToolStripMenuItem";
            this.terminadoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.terminadoToolStripMenuItem.Text = "Terminado";
            this.terminadoToolStripMenuItem.Click += new System.EventHandler(this.terminadoToolStripMenuItem_Click);
            // 
            // revisadoToolStripMenuItem
            // 
            this.revisadoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.ok_48;
            this.revisadoToolStripMenuItem.Name = "revisadoToolStripMenuItem";
            this.revisadoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.revisadoToolStripMenuItem.Text = "Revisado";
            this.revisadoToolStripMenuItem.Click += new System.EventHandler(this.revisadoToolStripMenuItem_Click);
            // 
            // editarPrioridadToolStripMenuItem
            // 
            this.editarPrioridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.urgenteToolStripMenuItem,
            this.requiereAtenciónToolStripMenuItem,
            this.regularToolStripMenuItem});
            this.editarPrioridadToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarPrioridadToolStripMenuItem.Name = "editarPrioridadToolStripMenuItem";
            this.editarPrioridadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editarPrioridadToolStripMenuItem.Text = "Editar prioridad";
            this.editarPrioridadToolStripMenuItem.Click += new System.EventHandler(this.editarPrioridadToolStripMenuItem_Click);
            // 
            // urgenteToolStripMenuItem
            // 
            this.urgenteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.en_proceso_tarde_24;
            this.urgenteToolStripMenuItem.Name = "urgenteToolStripMenuItem";
            this.urgenteToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.urgenteToolStripMenuItem.Text = "Urgente";
            this.urgenteToolStripMenuItem.Click += new System.EventHandler(this.urgenteToolStripMenuItem_Click);
            // 
            // requiereAtenciónToolStripMenuItem
            // 
            this.requiereAtenciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.en_proceso_limite_24;
            this.requiereAtenciónToolStripMenuItem.Name = "requiereAtenciónToolStripMenuItem";
            this.requiereAtenciónToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.requiereAtenciónToolStripMenuItem.Text = "requiere atención";
            this.requiereAtenciónToolStripMenuItem.Click += new System.EventHandler(this.requiereAtenciónToolStripMenuItem_Click);
            // 
            // regularToolStripMenuItem
            // 
            this.regularToolStripMenuItem.Image = global::CB_Base.Properties.Resources.en_proceso_a_tiempo_24;
            this.regularToolStripMenuItem.Name = "regularToolStripMenuItem";
            this.regularToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.regularToolStripMenuItem.Text = "regular";
            this.regularToolStripMenuItem.Click += new System.EventHandler(this.regularToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 58);
            this.panel1.TabIndex = 2;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(796, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(140, 58);
            this.BtnSalir.TabIndex = 20;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(936, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "TAREAS DEL PROYECTO #";
            // 
            // mostrarRevisadosToolStripMenuItem
            // 
            this.mostrarRevisadosToolStripMenuItem.CheckOnClick = true;
            this.mostrarRevisadosToolStripMenuItem.Name = "mostrarRevisadosToolStripMenuItem";
            this.mostrarRevisadosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.mostrarRevisadosToolStripMenuItem.Text = "Mostrar revisados";
            this.mostrarRevisadosToolStripMenuItem.Click += new System.EventHandler(this.mostrarRevisadosToolStripMenuItem_Click);
            // 
            // FrmTareas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 450);
            this.Controls.Add(this.DgvTareas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.Name = "FrmTareas";
            this.Text = "FrmTareas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTareas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTareas)).EndInit();
            this.MenuTareas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.DataGridView DgvTareas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ContextMenuStrip MenuTareas;
        private System.Windows.Forms.ToolStripMenuItem editarEstatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarPrioridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enProcesoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detenidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revisadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urgenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requiereAtenciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_topico;
        private System.Windows.Forms.ToolStripMenuItem mostrarRevisadosToolStripMenuItem;
    }
}
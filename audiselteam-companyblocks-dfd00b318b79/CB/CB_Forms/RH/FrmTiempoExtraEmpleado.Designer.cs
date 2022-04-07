namespace CB
{
    partial class FrmTiempoExtraEmpleado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.LblTotalHorasExtras = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NumSemanaYear = new System.Windows.Forms.NumericUpDown();
            this.LblEtiquetaEquipo = new System.Windows.Forms.Label();
            this.CmbEquipo = new System.Windows.Forms.ComboBox();
            this.CmbEmpleado = new System.Windows.Forms.ComboBox();
            this.DateHasta = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbDepartamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DateDesde = new System.Windows.Forms.DateTimePicker();
            this.TxtNombreSupervisor = new System.Windows.Forms.TextBox();
            this.LblEtiquetaSupervisor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvActividades = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_autorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_autorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cumplimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_cumplimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuActividades = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autorizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumSemanaYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActividades)).BeginInit();
            this.MenuActividades.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(1260, 23);
            this.LblTitulo.TabIndex = 13;
            this.LblTitulo.Text = "TIEMPO EXTRA DEL EMPLEADO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.NumSemanaYear);
            this.panel1.Controls.Add(this.LblEtiquetaEquipo);
            this.panel1.Controls.Add(this.CmbEquipo);
            this.panel1.Controls.Add(this.CmbEmpleado);
            this.panel1.Controls.Add(this.DateHasta);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CmbDepartamento);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.DateDesde);
            this.panel1.Controls.Add(this.TxtNombreSupervisor);
            this.panel1.Controls.Add(this.LblEtiquetaSupervisor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 165);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.LblTotalHorasExtras);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1063, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 165);
            this.panel2.TabIndex = 132;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 64);
            this.label9.TabIndex = 134;
            this.label9.Text = "Total autorizado:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTotalHorasExtras
            // 
            this.LblTotalHorasExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalHorasExtras.Location = new System.Drawing.Point(3, 61);
            this.LblTotalHorasExtras.Name = "LblTotalHorasExtras";
            this.LblTotalHorasExtras.Size = new System.Drawing.Size(182, 62);
            this.LblTotalHorasExtras.TabIndex = 133;
            this.LblTotalHorasExtras.Text = "N/A";
            this.LblTotalHorasExtras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Semana:";
            // 
            // NumSemanaYear
            // 
            this.NumSemanaYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumSemanaYear.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.NumSemanaYear.Location = new System.Drawing.Point(500, 24);
            this.NumSemanaYear.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.NumSemanaYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumSemanaYear.Name = "NumSemanaYear";
            this.NumSemanaYear.Size = new System.Drawing.Size(87, 31);
            this.NumSemanaYear.TabIndex = 130;
            this.NumSemanaYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSemanaYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumSemanaYear.ValueChanged += new System.EventHandler(this.NumSemanaYear_ValueChanged);
            // 
            // LblEtiquetaEquipo
            // 
            this.LblEtiquetaEquipo.AutoSize = true;
            this.LblEtiquetaEquipo.Location = new System.Drawing.Point(326, 8);
            this.LblEtiquetaEquipo.Name = "LblEtiquetaEquipo";
            this.LblEtiquetaEquipo.Size = new System.Drawing.Size(43, 13);
            this.LblEtiquetaEquipo.TabIndex = 129;
            this.LblEtiquetaEquipo.Text = "Equipo:";
            // 
            // CmbEquipo
            // 
            this.CmbEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEquipo.FormattingEnabled = true;
            this.CmbEquipo.Location = new System.Drawing.Point(329, 24);
            this.CmbEquipo.Name = "CmbEquipo";
            this.CmbEquipo.Size = new System.Drawing.Size(165, 32);
            this.CmbEquipo.TabIndex = 128;
            this.CmbEquipo.SelectedIndexChanged += new System.EventHandler(this.CmbEquipo_SelectedIndexChanged);
            // 
            // CmbEmpleado
            // 
            this.CmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEmpleado.FormattingEnabled = true;
            this.CmbEmpleado.Location = new System.Drawing.Point(12, 78);
            this.CmbEmpleado.Name = "CmbEmpleado";
            this.CmbEmpleado.Size = new System.Drawing.Size(307, 32);
            this.CmbEmpleado.TabIndex = 125;
            this.CmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.CmbEmpleado_SelectedIndexChanged);
            // 
            // DateHasta
            // 
            this.DateHasta.Enabled = false;
            this.DateHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateHasta.Location = new System.Drawing.Point(329, 128);
            this.DateHasta.Name = "DateHasta";
            this.DateHasta.Size = new System.Drawing.Size(304, 29);
            this.DateHasta.TabIndex = 43;
            this.DateHasta.ValueChanged += new System.EventHandler(this.DateHasta_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 124;
            this.label6.Text = "Departamento:";
            // 
            // CmbDepartamento
            // 
            this.CmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDepartamento.FormattingEnabled = true;
            this.CmbDepartamento.Location = new System.Drawing.Point(12, 24);
            this.CmbDepartamento.Name = "CmbDepartamento";
            this.CmbDepartamento.Size = new System.Drawing.Size(307, 32);
            this.CmbDepartamento.TabIndex = 123;
            this.CmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.CmbDepartamento_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Desde:";
            // 
            // DateDesde
            // 
            this.DateDesde.Enabled = false;
            this.DateDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateDesde.Location = new System.Drawing.Point(329, 78);
            this.DateDesde.Name = "DateDesde";
            this.DateDesde.Size = new System.Drawing.Size(304, 29);
            this.DateDesde.TabIndex = 41;
            this.DateDesde.ValueChanged += new System.EventHandler(this.DateDesde_ValueChanged);
            // 
            // TxtNombreSupervisor
            // 
            this.TxtNombreSupervisor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombreSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreSupervisor.Location = new System.Drawing.Point(12, 128);
            this.TxtNombreSupervisor.MaxLength = 30;
            this.TxtNombreSupervisor.Name = "TxtNombreSupervisor";
            this.TxtNombreSupervisor.ReadOnly = true;
            this.TxtNombreSupervisor.Size = new System.Drawing.Size(307, 29);
            this.TxtNombreSupervisor.TabIndex = 37;
            // 
            // LblEtiquetaSupervisor
            // 
            this.LblEtiquetaSupervisor.AutoSize = true;
            this.LblEtiquetaSupervisor.Location = new System.Drawing.Point(9, 113);
            this.LblEtiquetaSupervisor.Name = "LblEtiquetaSupervisor";
            this.LblEtiquetaSupervisor.Size = new System.Drawing.Size(115, 13);
            this.LblEtiquetaSupervisor.TabIndex = 38;
            this.LblEtiquetaSupervisor.Text = "Nombre del supervisor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Nombre del empleado:";
            // 
            // DgvActividades
            // 
            this.DgvActividades.AllowUserToAddRows = false;
            this.DgvActividades.AllowUserToDeleteRows = false;
            this.DgvActividades.AllowUserToResizeRows = false;
            this.DgvActividades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvActividades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha,
            this.actividad,
            this.horas,
            this.autorizacion,
            this.usuario_autorizacion,
            this.fecha_autorizacion,
            this.cumplimiento,
            this.comentarios_cumplimiento});
            this.DgvActividades.ContextMenuStrip = this.MenuActividades;
            this.DgvActividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvActividades.Location = new System.Drawing.Point(0, 208);
            this.DgvActividades.Name = "DgvActividades";
            this.DgvActividades.ReadOnly = true;
            this.DgvActividades.RowHeadersVisible = false;
            this.DgvActividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvActividades.Size = new System.Drawing.Size(1260, 270);
            this.DgvActividades.TabIndex = 16;
            // 
            // id
            // 
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fecha
            // 
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha.DefaultCellStyle = dataGridViewCellStyle33;
            this.fecha.Frozen = true;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // actividad
            // 
            this.actividad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.actividad.DefaultCellStyle = dataGridViewCellStyle34;
            this.actividad.Frozen = true;
            this.actividad.HeaderText = "Actividad";
            this.actividad.Name = "actividad";
            this.actividad.ReadOnly = true;
            this.actividad.Width = 350;
            // 
            // horas
            // 
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.horas.DefaultCellStyle = dataGridViewCellStyle35;
            this.horas.Frozen = true;
            this.horas.HeaderText = "Horas";
            this.horas.Name = "horas";
            this.horas.ReadOnly = true;
            // 
            // autorizacion
            // 
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.autorizacion.DefaultCellStyle = dataGridViewCellStyle36;
            this.autorizacion.Frozen = true;
            this.autorizacion.HeaderText = "Estatus autorizacion";
            this.autorizacion.Name = "autorizacion";
            this.autorizacion.ReadOnly = true;
            this.autorizacion.Width = 150;
            // 
            // usuario_autorizacion
            // 
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuario_autorizacion.DefaultCellStyle = dataGridViewCellStyle37;
            this.usuario_autorizacion.HeaderText = "Autorizado por";
            this.usuario_autorizacion.Name = "usuario_autorizacion";
            this.usuario_autorizacion.ReadOnly = true;
            this.usuario_autorizacion.Width = 200;
            // 
            // fecha_autorizacion
            // 
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_autorizacion.DefaultCellStyle = dataGridViewCellStyle38;
            this.fecha_autorizacion.HeaderText = "Fecha autorizacion";
            this.fecha_autorizacion.Name = "fecha_autorizacion";
            this.fecha_autorizacion.ReadOnly = true;
            this.fecha_autorizacion.Width = 200;
            // 
            // cumplimiento
            // 
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cumplimiento.DefaultCellStyle = dataGridViewCellStyle39;
            this.cumplimiento.HeaderText = "Estatus cumplimiento";
            this.cumplimiento.Name = "cumplimiento";
            this.cumplimiento.ReadOnly = true;
            this.cumplimiento.Visible = false;
            this.cumplimiento.Width = 130;
            // 
            // comentarios_cumplimiento
            // 
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios_cumplimiento.DefaultCellStyle = dataGridViewCellStyle40;
            this.comentarios_cumplimiento.HeaderText = "Comentarios de cumplimiento";
            this.comentarios_cumplimiento.Name = "comentarios_cumplimiento";
            this.comentarios_cumplimiento.ReadOnly = true;
            this.comentarios_cumplimiento.Visible = false;
            this.comentarios_cumplimiento.Width = 300;
            // 
            // MenuActividades
            // 
            this.MenuActividades.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorizarToolStripMenuItem});
            this.MenuActividades.Name = "MenuActividades";
            this.MenuActividades.Size = new System.Drawing.Size(123, 26);
            // 
            // autorizarToolStripMenuItem
            // 
            this.autorizarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.autorizarToolStripMenuItem.Name = "autorizarToolStripMenuItem";
            this.autorizarToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.autorizarToolStripMenuItem.Text = "Autorizar";
            this.autorizarToolStripMenuItem.Click += new System.EventHandler(this.autorizarToolStripMenuItem_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Navy;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1260, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "DESGLOSE DE ACTIVIDADES PLANIFICADAS PARA TIEMPO EXTRA:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmTiempoExtraEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 478);
            this.Controls.Add(this.DgvActividades);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmTiempoExtraEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiempo extra del empleado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTiempoExtraEmpleado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumSemanaYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActividades)).EndInit();
            this.MenuActividades.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblEtiquetaEquipo;
        private System.Windows.Forms.ComboBox CmbEquipo;
        private System.Windows.Forms.ComboBox CmbEmpleado;
        private System.Windows.Forms.DateTimePicker DateHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbDepartamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DateDesde;
        private System.Windows.Forms.TextBox TxtNombreSupervisor;
        private System.Windows.Forms.Label LblEtiquetaSupervisor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvActividades;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumSemanaYear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblTotalHorasExtras;
        private System.Windows.Forms.ContextMenuStrip MenuActividades;
        private System.Windows.Forms.ToolStripMenuItem autorizarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn actividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn horas;
        private System.Windows.Forms.DataGridViewTextBoxColumn autorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_autorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_autorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cumplimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_cumplimiento;
    }
}
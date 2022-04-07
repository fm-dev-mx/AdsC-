namespace CB
{
    partial class FrmHistorialMantenimiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbEquipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbMantenimiento = new System.Windows.Forms.ComboBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvHistorial = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CmbEquipo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbMantenimiento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 71);
            this.panel1.TabIndex = 0;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(909, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(155, 71);
            this.BtnSalir.TabIndex = 126;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(301, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo equipo:";
            // 
            // CmbEquipo
            // 
            this.CmbEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEquipo.FormattingEnabled = true;
            this.CmbEquipo.Location = new System.Drawing.Point(304, 28);
            this.CmbEquipo.Name = "CmbEquipo";
            this.CmbEquipo.Size = new System.Drawing.Size(253, 28);
            this.CmbEquipo.TabIndex = 2;
            this.CmbEquipo.SelectedIndexChanged += new System.EventHandler(this.CmbEquipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo mantenimiento:";
            // 
            // CmbMantenimiento
            // 
            this.CmbMantenimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMantenimiento.FormattingEnabled = true;
            this.CmbMantenimiento.Items.AddRange(new object[] {
            "TODOS",
            "PREVENTIVO",
            "CORRECTIVO"});
            this.CmbMantenimiento.Location = new System.Drawing.Point(26, 28);
            this.CmbMantenimiento.Name = "CmbMantenimiento";
            this.CmbMantenimiento.Size = new System.Drawing.Size(253, 28);
            this.CmbMantenimiento.TabIndex = 0;
            this.CmbMantenimiento.SelectedIndexChanged += new System.EventHandler(this.CmbMantenimiento_SelectedIndexChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1064, 23);
            this.LblTitulo.TabIndex = 11;
            this.LblTitulo.Text = "HISTORIAL DE MANTENIMIENTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvHistorial
            // 
            this.DgvHistorial.AllowUserToAddRows = false;
            this.DgvHistorial.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.mantenimiento,
            this.tipo_equipo,
            this.equipo,
            this.usuario});
            this.DgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHistorial.Location = new System.Drawing.Point(0, 94);
            this.DgvHistorial.Name = "DgvHistorial";
            this.DgvHistorial.RowHeadersVisible = false;
            this.DgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHistorial.Size = new System.Drawing.Size(1064, 536);
            this.DgvHistorial.TabIndex = 12;
            this.DgvHistorial.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHistorial_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 70;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // mantenimiento
            // 
            this.mantenimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mantenimiento.HeaderText = "Mantenimiento";
            this.mantenimiento.MinimumWidth = 200;
            this.mantenimiento.Name = "mantenimiento";
            this.mantenimiento.ReadOnly = true;
            // 
            // tipo_equipo
            // 
            this.tipo_equipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipo_equipo.HeaderText = "Tipo Equipo";
            this.tipo_equipo.MinimumWidth = 250;
            this.tipo_equipo.Name = "tipo_equipo";
            this.tipo_equipo.ReadOnly = true;
            // 
            // equipo
            // 
            this.equipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.equipo.HeaderText = "Equipo";
            this.equipo.MinimumWidth = 100;
            this.equipo.Name = "equipo";
            this.equipo.ReadOnly = true;
            // 
            // usuario
            // 
            this.usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.usuario.HeaderText = "Usuario asignado";
            this.usuario.MinimumWidth = 100;
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // FrmHistorialMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 630);
            this.Controls.Add(this.DgvHistorial);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmHistorialMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de mantenimiento";
            this.Load += new System.EventHandler(this.FrmHistorialMantenimiento_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbEquipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbMantenimiento;
        private System.Windows.Forms.DataGridView DgvHistorial;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
    }
}
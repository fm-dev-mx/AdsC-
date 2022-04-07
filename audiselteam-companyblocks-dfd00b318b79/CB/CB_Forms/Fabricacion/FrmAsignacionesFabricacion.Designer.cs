namespace CB
{
    partial class FrmAsignacionesFabricacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblMaterial = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DgvAsignaciones = new System.Windows.Forms.DataGridView();
            this.herramentista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trabajo_asignado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocupacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAsignaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // LblMaterial
            // 
            this.LblMaterial.BackColor = System.Drawing.Color.Black;
            this.LblMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMaterial.ForeColor = System.Drawing.Color.White;
            this.LblMaterial.Location = new System.Drawing.Point(0, 0);
            this.LblMaterial.Name = "LblMaterial";
            this.LblMaterial.Size = new System.Drawing.Size(679, 23);
            this.LblMaterial.TabIndex = 113;
            this.LblMaterial.Text = "ASIGNACIONES DE FABRICACION";
            this.LblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblMaterial.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblMaterial_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 64);
            this.panel1.TabIndex = 114;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(559, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(120, 64);
            this.BtnSalir.TabIndex = 20;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // DgvAsignaciones
            // 
            this.DgvAsignaciones.AllowUserToAddRows = false;
            this.DgvAsignaciones.AllowUserToDeleteRows = false;
            this.DgvAsignaciones.AllowUserToResizeRows = false;
            this.DgvAsignaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAsignaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAsignaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.herramentista,
            this.trabajo_asignado,
            this.ocupacion});
            this.DgvAsignaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAsignaciones.Location = new System.Drawing.Point(0, 87);
            this.DgvAsignaciones.Name = "DgvAsignaciones";
            this.DgvAsignaciones.RowHeadersVisible = false;
            this.DgvAsignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAsignaciones.Size = new System.Drawing.Size(679, 284);
            this.DgvAsignaciones.TabIndex = 115;
            this.DgvAsignaciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvAsignaciones_CellFormatting);
            // 
            // herramentista
            // 
            this.herramentista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.herramentista.DefaultCellStyle = dataGridViewCellStyle2;
            this.herramentista.HeaderText = "Herramentista";
            this.herramentista.Name = "herramentista";
            this.herramentista.ReadOnly = true;
            // 
            // trabajo_asignado
            // 
            this.trabajo_asignado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.trabajo_asignado.DefaultCellStyle = dataGridViewCellStyle3;
            this.trabajo_asignado.HeaderText = "Tiempo de trabajo asignado";
            this.trabajo_asignado.Name = "trabajo_asignado";
            this.trabajo_asignado.ReadOnly = true;
            // 
            // ocupacion
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ocupacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.ocupacion.HeaderText = "Estatus de ocupación";
            this.ocupacion.MinimumWidth = 180;
            this.ocupacion.Name = "ocupacion";
            this.ocupacion.ReadOnly = true;
            this.ocupacion.Width = 180;
            // 
            // FrmAsignacionesFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 371);
            this.Controls.Add(this.DgvAsignaciones);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAsignacionesFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignaciones de fabricación";
            this.Load += new System.EventHandler(this.FrmAsignacionesFabricacion_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAsignaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblMaterial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView DgvAsignaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramentista;
        private System.Windows.Forms.DataGridViewTextBoxColumn trabajo_asignado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ocupacion;
    }
}
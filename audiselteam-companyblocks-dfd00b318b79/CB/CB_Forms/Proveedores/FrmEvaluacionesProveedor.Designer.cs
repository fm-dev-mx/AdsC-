namespace CB
{
    partial class FrmEvaluacionesProveedor
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbEvaluaciones = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LblPuntuacion = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.LblPuntuacionEvaluacion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtEvaluador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtPuestoEvaluador = new System.Windows.Forms.TextBox();
            this.DgvHabilidadesPersonales = new System.Windows.Forms.DataGridView();
            this.id_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesPersonales)).BeginInit();
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
            this.LblTitulo.Size = new System.Drawing.Size(927, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "EVALUACIONES DE COMPETENCIAS DE PROVEEDORES";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CmbEvaluaciones);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 127);
            this.panel1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 13);
            this.label5.TabIndex = 122;
            this.label5.Text = "Selecciona una evaluación específica:";
            // 
            // CmbEvaluaciones
            // 
            this.CmbEvaluaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEvaluaciones.Enabled = false;
            this.CmbEvaluaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEvaluaciones.FormattingEnabled = true;
            this.CmbEvaluaciones.Location = new System.Drawing.Point(12, 82);
            this.CmbEvaluaciones.Name = "CmbEvaluaciones";
            this.CmbEvaluaciones.Size = new System.Drawing.Size(351, 32);
            this.CmbEvaluaciones.TabIndex = 121;
            this.CmbEvaluaciones.SelectedIndexChanged += new System.EventHandler(this.CmbEvaluaciones_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.LblPuntuacion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(766, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(161, 127);
            this.panel3.TabIndex = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "Promedio de evaluación:";
            // 
            // LblPuntuacion
            // 
            this.LblPuntuacion.AutoSize = true;
            this.LblPuntuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuntuacion.ForeColor = System.Drawing.Color.Red;
            this.LblPuntuacion.Location = new System.Drawing.Point(48, 27);
            this.LblPuntuacion.Name = "LblPuntuacion";
            this.LblPuntuacion.Size = new System.Drawing.Size(65, 37);
            this.LblPuntuacion.TabIndex = 117;
            this.LblPuntuacion.Text = "0%";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(12, 24);
            this.TxtNombre.Multiline = true;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ReadOnly = true;
            this.TxtNombre.Size = new System.Drawing.Size(697, 40);
            this.TxtNombre.TabIndex = 113;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "Proveedor:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DimGray;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(927, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "RESULTADOS DE LA EVALUACION SELECCIONADA";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.LblPuntuacionEvaluacion);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TxtEvaluador);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.TxtPuestoEvaluador);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 368);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(927, 65);
            this.panel2.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(670, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 125;
            this.label8.Text = "Resultado de la evaluación:";
            // 
            // LblPuntuacionEvaluacion
            // 
            this.LblPuntuacionEvaluacion.AutoSize = true;
            this.LblPuntuacionEvaluacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuntuacionEvaluacion.ForeColor = System.Drawing.Color.Red;
            this.LblPuntuacionEvaluacion.Location = new System.Drawing.Point(817, 16);
            this.LblPuntuacionEvaluacion.Name = "LblPuntuacionEvaluacion";
            this.LblPuntuacionEvaluacion.Size = new System.Drawing.Size(65, 37);
            this.LblPuntuacionEvaluacion.TabIndex = 126;
            this.LblPuntuacionEvaluacion.Text = "0%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 123;
            this.label4.Text = "Puesto:";
            // 
            // TxtEvaluador
            // 
            this.TxtEvaluador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEvaluador.Location = new System.Drawing.Point(12, 27);
            this.TxtEvaluador.Name = "TxtEvaluador";
            this.TxtEvaluador.ReadOnly = true;
            this.TxtEvaluador.Size = new System.Drawing.Size(316, 29);
            this.TxtEvaluador.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Evaluador:";
            // 
            // TxtPuestoEvaluador
            // 
            this.TxtPuestoEvaluador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPuestoEvaluador.Location = new System.Drawing.Point(334, 27);
            this.TxtPuestoEvaluador.Name = "TxtPuestoEvaluador";
            this.TxtPuestoEvaluador.ReadOnly = true;
            this.TxtPuestoEvaluador.Size = new System.Drawing.Size(312, 29);
            this.TxtPuestoEvaluador.TabIndex = 124;
            // 
            // DgvHabilidadesPersonales
            // 
            this.DgvHabilidadesPersonales.AllowUserToAddRows = false;
            this.DgvHabilidadesPersonales.AllowUserToDeleteRows = false;
            this.DgvHabilidadesPersonales.AllowUserToResizeRows = false;
            this.DgvHabilidadesPersonales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvHabilidadesPersonales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHabilidadesPersonales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_habilidad_personal,
            this.habilidad_personal,
            this.descripcion_habilidad_personal,
            this.comentarios_habilidad_personal,
            this.nivel_habilidad_personal});
            this.DgvHabilidadesPersonales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHabilidadesPersonales.Location = new System.Drawing.Point(0, 169);
            this.DgvHabilidadesPersonales.Name = "DgvHabilidadesPersonales";
            this.DgvHabilidadesPersonales.RowHeadersVisible = false;
            this.DgvHabilidadesPersonales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHabilidadesPersonales.Size = new System.Drawing.Size(927, 199);
            this.DgvHabilidadesPersonales.TabIndex = 18;
            // 
            // id_habilidad_personal
            // 
            this.id_habilidad_personal.HeaderText = "ID Habilidad Personal";
            this.id_habilidad_personal.Name = "id_habilidad_personal";
            this.id_habilidad_personal.ReadOnly = true;
            this.id_habilidad_personal.Visible = false;
            this.id_habilidad_personal.Width = 50;
            // 
            // habilidad_personal
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.habilidad_personal.DefaultCellStyle = dataGridViewCellStyle1;
            this.habilidad_personal.HeaderText = "Competencia";
            this.habilidad_personal.Name = "habilidad_personal";
            this.habilidad_personal.ReadOnly = true;
            this.habilidad_personal.Width = 280;
            // 
            // descripcion_habilidad_personal
            // 
            this.descripcion_habilidad_personal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle2;
            this.descripcion_habilidad_personal.HeaderText = "Descripción de la habilidad";
            this.descripcion_habilidad_personal.Name = "descripcion_habilidad_personal";
            this.descripcion_habilidad_personal.ReadOnly = true;
            // 
            // comentarios_habilidad_personal
            // 
            this.comentarios_habilidad_personal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle3;
            this.comentarios_habilidad_personal.HeaderText = "Comentarios";
            this.comentarios_habilidad_personal.Name = "comentarios_habilidad_personal";
            this.comentarios_habilidad_personal.ReadOnly = true;
            // 
            // nivel_habilidad_personal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nivel_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle4;
            this.nivel_habilidad_personal.HeaderText = "Nivel de desempeño observado";
            this.nivel_habilidad_personal.Name = "nivel_habilidad_personal";
            this.nivel_habilidad_personal.ReadOnly = true;
            this.nivel_habilidad_personal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nivel_habilidad_personal.Width = 180;
            // 
            // FrmEvaluacionesProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 433);
            this.Controls.Add(this.DgvHabilidadesPersonales);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmEvaluacionesProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEvaluacionesProveedor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEvaluacionesProveedor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesPersonales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbEvaluaciones;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblPuntuacion;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblPuntuacionEvaluacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtEvaluador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPuestoEvaluador;
        private System.Windows.Forms.DataGridView DgvHabilidadesPersonales;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel_habilidad_personal;
    }
}
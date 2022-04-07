namespace CB
{
    partial class FrmNuevoProcesoProyecto
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
            this.CmbIntervaloDuracion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NumDuracion = new System.Windows.Forms.NumericUpDown();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaFin = new System.Windows.Forms.DateTimePicker();
            this.FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.CmbProceso = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumDuracion)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbIntervaloDuracion
            // 
            this.CmbIntervaloDuracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIntervaloDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbIntervaloDuracion.FormattingEnabled = true;
            this.CmbIntervaloDuracion.Items.AddRange(new object[] {
            "DIAS NATURALES",
            "DIAS HABILES",
            "SEMANAS"});
            this.CmbIntervaloDuracion.Location = new System.Drawing.Point(110, 109);
            this.CmbIntervaloDuracion.Name = "CmbIntervaloDuracion";
            this.CmbIntervaloDuracion.Size = new System.Drawing.Size(224, 28);
            this.CmbIntervaloDuracion.TabIndex = 25;
            this.CmbIntervaloDuracion.SelectedIndexChanged += new System.EventHandler(this.CmbIntervaloDuracion_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Duración:";
            // 
            // NumDuracion
            // 
            this.NumDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumDuracion.Location = new System.Drawing.Point(12, 109);
            this.NumDuracion.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.NumDuracion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumDuracion.Name = "NumDuracion";
            this.NumDuracion.Size = new System.Drawing.Size(91, 29);
            this.NumDuracion.TabIndex = 23;
            this.NumDuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumDuracion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumDuracion.ValueChanged += new System.EventHandler(this.NumDuracion_ValueChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(12, 220);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(141, 51);
            this.BtnCancelar.TabIndex = 22;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Enabled = false;
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(399, 220);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(141, 51);
            this.BtnRegistrar.TabIndex = 21;
            this.BtnRegistrar.Text = "      Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Fecha de finalización del proceso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha de inicio del proceso:";
            // 
            // FechaFin
            // 
            this.FechaFin.Enabled = false;
            this.FechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaFin.Location = new System.Drawing.Point(282, 172);
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Size = new System.Drawing.Size(258, 26);
            this.FechaFin.TabIndex = 18;
            this.FechaFin.ValueChanged += new System.EventHandler(this.FechaFin_ValueChanged);
            // 
            // FechaInicio
            // 
            this.FechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaInicio.Location = new System.Drawing.Point(12, 172);
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Size = new System.Drawing.Size(258, 26);
            this.FechaInicio.TabIndex = 17;
            this.FechaInicio.ValueChanged += new System.EventHandler(this.FechaInicio_ValueChanged);
            // 
            // CmbProceso
            // 
            this.CmbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProceso.FormattingEnabled = true;
            this.CmbProceso.Location = new System.Drawing.Point(12, 47);
            this.CmbProceso.Name = "CmbProceso";
            this.CmbProceso.Size = new System.Drawing.Size(528, 32);
            this.CmbProceso.TabIndex = 16;
            this.CmbProceso.SelectedIndexChanged += new System.EventHandler(this.CmbProceso_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Proceso:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(552, 23);
            this.LblTitulo.TabIndex = 14;
            this.LblTitulo.Text = "NUEVO PROCESO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmNuevoProcesoProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 283);
            this.Controls.Add(this.CmbIntervaloDuracion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumDuracion);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FechaFin);
            this.Controls.Add(this.FechaInicio);
            this.Controls.Add(this.CmbProceso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoProcesoProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevoProcesoProyecto";
            this.Load += new System.EventHandler(this.FrmNuevoProcesoProyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumDuracion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbProceso;
        private System.Windows.Forms.DateTimePicker FechaInicio;
        private System.Windows.Forms.DateTimePicker FechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.NumericUpDown NumDuracion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbIntervaloDuracion;
    }
}
namespace CB
{
    partial class FrmAjustarTiemposFabricacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumTiempoEstandarMinutos = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbFactor = new System.Windows.Forms.ComboBox();
            this.DgvPorcentajes = new System.Windows.Forms.DataGridView();
            this.valor_factor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_adicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtProceso = new System.Windows.Forms.TextBox();
            this.TxtOperacion = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumTiempoEstandarMinutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPorcentajes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proceso de fabricación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Operación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tiempo estandar de la operación:";
            // 
            // NumTiempoEstandarMinutos
            // 
            this.NumTiempoEstandarMinutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumTiempoEstandarMinutos.Location = new System.Drawing.Point(12, 151);
            this.NumTiempoEstandarMinutos.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.NumTiempoEstandarMinutos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumTiempoEstandarMinutos.Name = "NumTiempoEstandarMinutos";
            this.NumTiempoEstandarMinutos.Size = new System.Drawing.Size(116, 29);
            this.NumTiempoEstandarMinutos.TabIndex = 5;
            this.NumTiempoEstandarMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumTiempoEstandarMinutos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumTiempoEstandarMinutos.ValueChanged += new System.EventHandler(this.NumTiempoEstandarMinutos_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Factores de tiempo adicional:";
            // 
            // CmbFactor
            // 
            this.CmbFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFactor.FormattingEnabled = true;
            this.CmbFactor.Items.AddRange(new object[] {
            "COMPLEJIDAD",
            "MATERIAL",
            "DIMENSIONES",
            "PRESENTACION"});
            this.CmbFactor.Location = new System.Drawing.Point(12, 203);
            this.CmbFactor.Name = "CmbFactor";
            this.CmbFactor.Size = new System.Drawing.Size(588, 32);
            this.CmbFactor.TabIndex = 7;
            this.CmbFactor.SelectedIndexChanged += new System.EventHandler(this.CmbFactor_SelectedIndexChanged);
            // 
            // DgvPorcentajes
            // 
            this.DgvPorcentajes.AllowUserToAddRows = false;
            this.DgvPorcentajes.AllowUserToDeleteRows = false;
            this.DgvPorcentajes.AllowUserToResizeRows = false;
            this.DgvPorcentajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPorcentajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valor_factor,
            this.porcentaje,
            this.tiempo_adicional});
            this.DgvPorcentajes.Location = new System.Drawing.Point(12, 241);
            this.DgvPorcentajes.MultiSelect = false;
            this.DgvPorcentajes.Name = "DgvPorcentajes";
            this.DgvPorcentajes.RowHeadersVisible = false;
            this.DgvPorcentajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvPorcentajes.Size = new System.Drawing.Size(588, 180);
            this.DgvPorcentajes.TabIndex = 8;
            this.DgvPorcentajes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPorcentajes_CellContentClick);
            this.DgvPorcentajes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPorcentajes_CellEndEdit);
            this.DgvPorcentajes.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DgvPorcentajes_CellValidating);
            // 
            // valor_factor
            // 
            this.valor_factor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valor_factor.HeaderText = "Opción del factor";
            this.valor_factor.Name = "valor_factor";
            this.valor_factor.ReadOnly = true;
            // 
            // porcentaje
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.porcentaje.DefaultCellStyle = dataGridViewCellStyle1;
            this.porcentaje.HeaderText = "Porcentaje de tiempo adicional";
            this.porcentaje.Name = "porcentaje";
            // 
            // tiempo_adicional
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tiempo_adicional.DefaultCellStyle = dataGridViewCellStyle2;
            this.tiempo_adicional.HeaderText = "Tiempo adicional (minutos)";
            this.tiempo_adicional.Name = "tiempo_adicional";
            this.tiempo_adicional.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(134, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "minutos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtProceso
            // 
            this.TxtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProceso.Location = new System.Drawing.Point(12, 48);
            this.TxtProceso.Name = "TxtProceso";
            this.TxtProceso.ReadOnly = true;
            this.TxtProceso.Size = new System.Drawing.Size(587, 29);
            this.TxtProceso.TabIndex = 12;
            // 
            // TxtOperacion
            // 
            this.TxtOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOperacion.Location = new System.Drawing.Point(12, 99);
            this.TxtOperacion.Name = "TxtOperacion";
            this.TxtOperacion.ReadOnly = true;
            this.TxtOperacion.Size = new System.Drawing.Size(587, 29);
            this.TxtOperacion.TabIndex = 13;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(609, 23);
            this.LblTitulo.TabIndex = 14;
            this.LblTitulo.Text = "AJUSTAR TIEMPOS DE FABRICACION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(441, 428);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(160, 53);
            this.BtnAceptar.TabIndex = 54;
            this.BtnAceptar.Text = "     Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // FrmAjustarTiemposFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 489);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.TxtOperacion);
            this.Controls.Add(this.TxtProceso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DgvPorcentajes);
            this.Controls.Add(this.CmbFactor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumTiempoEstandarMinutos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmAjustarTiemposFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajustar tiempos de fabricación";
            this.Load += new System.EventHandler(this.FrmAjustarTiemposFabricacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumTiempoEstandarMinutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPorcentajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumTiempoEstandarMinutos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbFactor;
        private System.Windows.Forms.DataGridView DgvPorcentajes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtProceso;
        private System.Windows.Forms.TextBox TxtOperacion;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_factor;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_adicional;
    }
}
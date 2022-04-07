namespace CB
{
    partial class FrmNuevoKeyitem
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
            this.label6 = new System.Windows.Forms.Label();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NumPiezas = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumPiezas)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Tipo";
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Items.AddRange(new object[] {
            "",
            "COMPRADO",
            "FABRICADO"});
            this.CmbTipo.Location = new System.Drawing.Point(9, 51);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(343, 32);
            this.CmbTipo.TabIndex = 0;
            this.CmbTipo.SelectedIndexChanged += new System.EventHandler(this.CmbTipo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Descripción";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Location = new System.Drawing.Point(10, 204);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(342, 78);
            this.TxtDescripcion.TabIndex = 3;
            this.TxtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Número de parte";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(10, 106);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(342, 29);
            this.TxtNumeroParte.TabIndex = 1;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(9, 347);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 40);
            this.BtnCancelar.TabIndex = 6;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Enabled = false;
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Location = new System.Drawing.Point(176, 347);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(176, 40);
            this.BtnRegistrar.TabIndex = 5;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(362, 23);
            this.LblTitulo.TabIndex = 65;
            this.LblTitulo.Text = "NUEVO KEY ITEM";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Fabricante";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(9, 156);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(342, 29);
            this.TxtFabricante.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 24);
            this.label3.TabIndex = 78;
            this.label3.Text = "Piezas";
            // 
            // NumPiezas
            // 
            this.NumPiezas.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPiezas.Location = new System.Drawing.Point(11, 296);
            this.NumPiezas.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.NumPiezas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPiezas.Name = "NumPiezas";
            this.NumPiezas.ReadOnly = true;
            this.NumPiezas.Size = new System.Drawing.Size(102, 35);
            this.NumPiezas.TabIndex = 4;
            this.NumPiezas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPiezas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmNuevoKeyitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 397);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumPiezas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtFabricante);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNumeroParte);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoKeyitem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo key item";
            ((System.ComponentModel.ISupportInitialize)(this.NumPiezas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumPiezas;
    }
}
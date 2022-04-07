namespace CB
{
    partial class FrmNuevoFactorValor
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
            this.label2 = new System.Windows.Forms.Label();
            this.TxtValorFactor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFactor = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.NumPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumPorcentaje)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Valor del factor";
            // 
            // TxtValorFactor
            // 
            this.TxtValorFactor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtValorFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtValorFactor.Location = new System.Drawing.Point(4, 103);
            this.TxtValorFactor.MaxLength = 40;
            this.TxtValorFactor.Name = "TxtValorFactor";
            this.TxtValorFactor.Size = new System.Drawing.Size(414, 29);
            this.TxtValorFactor.TabIndex = 63;
            this.TxtValorFactor.TextChanged += new System.EventHandler(this.TxtValorFactor_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Factor";
            // 
            // TxtFactor
            // 
            this.TxtFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFactor.Location = new System.Drawing.Point(4, 49);
            this.TxtFactor.Name = "TxtFactor";
            this.TxtFactor.ReadOnly = true;
            this.TxtFactor.Size = new System.Drawing.Size(518, 29);
            this.TxtFactor.TabIndex = 61;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(534, 23);
            this.LblTitulo.TabIndex = 60;
            this.LblTitulo.Text = "NUEVO FACTOR";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(196, 150);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 53);
            this.BtnCancelar.TabIndex = 65;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnCrear
            // 
            this.BtnCrear.Enabled = false;
            this.BtnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCrear.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCrear.Location = new System.Drawing.Point(362, 150);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(160, 53);
            this.BtnCrear.TabIndex = 66;
            this.BtnCrear.Text = "     Crear";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // NumPorcentaje
            // 
            this.NumPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPorcentaje.Location = new System.Drawing.Point(424, 104);
            this.NumPorcentaje.Name = "NumPorcentaje";
            this.NumPorcentaje.Size = new System.Drawing.Size(98, 26);
            this.NumPorcentaje.TabIndex = 67;
            this.NumPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPorcentaje.ValueChanged += new System.EventHandler(this.NumPorcentaje_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Porcentaje del valor";
            // 
            // FrmNuevoFactorValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 212);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumPorcentaje);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnCrear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtValorFactor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFactor);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoFactorValor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo valor del factor";
            ((System.ComponentModel.ISupportInitialize)(this.NumPorcentaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtValorFactor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFactor;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.NumericUpDown NumPorcentaje;
        private System.Windows.Forms.Label label3;
    }
}
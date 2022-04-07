namespace CB
{
    partial class FrmAgregarTermino
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
            this.LblInformacion = new System.Windows.Forms.Label();
            this.LblProcentaje = new System.Windows.Forms.Label();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.NumPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.TxtTermino = new System.Windows.Forms.TextBox();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumPorcentaje)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInformacion
            // 
            this.LblInformacion.AutoSize = true;
            this.LblInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInformacion.ForeColor = System.Drawing.Color.Red;
            this.LblInformacion.Location = new System.Drawing.Point(13, 97);
            this.LblInformacion.Name = "LblInformacion";
            this.LblInformacion.Size = new System.Drawing.Size(73, 13);
            this.LblInformacion.TabIndex = 18;
            this.LblInformacion.Text = "Información";
            this.LblInformacion.Visible = false;
            // 
            // LblProcentaje
            // 
            this.LblProcentaje.AutoSize = true;
            this.LblProcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.LblProcentaje.Location = new System.Drawing.Point(84, 65);
            this.LblProcentaje.Name = "LblProcentaje";
            this.LblProcentaje.Size = new System.Drawing.Size(26, 24);
            this.LblProcentaje.TabIndex = 17;
            this.LblProcentaje.Text = "%";
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnRegistrar.Location = new System.Drawing.Point(236, 119);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(218, 40);
            this.BtnRegistrar.TabIndex = 3;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Location = new System.Drawing.Point(12, 119);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(218, 40);
            this.BtnCancelar.TabIndex = 4;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // NumPorcentaje
            // 
            this.NumPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.NumPorcentaje.Location = new System.Drawing.Point(12, 62);
            this.NumPorcentaje.Name = "NumPorcentaje";
            this.NumPorcentaje.Size = new System.Drawing.Size(68, 29);
            this.NumPorcentaje.TabIndex = 1;
            // 
            // TxtTermino
            // 
            this.TxtTermino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTermino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtTermino.Location = new System.Drawing.Point(114, 63);
            this.TxtTermino.MaxLength = 30;
            this.TxtTermino.Multiline = true;
            this.TxtTermino.Name = "TxtTermino";
            this.TxtTermino.Size = new System.Drawing.Size(340, 29);
            this.TxtTermino.TabIndex = 2;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Location = new System.Drawing.Point(12, 41);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(277, 13);
            this.LblDescripcion.TabIndex = 12;
            this.LblDescripcion.Text = "Agregue el porcentaje y el concepto del término de pago.";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(466, 30);
            this.LblTitulo.TabIndex = 19;
            this.LblTitulo.Text = "AGREGAR TERMINO DE PAGO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmAgregarTermino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 172);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblInformacion);
            this.Controls.Add(this.LblProcentaje);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.NumPorcentaje);
            this.Controls.Add(this.TxtTermino);
            this.Controls.Add(this.LblDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarTermino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarTermino";
            ((System.ComponentModel.ISupportInitialize)(this.NumPorcentaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblInformacion;
        private System.Windows.Forms.Label LblProcentaje;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.NumericUpDown NumPorcentaje;
        private System.Windows.Forms.TextBox TxtTermino;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Label LblTitulo;

    }
}
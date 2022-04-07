namespace CB
{
    partial class FrmEscanearPlano
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
            this.TxtScaner = new System.Windows.Forms.TextBox();
            this.LblNumeroPlano = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.RButtonIDPlano = new System.Windows.Forms.RadioButton();
            this.RButtonNombrePlano = new System.Windows.Forms.RadioButton();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtScaner
            // 
            this.TxtScaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtScaner.Location = new System.Drawing.Point(12, 37);
            this.TxtScaner.Name = "TxtScaner";
            this.TxtScaner.Size = new System.Drawing.Size(326, 29);
            this.TxtScaner.TabIndex = 16;
            this.TxtScaner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtScaner_KeyDown);
            // 
            // LblNumeroPlano
            // 
            this.LblNumeroPlano.BackColor = System.Drawing.Color.Black;
            this.LblNumeroPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroPlano.ForeColor = System.Drawing.Color.White;
            this.LblNumeroPlano.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroPlano.Name = "LblNumeroPlano";
            this.LblNumeroPlano.Size = new System.Drawing.Size(350, 23);
            this.LblNumeroPlano.TabIndex = 15;
            this.LblNumeroPlano.Text = "BUSCAR PLANO";
            this.LblNumeroPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNumeroPlano.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblNumeroPlano_MouseDown);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(12, 118);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(147, 40);
            this.BtnCancelar.TabIndex = 17;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // RButtonIDPlano
            // 
            this.RButtonIDPlano.AutoSize = true;
            this.RButtonIDPlano.Location = new System.Drawing.Point(78, 83);
            this.RButtonIDPlano.Name = "RButtonIDPlano";
            this.RButtonIDPlano.Size = new System.Drawing.Size(36, 17);
            this.RButtonIDPlano.TabIndex = 18;
            this.RButtonIDPlano.TabStop = true;
            this.RButtonIDPlano.Text = "ID";
            this.RButtonIDPlano.UseVisualStyleBackColor = true;
            // 
            // RButtonNombrePlano
            // 
            this.RButtonNombrePlano.AutoSize = true;
            this.RButtonNombrePlano.Location = new System.Drawing.Point(191, 83);
            this.RButtonNombrePlano.Name = "RButtonNombrePlano";
            this.RButtonNombrePlano.Size = new System.Drawing.Size(109, 17);
            this.RButtonNombrePlano.TabIndex = 19;
            this.RButtonNombrePlano.TabStop = true;
            this.RButtonNombrePlano.Text = "Número de plano ";
            this.RButtonNombrePlano.UseVisualStyleBackColor = true;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Location = new System.Drawing.Point(191, 118);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(147, 40);
            this.BtnBuscar.TabIndex = 21;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // FrmEscanearPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 174);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.RButtonNombrePlano);
            this.Controls.Add(this.RButtonIDPlano);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TxtScaner);
            this.Controls.Add(this.LblNumeroPlano);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEscanearPlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEscanearPlano";
            this.Load += new System.EventHandler(this.FrmEscanearPlano_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEscanearPlano_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtScaner;
        private System.Windows.Forms.Label LblNumeroPlano;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.RadioButton RButtonIDPlano;
        private System.Windows.Forms.RadioButton RButtonNombrePlano;
        private System.Windows.Forms.Button BtnBuscar;
    }
}
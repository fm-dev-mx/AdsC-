namespace CB
{
    partial class FrmNuevoRol
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
            this.LblNumeroPlano = new System.Windows.Forms.Label();
            this.TxtRol = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblNumeroPlano
            // 
            this.LblNumeroPlano.BackColor = System.Drawing.Color.Black;
            this.LblNumeroPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroPlano.ForeColor = System.Drawing.Color.White;
            this.LblNumeroPlano.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroPlano.Name = "LblNumeroPlano";
            this.LblNumeroPlano.Size = new System.Drawing.Size(337, 23);
            this.LblNumeroPlano.TabIndex = 10;
            this.LblNumeroPlano.Text = "NUEVO ROL";
            this.LblNumeroPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtRol
            // 
            this.TxtRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRol.Location = new System.Drawing.Point(13, 45);
            this.TxtRol.Name = "TxtRol";
            this.TxtRol.Size = new System.Drawing.Size(310, 29);
            this.TxtRol.TabIndex = 11;
            this.TxtRol.TextChanged += new System.EventHandler(this.TxtRol_TextChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(12, 89);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(150, 40);
            this.BtnCancelar.TabIndex = 14;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnCrear
            // 
            this.BtnCrear.Enabled = false;
            this.BtnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrear.Location = new System.Drawing.Point(173, 89);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(150, 40);
            this.BtnCrear.TabIndex = 13;
            this.BtnCrear.Text = "Crear";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // FrmNuevoRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 144);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnCrear);
            this.Controls.Add(this.TxtRol);
            this.Controls.Add(this.LblNumeroPlano);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevoRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblNumeroPlano;
        private System.Windows.Forms.TextBox TxtRol;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnCrear;
    }
}
namespace CB
{
    partial class FrmRechazarMaterial
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRechazar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(379, 25);
            this.LblTitulo.TabIndex = 31;
            this.LblTitulo.Text = "RECHAZAR MATERIAL";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtComentarios.Location = new System.Drawing.Point(0, 44);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(379, 218);
            this.TxtComentarios.TabIndex = 32;
            this.TxtComentarios.TextChanged += new System.EventHandler(this.TxtComentarios_TextChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(0, 262);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(189, 62);
            this.BtnCancelar.TabIndex = 34;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRechazar
            // 
            this.BtnRechazar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnRechazar.Enabled = false;
            this.BtnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRechazar.Location = new System.Drawing.Point(187, 262);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(192, 62);
            this.BtnRechazar.TabIndex = 33;
            this.BtnRechazar.Text = "Rechazar";
            this.BtnRechazar.UseVisualStyleBackColor = true;
            this.BtnRechazar.Click += new System.EventHandler(this.BtnRechazar_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 19);
            this.label1.TabIndex = 35;
            this.label1.Text = "Notas para el requisitor:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmRechazarMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 324);
            this.Controls.Add(this.BtnRechazar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TxtComentarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRechazarMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRechazarMaterial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRechazar;
        private System.Windows.Forms.Label label1;
    }
}
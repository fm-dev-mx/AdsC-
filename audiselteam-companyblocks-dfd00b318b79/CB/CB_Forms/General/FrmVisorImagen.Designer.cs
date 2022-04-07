namespace CB
{
    partial class FrmVisorImagen
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
            this.PicImagen = new System.Windows.Forms.PictureBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PicImagen)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicImagen
            // 
            this.PicImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicImagen.Location = new System.Drawing.Point(0, 0);
            this.PicImagen.Name = "PicImagen";
            this.PicImagen.Size = new System.Drawing.Size(617, 417);
            this.PicImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicImagen.TabIndex = 0;
            this.PicImagen.TabStop = false;
            this.PicImagen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicImagen_MouseDown);
            this.PicImagen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicImagen_MouseMove);
            this.PicImagen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicImagen_MouseUp);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(617, 23);
            this.LblTitulo.TabIndex = 113;
            this.LblTitulo.Text = "VISOR DE IMAGEN";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PicImagen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 417);
            this.panel1.TabIndex = 114;
            // 
            // FrmVisorImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 440);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmVisorImagen";
            this.Load += new System.EventHandler(this.FrmVisorImagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicImagen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicImagen;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
    }
}
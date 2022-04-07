namespace CB
{
    partial class FrmSinConexion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSinConexion));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblSinConexion = new System.Windows.Forms.Label();
            this.LblDetalles = new System.Windows.Forms.Label();
            this.BtnReintentar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.Segundero = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LblSinConexion
            // 
            this.LblSinConexion.AutoSize = true;
            this.LblSinConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSinConexion.ForeColor = System.Drawing.Color.Red;
            this.LblSinConexion.Location = new System.Drawing.Point(158, 23);
            this.LblSinConexion.Name = "LblSinConexion";
            this.LblSinConexion.Size = new System.Drawing.Size(133, 24);
            this.LblSinConexion.TabIndex = 1;
            this.LblSinConexion.Text = "Sin conexión";
            // 
            // LblDetalles
            // 
            this.LblDetalles.Location = new System.Drawing.Point(159, 59);
            this.LblDetalles.Name = "LblDetalles";
            this.LblDetalles.Size = new System.Drawing.Size(259, 74);
            this.LblDetalles.TabIndex = 2;
            this.LblDetalles.Text = "No ha sido posible conectarse con la base de datos,";
            // 
            // BtnReintentar
            // 
            this.BtnReintentar.Location = new System.Drawing.Point(159, 136);
            this.BtnReintentar.Name = "BtnReintentar";
            this.BtnReintentar.Size = new System.Drawing.Size(126, 23);
            this.BtnReintentar.TabIndex = 3;
            this.BtnReintentar.Text = "Reintentar ahora";
            this.BtnReintentar.UseVisualStyleBackColor = true;
            this.BtnReintentar.Click += new System.EventHandler(this.BtnReintentar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(292, 136);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(126, 23);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // Segundero
            // 
            this.Segundero.Enabled = true;
            this.Segundero.Interval = 1000;
            this.Segundero.Tick += new System.EventHandler(this.Segundero_Tick);
            // 
            // FrmSinConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 177);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnReintentar);
            this.Controls.Add(this.LblDetalles);
            this.Controls.Add(this.LblSinConexion);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSinConexion";
            this.Text = "FrmSinConexion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblSinConexion;
        private System.Windows.Forms.Label LblDetalles;
        private System.Windows.Forms.Button BtnReintentar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Timer Segundero;
    }
}
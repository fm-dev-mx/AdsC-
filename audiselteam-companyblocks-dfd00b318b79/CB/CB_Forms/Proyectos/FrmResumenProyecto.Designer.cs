namespace CB
{
    partial class FrmResumenProyecto
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
            this.FondoProyecto = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // FondoProyecto
            // 
            this.FondoProyecto.BackColor = System.Drawing.Color.Black;
            this.FondoProyecto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FondoProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FondoProyecto.ForeColor = System.Drawing.Color.White;
            this.FondoProyecto.Location = new System.Drawing.Point(0, 0);
            this.FondoProyecto.Name = "FondoProyecto";
            this.FondoProyecto.Size = new System.Drawing.Size(654, 379);
            this.FondoProyecto.TabIndex = 1;
            this.FondoProyecto.TabStop = false;
            this.FondoProyecto.Text = "RXXX.XX - NOMBRE DEL PROYECTO";
            // 
            // FrmResumenProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(654, 379);
            this.Controls.Add(this.FondoProyecto);
            this.DoubleBuffered = true;
            this.Name = "FrmResumenProyecto";
            this.Text = "Resumen";
            this.Load += new System.EventHandler(this.FrmResumenProyecto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FondoProyecto;
    }
}
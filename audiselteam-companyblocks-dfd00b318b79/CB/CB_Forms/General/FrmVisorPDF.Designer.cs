namespace CB
{
    partial class FrmVisorPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisorPDF));
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 62);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(736, 370);
            this.VisorPDF.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 62);
            this.panel1.TabIndex = 3;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.Image = global::CB_Base.Properties.Resources.pdf_48;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(597, 0);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(139, 62);
            this.BtnImprimir.TabIndex = 59;
            this.BtnImprimir.Text = "      Abrir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // FrmVisorPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 432);
            this.Controls.Add(this.VisorPDF);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmVisorPDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor PDF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVisorPDF_FormClosing);
            this.Load += new System.EventHandler(this.FrmVisorPDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnImprimir;
    }
}
namespace CB_Base.CB_Controles
{
    partial class AudiselNotification
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudiselNotification));
            this.LblFecha = new System.Windows.Forms.Label();
            this.LblContenido = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblFecha
            // 
            this.LblFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblFecha.Location = new System.Drawing.Point(0, 0);
            this.LblFecha.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(339, 20);
            this.LblFecha.TabIndex = 1;
            this.LblFecha.Text = "jun 01, 2019";
            // 
            // LblContenido
            // 
            this.LblContenido.AutoEllipsis = true;
            this.LblContenido.BackColor = System.Drawing.SystemColors.Control;
            this.LblContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblContenido.Location = new System.Drawing.Point(0, 20);
            this.LblContenido.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.LblContenido.Name = "LblContenido";
            this.LblContenido.Size = new System.Drawing.Size(339, 78);
            this.LblContenido.TabIndex = 2;
            this.LblContenido.Text = resources.GetString("LblContenido.Text");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnCerrar);
            this.panel1.Controls.Add(this.LblContenido);
            this.panel1.Controls.Add(this.LblFecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 100);
            this.panel1.TabIndex = 3;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Location = new System.Drawing.Point(309, -1);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(31, 21);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.Text = "[X]";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // AudiselNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AudiselNotification";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.Size = new System.Drawing.Size(361, 110);
            this.Load += new System.EventHandler(this.AudiselNotification_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label LblContenido;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCerrar;
    }
}

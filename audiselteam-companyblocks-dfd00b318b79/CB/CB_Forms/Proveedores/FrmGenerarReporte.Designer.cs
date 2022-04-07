namespace CB
{
    partial class FrmGenerarReporte
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
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.lblReporte = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BkgGenerarReporte = new System.ComponentModel.BackgroundWorker();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.SuspendLayout();
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Top;
            this.Progreso.Location = new System.Drawing.Point(0, 39);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(368, 23);
            this.Progreso.TabIndex = 0;
            // 
            // lblReporte
            // 
            this.lblReporte.AutoSize = true;
            this.lblReporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporte.Location = new System.Drawing.Point(0, 23);
            this.lblReporte.Name = "lblReporte";
            this.lblReporte.Size = new System.Drawing.Size(177, 16);
            this.lblReporte.TabIndex = 1;
            this.lblReporte.Text = "Generando reporte espere...";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(237, 71);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(129, 36);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BkgGenerarReporte
            // 
            this.BkgGenerarReporte.WorkerReportsProgress = true;
            this.BkgGenerarReporte.WorkerSupportsCancellation = true;
            this.BkgGenerarReporte.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgGenerarReporte_DoWork);
            this.BkgGenerarReporte.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgGenerarReporte_ProgressChanged);
            this.BkgGenerarReporte.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgGenerarReporte_RunWorkerCompleted);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(368, 23);
            this.audiselTituloForm1.TabIndex = 4;
            this.audiselTituloForm1.Text = "GENERANDO REPORTE";
            // 
            // FrmGenerarReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 110);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.lblReporte);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGenerarReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar reporte";
            this.Load += new System.EventHandler(this.FrmGenerarReporte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.Button BtnCancelar;
        private System.ComponentModel.BackgroundWorker BkgGenerarReporte;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
    }
}
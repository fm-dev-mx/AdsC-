namespace CB
{
    partial class FrmBajarArchivos
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
            this.LblProgreso = new System.Windows.Forms.Label();
            this.LblArchivoActual = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BkgBajarDiseno = new System.ComponentModel.BackgroundWorker();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(12, 93);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(433, 23);
            this.Progreso.TabIndex = 0;
            // 
            // LblProgreso
            // 
            this.LblProgreso.AutoSize = true;
            this.LblProgreso.Location = new System.Drawing.Point(9, 26);
            this.LblProgreso.Name = "LblProgreso";
            this.LblProgreso.Size = new System.Drawing.Size(122, 13);
            this.LblProgreso.TabIndex = 1;
            this.LblProgreso.Text = "Bajando archivos... [X%]";
            // 
            // LblArchivoActual
            // 
            this.LblArchivoActual.Location = new System.Drawing.Point(12, 64);
            this.LblArchivoActual.Name = "LblArchivoActual";
            this.LblArchivoActual.Size = new System.Drawing.Size(433, 27);
            this.LblArchivoActual.TabIndex = 2;
            this.LblArchivoActual.Text = "Descargando: ";
            this.LblArchivoActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Archivo actual:";
            // 
            // BkgBajarDiseno
            // 
            this.BkgBajarDiseno.WorkerReportsProgress = true;
            this.BkgBajarDiseno.WorkerSupportsCancellation = true;
            this.BkgBajarDiseno.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgBajarDiseno_DoWork);
            this.BkgBajarDiseno.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgBajar_ProgressChanged);
            this.BkgBajarDiseno.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgBajar_RunWorkerCompleted);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(457, 23);
            this.audiselTituloForm1.TabIndex = 6;
            this.audiselTituloForm1.Text = "DESCARGAR ARCHIVO";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(345, 126);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(100, 26);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click_1);
            // 
            // FrmBajarArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 164);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.audiselTituloForm1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblArchivoActual);
            this.Controls.Add(this.LblProgreso);
            this.Controls.Add(this.Progreso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmBajarArchivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bajando diseño mecánico...";
            this.Load += new System.EventHandler(this.FrmBajarDiseno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.Label LblProgreso;
        private System.Windows.Forms.Label LblArchivoActual;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker BkgBajarDiseno;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Button BtnCancelar;
    }
}
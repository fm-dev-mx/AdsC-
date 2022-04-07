namespace CB
{
    partial class FrmBajarDiseno
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BkgBajarDiseno = new System.ComponentModel.BackgroundWorker();
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
            this.LblProgreso.Location = new System.Drawing.Point(12, 19);
            this.LblProgreso.Name = "LblProgreso";
            this.LblProgreso.Size = new System.Drawing.Size(162, 13);
            this.LblProgreso.TabIndex = 1;
            this.LblProgreso.Text = "Bajando diseño mecánico... [X%]";
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
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(345, 126);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(100, 26);
            this.BtnCancelar.TabIndex = 4;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
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
            // FrmBajarDiseno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 163);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LblArchivoActual);
            this.Controls.Add(this.LblProgreso);
            this.Controls.Add(this.Progreso);
            this.MaximizeBox = false;
            this.Name = "FrmBajarDiseno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bajando diseño mecánico...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBajarDiseno_FormClosing);
            this.Load += new System.EventHandler(this.FrmBajarDiseno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.Label LblProgreso;
        private System.Windows.Forms.Label LblArchivoActual;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker BkgBajarDiseno;
    }
}
namespace CB
{
    partial class FrmDescargarArchivos
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblArchivoActual = new System.Windows.Forms.Label();
            this.LblProgreso = new System.Windows.Forms.Label();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.BkgDescarga = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Archivo actual:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(345, 121);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(100, 26);
            this.BtnCancelar.TabIndex = 9;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // LblArchivoActual
            // 
            this.LblArchivoActual.Location = new System.Drawing.Point(12, 58);
            this.LblArchivoActual.Name = "LblArchivoActual";
            this.LblArchivoActual.Size = new System.Drawing.Size(433, 27);
            this.LblArchivoActual.TabIndex = 8;
            this.LblArchivoActual.Text = "Descargando: ";
            this.LblArchivoActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblProgreso
            // 
            this.LblProgreso.AutoSize = true;
            this.LblProgreso.Location = new System.Drawing.Point(9, 14);
            this.LblProgreso.Name = "LblProgreso";
            this.LblProgreso.Size = new System.Drawing.Size(162, 13);
            this.LblProgreso.TabIndex = 7;
            this.LblProgreso.Text = "Bajando diseño mecánico... [X%]";
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(12, 88);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(433, 23);
            this.Progreso.TabIndex = 6;
            // 
            // BkgDescarga
            // 
            this.BkgDescarga.WorkerReportsProgress = true;
            this.BkgDescarga.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescarga_DoWork);
            this.BkgDescarga.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescarga_ProgressChanged);
            this.BkgDescarga.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescarga_RunWorkerCompleted);
            // 
            // FrmDescargarArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 158);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LblArchivoActual);
            this.Controls.Add(this.LblProgreso);
            this.Controls.Add(this.Progreso);
            this.Name = "FrmDescargarArchivos";
            this.Text = "Descargando archivos...";
            this.Load += new System.EventHandler(this.FrmDescargarArchivos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblArchivoActual;
        private System.Windows.Forms.Label LblProgreso;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.ComponentModel.BackgroundWorker BkgDescarga;
    }
}
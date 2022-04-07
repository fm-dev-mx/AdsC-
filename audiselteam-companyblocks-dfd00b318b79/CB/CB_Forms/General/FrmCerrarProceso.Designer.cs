namespace CB
{
    partial class FrmCerrarProceso
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
            this.TxtMensaje = new System.Windows.Forms.TextBox();
            this.BtnContinuar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.LblProgreso = new System.Windows.Forms.Label();
            this.BkgCerrarProcesos = new System.ComponentModel.BackgroundWorker();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.SuspendLayout();
            // 
            // TxtMensaje
            // 
            this.TxtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMensaje.Location = new System.Drawing.Point(5, 29);
            this.TxtMensaje.Multiline = true;
            this.TxtMensaje.Name = "TxtMensaje";
            this.TxtMensaje.ReadOnly = true;
            this.TxtMensaje.Size = new System.Drawing.Size(422, 35);
            this.TxtMensaje.TabIndex = 1;
            this.TxtMensaje.Text = "Se encontró una instancia del programa abierto para continuar guarde sus cambios " +
    "y de click en continuar .";
            // 
            // BtnContinuar
            // 
            this.BtnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnContinuar.Image = global::CB_Base.Properties.Resources.ok_48;
            this.BtnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnContinuar.Location = new System.Drawing.Point(231, 125);
            this.BtnContinuar.Name = "BtnContinuar";
            this.BtnContinuar.Size = new System.Drawing.Size(196, 60);
            this.BtnContinuar.TabIndex = 2;
            this.BtnContinuar.Text = "Continuar";
            this.BtnContinuar.UseVisualStyleBackColor = true;
            this.BtnContinuar.Click += new System.EventHandler(this.BtnContinuar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(5, 125);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(196, 60);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(5, 93);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(422, 21);
            this.Progreso.TabIndex = 4;
            // 
            // LblProgreso
            // 
            this.LblProgreso.AutoSize = true;
            this.LblProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProgreso.Location = new System.Drawing.Point(2, 77);
            this.LblProgreso.Name = "LblProgreso";
            this.LblProgreso.Size = new System.Drawing.Size(114, 15);
            this.LblProgreso.TabIndex = 5;
            this.LblProgreso.Text = "Cerrando proceso...";
            // 
            // BkgCerrarProcesos
            // 
            this.BkgCerrarProcesos.WorkerReportsProgress = true;
            this.BkgCerrarProcesos.WorkerSupportsCancellation = true;
            this.BkgCerrarProcesos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgCerrarProcesos_DoWork);
            this.BkgCerrarProcesos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgCerrarProcesos_ProgressChanged);
            this.BkgCerrarProcesos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgCerrarProcesos_RunWorkerCompleted);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(432, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "CERRANDO PROCESOS";
            // 
            // FrmCerrarProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 197);
            this.Controls.Add(this.LblProgreso);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnContinuar);
            this.Controls.Add(this.TxtMensaje);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCerrarProceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCerrarProceso";
            this.Load += new System.EventHandler(this.FrmCerrarProceso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.TextBox TxtMensaje;
        private System.Windows.Forms.Button BtnContinuar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.Label LblProgreso;
        private System.ComponentModel.BackgroundWorker BkgCerrarProcesos;
    }
}
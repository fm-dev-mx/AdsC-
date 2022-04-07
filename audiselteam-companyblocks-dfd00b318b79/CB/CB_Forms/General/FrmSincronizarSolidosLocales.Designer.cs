namespace CB
{
    partial class FrmSincronizarSolidosLocales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvSincronizacion = new System.Windows.Forms.DataGridView();
            this.archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.BkgDescargarIndice = new System.ComponentModel.BackgroundWorker();
            this.BkgAnalizarArchivos = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarArchivos = new System.ComponentModel.BackgroundWorker();
            this.LblTituloPlano = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSincronizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvSincronizacion
            // 
            this.DgvSincronizacion.AllowUserToAddRows = false;
            this.DgvSincronizacion.AllowUserToDeleteRows = false;
            this.DgvSincronizacion.AllowUserToResizeColumns = false;
            this.DgvSincronizacion.AllowUserToResizeRows = false;
            this.DgvSincronizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSincronizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.archivo,
            this.estatus});
            this.DgvSincronizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSincronizacion.Location = new System.Drawing.Point(0, 23);
            this.DgvSincronizacion.Name = "DgvSincronizacion";
            this.DgvSincronizacion.RowHeadersVisible = false;
            this.DgvSincronizacion.Size = new System.Drawing.Size(716, 243);
            this.DgvSincronizacion.TabIndex = 0;
            // 
            // archivo
            // 
            this.archivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.archivo.HeaderText = "Archivo";
            this.archivo.Name = "archivo";
            // 
            // estatus
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.Width = 150;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 325);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(716, 23);
            this.Progreso.TabIndex = 1;
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEstatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 266);
            this.TxtEstatus.Multiline = true;
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(716, 59);
            this.TxtEstatus.TabIndex = 7;
            // 
            // BkgDescargarIndice
            // 
            this.BkgDescargarIndice.WorkerReportsProgress = true;
            this.BkgDescargarIndice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarIndice_DoWork);
            this.BkgDescargarIndice.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarIndice_ProgressChanged);
            this.BkgDescargarIndice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarIndice_RunWorkerCompleted);
            // 
            // BkgAnalizarArchivos
            // 
            this.BkgAnalizarArchivos.WorkerReportsProgress = true;
            this.BkgAnalizarArchivos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgAnalizarArchivos_DoWork);
            this.BkgAnalizarArchivos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgAnalizarArchivos_ProgressChanged);
            this.BkgAnalizarArchivos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgAnalizarArchivos_RunWorkerCompleted);
            // 
            // BkgDescargarArchivos
            // 
            this.BkgDescargarArchivos.WorkerReportsProgress = true;
            this.BkgDescargarArchivos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarArchivos_DoWork);
            this.BkgDescargarArchivos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarArchivos_ProgressChanged);
            this.BkgDescargarArchivos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarArchivos_RunWorkerCompleted);
            // 
            // LblTituloPlano
            // 
            this.LblTituloPlano.BackColor = System.Drawing.Color.Black;
            this.LblTituloPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTituloPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloPlano.ForeColor = System.Drawing.Color.White;
            this.LblTituloPlano.Location = new System.Drawing.Point(0, 0);
            this.LblTituloPlano.Name = "LblTituloPlano";
            this.LblTituloPlano.Size = new System.Drawing.Size(716, 23);
            this.LblTituloPlano.TabIndex = 8;
            this.LblTituloPlano.Text = "SINCRONIZANDO SOLIDOS LOCALES...";
            this.LblTituloPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSincronizarSolidosLocales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 348);
            this.Controls.Add(this.DgvSincronizacion);
            this.Controls.Add(this.TxtEstatus);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.LblTituloPlano);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSincronizarSolidosLocales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronizando solidos locales";
            this.Load += new System.EventHandler(this.FrmSincronizarArchivosFabricacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSincronizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvSincronizacion;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.ComponentModel.BackgroundWorker BkgDescargarIndice;
        private System.ComponentModel.BackgroundWorker BkgAnalizarArchivos;
        private System.ComponentModel.BackgroundWorker BkgDescargarArchivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn archivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.Label LblTituloPlano;
    }
}
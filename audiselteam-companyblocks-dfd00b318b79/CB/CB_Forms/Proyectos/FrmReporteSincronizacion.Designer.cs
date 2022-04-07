namespace CB
{
    partial class FrmReporteSincronizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteSincronizacion));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CkbIncluir = new System.Windows.Forms.CheckBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.DtpHasta = new System.Windows.Forms.DateTimePicker();
            this.DtpDesde = new System.Windows.Forms.DateTimePicker();
            this.CmbEstatus = new System.Windows.Forms.ComboBox();
            this.LblEstatusBkg = new System.Windows.Forms.Label();
            this.ProgresoDescarga = new System.Windows.Forms.ProgressBar();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BkgCargarPdf = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 23);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.CkbIncluir);
            this.splitContainer2.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.LblEstatus);
            this.splitContainer2.Panel1.Controls.Add(this.BtnGuardar);
            this.splitContainer2.Panel1.Controls.Add(this.DtpHasta);
            this.splitContainer2.Panel1.Controls.Add(this.DtpDesde);
            this.splitContainer2.Panel1.Controls.Add(this.CmbEstatus);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LblEstatusBkg);
            this.splitContainer2.Panel2.Controls.Add(this.ProgresoDescarga);
            this.splitContainer2.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer2.Size = new System.Drawing.Size(936, 509);
            this.splitContainer2.SplitterDistance = 325;
            this.splitContainer2.TabIndex = 1;
            // 
            // CkbIncluir
            // 
            this.CkbIncluir.AutoSize = true;
            this.CkbIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CkbIncluir.Location = new System.Drawing.Point(15, 206);
            this.CkbIncluir.Name = "CkbIncluir";
            this.CkbIncluir.Size = new System.Drawing.Size(185, 22);
            this.CkbIncluir.TabIndex = 54;
            this.CkbIncluir.Text = "Incluir subensambles";
            this.CkbIncluir.UseVisualStyleBackColor = true;
            this.CkbIncluir.CheckedChanged += new System.EventHandler(this.CkbIncluir_CheckedChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(168, 249);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(144, 58);
            this.BtnSalir.TabIndex = 53;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Desde:";
            // 
            // LblEstatus
            // 
            this.LblEstatus.AutoSize = true;
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.Location = new System.Drawing.Point(12, 11);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(55, 16);
            this.LblEstatus.TabIndex = 3;
            this.LblEstatus.Text = "Estatus:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnGuardar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(15, 249);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(144, 58);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "    Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // DtpHasta
            // 
            this.DtpHasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpHasta.Location = new System.Drawing.Point(15, 152);
            this.DtpHasta.Name = "DtpHasta";
            this.DtpHasta.Size = new System.Drawing.Size(297, 26);
            this.DtpHasta.TabIndex = 4;
            this.DtpHasta.ValueChanged += new System.EventHandler(this.DtpHasta_ValueChanged);
            // 
            // DtpDesde
            // 
            this.DtpDesde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDesde.Location = new System.Drawing.Point(15, 90);
            this.DtpDesde.Name = "DtpDesde";
            this.DtpDesde.Size = new System.Drawing.Size(297, 26);
            this.DtpDesde.TabIndex = 3;
            this.DtpDesde.ValueChanged += new System.EventHandler(this.DtpDesde_ValueChanged);
            // 
            // CmbEstatus
            // 
            this.CmbEstatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatus.FormattingEnabled = true;
            this.CmbEstatus.Items.AddRange(new object[] {
            "TODOS",
            "DETENIDO",
            "EN PROCESO",
            "PENDIENTE",
            "TERMINADO"});
            this.CmbEstatus.Location = new System.Drawing.Point(15, 30);
            this.CmbEstatus.Name = "CmbEstatus";
            this.CmbEstatus.Size = new System.Drawing.Size(297, 28);
            this.CmbEstatus.TabIndex = 3;
            this.CmbEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbEstatus_SelectedIndexChanged);
            // 
            // LblEstatusBkg
            // 
            this.LblEstatusBkg.BackColor = System.Drawing.Color.Black;
            this.LblEstatusBkg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusBkg.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusBkg.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusBkg.Location = new System.Drawing.Point(0, 457);
            this.LblEstatusBkg.Name = "LblEstatusBkg";
            this.LblEstatusBkg.Size = new System.Drawing.Size(607, 29);
            this.LblEstatusBkg.TabIndex = 4;
            this.LblEstatusBkg.Text = "Estatus...";
            this.LblEstatusBkg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoDescarga
            // 
            this.ProgresoDescarga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoDescarga.Location = new System.Drawing.Point(0, 486);
            this.ProgresoDescarga.Name = "ProgresoDescarga";
            this.ProgresoDescarga.Size = new System.Drawing.Size(607, 23);
            this.ProgresoDescarga.TabIndex = 3;
            // 
            // VisorPDF
            // 
            this.VisorPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(607, 486);
            this.VisorPDF.TabIndex = 2;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(936, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "REPORTE DE SINCRONIZACION ";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BkgCargarPdf
            // 
            this.BkgCargarPdf.WorkerReportsProgress = true;
            this.BkgCargarPdf.WorkerSupportsCancellation = true;
            this.BkgCargarPdf.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgCargarPdf_DoWork);
            this.BkgCargarPdf.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgCargarPdf_ProgressChanged);
            this.BkgCargarPdf.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgCargarPdf_RunWorkerCompleted);
            // 
            // FrmReporteSincronizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 532);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmReporteSincronizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de sincronización";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReporteSincronizacion_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.DateTimePicker DtpHasta;
        private System.Windows.Forms.DateTimePicker DtpDesde;
        private System.Windows.Forms.ComboBox CmbEstatus;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.CheckBox CkbIncluir;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblEstatusBkg;
        private System.Windows.Forms.ProgressBar ProgresoDescarga;
        private System.ComponentModel.BackgroundWorker BkgCargarPdf;

    }
}
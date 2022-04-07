namespace CB
{
    partial class FrmValeSalidaCalidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmValeSalidaCalidad));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnEntregar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.CmbUsuarios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BkgGuardarVale = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnEntregar);
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer1.Panel1.Controls.Add(this.CmbUsuarios);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer1.Panel2.Controls.Add(this.TxtEstatus);
            this.splitContainer1.Panel2.Controls.Add(this.Progreso);
            this.splitContainer1.Size = new System.Drawing.Size(933, 556);
            this.splitContainer1.SplitterDistance = 68;
            this.splitContainer1.TabIndex = 38;
            // 
            // BtnEntregar
            // 
            this.BtnEntregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEntregar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnEntregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEntregar.Location = new System.Drawing.Point(631, 0);
            this.BtnEntregar.Name = "BtnEntregar";
            this.BtnEntregar.Size = new System.Drawing.Size(151, 68);
            this.BtnEntregar.TabIndex = 53;
            this.BtnEntregar.Text = "Entregar";
            this.BtnEntregar.UseVisualStyleBackColor = true;
            this.BtnEntregar.Click += new System.EventHandler(this.BtnEntregar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(782, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(151, 68);
            this.BtnSalir.TabIndex = 52;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // CmbUsuarios
            // 
            this.CmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUsuarios.FormattingEnabled = true;
            this.CmbUsuarios.Location = new System.Drawing.Point(12, 26);
            this.CmbUsuarios.Name = "CmbUsuarios";
            this.CmbUsuarios.Size = new System.Drawing.Size(294, 28);
            this.CmbUsuarios.TabIndex = 51;
            this.CmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.CmbUsuarios_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Recibe:";
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(933, 432);
            this.VisorPDF.TabIndex = 2;
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtEstatus.ForeColor = System.Drawing.Color.Lime;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 432);
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(933, 29);
            this.TxtEstatus.TabIndex = 63;
            this.TxtEstatus.Text = "Estatus...";
            this.TxtEstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 461);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(933, 23);
            this.Progreso.TabIndex = 64;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(933, 23);
            this.LblTitulo.TabIndex = 37;
            this.LblTitulo.Text = "ENTREGAR PIEZAS ";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BkgGuardarVale
            // 
            this.BkgGuardarVale.WorkerReportsProgress = true;
            this.BkgGuardarVale.WorkerSupportsCancellation = true;
            this.BkgGuardarVale.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgGuardarVale_DoWork);
            this.BkgGuardarVale.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgGuardarVale_ProgressChanged);
            this.BkgGuardarVale.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgGuardarVale_RunWorkerCompleted);
            // 
            // FrmValeSalidaCalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 579);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmValeSalidaCalidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmEntregarPiezasFabricacion_MouseDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BtnEntregar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ComboBox CmbUsuarios;
        private System.Windows.Forms.Label label2;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.ComponentModel.BackgroundWorker BkgGuardarVale;

    }
}
namespace CB
{
    partial class FrmDisenoMecanico
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisenoMecanico));
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TvDiseno = new System.Windows.Forms.TreeView();
            this.ImagenesNodosDiseno = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.MenuLiberar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LblEstatusProyecto = new System.Windows.Forms.Label();
            this.BkgDescargarDiseno = new System.ComponentModel.BackgroundWorker();
            this.BuscadorArchivo = new System.Windows.Forms.OpenFileDialog();
            this.BkgInicializarDiseno = new System.ComponentModel.BackgroundWorker();
            this.SplitEstatusDiseno = new System.Windows.Forms.SplitContainer();
            this.TxtEstatusDiseno = new System.Windows.Forms.TextBox();
            this.ProgresoDiseno = new System.Windows.Forms.ProgressBar();
            this.BuscadorCarpetas = new System.Windows.Forms.FolderBrowserDialog();
            this.MenuDiseno = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BtnLiberar = new System.Windows.Forms.Button();
            this.PicEstatusProyecto = new System.Windows.Forms.PictureBox();
            this.BtnBajar = new System.Windows.Forms.Button();
            this.BtnSubir = new System.Windows.Forms.Button();
            this.imprimirFormatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liberarDisenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evidenciaDeLiberacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subirSubensamblePrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuscadorSubensamblePrincipal = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.MenuLiberar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitEstatusDiseno)).BeginInit();
            this.SplitEstatusDiseno.Panel1.SuspendLayout();
            this.SplitEstatusDiseno.Panel2.SuspendLayout();
            this.SplitEstatusDiseno.SuspendLayout();
            this.MenuDiseno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicEstatusProyecto)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(878, 23);
            this.LblTitulo.TabIndex = 9;
            this.LblTitulo.Text = "DISEÑO MECANICO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TvDiseno
            // 
            this.TvDiseno.ContextMenuStrip = this.MenuDiseno;
            this.TvDiseno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvDiseno.ImageIndex = 0;
            this.TvDiseno.ImageList = this.ImagenesNodosDiseno;
            this.TvDiseno.Location = new System.Drawing.Point(0, 0);
            this.TvDiseno.Name = "TvDiseno";
            this.TvDiseno.SelectedImageIndex = 0;
            this.TvDiseno.Size = new System.Drawing.Size(878, 347);
            this.TvDiseno.TabIndex = 10;
            // 
            // ImagenesNodosDiseno
            // 
            this.ImagenesNodosDiseno.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesNodosDiseno.ImageStream")));
            this.ImagenesNodosDiseno.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesNodosDiseno.Images.SetKeyName(0, "folder_24px.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(1, "sldprt-32.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(2, "sldasm.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(3, "slddrw.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(4, "slddrw-preliminar.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(5, "slddrw-rechazado.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(6, "slddrw-aceptado.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(7, "slddrw-aceptado-aprobado.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(8, "sldprt-modificado.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(9, "sldprt-nuevo.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(10, "folder_locked.png");
            this.ImagenesNodosDiseno.Images.SetKeyName(11, "folder_ice.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnLiberar);
            this.panel1.Controls.Add(this.PicEstatusProyecto);
            this.panel1.Controls.Add(this.LblEstatusProyecto);
            this.panel1.Controls.Add(this.BtnBajar);
            this.panel1.Controls.Add(this.BtnSubir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 65);
            this.panel1.TabIndex = 11;
            // 
            // MenuLiberar
            // 
            this.MenuLiberar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirFormatoToolStripMenuItem,
            this.liberarDisenoToolStripMenuItem,
            this.evidenciaDeLiberacionToolStripMenuItem});
            this.MenuLiberar.Name = "MenuLiberar";
            this.MenuLiberar.Size = new System.Drawing.Size(196, 70);
            // 
            // LblEstatusProyecto
            // 
            this.LblEstatusProyecto.AutoSize = true;
            this.LblEstatusProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusProyecto.ForeColor = System.Drawing.Color.Black;
            this.LblEstatusProyecto.Location = new System.Drawing.Point(62, 22);
            this.LblEstatusProyecto.Name = "LblEstatusProyecto";
            this.LblEstatusProyecto.Size = new System.Drawing.Size(191, 20);
            this.LblEstatusProyecto.TabIndex = 25;
            this.LblEstatusProyecto.Text = "Info bloqueo mecanico";
            this.LblEstatusProyecto.Visible = false;
            // 
            // BkgDescargarDiseno
            // 
            this.BkgDescargarDiseno.WorkerReportsProgress = true;
            this.BkgDescargarDiseno.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarDiseno_DoWork);
            this.BkgDescargarDiseno.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarDiseno_ProgressChanged);
            this.BkgDescargarDiseno.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarDiseno_RunWorkerCompleted);
            // 
            // BuscadorArchivo
            // 
            this.BuscadorArchivo.FileName = "openFileDialog1";
            // 
            // BkgInicializarDiseno
            // 
            this.BkgInicializarDiseno.WorkerReportsProgress = true;
            this.BkgInicializarDiseno.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgInicializarDiseno_DoWork);
            this.BkgInicializarDiseno.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgInicializarDiseno_ProgressChanged);
            this.BkgInicializarDiseno.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgInicializarDiseno_RunWorkerCompleted);
            // 
            // SplitEstatusDiseno
            // 
            this.SplitEstatusDiseno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitEstatusDiseno.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitEstatusDiseno.Location = new System.Drawing.Point(0, 88);
            this.SplitEstatusDiseno.Name = "SplitEstatusDiseno";
            this.SplitEstatusDiseno.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitEstatusDiseno.Panel1
            // 
            this.SplitEstatusDiseno.Panel1.Controls.Add(this.TvDiseno);
            // 
            // SplitEstatusDiseno.Panel2
            // 
            this.SplitEstatusDiseno.Panel2.Controls.Add(this.TxtEstatusDiseno);
            this.SplitEstatusDiseno.Panel2.Controls.Add(this.ProgresoDiseno);
            this.SplitEstatusDiseno.Size = new System.Drawing.Size(878, 387);
            this.SplitEstatusDiseno.SplitterDistance = 347;
            this.SplitEstatusDiseno.TabIndex = 12;
            // 
            // TxtEstatusDiseno
            // 
            this.TxtEstatusDiseno.BackColor = System.Drawing.Color.Black;
            this.TxtEstatusDiseno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEstatusDiseno.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEstatusDiseno.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtEstatusDiseno.Location = new System.Drawing.Point(0, 0);
            this.TxtEstatusDiseno.Multiline = true;
            this.TxtEstatusDiseno.Name = "TxtEstatusDiseno";
            this.TxtEstatusDiseno.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatusDiseno.Size = new System.Drawing.Size(878, 13);
            this.TxtEstatusDiseno.TabIndex = 10;
            // 
            // ProgresoDiseno
            // 
            this.ProgresoDiseno.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoDiseno.Location = new System.Drawing.Point(0, 13);
            this.ProgresoDiseno.Name = "ProgresoDiseno";
            this.ProgresoDiseno.Size = new System.Drawing.Size(878, 23);
            this.ProgresoDiseno.TabIndex = 9;
            // 
            // MenuDiseno
            // 
            this.MenuDiseno.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subirSubensamblePrincipalToolStripMenuItem});
            this.MenuDiseno.Name = "MenuDiseno";
            this.MenuDiseno.Size = new System.Drawing.Size(224, 26);
            // 
            // BtnLiberar
            // 
            this.BtnLiberar.ContextMenuStrip = this.MenuLiberar;
            this.BtnLiberar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnLiberar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLiberar.Image = global::CB_Base.Properties.Resources.complete_48;
            this.BtnLiberar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLiberar.Location = new System.Drawing.Point(531, 0);
            this.BtnLiberar.Name = "BtnLiberar";
            this.BtnLiberar.Size = new System.Drawing.Size(115, 65);
            this.BtnLiberar.TabIndex = 28;
            this.BtnLiberar.Text = "            Liberar";
            this.BtnLiberar.UseVisualStyleBackColor = true;
            this.BtnLiberar.Click += new System.EventHandler(this.BtnLiberar_Click);
            // 
            // PicEstatusProyecto
            // 
            this.PicEstatusProyecto.Image = global::CB_Base.Properties.Resources.loading_icon_48;
            this.PicEstatusProyecto.Location = new System.Drawing.Point(8, 9);
            this.PicEstatusProyecto.Name = "PicEstatusProyecto";
            this.PicEstatusProyecto.Size = new System.Drawing.Size(48, 48);
            this.PicEstatusProyecto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicEstatusProyecto.TabIndex = 26;
            this.PicEstatusProyecto.TabStop = false;
            // 
            // BtnBajar
            // 
            this.BtnBajar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBajar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBajar.Image = global::CB_Base.Properties.Resources.download_file_48;
            this.BtnBajar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBajar.Location = new System.Drawing.Point(646, 0);
            this.BtnBajar.Name = "BtnBajar";
            this.BtnBajar.Size = new System.Drawing.Size(110, 65);
            this.BtnBajar.TabIndex = 22;
            this.BtnBajar.Text = "           Bajar";
            this.BtnBajar.UseVisualStyleBackColor = true;
            this.BtnBajar.Click += new System.EventHandler(this.BtnBajar_Click);
            // 
            // BtnSubir
            // 
            this.BtnSubir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnSubir.Image = global::CB_Base.Properties.Resources.upload_file_48;
            this.BtnSubir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubir.Location = new System.Drawing.Point(756, 0);
            this.BtnSubir.Name = "BtnSubir";
            this.BtnSubir.Size = new System.Drawing.Size(122, 65);
            this.BtnSubir.TabIndex = 27;
            this.BtnSubir.Text = "         Subir";
            this.BtnSubir.UseVisualStyleBackColor = true;
            this.BtnSubir.Click += new System.EventHandler(this.BtnSubir_Click);
            // 
            // imprimirFormatoToolStripMenuItem
            // 
            this.imprimirFormatoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.pdf_48;
            this.imprimirFormatoToolStripMenuItem.Name = "imprimirFormatoToolStripMenuItem";
            this.imprimirFormatoToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.imprimirFormatoToolStripMenuItem.Text = "Imprimir formato";
            this.imprimirFormatoToolStripMenuItem.Click += new System.EventHandler(this.imprimirFormatoToolStripMenuItem_Click);
            // 
            // liberarDisenoToolStripMenuItem
            // 
            this.liberarDisenoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.upload_file_48;
            this.liberarDisenoToolStripMenuItem.Name = "liberarDisenoToolStripMenuItem";
            this.liberarDisenoToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.liberarDisenoToolStripMenuItem.Text = "Liberar diseño";
            this.liberarDisenoToolStripMenuItem.Click += new System.EventHandler(this.liberarDisenoToolStripMenuItem_Click);
            // 
            // evidenciaDeLiberacionToolStripMenuItem
            // 
            this.evidenciaDeLiberacionToolStripMenuItem.Image = global::CB_Base.Properties.Resources.search;
            this.evidenciaDeLiberacionToolStripMenuItem.Name = "evidenciaDeLiberacionToolStripMenuItem";
            this.evidenciaDeLiberacionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.evidenciaDeLiberacionToolStripMenuItem.Text = "Evidencia de liberación";
            this.evidenciaDeLiberacionToolStripMenuItem.Click += new System.EventHandler(this.evidenciaDeLiberacionToolStripMenuItem_Click);
            // 
            // subirSubensamblePrincipalToolStripMenuItem
            // 
            this.subirSubensamblePrincipalToolStripMenuItem.Image = global::CB_Base.Properties.Resources.sldasm_48;
            this.subirSubensamblePrincipalToolStripMenuItem.Name = "subirSubensamblePrincipalToolStripMenuItem";
            this.subirSubensamblePrincipalToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.subirSubensamblePrincipalToolStripMenuItem.Text = "Subir subensamble principal";
            this.subirSubensamblePrincipalToolStripMenuItem.Click += new System.EventHandler(this.subirSubensamblePrincipalToolStripMenuItem_Click);
            // 
            // BuscadorSubensamblePrincipal
            // 
            this.BuscadorSubensamblePrincipal.Filter = "Assembly Files|*.sldasm";
            this.BuscadorSubensamblePrincipal.ReadOnlyChecked = true;
            // 
            // FrmDisenoMecanico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 475);
            this.Controls.Add(this.SplitEstatusDiseno);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDisenoMecanico";
            this.Text = "Diseño mecánico";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDisenoMecanico_FormClosing);
            this.Load += new System.EventHandler(this.FrmDisenoMecanico_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MenuLiberar.ResumeLayout(false);
            this.SplitEstatusDiseno.Panel1.ResumeLayout(false);
            this.SplitEstatusDiseno.Panel2.ResumeLayout(false);
            this.SplitEstatusDiseno.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitEstatusDiseno)).EndInit();
            this.SplitEstatusDiseno.ResumeLayout(false);
            this.MenuDiseno.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicEstatusProyecto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TreeView TvDiseno;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnBajar;
        private System.ComponentModel.BackgroundWorker BkgDescargarDiseno;
        private System.Windows.Forms.ImageList ImagenesNodosDiseno;
        private System.Windows.Forms.PictureBox PicEstatusProyecto;
        private System.Windows.Forms.Label LblEstatusProyecto;
        private System.Windows.Forms.OpenFileDialog BuscadorArchivo;
        private System.ComponentModel.BackgroundWorker BkgInicializarDiseno;
        private System.Windows.Forms.SplitContainer SplitEstatusDiseno;
        private System.Windows.Forms.TextBox TxtEstatusDiseno;
        private System.Windows.Forms.ProgressBar ProgresoDiseno;
        private System.Windows.Forms.Button BtnSubir;
        private System.Windows.Forms.FolderBrowserDialog BuscadorCarpetas;
        private System.Windows.Forms.Button BtnLiberar;
        private System.Windows.Forms.ContextMenuStrip MenuLiberar;
        private System.Windows.Forms.ToolStripMenuItem imprimirFormatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liberarDisenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evidenciaDeLiberacionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuDiseno;
        private System.Windows.Forms.ToolStripMenuItem subirSubensamblePrincipalToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog BuscadorSubensamblePrincipal;
    }
}
namespace CB
{
    partial class FrmCompararSolidWorks
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
            this.BkgDescargarArchivos = new System.ComponentModel.BackgroundWorker();
            this.BkgGenerarVistasPrevias = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PicArchivoLocal = new System.Windows.Forms.PictureBox();
            this.BtnConservarArchivoLocal = new System.Windows.Forms.Button();
            this.LblArchivoLocal = new System.Windows.Forms.Label();
            this.PicArchivoRemoto = new System.Windows.Forms.PictureBox();
            this.BtnConservarArchivoRemoto = new System.Windows.Forms.Button();
            this.LblArchivoRemoto = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblVista = new System.Windows.Forms.Label();
            this.CmbVista = new System.Windows.Forms.ComboBox();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.LblNombreArchivo = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicArchivoLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicArchivoRemoto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BkgDescargarArchivos
            // 
            this.BkgDescargarArchivos.WorkerReportsProgress = true;
            this.BkgDescargarArchivos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarArchivos_DoWork);
            this.BkgDescargarArchivos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarArchivos_ProgressChanged);
            this.BkgDescargarArchivos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarArchivos_RunWorkerCompleted);
            // 
            // BkgGenerarVistasPrevias
            // 
            this.BkgGenerarVistasPrevias.WorkerReportsProgress = true;
            this.BkgGenerarVistasPrevias.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgGenerarVistasPrevias_DoWork);
            this.BkgGenerarVistasPrevias.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgGenerarVistasPrevias_ProgressChanged);
            this.BkgGenerarVistasPrevias.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgGenerarVistasPrevias_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 85);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PicArchivoLocal);
            this.splitContainer1.Panel1.Controls.Add(this.BtnConservarArchivoLocal);
            this.splitContainer1.Panel1.Controls.Add(this.LblArchivoLocal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PicArchivoRemoto);
            this.splitContainer1.Panel2.Controls.Add(this.BtnConservarArchivoRemoto);
            this.splitContainer1.Panel2.Controls.Add(this.LblArchivoRemoto);
            this.splitContainer1.Size = new System.Drawing.Size(755, 281);
            this.splitContainer1.SplitterDistance = 384;
            this.splitContainer1.TabIndex = 0;
            // 
            // PicArchivoLocal
            // 
            this.PicArchivoLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicArchivoLocal.Location = new System.Drawing.Point(0, 46);
            this.PicArchivoLocal.Name = "PicArchivoLocal";
            this.PicArchivoLocal.Size = new System.Drawing.Size(384, 235);
            this.PicArchivoLocal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicArchivoLocal.TabIndex = 0;
            this.PicArchivoLocal.TabStop = false;
            // 
            // BtnConservarArchivoLocal
            // 
            this.BtnConservarArchivoLocal.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnConservarArchivoLocal.Location = new System.Drawing.Point(0, 23);
            this.BtnConservarArchivoLocal.Name = "BtnConservarArchivoLocal";
            this.BtnConservarArchivoLocal.Size = new System.Drawing.Size(384, 23);
            this.BtnConservarArchivoLocal.TabIndex = 35;
            this.BtnConservarArchivoLocal.Text = "Conservar";
            this.BtnConservarArchivoLocal.UseVisualStyleBackColor = true;
            this.BtnConservarArchivoLocal.Click += new System.EventHandler(this.BtnConservarArchivoLocal_Click);
            // 
            // LblArchivoLocal
            // 
            this.LblArchivoLocal.BackColor = System.Drawing.Color.Black;
            this.LblArchivoLocal.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblArchivoLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArchivoLocal.ForeColor = System.Drawing.Color.White;
            this.LblArchivoLocal.Location = new System.Drawing.Point(0, 0);
            this.LblArchivoLocal.Name = "LblArchivoLocal";
            this.LblArchivoLocal.Size = new System.Drawing.Size(384, 23);
            this.LblArchivoLocal.TabIndex = 31;
            this.LblArchivoLocal.Text = "ARCHIVO LOCAL";
            this.LblArchivoLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicArchivoRemoto
            // 
            this.PicArchivoRemoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicArchivoRemoto.Location = new System.Drawing.Point(0, 46);
            this.PicArchivoRemoto.Name = "PicArchivoRemoto";
            this.PicArchivoRemoto.Size = new System.Drawing.Size(367, 235);
            this.PicArchivoRemoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicArchivoRemoto.TabIndex = 1;
            this.PicArchivoRemoto.TabStop = false;
            // 
            // BtnConservarArchivoRemoto
            // 
            this.BtnConservarArchivoRemoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnConservarArchivoRemoto.Location = new System.Drawing.Point(0, 23);
            this.BtnConservarArchivoRemoto.Name = "BtnConservarArchivoRemoto";
            this.BtnConservarArchivoRemoto.Size = new System.Drawing.Size(367, 23);
            this.BtnConservarArchivoRemoto.TabIndex = 34;
            this.BtnConservarArchivoRemoto.Text = "Conservar";
            this.BtnConservarArchivoRemoto.UseVisualStyleBackColor = true;
            this.BtnConservarArchivoRemoto.Click += new System.EventHandler(this.BtnConservarArchivoRemoto_Click);
            // 
            // LblArchivoRemoto
            // 
            this.LblArchivoRemoto.BackColor = System.Drawing.Color.Black;
            this.LblArchivoRemoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblArchivoRemoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArchivoRemoto.ForeColor = System.Drawing.Color.White;
            this.LblArchivoRemoto.Location = new System.Drawing.Point(0, 0);
            this.LblArchivoRemoto.Name = "LblArchivoRemoto";
            this.LblArchivoRemoto.Size = new System.Drawing.Size(367, 23);
            this.LblArchivoRemoto.TabIndex = 31;
            this.LblArchivoRemoto.Text = "ARCHIVO REMOTO";
            this.LblArchivoRemoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblVista);
            this.panel1.Controls.Add(this.CmbVista);
            this.panel1.Controls.Add(this.LblEstatus);
            this.panel1.Controls.Add(this.LblNombreArchivo);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 85);
            this.panel1.TabIndex = 1;
            // 
            // LblVista
            // 
            this.LblVista.AutoSize = true;
            this.LblVista.Location = new System.Drawing.Point(17, 58);
            this.LblVista.Name = "LblVista";
            this.LblVista.Size = new System.Drawing.Size(33, 13);
            this.LblVista.TabIndex = 39;
            this.LblVista.Text = "Vista:";
            // 
            // CmbVista
            // 
            this.CmbVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbVista.FormattingEnabled = true;
            this.CmbVista.Items.AddRange(new object[] {
            "ISOMETRICO",
            "FRONTAL",
            "LATERAL IZQUIERDA",
            "LATERAL DERECHA",
            "INFERIOR",
            "POSTERIOR"});
            this.CmbVista.Location = new System.Drawing.Point(52, 50);
            this.CmbVista.Name = "CmbVista";
            this.CmbVista.Size = new System.Drawing.Size(332, 28);
            this.CmbVista.TabIndex = 38;
            this.CmbVista.SelectedIndexChanged += new System.EventHandler(this.CmbVista_SelectedIndexChanged);
            // 
            // LblEstatus
            // 
            this.LblEstatus.AutoSize = true;
            this.LblEstatus.BackColor = System.Drawing.Color.Cyan;
            this.LblEstatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.Location = new System.Drawing.Point(498, 23);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(127, 24);
            this.LblEstatus.TabIndex = 37;
            this.LblEstatus.Text = "PENDIENTE";
            // 
            // LblNombreArchivo
            // 
            this.LblNombreArchivo.AutoSize = true;
            this.LblNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreArchivo.Location = new System.Drawing.Point(48, 27);
            this.LblNombreArchivo.Name = "LblNombreArchivo";
            this.LblNombreArchivo.Size = new System.Drawing.Size(211, 20);
            this.LblNombreArchivo.TabIndex = 36;
            this.LblNombreArchivo.Text = "NOMBRE DEL ARCHIVO";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(625, 23);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(130, 62);
            this.BtnSalir.TabIndex = 2;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(755, 23);
            this.LblTitulo.TabIndex = 33;
            this.LblTitulo.Text = "COMPARAR ARCHIVOS DE SOLIDWORKS";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEstatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 366);
            this.TxtEstatus.Multiline = true;
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(755, 41);
            this.TxtEstatus.TabIndex = 36;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 407);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(755, 23);
            this.Progreso.TabIndex = 37;
            this.Progreso.Visible = false;
            // 
            // FrmCompararSolidWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 430);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtEstatus);
            this.Controls.Add(this.Progreso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCompararSolidWorks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparar archivo SolidWorks";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCompararSolidWorks_FormClosing);
            this.Load += new System.EventHandler(this.FrmCompararSolidWorks_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicArchivoLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicArchivoRemoto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.PictureBox PicArchivoLocal;
        private System.Windows.Forms.PictureBox PicArchivoRemoto;
        private System.Windows.Forms.Label LblArchivoLocal;
        private System.Windows.Forms.Label LblArchivoRemoto;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnConservarArchivoLocal;
        private System.Windows.Forms.Button BtnConservarArchivoRemoto;
        private System.Windows.Forms.Label LblNombreArchivo;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.ComponentModel.BackgroundWorker BkgDescargarArchivos;
        private System.ComponentModel.BackgroundWorker BkgGenerarVistasPrevias;
        private System.Windows.Forms.Label LblVista;
        private System.Windows.Forms.ComboBox CmbVista;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.ProgressBar Progreso;
    }
}
namespace CB
{
    partial class FrmRestringirNumeroParte
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ImagenMaterial = new System.Windows.Forms.PictureBox();
            this.ChkRestringit = new System.Windows.Forms.CheckBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtAudiselParte = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.LblEstatusAsignaciones = new System.Windows.Forms.Label();
            this.BarraProgresoAsignaciones = new System.Windows.Forms.ProgressBar();
            this.BkgDescargarImagen = new System.ComponentModel.BackgroundWorker();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtNumeroParte);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 62);
            this.panel1.TabIndex = 0;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(675, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(152, 62);
            this.BtnSalir.TabIndex = 65;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Número de parte fabricante*";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(3, 24);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.Size = new System.Drawing.Size(283, 29);
            this.TxtNumeroParte.TabIndex = 63;
            this.TxtNumeroParte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNumeroParte_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 85);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ImagenMaterial);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ChkRestringit);
            this.splitContainer1.Panel2.Controls.Add(this.TxtDescripcion);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.TxtAudiselParte);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.TxtFabricante);
            this.splitContainer1.Size = new System.Drawing.Size(827, 287);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 1;
            // 
            // ImagenMaterial
            // 
            this.ImagenMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImagenMaterial.Image = global::CB_Base.Properties.Resources.manu_prod;
            this.ImagenMaterial.Location = new System.Drawing.Point(0, 0);
            this.ImagenMaterial.Name = "ImagenMaterial";
            this.ImagenMaterial.Size = new System.Drawing.Size(155, 163);
            this.ImagenMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenMaterial.TabIndex = 17;
            this.ImagenMaterial.TabStop = false;
            // 
            // ChkRestringit
            // 
            this.ChkRestringit.AutoSize = true;
            this.ChkRestringit.Location = new System.Drawing.Point(3, 257);
            this.ChkRestringit.Name = "ChkRestringit";
            this.ChkRestringit.Size = new System.Drawing.Size(150, 17);
            this.ChkRestringit.TabIndex = 63;
            this.ChkRestringit.Text = "Restringir numero de parte";
            this.ChkRestringit.UseVisualStyleBackColor = true;
            this.ChkRestringit.CheckedChanged += new System.EventHandler(this.ChkRestringit_CheckedChanged);
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(2, 121);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.Size = new System.Drawing.Size(652, 122);
            this.TxtDescripcion.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Descripción *";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Número de parte interno";
            // 
            // TxtAudiselParte
            // 
            this.TxtAudiselParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAudiselParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAudiselParte.Location = new System.Drawing.Point(6, 25);
            this.TxtAudiselParte.Name = "TxtAudiselParte";
            this.TxtAudiselParte.ReadOnly = true;
            this.TxtAudiselParte.Size = new System.Drawing.Size(360, 29);
            this.TxtAudiselParte.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Fabricante *";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(6, 73);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(360, 29);
            this.TxtFabricante.TabIndex = 46;
            // 
            // LblEstatusAsignaciones
            // 
            this.LblEstatusAsignaciones.BackColor = System.Drawing.Color.Black;
            this.LblEstatusAsignaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusAsignaciones.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusAsignaciones.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusAsignaciones.Location = new System.Drawing.Point(0, 372);
            this.LblEstatusAsignaciones.Name = "LblEstatusAsignaciones";
            this.LblEstatusAsignaciones.Size = new System.Drawing.Size(827, 25);
            this.LblEstatusAsignaciones.TabIndex = 114;
            this.LblEstatusAsignaciones.Text = "Estatus...";
            this.LblEstatusAsignaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarraProgresoAsignaciones
            // 
            this.BarraProgresoAsignaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraProgresoAsignaciones.Location = new System.Drawing.Point(0, 397);
            this.BarraProgresoAsignaciones.Name = "BarraProgresoAsignaciones";
            this.BarraProgresoAsignaciones.Size = new System.Drawing.Size(827, 23);
            this.BarraProgresoAsignaciones.TabIndex = 113;
            this.BarraProgresoAsignaciones.Visible = false;
            // 
            // BkgDescargarImagen
            // 
            this.BkgDescargarImagen.WorkerReportsProgress = true;
            this.BkgDescargarImagen.WorkerSupportsCancellation = true;
            this.BkgDescargarImagen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DescargarImagen_DoWork);
            this.BkgDescargarImagen.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarImagen_ProgressChanged);
            this.BkgDescargarImagen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarImagen_RunWorkerCompleted);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(827, 23);
            this.audiselTituloForm1.TabIndex = 2;
            this.audiselTituloForm1.Text = "RESTRINGIR NUMERO DE PARTE";
            // 
            // FrmRestringirNumeroParte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 420);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblEstatusAsignaciones);
            this.Controls.Add(this.BarraProgresoAsignaciones);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRestringirNumeroParte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRestringirNumeroParte";
            this.Load += new System.EventHandler(this.FrmRestringirNumeroParte_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox ImagenMaterial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtAudiselParte;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ChkRestringit;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label LblEstatusAsignaciones;
        private System.Windows.Forms.ProgressBar BarraProgresoAsignaciones;
        private System.ComponentModel.BackgroundWorker BkgDescargarImagen;
    }
}
namespace CB
{
    partial class FrmGaleria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGaleria));
            this.LiiPrueba = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbFiltroArchivos = new System.Windows.Forms.ComboBox();
            this.BtnDescargarArchivo = new System.Windows.Forms.Button();
            this.BtnSubirArchivo = new System.Windows.Forms.Button();
            this.LiiDefecto = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LiiPrueba
            // 
            this.LiiPrueba.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.LiiPrueba.ImageSize = new System.Drawing.Size(128, 128);
            this.LiiPrueba.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.LiiPrueba;
            this.listView1.Location = new System.Drawing.Point(0, 64);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(602, 484);
            this.listView1.SmallImageList = this.LiiPrueba;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbFiltroArchivos);
            this.panel1.Controls.Add(this.BtnDescargarArchivo);
            this.panel1.Controls.Add(this.BtnSubirArchivo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 64);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filtrar por tipo de documento:";
            // 
            // CmbFiltroArchivos
            // 
            this.CmbFiltroArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbFiltroArchivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroArchivos.FormattingEnabled = true;
            this.CmbFiltroArchivos.Items.AddRange(new object[] {
            "TODO",
            "IMAGENES",
            "VIDEOS",
            "DOCUMENTOS"});
            this.CmbFiltroArchivos.Location = new System.Drawing.Point(12, 27);
            this.CmbFiltroArchivos.Name = "CmbFiltroArchivos";
            this.CmbFiltroArchivos.Size = new System.Drawing.Size(282, 28);
            this.CmbFiltroArchivos.TabIndex = 2;
            this.CmbFiltroArchivos.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroArchivos_SelectedIndexChanged);
            // 
            // BtnDescargarArchivo
            // 
            this.BtnDescargarArchivo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnDescargarArchivo.Enabled = false;
            this.BtnDescargarArchivo.Image = global::CB_Base.Properties.Resources.download_file_48;
            this.BtnDescargarArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDescargarArchivo.Location = new System.Drawing.Point(300, 0);
            this.BtnDescargarArchivo.Name = "BtnDescargarArchivo";
            this.BtnDescargarArchivo.Size = new System.Drawing.Size(158, 64);
            this.BtnDescargarArchivo.TabIndex = 1;
            this.BtnDescargarArchivo.Text = "              Descargar archivo";
            this.BtnDescargarArchivo.UseVisualStyleBackColor = true;
            this.BtnDescargarArchivo.Click += new System.EventHandler(this.BtnDescargarArchivo_Click);
            // 
            // BtnSubirArchivo
            // 
            this.BtnSubirArchivo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSubirArchivo.Image = global::CB_Base.Properties.Resources.upload_file_48;
            this.BtnSubirArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubirArchivo.Location = new System.Drawing.Point(458, 0);
            this.BtnSubirArchivo.Name = "BtnSubirArchivo";
            this.BtnSubirArchivo.Size = new System.Drawing.Size(144, 64);
            this.BtnSubirArchivo.TabIndex = 0;
            this.BtnSubirArchivo.Text = "            Subir archivo";
            this.BtnSubirArchivo.UseVisualStyleBackColor = true;
            this.BtnSubirArchivo.Click += new System.EventHandler(this.BtnImagen_Click);
            // 
            // LiiDefecto
            // 
            this.LiiDefecto.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LiiDefecto.ImageStream")));
            this.LiiDefecto.TransparentColor = System.Drawing.Color.Transparent;
            this.LiiDefecto.Images.SetKeyName(0, "video_icon.png");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listView1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 548);
            this.panel3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(496, 548);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(602, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(496, 548);
            this.panel2.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(496, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(99, 17);
            this.toolStripStatusLabel1.Text = "Nombre archivo: ";
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(1098, 23);
            this.audiselTituloForm1.TabIndex = 5;
            this.audiselTituloForm1.Text = "GALERIA";
            // 
            // FrmGaleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 571);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.audiselTituloForm1);
            this.Name = "FrmGaleria";
            this.Text = "FrmGaleria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGaleria_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList LiiPrueba;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSubirArchivo;
        private System.Windows.Forms.ImageList LiiDefecto;
        private System.Windows.Forms.Button BtnDescargarArchivo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox CmbFiltroArchivos;
        private System.Windows.Forms.Label label1;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
    }
}
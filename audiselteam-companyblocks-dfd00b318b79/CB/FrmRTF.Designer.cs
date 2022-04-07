namespace CB
{
    partial class FrmRTF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRTF));
            this.RTBcaja = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsbAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.TsbAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.TsbAlignRight = new System.Windows.Forms.ToolStripButton();
            this.TsbBold = new System.Windows.Forms.ToolStripButton();
            this.TsbItalika = new System.Windows.Forms.ToolStripButton();
            this.TsbSubrayar = new System.Windows.Forms.ToolStripButton();
            this.TsbTachar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.BtnHazAlgo = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressArchivo = new System.Windows.Forms.ToolStripProgressBar();
            this.LblGuardarArchivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.BkgGuardarArchivo = new System.ComponentModel.BackgroundWorker();
            this.audiselColorSelector1 = new CB_Base.CB_Controles.AudiselColorSelector();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RTBcaja
            // 
            this.RTBcaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTBcaja.Location = new System.Drawing.Point(0, 48);
            this.RTBcaja.Name = "RTBcaja";
            this.RTBcaja.Size = new System.Drawing.Size(574, 327);
            this.RTBcaja.TabIndex = 0;
            this.RTBcaja.Text = "";
            this.RTBcaja.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbAlignLeft,
            this.TsbAlignCenter,
            this.TsbAlignRight,
            this.audiselColorSelector1,
            this.TsbBold,
            this.TsbItalika,
            this.TsbSubrayar,
            this.TsbTachar,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(574, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TsbAlignLeft
            // 
            this.TsbAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbAlignLeft.Image = global::CB_Base.Properties.Resources.align_center1;
            this.TsbAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbAlignLeft.Name = "TsbAlignLeft";
            this.TsbAlignLeft.Size = new System.Drawing.Size(23, 22);
            this.TsbAlignLeft.Text = "Align Left";
            this.TsbAlignLeft.Click += new System.EventHandler(this.TsbAlignLeft_Click);
            // 
            // TsbAlignCenter
            // 
            this.TsbAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbAlignCenter.Image = global::CB_Base.Properties.Resources.align_left;
            this.TsbAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbAlignCenter.Name = "TsbAlignCenter";
            this.TsbAlignCenter.Size = new System.Drawing.Size(23, 22);
            this.TsbAlignCenter.Text = "Align Center";
            this.TsbAlignCenter.Click += new System.EventHandler(this.TsbAlignCenter_Click);
            // 
            // TsbAlignRight
            // 
            this.TsbAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbAlignRight.Image = global::CB_Base.Properties.Resources.align_right;
            this.TsbAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbAlignRight.Name = "TsbAlignRight";
            this.TsbAlignRight.Size = new System.Drawing.Size(23, 22);
            this.TsbAlignRight.Text = "Align Right";
            this.TsbAlignRight.Click += new System.EventHandler(this.TsbAlignRight_Click);
            // 
            // TsbBold
            // 
            this.TsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsbBold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.TsbBold.Image = ((System.Drawing.Image)(resources.GetObject("TsbBold.Image")));
            this.TsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbBold.Name = "TsbBold";
            this.TsbBold.Size = new System.Drawing.Size(23, 22);
            this.TsbBold.Text = "N";
            this.TsbBold.Click += new System.EventHandler(this.TsbBold_Click);
            // 
            // TsbItalika
            // 
            this.TsbItalika.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsbItalika.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.TsbItalika.Image = ((System.Drawing.Image)(resources.GetObject("TsbItalika.Image")));
            this.TsbItalika.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbItalika.Name = "TsbItalika";
            this.TsbItalika.Size = new System.Drawing.Size(23, 22);
            this.TsbItalika.Text = "I";
            this.TsbItalika.Click += new System.EventHandler(this.TsbItalika_Click);
            // 
            // TsbSubrayar
            // 
            this.TsbSubrayar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsbSubrayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.TsbSubrayar.Image = ((System.Drawing.Image)(resources.GetObject("TsbSubrayar.Image")));
            this.TsbSubrayar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbSubrayar.Name = "TsbSubrayar";
            this.TsbSubrayar.Size = new System.Drawing.Size(23, 22);
            this.TsbSubrayar.Text = "S";
            this.TsbSubrayar.Click += new System.EventHandler(this.TsbSubrayar_Click);
            // 
            // TsbTachar
            // 
            this.TsbTachar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsbTachar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout);
            this.TsbTachar.Image = ((System.Drawing.Image)(resources.GetObject("TsbTachar.Image")));
            this.TsbTachar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbTachar.Name = "TsbTachar";
            this.TsbTachar.Size = new System.Drawing.Size(30, 22);
            this.TsbTachar.Text = "abc";
            this.TsbTachar.Click += new System.EventHandler(this.TsbTachar_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::CB_Base.Properties.Resources.bullets_icon_16px;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CB_Base.Properties.Resources.Zoom_In_icon_16px;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.BtnZoomIn_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::CB_Base.Properties.Resources.Zoom_Out_icon_16px;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.BtnHazAlgo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 53);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "PDF ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(308, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 53);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "    Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BtnHazAlgo
            // 
            this.BtnHazAlgo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnHazAlgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHazAlgo.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnHazAlgo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHazAlgo.Location = new System.Drawing.Point(441, 0);
            this.BtnHazAlgo.Name = "BtnHazAlgo";
            this.BtnHazAlgo.Size = new System.Drawing.Size(133, 53);
            this.BtnHazAlgo.TabIndex = 1;
            this.BtnHazAlgo.Text = "    Guardar";
            this.BtnHazAlgo.UseVisualStyleBackColor = true;
            this.BtnHazAlgo.Click += new System.EventHandler(this.BtnHazAlgo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblGuardarArchivo,
            this.ProgressArchivo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 31);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(308, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressArchivo
            // 
            this.ProgressArchivo.Name = "ProgressArchivo";
            this.ProgressArchivo.Size = new System.Drawing.Size(100, 16);
            // 
            // LblGuardarArchivo
            // 
            this.LblGuardarArchivo.Name = "LblGuardarArchivo";
            this.LblGuardarArchivo.Size = new System.Drawing.Size(108, 17);
            this.LblGuardarArchivo.Text = "Guardando archivo";
            // 
            // BkgGuardarArchivo
            // 
            this.BkgGuardarArchivo.WorkerReportsProgress = true;
            this.BkgGuardarArchivo.WorkerSupportsCancellation = true;
            this.BkgGuardarArchivo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgGuardarArchivo_DoWork);
            this.BkgGuardarArchivo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgGuardarArchivo_ProgressChanged);
            this.BkgGuardarArchivo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgGuardarArchivo_RunWorkerCompleted);
            // 
            // audiselColorSelector1
            // 
            this.audiselColorSelector1.Color = System.Drawing.Color.Black;
            this.audiselColorSelector1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audiselColorSelector1.Image = global::CB_Base.Properties.Resources.back;
            this.audiselColorSelector1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audiselColorSelector1.Name = "audiselColorSelector1";
            this.audiselColorSelector1.Size = new System.Drawing.Size(32, 22);
            this.audiselColorSelector1.Text = "audiselColorSelector1";
            this.audiselColorSelector1.ButtonClick += new System.EventHandler(this.audiselColorSelector1_ButtonClick);
            this.audiselColorSelector1.DropDownOpening += new System.EventHandler(this.audiselColorSelector1_DropDownOpening);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(574, 23);
            this.audiselTituloForm1.TabIndex = 6;
            this.audiselTituloForm1.Text = "SECUENCIA DE OPERACIONES";
            // 
            // FrmRTF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 428);
            this.Controls.Add(this.RTBcaja);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.audiselTituloForm1);
            this.Name = "FrmRTF";
            this.Text = "FrmRTF";
            this.Load += new System.EventHandler(this.FrmRTF_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTBcaja;
        private System.Windows.Forms.Button BtnHazAlgo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsbAlignLeft;
        private System.Windows.Forms.ToolStripButton TsbAlignCenter;
        private System.Windows.Forms.ToolStripButton TsbAlignRight;
        private System.Windows.Forms.ToolStripButton TsbItalika;
        private System.Windows.Forms.ToolStripButton TsbBold;
        private System.Windows.Forms.ToolStripButton TsbSubrayar;
        private System.Windows.Forms.ToolStripButton TsbTachar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private CB_Base.CB_Controles.AudiselColorSelector audiselColorSelector1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button btnCancelar;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblGuardarArchivo;
        private System.Windows.Forms.ToolStripProgressBar ProgressArchivo;
        private System.ComponentModel.BackgroundWorker BkgGuardarArchivo;
    }
}
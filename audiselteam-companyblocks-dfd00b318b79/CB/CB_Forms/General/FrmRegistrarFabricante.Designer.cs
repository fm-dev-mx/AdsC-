namespace CB
{
    partial class FrmRegistrarFabricante
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
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.BkgSubirArchivo = new System.ComponentModel.BackgroundWorker();
            this.OFDSubirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.lblSubiendoArchivo = new System.Windows.Forms.Label();
            this.PBImage = new System.Windows.Forms.PictureBox();
            this.MenuCopiarImagen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImage)).BeginInit();
            this.MenuCopiarImagen.SuspendLayout();
            this.SuspendLayout();
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(392, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "REGISTRAR FABRICANTE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del fabricante:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(1, 42);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TxtNombre.Size = new System.Drawing.Size(390, 26);
            this.TxtNombre.TabIndex = 2;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 177);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 46);
            this.panel1.TabIndex = 6;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(110, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(141, 46);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(251, 0);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(141, 46);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button2_Click);
            // 
            // BkgSubirArchivo
            // 
            this.BkgSubirArchivo.WorkerReportsProgress = true;
            this.BkgSubirArchivo.WorkerSupportsCancellation = true;
            this.BkgSubirArchivo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubirArchivo_DoWork);
            this.BkgSubirArchivo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubirArchivo_ProgressChanged);
            this.BkgSubirArchivo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubirArchivo_RunWorkerCompleted);
            // 
            // OFDSubirArchivo
            // 
            this.OFDSubirArchivo.FileName = "openFileDialog1";
            // 
            // lblSubiendoArchivo
            // 
            this.lblSubiendoArchivo.AutoSize = true;
            this.lblSubiendoArchivo.Location = new System.Drawing.Point(165, 126);
            this.lblSubiendoArchivo.Name = "lblSubiendoArchivo";
            this.lblSubiendoArchivo.Size = new System.Drawing.Size(99, 13);
            this.lblSubiendoArchivo.TabIndex = 7;
            this.lblSubiendoArchivo.Text = "Subiendo archivo...";
            // 
            // PBImage
            // 
            this.PBImage.ContextMenuStrip = this.MenuCopiarImagen;
            this.PBImage.Image = global::CB_Base.Properties.Resources.image_not_found;
            this.PBImage.Location = new System.Drawing.Point(4, 74);
            this.PBImage.Name = "PBImage";
            this.PBImage.Size = new System.Drawing.Size(155, 97);
            this.PBImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBImage.TabIndex = 8;
            this.PBImage.TabStop = false;
            // 
            // MenuCopiarImagen
            // 
            this.MenuCopiarImagen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pegarToolStripMenuItem});
            this.MenuCopiarImagen.Name = "MenuCopiarImagen";
            this.MenuCopiarImagen.Size = new System.Drawing.Size(153, 48);
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Paste_32;
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pegarToolStripMenuItem.Text = "Pegar";
            this.pegarToolStripMenuItem.Click += new System.EventHandler(this.pegarToolStripMenuItem_Click);
            // 
            // FrmRegistrarFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 223);
            this.Controls.Add(this.PBImage);
            this.Controls.Add(this.lblSubiendoArchivo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistrarFabricante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar fabricante";
            this.Load += new System.EventHandler(this.FrmRegistrarFabricante_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBImage)).EndInit();
            this.MenuCopiarImagen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.ComponentModel.BackgroundWorker BkgSubirArchivo;
        private System.Windows.Forms.OpenFileDialog OFDSubirArchivo;
        private System.Windows.Forms.Label lblSubiendoArchivo;
        private System.Windows.Forms.PictureBox PBImage;
        private System.Windows.Forms.ContextMenuStrip MenuCopiarImagen;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
    }
}
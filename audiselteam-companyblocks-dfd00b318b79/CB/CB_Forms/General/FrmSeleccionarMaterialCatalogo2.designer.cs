namespace CB
{
    partial class FrmSeleccionarMaterialCatalogo2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionarMaterialCatalogo2));
            this.BtnValesSalida = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSeleccionarMaterial = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TvMaterial = new System.Windows.Forms.TreeView();
            this.ImagenesNodos = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ImagenMaterial = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtEnlace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTipoVenta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtParteAudisel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblNumeroParte = new System.Windows.Forms.Label();
            this.LblEstatusAsignaciones = new System.Windows.Forms.Label();
            this.BarraProgresoAsignaciones = new System.Windows.Forms.ProgressBar();
            this.BkgCargarInformacion = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnValesSalida
            // 
            this.BtnValesSalida.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnValesSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValesSalida.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnValesSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnValesSalida.Location = new System.Drawing.Point(792, 23);
            this.BtnValesSalida.Name = "BtnValesSalida";
            this.BtnValesSalida.Size = new System.Drawing.Size(136, 68);
            this.BtnValesSalida.TabIndex = 109;
            this.BtnValesSalida.Text = "        Salir";
            this.BtnValesSalida.UseVisualStyleBackColor = true;
            this.BtnValesSalida.Click += new System.EventHandler(this.BtnValesSalida_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(656, 23);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(136, 68);
            this.BtnBuscar.TabIndex = 108;
            this.BtnBuscar.Text = "Buscar    ";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSeleccionarMaterial);
            this.panel1.Controls.Add(this.BtnBuscar);
            this.panel1.Controls.Add(this.BtnValesSalida);
            this.panel1.Controls.Add(this.audiselTituloForm1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(928, 91);
            this.panel1.TabIndex = 1;
            // 
            // BtnSeleccionarMaterial
            // 
            this.BtnSeleccionarMaterial.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSeleccionarMaterial.Enabled = false;
            this.BtnSeleccionarMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarMaterial.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnSeleccionarMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSeleccionarMaterial.Location = new System.Drawing.Point(511, 23);
            this.BtnSeleccionarMaterial.Name = "BtnSeleccionarMaterial";
            this.BtnSeleccionarMaterial.Size = new System.Drawing.Size(145, 68);
            this.BtnSeleccionarMaterial.TabIndex = 110;
            this.BtnSeleccionarMaterial.Text = "    Seleccionar";
            this.BtnSeleccionarMaterial.UseVisualStyleBackColor = true;
            this.BtnSeleccionarMaterial.Click += new System.EventHandler(this.BtnSeleccionarMaterial_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(928, 23);
            this.audiselTituloForm1.TabIndex = 111;
            this.audiselTituloForm1.Text = "SELECCIONAR MATERIAL DE CATALOGO";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 91);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TvMaterial);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(928, 573);
            this.splitContainer1.SplitterDistance = 275;
            this.splitContainer1.TabIndex = 2;
            // 
            // TvMaterial
            // 
            this.TvMaterial.AllowDrop = true;
            this.TvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvMaterial.ImageIndex = 0;
            this.TvMaterial.ImageList = this.ImagenesNodos;
            this.TvMaterial.Location = new System.Drawing.Point(0, 0);
            this.TvMaterial.Name = "TvMaterial";
            this.TvMaterial.SelectedImageIndex = 0;
            this.TvMaterial.Size = new System.Drawing.Size(275, 573);
            this.TvMaterial.TabIndex = 2;
            this.TvMaterial.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TvMaterial_AfterCollapse);
            this.TvMaterial.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvMaterial_BeforeExpand);
            this.TvMaterial.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMaterial_NodeMouseClick);
            this.TvMaterial.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMaterial_NodeMouseDoubleClick);
            // 
            // ImagenesNodos
            // 
            this.ImagenesNodos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesNodos.ImageStream")));
            this.ImagenesNodos.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesNodos.Images.SetKeyName(0, "index_48.png");
            this.ImagenesNodos.Images.SetKeyName(1, "folder_24px.png");
            this.ImagenesNodos.Images.SetKeyName(2, "Box-icon.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Controls.Add(this.LblNumeroParte);
            this.panel2.Controls.Add(this.LblEstatusAsignaciones);
            this.panel2.Controls.Add(this.BarraProgresoAsignaciones);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 573);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 23);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ImagenMaterial);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Size = new System.Drawing.Size(649, 502);
            this.splitContainer2.SplitterDistance = 163;
            this.splitContainer2.TabIndex = 5;
            // 
            // ImagenMaterial
            // 
            this.ImagenMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImagenMaterial.Image = global::CB_Base.Properties.Resources.manu_prod;
            this.ImagenMaterial.Location = new System.Drawing.Point(0, 0);
            this.ImagenMaterial.Name = "ImagenMaterial";
            this.ImagenMaterial.Size = new System.Drawing.Size(163, 163);
            this.ImagenMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenMaterial.TabIndex = 16;
            this.ImagenMaterial.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TxtDescripcion);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(482, 502);
            this.panel3.TabIndex = 42;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.AcceptsTab = true;
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDescripcion.Location = new System.Drawing.Point(0, 229);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.Size = new System.Drawing.Size(482, 273);
            this.TxtDescripcion.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.TxtEnlace);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.TxtFabricante);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.TxtTipoVenta);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.TxtParteAudisel);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.TxtNumeroParte);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(482, 229);
            this.panel4.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Descripción *";
            // 
            // TxtEnlace
            // 
            this.TxtEnlace.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtEnlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEnlace.Location = new System.Drawing.Point(0, 181);
            this.TxtEnlace.Name = "TxtEnlace";
            this.TxtEnlace.ReadOnly = true;
            this.TxtEnlace.Size = new System.Drawing.Size(482, 29);
            this.TxtEnlace.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Enlace de información:";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFabricante.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(0, 139);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(482, 29);
            this.TxtFabricante.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Fabricante *";
            // 
            // TxtTipoVenta
            // 
            this.TxtTipoVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtTipoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTipoVenta.Location = new System.Drawing.Point(0, 97);
            this.TxtTipoVenta.Name = "TxtTipoVenta";
            this.TxtTipoVenta.ReadOnly = true;
            this.TxtTipoVenta.Size = new System.Drawing.Size(482, 29);
            this.TxtTipoVenta.TabIndex = 54;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Tipo de venta *";
            // 
            // TxtParteAudisel
            // 
            this.TxtParteAudisel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtParteAudisel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtParteAudisel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtParteAudisel.Location = new System.Drawing.Point(0, 55);
            this.TxtParteAudisel.Name = "TxtParteAudisel";
            this.TxtParteAudisel.ReadOnly = true;
            this.TxtParteAudisel.Size = new System.Drawing.Size(482, 29);
            this.TxtParteAudisel.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Número de parte interno*";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(0, 13);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(482, 29);
            this.TxtNumeroParte.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Número de parte fabricante*";
            // 
            // LblNumeroParte
            // 
            this.LblNumeroParte.BackColor = System.Drawing.Color.Black;
            this.LblNumeroParte.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroParte.ForeColor = System.Drawing.Color.White;
            this.LblNumeroParte.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroParte.Name = "LblNumeroParte";
            this.LblNumeroParte.Size = new System.Drawing.Size(649, 23);
            this.LblNumeroParte.TabIndex = 4;
            this.LblNumeroParte.Text = "SELECCIONA UN NUMERO DE PARTE";
            this.LblNumeroParte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblEstatusAsignaciones
            // 
            this.LblEstatusAsignaciones.BackColor = System.Drawing.Color.Black;
            this.LblEstatusAsignaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusAsignaciones.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusAsignaciones.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusAsignaciones.Location = new System.Drawing.Point(0, 525);
            this.LblEstatusAsignaciones.Name = "LblEstatusAsignaciones";
            this.LblEstatusAsignaciones.Size = new System.Drawing.Size(649, 25);
            this.LblEstatusAsignaciones.TabIndex = 114;
            this.LblEstatusAsignaciones.Text = "Estatus...";
            this.LblEstatusAsignaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarraProgresoAsignaciones
            // 
            this.BarraProgresoAsignaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraProgresoAsignaciones.Location = new System.Drawing.Point(0, 550);
            this.BarraProgresoAsignaciones.Name = "BarraProgresoAsignaciones";
            this.BarraProgresoAsignaciones.Size = new System.Drawing.Size(649, 23);
            this.BarraProgresoAsignaciones.TabIndex = 113;
            this.BarraProgresoAsignaciones.Visible = false;
            // 
            // BkgCargarInformacion
            // 
            this.BkgCargarInformacion.WorkerReportsProgress = true;
            this.BkgCargarInformacion.WorkerSupportsCancellation = true;
            this.BkgCargarInformacion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgCargarInformacion_DoWork);
            this.BkgCargarInformacion.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgCargarInformacion_ProgressChanged);
            this.BkgCargarInformacion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgCargarInformacion_RunWorkerCompleted);
            // 
            // FrmSeleccionarMaterialCatalogo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 664);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSeleccionarMaterialCatalogo2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar material del catálogo";
            this.Load += new System.EventHandler(this.FrmSeleccionarMaterialCatalogo2_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnValesSalida;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TvMaterial;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblNumeroParte;
        private System.Windows.Forms.Button BtnSeleccionarMaterial;
        private System.Windows.Forms.ImageList ImagenesNodos;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.ComponentModel.BackgroundWorker BkgCargarInformacion;
        private System.Windows.Forms.Label LblEstatusAsignaciones;
        private System.Windows.Forms.ProgressBar BarraProgresoAsignaciones;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox ImagenMaterial;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtEnlace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtTipoVenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtParteAudisel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.Label label3;

    }
}
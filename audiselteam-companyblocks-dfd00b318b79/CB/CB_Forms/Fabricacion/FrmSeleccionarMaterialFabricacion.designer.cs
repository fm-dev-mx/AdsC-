namespace CB
{
    partial class FrmSeleccionarMaterialFabricacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionarMaterialFabricacion));
            this.BtnValesSalida = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSeleccionarMaterial = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TvMaterial = new System.Windows.Forms.TreeView();
            this.ImagenesNodos = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.PanelMedidaEstandar = new System.Windows.Forms.Panel();
            this.LblMedidaEstandar = new System.Windows.Forms.Label();
            this.label1000 = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkCantidad = new System.Windows.Forms.CheckBox();
            this.PanelPulgadas = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PnlAncho = new System.Windows.Forms.Panel();
            this.CmbTamAncho = new System.Windows.Forms.ComboBox();
            this.NumTamAncho = new System.Windows.Forms.NumericUpDown();
            this.LblLargo = new System.Windows.Forms.Label();
            this.PnlEspesorRadio = new System.Windows.Forms.Panel();
            this.CmbTamEspesor = new System.Windows.Forms.ComboBox();
            this.LblEspesorRadio = new System.Windows.Forms.Label();
            this.NumTamEspesor = new System.Windows.Forms.NumericUpDown();
            this.PnlLargo = new System.Windows.Forms.Panel();
            this.CmbTamLargo = new System.Windows.Forms.ComboBox();
            this.NumTamLargo = new System.Windows.Forms.NumericUpDown();
            this.LblAncho = new System.Windows.Forms.Label();
            this.TxtCategoriaMaterial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LblNumeroParte = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.NumCantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ChkOversize = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbPresentaciones = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PanelMedidaEstandar.SuspendLayout();
            this.PanelPulgadas.SuspendLayout();
            this.PnlAncho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTamAncho)).BeginInit();
            this.PnlEspesorRadio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTamEspesor)).BeginInit();
            this.PnlLargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTamLargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnValesSalida
            // 
            this.BtnValesSalida.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnValesSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValesSalida.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnValesSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnValesSalida.Location = new System.Drawing.Point(565, 23);
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
            this.BtnBuscar.Location = new System.Drawing.Point(429, 23);
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
            this.panel1.Size = new System.Drawing.Size(701, 91);
            this.panel1.TabIndex = 1;
            // 
            // BtnSeleccionarMaterial
            // 
            this.BtnSeleccionarMaterial.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSeleccionarMaterial.Enabled = false;
            this.BtnSeleccionarMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarMaterial.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnSeleccionarMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSeleccionarMaterial.Location = new System.Drawing.Point(284, 23);
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
            this.audiselTituloForm1.Size = new System.Drawing.Size(701, 23);
            this.audiselTituloForm1.TabIndex = 111;
            this.audiselTituloForm1.Text = "SELECCIONAR MATERIAL DE FABRICACION";
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
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Size = new System.Drawing.Size(701, 468);
            this.splitContainer1.SplitterDistance = 265;
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
            this.TvMaterial.Size = new System.Drawing.Size(265, 468);
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
            this.panel2.Controls.Add(this.PanelMedidaEstandar);
            this.panel2.Controls.Add(this.txtComentarios);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ChkCantidad);
            this.panel2.Controls.Add(this.PanelPulgadas);
            this.panel2.Controls.Add(this.TxtCategoriaMaterial);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.LblNumeroParte);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TxtFabricante);
            this.panel2.Controls.Add(this.NumCantidad);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ChkOversize);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TxtNumeroParte);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CmbPresentaciones);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 468);
            this.panel2.TabIndex = 1;
            // 
            // PanelMedidaEstandar
            // 
            this.PanelMedidaEstandar.Controls.Add(this.LblMedidaEstandar);
            this.PanelMedidaEstandar.Controls.Add(this.label1000);
            this.PanelMedidaEstandar.Location = new System.Drawing.Point(10, 273);
            this.PanelMedidaEstandar.Name = "PanelMedidaEstandar";
            this.PanelMedidaEstandar.Size = new System.Drawing.Size(410, 47);
            this.PanelMedidaEstandar.TabIndex = 84;
            // 
            // LblMedidaEstandar
            // 
            this.LblMedidaEstandar.AutoSize = true;
            this.LblMedidaEstandar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMedidaEstandar.Location = new System.Drawing.Point(3, 20);
            this.LblMedidaEstandar.Name = "LblMedidaEstandar";
            this.LblMedidaEstandar.Size = new System.Drawing.Size(48, 13);
            this.LblMedidaEstandar.TabIndex = 84;
            this.LblMedidaEstandar.Text = "Medida";
            // 
            // label1000
            // 
            this.label1000.AutoSize = true;
            this.label1000.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1000.Location = new System.Drawing.Point(3, 4);
            this.label1000.Name = "label1000";
            this.label1000.Size = new System.Drawing.Size(309, 13);
            this.label1000.TabIndex = 83;
            this.label1000.Text = "Este material tiene definida una medida estándar de: ";
            // 
            // txtComentarios
            // 
            this.txtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentarios.Location = new System.Drawing.Point(10, 341);
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(410, 115);
            this.txtComentarios.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Comentarios";
            // 
            // ChkCantidad
            // 
            this.ChkCantidad.AutoSize = true;
            this.ChkCantidad.Checked = true;
            this.ChkCantidad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkCantidad.Location = new System.Drawing.Point(13, 185);
            this.ChkCantidad.Name = "ChkCantidad";
            this.ChkCantidad.Size = new System.Drawing.Size(218, 17);
            this.ChkCantidad.TabIndex = 82;
            this.ChkCantidad.Text = "Acorde a la cantidad de piezas del plano";
            this.ChkCantidad.UseVisualStyleBackColor = true;
            this.ChkCantidad.CheckedChanged += new System.EventHandler(this.ChkCantidad_CheckedChanged);
            // 
            // PanelPulgadas
            // 
            this.PanelPulgadas.Controls.Add(this.PnlLargo);
            this.PanelPulgadas.Controls.Add(this.label10);
            this.PanelPulgadas.Controls.Add(this.PnlAncho);
            this.PanelPulgadas.Controls.Add(this.label7);
            this.PanelPulgadas.Controls.Add(this.PnlEspesorRadio);
            this.PanelPulgadas.Location = new System.Drawing.Point(10, 208);
            this.PanelPulgadas.Name = "PanelPulgadas";
            this.PanelPulgadas.Size = new System.Drawing.Size(411, 59);
            this.PanelPulgadas.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(131, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 59);
            this.label7.TabIndex = 58;
            this.label7.Text = "X";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(274, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 59);
            this.label10.TabIndex = 69;
            this.label10.Text = "X";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PnlAncho
            // 
            this.PnlAncho.Controls.Add(this.CmbTamAncho);
            this.PnlAncho.Controls.Add(this.NumTamAncho);
            this.PnlAncho.Controls.Add(this.LblLargo);
            this.PnlAncho.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlAncho.Location = new System.Drawing.Point(145, 0);
            this.PnlAncho.Name = "PnlAncho";
            this.PnlAncho.Size = new System.Drawing.Size(129, 59);
            this.PnlAncho.TabIndex = 76;
            // 
            // CmbTamAncho
            // 
            this.CmbTamAncho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTamAncho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTamAncho.FormattingEnabled = true;
            this.CmbTamAncho.Location = new System.Drawing.Point(66, 17);
            this.CmbTamAncho.Name = "CmbTamAncho";
            this.CmbTamAncho.Size = new System.Drawing.Size(58, 28);
            this.CmbTamAncho.TabIndex = 66;
            this.CmbTamAncho.SelectedIndexChanged += new System.EventHandler(this.CmbTamLargo_SelectedIndexChanged);
            // 
            // NumTamAncho
            // 
            this.NumTamAncho.DecimalPlaces = 2;
            this.NumTamAncho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NumTamAncho.Location = new System.Drawing.Point(2, 19);
            this.NumTamAncho.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NumTamAncho.Name = "NumTamAncho";
            this.NumTamAncho.Size = new System.Drawing.Size(58, 26);
            this.NumTamAncho.TabIndex = 65;
            this.NumTamAncho.ValueChanged += new System.EventHandler(this.CmbTamLargo_SelectedIndexChanged);
            // 
            // LblLargo
            // 
            this.LblLargo.AutoSize = true;
            this.LblLargo.Location = new System.Drawing.Point(-4, 2);
            this.LblLargo.Name = "LblLargo";
            this.LblLargo.Size = new System.Drawing.Size(38, 13);
            this.LblLargo.TabIndex = 55;
            this.LblLargo.Text = "Ancho";
            // 
            // PnlEspesorRadio
            // 
            this.PnlEspesorRadio.Controls.Add(this.CmbTamEspesor);
            this.PnlEspesorRadio.Controls.Add(this.NumTamEspesor);
            this.PnlEspesorRadio.Controls.Add(this.LblEspesorRadio);
            this.PnlEspesorRadio.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlEspesorRadio.Location = new System.Drawing.Point(0, 0);
            this.PnlEspesorRadio.Name = "PnlEspesorRadio";
            this.PnlEspesorRadio.Size = new System.Drawing.Size(131, 59);
            this.PnlEspesorRadio.TabIndex = 77;
            // 
            // CmbTamEspesor
            // 
            this.CmbTamEspesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTamEspesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTamEspesor.FormattingEnabled = true;
            this.CmbTamEspesor.Location = new System.Drawing.Point(67, 18);
            this.CmbTamEspesor.Name = "CmbTamEspesor";
            this.CmbTamEspesor.Size = new System.Drawing.Size(58, 28);
            this.CmbTamEspesor.TabIndex = 71;
            this.CmbTamEspesor.SelectedIndexChanged += new System.EventHandler(this.CmbTamLargo_SelectedIndexChanged);
            // 
            // LblEspesorRadio
            // 
            this.LblEspesorRadio.AutoSize = true;
            this.LblEspesorRadio.Location = new System.Drawing.Point(0, 3);
            this.LblEspesorRadio.Name = "LblEspesorRadio";
            this.LblEspesorRadio.Size = new System.Drawing.Size(45, 13);
            this.LblEspesorRadio.TabIndex = 60;
            this.LblEspesorRadio.Text = "Espesor";
            // 
            // NumTamEspesor
            // 
            this.NumTamEspesor.DecimalPlaces = 2;
            this.NumTamEspesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NumTamEspesor.Location = new System.Drawing.Point(3, 20);
            this.NumTamEspesor.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NumTamEspesor.Name = "NumTamEspesor";
            this.NumTamEspesor.Size = new System.Drawing.Size(58, 26);
            this.NumTamEspesor.TabIndex = 70;
            this.NumTamEspesor.ValueChanged += new System.EventHandler(this.CmbTamLargo_SelectedIndexChanged);
            // 
            // PnlLargo
            // 
            this.PnlLargo.Controls.Add(this.CmbTamLargo);
            this.PnlLargo.Controls.Add(this.NumTamLargo);
            this.PnlLargo.Controls.Add(this.LblAncho);
            this.PnlLargo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlLargo.Location = new System.Drawing.Point(288, 0);
            this.PnlLargo.Name = "PnlLargo";
            this.PnlLargo.Size = new System.Drawing.Size(124, 59);
            this.PnlLargo.TabIndex = 75;
            // 
            // CmbTamLargo
            // 
            this.CmbTamLargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTamLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTamLargo.FormattingEnabled = true;
            this.CmbTamLargo.Location = new System.Drawing.Point(63, 15);
            this.CmbTamLargo.Name = "CmbTamLargo";
            this.CmbTamLargo.Size = new System.Drawing.Size(58, 28);
            this.CmbTamLargo.TabIndex = 68;
            this.CmbTamLargo.SelectedIndexChanged += new System.EventHandler(this.CmbTamLargo_SelectedIndexChanged);
            // 
            // NumTamLargo
            // 
            this.NumTamLargo.DecimalPlaces = 2;
            this.NumTamLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NumTamLargo.Location = new System.Drawing.Point(1, 17);
            this.NumTamLargo.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NumTamLargo.Name = "NumTamLargo";
            this.NumTamLargo.Size = new System.Drawing.Size(58, 26);
            this.NumTamLargo.TabIndex = 67;
            this.NumTamLargo.ValueChanged += new System.EventHandler(this.CmbTamLargo_SelectedIndexChanged);
            // 
            // LblAncho
            // 
            this.LblAncho.AutoSize = true;
            this.LblAncho.Location = new System.Drawing.Point(-2, 0);
            this.LblAncho.Name = "LblAncho";
            this.LblAncho.Size = new System.Drawing.Size(34, 13);
            this.LblAncho.TabIndex = 72;
            this.LblAncho.Text = "Largo";
            // 
            // TxtCategoriaMaterial
            // 
            this.TxtCategoriaMaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCategoriaMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCategoriaMaterial.Location = new System.Drawing.Point(180, 96);
            this.TxtCategoriaMaterial.Name = "TxtCategoriaMaterial";
            this.TxtCategoriaMaterial.ReadOnly = true;
            this.TxtCategoriaMaterial.Size = new System.Drawing.Size(241, 29);
            this.TxtCategoriaMaterial.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Categoría";
            // 
            // LblNumeroParte
            // 
            this.LblNumeroParte.BackColor = System.Drawing.Color.Black;
            this.LblNumeroParte.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroParte.ForeColor = System.Drawing.Color.White;
            this.LblNumeroParte.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroParte.Name = "LblNumeroParte";
            this.LblNumeroParte.Size = new System.Drawing.Size(432, 23);
            this.LblNumeroParte.TabIndex = 4;
            this.LblNumeroParte.Text = "SELECCIONA UN NUMERO DE PARTE";
            this.LblNumeroParte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Material";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(11, 96);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(155, 29);
            this.TxtFabricante.TabIndex = 44;
            this.TxtFabricante.Text = "LOCAL";
            // 
            // NumCantidad
            // 
            this.NumCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumCantidad.Location = new System.Drawing.Point(180, 151);
            this.NumCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumCantidad.Name = "NumCantidad";
            this.NumCantidad.Size = new System.Drawing.Size(120, 26);
            this.NumCantidad.TabIndex = 62;
            this.NumCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Fabricante";
            // 
            // ChkOversize
            // 
            this.ChkOversize.AutoSize = true;
            this.ChkOversize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkOversize.Location = new System.Drawing.Point(313, 151);
            this.ChkOversize.Name = "ChkOversize";
            this.ChkOversize.Size = new System.Drawing.Size(72, 17);
            this.ChkOversize.TabIndex = 63;
            this.ChkOversize.Text = "Over Size";
            this.ChkOversize.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Cantidad";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(11, 43);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(410, 29);
            this.TxtNumeroParte.TabIndex = 42;
            this.TxtNumeroParte.TextChanged += new System.EventHandler(this.TxtNumeroParte_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Presentación";
            // 
            // CmbPresentaciones
            // 
            this.CmbPresentaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPresentaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPresentaciones.FormattingEnabled = true;
            this.CmbPresentaciones.Location = new System.Drawing.Point(11, 151);
            this.CmbPresentaciones.Name = "CmbPresentaciones";
            this.CmbPresentaciones.Size = new System.Drawing.Size(155, 28);
            this.CmbPresentaciones.TabIndex = 52;
            this.CmbPresentaciones.SelectedIndexChanged += new System.EventHandler(this.CmbPresentaciones_SelectedIndexChanged);
            // 
            // FrmSeleccionarMaterialFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 559);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSeleccionarMaterialFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3";
            this.Load += new System.EventHandler(this.FrmSeleccionarMaterialCatalogo2_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PanelMedidaEstandar.ResumeLayout(false);
            this.PanelMedidaEstandar.PerformLayout();
            this.PanelPulgadas.ResumeLayout(false);
            this.PnlAncho.ResumeLayout(false);
            this.PnlAncho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTamAncho)).EndInit();
            this.PnlEspesorRadio.ResumeLayout(false);
            this.PnlEspesorRadio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTamEspesor)).EndInit();
            this.PnlLargo.ResumeLayout(false);
            this.PnlLargo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTamLargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnValesSalida;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TvMaterial;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.Label LblNumeroParte;
        private System.Windows.Forms.Button BtnSeleccionarMaterial;
        private System.Windows.Forms.ImageList ImagenesNodos;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbPresentaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ChkOversize;
        private System.Windows.Forms.NumericUpDown NumCantidad;
        private System.Windows.Forms.TextBox TxtCategoriaMaterial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel PanelPulgadas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel PnlAncho;
        private System.Windows.Forms.ComboBox CmbTamAncho;
        private System.Windows.Forms.NumericUpDown NumTamAncho;
        private System.Windows.Forms.Label LblLargo;
        private System.Windows.Forms.Panel PnlEspesorRadio;
        private System.Windows.Forms.ComboBox CmbTamEspesor;
        private System.Windows.Forms.Label LblEspesorRadio;
        private System.Windows.Forms.NumericUpDown NumTamEspesor;
        private System.Windows.Forms.Panel PnlLargo;
        private System.Windows.Forms.ComboBox CmbTamLargo;
        private System.Windows.Forms.NumericUpDown NumTamLargo;
        private System.Windows.Forms.Label LblAncho;
        private System.Windows.Forms.CheckBox ChkCantidad;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelMedidaEstandar;
        private System.Windows.Forms.Label label1000;
        private System.Windows.Forms.Label LblMedidaEstandar;

    }
}
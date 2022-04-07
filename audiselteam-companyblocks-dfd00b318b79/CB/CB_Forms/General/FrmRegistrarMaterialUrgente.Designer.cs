namespace CB
{
    partial class FrmRegistrarMaterialUrgente
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
            this.label16 = new System.Windows.Forms.Label();
            this.CmbSubcategoria = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CmbTipoCompra = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.TxtProveedor = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbTiempo = new System.Windows.Forms.ComboBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.NumTiempoEntrega = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ChkIva = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbMoneda = new System.Windows.Forms.ComboBox();
            this.ImagenMaterial = new System.Windows.Forms.PictureBox();
            this.btnRegstrarFabricante = new System.Windows.Forms.Button();
            this.PnlMinMax = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.NumMaximo = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.NumMinimo = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbFabricante = new System.Windows.Forms.ComboBox();
            this.NumPrecioUnitario = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtLink = new System.Windows.Forms.TextBox();
            this.LblEtiquetaPiezasPorPaquete = new System.Windows.Forms.Label();
            this.NumPiezasPaquete = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbUnidades = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.BkgRegistrarMaterial = new System.ComponentModel.BackgroundWorker();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.BkgRegistrarMat = new System.ComponentModel.BackgroundWorker();
            this.LblInfo = new System.Windows.Forms.Label();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTiempoEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).BeginInit();
            this.PnlMinMax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrecioUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPiezasPaquete)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.CmbSubcategoria);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.CmbCategoria);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.CmbTipoCompra);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 50);
            this.panel1.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(2, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 72;
            this.label16.Text = "Tipo de compra";
            // 
            // CmbSubcategoria
            // 
            this.CmbSubcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSubcategoria.FormattingEnabled = true;
            this.CmbSubcategoria.Location = new System.Drawing.Point(333, 19);
            this.CmbSubcategoria.Name = "CmbSubcategoria";
            this.CmbSubcategoria.Size = new System.Drawing.Size(156, 21);
            this.CmbSubcategoria.TabIndex = 71;
            this.CmbSubcategoria.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(330, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 70;
            this.label15.Text = "Subcategoria";
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(168, 19);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(156, 21);
            this.CmbCategoria.TabIndex = 69;
            this.CmbCategoria.SelectedIndexChanged += new System.EventHandler(this.CmbCategoria_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(168, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 68;
            this.label14.Text = "Categoría";
            // 
            // CmbTipoCompra
            // 
            this.CmbTipoCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoCompra.FormattingEnabled = true;
            this.CmbTipoCompra.Location = new System.Drawing.Point(6, 19);
            this.CmbTipoCompra.Name = "CmbTipoCompra";
            this.CmbTipoCompra.Size = new System.Drawing.Size(156, 21);
            this.CmbTipoCompra.TabIndex = 0;
            this.CmbTipoCompra.SelectedIndexChanged += new System.EventHandler(this.CmbTipoCompra_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.TxtProveedor);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.CmbTiempo);
            this.panel2.Controls.Add(this.numCantidad);
            this.panel2.Controls.Add(this.NumTiempoEntrega);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.ChkIva);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.CmbMoneda);
            this.panel2.Controls.Add(this.ImagenMaterial);
            this.panel2.Controls.Add(this.btnRegstrarFabricante);
            this.panel2.Controls.Add(this.PnlMinMax);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.CmbFabricante);
            this.panel2.Controls.Add(this.NumPrecioUnitario);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.TxtLink);
            this.panel2.Controls.Add(this.LblEtiquetaPiezasPorPaquete);
            this.panel2.Controls.Add(this.NumPiezasPaquete);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.CmbUnidades);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TxtDescripcion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TxtNumeroParte);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 454);
            this.panel2.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 352);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 105;
            this.label17.Text = "Proveedor";
            // 
            // TxtProveedor
            // 
            this.TxtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProveedor.Location = new System.Drawing.Point(6, 371);
            this.TxtProveedor.Name = "TxtProveedor";
            this.TxtProveedor.ReadOnly = true;
            this.TxtProveedor.Size = new System.Drawing.Size(271, 26);
            this.TxtProveedor.TabIndex = 104;
            // 
            // button2
            // 
            this.button2.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.button2.Location = new System.Drawing.Point(283, 371);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 29);
            this.button2.TabIndex = 103;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(334, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 102;
            this.label9.Text = "Tiempo de entrega:";
            // 
            // CmbTiempo
            // 
            this.CmbTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTiempo.FormattingEnabled = true;
            this.CmbTiempo.Items.AddRange(new object[] {
            "DIAS",
            "SEMANAS"});
            this.CmbTiempo.Location = new System.Drawing.Point(477, 368);
            this.CmbTiempo.Name = "CmbTiempo";
            this.CmbTiempo.Size = new System.Drawing.Size(134, 32);
            this.CmbTiempo.TabIndex = 101;
            // 
            // numCantidad
            // 
            this.numCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCantidad.Location = new System.Drawing.Point(3, 416);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(134, 29);
            this.numCantidad.TabIndex = 91;
            this.numCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NumTiempoEntrega
            // 
            this.NumTiempoEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumTiempoEntrega.Location = new System.Drawing.Point(337, 371);
            this.NumTiempoEntrega.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumTiempoEntrega.Name = "NumTiempoEntrega";
            this.NumTiempoEntrega.Size = new System.Drawing.Size(134, 29);
            this.NumTiempoEntrega.TabIndex = 95;
            this.NumTiempoEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 400);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 90;
            this.label11.Text = "Cantidad";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(-1, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(676, 23);
            this.label12.TabIndex = 84;
            this.label12.Text = "INFORMACION DEL MATERIAL";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChkIva
            // 
            this.ChkIva.AutoSize = true;
            this.ChkIva.Checked = true;
            this.ChkIva.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkIva.Location = new System.Drawing.Point(128, 155);
            this.ChkIva.Name = "ChkIva";
            this.ChkIva.Size = new System.Drawing.Size(78, 17);
            this.ChkIva.TabIndex = 83;
            this.ChkIva.Text = "Aplicar IVA";
            this.ChkIva.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(280, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 100;
            this.label8.Text = "Moneda:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 32);
            this.button1.TabIndex = 81;
            this.button1.Text = "Pegar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbMoneda
            // 
            this.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMoneda.FormattingEnabled = true;
            this.CmbMoneda.Items.AddRange(new object[] {
            "MXN",
            "USD",
            "EUR"});
            this.CmbMoneda.Location = new System.Drawing.Point(283, 416);
            this.CmbMoneda.Name = "CmbMoneda";
            this.CmbMoneda.Size = new System.Drawing.Size(134, 32);
            this.CmbMoneda.TabIndex = 96;
            // 
            // ImagenMaterial
            // 
            this.ImagenMaterial.Location = new System.Drawing.Point(3, 29);
            this.ImagenMaterial.Name = "ImagenMaterial";
            this.ImagenMaterial.Size = new System.Drawing.Size(120, 111);
            this.ImagenMaterial.TabIndex = 80;
            this.ImagenMaterial.TabStop = false;
            // 
            // btnRegstrarFabricante
            // 
            this.btnRegstrarFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegstrarFabricante.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.btnRegstrarFabricante.Location = new System.Drawing.Point(625, 50);
            this.btnRegstrarFabricante.Name = "btnRegstrarFabricante";
            this.btnRegstrarFabricante.Size = new System.Drawing.Size(36, 32);
            this.btnRegstrarFabricante.TabIndex = 79;
            this.btnRegstrarFabricante.UseVisualStyleBackColor = true;
            this.btnRegstrarFabricante.Click += new System.EventHandler(this.btnRegstrarFabricante_Click);
            // 
            // PnlMinMax
            // 
            this.PnlMinMax.Controls.Add(this.label5);
            this.PnlMinMax.Controls.Add(this.NumMaximo);
            this.PnlMinMax.Controls.Add(this.label7);
            this.PnlMinMax.Controls.Add(this.NumMinimo);
            this.PnlMinMax.Location = new System.Drawing.Point(492, 87);
            this.PnlMinMax.Name = "PnlMinMax";
            this.PnlMinMax.Size = new System.Drawing.Size(169, 53);
            this.PnlMinMax.TabIndex = 78;
            this.PnlMinMax.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Máximo";
            // 
            // NumMaximo
            // 
            this.NumMaximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumMaximo.Location = new System.Drawing.Point(88, 19);
            this.NumMaximo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumMaximo.Name = "NumMaximo";
            this.NumMaximo.Size = new System.Drawing.Size(75, 29);
            this.NumMaximo.TabIndex = 53;
            this.NumMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumMaximo.ValueChanged += new System.EventHandler(this.NumMaximo_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Mínimo";
            // 
            // NumMinimo
            // 
            this.NumMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumMinimo.Location = new System.Drawing.Point(4, 19);
            this.NumMinimo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumMinimo.Name = "NumMinimo";
            this.NumMinimo.Size = new System.Drawing.Size(78, 29);
            this.NumMinimo.TabIndex = 51;
            this.NumMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumMinimo.ValueChanged += new System.EventHandler(this.NumMinimo_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(141, 400);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 98;
            this.label10.Text = "Precio unitario:";
            // 
            // CmbFabricante
            // 
            this.CmbFabricante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CmbFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFabricante.FormattingEnabled = true;
            this.CmbFabricante.Items.AddRange(new object[] {
            "POR PIEZA",
            "POR PAQUETE"});
            this.CmbFabricante.Location = new System.Drawing.Point(381, 50);
            this.CmbFabricante.Name = "CmbFabricante";
            this.CmbFabricante.Size = new System.Drawing.Size(238, 32);
            this.CmbFabricante.TabIndex = 77;
            this.CmbFabricante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbFabricante_KeyPress);
            // 
            // NumPrecioUnitario
            // 
            this.NumPrecioUnitario.DecimalPlaces = 2;
            this.NumPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPrecioUnitario.Location = new System.Drawing.Point(143, 416);
            this.NumPrecioUnitario.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.NumPrecioUnitario.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.NumPrecioUnitario.Name = "NumPrecioUnitario";
            this.NumPrecioUnitario.Size = new System.Drawing.Size(134, 29);
            this.NumPrecioUnitario.TabIndex = 93;
            this.NumPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Enlace de información";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(1, 315);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(674, 23);
            this.label13.TabIndex = 92;
            this.label13.Text = "INFORMACION DE COMPRA";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtLink
            // 
            this.TxtLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLink.Location = new System.Drawing.Point(0, 292);
            this.TxtLink.Name = "TxtLink";
            this.TxtLink.Size = new System.Drawing.Size(661, 20);
            this.TxtLink.TabIndex = 75;
            // 
            // LblEtiquetaPiezasPorPaquete
            // 
            this.LblEtiquetaPiezasPorPaquete.AutoSize = true;
            this.LblEtiquetaPiezasPorPaquete.Location = new System.Drawing.Point(378, 90);
            this.LblEtiquetaPiezasPorPaquete.Name = "LblEtiquetaPiezasPorPaquete";
            this.LblEtiquetaPiezasPorPaquete.Size = new System.Drawing.Size(105, 13);
            this.LblEtiquetaPiezasPorPaquete.TabIndex = 71;
            this.LblEtiquetaPiezasPorPaquete.Text = "Piezas por paquete *";
            this.LblEtiquetaPiezasPorPaquete.Visible = false;
            // 
            // NumPiezasPaquete
            // 
            this.NumPiezasPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPiezasPaquete.Location = new System.Drawing.Point(381, 106);
            this.NumPiezasPaquete.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPiezasPaquete.Name = "NumPiezasPaquete";
            this.NumPiezasPaquete.Size = new System.Drawing.Size(102, 29);
            this.NumPiezasPaquete.TabIndex = 70;
            this.NumPiezasPaquete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPiezasPaquete.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPiezasPaquete.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "Tipo de venta *";
            // 
            // CmbUnidades
            // 
            this.CmbUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUnidades.FormattingEnabled = true;
            this.CmbUnidades.Items.AddRange(new object[] {
            "POR PIEZA",
            "POR PAQUETE"});
            this.CmbUnidades.Location = new System.Drawing.Point(128, 106);
            this.CmbUnidades.Name = "CmbUnidades";
            this.CmbUnidades.Size = new System.Drawing.Size(247, 32);
            this.CmbUnidades.TabIndex = 68;
            this.CmbUnidades.SelectedIndexChanged += new System.EventHandler(this.CmbUnidades_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Descripción *";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.Location = new System.Drawing.Point(0, 207);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(661, 66);
            this.TxtDescripcion.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Fabricante *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Número de parte *";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(128, 50);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.Size = new System.Drawing.Size(247, 29);
            this.TxtNumeroParte.TabIndex = 63;
            // 
            // BkgRegistrarMaterial
            // 
            this.BkgRegistrarMaterial.WorkerReportsProgress = true;
            this.BkgRegistrarMaterial.WorkerSupportsCancellation = true;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(281, 555);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(190, 40);
            this.BtnCancelar.TabIndex = 73;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.ok_48;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(477, 555);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(186, 40);
            this.BtnRegistrar.TabIndex = 72;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(3, 572);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(255, 23);
            this.Progreso.TabIndex = 75;
            // 
            // BkgRegistrarMat
            // 
            this.BkgRegistrarMat.WorkerReportsProgress = true;
            this.BkgRegistrarMat.WorkerSupportsCancellation = true;
            this.BkgRegistrarMat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgRegistrarMat_DoWork);
            this.BkgRegistrarMat.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgRegistrarMat_ProgressChanged);
            this.BkgRegistrarMat.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgRegistrarMat_RunWorkerCompleted);
            // 
            // LblInfo
            // 
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.ForeColor = System.Drawing.Color.Red;
            this.LblInfo.Location = new System.Drawing.Point(2, 544);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(256, 25);
            this.LblInfo.TabIndex = 76;
            this.LblInfo.Text = "Info";
            this.LblInfo.Visible = false;
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(675, 23);
            this.audiselTituloForm1.TabIndex = 74;
            this.audiselTituloForm1.Text = "CREAR REQUISICION URGENTE";
            // 
            // FrmRegistrarMaterialUrgente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 607);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistrarMaterialUrgente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegistrarMaterialUrgente";
            this.Load += new System.EventHandler(this.FrmRegistrarMaterialUrgente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTiempoEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).EndInit();
            this.PnlMinMax.ResumeLayout(false);
            this.PnlMinMax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrecioUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPiezasPaquete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ChkIva;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox ImagenMaterial;
        private System.Windows.Forms.Button btnRegstrarFabricante;
        private System.Windows.Forms.Panel PnlMinMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumMaximo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NumMinimo;
        private System.Windows.Forms.ComboBox CmbFabricante;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtLink;
        private System.Windows.Forms.Label LblEtiquetaPiezasPorPaquete;
        private System.Windows.Forms.NumericUpDown NumPiezasPaquete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbUnidades;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.ComponentModel.BackgroundWorker BkgRegistrarMaterial;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CmbTiempo;
        private System.Windows.Forms.NumericUpDown NumTiempoEntrega;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbMoneda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown NumPrecioUnitario;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CmbSubcategoria;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox CmbTipoCompra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.ComponentModel.BackgroundWorker BkgRegistrarMat;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TxtProveedor;
        private System.Windows.Forms.Button button2;
    }
}
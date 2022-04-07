namespace CB
{
    partial class FrmRevisarDrawing
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
            this.PicPlano = new System.Windows.Forms.PictureBox();
            this.SplitPlano = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvCustomProperties = new System.Windows.Forms.DataGridView();
            this.propiedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.BtnComentarios = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnRechazar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LblEditar = new System.Windows.Forms.Label();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnClean = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSizePicker = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnColorPicker = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SplitEstatus = new System.Windows.Forms.SplitContainer();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.BkgDescargarPlano = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarCP = new System.ComponentModel.BackgroundWorker();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.BkgGuardarImagen = new System.ComponentModel.BackgroundWorker();
            this.vistaGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vistaDetalladaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgRenombrarArchivos = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPlano)).BeginInit();
            this.SplitPlano.Panel1.SuspendLayout();
            this.SplitPlano.Panel2.SuspendLayout();
            this.SplitPlano.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitEstatus)).BeginInit();
            this.SplitEstatus.Panel1.SuspendLayout();
            this.SplitEstatus.Panel2.SuspendLayout();
            this.SplitEstatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.PicPlano);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 640);
            this.panel1.TabIndex = 1;
            // 
            // PicPlano
            // 
            this.PicPlano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPlano.Location = new System.Drawing.Point(0, 0);
            this.PicPlano.Name = "PicPlano";
            this.PicPlano.Size = new System.Drawing.Size(642, 640);
            this.PicPlano.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicPlano.TabIndex = 0;
            this.PicPlano.TabStop = false;
            this.PicPlano.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPlano_MouseDown);
            this.PicPlano.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPlano_MouseMove);
            this.PicPlano.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPlano_MouseUp);
            // 
            // SplitPlano
            // 
            this.SplitPlano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitPlano.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitPlano.Location = new System.Drawing.Point(0, 0);
            this.SplitPlano.Name = "SplitPlano";
            // 
            // SplitPlano.Panel1
            // 
            this.SplitPlano.Panel1.Controls.Add(this.panel1);
            // 
            // SplitPlano.Panel2
            // 
            this.SplitPlano.Panel2.Controls.Add(this.splitContainer2);
            this.SplitPlano.Panel2.Controls.Add(this.splitContainer1);
            this.SplitPlano.Size = new System.Drawing.Size(943, 640);
            this.SplitPlano.SplitterDistance = 642;
            this.SplitPlano.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 118);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.DgvCustomProperties);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.TxtComentarios);
            this.splitContainer2.Panel2.Controls.Add(this.BtnComentarios);
            this.splitContainer2.Panel2.Controls.Add(this.BtnAceptar);
            this.splitContainer2.Panel2.Controls.Add(this.BtnRechazar);
            this.splitContainer2.Panel2.Controls.Add(this.BtnSalir);
            this.splitContainer2.Size = new System.Drawing.Size(297, 522);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 29);
            this.label2.TabIndex = 33;
            this.label2.Text = "COMENTARIOS DE REVISION";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvCustomProperties
            // 
            this.DgvCustomProperties.AllowUserToAddRows = false;
            this.DgvCustomProperties.AllowUserToDeleteRows = false;
            this.DgvCustomProperties.AllowUserToResizeRows = false;
            this.DgvCustomProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCustomProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.propiedad,
            this.valor});
            this.DgvCustomProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCustomProperties.Location = new System.Drawing.Point(0, 182);
            this.DgvCustomProperties.Name = "DgvCustomProperties";
            this.DgvCustomProperties.ReadOnly = true;
            this.DgvCustomProperties.RowHeadersVisible = false;
            this.DgvCustomProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCustomProperties.Size = new System.Drawing.Size(297, 91);
            this.DgvCustomProperties.TabIndex = 31;
            // 
            // propiedad
            // 
            this.propiedad.HeaderText = "Propiedad";
            this.propiedad.Name = "propiedad";
            this.propiedad.ReadOnly = true;
            this.propiedad.Width = 150;
            // 
            // valor
            // 
            this.valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 22);
            this.label1.TabIndex = 26;
            this.label1.Text = "SOLIDWORKS CUSTOM PROPERTIES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtComentarios.Enabled = false;
            this.TxtComentarios.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(0, 0);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ReadOnly = true;
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentarios.Size = new System.Drawing.Size(297, 160);
            this.TxtComentarios.TabIndex = 27;
            this.TxtComentarios.TextChanged += new System.EventHandler(this.TxtComentarios_TextChanged);
            // 
            // BtnComentarios
            // 
            this.BtnComentarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnComentarios.Image = global::CB_Base.Properties.Resources.Nota;
            this.BtnComentarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnComentarios.Location = new System.Drawing.Point(0, 273);
            this.BtnComentarios.Name = "BtnComentarios";
            this.BtnComentarios.Size = new System.Drawing.Size(297, 55);
            this.BtnComentarios.TabIndex = 33;
            this.BtnComentarios.Text = "            Comentarios";
            this.BtnComentarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnComentarios.UseVisualStyleBackColor = true;
            this.BtnComentarios.Click += new System.EventHandler(this.BtnComentarios_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnAceptar.Enabled = false;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(0, 328);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(297, 55);
            this.BtnAceptar.TabIndex = 28;
            this.BtnAceptar.Text = "            Aceptar plano";
            this.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnRechazar
            // 
            this.BtnRechazar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnRechazar.Enabled = false;
            this.BtnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRechazar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnRechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRechazar.Location = new System.Drawing.Point(0, 383);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(297, 55);
            this.BtnRechazar.TabIndex = 29;
            this.BtnRechazar.Text = "            Rechazar plano";
            this.BtnRechazar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRechazar.UseVisualStyleBackColor = true;
            this.BtnRechazar.Click += new System.EventHandler(this.BtnRechazar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 438);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(297, 55);
            this.BtnSalir.TabIndex = 30;
            this.BtnSalir.Text = "            Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(297, 118);
            this.splitContainer1.SplitterDistance = 29;
            this.splitContainer1.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "PERSONALIZAR LINEA";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.UseMnemonic = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LblEditar);
            this.groupBox4.Controls.Add(this.BtnEditar);
            this.groupBox4.Location = new System.Drawing.Point(195, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(58, 74);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // LblEditar
            // 
            this.LblEditar.Location = new System.Drawing.Point(0, 54);
            this.LblEditar.Name = "LblEditar";
            this.LblEditar.Size = new System.Drawing.Size(54, 11);
            this.LblEditar.TabIndex = 3;
            this.LblEditar.Text = "Editar";
            this.LblEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnEditar
            // 
            this.BtnEditar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnEditar.Image = global::CB_Base.Properties.Resources.Edit;
            this.BtnEditar.Location = new System.Drawing.Point(0, 8);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(56, 43);
            this.BtnEditar.TabIndex = 2;
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.BtnClean);
            this.groupBox3.Location = new System.Drawing.Point(131, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(58, 74);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Limpiar";
            // 
            // BtnClean
            // 
            this.BtnClean.BackColor = System.Drawing.SystemColors.Control;
            this.BtnClean.Image = global::CB_Base.Properties.Resources.clean_image;
            this.BtnClean.Location = new System.Drawing.Point(0, 8);
            this.BtnClean.Name = "BtnClean";
            this.BtnClean.Size = new System.Drawing.Size(56, 43);
            this.BtnClean.TabIndex = 2;
            this.BtnClean.UseVisualStyleBackColor = false;
            this.BtnClean.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.BtnSizePicker);
            this.groupBox1.Location = new System.Drawing.Point(67, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(58, 74);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tamaño";
            // 
            // BtnSizePicker
            // 
            this.BtnSizePicker.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSizePicker.Image = global::CB_Base.Properties.Resources.size_paint;
            this.BtnSizePicker.Location = new System.Drawing.Point(0, 7);
            this.BtnSizePicker.Name = "BtnSizePicker";
            this.BtnSizePicker.Size = new System.Drawing.Size(56, 43);
            this.BtnSizePicker.TabIndex = 2;
            this.BtnSizePicker.UseVisualStyleBackColor = false;
            this.BtnSizePicker.Click += new System.EventHandler(this.BtnSizePicker_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BtnColorPicker);
            this.groupBox2.Location = new System.Drawing.Point(5, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(58, 74);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Color";
            // 
            // BtnColorPicker
            // 
            this.BtnColorPicker.BackColor = System.Drawing.Color.Black;
            this.BtnColorPicker.Location = new System.Drawing.Point(0, 7);
            this.BtnColorPicker.Name = "BtnColorPicker";
            this.BtnColorPicker.Size = new System.Drawing.Size(56, 43);
            this.BtnColorPicker.TabIndex = 2;
            this.BtnColorPicker.UseVisualStyleBackColor = false;
            this.BtnColorPicker.Click += new System.EventHandler(this.BtnColorPicker_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(943, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "REVISAR PLANO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplitEstatus
            // 
            this.SplitEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitEstatus.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitEstatus.Location = new System.Drawing.Point(0, 22);
            this.SplitEstatus.Name = "SplitEstatus";
            this.SplitEstatus.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitEstatus.Panel1
            // 
            this.SplitEstatus.Panel1.Controls.Add(this.SplitPlano);
            // 
            // SplitEstatus.Panel2
            // 
            this.SplitEstatus.Panel2.Controls.Add(this.TxtEstatus);
            this.SplitEstatus.Panel2.Controls.Add(this.Progreso);
            this.SplitEstatus.Size = new System.Drawing.Size(943, 669);
            this.SplitEstatus.SplitterDistance = 640;
            this.SplitEstatus.TabIndex = 3;
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEstatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 0);
            this.TxtEstatus.Multiline = true;
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(943, 2);
            this.TxtEstatus.TabIndex = 10;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 2);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(943, 23);
            this.Progreso.TabIndex = 9;
            // 
            // BkgDescargarPlano
            // 
            this.BkgDescargarPlano.WorkerReportsProgress = true;
            this.BkgDescargarPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPlano_DoWork);
            this.BkgDescargarPlano.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarPlano_ProgressChanged);
            this.BkgDescargarPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarPlano_RunWorkerCompleted);
            // 
            // BkgDescargarCP
            // 
            this.BkgDescargarCP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarCP_DoWork);
            this.BkgDescargarCP.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarCP_RunWorkerCompleted);
            // 
            // BkgGuardarImagen
            // 
            this.BkgGuardarImagen.WorkerReportsProgress = true;
            this.BkgGuardarImagen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgGuardarImagen_DoWork);
            this.BkgGuardarImagen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgGuardarImagen_RunWorkerCompleted);
            // 
            // vistaGeneralToolStripMenuItem
            // 
            this.vistaGeneralToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Zoom_Out_icon;
            this.vistaGeneralToolStripMenuItem.Name = "vistaGeneralToolStripMenuItem";
            this.vistaGeneralToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.vistaGeneralToolStripMenuItem.Text = "Vista general";
            this.vistaGeneralToolStripMenuItem.Click += new System.EventHandler(this.vistaGeneralToolStripMenuItem_Click);
            // 
            // vistaDetalladaToolStripMenuItem
            // 
            this.vistaDetalladaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Zoom_In_icon;
            this.vistaDetalladaToolStripMenuItem.Name = "vistaDetalladaToolStripMenuItem";
            this.vistaDetalladaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.vistaDetalladaToolStripMenuItem.Text = "Vista detallada";
            this.vistaDetalladaToolStripMenuItem.Click += new System.EventHandler(this.vistaDetalladaToolStripMenuItem_Click);
            // 
            // FrmRevisarDrawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 691);
            this.Controls.Add(this.SplitEstatus);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRevisarDrawing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Revisar plano";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRevisarDrawing_FormClosing);
            this.Load += new System.EventHandler(this.FrmRevisarDrawing_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).EndInit();
            this.SplitPlano.Panel1.ResumeLayout(false);
            this.SplitPlano.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPlano)).EndInit();
            this.SplitPlano.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomProperties)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.SplitEstatus.Panel1.ResumeLayout(false);
            this.SplitEstatus.Panel2.ResumeLayout(false);
            this.SplitEstatus.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitEstatus)).EndInit();
            this.SplitEstatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicPlano;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer SplitPlano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer SplitEstatus;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlano;
      //  private System.Windows.Forms.ContextMenuStrip MenuPlano;
        private System.Windows.Forms.ToolStripMenuItem vistaGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vistaDetalladaToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgDescargarCP;
        private System.Windows.Forms.Button BtnColorPicker;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvCustomProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn propiedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Button BtnComentarios;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnRechazar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSizePicker;
        private System.ComponentModel.BackgroundWorker BkgGuardarImagen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnClean;
        private System.ComponentModel.BackgroundWorker BkgRenombrarArchivos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label LblEditar;
        private System.Windows.Forms.Button BtnEditar;
    }
}
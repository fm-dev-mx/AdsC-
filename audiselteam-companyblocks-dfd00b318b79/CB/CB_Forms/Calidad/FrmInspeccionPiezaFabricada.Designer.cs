namespace CB
{
    partial class FrmInspeccionPiezaFabricada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PicPlano = new System.Windows.Forms.PictureBox();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnRechazar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.DgvProcesos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_ok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_nok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
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
            this.LblInspeccion = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.BkgDescargarPlano = new System.ComponentModel.BackgroundWorker();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.BkgSubirPlano = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PicPlano);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TxtComentarios);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.DgvProcesos);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.LblInspeccion);
            this.splitContainer1.Size = new System.Drawing.Size(1069, 591);
            this.splitContainer1.SplitterDistance = 714;
            this.splitContainer1.TabIndex = 0;
            // 
            // PicPlano
            // 
            this.PicPlano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPlano.Location = new System.Drawing.Point(0, 0);
            this.PicPlano.Name = "PicPlano";
            this.PicPlano.Size = new System.Drawing.Size(714, 591);
            this.PicPlano.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicPlano.TabIndex = 1;
            this.PicPlano.TabStop = false;
            this.PicPlano.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicPlano_MouseDown);
            this.PicPlano.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPlano_MouseMove);
            this.PicPlano.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicPlano_MouseUp);
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtComentarios.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(0, 367);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentarios.Size = new System.Drawing.Size(351, 164);
            this.TxtComentarios.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 27);
            this.label2.TabIndex = 35;
            this.label2.Text = "COMENTARIOS DE REVISION:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnRechazar);
            this.panel1.Controls.Add(this.BtnAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 60);
            this.panel1.TabIndex = 31;
            // 
            // BtnRechazar
            // 
            this.BtnRechazar.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRechazar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnRechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRechazar.Location = new System.Drawing.Point(0, 0);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(174, 60);
            this.BtnRechazar.TabIndex = 30;
            this.BtnRechazar.Text = "Rechazar";
            this.BtnRechazar.UseVisualStyleBackColor = true;
            this.BtnRechazar.Click += new System.EventHandler(this.BtnRechazar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(176, 0);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(175, 60);
            this.BtnAceptar.TabIndex = 29;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // DgvProcesos
            // 
            this.DgvProcesos.AllowUserToAddRows = false;
            this.DgvProcesos.AllowUserToResizeRows = false;
            this.DgvProcesos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DgvProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProcesos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.check,
            this.id_proceso,
            this.comentario,
            this.cantidad_ok,
            this.cantidad_nok,
            this.tipo});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesos.DefaultCellStyle = dataGridViewCellStyle19;
            this.DgvProcesos.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvProcesos.Location = new System.Drawing.Point(0, 167);
            this.DgvProcesos.MultiSelect = false;
            this.DgvProcesos.Name = "DgvProcesos";
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesos.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DgvProcesos.RowHeadersVisible = false;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesos.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.DgvProcesos.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProcesos.Size = new System.Drawing.Size(351, 173);
            this.DgvProcesos.TabIndex = 0;
            this.DgvProcesos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProcesos_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // check
            // 
            this.check.FalseValue = "false";
            this.check.HeaderText = "";
            this.check.MinimumWidth = 30;
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.TrueValue = "true";
            this.check.Width = 30;
            // 
            // id_proceso
            // 
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id_proceso.DefaultCellStyle = dataGridViewCellStyle16;
            this.id_proceso.HeaderText = "Proceso";
            this.id_proceso.Name = "id_proceso";
            this.id_proceso.ReadOnly = true;
            // 
            // comentario
            // 
            this.comentario.HeaderText = "Defecto";
            this.comentario.Name = "comentario";
            this.comentario.ReadOnly = true;
            // 
            // cantidad_ok
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad_ok.DefaultCellStyle = dataGridViewCellStyle17;
            this.cantidad_ok.HeaderText = "Cantidad OK";
            this.cantidad_ok.MinimumWidth = 60;
            this.cantidad_ok.Name = "cantidad_ok";
            this.cantidad_ok.ReadOnly = true;
            this.cantidad_ok.Width = 60;
            // 
            // cantidad_nok
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad_nok.DefaultCellStyle = dataGridViewCellStyle18;
            this.cantidad_nok.HeaderText = "Cantidad NOK";
            this.cantidad_nok.MinimumWidth = 60;
            this.cantidad_nok.Name = "cantidad_nok";
            this.cantidad_nok.ReadOnly = true;
            this.cantidad_nok.Width = 60;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "PROCESOS CON DEFECTOS:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 23);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(351, 118);
            this.splitContainer2.SplitterDistance = 29;
            this.splitContainer2.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(351, 29);
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
            this.BtnClean.Click += new System.EventHandler(this.BtnClean_Click);
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
            this.BtnColorPicker.BackColor = System.Drawing.Color.Red;
            this.BtnColorPicker.Enabled = false;
            this.BtnColorPicker.Location = new System.Drawing.Point(0, 7);
            this.BtnColorPicker.Name = "BtnColorPicker";
            this.BtnColorPicker.Size = new System.Drawing.Size(56, 43);
            this.BtnColorPicker.TabIndex = 2;
            this.BtnColorPicker.UseVisualStyleBackColor = false;
            this.BtnColorPicker.Click += new System.EventHandler(this.BtnColorPicker_Click);
            // 
            // LblInspeccion
            // 
            this.LblInspeccion.BackColor = System.Drawing.Color.Navy;
            this.LblInspeccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblInspeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInspeccion.ForeColor = System.Drawing.Color.White;
            this.LblInspeccion.Location = new System.Drawing.Point(0, 0);
            this.LblInspeccion.Name = "LblInspeccion";
            this.LblInspeccion.Size = new System.Drawing.Size(351, 23);
            this.LblInspeccion.TabIndex = 13;
            this.LblInspeccion.Text = "INSPECCION DE";
            this.LblInspeccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1069, 23);
            this.LblTitulo.TabIndex = 11;
            this.LblTitulo.Text = "INSPECCIONAR PIEZA FABRICADA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 643);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(1069, 23);
            this.Progreso.TabIndex = 14;
            // 
            // BkgDescargarPlano
            // 
            this.BkgDescargarPlano.WorkerReportsProgress = true;
            this.BkgDescargarPlano.WorkerSupportsCancellation = true;
            this.BkgDescargarPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPlano_DoWork);
            this.BkgDescargarPlano.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarPlano_ProgressChanged);
            this.BkgDescargarPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarPlano_RunWorkerCompleted);
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtEstatus.ForeColor = System.Drawing.Color.Lime;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 614);
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(1069, 29);
            this.TxtEstatus.TabIndex = 11;
            this.TxtEstatus.Text = "Estatus...";
            this.TxtEstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BkgSubirPlano
            // 
            this.BkgSubirPlano.WorkerReportsProgress = true;
            this.BkgSubirPlano.WorkerSupportsCancellation = true;
            this.BkgSubirPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubirPlano_DoWork);
            this.BkgSubirPlano.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubirPlano_ProgressChanged);
            this.BkgSubirPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubirPlano_RunWorkerCompleted);
            // 
            // FrmInspeccionPiezaFabricada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 666);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.TxtEstatus);
            this.Controls.Add(this.Progreso);
            this.Name = "FrmInspeccionPiezaFabricada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspeccionar pieza fabricada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInspeccionPiezaFabricada_FormClosing);
            this.Load += new System.EventHandler(this.FrmInspeccionPiezaFabricada_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInspeccionPiezaFabricada_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesos)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvProcesos;
        private System.Windows.Forms.Label LblInspeccion;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnRechazar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label LblEditar;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnClean;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSizePicker;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnColorPicker;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlano;
        private System.Windows.Forms.PictureBox PicPlano;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_nok;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.ComponentModel.BackgroundWorker BkgSubirPlano;
    }
}
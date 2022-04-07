namespace CB
{
    partial class FrmProcesosFabricacionAsignados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcesosFabricacionAsignados));
            this.LblTitulo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PicPlano = new System.Windows.Forms.PictureBox();
            this.LblEstatusProgreso = new System.Windows.Forms.Label();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CmbProcesos = new System.Windows.Forms.ComboBox();
            this.lblComboBox = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.LblOperador = new System.Windows.Forms.Label();
            this.TxtEscanearPlano = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DgvTiempoMuerto = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_muerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnTerminar = new System.Windows.Forms.Button();
            this.BtnDetener = new System.Windows.Forms.Button();
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblTotalProduccion = new System.Windows.Forms.Label();
            this.LblHrsProduccion = new System.Windows.Forms.Label();
            this.LblTiempoMuerto = new System.Windows.Forms.Label();
            this.LblTiempoMeta = new System.Windows.Forms.Label();
            this.LblFechaInicio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.LblIdProceso = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.BkgDescargarPlano = new System.ComponentModel.BackgroundWorker();
            this.TimerOpciones = new System.Windows.Forms.Timer(this.components);
            this.ListaImagenesEstatusProcesos = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTiempoMuerto)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1353, 27);
            this.LblTitulo.TabIndex = 2;
            this.LblTitulo.Text = "PROCESOS DE FABRICACION ASIGNADOS";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PicPlano);
            this.splitContainer1.Panel1.Controls.Add(this.LblEstatusProgreso);
            this.splitContainer1.Panel1.Controls.Add(this.Progreso);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BtnTerminar);
            this.splitContainer1.Panel2.Controls.Add(this.BtnDetener);
            this.splitContainer1.Panel2.Controls.Add(this.BtnIniciar);
            this.splitContainer1.Panel2.Controls.Add(this.TxtComentarios);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.LblTotalProduccion);
            this.splitContainer1.Panel2.Controls.Add(this.LblHrsProduccion);
            this.splitContainer1.Panel2.Controls.Add(this.LblTiempoMuerto);
            this.splitContainer1.Panel2.Controls.Add(this.LblTiempoMeta);
            this.splitContainer1.Panel2.Controls.Add(this.LblFechaInicio);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.LblEstatus);
            this.splitContainer1.Panel2.Controls.Add(this.LblIdProceso);
            this.splitContainer1.Panel2.Controls.Add(this.lblTimer);
            this.splitContainer1.Size = new System.Drawing.Size(1353, 702);
            this.splitContainer1.SplitterDistance = 743;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // PicPlano
            // 
            this.PicPlano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPlano.Location = new System.Drawing.Point(0, 155);
            this.PicPlano.Name = "PicPlano";
            this.PicPlano.Size = new System.Drawing.Size(743, 265);
            this.PicPlano.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicPlano.TabIndex = 0;
            this.PicPlano.TabStop = false;
            this.PicPlano.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // LblEstatusProgreso
            // 
            this.LblEstatusProgreso.BackColor = System.Drawing.Color.Black;
            this.LblEstatusProgreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusProgreso.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusProgreso.Location = new System.Drawing.Point(0, 420);
            this.LblEstatusProgreso.Name = "LblEstatusProgreso";
            this.LblEstatusProgreso.Size = new System.Drawing.Size(743, 25);
            this.LblEstatusProgreso.TabIndex = 18;
            this.LblEstatusProgreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 445);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(743, 27);
            this.Progreso.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 155);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CmbProcesos);
            this.panel3.Controls.Add(this.lblComboBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(743, 83);
            this.panel3.TabIndex = 23;
            // 
            // CmbProcesos
            // 
            this.CmbProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbProcesos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbProcesos.DropDownHeight = 206;
            this.CmbProcesos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProcesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProcesos.FormattingEnabled = true;
            this.CmbProcesos.IntegralHeight = false;
            this.CmbProcesos.ItemHeight = 42;
            this.CmbProcesos.Location = new System.Drawing.Point(0, 25);
            this.CmbProcesos.Name = "CmbProcesos";
            this.CmbProcesos.Size = new System.Drawing.Size(743, 48);
            this.CmbProcesos.TabIndex = 0;
            this.CmbProcesos.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CmbProcesos_DrawItem);
            this.CmbProcesos.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.CmbProcesos_MeasureItem);
            this.CmbProcesos.SelectedIndexChanged += new System.EventHandler(this.CmbProcesos_SelectedIndexChanged);
            this.CmbProcesos.DropDownClosed += new System.EventHandler(this.CmbProcesos_DropDownClosed);
            this.CmbProcesos.MouseLeave += new System.EventHandler(this.CmbProcesos_MouseLeave);
            // 
            // lblComboBox
            // 
            this.lblComboBox.AutoSize = true;
            this.lblComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComboBox.Location = new System.Drawing.Point(0, 0);
            this.lblComboBox.Name = "lblComboBox";
            this.lblComboBox.Size = new System.Drawing.Size(252, 25);
            this.lblComboBox.TabIndex = 1;
            this.lblComboBox.Text = "Seleccione el proceso:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.LblOperador);
            this.splitContainer2.Panel1.Controls.Add(this.TxtEscanearPlano);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.BtnSalir);
            this.splitContainer2.Size = new System.Drawing.Size(743, 72);
            this.splitContainer2.SplitterDistance = 620;
            this.splitContainer2.TabIndex = 22;
            // 
            // LblOperador
            // 
            this.LblOperador.BackColor = System.Drawing.SystemColors.Control;
            this.LblOperador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOperador.ForeColor = System.Drawing.Color.Black;
            this.LblOperador.Location = new System.Drawing.Point(0, 18);
            this.LblOperador.Name = "LblOperador";
            this.LblOperador.Size = new System.Drawing.Size(620, 54);
            this.LblOperador.TabIndex = 22;
            this.LblOperador.Text = "10021 | MANUEL MARTINEZ";
            // 
            // TxtEscanearPlano
            // 
            this.TxtEscanearPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEscanearPlano.Location = new System.Drawing.Point(0, 18);
            this.TxtEscanearPlano.Name = "TxtEscanearPlano";
            this.TxtEscanearPlano.Size = new System.Drawing.Size(193, 40);
            this.TxtEscanearPlano.TabIndex = 20;
            this.TxtEscanearPlano.TextChanged += new System.EventHandler(this.TxtEscanearPlano_TextChanged);
            this.TxtEscanearPlano.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEscanear_KeyDown);
            this.TxtEscanearPlano.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEscanearPlano_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Escanear plano";
            this.label3.Visible = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(119, 72);
            this.BtnSalir.TabIndex = 19;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DgvTiempoMuerto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 472);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 230);
            this.panel1.TabIndex = 1;
            // 
            // DgvTiempoMuerto
            // 
            this.DgvTiempoMuerto.AllowUserToAddRows = false;
            this.DgvTiempoMuerto.AllowUserToDeleteRows = false;
            this.DgvTiempoMuerto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTiempoMuerto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvTiempoMuerto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTiempoMuerto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.hora_inicio,
            this.hora_fin,
            this.razon,
            this.tiempo_muerto});
            this.DgvTiempoMuerto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTiempoMuerto.Location = new System.Drawing.Point(0, 39);
            this.DgvTiempoMuerto.Name = "DgvTiempoMuerto";
            this.DgvTiempoMuerto.RowHeadersVisible = false;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTiempoMuerto.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvTiempoMuerto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTiempoMuerto.Size = new System.Drawing.Size(743, 191);
            this.DgvTiempoMuerto.TabIndex = 4;
            this.DgvTiempoMuerto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTiempoMuerto_CellClick);
            // 
            // id
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // hora_inicio
            // 
            this.hora_inicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hora_inicio.DefaultCellStyle = dataGridViewCellStyle3;
            this.hora_inicio.HeaderText = "Hora inicio";
            this.hora_inicio.Name = "hora_inicio";
            this.hora_inicio.ReadOnly = true;
            // 
            // hora_fin
            // 
            this.hora_fin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hora_fin.DefaultCellStyle = dataGridViewCellStyle4;
            this.hora_fin.HeaderText = "Hora de finalización";
            this.hora_fin.Name = "hora_fin";
            this.hora_fin.ReadOnly = true;
            // 
            // razon
            // 
            this.razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.razon.DefaultCellStyle = dataGridViewCellStyle5;
            this.razon.HeaderText = "Razón por la que se interrumpió";
            this.razon.Name = "razon";
            this.razon.ReadOnly = true;
            // 
            // tiempo_muerto
            // 
            this.tiempo_muerto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_muerto.DefaultCellStyle = dataGridViewCellStyle6;
            this.tiempo_muerto.HeaderText = "Tiempo muerto";
            this.tiempo_muerto.Name = "tiempo_muerto";
            this.tiempo_muerto.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(743, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "HISTORIAL DE TIEMPO MUERTO:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnTerminar
            // 
            this.BtnTerminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTerminar.Image = global::CB_Base.Properties.Resources.ok_48;
            this.BtnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTerminar.Location = new System.Drawing.Point(0, 611);
            this.BtnTerminar.Name = "BtnTerminar";
            this.BtnTerminar.Size = new System.Drawing.Size(606, 77);
            this.BtnTerminar.TabIndex = 9;
            this.BtnTerminar.Text = "       Terminar";
            this.BtnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTerminar.UseVisualStyleBackColor = true;
            this.BtnTerminar.Click += new System.EventHandler(this.BtnTerminar_Click);
            this.BtnTerminar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // BtnDetener
            // 
            this.BtnDetener.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnDetener.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDetener.Image = global::CB_Base.Properties.Resources.stop_48;
            this.BtnDetener.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDetener.Location = new System.Drawing.Point(0, 534);
            this.BtnDetener.Name = "BtnDetener";
            this.BtnDetener.Size = new System.Drawing.Size(606, 77);
            this.BtnDetener.TabIndex = 8;
            this.BtnDetener.Text = "       Detener";
            this.BtnDetener.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDetener.UseVisualStyleBackColor = true;
            this.BtnDetener.Click += new System.EventHandler(this.BtnDetener_Click);
            this.BtnDetener.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIniciar.Image = global::CB_Base.Properties.Resources.start_48;
            this.BtnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIniciar.Location = new System.Drawing.Point(0, 457);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(606, 77);
            this.BtnIniciar.TabIndex = 11;
            this.BtnIniciar.Text = "       Iniciar";
            this.BtnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIniciar.UseVisualStyleBackColor = true;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            this.BtnIniciar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(0, 325);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ReadOnly = true;
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentarios.Size = new System.Drawing.Size(606, 132);
            this.TxtComentarios.TabIndex = 4;
            this.TxtComentarios.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(606, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "COMENTARIOS DEL SUPERVISOR:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // LblTotalProduccion
            // 
            this.LblTotalProduccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTotalProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalProduccion.Location = new System.Drawing.Point(0, 260);
            this.LblTotalProduccion.Name = "LblTotalProduccion";
            this.LblTotalProduccion.Size = new System.Drawing.Size(606, 35);
            this.LblTotalProduccion.TabIndex = 16;
            this.LblTotalProduccion.Text = "Tiempo total: 0 hrs";
            this.LblTotalProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTotalProduccion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // LblHrsProduccion
            // 
            this.LblHrsProduccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblHrsProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHrsProduccion.Location = new System.Drawing.Point(0, 225);
            this.LblHrsProduccion.Name = "LblHrsProduccion";
            this.LblHrsProduccion.Size = new System.Drawing.Size(606, 35);
            this.LblHrsProduccion.TabIndex = 15;
            this.LblHrsProduccion.Text = "Tiempo de producción: 0 hrs";
            this.LblHrsProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblHrsProduccion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // LblTiempoMuerto
            // 
            this.LblTiempoMuerto.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTiempoMuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTiempoMuerto.Location = new System.Drawing.Point(0, 190);
            this.LblTiempoMuerto.Name = "LblTiempoMuerto";
            this.LblTiempoMuerto.Size = new System.Drawing.Size(606, 35);
            this.LblTiempoMuerto.TabIndex = 14;
            this.LblTiempoMuerto.Text = "Tiempo muerto: 0 hrs";
            this.LblTiempoMuerto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTiempoMuerto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // LblTiempoMeta
            // 
            this.LblTiempoMeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTiempoMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTiempoMeta.ForeColor = System.Drawing.Color.Navy;
            this.LblTiempoMeta.Location = new System.Drawing.Point(0, 155);
            this.LblTiempoMeta.Name = "LblTiempoMeta";
            this.LblTiempoMeta.Size = new System.Drawing.Size(606, 35);
            this.LblTiempoMeta.TabIndex = 19;
            this.LblTiempoMeta.Text = "Tiempo estimado (meta):";
            this.LblTiempoMeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTiempoMeta.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // LblFechaInicio
            // 
            this.LblFechaInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFechaInicio.Location = new System.Drawing.Point(0, 120);
            this.LblFechaInicio.Name = "LblFechaInicio";
            this.LblFechaInicio.Size = new System.Drawing.Size(606, 35);
            this.LblFechaInicio.TabIndex = 12;
            this.LblFechaInicio.Text = "Fecha inicio:  Jun 24, 2019 5:35";
            this.LblFechaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblFechaInicio.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(606, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "DATOS DE PRODUCCION:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // LblEstatus
            // 
            this.LblEstatus.BackColor = System.Drawing.Color.Black;
            this.LblEstatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.ForeColor = System.Drawing.Color.Yellow;
            this.LblEstatus.Location = new System.Drawing.Point(0, 58);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(606, 30);
            this.LblEstatus.TabIndex = 5;
            this.LblEstatus.Text = "PENDIENTE";
            this.LblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblEstatus.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // LblIdProceso
            // 
            this.LblIdProceso.BackColor = System.Drawing.Color.Navy;
            this.LblIdProceso.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblIdProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIdProceso.ForeColor = System.Drawing.Color.White;
            this.LblIdProceso.Location = new System.Drawing.Point(0, 24);
            this.LblIdProceso.Name = "LblIdProceso";
            this.LblIdProceso.Size = new System.Drawing.Size(606, 34);
            this.LblIdProceso.TabIndex = 10;
            this.LblIdProceso.Text = "00321 | FRESADO CONVENCIONAL";
            this.LblIdProceso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblIdProceso.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblFechaInicio_MouseMove);
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.Color.Black;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Yellow;
            this.lblTimer.Location = new System.Drawing.Point(0, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(606, 24);
            this.lblTimer.TabIndex = 17;
            this.lblTimer.Text = "123456";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BkgDescargarPlano
            // 
            this.BkgDescargarPlano.WorkerReportsProgress = true;
            this.BkgDescargarPlano.WorkerSupportsCancellation = true;
            this.BkgDescargarPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPlano_DoWork);
            this.BkgDescargarPlano.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarPlano_ProgressChanged);
            this.BkgDescargarPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarPlano_RunWorkerCompleted);
            // 
            // ListaImagenesEstatusProcesos
            // 
            this.ListaImagenesEstatusProcesos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListaImagenesEstatusProcesos.ImageStream")));
            this.ListaImagenesEstatusProcesos.TransparentColor = System.Drawing.Color.Transparent;
            this.ListaImagenesEstatusProcesos.Images.SetKeyName(0, "en-proceso-a-tiempo-24.png");
            this.ListaImagenesEstatusProcesos.Images.SetKeyName(1, "pendiente-tarde-24.png");
            this.ListaImagenesEstatusProcesos.Images.SetKeyName(2, "detenido-limite.png");
            // 
            // FrmProcesosFabricacionAsignados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 729);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProcesosFabricacionAsignados";
            this.Text = "FrmOpcionesProceso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOpcionesProceso_FormClosing);
            this.Load += new System.EventHandler(this.FrmOpcionesProceso_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTiempoMuerto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox PicPlano;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnDetener;
        private System.Windows.Forms.Button BtnTerminar;
        private System.Windows.Forms.Label LblIdProceso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvTiempoMuerto;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlano;
        private System.Windows.Forms.Button BtnIniciar;
        private System.Windows.Forms.Label LblTotalProduccion;
        private System.Windows.Forms.Label LblHrsProduccion;
        private System.Windows.Forms.Label LblTiempoMuerto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblFechaInicio;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label LblTiempoMeta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblComboBox;
        private System.Windows.Forms.ComboBox CmbProcesos;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TextBox TxtEscanearPlano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblEstatusProgreso;
        private System.Windows.Forms.Timer TimerOpciones;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn razon;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_muerto;
        private System.Windows.Forms.Label LblOperador;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.ImageList ListaImagenesEstatusProcesos;

    }
}
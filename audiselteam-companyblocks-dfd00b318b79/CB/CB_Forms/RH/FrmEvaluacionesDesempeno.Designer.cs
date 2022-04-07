namespace CB
{
    partial class FrmEvaluacionesDesempeno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvaluacionesDesempeno));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbEvaluaciones = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LblPuntuacion = new System.Windows.Forms.Label();
            this.TxtPuestoBajoEvaluacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DgvHabilidadesPersonales = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgvHabilidadesTecnicas = new System.Windows.Forms.DataGridView();
            this.ImagenesTabs = new System.Windows.Forms.ImageList(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.LblPuntuacionEvaluacion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtEvaluador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtPuestoEvaluador = new System.Windows.Forms.TextBox();
            this.id_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_habilidad_tecnica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_desempeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesPersonales)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesTecnicas)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(993, 23);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "EVALUACIONES DE DESEMPEÑO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(993, 429);
            this.splitContainer1.SplitterDistance = 126;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CmbEvaluaciones);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.TxtPuestoBajoEvaluacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 127);
            this.panel1.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 13);
            this.label5.TabIndex = 122;
            this.label5.Text = "Selecciona una evaluación específica:";
            // 
            // CmbEvaluaciones
            // 
            this.CmbEvaluaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEvaluaciones.Enabled = false;
            this.CmbEvaluaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEvaluaciones.FormattingEnabled = true;
            this.CmbEvaluaciones.Location = new System.Drawing.Point(12, 82);
            this.CmbEvaluaciones.Name = "CmbEvaluaciones";
            this.CmbEvaluaciones.Size = new System.Drawing.Size(316, 32);
            this.CmbEvaluaciones.TabIndex = 121;
            this.CmbEvaluaciones.SelectedIndexChanged += new System.EventHandler(this.CmbEvaluaciones_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.LblPuntuacion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(832, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(161, 127);
            this.panel3.TabIndex = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "Promedio de desempeño:";
            // 
            // LblPuntuacion
            // 
            this.LblPuntuacion.AutoSize = true;
            this.LblPuntuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuntuacion.ForeColor = System.Drawing.Color.Red;
            this.LblPuntuacion.Location = new System.Drawing.Point(48, 27);
            this.LblPuntuacion.Name = "LblPuntuacion";
            this.LblPuntuacion.Size = new System.Drawing.Size(65, 37);
            this.LblPuntuacion.TabIndex = 117;
            this.LblPuntuacion.Text = "0%";
            // 
            // TxtPuestoBajoEvaluacion
            // 
            this.TxtPuestoBajoEvaluacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPuestoBajoEvaluacion.Location = new System.Drawing.Point(334, 24);
            this.TxtPuestoBajoEvaluacion.Name = "TxtPuestoBajoEvaluacion";
            this.TxtPuestoBajoEvaluacion.ReadOnly = true;
            this.TxtPuestoBajoEvaluacion.Size = new System.Drawing.Size(312, 29);
            this.TxtPuestoBajoEvaluacion.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "Puesto:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(12, 24);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ReadOnly = true;
            this.TxtNombre.Size = new System.Drawing.Size(316, 29);
            this.TxtNombre.TabIndex = 113;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "Bajo evaluación:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.ImagenesTabs;
            this.tabControl1.Location = new System.Drawing.Point(0, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(993, 215);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgvHabilidadesPersonales);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(985, 172);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Competencias personales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DgvHabilidadesPersonales
            // 
            this.DgvHabilidadesPersonales.AllowUserToAddRows = false;
            this.DgvHabilidadesPersonales.AllowUserToDeleteRows = false;
            this.DgvHabilidadesPersonales.AllowUserToResizeRows = false;
            this.DgvHabilidadesPersonales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvHabilidadesPersonales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHabilidadesPersonales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_habilidad_personal,
            this.habilidad_personal,
            this.descripcion_habilidad_personal,
            this.comentarios_habilidad_personal,
            this.nivel_habilidad_personal});
            this.DgvHabilidadesPersonales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHabilidadesPersonales.Location = new System.Drawing.Point(3, 3);
            this.DgvHabilidadesPersonales.Name = "DgvHabilidadesPersonales";
            this.DgvHabilidadesPersonales.RowHeadersVisible = false;
            this.DgvHabilidadesPersonales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHabilidadesPersonales.Size = new System.Drawing.Size(979, 166);
            this.DgvHabilidadesPersonales.TabIndex = 0;
            this.DgvHabilidadesPersonales.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvHabilidadesPersonales_CellFormatting);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgvHabilidadesTecnicas);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 172);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Competencias técnicas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DgvHabilidadesTecnicas
            // 
            this.DgvHabilidadesTecnicas.AllowUserToAddRows = false;
            this.DgvHabilidadesTecnicas.AllowUserToDeleteRows = false;
            this.DgvHabilidadesTecnicas.AllowUserToResizeRows = false;
            this.DgvHabilidadesTecnicas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvHabilidadesTecnicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHabilidadesTecnicas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.comentarios_habilidad_tecnica,
            this.nivel_desempeno});
            this.DgvHabilidadesTecnicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHabilidadesTecnicas.Location = new System.Drawing.Point(3, 3);
            this.DgvHabilidadesTecnicas.Name = "DgvHabilidadesTecnicas";
            this.DgvHabilidadesTecnicas.RowHeadersVisible = false;
            this.DgvHabilidadesTecnicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHabilidadesTecnicas.Size = new System.Drawing.Size(979, 166);
            this.DgvHabilidadesTecnicas.TabIndex = 1;
            this.DgvHabilidadesTecnicas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvHabilidadesTecnicas_CellFormatting);
            // 
            // ImagenesTabs
            // 
            this.ImagenesTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTabs.ImageStream")));
            this.ImagenesTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTabs.Images.SetKeyName(0, "user.png");
            this.ImagenesTabs.Images.SetKeyName(1, "tool-box-32.png");
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DimGray;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(993, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "RESULTADOS DE LA EVALUACION SELECCIONADA";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.LblPuntuacionEvaluacion);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TxtEvaluador);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.TxtPuestoEvaluador);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 65);
            this.panel2.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(670, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 125;
            this.label8.Text = "Resultado de la evaluación:";
            // 
            // LblPuntuacionEvaluacion
            // 
            this.LblPuntuacionEvaluacion.AutoSize = true;
            this.LblPuntuacionEvaluacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuntuacionEvaluacion.ForeColor = System.Drawing.Color.Red;
            this.LblPuntuacionEvaluacion.Location = new System.Drawing.Point(817, 16);
            this.LblPuntuacionEvaluacion.Name = "LblPuntuacionEvaluacion";
            this.LblPuntuacionEvaluacion.Size = new System.Drawing.Size(65, 37);
            this.LblPuntuacionEvaluacion.TabIndex = 126;
            this.LblPuntuacionEvaluacion.Text = "0%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 123;
            this.label4.Text = "Puesto:";
            // 
            // TxtEvaluador
            // 
            this.TxtEvaluador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEvaluador.Location = new System.Drawing.Point(12, 27);
            this.TxtEvaluador.Name = "TxtEvaluador";
            this.TxtEvaluador.ReadOnly = true;
            this.TxtEvaluador.Size = new System.Drawing.Size(316, 29);
            this.TxtEvaluador.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Evaluador:";
            // 
            // TxtPuestoEvaluador
            // 
            this.TxtPuestoEvaluador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPuestoEvaluador.Location = new System.Drawing.Point(334, 27);
            this.TxtPuestoEvaluador.Name = "TxtPuestoEvaluador";
            this.TxtPuestoEvaluador.ReadOnly = true;
            this.TxtPuestoEvaluador.Size = new System.Drawing.Size(312, 29);
            this.TxtPuestoEvaluador.TabIndex = 124;
            // 
            // id_habilidad_personal
            // 
            this.id_habilidad_personal.HeaderText = "ID Habilidad Personal";
            this.id_habilidad_personal.Name = "id_habilidad_personal";
            this.id_habilidad_personal.ReadOnly = true;
            this.id_habilidad_personal.Visible = false;
            this.id_habilidad_personal.Width = 50;
            // 
            // habilidad_personal
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.habilidad_personal.DefaultCellStyle = dataGridViewCellStyle1;
            this.habilidad_personal.HeaderText = "Competencia";
            this.habilidad_personal.Name = "habilidad_personal";
            this.habilidad_personal.ReadOnly = true;
            this.habilidad_personal.Width = 320;
            // 
            // descripcion_habilidad_personal
            // 
            this.descripcion_habilidad_personal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle2;
            this.descripcion_habilidad_personal.HeaderText = "Descripción de la habilidad";
            this.descripcion_habilidad_personal.Name = "descripcion_habilidad_personal";
            this.descripcion_habilidad_personal.ReadOnly = true;
            this.descripcion_habilidad_personal.Visible = false;
            // 
            // comentarios_habilidad_personal
            // 
            this.comentarios_habilidad_personal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle3;
            this.comentarios_habilidad_personal.HeaderText = "Comentarios";
            this.comentarios_habilidad_personal.Name = "comentarios_habilidad_personal";
            this.comentarios_habilidad_personal.ReadOnly = true;
            // 
            // nivel_habilidad_personal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nivel_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle4;
            this.nivel_habilidad_personal.HeaderText = "Nivel de desempeño observado";
            this.nivel_habilidad_personal.Name = "nivel_habilidad_personal";
            this.nivel_habilidad_personal.ReadOnly = true;
            this.nivel_habilidad_personal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nivel_habilidad_personal.Width = 180;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID Habilidad Personal";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Competencia";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 320;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripción de la habilidad";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // comentarios_habilidad_tecnica
            // 
            this.comentarios_habilidad_tecnica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios_habilidad_tecnica.DefaultCellStyle = dataGridViewCellStyle7;
            this.comentarios_habilidad_tecnica.HeaderText = "Comentarios";
            this.comentarios_habilidad_tecnica.Name = "comentarios_habilidad_tecnica";
            // 
            // nivel_desempeno
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nivel_desempeno.DefaultCellStyle = dataGridViewCellStyle8;
            this.nivel_desempeno.HeaderText = "Nivel de desempeño observado";
            this.nivel_desempeno.Name = "nivel_desempeno";
            this.nivel_desempeno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nivel_desempeno.Width = 180;
            // 
            // FrmEvaluacionesDesempeno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 452);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmEvaluacionesDesempeno";
            this.Text = "Evaluaciones de desempeño";
            this.Load += new System.EventHandler(this.FrmEvaluacionesDesempeno_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesPersonales)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesTecnicas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbEvaluaciones;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblPuntuacion;
        private System.Windows.Forms.TextBox TxtPuestoBajoEvaluacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DgvHabilidadesPersonales;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DgvHabilidadesTecnicas;
        private System.Windows.Forms.ImageList ImagenesTabs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblPuntuacionEvaluacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtEvaluador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPuestoEvaluador;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_habilidad_tecnica;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel_desempeno;
    }
}
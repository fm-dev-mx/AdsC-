namespace CB
{
    partial class FrmEvaluarDesempeno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvaluarDesempeno));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtPuestoEvaluador = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtEvaluador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblAvance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblPuntuacion = new System.Windows.Forms.Label();
            this.TxtPuestoBajoEvaluacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DgvHabilidadesPersonales = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgvHabilidadesTecnicas = new System.Windows.Forms.DataGridView();
            this.ImagenesTabs = new System.Windows.Forms.ImageList(this.components);
            this.MenuEvaluarHabilidad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.evaluarHabilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evaluarHabilidadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.id_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_habilidad_tecnica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_habilidad_tecnica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_habilidad_tecnica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesPersonales)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesTecnicas)).BeginInit();
            this.MenuEvaluarHabilidad.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(1161, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "EVALUAR EMPLEADO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtPuestoEvaluador);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtEvaluador);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.TxtPuestoBajoEvaluacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 116);
            this.panel1.TabIndex = 7;
            // 
            // TxtPuestoEvaluador
            // 
            this.TxtPuestoEvaluador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPuestoEvaluador.Location = new System.Drawing.Point(334, 75);
            this.TxtPuestoEvaluador.Name = "TxtPuestoEvaluador";
            this.TxtPuestoEvaluador.ReadOnly = true;
            this.TxtPuestoEvaluador.Size = new System.Drawing.Size(312, 29);
            this.TxtPuestoEvaluador.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 123;
            this.label4.Text = "Puesto:";
            // 
            // TxtEvaluador
            // 
            this.TxtEvaluador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEvaluador.Location = new System.Drawing.Point(12, 75);
            this.TxtEvaluador.Name = "TxtEvaluador";
            this.TxtEvaluador.ReadOnly = true;
            this.TxtEvaluador.Size = new System.Drawing.Size(316, 29);
            this.TxtEvaluador.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Evaluador:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LblAvance);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.LblPuntuacion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(900, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 116);
            this.panel3.TabIndex = 120;
            // 
            // LblAvance
            // 
            this.LblAvance.AutoSize = true;
            this.LblAvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAvance.Location = new System.Drawing.Point(31, 24);
            this.LblAvance.Name = "LblAvance";
            this.LblAvance.Size = new System.Drawing.Size(71, 37);
            this.LblAvance.TabIndex = 119;
            this.LblAvance.Text = "0/N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "Puntuación actual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 118;
            this.label5.Text = "Habilidades evaluadas:";
            // 
            // LblPuntuacion
            // 
            this.LblPuntuacion.AutoSize = true;
            this.LblPuntuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuntuacion.ForeColor = System.Drawing.Color.Red;
            this.LblPuntuacion.Location = new System.Drawing.Point(155, 24);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnFinalizar);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 424);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1161, 63);
            this.panel2.TabIndex = 8;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(900, 0);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(124, 63);
            this.BtnFinalizar.TabIndex = 123;
            this.BtnFinalizar.Text = "      Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1024, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 63);
            this.BtnSalir.TabIndex = 122;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.ImagenesTabs;
            this.tabControl1.Location = new System.Drawing.Point(0, 139);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1161, 285);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgvHabilidadesPersonales);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1153, 242);
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
            this.DgvHabilidadesPersonales.Size = new System.Drawing.Size(1147, 236);
            this.DgvHabilidadesPersonales.TabIndex = 0;
            this.DgvHabilidadesPersonales.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvHabilidadesPersonales_CellMouseClick);
            this.DgvHabilidadesPersonales.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvHabilidadesPersonales_CellMouseDown);
            this.DgvHabilidadesPersonales.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvHabilidadesPersonales_EditingControlShowing);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgvHabilidadesTecnicas);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1153, 242);
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
            this.id_habilidad_tecnica,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.comentarios_habilidad_tecnica,
            this.nivel_habilidad_tecnica});
            this.DgvHabilidadesTecnicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHabilidadesTecnicas.Location = new System.Drawing.Point(3, 3);
            this.DgvHabilidadesTecnicas.Name = "DgvHabilidadesTecnicas";
            this.DgvHabilidadesTecnicas.RowHeadersVisible = false;
            this.DgvHabilidadesTecnicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHabilidadesTecnicas.Size = new System.Drawing.Size(1147, 236);
            this.DgvHabilidadesTecnicas.TabIndex = 1;
            this.DgvHabilidadesTecnicas.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvHabilidadesTecnicas_CellMouseDown);
            this.DgvHabilidadesTecnicas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvHabilidadesTecnicas_EditingControlShowing);
            this.DgvHabilidadesTecnicas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvHabilidadesTecnicas_MouseClick);
            // 
            // ImagenesTabs
            // 
            this.ImagenesTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTabs.ImageStream")));
            this.ImagenesTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTabs.Images.SetKeyName(0, "user.png");
            this.ImagenesTabs.Images.SetKeyName(1, "tool-box-32.png");
            // 
            // MenuEvaluarHabilidad
            // 
            this.MenuEvaluarHabilidad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluarHabilidadToolStripMenuItem,
            this.evaluarHabilidadToolStripMenuItem1});
            this.MenuEvaluarHabilidad.Name = "MenuEvaluarHabilidad";
            this.MenuEvaluarHabilidad.Size = new System.Drawing.Size(165, 48);
            // 
            // evaluarHabilidadToolStripMenuItem
            // 
            this.evaluarHabilidadToolStripMenuItem.Image = global::CB_Base.Properties.Resources.factura;
            this.evaluarHabilidadToolStripMenuItem.Name = "evaluarHabilidadToolStripMenuItem";
            this.evaluarHabilidadToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.evaluarHabilidadToolStripMenuItem.Text = "Evaluar habilidad";
            this.evaluarHabilidadToolStripMenuItem.Click += new System.EventHandler(this.evaluarHabilidadToolStripMenuItem_Click);
            // 
            // evaluarHabilidadToolStripMenuItem1
            // 
            this.evaluarHabilidadToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.factura;
            this.evaluarHabilidadToolStripMenuItem1.Name = "evaluarHabilidadToolStripMenuItem1";
            this.evaluarHabilidadToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.evaluarHabilidadToolStripMenuItem1.Text = "Evaluar habilidad";
            this.evaluarHabilidadToolStripMenuItem1.Click += new System.EventHandler(this.evaluarHabilidadToolStripMenuItem1_Click);
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
            // id_habilidad_tecnica
            // 
            this.id_habilidad_tecnica.HeaderText = "ID Habilidad Personal";
            this.id_habilidad_tecnica.Name = "id_habilidad_tecnica";
            this.id_habilidad_tecnica.ReadOnly = true;
            this.id_habilidad_tecnica.Visible = false;
            this.id_habilidad_tecnica.Width = 50;
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
            // nivel_habilidad_tecnica
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nivel_habilidad_tecnica.DefaultCellStyle = dataGridViewCellStyle8;
            this.nivel_habilidad_tecnica.HeaderText = "Nivel de desempeño observado";
            this.nivel_habilidad_tecnica.Name = "nivel_habilidad_tecnica";
            this.nivel_habilidad_tecnica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nivel_habilidad_tecnica.Width = 180;
            // 
            // FrmEvaluarDesempeno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 487);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEvaluarDesempeno";
            this.Text = "Evaluar empleado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEvaluarEmpleado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesPersonales)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesTecnicas)).EndInit();
            this.MenuEvaluarHabilidad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtPuestoBajoEvaluacion;
        private System.Windows.Forms.Label LblPuntuacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblAvance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.ImageList ImagenesTabs;
        private System.Windows.Forms.DataGridView DgvHabilidadesPersonales;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DgvHabilidadesTecnicas;
        private System.Windows.Forms.TextBox TxtPuestoEvaluador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtEvaluador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip MenuEvaluarHabilidad;
        private System.Windows.Forms.ToolStripMenuItem evaluarHabilidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evaluarHabilidadToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_habilidad_tecnica;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_habilidad_tecnica;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel_habilidad_tecnica;
    }
}
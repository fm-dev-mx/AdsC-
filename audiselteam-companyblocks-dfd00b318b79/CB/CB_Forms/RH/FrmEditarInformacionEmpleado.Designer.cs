namespace CB
{
    partial class FrmEditarInformacionEmpleado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarInformacionEmpleado));
            this.LblTitulo = new System.Windows.Forms.Label();
            this.CmbPuesto = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.TxtPaterno = new System.Windows.Forms.TextBox();
            this.TxtMaterno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NumNivel = new System.Windows.Forms.NumericUpDown();
            this.LblNivel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnBaja = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpFehcaIngreso = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DgvDocumentos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meses_vigencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImagenesTabs = new System.Windows.Forms.ImageList(this.components);
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtApodo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumNivel)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDocumentos)).BeginInit();
            this.Menu.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(1198, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "EDITAR INFORMACION DEL EMPLEADO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbPuesto
            // 
            this.CmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPuesto.FormattingEnabled = true;
            this.CmbPuesto.Location = new System.Drawing.Point(12, 179);
            this.CmbPuesto.Name = "CmbPuesto";
            this.CmbPuesto.Size = new System.Drawing.Size(448, 32);
            this.CmbPuesto.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(465, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Telefono";
            // 
            // TxtNombre
            // 
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(14, 29);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(220, 29);
            this.TxtNombre.TabIndex = 27;
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelefono.Location = new System.Drawing.Point(468, 85);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(220, 29);
            this.TxtTelefono.TabIndex = 37;
            // 
            // TxtPaterno
            // 
            this.TxtPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaterno.Location = new System.Drawing.Point(242, 29);
            this.TxtPaterno.Name = "TxtPaterno";
            this.TxtPaterno.Size = new System.Drawing.Size(220, 29);
            this.TxtPaterno.TabIndex = 28;
            // 
            // TxtMaterno
            // 
            this.TxtMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaterno.Location = new System.Drawing.Point(468, 29);
            this.TxtMaterno.Name = "TxtMaterno";
            this.TxtMaterno.Size = new System.Drawing.Size(220, 29);
            this.TxtMaterno.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Puesto *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nombre *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Apellido paterno *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Apellido materno";
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.TxtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreo.Location = new System.Drawing.Point(14, 79);
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Size = new System.Drawing.Size(448, 29);
            this.TxtCorreo.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Correo *";
            // 
            // NumNivel
            // 
            this.NumNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumNivel.Location = new System.Drawing.Point(466, 180);
            this.NumNivel.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumNivel.Name = "NumNivel";
            this.NumNivel.Size = new System.Drawing.Size(58, 31);
            this.NumNivel.TabIndex = 111;
            this.NumNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblNivel
            // 
            this.LblNivel.AutoSize = true;
            this.LblNivel.Location = new System.Drawing.Point(463, 164);
            this.LblNivel.Name = "LblNivel";
            this.LblNivel.Size = new System.Drawing.Size(34, 13);
            this.LblNivel.TabIndex = 110;
            this.LblNivel.Text = "Nivel:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TxtApodo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.DtpFehcaIngreso);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.TxtPaterno);
            this.panel1.Controls.Add(this.NumNivel);
            this.panel1.Controls.Add(this.TxtMaterno);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.LblNivel);
            this.panel1.Controls.Add(this.TxtTelefono);
            this.panel1.Controls.Add(this.TxtCorreo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbPuesto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 226);
            this.panel1.TabIndex = 113;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnEditar);
            this.panel2.Controls.Add(this.BtnBaja);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1057, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 226);
            this.panel2.TabIndex = 114;
            // 
            // BtnEditar
            // 
            this.BtnEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditar.Image = global::CB_Base.Properties.Resources.Edit;
            this.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditar.Location = new System.Drawing.Point(0, 61);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(141, 61);
            this.BtnEditar.TabIndex = 123;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnBaja
            // 
            this.BtnBaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBaja.Image = global::CB_Base.Properties.Resources.close;
            this.BtnBaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBaja.Location = new System.Drawing.Point(0, 0);
            this.BtnBaja.Name = "BtnBaja";
            this.BtnBaja.Size = new System.Drawing.Size(141, 61);
            this.BtnBaja.TabIndex = 122;
            this.BtnBaja.Text = "       Dar de baja";
            this.BtnBaja.UseVisualStyleBackColor = true;
            this.BtnBaja.Click += new System.EventHandler(this.BtnBaja_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 113;
            this.label5.Text = "Fecha de ingreso:";
            // 
            // DtpFehcaIngreso
            // 
            this.DtpFehcaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFehcaIngreso.Location = new System.Drawing.Point(556, 179);
            this.DtpFehcaIngreso.Name = "DtpFehcaIngreso";
            this.DtpFehcaIngreso.Size = new System.Drawing.Size(267, 26);
            this.DtpFehcaIngreso.TabIndex = 112;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.ImagenesTabs;
            this.tabControl1.Location = new System.Drawing.Point(0, 249);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1198, 321);
            this.tabControl1.TabIndex = 114;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgvDocumentos);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1190, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Documentos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DgvDocumentos
            // 
            this.DgvDocumentos.AllowUserToAddRows = false;
            this.DgvDocumentos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDocumentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipo,
            this.fecha_registro,
            this.meses_vigencia,
            this.fecha_vencimiento,
            this.estatus,
            this.datos});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDocumentos.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDocumentos.Location = new System.Drawing.Point(3, 3);
            this.DgvDocumentos.Name = "DgvDocumentos";
            this.DgvDocumentos.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDocumentos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDocumentos.Size = new System.Drawing.Size(1184, 272);
            this.DgvDocumentos.TabIndex = 0;
            this.DgvDocumentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDocumentos_CellClick);
            this.DgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDocumentos_CellDoubleClick);
            this.DgvDocumentos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvDocumentos_CellFormatting);
            this.DgvDocumentos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvDocumentos_CellMouseDown);
            this.DgvDocumentos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvDocumentos_MouseClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipo.HeaderText = "Tipo";
            this.tipo.MinimumWidth = 300;
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // fecha_registro
            // 
            this.fecha_registro.HeaderText = "Fecha de registro";
            this.fecha_registro.MinimumWidth = 200;
            this.fecha_registro.Name = "fecha_registro";
            this.fecha_registro.ReadOnly = true;
            this.fecha_registro.Width = 200;
            // 
            // meses_vigencia
            // 
            this.meses_vigencia.HeaderText = "Meses de vigencia";
            this.meses_vigencia.MinimumWidth = 150;
            this.meses_vigencia.Name = "meses_vigencia";
            this.meses_vigencia.ReadOnly = true;
            this.meses_vigencia.Width = 150;
            // 
            // fecha_vencimiento
            // 
            this.fecha_vencimiento.HeaderText = "Fecha de vencimiento";
            this.fecha_vencimiento.MinimumWidth = 200;
            this.fecha_vencimiento.Name = "fecha_vencimiento";
            this.fecha_vencimiento.ReadOnly = true;
            this.fecha_vencimiento.Width = 200;
            // 
            // estatus
            // 
            this.estatus.HeaderText = "Estatus";
            this.estatus.MinimumWidth = 150;
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 150;
            // 
            // datos
            // 
            this.datos.HeaderText = "Datos";
            this.datos.Name = "datos";
            this.datos.ReadOnly = true;
            this.datos.Visible = false;
            // 
            // ImagenesTabs
            // 
            this.ImagenesTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTabs.ImageStream")));
            this.ImagenesTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTabs.Images.SetKeyName(0, "document-icon-48.png");
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.actualizarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.Menu.Name = "contextMenuStrip1";
            this.Menu.Size = new System.Drawing.Size(118, 70);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.actualizarToolStripMenuItem.Text = "Editar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 116;
            this.label8.Text = "Apodo";
            // 
            // TxtApodo
            // 
            this.TxtApodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.TxtApodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtApodo.Location = new System.Drawing.Point(14, 129);
            this.TxtApodo.Name = "TxtApodo";
            this.TxtApodo.Size = new System.Drawing.Size(448, 29);
            this.TxtApodo.TabIndex = 115;
            // 
            // FrmEditarInformacionEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 570);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmEditarInformacionEmpleado";
            this.Text = "Editar información del empleado";
            this.Load += new System.EventHandler(this.FrmEditarInformacionEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumNivel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDocumentos)).EndInit();
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ComboBox CmbPuesto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.TextBox TxtPaterno;
        private System.Windows.Forms.TextBox TxtMaterno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCorreo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumNivel;
        private System.Windows.Forms.Label LblNivel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ImageList ImagenesTabs;
        private System.Windows.Forms.DataGridView DgvDocumentos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtpFehcaIngreso;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnBaja;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn meses_vigencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_vencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn datos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtApodo;
    }
}
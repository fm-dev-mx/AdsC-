namespace CB
{
    partial class FrmSeleccionOrdenTrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionOrdenTrabajo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabImagen = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DgvOrdenTrabajoPendiente = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solicita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgvOrdenTrabajoProceso = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DgvMantenimientoCorrectivoRealizado = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnHistorialMantenimiento = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblPendiente = new System.Windows.Forms.Label();
            this.LblEnProceso = new System.Windows.Forms.Label();
            this.LblOrdenEnProceso = new System.Windows.Forms.Label();
            this.LblMantenimientoProceso = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.id_en_proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipo_en_proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_realizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipo_realizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_realizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdenTrabajoPendiente)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdenTrabajoProceso)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimientoCorrectivoRealizado)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabImagen
            // 
            this.TabImagen.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabImagen.ImageStream")));
            this.TabImagen.TransparentColor = System.Drawing.Color.Transparent;
            this.TabImagen.Images.SetKeyName(0, "warning-48.png");
            this.TabImagen.Images.SetKeyName(1, "working.png");
            this.TabImagen.Images.SetKeyName(2, "Oxygen-Icons.org-Oxygen-Actions-dialog-ok-apply.ico");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.TabImagen;
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(0, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1066, 485);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgvOrdenTrabajoPendiente);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1058, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pendientes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DgvOrdenTrabajoPendiente
            // 
            this.DgvOrdenTrabajoPendiente.AllowUserToAddRows = false;
            this.DgvOrdenTrabajoPendiente.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvOrdenTrabajoPendiente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvOrdenTrabajoPendiente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvOrdenTrabajoPendiente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.equipo,
            this.solicita,
            this.fecha,
            this.estatus});
            this.DgvOrdenTrabajoPendiente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvOrdenTrabajoPendiente.Location = new System.Drawing.Point(3, 3);
            this.DgvOrdenTrabajoPendiente.Name = "DgvOrdenTrabajoPendiente";
            this.DgvOrdenTrabajoPendiente.RowHeadersVisible = false;
            this.DgvOrdenTrabajoPendiente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvOrdenTrabajoPendiente.Size = new System.Drawing.Size(1052, 444);
            this.DgvOrdenTrabajoPendiente.TabIndex = 0;
            this.DgvOrdenTrabajoPendiente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrdenTrabajo_CellDoubleClick);
            // 
            // id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 70;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // equipo
            // 
            this.equipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.equipo.HeaderText = "Elemento del mantenimiento";
            this.equipo.MinimumWidth = 150;
            this.equipo.Name = "equipo";
            this.equipo.ReadOnly = true;
            // 
            // solicita
            // 
            this.solicita.HeaderText = "Solicitante";
            this.solicita.MinimumWidth = 200;
            this.solicita.Name = "solicita";
            this.solicita.ReadOnly = true;
            this.solicita.Width = 200;
            // 
            // fecha
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.fecha.HeaderText = "Fecha de solicitud";
            this.fecha.MinimumWidth = 180;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 180;
            // 
            // estatus
            // 
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgvOrdenTrabajoProceso);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1058, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "En proceso";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DgvOrdenTrabajoProceso
            // 
            this.DgvOrdenTrabajoProceso.AllowUserToAddRows = false;
            this.DgvOrdenTrabajoProceso.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvOrdenTrabajoProceso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvOrdenTrabajoProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvOrdenTrabajoProceso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_en_proceso,
            this.equipo_en_proceso,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.DgvOrdenTrabajoProceso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvOrdenTrabajoProceso.Location = new System.Drawing.Point(3, 3);
            this.DgvOrdenTrabajoProceso.Name = "DgvOrdenTrabajoProceso";
            this.DgvOrdenTrabajoProceso.RowHeadersVisible = false;
            this.DgvOrdenTrabajoProceso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvOrdenTrabajoProceso.Size = new System.Drawing.Size(1052, 444);
            this.DgvOrdenTrabajoProceso.TabIndex = 1;
            this.DgvOrdenTrabajoProceso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrdenTrabajoProceso_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DgvMantenimientoCorrectivoRealizado);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1058, 450);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Realizados";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DgvMantenimientoCorrectivoRealizado
            // 
            this.DgvMantenimientoCorrectivoRealizado.AllowUserToAddRows = false;
            this.DgvMantenimientoCorrectivoRealizado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMantenimientoCorrectivoRealizado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvMantenimientoCorrectivoRealizado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMantenimientoCorrectivoRealizado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_realizado,
            this.equipo_realizado,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.estatus_realizado});
            this.DgvMantenimientoCorrectivoRealizado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMantenimientoCorrectivoRealizado.Location = new System.Drawing.Point(3, 3);
            this.DgvMantenimientoCorrectivoRealizado.Name = "DgvMantenimientoCorrectivoRealizado";
            this.DgvMantenimientoCorrectivoRealizado.RowHeadersVisible = false;
            this.DgvMantenimientoCorrectivoRealizado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMantenimientoCorrectivoRealizado.Size = new System.Drawing.Size(1052, 444);
            this.DgvMantenimientoCorrectivoRealizado.TabIndex = 2;
            this.DgvMantenimientoCorrectivoRealizado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMantenimientoCorrectivoRealizado_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnHistorialMantenimiento);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Controls.Add(this.LblPendiente);
            this.panel2.Controls.Add(this.LblEnProceso);
            this.panel2.Controls.Add(this.LblOrdenEnProceso);
            this.panel2.Controls.Add(this.LblMantenimientoProceso);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 59);
            this.panel2.TabIndex = 13;
            // 
            // BtnHistorialMantenimiento
            // 
            this.BtnHistorialMantenimiento.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnHistorialMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHistorialMantenimiento.Image = global::CB_Base.Properties.Resources.calendar_48;
            this.BtnHistorialMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHistorialMantenimiento.Location = new System.Drawing.Point(802, 0);
            this.BtnHistorialMantenimiento.Name = "BtnHistorialMantenimiento";
            this.BtnHistorialMantenimiento.Size = new System.Drawing.Size(132, 59);
            this.BtnHistorialMantenimiento.TabIndex = 130;
            this.BtnHistorialMantenimiento.Text = "         Historial";
            this.BtnHistorialMantenimiento.UseVisualStyleBackColor = true;
            this.BtnHistorialMantenimiento.Click += new System.EventHandler(this.BtnHistorialMantenimiento_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(934, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(132, 59);
            this.BtnSalir.TabIndex = 127;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click_1);
            // 
            // LblPendiente
            // 
            this.LblPendiente.AutoSize = true;
            this.LblPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPendiente.Location = new System.Drawing.Point(260, 20);
            this.LblPendiente.Name = "LblPendiente";
            this.LblPendiente.Size = new System.Drawing.Size(28, 18);
            this.LblPendiente.TabIndex = 3;
            this.LblPendiente.Text = "_ _";
            // 
            // LblEnProceso
            // 
            this.LblEnProceso.AutoSize = true;
            this.LblEnProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEnProceso.Location = new System.Drawing.Point(107, 20);
            this.LblEnProceso.Name = "LblEnProceso";
            this.LblEnProceso.Size = new System.Drawing.Size(28, 18);
            this.LblEnProceso.TabIndex = 2;
            this.LblEnProceso.Text = "_ _";
            // 
            // LblOrdenEnProceso
            // 
            this.LblOrdenEnProceso.AutoSize = true;
            this.LblOrdenEnProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOrdenEnProceso.Location = new System.Drawing.Point(169, 20);
            this.LblOrdenEnProceso.Name = "LblOrdenEnProceso";
            this.LblOrdenEnProceso.Size = new System.Drawing.Size(85, 18);
            this.LblOrdenEnProceso.TabIndex = 1;
            this.LblOrdenEnProceso.Text = "Pendientes:";
            // 
            // LblMantenimientoProceso
            // 
            this.LblMantenimientoProceso.AutoSize = true;
            this.LblMantenimientoProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMantenimientoProceso.Location = new System.Drawing.Point(12, 20);
            this.LblMantenimientoProceso.Name = "LblMantenimientoProceso";
            this.LblMantenimientoProceso.Size = new System.Drawing.Size(89, 18);
            this.LblMantenimientoProceso.TabIndex = 0;
            this.LblMantenimientoProceso.Text = "En proceso:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1066, 23);
            this.LblTitulo.TabIndex = 11;
            this.LblTitulo.Text = "ORDENES DE TRABAJO PARA MANTENIMIENTO CORRECTIVO A";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // id_en_proceso
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id_en_proceso.DefaultCellStyle = dataGridViewCellStyle5;
            this.id_en_proceso.HeaderText = "Id";
            this.id_en_proceso.MinimumWidth = 70;
            this.id_en_proceso.Name = "id_en_proceso";
            this.id_en_proceso.ReadOnly = true;
            this.id_en_proceso.Width = 70;
            // 
            // equipo_en_proceso
            // 
            this.equipo_en_proceso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.equipo_en_proceso.HeaderText = "Elemento de mantenimiento";
            this.equipo_en_proceso.MinimumWidth = 150;
            this.equipo_en_proceso.Name = "equipo_en_proceso";
            this.equipo_en_proceso.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Solicitante";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.HeaderText = "Fecha de solicitud";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 180;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 180;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Estatus";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // id_realizado
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id_realizado.DefaultCellStyle = dataGridViewCellStyle8;
            this.id_realizado.HeaderText = "Id";
            this.id_realizado.MinimumWidth = 70;
            this.id_realizado.Name = "id_realizado";
            this.id_realizado.ReadOnly = true;
            this.id_realizado.Width = 70;
            // 
            // equipo_realizado
            // 
            this.equipo_realizado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.equipo_realizado.HeaderText = "Elemento de mantenimiento";
            this.equipo_realizado.MinimumWidth = 150;
            this.equipo_realizado.Name = "equipo_realizado";
            this.equipo_realizado.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Solicitante";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha de solicitud";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 180;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 180;
            // 
            // estatus_realizado
            // 
            this.estatus_realizado.HeaderText = "Estatus";
            this.estatus_realizado.Name = "estatus_realizado";
            this.estatus_realizado.ReadOnly = true;
            // 
            // FrmSeleccionOrdenTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 567);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmSeleccionOrdenTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de trabajo de mantenimiento correctivo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSeleccionOrdenTrabajo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdenTrabajoPendiente)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdenTrabajoProceso)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimientoCorrectivoRealizado)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvOrdenTrabajoPendiente;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblMantenimientoProceso;
        private System.Windows.Forms.Label LblOrdenEnProceso;
        private System.Windows.Forms.Label LblPendiente;
        private System.Windows.Forms.Label LblEnProceso;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DgvOrdenTrabajoProceso;
        private System.Windows.Forms.ImageList TabImagen;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView DgvMantenimientoCorrectivoRealizado;
        private System.Windows.Forms.Button BtnHistorialMantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn solicita;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_en_proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipo_en_proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_realizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipo_realizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_realizado;
    }
}
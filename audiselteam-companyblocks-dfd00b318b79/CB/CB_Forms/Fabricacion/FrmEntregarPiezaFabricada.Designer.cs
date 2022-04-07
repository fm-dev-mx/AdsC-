namespace CB
{
    partial class FrmEntregarPiezaFabricada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntregarPiezaFabricada));
            this.label4 = new System.Windows.Forms.Label();
            this.DgvPiezasFabricadas = new System.Windows.Forms.DataGridView();
            this.check_item = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnEnviarInspeccion = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LblEstatusDescargar = new System.Windows.Forms.Label();
            this.ProgresoDescarga = new System.Windows.Forms.ProgressBar();
            this.DgvProcesos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columna_proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramentista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proceso_anterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columna_requisicion_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_muerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_total_fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnValeSalida = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NumIdPlano = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.ImagenesTabs = new System.Windows.Forms.ImageList(this.components);
            this.MenuValeSalida = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.piezaFabricadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tratamientoDeMaterialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.piezasEntregadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgDescargarVales = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Bkg = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPiezasFabricadas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumIdPlano)).BeginInit();
            this.MenuValeSalida.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(990, 23);
            this.label4.TabIndex = 53;
            this.label4.Text = "PIEZAS FABRICADAS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // DgvPiezasFabricadas
            // 
            this.DgvPiezasFabricadas.AllowUserToAddRows = false;
            this.DgvPiezasFabricadas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DgvPiezasFabricadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPiezasFabricadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvPiezasFabricadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPiezasFabricadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvPiezasFabricadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPiezasFabricadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check_item,
            this.plano,
            this.proyecto,
            this.material,
            this.size,
            this.estatus});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPiezasFabricadas.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvPiezasFabricadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPiezasFabricadas.Location = new System.Drawing.Point(3, 73);
            this.DgvPiezasFabricadas.MultiSelect = false;
            this.DgvPiezasFabricadas.Name = "DgvPiezasFabricadas";
            this.DgvPiezasFabricadas.ReadOnly = true;
            this.DgvPiezasFabricadas.RowHeadersVisible = false;
            this.DgvPiezasFabricadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPiezasFabricadas.Size = new System.Drawing.Size(976, 339);
            this.DgvPiezasFabricadas.TabIndex = 23;
            this.DgvPiezasFabricadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPiezasFabricadas_CellClick);
            // 
            // check_item
            // 
            this.check_item.FalseValue = "false";
            this.check_item.HeaderText = "";
            this.check_item.MinimumWidth = 50;
            this.check_item.Name = "check_item";
            this.check_item.ReadOnly = true;
            this.check_item.TrueValue = "true";
            this.check_item.Width = 50;
            // 
            // plano
            // 
            this.plano.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.plano.HeaderText = "Plano";
            this.plano.Name = "plano";
            this.plano.ReadOnly = true;
            // 
            // proyecto
            // 
            this.proyecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.proyecto.DefaultCellStyle = dataGridViewCellStyle3;
            this.proyecto.HeaderText = "Proyecto";
            this.proyecto.MinimumWidth = 120;
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            this.proyecto.Width = 120;
            // 
            // material
            // 
            this.material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.material.HeaderText = "Material";
            this.material.Name = "material";
            this.material.ReadOnly = true;
            // 
            // size
            // 
            this.size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // estatus
            // 
            this.estatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.estatus.HeaderText = "Estatus";
            this.estatus.MinimumWidth = 160;
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 160;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.ImagenesTabs;
            this.tabControl1.Location = new System.Drawing.Point(0, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(990, 458);
            this.tabControl1.TabIndex = 24;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgvPiezasFabricadas);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(982, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "     Entregar piezas     ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnEnviarInspeccion);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 70);
            this.panel2.TabIndex = 24;
            // 
            // BtnEnviarInspeccion
            // 
            this.BtnEnviarInspeccion.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnEnviarInspeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviarInspeccion.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnEnviarInspeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEnviarInspeccion.Location = new System.Drawing.Point(674, 0);
            this.BtnEnviarInspeccion.Name = "BtnEnviarInspeccion";
            this.BtnEnviarInspeccion.Size = new System.Drawing.Size(151, 70);
            this.BtnEnviarInspeccion.TabIndex = 52;
            this.BtnEnviarInspeccion.Text = "Enviar a inspección";
            this.BtnEnviarInspeccion.UseVisualStyleBackColor = true;
            this.BtnEnviarInspeccion.Click += new System.EventHandler(this.BtnEntregar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(825, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(151, 70);
            this.BtnSalir.TabIndex = 51;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LblEstatusDescargar);
            this.tabPage2.Controls.Add(this.ProgresoDescarga);
            this.tabPage2.Controls.Add(this.DgvProcesos);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(982, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consultar vales de salida";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LblEstatusDescargar
            // 
            this.LblEstatusDescargar.BackColor = System.Drawing.Color.Black;
            this.LblEstatusDescargar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusDescargar.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusDescargar.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusDescargar.Location = new System.Drawing.Point(3, 360);
            this.LblEstatusDescargar.Name = "LblEstatusDescargar";
            this.LblEstatusDescargar.Size = new System.Drawing.Size(976, 29);
            this.LblEstatusDescargar.TabIndex = 81;
            this.LblEstatusDescargar.Text = "Estatus ...";
            this.LblEstatusDescargar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoDescarga
            // 
            this.ProgresoDescarga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoDescarga.Location = new System.Drawing.Point(3, 389);
            this.ProgresoDescarga.Name = "ProgresoDescarga";
            this.ProgresoDescarga.Size = new System.Drawing.Size(976, 23);
            this.ProgresoDescarga.TabIndex = 80;
            // 
            // DgvProcesos
            // 
            this.DgvProcesos.AllowUserToAddRows = false;
            this.DgvProcesos.AllowUserToDeleteRows = false;
            this.DgvProcesos.AllowUserToResizeRows = false;
            this.DgvProcesos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProcesos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.columna_proceso,
            this.maquina,
            this.programador,
            this.herramentista,
            this.dataGridViewTextBoxColumn1,
            this.fecha_inicio,
            this.fecha_termino,
            this.comentarios,
            this.proceso_anterior,
            this.col_categoria,
            this.columna_requisicion_compra,
            this.tiempo_muerto,
            this.tiempo_fabricacion,
            this.tiempo_total_fabricacion});
            this.DgvProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProcesos.Location = new System.Drawing.Point(3, 73);
            this.DgvProcesos.Name = "DgvProcesos";
            this.DgvProcesos.ReadOnly = true;
            this.DgvProcesos.RowHeadersVisible = false;
            this.DgvProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProcesos.Size = new System.Drawing.Size(976, 339);
            this.DgvProcesos.TabIndex = 31;
            // 
            // id
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle5;
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // columna_proceso
            // 
            this.columna_proceso.Frozen = true;
            this.columna_proceso.HeaderText = "Proceso";
            this.columna_proceso.Name = "columna_proceso";
            this.columna_proceso.ReadOnly = true;
            this.columna_proceso.Width = 200;
            // 
            // maquina
            // 
            this.maquina.HeaderText = "Maquina herramienta";
            this.maquina.Name = "maquina";
            this.maquina.ReadOnly = true;
            this.maquina.Width = 200;
            // 
            // programador
            // 
            this.programador.HeaderText = "Programador";
            this.programador.Name = "programador";
            this.programador.ReadOnly = true;
            this.programador.Visible = false;
            this.programador.Width = 200;
            // 
            // herramentista
            // 
            this.herramentista.HeaderText = "Herramentista";
            this.herramentista.Name = "herramentista";
            this.herramentista.ReadOnly = true;
            this.herramentista.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Estatus";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // fecha_inicio
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_inicio.DefaultCellStyle = dataGridViewCellStyle7;
            this.fecha_inicio.HeaderText = "Fecha y hora de inicio";
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.ReadOnly = true;
            this.fecha_inicio.Width = 180;
            // 
            // fecha_termino
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_termino.DefaultCellStyle = dataGridViewCellStyle8;
            this.fecha_termino.HeaderText = "Fecha y hora de finalización";
            this.fecha_termino.Name = "fecha_termino";
            this.fecha_termino.ReadOnly = true;
            this.fecha_termino.Width = 180;
            // 
            // comentarios
            // 
            this.comentarios.HeaderText = "Comentarios";
            this.comentarios.MinimumWidth = 100;
            this.comentarios.Name = "comentarios";
            this.comentarios.ReadOnly = true;
            this.comentarios.Width = 300;
            // 
            // proceso_anterior
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proceso_anterior.DefaultCellStyle = dataGridViewCellStyle9;
            this.proceso_anterior.HeaderText = "Proceso anterior";
            this.proceso_anterior.MinimumWidth = 80;
            this.proceso_anterior.Name = "proceso_anterior";
            this.proceso_anterior.ReadOnly = true;
            this.proceso_anterior.Width = 80;
            // 
            // col_categoria
            // 
            this.col_categoria.HeaderText = "Columna categoria";
            this.col_categoria.Name = "col_categoria";
            this.col_categoria.ReadOnly = true;
            this.col_categoria.Visible = false;
            // 
            // columna_requisicion_compra
            // 
            this.columna_requisicion_compra.HeaderText = "Requisicion";
            this.columna_requisicion_compra.Name = "columna_requisicion_compra";
            this.columna_requisicion_compra.ReadOnly = true;
            this.columna_requisicion_compra.Visible = false;
            // 
            // tiempo_muerto
            // 
            this.tiempo_muerto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_muerto.DefaultCellStyle = dataGridViewCellStyle10;
            this.tiempo_muerto.HeaderText = "Tiempo muerto";
            this.tiempo_muerto.MinimumWidth = 100;
            this.tiempo_muerto.Name = "tiempo_muerto";
            this.tiempo_muerto.ReadOnly = true;
            // 
            // tiempo_fabricacion
            // 
            this.tiempo_fabricacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_fabricacion.DefaultCellStyle = dataGridViewCellStyle11;
            this.tiempo_fabricacion.HeaderText = "Tiempo de fabricación";
            this.tiempo_fabricacion.MinimumWidth = 100;
            this.tiempo_fabricacion.Name = "tiempo_fabricacion";
            this.tiempo_fabricacion.ReadOnly = true;
            // 
            // tiempo_total_fabricacion
            // 
            this.tiempo_total_fabricacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_total_fabricacion.DefaultCellStyle = dataGridViewCellStyle12;
            this.tiempo_total_fabricacion.HeaderText = "Tiempo total de fabricación";
            this.tiempo_total_fabricacion.MinimumWidth = 100;
            this.tiempo_total_fabricacion.Name = "tiempo_total_fabricacion";
            this.tiempo_total_fabricacion.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnValeSalida);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NumIdPlano);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 70);
            this.panel1.TabIndex = 25;
            // 
            // BtnValeSalida
            // 
            this.BtnValeSalida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnValeSalida.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnValeSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValeSalida.Image = global::CB_Base.Properties.Resources.Nota;
            this.BtnValeSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnValeSalida.Location = new System.Drawing.Point(659, 0);
            this.BtnValeSalida.Name = "BtnValeSalida";
            this.BtnValeSalida.Size = new System.Drawing.Size(166, 70);
            this.BtnValeSalida.TabIndex = 54;
            this.BtnValeSalida.Text = "         Vales de salida ";
            this.BtnValeSalida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnValeSalida.UseVisualStyleBackColor = true;
            this.BtnValeSalida.Click += new System.EventHandler(this.BtnValeSalida_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Id plano:";
            // 
            // NumIdPlano
            // 
            this.NumIdPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumIdPlano.Location = new System.Drawing.Point(5, 28);
            this.NumIdPlano.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumIdPlano.Name = "NumIdPlano";
            this.NumIdPlano.Size = new System.Drawing.Size(99, 26);
            this.NumIdPlano.TabIndex = 52;
            this.NumIdPlano.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumIdPlano.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyDown);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CB_Base.Properties.Resources.exit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(825, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 70);
            this.button2.TabIndex = 51;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // ImagenesTabs
            // 
            this.ImagenesTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTabs.ImageStream")));
            this.ImagenesTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTabs.Images.SetKeyName(0, "evaluation-48.png");
            this.ImagenesTabs.Images.SetKeyName(1, "pieza_comprada.png");
            // 
            // MenuValeSalida
            // 
            this.MenuValeSalida.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.piezaFabricadaToolStripMenuItem,
            this.tratamientoDeMaterialesToolStripMenuItem,
            this.piezasEntregadasToolStripMenuItem});
            this.MenuValeSalida.Name = "MenuValeSalida";
            this.MenuValeSalida.Size = new System.Drawing.Size(212, 70);
            this.MenuValeSalida.Opening += new System.ComponentModel.CancelEventHandler(this.MenuValeSalida_Opening);
            // 
            // piezaFabricadaToolStripMenuItem
            // 
            this.piezaFabricadaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.piezas_fabricadas;
            this.piezaFabricadaToolStripMenuItem.Name = "piezaFabricadaToolStripMenuItem";
            this.piezaFabricadaToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.piezaFabricadaToolStripMenuItem.Text = "Pieza fabricada";
            this.piezaFabricadaToolStripMenuItem.Click += new System.EventHandler(this.piezaFabricadaToolStripMenuItem_Click);
            // 
            // tratamientoDeMaterialesToolStripMenuItem
            // 
            this.tratamientoDeMaterialesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.paint_icon1;
            this.tratamientoDeMaterialesToolStripMenuItem.Name = "tratamientoDeMaterialesToolStripMenuItem";
            this.tratamientoDeMaterialesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.tratamientoDeMaterialesToolStripMenuItem.Text = "Tratamiento de materiales";
            this.tratamientoDeMaterialesToolStripMenuItem.Click += new System.EventHandler(this.tratamientoDeMaterialesToolStripMenuItem_Click);
            // 
            // piezasEntregadasToolStripMenuItem
            // 
            this.piezasEntregadasToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.piezasEntregadasToolStripMenuItem.Name = "piezasEntregadasToolStripMenuItem";
            this.piezasEntregadasToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.piezasEntregadasToolStripMenuItem.Text = "Piezas entregadas";
            this.piezasEntregadasToolStripMenuItem.Click += new System.EventHandler(this.piezasEntregadasToolStripMenuItem_Click);
            // 
            // BkgDescargarVales
            // 
            this.BkgDescargarVales.WorkerReportsProgress = true;
            this.BkgDescargarVales.WorkerSupportsCancellation = true;
            this.BkgDescargarVales.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarVales_DoWork);
            this.BkgDescargarVales.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarVales_ProgressChanged);
            this.BkgDescargarVales.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarVales_RunWorkerCompleted);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmEntregarPiezaFabricada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 481);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Name = "FrmEntregarPiezaFabricada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entregar piezas fabricadas a inspeccion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEntregarPiezaFabricada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPiezasFabricadas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumIdPlano)).EndInit();
            this.MenuValeSalida.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPiezasFabricadas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn material;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnEnviarInspeccion;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumIdPlano;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DgvProcesos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna_proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn maquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn programador;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramentista;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn proceso_anterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna_requisicion_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_muerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_fabricacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_total_fabricacion;
        private System.Windows.Forms.Button BtnValeSalida;
        private System.Windows.Forms.ContextMenuStrip MenuValeSalida;
        private System.Windows.Forms.ToolStripMenuItem piezaFabricadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tratamientoDeMaterialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem piezasEntregadasToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgDescargarVales;
        private System.Windows.Forms.Label LblEstatusDescargar;
        private System.Windows.Forms.ProgressBar ProgresoDescarga;
        private System.Windows.Forms.ImageList ImagenesTabs;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker Bkg;
    }
}
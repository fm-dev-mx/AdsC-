namespace CB
{
    partial class FrmRecibirPiezaTratamiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecibirPiezaTratamiento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumValeSalida = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgvRecibirPiezaAluminio = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvRecibirPiezasAcero = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pz_aluminio_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte_aluminio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano_aluminio_recibir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisicion_aluminio_recibir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_aluminio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pza_aluminio_proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recibir_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pz_acero_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte_acero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_acero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pza_acero_proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumValeSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecibirPiezaAluminio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecibirPiezasAcero)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnAceptar);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.NumValeSalida);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 81);
            this.panel1.TabIndex = 0;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAceptar.Image")));
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(851, 23);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(145, 58);
            this.BtnAceptar.TabIndex = 57;
            this.BtnAceptar.Text = "   Recibir";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.Image")));
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(996, 23);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(145, 58);
            this.BtnCancelar.TabIndex = 59;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1141, 23);
            this.label4.TabIndex = 58;
            this.label4.Text = "RECIBIR PIEZAS DE TRATAMIENTO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label4_MouseDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Vale de salida:";
            // 
            // NumValeSalida
            // 
            this.NumValeSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumValeSalida.Location = new System.Drawing.Point(11, 46);
            this.NumValeSalida.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumValeSalida.Name = "NumValeSalida";
            this.NumValeSalida.Size = new System.Drawing.Size(120, 29);
            this.NumValeSalida.TabIndex = 0;
            this.NumValeSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumValeSalida.ValueChanged += new System.EventHandler(this.NumValeSalida_ValueChanged);
            this.NumValeSalida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumValeSalida_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 81);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvRecibirPiezaAluminio);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvRecibirPiezasAcero);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(1141, 395);
            this.splitContainer1.SplitterDistance = 572;
            this.splitContainer1.TabIndex = 1;
            // 
            // DgvRecibirPiezaAluminio
            // 
            this.DgvRecibirPiezaAluminio.AllowUserToAddRows = false;
            this.DgvRecibirPiezaAluminio.AllowUserToResizeRows = false;
            this.DgvRecibirPiezaAluminio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRecibirPiezaAluminio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvRecibirPiezaAluminio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRecibirPiezaAluminio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.pz_aluminio_id,
            this.cantidad,
            this.numero_parte_aluminio,
            this.plano_aluminio_recibir,
            this.requisicion_aluminio_recibir,
            this.estatus_aluminio,
            this.pza_aluminio_proceso});
            this.DgvRecibirPiezaAluminio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvRecibirPiezaAluminio.Location = new System.Drawing.Point(0, 23);
            this.DgvRecibirPiezaAluminio.Name = "DgvRecibirPiezaAluminio";
            this.DgvRecibirPiezaAluminio.RowHeadersVisible = false;
            this.DgvRecibirPiezaAluminio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRecibirPiezaAluminio.Size = new System.Drawing.Size(572, 372);
            this.DgvRecibirPiezaAluminio.TabIndex = 2;
            this.DgvRecibirPiezaAluminio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRecibirPiezaAluminio_CellClick);
            this.DgvRecibirPiezaAluminio.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvRecibirPiezaAluminio_CellFormatting);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "PIEZAS DE ALUMINIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvRecibirPiezasAcero
            // 
            this.DgvRecibirPiezasAcero.AllowUserToAddRows = false;
            this.DgvRecibirPiezasAcero.AllowUserToResizeRows = false;
            this.DgvRecibirPiezasAcero.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRecibirPiezasAcero.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvRecibirPiezasAcero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRecibirPiezasAcero.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recibir_check,
            this.pz_acero_id,
            this.dataGridViewTextBoxColumn2,
            this.numero_parte_acero,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.estatus_acero,
            this.pza_acero_proceso});
            this.DgvRecibirPiezasAcero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvRecibirPiezasAcero.Location = new System.Drawing.Point(0, 23);
            this.DgvRecibirPiezasAcero.Name = "DgvRecibirPiezasAcero";
            this.DgvRecibirPiezasAcero.RowHeadersVisible = false;
            this.DgvRecibirPiezasAcero.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRecibirPiezasAcero.Size = new System.Drawing.Size(565, 372);
            this.DgvRecibirPiezasAcero.TabIndex = 24;
            this.DgvRecibirPiezasAcero.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRecibirPiezasAcero_CellClick);
            this.DgvRecibirPiezasAcero.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvRecibirPiezasAcero_CellFormatting);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(565, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "PIEZAS DE ACERO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // check
            // 
            this.check.FalseValue = "false";
            this.check.HeaderText = "";
            this.check.Name = "check";
            this.check.TrueValue = "true";
            this.check.Width = 40;
            // 
            // pz_aluminio_id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pz_aluminio_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.pz_aluminio_id.HeaderText = "Id";
            this.pz_aluminio_id.Name = "pz_aluminio_id";
            this.pz_aluminio_id.ReadOnly = true;
            this.pz_aluminio_id.Width = 50;
            // 
            // cantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cantidad.Width = 80;
            // 
            // numero_parte_aluminio
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.numero_parte_aluminio.DefaultCellStyle = dataGridViewCellStyle4;
            this.numero_parte_aluminio.HeaderText = "Id plano";
            this.numero_parte_aluminio.Name = "numero_parte_aluminio";
            this.numero_parte_aluminio.ReadOnly = true;
            this.numero_parte_aluminio.Width = 80;
            // 
            // plano_aluminio_recibir
            // 
            this.plano_aluminio_recibir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.plano_aluminio_recibir.DefaultCellStyle = dataGridViewCellStyle5;
            this.plano_aluminio_recibir.HeaderText = "Plano";
            this.plano_aluminio_recibir.Name = "plano_aluminio_recibir";
            this.plano_aluminio_recibir.ReadOnly = true;
            // 
            // requisicion_aluminio_recibir
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requisicion_aluminio_recibir.DefaultCellStyle = dataGridViewCellStyle6;
            this.requisicion_aluminio_recibir.HeaderText = "Requisición de compra";
            this.requisicion_aluminio_recibir.Name = "requisicion_aluminio_recibir";
            this.requisicion_aluminio_recibir.ReadOnly = true;
            this.requisicion_aluminio_recibir.Width = 80;
            // 
            // estatus_aluminio
            // 
            this.estatus_aluminio.HeaderText = "estatus";
            this.estatus_aluminio.Name = "estatus_aluminio";
            this.estatus_aluminio.ReadOnly = true;
            this.estatus_aluminio.Visible = false;
            // 
            // pza_aluminio_proceso
            // 
            this.pza_aluminio_proceso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pza_aluminio_proceso.DefaultCellStyle = dataGridViewCellStyle7;
            this.pza_aluminio_proceso.HeaderText = "Proceso de tratamiento";
            this.pza_aluminio_proceso.Name = "pza_aluminio_proceso";
            this.pza_aluminio_proceso.ReadOnly = true;
            // 
            // recibir_check
            // 
            this.recibir_check.FalseValue = "false";
            this.recibir_check.HeaderText = "";
            this.recibir_check.Name = "recibir_check";
            this.recibir_check.TrueValue = "true";
            this.recibir_check.Width = 40;
            // 
            // pz_acero_id
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pz_acero_id.DefaultCellStyle = dataGridViewCellStyle9;
            this.pz_acero_id.HeaderText = "Id";
            this.pz_acero_id.Name = "pz_acero_id";
            this.pz_acero_id.ReadOnly = true;
            this.pz_acero_id.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn2.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // numero_parte_acero
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.numero_parte_acero.DefaultCellStyle = dataGridViewCellStyle11;
            this.numero_parte_acero.HeaderText = "Id plano";
            this.numero_parte_acero.Name = "numero_parte_acero";
            this.numero_parte_acero.ReadOnly = true;
            this.numero_parte_acero.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn4.HeaderText = "Plano";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn5.HeaderText = "Requisición de compra";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // estatus_acero
            // 
            this.estatus_acero.HeaderText = "estatus";
            this.estatus_acero.Name = "estatus_acero";
            this.estatus_acero.ReadOnly = true;
            this.estatus_acero.Visible = false;
            // 
            // pza_acero_proceso
            // 
            this.pza_acero_proceso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pza_acero_proceso.DefaultCellStyle = dataGridViewCellStyle14;
            this.pza_acero_proceso.HeaderText = "Proceso de tratamiento";
            this.pza_acero_proceso.Name = "pza_acero_proceso";
            this.pza_acero_proceso.ReadOnly = true;
            // 
            // FrmRecibirPiezaTratamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 476);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRecibirPiezaTratamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibir piezas de tratamiento";
            this.Load += new System.EventHandler(this.FrmRecibirPiezaTratamiento_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumValeSalida)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecibirPiezaAluminio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecibirPiezasAcero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvRecibirPiezaAluminio;
        private System.Windows.Forms.NumericUpDown NumValeSalida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.DataGridView DgvRecibirPiezasAcero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn pz_aluminio_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte_aluminio;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano_aluminio_recibir;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisicion_aluminio_recibir;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_aluminio;
        private System.Windows.Forms.DataGridViewTextBoxColumn pza_aluminio_proceso;
        private System.Windows.Forms.DataGridViewCheckBoxColumn recibir_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn pz_acero_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte_acero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_acero;
        private System.Windows.Forms.DataGridViewTextBoxColumn pza_acero_proceso;
    }
}
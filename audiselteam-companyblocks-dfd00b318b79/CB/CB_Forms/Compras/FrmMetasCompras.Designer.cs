namespace CB
{
    partial class FrmMetasCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BkgCargarMetas = new System.ComponentModel.BackgroundWorker();
            this.DgvMetas = new System.Windows.Forms.DataGridView();
            this.id_requisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_meta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_entrega_cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblEstatusDescargar = new System.Windows.Forms.Label();
            this.ProgresoDescarga = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbFiltroOrdenado = new System.Windows.Forms.ComboBox();
            this.CmbFiltroMetas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.CmbFiltroFabricante = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbFiltroProyecto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BkgCargarMetas
            // 
            this.BkgCargarMetas.WorkerReportsProgress = true;
            this.BkgCargarMetas.WorkerSupportsCancellation = true;
            this.BkgCargarMetas.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgCargarMetas_DoWork);
            this.BkgCargarMetas.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgCargarMetas_ProgressChanged);
            this.BkgCargarMetas.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgCargarMetas_RunWorkerCompleted);
            // 
            // DgvMetas
            // 
            this.DgvMetas.AllowUserToAddRows = false;
            this.DgvMetas.AllowUserToDeleteRows = false;
            this.DgvMetas.AllowUserToResizeRows = false;
            this.DgvMetas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_requisicion,
            this.proyecto,
            this.numero_parte,
            this.Fabricante,
            this.id_meta,
            this.fecha_promesa,
            this.tiempo_entrega_cotizacion,
            this.fecha_limite,
            this.estatus_compra,
            this.proveedor});
            this.DgvMetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMetas.Location = new System.Drawing.Point(0, 89);
            this.DgvMetas.MultiSelect = false;
            this.DgvMetas.Name = "DgvMetas";
            this.DgvMetas.RowHeadersVisible = false;
            this.DgvMetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMetas.Size = new System.Drawing.Size(1119, 390);
            this.DgvMetas.TabIndex = 1;
            this.DgvMetas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvMetas_CellFormatting);
            this.DgvMetas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMetas_CellMouseDoubleClick);
            // 
            // id_requisicion
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id_requisicion.DefaultCellStyle = dataGridViewCellStyle2;
            this.id_requisicion.HeaderText = "# Requisición";
            this.id_requisicion.MinimumWidth = 80;
            this.id_requisicion.Name = "id_requisicion";
            this.id_requisicion.ReadOnly = true;
            this.id_requisicion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id_requisicion.Width = 80;
            // 
            // proyecto
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proyecto.DefaultCellStyle = dataGridViewCellStyle3;
            this.proyecto.HeaderText = "Proyecto";
            this.proyecto.MinimumWidth = 70;
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            this.proyecto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.proyecto.Width = 70;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle4;
            this.numero_parte.HeaderText = "Número de parte";
            this.numero_parte.MinimumWidth = 230;
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            this.numero_parte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.numero_parte.Width = 230;
            // 
            // Fabricante
            // 
            this.Fabricante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Fabricante.DefaultCellStyle = dataGridViewCellStyle5;
            this.Fabricante.HeaderText = "Fabricante";
            this.Fabricante.MinimumWidth = 150;
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.ReadOnly = true;
            this.Fabricante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // id_meta
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id_meta.DefaultCellStyle = dataGridViewCellStyle6;
            this.id_meta.HeaderText = "Meta";
            this.id_meta.Name = "id_meta";
            this.id_meta.ReadOnly = true;
            this.id_meta.Width = 70;
            // 
            // fecha_promesa
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_promesa.DefaultCellStyle = dataGridViewCellStyle7;
            this.fecha_promesa.HeaderText = "Fecha promesa";
            this.fecha_promesa.MinimumWidth = 100;
            this.fecha_promesa.Name = "fecha_promesa";
            this.fecha_promesa.ReadOnly = true;
            // 
            // tiempo_entrega_cotizacion
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_entrega_cotizacion.DefaultCellStyle = dataGridViewCellStyle8;
            this.tiempo_entrega_cotizacion.HeaderText = "Tiempo de entrega (dias)";
            this.tiempo_entrega_cotizacion.Name = "tiempo_entrega_cotizacion";
            this.tiempo_entrega_cotizacion.ReadOnly = true;
            // 
            // fecha_limite
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_limite.DefaultCellStyle = dataGridViewCellStyle9;
            this.fecha_limite.HeaderText = "Fecha límite para ordenar";
            this.fecha_limite.MinimumWidth = 100;
            this.fecha_limite.Name = "fecha_limite";
            this.fecha_limite.ReadOnly = true;
            // 
            // estatus_compra
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_compra.DefaultCellStyle = dataGridViewCellStyle10;
            this.estatus_compra.HeaderText = "Estatus de compra";
            this.estatus_compra.Name = "estatus_compra";
            this.estatus_compra.ReadOnly = true;
            // 
            // proveedor
            // 
            this.proveedor.HeaderText = "Proveedor Seleccionado";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            // 
            // LblEstatusDescargar
            // 
            this.LblEstatusDescargar.BackColor = System.Drawing.Color.Black;
            this.LblEstatusDescargar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusDescargar.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusDescargar.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusDescargar.Location = new System.Drawing.Point(0, 479);
            this.LblEstatusDescargar.Name = "LblEstatusDescargar";
            this.LblEstatusDescargar.Size = new System.Drawing.Size(1119, 29);
            this.LblEstatusDescargar.TabIndex = 83;
            this.LblEstatusDescargar.Text = "Estatus ...";
            this.LblEstatusDescargar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoDescarga
            // 
            this.ProgresoDescarga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoDescarga.Location = new System.Drawing.Point(0, 508);
            this.ProgresoDescarga.Name = "ProgresoDescarga";
            this.ProgresoDescarga.Size = new System.Drawing.Size(1119, 23);
            this.ProgresoDescarga.TabIndex = 82;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbFiltroOrdenado);
            this.panel1.Controls.Add(this.CmbFiltroMetas);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.CmbFiltroFabricante);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CmbFiltroProyecto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 89);
            this.panel1.TabIndex = 0;
            // 
            // CmbFiltroOrdenado
            // 
            this.CmbFiltroOrdenado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroOrdenado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroOrdenado.FormattingEnabled = true;
            this.CmbFiltroOrdenado.Items.AddRange(new object[] {
            "SIN ORDENAR",
            "ORDENADO"});
            this.CmbFiltroOrdenado.Location = new System.Drawing.Point(723, 49);
            this.CmbFiltroOrdenado.Name = "CmbFiltroOrdenado";
            this.CmbFiltroOrdenado.Size = new System.Drawing.Size(189, 26);
            this.CmbFiltroOrdenado.TabIndex = 37;
            this.CmbFiltroOrdenado.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroOrdenado_SelectedIndexChanged);
            // 
            // CmbFiltroMetas
            // 
            this.CmbFiltroMetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroMetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroMetas.FormattingEnabled = true;
            this.CmbFiltroMetas.Location = new System.Drawing.Point(603, 49);
            this.CmbFiltroMetas.Name = "CmbFiltroMetas";
            this.CmbFiltroMetas.Size = new System.Drawing.Size(114, 26);
            this.CmbFiltroMetas.TabIndex = 36;
            this.CmbFiltroMetas.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroMetas_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(600, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Filtrar por meta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(721, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Estatus de compra:";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(987, 23);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(132, 66);
            this.BtnSalir.TabIndex = 9;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // CmbFiltroFabricante
            // 
            this.CmbFiltroFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroFabricante.FormattingEnabled = true;
            this.CmbFiltroFabricante.Location = new System.Drawing.Point(308, 49);
            this.CmbFiltroFabricante.Name = "CmbFiltroFabricante";
            this.CmbFiltroFabricante.Size = new System.Drawing.Size(287, 26);
            this.CmbFiltroFabricante.TabIndex = 8;
            this.CmbFiltroFabricante.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroFabricante_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1119, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "METAS DE COMPRAS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label4_MouseDown);
            // 
            // CmbFiltroProyecto
            // 
            this.CmbFiltroProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroProyecto.FormattingEnabled = true;
            this.CmbFiltroProyecto.Location = new System.Drawing.Point(12, 49);
            this.CmbFiltroProyecto.Name = "CmbFiltroProyecto";
            this.CmbFiltroProyecto.Size = new System.Drawing.Size(287, 26);
            this.CmbFiltroProyecto.TabIndex = 2;
            this.CmbFiltroProyecto.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroProyecto_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filtrar por fabricante:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar por proyecto:";
            // 
            // FrmMetasCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 531);
            this.Controls.Add(this.DgvMetas);
            this.Controls.Add(this.LblEstatusDescargar);
            this.Controls.Add(this.ProgresoDescarga);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMetasCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Metas de compra";
            this.Load += new System.EventHandler(this.FrmMetasCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvMetas;
        private System.Windows.Forms.ComboBox CmbFiltroProyecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbFiltroFabricante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker BkgCargarMetas;
        private System.Windows.Forms.Label LblEstatusDescargar;
        private System.Windows.Forms.ProgressBar ProgresoDescarga;
        private System.Windows.Forms.ComboBox CmbFiltroMetas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbFiltroOrdenado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_requisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_meta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_entrega_cotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
    }
}
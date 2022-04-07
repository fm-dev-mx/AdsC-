namespace CB
{
    partial class FrmEstatusComprasProyecto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.DgvMaterial = new System.Windows.Forms.DataGridView();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dias_entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financiero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1041, 50);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pieChart1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1041, 314);
            this.panel2.TabIndex = 2;
            // 
            // pieChart1
            // 
            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart1.Location = new System.Drawing.Point(0, 0);
            this.pieChart1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Padding = new System.Windows.Forms.Padding(0, 50, 0, 50);
            this.pieChart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pieChart1.Size = new System.Drawing.Size(1041, 314);
            this.pieChart1.TabIndex = 14;
            this.pieChart1.Text = "pieChart1";
            //this.pieChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.pieChart1_ChildChanged);
            // 
            // DgvMaterial
            // 
            this.DgvMaterial.AllowUserToAddRows = false;
            this.DgvMaterial.AllowUserToDeleteRows = false;
            this.DgvMaterial.AllowUserToResizeRows = false;
            this.DgvMaterial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMaterial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.parte,
            this.marca,
            this.descripcion,
            this.modulo,
            this.cantidad,
            this.dias_entrega,
            this.seleccion,
            this.autorizacion,
            this.estatus_compra,
            this.financiero,
            this.fecha_entrega});
            this.DgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMaterial.Location = new System.Drawing.Point(0, 387);
            this.DgvMaterial.Name = "DgvMaterial";
            this.DgvMaterial.RowHeadersVisible = false;
            this.DgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMaterial.Size = new System.Drawing.Size(1041, 298);
            this.DgvMaterial.TabIndex = 3;
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(1041, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "ESTATUS DE COMPRA DEL PROYECTO";

            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exitMenuIcon;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(894, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(147, 50);
            this.BtnSalir.TabIndex = 0;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "RFQ";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // parte
            // 
            this.parte.HeaderText = "# Parte";
            this.parte.Name = "parte";
            this.parte.ReadOnly = true;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle3;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 150;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // modulo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.modulo.DefaultCellStyle = dataGridViewCellStyle4;
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            this.modulo.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle5;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dias_entrega
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dias_entrega.DefaultCellStyle = dataGridViewCellStyle6;
            this.dias_entrega.HeaderText = "Días de entrega";
            this.dias_entrega.Name = "dias_entrega";
            this.dias_entrega.ReadOnly = true;
            this.dias_entrega.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dias_entrega.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // seleccion
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccion.DefaultCellStyle = dataGridViewCellStyle7;
            this.seleccion.HeaderText = "Estatus de selección";
            this.seleccion.Name = "seleccion";
            this.seleccion.ReadOnly = true;
            this.seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // autorizacion
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.autorizacion.DefaultCellStyle = dataGridViewCellStyle8;
            this.autorizacion.HeaderText = "Autorización";
            this.autorizacion.Name = "autorizacion";
            this.autorizacion.ReadOnly = true;
            this.autorizacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.autorizacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // estatus_compra
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus_compra.DefaultCellStyle = dataGridViewCellStyle9;
            this.estatus_compra.HeaderText = "Estatus de compra";
            this.estatus_compra.Name = "estatus_compra";
            this.estatus_compra.ReadOnly = true;
            this.estatus_compra.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus_compra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // financiero
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.financiero.DefaultCellStyle = dataGridViewCellStyle10;
            this.financiero.HeaderText = "Estatus financiero";
            this.financiero.Name = "financiero";
            this.financiero.ReadOnly = true;
            this.financiero.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.financiero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fecha_entrega
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_entrega.DefaultCellStyle = dataGridViewCellStyle11;
            this.fecha_entrega.HeaderText = "Fecha de entrega";
            this.fecha_entrega.Name = "fecha_entrega";
            this.fecha_entrega.ReadOnly = true;
            this.fecha_entrega.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_entrega.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmEstatusComprasProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 685);
            this.Controls.Add(this.DgvMaterial);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEstatusComprasProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEstatusComprasProyecto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEstatusComprasProyecto_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.DataGridView DgvMaterial;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dias_entrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn autorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn financiero;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_entrega;
    }
}
namespace CB
{
    partial class FrmVerCotizacionesMaterial
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvCotizaciones = new System.Windows.Forms.DataGridView();
            this.rfq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_disponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblNumeroParte = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCotizaciones)).BeginInit();
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
            this.LblTitulo.Size = new System.Drawing.Size(851, 23);
            this.LblTitulo.TabIndex = 5;
            this.LblTitulo.Text = "COTIZACIONES DEL MATERIAL";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // DgvCotizaciones
            // 
            this.DgvCotizaciones.AllowUserToAddRows = false;
            this.DgvCotizaciones.AllowUserToDeleteRows = false;
            this.DgvCotizaciones.AllowUserToResizeRows = false;
            this.DgvCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCotizaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rfq,
            this.proveedor,
            this.precio_unitario,
            this.tiempo_entrega,
            this.cantidad_disponible,
            this.tipo_venta,
            this.estatus});
            this.DgvCotizaciones.Location = new System.Drawing.Point(12, 58);
            this.DgvCotizaciones.MultiSelect = false;
            this.DgvCotizaciones.Name = "DgvCotizaciones";
            this.DgvCotizaciones.ReadOnly = true;
            this.DgvCotizaciones.RowHeadersVisible = false;
            this.DgvCotizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCotizaciones.Size = new System.Drawing.Size(826, 231);
            this.DgvCotizaciones.TabIndex = 6;
            this.DgvCotizaciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCotizaciones_CellDoubleClick);
            // 
            // rfq
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rfq.DefaultCellStyle = dataGridViewCellStyle1;
            this.rfq.HeaderText = "RFQ #";
            this.rfq.Name = "rfq";
            this.rfq.ReadOnly = true;
            this.rfq.Width = 70;
            // 
            // proveedor
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.proveedor.DefaultCellStyle = dataGridViewCellStyle2;
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            this.proveedor.Width = 130;
            // 
            // precio_unitario
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio_unitario.DefaultCellStyle = dataGridViewCellStyle3;
            this.precio_unitario.HeaderText = "Precio unitario";
            this.precio_unitario.Name = "precio_unitario";
            this.precio_unitario.ReadOnly = true;
            this.precio_unitario.Width = 150;
            // 
            // tiempo_entrega
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo_entrega.DefaultCellStyle = dataGridViewCellStyle4;
            this.tiempo_entrega.HeaderText = "Tiempo de entrega";
            this.tiempo_entrega.Name = "tiempo_entrega";
            this.tiempo_entrega.ReadOnly = true;
            this.tiempo_entrega.Width = 120;
            // 
            // cantidad_disponible
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad_disponible.DefaultCellStyle = dataGridViewCellStyle5;
            this.cantidad_disponible.HeaderText = "Cantidad disponible";
            this.cantidad_disponible.Name = "cantidad_disponible";
            this.cantidad_disponible.ReadOnly = true;
            // 
            // tipo_venta
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipo_venta.DefaultCellStyle = dataGridViewCellStyle6;
            this.tipo_venta.HeaderText = "Unidades";
            this.tipo_venta.Name = "tipo_venta";
            this.tipo_venta.ReadOnly = true;
            // 
            // estatus
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle7;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 150;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(661, 295);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(177, 42);
            this.BtnSalir.TabIndex = 51;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblNumeroParte
            // 
            this.LblNumeroParte.AutoSize = true;
            this.LblNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroParte.Location = new System.Drawing.Point(8, 31);
            this.LblNumeroParte.Name = "LblNumeroParte";
            this.LblNumeroParte.Size = new System.Drawing.Size(168, 24);
            this.LblNumeroParte.TabIndex = 52;
            this.LblNumeroParte.Text = "Número de parte";
            // 
            // FrmVerCotizacionesMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 349);
            this.Controls.Add(this.LblNumeroParte);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.DgvCotizaciones);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVerCotizacionesMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerCotizaciones";
            this.Load += new System.EventHandler(this.FrmVerCotizacionesMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCotizaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridView DgvCotizaciones;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblNumeroParte;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfq;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_entrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_disponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
    }
}
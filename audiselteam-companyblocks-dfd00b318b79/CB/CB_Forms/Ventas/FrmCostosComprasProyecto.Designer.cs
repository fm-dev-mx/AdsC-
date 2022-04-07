namespace CB
{
    partial class FrmCostosComprasProyecto
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvCostosCompras = new System.Windows.Forms.DataGridView();
            this.tipo_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbComprasTipos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.LblTipoCambio = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbModulo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCostosCompras)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1156, 28);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "COSTOS DE COMPRAS DEL PROYECTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvCostosCompras
            // 
            this.DgvCostosCompras.AllowUserToAddRows = false;
            this.DgvCostosCompras.AllowUserToDeleteRows = false;
            this.DgvCostosCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvCostosCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCostosCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo_compra,
            this.Column2});
            this.DgvCostosCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCostosCompras.Location = new System.Drawing.Point(0, 447);
            this.DgvCostosCompras.Margin = new System.Windows.Forms.Padding(4);
            this.DgvCostosCompras.Name = "DgvCostosCompras";
            this.DgvCostosCompras.ReadOnly = true;
            this.DgvCostosCompras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DgvCostosCompras.RowHeadersVisible = false;
            this.DgvCostosCompras.RowHeadersWidth = 51;
            this.DgvCostosCompras.Size = new System.Drawing.Size(1156, 215);
            this.DgvCostosCompras.TabIndex = 11;
            this.DgvCostosCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCostosCompras_CellContentClick);
            // 
            // tipo_compra
            // 
            this.tipo_compra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipo_compra.HeaderText = "Nombre";
            this.tipo_compra.MinimumWidth = 6;
            this.tipo_compra.Name = "tipo_compra";
            this.tipo_compra.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Monto gastado (USD)";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // pieChart1
            // 
            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pieChart1.Location = new System.Drawing.Point(0, 101);
            this.pieChart1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Padding = new System.Windows.Forms.Padding(0, 50, 0, 50);
            this.pieChart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pieChart1.Size = new System.Drawing.Size(1156, 346);
            this.pieChart1.TabIndex = 13;
            this.pieChart1.Text = "pieChart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de compra";
            // 
            // CmbComprasTipos
            // 
            this.CmbComprasTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComprasTipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbComprasTipos.FormattingEnabled = true;
            this.CmbComprasTipos.Location = new System.Drawing.Point(15, 28);
            this.CmbComprasTipos.Margin = new System.Windows.Forms.Padding(4);
            this.CmbComprasTipos.Name = "CmbComprasTipos";
            this.CmbComprasTipos.Size = new System.Drawing.Size(272, 28);
            this.CmbComprasTipos.TabIndex = 1;
            this.CmbComprasTipos.SelectedIndexChanged += new System.EventHandler(this.CmbComprasTipos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Categoría:";
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategoria.Enabled = false;
            this.CmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(295, 28);
            this.CmbCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(272, 28);
            this.CmbCategoria.TabIndex = 3;
            this.CmbCategoria.SelectedIndexChanged += new System.EventHandler(this.CmbCategoria_SelectedIndexChanged);
            // 
            // LblTipoCambio
            // 
            this.LblTipoCambio.AutoSize = true;
            this.LblTipoCambio.Location = new System.Drawing.Point(855, 36);
            this.LblTipoCambio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTipoCambio.Name = "LblTipoCambio";
            this.LblTipoCambio.Size = new System.Drawing.Size(80, 13);
            this.LblTipoCambio.TabIndex = 4;
            this.LblTipoCambio.Text = "Tipo de cambio";
            this.LblTipoCambio.Click += new System.EventHandler(this.LblTipoCambio_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(572, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Modulo:";
            // 
            // CmbModulo
            // 
            this.CmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbModulo.Enabled = false;
            this.CmbModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbModulo.FormattingEnabled = true;
            this.CmbModulo.Location = new System.Drawing.Point(575, 28);
            this.CmbModulo.Margin = new System.Windows.Forms.Padding(4);
            this.CmbModulo.Name = "CmbModulo";
            this.CmbModulo.Size = new System.Drawing.Size(272, 28);
            this.CmbModulo.TabIndex = 24;
            this.CmbModulo.SelectedIndexChanged += new System.EventHandler(this.CmbModulo_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.CmbModulo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.LblTipoCambio);
            this.panel1.Controls.Add(this.CmbCategoria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CmbComprasTipos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1156, 73);
            this.panel1.TabIndex = 8;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exitMenuIcon;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1009, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(147, 73);
            this.BtnSalir.TabIndex = 25;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmCostosComprasProyecto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1156, 662);
            this.Controls.Add(this.DgvCostosCompras);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCostosComprasProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Costos de compras del proyecto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCostosComprasProyecto_Load);
            this.Shown += new System.EventHandler(this.FrmCostosComprasProyecto_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCostosCompras)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridView DgvCostosCompras;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbComprasTipos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.Label LblTipoCambio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbModulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button BtnSalir;
    }
}
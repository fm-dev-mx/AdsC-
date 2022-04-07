namespace CB
{
    partial class FrmSeleccionarPO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvPO = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbMoneda = new System.Windows.Forms.ComboBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbEstatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.CmbProveedor = new System.Windows.Forms.ComboBox();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda_po = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvPO
            // 
            this.DgvPO.AllowUserToAddRows = false;
            this.DgvPO.AllowUserToDeleteRows = false;
            this.DgvPO.AllowUserToResizeRows = false;
            this.DgvPO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.proveedor,
            this.usuario,
            this.fecha_creacion,
            this.moneda_po});
            this.DgvPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPO.Location = new System.Drawing.Point(0, 0);
            this.DgvPO.Name = "DgvPO";
            this.DgvPO.RowHeadersVisible = false;
            this.DgvPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPO.Size = new System.Drawing.Size(981, 378);
            this.DgvPO.TabIndex = 0;
            this.DgvPO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPO_CellDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnNuevo);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.CmbMoneda);
            this.splitContainer1.Panel1.Controls.Add(this.BtnCancelar);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.CmbEstatus);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.LblTitulo);
            this.splitContainer1.Panel1.Controls.Add(this.CmbProveedor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvPO);
            this.splitContainer1.Size = new System.Drawing.Size(981, 469);
            this.splitContainer1.SplitterDistance = 87;
            this.splitContainer1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(528, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Moneda:";
            // 
            // CmbMoneda
            // 
            this.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMoneda.FormattingEnabled = true;
            this.CmbMoneda.Items.AddRange(new object[] {
            "TODOS",
            "MXN",
            "USD"});
            this.CmbMoneda.Location = new System.Drawing.Point(531, 46);
            this.CmbMoneda.Name = "CmbMoneda";
            this.CmbMoneda.Size = new System.Drawing.Size(180, 32);
            this.CmbMoneda.TabIndex = 21;
            this.CmbMoneda.SelectedIndexChanged += new System.EventHandler(this.CmbMoneda_SelectedIndexChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(862, 23);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(119, 64);
            this.BtnCancelar.TabIndex = 20;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Estatus:";
            // 
            // CmbEstatus
            // 
            this.CmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatus.FormattingEnabled = true;
            this.CmbEstatus.Items.AddRange(new object[] {
            "TODOS",
            "SIN ENVIAR",
            "ENVIADO"});
            this.CmbEstatus.Location = new System.Drawing.Point(263, 46);
            this.CmbEstatus.Name = "CmbEstatus";
            this.CmbEstatus.Size = new System.Drawing.Size(262, 32);
            this.CmbEstatus.TabIndex = 15;
            this.CmbEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbEstatus_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Proveedor:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(981, 23);
            this.LblTitulo.TabIndex = 11;
            this.LblTitulo.Text = "SELECCIONAR PO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // CmbProveedor
            // 
            this.CmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProveedor.FormattingEnabled = true;
            this.CmbProveedor.Location = new System.Drawing.Point(12, 46);
            this.CmbProveedor.Name = "CmbProveedor";
            this.CmbProveedor.Size = new System.Drawing.Size(245, 32);
            this.CmbProveedor.TabIndex = 13;
            this.CmbProveedor.SelectedIndexChanged += new System.EventHandler(this.CmbProveedor_SelectedIndexChanged);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNuevo.Enabled = false;
            this.BtnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.Image = global::CB_Base.Properties.Resources.purchase_order;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(743, 23);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(119, 64);
            this.BtnNuevo.TabIndex = 23;
            this.BtnNuevo.Text = "      Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // id
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle4;
            this.id.HeaderText = "PO #";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // proveedor
            // 
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            this.proveedor.Width = 200;
            // 
            // usuario
            // 
            this.usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usuario.DefaultCellStyle = dataGridViewCellStyle5;
            this.usuario.HeaderText = "Creado por";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // fecha_creacion
            // 
            this.fecha_creacion.HeaderText = "Fecha de creación";
            this.fecha_creacion.Name = "fecha_creacion";
            this.fecha_creacion.ReadOnly = true;
            this.fecha_creacion.Width = 200;
            // 
            // moneda_po
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.moneda_po.DefaultCellStyle = dataGridViewCellStyle6;
            this.moneda_po.HeaderText = "Moneda";
            this.moneda_po.Items.AddRange(new object[] {
            "USD",
            "MXN"});
            this.moneda_po.Name = "moneda_po";
            this.moneda_po.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.moneda_po.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FrmSeleccionarPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 469);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeleccionarPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar PO";
            this.Load += new System.EventHandler(this.FrmSeleccionarPO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPO)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPO;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbEstatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ComboBox CmbProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbMoneda;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_creacion;
        private System.Windows.Forms.DataGridViewComboBoxColumn moneda_po;
    }
}
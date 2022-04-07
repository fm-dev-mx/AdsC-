namespace CB
{
    partial class FrmDesglosarPO
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RBCosto = new System.Windows.Forms.RadioButton();
            this.RBRequisicion = new System.Windows.Forms.RadioButton();
            this.LblPO = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.DgvDesglose = new System.Windows.Forms.DataGridView();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDesglose)).BeginInit();
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
            this.LblTitulo.Size = new System.Drawing.Size(821, 23);
            this.LblTitulo.TabIndex = 18;
            this.LblTitulo.Text = "DESGLOSE DE PO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(0, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(119, 54);
            this.BtnCancelar.TabIndex = 57;
            this.BtnCancelar.Text = "Salir";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.RBCosto);
            this.splitContainer1.Panel1.Controls.Add(this.RBRequisicion);
            this.splitContainer1.Panel1.Controls.Add(this.LblPO);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvDesglose);
            this.splitContainer1.Size = new System.Drawing.Size(821, 502);
            this.splitContainer1.SplitterDistance = 57;
            this.splitContainer1.TabIndex = 19;
            // 
            // RBCosto
            // 
            this.RBCosto.AutoSize = true;
            this.RBCosto.Location = new System.Drawing.Point(118, 33);
            this.RBCosto.Name = "RBCosto";
            this.RBCosto.Size = new System.Drawing.Size(70, 17);
            this.RBCosto.TabIndex = 63;
            this.RBCosto.TabStop = true;
            this.RBCosto.Text = "Por costo";
            this.RBCosto.UseVisualStyleBackColor = true;
            this.RBCosto.CheckedChanged += new System.EventHandler(this.RBRequisicion_CheckedChanged);
            // 
            // RBRequisicion
            // 
            this.RBRequisicion.AutoSize = true;
            this.RBRequisicion.Location = new System.Drawing.Point(12, 33);
            this.RBRequisicion.Name = "RBRequisicion";
            this.RBRequisicion.Size = new System.Drawing.Size(94, 17);
            this.RBRequisicion.TabIndex = 62;
            this.RBRequisicion.TabStop = true;
            this.RBRequisicion.Text = "Por requisición";
            this.RBRequisicion.UseVisualStyleBackColor = true;
            // 
            // LblPO
            // 
            this.LblPO.AutoSize = true;
            this.LblPO.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPO.Location = new System.Drawing.Point(0, 0);
            this.LblPO.Name = "LblPO";
            this.LblPO.Size = new System.Drawing.Size(188, 24);
            this.LblPO.TabIndex = 61;
            this.LblPO.Text = "PO # - PROVEEDOR";
            this.LblPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CB_Base.Properties.Resources.exit;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(663, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 57);
            this.button1.TabIndex = 60;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // DgvDesglose
            // 
            this.DgvDesglose.AllowUserToAddRows = false;
            this.DgvDesglose.AllowUserToDeleteRows = false;
            this.DgvDesglose.AllowUserToResizeRows = false;
            this.DgvDesglose.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDesglose.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvDesglose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDesglose.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proyecto,
            this.numero_parte,
            this.precio_unitario,
            this.cantidad,
            this.total});
            this.DgvDesglose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDesglose.Location = new System.Drawing.Point(0, 0);
            this.DgvDesglose.MultiSelect = false;
            this.DgvDesglose.Name = "DgvDesglose";
            this.DgvDesglose.ReadOnly = true;
            this.DgvDesglose.RowHeadersVisible = false;
            this.DgvDesglose.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDesglose.Size = new System.Drawing.Size(821, 441);
            this.DgvDesglose.TabIndex = 22;
            // 
            // proyecto
            // 
            this.proyecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.proyecto.DefaultCellStyle = dataGridViewCellStyle2;
            this.proyecto.HeaderText = "# Proyecto";
            this.proyecto.MinimumWidth = 100;
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            // 
            // numero_parte
            // 
            this.numero_parte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle3;
            this.numero_parte.HeaderText = "Número de parte";
            this.numero_parte.MinimumWidth = 280;
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            this.numero_parte.Width = 280;
            // 
            // precio_unitario
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.precio_unitario.DefaultCellStyle = dataGridViewCellStyle4;
            this.precio_unitario.HeaderText = "Precio unitario";
            this.precio_unitario.Name = "precio_unitario";
            this.precio_unitario.ReadOnly = true;
            this.precio_unitario.Width = 129;
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle5;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 180;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 180;
            // 
            // total
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = "N/A";
            this.total.DefaultCellStyle = dataGridViewCellStyle6;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 129;
            // 
            // FrmDesglosarPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 525);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDesglosarPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDesglosarPO";
            this.Load += new System.EventHandler(this.FrmDesglosarPO_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDesglose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblPO;
        private System.Windows.Forms.DataGridView DgvDesglose;
        private System.Windows.Forms.RadioButton RBCosto;
        private System.Windows.Forms.RadioButton RBRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;

    }
}
namespace CB
{
    partial class FrmVincularRequisicionesRfq
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnValesSalida = new System.Windows.Forms.Button();
            this.DgvVincularReqRfq = new System.Windows.Forms.DataGridView();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTipoVenta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVincularReqRfq)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnValesSalida);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(942, 63);
            this.panel1.TabIndex = 13;
            // 
            // BtnValesSalida
            // 
            this.BtnValesSalida.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnValesSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValesSalida.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnValesSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnValesSalida.Location = new System.Drawing.Point(779, 0);
            this.BtnValesSalida.Margin = new System.Windows.Forms.Padding(4);
            this.BtnValesSalida.Name = "BtnValesSalida";
            this.BtnValesSalida.Size = new System.Drawing.Size(161, 61);
            this.BtnValesSalida.TabIndex = 109;
            this.BtnValesSalida.Text = "        Salir";
            this.BtnValesSalida.UseVisualStyleBackColor = true;
            this.BtnValesSalida.Click += new System.EventHandler(this.BtnValesSalida_Click);
            // 
            // DgvVincularReqRfq
            // 
            this.DgvVincularReqRfq.AllowUserToAddRows = false;
            this.DgvVincularReqRfq.AllowUserToDeleteRows = false;
            this.DgvVincularReqRfq.AllowUserToResizeRows = false;
            this.DgvVincularReqRfq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVincularReqRfq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proyecto,
            this.requisicion,
            this.requisitor,
            this.cantidad,
            this.estatus_compra});
            this.DgvVincularReqRfq.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DgvVincularReqRfq.Location = new System.Drawing.Point(0, 297);
            this.DgvVincularReqRfq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.DgvVincularReqRfq.Name = "DgvVincularReqRfq";
            this.DgvVincularReqRfq.ReadOnly = true;
            this.DgvVincularReqRfq.RowHeadersVisible = false;
            this.DgvVincularReqRfq.RowHeadersWidth = 54;
            this.DgvVincularReqRfq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvVincularReqRfq.Size = new System.Drawing.Size(942, 346);
            this.DgvVincularReqRfq.TabIndex = 14;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 63);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(942, 33);
            this.LblTitulo.TabIndex = 15;
            this.LblTitulo.Text = "REQUISICIONES VINCULADAS A RFQ";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTipoVenta);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TxtFabricante);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TxtNumeroParte);
            this.panel2.Controls.Add(this.TxtDescripcion);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(942, 202);
            this.panel2.TabIndex = 16;
            // 
            // txtTipoVenta
            // 
            this.txtTipoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoVenta.Location = new System.Drawing.Point(748, 33);
            this.txtTipoVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipoVenta.Name = "txtTipoVenta";
            this.txtTipoVenta.ReadOnly = true;
            this.txtTipoVenta.Size = new System.Drawing.Size(185, 30);
            this.txtTipoVenta.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(745, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tipo de venta:";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(409, 33);
            this.TxtFabricante.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(331, 30);
            this.TxtFabricante.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fabricante:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Número de parte:";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(13, 33);
            this.TxtNumeroParte.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(385, 30);
            this.TxtNumeroParte.TabIndex = 9;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.Location = new System.Drawing.Point(13, 95);
            this.TxtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.Size = new System.Drawing.Size(920, 95);
            this.TxtDescripcion.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Descripción: ";
            // 
            // proyecto
            // 
            this.proyecto.HeaderText = "Proyecto";
            this.proyecto.MinimumWidth = 80;
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            this.proyecto.Width = 80;
            // 
            // requisicion
            // 
            this.requisicion.HeaderText = "Requisición";
            this.requisicion.MinimumWidth = 80;
            this.requisicion.Name = "requisicion";
            this.requisicion.ReadOnly = true;
            this.requisicion.Width = 80;
            // 
            // requisitor
            // 
            this.requisitor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requisitor.DefaultCellStyle = dataGridViewCellStyle1;
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.MinimumWidth = 250;
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "cantidad";
            this.cantidad.MinimumWidth = 100;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 125;
            // 
            // estatus_compra
            // 
            this.estatus_compra.HeaderText = "Estatus compra";
            this.estatus_compra.MinimumWidth = 150;
            this.estatus_compra.Name = "estatus_compra";
            this.estatus_compra.ReadOnly = true;
            this.estatus_compra.Width = 150;
            // 
            // FrmVincularRequisicionesRfq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 643);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.DgvVincularReqRfq);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVincularRequisicionesRfq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vincular Requisiciones a RFQ";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvVincularReqRfq)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnValesSalida;
        private System.Windows.Forms.DataGridView DgvVincularReqRfq;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTipoVenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_compra;
    }
}
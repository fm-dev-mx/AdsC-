namespace CB

{
    partial class FrmPagarFactura
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LvInfoPieza = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnRecibir = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxbReferencia = new System.Windows.Forms.TextBox();
            this.RbtnCheque = new System.Windows.Forms.RadioButton();
            this.RbtnTransaccion = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(12, 371);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(144, 41);
            this.BtnCancelar.TabIndex = 23;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LvInfoPieza
            // 
            this.LvInfoPieza.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LvInfoPieza.Location = new System.Drawing.Point(12, 47);
            this.LvInfoPieza.Name = "LvInfoPieza";
            this.LvInfoPieza.Size = new System.Drawing.Size(294, 205);
            this.LvInfoPieza.TabIndex = 27;
            this.LvInfoPieza.UseCompatibleStateImageBehavior = false;
            this.LvInfoPieza.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 164;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 170;
            // 
            // BtnRecibir
            // 
            this.BtnRecibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRecibir.Location = new System.Drawing.Point(166, 371);
            this.BtnRecibir.Name = "BtnRecibir";
            this.BtnRecibir.Size = new System.Drawing.Size(140, 41);
            this.BtnRecibir.TabIndex = 25;
            this.BtnRecibir.Text = "Actualizar";
            this.BtnRecibir.UseVisualStyleBackColor = true;
            this.BtnRecibir.Click += new System.EventHandler(this.BtnRecibir_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(317, 23);
            this.LblTitulo.TabIndex = 28;
            this.LblTitulo.Text = "PAGAR FACTURA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Número transaccion / número cheque";
            // 
            // TxbReferencia
            // 
            this.TxbReferencia.Location = new System.Drawing.Point(12, 337);
            this.TxbReferencia.Name = "TxbReferencia";
            this.TxbReferencia.Size = new System.Drawing.Size(294, 20);
            this.TxbReferencia.TabIndex = 33;
            // 
            // RbtnCheque
            // 
            this.RbtnCheque.AutoSize = true;
            this.RbtnCheque.Location = new System.Drawing.Point(56, 271);
            this.RbtnCheque.Name = "RbtnCheque";
            this.RbtnCheque.Size = new System.Drawing.Size(62, 17);
            this.RbtnCheque.TabIndex = 34;
            this.RbtnCheque.TabStop = true;
            this.RbtnCheque.Text = "Cheque";
            this.RbtnCheque.UseVisualStyleBackColor = true;
            // 
            // RbtnTransaccion
            // 
            this.RbtnTransaccion.AutoSize = true;
            this.RbtnTransaccion.Location = new System.Drawing.Point(194, 271);
            this.RbtnTransaccion.Name = "RbtnTransaccion";
            this.RbtnTransaccion.Size = new System.Drawing.Size(90, 17);
            this.RbtnTransaccion.TabIndex = 35;
            this.RbtnTransaccion.TabStop = true;
            this.RbtnTransaccion.Text = "Transferencia";
            this.RbtnTransaccion.UseVisualStyleBackColor = true;
            // 
            // FrmPagarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(317, 441);
            this.Controls.Add(this.RbtnTransaccion);
            this.Controls.Add(this.RbtnCheque);
            this.Controls.Add(this.TxbReferencia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LvInfoPieza);
            this.Controls.Add(this.BtnRecibir);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmPagarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPagarFactura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ListView LvInfoPieza;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BtnRecibir;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxbReferencia;
        private System.Windows.Forms.RadioButton RbtnCheque;
        private System.Windows.Forms.RadioButton RbtnTransaccion;
    }
}
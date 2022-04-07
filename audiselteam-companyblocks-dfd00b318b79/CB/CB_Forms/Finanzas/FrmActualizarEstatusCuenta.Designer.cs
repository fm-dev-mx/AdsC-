namespace CB
{
    partial class FrmActualizarEstarusCuenta
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
            this.NumDias = new System.Windows.Forms.NumericUpDown();
            this.BtnRecibir = new System.Windows.Forms.Button();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxbNumeroFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnBuscarPDF = new System.Windows.Forms.Button();
            this.TxtArchivoPdf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnBuscarXml = new System.Windows.Forms.Button();
            this.TxtArchivoXml = new System.Windows.Forms.TextBox();
            this.OFDBuscarArchivo = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.NumDias)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(12, 448);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(144, 41);
            this.BtnCancelar.TabIndex = 13;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click_1);
            // 
            // LvInfoPieza
            // 
            this.LvInfoPieza.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LvInfoPieza.Dock = System.Windows.Forms.DockStyle.Top;
            this.LvInfoPieza.Location = new System.Drawing.Point(0, 23);
            this.LvInfoPieza.Name = "LvInfoPieza";
            this.LvInfoPieza.Size = new System.Drawing.Size(319, 140);
            this.LvInfoPieza.TabIndex = 17;
            this.LvInfoPieza.UseCompatibleStateImageBehavior = false;
            this.LvInfoPieza.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 170;
            // 
            // NumDias
            // 
            this.NumDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumDias.Location = new System.Drawing.Point(165, 180);
            this.NumDias.Name = "NumDias";
            this.NumDias.Size = new System.Drawing.Size(88, 31);
            this.NumDias.TabIndex = 11;
            this.NumDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumDias.ValueChanged += new System.EventHandler(this.NumDias_ValueChanged);
            // 
            // BtnRecibir
            // 
            this.BtnRecibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRecibir.Location = new System.Drawing.Point(166, 448);
            this.BtnRecibir.Name = "BtnRecibir";
            this.BtnRecibir.Size = new System.Drawing.Size(140, 41);
            this.BtnRecibir.TabIndex = 14;
            this.BtnRecibir.Text = "Actualizar";
            this.BtnRecibir.UseVisualStyleBackColor = true;
            this.BtnRecibir.Click += new System.EventHandler(this.BtnRecibir_Click);
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.Location = new System.Drawing.Point(253, 182);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(56, 25);
            this.LblCantidad.TabIndex = 13;
            this.LblCantidad.Text = "días";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Términos de pago:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(319, 23);
            this.LblTitulo.TabIndex = 18;
            this.LblTitulo.Text = "CAPTURAR FACTURA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxbNumeroFactura
            // 
            this.TxbNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbNumeroFactura.Location = new System.Drawing.Point(12, 391);
            this.TxbNumeroFactura.Name = "TxbNumeroFactura";
            this.TxbNumeroFactura.Size = new System.Drawing.Size(294, 35);
            this.TxbNumeroFactura.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 375);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Número de factura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Archivo PDF:";
            // 
            // BtnBuscarPDF
            // 
            this.BtnBuscarPDF.Location = new System.Drawing.Point(218, 270);
            this.BtnBuscarPDF.Name = "BtnBuscarPDF";
            this.BtnBuscarPDF.Size = new System.Drawing.Size(88, 23);
            this.BtnBuscarPDF.TabIndex = 42;
            this.BtnBuscarPDF.Text = "Buscar";
            this.BtnBuscarPDF.UseVisualStyleBackColor = true;
            this.BtnBuscarPDF.Click += new System.EventHandler(this.BtnBuscarPDF_Click);
            // 
            // TxtArchivoPdf
            // 
            this.TxtArchivoPdf.Location = new System.Drawing.Point(12, 248);
            this.TxtArchivoPdf.Name = "TxtArchivoPdf";
            this.TxtArchivoPdf.ReadOnly = true;
            this.TxtArchivoPdf.Size = new System.Drawing.Size(294, 20);
            this.TxtArchivoPdf.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Archivo XML:";
            // 
            // BtnBuscarXml
            // 
            this.BtnBuscarXml.Location = new System.Drawing.Point(218, 341);
            this.BtnBuscarXml.Name = "BtnBuscarXml";
            this.BtnBuscarXml.Size = new System.Drawing.Size(88, 23);
            this.BtnBuscarXml.TabIndex = 45;
            this.BtnBuscarXml.Text = "Buscar";
            this.BtnBuscarXml.UseVisualStyleBackColor = true;
            this.BtnBuscarXml.Click += new System.EventHandler(this.BtnBuscarXml_Click);
            // 
            // TxtArchivoXml
            // 
            this.TxtArchivoXml.Location = new System.Drawing.Point(12, 319);
            this.TxtArchivoXml.Name = "TxtArchivoXml";
            this.TxtArchivoXml.ReadOnly = true;
            this.TxtArchivoXml.Size = new System.Drawing.Size(294, 20);
            this.TxtArchivoXml.TabIndex = 44;
            // 
            // OFDBuscarArchivo
            // 
            this.OFDBuscarArchivo.FileName = "openFileDialog1";
            // 
            // FrmActualizarEstarusCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(319, 501);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnBuscarXml);
            this.Controls.Add(this.TxtArchivoXml);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnBuscarPDF);
            this.Controls.Add(this.TxtArchivoPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxbNumeroFactura);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LvInfoPieza);
            this.Controls.Add(this.NumDias);
            this.Controls.Add(this.BtnRecibir);
            this.Controls.Add(this.LblCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmActualizarEstarusCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmActualizarEstarusCuenta";
            ((System.ComponentModel.ISupportInitialize)(this.NumDias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ListView LvInfoPieza;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.NumericUpDown NumDias;
        private System.Windows.Forms.Button BtnRecibir;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxbNumeroFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnBuscarPDF;
        private System.Windows.Forms.TextBox TxtArchivoPdf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnBuscarXml;
        private System.Windows.Forms.TextBox TxtArchivoXml;
        private System.Windows.Forms.OpenFileDialog OFDBuscarArchivo;
    }
}
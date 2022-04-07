namespace CB
{
    partial class FrmBajaAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBajaAlmacen));
            this.LblTitulo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.NumCantidad = new System.Windows.Forms.NumericUpDown();
            this.CmbIdReq = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnEntregar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.CmbUsuarios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(962, 23);
            this.LblTitulo.TabIndex = 35;
            this.LblTitulo.Text = "ENTREGAR PIEZAS ";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnImprimir);
            this.splitContainer1.Panel1.Controls.Add(this.NumCantidad);
            this.splitContainer1.Panel1.Controls.Add(this.CmbIdReq);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.BtnEntregar);
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer1.Panel1.Controls.Add(this.CmbUsuarios);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer1.Size = new System.Drawing.Size(962, 592);
            this.splitContainer1.SplitterDistance = 63;
            this.splitContainer1.TabIndex = 36;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.Image = global::CB_Base.Properties.Resources.pdf_48;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(617, 0);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(115, 63);
            this.BtnImprimir.TabIndex = 58;
            this.BtnImprimir.Text = "      Abrir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.button1_Click);
            // 
            // NumCantidad
            // 
            this.NumCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NumCantidad.Location = new System.Drawing.Point(428, 26);
            this.NumCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumCantidad.Name = "NumCantidad";
            this.NumCantidad.Size = new System.Drawing.Size(120, 26);
            this.NumCantidad.TabIndex = 57;
            this.NumCantidad.ValueChanged += new System.EventHandler(this.NumCantidad_ValueChanged);
            this.NumCantidad.Enter += new System.EventHandler(this.NumCantidad_Enter);
            // 
            // CmbIdReq
            // 
            this.CmbIdReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIdReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbIdReq.FormattingEnabled = true;
            this.CmbIdReq.Location = new System.Drawing.Point(324, 26);
            this.CmbIdReq.Name = "CmbIdReq";
            this.CmbIdReq.Size = new System.Drawing.Size(89, 28);
            this.CmbIdReq.TabIndex = 56;
            this.CmbIdReq.SelectedIndexChanged += new System.EventHandler(this.CmbIdReq_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Cantidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "# Material:";
            // 
            // BtnEntregar
            // 
            this.BtnEntregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEntregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEntregar.Location = new System.Drawing.Point(732, 0);
            this.BtnEntregar.Name = "BtnEntregar";
            this.BtnEntregar.Size = new System.Drawing.Size(115, 63);
            this.BtnEntregar.TabIndex = 53;
            this.BtnEntregar.Text = "Entregar";
            this.BtnEntregar.UseVisualStyleBackColor = true;
            this.BtnEntregar.Click += new System.EventHandler(this.BtnEntregar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(847, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(115, 63);
            this.BtnSalir.TabIndex = 52;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // CmbUsuarios
            // 
            this.CmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUsuarios.FormattingEnabled = true;
            this.CmbUsuarios.Location = new System.Drawing.Point(12, 26);
            this.CmbUsuarios.Name = "CmbUsuarios";
            this.CmbUsuarios.Size = new System.Drawing.Size(294, 28);
            this.CmbUsuarios.TabIndex = 51;
            this.CmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.CmbUsuarios_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Recibe:";
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(962, 525);
            this.VisorPDF.TabIndex = 2;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // FrmBajaAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 615);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBajaAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBajaAlmacen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBajaAlmacen_FormClosing);
            this.Load += new System.EventHandler(this.FrmBajaAlmacen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox CmbUsuarios;
        private System.Windows.Forms.Label label2;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Button BtnEntregar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ComboBox CmbIdReq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumCantidad;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}
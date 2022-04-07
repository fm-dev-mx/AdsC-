namespace CB
{
    partial class FrmGenerarReportePO
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.LblFechaHasta = new System.Windows.Forms.Label();
            this.DtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.LblFechaInicio = new System.Windows.Forms.Label();
            this.DgvReporte = new System.Windows.Forms.DataGridView();
            this.po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.audiselTituloForm1);
            this.panel1.Controls.Add(this.DtpFechaFin);
            this.panel1.Controls.Add(this.LblFechaHasta);
            this.panel1.Controls.Add(this.DtpFechaInicio);
            this.panel1.Controls.Add(this.LblFechaInicio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 78);
            this.panel1.TabIndex = 1;
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(584, 23);
            this.audiselTituloForm1.TabIndex = 4;
            this.audiselTituloForm1.Text = "REPORTE DE ORDENES DE COMPRAS";
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaFin.Location = new System.Drawing.Point(294, 46);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(280, 26);
            this.DtpFechaFin.TabIndex = 3;
            this.DtpFechaFin.ValueChanged += new System.EventHandler(this.DtpFechaFin_ValueChanged);
            // 
            // LblFechaHasta
            // 
            this.LblFechaHasta.AutoSize = true;
            this.LblFechaHasta.Location = new System.Drawing.Point(291, 30);
            this.LblFechaHasta.Name = "LblFechaHasta";
            this.LblFechaHasta.Size = new System.Drawing.Size(69, 13);
            this.LblFechaHasta.TabIndex = 2;
            this.LblFechaHasta.Text = "Fecha hasta:";
            // 
            // DtpFechaInicio
            // 
            this.DtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaInicio.Location = new System.Drawing.Point(8, 46);
            this.DtpFechaInicio.Name = "DtpFechaInicio";
            this.DtpFechaInicio.Size = new System.Drawing.Size(280, 26);
            this.DtpFechaInicio.TabIndex = 1;
            this.DtpFechaInicio.ValueChanged += new System.EventHandler(this.DtpFechaInicio_ValueChanged);
            // 
            // LblFechaInicio
            // 
            this.LblFechaInicio.AutoSize = true;
            this.LblFechaInicio.Location = new System.Drawing.Point(5, 30);
            this.LblFechaInicio.Name = "LblFechaInicio";
            this.LblFechaInicio.Size = new System.Drawing.Size(92, 13);
            this.LblFechaInicio.TabIndex = 0;
            this.LblFechaInicio.Text = "Fecha a partir del:";
            // 
            // DgvReporte
            // 
            this.DgvReporte.AllowUserToAddRows = false;
            this.DgvReporte.AllowUserToDeleteRows = false;
            this.DgvReporte.AllowUserToResizeRows = false;
            this.DgvReporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.po,
            this.estatus,
            this.sub_total,
            this.moneda});
            this.DgvReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvReporte.Location = new System.Drawing.Point(0, 78);
            this.DgvReporte.Name = "DgvReporte";
            this.DgvReporte.RowHeadersVisible = false;
            this.DgvReporte.Size = new System.Drawing.Size(584, 329);
            this.DgvReporte.TabIndex = 2;
            // 
            // po
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.po.DefaultCellStyle = dataGridViewCellStyle1;
            this.po.HeaderText = "PO";
            this.po.MinimumWidth = 60;
            this.po.Name = "po";
            this.po.ReadOnly = true;
            this.po.Width = 60;
            // 
            // estatus
            // 
            this.estatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            // 
            // sub_total
            // 
            this.sub_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sub_total.HeaderText = "Subtotal";
            this.sub_total.Name = "sub_total";
            this.sub_total.ReadOnly = true;
            // 
            // moneda
            // 
            this.moneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.moneda.DefaultCellStyle = dataGridViewCellStyle3;
            this.moneda.HeaderText = "moneda";
            this.moneda.Name = "moneda";
            this.moneda.ReadOnly = true;
            // 
            // FrmGenerarReportePO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 407);
            this.Controls.Add(this.DgvReporte);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGenerarReportePO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar reporte de PO";
            this.Load += new System.EventHandler(this.FrmGenerarReportePO_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Label LblFechaHasta;
        private System.Windows.Forms.DateTimePicker DtpFechaInicio;
        private System.Windows.Forms.Label LblFechaInicio;
        private System.Windows.Forms.DataGridView DgvReporte;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.DataGridViewTextBoxColumn po;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
    }
}
namespace CB
{
    partial class FrmBuscadorKPIs
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblFiltoGrafica = new System.Windows.Forms.Label();
            this.DateFechaSeleccionada = new System.Windows.Forms.DateTimePicker();
            this.CmbIntervalo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbIndicador = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbProceso = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(1132, 23);
            this.LblTitulo.TabIndex = 19;
            this.LblTitulo.Text = "INDICADORES CLAVE DE RENDIMIENTO (KPI)";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.LblFiltoGrafica);
            this.panel1.Controls.Add(this.DateFechaSeleccionada);
            this.panel1.Controls.Add(this.CmbIntervalo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbIndicador);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.CmbProceso);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 109);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(978, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 109);
            this.panel2.TabIndex = 36;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer1.Size = new System.Drawing.Size(154, 109);
            this.splitContainer1.SplitterDistance = 61;
            this.splitContainer1.TabIndex = 0;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(154, 61);
            this.BtnSalir.TabIndex = 32;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblFiltoGrafica
            // 
            this.LblFiltoGrafica.AutoSize = true;
            this.LblFiltoGrafica.Location = new System.Drawing.Point(353, 5);
            this.LblFiltoGrafica.Name = "LblFiltoGrafica";
            this.LblFiltoGrafica.Size = new System.Drawing.Size(120, 13);
            this.LblFiltoGrafica.TabIndex = 35;
            this.LblFiltoGrafica.Text = "Mostrar información por:";
            // 
            // DateFechaSeleccionada
            // 
            this.DateFechaSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFechaSeleccionada.Location = new System.Drawing.Point(636, 19);
            this.DateFechaSeleccionada.Name = "DateFechaSeleccionada";
            this.DateFechaSeleccionada.Size = new System.Drawing.Size(301, 26);
            this.DateFechaSeleccionada.TabIndex = 34;
            this.DateFechaSeleccionada.ValueChanged += new System.EventHandler(this.DateFechaSeleccionada_ValueChanged);
            // 
            // CmbIntervalo
            // 
            this.CmbIntervalo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIntervalo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbIntervalo.FormattingEnabled = true;
            this.CmbIntervalo.Items.AddRange(new object[] {
            "DIA",
            "SEMANA",
            "MES",
            "AÑO"});
            this.CmbIntervalo.Location = new System.Drawing.Point(353, 21);
            this.CmbIntervalo.Name = "CmbIntervalo";
            this.CmbIntervalo.Size = new System.Drawing.Size(263, 28);
            this.CmbIntervalo.TabIndex = 33;
            this.CmbIntervalo.SelectedIndexChanged += new System.EventHandler(this.CmbIntervalo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Indicador:";
            // 
            // CmbIndicador
            // 
            this.CmbIndicador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIndicador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbIndicador.FormattingEnabled = true;
            this.CmbIndicador.Location = new System.Drawing.Point(9, 70);
            this.CmbIndicador.Name = "CmbIndicador";
            this.CmbIndicador.Size = new System.Drawing.Size(607, 28);
            this.CmbIndicador.TabIndex = 30;
            this.CmbIndicador.SelectedIndexChanged += new System.EventHandler(this.CmbIndicador_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Proceso:";
            // 
            // CmbProceso
            // 
            this.CmbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProceso.FormattingEnabled = true;
            this.CmbProceso.Location = new System.Drawing.Point(9, 21);
            this.CmbProceso.Name = "CmbProceso";
            this.CmbProceso.Size = new System.Drawing.Size(333, 28);
            this.CmbProceso.TabIndex = 28;
            this.CmbProceso.SelectedIndexChanged += new System.EventHandler(this.CmbProceso_SelectedIndexChanged);
            // 
            // FrmBuscadorKPIs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 490);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "FrmBuscadorKPIs";
            this.Text = "Indicadores clave de proceso (KPI)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmKPIs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbIndicador;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbProceso;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblFiltoGrafica;
        private System.Windows.Forms.DateTimePicker DateFechaSeleccionada;
        private System.Windows.Forms.ComboBox CmbIntervalo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
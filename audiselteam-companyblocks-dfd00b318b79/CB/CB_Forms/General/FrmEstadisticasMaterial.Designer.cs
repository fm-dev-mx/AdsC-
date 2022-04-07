namespace CB
{
    partial class FrmEstadisticasMaterial
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstadisticasMaterial));
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ChartCompras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.NumYear = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ImagenesTabs = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartCompras)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumYear)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(978, 23);
            this.LblTitulo.TabIndex = 69;
            this.LblTitulo.Text = "ESTADISTICAS DEL MATERIAL";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtDescripcion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtFabricante);
            this.panel1.Controls.Add(this.TxtNumeroParte);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 195);
            this.panel1.TabIndex = 70;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(794, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 68);
            this.panel2.TabIndex = 12;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(55, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(129, 68);
            this.BtnSalir.TabIndex = 59;
            this.BtnSalir.Text = "     Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Descripción:";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.AcceptsTab = true;
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtDescripcion.Location = new System.Drawing.Point(0, 68);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.Size = new System.Drawing.Size(978, 127);
            this.TxtDescripcion.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fabricante:";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(356, 20);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(343, 29);
            this.TxtFabricante.TabIndex = 7;
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(7, 20);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(343, 29);
            this.TxtNumeroParte.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de parte:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.ImagenesTabs;
            this.tabControl1.Location = new System.Drawing.Point(0, 218);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 375);
            this.tabControl1.TabIndex = 71;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ChartCompras);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(970, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Historial de compra";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ChartCompras
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartCompras.ChartAreas.Add(chartArea1);
            this.ChartCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.ChartCompras.Legends.Add(legend1);
            this.ChartCompras.Location = new System.Drawing.Point(3, 70);
            this.ChartCompras.Name = "ChartCompras";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChartCompras.Series.Add(series1);
            this.ChartCompras.Size = new System.Drawing.Size(964, 259);
            this.ChartCompras.TabIndex = 14;
            this.ChartCompras.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.NumYear);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(964, 67);
            this.panel3.TabIndex = 15;
            // 
            // NumYear
            // 
            this.NumYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumYear.Location = new System.Drawing.Point(18, 25);
            this.NumYear.Maximum = new decimal(new int[] {
            2060,
            0,
            0,
            0});
            this.NumYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.NumYear.Name = "NumYear";
            this.NumYear.Size = new System.Drawing.Size(120, 29);
            this.NumYear.TabIndex = 0;
            this.NumYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.NumYear.ValueChanged += new System.EventHandler(this.NumYear_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Año:";
            // 
            // tabPage2
            // 
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(970, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Precio y tiempo de entrega";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ImagenesTabs
            // 
            this.ImagenesTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTabs.ImageStream")));
            this.ImagenesTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTabs.Images.SetKeyName(0, "price.ico");
            this.ImagenesTabs.Images.SetKeyName(1, "histo.png");
            // 
            // FrmEstadisticasMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 593);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEstadisticasMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas del material";
            this.Load += new System.EventHandler(this.FrmEstadisticasMaterial_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartCompras)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList ImagenesTabs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartCompras;
        private System.Windows.Forms.Panel panel3;
    }
}
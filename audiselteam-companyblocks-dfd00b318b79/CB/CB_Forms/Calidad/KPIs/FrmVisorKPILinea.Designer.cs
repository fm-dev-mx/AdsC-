namespace CB
{
    partial class FrmVisorKPILinea
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("General", System.Windows.Forms.HorizontalAlignment.Left);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumFactorEscala = new System.Windows.Forms.NumericUpDown();
            this.BtnAcciones = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ChartIndicadores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ListaEstadisticas = new System.Windows.Forms.ListView();
            this.detalles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnEscalaAuto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumFactorEscala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartIndicadores)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnEscalaAuto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NumFactorEscala);
            this.panel1.Controls.Add(this.BtnAcciones);
            this.panel1.Controls.Add(this.BtnActualizar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LblEstatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 64);
            this.panel1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(740, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Factor de escala:";
            // 
            // NumFactorEscala
            // 
            this.NumFactorEscala.DecimalPlaces = 1;
            this.NumFactorEscala.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumFactorEscala.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumFactorEscala.Location = new System.Drawing.Point(743, 28);
            this.NumFactorEscala.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumFactorEscala.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumFactorEscala.Name = "NumFactorEscala";
            this.NumFactorEscala.Size = new System.Drawing.Size(96, 29);
            this.NumFactorEscala.TabIndex = 47;
            this.NumFactorEscala.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumFactorEscala.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumFactorEscala.ValueChanged += new System.EventHandler(this.NumFactorEscala_ValueChanged);
            // 
            // BtnAcciones
            // 
            this.BtnAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAcciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAcciones.Image = global::CB_Base.Properties.Resources.order;
            this.BtnAcciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAcciones.Location = new System.Drawing.Point(966, 0);
            this.BtnAcciones.Name = "BtnAcciones";
            this.BtnAcciones.Size = new System.Drawing.Size(138, 64);
            this.BtnAcciones.TabIndex = 44;
            this.BtnAcciones.Text = "         Acciones";
            this.BtnAcciones.UseVisualStyleBackColor = true;
            this.BtnAcciones.Click += new System.EventHandler(this.BtnAcciones_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.update;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(1104, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(136, 64);
            this.BtnActualizar.TabIndex = 43;
            this.BtnActualizar.Text = "     Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Estatus del indicador en el periodo seleccionado:";
            // 
            // LblEstatus
            // 
            this.LblEstatus.BackColor = System.Drawing.Color.Black;
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.ForeColor = System.Drawing.Color.White;
            this.LblEstatus.Location = new System.Drawing.Point(12, 28);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(233, 23);
            this.LblEstatus.TabIndex = 45;
            this.LblEstatus.Text = "EN INCUMPLIMIENTO";
            this.LblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ChartIndicadores);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ListaEstadisticas);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(1240, 685);
            this.splitContainer1.SplitterDistance = 839;
            this.splitContainer1.TabIndex = 25;
            // 
            // ChartIndicadores
            // 
            chartArea3.AxisX.InterlacedColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea3.AxisX.Title = "dato";
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.Interval = 5D;
            chartArea3.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisY.LogarithmBase = 2D;
            chartArea3.AxisY.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
            chartArea3.AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 3;
            chartArea3.AxisY.ScaleBreakStyle.Spacing = 1.2D;
            chartArea3.AxisY.Title = "Productividad";
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BackSecondaryColor = System.Drawing.Color.Black;
            chartArea3.Name = "ChartArea1";
            this.ChartIndicadores.ChartAreas.Add(chartArea3);
            this.ChartIndicadores.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.ChartIndicadores.Legends.Add(legend3);
            this.ChartIndicadores.Location = new System.Drawing.Point(0, 0);
            this.ChartIndicadores.Name = "ChartIndicadores";
            series11.BorderWidth = 5;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.SystemColors.MenuHighlight;
            series11.EmptyPointStyle.IsValueShownAsLabel = true;
            series11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series11.Label = "test";
            series11.LabelAngle = 25;
            series11.LabelBackColor = System.Drawing.Color.Transparent;
            series11.LabelBorderColor = System.Drawing.Color.Transparent;
            series11.Legend = "Legend1";
            series11.MarkerColor = System.Drawing.Color.RoyalBlue;
            series11.MarkerSize = 10;
            series11.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            series11.Name = "Series1";
            series12.BorderWidth = 3;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Color = System.Drawing.Color.MediumSlateBlue;
            series12.Legend = "Legend1";
            series12.LegendText = "Tendencia";
            series12.Name = "tendencia";
            series13.BorderColor = System.Drawing.Color.Transparent;
            series13.BorderWidth = 3;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Color = System.Drawing.Color.Green;
            series13.Legend = "Legend1";
            series13.Name = "Meta";
            series14.BorderWidth = 3;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Color = System.Drawing.Color.Gold;
            series14.Legend = "Legend1";
            series14.Name = "Alerta";
            series15.BorderWidth = 3;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Color = System.Drawing.Color.Crimson;
            series15.Legend = "Legend1";
            series15.Name = "Incumplimiento";
            this.ChartIndicadores.Series.Add(series11);
            this.ChartIndicadores.Series.Add(series12);
            this.ChartIndicadores.Series.Add(series13);
            this.ChartIndicadores.Series.Add(series14);
            this.ChartIndicadores.Series.Add(series15);
            this.ChartIndicadores.Size = new System.Drawing.Size(839, 685);
            this.ChartIndicadores.TabIndex = 23;
            this.ChartIndicadores.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "titulo";
            title3.Text = "Título de indicador";
            this.ChartIndicadores.Titles.Add(title3);
            // 
            // ListaEstadisticas
            // 
            this.ListaEstadisticas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.detalles,
            this.valor});
            this.ListaEstadisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup3.Header = "General";
            listViewGroup3.Name = "General";
            listViewGroup3.Tag = "General";
            this.ListaEstadisticas.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.ListaEstadisticas.Location = new System.Drawing.Point(0, 23);
            this.ListaEstadisticas.Name = "ListaEstadisticas";
            this.ListaEstadisticas.Size = new System.Drawing.Size(397, 662);
            this.ListaEstadisticas.TabIndex = 26;
            this.ListaEstadisticas.UseCompatibleStateImageBehavior = false;
            this.ListaEstadisticas.View = System.Windows.Forms.View.Details;
            // 
            // detalles
            // 
            this.detalles.Text = "Detalles";
            this.detalles.Width = 224;
            // 
            // valor
            // 
            this.valor.Text = "Valor";
            this.valor.Width = 137;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(397, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "ESTADISTICAS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnEscalaAuto
            // 
            this.BtnEscalaAuto.Location = new System.Drawing.Point(843, 28);
            this.BtnEscalaAuto.Name = "BtnEscalaAuto";
            this.BtnEscalaAuto.Size = new System.Drawing.Size(75, 23);
            this.BtnEscalaAuto.TabIndex = 49;
            this.BtnEscalaAuto.Text = "Auto";
            this.BtnEscalaAuto.UseVisualStyleBackColor = true;
            this.BtnEscalaAuto.Click += new System.EventHandler(this.BtnEscalaAuto_Click);
            // 
            // FrmVisorKPILinea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 749);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVisorKPILinea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor KPI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmVisorKPILinea_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumFactorEscala)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartIndicadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.Button BtnAcciones;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartIndicadores;
        private System.Windows.Forms.ListView ListaEstadisticas;
        private System.Windows.Forms.ColumnHeader detalles;
        private System.Windows.Forms.ColumnHeader valor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumFactorEscala;
        private System.Windows.Forms.Button BtnEscalaAuto;
    }
}
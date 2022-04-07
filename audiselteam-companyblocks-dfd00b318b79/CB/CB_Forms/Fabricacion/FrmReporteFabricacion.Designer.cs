namespace CB
{
    partial class FrmReporteFabricacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblTipoSeleccion = new System.Windows.Forms.Label();
            this.DtDia = new System.Windows.Forms.DateTimePicker();
            this.NumSemana = new System.Windows.Forms.NumericUpDown();
            this.CmbMes = new System.Windows.Forms.ComboBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.label5 = new System.Windows.Forms.Label();
            this.NumObjetivo = new System.Windows.Forms.NumericUpDown();
            this.NumAnio = new System.Windows.Forms.NumericUpDown();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumObjetivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Para:";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Image = global::CB_Base.Properties.Resources.search_icon_48;
            this.button1.Location = new System.Drawing.Point(889, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 43);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.Dock = System.Windows.Forms.DockStyle.Left;
            this.TxtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreo.Location = new System.Drawing.Point(0, 0);
            this.TxtCorreo.Multiline = true;
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtCorreo.Size = new System.Drawing.Size(883, 43);
            this.TxtCorreo.TabIndex = 3;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.Location = new System.Drawing.Point(43, 617);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentarios.Size = new System.Drawing.Size(956, 66);
            this.TxtComentarios.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 596);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comentarios:";
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviar.Image = global::CB_Base.Properties.Resources.ok_48;
            this.BtnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEnviar.Location = new System.Drawing.Point(838, 689);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(161, 50);
            this.BtnEnviar.TabIndex = 6;
            this.BtnEnviar.Text = "    Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(671, 689);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(161, 50);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtCorreo);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(43, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 43);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Location = new System.Drawing.Point(43, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 282);
            this.panel2.TabIndex = 9;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(956, 282);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Detalles:";
            // 
            // CmbTipoReporte
            // 
            this.CmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoReporte.FormattingEnabled = true;
            this.CmbTipoReporte.Items.AddRange(new object[] {
            "Por día",
            "Por semana",
            "Por mes",
            "Por año",
            "--SELECCIONE--"});
            this.CmbTipoReporte.Location = new System.Drawing.Point(43, 90);
            this.CmbTipoReporte.Name = "CmbTipoReporte";
            this.CmbTipoReporte.Size = new System.Drawing.Size(221, 24);
            this.CmbTipoReporte.TabIndex = 1;
            this.CmbTipoReporte.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tipo de reporte:";
            // 
            // LblTipoSeleccion
            // 
            this.LblTipoSeleccion.AutoSize = true;
            this.LblTipoSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipoSeleccion.Location = new System.Drawing.Point(396, 68);
            this.LblTipoSeleccion.Name = "LblTipoSeleccion";
            this.LblTipoSeleccion.Size = new System.Drawing.Size(123, 18);
            this.LblTipoSeleccion.TabIndex = 13;
            this.LblTipoSeleccion.Text = "Seleccione el dia:";
            // 
            // DtDia
            // 
            this.DtDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtDia.Location = new System.Drawing.Point(399, 89);
            this.DtDia.Name = "DtDia";
            this.DtDia.Size = new System.Drawing.Size(229, 22);
            this.DtDia.TabIndex = 14;
            this.DtDia.ValueChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // NumSemana
            // 
            this.NumSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumSemana.Location = new System.Drawing.Point(741, 69);
            this.NumSemana.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.NumSemana.Name = "NumSemana";
            this.NumSemana.Size = new System.Drawing.Size(120, 22);
            this.NumSemana.TabIndex = 15;
            this.NumSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSemana.ValueChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // CmbMes
            // 
            this.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMes.FormattingEnabled = true;
            this.CmbMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.CmbMes.Location = new System.Drawing.Point(741, 97);
            this.CmbMes.Name = "CmbMes";
            this.CmbMes.Size = new System.Drawing.Size(133, 24);
            this.CmbMes.TabIndex = 16;
            this.CmbMes.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(696, 428);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(20, 20);
            this.webBrowser1.TabIndex = 17;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(43, 426);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(956, 167);
            this.webBrowser2.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(270, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Objetivo:";
            // 
            // NumObjetivo
            // 
            this.NumObjetivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumObjetivo.Location = new System.Drawing.Point(273, 90);
            this.NumObjetivo.Name = "NumObjetivo";
            this.NumObjetivo.Size = new System.Drawing.Size(120, 22);
            this.NumObjetivo.TabIndex = 20;
            this.NumObjetivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumObjetivo.ValueChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // NumAnio
            // 
            this.NumAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumAnio.Location = new System.Drawing.Point(867, 72);
            this.NumAnio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumAnio.Name = "NumAnio";
            this.NumAnio.Size = new System.Drawing.Size(120, 22);
            this.NumAnio.TabIndex = 21;
            this.NumAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumAnio.ValueChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(1011, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "REPORTE DE FABRICACIÓN";
            // 
            // FrmReporteFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 751);
            this.Controls.Add(this.NumAnio);
            this.Controls.Add(this.NumObjetivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.CmbMes);
            this.Controls.Add(this.NumSemana);
            this.Controls.Add(this.DtDia);
            this.Controls.Add(this.LblTipoSeleccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbTipoReporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.TxtComentarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReporteFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de fabricación";
            this.Load += new System.EventHandler(this.FrmReporteFabricacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumObjetivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtCorreo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbTipoReporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblTipoSeleccion;
        private System.Windows.Forms.DateTimePicker DtDia;
        private System.Windows.Forms.NumericUpDown NumSemana;
        private System.Windows.Forms.ComboBox CmbMes;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumObjetivo;
        private System.Windows.Forms.NumericUpDown NumAnio;
    }
}
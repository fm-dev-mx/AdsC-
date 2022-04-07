namespace CB
{
    partial class FrmSubirPlanoPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSubirPlanoPDF));
            this.LblTitulo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnBuscarDXF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtArchivoDXF = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbPresentacion = new System.Windows.Forms.ComboBox();
            this.cmbTipoTrabajo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblPresentacion = new System.Windows.Forms.Label();
            this.NumCantidad = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.LblInfo = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblAncho = new System.Windows.Forms.Label();
            this.LblLargo = new System.Windows.Forms.Label();
            this.LblEspesor = new System.Windows.Forms.Label();
            this.TxtAncho = new System.Windows.Forms.TextBox();
            this.TxtLargo = new System.Windows.Forms.TextBox();
            this.TxtEspesor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBuscarPDF = new System.Windows.Forms.Button();
            this.TxtArchivoPDF = new System.Windows.Forms.TextBox();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.abrirArchivo = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(995, 25);
            this.LblTitulo.TabIndex = 29;
            this.LblTitulo.Text = "SUBIR PLANO DESDE PDF";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnBuscarDXF);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.TxtArchivoDXF);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.NumCantidad);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.LblInfo);
            this.splitContainer1.Panel1.Controls.Add(this.BtnCerrar);
            this.splitContainer1.Panel1.Controls.Add(this.BtnFinalizar);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.BtnBuscarPDF);
            this.splitContainer1.Panel1.Controls.Add(this.TxtArchivoPDF);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer1.Size = new System.Drawing.Size(995, 584);
            this.splitContainer1.SplitterDistance = 298;
            this.splitContainer1.TabIndex = 30;
            // 
            // BtnBuscarDXF
            // 
            this.BtnBuscarDXF.Location = new System.Drawing.Point(197, 125);
            this.BtnBuscarDXF.Name = "BtnBuscarDXF";
            this.BtnBuscarDXF.Size = new System.Drawing.Size(88, 23);
            this.BtnBuscarDXF.TabIndex = 32;
            this.BtnBuscarDXF.Text = "Buscar";
            this.BtnBuscarDXF.UseVisualStyleBackColor = true;
            this.BtnBuscarDXF.Click += new System.EventHandler(this.BtnBuscarDXF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Archivo DXF";
            // 
            // TxtArchivoDXF
            // 
            this.TxtArchivoDXF.Location = new System.Drawing.Point(13, 99);
            this.TxtArchivoDXF.Name = "TxtArchivoDXF";
            this.TxtArchivoDXF.ReadOnly = true;
            this.TxtArchivoDXF.Size = new System.Drawing.Size(272, 20);
            this.TxtArchivoDXF.TabIndex = 30;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbPresentacion);
            this.groupBox2.Controls.Add(this.cmbTipoTrabajo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.LblPresentacion);
            this.groupBox2.Location = new System.Drawing.Point(13, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 116);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información básica";
            // 
            // cmbPresentacion
            // 
            this.cmbPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPresentacion.FormattingEnabled = true;
            this.cmbPresentacion.Items.AddRange(new object[] {
            "PLACA",
            "PRISMA",
            "CILINDRO",
            "ANGULO",
            "FIXTURA"});
            this.cmbPresentacion.Location = new System.Drawing.Point(9, 80);
            this.cmbPresentacion.Name = "cmbPresentacion";
            this.cmbPresentacion.Size = new System.Drawing.Size(247, 21);
            this.cmbPresentacion.TabIndex = 7;
            this.cmbPresentacion.SelectedIndexChanged += new System.EventHandler(this.cmbPresentacion_SelectedIndexChanged);
            // 
            // cmbTipoTrabajo
            // 
            this.cmbTipoTrabajo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoTrabajo.FormattingEnabled = true;
            this.cmbTipoTrabajo.Items.AddRange(new object[] {
            "REGULAR",
            "WATER JET",
            "LASER",
            "REWORK",
            "EXTRA WORK"});
            this.cmbTipoTrabajo.Location = new System.Drawing.Point(8, 40);
            this.cmbTipoTrabajo.Name = "cmbTipoTrabajo";
            this.cmbTipoTrabajo.Size = new System.Drawing.Size(248, 21);
            this.cmbTipoTrabajo.TabIndex = 3;
            this.cmbTipoTrabajo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTrabajo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de trabajo:";
            // 
            // LblPresentacion
            // 
            this.LblPresentacion.AutoSize = true;
            this.LblPresentacion.Location = new System.Drawing.Point(6, 64);
            this.LblPresentacion.Name = "LblPresentacion";
            this.LblPresentacion.Size = new System.Drawing.Size(72, 13);
            this.LblPresentacion.TabIndex = 8;
            this.LblPresentacion.Text = "Presentación:";
            // 
            // NumCantidad
            // 
            this.NumCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumCantidad.Location = new System.Drawing.Point(13, 416);
            this.NumCantidad.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.NumCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumCantidad.Name = "NumCantidad";
            this.NumCantidad.Size = new System.Drawing.Size(130, 29);
            this.NumCantidad.TabIndex = 26;
            this.NumCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Cantidad:";
            // 
            // LblInfo
            // 
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.ForeColor = System.Drawing.Color.Red;
            this.LblInfo.Location = new System.Drawing.Point(10, 510);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(275, 42);
            this.LblInfo.TabIndex = 24;
            this.LblInfo.Text = "Info";
            this.LblInfo.Visible = false;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(13, 460);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(130, 38);
            this.BtnCerrar.TabIndex = 18;
            this.BtnCerrar.Text = "     Cancelar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(157, 460);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(130, 38);
            this.BtnFinalizar.TabIndex = 19;
            this.BtnFinalizar.Text = "     Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblAncho);
            this.groupBox1.Controls.Add(this.LblLargo);
            this.groupBox1.Controls.Add(this.LblEspesor);
            this.groupBox1.Controls.Add(this.TxtAncho);
            this.groupBox1.Controls.Add(this.TxtLargo);
            this.groupBox1.Controls.Add(this.TxtEspesor);
            this.groupBox1.Location = new System.Drawing.Point(13, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 110);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimensiones";
            // 
            // LblAncho
            // 
            this.LblAncho.AutoSize = true;
            this.LblAncho.Location = new System.Drawing.Point(57, 76);
            this.LblAncho.Name = "LblAncho";
            this.LblAncho.Size = new System.Drawing.Size(41, 13);
            this.LblAncho.TabIndex = 26;
            this.LblAncho.Text = "Ancho:";
            // 
            // LblLargo
            // 
            this.LblLargo.AutoSize = true;
            this.LblLargo.Location = new System.Drawing.Point(61, 50);
            this.LblLargo.Name = "LblLargo";
            this.LblLargo.Size = new System.Drawing.Size(37, 13);
            this.LblLargo.TabIndex = 25;
            this.LblLargo.Text = "Largo:";
            // 
            // LblEspesor
            // 
            this.LblEspesor.AutoSize = true;
            this.LblEspesor.Location = new System.Drawing.Point(50, 24);
            this.LblEspesor.Name = "LblEspesor";
            this.LblEspesor.Size = new System.Drawing.Size(48, 13);
            this.LblEspesor.TabIndex = 24;
            this.LblEspesor.Text = "Espesor:";
            // 
            // TxtAncho
            // 
            this.TxtAncho.Location = new System.Drawing.Point(104, 73);
            this.TxtAncho.Name = "TxtAncho";
            this.TxtAncho.Size = new System.Drawing.Size(111, 20);
            this.TxtAncho.TabIndex = 2;
            // 
            // TxtLargo
            // 
            this.TxtLargo.Location = new System.Drawing.Point(104, 47);
            this.TxtLargo.Name = "TxtLargo";
            this.TxtLargo.Size = new System.Drawing.Size(111, 20);
            this.TxtLargo.TabIndex = 1;
            // 
            // TxtEspesor
            // 
            this.TxtEspesor.Location = new System.Drawing.Point(104, 21);
            this.TxtEspesor.Name = "TxtEspesor";
            this.TxtEspesor.Size = new System.Drawing.Size(111, 20);
            this.TxtEspesor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Archivo PDF";
            // 
            // BtnBuscarPDF
            // 
            this.BtnBuscarPDF.Location = new System.Drawing.Point(197, 57);
            this.BtnBuscarPDF.Name = "BtnBuscarPDF";
            this.BtnBuscarPDF.Size = new System.Drawing.Size(88, 23);
            this.BtnBuscarPDF.TabIndex = 1;
            this.BtnBuscarPDF.Text = "Buscar";
            this.BtnBuscarPDF.UseVisualStyleBackColor = true;
            this.BtnBuscarPDF.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtArchivoPDF
            // 
            this.TxtArchivoPDF.Location = new System.Drawing.Point(13, 31);
            this.TxtArchivoPDF.Name = "TxtArchivoPDF";
            this.TxtArchivoPDF.ReadOnly = true;
            this.TxtArchivoPDF.Size = new System.Drawing.Size(272, 20);
            this.TxtArchivoPDF.TabIndex = 0;
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(693, 584);
            this.VisorPDF.TabIndex = 0;
            // 
            // FrmSubirPlanoPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 609);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmSubirPlanoPDF";
            this.Text = "Subir plano PDF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSubirPlanoPDF_FormClosed);
            this.Load += new System.EventHandler(this.FrmSubirPlanoPDF_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBuscarPDF;
        private System.Windows.Forms.TextBox TxtArchivoPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoTrabajo;
        private System.Windows.Forms.Label LblPresentacion;
        private System.Windows.Forms.ComboBox cmbPresentacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Label LblAncho;
        private System.Windows.Forms.Label LblLargo;
        private System.Windows.Forms.Label LblEspesor;
        private System.Windows.Forms.TextBox TxtAncho;
        private System.Windows.Forms.TextBox TxtLargo;
        private System.Windows.Forms.TextBox TxtEspesor;
        private System.Windows.Forms.OpenFileDialog abrirArchivo;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.NumericUpDown NumCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtArchivoDXF;
        private System.Windows.Forms.Button BtnBuscarDXF;
    }
}
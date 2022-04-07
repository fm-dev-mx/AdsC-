namespace CB
{
    partial class FrmGenerarValeSalidaPendienteTratamiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenerarValeSalidaPendienteTratamiento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtPersonaEntrega = new System.Windows.Forms.TextBox();
            this.CmbProveedor = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.BkgGuardarVale = new System.ComponentModel.BackgroundWorker();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtPersonaEntrega);
            this.panel1.Controls.Add(this.CmbProveedor);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 94);
            this.panel1.TabIndex = 0;
            // 
            // TxtPersonaEntrega
            // 
            this.TxtPersonaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtPersonaEntrega.Location = new System.Drawing.Point(335, 47);
            this.TxtPersonaEntrega.Name = "TxtPersonaEntrega";
            this.TxtPersonaEntrega.ReadOnly = true;
            this.TxtPersonaEntrega.Size = new System.Drawing.Size(314, 29);
            this.TxtPersonaEntrega.TabIndex = 64;
            // 
            // CmbProveedor
            // 
            this.CmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProveedor.FormattingEnabled = true;
            this.CmbProveedor.Location = new System.Drawing.Point(14, 47);
            this.CmbProveedor.Name = "CmbProveedor";
            this.CmbProveedor.Size = new System.Drawing.Size(315, 32);
            this.CmbProveedor.TabIndex = 63;
            this.CmbProveedor.SelectedIndexChanged += new System.EventHandler(this.CmbProveedor_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 23);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 71);
            this.splitter1.TabIndex = 62;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnAceptar);
            this.panel3.Controls.Add(this.BtnCancelar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(814, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 71);
            this.panel3.TabIndex = 61;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAceptar.Image")));
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(4, 0);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(142, 71);
            this.BtnAceptar.TabIndex = 55;
            this.BtnAceptar.Text = "     Entregar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.Image")));
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(146, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(138, 71);
            this.BtnCancelar.TabIndex = 56;
            this.BtnCancelar.Text = "    Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Persona que entrega:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1098, 23);
            this.label4.TabIndex = 56;
            this.label4.Text = "VALE DE SALIDA DE PIEZAS A TRATAMIENTO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label4_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1098, 23);
            this.label6.TabIndex = 59;
            this.label6.Text = "VALE DE SALIDA";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 117);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(1098, 420);
            this.VisorPDF.TabIndex = 60;
            // 
            // BkgGuardarVale
            // 
            this.BkgGuardarVale.WorkerReportsProgress = true;
            this.BkgGuardarVale.WorkerSupportsCancellation = true;
            this.BkgGuardarVale.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgGuardarVale_DoWork);
            this.BkgGuardarVale.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgGuardarVale_ProgressChanged);
            this.BkgGuardarVale.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgGuardarVale_RunWorkerCompleted);
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtEstatus.ForeColor = System.Drawing.Color.Lime;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 537);
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(1098, 29);
            this.TxtEstatus.TabIndex = 61;
            this.TxtEstatus.Text = "Estatus...";
            this.TxtEstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 566);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(1098, 23);
            this.Progreso.TabIndex = 62;
            // 
            // FrmGenerarValeSalidaPendienteTratamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 589);
            this.Controls.Add(this.VisorPDF);
            this.Controls.Add(this.TxtEstatus);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGenerarValeSalidaPendienteTratamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vale de salida de piezas a tratamiento";
            this.Load += new System.EventHandler(this.FrmGenerarValeSalidaPendienteTratamiento_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtPersonaEntrega;
        private System.Windows.Forms.ComboBox CmbProveedor;
        private System.Windows.Forms.Label label6;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.ComponentModel.BackgroundWorker BkgGuardarVale;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.Button BtnCancelar;
    }
}
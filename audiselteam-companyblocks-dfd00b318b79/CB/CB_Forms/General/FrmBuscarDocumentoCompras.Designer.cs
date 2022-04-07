namespace CB
{
    partial class FrmBuscarDocumentoCompras
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TxtScaner = new System.Windows.Forms.TextBox();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RBPo = new System.Windows.Forms.RadioButton();
            this.RBRfq = new System.Windows.Forms.RadioButton();
            this.RBRequisicion = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Ingrese ID del documento";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnBuscar.Enabled = false;
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Location = new System.Drawing.Point(192, 119);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(147, 40);
            this.BtnBuscar.TabIndex = 34;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(13, 119);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(147, 40);
            this.BtnCancelar.TabIndex = 33;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TxtScaner
            // 
            this.TxtScaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtScaner.Location = new System.Drawing.Point(13, 48);
            this.TxtScaner.Name = "TxtScaner";
            this.TxtScaner.Size = new System.Drawing.Size(326, 29);
            this.TxtScaner.TabIndex = 32;
            this.TxtScaner.TextChanged += new System.EventHandler(this.TxtScaner_TextChanged);
            this.TxtScaner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtScaner_KeyDown);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(354, 23);
            this.audiselTituloForm1.TabIndex = 29;
            this.audiselTituloForm1.Text = "BUSCAR DOCUMENTO";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RBPo);
            this.panel1.Controls.Add(this.RBRfq);
            this.panel1.Controls.Add(this.RBRequisicion);
            this.panel1.Location = new System.Drawing.Point(12, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 30);
            this.panel1.TabIndex = 36;
            // 
            // RBPo
            // 
            this.RBPo.AutoSize = true;
            this.RBPo.Location = new System.Drawing.Point(164, 6);
            this.RBPo.Name = "RBPo";
            this.RBPo.Size = new System.Drawing.Size(40, 17);
            this.RBPo.TabIndex = 2;
            this.RBPo.TabStop = true;
            this.RBPo.Text = "PO";
            this.RBPo.UseVisualStyleBackColor = true;
            // 
            // RBRfq
            // 
            this.RBRfq.AutoSize = true;
            this.RBRfq.Location = new System.Drawing.Point(101, 6);
            this.RBRfq.Name = "RBRfq";
            this.RBRfq.Size = new System.Drawing.Size(47, 17);
            this.RBRfq.TabIndex = 1;
            this.RBRfq.TabStop = true;
            this.RBRfq.Text = "RFQ";
            this.RBRfq.UseVisualStyleBackColor = true;
            // 
            // RBRequisicion
            // 
            this.RBRequisicion.AutoSize = true;
            this.RBRequisicion.Location = new System.Drawing.Point(8, 6);
            this.RBRequisicion.Name = "RBRequisicion";
            this.RBRequisicion.Size = new System.Drawing.Size(80, 17);
            this.RBRequisicion.TabIndex = 0;
            this.RBRequisicion.TabStop = true;
            this.RBRequisicion.Text = "Requisición";
            this.RBRequisicion.UseVisualStyleBackColor = true;
            // 
            // FrmBuscarRequisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 171);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TxtScaner);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBuscarRequisicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscarRequisicion";
            this.Load += new System.EventHandler(this.FrmBuscarRequisicion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtScaner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RBPo;
        private System.Windows.Forms.RadioButton RBRfq;
        private System.Windows.Forms.RadioButton RBRequisicion;
    }
}
namespace CB
{
    partial class FrmBuscarMaterial
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
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TxtScaner = new System.Windows.Forms.TextBox();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.RdbParteProveedor = new System.Windows.Forms.RadioButton();
            this.RdbParteAudisel = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Location = new System.Drawing.Point(194, 112);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(147, 40);
            this.BtnBuscar.TabIndex = 27;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(15, 112);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(147, 40);
            this.BtnCancelar.TabIndex = 24;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TxtScaner
            // 
            this.TxtScaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtScaner.Location = new System.Drawing.Point(15, 47);
            this.TxtScaner.Name = "TxtScaner";
            this.TxtScaner.Size = new System.Drawing.Size(326, 29);
            this.TxtScaner.TabIndex = 23;
            this.TxtScaner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtScaner_KeyDown);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(355, 23);
            this.audiselTituloForm1.TabIndex = 28;
            this.audiselTituloForm1.Text = "BUSCAR MATERIAL";
            // 
            // RdbParteProveedor
            // 
            this.RdbParteProveedor.AutoSize = true;
            this.RdbParteProveedor.Checked = true;
            this.RdbParteProveedor.Location = new System.Drawing.Point(11, 85);
            this.RdbParteProveedor.Name = "RdbParteProveedor";
            this.RdbParteProveedor.Size = new System.Drawing.Size(154, 17);
            this.RdbParteProveedor.TabIndex = 29;
            this.RdbParteProveedor.TabStop = true;
            this.RdbParteProveedor.Text = "Número de parte fabricante";
            this.RdbParteProveedor.UseVisualStyleBackColor = true;
            // 
            // RdbParteAudisel
            // 
            this.RdbParteAudisel.AutoSize = true;
            this.RdbParteAudisel.Location = new System.Drawing.Point(187, 85);
            this.RdbParteAudisel.Name = "RdbParteAudisel";
            this.RdbParteAudisel.Size = new System.Drawing.Size(139, 17);
            this.RdbParteAudisel.TabIndex = 30;
            this.RdbParteAudisel.TabStop = true;
            this.RdbParteAudisel.Text = "Numero de parte interno";
            this.RdbParteAudisel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Ingrese número de parte";
            // 
            // FrmBuscarMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 164);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RdbParteAudisel);
            this.Controls.Add(this.RdbParteProveedor);
            this.Controls.Add(this.audiselTituloForm1);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TxtScaner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBuscarMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar material";
            this.Load += new System.EventHandler(this.FrmBuscarMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtScaner;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.RadioButton RdbParteProveedor;
        private System.Windows.Forms.RadioButton RdbParteAudisel;
        private System.Windows.Forms.Label label1;
    }
}
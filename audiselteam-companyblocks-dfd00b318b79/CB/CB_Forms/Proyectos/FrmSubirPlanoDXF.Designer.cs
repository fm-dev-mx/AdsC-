namespace CB
{
    partial class FrmSubirPlanoDXF
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
            this.TxtArchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSubir = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.abrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.LblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtArchivo
            // 
            this.TxtArchivo.Location = new System.Drawing.Point(12, 35);
            this.TxtArchivo.Name = "TxtArchivo";
            this.TxtArchivo.ReadOnly = true;
            this.TxtArchivo.Size = new System.Drawing.Size(350, 20);
            this.TxtArchivo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecciona el plano DXF correspondiente al corte con Water Jet:";
            // 
            // BtnSubir
            // 
            this.BtnSubir.Location = new System.Drawing.Point(259, 123);
            this.BtnSubir.Name = "BtnSubir";
            this.BtnSubir.Size = new System.Drawing.Size(103, 23);
            this.BtnSubir.TabIndex = 2;
            this.BtnSubir.Text = "Subir";
            this.BtnSubir.UseVisualStyleBackColor = true;
            this.BtnSubir.Click += new System.EventHandler(this.BtnSubir_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(150, 123);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(103, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(259, 61);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(103, 23);
            this.BtnBuscar.TabIndex = 4;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.ForeColor = System.Drawing.Color.Red;
            this.LblInfo.Location = new System.Drawing.Point(9, 61);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(244, 56);
            this.LblInfo.TabIndex = 25;
            this.LblInfo.Text = "Info";
            this.LblInfo.Visible = false;
            // 
            // FrmSubirPlanoDXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 154);
            this.ControlBox = false;
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnSubir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtArchivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSubirPlanoDXF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subir plano DXF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSubir;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.OpenFileDialog abrirArchivo;
        private System.Windows.Forms.Label LblInfo;
    }
}
namespace CB
{
    partial class FrmCancelarPo
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
            this.TxtRazon = new System.Windows.Forms.TextBox();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.LblPo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.CmbProveedorContacto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtRazon
            // 
            this.TxtRazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtRazon.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRazon.Location = new System.Drawing.Point(0, 79);
            this.TxtRazon.Multiline = true;
            this.TxtRazon.Name = "TxtRazon";
            this.TxtRazon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtRazon.Size = new System.Drawing.Size(565, 151);
            this.TxtRazon.TabIndex = 1;
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConfirmar.Location = new System.Drawing.Point(436, 230);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(129, 60);
            this.BtnConfirmar.TabIndex = 2;
            this.BtnConfirmar.Text = "   Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // LblPo
            // 
            this.LblPo.AutoSize = true;
            this.LblPo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPo.Location = new System.Drawing.Point(0, 23);
            this.LblPo.Name = "LblPo";
            this.LblPo.Size = new System.Drawing.Size(73, 24);
            this.LblPo.TabIndex = 3;
            this.LblPo.Text = "PO: ##";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(565, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Razón por la cual se cancela la PO:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(307, 230);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(129, 60);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "    Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(565, 23);
            this.audiselTituloForm1.TabIndex = 6;
            this.audiselTituloForm1.Text = "CANCELAR PO";
            // 
            // CmbProveedorContacto
            // 
            this.CmbProveedorContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProveedorContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProveedorContacto.FormattingEnabled = true;
            this.CmbProveedorContacto.Location = new System.Drawing.Point(356, 41);
            this.CmbProveedorContacto.Name = "CmbProveedorContacto";
            this.CmbProveedorContacto.Size = new System.Drawing.Size(197, 28);
            this.CmbProveedorContacto.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Contacto";
            // 
            // FrmCancelarPo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbProveedorContacto);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.TxtRazon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblPo);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCancelarPo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCancelarPo";
            this.Load += new System.EventHandler(this.FrmCancelarPo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtRazon;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Label LblPo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancelar;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.ComboBox CmbProveedorContacto;
        private System.Windows.Forms.Label label1;
    }
}
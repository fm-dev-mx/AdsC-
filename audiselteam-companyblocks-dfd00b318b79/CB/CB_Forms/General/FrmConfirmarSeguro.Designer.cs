namespace CB
{
    partial class FrmConfirmarSeguro
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
            this.TxtConfirmar = new System.Windows.Forms.TextBox();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtConfirmar
            // 
            this.TxtConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TxtConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConfirmar.Location = new System.Drawing.Point(9, 53);
            this.TxtConfirmar.Name = "TxtConfirmar";
            this.TxtConfirmar.Size = new System.Drawing.Size(286, 26);
            this.TxtConfirmar.TabIndex = 0;
            this.TxtConfirmar.TextChanged += new System.EventHandler(this.TxtConfirmar_TextChanged);
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnConfirmar.Enabled = false;
            this.BtnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmar.Location = new System.Drawing.Point(155, 88);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(140, 40);
            this.BtnConfirmar.TabIndex = 29;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(9, 87);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(140, 40);
            this.BtnCancelar.TabIndex = 28;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 42);
            this.label1.TabIndex = 30;
            this.label1.Text = "Escriba la palabra \"CANCELAR\" para confirmar la cancelación.";
            // 
            // FrmConfirmarSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 140);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TxtConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmConfirmarSeguro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmar cancelación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtConfirmar;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label1;
    }
}
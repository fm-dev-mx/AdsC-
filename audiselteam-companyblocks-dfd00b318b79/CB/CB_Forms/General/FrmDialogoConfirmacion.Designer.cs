namespace CB
{
    partial class FrmDialogoConfirmacion
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
            this.LblConfirmacion = new System.Windows.Forms.Label();
            this.TxtConfirmacion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtConfirmar = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblConfirmacion
            // 
            this.LblConfirmacion.AutoSize = true;
            this.LblConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblConfirmacion.Location = new System.Drawing.Point(0, 23);
            this.LblConfirmacion.Name = "LblConfirmacion";
            this.LblConfirmacion.Size = new System.Drawing.Size(164, 16);
            this.LblConfirmacion.TabIndex = 1;
            this.LblConfirmacion.Text = "Favor de teclear confirmar";
            // 
            // TxtConfirmacion
            // 
            this.TxtConfirmacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConfirmacion.Location = new System.Drawing.Point(0, 39);
            this.TxtConfirmacion.Name = "TxtConfirmacion";
            this.TxtConfirmacion.Size = new System.Drawing.Size(284, 26);
            this.TxtConfirmacion.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Image = global::CB_Base.Properties.Resources.close;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConfirmar.Location = new System.Drawing.Point(141, 65);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(143, 40);
            this.BtnConfirmar.TabIndex = 3;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(284, 23);
            this.audiselTituloForm1.TabIndex = 5;
            this.audiselTituloForm1.Text = "CONFIRMAR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Favor de teclear confirmar";
            // 
            // TxtConfirmar
            // 
            this.TxtConfirmar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConfirmar.Location = new System.Drawing.Point(0, 39);
            this.TxtConfirmar.Name = "TxtConfirmar";
            this.TxtConfirmar.Size = new System.Drawing.Size(284, 26);
            this.TxtConfirmar.TabIndex = 2;
            this.TxtConfirmar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtConfirmar_KeyPress);
            // 
            // button2
            // 
            this.button2.Image = global::CB_Base.Properties.Resources.close;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 40);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmDialogoConfirmacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 105);
            this.Controls.Add(this.audiselTituloForm1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.TxtConfirmar);
            this.Controls.Add(this.TxtConfirmacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblConfirmacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDialogoConfirmacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDialogoConfirmacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblConfirmacion;
        private System.Windows.Forms.TextBox TxtConfirmacion;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Button button1;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtConfirmar;
        private System.Windows.Forms.Button button2;
    }
}
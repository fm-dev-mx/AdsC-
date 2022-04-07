namespace CB
{
    partial class FrmNuevaCategoria
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
            this.TxtCategoria = new System.Windows.Forms.TextBox();
            this.LblNombre = new System.Windows.Forms.Label();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.SuspendLayout();
            // 
            // TxtCategoria
            // 
            this.TxtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCategoria.Location = new System.Drawing.Point(12, 48);
            this.TxtCategoria.Name = "TxtCategoria";
            this.TxtCategoria.Size = new System.Drawing.Size(288, 26);
            this.TxtCategoria.TabIndex = 6;
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(9, 32);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(120, 13);
            this.LblNombre.TabIndex = 7;
            this.LblNombre.Text = "Nombre de la categoria:";
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConfirmar.Location = new System.Drawing.Point(183, 87);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(117, 40);
            this.BtnConfirmar.TabIndex = 8;
            this.BtnConfirmar.Text = "      Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(12, 87);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(117, 40);
            this.BtnCancelar.TabIndex = 9;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(313, 23);
            this.audiselTituloForm1.TabIndex = 10;
            this.audiselTituloForm1.Text = "NUEVA CATEGORIA";
            // 
            // FrmNuevaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 139);
            this.Controls.Add(this.audiselTituloForm1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.TxtCategoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva categoria";
            this.Load += new System.EventHandler(this.FrmNuevaCategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCategoria;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Button BtnCancelar;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
    }
}
namespace CB
{
    partial class FrmEditarContactoProveedor
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtApellidoCantacto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNombreContacto = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNumeroCelular = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNumeroTelefono = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNumeroTelefono2 = new System.Windows.Forms.TextBox();
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(12, 311);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(165, 40);
            this.BtnCancelar.TabIndex = 57;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Location = new System.Drawing.Point(183, 311);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(172, 40);
            this.BtnRegistrar.TabIndex = 56;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Apellido *";
            // 
            // TxtApellidoCantacto
            // 
            this.TxtApellidoCantacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtApellidoCantacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtApellidoCantacto.Location = new System.Drawing.Point(12, 104);
            this.TxtApellidoCantacto.Name = "TxtApellidoCantacto";
            this.TxtApellidoCantacto.Size = new System.Drawing.Size(342, 29);
            this.TxtApellidoCantacto.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nombre *";
            // 
            // TxtNombreContacto
            // 
            this.TxtNombreContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombreContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreContacto.Location = new System.Drawing.Point(12, 49);
            this.TxtNombreContacto.Name = "TxtNombreContacto";
            this.TxtNombreContacto.Size = new System.Drawing.Size(342, 29);
            this.TxtNombreContacto.TabIndex = 46;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(367, 23);
            this.LblTitulo.TabIndex = 45;
            this.LblTitulo.Text = "REGISTRAR CONTACTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Número celular *";
            // 
            // TxtNumeroCelular
            // 
            this.TxtNumeroCelular.CausesValidation = false;
            this.TxtNumeroCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroCelular.Location = new System.Drawing.Point(12, 160);
            this.TxtNumeroCelular.Name = "TxtNumeroCelular";
            this.TxtNumeroCelular.Size = new System.Drawing.Size(162, 29);
            this.TxtNumeroCelular.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Número de telefono 1 *";
            // 
            // TxtNumeroTelefono
            // 
            this.TxtNumeroTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroTelefono.Location = new System.Drawing.Point(182, 160);
            this.TxtNumeroTelefono.Name = "TxtNumeroTelefono";
            this.TxtNumeroTelefono.Size = new System.Drawing.Size(172, 29);
            this.TxtNumeroTelefono.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Número de telefono 2";
            // 
            // TxtNumeroTelefono2
            // 
            this.TxtNumeroTelefono2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroTelefono2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroTelefono2.Location = new System.Drawing.Point(12, 214);
            this.TxtNumeroTelefono2.Name = "TxtNumeroTelefono2";
            this.TxtNumeroTelefono2.Size = new System.Drawing.Size(164, 29);
            this.TxtNumeroTelefono2.TabIndex = 62;
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreo.Location = new System.Drawing.Point(12, 269);
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Size = new System.Drawing.Size(343, 29);
            this.TxtCorreo.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Correo Electronico *";
            // 
            // FrmEditarContactoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(367, 365);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtCorreo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtNumeroTelefono2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtNumeroTelefono);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNumeroCelular);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtApellidoCantacto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNombreContacto);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEditarContactoProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditarContactoProveedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtApellidoCantacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombreContacto;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNumeroCelular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtNumeroTelefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtNumeroTelefono2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtCorreo;
    }
}
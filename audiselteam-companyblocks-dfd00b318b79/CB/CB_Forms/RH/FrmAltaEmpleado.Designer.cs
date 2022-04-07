namespace CB
{
    partial class FrmAltaEmpleado
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblContrasena = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtConfirmacionContrasena = new System.Windows.Forms.MaskedTextBox();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.TxtContrasena = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtPaterno = new System.Windows.Forms.TextBox();
            this.NumNivel = new System.Windows.Forms.NumericUpDown();
            this.TxtMaterno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblNivel = new System.Windows.Forms.Label();
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbPuesto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtApodo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.TxtApodo);
            this.panel1.Controls.Add(this.LblContrasena);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TxtConfirmacionContrasena);
            this.panel1.Controls.Add(this.TxtTelefono);
            this.panel1.Controls.Add(this.TxtContrasena);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.TxtPaterno);
            this.panel1.Controls.Add(this.NumNivel);
            this.panel1.Controls.Add(this.TxtMaterno);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.LblNivel);
            this.panel1.Controls.Add(this.TxtCorreo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbPuesto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 407);
            this.panel1.TabIndex = 114;
            // 
            // LblContrasena
            // 
            this.LblContrasena.AutoSize = true;
            this.LblContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblContrasena.ForeColor = System.Drawing.Color.Red;
            this.LblContrasena.Location = new System.Drawing.Point(468, 324);
            this.LblContrasena.Name = "LblContrasena";
            this.LblContrasena.Size = new System.Drawing.Size(176, 15);
            this.LblContrasena.TabIndex = 119;
            this.LblContrasena.Text = "La contraseña no coincide";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 118;
            this.label8.Text = "Confirme la contraseña *";
            // 
            // TxtConfirmacionContrasena
            // 
            this.TxtConfirmacionContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtConfirmacionContrasena.Location = new System.Drawing.Point(14, 317);
            this.TxtConfirmacionContrasena.Name = "TxtConfirmacionContrasena";
            this.TxtConfirmacionContrasena.PasswordChar = '*';
            this.TxtConfirmacionContrasena.Size = new System.Drawing.Size(448, 29);
            this.TxtConfirmacionContrasena.TabIndex = 9;
            this.TxtConfirmacionContrasena.TextChanged += new System.EventHandler(this.TxtConfirmacionContrasena_TextChanged);
            this.TxtConfirmacionContrasena.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtConfirmacionContrasena_KeyUp);
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtTelefono.Location = new System.Drawing.Point(468, 85);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(220, 29);
            this.TxtTelefono.TabIndex = 5;
            this.TxtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTelefono_KeyPress);
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtContrasena.Location = new System.Drawing.Point(14, 258);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.PasswordChar = '*';
            this.TxtContrasena.Size = new System.Drawing.Size(448, 29);
            this.TxtContrasena.TabIndex = 8;
            this.TxtContrasena.TextChanged += new System.EventHandler(this.TxtContrasena_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Contraseña del sistema *";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnCancelar);
            this.panel2.Controls.Add(this.BtnGuardar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(694, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 407);
            this.panel2.TabIndex = 114;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(0, 64);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(141, 61);
            this.BtnCancelar.TabIndex = 11;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(0, 1);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(141, 58);
            this.BtnGuardar.TabIndex = 10;
            this.BtnGuardar.Text = "       Dar de alta";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(14, 29);
            this.TxtNombre.MaxLength = 30;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(220, 29);
            this.TxtNombre.TabIndex = 1;
            // 
            // TxtPaterno
            // 
            this.TxtPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaterno.Location = new System.Drawing.Point(242, 29);
            this.TxtPaterno.MaxLength = 30;
            this.TxtPaterno.Name = "TxtPaterno";
            this.TxtPaterno.Size = new System.Drawing.Size(220, 29);
            this.TxtPaterno.TabIndex = 2;
            // 
            // NumNivel
            // 
            this.NumNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumNivel.Location = new System.Drawing.Point(468, 201);
            this.NumNivel.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumNivel.Name = "NumNivel";
            this.NumNivel.Size = new System.Drawing.Size(58, 31);
            this.NumNivel.TabIndex = 7;
            this.NumNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TxtMaterno
            // 
            this.TxtMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaterno.Location = new System.Drawing.Point(468, 29);
            this.TxtMaterno.MaxLength = 30;
            this.TxtMaterno.Name = "TxtMaterno";
            this.TxtMaterno.Size = new System.Drawing.Size(220, 29);
            this.TxtMaterno.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Correo *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Puesto *";
            // 
            // LblNivel
            // 
            this.LblNivel.AutoSize = true;
            this.LblNivel.Location = new System.Drawing.Point(465, 185);
            this.LblNivel.Name = "LblNivel";
            this.LblNivel.Size = new System.Drawing.Size(34, 13);
            this.LblNivel.TabIndex = 110;
            this.LblNivel.Text = "Nivel:";
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.TxtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreo.Location = new System.Drawing.Point(14, 85);
            this.TxtCorreo.MaxLength = 60;
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Size = new System.Drawing.Size(448, 29);
            this.TxtCorreo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nombre *";
            // 
            // CmbPuesto
            // 
            this.CmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPuesto.FormattingEnabled = true;
            this.CmbPuesto.Location = new System.Drawing.Point(14, 200);
            this.CmbPuesto.Name = "CmbPuesto";
            this.CmbPuesto.Size = new System.Drawing.Size(448, 32);
            this.CmbPuesto.TabIndex = 6;
            this.CmbPuesto.SelectedIndexChanged += new System.EventHandler(this.CmbPuesto_SelectedIndexChanged);
            this.CmbPuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbPuesto_KeyPress);
            this.CmbPuesto.Leave += new System.EventHandler(this.CmbPuesto_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Apellido paterno *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Apellido materno";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(465, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Teléfono";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(839, 23);
            this.LblTitulo.TabIndex = 115;
            this.LblTitulo.Text = "CAPTURAR INFORMACION DEL EMPLEADO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 121;
            this.label9.Text = "Apodo ";
            // 
            // TxtApodo
            // 
            this.TxtApodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.TxtApodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtApodo.Location = new System.Drawing.Point(14, 142);
            this.TxtApodo.MaxLength = 60;
            this.TxtApodo.Name = "TxtApodo";
            this.TxtApodo.Size = new System.Drawing.Size(448, 29);
            this.TxtApodo.TabIndex = 120;
            // 
            // FrmAltaEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 430);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAltaEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Altas de empleados";
            this.Load += new System.EventHandler(this.FrmAltaEmpleado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumNivel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtPaterno;
        private System.Windows.Forms.NumericUpDown NumNivel;
        private System.Windows.Forms.TextBox TxtMaterno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblNivel;
        private System.Windows.Forms.TextBox TxtCorreo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbPuesto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox TxtContrasena;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox TxtConfirmacionContrasena;
        private System.Windows.Forms.Label LblContrasena;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtApodo;
    }
}
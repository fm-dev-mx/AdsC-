namespace CB
{
    partial class FrmNuevaCotizacion
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbContacto = new System.Windows.Forms.ComboBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.TxtTitulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbTipoProyecto = new System.Windows.Forms.ComboBox();
            this.DateFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(437, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "NUEVA COTIZACION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Cliente:";
            // 
            // CmbCliente
            // 
            this.CmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCliente.FormattingEnabled = true;
            this.CmbCliente.Location = new System.Drawing.Point(12, 53);
            this.CmbCliente.Name = "CmbCliente";
            this.CmbCliente.Size = new System.Drawing.Size(413, 32);
            this.CmbCliente.TabIndex = 25;
            this.CmbCliente.SelectedIndexChanged += new System.EventHandler(this.CmbCliente_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Contacto:";
            // 
            // CmbContacto
            // 
            this.CmbContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContacto.FormattingEnabled = true;
            this.CmbContacto.Location = new System.Drawing.Point(12, 107);
            this.CmbContacto.Name = "CmbContacto";
            this.CmbContacto.Size = new System.Drawing.Size(413, 32);
            this.CmbContacto.TabIndex = 27;
            this.CmbContacto.SelectedIndexChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(12, 345);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 53);
            this.BtnCancelar.TabIndex = 30;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnCrear
            // 
            this.BtnCrear.Enabled = false;
            this.BtnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCrear.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCrear.Location = new System.Drawing.Point(265, 345);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(160, 53);
            this.BtnCrear.TabIndex = 29;
            this.BtnCrear.Text = "     Crear";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // TxtTitulo
            // 
            this.TxtTitulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTitulo.Location = new System.Drawing.Point(12, 164);
            this.TxtTitulo.MaxLength = 100;
            this.TxtTitulo.Multiline = true;
            this.TxtTitulo.Name = "TxtTitulo";
            this.TxtTitulo.Size = new System.Drawing.Size(413, 40);
            this.TxtTitulo.TabIndex = 31;
            this.TxtTitulo.TextChanged += new System.EventHandler(this.TxtTitulo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Título:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Tipo de proyecto:";
            // 
            // CmbTipoProyecto
            // 
            this.CmbTipoProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoProyecto.FormattingEnabled = true;
            this.CmbTipoProyecto.Location = new System.Drawing.Point(12, 232);
            this.CmbTipoProyecto.Name = "CmbTipoProyecto";
            this.CmbTipoProyecto.Size = new System.Drawing.Size(413, 32);
            this.CmbTipoProyecto.TabIndex = 33;
            this.CmbTipoProyecto.SelectedIndexChanged += new System.EventHandler(this.CmbTipoProyecto_SelectedIndexChanged);
            // 
            // DateFechaLimite
            // 
            this.DateFechaLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFechaLimite.Location = new System.Drawing.Point(12, 295);
            this.DateFechaLimite.Name = "DateFechaLimite";
            this.DateFechaLimite.Size = new System.Drawing.Size(256, 26);
            this.DateFechaLimite.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Fecha limite para enviar:";
            // 
            // FrmNuevaCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 409);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DateFechaLimite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbTipoProyecto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtTitulo);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnCrear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbContacto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbCliente);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaCotizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevaCotizacion";
            this.Load += new System.EventHandler(this.FrmNuevaCotizacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbContacto;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.TextBox TxtTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbTipoProyecto;
        private System.Windows.Forms.DateTimePicker DateFechaLimite;
        private System.Windows.Forms.Label label5;
    }
}
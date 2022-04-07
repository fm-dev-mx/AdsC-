namespace CB
{
    partial class FrmInformacionGeneralCotizacion
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
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.ContactoCompras = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbProducto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbIndustria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTitulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbContacto = new System.Windows.Forms.ComboBox();
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.CkbEditar = new System.Windows.Forms.CheckBox();
            this.CkbDesglosarCosto = new System.Windows.Forms.CheckBox();
            this.CkbMostrarPartida = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(832, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "INFORMACIÓN GENERAL DE LA COTIZACION";
            // 
            // ContactoCompras
            // 
            this.ContactoCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ContactoCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactoCompras.FormattingEnabled = true;
            this.ContactoCompras.Location = new System.Drawing.Point(303, 203);
            this.ContactoCompras.Name = "ContactoCompras";
            this.ContactoCompras.Size = new System.Drawing.Size(282, 32);
            this.ContactoCompras.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Título:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(306, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Fecha límite para enviar:";
            // 
            // DtpFechaLimite
            // 
            this.DtpFechaLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaLimite.Location = new System.Drawing.Point(303, 263);
            this.DtpFechaLimite.Name = "DtpFechaLimite";
            this.DtpFechaLimite.Size = new System.Drawing.Size(282, 26);
            this.DtpFechaLimite.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Producto (opcional):";
            // 
            // CmbProducto
            // 
            this.CmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProducto.FormattingEnabled = true;
            this.CmbProducto.Location = new System.Drawing.Point(15, 259);
            this.CmbProducto.Name = "CmbProducto";
            this.CmbProducto.Size = new System.Drawing.Size(282, 32);
            this.CmbProducto.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Contacto de compras (Opcional):";
            // 
            // CmbIndustria
            // 
            this.CmbIndustria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIndustria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbIndustria.FormattingEnabled = true;
            this.CmbIndustria.Location = new System.Drawing.Point(373, 148);
            this.CmbIndustria.Name = "CmbIndustria";
            this.CmbIndustria.Size = new System.Drawing.Size(212, 32);
            this.CmbIndustria.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Industria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Cliente:";
            // 
            // TxtTitulo
            // 
            this.TxtTitulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTitulo.Location = new System.Drawing.Point(15, 92);
            this.TxtTitulo.MaxLength = 100;
            this.TxtTitulo.Multiline = true;
            this.TxtTitulo.Name = "TxtTitulo";
            this.TxtTitulo.Size = new System.Drawing.Size(570, 32);
            this.TxtTitulo.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Contacto técnico:";
            // 
            // CmbContacto
            // 
            this.CmbContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContacto.FormattingEnabled = true;
            this.CmbContacto.Location = new System.Drawing.Point(15, 203);
            this.CmbContacto.Name = "CmbContacto";
            this.CmbContacto.Size = new System.Drawing.Size(282, 32);
            this.CmbContacto.TabIndex = 52;
            // 
            // TxtCliente
            // 
            this.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCliente.Location = new System.Drawing.Point(15, 148);
            this.TxtCliente.MaxLength = 100;
            this.TxtCliente.Multiline = true;
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.ReadOnly = true;
            this.TxtCliente.Size = new System.Drawing.Size(352, 32);
            this.TxtCliente.TabIndex = 64;
            // 
            // CkbEditar
            // 
            this.CkbEditar.AutoSize = true;
            this.CkbEditar.Location = new System.Drawing.Point(15, 17);
            this.CkbEditar.Name = "CkbEditar";
            this.CkbEditar.Size = new System.Drawing.Size(110, 17);
            this.CkbEditar.TabIndex = 65;
            this.CkbEditar.Text = "Editar información";
            this.CkbEditar.UseVisualStyleBackColor = true;
            this.CkbEditar.CheckedChanged += new System.EventHandler(this.CkbEditar_CheckedChanged);
            // 
            // CkbDesglosarCosto
            // 
            this.CkbDesglosarCosto.AutoSize = true;
            this.CkbDesglosarCosto.Location = new System.Drawing.Point(605, 99);
            this.CkbDesglosarCosto.Name = "CkbDesglosarCosto";
            this.CkbDesglosarCosto.Size = new System.Drawing.Size(107, 17);
            this.CkbDesglosarCosto.TabIndex = 67;
            this.CkbDesglosarCosto.Text = "Desglosar costos";
            this.CkbDesglosarCosto.UseVisualStyleBackColor = true;
            // 
            // CkbMostrarPartida
            // 
            this.CkbMostrarPartida.AutoSize = true;
            this.CkbMostrarPartida.Location = new System.Drawing.Point(605, 76);
            this.CkbMostrarPartida.Name = "CkbMostrarPartida";
            this.CkbMostrarPartida.Size = new System.Drawing.Size(203, 17);
            this.CkbMostrarPartida.TabIndex = 66;
            this.CkbMostrarPartida.Text = "Mostrar partida en resumen de costos";
            this.CkbMostrarPartida.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.BtnCrear);
            this.panel2.Controls.Add(this.CkbEditar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 46);
            this.panel2.TabIndex = 68;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CB_Base.Properties.Resources.close;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(584, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 46);
            this.button2.TabIndex = 67;
            this.button2.Text = "     Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // BtnCrear
            // 
            this.BtnCrear.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrear.Image = global::CB_Base.Properties.Resources.ok_48;
            this.BtnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCrear.Location = new System.Drawing.Point(708, 0);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(124, 46);
            this.BtnCrear.TabIndex = 66;
            this.BtnCrear.Text = "        Guardar";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click_1);
            // 
            // FrmInformacionGeneralCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 445);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CkbDesglosarCosto);
            this.Controls.Add(this.CkbMostrarPartida);
            this.Controls.Add(this.TxtCliente);
            this.Controls.Add(this.ContactoCompras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DtpFechaLimite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbIndustria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbContacto);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInformacionGeneralCotizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información general de la cotización";
            this.Load += new System.EventHandler(this.FrmEditarCotizacion2_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.ComboBox ContactoCompras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DtpFechaLimite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbIndustria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbContacto;
        private System.Windows.Forms.TextBox TxtCliente;
        private System.Windows.Forms.CheckBox CkbEditar;
        private System.Windows.Forms.CheckBox CkbDesglosarCosto;
        private System.Windows.Forms.CheckBox CkbMostrarPartida;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnCrear;
    }
}
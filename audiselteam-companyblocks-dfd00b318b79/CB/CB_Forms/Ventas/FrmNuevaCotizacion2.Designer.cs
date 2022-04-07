namespace CB
{
    partial class FrmNuevaCotizacion2
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
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTitulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbContacto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbClientes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbIndustria = new System.Windows.Forms.ComboBox();
            this.ContactoCompras = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbProducto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Título:";
            // 
            // TxtTitulo
            // 
            this.TxtTitulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTitulo.Location = new System.Drawing.Point(6, 45);
            this.TxtTitulo.MaxLength = 100;
            this.TxtTitulo.Multiline = true;
            this.TxtTitulo.Name = "TxtTitulo";
            this.TxtTitulo.Size = new System.Drawing.Size(570, 32);
            this.TxtTitulo.TabIndex = 1;
            this.TxtTitulo.TextChanged += new System.EventHandler(this.TxtTitulo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Contacto técnico:";
            // 
            // CmbContacto
            // 
            this.CmbContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContacto.FormattingEnabled = true;
            this.CmbContacto.Location = new System.Drawing.Point(6, 156);
            this.CmbContacto.Name = "CmbContacto";
            this.CmbContacto.Size = new System.Drawing.Size(282, 32);
            this.CmbContacto.TabIndex = 4;
            this.CmbContacto.SelectedIndexChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Cliente:";
            // 
            // CmbClientes
            // 
            this.CmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbClientes.FormattingEnabled = true;
            this.CmbClientes.Location = new System.Drawing.Point(6, 101);
            this.CmbClientes.Name = "CmbClientes";
            this.CmbClientes.Size = new System.Drawing.Size(352, 32);
            this.CmbClientes.TabIndex = 2;
            this.CmbClientes.SelectedIndexChanged += new System.EventHandler(this.CmbClientes_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Industria:";
            // 
            // CmbIndustria
            // 
            this.CmbIndustria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIndustria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbIndustria.FormattingEnabled = true;
            this.CmbIndustria.Location = new System.Drawing.Point(364, 101);
            this.CmbIndustria.Name = "CmbIndustria";
            this.CmbIndustria.Size = new System.Drawing.Size(212, 32);
            this.CmbIndustria.TabIndex = 3;
            this.CmbIndustria.SelectedIndexChanged += new System.EventHandler(this.CmbIndustria_SelectedIndexChanged);
            // 
            // ContactoCompras
            // 
            this.ContactoCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ContactoCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactoCompras.FormattingEnabled = true;
            this.ContactoCompras.Location = new System.Drawing.Point(294, 156);
            this.ContactoCompras.Name = "ContactoCompras";
            this.ContactoCompras.Size = new System.Drawing.Size(282, 32);
            this.ContactoCompras.TabIndex = 5;
            this.ContactoCompras.SelectedIndexChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Contacto de compras (Opcional):";
            // 
            // CmbProducto
            // 
            this.CmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProducto.FormattingEnabled = true;
            this.CmbProducto.Location = new System.Drawing.Point(6, 212);
            this.CmbProducto.Name = "CmbProducto";
            this.CmbProducto.Size = new System.Drawing.Size(282, 32);
            this.CmbProducto.TabIndex = 6;
            this.CmbProducto.SelectedIndexChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Producto (opcional):";
            // 
            // DtpFechaLimite
            // 
            this.DtpFechaLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaLimite.Location = new System.Drawing.Point(294, 216);
            this.DtpFechaLimite.Name = "DtpFechaLimite";
            this.DtpFechaLimite.Size = new System.Drawing.Size(282, 26);
            this.DtpFechaLimite.TabIndex = 7;
            this.DtpFechaLimite.ValueChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Fecha límite para enviar:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.BtnCrear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 63);
            this.panel1.TabIndex = 47;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CB_Base.Properties.Resources.close;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 63);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnCrear
            // 
            this.BtnCrear.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrear.Image = global::CB_Base.Properties.Resources.ok_48;
            this.BtnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCrear.Location = new System.Drawing.Point(431, 0);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(151, 63);
            this.BtnCrear.TabIndex = 0;
            this.BtnCrear.Text = "Crear";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(582, 23);
            this.audiselTituloForm1.TabIndex = 1;
            this.audiselTituloForm1.Text = "NUEVA COTIZACION";
            // 
            // FrmNuevaCotizacion2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 313);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DtpFechaLimite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ContactoCompras);
            this.Controls.Add(this.CmbIndustria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbClientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbContacto);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaCotizacion2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva cotización";
            this.Load += new System.EventHandler(this.FrmNuevaCotizacion2_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbContacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbClientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbIndustria;
        private System.Windows.Forms.ComboBox ContactoCompras;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbProducto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtpFechaLimite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnCrear;
    }
}
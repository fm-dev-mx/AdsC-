namespace CB
{
    partial class FrmSelectorFechaCompra
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
            this.TxtFechaPromesa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFechaSolicitud = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.TxtProceso = new System.Windows.Forms.TextBox();
            this.LblMensaje = new System.Windows.Forms.Label();
            this.DtpFechaMeta = new System.Windows.Forms.DateTimePicker();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Seleccionar fecha promesa:";
            // 
            // TxtFechaPromesa
            // 
            this.TxtFechaPromesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaPromesa.Location = new System.Drawing.Point(308, 125);
            this.TxtFechaPromesa.Name = "TxtFechaPromesa";
            this.TxtFechaPromesa.ReadOnly = true;
            this.TxtFechaPromesa.Size = new System.Drawing.Size(189, 29);
            this.TxtFechaPromesa.TabIndex = 38;
            this.TxtFechaPromesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Fecha de solicitud:";
            // 
            // TxtFechaSolicitud
            // 
            this.TxtFechaSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaSolicitud.Location = new System.Drawing.Point(308, 71);
            this.TxtFechaSolicitud.Name = "TxtFechaSolicitud";
            this.TxtFechaSolicitud.ReadOnly = true;
            this.TxtFechaSolicitud.Size = new System.Drawing.Size(189, 29);
            this.TxtFechaSolicitud.TabIndex = 36;
            this.TxtFechaSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Fecha promesa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Proceso:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(19, 170);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(172, 55);
            this.BtnCancelar.TabIndex = 6;
            this.BtnCancelar.Text = "          No requiere fecha";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(191, 170);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(172, 55);
            this.BtnAceptar.TabIndex = 5;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.audiselTituloForm1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtFechaPromesa);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtFechaSolicitud);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtProceso);
            this.panel1.Controls.Add(this.LblMensaje);
            this.panel1.Controls.Add(this.DtpFechaMeta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 170);
            this.panel1.TabIndex = 7;
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(505, 23);
            this.audiselTituloForm1.TabIndex = 47;
            this.audiselTituloForm1.Text = "NUEVA META";
            // 
            // TxtProceso
            // 
            this.TxtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProceso.Location = new System.Drawing.Point(6, 71);
            this.TxtProceso.Name = "TxtProceso";
            this.TxtProceso.ReadOnly = true;
            this.TxtProceso.Size = new System.Drawing.Size(296, 29);
            this.TxtProceso.TabIndex = 33;
            // 
            // LblMensaje
            // 
            this.LblMensaje.AutoSize = true;
            this.LblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMensaje.Location = new System.Drawing.Point(3, 27);
            this.LblMensaje.Name = "LblMensaje";
            this.LblMensaje.Size = new System.Drawing.Size(354, 13);
            this.LblMensaje.TabIndex = 0;
            this.LblMensaje.Text = "Es necesario seleccionar una fecha ideal de recepcion para la requisición";
            // 
            // DtpFechaMeta
            // 
            this.DtpFechaMeta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.DtpFechaMeta.Location = new System.Drawing.Point(4, 125);
            this.DtpFechaMeta.Name = "DtpFechaMeta";
            this.DtpFechaMeta.Size = new System.Drawing.Size(298, 27);
            this.DtpFechaMeta.TabIndex = 1;
            this.DtpFechaMeta.ValueChanged += new System.EventHandler(this.DtpFechaMeta_ValueChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(363, 170);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(142, 55);
            this.BtnSalir.TabIndex = 76;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmSelectorFechaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 225);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSelectorFechaCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSelectorFechaCompra";
            this.Load += new System.EventHandler(this.FrmSelectorFechaCompra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFechaPromesa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFechaSolicitud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblMensaje;
        private System.Windows.Forms.DateTimePicker DtpFechaMeta;
        private System.Windows.Forms.TextBox TxtProceso;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Button BtnSalir;
    }
}
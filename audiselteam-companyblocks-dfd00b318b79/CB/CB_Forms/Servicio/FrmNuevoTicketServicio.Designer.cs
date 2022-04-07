namespace CB
{
    partial class FrmNuevoTicketServicio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevoTicketServicio));
            this.BkgEnviarCorreo = new System.ComponentModel.BackgroundWorker();
            this.TtProblema = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ListaSintomas = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.TxtDetalles = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RdSeguimientoGarantia = new System.Windows.Forms.RadioButton();
            this.RdIncidenteCalidad = new System.Windows.Forms.RadioButton();
            this.RdReclamoOficial = new System.Windows.Forms.RadioButton();
            this.CmbContacto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbProyecto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BkgBuscador = new System.ComponentModel.BackgroundWorker();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BkgEnviarCorreo
            // 
            this.BkgEnviarCorreo.WorkerReportsProgress = true;
            this.BkgEnviarCorreo.WorkerSupportsCancellation = true;
            this.BkgEnviarCorreo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEnviarCorreo_DoWork);
            this.BkgEnviarCorreo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEnviarCorreo_RunWorkerCompleted);
            // 
            // TtProblema
            // 
            this.TtProblema.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TtProblema.ToolTipTitle = "Describe brevemente el problema";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(717, 21);
            this.label6.TabIndex = 58;
            this.label6.Text = "Deberá generarse un ticket de servicio independiente por cada problema a resolver" +
    "";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ListaSintomas);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BtnCancelar);
            this.groupBox2.Controls.Add(this.LblEstatus);
            this.groupBox2.Controls.Add(this.BtnRegistrar);
            this.groupBox2.Controls.Add(this.TxtDetalles);
            this.groupBox2.Location = new System.Drawing.Point(12, 294);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 324);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Describe qué ocurre o cuál es el síntoma principal del problema";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(14, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(687, 20);
            this.label7.TabIndex = 59;
            this.label7.Text = "Síntomas similares que ya se han presentado anteriormente:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListaSintomas
            // 
            this.ListaSintomas.Location = new System.Drawing.Point(17, 176);
            this.ListaSintomas.MultiSelect = false;
            this.ListaSintomas.Name = "ListaSintomas";
            this.ListaSintomas.Size = new System.Drawing.Size(515, 133);
            this.ListaSintomas.TabIndex = 58;
            this.ListaSintomas.UseCompatibleStateImageBehavior = false;
            this.ListaSintomas.View = System.Windows.Forms.View.List;
            this.ListaSintomas.SelectedIndexChanged += new System.EventHandler(this.ListaSintomas_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(384, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 52);
            this.label5.TabIndex = 57;
            this.label5.Text = "CARGA DE PRODUCTO POCO ERGONOMICA\r\nFALSOS RECHAZOS\r\nPERNOS GUIA SE SALEN DE SU RI" +
    "MA\r\nFLANGE MAL ORIENTADO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 52);
            this.label1.TabIndex = 56;
            this.label1.Text = "ATEQ NO RESPONDE A SEÑALES DE I/O Y SERIAL\r\nPROGRAMA DE LABVIEW SE CONGELA\r\nBALIN" +
    " NO DETECTADO\r\nFLANGE FLEXIONADO";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(687, 33);
            this.label4.TabIndex = 54;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblEstatus
            // 
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.ForeColor = System.Drawing.Color.Black;
            this.LblEstatus.Location = new System.Drawing.Point(538, 125);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(155, 18);
            this.LblEstatus.TabIndex = 48;
            this.LblEstatus.Text = "50 caracteres disponibles";
            this.LblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtDetalles
            // 
            this.TxtDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtDetalles.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDetalles.Enabled = false;
            this.TxtDetalles.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDetalles.Location = new System.Drawing.Point(17, 125);
            this.TxtDetalles.MaxLength = 50;
            this.TxtDetalles.Name = "TxtDetalles";
            this.TxtDetalles.Size = new System.Drawing.Size(515, 24);
            this.TxtDetalles.TabIndex = 42;
            this.TtProblema.SetToolTip(this.TxtDetalles, "Sólamente describe el problema, no la solución.");
            this.TxtDetalles.TextChanged += new System.EventHandler(this.TxtDetalles_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.RdSeguimientoGarantia);
            this.groupBox1.Controls.Add(this.RdIncidenteCalidad);
            this.groupBox1.Controls.Add(this.RdReclamoOficial);
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 179);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Describe el alcance del problema";
            // 
            // RdSeguimientoGarantia
            // 
            this.RdSeguimientoGarantia.Enabled = false;
            this.RdSeguimientoGarantia.Location = new System.Drawing.Point(71, 127);
            this.RdSeguimientoGarantia.Name = "RdSeguimientoGarantia";
            this.RdSeguimientoGarantia.Size = new System.Drawing.Size(616, 41);
            this.RdSeguimientoGarantia.TabIndex = 52;
            this.RdSeguimientoGarantia.TabStop = true;
            this.RdSeguimientoGarantia.Text = "El cliente solicita soporte para un problema menor cuya solución es evidente y no" +
    " representa riesgo. (Capacitación de personal del cliente, aclaraciones, dudas, " +
    "oportunidades de mejora, etc.)";
            this.RdSeguimientoGarantia.UseVisualStyleBackColor = true;
            this.RdSeguimientoGarantia.CheckedChanged += new System.EventHandler(this.RdSeguimientoGarantia_CheckedChanged);
            // 
            // RdIncidenteCalidad
            // 
            this.RdIncidenteCalidad.Enabled = false;
            this.RdIncidenteCalidad.Location = new System.Drawing.Point(71, 68);
            this.RdIncidenteCalidad.Name = "RdIncidenteCalidad";
            this.RdIncidenteCalidad.Size = new System.Drawing.Size(622, 53);
            this.RdIncidenteCalidad.TabIndex = 51;
            this.RdIncidenteCalidad.TabStop = true;
            this.RdIncidenteCalidad.Text = resources.GetString("RdIncidenteCalidad.Text");
            this.RdIncidenteCalidad.UseVisualStyleBackColor = true;
            this.RdIncidenteCalidad.CheckedChanged += new System.EventHandler(this.RdIncidenteCalidad_CheckedChanged);
            // 
            // RdReclamoOficial
            // 
            this.RdReclamoOficial.Enabled = false;
            this.RdReclamoOficial.Location = new System.Drawing.Point(71, 19);
            this.RdReclamoOficial.Name = "RdReclamoOficial";
            this.RdReclamoOficial.Size = new System.Drawing.Size(616, 51);
            this.RdReclamoOficial.TabIndex = 50;
            this.RdReclamoOficial.TabStop = true;
            this.RdReclamoOficial.Text = resources.GetString("RdReclamoOficial.Text");
            this.RdReclamoOficial.UseVisualStyleBackColor = true;
            this.RdReclamoOficial.CheckedChanged += new System.EventHandler(this.RdReclamoOficial_CheckedChanged);
            // 
            // CmbContacto
            // 
            this.CmbContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContacto.FormattingEnabled = true;
            this.CmbContacto.Location = new System.Drawing.Point(371, 71);
            this.CmbContacto.Name = "CmbContacto";
            this.CmbContacto.Size = new System.Drawing.Size(352, 28);
            this.CmbContacto.TabIndex = 47;
            this.CmbContacto.SelectedIndexChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Contacto:";
            // 
            // CmbProyecto
            // 
            this.CmbProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProyecto.FormattingEnabled = true;
            this.CmbProyecto.Location = new System.Drawing.Point(9, 72);
            this.CmbProyecto.Name = "CmbProyecto";
            this.CmbProyecto.Size = new System.Drawing.Size(353, 28);
            this.CmbProyecto.TabIndex = 26;
            this.CmbProyecto.SelectedIndexChanged += new System.EventHandler(this.CmbProyecto_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Proyecto:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(738, 23);
            this.LblTitulo.TabIndex = 5;
            this.LblTitulo.Text = "NUEVO TICKET DE SERVICIO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BkgBuscador
            // 
            this.BkgBuscador.WorkerReportsProgress = true;
            this.BkgBuscador.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgBuscador_DoWork);
            this.BkgBuscador.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgBuscador_RunWorkerCompleted);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(541, 222);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 40);
            this.BtnCancelar.TabIndex = 45;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Enabled = false;
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(541, 176);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(160, 40);
            this.BtnRegistrar.TabIndex = 44;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CB_Base.Properties.Resources.about_icon_48;
            this.pictureBox3.Location = new System.Drawing.Point(17, 121);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 55;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CB_Base.Properties.Resources.reclamo_oficial_48;
            this.pictureBox2.Location = new System.Drawing.Point(17, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CB_Base.Properties.Resources.incidente_calidad_48;
            this.pictureBox1.Location = new System.Drawing.Point(17, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // FrmNuevoTicketServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 630);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbContacto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbProyecto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoTicketServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevoTicketServicio";
            this.Load += new System.EventHandler(this.FrmNuevoTicketServicio_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ComboBox CmbProyecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDetalles;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.ComboBox CmbContacto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblEstatus;
        private System.ComponentModel.BackgroundWorker BkgEnviarCorreo;
        private System.Windows.Forms.ToolTip TtProblema;
        private System.Windows.Forms.RadioButton RdReclamoOficial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RdSeguimientoGarantia;
        private System.Windows.Forms.RadioButton RdIncidenteCalidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView ListaSintomas;
        private System.ComponentModel.BackgroundWorker BkgBuscador;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
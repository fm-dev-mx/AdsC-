namespace CB
{
    partial class FrmDetallesTicketServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetallesTicketServicio));
            this.MenuAcciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BkgEnviarAvancesAlCorreo = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbMetodologia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtDetalles = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbEtapa = new System.Windows.Forms.ComboBox();
            this.TxtTipo = new System.Windows.Forms.TextBox();
            this.LblUltimoReporte = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtProyecto = new System.Windows.Forms.TextBox();
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtContacto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnRegresar = new System.Windows.Forms.Button();
            this.BtnContinuar = new System.Windows.Forms.Button();
            this.BtnEnviarAvances = new System.Windows.Forms.Button();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.LblEstatusSeguimiento = new System.Windows.Forms.Label();
            this.LblEstatusTicket = new System.Windows.Forms.Label();
            this.ImagenesTipoTicket = new System.Windows.Forms.ImageList(this.components);
            this.PicTipoTicket = new System.Windows.Forms.PictureBox();
            this.MenuAcciones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTipoTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuAcciones
            // 
            this.MenuAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaToolStripMenuItem});
            this.MenuAcciones.Name = "MenuAcciones";
            this.MenuAcciones.Size = new System.Drawing.Size(109, 26);
            // 
            // BkgEnviarAvancesAlCorreo
            // 
            this.BkgEnviarAvancesAlCorreo.WorkerReportsProgress = true;
            this.BkgEnviarAvancesAlCorreo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEnviarCorreo_DoWork);
            this.BkgEnviarAvancesAlCorreo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEnviarAvancesAlCorreo_RunWorkerCompleted);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "help_icon_48.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PicTipoTicket);
            this.panel1.Controls.Add(this.LblEstatusTicket);
            this.panel1.Controls.Add(this.LblEstatusSeguimiento);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.CmbMetodologia);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TxtDetalles);
            this.panel1.Controls.Add(this.BtnRegresar);
            this.panel1.Controls.Add(this.BtnContinuar);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CmbEtapa);
            this.panel1.Controls.Add(this.TxtTipo);
            this.panel1.Controls.Add(this.LblUltimoReporte);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.BtnEnviarAvances);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtProyecto);
            this.panel1.Controls.Add(this.TxtCliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtContacto);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TxtID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 270);
            this.panel1.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(250, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Metodología a seguir para la solución del problema:";
            // 
            // CmbMetodologia
            // 
            this.CmbMetodologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMetodologia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMetodologia.FormattingEnabled = true;
            this.CmbMetodologia.Location = new System.Drawing.Point(12, 229);
            this.CmbMetodologia.Name = "CmbMetodologia";
            this.CmbMetodologia.Size = new System.Drawing.Size(439, 32);
            this.CmbMetodologia.TabIndex = 43;
            this.CmbMetodologia.SelectedIndexChanged += new System.EventHandler(this.CmbMetodologia_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "¿Qué ocurre?";
            // 
            // TxtDetalles
            // 
            this.TxtDetalles.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDetalles.Location = new System.Drawing.Point(13, 145);
            this.TxtDetalles.Multiline = true;
            this.TxtDetalles.Name = "TxtDetalles";
            this.TxtDetalles.ReadOnly = true;
            this.TxtDetalles.Size = new System.Drawing.Size(1013, 65);
            this.TxtDetalles.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Etapa actual:";
            // 
            // CmbEtapa
            // 
            this.CmbEtapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEtapa.Enabled = false;
            this.CmbEtapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEtapa.FormattingEnabled = true;
            this.CmbEtapa.Location = new System.Drawing.Point(457, 229);
            this.CmbEtapa.Name = "CmbEtapa";
            this.CmbEtapa.Size = new System.Drawing.Size(661, 32);
            this.CmbEtapa.TabIndex = 37;
            this.CmbEtapa.SelectedIndexChanged += new System.EventHandler(this.CmbEtapa_SelectedIndexChanged);
            // 
            // TxtTipo
            // 
            this.TxtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTipo.Location = new System.Drawing.Point(117, 47);
            this.TxtTipo.Name = "TxtTipo";
            this.TxtTipo.ReadOnly = true;
            this.TxtTipo.Size = new System.Drawing.Size(334, 29);
            this.TxtTipo.TabIndex = 20;
            // 
            // LblUltimoReporte
            // 
            this.LblUltimoReporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUltimoReporte.BackColor = System.Drawing.Color.Transparent;
            this.LblUltimoReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUltimoReporte.ForeColor = System.Drawing.Color.Black;
            this.LblUltimoReporte.Location = new System.Drawing.Point(1065, 148);
            this.LblUltimoReporte.Name = "LblUltimoReporte";
            this.LblUltimoReporte.Size = new System.Drawing.Size(224, 23);
            this.LblUltimoReporte.TabIndex = 32;
            this.LblUltimoReporte.Text = "Ultimo reporte: 00,00 2018 00:00:00";
            this.LblUltimoReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1370, 23);
            this.LblTitulo.TabIndex = 9;
            this.LblTitulo.Text = "DETALLES DEL TICKET DE SERVICIO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1193, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 20);
            this.button1.TabIndex = 32;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Proyecto:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(799, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Estatus del ticket:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Cliente:";
            // 
            // TxtProyecto
            // 
            this.TxtProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProyecto.Location = new System.Drawing.Point(13, 95);
            this.TxtProyecto.Name = "TxtProyecto";
            this.TxtProyecto.ReadOnly = true;
            this.TxtProyecto.Size = new System.Drawing.Size(438, 29);
            this.TxtProyecto.TabIndex = 21;
            // 
            // TxtCliente
            // 
            this.TxtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCliente.Location = new System.Drawing.Point(457, 47);
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.ReadOnly = true;
            this.TxtCliente.Size = new System.Drawing.Size(339, 29);
            this.TxtCliente.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tipo de ticket:";
            // 
            // TxtContacto
            // 
            this.TxtContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContacto.Location = new System.Drawing.Point(457, 95);
            this.TxtContacto.Name = "TxtContacto";
            this.TxtContacto.ReadOnly = true;
            this.TxtContacto.Size = new System.Drawing.Size(339, 29);
            this.TxtContacto.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Contacto:";
            // 
            // TxtID
            // 
            this.TxtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtID.Location = new System.Drawing.Point(13, 47);
            this.TxtID.Name = "TxtID";
            this.TxtID.ReadOnly = true;
            this.TxtID.Size = new System.Drawing.Size(59, 29);
            this.TxtID.TabIndex = 17;
            this.TxtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "ID";
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegresar.Image = global::CB_Base.Properties.Resources.previous_icon_32;
            this.BtnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegresar.Location = new System.Drawing.Point(1124, 221);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Size = new System.Drawing.Size(108, 40);
            this.BtnRegresar.TabIndex = 40;
            this.BtnRegresar.Text = "Regresar";
            this.BtnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRegresar.UseVisualStyleBackColor = true;
            // 
            // BtnContinuar
            // 
            this.BtnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnContinuar.Image = global::CB_Base.Properties.Resources.next_icon_32;
            this.BtnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnContinuar.Location = new System.Drawing.Point(1238, 221);
            this.BtnContinuar.Name = "BtnContinuar";
            this.BtnContinuar.Size = new System.Drawing.Size(108, 40);
            this.BtnContinuar.TabIndex = 39;
            this.BtnContinuar.Text = "Continuar       ";
            this.BtnContinuar.UseVisualStyleBackColor = true;
            // 
            // BtnEnviarAvances
            // 
            this.BtnEnviarAvances.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEnviarAvances.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviarAvances.Image = global::CB_Base.Properties.Resources.mail_send_icon48;
            this.BtnEnviarAvances.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEnviarAvances.Location = new System.Drawing.Point(1193, 47);
            this.BtnEnviarAvances.Name = "BtnEnviarAvances";
            this.BtnEnviarAvances.Size = new System.Drawing.Size(153, 54);
            this.BtnEnviarAvances.TabIndex = 30;
            this.BtnEnviarAvances.Text = "        Reportar";
            this.BtnEnviarAvances.UseVisualStyleBackColor = true;
            this.BtnEnviarAvances.Visible = false;
            this.BtnEnviarAvances.Click += new System.EventHandler(this.BtnEnviarAvances_Click);
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.nuevaToolStripMenuItem.Text = "Nueva";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(799, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Estatus del seguimiento:";
            // 
            // LblEstatusSeguimiento
            // 
            this.LblEstatusSeguimiento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEstatusSeguimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.LblEstatusSeguimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusSeguimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblEstatusSeguimiento.Location = new System.Drawing.Point(802, 95);
            this.LblEstatusSeguimiento.Name = "LblEstatusSeguimiento";
            this.LblEstatusSeguimiento.Size = new System.Drawing.Size(224, 29);
            this.LblEstatusSeguimiento.TabIndex = 47;
            this.LblEstatusSeguimiento.Text = "OK";
            this.LblEstatusSeguimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblEstatusTicket
            // 
            this.LblEstatusTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEstatusTicket.BackColor = System.Drawing.SystemColors.Control;
            this.LblEstatusTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblEstatusTicket.Location = new System.Drawing.Point(802, 47);
            this.LblEstatusTicket.Name = "LblEstatusTicket";
            this.LblEstatusTicket.Size = new System.Drawing.Size(224, 29);
            this.LblEstatusTicket.TabIndex = 48;
            this.LblEstatusTicket.Text = "ABIERTO";
            this.LblEstatusTicket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImagenesTipoTicket
            // 
            this.ImagenesTipoTicket.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTipoTicket.ImageStream")));
            this.ImagenesTipoTicket.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTipoTicket.Images.SetKeyName(0, "critical_48.png");
            this.ImagenesTipoTicket.Images.SetKeyName(1, "warning-48.png");
            this.ImagenesTipoTicket.Images.SetKeyName(2, "about_icon_48.png");
            // 
            // PicTipoTicket
            // 
            this.PicTipoTicket.Location = new System.Drawing.Point(81, 47);
            this.PicTipoTicket.Name = "PicTipoTicket";
            this.PicTipoTicket.Size = new System.Drawing.Size(30, 29);
            this.PicTipoTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTipoTicket.TabIndex = 49;
            this.PicTipoTicket.TabStop = false;
            // 
            // FrmDetallesTicketServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 567);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "FrmDetallesTicketServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles del ticket de servicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDetallesTicketServicio_Load);
            this.MenuAcciones.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTipoTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MenuAcciones;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgEnviarAvancesAlCorreo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtTipo;
        private System.Windows.Forms.Label LblUltimoReporte;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnEnviarAvances;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtProyecto;
        private System.Windows.Forms.TextBox TxtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtContacto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbEtapa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnRegresar;
        private System.Windows.Forms.Button BtnContinuar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtDetalles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbMetodologia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblEstatusTicket;
        private System.Windows.Forms.Label LblEstatusSeguimiento;
        private System.Windows.Forms.PictureBox PicTipoTicket;
        private System.Windows.Forms.ImageList ImagenesTipoTicket;
    }
}
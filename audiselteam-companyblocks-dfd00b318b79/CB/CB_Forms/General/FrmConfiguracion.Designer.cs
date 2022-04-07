namespace CB
{
    partial class FrmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtFirma = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkSsl = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtServidor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPuerto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtBDServidorLocal = new System.Windows.Forms.TextBox();
            this.TxtBDPuerto = new System.Windows.Forms.TextBox();
            this.LblPuertoBD = new System.Windows.Forms.Label();
            this.LblUsuarioSistema = new System.Windows.Forms.Label();
            this.TxtBDNombre = new System.Windows.Forms.TextBox();
            this.LblBaseDatos = new System.Windows.Forms.Label();
            this.TxtBDUsuario = new System.Windows.Forms.TextBox();
            this.LblContrasena = new System.Windows.Forms.Label();
            this.TxtBDPassword = new System.Windows.Forms.TextBox();
            this.LblIpServidor = new System.Windows.Forms.Label();
            this.TxtBDServidorRemoto = new System.Windows.Forms.TextBox();
            this.BtnSalirBD = new System.Windows.Forms.Button();
            this.BtnGuardarBD = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TxtFtpPuerto = new System.Windows.Forms.TextBox();
            this.LblFtpPuerto = new System.Windows.Forms.Label();
            this.TxtFtpIpServidor = new System.Windows.Forms.TextBox();
            this.LblFtpIpServidor = new System.Windows.Forms.Label();
            this.TxtFtpHost = new System.Windows.Forms.TextBox();
            this.LblFtpHost = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ChkBCache = new System.Windows.Forms.CheckBox();
            this.BtnDisenoSalir = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ImgListaImagenes = new System.Windows.Forms.ImageList(this.components);
            this.BkgDescargarDB = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarCorreo = new System.ComponentModel.BackgroundWorker();
            this.BtnImportar = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(518, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "CONFIGURACION DEL SISTEMA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label4_MouseDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(506, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "   Correo        ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtFirma);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 86);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Firma";
            // 
            // TxtFirma
            // 
            this.TxtFirma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFirma.Location = new System.Drawing.Point(6, 15);
            this.TxtFirma.Multiline = true;
            this.TxtFirma.Name = "TxtFirma";
            this.TxtFirma.Size = new System.Drawing.Size(488, 65);
            this.TxtFirma.TabIndex = 5;
            this.TxtFirma.TextChanged += new System.EventHandler(this.TxtFirma_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkSsl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtUsuario);
            this.groupBox1.Controls.Add(this.TxtPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtServidor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtPuerto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 283);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del usuario";
            // 
            // ChkSsl
            // 
            this.ChkSsl.AutoSize = true;
            this.ChkSsl.Location = new System.Drawing.Point(8, 174);
            this.ChkSsl.Name = "ChkSsl";
            this.ChkSsl.Size = new System.Drawing.Size(87, 17);
            this.ChkSsl.TabIndex = 16;
            this.ChkSsl.Text = "Habilitar SSL";
            this.ChkSsl.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Usuario:";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtUsuario.Location = new System.Drawing.Point(94, 27);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(392, 29);
            this.TxtUsuario.TabIndex = 1;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtPassword.Location = new System.Drawing.Point(94, 62);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(392, 29);
            this.TxtPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Puerto SMTP:";
            // 
            // TxtServidor
            // 
            this.TxtServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtServidor.Location = new System.Drawing.Point(94, 97);
            this.TxtServidor.Name = "TxtServidor";
            this.TxtServidor.Size = new System.Drawing.Size(392, 29);
            this.TxtServidor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Servidor SMTP:";
            // 
            // TxtPuerto
            // 
            this.TxtPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtPuerto.Location = new System.Drawing.Point(94, 132);
            this.TxtPuerto.Name = "TxtPuerto";
            this.TxtPuerto.Size = new System.Drawing.Size(138, 29);
            this.TxtPuerto.TabIndex = 4;
            this.TxtPuerto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPuerto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(506, 289);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Base de datos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.TxtBDServidorLocal);
            this.groupBox3.Controls.Add(this.TxtBDPuerto);
            this.groupBox3.Controls.Add(this.LblPuertoBD);
            this.groupBox3.Controls.Add(this.LblUsuarioSistema);
            this.groupBox3.Controls.Add(this.TxtBDNombre);
            this.groupBox3.Controls.Add(this.LblBaseDatos);
            this.groupBox3.Controls.Add(this.TxtBDUsuario);
            this.groupBox3.Controls.Add(this.LblContrasena);
            this.groupBox3.Controls.Add(this.TxtBDPassword);
            this.groupBox3.Controls.Add(this.LblIpServidor);
            this.groupBox3.Controls.Add(this.TxtBDServidorRemoto);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 283);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos de conexión";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "IP del servidor local:";
            // 
            // TxtBDServidorLocal
            // 
            this.TxtBDServidorLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtBDServidorLocal.Location = new System.Drawing.Point(127, 50);
            this.TxtBDServidorLocal.MaxLength = 15;
            this.TxtBDServidorLocal.Name = "TxtBDServidorLocal";
            this.TxtBDServidorLocal.Size = new System.Drawing.Size(370, 29);
            this.TxtBDServidorLocal.TabIndex = 2;
            this.TxtBDServidorLocal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBDServidorLocal_KeyPress);
            // 
            // TxtBDPuerto
            // 
            this.TxtBDPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtBDPuerto.Location = new System.Drawing.Point(127, 120);
            this.TxtBDPuerto.Name = "TxtBDPuerto";
            this.TxtBDPuerto.Size = new System.Drawing.Size(130, 29);
            this.TxtBDPuerto.TabIndex = 4;
            this.TxtBDPuerto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBDPuerto_KeyPress);
            // 
            // LblPuertoBD
            // 
            this.LblPuertoBD.AutoSize = true;
            this.LblPuertoBD.Location = new System.Drawing.Point(9, 131);
            this.LblPuertoBD.Name = "LblPuertoBD";
            this.LblPuertoBD.Size = new System.Drawing.Size(58, 13);
            this.LblPuertoBD.TabIndex = 18;
            this.LblPuertoBD.Text = "BD puerto:";
            // 
            // LblUsuarioSistema
            // 
            this.LblUsuarioSistema.AutoSize = true;
            this.LblUsuarioSistema.Location = new System.Drawing.Point(9, 166);
            this.LblUsuarioSistema.Name = "LblUsuarioSistema";
            this.LblUsuarioSistema.Size = new System.Drawing.Size(62, 13);
            this.LblUsuarioSistema.TabIndex = 16;
            this.LblUsuarioSistema.Text = "BD usuario:";
            // 
            // TxtBDNombre
            // 
            this.TxtBDNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtBDNombre.Location = new System.Drawing.Point(127, 85);
            this.TxtBDNombre.Name = "TxtBDNombre";
            this.TxtBDNombre.Size = new System.Drawing.Size(370, 29);
            this.TxtBDNombre.TabIndex = 3;
            // 
            // LblBaseDatos
            // 
            this.LblBaseDatos.AutoSize = true;
            this.LblBaseDatos.Location = new System.Drawing.Point(9, 96);
            this.LblBaseDatos.Name = "LblBaseDatos";
            this.LblBaseDatos.Size = new System.Drawing.Size(78, 13);
            this.LblBaseDatos.TabIndex = 14;
            this.LblBaseDatos.Text = "Base de datos:";
            // 
            // TxtBDUsuario
            // 
            this.TxtBDUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtBDUsuario.Location = new System.Drawing.Point(127, 155);
            this.TxtBDUsuario.Name = "TxtBDUsuario";
            this.TxtBDUsuario.Size = new System.Drawing.Size(370, 29);
            this.TxtBDUsuario.TabIndex = 5;
            // 
            // LblContrasena
            // 
            this.LblContrasena.AutoSize = true;
            this.LblContrasena.Location = new System.Drawing.Point(9, 201);
            this.LblContrasena.Name = "LblContrasena";
            this.LblContrasena.Size = new System.Drawing.Size(64, 13);
            this.LblContrasena.TabIndex = 12;
            this.LblContrasena.Text = "Contraseña:";
            // 
            // TxtBDPassword
            // 
            this.TxtBDPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtBDPassword.Location = new System.Drawing.Point(127, 190);
            this.TxtBDPassword.Name = "TxtBDPassword";
            this.TxtBDPassword.Size = new System.Drawing.Size(370, 29);
            this.TxtBDPassword.TabIndex = 6;
            this.TxtBDPassword.UseSystemPasswordChar = true;
            // 
            // LblIpServidor
            // 
            this.LblIpServidor.AutoSize = true;
            this.LblIpServidor.Location = new System.Drawing.Point(6, 26);
            this.LblIpServidor.Name = "LblIpServidor";
            this.LblIpServidor.Size = new System.Drawing.Size(112, 13);
            this.LblIpServidor.TabIndex = 10;
            this.LblIpServidor.Text = "IP del servidor remoto:";
            // 
            // TxtBDServidorRemoto
            // 
            this.TxtBDServidorRemoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtBDServidorRemoto.Location = new System.Drawing.Point(127, 15);
            this.TxtBDServidorRemoto.MaxLength = 15;
            this.TxtBDServidorRemoto.Name = "TxtBDServidorRemoto";
            this.TxtBDServidorRemoto.Size = new System.Drawing.Size(370, 29);
            this.TxtBDServidorRemoto.TabIndex = 1;
            this.TxtBDServidorRemoto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBDServidorRemoto_KeyPress);
            // 
            // BtnSalirBD
            // 
            this.BtnSalirBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnSalirBD.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalirBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalirBD.Location = new System.Drawing.Point(381, 360);
            this.BtnSalirBD.Name = "BtnSalirBD";
            this.BtnSalirBD.Size = new System.Drawing.Size(133, 55);
            this.BtnSalirBD.TabIndex = 7;
            this.BtnSalirBD.Text = "       Salir";
            this.BtnSalirBD.UseVisualStyleBackColor = true;
            this.BtnSalirBD.Click += new System.EventHandler(this.BtnSalirBD_Click);
            // 
            // BtnGuardarBD
            // 
            this.BtnGuardarBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnGuardarBD.Image = global::CB_Base.Properties.Resources.User_Interface_Save_As_icon;
            this.BtnGuardarBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardarBD.Location = new System.Drawing.Point(242, 360);
            this.BtnGuardarBD.Name = "BtnGuardarBD";
            this.BtnGuardarBD.Size = new System.Drawing.Size(133, 55);
            this.BtnGuardarBD.TabIndex = 8;
            this.BtnGuardarBD.Text = "             Guardar";
            this.BtnGuardarBD.UseVisualStyleBackColor = true;
            this.BtnGuardarBD.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ImageList = this.ImgListaImagenes;
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 31);
            this.tabControl1.Location = new System.Drawing.Point(4, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(514, 328);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 35);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(506, 289);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Servidor FTP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.TxtFtpPuerto);
            this.groupBox4.Controls.Add(this.LblFtpPuerto);
            this.groupBox4.Controls.Add(this.TxtFtpIpServidor);
            this.groupBox4.Controls.Add(this.LblFtpIpServidor);
            this.groupBox4.Controls.Add(this.TxtFtpHost);
            this.groupBox4.Controls.Add(this.LblFtpHost);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(500, 109);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos del servidor FTP";
            // 
            // TxtFtpPuerto
            // 
            this.TxtFtpPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtFtpPuerto.Location = new System.Drawing.Point(94, 109);
            this.TxtFtpPuerto.Name = "TxtFtpPuerto";
            this.TxtFtpPuerto.Size = new System.Drawing.Size(100, 29);
            this.TxtFtpPuerto.TabIndex = 3;
            this.TxtFtpPuerto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFtpPuerto_KeyPress);
            // 
            // LblFtpPuerto
            // 
            this.LblFtpPuerto.AutoSize = true;
            this.LblFtpPuerto.Location = new System.Drawing.Point(6, 120);
            this.LblFtpPuerto.Name = "LblFtpPuerto";
            this.LblFtpPuerto.Size = new System.Drawing.Size(41, 13);
            this.LblFtpPuerto.TabIndex = 15;
            this.LblFtpPuerto.Text = "Puerto:";
            // 
            // TxtFtpIpServidor
            // 
            this.TxtFtpIpServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtFtpIpServidor.Location = new System.Drawing.Point(94, 31);
            this.TxtFtpIpServidor.MaxLength = 21;
            this.TxtFtpIpServidor.Name = "TxtFtpIpServidor";
            this.TxtFtpIpServidor.Size = new System.Drawing.Size(392, 29);
            this.TxtFtpIpServidor.TabIndex = 1;
            // 
            // LblFtpIpServidor
            // 
            this.LblFtpIpServidor.AutoSize = true;
            this.LblFtpIpServidor.Location = new System.Drawing.Point(6, 42);
            this.LblFtpIpServidor.Name = "LblFtpIpServidor";
            this.LblFtpIpServidor.Size = new System.Drawing.Size(89, 13);
            this.LblFtpIpServidor.TabIndex = 13;
            this.LblFtpIpServidor.Text = "Conexion remota:";
            // 
            // TxtFtpHost
            // 
            this.TxtFtpHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtFtpHost.Location = new System.Drawing.Point(94, 74);
            this.TxtFtpHost.Name = "TxtFtpHost";
            this.TxtFtpHost.Size = new System.Drawing.Size(392, 29);
            this.TxtFtpHost.TabIndex = 2;
            // 
            // LblFtpHost
            // 
            this.LblFtpHost.AutoSize = true;
            this.LblFtpHost.Location = new System.Drawing.Point(6, 85);
            this.LblFtpHost.Name = "LblFtpHost";
            this.LblFtpHost.Size = new System.Drawing.Size(83, 13);
            this.LblFtpHost.TabIndex = 11;
            this.LblFtpHost.Text = "Conexion Local:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.ImageIndex = 3;
            this.tabPage4.Location = new System.Drawing.Point(4, 35);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(506, 289);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Diseño          ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.ChkBCache);
            this.groupBox5.Controls.Add(this.BtnDisenoSalir);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(504, 315);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Opciones avanzadas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Khaki;
            this.label7.Location = new System.Drawing.Point(42, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(379, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Esta opción no es recomendada para equipos de computo con pocos recursos";
            // 
            // ChkBCache
            // 
            this.ChkBCache.AutoSize = true;
            this.ChkBCache.Checked = true;
            this.ChkBCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBCache.Location = new System.Drawing.Point(22, 31);
            this.ChkBCache.Name = "ChkBCache";
            this.ChkBCache.Size = new System.Drawing.Size(407, 19);
            this.ChkBCache.TabIndex = 6;
            this.ChkBCache.Text = "Perminitir que el sistema genere de forma automática  archivos caché";
            this.ChkBCache.UseVisualStyleBackColor = true;
            // 
            // BtnDisenoSalir
            // 
            this.BtnDisenoSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnDisenoSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnDisenoSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDisenoSalir.Location = new System.Drawing.Point(225, 291);
            this.BtnDisenoSalir.Name = "BtnDisenoSalir";
            this.BtnDisenoSalir.Size = new System.Drawing.Size(133, 55);
            this.BtnDisenoSalir.TabIndex = 4;
            this.BtnDisenoSalir.Text = "       Salir";
            this.BtnDisenoSalir.UseVisualStyleBackColor = true;
            this.BtnDisenoSalir.Click += new System.EventHandler(this.BtnDisenoSalir_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button3.Image = global::CB_Base.Properties.Resources.User_Interface_Save_As_icon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(364, 291);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 55);
            this.button3.TabIndex = 5;
            this.button3.Text = "             Guardar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ImgListaImagenes
            // 
            this.ImgListaImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgListaImagenes.ImageStream")));
            this.ImgListaImagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgListaImagenes.Images.SetKeyName(0, "email-setup.png");
            this.ImgListaImagenes.Images.SetKeyName(1, "DataBase-configuration.png");
            this.ImgListaImagenes.Images.SetKeyName(2, "FTP.png");
            this.ImgListaImagenes.Images.SetKeyName(3, "solidworks.png");
            this.ImgListaImagenes.Images.SetKeyName(4, "adjunto.png");
            // 
            // BkgDescargarDB
            // 
            this.BkgDescargarDB.WorkerReportsProgress = true;
            // 
            // BkgDescargarCorreo
            // 
            this.BkgDescargarCorreo.WorkerReportsProgress = true;
            // 
            // BtnImportar
            // 
            this.BtnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImportar.Image = global::CB_Base.Properties.Resources.complete_48;
            this.BtnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImportar.Location = new System.Drawing.Point(105, 360);
            this.BtnImportar.Name = "BtnImportar";
            this.BtnImportar.Size = new System.Drawing.Size(131, 55);
            this.BtnImportar.TabIndex = 23;
            this.BtnImportar.Text = "         Importar";
            this.BtnImportar.UseVisualStyleBackColor = true;
            this.BtnImportar.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 419);
            this.Controls.Add(this.BtnImportar);
            this.Controls.Add(this.BtnSalirBD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BtnGuardarBD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración del sistema";
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtFirma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtServidor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPuerto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label LblUsuarioSistema;
        private System.Windows.Forms.TextBox TxtBDNombre;
        private System.Windows.Forms.Label LblBaseDatos;
        private System.Windows.Forms.TextBox TxtBDUsuario;
        private System.Windows.Forms.Label LblContrasena;
        private System.Windows.Forms.TextBox TxtBDPassword;
        private System.Windows.Forms.Label LblIpServidor;
        private System.Windows.Forms.TextBox TxtBDServidorRemoto;
        private System.Windows.Forms.TextBox TxtBDPuerto;
        private System.Windows.Forms.Label LblPuertoBD;
        private System.ComponentModel.BackgroundWorker BkgDescargarDB;
        private System.ComponentModel.BackgroundWorker BkgDescargarCorreo;
        private System.Windows.Forms.Button BtnGuardarBD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtBDServidorLocal;
        private System.Windows.Forms.ImageList ImgListaImagenes;
        private System.Windows.Forms.Button BtnSalirBD;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TxtFtpPuerto;
        private System.Windows.Forms.Label LblFtpPuerto;
        private System.Windows.Forms.TextBox TxtFtpIpServidor;
        private System.Windows.Forms.Label LblFtpIpServidor;
        private System.Windows.Forms.TextBox TxtFtpHost;
        private System.Windows.Forms.Label LblFtpHost;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BtnDisenoSalir;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ChkBCache;
        private System.Windows.Forms.CheckBox ChkSsl;
        private System.Windows.Forms.Button BtnImportar;
    }
}
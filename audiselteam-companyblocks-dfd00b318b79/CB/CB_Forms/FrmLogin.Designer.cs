namespace CB
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.CmbTipoConexion = new System.Windows.Forms.ComboBox();
            this.LblTipoConexion = new System.Windows.Forms.Label();
            this.LinkConfiguracion = new System.Windows.Forms.LinkLabel();
            this.LblVersion = new System.Windows.Forms.Label();
            this.BtnIngresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(242, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(354, 97);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(221, 20);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(261, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Usuario:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(354, 61);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(221, 20);
            this.txtCorreo.TabIndex = 11;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            this.txtCorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorreo_KeyPress);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(499, 2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 17;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblEstatus
            // 
            this.LblEstatus.AutoSize = true;
            this.LblEstatus.BackColor = System.Drawing.Color.Transparent;
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LblEstatus.Location = new System.Drawing.Point(8, 135);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(71, 20);
            this.LblEstatus.TabIndex = 18;
            this.LblEstatus.Text = "Estatus";
            this.LblEstatus.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CB_Base.Properties.Resources.logopositivoCompanyblocks_Artboard_31;
            this.pictureBox1.Location = new System.Drawing.Point(16, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(325, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(403, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(171, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // CmbTipoConexion
            // 
            this.CmbTipoConexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoConexion.FormattingEnabled = true;
            this.CmbTipoConexion.Items.AddRange(new object[] {
            "LOCAL",
            "REMOTA"});
            this.CmbTipoConexion.Location = new System.Drawing.Point(42, 76);
            this.CmbTipoConexion.Name = "CmbTipoConexion";
            this.CmbTipoConexion.Size = new System.Drawing.Size(138, 21);
            this.CmbTipoConexion.TabIndex = 21;
            this.CmbTipoConexion.SelectedIndexChanged += new System.EventHandler(this.CmbTipoConexion_SelectedIndexChanged);
            // 
            // LblTipoConexion
            // 
            this.LblTipoConexion.AutoSize = true;
            this.LblTipoConexion.BackColor = System.Drawing.Color.Transparent;
            this.LblTipoConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipoConexion.ForeColor = System.Drawing.Color.White;
            this.LblTipoConexion.Location = new System.Drawing.Point(39, 55);
            this.LblTipoConexion.Name = "LblTipoConexion";
            this.LblTipoConexion.Size = new System.Drawing.Size(142, 18);
            this.LblTipoConexion.TabIndex = 22;
            this.LblTipoConexion.Text = "Tipo de conexión:";
            // 
            // LinkConfiguracion
            // 
            this.LinkConfiguracion.ActiveLinkColor = System.Drawing.Color.White;
            this.LinkConfiguracion.AutoSize = true;
            this.LinkConfiguracion.BackColor = System.Drawing.Color.Transparent;
            this.LinkConfiguracion.LinkColor = System.Drawing.Color.White;
            this.LinkConfiguracion.Location = new System.Drawing.Point(39, 104);
            this.LinkConfiguracion.Name = "LinkConfiguracion";
            this.LinkConfiguracion.Size = new System.Drawing.Size(72, 13);
            this.LinkConfiguracion.TabIndex = 24;
            this.LinkConfiguracion.TabStop = true;
            this.LinkConfiguracion.Text = "Configuración";
            this.LinkConfiguracion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkConfiguracion_LinkClicked);
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.BackColor = System.Drawing.Color.Transparent;
            this.LblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVersion.ForeColor = System.Drawing.Color.Transparent;
            this.LblVersion.Location = new System.Drawing.Point(351, 38);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(47, 16);
            this.LblVersion.TabIndex = 26;
            this.LblVersion.Text = "V 4.2.9";
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.Enabled = false;
            this.BtnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIngresar.Location = new System.Drawing.Point(478, 123);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(97, 32);
            this.BtnIngresar.TabIndex = 25;
            this.BtnIngresar.Text = "Ingresar";
            this.BtnIngresar.UseVisualStyleBackColor = true;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CB_Base.Properties.Resources.fondocompanynegro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(590, 164);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnIngresar);
            this.Controls.Add(this.LinkConfiguracion);
            this.Controls.Add(this.LblTipoConexion);
            this.Controls.Add(this.CmbTipoConexion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblEstatus);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox CmbTipoConexion;
        private System.Windows.Forms.Label LblTipoConexion;
        private System.Windows.Forms.LinkLabel LinkConfiguracion;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Button BtnIngresar;
    }
}
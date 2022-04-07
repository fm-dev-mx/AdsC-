namespace CB
{
    partial class FrmAdministrarUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblNumeroPlano = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ChkMostrarInactivos = new System.Windows.Forms.CheckBox();
            this.BtnEditarUsuario = new System.Windows.Forms.Button();
            this.BtnNuevoUsuario = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DgvUsuarios = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatosUsuario = new System.Windows.Forms.GroupBox();
            this.LblInfo = new System.Windows.Forms.Label();
            this.CmbRol = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.TxtPaterno = new System.Windows.Forms.TextBox();
            this.ChkUsuarioActivo = new System.Windows.Forms.CheckBox();
            this.TxtMaterno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCambiarPassword = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblNombreUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).BeginInit();
            this.DatosUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblNumeroPlano
            // 
            this.LblNumeroPlano.BackColor = System.Drawing.Color.Black;
            this.LblNumeroPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroPlano.ForeColor = System.Drawing.Color.White;
            this.LblNumeroPlano.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroPlano.Name = "LblNumeroPlano";
            this.LblNumeroPlano.Size = new System.Drawing.Size(1229, 23);
            this.LblNumeroPlano.TabIndex = 9;
            this.LblNumeroPlano.Text = "ADMINISTRAR USUARIOS";
            this.LblNumeroPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ChkMostrarInactivos);
            this.splitContainer1.Panel1.Controls.Add(this.BtnEditarUsuario);
            this.splitContainer1.Panel1.Controls.Add(this.BtnNuevoUsuario);
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1229, 680);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.TabIndex = 11;
            // 
            // ChkMostrarInactivos
            // 
            this.ChkMostrarInactivos.AutoSize = true;
            this.ChkMostrarInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkMostrarInactivos.Location = new System.Drawing.Point(12, 12);
            this.ChkMostrarInactivos.Name = "ChkMostrarInactivos";
            this.ChkMostrarInactivos.Size = new System.Drawing.Size(168, 28);
            this.ChkMostrarInactivos.TabIndex = 26;
            this.ChkMostrarInactivos.Text = "Mostrar inactivos";
            this.ChkMostrarInactivos.UseVisualStyleBackColor = true;
            this.ChkMostrarInactivos.CheckedChanged += new System.EventHandler(this.ChkMostrarInactivos_CheckedChanged);
            // 
            // BtnEditarUsuario
            // 
            this.BtnEditarUsuario.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnEditarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditarUsuario.Image = global::CB_Base.Properties.Resources.Edit;
            this.BtnEditarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditarUsuario.Location = new System.Drawing.Point(857, 0);
            this.BtnEditarUsuario.Name = "BtnEditarUsuario";
            this.BtnEditarUsuario.Size = new System.Drawing.Size(101, 53);
            this.BtnEditarUsuario.TabIndex = 25;
            this.BtnEditarUsuario.Text = "Editar";
            this.BtnEditarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEditarUsuario.UseVisualStyleBackColor = true;
            this.BtnEditarUsuario.Click += new System.EventHandler(this.BtnEditarUsuario_Click);
            // 
            // BtnNuevoUsuario
            // 
            this.BtnNuevoUsuario.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNuevoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevoUsuario.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.BtnNuevoUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevoUsuario.Location = new System.Drawing.Point(958, 0);
            this.BtnNuevoUsuario.Name = "BtnNuevoUsuario";
            this.BtnNuevoUsuario.Size = new System.Drawing.Size(152, 53);
            this.BtnNuevoUsuario.TabIndex = 23;
            this.BtnNuevoUsuario.Text = "Nuevo usuario";
            this.BtnNuevoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevoUsuario.UseVisualStyleBackColor = true;
            this.BtnNuevoUsuario.Click += new System.EventHandler(this.BtnNuevoUsuario_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.close;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1110, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(119, 53);
            this.BtnSalir.TabIndex = 18;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.DgvUsuarios);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.DatosUsuario);
            this.splitContainer2.Panel2.Controls.Add(this.LblNombreUsuario);
            this.splitContainer2.Size = new System.Drawing.Size(1229, 623);
            this.splitContainer2.SplitterDistance = 431;
            this.splitContainer2.TabIndex = 1;
            // 
            // DgvUsuarios
            // 
            this.DgvUsuarios.AllowUserToAddRows = false;
            this.DgvUsuarios.AllowUserToDeleteRows = false;
            this.DgvUsuarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.activo});
            this.DgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvUsuarios.Location = new System.Drawing.Point(0, 0);
            this.DgvUsuarios.MultiSelect = false;
            this.DgvUsuarios.Name = "DgvUsuarios";
            this.DgvUsuarios.ReadOnly = true;
            this.DgvUsuarios.RowHeadersVisible = false;
            this.DgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvUsuarios.Size = new System.Drawing.Size(431, 623);
            this.DgvUsuarios.TabIndex = 0;
            this.DgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUsuarios_CellClick);
            this.DgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUsuarios_CellContentClick);
            // 
            // id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 230;
            // 
            // activo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.activo.DefaultCellStyle = dataGridViewCellStyle3;
            this.activo.HeaderText = "Activo";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            // 
            // DatosUsuario
            // 
            this.DatosUsuario.Controls.Add(this.LblInfo);
            this.DatosUsuario.Controls.Add(this.CmbRol);
            this.DatosUsuario.Controls.Add(this.label7);
            this.DatosUsuario.Controls.Add(this.TxtNombre);
            this.DatosUsuario.Controls.Add(this.TxtTelefono);
            this.DatosUsuario.Controls.Add(this.TxtPaterno);
            this.DatosUsuario.Controls.Add(this.ChkUsuarioActivo);
            this.DatosUsuario.Controls.Add(this.TxtMaterno);
            this.DatosUsuario.Controls.Add(this.label6);
            this.DatosUsuario.Controls.Add(this.label1);
            this.DatosUsuario.Controls.Add(this.label2);
            this.DatosUsuario.Controls.Add(this.BtnCambiarPassword);
            this.DatosUsuario.Controls.Add(this.label3);
            this.DatosUsuario.Controls.Add(this.TxtCorreo);
            this.DatosUsuario.Controls.Add(this.label4);
            this.DatosUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatosUsuario.Location = new System.Drawing.Point(0, 23);
            this.DatosUsuario.Name = "DatosUsuario";
            this.DatosUsuario.Size = new System.Drawing.Size(794, 600);
            this.DatosUsuario.TabIndex = 27;
            this.DatosUsuario.TabStop = false;
            // 
            // LblInfo
            // 
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.ForeColor = System.Drawing.Color.Red;
            this.LblInfo.Location = new System.Drawing.Point(21, 273);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(677, 37);
            this.LblInfo.TabIndex = 27;
            this.LblInfo.Text = "Info";
            // 
            // CmbRol
            // 
            this.CmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRol.Enabled = false;
            this.CmbRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRol.FormattingEnabled = true;
            this.CmbRol.Location = new System.Drawing.Point(24, 172);
            this.CmbRol.Name = "CmbRol";
            this.CmbRol.Size = new System.Drawing.Size(448, 32);
            this.CmbRol.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(475, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Telefono";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(24, 51);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ReadOnly = true;
            this.TxtNombre.Size = new System.Drawing.Size(220, 29);
            this.TxtNombre.TabIndex = 11;
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelefono.Location = new System.Drawing.Point(478, 107);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.ReadOnly = true;
            this.TxtTelefono.Size = new System.Drawing.Size(220, 29);
            this.TxtTelefono.TabIndex = 25;
            // 
            // TxtPaterno
            // 
            this.TxtPaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaterno.Location = new System.Drawing.Point(252, 51);
            this.TxtPaterno.Name = "TxtPaterno";
            this.TxtPaterno.ReadOnly = true;
            this.TxtPaterno.Size = new System.Drawing.Size(220, 29);
            this.TxtPaterno.TabIndex = 12;
            // 
            // ChkUsuarioActivo
            // 
            this.ChkUsuarioActivo.AutoSize = true;
            this.ChkUsuarioActivo.Enabled = false;
            this.ChkUsuarioActivo.Location = new System.Drawing.Point(24, 230);
            this.ChkUsuarioActivo.Name = "ChkUsuarioActivo";
            this.ChkUsuarioActivo.Size = new System.Drawing.Size(94, 17);
            this.ChkUsuarioActivo.TabIndex = 24;
            this.ChkUsuarioActivo.Text = "Usuario activo";
            this.ChkUsuarioActivo.UseVisualStyleBackColor = true;
            this.ChkUsuarioActivo.CheckedChanged += new System.EventHandler(this.ChkUsuarioActivo_CheckedChanged);
            // 
            // TxtMaterno
            // 
            this.TxtMaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaterno.Location = new System.Drawing.Point(478, 51);
            this.TxtMaterno.Name = "TxtMaterno";
            this.TxtMaterno.ReadOnly = true;
            this.TxtMaterno.Size = new System.Drawing.Size(220, 29);
            this.TxtMaterno.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Rol *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Apellido paterno *";
            // 
            // BtnCambiarPassword
            // 
            this.BtnCambiarPassword.Location = new System.Drawing.Point(351, 223);
            this.BtnCambiarPassword.Name = "BtnCambiarPassword";
            this.BtnCambiarPassword.Size = new System.Drawing.Size(121, 29);
            this.BtnCambiarPassword.TabIndex = 21;
            this.BtnCambiarPassword.Text = "Asignar contraseña";
            this.BtnCambiarPassword.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Apellido materno";
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreo.Location = new System.Drawing.Point(24, 107);
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.ReadOnly = true;
            this.TxtCorreo.Size = new System.Drawing.Size(448, 29);
            this.TxtCorreo.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Correo *";
            // 
            // LblNombreUsuario
            // 
            this.LblNombreUsuario.BackColor = System.Drawing.Color.Black;
            this.LblNombreUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.LblNombreUsuario.Location = new System.Drawing.Point(0, 0);
            this.LblNombreUsuario.Name = "LblNombreUsuario";
            this.LblNombreUsuario.Size = new System.Drawing.Size(794, 23);
            this.LblNombreUsuario.TabIndex = 10;
            this.LblNombreUsuario.Text = "SELECCIONA UN USUARIO";
            this.LblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmAdministrarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 703);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblNumeroPlano);
            this.Name = "FrmAdministrarUsuarios";
            this.Text = "Administrar usuarios";
            this.Load += new System.EventHandler(this.FrmAdministrarUsuarios_Load);
            this.Shown += new System.EventHandler(this.FrmAdministrarUsuarios_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).EndInit();
            this.DatosUsuario.ResumeLayout(false);
            this.DatosUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblNumeroPlano;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BtnNuevoUsuario;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnEditarUsuario;
        private System.Windows.Forms.CheckBox ChkMostrarInactivos;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView DgvUsuarios;
        private System.Windows.Forms.Label LblNombreUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtMaterno;
        private System.Windows.Forms.TextBox TxtPaterno;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCorreo;
        private System.Windows.Forms.Button BtnCambiarPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbRol;
        private System.Windows.Forms.CheckBox ChkUsuarioActivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.GroupBox DatosUsuario;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn activo;
    }
}
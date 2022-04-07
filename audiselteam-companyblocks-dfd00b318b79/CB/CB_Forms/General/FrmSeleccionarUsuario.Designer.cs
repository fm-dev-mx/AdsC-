namespace CB
{
    partial class FrmSeleccionarUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFiltro = new System.Windows.Forms.TextBox();
            this.DgvUsuarios = new System.Windows.Forms.DataGridView();
            this.seleccionar_usuario = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(706, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(119, 74);
            this.BtnCancelar.TabIndex = 21;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnSeleccionar);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.TxtFiltro);
            this.splitContainer1.Panel1.Controls.Add(this.BtnCancelar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvUsuarios);
            this.splitContainer1.Size = new System.Drawing.Size(825, 464);
            this.splitContainer1.SplitterDistance = 74;
            this.splitContainer1.TabIndex = 13;
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSeleccionar.Location = new System.Drawing.Point(568, 0);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(138, 74);
            this.BtnSeleccionar.TabIndex = 24;
            this.BtnSeleccionar.Text = "     Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Buscar:";
            // 
            // TxtFiltro
            // 
            this.TxtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFiltro.Location = new System.Drawing.Point(99, 21);
            this.TxtFiltro.Name = "TxtFiltro";
            this.TxtFiltro.Size = new System.Drawing.Size(278, 29);
            this.TxtFiltro.TabIndex = 22;
            this.TxtFiltro.TextChanged += new System.EventHandler(this.TxtFiltro_TextChanged);
            // 
            // DgvUsuarios
            // 
            this.DgvUsuarios.AllowUserToAddRows = false;
            this.DgvUsuarios.AllowUserToDeleteRows = false;
            this.DgvUsuarios.AllowUserToResizeRows = false;
            this.DgvUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccionar_usuario,
            this.id,
            this.nombre,
            this.paterno,
            this.materno,
            this.rol});
            this.DgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvUsuarios.Location = new System.Drawing.Point(0, 0);
            this.DgvUsuarios.Name = "DgvUsuarios";
            this.DgvUsuarios.RowHeadersVisible = false;
            this.DgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvUsuarios.Size = new System.Drawing.Size(825, 386);
            this.DgvUsuarios.TabIndex = 0;
            this.DgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUsuarios_CellClick);
            this.DgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUsuarios_CellDoubleClick);
            // 
            // seleccionar_usuario
            // 
            this.seleccionar_usuario.FalseValue = "0";
            this.seleccionar_usuario.HeaderText = "";
            this.seleccionar_usuario.Name = "seleccionar_usuario";
            this.seleccionar_usuario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccionar_usuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seleccionar_usuario.TrueValue = "1";
            this.seleccionar_usuario.Width = 30;
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Width = 70;
            // 
            // nombre
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle2;
            this.nombre.HeaderText = "Nombre(s)";
            this.nombre.Name = "nombre";
            this.nombre.Width = 180;
            // 
            // paterno
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.paterno.DefaultCellStyle = dataGridViewCellStyle3;
            this.paterno.HeaderText = "Apellido paterno";
            this.paterno.Name = "paterno";
            this.paterno.Width = 180;
            // 
            // materno
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.materno.DefaultCellStyle = dataGridViewCellStyle4;
            this.materno.HeaderText = "Apellido materno";
            this.materno.Name = "materno";
            this.materno.Width = 180;
            // 
            // rol
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.rol.DefaultCellStyle = dataGridViewCellStyle5;
            this.rol.HeaderText = "Rol";
            this.rol.Name = "rol";
            this.rol.Width = 210;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(825, 23);
            this.LblTitulo.TabIndex = 12;
            this.LblTitulo.Text = "SELECCIONAR USUARIO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmSeleccionarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(825, 487);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeleccionarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSeleccionarUsuario";
            this.Load += new System.EventHandler(this.FrmSeleccionarUsuario_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridView DgvUsuarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFiltro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionar_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn paterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn materno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rol;
        private System.Windows.Forms.Button BtnSeleccionar;
    }
}
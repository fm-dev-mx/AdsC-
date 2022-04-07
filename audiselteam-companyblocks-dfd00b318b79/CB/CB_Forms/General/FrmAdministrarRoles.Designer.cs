namespace CB
{
    partial class FrmAdministrarRoles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblNumeroPlano = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnNuevoRol = new System.Windows.Forms.Button();
            this.BtnEliminarRol = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbRoles = new System.Windows.Forms.ComboBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrivilegios = new System.Windows.Forms.TabPage();
            this.DgvPrivilegios = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabHabilidades = new System.Windows.Forms.TabPage();
            this.DgvHabilidades = new System.Windows.Forms.DataGridView();
            this.ID_HABILIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATEGORIA_HABILIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HABILIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION_HABILIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIVEL_HABILIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAsignarPrivilegio = new System.Windows.Forms.Button();
            this.BtnQuitarPrivilegio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPrivilegios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrivilegios)).BeginInit();
            this.tabHabilidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidades)).BeginInit();
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
            this.LblNumeroPlano.Size = new System.Drawing.Size(1172, 23);
            this.LblNumeroPlano.TabIndex = 9;
            this.LblNumeroPlano.Text = "ADMINISTRAR ROLES";
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
            this.splitContainer1.Panel1.Controls.Add(this.BtnNuevoRol);
            this.splitContainer1.Panel1.Controls.Add(this.BtnEliminarRol);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.CmbRoles);
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(1172, 578);
            this.splitContainer1.SplitterDistance = 51;
            this.splitContainer1.TabIndex = 10;
            // 
            // BtnNuevoRol
            // 
            this.BtnNuevoRol.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNuevoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevoRol.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.BtnNuevoRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevoRol.Location = new System.Drawing.Point(796, 0);
            this.BtnNuevoRol.Name = "BtnNuevoRol";
            this.BtnNuevoRol.Size = new System.Drawing.Size(125, 51);
            this.BtnNuevoRol.TabIndex = 23;
            this.BtnNuevoRol.Text = "Nuevo rol";
            this.BtnNuevoRol.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNuevoRol.UseCompatibleTextRendering = true;
            this.BtnNuevoRol.UseMnemonic = false;
            this.BtnNuevoRol.UseVisualStyleBackColor = true;
            this.BtnNuevoRol.Click += new System.EventHandler(this.BtnNuevoRol_Click);
            // 
            // BtnEliminarRol
            // 
            this.BtnEliminarRol.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnEliminarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarRol.Image = global::CB_Base.Properties.Resources.close;
            this.BtnEliminarRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminarRol.Location = new System.Drawing.Point(921, 0);
            this.BtnEliminarRol.Name = "BtnEliminarRol";
            this.BtnEliminarRol.Size = new System.Drawing.Size(132, 51);
            this.BtnEliminarRol.TabIndex = 24;
            this.BtnEliminarRol.Text = "Eliminar rol";
            this.BtnEliminarRol.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEliminarRol.UseCompatibleTextRendering = true;
            this.BtnEliminarRol.UseVisualStyleBackColor = true;
            this.BtnEliminarRol.Click += new System.EventHandler(this.BtnEliminarRol_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Rol:";
            // 
            // CmbRoles
            // 
            this.CmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRoles.FormattingEnabled = true;
            this.CmbRoles.Items.AddRange(new object[] {
            "PENDIENTE",
            "EN COTIZACION",
            "EN FABRICACION",
            "PENDIENTE DE TRATAMIENTO",
            "EN TRATAMIENTO",
            "TERMINADO",
            "ENTREGADO"});
            this.CmbRoles.Location = new System.Drawing.Point(12, 18);
            this.CmbRoles.Name = "CmbRoles";
            this.CmbRoles.Size = new System.Drawing.Size(386, 32);
            this.CmbRoles.TabIndex = 21;
            this.CmbRoles.SelectedIndexChanged += new System.EventHandler(this.CmbRoles_SelectedIndexChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.close;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1053, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(119, 51);
            this.BtnSalir.TabIndex = 18;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 20);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.BtnQuitarPrivilegio);
            this.splitContainer2.Panel2.Controls.Add(this.BtnAsignarPrivilegio);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.splitContainer2.Size = new System.Drawing.Size(1172, 503);
            this.splitContainer2.SplitterDistance = 1016;
            this.splitContainer2.TabIndex = 21;
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.tabControl1.Controls.Add(this.tabPrivilegios);
            this.tabControl1.Controls.Add(this.tabHabilidades);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1016, 503);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPrivilegios
            // 
            this.tabPrivilegios.Controls.Add(this.DgvPrivilegios);
            this.tabPrivilegios.Location = new System.Drawing.Point(4, 22);
            this.tabPrivilegios.Name = "tabPrivilegios";
            this.tabPrivilegios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrivilegios.Size = new System.Drawing.Size(1008, 477);
            this.tabPrivilegios.TabIndex = 0;
            this.tabPrivilegios.Text = "Pivilegios";
            this.tabPrivilegios.UseVisualStyleBackColor = true;
            // 
            // DgvPrivilegios
            // 
            this.DgvPrivilegios.AllowUserToAddRows = false;
            this.DgvPrivilegios.AllowUserToDeleteRows = false;
            this.DgvPrivilegios.AllowUserToResizeColumns = false;
            this.DgvPrivilegios.AllowUserToResizeRows = false;
            this.DgvPrivilegios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPrivilegios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPrivilegios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPrivilegios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.categoria,
            this.Column1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPrivilegios.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvPrivilegios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPrivilegios.Location = new System.Drawing.Point(3, 3);
            this.DgvPrivilegios.MultiSelect = false;
            this.DgvPrivilegios.Name = "DgvPrivilegios";
            this.DgvPrivilegios.ReadOnly = true;
            this.DgvPrivilegios.RowHeadersVisible = false;
            this.DgvPrivilegios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPrivilegios.Size = new System.Drawing.Size(1002, 471);
            this.DgvPrivilegios.TabIndex = 21;
            this.DgvPrivilegios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPrivilegios_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // categoria
            // 
            this.categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoria.DefaultCellStyle = dataGridViewCellStyle2;
            this.categoria.HeaderText = "Categoría";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "Privilegio";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // tabHabilidades
            // 
            this.tabHabilidades.Controls.Add(this.DgvHabilidades);
            this.tabHabilidades.Location = new System.Drawing.Point(4, 22);
            this.tabHabilidades.Name = "tabHabilidades";
            this.tabHabilidades.Padding = new System.Windows.Forms.Padding(3);
            this.tabHabilidades.Size = new System.Drawing.Size(964, 477);
            this.tabHabilidades.TabIndex = 1;
            this.tabHabilidades.Text = "Habilidades";
            this.tabHabilidades.UseVisualStyleBackColor = true;
            // 
            // DgvHabilidades
            // 
            this.DgvHabilidades.AllowUserToAddRows = false;
            this.DgvHabilidades.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvHabilidades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvHabilidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvHabilidades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvHabilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHabilidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_HABILIDAD,
            this.CATEGORIA_HABILIDAD,
            this.HABILIDAD,
            this.DESCRIPCION_HABILIDAD,
            this.NIVEL_HABILIDAD});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvHabilidades.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvHabilidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHabilidades.Location = new System.Drawing.Point(3, 3);
            this.DgvHabilidades.Name = "DgvHabilidades";
            this.DgvHabilidades.RowHeadersVisible = false;
            this.DgvHabilidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHabilidades.Size = new System.Drawing.Size(958, 471);
            this.DgvHabilidades.TabIndex = 0;
            this.DgvHabilidades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPrivilegios_CellClick);
            // 
            // ID_HABILIDAD
            // 
            this.ID_HABILIDAD.HeaderText = "Id";
            this.ID_HABILIDAD.Name = "ID_HABILIDAD";
            this.ID_HABILIDAD.Visible = false;
            // 
            // CATEGORIA_HABILIDAD
            // 
            this.CATEGORIA_HABILIDAD.FillWeight = 150F;
            this.CATEGORIA_HABILIDAD.HeaderText = "Categoria";
            this.CATEGORIA_HABILIDAD.Name = "CATEGORIA_HABILIDAD";
            // 
            // HABILIDAD
            // 
            this.HABILIDAD.HeaderText = "habilidad";
            this.HABILIDAD.Name = "HABILIDAD";
            // 
            // DESCRIPCION_HABILIDAD
            // 
            this.DESCRIPCION_HABILIDAD.HeaderText = "Descripcion";
            this.DESCRIPCION_HABILIDAD.Name = "DESCRIPCION_HABILIDAD";
            // 
            // NIVEL_HABILIDAD
            // 
            this.NIVEL_HABILIDAD.HeaderText = "Nivel";
            this.NIVEL_HABILIDAD.Name = "NIVEL_HABILIDAD";
            // 
            // BtnAsignarPrivilegio
            // 
            this.BtnAsignarPrivilegio.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAsignarPrivilegio.Enabled = false;
            this.BtnAsignarPrivilegio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsignarPrivilegio.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.BtnAsignarPrivilegio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAsignarPrivilegio.Location = new System.Drawing.Point(0, 40);
            this.BtnAsignarPrivilegio.Name = "BtnAsignarPrivilegio";
            this.BtnAsignarPrivilegio.Size = new System.Drawing.Size(152, 53);
            this.BtnAsignarPrivilegio.TabIndex = 23;
            this.BtnAsignarPrivilegio.Text = "Asignar";
            this.BtnAsignarPrivilegio.UseVisualStyleBackColor = true;
            this.BtnAsignarPrivilegio.Click += new System.EventHandler(this.BtnAsignarPrivilegio_Click);
            // 
            // BtnQuitarPrivilegio
            // 
            this.BtnQuitarPrivilegio.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnQuitarPrivilegio.Enabled = false;
            this.BtnQuitarPrivilegio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuitarPrivilegio.Image = global::CB_Base.Properties.Resources.close;
            this.BtnQuitarPrivilegio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuitarPrivilegio.Location = new System.Drawing.Point(0, 93);
            this.BtnQuitarPrivilegio.Name = "BtnQuitarPrivilegio";
            this.BtnQuitarPrivilegio.Size = new System.Drawing.Size(152, 53);
            this.BtnQuitarPrivilegio.TabIndex = 24;
            this.BtnQuitarPrivilegio.Text = "Quitar";
            this.BtnQuitarPrivilegio.UseVisualStyleBackColor = true;
            this.BtnQuitarPrivilegio.Click += new System.EventHandler(this.BtnQuitarPrivilegio_Click);
            // 
            // FrmAdministrarRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 601);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblNumeroPlano);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmAdministrarRoles";
            this.Text = "Administrar roles";
            this.Load += new System.EventHandler(this.FrmAdministrarRoles_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPrivilegios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrivilegios)).EndInit();
            this.tabHabilidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblNumeroPlano;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbRoles;
        private System.Windows.Forms.Button BtnNuevoRol;
        private System.Windows.Forms.Button BtnEliminarRol;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPrivilegios;
        private System.Windows.Forms.DataGridView DgvPrivilegios;
        private System.Windows.Forms.TabPage tabHabilidades;
        private System.Windows.Forms.Button BtnAsignarPrivilegio;
        private System.Windows.Forms.DataGridView DgvHabilidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_HABILIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORIA_HABILIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HABILIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION_HABILIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIVEL_HABILIDAD;
        private System.Windows.Forms.Button BtnQuitarPrivilegio;
    }
}
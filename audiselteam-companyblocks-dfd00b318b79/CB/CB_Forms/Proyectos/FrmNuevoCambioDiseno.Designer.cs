namespace CB
{
    partial class FrmNuevoCambioDiseno
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbMotivo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtAlcance = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.DgvModulosInvolucrados = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbNivelRiesgo = new System.Windows.Forms.ComboBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nombre_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModulosInvolucrados)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(804, 23);
            this.LblTitulo.TabIndex = 10;
            this.LblTitulo.Text = "NUEVO CAMBIO DE DISEÑO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Tipo de cambio";
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Items.AddRange(new object[] {
            "MECANICO"});
            this.CmbTipo.Location = new System.Drawing.Point(495, 53);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(297, 32);
            this.CmbTipo.TabIndex = 37;
            this.CmbTipo.SelectedIndexChanged += new System.EventHandler(this.CmbTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Motivo del cambio:";
            // 
            // CmbMotivo
            // 
            this.CmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMotivo.FormattingEnabled = true;
            this.CmbMotivo.Items.AddRange(new object[] {
            "CAMBIO DEL CLIENTE",
            "ERROR DE DISEÑO"});
            this.CmbMotivo.Location = new System.Drawing.Point(12, 53);
            this.CmbMotivo.Name = "CmbMotivo";
            this.CmbMotivo.Size = new System.Drawing.Size(318, 32);
            this.CmbMotivo.TabIndex = 39;
            this.CmbMotivo.SelectedIndexChanged += new System.EventHandler(this.CmbMotivo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Alcance o análisis del cambio:";
            // 
            // TxtAlcance
            // 
            this.TxtAlcance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtAlcance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAlcance.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAlcance.Location = new System.Drawing.Point(12, 114);
            this.TxtAlcance.Multiline = true;
            this.TxtAlcance.Name = "TxtAlcance";
            this.TxtAlcance.Size = new System.Drawing.Size(476, 263);
            this.TxtAlcance.TabIndex = 42;
            this.TxtAlcance.TextChanged += new System.EventHandler(this.TxtAlcance_TextChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(495, 392);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(139, 40);
            this.BtnCancelar.TabIndex = 75;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Enabled = false;
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(650, 392);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(142, 40);
            this.BtnRegistrar.TabIndex = 76;
            this.BtnRegistrar.Text = "     Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // DgvModulosInvolucrados
            // 
            this.DgvModulosInvolucrados.AllowUserToAddRows = false;
            this.DgvModulosInvolucrados.AllowUserToResizeRows = false;
            this.DgvModulosInvolucrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvModulosInvolucrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.seleccion,
            this.nombre_modulo});
            this.DgvModulosInvolucrados.Location = new System.Drawing.Point(495, 114);
            this.DgvModulosInvolucrados.Name = "DgvModulosInvolucrados";
            this.DgvModulosInvolucrados.RowHeadersVisible = false;
            this.DgvModulosInvolucrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvModulosInvolucrados.Size = new System.Drawing.Size(297, 263);
            this.DgvModulosInvolucrados.TabIndex = 77;
            this.DgvModulosInvolucrados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvModulosInvolucrados_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 78;
            this.label4.Text = "Módulos afectados:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "Nivel de riesgo:";
            // 
            // CmbNivelRiesgo
            // 
            this.CmbNivelRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNivelRiesgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbNivelRiesgo.FormattingEnabled = true;
            this.CmbNivelRiesgo.Items.AddRange(new object[] {
            "MUY BAJO",
            "BAJO",
            "REGULAR",
            "ALTO",
            "MUY ALTO"});
            this.CmbNivelRiesgo.Location = new System.Drawing.Point(336, 53);
            this.CmbNivelRiesgo.Name = "CmbNivelRiesgo";
            this.CmbNivelRiesgo.Size = new System.Drawing.Size(152, 32);
            this.CmbNivelRiesgo.TabIndex = 80;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // seleccion
            // 
            this.seleccion.HeaderText = "";
            this.seleccion.Name = "seleccion";
            this.seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seleccion.Width = 20;
            // 
            // nombre_modulo
            // 
            this.nombre_modulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_modulo.HeaderText = "";
            this.nombre_modulo.Name = "nombre_modulo";
            this.nombre_modulo.ReadOnly = true;
            // 
            // FrmNuevoCambioDiseno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 444);
            this.Controls.Add(this.CmbNivelRiesgo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DgvModulosInvolucrados);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.TxtAlcance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbMotivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoCambioDiseno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo cambio de diseño";
            this.Load += new System.EventHandler(this.FrmNuevoCambioDiseno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvModulosInvolucrados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbMotivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtAlcance;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.DataGridView DgvModulosInvolucrados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbNivelRiesgo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_modulo;
    }
}
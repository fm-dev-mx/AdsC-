namespace CB
{
    partial class FrmNuevaMetaProyecto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvEntregables = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbCoordinador = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtFechaPromesa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbResponsable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFechaSolicitud = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbTipoEntregable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProceso = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.entregable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEntregables)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvEntregables
            // 
            this.DgvEntregables.AllowUserToAddRows = false;
            this.DgvEntregables.AllowUserToResizeRows = false;
            this.DgvEntregables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEntregables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.check,
            this.entregable});
            this.DgvEntregables.Location = new System.Drawing.Point(10, 263);
            this.DgvEntregables.MultiSelect = false;
            this.DgvEntregables.Name = "DgvEntregables";
            this.DgvEntregables.RowHeadersVisible = false;
            this.DgvEntregables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEntregables.Size = new System.Drawing.Size(490, 204);
            this.DgvEntregables.TabIndex = 39;
            this.DgvEntregables.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEntregables_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Entregable(s):";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(10, 473);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(141, 51);
            this.BtnCancelar.TabIndex = 37;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Enabled = false;
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(360, 473);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(141, 51);
            this.BtnRegistrar.TabIndex = 36;
            this.BtnRegistrar.Text = "      Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "¿Quién debe coordinar las operaciones?";
            // 
            // CmbCoordinador
            // 
            this.CmbCoordinador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCoordinador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCoordinador.FormattingEnabled = true;
            this.CmbCoordinador.Items.AddRange(new object[] {
            "DIAS NATURALES",
            "DIAS HABILES",
            "SEMANAS"});
            this.CmbCoordinador.Location = new System.Drawing.Point(10, 208);
            this.CmbCoordinador.Name = "CmbCoordinador";
            this.CmbCoordinador.Size = new System.Drawing.Size(491, 32);
            this.CmbCoordinador.TabIndex = 34;
            this.CmbCoordinador.SelectedIndexChanged += new System.EventHandler(this.CmbCoordinador_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "¿Quién es responsable del proceso?";
            // 
            // TxtFechaPromesa
            // 
            this.TxtFechaPromesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaPromesa.Location = new System.Drawing.Point(312, 102);
            this.TxtFechaPromesa.Name = "TxtFechaPromesa";
            this.TxtFechaPromesa.ReadOnly = true;
            this.TxtFechaPromesa.Size = new System.Drawing.Size(189, 29);
            this.TxtFechaPromesa.TabIndex = 32;
            this.TxtFechaPromesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Fecha de solicitud:";
            // 
            // CmbResponsable
            // 
            this.CmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbResponsable.FormattingEnabled = true;
            this.CmbResponsable.Items.AddRange(new object[] {
            "DIAS NATURALES",
            "DIAS HABILES",
            "SEMANAS"});
            this.CmbResponsable.Location = new System.Drawing.Point(10, 155);
            this.CmbResponsable.Name = "CmbResponsable";
            this.CmbResponsable.Size = new System.Drawing.Size(491, 32);
            this.CmbResponsable.TabIndex = 30;
            this.CmbResponsable.SelectedIndexChanged += new System.EventHandler(this.CmbResponsable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Tipo de entregable:";
            // 
            // TxtFechaSolicitud
            // 
            this.TxtFechaSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaSolicitud.Location = new System.Drawing.Point(312, 48);
            this.TxtFechaSolicitud.Name = "TxtFechaSolicitud";
            this.TxtFechaSolicitud.ReadOnly = true;
            this.TxtFechaSolicitud.Size = new System.Drawing.Size(189, 29);
            this.TxtFechaSolicitud.TabIndex = 28;
            this.TxtFechaSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Fecha promesa:";
            // 
            // CmbTipoEntregable
            // 
            this.CmbTipoEntregable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoEntregable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoEntregable.FormattingEnabled = true;
            this.CmbTipoEntregable.Items.AddRange(new object[] {
            "DISENO FINAL",
            "DISENO CONCEPTUAL",
            "MODULO FABRICADO",
            "PIEZA FABRICADA"});
            this.CmbTipoEntregable.Location = new System.Drawing.Point(10, 102);
            this.CmbTipoEntregable.Name = "CmbTipoEntregable";
            this.CmbTipoEntregable.Size = new System.Drawing.Size(296, 32);
            this.CmbTipoEntregable.TabIndex = 26;
            this.CmbTipoEntregable.SelectedIndexChanged += new System.EventHandler(this.CmbTipoEntregable_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Proceso:";
            // 
            // TxtProceso
            // 
            this.TxtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProceso.Location = new System.Drawing.Point(10, 48);
            this.TxtProceso.Name = "TxtProceso";
            this.TxtProceso.ReadOnly = true;
            this.TxtProceso.Size = new System.Drawing.Size(296, 29);
            this.TxtProceso.TabIndex = 16;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(512, 23);
            this.LblTitulo.TabIndex = 15;
            this.LblTitulo.Text = "NUEVA META";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // id
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle5;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 70;
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Width = 25;
            // 
            // entregable
            // 
            this.entregable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.entregable.HeaderText = "Entregable";
            this.entregable.Name = "entregable";
            this.entregable.ReadOnly = true;
            // 
            // FrmNuevaMetaProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 536);
            this.Controls.Add(this.DgvEntregables);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbCoordinador);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtFechaPromesa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbResponsable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtFechaSolicitud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbTipoEntregable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtProceso);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaMetaProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva meta";
            this.Load += new System.EventHandler(this.FrmNuevaMetaProyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEntregables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtProceso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbTipoEntregable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFechaSolicitud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbResponsable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFechaPromesa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbCoordinador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView DgvEntregables;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn entregable;
    }
}
namespace CB
{
    partial class FrmProgramarCapacitacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbPlanCapacitacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbResponsable = new System.Windows.Forms.ComboBox();
            this.DgvParticipantes = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuAgregarParticipante = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.DtpHora = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtDetalles = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvParticipantes)).BeginInit();
            this.MenuAgregarParticipante.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(893, 23);
            this.LblTitulo.TabIndex = 11;
            this.LblTitulo.Text = "PROGRAMAR CAPACITACION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // DtpFecha
            // 
            this.DtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecha.Location = new System.Drawing.Point(10, 49);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(432, 29);
            this.DtpFecha.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Fecha:";
            // 
            // CmbPlanCapacitacion
            // 
            this.CmbPlanCapacitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPlanCapacitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPlanCapacitacion.FormattingEnabled = true;
            this.CmbPlanCapacitacion.Location = new System.Drawing.Point(10, 206);
            this.CmbPlanCapacitacion.Name = "CmbPlanCapacitacion";
            this.CmbPlanCapacitacion.Size = new System.Drawing.Size(432, 32);
            this.CmbPlanCapacitacion.TabIndex = 14;
            this.CmbPlanCapacitacion.SelectedIndexChanged += new System.EventHandler(this.CmbPlanCapacitacion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Plan de capacitación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Responsable:";
            // 
            // CmbResponsable
            // 
            this.CmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbResponsable.FormattingEnabled = true;
            this.CmbResponsable.Location = new System.Drawing.Point(10, 379);
            this.CmbResponsable.Name = "CmbResponsable";
            this.CmbResponsable.Size = new System.Drawing.Size(432, 32);
            this.CmbResponsable.TabIndex = 17;
            // 
            // DgvParticipantes
            // 
            this.DgvParticipantes.AllowUserToAddRows = false;
            this.DgvParticipantes.AllowUserToDeleteRows = false;
            this.DgvParticipantes.AllowUserToResizeColumns = false;
            this.DgvParticipantes.AllowUserToResizeRows = false;
            this.DgvParticipantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvParticipantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.id_usuario,
            this.nombre});
            this.DgvParticipantes.ContextMenuStrip = this.MenuAgregarParticipante;
            this.DgvParticipantes.Location = new System.Drawing.Point(451, 51);
            this.DgvParticipantes.Name = "DgvParticipantes";
            this.DgvParticipantes.RowHeadersVisible = false;
            this.DgvParticipantes.Size = new System.Drawing.Size(430, 360);
            this.DgvParticipantes.TabIndex = 18;
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.MinimumWidth = 30;
            this.check.Name = "check";
            this.check.Width = 30;
            // 
            // id_usuario
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id_usuario.DefaultCellStyle = dataGridViewCellStyle1;
            this.id_usuario.HeaderText = "Id";
            this.id_usuario.MinimumWidth = 50;
            this.id_usuario.Name = "id_usuario";
            this.id_usuario.ReadOnly = true;
            this.id_usuario.Width = 50;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // MenuAgregarParticipante
            // 
            this.MenuAgregarParticipante.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.MenuAgregarParticipante.Name = "MenuAgregarParticipante";
            this.MenuAgregarParticipante.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Participantes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tipo:";
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Items.AddRange(new object[] {
            "INTERNA",
            "EXTERNA"});
            this.CmbTipo.Location = new System.Drawing.Point(10, 151);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(432, 32);
            this.CmbTipo.TabIndex = 20;
            this.CmbTipo.SelectedIndexChanged += new System.EventHandler(this.CmbTipo_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 60);
            this.panel1.TabIndex = 22;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(593, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(150, 60);
            this.BtnCancelar.TabIndex = 115;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(743, 0);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(150, 60);
            this.BtnAceptar.TabIndex = 114;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Hora:";
            // 
            // DtpHora
            // 
            this.DtpHora.CustomFormat = "hh:mm tt";
            this.DtpHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpHora.ImeMode = System.Windows.Forms.ImeMode.On;
            this.DtpHora.Location = new System.Drawing.Point(10, 100);
            this.DtpHora.Name = "DtpHora";
            this.DtpHora.ShowUpDown = true;
            this.DtpHora.Size = new System.Drawing.Size(432, 29);
            this.DtpHora.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Detalles:";
            // 
            // TxtDetalles
            // 
            this.TxtDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDetalles.Location = new System.Drawing.Point(10, 259);
            this.TxtDetalles.Multiline = true;
            this.TxtDetalles.Name = "TxtDetalles";
            this.TxtDetalles.ReadOnly = true;
            this.TxtDetalles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDetalles.Size = new System.Drawing.Size(430, 93);
            this.TxtDetalles.TabIndex = 26;
            // 
            // FrmProgramarCapacitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 475);
            this.Controls.Add(this.TxtDetalles);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DtpHora);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DgvParticipantes);
            this.Controls.Add(this.CmbResponsable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbPlanCapacitacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProgramarCapacitacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProgramarCapacitacion";
            this.Load += new System.EventHandler(this.FrmProgramarCapacitacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvParticipantes)).EndInit();
            this.MenuAgregarParticipante.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbPlanCapacitacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbResponsable;
        private System.Windows.Forms.DataGridView DgvParticipantes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.ContextMenuStrip MenuAgregarParticipante;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtpHora;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtDetalles;
    }
}
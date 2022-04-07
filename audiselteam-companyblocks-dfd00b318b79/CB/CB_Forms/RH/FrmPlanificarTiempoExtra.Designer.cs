namespace CB
{
    partial class FrmPlanificarTiempoExtra
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblPlanosActividades = new System.Windows.Forms.Label();
            this.DgvActividades = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_requerido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtEquipo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDepartamento = new System.Windows.Forms.TextBox();
            this.TxtNombreSupervisor = new System.Windows.Forms.TextBox();
            this.DateTiempoExtra = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.NumHoras = new System.Windows.Forms.NumericUpDown();
            this.LblNivelCoordinador = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnPlanificar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtActividad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbEmpleado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoras)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(909, 23);
            this.LblTitulo.TabIndex = 11;
            this.LblTitulo.Text = "PLANIFICAR TIEMPO EXTRA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // LblPlanosActividades
            // 
            this.LblPlanosActividades.BackColor = System.Drawing.Color.Navy;
            this.LblPlanosActividades.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPlanosActividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPlanosActividades.ForeColor = System.Drawing.Color.White;
            this.LblPlanosActividades.Location = new System.Drawing.Point(0, 296);
            this.LblPlanosActividades.Name = "LblPlanosActividades";
            this.LblPlanosActividades.Size = new System.Drawing.Size(909, 21);
            this.LblPlanosActividades.TabIndex = 40;
            this.LblPlanosActividades.Text = "ACTIVIDADES PLANIFICADAS PARA LA FECHA SELECCIONADA (XX.YY HRS):";
            this.LblPlanosActividades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvActividades
            // 
            this.DgvActividades.AllowUserToAddRows = false;
            this.DgvActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvActividades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.actividad,
            this.tiempo_requerido,
            this.comentarios});
            this.DgvActividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvActividades.Location = new System.Drawing.Point(0, 317);
            this.DgvActividades.Name = "DgvActividades";
            this.DgvActividades.RowHeadersVisible = false;
            this.DgvActividades.Size = new System.Drawing.Size(909, 270);
            this.DgvActividades.TabIndex = 41;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // actividad
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.actividad.DefaultCellStyle = dataGridViewCellStyle1;
            this.actividad.HeaderText = "Actividad";
            this.actividad.Name = "actividad";
            this.actividad.Width = 300;
            // 
            // tiempo_requerido
            // 
            this.tiempo_requerido.HeaderText = "Tiempo requerido (hrs)";
            this.tiempo_requerido.Name = "tiempo_requerido";
            this.tiempo_requerido.Width = 70;
            // 
            // comentarios
            // 
            this.comentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.comentarios.HeaderText = "Comentarios";
            this.comentarios.Name = "comentarios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Equipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Nombre del supervisor:";
            // 
            // TxtEquipo
            // 
            this.TxtEquipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEquipo.Location = new System.Drawing.Point(11, 75);
            this.TxtEquipo.MaxLength = 30;
            this.TxtEquipo.Name = "TxtEquipo";
            this.TxtEquipo.ReadOnly = true;
            this.TxtEquipo.Size = new System.Drawing.Size(60, 29);
            this.TxtEquipo.TabIndex = 36;
            this.TxtEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Departamento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Nombre del empleado:";
            // 
            // TxtDepartamento
            // 
            this.TxtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDepartamento.Location = new System.Drawing.Point(11, 23);
            this.TxtDepartamento.MaxLength = 30;
            this.TxtDepartamento.Name = "TxtDepartamento";
            this.TxtDepartamento.ReadOnly = true;
            this.TxtDepartamento.Size = new System.Drawing.Size(414, 29);
            this.TxtDepartamento.TabIndex = 38;
            // 
            // TxtNombreSupervisor
            // 
            this.TxtNombreSupervisor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombreSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreSupervisor.Location = new System.Drawing.Point(436, 75);
            this.TxtNombreSupervisor.MaxLength = 30;
            this.TxtNombreSupervisor.Name = "TxtNombreSupervisor";
            this.TxtNombreSupervisor.ReadOnly = true;
            this.TxtNombreSupervisor.Size = new System.Drawing.Size(328, 29);
            this.TxtNombreSupervisor.TabIndex = 33;
            // 
            // DateTiempoExtra
            // 
            this.DateTiempoExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTiempoExtra.Location = new System.Drawing.Point(436, 186);
            this.DateTiempoExtra.Name = "DateTiempoExtra";
            this.DateTiempoExtra.Size = new System.Drawing.Size(323, 26);
            this.DateTiempoExtra.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(433, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Fecha del tiempo extra:";
            // 
            // NumHoras
            // 
            this.NumHoras.DecimalPlaces = 2;
            this.NumHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumHoras.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.NumHoras.Location = new System.Drawing.Point(436, 235);
            this.NumHoras.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NumHoras.Name = "NumHoras";
            this.NumHoras.Size = new System.Drawing.Size(87, 31);
            this.NumHoras.TabIndex = 124;
            this.NumHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumHoras.ValueChanged += new System.EventHandler(this.NumHoras_ValueChanged);
            // 
            // LblNivelCoordinador
            // 
            this.LblNivelCoordinador.AutoSize = true;
            this.LblNivelCoordinador.Location = new System.Drawing.Point(431, 219);
            this.LblNivelCoordinador.Name = "LblNivelCoordinador";
            this.LblNivelCoordinador.Size = new System.Drawing.Size(92, 13);
            this.LblNivelCoordinador.TabIndex = 125;
            this.LblNivelCoordinador.Text = "Tiempo requerido:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnSalir);
            this.panel3.Controls.Add(this.BtnPlanificar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(774, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(135, 273);
            this.panel3.TabIndex = 126;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 63);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 62);
            this.BtnSalir.TabIndex = 123;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnPlanificar
            // 
            this.BtnPlanificar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnPlanificar.Enabled = false;
            this.BtnPlanificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnPlanificar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnPlanificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPlanificar.Location = new System.Drawing.Point(0, 0);
            this.BtnPlanificar.Name = "BtnPlanificar";
            this.BtnPlanificar.Size = new System.Drawing.Size(135, 63);
            this.BtnPlanificar.TabIndex = 124;
            this.BtnPlanificar.Text = "       Planificar";
            this.BtnPlanificar.UseVisualStyleBackColor = true;
            this.BtnPlanificar.Click += new System.EventHandler(this.BtnPlanificar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "Actividad a realizar:";
            // 
            // TxtActividad
            // 
            this.TxtActividad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtActividad.Location = new System.Drawing.Point(11, 128);
            this.TxtActividad.MaxLength = 30;
            this.TxtActividad.Name = "TxtActividad";
            this.TxtActividad.ReadOnly = true;
            this.TxtActividad.Size = new System.Drawing.Size(748, 29);
            this.TxtActividad.TabIndex = 128;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 129;
            this.label7.Text = "Comentarios:";
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(11, 182);
            this.TxtComentarios.MaxLength = 0;
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(414, 84);
            this.TxtComentarios.TabIndex = 130;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.CmbEmpleado);
            this.panel1.Controls.Add(this.TxtComentarios);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TxtActividad);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.LblNivelCoordinador);
            this.panel1.Controls.Add(this.NumHoras);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.DateTiempoExtra);
            this.panel1.Controls.Add(this.TxtNombreSupervisor);
            this.panel1.Controls.Add(this.TxtDepartamento);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtEquipo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 273);
            this.panel1.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(529, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 25);
            this.label8.TabIndex = 132;
            this.label8.Text = "horas";
            // 
            // CmbEmpleado
            // 
            this.CmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEmpleado.FormattingEnabled = true;
            this.CmbEmpleado.Items.AddRange(new object[] {
            "SIN ENVIAR",
            "ENVIADO"});
            this.CmbEmpleado.Location = new System.Drawing.Point(77, 75);
            this.CmbEmpleado.Name = "CmbEmpleado";
            this.CmbEmpleado.Size = new System.Drawing.Size(348, 32);
            this.CmbEmpleado.TabIndex = 131;
            this.CmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.CmbEmpleado_SelectedIndexChanged);
            // 
            // FrmPlanificarTiempoExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 587);
            this.Controls.Add(this.DgvActividades);
            this.Controls.Add(this.LblPlanosActividades);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPlanificarTiempoExtra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planificar tiempo extra";
            this.Load += new System.EventHandler(this.FrmPlanificarTiempoExtra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvActividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoras)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblPlanosActividades;
        private System.Windows.Forms.DataGridView DgvActividades;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtEquipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDepartamento;
        private System.Windows.Forms.TextBox TxtNombreSupervisor;
        private System.Windows.Forms.DateTimePicker DateTiempoExtra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumHoras;
        private System.Windows.Forms.Label LblNivelCoordinador;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtActividad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnPlanificar;
        private System.Windows.Forms.ComboBox CmbEmpleado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn actividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_requerido;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
    }
}
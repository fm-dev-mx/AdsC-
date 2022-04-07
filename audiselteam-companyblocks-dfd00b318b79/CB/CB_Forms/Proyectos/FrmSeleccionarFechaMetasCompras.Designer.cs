namespace CB
{
    partial class FrmSeleccionarFechaMetasCompras
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
            this.LblMensaje = new System.Windows.Forms.Label();
            this.DtpFechaMeta = new System.Windows.Forms.DateTimePicker();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DgvEntregables = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entregable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbCoordinador = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbResponsable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFechaPromesa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFechaSolicitud = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProceso = new System.Windows.Forms.TextBox();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEntregables)).BeginInit();
            this.SuspendLayout();
            // 
            // LblMensaje
            // 
            this.LblMensaje.AutoSize = true;
            this.LblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMensaje.Location = new System.Drawing.Point(3, 27);
            this.LblMensaje.Name = "LblMensaje";
            this.LblMensaje.Size = new System.Drawing.Size(294, 13);
            this.LblMensaje.TabIndex = 0;
            this.LblMensaje.Text = "Es necesario colocar una meta de compra para la requisición";
            // 
            // DtpFechaMeta
            // 
            this.DtpFechaMeta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.DtpFechaMeta.Location = new System.Drawing.Point(4, 125);
            this.DtpFechaMeta.Name = "DtpFechaMeta";
            this.DtpFechaMeta.Size = new System.Drawing.Size(298, 27);
            this.DtpFechaMeta.TabIndex = 1;
            this.DtpFechaMeta.ValueChanged += new System.EventHandler(this.DtpFechaMeta_ValueChanged);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(333, 415);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(172, 67);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(161, 415);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(172, 67);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.audiselTituloForm1);
            this.panel1.Controls.Add(this.DgvEntregables);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CmbCoordinador);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CmbResponsable);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtFechaPromesa);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtFechaSolicitud);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtProceso);
            this.panel1.Controls.Add(this.LblMensaje);
            this.panel1.Controls.Add(this.DtpFechaMeta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 415);
            this.panel1.TabIndex = 4;
            // 
            // DgvEntregables
            // 
            this.DgvEntregables.AllowUserToAddRows = false;
            this.DgvEntregables.AllowUserToResizeRows = false;
            this.DgvEntregables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEntregables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.entregable});
            this.DgvEntregables.Location = new System.Drawing.Point(7, 278);
            this.DgvEntregables.MultiSelect = false;
            this.DgvEntregables.Name = "DgvEntregables";
            this.DgvEntregables.RowHeadersVisible = false;
            this.DgvEntregables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEntregables.Size = new System.Drawing.Size(490, 131);
            this.DgvEntregables.TabIndex = 45;
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 70;
            // 
            // entregable
            // 
            this.entregable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.entregable.HeaderText = "Entregable";
            this.entregable.Name = "entregable";
            this.entregable.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Entregable(s):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 13);
            this.label6.TabIndex = 43;
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
            this.CmbCoordinador.Location = new System.Drawing.Point(6, 228);
            this.CmbCoordinador.Name = "CmbCoordinador";
            this.CmbCoordinador.Size = new System.Drawing.Size(491, 32);
            this.CmbCoordinador.TabIndex = 42;
            this.CmbCoordinador.SelectedIndexChanged += new System.EventHandler(this.CmbResponsable_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "¿Quién es responsable del proceso?";
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
            this.CmbResponsable.Location = new System.Drawing.Point(6, 175);
            this.CmbResponsable.Name = "CmbResponsable";
            this.CmbResponsable.Size = new System.Drawing.Size(491, 32);
            this.CmbResponsable.TabIndex = 40;
            this.CmbResponsable.SelectedIndexChanged += new System.EventHandler(this.CmbResponsable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Seleccionar fecha promesa:";
            // 
            // TxtFechaPromesa
            // 
            this.TxtFechaPromesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaPromesa.Location = new System.Drawing.Point(308, 125);
            this.TxtFechaPromesa.Name = "TxtFechaPromesa";
            this.TxtFechaPromesa.ReadOnly = true;
            this.TxtFechaPromesa.Size = new System.Drawing.Size(189, 29);
            this.TxtFechaPromesa.TabIndex = 38;
            this.TxtFechaPromesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Fecha de solicitud:";
            // 
            // TxtFechaSolicitud
            // 
            this.TxtFechaSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaSolicitud.Location = new System.Drawing.Point(308, 71);
            this.TxtFechaSolicitud.Name = "TxtFechaSolicitud";
            this.TxtFechaSolicitud.ReadOnly = true;
            this.TxtFechaSolicitud.Size = new System.Drawing.Size(189, 29);
            this.TxtFechaSolicitud.TabIndex = 36;
            this.TxtFechaSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Fecha promesa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Proceso:";
            // 
            // TxtProceso
            // 
            this.TxtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProceso.Location = new System.Drawing.Point(6, 71);
            this.TxtProceso.Name = "TxtProceso";
            this.TxtProceso.ReadOnly = true;
            this.TxtProceso.Size = new System.Drawing.Size(296, 29);
            this.TxtProceso.TabIndex = 33;
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(505, 23);
            this.audiselTituloForm1.TabIndex = 46;
            this.audiselTituloForm1.Text = "NUEVA META";
            // 
            // FrmSeleccionarFechaMetasCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 482);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeleccionarFechaMetasCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".";
            this.Load += new System.EventHandler(this.FrmSeleccionarFechaMetasCompras_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEntregables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblMensaje;
        private System.Windows.Forms.DateTimePicker DtpFechaMeta;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFechaPromesa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFechaSolicitud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtProceso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbCoordinador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbResponsable;
        private System.Windows.Forms.DataGridView DgvEntregables;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn entregable;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
    }
}
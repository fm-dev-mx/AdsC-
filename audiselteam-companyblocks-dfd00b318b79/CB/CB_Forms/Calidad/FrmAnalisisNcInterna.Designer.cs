namespace CB
{
    partial class FrmAnalisisNcInterna
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtDisposicion = new System.Windows.Forms.TextBox();
            this.TxtDefecto = new System.Windows.Forms.TextBox();
            this.LblDefecto = new System.Windows.Forms.Label();
            this.NumDefecto = new System.Windows.Forms.NumericUpDown();
            this.TxtFechaLiberacion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtLiberacion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtFechaInspeccion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtInspeccion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NumUdDiasRetraso = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbProbabilidad = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NumUdCostoEstimado = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtPersonaQueOrigina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtOrigen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSalidaNc = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtIdNoConformidad = new System.Windows.Forms.TextBox();
            this.DgvAcciones = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsables = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevaAcciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbTipoAccion = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDefecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdDiasRetraso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdCostoEstimado)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcciones)).BeginInit();
            this.Menu.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(1354, 23);
            this.LblTitulo.TabIndex = 10;
            this.LblTitulo.Text = "ANALISIS DE NO CONFORMIDAD INTERNA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.TxtDisposicion);
            this.panel1.Controls.Add(this.TxtDefecto);
            this.panel1.Controls.Add(this.LblDefecto);
            this.panel1.Controls.Add(this.NumDefecto);
            this.panel1.Controls.Add(this.TxtFechaLiberacion);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.TxtLiberacion);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.TxtFechaInspeccion);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.TxtInspeccion);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.NumUdDiasRetraso);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.CmbProbabilidad);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.NumUdCostoEstimado);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TxtPersonaQueOrigina);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtOrigen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtSalidaNc);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.TxtComentarios);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtIdNoConformidad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1354, 353);
            this.panel1.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(678, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 15);
            this.label14.TabIndex = 33;
            this.label14.Text = "Disposición:";
            // 
            // TxtDisposicion
            // 
            this.TxtDisposicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDisposicion.Location = new System.Drawing.Point(681, 179);
            this.TxtDisposicion.Name = "TxtDisposicion";
            this.TxtDisposicion.ReadOnly = true;
            this.TxtDisposicion.Size = new System.Drawing.Size(279, 29);
            this.TxtDisposicion.TabIndex = 32;
            // 
            // TxtDefecto
            // 
            this.TxtDefecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDefecto.Location = new System.Drawing.Point(748, 27);
            this.TxtDefecto.Name = "TxtDefecto";
            this.TxtDefecto.ReadOnly = true;
            this.TxtDefecto.Size = new System.Drawing.Size(333, 29);
            this.TxtDefecto.TabIndex = 31;
            // 
            // LblDefecto
            // 
            this.LblDefecto.AutoSize = true;
            this.LblDefecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDefecto.Location = new System.Drawing.Point(678, 9);
            this.LblDefecto.Name = "LblDefecto";
            this.LblDefecto.Size = new System.Drawing.Size(49, 15);
            this.LblDefecto.TabIndex = 30;
            this.LblDefecto.Text = "Defecto";
            // 
            // NumDefecto
            // 
            this.NumDefecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumDefecto.Location = new System.Drawing.Point(681, 27);
            this.NumDefecto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumDefecto.Name = "NumDefecto";
            this.NumDefecto.Size = new System.Drawing.Size(61, 29);
            this.NumDefecto.TabIndex = 29;
            this.NumDefecto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumDefecto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumDefecto.ValueChanged += new System.EventHandler(this.NumDefecto_ValueChanged);
            // 
            // TxtFechaLiberacion
            // 
            this.TxtFechaLiberacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaLiberacion.Location = new System.Drawing.Point(392, 179);
            this.TxtFechaLiberacion.Name = "TxtFechaLiberacion";
            this.TxtFechaLiberacion.ReadOnly = true;
            this.TxtFechaLiberacion.Size = new System.Drawing.Size(279, 29);
            this.TxtFechaLiberacion.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(389, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 15);
            this.label12.TabIndex = 27;
            this.label12.Text = "Fecha de liberación:";
            // 
            // TxtLiberacion
            // 
            this.TxtLiberacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLiberacion.Location = new System.Drawing.Point(12, 179);
            this.TxtLiberacion.Name = "TxtLiberacion";
            this.TxtLiberacion.ReadOnly = true;
            this.TxtLiberacion.Size = new System.Drawing.Size(372, 29);
            this.TxtLiberacion.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "Liberado por:";
            // 
            // TxtFechaInspeccion
            // 
            this.TxtFechaInspeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaInspeccion.Location = new System.Drawing.Point(392, 127);
            this.TxtFechaInspeccion.Name = "TxtFechaInspeccion";
            this.TxtFechaInspeccion.ReadOnly = true;
            this.TxtFechaInspeccion.Size = new System.Drawing.Size(281, 29);
            this.TxtFechaInspeccion.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(389, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Fecha de inspección:";
            // 
            // TxtInspeccion
            // 
            this.TxtInspeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInspeccion.Location = new System.Drawing.Point(12, 127);
            this.TxtInspeccion.Name = "TxtInspeccion";
            this.TxtInspeccion.ReadOnly = true;
            this.TxtInspeccion.Size = new System.Drawing.Size(372, 29);
            this.TxtInspeccion.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "Inspeccionado por:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(527, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Tiempo de retraso (días):";
            // 
            // NumUdDiasRetraso
            // 
            this.NumUdDiasRetraso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumUdDiasRetraso.Location = new System.Drawing.Point(532, 77);
            this.NumUdDiasRetraso.Name = "NumUdDiasRetraso";
            this.NumUdDiasRetraso.Size = new System.Drawing.Size(141, 29);
            this.NumUdDiasRetraso.TabIndex = 19;
            this.NumUdDiasRetraso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUdDiasRetraso.ValueChanged += new System.EventHandler(this.NumUdDiasRetraso_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(678, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(206, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Probabilidad de que vuelva a ocurrir:";
            // 
            // CmbProbabilidad
            // 
            this.CmbProbabilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProbabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProbabilidad.FormattingEnabled = true;
            this.CmbProbabilidad.Items.AddRange(new object[] {
            "",
            "MUY BAJA",
            "BAJA",
            "REGULAR",
            "ALTA",
            "MUY ALTA"});
            this.CmbProbabilidad.Location = new System.Drawing.Point(681, 76);
            this.CmbProbabilidad.Name = "CmbProbabilidad";
            this.CmbProbabilidad.Size = new System.Drawing.Size(241, 32);
            this.CmbProbabilidad.TabIndex = 17;
            this.CmbProbabilidad.SelectedIndexChanged += new System.EventHandler(this.CmbProbabilidad_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(389, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Costo estimado (USD):";
            // 
            // NumUdCostoEstimado
            // 
            this.NumUdCostoEstimado.DecimalPlaces = 2;
            this.NumUdCostoEstimado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumUdCostoEstimado.Location = new System.Drawing.Point(392, 76);
            this.NumUdCostoEstimado.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.NumUdCostoEstimado.Name = "NumUdCostoEstimado";
            this.NumUdCostoEstimado.Size = new System.Drawing.Size(120, 29);
            this.NumUdCostoEstimado.TabIndex = 15;
            this.NumUdCostoEstimado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUdCostoEstimado.ValueChanged += new System.EventHandler(this.NumUdCostoEstimado_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Detalles de la no conformidad:";
            // 
            // TxtPersonaQueOrigina
            // 
            this.TxtPersonaQueOrigina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPersonaQueOrigina.Location = new System.Drawing.Point(12, 76);
            this.TxtPersonaQueOrigina.Name = "TxtPersonaQueOrigina";
            this.TxtPersonaQueOrigina.ReadOnly = true;
            this.TxtPersonaQueOrigina.Size = new System.Drawing.Size(372, 29);
            this.TxtPersonaQueOrigina.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Persona que la origina:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(389, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Salida no conforme generada:";
            // 
            // TxtOrigen
            // 
            this.TxtOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOrigen.Location = new System.Drawing.Point(113, 27);
            this.TxtOrigen.Name = "TxtOrigen";
            this.TxtOrigen.ReadOnly = true;
            this.TxtOrigen.Size = new System.Drawing.Size(271, 29);
            this.TxtOrigen.TabIndex = 10;
            this.TxtOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Proceso que la origina:";
            // 
            // TxtSalidaNc
            // 
            this.TxtSalidaNc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSalidaNc.Location = new System.Drawing.Point(392, 27);
            this.TxtSalidaNc.Name = "TxtSalidaNc";
            this.TxtSalidaNc.ReadOnly = true;
            this.TxtSalidaNc.Size = new System.Drawing.Size(281, 29);
            this.TxtSalidaNc.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.BtnFinalizar);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Location = new System.Drawing.Point(1099, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 56);
            this.panel2.TabIndex = 7;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(3, 0);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(126, 56);
            this.BtnFinalizar.TabIndex = 52;
            this.BtnFinalizar.Text = "       Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(129, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(126, 56);
            this.BtnSalir.TabIndex = 51;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(0, 233);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ReadOnly = true;
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TxtComentarios.Size = new System.Drawing.Size(1354, 120);
            this.TxtComentarios.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "No conformidad:";
            // 
            // TxtIdNoConformidad
            // 
            this.TxtIdNoConformidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdNoConformidad.Location = new System.Drawing.Point(12, 27);
            this.TxtIdNoConformidad.Name = "TxtIdNoConformidad";
            this.TxtIdNoConformidad.ReadOnly = true;
            this.TxtIdNoConformidad.Size = new System.Drawing.Size(95, 29);
            this.TxtIdNoConformidad.TabIndex = 4;
            this.TxtIdNoConformidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DgvAcciones
            // 
            this.DgvAcciones.AllowUserToAddRows = false;
            this.DgvAcciones.AllowUserToResizeRows = false;
            this.DgvAcciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAcciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipo,
            this.nombre,
            this.descripcion,
            this.responsables,
            this.fecha_promesa,
            this.estatus});
            this.DgvAcciones.ContextMenuStrip = this.Menu;
            this.DgvAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAcciones.Location = new System.Drawing.Point(0, 445);
            this.DgvAcciones.Name = "DgvAcciones";
            this.DgvAcciones.ReadOnly = true;
            this.DgvAcciones.RowHeadersVisible = false;
            this.DgvAcciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAcciones.Size = new System.Drawing.Size(1354, 142);
            this.DgvAcciones.TabIndex = 13;
            // 
            // id
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle15;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // tipo
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipo.DefaultCellStyle = dataGridViewCellStyle16;
            this.tipo.HeaderText = "Tipo de acción";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Visible = false;
            this.tipo.Width = 180;
            // 
            // nombre
            // 
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle17;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 300;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle18;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // responsables
            // 
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.responsables.DefaultCellStyle = dataGridViewCellStyle19;
            this.responsables.HeaderText = "Responsable(s)";
            this.responsables.Name = "responsables";
            this.responsables.ReadOnly = true;
            this.responsables.Width = 230;
            // 
            // fecha_promesa
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_promesa.DefaultCellStyle = dataGridViewCellStyle20;
            this.fecha_promesa.HeaderText = "Fecha promesa";
            this.fecha_promesa.Name = "fecha_promesa";
            this.fecha_promesa.ReadOnly = true;
            this.fecha_promesa.Width = 150;
            // 
            // estatus
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle21;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 150;
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaAcciónToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(147, 26);
            // 
            // nuevaAcciónToolStripMenuItem
            // 
            this.nuevaAcciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevaAcciónToolStripMenuItem.Name = "nuevaAcciónToolStripMenuItem";
            this.nuevaAcciónToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.nuevaAcciónToolStripMenuItem.Text = "Nueva acción";
            this.nuevaAcciónToolStripMenuItem.Click += new System.EventHandler(this.nuevaAcciónToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.CmbTipoAccion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 376);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1354, 69);
            this.panel3.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Navy;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1354, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "ACCIONES IMPLEMENTADAS:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbTipoAccion
            // 
            this.CmbTipoAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoAccion.FormattingEnabled = true;
            this.CmbTipoAccion.Items.AddRange(new object[] {
            "TODAS",
            "CONTENCION",
            "CORRECTIVA",
            "PREVENTIVA"});
            this.CmbTipoAccion.Location = new System.Drawing.Point(12, 31);
            this.CmbTipoAccion.Name = "CmbTipoAccion";
            this.CmbTipoAccion.Size = new System.Drawing.Size(226, 28);
            this.CmbTipoAccion.TabIndex = 26;
            this.CmbTipoAccion.SelectedIndexChanged += new System.EventHandler(this.CmbTipoAccion_SelectedIndexChanged);
            // 
            // FrmAnalisisNcInterna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 587);
            this.Controls.Add(this.DgvAcciones);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAnalisisNcInterna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analisis de no conformidad interna";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAnalisisNcInterna_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDefecto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdDiasRetraso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdCostoEstimado)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcciones)).EndInit();
            this.Menu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtIdNoConformidad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtSalidaNc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NumUdCostoEstimado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown NumUdDiasRetraso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbProbabilidad;
        private System.Windows.Forms.DataGridView DgvAcciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsables;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox CmbTipoAccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem nuevaAcciónToolStripMenuItem;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.TextBox TxtFechaLiberacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtLiberacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtFechaInspeccion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtInspeccion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtPersonaQueOrigina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblDefecto;
        private System.Windows.Forms.NumericUpDown NumDefecto;
        private System.Windows.Forms.TextBox TxtDefecto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtDisposicion;
    }
}
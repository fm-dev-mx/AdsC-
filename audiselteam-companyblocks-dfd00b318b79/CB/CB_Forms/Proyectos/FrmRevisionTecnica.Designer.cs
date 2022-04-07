namespace CB
{
    partial class FrmRevisionTecnica
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
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.ImagenMaterial = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelInformacion = new System.Windows.Forms.LinkLabel();
            this.lbllink = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TxtRequisitor = new System.Windows.Forms.TextBox();
            this.TxtProyecto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtNumeroParteInterno = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DgvCotizacion = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_estimado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblInformacionCotizacion = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnRechazar = new System.Windows.Forms.Button();
            this.BkgDescargarImagen = new System.ComponentModel.BackgroundWorker();
            this.Progreso = new System.Windows.Forms.StatusStrip();
            this.LblEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCotizacion)).BeginInit();
            this.panel3.SuspendLayout();
            this.Progreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Número de parte fabricante:";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(194, 98);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(306, 29);
            this.TxtNumeroParte.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Fabricante *";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(194, 146);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(622, 29);
            this.TxtFabricante.TabIndex = 58;
            // 
            // ImagenMaterial
            // 
            this.ImagenMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagenMaterial.Image = global::CB_Base.Properties.Resources.manu_prod;
            this.ImagenMaterial.Location = new System.Drawing.Point(0, 0);
            this.ImagenMaterial.Name = "ImagenMaterial";
            this.ImagenMaterial.Size = new System.Drawing.Size(185, 152);
            this.ImagenMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenMaterial.TabIndex = 62;
            this.ImagenMaterial.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabelInformacion);
            this.panel1.Controls.Add(this.lbllink);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.TxtRequisitor);
            this.panel1.Controls.Add(this.TxtProyecto);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TxtNumeroParteInterno);
            this.panel1.Controls.Add(this.TxtDescripcion);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtFabricante);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtNumeroParte);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 283);
            this.panel1.TabIndex = 63;
            // 
            // linkLabelInformacion
            // 
            this.linkLabelInformacion.AutoSize = true;
            this.linkLabelInformacion.Location = new System.Drawing.Point(12, 195);
            this.linkLabelInformacion.Name = "linkLabelInformacion";
            this.linkLabelInformacion.Size = new System.Drawing.Size(63, 13);
            this.linkLabelInformacion.TabIndex = 75;
            this.linkLabelInformacion.TabStop = true;
            this.linkLabelInformacion.Text = "audisel.com";
            // 
            // lbllink
            // 
            this.lbllink.AutoSize = true;
            this.lbllink.Location = new System.Drawing.Point(12, 181);
            this.lbllink.Name = "lbllink";
            this.lbllink.Size = new System.Drawing.Size(30, 13);
            this.lbllink.TabIndex = 74;
            this.lbllink.Text = "Link:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(828, 21);
            this.label2.TabIndex = 65;
            this.label2.Text = "INFORMACION DEL MATERIAL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ImagenMaterial);
            this.panel4.Location = new System.Drawing.Point(3, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(185, 152);
            this.panel4.TabIndex = 73;
            // 
            // TxtRequisitor
            // 
            this.TxtRequisitor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtRequisitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRequisitor.Location = new System.Drawing.Point(510, 50);
            this.TxtRequisitor.Name = "TxtRequisitor";
            this.TxtRequisitor.ReadOnly = true;
            this.TxtRequisitor.Size = new System.Drawing.Size(306, 29);
            this.TxtRequisitor.TabIndex = 72;
            // 
            // TxtProyecto
            // 
            this.TxtProyecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProyecto.Location = new System.Drawing.Point(194, 50);
            this.TxtProyecto.Name = "TxtProyecto";
            this.TxtProyecto.ReadOnly = true;
            this.TxtProyecto.Size = new System.Drawing.Size(306, 29);
            this.TxtProyecto.TabIndex = 71;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(507, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 70;
            this.label9.Text = "Requisitor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 69;
            this.label7.Text = "Proyecto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(700, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(507, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Número de parte interno:";
            // 
            // TxtNumeroParteInterno
            // 
            this.TxtNumeroParteInterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParteInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParteInterno.Location = new System.Drawing.Point(510, 98);
            this.TxtNumeroParteInterno.Name = "TxtNumeroParteInterno";
            this.TxtNumeroParteInterno.ReadOnly = true;
            this.TxtNumeroParteInterno.Size = new System.Drawing.Size(306, 29);
            this.TxtNumeroParteInterno.TabIndex = 67;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.AcceptsTab = true;
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Location = new System.Drawing.Point(9, 228);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.Size = new System.Drawing.Size(807, 46);
            this.TxtDescripcion.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgvCotizacion);
            this.panel2.Controls.Add(this.LblInformacionCotizacion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 203);
            this.panel2.TabIndex = 64;
            // 
            // DgvCotizacion
            // 
            this.DgvCotizacion.AllowUserToAddRows = false;
            this.DgvCotizacion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCotizacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCotizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.proveedor,
            this.cantidad,
            this.precio_unitario,
            this.total,
            this.tiempo_estimado});
            this.DgvCotizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCotizacion.Location = new System.Drawing.Point(0, 21);
            this.DgvCotizacion.Name = "DgvCotizacion";
            this.DgvCotizacion.RowHeadersVisible = false;
            this.DgvCotizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCotizacion.Size = new System.Drawing.Size(828, 182);
            this.DgvCotizacion.TabIndex = 85;
            this.DgvCotizacion.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvCotizacion_CellFormatting);
            this.DgvCotizacion.SelectionChanged += new System.EventHandler(this.DgvCotizacion_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "Concepto";
            this.id.MinimumWidth = 70;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // proveedor
            // 
            this.proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cantidad.HeaderText = "Cantidad solicitada";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // precio_unitario
            // 
            this.precio_unitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.precio_unitario.HeaderText = "Precio unitario";
            this.precio_unitario.Name = "precio_unitario";
            this.precio_unitario.ReadOnly = true;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total.HeaderText = "Total estimado";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // tiempo_estimado
            // 
            this.tiempo_estimado.HeaderText = "Tiempo estimado";
            this.tiempo_estimado.Name = "tiempo_estimado";
            // 
            // LblInformacionCotizacion
            // 
            this.LblInformacionCotizacion.BackColor = System.Drawing.Color.Silver;
            this.LblInformacionCotizacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblInformacionCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInformacionCotizacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblInformacionCotizacion.Location = new System.Drawing.Point(0, 0);
            this.LblInformacionCotizacion.Name = "LblInformacionCotizacion";
            this.LblInformacionCotizacion.Size = new System.Drawing.Size(828, 21);
            this.LblInformacionCotizacion.TabIndex = 66;
            this.LblInformacionCotizacion.Text = "INFORMACION DE COTIZACION";
            this.LblInformacionCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TxtComentarios);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 509);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(828, 86);
            this.panel3.TabIndex = 65;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.AcceptsTab = true;
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtComentarios.Location = new System.Drawing.Point(0, 21);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(828, 65);
            this.TxtComentarios.TabIndex = 68;
            this.TxtComentarios.TextChanged += new System.EventHandler(this.TxtComentarios_TextChanged);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Silver;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(828, 21);
            this.label16.TabIndex = 67;
            this.label16.Text = "COMENTARIOS DE AUTORIZACION";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Enabled = false;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(544, 595);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(142, 51);
            this.BtnAceptar.TabIndex = 66;
            this.BtnAceptar.Text = "   Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnRechazar
            // 
            this.BtnRechazar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnRechazar.Enabled = false;
            this.BtnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRechazar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnRechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRechazar.Location = new System.Drawing.Point(400, 595);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(144, 51);
            this.BtnRechazar.TabIndex = 67;
            this.BtnRechazar.Text = "     Rechazar";
            this.BtnRechazar.UseVisualStyleBackColor = true;
            this.BtnRechazar.Click += new System.EventHandler(this.BtnRechazar_Click);
            // 
            // BkgDescargarImagen
            // 
            this.BkgDescargarImagen.WorkerReportsProgress = true;
            this.BkgDescargarImagen.WorkerSupportsCancellation = true;
            this.BkgDescargarImagen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarImagen_DoWork);
            this.BkgDescargarImagen.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarImagen_ProgressChanged);
            this.BkgDescargarImagen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarImagen_RunWorkerCompleted);
            // 
            // Progreso
            // 
            this.Progreso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblEstatus,
            this.Progress});
            this.Progreso.Location = new System.Drawing.Point(0, 646);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(828, 22);
            this.Progreso.TabIndex = 69;
            this.Progreso.Text = "statusStrip1";
            // 
            // LblEstatus
            // 
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(119, 17);
            this.LblEstatus.Text = "Descargando imagen";
            // 
            // Progress
            // 
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 16);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(686, 595);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(142, 51);
            this.BtnSalir.TabIndex = 75;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.Block_icon;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(256, 595);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(144, 51);
            this.BtnCancelar.TabIndex = 76;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(828, 23);
            this.audiselTituloForm1.TabIndex = 74;
            this.audiselTituloForm1.Text = "REVISION TECNICA";
            // 
            // FrmRevisionTecnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 668);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRechazar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRevisionTecnica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RevisionTecnica";
            this.Load += new System.EventHandler(this.FrmRevisionTecnica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCotizacion)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Progreso.ResumeLayout(false);
            this.Progreso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.PictureBox ImagenMaterial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtNumeroParteInterno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtRequisitor;
        private System.Windows.Forms.TextBox TxtProyecto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblInformacionCotizacion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnRechazar;
        private System.ComponentModel.BackgroundWorker BkgDescargarImagen;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.StatusStrip Progreso;
        private System.Windows.Forms.ToolStripStatusLabel LblEstatus;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridView DgvCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_estimado;
        private System.Windows.Forms.LinkLabel linkLabelInformacion;
        private System.Windows.Forms.Label lbllink;
    }
}
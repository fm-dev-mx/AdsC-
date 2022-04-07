namespace CB
{
    partial class FrmHistorialPagos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistorialPagos));
            this.LblTratamiento = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblRecibido = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbFiltroHistorialFinanzas = new System.Windows.Forms.ComboBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.DgvPlanosHistorial = new System.Windows.Forms.DataGridView();
            this.id_plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METODO_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODO_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_facturacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COTIZACION_FINAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO_COTIZACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.LblCargandoPlano = new System.Windows.Forms.Label();
            this.LblNumeroPlano = new System.Windows.Forms.Label();
            this.BtnHistorialPlanoFinanzas = new System.Windows.Forms.Button();
            this.GrupoInfoPlanoFinanzas = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblFechaPlano = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.MenuOpcionesPlanoRevisado = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDetallesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlanosHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.GrupoInfoPlanoFinanzas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.MenuOpcionesPlanoRevisado.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTratamiento
            // 
            this.LblTratamiento.AutoSize = true;
            this.LblTratamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTratamiento.Location = new System.Drawing.Point(387, 56);
            this.LblTratamiento.Name = "LblTratamiento";
            this.LblTratamiento.Size = new System.Drawing.Size(80, 16);
            this.LblTratamiento.TabIndex = 14;
            this.LblTratamiento.Text = "Tratamiento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(298, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tratamiento:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(283, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Fabricado por:";
            // 
            // LblRecibido
            // 
            this.LblRecibido.AutoSize = true;
            this.LblRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRecibido.Location = new System.Drawing.Point(389, 14);
            this.LblRecibido.Name = "LblRecibido";
            this.LblRecibido.Size = new System.Drawing.Size(63, 16);
            this.LblRecibido.TabIndex = 3;
            this.LblRecibido.Text = "Recibido";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.CmbFiltroHistorialFinanzas);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1709, 678);
            this.splitContainer2.SplitterDistance = 85;
            this.splitContainer2.TabIndex = 9;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1590, 23);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(119, 62);
            this.BtnSalir.TabIndex = 19;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1709, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "HISTORIAL DE PAGOS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cuentas:";
            // 
            // CmbFiltroHistorialFinanzas
            // 
            this.CmbFiltroHistorialFinanzas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroHistorialFinanzas.Enabled = false;
            this.CmbFiltroHistorialFinanzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroHistorialFinanzas.FormattingEnabled = true;
            this.CmbFiltroHistorialFinanzas.Items.AddRange(new object[] {
            "PARTES FABRICADAS",
            "PARTES COMPRADAS"});
            this.CmbFiltroHistorialFinanzas.Location = new System.Drawing.Point(10, 45);
            this.CmbFiltroHistorialFinanzas.Name = "CmbFiltroHistorialFinanzas";
            this.CmbFiltroHistorialFinanzas.Size = new System.Drawing.Size(671, 32);
            this.CmbFiltroHistorialFinanzas.TabIndex = 1;
            this.CmbFiltroHistorialFinanzas.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroHistorialFinanzas_SelectedIndexChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.DgvPlanosHistorial);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1709, 589);
            this.splitContainer3.SplitterDistance = 614;
            this.splitContainer3.TabIndex = 1;
            // 
            // DgvPlanosHistorial
            // 
            this.DgvPlanosHistorial.AllowUserToAddRows = false;
            this.DgvPlanosHistorial.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DgvPlanosHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPlanosHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvPlanosHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlanosHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_plano,
            this.plano,
            this.Proveedor,
            this.numero_factura,
            this.METODO_PAGO,
            this.MODO_PAGO,
            this.fecha_facturacion,
            this.fecha_pago,
            this.COTIZACION_FINAL,
            this.USUARIO_COTIZACION,
            this.USUARIO_PAGO});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPlanosHistorial.DefaultCellStyle = dataGridViewCellStyle14;
            this.DgvPlanosHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPlanosHistorial.Location = new System.Drawing.Point(0, 0);
            this.DgvPlanosHistorial.MultiSelect = false;
            this.DgvPlanosHistorial.Name = "DgvPlanosHistorial";
            this.DgvPlanosHistorial.ReadOnly = true;
            this.DgvPlanosHistorial.RowHeadersVisible = false;
            this.DgvPlanosHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPlanosHistorial.Size = new System.Drawing.Size(614, 589);
            this.DgvPlanosHistorial.TabIndex = 0;
            this.DgvPlanosHistorial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlanosHistorial_CellClick);
            // 
            // id_plano
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id_plano.DefaultCellStyle = dataGridViewCellStyle3;
            this.id_plano.Frozen = true;
            this.id_plano.HeaderText = "ID";
            this.id_plano.Name = "id_plano";
            this.id_plano.ReadOnly = true;
            this.id_plano.Width = 70;
            // 
            // plano
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plano.DefaultCellStyle = dataGridViewCellStyle4;
            this.plano.Frozen = true;
            this.plano.HeaderText = "Plano";
            this.plano.Name = "plano";
            this.plano.ReadOnly = true;
            this.plano.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.plano.Width = 140;
            // 
            // Proveedor
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Proveedor.DefaultCellStyle = dataGridViewCellStyle5;
            this.Proveedor.Frozen = true;
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            this.Proveedor.Width = 150;
            // 
            // numero_factura
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numero_factura.DefaultCellStyle = dataGridViewCellStyle6;
            this.numero_factura.Frozen = true;
            this.numero_factura.HeaderText = "Numero Factura";
            this.numero_factura.Name = "numero_factura";
            this.numero_factura.ReadOnly = true;
            // 
            // METODO_PAGO
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.METODO_PAGO.DefaultCellStyle = dataGridViewCellStyle7;
            this.METODO_PAGO.HeaderText = "Metodo de Pago";
            this.METODO_PAGO.Name = "METODO_PAGO";
            this.METODO_PAGO.ReadOnly = true;
            this.METODO_PAGO.Width = 150;
            // 
            // MODO_PAGO
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "N/A";
            this.MODO_PAGO.DefaultCellStyle = dataGridViewCellStyle8;
            this.MODO_PAGO.HeaderText = "Referencia Bancaria";
            this.MODO_PAGO.Name = "MODO_PAGO";
            this.MODO_PAGO.ReadOnly = true;
            this.MODO_PAGO.Width = 150;
            // 
            // fecha_facturacion
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = "N/A";
            this.fecha_facturacion.DefaultCellStyle = dataGridViewCellStyle9;
            this.fecha_facturacion.HeaderText = "Fecha Facturacion ";
            this.fecha_facturacion.Name = "fecha_facturacion";
            this.fecha_facturacion.ReadOnly = true;
            this.fecha_facturacion.Width = 150;
            // 
            // fecha_pago
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = "N/A";
            this.fecha_pago.DefaultCellStyle = dataGridViewCellStyle10;
            this.fecha_pago.HeaderText = "Fecha de Pago";
            this.fecha_pago.Name = "fecha_pago";
            this.fecha_pago.ReadOnly = true;
            this.fecha_pago.Width = 150;
            // 
            // COTIZACION_FINAL
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.COTIZACION_FINAL.DefaultCellStyle = dataGridViewCellStyle11;
            this.COTIZACION_FINAL.HeaderText = "Cotizacion Final";
            this.COTIZACION_FINAL.Name = "COTIZACION_FINAL";
            this.COTIZACION_FINAL.ReadOnly = true;
            this.COTIZACION_FINAL.Width = 150;
            // 
            // USUARIO_COTIZACION
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.USUARIO_COTIZACION.DefaultCellStyle = dataGridViewCellStyle12;
            this.USUARIO_COTIZACION.HeaderText = "Usuario Cotizacion";
            this.USUARIO_COTIZACION.Name = "USUARIO_COTIZACION";
            this.USUARIO_COTIZACION.ReadOnly = true;
            this.USUARIO_COTIZACION.Width = 150;
            // 
            // USUARIO_PAGO
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.USUARIO_PAGO.DefaultCellStyle = dataGridViewCellStyle13;
            this.USUARIO_PAGO.HeaderText = "Usuario Pago";
            this.USUARIO_PAGO.Name = "USUARIO_PAGO";
            this.USUARIO_PAGO.ReadOnly = true;
            this.USUARIO_PAGO.Width = 150;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer4.Panel1.Controls.Add(this.LblCargandoPlano);
            this.splitContainer4.Panel1.Controls.Add(this.LblNumeroPlano);
            this.splitContainer4.Panel1.Controls.Add(this.BtnHistorialPlanoFinanzas);
            this.splitContainer4.Panel1.Controls.Add(this.GrupoInfoPlanoFinanzas);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer4.Size = new System.Drawing.Size(1091, 589);
            this.splitContainer4.SplitterDistance = 105;
            this.splitContainer4.TabIndex = 1;
            // 
            // LblCargandoPlano
            // 
            this.LblCargandoPlano.AutoSize = true;
            this.LblCargandoPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCargandoPlano.Location = new System.Drawing.Point(5, 80);
            this.LblCargandoPlano.Name = "LblCargandoPlano";
            this.LblCargandoPlano.Size = new System.Drawing.Size(108, 13);
            this.LblCargandoPlano.TabIndex = 1;
            this.LblCargandoPlano.Text = "Cargando plano...";
            this.LblCargandoPlano.Visible = false;
            // 
            // LblNumeroPlano
            // 
            this.LblNumeroPlano.BackColor = System.Drawing.Color.Black;
            this.LblNumeroPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroPlano.ForeColor = System.Drawing.Color.White;
            this.LblNumeroPlano.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroPlano.Name = "LblNumeroPlano";
            this.LblNumeroPlano.Size = new System.Drawing.Size(1091, 23);
            this.LblNumeroPlano.TabIndex = 1;
            this.LblNumeroPlano.Text = "SELECCIONA UN PLANO";
            this.LblNumeroPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnHistorialPlanoFinanzas
            // 
            this.BtnHistorialPlanoFinanzas.Enabled = false;
            this.BtnHistorialPlanoFinanzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHistorialPlanoFinanzas.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnHistorialPlanoFinanzas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHistorialPlanoFinanzas.Location = new System.Drawing.Point(2, 26);
            this.BtnHistorialPlanoFinanzas.Name = "BtnHistorialPlanoFinanzas";
            this.BtnHistorialPlanoFinanzas.Size = new System.Drawing.Size(115, 45);
            this.BtnHistorialPlanoFinanzas.TabIndex = 1;
            this.BtnHistorialPlanoFinanzas.Text = "Opciones";
            this.BtnHistorialPlanoFinanzas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnHistorialPlanoFinanzas.UseVisualStyleBackColor = true;
            this.BtnHistorialPlanoFinanzas.Click += new System.EventHandler(this.BtnOpcionesPlanoFinanzas_Click);
            // 
            // GrupoInfoPlanoFinanzas
            // 
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.LblTratamiento);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.label9);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.label8);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.label7);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.LblRecibido);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.label6);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.LblCantidad);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.label5);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.LblProveedor);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.label3);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.LblFechaPlano);
            this.GrupoInfoPlanoFinanzas.Controls.Add(this.LblUsuario);
            this.GrupoInfoPlanoFinanzas.Location = new System.Drawing.Point(119, 22);
            this.GrupoInfoPlanoFinanzas.Name = "GrupoInfoPlanoFinanzas";
            this.GrupoInfoPlanoFinanzas.Size = new System.Drawing.Size(1197, 80);
            this.GrupoInfoPlanoFinanzas.TabIndex = 1;
            this.GrupoInfoPlanoFinanzas.TabStop = false;
            this.GrupoInfoPlanoFinanzas.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(318, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Recibido:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cantidad:";
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.Location = new System.Drawing.Point(121, 56);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(62, 16);
            this.LblCantidad.TabIndex = 4;
            this.LblCantidad.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha creación:";
            // 
            // LblProveedor
            // 
            this.LblProveedor.AutoSize = true;
            this.LblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProveedor.Location = new System.Drawing.Point(389, 34);
            this.LblProveedor.Name = "LblProveedor";
            this.LblProveedor.Size = new System.Drawing.Size(72, 16);
            this.LblProveedor.TabIndex = 5;
            this.LblProveedor.Text = "Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Creado por:";
            // 
            // LblFechaPlano
            // 
            this.LblFechaPlano.AutoSize = true;
            this.LblFechaPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFechaPlano.Location = new System.Drawing.Point(121, 34);
            this.LblFechaPlano.Name = "LblFechaPlano";
            this.LblFechaPlano.Size = new System.Drawing.Size(46, 16);
            this.LblFechaPlano.TabIndex = 6;
            this.LblFechaPlano.Text = "Fecha";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.Location = new System.Drawing.Point(121, 12);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(55, 16);
            this.LblUsuario.TabIndex = 7;
            this.LblUsuario.Text = "Usuario";
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(1091, 480);
            this.VisorPDF.TabIndex = 1;
            // 
            // MenuOpcionesPlanoRevisado
            // 
            this.MenuOpcionesPlanoRevisado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetallesToolStripMenuItem1});
            this.MenuOpcionesPlanoRevisado.Name = "MenuOpcionesPlanoRevisado";
            this.MenuOpcionesPlanoRevisado.Size = new System.Drawing.Size(134, 26);
            // 
            // verDetallesToolStripMenuItem1
            // 
            this.verDetallesToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.details;
            this.verDetallesToolStripMenuItem1.Name = "verDetallesToolStripMenuItem1";
            this.verDetallesToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.verDetallesToolStripMenuItem1.Text = "Ver detalles";
            this.verDetallesToolStripMenuItem1.Click += new System.EventHandler(this.verDetallesToolStripMenuItem1_Click);
            // 
            // FrmHistorialPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1709, 678);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FrmHistorialPagos";
            this.Text = "Historial de pagos";
            this.Load += new System.EventHandler(this.FrmHistorialPagos_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlanosHistorial)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.GrupoInfoPlanoFinanzas.ResumeLayout(false);
            this.GrupoInfoPlanoFinanzas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.MenuOpcionesPlanoRevisado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTratamiento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblRecibido;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbFiltroHistorialFinanzas;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView DgvPlanosHistorial;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label LblCargandoPlano;
        private System.Windows.Forms.Label LblNumeroPlano;
        private System.Windows.Forms.Button BtnHistorialPlanoFinanzas;
        private System.Windows.Forms.GroupBox GrupoInfoPlanoFinanzas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblFechaPlano;
        private System.Windows.Forms.Label LblUsuario;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.ContextMenuStrip MenuOpcionesPlanoRevisado;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn METODO_PAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODO_PAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_facturacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn COTIZACION_FINAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO_COTIZACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO_PAGO;





    }
}
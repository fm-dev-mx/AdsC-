namespace CB
{
    partial class FrmEnviarPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnviarPO));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgvTerminoPago = new System.Windows.Forms.DataGridView();
            this.id_termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblTerminosPago = new System.Windows.Forms.Label();
            this.CmbMoneda = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.NumOtrosCargos = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbFormato = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbDireccionFacturacion = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbDireccionEntrega = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NumPorcentajeDescuento = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.NumPorcentajeImpuestos = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbContacto = new System.Windows.Forms.ComboBox();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtProveedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDe = new System.Windows.Forms.TextBox();
            this.TxtNotas = new System.Windows.Forms.TextBox();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkEnviarCorreo = new System.Windows.Forms.CheckBox();
            this.BtnBorrarAdjunto = new System.Windows.Forms.Button();
            this.BtnAdjuntar = new System.Windows.Forms.Button();
            this.DgvAdjuntos = new System.Windows.Forms.DataGridView();
            this.nombre_archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.DgvContactosCopia = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtCuerpoCorreo = new System.Windows.Forms.TextBox();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.SeleccionarAdjunto = new System.Windows.Forms.OpenFileDialog();
            this.MenuTerminosPago = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volverADefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTerminoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOtrosCargos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPorcentajeDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPorcentajeImpuestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdjuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvContactosCopia)).BeginInit();
            this.MenuTerminosPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvTerminoPago);
            this.splitContainer1.Panel1.Controls.Add(this.LblTerminosPago);
            this.splitContainer1.Panel1.Controls.Add(this.CmbMoneda);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.NumOtrosCargos);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.CmbFormato);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.CmbDireccionFacturacion);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.CmbDireccionEntrega);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.NumPorcentajeDescuento);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.NumPorcentajeImpuestos);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.CmbContacto);
            this.splitContainer1.Panel1.Controls.Add(this.BtnActualizar);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.TxtProveedor);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.TxtDe);
            this.splitContainer1.Panel1.Controls.Add(this.TxtNotas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1028, 749);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 1;
            // 
            // DgvTerminoPago
            // 
            this.DgvTerminoPago.AllowUserToAddRows = false;
            this.DgvTerminoPago.AllowUserToResizeRows = false;
            this.DgvTerminoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTerminoPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_termino,
            this.porcentaje,
            this.termino});
            this.DgvTerminoPago.Location = new System.Drawing.Point(11, 490);
            this.DgvTerminoPago.Name = "DgvTerminoPago";
            this.DgvTerminoPago.RowHeadersVisible = false;
            this.DgvTerminoPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTerminoPago.Size = new System.Drawing.Size(282, 97);
            this.DgvTerminoPago.TabIndex = 79;
            this.DgvTerminoPago.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTerminoPago_CellClick);
            this.DgvTerminoPago.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTerminoPago_CellMouseDown);
            this.DgvTerminoPago.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DgvTerminoPago_RowsRemoved);
            this.DgvTerminoPago.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvTerminoPago_MouseClick);
            // 
            // id_termino
            // 
            this.id_termino.HeaderText = "ID";
            this.id_termino.Name = "id_termino";
            this.id_termino.ReadOnly = true;
            this.id_termino.Visible = false;
            // 
            // porcentaje
            // 
            this.porcentaje.HeaderText = "Prorcentaje";
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.ReadOnly = true;
            // 
            // termino
            // 
            this.termino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.termino.HeaderText = "Término";
            this.termino.Name = "termino";
            this.termino.ReadOnly = true;
            // 
            // LblTerminosPago
            // 
            this.LblTerminosPago.AutoSize = true;
            this.LblTerminosPago.Location = new System.Drawing.Point(8, 474);
            this.LblTerminosPago.Name = "LblTerminosPago";
            this.LblTerminosPago.Size = new System.Drawing.Size(92, 13);
            this.LblTerminosPago.TabIndex = 78;
            this.LblTerminosPago.Text = "Términos de pago";
            // 
            // CmbMoneda
            // 
            this.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMoneda.Enabled = false;
            this.CmbMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMoneda.FormattingEnabled = true;
            this.CmbMoneda.Items.AddRange(new object[] {
            "USD",
            "MXN",
            "EUR"});
            this.CmbMoneda.Location = new System.Drawing.Point(100, 443);
            this.CmbMoneda.Name = "CmbMoneda";
            this.CmbMoneda.Size = new System.Drawing.Size(131, 28);
            this.CmbMoneda.TabIndex = 76;
            this.CmbMoneda.SelectedIndexChanged += new System.EventHandler(this.CmbMoneda_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 451);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 75;
            this.label13.Text = "Moneda:";
            // 
            // NumOtrosCargos
            // 
            this.NumOtrosCargos.DecimalPlaces = 2;
            this.NumOtrosCargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOtrosCargos.Location = new System.Drawing.Point(99, 404);
            this.NumOtrosCargos.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.NumOtrosCargos.Name = "NumOtrosCargos";
            this.NumOtrosCargos.Size = new System.Drawing.Size(132, 29);
            this.NumOtrosCargos.TabIndex = 74;
            this.NumOtrosCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 414);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 73;
            this.label12.Text = "Otros cargos:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(237, 370);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 25);
            this.label11.TabIndex = 72;
            this.label11.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(237, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 25);
            this.label5.TabIndex = 71;
            this.label5.Text = "%";
            // 
            // CmbFormato
            // 
            this.CmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFormato.FormattingEnabled = true;
            this.CmbFormato.Items.AddRange(new object[] {
            "ESTADOS UNIDOS",
            "MEXICO",
            "EUROPA"});
            this.CmbFormato.Location = new System.Drawing.Point(11, 126);
            this.CmbFormato.Name = "CmbFormato";
            this.CmbFormato.Size = new System.Drawing.Size(284, 32);
            this.CmbFormato.TabIndex = 70;
            this.CmbFormato.SelectedIndexChanged += new System.EventHandler(this.CmbFormato_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Formato:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CmbDireccionFacturacion
            // 
            this.CmbDireccionFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDireccionFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDireccionFacturacion.FormattingEnabled = true;
            this.CmbDireccionFacturacion.Location = new System.Drawing.Point(10, 293);
            this.CmbDireccionFacturacion.Name = "CmbDireccionFacturacion";
            this.CmbDireccionFacturacion.Size = new System.Drawing.Size(283, 32);
            this.CmbDireccionFacturacion.TabIndex = 68;
            this.CmbDireccionFacturacion.SelectedIndexChanged += new System.EventHandler(this.CmbDireccionFacturacion_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "Dirección de facturación:";
            // 
            // CmbDireccionEntrega
            // 
            this.CmbDireccionEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDireccionEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDireccionEntrega.FormattingEnabled = true;
            this.CmbDireccionEntrega.Location = new System.Drawing.Point(10, 237);
            this.CmbDireccionEntrega.Name = "CmbDireccionEntrega";
            this.CmbDireccionEntrega.Size = new System.Drawing.Size(283, 32);
            this.CmbDireccionEntrega.TabIndex = 66;
            this.CmbDireccionEntrega.SelectedIndexChanged += new System.EventHandler(this.CmbDireccionEntrega_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Dirección de entrega:";
            // 
            // NumPorcentajeDescuento
            // 
            this.NumPorcentajeDescuento.DecimalPlaces = 2;
            this.NumPorcentajeDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPorcentajeDescuento.Location = new System.Drawing.Point(99, 369);
            this.NumPorcentajeDescuento.Name = "NumPorcentajeDescuento";
            this.NumPorcentajeDescuento.Size = new System.Drawing.Size(132, 29);
            this.NumPorcentajeDescuento.TabIndex = 64;
            this.NumPorcentajeDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 379);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Descuento:";
            // 
            // NumPorcentajeImpuestos
            // 
            this.NumPorcentajeImpuestos.DecimalPlaces = 2;
            this.NumPorcentajeImpuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPorcentajeImpuestos.Location = new System.Drawing.Point(99, 334);
            this.NumPorcentajeImpuestos.Name = "NumPorcentajeImpuestos";
            this.NumPorcentajeImpuestos.Size = new System.Drawing.Size(132, 29);
            this.NumPorcentajeImpuestos.TabIndex = 62;
            this.NumPorcentajeImpuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Impuestos:";
            // 
            // CmbContacto
            // 
            this.CmbContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContacto.FormattingEnabled = true;
            this.CmbContacto.Location = new System.Drawing.Point(10, 181);
            this.CmbContacto.Name = "CmbContacto";
            this.CmbContacto.Size = new System.Drawing.Size(283, 32);
            this.CmbContacto.TabIndex = 58;
            this.CmbContacto.SelectedIndexChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Location = new System.Drawing.Point(198, 700);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(95, 23);
            this.BtnActualizar.TabIndex = 57;
            this.BtnActualizar.Text = "Actualizar PDF";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Proveedor:";
            // 
            // TxtProveedor
            // 
            this.TxtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProveedor.Location = new System.Drawing.Point(11, 74);
            this.TxtProveedor.Name = "TxtProveedor";
            this.TxtProveedor.ReadOnly = true;
            this.TxtProveedor.Size = new System.Drawing.Size(284, 29);
            this.TxtProveedor.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 590);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Comentarios / notas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contacto principal:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Emitida por:";
            // 
            // TxtDe
            // 
            this.TxtDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDe.Location = new System.Drawing.Point(11, 25);
            this.TxtDe.Name = "TxtDe";
            this.TxtDe.ReadOnly = true;
            this.TxtDe.Size = new System.Drawing.Size(284, 29);
            this.TxtDe.TabIndex = 1;
            // 
            // TxtNotas
            // 
            this.TxtNotas.Location = new System.Drawing.Point(10, 608);
            this.TxtNotas.Multiline = true;
            this.TxtNotas.Name = "TxtNotas";
            this.TxtNotas.Size = new System.Drawing.Size(283, 86);
            this.TxtNotas.TabIndex = 0;
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(412, 749);
            this.VisorPDF.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkEnviarCorreo);
            this.panel1.Controls.Add(this.BtnBorrarAdjunto);
            this.panel1.Controls.Add(this.BtnAdjuntar);
            this.panel1.Controls.Add(this.DgvAdjuntos);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.DgvContactosCopia);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.TxtCuerpoCorreo);
            this.panel1.Controls.Add(this.BtnEnviar);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(412, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 749);
            this.panel1.TabIndex = 2;
            // 
            // chkEnviarCorreo
            // 
            this.chkEnviarCorreo.AutoSize = true;
            this.chkEnviarCorreo.Checked = true;
            this.chkEnviarCorreo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnviarCorreo.Location = new System.Drawing.Point(189, 7);
            this.chkEnviarCorreo.Name = "chkEnviarCorreo";
            this.chkEnviarCorreo.Size = new System.Drawing.Size(107, 17);
            this.chkEnviarCorreo.TabIndex = 87;
            this.chkEnviarCorreo.Text = "Enviar por correo";
            this.chkEnviarCorreo.UseVisualStyleBackColor = true;
            this.chkEnviarCorreo.CheckedChanged += new System.EventHandler(this.chkEnviarCorreo_CheckedChanged);
            // 
            // BtnBorrarAdjunto
            // 
            this.BtnBorrarAdjunto.Enabled = false;
            this.BtnBorrarAdjunto.Location = new System.Drawing.Point(157, 586);
            this.BtnBorrarAdjunto.Name = "BtnBorrarAdjunto";
            this.BtnBorrarAdjunto.Size = new System.Drawing.Size(139, 23);
            this.BtnBorrarAdjunto.TabIndex = 81;
            this.BtnBorrarAdjunto.Text = "Borrar";
            this.BtnBorrarAdjunto.UseVisualStyleBackColor = true;
            this.BtnBorrarAdjunto.Click += new System.EventHandler(this.BtnBorrarAdjunto_Click);
            // 
            // BtnAdjuntar
            // 
            this.BtnAdjuntar.Location = new System.Drawing.Point(12, 586);
            this.BtnAdjuntar.Name = "BtnAdjuntar";
            this.BtnAdjuntar.Size = new System.Drawing.Size(139, 23);
            this.BtnAdjuntar.TabIndex = 77;
            this.BtnAdjuntar.Text = "Adjuntar";
            this.BtnAdjuntar.UseVisualStyleBackColor = true;
            this.BtnAdjuntar.Click += new System.EventHandler(this.BtnAdjuntar_Click);
            // 
            // DgvAdjuntos
            // 
            this.DgvAdjuntos.AllowUserToAddRows = false;
            this.DgvAdjuntos.AllowUserToResizeRows = false;
            this.DgvAdjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAdjuntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre_archivo});
            this.DgvAdjuntos.Location = new System.Drawing.Point(12, 412);
            this.DgvAdjuntos.MultiSelect = false;
            this.DgvAdjuntos.Name = "DgvAdjuntos";
            this.DgvAdjuntos.ReadOnly = true;
            this.DgvAdjuntos.RowHeadersVisible = false;
            this.DgvAdjuntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAdjuntos.Size = new System.Drawing.Size(284, 168);
            this.DgvAdjuntos.TabIndex = 80;
            this.DgvAdjuntos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdjuntos_CellClick);
            this.DgvAdjuntos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdjuntos_CellDoubleClick);
            // 
            // nombre_archivo
            // 
            this.nombre_archivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_archivo.HeaderText = "Archivo";
            this.nombre_archivo.Name = "nombre_archivo";
            this.nombre_archivo.ReadOnly = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 396);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 77;
            this.label15.Text = "Archivos adjuntos:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 221);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 13);
            this.label16.TabIndex = 78;
            this.label16.Text = "Contactos en copia:";
            // 
            // DgvContactosCopia
            // 
            this.DgvContactosCopia.AllowUserToAddRows = false;
            this.DgvContactosCopia.AllowUserToResizeRows = false;
            this.DgvContactosCopia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvContactosCopia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.seleccion,
            this.contacto,
            this.correo});
            this.DgvContactosCopia.Location = new System.Drawing.Point(12, 238);
            this.DgvContactosCopia.MultiSelect = false;
            this.DgvContactosCopia.Name = "DgvContactosCopia";
            this.DgvContactosCopia.RowHeadersVisible = false;
            this.DgvContactosCopia.Size = new System.Drawing.Size(284, 150);
            this.DgvContactosCopia.TabIndex = 79;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // seleccion
            // 
            this.seleccion.HeaderText = "";
            this.seleccion.Name = "seleccion";
            this.seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seleccion.Width = 30;
            // 
            // contacto
            // 
            this.contacto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.contacto.HeaderText = "Contacto";
            this.contacto.Name = "contacto";
            this.contacto.ReadOnly = true;
            // 
            // correo
            // 
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            this.correo.ReadOnly = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 78;
            this.label14.Text = "Cuerpo del correo:";
            // 
            // TxtCuerpoCorreo
            // 
            this.TxtCuerpoCorreo.Location = new System.Drawing.Point(12, 27);
            this.TxtCuerpoCorreo.Multiline = true;
            this.TxtCuerpoCorreo.Name = "TxtCuerpoCorreo";
            this.TxtCuerpoCorreo.Size = new System.Drawing.Size(284, 188);
            this.TxtCuerpoCorreo.TabIndex = 77;
            this.TxtCuerpoCorreo.Text = "Estimado proveedor, favor de proveer precio unitario, tiempo de entrega estimado " +
    "y unidades disponibles para los siguientes números de parte:";
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Enabled = false;
            this.BtnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviar.Location = new System.Drawing.Point(157, 640);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(139, 42);
            this.BtnEnviar.TabIndex = 52;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(12, 640);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(139, 42);
            this.BtnCancelar.TabIndex = 53;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // SeleccionarAdjunto
            // 
            this.SeleccionarAdjunto.FileName = "openFileDialog1";
            // 
            // MenuTerminosPago
            // 
            this.MenuTerminosPago.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuTerminosPago.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.borrarToolStripMenuItem,
            this.volverADefaultToolStripMenuItem});
            this.MenuTerminosPago.Name = "contextMenuStrip1";
            this.MenuTerminosPago.Size = new System.Drawing.Size(160, 108);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // volverADefaultToolStripMenuItem
            // 
            this.volverADefaultToolStripMenuItem.Image = global::CB_Base.Properties.Resources.update;
            this.volverADefaultToolStripMenuItem.Name = "volverADefaultToolStripMenuItem";
            this.volverADefaultToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.volverADefaultToolStripMenuItem.Text = "Volver a default";
            this.volverADefaultToolStripMenuItem.Click += new System.EventHandler(this.volverADefaultToolStripMenuItem_Click);
            // 
            // FrmEnviarPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 749);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmEnviarPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar PO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEnviarPO_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTerminoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOtrosCargos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPorcentajeDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPorcentajeImpuestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdjuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvContactosCopia)).EndInit();
            this.MenuTerminosPago.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox CmbContacto;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtProveedor;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDe;
        private System.Windows.Forms.TextBox TxtNotas;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.NumericUpDown NumPorcentajeDescuento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NumPorcentajeImpuestos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbDireccionFacturacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbDireccionEntrega;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbFormato;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumOtrosCargos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox CmbMoneda;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtCuerpoCorreo;
        private System.Windows.Forms.DataGridView DgvAdjuntos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView DgvContactosCopia;
        private System.Windows.Forms.Button BtnAdjuntar;
        private System.Windows.Forms.Button BtnBorrarAdjunto;
        private System.Windows.Forms.OpenFileDialog SeleccionarAdjunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_archivo;
        private System.Windows.Forms.CheckBox chkEnviarCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.Label LblTerminosPago;
        private System.Windows.Forms.DataGridView DgvTerminoPago;
        private System.Windows.Forms.ContextMenuStrip MenuTerminosPago;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volverADefaultToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn termino;
    }
}
namespace CB
{
    partial class FrmSeleccionarProveedorParaPieza
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvUltimosConceptos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.TxtCantEstimada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSeleccionarProveedor = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.DgvRequisiciones = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.MenuRfqConceptos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.capturarCotizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionRequisicion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idRequisicionCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyectoRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preferido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rfq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_disponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuRequisiciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarNadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUltimosConceptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequisiciones)).BeginInit();
            this.MenuRfqConceptos.SuspendLayout();
            this.MenuRequisiciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvUltimosConceptos
            // 
            this.DgvUltimosConceptos.AllowUserToAddRows = false;
            this.DgvUltimosConceptos.AllowUserToDeleteRows = false;
            this.DgvUltimosConceptos.AllowUserToResizeColumns = false;
            this.DgvUltimosConceptos.AllowUserToResizeRows = false;
            this.DgvUltimosConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUltimosConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.preferido,
            this.rfq,
            this.proveedor,
            this.concepto,
            this.precio_unitario,
            this.moneda,
            this.cantidad_disponible,
            this.tiempo_entrega,
            this.fecha_cotizacion});
            this.DgvUltimosConceptos.ContextMenuStrip = this.MenuRfqConceptos;
            this.DgvUltimosConceptos.Location = new System.Drawing.Point(12, 194);
            this.DgvUltimosConceptos.Name = "DgvUltimosConceptos";
            this.DgvUltimosConceptos.RowHeadersVisible = false;
            this.DgvUltimosConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvUltimosConceptos.Size = new System.Drawing.Size(691, 129);
            this.DgvUltimosConceptos.TabIndex = 0;
            this.DgvUltimosConceptos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUltimosConceptos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripción: ";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.Location = new System.Drawing.Point(12, 97);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.Size = new System.Drawing.Size(691, 78);
            this.TxtDescripcion.TabIndex = 2;
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(12, 46);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(385, 26);
            this.TxtNumeroParte.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Número de parte:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fabricante:";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(403, 46);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(300, 26);
            this.TxtFabricante.TabIndex = 6;
            // 
            // TxtCantEstimada
            // 
            this.TxtCantEstimada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantEstimada.Location = new System.Drawing.Point(12, 568);
            this.TxtCantEstimada.Name = "TxtCantEstimada";
            this.TxtCantEstimada.ReadOnly = true;
            this.TxtCantEstimada.Size = new System.Drawing.Size(371, 26);
            this.TxtCantEstimada.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 552);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cantidad estimada:";
            // 
            // BtnSeleccionarProveedor
            // 
            this.BtnSeleccionarProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSeleccionarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarProveedor.Location = new System.Drawing.Point(556, 545);
            this.BtnSeleccionarProveedor.Name = "BtnSeleccionarProveedor";
            this.BtnSeleccionarProveedor.Size = new System.Drawing.Size(147, 57);
            this.BtnSeleccionarProveedor.TabIndex = 31;
            this.BtnSeleccionarProveedor.Text = "Seleccionar";
            this.BtnSeleccionarProveedor.UseVisualStyleBackColor = true;
            this.BtnSeleccionarProveedor.Click += new System.EventHandler(this.BtnSeleccionarProveedor_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(403, 545);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(147, 57);
            this.BtnCancelar.TabIndex = 30;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Selecciona el proveedor preferido:";
            // 
            // DgvRequisiciones
            // 
            this.DgvRequisiciones.AllowUserToAddRows = false;
            this.DgvRequisiciones.AllowUserToDeleteRows = false;
            this.DgvRequisiciones.AllowUserToResizeColumns = false;
            this.DgvRequisiciones.AllowUserToResizeRows = false;
            this.DgvRequisiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRequisiciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccionRequisicion,
            this.idRequisicionCompra,
            this.cantidadRequisicion,
            this.proyectoRequisicion,
            this.Column1,
            this.fechaRequisicion,
            this.estatusRequisicion});
            this.DgvRequisiciones.ContextMenuStrip = this.MenuRequisiciones;
            this.DgvRequisiciones.Location = new System.Drawing.Point(12, 342);
            this.DgvRequisiciones.Name = "DgvRequisiciones";
            this.DgvRequisiciones.RowHeadersVisible = false;
            this.DgvRequisiciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRequisiciones.Size = new System.Drawing.Size(691, 197);
            this.DgvRequisiciones.TabIndex = 33;
            this.DgvRequisiciones.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvRequisiciones_CellMouseUp);
            this.DgvRequisiciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequisiciones_CellValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(298, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Selecciona las requisiciones de compra que deseas procesar:";
            // 
            // MenuRfqConceptos
            // 
            this.MenuRfqConceptos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capturarCotizaciónToolStripMenuItem});
            this.MenuRfqConceptos.Name = "MenuRfqConceptos";
            this.MenuRfqConceptos.Size = new System.Drawing.Size(178, 26);
            // 
            // capturarCotizaciónToolStripMenuItem
            // 
            this.capturarCotizaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.price_tag_icon;
            this.capturarCotizaciónToolStripMenuItem.Name = "capturarCotizaciónToolStripMenuItem";
            this.capturarCotizaciónToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.capturarCotizaciónToolStripMenuItem.Text = "Capturar cotización";
            this.capturarCotizaciónToolStripMenuItem.Click += new System.EventHandler(this.capturarCotizaciónToolStripMenuItem_Click);
            // 
            // seleccionRequisicion
            // 
            this.seleccionRequisicion.Frozen = true;
            this.seleccionRequisicion.HeaderText = "";
            this.seleccionRequisicion.MinimumWidth = 20;
            this.seleccionRequisicion.Name = "seleccionRequisicion";
            this.seleccionRequisicion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.seleccionRequisicion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seleccionRequisicion.Width = 20;
            // 
            // idRequisicionCompra
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idRequisicionCompra.DefaultCellStyle = dataGridViewCellStyle17;
            this.idRequisicionCompra.Frozen = true;
            this.idRequisicionCompra.HeaderText = "ID";
            this.idRequisicionCompra.Name = "idRequisicionCompra";
            this.idRequisicionCompra.ReadOnly = true;
            this.idRequisicionCompra.Width = 70;
            // 
            // cantidadRequisicion
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidadRequisicion.DefaultCellStyle = dataGridViewCellStyle18;
            this.cantidadRequisicion.HeaderText = "Cantidad";
            this.cantidadRequisicion.Name = "cantidadRequisicion";
            this.cantidadRequisicion.Width = 70;
            // 
            // proyectoRequisicion
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.proyectoRequisicion.DefaultCellStyle = dataGridViewCellStyle19;
            this.proyectoRequisicion.HeaderText = "Proyecto";
            this.proyectoRequisicion.Name = "proyectoRequisicion";
            this.proyectoRequisicion.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Requisitor";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // fechaRequisicion
            // 
            this.fechaRequisicion.HeaderText = "Fecha de requisición";
            this.fechaRequisicion.Name = "fechaRequisicion";
            this.fechaRequisicion.Width = 130;
            // 
            // estatusRequisicion
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatusRequisicion.DefaultCellStyle = dataGridViewCellStyle20;
            this.estatusRequisicion.HeaderText = "Estatus de compra";
            this.estatusRequisicion.Name = "estatusRequisicion";
            this.estatusRequisicion.Width = 175;
            // 
            // preferido
            // 
            this.preferido.HeaderText = "";
            this.preferido.MinimumWidth = 20;
            this.preferido.Name = "preferido";
            this.preferido.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.preferido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.preferido.Width = 20;
            // 
            // rfq
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.rfq.DefaultCellStyle = dataGridViewCellStyle11;
            this.rfq.HeaderText = "RFQ";
            this.rfq.Name = "rfq";
            this.rfq.Width = 80;
            // 
            // proveedor
            // 
            this.proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            // 
            // concepto
            // 
            this.concepto.HeaderText = "Concepto";
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            this.concepto.Visible = false;
            // 
            // precio_unitario
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.precio_unitario.DefaultCellStyle = dataGridViewCellStyle12;
            this.precio_unitario.HeaderText = "Precio Unitario";
            this.precio_unitario.MinimumWidth = 85;
            this.precio_unitario.Name = "precio_unitario";
            this.precio_unitario.ReadOnly = true;
            this.precio_unitario.Width = 85;
            // 
            // moneda
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.moneda.DefaultCellStyle = dataGridViewCellStyle13;
            this.moneda.HeaderText = "Moneda";
            this.moneda.MinimumWidth = 55;
            this.moneda.Name = "moneda";
            this.moneda.ReadOnly = true;
            this.moneda.Width = 55;
            // 
            // cantidad_disponible
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad_disponible.DefaultCellStyle = dataGridViewCellStyle14;
            this.cantidad_disponible.HeaderText = "Cantidad disponible";
            this.cantidad_disponible.MinimumWidth = 65;
            this.cantidad_disponible.Name = "cantidad_disponible";
            this.cantidad_disponible.ReadOnly = true;
            this.cantidad_disponible.Width = 65;
            // 
            // tiempo_entrega
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tiempo_entrega.DefaultCellStyle = dataGridViewCellStyle15;
            this.tiempo_entrega.HeaderText = "Tiempo Entrega";
            this.tiempo_entrega.MinimumWidth = 65;
            this.tiempo_entrega.Name = "tiempo_entrega";
            this.tiempo_entrega.ReadOnly = true;
            this.tiempo_entrega.Width = 65;
            // 
            // fecha_cotizacion
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_cotizacion.DefaultCellStyle = dataGridViewCellStyle16;
            this.fecha_cotizacion.HeaderText = "Fecha de cotización";
            this.fecha_cotizacion.Name = "fecha_cotizacion";
            this.fecha_cotizacion.ReadOnly = true;
            this.fecha_cotizacion.Width = 90;
            // 
            // MenuRequisiciones
            // 
            this.MenuRequisiciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarTodoToolStripMenuItem,
            this.seleccionarNadaToolStripMenuItem});
            this.MenuRequisiciones.Name = "MenuRequisiciones";
            this.MenuRequisiciones.Size = new System.Drawing.Size(164, 70);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo";
            this.seleccionarTodoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarTodoToolStripMenuItem_Click);
            // 
            // seleccionarNadaToolStripMenuItem
            // 
            this.seleccionarNadaToolStripMenuItem.Name = "seleccionarNadaToolStripMenuItem";
            this.seleccionarNadaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seleccionarNadaToolStripMenuItem.Text = "Seleccionar nada";
            this.seleccionarNadaToolStripMenuItem.Click += new System.EventHandler(this.seleccionarNadaToolStripMenuItem_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(715, 23);
            this.audiselTituloForm1.TabIndex = 10;
            this.audiselTituloForm1.Text = "SELECCIONAR PROVEEDOR PREFERIDO";
            // 
            // FrmSeleccionarProveedorParaPieza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 611);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DgvRequisiciones);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnSeleccionarProveedor);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.audiselTituloForm1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtCantEstimada);
            this.Controls.Add(this.TxtFabricante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNumeroParte);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvUltimosConceptos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeleccionarProveedorParaPieza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSeleccionarProveedorParaPieza";
            this.Load += new System.EventHandler(this.FrmSeleccionarProveedorParaPieza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvUltimosConceptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequisiciones)).EndInit();
            this.MenuRfqConceptos.ResumeLayout(false);
            this.MenuRequisiciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvUltimosConceptos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.TextBox TxtCantEstimada;
        private System.Windows.Forms.Label label4;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Button BtnSeleccionarProveedor;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DgvRequisiciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip MenuRfqConceptos;
        private System.Windows.Forms.ToolStripMenuItem capturarCotizaciónToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn preferido;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfq;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_disponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_entrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_cotizacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRequisicionCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyectoRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatusRequisicion;
        private System.Windows.Forms.ContextMenuStrip MenuRequisiciones;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarNadaToolStripMenuItem;
    }
}
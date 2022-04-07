namespace CB
{
    partial class FrmAceptacionDisenoMecanico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAceptacionDisenoMecanico));
            this.SeleccionarAdjunto = new System.Windows.Forms.OpenFileDialog();
            this.MenuTerminosPago = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volverADefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRequerimiento = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarNadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LblModulos = new System.Windows.Forms.Label();
            this.ChkModoFalla = new System.Windows.Forms.CheckBox();
            this.ChkSecuencia = new System.Windows.Forms.CheckBox();
            this.ChkElemento = new System.Windows.Forms.CheckBox();
            this.ChkCliente = new System.Windows.Forms.CheckBox();
            this.ChkInterno = new System.Windows.Forms.CheckBox();
            this.LblRequerimirnto = new System.Windows.Forms.Label();
            this.DgvRequerimentos = new System.Windows.Forms.DataGridView();
            this.id_req = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblVistas = new System.Windows.Forms.Label();
            this.DgvImagenModulo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vista_detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_previa = new System.Windows.Forms.DataGridViewImageColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.MenuTerminosPago.SuspendLayout();
            this.MenuRequerimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequerimentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvImagenModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.SuspendLayout();
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
            this.MenuTerminosPago.Size = new System.Drawing.Size(156, 92);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            // 
            // volverADefaultToolStripMenuItem
            // 
            this.volverADefaultToolStripMenuItem.Name = "volverADefaultToolStripMenuItem";
            this.volverADefaultToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.volverADefaultToolStripMenuItem.Text = "Volver a default";
            // 
            // MenuRequerimiento
            // 
            this.MenuRequerimiento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarTodoToolStripMenuItem,
            this.seleccionarNadaToolStripMenuItem});
            this.MenuRequerimiento.Name = "contextMenuStrip1";
            this.MenuRequerimiento.Size = new System.Drawing.Size(164, 48);
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
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(739, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(159, 75);
            this.BtnSalir.TabIndex = 19;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LblModulos);
            this.splitContainer1.Panel1.Controls.Add(this.ChkModoFalla);
            this.splitContainer1.Panel1.Controls.Add(this.ChkSecuencia);
            this.splitContainer1.Panel1.Controls.Add(this.ChkElemento);
            this.splitContainer1.Panel1.Controls.Add(this.ChkCliente);
            this.splitContainer1.Panel1.Controls.Add(this.ChkInterno);
            this.splitContainer1.Panel1.Controls.Add(this.LblRequerimirnto);
            this.splitContainer1.Panel1.Controls.Add(this.DgvRequerimentos);
            this.splitContainer1.Panel1.Controls.Add(this.LblVistas);
            this.splitContainer1.Panel1.Controls.Add(this.DgvImagenModulo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1370, 720);
            this.splitContainer1.SplitterDistance = 468;
            this.splitContainer1.TabIndex = 2;
            // 
            // LblModulos
            // 
            this.LblModulos.AutoSize = true;
            this.LblModulos.Enabled = false;
            this.LblModulos.Location = new System.Drawing.Point(8, 493);
            this.LblModulos.Name = "LblModulos";
            this.LblModulos.Size = new System.Drawing.Size(283, 13);
            this.LblModulos.TabIndex = 89;
            this.LblModulos.Text = "Seleccione los módulos que desea agregar al archivo PDF";
            // 
            // ChkModoFalla
            // 
            this.ChkModoFalla.AutoSize = true;
            this.ChkModoFalla.Enabled = false;
            this.ChkModoFalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ChkModoFalla.Location = new System.Drawing.Point(13, 572);
            this.ChkModoFalla.Name = "ChkModoFalla";
            this.ChkModoFalla.Size = new System.Drawing.Size(132, 17);
            this.ChkModoFalla.TabIndex = 88;
            this.ChkModoFalla.Text = "Mostrar modo de fallas";
            this.ChkModoFalla.UseVisualStyleBackColor = true;
            this.ChkModoFalla.CheckedChanged += new System.EventHandler(this.ChkModoFalla_CheckedChanged);
            // 
            // ChkSecuencia
            // 
            this.ChkSecuencia.AutoSize = true;
            this.ChkSecuencia.Enabled = false;
            this.ChkSecuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ChkSecuencia.Location = new System.Drawing.Point(13, 546);
            this.ChkSecuencia.Name = "ChkSecuencia";
            this.ChkSecuencia.Size = new System.Drawing.Size(113, 17);
            this.ChkSecuencia.TabIndex = 87;
            this.ChkSecuencia.Text = "Mostrar secuencia";
            this.ChkSecuencia.UseVisualStyleBackColor = true;
            this.ChkSecuencia.CheckedChanged += new System.EventHandler(this.ChkSecuencia_CheckedChanged);
            // 
            // ChkElemento
            // 
            this.ChkElemento.AutoSize = true;
            this.ChkElemento.Enabled = false;
            this.ChkElemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ChkElemento.Location = new System.Drawing.Point(13, 520);
            this.ChkElemento.Name = "ChkElemento";
            this.ChkElemento.Size = new System.Drawing.Size(112, 17);
            this.ChkElemento.TabIndex = 86;
            this.ChkElemento.Text = "Mostrar elementos";
            this.ChkElemento.UseVisualStyleBackColor = true;
            this.ChkElemento.CheckedChanged += new System.EventHandler(this.ChkElemento_CheckedChanged);
            // 
            // ChkCliente
            // 
            this.ChkCliente.AutoSize = true;
            this.ChkCliente.Location = new System.Drawing.Point(257, 246);
            this.ChkCliente.Name = "ChkCliente";
            this.ChkCliente.Size = new System.Drawing.Size(58, 17);
            this.ChkCliente.TabIndex = 85;
            this.ChkCliente.Text = "Cliente";
            this.ChkCliente.UseVisualStyleBackColor = true;
            this.ChkCliente.CheckedChanged += new System.EventHandler(this.ChkCliente_CheckedChanged);
            // 
            // ChkInterno
            // 
            this.ChkInterno.AutoSize = true;
            this.ChkInterno.Location = new System.Drawing.Point(185, 246);
            this.ChkInterno.Name = "ChkInterno";
            this.ChkInterno.Size = new System.Drawing.Size(59, 17);
            this.ChkInterno.TabIndex = 84;
            this.ChkInterno.Text = "Interno";
            this.ChkInterno.UseVisualStyleBackColor = true;
            this.ChkInterno.CheckStateChanged += new System.EventHandler(this.ChkInterno_CheckStateChanged);
            // 
            // LblRequerimirnto
            // 
            this.LblRequerimirnto.AutoSize = true;
            this.LblRequerimirnto.Location = new System.Drawing.Point(8, 247);
            this.LblRequerimirnto.Name = "LblRequerimirnto";
            this.LblRequerimirnto.Size = new System.Drawing.Size(150, 13);
            this.LblRequerimirnto.TabIndex = 83;
            this.LblRequerimirnto.Text = "Seleccione los requerimientos:";
            // 
            // DgvRequerimentos
            // 
            this.DgvRequerimentos.AllowUserToAddRows = false;
            this.DgvRequerimentos.AllowUserToResizeRows = false;
            this.DgvRequerimentos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvRequerimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRequerimentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_req,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.origen});
            this.DgvRequerimentos.Location = new System.Drawing.Point(7, 273);
            this.DgvRequerimentos.MultiSelect = false;
            this.DgvRequerimentos.Name = "DgvRequerimentos";
            this.DgvRequerimentos.RowHeadersVisible = false;
            this.DgvRequerimentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRequerimentos.Size = new System.Drawing.Size(454, 209);
            this.DgvRequerimentos.TabIndex = 82;
            this.DgvRequerimentos.TabStop = false;
            this.DgvRequerimentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequerimentos_CellContentClick);
            this.DgvRequerimentos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvRequerimentos_CellMouseDown);
            this.DgvRequerimentos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvRequerimentos_MouseClick);
            // 
            // id_req
            // 
            this.id_req.HeaderText = "ID";
            this.id_req.Name = "id_req";
            this.id_req.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "False";
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.TrueValue = "True";
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 90;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // origen
            // 
            this.origen.HeaderText = "Origen";
            this.origen.Name = "origen";
            this.origen.ReadOnly = true;
            // 
            // LblVistas
            // 
            this.LblVistas.AutoSize = true;
            this.LblVistas.Location = new System.Drawing.Point(10, 9);
            this.LblVistas.Name = "LblVistas";
            this.LblVistas.Size = new System.Drawing.Size(237, 13);
            this.LblVistas.TabIndex = 81;
            this.LblVistas.Text = "Seleccione las vistas a mostrar en el documento:";
            // 
            // DgvImagenModulo
            // 
            this.DgvImagenModulo.AllowUserToAddRows = false;
            this.DgvImagenModulo.AllowUserToResizeRows = false;
            this.DgvImagenModulo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvImagenModulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvImagenModulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.seleccion,
            this.vista_detalle,
            this.descripcion,
            this.vista_previa});
            this.DgvImagenModulo.Location = new System.Drawing.Point(9, 25);
            this.DgvImagenModulo.MultiSelect = false;
            this.DgvImagenModulo.Name = "DgvImagenModulo";
            this.DgvImagenModulo.RowHeadersVisible = false;
            this.DgvImagenModulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvImagenModulo.Size = new System.Drawing.Size(454, 209);
            this.DgvImagenModulo.TabIndex = 80;
            this.DgvImagenModulo.TabStop = false;
            this.DgvImagenModulo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvImagenModulo_CellContentClick);
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
            // vista_detalle
            // 
            this.vista_detalle.HeaderText = "Vista";
            this.vista_detalle.Name = "vista_detalle";
            this.vista_detalle.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 90;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // vista_previa
            // 
            this.vista_previa.HeaderText = "Vista Previa";
            this.vista_previa.Name = "vista_previa";
            this.vista_previa.ReadOnly = true;
            this.vista_previa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vista_previa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.VisorPDF);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.BtnGuardar);
            this.splitContainer2.Panel2.Controls.Add(this.BtnSalir);
            this.splitContainer2.Panel2.Controls.Add(this.BtnActualizar);
            this.splitContainer2.Size = new System.Drawing.Size(898, 720);
            this.splitContainer2.SplitterDistance = 641;
            this.splitContainer2.TabIndex = 0;
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(898, 641);
            this.VisorPDF.TabIndex = 1;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnGuardar.Image = global::CB_Base.Properties.Resources.User_Interface_Save_As_icon;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(580, 0);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(159, 75);
            this.BtnGuardar.TabIndex = 20;
            this.BtnGuardar.Text = "            Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnActualizar.Location = new System.Drawing.Point(0, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(159, 75);
            this.BtnActualizar.TabIndex = 57;
            this.BtnActualizar.Text = "Actualizar PDF";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // FrmAceptacionDisenoMecanico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(1370, 720);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmAceptacionDisenoMecanico";
            this.Text = "Aceptacion de diseño mecanico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAceptacionDisenoMecanico_Load);
            this.MenuTerminosPago.ResumeLayout(false);
            this.MenuRequerimiento.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequerimentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvImagenModulo)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.OpenFileDialog SeleccionarAdjunto;
        private System.Windows.Forms.ContextMenuStrip MenuTerminosPago;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volverADefaultToolStripMenuItem;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LblVistas;
        private System.Windows.Forms.DataGridView DgvImagenModulo;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn vista;
        private System.Windows.Forms.CheckBox ChkCliente;
        private System.Windows.Forms.CheckBox ChkInterno;
        private System.Windows.Forms.Label LblRequerimirnto;
        private System.Windows.Forms.DataGridView DgvRequerimentos;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox ChkModoFalla;
        private System.Windows.Forms.CheckBox ChkSecuencia;
        private System.Windows.Forms.CheckBox ChkElemento;
        private System.Windows.Forms.Label LblModulos;
        private System.Windows.Forms.ContextMenuStrip MenuRequerimiento;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarNadaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_req;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn vista_detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewImageColumn vista_previa;
    }
}
namespace CB
{
    partial class FrmAgregarPartidaPO
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblCotizacionesVigentes = new System.Windows.Forms.SplitContainer();
            this.BtnBuscarPO = new System.Windows.Forms.Button();
            this.BtnBuscarRFQ = new System.Windows.Forms.Button();
            this.NumPO = new System.Windows.Forms.NumericUpDown();
            this.LblProveedorPO = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NumRFQ = new System.Windows.Forms.NumericUpDown();
            this.LblUsuarioRFQ = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnOpcionesSeleccion = new System.Windows.Forms.Button();
            this.menuOpcionesSeleccion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarNadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colapsarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TvRequisiciones = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDetalles = new System.Windows.Forms.TextBox();
            this.LblElementoSeleccionado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LblCotizacionesVigentes)).BeginInit();
            this.LblCotizacionesVigentes.Panel1.SuspendLayout();
            this.LblCotizacionesVigentes.Panel2.SuspendLayout();
            this.LblCotizacionesVigentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRFQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuOpcionesSeleccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(995, 23);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "AGREGAR PARTIDAS A LA ORDEN DE COMPRA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // LblCotizacionesVigentes
            // 
            this.LblCotizacionesVigentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCotizacionesVigentes.Location = new System.Drawing.Point(0, 23);
            this.LblCotizacionesVigentes.Name = "LblCotizacionesVigentes";
            this.LblCotizacionesVigentes.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LblCotizacionesVigentes.Panel1
            // 
            this.LblCotizacionesVigentes.Panel1.Controls.Add(this.BtnBuscarPO);
            this.LblCotizacionesVigentes.Panel1.Controls.Add(this.BtnBuscarRFQ);
            this.LblCotizacionesVigentes.Panel1.Controls.Add(this.NumPO);
            this.LblCotizacionesVigentes.Panel1.Controls.Add(this.LblProveedorPO);
            this.LblCotizacionesVigentes.Panel1.Controls.Add(this.label4);
            this.LblCotizacionesVigentes.Panel1.Controls.Add(this.NumRFQ);
            this.LblCotizacionesVigentes.Panel1.Controls.Add(this.LblUsuarioRFQ);
            this.LblCotizacionesVigentes.Panel1.Controls.Add(this.label5);
            // 
            // LblCotizacionesVigentes.Panel2
            // 
            this.LblCotizacionesVigentes.Panel2.Controls.Add(this.splitContainer2);
            this.LblCotizacionesVigentes.Size = new System.Drawing.Size(995, 563);
            this.LblCotizacionesVigentes.SplitterDistance = 88;
            this.LblCotizacionesVigentes.TabIndex = 57;
            // 
            // BtnBuscarPO
            // 
            this.BtnBuscarPO.Location = new System.Drawing.Point(424, 53);
            this.BtnBuscarPO.Name = "BtnBuscarPO";
            this.BtnBuscarPO.Size = new System.Drawing.Size(134, 23);
            this.BtnBuscarPO.TabIndex = 25;
            this.BtnBuscarPO.Text = "Buscar";
            this.BtnBuscarPO.UseVisualStyleBackColor = true;
            this.BtnBuscarPO.Click += new System.EventHandler(this.BtnBuscarPO_Click);
            // 
            // BtnBuscarRFQ
            // 
            this.BtnBuscarRFQ.Location = new System.Drawing.Point(11, 53);
            this.BtnBuscarRFQ.Name = "BtnBuscarRFQ";
            this.BtnBuscarRFQ.Size = new System.Drawing.Size(134, 23);
            this.BtnBuscarRFQ.TabIndex = 24;
            this.BtnBuscarRFQ.Text = "Buscar";
            this.BtnBuscarRFQ.UseVisualStyleBackColor = true;
            this.BtnBuscarRFQ.Click += new System.EventHandler(this.BtnBuscarRFQ_Click);
            // 
            // NumPO
            // 
            this.NumPO.Enabled = false;
            this.NumPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.NumPO.Location = new System.Drawing.Point(425, 24);
            this.NumPO.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumPO.Name = "NumPO";
            this.NumPO.Size = new System.Drawing.Size(133, 29);
            this.NumPO.TabIndex = 23;
            this.NumPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPO.ValueChanged += new System.EventHandler(this.NumPO_ValueChanged);
            // 
            // LblProveedorPO
            // 
            this.LblProveedorPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProveedorPO.Location = new System.Drawing.Point(564, 22);
            this.LblProveedorPO.Name = "LblProveedorPO";
            this.LblProveedorPO.Size = new System.Drawing.Size(367, 32);
            this.LblProveedorPO.TabIndex = 22;
            this.LblProveedorPO.Text = "SELECCIONA UNA PO";
            this.LblProveedorPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "PO destino:";
            // 
            // NumRFQ
            // 
            this.NumRFQ.Enabled = false;
            this.NumRFQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.NumRFQ.Location = new System.Drawing.Point(12, 23);
            this.NumRFQ.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumRFQ.Name = "NumRFQ";
            this.NumRFQ.Size = new System.Drawing.Size(133, 29);
            this.NumRFQ.TabIndex = 20;
            this.NumRFQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumRFQ.ValueChanged += new System.EventHandler(this.NumRFQ_ValueChanged);
            // 
            // LblUsuarioRFQ
            // 
            this.LblUsuarioRFQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioRFQ.Location = new System.Drawing.Point(151, 21);
            this.LblUsuarioRFQ.Name = "LblUsuarioRFQ";
            this.LblUsuarioRFQ.Size = new System.Drawing.Size(264, 32);
            this.LblUsuarioRFQ.TabIndex = 18;
            this.LblUsuarioRFQ.Text = "SELECCIONA UN RFQ";
            this.LblUsuarioRFQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblUsuarioRFQ.Click += new System.EventHandler(this.LblUsuarioRFQ_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "RFQ origen:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.BtnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.BtnAgregar);
            this.splitContainer2.Size = new System.Drawing.Size(995, 471);
            this.splitContainer2.SplitterDistance = 812;
            this.splitContainer2.TabIndex = 56;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnOpcionesSeleccion);
            this.splitContainer1.Panel1.Controls.Add(this.TvRequisiciones);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TxtDetalles);
            this.splitContainer1.Panel2.Controls.Add(this.LblElementoSeleccionado);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(812, 471);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.TabIndex = 18;
            // 
            // BtnOpcionesSeleccion
            // 
            this.BtnOpcionesSeleccion.ContextMenuStrip = this.menuOpcionesSeleccion;
            this.BtnOpcionesSeleccion.Location = new System.Drawing.Point(317, 11);
            this.BtnOpcionesSeleccion.Name = "BtnOpcionesSeleccion";
            this.BtnOpcionesSeleccion.Size = new System.Drawing.Size(100, 23);
            this.BtnOpcionesSeleccion.TabIndex = 18;
            this.BtnOpcionesSeleccion.Text = "Opciones";
            this.BtnOpcionesSeleccion.UseVisualStyleBackColor = true;
            this.BtnOpcionesSeleccion.Click += new System.EventHandler(this.BtnOpciones_Click);
            // 
            // menuOpcionesSeleccion
            // 
            this.menuOpcionesSeleccion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarTodoToolStripMenuItem,
            this.seleccionarNadaToolStripMenuItem,
            this.expandirToolStripMenuItem,
            this.colapsarToolStripMenuItem});
            this.menuOpcionesSeleccion.Name = "menuOpcionesSeleccion";
            this.menuOpcionesSeleccion.Size = new System.Drawing.Size(168, 92);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todos";
            this.seleccionarTodoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarTodoToolStripMenuItem_Click);
            // 
            // seleccionarNadaToolStripMenuItem
            // 
            this.seleccionarNadaToolStripMenuItem.Name = "seleccionarNadaToolStripMenuItem";
            this.seleccionarNadaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.seleccionarNadaToolStripMenuItem.Text = "Seleccionar nada";
            this.seleccionarNadaToolStripMenuItem.Click += new System.EventHandler(this.seleccionarNadaToolStripMenuItem_Click);
            // 
            // expandirToolStripMenuItem
            // 
            this.expandirToolStripMenuItem.Name = "expandirToolStripMenuItem";
            this.expandirToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.expandirToolStripMenuItem.Text = "Expandir";
            this.expandirToolStripMenuItem.Click += new System.EventHandler(this.expandirToolStripMenuItem_Click);
            // 
            // colapsarToolStripMenuItem
            // 
            this.colapsarToolStripMenuItem.Name = "colapsarToolStripMenuItem";
            this.colapsarToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.colapsarToolStripMenuItem.Text = "Colapsar";
            this.colapsarToolStripMenuItem.Click += new System.EventHandler(this.colapsarToolStripMenuItem_Click);
            // 
            // TvRequisiciones
            // 
            this.TvRequisiciones.CheckBoxes = true;
            this.TvRequisiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvRequisiciones.Location = new System.Drawing.Point(0, 42);
            this.TvRequisiciones.Name = "TvRequisiciones";
            this.TvRequisiciones.Size = new System.Drawing.Size(417, 429);
            this.TvRequisiciones.TabIndex = 17;
            this.TvRequisiciones.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvRequisiciones_BeforeCheck);
            this.TvRequisiciones.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvRequisiciones_AfterCheck);
            this.TvRequisiciones.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvRequisiciones_AfterSelect);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 42);
            this.label1.TabIndex = 16;
            this.label1.Text = "Desglose por requisiciones:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtDetalles
            // 
            this.TxtDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDetalles.Location = new System.Drawing.Point(0, 66);
            this.TxtDetalles.Multiline = true;
            this.TxtDetalles.Name = "TxtDetalles";
            this.TxtDetalles.ReadOnly = true;
            this.TxtDetalles.Size = new System.Drawing.Size(391, 405);
            this.TxtDetalles.TabIndex = 18;
            // 
            // LblElementoSeleccionado
            // 
            this.LblElementoSeleccionado.BackColor = System.Drawing.Color.Black;
            this.LblElementoSeleccionado.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblElementoSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblElementoSeleccionado.ForeColor = System.Drawing.Color.White;
            this.LblElementoSeleccionado.Location = new System.Drawing.Point(0, 42);
            this.LblElementoSeleccionado.Name = "LblElementoSeleccionado";
            this.LblElementoSeleccionado.Size = new System.Drawing.Size(391, 24);
            this.LblElementoSeleccionado.TabIndex = 19;
            this.LblElementoSeleccionado.Text = "SELECCIONA UN ELEMENTO";
            this.LblElementoSeleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 42);
            this.label2.TabIndex = 17;
            this.label2.Text = "Detalles:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(0, 42);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(179, 42);
            this.BtnCancelar.TabIndex = 54;
            this.BtnCancelar.Text = "Salir";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAgregar.Enabled = false;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(0, 0);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(179, 42);
            this.BtnAgregar.TabIndex = 55;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // FrmAgregarPartidaPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 586);
            this.ControlBox = false;
            this.Controls.Add(this.LblCotizacionesVigentes);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarPartidaPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar partidas a la orden de compra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAgregarPartidaPO_Load);
            this.LblCotizacionesVigentes.Panel1.ResumeLayout(false);
            this.LblCotizacionesVigentes.Panel1.PerformLayout();
            this.LblCotizacionesVigentes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LblCotizacionesVigentes)).EndInit();
            this.LblCotizacionesVigentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRFQ)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuOpcionesSeleccion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.SplitContainer LblCotizacionesVigentes;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView TvRequisiciones;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TxtDetalles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblUsuarioRFQ;
        private System.Windows.Forms.Label LblElementoSeleccionado;
        private System.Windows.Forms.NumericUpDown NumRFQ;
        private System.Windows.Forms.Button BtnOpcionesSeleccion;
        private System.Windows.Forms.ContextMenuStrip menuOpcionesSeleccion;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarNadaToolStripMenuItem;
        private System.Windows.Forms.Button BtnBuscarPO;
        private System.Windows.Forms.Button BtnBuscarRFQ;
        private System.Windows.Forms.NumericUpDown NumPO;
        private System.Windows.Forms.Label LblProveedorPO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem expandirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colapsarToolStripMenuItem;
    }
}
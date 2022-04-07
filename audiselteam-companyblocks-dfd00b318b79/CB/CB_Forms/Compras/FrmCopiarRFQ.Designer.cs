namespace CB
{
    partial class FrmCopiarRFQ
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LblProveedorRFQ = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BtnCopiar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSeleccionarNada = new System.Windows.Forms.Button();
            this.BtnSeleccionarTodos = new System.Windows.Forms.Button();
            this.BtnBuscarRFQ = new System.Windows.Forms.Button();
            this.NumRFQ = new System.Windows.Forms.NumericUpDown();
            this.LblUsuarioRFQ = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DgvPartidas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoRFQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RFQExistenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumRFQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPartidas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(837, 23);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "COPIAR RFQ";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LblProveedorRFQ);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.BtnBuscarRFQ);
            this.splitContainer1.Panel1.Controls.Add(this.NumRFQ);
            this.splitContainer1.Panel1.Controls.Add(this.LblUsuarioRFQ);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvPartidas);
            this.splitContainer1.Size = new System.Drawing.Size(837, 406);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 29;
            // 
            // LblProveedorRFQ
            // 
            this.LblProveedorRFQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProveedorRFQ.Location = new System.Drawing.Point(148, 20);
            this.LblProveedorRFQ.Name = "LblProveedorRFQ";
            this.LblProveedorRFQ.Size = new System.Drawing.Size(264, 32);
            this.LblProveedorRFQ.TabIndex = 91;
            this.LblProveedorRFQ.Text = "SELECCIONA UN RFQ";
            this.LblProveedorRFQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.Location = new System.Drawing.Point(530, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BtnCopiar);
            this.splitContainer2.Panel1.Controls.Add(this.BtnCancelar);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.BtnSeleccionarNada);
            this.splitContainer2.Panel2.Controls.Add(this.BtnSeleccionarTodos);
            this.splitContainer2.Size = new System.Drawing.Size(307, 93);
            this.splitContainer2.SplitterDistance = 61;
            this.splitContainer2.TabIndex = 90;
            // 
            // BtnCopiar
            // 
            this.BtnCopiar.ContextMenuStrip = this.contextMenuStrip1;
            this.BtnCopiar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCopiar.Enabled = false;
            this.BtnCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCopiar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCopiar.Location = new System.Drawing.Point(1, 0);
            this.BtnCopiar.Name = "BtnCopiar";
            this.BtnCopiar.Size = new System.Drawing.Size(153, 61);
            this.BtnCopiar.TabIndex = 75;
            this.BtnCopiar.Text = "Copiar";
            this.BtnCopiar.UseVisualStyleBackColor = true;
            this.BtnCopiar.Click += new System.EventHandler(this.BtnCopiar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(154, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(153, 61);
            this.BtnCancelar.TabIndex = 53;
            this.BtnCancelar.Text = "       Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnSeleccionarNada
            // 
            this.BtnSeleccionarNada.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSeleccionarNada.Location = new System.Drawing.Point(121, 0);
            this.BtnSeleccionarNada.Name = "BtnSeleccionarNada";
            this.BtnSeleccionarNada.Size = new System.Drawing.Size(121, 28);
            this.BtnSeleccionarNada.TabIndex = 77;
            this.BtnSeleccionarNada.Text = "Seleccionar nada";
            this.BtnSeleccionarNada.UseVisualStyleBackColor = true;
            this.BtnSeleccionarNada.Click += new System.EventHandler(this.BtnSeleccionarNada_Click);
            // 
            // BtnSeleccionarTodos
            // 
            this.BtnSeleccionarTodos.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSeleccionarTodos.Location = new System.Drawing.Point(0, 0);
            this.BtnSeleccionarTodos.Name = "BtnSeleccionarTodos";
            this.BtnSeleccionarTodos.Size = new System.Drawing.Size(121, 28);
            this.BtnSeleccionarTodos.TabIndex = 76;
            this.BtnSeleccionarTodos.Text = "Seleccionar todos";
            this.BtnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.BtnSeleccionarTodos.Click += new System.EventHandler(this.BtnSeleccionarTodos_Click);
            // 
            // BtnBuscarRFQ
            // 
            this.BtnBuscarRFQ.Location = new System.Drawing.Point(8, 53);
            this.BtnBuscarRFQ.Name = "BtnBuscarRFQ";
            this.BtnBuscarRFQ.Size = new System.Drawing.Size(134, 23);
            this.BtnBuscarRFQ.TabIndex = 32;
            this.BtnBuscarRFQ.Text = "Buscar";
            this.BtnBuscarRFQ.UseVisualStyleBackColor = true;
            this.BtnBuscarRFQ.Click += new System.EventHandler(this.BtnBuscarRFQ_Click);
            // 
            // NumRFQ
            // 
            this.NumRFQ.Enabled = false;
            this.NumRFQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.NumRFQ.Location = new System.Drawing.Point(9, 23);
            this.NumRFQ.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumRFQ.Name = "NumRFQ";
            this.NumRFQ.Size = new System.Drawing.Size(133, 29);
            this.NumRFQ.TabIndex = 31;
            this.NumRFQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumRFQ.ValueChanged += new System.EventHandler(this.NumRFQ_ValueChanged);
            // 
            // LblUsuarioRFQ
            // 
            this.LblUsuarioRFQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioRFQ.Location = new System.Drawing.Point(148, 53);
            this.LblUsuarioRFQ.Name = "LblUsuarioRFQ";
            this.LblUsuarioRFQ.Size = new System.Drawing.Size(264, 32);
            this.LblUsuarioRFQ.TabIndex = 30;
            this.LblUsuarioRFQ.Text = "SELECCIONA UN RFQ";
            this.LblUsuarioRFQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "RFQ origen:";
            // 
            // DgvPartidas
            // 
            this.DgvPartidas.AllowUserToAddRows = false;
            this.DgvPartidas.AllowUserToDeleteRows = false;
            this.DgvPartidas.AllowUserToResizeColumns = false;
            this.DgvPartidas.AllowUserToResizeRows = false;
            this.DgvPartidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPartidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.seleccion,
            this.numero_parte,
            this.fabricante,
            this.descripcion});
            this.DgvPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPartidas.Location = new System.Drawing.Point(0, 0);
            this.DgvPartidas.MultiSelect = false;
            this.DgvPartidas.Name = "DgvPartidas";
            this.DgvPartidas.RowHeadersVisible = false;
            this.DgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPartidas.Size = new System.Drawing.Size(837, 309);
            this.DgvPartidas.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 70;
            // 
            // seleccion
            // 
            this.seleccion.HeaderText = "";
            this.seleccion.Name = "seleccion";
            this.seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seleccion.Width = 30;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle10;
            this.numero_parte.HeaderText = "Número de parte";
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.Width = 150;
            // 
            // fabricante
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fabricante.DefaultCellStyle = dataGridViewCellStyle11;
            this.fabricante.HeaderText = "Fabricante";
            this.fabricante.Name = "fabricante";
            this.fabricante.Width = 150;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle12;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoRFQToolStripMenuItem,
            this.RFQExistenteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // nuevoRFQToolStripMenuItem
            // 
            this.nuevoRFQToolStripMenuItem.Name = "nuevoRFQToolStripMenuItem";
            this.nuevoRFQToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoRFQToolStripMenuItem.Text = "Nuevo RFQ";
            this.nuevoRFQToolStripMenuItem.Click += new System.EventHandler(this.nuevoRFQToolStripMenuItem_Click);
            // 
            // RFQExistenteToolStripMenuItem
            // 
            this.RFQExistenteToolStripMenuItem.Name = "RFQExistenteToolStripMenuItem";
            this.RFQExistenteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RFQExistenteToolStripMenuItem.Text = "RFQ existente";
            this.RFQExistenteToolStripMenuItem.Click += new System.EventHandler(this.RFQExistenteToolStripMenuItem_Click);
            // 
            // FrmCopiarRFQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 429);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCopiarRFQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar RFQ";
            this.Load += new System.EventHandler(this.FrmCopiarRFQ_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumRFQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPartidas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BtnBuscarRFQ;
        private System.Windows.Forms.NumericUpDown NumRFQ;
        private System.Windows.Forms.Label LblUsuarioRFQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DgvPartidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button BtnCopiar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnSeleccionarNada;
        private System.Windows.Forms.Button BtnSeleccionarTodos;
        private System.Windows.Forms.Label LblProveedorRFQ;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoRFQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RFQExistenteToolStripMenuItem;
    }
}
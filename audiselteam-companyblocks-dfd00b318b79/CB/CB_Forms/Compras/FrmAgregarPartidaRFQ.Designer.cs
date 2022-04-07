namespace CB
{
    partial class FrmAgregarPartidaRFQ
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DateHasta = new System.Windows.Forms.DateTimePicker();
            this.DateDesde = new System.Windows.Forms.DateTimePicker();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnFiltrarDatos = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSeleccionarNada = new System.Windows.Forms.Button();
            this.BtnSeleccionarTodos = new System.Windows.Forms.Button();
            this.LblRFQ = new System.Windows.Forms.Label();
            this.DgvNumerosParte = new System.Windows.Forms.DataGridView();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_estimada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNumerosParte)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1751, 28);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "AGREGAR PARTIDAS AL RFQ";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.DateHasta);
            this.splitContainer1.Panel1.Controls.Add(this.DateDesde);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.LblRFQ);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvNumerosParte);
            this.splitContainer1.Size = new System.Drawing.Size(1751, 542);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 93;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 92;
            this.label1.Text = "Desde:";
            // 
            // DateHasta
            // 
            this.DateHasta.Location = new System.Drawing.Point(29, 100);
            this.DateHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateHasta.Name = "DateHasta";
            this.DateHasta.Size = new System.Drawing.Size(259, 22);
            this.DateHasta.TabIndex = 91;
            this.DateHasta.ValueChanged += new System.EventHandler(this.DateHasta_ValueChanged);
            this.DateHasta.Leave += new System.EventHandler(this.DateHasta_Leave);
            // 
            // DateDesde
            // 
            this.DateDesde.Location = new System.Drawing.Point(29, 43);
            this.DateDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateDesde.Name = "DateDesde";
            this.DateDesde.Size = new System.Drawing.Size(259, 22);
            this.DateDesde.TabIndex = 90;
            this.DateDesde.ValueChanged += new System.EventHandler(this.DateDesde_ValueChanged);
            this.DateDesde.Leave += new System.EventHandler(this.DateDesde_Leave);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.Location = new System.Drawing.Point(992, 37);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BtnActualizar);
            this.splitContainer2.Panel1.Controls.Add(this.BtnFiltrarDatos);
            this.splitContainer2.Panel1.Controls.Add(this.BtnAgregar);
            this.splitContainer2.Panel1.Controls.Add(this.BtnCancelar);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.BtnSeleccionarNada);
            this.splitContainer2.Panel2.Controls.Add(this.BtnSeleccionarTodos);
            this.splitContainer2.Size = new System.Drawing.Size(759, 85);
            this.splitContainer2.SplitterDistance = 55;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 89;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.update;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(0, 0);
            this.BtnActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(171, 55);
            this.BtnActualizar.TabIndex = 94;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnFiltrarDatos
            // 
            this.BtnFiltrarDatos.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFiltrarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltrarDatos.Image = global::CB_Base.Properties.Resources.Filter_List_icon;
            this.BtnFiltrarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFiltrarDatos.Location = new System.Drawing.Point(171, 0);
            this.BtnFiltrarDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnFiltrarDatos.Name = "BtnFiltrarDatos";
            this.BtnFiltrarDatos.Size = new System.Drawing.Size(180, 55);
            this.BtnFiltrarDatos.TabIndex = 90;
            this.BtnFiltrarDatos.Text = "       Filtrar";
            this.BtnFiltrarDatos.UseVisualStyleBackColor = true;
            this.BtnFiltrarDatos.Click += new System.EventHandler(this.BtnFiltrarDatos_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(351, 0);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(204, 55);
            this.BtnAgregar.TabIndex = 75;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(555, 0);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(204, 55);
            this.BtnCancelar.TabIndex = 53;
            this.BtnCancelar.Text = "       Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnSeleccionarNada
            // 
            this.BtnSeleccionarNada.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSeleccionarNada.Location = new System.Drawing.Point(161, 0);
            this.BtnSeleccionarNada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnSeleccionarNada.Name = "BtnSeleccionarNada";
            this.BtnSeleccionarNada.Size = new System.Drawing.Size(161, 25);
            this.BtnSeleccionarNada.TabIndex = 77;
            this.BtnSeleccionarNada.Text = "Seleccionar nada";
            this.BtnSeleccionarNada.UseVisualStyleBackColor = true;
            this.BtnSeleccionarNada.Click += new System.EventHandler(this.BtnSeleccionarNada_Click);
            // 
            // BtnSeleccionarTodos
            // 
            this.BtnSeleccionarTodos.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSeleccionarTodos.Location = new System.Drawing.Point(0, 0);
            this.BtnSeleccionarTodos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnSeleccionarTodos.Name = "BtnSeleccionarTodos";
            this.BtnSeleccionarTodos.Size = new System.Drawing.Size(161, 25);
            this.BtnSeleccionarTodos.TabIndex = 76;
            this.BtnSeleccionarTodos.Text = "Seleccionar todos";
            this.BtnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.BtnSeleccionarTodos.Click += new System.EventHandler(this.BtnSeleccionarTodos_Click);
            // 
            // LblRFQ
            // 
            this.LblRFQ.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblRFQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRFQ.Location = new System.Drawing.Point(0, 0);
            this.LblRFQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRFQ.Name = "LblRFQ";
            this.LblRFQ.Size = new System.Drawing.Size(1751, 37);
            this.LblRFQ.TabIndex = 78;
            this.LblRFQ.Text = "RFQ #XX - PROVEEDOR";
            this.LblRFQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DgvNumerosParte
            // 
            this.DgvNumerosParte.AllowUserToAddRows = false;
            this.DgvNumerosParte.AllowUserToDeleteRows = false;
            this.DgvNumerosParte.AllowUserToResizeRows = false;
            this.DgvNumerosParte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvNumerosParte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvNumerosParte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccion,
            this.numero_parte,
            this.fabricante,
            this.descripcion,
            this.cantidad_estimada,
            this.unidades});
            this.DgvNumerosParte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvNumerosParte.Location = new System.Drawing.Point(0, 0);
            this.DgvNumerosParte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DgvNumerosParte.Name = "DgvNumerosParte";
            this.DgvNumerosParte.RowHeadersVisible = false;
            this.DgvNumerosParte.RowHeadersWidth = 51;
            this.DgvNumerosParte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvNumerosParte.Size = new System.Drawing.Size(1751, 415);
            this.DgvNumerosParte.TabIndex = 8;
            // 
            // seleccion
            // 
            this.seleccion.HeaderText = "";
            this.seleccion.MinimumWidth = 6;
            this.seleccion.Name = "seleccion";
            this.seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seleccion.Width = 30;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle1;
            this.numero_parte.HeaderText = "Número de parte";
            this.numero_parte.MinimumWidth = 6;
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.Width = 175;
            // 
            // fabricante
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fabricante.DefaultCellStyle = dataGridViewCellStyle2;
            this.fabricante.HeaderText = "Fabricante";
            this.fabricante.MinimumWidth = 6;
            this.fabricante.Name = "fabricante";
            this.fabricante.Width = 150;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle3;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            // 
            // cantidad_estimada
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad_estimada.DefaultCellStyle = dataGridViewCellStyle4;
            this.cantidad_estimada.HeaderText = "Cantidad estimada";
            this.cantidad_estimada.MinimumWidth = 6;
            this.cantidad_estimada.Name = "cantidad_estimada";
            this.cantidad_estimada.Width = 125;
            // 
            // unidades
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.unidades.DefaultCellStyle = dataGridViewCellStyle5;
            this.unidades.HeaderText = "Unidades";
            this.unidades.MinimumWidth = 6;
            this.unidades.Name = "unidades";
            this.unidades.Width = 125;
            // 
            // FrmAgregarPartidaRFQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1751, 570);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAgregarPartidaRFQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarPartidaRFQ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAgregarPartidaRFQ_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvNumerosParte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LblRFQ;
        private System.Windows.Forms.Button BtnSeleccionarNada;
        private System.Windows.Forms.Button BtnSeleccionarTodos;
        private System.Windows.Forms.DataGridView DgvNumerosParte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_estimada;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidades;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button BtnFiltrarDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateHasta;
        private System.Windows.Forms.DateTimePicker DateDesde;
        private System.Windows.Forms.Button BtnActualizar;
    }
}
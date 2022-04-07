namespace CB
{
    partial class FrmDesvincularProveedorFavorito
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSeleccionarProveedor = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.DgvRequisiciones = new System.Windows.Forms.DataGridView();
            this.seleccionRequisicion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idRequisicionCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyectoRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSeleccionarTodo = new System.Windows.Forms.Button();
            this.BtnSeleccionarNada = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequisiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtProveedor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtNumeroParte);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 59);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Proveedor:";
            // 
            // TxtProveedor
            // 
            this.TxtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProveedor.Location = new System.Drawing.Point(9, 21);
            this.TxtProveedor.Name = "TxtProveedor";
            this.TxtProveedor.ReadOnly = true;
            this.TxtProveedor.Size = new System.Drawing.Size(327, 26);
            this.TxtProveedor.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Número de parte:";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(342, 21);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(315, 26);
            this.TxtNumeroParte.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSeleccionarNada);
            this.panel2.Controls.Add(this.BtnSeleccionarTodo);
            this.panel2.Controls.Add(this.BtnSeleccionarProveedor);
            this.panel2.Controls.Add(this.BtnCancelar);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 516);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(669, 70);
            this.panel2.TabIndex = 2;
            // 
            // BtnSeleccionarProveedor
            // 
            this.BtnSeleccionarProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSeleccionarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarProveedor.Location = new System.Drawing.Point(515, 6);
            this.BtnSeleccionarProveedor.Name = "BtnSeleccionarProveedor";
            this.BtnSeleccionarProveedor.Size = new System.Drawing.Size(147, 57);
            this.BtnSeleccionarProveedor.TabIndex = 33;
            this.BtnSeleccionarProveedor.Text = "Seleccionar";
            this.BtnSeleccionarProveedor.UseVisualStyleBackColor = true;
            this.BtnSeleccionarProveedor.Click += new System.EventHandler(this.BtnSeleccionarProveedor_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(362, 6);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(147, 57);
            this.BtnCancelar.TabIndex = 32;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
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
            this.DgvRequisiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvRequisiciones.Location = new System.Drawing.Point(0, 82);
            this.DgvRequisiciones.Name = "DgvRequisiciones";
            this.DgvRequisiciones.RowHeadersVisible = false;
            this.DgvRequisiciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRequisiciones.Size = new System.Drawing.Size(669, 434);
            this.DgvRequisiciones.TabIndex = 34;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idRequisicionCompra.DefaultCellStyle = dataGridViewCellStyle1;
            this.idRequisicionCompra.Frozen = true;
            this.idRequisicionCompra.HeaderText = "ID";
            this.idRequisicionCompra.Name = "idRequisicionCompra";
            this.idRequisicionCompra.ReadOnly = true;
            this.idRequisicionCompra.Width = 70;
            // 
            // cantidadRequisicion
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidadRequisicion.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantidadRequisicion.HeaderText = "Cantidad";
            this.cantidadRequisicion.Name = "cantidadRequisicion";
            this.cantidadRequisicion.Width = 70;
            // 
            // proyectoRequisicion
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.proyectoRequisicion.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatusRequisicion.DefaultCellStyle = dataGridViewCellStyle4;
            this.estatusRequisicion.HeaderText = "Estatus de compra";
            this.estatusRequisicion.Name = "estatusRequisicion";
            this.estatusRequisicion.Width = 175;
            // 
            // BtnSeleccionarTodo
            // 
            this.BtnSeleccionarTodo.Location = new System.Drawing.Point(3, 24);
            this.BtnSeleccionarTodo.Name = "BtnSeleccionarTodo";
            this.BtnSeleccionarTodo.Size = new System.Drawing.Size(133, 23);
            this.BtnSeleccionarTodo.TabIndex = 34;
            this.BtnSeleccionarTodo.Text = "Seleccionar todo";
            this.BtnSeleccionarTodo.UseVisualStyleBackColor = true;
            this.BtnSeleccionarTodo.Click += new System.EventHandler(this.BtnSeleccionarTodo_Click);
            // 
            // BtnSeleccionarNada
            // 
            this.BtnSeleccionarNada.Location = new System.Drawing.Point(142, 24);
            this.BtnSeleccionarNada.Name = "BtnSeleccionarNada";
            this.BtnSeleccionarNada.Size = new System.Drawing.Size(133, 23);
            this.BtnSeleccionarNada.TabIndex = 35;
            this.BtnSeleccionarNada.Text = "Seleccionar nada";
            this.BtnSeleccionarNada.UseVisualStyleBackColor = true;
            this.BtnSeleccionarNada.Click += new System.EventHandler(this.BtnSeleccionarNada_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(669, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "DESVINCULAR REQUISICIONES";
            // 
            // FrmDesvincularProveedorFavorito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 586);
            this.Controls.Add(this.DgvRequisiciones);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDesvincularProveedorFavorito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desvincular requisiciones";
            this.Load += new System.EventHandler(this.FrmConsultarCostoEstimadoRfq_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequisiciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgvRequisiciones;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRequisicionCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyectoRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatusRequisicion;
        private System.Windows.Forms.Button BtnSeleccionarProveedor;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.Button BtnSeleccionarNada;
        private System.Windows.Forms.Button BtnSeleccionarTodo;
    }
}
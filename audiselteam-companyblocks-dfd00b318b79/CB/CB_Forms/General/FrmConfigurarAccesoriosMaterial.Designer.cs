namespace CB
{
    partial class FrmConfigurarAccesoriosMaterial
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblFabricante = new System.Windows.Forms.Label();
            this.LblNumeroDeParte = new System.Windows.Forms.Label();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.DgvOpciones = new System.Windows.Forms.DataGridView();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piezas_requeridas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_accesorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piezas_requeridas_accesorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOpciones)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(962, 25);
            this.LblTitulo.TabIndex = 33;
            this.LblTitulo.Text = "CONFIGURAR ACCESORIOS";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // LblFabricante
            // 
            this.LblFabricante.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFabricante.Location = new System.Drawing.Point(0, 53);
            this.LblFabricante.Name = "LblFabricante";
            this.LblFabricante.Size = new System.Drawing.Size(962, 29);
            this.LblFabricante.TabIndex = 35;
            this.LblFabricante.Text = "FABRICANTE";
            this.LblFabricante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblNumeroDeParte
            // 
            this.LblNumeroDeParte.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroDeParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroDeParte.Location = new System.Drawing.Point(0, 25);
            this.LblNumeroDeParte.Name = "LblNumeroDeParte";
            this.LblNumeroDeParte.Size = new System.Drawing.Size(962, 28);
            this.LblNumeroDeParte.TabIndex = 34;
            this.LblNumeroDeParte.Text = "NUMERO DE PARTE";
            this.LblNumeroDeParte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescripcion.Location = new System.Drawing.Point(0, 111);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(962, 48);
            this.LblDescripcion.TabIndex = 61;
            this.LblDescripcion.Text = "Descripcion";
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(813, 116);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(149, 44);
            this.BtnFinalizar.TabIndex = 60;
            this.BtnFinalizar.Text = "     Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // LblCantidad
            // 
            this.LblCantidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.Location = new System.Drawing.Point(0, 82);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(962, 29);
            this.LblCantidad.TabIndex = 64;
            this.LblCantidad.Text = "CANTIDAD";
            this.LblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DgvOpciones
            // 
            this.DgvOpciones.AllowUserToAddRows = false;
            this.DgvOpciones.AllowUserToDeleteRows = false;
            this.DgvOpciones.AllowUserToResizeColumns = false;
            this.DgvOpciones.AllowUserToResizeRows = false;
            this.DgvOpciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvOpciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvOpciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo,
            this.numero_parte,
            this.descripcion,
            this.piezas_requeridas,
            this.total,
            this.id_accesorio,
            this.piezas_requeridas_accesorio});
            this.DgvOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvOpciones.Location = new System.Drawing.Point(0, 159);
            this.DgvOpciones.MultiSelect = false;
            this.DgvOpciones.Name = "DgvOpciones";
            this.DgvOpciones.RowHeadersVisible = false;
            this.DgvOpciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvOpciones.Size = new System.Drawing.Size(962, 387);
            this.DgvOpciones.TabIndex = 62;
            this.DgvOpciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOpciones_CellValueChanged);
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 200;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle1;
            this.numero_parte.HeaderText = "Número de parte";
            this.numero_parte.Items.AddRange(new object[] {
            "test",
            "otro",
            "mas"});
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numero_parte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.numero_parte.Width = 150;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            // 
            // piezas_requeridas
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.piezas_requeridas.DefaultCellStyle = dataGridViewCellStyle3;
            this.piezas_requeridas.HeaderText = "Piezas requeridas";
            this.piezas_requeridas.Name = "piezas_requeridas";
            this.piezas_requeridas.Width = 80;
            // 
            // total
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.total.DefaultCellStyle = dataGridViewCellStyle4;
            this.total.HeaderText = "Total a ordenar";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 150;
            // 
            // id_accesorio
            // 
            this.id_accesorio.HeaderText = "ID accesorio";
            this.id_accesorio.Name = "id_accesorio";
            this.id_accesorio.Visible = false;
            // 
            // piezas_requeridas_accesorio
            // 
            this.piezas_requeridas_accesorio.HeaderText = "Piezas requeridas";
            this.piezas_requeridas_accesorio.Name = "piezas_requeridas_accesorio";
            this.piezas_requeridas_accesorio.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CB_Base.Properties.Resources.close;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(666, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 44);
            this.button1.TabIndex = 65;
            this.button1.Text = "     Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmConfigurarAccesoriosMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 546);
            this.Controls.Add(this.DgvOpciones);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnFinalizar);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.LblCantidad);
            this.Controls.Add(this.LblFabricante);
            this.Controls.Add(this.LblNumeroDeParte);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConfigurarAccesoriosMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmConfigurarAccesoriosMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvOpciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblFabricante;
        private System.Windows.Forms.Label LblNumeroDeParte;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.DataGridView DgvOpciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewComboBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn piezas_requeridas;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_accesorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn piezas_requeridas_accesorio;
        private System.Windows.Forms.Button button1;
    }
}
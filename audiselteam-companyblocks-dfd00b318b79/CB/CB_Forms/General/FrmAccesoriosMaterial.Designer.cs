namespace CB
{
    partial class FrmAccesoriosMaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblNumeroDeParte = new System.Windows.Forms.Label();
            this.LblFabricante = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbTipoAccesorio = new System.Windows.Forms.ComboBox();
            this.BtnOpciones = new System.Windows.Forms.Button();
            this.menuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarOpciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvOpciones = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piezas_requeridas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOpciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(950, 23);
            this.LblTitulo.TabIndex = 10;
            this.LblTitulo.Text = "ACCESORIOS DEL MATERIAL";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // LblNumeroDeParte
            // 
            this.LblNumeroDeParte.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroDeParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroDeParte.Location = new System.Drawing.Point(0, 23);
            this.LblNumeroDeParte.Name = "LblNumeroDeParte";
            this.LblNumeroDeParte.Size = new System.Drawing.Size(950, 28);
            this.LblNumeroDeParte.TabIndex = 11;
            this.LblNumeroDeParte.Text = "NUMERO DE PARTE";
            this.LblNumeroDeParte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblFabricante
            // 
            this.LblFabricante.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFabricante.Location = new System.Drawing.Point(0, 51);
            this.LblFabricante.Name = "LblFabricante";
            this.LblFabricante.Size = new System.Drawing.Size(950, 29);
            this.LblFabricante.TabIndex = 12;
            this.LblFabricante.Text = "FABRICANTE";
            this.LblFabricante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de accesorio:";
            // 
            // CmbTipoAccesorio
            // 
            this.CmbTipoAccesorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoAccesorio.FormattingEnabled = true;
            this.CmbTipoAccesorio.Items.AddRange(new object[] {
            "OPCION1",
            "OPCION2"});
            this.CmbTipoAccesorio.Location = new System.Drawing.Point(12, 153);
            this.CmbTipoAccesorio.Name = "CmbTipoAccesorio";
            this.CmbTipoAccesorio.Size = new System.Drawing.Size(521, 32);
            this.CmbTipoAccesorio.TabIndex = 4;
            this.CmbTipoAccesorio.SelectedIndexChanged += new System.EventHandler(this.CmbTipoAccesorio_SelectedIndexChanged);
            this.CmbTipoAccesorio.TextChanged += new System.EventHandler(this.CmbTipoAccesorio_TextChanged);
            this.CmbTipoAccesorio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbTipoAccesorio_KeyPress);
            // 
            // BtnOpciones
            // 
            this.BtnOpciones.ContextMenuStrip = this.menuOpciones;
            this.BtnOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpciones.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnOpciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpciones.Location = new System.Drawing.Point(539, 131);
            this.BtnOpciones.Name = "BtnOpciones";
            this.BtnOpciones.Size = new System.Drawing.Size(115, 54);
            this.BtnOpciones.TabIndex = 13;
            this.BtnOpciones.Text = "Opciones";
            this.BtnOpciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpciones.UseVisualStyleBackColor = true;
            this.BtnOpciones.Click += new System.EventHandler(this.BtnOpciones_Click);
            // 
            // menuOpciones
            // 
            this.menuOpciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarOpciónToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Size = new System.Drawing.Size(122, 56);
            // 
            // agregarOpciónToolStripMenuItem
            // 
            this.agregarOpciónToolStripMenuItem.Enabled = false;
            this.agregarOpciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.agregarOpciónToolStripMenuItem.Name = "agregarOpciónToolStripMenuItem";
            this.agregarOpciónToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.agregarOpciónToolStripMenuItem.Text = "Agregar";
            this.agregarOpciónToolStripMenuItem.Click += new System.EventHandler(this.agregarOpciónToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Enabled = false;
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
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
            this.id,
            this.tipo,
            this.numero_parte,
            this.descripcion,
            this.piezas_requeridas});
            this.DgvOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvOpciones.Location = new System.Drawing.Point(0, 23);
            this.DgvOpciones.MultiSelect = false;
            this.DgvOpciones.Name = "DgvOpciones";
            this.DgvOpciones.ReadOnly = true;
            this.DgvOpciones.RowHeadersVisible = false;
            this.DgvOpciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvOpciones.Size = new System.Drawing.Size(950, 419);
            this.DgvOpciones.TabIndex = 14;
            this.DgvOpciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOpciones_CellClick);
            this.DgvOpciones.SelectionChanged += new System.EventHandler(this.DgvOpciones_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
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
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            this.numero_parte.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numero_parte.Width = 150;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // piezas_requeridas
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.piezas_requeridas.DefaultCellStyle = dataGridViewCellStyle3;
            this.piezas_requeridas.HeaderText = "Piezas requeridas";
            this.piezas_requeridas.Name = "piezas_requeridas";
            this.piezas_requeridas.ReadOnly = true;
            this.piezas_requeridas.Width = 80;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(950, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Opciones:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(660, 131);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(129, 53);
            this.BtnCancelar.TabIndex = 58;
            this.BtnCancelar.Text = "     Salir";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescripcion.Location = new System.Drawing.Point(0, 80);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(950, 48);
            this.LblDescripcion.TabIndex = 60;
            this.LblDescripcion.Text = "Descripcion";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnCancelar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvOpciones);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(950, 640);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 61;
            // 
            // FrmAccesoriosMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 640);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.BtnOpciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbTipoAccesorio);
            this.Controls.Add(this.LblFabricante);
            this.Controls.Add(this.LblNumeroDeParte);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAccesoriosMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAccesoriosMaterial";
            this.Load += new System.EventHandler(this.FrmAccesoriosMaterial_Load);
            this.menuOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvOpciones)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblNumeroDeParte;
        private System.Windows.Forms.Label LblFabricante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbTipoAccesorio;
        private System.Windows.Forms.Button BtnOpciones;
        private System.Windows.Forms.DataGridView DgvOpciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ContextMenuStrip menuOpciones;
        private System.Windows.Forms.ToolStripMenuItem agregarOpciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn piezas_requeridas;
    }
}
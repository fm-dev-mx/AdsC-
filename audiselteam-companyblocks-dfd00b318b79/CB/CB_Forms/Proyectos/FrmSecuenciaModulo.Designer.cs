namespace CB
{
    partial class FrmSecuenciaModulo
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
            this.DgvElementos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnOpciones = new System.Windows.Forms.Button();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.LblCategoria = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvElementos)).BeginInit();
            this.MenuOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvElementos
            // 
            this.DgvElementos.AllowUserToAddRows = false;
            this.DgvElementos.AllowUserToDeleteRows = false;
            this.DgvElementos.AllowUserToResizeRows = false;
            this.DgvElementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvElementos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.paso,
            this.elemento,
            this.descripcion});
            this.DgvElementos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvElementos.Location = new System.Drawing.Point(0, 0);
            this.DgvElementos.Name = "DgvElementos";
            this.DgvElementos.ReadOnly = true;
            this.DgvElementos.RowHeadersVisible = false;
            this.DgvElementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvElementos.Size = new System.Drawing.Size(844, 404);
            this.DgvElementos.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // paso
            // 
            this.paso.HeaderText = "Paso";
            this.paso.Name = "paso";
            this.paso.ReadOnly = true;
            // 
            // elemento
            // 
            this.elemento.HeaderText = "Elemento";
            this.elemento.Name = "elemento";
            this.elemento.ReadOnly = true;
            this.elemento.Width = 200;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle1;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(118, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(122, 55);
            this.BtnSalir.TabIndex = 18;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.borrarToolStripMenuItem.Text = "Borrar paso";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editarToolStripMenuItem.Text = "Editar paso";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo paso";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // BtnOpciones
            // 
            this.BtnOpciones.ContextMenuStrip = this.MenuOpciones;
            this.BtnOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpciones.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnOpciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpciones.Location = new System.Drawing.Point(-1, 0);
            this.BtnOpciones.Name = "BtnOpciones";
            this.BtnOpciones.Size = new System.Drawing.Size(119, 55);
            this.BtnOpciones.TabIndex = 19;
            this.BtnOpciones.Text = "Opciones";
            this.BtnOpciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpciones.UseVisualStyleBackColor = true;
            this.BtnOpciones.Click += new System.EventHandler(this.BtnOpciones_Click);
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.borrarToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(153, 92);
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDescripcion.Location = new System.Drawing.Point(0, 55);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(604, 38);
            this.LblDescripcion.TabIndex = 20;
            this.LblDescripcion.Text = "DESCRIPCION DEL MODULO";
            // 
            // LblCategoria
            // 
            this.LblCategoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblCategoria.Location = new System.Drawing.Point(0, 34);
            this.LblCategoria.Name = "LblCategoria";
            this.LblCategoria.Size = new System.Drawing.Size(604, 21);
            this.LblCategoria.TabIndex = 22;
            this.LblCategoria.Text = "CATEGORIA";
            // 
            // LblNombre
            // 
            this.LblNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.Location = new System.Drawing.Point(0, 0);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(604, 34);
            this.LblNombre.TabIndex = 19;
            this.LblNombre.Text = "NOMBRE DEL MODULO";
            this.LblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(604, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BtnOpciones);
            this.splitContainer2.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer2.Size = new System.Drawing.Size(240, 93);
            this.splitContainer2.SplitterDistance = 55;
            this.splitContainer2.TabIndex = 21;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LblDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.LblCategoria);
            this.splitContainer1.Panel1.Controls.Add(this.LblNombre);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvElementos);
            this.splitContainer1.Size = new System.Drawing.Size(844, 501);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 9;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(844, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "SECUENCIA DEL MODULO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmSecuenciaModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 524);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSecuenciaModulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secuencia del módulo";
            this.Load += new System.EventHandler(this.FrmSecuenciaModulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvElementos)).EndInit();
            this.MenuOpciones.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvElementos;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.Button BtnOpciones;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Label LblCategoria;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn paso;
        private System.Windows.Forms.DataGridViewTextBoxColumn elemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}
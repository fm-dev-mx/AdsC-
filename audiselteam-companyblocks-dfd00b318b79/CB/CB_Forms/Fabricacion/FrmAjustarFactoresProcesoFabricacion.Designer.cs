namespace CB
{
    partial class FrmAjustarFactoresProcesoFabricacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAjustarFactoresProcesoFabricacion));
            this.DgvPorcentajes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_factor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuOpcionProceso = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmbFactor = new System.Windows.Forms.ComboBox();
            this.MenuFactor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarFactorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarFactorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxtProceso = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoFactorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarFactorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListaImagen = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPorcentajes)).BeginInit();
            this.MenuOpcionProceso.SuspendLayout();
            this.MenuFactor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvPorcentajes
            // 
            this.DgvPorcentajes.AllowUserToAddRows = false;
            this.DgvPorcentajes.AllowUserToDeleteRows = false;
            this.DgvPorcentajes.AllowUserToResizeRows = false;
            this.DgvPorcentajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPorcentajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.valor_factor,
            this.porcentaje});
            this.DgvPorcentajes.ContextMenuStrip = this.MenuOpcionProceso;
            this.DgvPorcentajes.Location = new System.Drawing.Point(10, 147);
            this.DgvPorcentajes.MultiSelect = false;
            this.DgvPorcentajes.Name = "DgvPorcentajes";
            this.DgvPorcentajes.RowHeadersVisible = false;
            this.DgvPorcentajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPorcentajes.Size = new System.Drawing.Size(588, 221);
            this.DgvPorcentajes.TabIndex = 61;
            this.DgvPorcentajes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPorcentajes_CellValueChanged);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // valor_factor
            // 
            this.valor_factor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valor_factor.HeaderText = "Opción del factor";
            this.valor_factor.Name = "valor_factor";
            this.valor_factor.ReadOnly = true;
            // 
            // porcentaje
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.porcentaje.DefaultCellStyle = dataGridViewCellStyle1;
            this.porcentaje.HeaderText = "Porcentaje de tiempo adicional";
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.ReadOnly = true;
            // 
            // MenuOpcionProceso
            // 
            this.MenuOpcionProceso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuOpcionProceso.Name = "MenuOpcionProceso";
            this.MenuOpcionProceso.Size = new System.Drawing.Size(118, 70);
            this.MenuOpcionProceso.Opening += new System.ComponentModel.CancelEventHandler(this.MenuOpcionProceso_Opening);
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.nuevoToolStripMenuItem1.Text = "Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // CmbFactor
            // 
            this.CmbFactor.ContextMenuStrip = this.MenuFactor;
            this.CmbFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFactor.FormattingEnabled = true;
            this.CmbFactor.Items.AddRange(new object[] {
            "COMPLEJIDAD",
            "MATERIAL",
            "DIMENSIONES",
            "PRESENTACION"});
            this.CmbFactor.Location = new System.Drawing.Point(10, 97);
            this.CmbFactor.Name = "CmbFactor";
            this.CmbFactor.Size = new System.Drawing.Size(587, 32);
            this.CmbFactor.TabIndex = 60;
            this.CmbFactor.SelectedIndexChanged += new System.EventHandler(this.CmbFactor_SelectedIndexChanged);
            // 
            // MenuFactor
            // 
            this.MenuFactor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.editarFactorToolStripMenuItem1,
            this.eliminarFactorToolStripMenuItem});
            this.MenuFactor.Name = "MenuFactor";
            this.MenuFactor.Size = new System.Drawing.Size(153, 92);
            this.MenuFactor.Opening += new System.ComponentModel.CancelEventHandler(this.MenuFactor_Opening);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo factor";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // editarFactorToolStripMenuItem1
            // 
            this.editarFactorToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarFactorToolStripMenuItem1.Name = "editarFactorToolStripMenuItem1";
            this.editarFactorToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.editarFactorToolStripMenuItem1.Text = "Editar factor";
            this.editarFactorToolStripMenuItem1.Click += new System.EventHandler(this.editarFactorToolStripMenuItem1_Click);
            // 
            // eliminarFactorToolStripMenuItem
            // 
            this.eliminarFactorToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarFactorToolStripMenuItem.Name = "eliminarFactorToolStripMenuItem";
            this.eliminarFactorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarFactorToolStripMenuItem.Text = "Eliminar factor";
            this.eliminarFactorToolStripMenuItem.Click += new System.EventHandler(this.eliminarFactorToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Factores:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Proceso de fabricación:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(609, 23);
            this.LblTitulo.TabIndex = 65;
            this.LblTitulo.Text = "AJUSTAR FACTORES DEL PROCEO DE FABRICACION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // TxtProceso
            // 
            this.TxtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProceso.Location = new System.Drawing.Point(10, 48);
            this.TxtProceso.Name = "TxtProceso";
            this.TxtProceso.ReadOnly = true;
            this.TxtProceso.Size = new System.Drawing.Size(587, 29);
            this.TxtProceso.TabIndex = 63;
            this.TxtProceso.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxtProceso_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 67);
            this.panel1.TabIndex = 67;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(474, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 67);
            this.BtnSalir.TabIndex = 67;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoFactorToolStripMenuItem,
            this.editarFactorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 48);
            // 
            // nuevoFactorToolStripMenuItem
            // 
            this.nuevoFactorToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevoFactorToolStripMenuItem.Name = "nuevoFactorToolStripMenuItem";
            this.nuevoFactorToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.nuevoFactorToolStripMenuItem.Text = "Nuevo factor";
            // 
            // editarFactorToolStripMenuItem
            // 
            this.editarFactorToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarFactorToolStripMenuItem.Name = "editarFactorToolStripMenuItem";
            this.editarFactorToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.editarFactorToolStripMenuItem.Text = "Editar factor";
            // 
            // ListaImagen
            // 
            this.ListaImagen.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListaImagen.ImageStream")));
            this.ListaImagen.TransparentColor = System.Drawing.Color.Transparent;
            this.ListaImagen.Images.SetKeyName(0, "Awicons-Vista-Artistic-Add.ico");
            // 
            // FrmAjustarFactoresProcesoFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 441);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DgvPorcentajes);
            this.Controls.Add(this.CmbFactor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.TxtProceso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAjustarFactoresProcesoFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajustar factores de proceso fabricacion";
            this.Load += new System.EventHandler(this.FrmAjustarFactoresProcesoFabricacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPorcentajes)).EndInit();
            this.MenuOpcionProceso.ResumeLayout(false);
            this.MenuFactor.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPorcentajes;
        private System.Windows.Forms.ComboBox CmbFactor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtProceso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoFactorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarFactorToolStripMenuItem;
        private System.Windows.Forms.ImageList ListaImagen;
        private System.Windows.Forms.ContextMenuStrip MenuFactor;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarFactorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarFactorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuOpcionProceso;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_factor;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
    }
}
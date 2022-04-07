namespace CB
{
    partial class FrmAdministrarProductoCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.id_variante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_variantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_componentes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_variante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelFiltros = new System.Windows.Forms.Panel();
            this.LblTituloComponente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbFiltroCliente = new System.Windows.Forms.ComboBox();
            this.DgvProducto = new System.Windows.Forms.DataGridView();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.industria_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clase_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuProducto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).BeginInit();
            this.MenuProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // id_variante
            // 
            this.id_variante.HeaderText = "id";
            this.id_variante.Name = "id_variante";
            this.id_variante.Visible = false;
            // 
            // variante
            // 
            this.variante.HeaderText = "variante";
            this.variante.Name = "variante";
            // 
            // modelo
            // 
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn1.FillWeight = 60F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 75;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // id_variantes
            // 
            this.id_variantes.HeaderText = "id";
            this.id_variantes.Name = "id_variantes";
            this.id_variantes.Visible = false;
            // 
            // id_componentes
            // 
            this.id_componentes.HeaderText = "ID";
            this.id_componentes.Name = "id_componentes";
            this.id_componentes.ReadOnly = true;
            this.id_componentes.Visible = false;
            // 
            // nombre_variante
            // 
            this.nombre_variante.HeaderText = "Nombre variante";
            this.nombre_variante.Name = "nombre_variante";
            // 
            // componentes
            // 
            this.componentes.HeaderText = "componente";
            this.componentes.Name = "componentes";
            this.componentes.ReadOnly = true;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle9;
            this.id.FillWeight = 60F;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 75;
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // numero_proyecto
            // 
            this.numero_proyecto.HeaderText = "proyecto";
            this.numero_proyecto.Name = "numero_proyecto";
            this.numero_proyecto.ReadOnly = true;
            this.numero_proyecto.Visible = false;
            // 
            // PanelFiltros
            // 
            this.PanelFiltros.Controls.Add(this.LblTituloComponente);
            this.PanelFiltros.Controls.Add(this.label3);
            this.PanelFiltros.Controls.Add(this.CmbFiltroCliente);
            this.PanelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelFiltros.Location = new System.Drawing.Point(0, 0);
            this.PanelFiltros.Name = "PanelFiltros";
            this.PanelFiltros.Size = new System.Drawing.Size(1370, 89);
            this.PanelFiltros.TabIndex = 34;
            // 
            // LblTituloComponente
            // 
            this.LblTituloComponente.BackColor = System.Drawing.Color.Black;
            this.LblTituloComponente.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTituloComponente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloComponente.ForeColor = System.Drawing.Color.White;
            this.LblTituloComponente.Location = new System.Drawing.Point(0, 0);
            this.LblTituloComponente.Name = "LblTituloComponente";
            this.LblTituloComponente.Size = new System.Drawing.Size(1370, 23);
            this.LblTituloComponente.TabIndex = 34;
            this.LblTituloComponente.Text = "ADMINISTRAR PRODUCTO DEL CLIENTE";
            this.LblTituloComponente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cliente:";
            // 
            // CmbFiltroCliente
            // 
            this.CmbFiltroCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroCliente.FormattingEnabled = true;
            this.CmbFiltroCliente.Items.AddRange(new object[] {
            "TODOS"});
            this.CmbFiltroCliente.Location = new System.Drawing.Point(12, 45);
            this.CmbFiltroCliente.Name = "CmbFiltroCliente";
            this.CmbFiltroCliente.Size = new System.Drawing.Size(571, 32);
            this.CmbFiltroCliente.TabIndex = 2;
            this.CmbFiltroCliente.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroCliente_SelectedIndexChanged);
            // 
            // DgvProducto
            // 
            this.DgvProducto.AllowUserToAddRows = false;
            this.DgvProducto.AllowUserToResizeRows = false;
            this.DgvProducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_producto,
            this.cliente_producto,
            this.industria_producto,
            this.nombre_producto,
            this.clase_producto,
            this.descripcion});
            this.DgvProducto.ContextMenuStrip = this.MenuProducto;
            this.DgvProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProducto.Location = new System.Drawing.Point(0, 89);
            this.DgvProducto.Name = "DgvProducto";
            this.DgvProducto.ReadOnly = true;
            this.DgvProducto.RowHeadersVisible = false;
            this.DgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProducto.Size = new System.Drawing.Size(1370, 331);
            this.DgvProducto.TabIndex = 0;
            // 
            // id_producto
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id_producto.DefaultCellStyle = dataGridViewCellStyle10;
            this.id_producto.Frozen = true;
            this.id_producto.HeaderText = "ID";
            this.id_producto.Name = "id_producto";
            this.id_producto.ReadOnly = true;
            this.id_producto.Width = 50;
            // 
            // cliente_producto
            // 
            this.cliente_producto.Frozen = true;
            this.cliente_producto.HeaderText = "Cliente";
            this.cliente_producto.Name = "cliente_producto";
            this.cliente_producto.ReadOnly = true;
            this.cliente_producto.Width = 280;
            // 
            // industria_producto
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.industria_producto.DefaultCellStyle = dataGridViewCellStyle11;
            this.industria_producto.Frozen = true;
            this.industria_producto.HeaderText = "Industria";
            this.industria_producto.Name = "industria_producto";
            this.industria_producto.ReadOnly = true;
            this.industria_producto.Width = 250;
            // 
            // nombre_producto
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre_producto.DefaultCellStyle = dataGridViewCellStyle12;
            this.nombre_producto.Frozen = true;
            this.nombre_producto.HeaderText = "Nombre del producto";
            this.nombre_producto.Name = "nombre_producto";
            this.nombre_producto.ReadOnly = true;
            this.nombre_producto.Width = 300;
            // 
            // clase_producto
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clase_producto.DefaultCellStyle = dataGridViewCellStyle13;
            this.clase_producto.Frozen = true;
            this.clase_producto.HeaderText = "Clase";
            this.clase_producto.Name = "clase_producto";
            this.clase_producto.ReadOnly = true;
            this.clase_producto.Width = 200;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle14;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // MenuProducto
            // 
            this.MenuProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProductoToolStripMenuItem,
            this.editarProductoToolStripMenuItem,
            this.eliminarProductoToolStripMenuItem});
            this.MenuProducto.Name = "MenuProducto";
            this.MenuProducto.Size = new System.Drawing.Size(170, 92);
            this.MenuProducto.Opening += new System.ComponentModel.CancelEventHandler(this.MenuProducto_Opening);
            // 
            // nuevoProductoToolStripMenuItem
            // 
            this.nuevoProductoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoProductoToolStripMenuItem.Name = "nuevoProductoToolStripMenuItem";
            this.nuevoProductoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.nuevoProductoToolStripMenuItem.Text = "Nuevo producto";
            this.nuevoProductoToolStripMenuItem.Click += new System.EventHandler(this.nuevoProductoToolStripMenuItem_Click);
            // 
            // editarProductoToolStripMenuItem
            // 
            this.editarProductoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarProductoToolStripMenuItem.Name = "editarProductoToolStripMenuItem";
            this.editarProductoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.editarProductoToolStripMenuItem.Text = "Editar producto";
            this.editarProductoToolStripMenuItem.Click += new System.EventHandler(this.editarProductoToolStripMenuItem_Click);
            // 
            // eliminarProductoToolStripMenuItem
            // 
            this.eliminarProductoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            this.eliminarProductoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.eliminarProductoToolStripMenuItem.Text = "Eliminar producto";
            // 
            // FrmAdministrarProductoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 420);
            this.Controls.Add(this.DgvProducto);
            this.Controls.Add(this.PanelFiltros);
            this.Name = "FrmAdministrarProductoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar producto del cliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmProducto_Load);
            this.PanelFiltros.ResumeLayout(false);
            this.PanelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).EndInit();
            this.MenuProducto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn id_variante;
        private System.Windows.Forms.DataGridViewTextBoxColumn variante;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_variantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_componentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_variante;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_proyecto;
        private System.Windows.Forms.Panel PanelFiltros;
        private System.Windows.Forms.DataGridView DgvProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbFiltroCliente;
        private System.Windows.Forms.Label LblTituloComponente;
        private System.Windows.Forms.ContextMenuStrip MenuProducto;
        private System.Windows.Forms.ToolStripMenuItem nuevoProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarProductoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn industria_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clase_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;




    }
}
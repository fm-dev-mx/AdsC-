namespace CB
{
    partial class FrmMonitorVentas
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
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbVendedor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbEstatus = new System.Windows.Forms.ComboBox();
            this.DgvCotizaciones = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuCotizaciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevaCotizaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarCotizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarCotizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCotizaciones)).BeginInit();
            this.MenuCotizaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1637, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "MONITOR DE VENTAS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbCliente);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CmbVendedor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CmbEstatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1637, 85);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Cliente:";
            // 
            // CmbCliente
            // 
            this.CmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCliente.FormattingEnabled = true;
            this.CmbCliente.Items.AddRange(new object[] {
            "TODOS"});
            this.CmbCliente.Location = new System.Drawing.Point(336, 30);
            this.CmbCliente.Margin = new System.Windows.Forms.Padding(4);
            this.CmbCliente.Name = "CmbCliente";
            this.CmbCliente.Size = new System.Drawing.Size(628, 37);
            this.CmbCliente.TabIndex = 23;
            this.CmbCliente.SelectedIndexChanged += new System.EventHandler(this.CmbCliente_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(969, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Vendedor:";
            // 
            // CmbVendedor
            // 
            this.CmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbVendedor.FormattingEnabled = true;
            this.CmbVendedor.Items.AddRange(new object[] {
            "TODOS"});
            this.CmbVendedor.Location = new System.Drawing.Point(973, 30);
            this.CmbVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.CmbVendedor.Name = "CmbVendedor";
            this.CmbVendedor.Size = new System.Drawing.Size(488, 37);
            this.CmbVendedor.TabIndex = 21;
            this.CmbVendedor.SelectedIndexChanged += new System.EventHandler(this.CmbVendedor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Estatus:";
            // 
            // CmbEstatus
            // 
            this.CmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatus.FormattingEnabled = true;
            this.CmbEstatus.Items.AddRange(new object[] {
            "SIN ENVIAR",
            "ENVIADO",
            "DESCARTADO",
            "EN REVISION",
            "ORDEN DE COMPRA"});
            this.CmbEstatus.Location = new System.Drawing.Point(16, 30);
            this.CmbEstatus.Margin = new System.Windows.Forms.Padding(4);
            this.CmbEstatus.Name = "CmbEstatus";
            this.CmbEstatus.Size = new System.Drawing.Size(311, 37);
            this.CmbEstatus.TabIndex = 12;
            this.CmbEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbEstatus_SelectedIndexChanged);
            // 
            // DgvCotizaciones
            // 
            this.DgvCotizaciones.AllowUserToAddRows = false;
            this.DgvCotizaciones.AllowUserToDeleteRows = false;
            this.DgvCotizaciones.AllowUserToResizeRows = false;
            this.DgvCotizaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCotizaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.contacto,
            this.fecha_limite});
            this.DgvCotizaciones.ContextMenuStrip = this.MenuCotizaciones;
            this.DgvCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCotizaciones.Location = new System.Drawing.Point(0, 113);
            this.DgvCotizaciones.Margin = new System.Windows.Forms.Padding(4);
            this.DgvCotizaciones.Name = "DgvCotizaciones";
            this.DgvCotizaciones.ReadOnly = true;
            this.DgvCotizaciones.RowHeadersVisible = false;
            this.DgvCotizaciones.RowHeadersWidth = 51;
            this.DgvCotizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCotizaciones.Size = new System.Drawing.Size(1637, 598);
            this.DgvCotizaciones.TabIndex = 9;
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 60;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle2;
            this.nombre.HeaderText = "Titulo";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // contacto
            // 
            this.contacto.HeaderText = "Contacto";
            this.contacto.MinimumWidth = 6;
            this.contacto.Name = "contacto";
            this.contacto.ReadOnly = true;
            this.contacto.Width = 300;
            // 
            // fecha_limite
            // 
            this.fecha_limite.HeaderText = "Fecha limite";
            this.fecha_limite.MinimumWidth = 6;
            this.fecha_limite.Name = "fecha_limite";
            this.fecha_limite.ReadOnly = true;
            this.fecha_limite.Width = 200;
            // 
            // MenuCotizaciones
            // 
            this.MenuCotizaciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuCotizaciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCotizaciToolStripMenuItem,
            this.editarCotizaciónToolStripMenuItem,
            this.borrarCotizaciónToolStripMenuItem});
            this.MenuCotizaciones.Name = "MenuCotizaciones";
            this.MenuCotizaciones.Size = new System.Drawing.Size(215, 110);
            // 
            // nuevaCotizaciToolStripMenuItem
            // 
            this.nuevaCotizaciToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevaCotizaciToolStripMenuItem.Name = "nuevaCotizaciToolStripMenuItem";
            this.nuevaCotizaciToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.nuevaCotizaciToolStripMenuItem.Text = "Nueva cotización";
            this.nuevaCotizaciToolStripMenuItem.Click += new System.EventHandler(this.nuevaCotizaciToolStripMenuItem_Click);
            // 
            // editarCotizaciónToolStripMenuItem
            // 
            this.editarCotizaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarCotizaciónToolStripMenuItem.Name = "editarCotizaciónToolStripMenuItem";
            this.editarCotizaciónToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.editarCotizaciónToolStripMenuItem.Text = "Editar cotización";
            this.editarCotizaciónToolStripMenuItem.Click += new System.EventHandler(this.editarCotizaciónToolStripMenuItem_Click);
            // 
            // borrarCotizaciónToolStripMenuItem
            // 
            this.borrarCotizaciónToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarCotizaciónToolStripMenuItem.Name = "borrarCotizaciónToolStripMenuItem";
            this.borrarCotizaciónToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.borrarCotizaciónToolStripMenuItem.Text = "Borrar cotización";
            // 
            // FrmMonitorVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 711);
            this.Controls.Add(this.DgvCotizaciones);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMonitorVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMonitorVentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCotizaciones)).EndInit();
            this.MenuCotizaciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvCotizaciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbEstatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbCliente;
        private System.Windows.Forms.ContextMenuStrip MenuCotizaciones;
        private System.Windows.Forms.ToolStripMenuItem nuevaCotizaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarCotizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarCotizaciónToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_limite;
    }
}
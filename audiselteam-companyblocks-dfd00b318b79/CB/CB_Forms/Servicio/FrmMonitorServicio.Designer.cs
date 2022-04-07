namespace CB
{
    partial class FrmMonitorServicio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbEstatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvTickets = new System.Windows.Forms.DataGridView();
            this.MenuTickets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTickets)).BeginInit();
            this.MenuTickets.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(1084, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "MONITOR DE SERVICIO AL CLIENTE";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbTipo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbEstatus);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 67);
            this.panel1.TabIndex = 9;
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Items.AddRange(new object[] {
            "TODOS",
            "RECLAMO OFICIAL",
            "INCIDENTE DE CALIDAD",
            "SEGUIMIENTO DE GARANTIA"});
            this.CmbTipo.Location = new System.Drawing.Point(12, 27);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(285, 28);
            this.CmbTipo.TabIndex = 22;
            this.CmbTipo.SelectedIndexChanged += new System.EventHandler(this.CmbTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tipo de ticket: ";
            // 
            // CmbEstatus
            // 
            this.CmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatus.FormattingEnabled = true;
            this.CmbEstatus.Items.AddRange(new object[] {
            "TODOS",
            "ABIERTO",
            "CERRADO"});
            this.CmbEstatus.Location = new System.Drawing.Point(309, 27);
            this.CmbEstatus.Name = "CmbEstatus";
            this.CmbEstatus.Size = new System.Drawing.Size(213, 28);
            this.CmbEstatus.TabIndex = 20;
            this.CmbEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbEstatus_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(306, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Estatus:";
            // 
            // DgvTickets
            // 
            this.DgvTickets.AllowUserToAddRows = false;
            this.DgvTickets.AllowUserToResizeRows = false;
            this.DgvTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipo,
            this.proyecto,
            this.usuario_creacion,
            this.fecha_creacion,
            this.estatus,
            this.detalles});
            this.DgvTickets.ContextMenuStrip = this.MenuTickets;
            this.DgvTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTickets.Location = new System.Drawing.Point(0, 90);
            this.DgvTickets.Name = "DgvTickets";
            this.DgvTickets.ReadOnly = true;
            this.DgvTickets.RowHeadersVisible = false;
            this.DgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTickets.Size = new System.Drawing.Size(1084, 419);
            this.DgvTickets.TabIndex = 10;
            this.DgvTickets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTickets_CellDoubleClick);
            // 
            // MenuTickets
            // 
            this.MenuTickets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem});
            this.MenuTickets.Name = "MenuTickets";
            this.MenuTickets.Size = new System.Drawing.Size(110, 26);
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // tipo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipo.DefaultCellStyle = dataGridViewCellStyle2;
            this.tipo.HeaderText = "Tipo de ticket";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 180;
            // 
            // proyecto
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.proyecto.DefaultCellStyle = dataGridViewCellStyle3;
            this.proyecto.HeaderText = "Proyecto";
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            this.proyecto.Width = 60;
            // 
            // usuario_creacion
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuario_creacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.usuario_creacion.HeaderText = "Creado por";
            this.usuario_creacion.Name = "usuario_creacion";
            this.usuario_creacion.ReadOnly = true;
            this.usuario_creacion.Width = 150;
            // 
            // fecha_creacion
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_creacion.DefaultCellStyle = dataGridViewCellStyle5;
            this.fecha_creacion.HeaderText = "Fecha de creación";
            this.fecha_creacion.Name = "fecha_creacion";
            this.fecha_creacion.ReadOnly = true;
            this.fecha_creacion.Width = 150;
            // 
            // estatus
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 120;
            // 
            // detalles
            // 
            this.detalles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detalles.DefaultCellStyle = dataGridViewCellStyle7;
            this.detalles.HeaderText = "Detalles";
            this.detalles.Name = "detalles";
            this.detalles.ReadOnly = true;
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // FrmMonitorServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 509);
            this.Controls.Add(this.DgvTickets);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmMonitorServicio";
            this.Text = "Monitor de servicio al cliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMonitorServicio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTickets)).EndInit();
            this.MenuTickets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvTickets;
        private System.Windows.Forms.ComboBox CmbEstatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip MenuTickets;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalles;
    }
}
namespace CB
{
    partial class FrmPlanMantenimientoEquipoComputo
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
            this.MenuMantenimiento = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.realizarMantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultimoMantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DgvMantenimiento = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnHistorialMantenimiento = new System.Windows.Forms.Button();
            this.LblFiltro = new System.Windows.Forms.Label();
            this.CmbFiltro = new System.Windows.Forms.ComboBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimo_mantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proximo_mantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuMantenimiento.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimiento)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMantenimiento
            // 
            this.MenuMantenimiento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizarMantenimientoToolStripMenuItem,
            this.ultimoMantenimientoToolStripMenuItem});
            this.MenuMantenimiento.Name = "MenuMantenimiento";
            this.MenuMantenimiento.Size = new System.Drawing.Size(200, 48);
            // 
            // realizarMantenimientoToolStripMenuItem
            // 
            this.realizarMantenimientoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.mantenimiento_48;
            this.realizarMantenimientoToolStripMenuItem.Name = "realizarMantenimientoToolStripMenuItem";
            this.realizarMantenimientoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.realizarMantenimientoToolStripMenuItem.Text = "Realizar mantenimiento";
            this.realizarMantenimientoToolStripMenuItem.Click += new System.EventHandler(this.realizarMantenimientoToolStripMenuItem_Click);
            // 
            // ultimoMantenimientoToolStripMenuItem
            // 
            this.ultimoMantenimientoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Custom_reports_icon;
            this.ultimoMantenimientoToolStripMenuItem.Name = "ultimoMantenimientoToolStripMenuItem";
            this.ultimoMantenimientoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.ultimoMantenimientoToolStripMenuItem.Text = "Ultimo mantenimiento";
            this.ultimoMantenimientoToolStripMenuItem.Click += new System.EventHandler(this.ultimoMantenimientoToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgvMantenimiento);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 479);
            this.panel2.TabIndex = 13;
            // 
            // DgvMantenimiento
            // 
            this.DgvMantenimiento.AllowUserToAddRows = false;
            this.DgvMantenimiento.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMantenimiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMantenimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMantenimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.equipo,
            this.ultimo_mantenimiento,
            this.responsable,
            this.proximo_mantenimiento,
            this.estatus});
            this.DgvMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMantenimiento.Location = new System.Drawing.Point(0, 0);
            this.DgvMantenimiento.Name = "DgvMantenimiento";
            this.DgvMantenimiento.RowHeadersVisible = false;
            this.DgvMantenimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMantenimiento.Size = new System.Drawing.Size(1066, 479);
            this.DgvMantenimiento.TabIndex = 11;
            this.DgvMantenimiento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMantenimiento_CellClick);
            this.DgvMantenimiento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvMantenimiento_CellFormatting);
            this.DgvMantenimiento.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMantenimiento_CellMouseClick);
            this.DgvMantenimiento.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMantenimiento_CellMouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnHistorialMantenimiento);
            this.panel1.Controls.Add(this.LblFiltro);
            this.panel1.Controls.Add(this.CmbFiltro);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 65);
            this.panel1.TabIndex = 12;
            // 
            // BtnHistorialMantenimiento
            // 
            this.BtnHistorialMantenimiento.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnHistorialMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHistorialMantenimiento.Image = global::CB_Base.Properties.Resources.calendar_48;
            this.BtnHistorialMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHistorialMantenimiento.Location = new System.Drawing.Point(784, 0);
            this.BtnHistorialMantenimiento.Name = "BtnHistorialMantenimiento";
            this.BtnHistorialMantenimiento.Size = new System.Drawing.Size(141, 65);
            this.BtnHistorialMantenimiento.TabIndex = 129;
            this.BtnHistorialMantenimiento.Text = "         Historial";
            this.BtnHistorialMantenimiento.UseVisualStyleBackColor = true;
            this.BtnHistorialMantenimiento.Click += new System.EventHandler(this.BtnHistorialMantenimiento_Click);
            // 
            // LblFiltro
            // 
            this.LblFiltro.AutoSize = true;
            this.LblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFiltro.Location = new System.Drawing.Point(12, 11);
            this.LblFiltro.Name = "LblFiltro";
            this.LblFiltro.Size = new System.Drawing.Size(67, 16);
            this.LblFiltro.TabIndex = 127;
            this.LblFiltro.Text = "Filtrar por:";
            // 
            // CmbFiltro
            // 
            this.CmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltro.FormattingEnabled = true;
            this.CmbFiltro.Items.AddRange(new object[] {
            "TODOS",
            "A TIEMPO",
            "PROXIMO",
            "TARDE"});
            this.CmbFiltro.Location = new System.Drawing.Point(12, 28);
            this.CmbFiltro.Name = "CmbFiltro";
            this.CmbFiltro.Size = new System.Drawing.Size(348, 28);
            this.CmbFiltro.TabIndex = 126;
            this.CmbFiltro.SelectedIndexChanged += new System.EventHandler(this.CmbFiltro_SelectedIndexChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(925, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(141, 65);
            this.BtnSalir.TabIndex = 125;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1066, 23);
            this.LblTitulo.TabIndex = 10;
            this.LblTitulo.Text = "PLAN DE MANTENIMIENTO PREVENTIVO A EQUIPOS DE COMPUTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // equipo
            // 
            this.equipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.equipo.HeaderText = "Elemento del mantenimiento";
            this.equipo.MinimumWidth = 300;
            this.equipo.Name = "equipo";
            this.equipo.ReadOnly = true;
            // 
            // ultimo_mantenimiento
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ultimo_mantenimiento.DefaultCellStyle = dataGridViewCellStyle2;
            this.ultimo_mantenimiento.HeaderText = "Ultimo mantenimiento";
            this.ultimo_mantenimiento.MinimumWidth = 150;
            this.ultimo_mantenimiento.Name = "ultimo_mantenimiento";
            this.ultimo_mantenimiento.ReadOnly = true;
            this.ultimo_mantenimiento.Width = 200;
            // 
            // responsable
            // 
            this.responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.responsable.HeaderText = "Realizado por";
            this.responsable.MinimumWidth = 150;
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            // 
            // proximo_mantenimiento
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proximo_mantenimiento.DefaultCellStyle = dataGridViewCellStyle3;
            this.proximo_mantenimiento.HeaderText = "Próximo mantenimiento";
            this.proximo_mantenimiento.MinimumWidth = 150;
            this.proximo_mantenimiento.Name = "proximo_mantenimiento";
            this.proximo_mantenimiento.ReadOnly = true;
            this.proximo_mantenimiento.Width = 200;
            // 
            // estatus
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.estatus.HeaderText = "Estatus";
            this.estatus.MinimumWidth = 100;
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 150;
            // 
            // FrmPlanMantenimientoEquipoComputo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 567);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmPlanMantenimientoEquipoComputo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plan de mantenimiento de equipos de computo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPlanMantenimientoEquipoComputo_Load);
            this.MenuMantenimiento.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimiento)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridView DgvMantenimiento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblFiltro;
        private System.Windows.Forms.ComboBox CmbFiltro;
        private System.Windows.Forms.ContextMenuStrip MenuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem realizarMantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ultimoMantenimientoToolStripMenuItem;
        private System.Windows.Forms.Button BtnHistorialMantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimo_mantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn proximo_mantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
    }
}
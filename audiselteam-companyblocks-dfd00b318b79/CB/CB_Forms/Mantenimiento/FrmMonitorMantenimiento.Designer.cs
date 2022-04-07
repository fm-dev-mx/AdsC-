namespace CB
{
    partial class FrmMonitorMantenimiento
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
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbFiltro = new System.Windows.Forms.ComboBox();
            this.LblFiltro = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbTipoMantenimiento = new System.Windows.Forms.ComboBox();
            this.BtnHistorialMantenimiento = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvMantenimiento = new System.Windows.Forms.DataGridView();
            this.MenuMantenimiento = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.realizarMantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultimoMantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimo_mantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proximo_mantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimiento)).BeginInit();
            this.MenuMantenimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1088, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "MONITOR DE MANTENIMIENTO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CmbFiltro);
            this.panel1.Controls.Add(this.LblFiltro);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.CmbTipoMantenimiento);
            this.panel1.Controls.Add(this.BtnHistorialMantenimiento);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 68);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(301, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 130;
            this.label2.Text = "Filtrar por:";
            // 
            // CmbFiltro
            // 
            this.CmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CmbFiltro.FormattingEnabled = true;
            this.CmbFiltro.Items.AddRange(new object[] {
            "TODOS",
            "A TIEMPO",
            "PROXIMO",
            "TARDE"});
            this.CmbFiltro.Location = new System.Drawing.Point(301, 27);
            this.CmbFiltro.Name = "CmbFiltro";
            this.CmbFiltro.Size = new System.Drawing.Size(280, 28);
            this.CmbFiltro.TabIndex = 129;
            this.CmbFiltro.SelectedIndexChanged += new System.EventHandler(this.CmbFiltro_SelectedIndexChanged);
            // 
            // LblFiltro
            // 
            this.LblFiltro.AutoSize = true;
            this.LblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFiltro.Location = new System.Drawing.Point(12, 8);
            this.LblFiltro.Name = "LblFiltro";
            this.LblFiltro.Size = new System.Drawing.Size(126, 16);
            this.LblFiltro.TabIndex = 128;
            this.LblFiltro.Text = "Tipo mantenimiento";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Image = global::CB_Base.Properties.Resources.mantenimiento_48;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(665, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "          Correctivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbTipoMantenimiento
            // 
            this.CmbTipoMantenimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CmbTipoMantenimiento.FormattingEnabled = true;
            this.CmbTipoMantenimiento.Items.AddRange(new object[] {
            "VEHICULOS",
            "EDIFICIO",
            "MAQUINARIA"});
            this.CmbTipoMantenimiento.Location = new System.Drawing.Point(12, 27);
            this.CmbTipoMantenimiento.Name = "CmbTipoMantenimiento";
            this.CmbTipoMantenimiento.Size = new System.Drawing.Size(280, 28);
            this.CmbTipoMantenimiento.TabIndex = 1;
            this.CmbTipoMantenimiento.SelectedIndexChanged += new System.EventHandler(this.CmbTipoMantenimiento_SelectedIndexChanged);
            // 
            // BtnHistorialMantenimiento
            // 
            this.BtnHistorialMantenimiento.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnHistorialMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHistorialMantenimiento.Image = global::CB_Base.Properties.Resources.calendar_48;
            this.BtnHistorialMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHistorialMantenimiento.Location = new System.Drawing.Point(806, 0);
            this.BtnHistorialMantenimiento.Name = "BtnHistorialMantenimiento";
            this.BtnHistorialMantenimiento.Size = new System.Drawing.Size(141, 68);
            this.BtnHistorialMantenimiento.TabIndex = 131;
            this.BtnHistorialMantenimiento.Text = "         Historial";
            this.BtnHistorialMantenimiento.UseVisualStyleBackColor = true;
            this.BtnHistorialMantenimiento.Click += new System.EventHandler(this.BtnHistorialMantenimiento_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(947, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(141, 68);
            this.BtnSalir.TabIndex = 126;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Aqui va el preventivo";
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
            this.DgvMantenimiento.Location = new System.Drawing.Point(0, 91);
            this.DgvMantenimiento.Name = "DgvMantenimiento";
            this.DgvMantenimiento.RowHeadersVisible = false;
            this.DgvMantenimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMantenimiento.Size = new System.Drawing.Size(1088, 475);
            this.DgvMantenimiento.TabIndex = 12;
            this.DgvMantenimiento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMantenimiento_CellClick);
            this.DgvMantenimiento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvMantenimiento_CellFormatting);
            this.DgvMantenimiento.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMantenimiento_CellMouseClick);
            this.DgvMantenimiento.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMantenimiento_CellMouseDown);
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
            this.equipo.HeaderText = "Elemento de mantenimiento";
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
            // FrmMonitorMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 566);
            this.Controls.Add(this.DgvMantenimiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Name = "FrmMonitorMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de mantenimiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMonitorMantenimiento_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimiento)).EndInit();
            this.MenuMantenimiento.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CmbTipoMantenimiento;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvMantenimiento;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblFiltro;
        private System.Windows.Forms.Label label2;
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
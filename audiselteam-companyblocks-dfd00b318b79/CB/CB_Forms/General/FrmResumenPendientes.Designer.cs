namespace CB_Base.Classes
{
    partial class FrmResumenPendientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResumenPendientes));
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbProyecto = new System.Windows.Forms.ComboBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DgvRequerimientos = new System.Windows.Forms.DataGridView();
            this.req_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_nivel_revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_estatus_revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbEstatusRequerimiento = new System.Windows.Forms.ComboBox();
            this.ImagenesTabs = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequerimientos)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(1170, 25);
            this.LblTitulo.TabIndex = 33;
            this.LblTitulo.Text = "RESUMEN DE PENDIENTES";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CmbProyecto);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 70);
            this.panel1.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Proyecto:";
            // 
            // CmbProyecto
            // 
            this.CmbProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProyecto.FormattingEnabled = true;
            this.CmbProyecto.Items.AddRange(new object[] {
            "TODOS",
            "NO DEFINIDO",
            "DEFINIDO",
            "EN EVALUACION",
            "DESCARTADO"});
            this.CmbProyecto.Location = new System.Drawing.Point(18, 27);
            this.CmbProyecto.Name = "CmbProyecto";
            this.CmbProyecto.Size = new System.Drawing.Size(583, 32);
            this.CmbProyecto.TabIndex = 20;
            this.CmbProyecto.SelectedIndexChanged += new System.EventHandler(this.CmbProyecto_SelectedIndexChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1048, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(122, 70);
            this.BtnSalir.TabIndex = 19;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.ImageList = this.ImagenesTabs;
            this.Tabs.Location = new System.Drawing.Point(0, 95);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1170, 384);
            this.Tabs.TabIndex = 35;
            this.Tabs.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgvRequerimientos);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1162, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Requerimientos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DgvRequerimientos
            // 
            this.DgvRequerimientos.AllowUserToAddRows = false;
            this.DgvRequerimientos.AllowUserToDeleteRows = false;
            this.DgvRequerimientos.AllowUserToResizeRows = false;
            this.DgvRequerimientos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvRequerimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRequerimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.req_id,
            this.req_proyecto,
            this.req_nombre,
            this.req_descripcion,
            this.req_origen,
            this.req_estatus,
            this.req_nivel_revision,
            this.req_estatus_revision});
            this.DgvRequerimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvRequerimientos.Location = new System.Drawing.Point(3, 72);
            this.DgvRequerimientos.Name = "DgvRequerimientos";
            this.DgvRequerimientos.ReadOnly = true;
            this.DgvRequerimientos.RowHeadersVisible = false;
            this.DgvRequerimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRequerimientos.Size = new System.Drawing.Size(1156, 266);
            this.DgvRequerimientos.TabIndex = 1;
            this.DgvRequerimientos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequerimientos_CellDoubleClick);
            // 
            // req_id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.req_id.DefaultCellStyle = dataGridViewCellStyle1;
            this.req_id.HeaderText = "Req. #";
            this.req_id.Name = "req_id";
            this.req_id.ReadOnly = true;
            this.req_id.Width = 50;
            // 
            // req_proyecto
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.req_proyecto.DefaultCellStyle = dataGridViewCellStyle2;
            this.req_proyecto.HeaderText = "Proyecto";
            this.req_proyecto.Name = "req_proyecto";
            this.req_proyecto.ReadOnly = true;
            // 
            // req_nombre
            // 
            this.req_nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.req_nombre.DefaultCellStyle = dataGridViewCellStyle3;
            this.req_nombre.HeaderText = "Nombre";
            this.req_nombre.Name = "req_nombre";
            this.req_nombre.ReadOnly = true;
            this.req_nombre.Width = 180;
            // 
            // req_descripcion
            // 
            this.req_descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.req_descripcion.DefaultCellStyle = dataGridViewCellStyle4;
            this.req_descripcion.HeaderText = "Descripción";
            this.req_descripcion.Name = "req_descripcion";
            this.req_descripcion.ReadOnly = true;
            // 
            // req_origen
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.req_origen.DefaultCellStyle = dataGridViewCellStyle5;
            this.req_origen.HeaderText = "Origen";
            this.req_origen.Name = "req_origen";
            this.req_origen.ReadOnly = true;
            this.req_origen.Width = 120;
            // 
            // req_estatus
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.req_estatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.req_estatus.HeaderText = "Estatus";
            this.req_estatus.Name = "req_estatus";
            this.req_estatus.ReadOnly = true;
            this.req_estatus.Width = 150;
            // 
            // req_nivel_revision
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.req_nivel_revision.DefaultCellStyle = dataGridViewCellStyle7;
            this.req_nivel_revision.HeaderText = "Nivel de revisión";
            this.req_nivel_revision.Name = "req_nivel_revision";
            this.req_nivel_revision.ReadOnly = true;
            this.req_nivel_revision.Width = 150;
            // 
            // req_estatus_revision
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.req_estatus_revision.DefaultCellStyle = dataGridViewCellStyle8;
            this.req_estatus_revision.HeaderText = "Estatus de revisión";
            this.req_estatus_revision.Name = "req_estatus_revision";
            this.req_estatus_revision.ReadOnly = true;
            this.req_estatus_revision.Width = 130;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CmbEstatusRequerimiento);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1156, 69);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Estatus:";
            // 
            // CmbEstatusRequerimiento
            // 
            this.CmbEstatusRequerimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatusRequerimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstatusRequerimiento.FormattingEnabled = true;
            this.CmbEstatusRequerimiento.Items.AddRange(new object[] {
            "SOLICITUDES",
            "NO DEFINIDOS",
            "EN EVALUACION",
            "SIN REVISAR",
            "SIN CUMPLIR"});
            this.CmbEstatusRequerimiento.Location = new System.Drawing.Point(11, 27);
            this.CmbEstatusRequerimiento.Name = "CmbEstatusRequerimiento";
            this.CmbEstatusRequerimiento.Size = new System.Drawing.Size(204, 32);
            this.CmbEstatusRequerimiento.TabIndex = 22;
            this.CmbEstatusRequerimiento.SelectedIndexChanged += new System.EventHandler(this.CmbEstatusRequerimiento_SelectedIndexChanged);
            // 
            // ImagenesTabs
            // 
            this.ImagenesTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTabs.ImageStream")));
            this.ImagenesTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTabs.Images.SetKeyName(0, "red-list-ingredients-24.ico");
            // 
            // FrmResumenPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 479);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmResumenPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de pendientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmResumenPendientes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequerimientos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ImageList ImagenesTabs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbProyecto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbEstatusRequerimiento;
        private System.Windows.Forms.DataGridView DgvRequerimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_nivel_revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_estatus_revision;
    }
}
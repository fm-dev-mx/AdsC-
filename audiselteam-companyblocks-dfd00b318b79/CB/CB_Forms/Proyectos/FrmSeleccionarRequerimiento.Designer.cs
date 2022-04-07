namespace CB
{
    partial class FrmSeleccionarRequerimiento
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
            this.MenuSeleccion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarNadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DgvRequerimientos = new System.Windows.Forms.DataGridView();
            this.check_req = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuSeleccion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequerimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuSeleccion
            // 
            this.MenuSeleccion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarTodoToolStripMenuItem,
            this.seleccionarNadaToolStripMenuItem});
            this.MenuSeleccion.Name = "MenuSeleccion";
            this.MenuSeleccion.Size = new System.Drawing.Size(164, 48);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo";
            this.seleccionarTodoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarTodoToolStripMenuItem_Click);
            // 
            // seleccionarNadaToolStripMenuItem
            // 
            this.seleccionarNadaToolStripMenuItem.Name = "seleccionarNadaToolStripMenuItem";
            this.seleccionarNadaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seleccionarNadaToolStripMenuItem.Text = "Seleccionar nada";
            this.seleccionarNadaToolStripMenuItem.Click += new System.EventHandler(this.seleccionarNadaToolStripMenuItem_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1193, 23);
            this.LblTitulo.TabIndex = 26;
            this.LblTitulo.Text = "VINCULAR REQUERIMIENTOS";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnSeleccionar);
            this.groupBox1.Controls.Add(this.BtnSalir);
            this.groupBox1.Location = new System.Drawing.Point(921, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 68);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSeleccionar.Location = new System.Drawing.Point(3, 9);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(129, 55);
            this.BtnSeleccionar.TabIndex = 23;
            this.BtnSeleccionar.Text = "    Seleccionar";
            this.BtnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(134, 9);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(129, 55);
            this.BtnSalir.TabIndex = 22;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // DgvRequerimientos
            // 
            this.DgvRequerimientos.AllowUserToAddRows = false;
            this.DgvRequerimientos.AllowUserToDeleteRows = false;
            this.DgvRequerimientos.AllowUserToResizeRows = false;
            this.DgvRequerimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvRequerimientos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvRequerimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRequerimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check_req,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.origen,
            this.estatus,
            this.nivel_revision,
            this.estatus_revision});
            this.DgvRequerimientos.Location = new System.Drawing.Point(4, 106);
            this.DgvRequerimientos.Name = "DgvRequerimientos";
            this.DgvRequerimientos.ReadOnly = true;
            this.DgvRequerimientos.RowHeadersVisible = false;
            this.DgvRequerimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRequerimientos.Size = new System.Drawing.Size(1183, 478);
            this.DgvRequerimientos.TabIndex = 2;
            this.DgvRequerimientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequerimientos_CellContentClick);
            this.DgvRequerimientos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequerimientos_CellDoubleClick);
            this.DgvRequerimientos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvRequerimientos_CellMouseDown);
            this.DgvRequerimientos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvRequerimientos_MouseClick);
            // 
            // check_req
            // 
            this.check_req.FalseValue = "";
            this.check_req.Frozen = true;
            this.check_req.HeaderText = "";
            this.check_req.MinimumWidth = 30;
            this.check_req.Name = "check_req";
            this.check_req.ReadOnly = true;
            this.check_req.TrueValue = "";
            this.check_req.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Req. #";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 180;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // origen
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.origen.DefaultCellStyle = dataGridViewCellStyle4;
            this.origen.HeaderText = "Origen";
            this.origen.Name = "origen";
            this.origen.ReadOnly = true;
            this.origen.Width = 180;
            // 
            // estatus
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle5;
            this.estatus.HeaderText = "Estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 180;
            // 
            // nivel_revision
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nivel_revision.DefaultCellStyle = dataGridViewCellStyle6;
            this.nivel_revision.HeaderText = "Nivel de revisión";
            this.nivel_revision.Name = "nivel_revision";
            this.nivel_revision.ReadOnly = true;
            this.nivel_revision.Width = 180;
            // 
            // estatus_revision
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_revision.DefaultCellStyle = dataGridViewCellStyle7;
            this.estatus_revision.HeaderText = "Estatus de revisión";
            this.estatus_revision.Name = "estatus_revision";
            this.estatus_revision.ReadOnly = true;
            this.estatus_revision.Width = 180;
            // 
            // FrmSeleccionarRequerimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 588);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvRequerimientos);
            this.Name = "FrmSeleccionarRequerimiento";
            this.Text = "Selección de  requerimiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSeleccionarRequerimiento_Load);
            this.MenuSeleccion.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRequerimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvRequerimientos;
        private System.Windows.Forms.Button BtnSeleccionar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_req;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel_revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_revision;
        private System.Windows.Forms.ContextMenuStrip MenuSeleccion;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarNadaToolStripMenuItem;
        private System.Windows.Forms.Label LblTitulo;

    }
}
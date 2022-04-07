namespace CB
{
    partial class FrmEquipoTrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEquipoTrabajo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblDepartamento = new System.Windows.Forms.Label();
            this.CmbDepartamentos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ImagenesPuesto = new System.Windows.Forms.ImageList(this.components);
            this.CmbLider = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnNuevoEquipo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PanelEquipo = new System.Windows.Forms.Panel();
            this.DgvEquipos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.integrantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuEquipos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PanelEquipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEquipos)).BeginInit();
            this.MenuEquipos.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblDepartamento
            // 
            this.LblDepartamento.AutoSize = true;
            this.LblDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDepartamento.Location = new System.Drawing.Point(12, 8);
            this.LblDepartamento.Name = "LblDepartamento";
            this.LblDepartamento.Size = new System.Drawing.Size(94, 16);
            this.LblDepartamento.TabIndex = 100;
            this.LblDepartamento.Text = "Departamento";
            // 
            // CmbDepartamentos
            // 
            this.CmbDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDepartamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDepartamentos.FormattingEnabled = true;
            this.CmbDepartamentos.Items.AddRange(new object[] {
            "TODOS"});
            this.CmbDepartamentos.Location = new System.Drawing.Point(15, 24);
            this.CmbDepartamentos.Name = "CmbDepartamentos";
            this.CmbDepartamentos.Size = new System.Drawing.Size(282, 32);
            this.CmbDepartamentos.TabIndex = 99;
            this.CmbDepartamentos.SelectedIndexChanged += new System.EventHandler(this.CmbDepartamentos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Líder";
            // 
            // ImagenesPuesto
            // 
            this.ImagenesPuesto.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesPuesto.ImageStream")));
            this.ImagenesPuesto.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesPuesto.Images.SetKeyName(0, "laptop-icon.png");
            this.ImagenesPuesto.Images.SetKeyName(1, "details.ico");
            this.ImagenesPuesto.Images.SetKeyName(2, "evaluation-48.png");
            this.ImagenesPuesto.Images.SetKeyName(3, "warning-48.png");
            this.ImagenesPuesto.Images.SetKeyName(4, "delete-48.png");
            this.ImagenesPuesto.Images.SetKeyName(5, "profile-icon-48.png");
            // 
            // CmbLider
            // 
            this.CmbLider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLider.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLider.FormattingEnabled = true;
            this.CmbLider.Items.AddRange(new object[] {
            "TODOS"});
            this.CmbLider.Location = new System.Drawing.Point(312, 24);
            this.CmbLider.Name = "CmbLider";
            this.CmbLider.Size = new System.Drawing.Size(311, 32);
            this.CmbLider.TabIndex = 14;
            this.CmbLider.SelectedIndexChanged += new System.EventHandler(this.CmbLider_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnNuevoEquipo);
            this.panel1.Controls.Add(this.LblDepartamento);
            this.panel1.Controls.Add(this.CmbDepartamentos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbLider);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 68);
            this.panel1.TabIndex = 5;
            // 
            // BtnNuevoEquipo
            // 
            this.BtnNuevoEquipo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNuevoEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevoEquipo.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.BtnNuevoEquipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevoEquipo.Location = new System.Drawing.Point(635, 0);
            this.BtnNuevoEquipo.Name = "BtnNuevoEquipo";
            this.BtnNuevoEquipo.Size = new System.Drawing.Size(129, 68);
            this.BtnNuevoEquipo.TabIndex = 101;
            this.BtnNuevoEquipo.Text = "     Nuevo";
            this.BtnNuevoEquipo.UseVisualStyleBackColor = true;
            this.BtnNuevoEquipo.Click += new System.EventHandler(this.BtnNuevoEquipo_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PanelEquipo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(893, 347);
            this.panel2.TabIndex = 6;
            // 
            // PanelEquipo
            // 
            this.PanelEquipo.Controls.Add(this.DgvEquipos);
            this.PanelEquipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelEquipo.Location = new System.Drawing.Point(0, 0);
            this.PanelEquipo.Name = "PanelEquipo";
            this.PanelEquipo.Size = new System.Drawing.Size(893, 347);
            this.PanelEquipo.TabIndex = 1;
            // 
            // DgvEquipos
            // 
            this.DgvEquipos.AllowUserToAddRows = false;
            this.DgvEquipos.AllowUserToResizeColumns = false;
            this.DgvEquipos.AllowUserToResizeRows = false;
            this.DgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvEquipos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.DgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEquipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.departamento,
            this.lider,
            this.integrantes});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvEquipos.DefaultCellStyle = dataGridViewCellStyle22;
            this.DgvEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvEquipos.Location = new System.Drawing.Point(0, 0);
            this.DgvEquipos.Name = "DgvEquipos";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvEquipos.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.DgvEquipos.RowHeadersVisible = false;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvEquipos.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.DgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEquipos.Size = new System.Drawing.Size(893, 347);
            this.DgvEquipos.TabIndex = 0;
            this.DgvEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEquipos_CellClick);
            this.DgvEquipos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvEquipos_CellMouseDown);
            this.DgvEquipos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvEquipos_MouseClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle18;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 70;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // departamento
            // 
            this.departamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.departamento.DefaultCellStyle = dataGridViewCellStyle19;
            this.departamento.HeaderText = "Departamento";
            this.departamento.MinimumWidth = 200;
            this.departamento.Name = "departamento";
            this.departamento.ReadOnly = true;
            // 
            // lider
            // 
            this.lider.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lider.DefaultCellStyle = dataGridViewCellStyle20;
            this.lider.HeaderText = "Líder de equipo";
            this.lider.MinimumWidth = 250;
            this.lider.Name = "lider";
            this.lider.ReadOnly = true;
            this.lider.Width = 250;
            // 
            // integrantes
            // 
            this.integrantes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.integrantes.DefaultCellStyle = dataGridViewCellStyle21;
            this.integrantes.HeaderText = "Integrantes del equipo";
            this.integrantes.MinimumWidth = 250;
            this.integrantes.Name = "integrantes";
            this.integrantes.ReadOnly = true;
            this.integrantes.Width = 250;
            // 
            // MenuEquipos
            // 
            this.MenuEquipos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuEquipos.Name = "contextMenuStrip1";
            this.MenuEquipos.Size = new System.Drawing.Size(118, 48);
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
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(893, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "EQUIPOS DE TRABAJO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(764, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(129, 68);
            this.BtnSalir.TabIndex = 102;
            this.BtnSalir.Text = "     Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmEquipoTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 438);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEquipoTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipos de trabajo";
            this.Load += new System.EventHandler(this.FrmEquipoTrabajo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.PanelEquipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEquipos)).EndInit();
            this.MenuEquipos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblDepartamento;
        private System.Windows.Forms.ComboBox CmbDepartamentos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ImagenesPuesto;
        private System.Windows.Forms.ComboBox CmbLider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PanelEquipo;
        private System.Windows.Forms.DataGridView DgvEquipos;
        private System.Windows.Forms.Button BtnNuevoEquipo;
        private System.Windows.Forms.ContextMenuStrip MenuEquipos;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn lider;
        private System.Windows.Forms.DataGridViewTextBoxColumn integrantes;
        private System.Windows.Forms.Button BtnSalir;
    }
}
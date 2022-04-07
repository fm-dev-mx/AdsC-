namespace CB
{
    partial class FrmEvaluarDesempenoProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvaluarDesempenoProveedores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ImagenesTabs = new System.Windows.Forms.ImageList(this.components);
            this.MenuEvaluarHabilidad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.evaluarHabilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evaluarHabilidadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtPuestoEvaluador = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtEvaluador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblAvance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblPuntuacion = new System.Windows.Forms.Label();
            this.TxtProveedor = new System.Windows.Forms.TextBox();
            this.LblBajoEvaluacion = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DgvHabilidadesProveedor = new System.Windows.Forms.DataGridView();
            this.MenuEvaluar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.evaluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id_habilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_habilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_habilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuEvaluarHabilidad.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesProveedor)).BeginInit();
            this.MenuEvaluar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImagenesTabs
            // 
            this.ImagenesTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTabs.ImageStream")));
            this.ImagenesTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTabs.Images.SetKeyName(0, "user.png");
            this.ImagenesTabs.Images.SetKeyName(1, "tool-box-32.png");
            // 
            // MenuEvaluarHabilidad
            // 
            this.MenuEvaluarHabilidad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluarHabilidadToolStripMenuItem,
            this.evaluarHabilidadToolStripMenuItem1});
            this.MenuEvaluarHabilidad.Name = "MenuEvaluarHabilidad";
            this.MenuEvaluarHabilidad.Size = new System.Drawing.Size(165, 48);
            // 
            // evaluarHabilidadToolStripMenuItem
            // 
            this.evaluarHabilidadToolStripMenuItem.Image = global::CB_Base.Properties.Resources.factura;
            this.evaluarHabilidadToolStripMenuItem.Name = "evaluarHabilidadToolStripMenuItem";
            this.evaluarHabilidadToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.evaluarHabilidadToolStripMenuItem.Text = "Evaluar habilidad";
            // 
            // evaluarHabilidadToolStripMenuItem1
            // 
            this.evaluarHabilidadToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.factura;
            this.evaluarHabilidadToolStripMenuItem1.Name = "evaluarHabilidadToolStripMenuItem1";
            this.evaluarHabilidadToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.evaluarHabilidadToolStripMenuItem1.Text = "Evaluar habilidad";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtPuestoEvaluador);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtEvaluador);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.TxtProveedor);
            this.panel1.Controls.Add(this.LblBajoEvaluacion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 116);
            this.panel1.TabIndex = 11;
            // 
            // TxtPuestoEvaluador
            // 
            this.TxtPuestoEvaluador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPuestoEvaluador.Location = new System.Drawing.Point(334, 75);
            this.TxtPuestoEvaluador.Name = "TxtPuestoEvaluador";
            this.TxtPuestoEvaluador.ReadOnly = true;
            this.TxtPuestoEvaluador.Size = new System.Drawing.Size(253, 29);
            this.TxtPuestoEvaluador.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 123;
            this.label4.Text = "Puesto:";
            // 
            // TxtEvaluador
            // 
            this.TxtEvaluador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEvaluador.Location = new System.Drawing.Point(12, 75);
            this.TxtEvaluador.Name = "TxtEvaluador";
            this.TxtEvaluador.ReadOnly = true;
            this.TxtEvaluador.Size = new System.Drawing.Size(316, 29);
            this.TxtEvaluador.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Evaluador:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LblAvance);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.LblPuntuacion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(645, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 116);
            this.panel3.TabIndex = 120;
            // 
            // LblAvance
            // 
            this.LblAvance.AutoSize = true;
            this.LblAvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAvance.Location = new System.Drawing.Point(31, 24);
            this.LblAvance.Name = "LblAvance";
            this.LblAvance.Size = new System.Drawing.Size(71, 37);
            this.LblAvance.TabIndex = 119;
            this.LblAvance.Text = "0/N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "Puntuación actual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 118;
            this.label5.Text = "Competencias evaluadas:";
            // 
            // LblPuntuacion
            // 
            this.LblPuntuacion.AutoSize = true;
            this.LblPuntuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuntuacion.ForeColor = System.Drawing.Color.Red;
            this.LblPuntuacion.Location = new System.Drawing.Point(155, 24);
            this.LblPuntuacion.Name = "LblPuntuacion";
            this.LblPuntuacion.Size = new System.Drawing.Size(65, 37);
            this.LblPuntuacion.TabIndex = 117;
            this.LblPuntuacion.Text = "0%";
            // 
            // TxtProveedor
            // 
            this.TxtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProveedor.Location = new System.Drawing.Point(12, 24);
            this.TxtProveedor.Name = "TxtProveedor";
            this.TxtProveedor.ReadOnly = true;
            this.TxtProveedor.Size = new System.Drawing.Size(575, 29);
            this.TxtProveedor.TabIndex = 113;
            // 
            // LblBajoEvaluacion
            // 
            this.LblBajoEvaluacion.AutoSize = true;
            this.LblBajoEvaluacion.Location = new System.Drawing.Point(9, 8);
            this.LblBajoEvaluacion.Name = "LblBajoEvaluacion";
            this.LblBajoEvaluacion.Size = new System.Drawing.Size(56, 13);
            this.LblBajoEvaluacion.TabIndex = 112;
            this.LblBajoEvaluacion.Text = "Proveedor";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(906, 23);
            this.LblTitulo.TabIndex = 10;
            this.LblTitulo.Text = "EVALUAR  COMPETENCIAS DEL PROVEEDOR";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnFinalizar);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 393);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 63);
            this.panel2.TabIndex = 12;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(645, 0);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(124, 63);
            this.BtnFinalizar.TabIndex = 123;
            this.BtnFinalizar.Text = "      Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(769, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 63);
            this.BtnSalir.TabIndex = 122;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.ImagenesTabs;
            this.tabControl1.Location = new System.Drawing.Point(0, 139);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(906, 254);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgvHabilidadesProveedor);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(898, 211);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Puntos a evaluar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DgvHabilidadesProveedor
            // 
            this.DgvHabilidadesProveedor.AllowUserToAddRows = false;
            this.DgvHabilidadesProveedor.AllowUserToDeleteRows = false;
            this.DgvHabilidadesProveedor.AllowUserToResizeRows = false;
            this.DgvHabilidadesProveedor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvHabilidadesProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHabilidadesProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_habilidad,
            this.habilidad,
            this.descripcion_habilidad_personal,
            this.comentarios_habilidad,
            this.nivel_habilidad});
            this.DgvHabilidadesProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHabilidadesProveedor.Location = new System.Drawing.Point(3, 3);
            this.DgvHabilidadesProveedor.Name = "DgvHabilidadesProveedor";
            this.DgvHabilidadesProveedor.RowHeadersVisible = false;
            this.DgvHabilidadesProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHabilidadesProveedor.Size = new System.Drawing.Size(892, 205);
            this.DgvHabilidadesProveedor.TabIndex = 0;
            this.DgvHabilidadesProveedor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvHabilidadesProveedor_CellFormatting);
            this.DgvHabilidadesProveedor.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvHabilidadesProveedor_CellMouseClick);
            this.DgvHabilidadesProveedor.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvHabilidadesProveedor_CellMouseDown);
            // 
            // MenuEvaluar
            // 
            this.MenuEvaluar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluarToolStripMenuItem});
            this.MenuEvaluar.Name = "MenuEvaluar";
            this.MenuEvaluar.Size = new System.Drawing.Size(113, 26);
            // 
            // evaluarToolStripMenuItem
            // 
            this.evaluarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Nota;
            this.evaluarToolStripMenuItem.Name = "evaluarToolStripMenuItem";
            this.evaluarToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.evaluarToolStripMenuItem.Text = "Evaluar";
            this.evaluarToolStripMenuItem.Click += new System.EventHandler(this.evaluarToolStripMenuItem_Click);
            // 
            // id_habilidad
            // 
            this.id_habilidad.HeaderText = "ID Habilidad Personal";
            this.id_habilidad.Name = "id_habilidad";
            this.id_habilidad.ReadOnly = true;
            this.id_habilidad.Visible = false;
            this.id_habilidad.Width = 50;
            // 
            // habilidad
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.habilidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.habilidad.HeaderText = "Competencias";
            this.habilidad.Name = "habilidad";
            this.habilidad.ReadOnly = true;
            this.habilidad.Width = 280;
            // 
            // descripcion_habilidad_personal
            // 
            this.descripcion_habilidad_personal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle2;
            this.descripcion_habilidad_personal.HeaderText = "Descripción de la competencia";
            this.descripcion_habilidad_personal.Name = "descripcion_habilidad_personal";
            this.descripcion_habilidad_personal.ReadOnly = true;
            // 
            // comentarios_habilidad
            // 
            this.comentarios_habilidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios_habilidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.comentarios_habilidad.HeaderText = "Comentarios";
            this.comentarios_habilidad.Name = "comentarios_habilidad";
            this.comentarios_habilidad.ReadOnly = true;
            // 
            // nivel_habilidad
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nivel_habilidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.nivel_habilidad.HeaderText = "Nivel de desempeño observado";
            this.nivel_habilidad.Name = "nivel_habilidad";
            this.nivel_habilidad.ReadOnly = true;
            this.nivel_habilidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nivel_habilidad.Width = 180;
            // 
            // FrmEvaluarDesempenoProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 456);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.panel2);
            this.Name = "FrmEvaluarDesempenoProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluar desempeño";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEvaluarDesempenoProveedores_Load);
            this.MenuEvaluarHabilidad.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesProveedor)).EndInit();
            this.MenuEvaluar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem evaluarHabilidadToolStripMenuItem;
        private System.Windows.Forms.ImageList ImagenesTabs;
        private System.Windows.Forms.ContextMenuStrip MenuEvaluarHabilidad;
        private System.Windows.Forms.ToolStripMenuItem evaluarHabilidadToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtPuestoEvaluador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtEvaluador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblAvance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblPuntuacion;
        private System.Windows.Forms.TextBox TxtProveedor;
        private System.Windows.Forms.Label LblBajoEvaluacion;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DgvHabilidadesProveedor;
        private System.Windows.Forms.ContextMenuStrip MenuEvaluar;
        private System.Windows.Forms.ToolStripMenuItem evaluarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_habilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_habilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel_habilidad;
    }
}
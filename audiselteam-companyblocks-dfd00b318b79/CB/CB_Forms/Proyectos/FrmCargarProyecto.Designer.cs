namespace CB
{
    partial class FrmCargarProyecto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvProyectos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuActivar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activarProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblNumeroPlano = new System.Windows.Forms.Label();
            this.ChkMostrarInactivos = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFiltroProyecto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProyectos)).BeginInit();
            this.menuActivar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvProyectos
            // 
            this.DgvProyectos.AllowUserToAddRows = false;
            this.DgvProyectos.AllowUserToResizeRows = false;
            this.DgvProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProyectos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.DgvProyectos.ContextMenuStrip = this.menuActivar;
            this.DgvProyectos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProyectos.Location = new System.Drawing.Point(0, 0);
            this.DgvProyectos.Margin = new System.Windows.Forms.Padding(4);
            this.DgvProyectos.MultiSelect = false;
            this.DgvProyectos.Name = "DgvProyectos";
            this.DgvProyectos.ReadOnly = true;
            this.DgvProyectos.RowHeadersVisible = false;
            this.DgvProyectos.RowHeadersWidth = 51;
            this.DgvProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProyectos.Size = new System.Drawing.Size(1563, 660);
            this.DgvProyectos.TabIndex = 0;
            this.DgvProyectos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProyectos_CellDoubleClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Proyecto";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 350;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cliente";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Contacto";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "Estatus";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // menuActivar
            // 
            this.menuActivar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuActivar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarProyectoToolStripMenuItem,
            this.desactivarProyectoToolStripMenuItem});
            this.menuActivar.Name = "contextMenuStrip1";
            this.menuActivar.Size = new System.Drawing.Size(215, 84);
            this.menuActivar.Opening += new System.ComponentModel.CancelEventHandler(this.menuActivar_Opening);
            // 
            // activarProyectoToolStripMenuItem
            // 
            this.activarProyectoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.activarProyectoToolStripMenuItem.Name = "activarProyectoToolStripMenuItem";
            this.activarProyectoToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.activarProyectoToolStripMenuItem.Text = "Activar Proyecto";
            this.activarProyectoToolStripMenuItem.Click += new System.EventHandler(this.activarProyectoToolStripMenuItem_Click);
            // 
            // desactivarProyectoToolStripMenuItem
            // 
            this.desactivarProyectoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.desactivarProyectoToolStripMenuItem.Name = "desactivarProyectoToolStripMenuItem";
            this.desactivarProyectoToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.desactivarProyectoToolStripMenuItem.Text = "Desactivar Proyecto";
            this.desactivarProyectoToolStripMenuItem.Click += new System.EventHandler(this.desactivarProyectoToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnCancelar);
            this.splitContainer1.Panel1.Controls.Add(this.LblNumeroPlano);
            this.splitContainer1.Panel1.Controls.Add(this.ChkMostrarInactivos);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.TxtFiltroProyecto);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvProyectos);
            this.splitContainer1.Size = new System.Drawing.Size(1563, 740);
            this.splitContainer1.SplitterDistance = 75;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(1404, 28);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(159, 47);
            this.BtnCancelar.TabIndex = 17;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblNumeroPlano
            // 
            this.LblNumeroPlano.BackColor = System.Drawing.Color.Black;
            this.LblNumeroPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroPlano.ForeColor = System.Drawing.Color.White;
            this.LblNumeroPlano.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroPlano.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNumeroPlano.Name = "LblNumeroPlano";
            this.LblNumeroPlano.Size = new System.Drawing.Size(1563, 28);
            this.LblNumeroPlano.TabIndex = 8;
            this.LblNumeroPlano.Text = "CARGAR PROYECTO";
            this.LblNumeroPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChkMostrarInactivos
            // 
            this.ChkMostrarInactivos.AutoSize = true;
            this.ChkMostrarInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkMostrarInactivos.Location = new System.Drawing.Point(532, 44);
            this.ChkMostrarInactivos.Margin = new System.Windows.Forms.Padding(4);
            this.ChkMostrarInactivos.Name = "ChkMostrarInactivos";
            this.ChkMostrarInactivos.Size = new System.Drawing.Size(242, 33);
            this.ChkMostrarInactivos.TabIndex = 5;
            this.ChkMostrarInactivos.Text = "Mostrar terminados";
            this.ChkMostrarInactivos.UseVisualStyleBackColor = true;
            this.ChkMostrarInactivos.CheckedChanged += new System.EventHandler(this.ChkMostrarInactivos_CheckedChanged);
            this.ChkMostrarInactivos.CheckStateChanged += new System.EventHandler(this.ChkMostrarInactivos_CheckStateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Buscar:";
            // 
            // TxtFiltroProyecto
            // 
            this.TxtFiltroProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFiltroProyecto.Location = new System.Drawing.Point(135, 44);
            this.TxtFiltroProyecto.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFiltroProyecto.Name = "TxtFiltroProyecto";
            this.TxtFiltroProyecto.Size = new System.Drawing.Size(369, 34);
            this.TxtFiltroProyecto.TabIndex = 6;
            this.TxtFiltroProyecto.TextChanged += new System.EventHandler(this.TxtFiltroProyecto_TextChanged);
            // 
            // FrmCargarProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1563, 740);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCargarProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar Proyecto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FrmAdministrarProyectos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProyectos)).EndInit();
            this.menuActivar.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvProyectos;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox ChkMostrarInactivos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFiltroProyecto;
        private System.Windows.Forms.Label LblNumeroPlano;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ContextMenuStrip menuActivar;
        private System.Windows.Forms.ToolStripMenuItem activarProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivarProyectoToolStripMenuItem;
    }
}
namespace CB
{
    partial class FrmFechasProyecto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvFechasProyecto = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inicio_etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cierre_etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnOpciones = new System.Windows.Forms.Button();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFechasProyecto)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.borrarToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(153, 92);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnOpciones);
            this.splitContainer1.Panel1.Controls.Add(this.LblTitulo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvFechasProyecto);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 552);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 8;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1168, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "FECHAS PROYECTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvFechasProyecto
            // 
            this.DgvFechasProyecto.AllowUserToAddRows = false;
            this.DgvFechasProyecto.AllowUserToDeleteRows = false;
            this.DgvFechasProyecto.AllowUserToResizeRows = false;
            this.DgvFechasProyecto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFechasProyecto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvFechasProyecto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFechasProyecto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.etapa,
            this.inicio_etapa,
            this.cierre_etapa});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFechasProyecto.DefaultCellStyle = dataGridViewCellStyle12;
            this.DgvFechasProyecto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvFechasProyecto.Location = new System.Drawing.Point(0, 0);
            this.DgvFechasProyecto.Name = "DgvFechasProyecto";
            this.DgvFechasProyecto.ReadOnly = true;
            this.DgvFechasProyecto.RowHeadersVisible = false;
            this.DgvFechasProyecto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFechasProyecto.Size = new System.Drawing.Size(1168, 464);
            this.DgvFechasProyecto.TabIndex = 0;
            this.DgvFechasProyecto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFechasProyecto_CellClick);
            // 
            // id
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle8;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 50;
            // 
            // etapa
            // 
            this.etapa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.etapa.DefaultCellStyle = dataGridViewCellStyle9;
            this.etapa.HeaderText = "Etapa";
            this.etapa.Name = "etapa";
            this.etapa.ReadOnly = true;
            // 
            // inicio_etapa
            // 
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inicio_etapa.DefaultCellStyle = dataGridViewCellStyle10;
            this.inicio_etapa.HeaderText = "Inicio";
            this.inicio_etapa.Name = "inicio_etapa";
            this.inicio_etapa.ReadOnly = true;
            this.inicio_etapa.Width = 400;
            // 
            // cierre_etapa
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cierre_etapa.DefaultCellStyle = dataGridViewCellStyle11;
            this.cierre_etapa.HeaderText = "Cierre";
            this.cierre_etapa.Name = "cierre_etapa";
            this.cierre_etapa.ReadOnly = true;
            this.cierre_etapa.Width = 400;
            // 
            // BtnOpciones
            // 
            this.BtnOpciones.ContextMenuStrip = this.MenuOpciones;
            this.BtnOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpciones.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnOpciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpciones.Location = new System.Drawing.Point(1049, 23);
            this.BtnOpciones.Name = "BtnOpciones";
            this.BtnOpciones.Size = new System.Drawing.Size(119, 61);
            this.BtnOpciones.TabIndex = 20;
            this.BtnOpciones.Text = "Opciones";
            this.BtnOpciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpciones.UseVisualStyleBackColor = true;
            this.BtnOpciones.Click += new System.EventHandler(this.BtnOpciones_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Enabled = false;
            this.nuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Agregar etapa";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Enabled = false;
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editarToolStripMenuItem.Text = " Editar etapa";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Enabled = false;
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // FrmFechasProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 552);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmFechasProyecto";
            this.Text = "Fechas del proyecto";
            this.Load += new System.EventHandler(this.FrmFechasProyecto_Load);
            this.MenuOpciones.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFechasProyecto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvFechasProyecto;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnOpciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn inicio_etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cierre_etapa;
    }
}
namespace CB
{
    partial class FrmMonitorProyecto
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnOpciones = new System.Windows.Forms.Button();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seguimientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmbEtapa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbProyecto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvMonitorProyecto = new System.Windows.Forms.DataGridView();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subensamble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_trabajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MenuOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMonitorProyecto)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnOpciones);
            this.splitContainer1.Panel1.Controls.Add(this.CmbEtapa);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.CmbProyecto);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.LblTitulo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvMonitorProyecto);
            this.splitContainer1.Size = new System.Drawing.Size(927, 619);
            this.splitContainer1.SplitterDistance = 102;
            this.splitContainer1.TabIndex = 0;
            // 
            // BtnOpciones
            // 
            this.BtnOpciones.ContextMenuStrip = this.MenuOpciones;
            this.BtnOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpciones.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnOpciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpciones.Location = new System.Drawing.Point(808, 23);
            this.BtnOpciones.Name = "BtnOpciones";
            this.BtnOpciones.Size = new System.Drawing.Size(119, 79);
            this.BtnOpciones.TabIndex = 10;
            this.BtnOpciones.Text = "Opciones";
            this.BtnOpciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpciones.UseVisualStyleBackColor = true;
            this.BtnOpciones.Click += new System.EventHandler(this.BtnOpciones_Click);
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seguimientToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(142, 26);
            // 
            // seguimientToolStripMenuItem
            // 
            this.seguimientToolStripMenuItem.Name = "seguimientToolStripMenuItem";
            this.seguimientToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.seguimientToolStripMenuItem.Text = "Seguimiento";
            this.seguimientToolStripMenuItem.Click += new System.EventHandler(this.seguimientoToolStripMenuItem_Click);
            // 
            // CmbEtapa
            // 
            this.CmbEtapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEtapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEtapa.FormattingEnabled = true;
            this.CmbEtapa.Items.AddRange(new object[] {
            "",
            "DOCUMENTACION MECANICA",
            "REVISION DE PLANOS",
            "FABRICACION",
            "TRATAMIENTO DE MATERIALES",
            "ENSAMBLE"});
            this.CmbEtapa.Location = new System.Drawing.Point(466, 54);
            this.CmbEtapa.Name = "CmbEtapa";
            this.CmbEtapa.Size = new System.Drawing.Size(322, 32);
            this.CmbEtapa.TabIndex = 9;
            this.CmbEtapa.SelectedIndexChanged += new System.EventHandler(this.CmbEtapa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Etapa: ";
            // 
            // CmbProyecto
            // 
            this.CmbProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProyecto.FormattingEnabled = true;
            this.CmbProyecto.Location = new System.Drawing.Point(6, 54);
            this.CmbProyecto.Name = "CmbProyecto";
            this.CmbProyecto.Size = new System.Drawing.Size(436, 32);
            this.CmbProyecto.TabIndex = 7;
            this.CmbProyecto.SelectedIndexChanged += new System.EventHandler(this.CmbProyecto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Proyecto: ";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(927, 23);
            this.LblTitulo.TabIndex = 5;
            this.LblTitulo.Text = "MONITOR DE PROYECTOS";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvMonitorProyecto
            // 
            this.DgvMonitorProyecto.AllowUserToAddRows = false;
            this.DgvMonitorProyecto.AllowUserToDeleteRows = false;
            this.DgvMonitorProyecto.AllowUserToResizeRows = false;
            this.DgvMonitorProyecto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMonitorProyecto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMonitorProyecto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMonitorProyecto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modulo,
            this.subensamble,
            this.total_trabajo,
            this.avance,
            this.responsable,
            this.fecha_promesa,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvMonitorProyecto.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvMonitorProyecto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMonitorProyecto.Location = new System.Drawing.Point(0, 0);
            this.DgvMonitorProyecto.Name = "DgvMonitorProyecto";
            this.DgvMonitorProyecto.RowHeadersVisible = false;
            this.DgvMonitorProyecto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMonitorProyecto.Size = new System.Drawing.Size(927, 513);
            this.DgvMonitorProyecto.TabIndex = 0;
            this.DgvMonitorProyecto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMonitorProyecto_CellClick);
            // 
            // modulo
            // 
            this.modulo.HeaderText = "Modulo";
            this.modulo.Name = "modulo";
            // 
            // subensamble
            // 
            this.subensamble.HeaderText = "Subensamble";
            this.subensamble.Name = "subensamble";
            // 
            // total_trabajo
            // 
            this.total_trabajo.HeaderText = "Total trabajo";
            this.total_trabajo.Name = "total_trabajo";
            // 
            // avance
            // 
            this.avance.HeaderText = "Avance";
            this.avance.Name = "avance";
            // 
            // responsable
            // 
            this.responsable.HeaderText = "Responsable";
            this.responsable.Name = "responsable";
            // 
            // fecha_promesa
            // 
            this.fecha_promesa.HeaderText = "Fecha promesa";
            this.fecha_promesa.Name = "fecha_promesa";
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // FrmMonitorProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 619);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMonitorProyecto";
            this.Text = "Monitor de proyectos";
            this.Load += new System.EventHandler(this.FrmMonitorProyecto_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.MenuOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMonitorProyecto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ComboBox CmbProyecto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbEtapa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvMonitorProyecto;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem seguimientToolStripMenuItem;
        private System.Windows.Forms.Button BtnOpciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn subensamble;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_trabajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn avance;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}
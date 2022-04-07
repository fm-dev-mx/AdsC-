namespace CB
{
    partial class FrmAlcanceProyecto
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
            this.DgvAlcance = new System.Windows.Forms.DataGridView();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoAlcanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alcance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlcance)).BeginInit();
            this.Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvAlcance
            // 
            this.DgvAlcance.AllowUserToAddRows = false;
            this.DgvAlcance.AllowUserToDeleteRows = false;
            this.DgvAlcance.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAlcance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAlcance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlcance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.proceso,
            this.alcance,
            this.personas,
            this.horas});
            this.DgvAlcance.ContextMenuStrip = this.Menu;
            this.DgvAlcance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAlcance.Location = new System.Drawing.Point(0, 73);
            this.DgvAlcance.Name = "DgvAlcance";
            this.DgvAlcance.RowHeadersVisible = false;
            this.DgvAlcance.Size = new System.Drawing.Size(800, 313);
            this.DgvAlcance.TabIndex = 2;
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoAlcanceToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(153, 70);
            this.Menu.Opening += new System.ComponentModel.CancelEventHandler(this.Menu_Opening);
            // 
            // nuevoAlcanceToolStripMenuItem
            // 
            this.nuevoAlcanceToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevoAlcanceToolStripMenuItem.Name = "nuevoAlcanceToolStripMenuItem";
            this.nuevoAlcanceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoAlcanceToolStripMenuItem.Text = "Nuevo alcance";
            this.nuevoAlcanceToolStripMenuItem.Click += new System.EventHandler(this.nuevoAlcanceToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar ";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CB_Base.Properties.Resources.exit;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(677, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "      Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(800, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "ALCANCE";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "id";
            this.Column1.MinimumWidth = 50;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // proceso
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proceso.DefaultCellStyle = dataGridViewCellStyle3;
            this.proceso.HeaderText = "Process";
            this.proceso.MinimumWidth = 200;
            this.proceso.Name = "proceso";
            this.proceso.ReadOnly = true;
            this.proceso.Width = 200;
            // 
            // alcance
            // 
            this.alcance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alcance.DefaultCellStyle = dataGridViewCellStyle4;
            this.alcance.HeaderText = "Alcance";
            this.alcance.MinimumWidth = 100;
            this.alcance.Name = "alcance";
            this.alcance.ReadOnly = true;
            // 
            // personas
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.personas.DefaultCellStyle = dataGridViewCellStyle5;
            this.personas.HeaderText = "Personas";
            this.personas.Name = "personas";
            this.personas.ReadOnly = true;
            // 
            // horas
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.horas.DefaultCellStyle = dataGridViewCellStyle6;
            this.horas.HeaderText = "Horas";
            this.horas.MinimumWidth = 100;
            this.horas.Name = "horas";
            this.horas.ReadOnly = true;
            // 
            // FrmAlcanceProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 386);
            this.Controls.Add(this.DgvAlcance);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.Name = "FrmAlcanceProyecto";
            this.Text = "Alcance del proyecto";
            this.Load += new System.EventHandler(this.FrmAlcanceProyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlcance)).EndInit();
            this.Menu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.DataGridView DgvAlcance;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem nuevoAlcanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn alcance;
        private System.Windows.Forms.DataGridViewTextBoxColumn personas;
        private System.Windows.Forms.DataGridViewTextBoxColumn horas;
    }
}
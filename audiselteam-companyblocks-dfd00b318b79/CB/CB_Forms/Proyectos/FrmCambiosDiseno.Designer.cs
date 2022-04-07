namespace CB
{
    partial class FrmCambiosDiseno
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvCambiosDiseno = new System.Windows.Forms.DataGridView();
            this.MenuCambiosDiseno = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alcance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulos_afectados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solicitado_por = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_solicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCambiosDiseno)).BeginInit();
            this.MenuCambiosDiseno.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1034, 23);
            this.LblTitulo.TabIndex = 35;
            this.LblTitulo.Text = "CAMBIOS DE DISEÑO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvCambiosDiseno
            // 
            this.DgvCambiosDiseno.AllowUserToAddRows = false;
            this.DgvCambiosDiseno.AllowUserToDeleteRows = false;
            this.DgvCambiosDiseno.AllowUserToResizeRows = false;
            this.DgvCambiosDiseno.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvCambiosDiseno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCambiosDiseno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipo,
            this.motivo,
            this.alcance,
            this.modulos_afectados,
            this.solicitado_por,
            this.fecha_solicitud});
            this.DgvCambiosDiseno.ContextMenuStrip = this.MenuCambiosDiseno;
            this.DgvCambiosDiseno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCambiosDiseno.Location = new System.Drawing.Point(0, 23);
            this.DgvCambiosDiseno.Name = "DgvCambiosDiseno";
            this.DgvCambiosDiseno.ReadOnly = true;
            this.DgvCambiosDiseno.RowHeadersVisible = false;
            this.DgvCambiosDiseno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCambiosDiseno.Size = new System.Drawing.Size(1034, 355);
            this.DgvCambiosDiseno.TabIndex = 36;
            // 
            // MenuCambiosDiseno
            // 
            this.MenuCambiosDiseno.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem});
            this.MenuCambiosDiseno.Name = "MenuCambiosDiseno";
            this.MenuCambiosDiseno.Size = new System.Drawing.Size(110, 26);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 60;
            // 
            // tipo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipo.DefaultCellStyle = dataGridViewCellStyle2;
            this.tipo.Frozen = true;
            this.tipo.HeaderText = "Tipo de cambio";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 160;
            // 
            // motivo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.motivo.DefaultCellStyle = dataGridViewCellStyle3;
            this.motivo.Frozen = true;
            this.motivo.HeaderText = "Motivo del cambio";
            this.motivo.Name = "motivo";
            this.motivo.ReadOnly = true;
            this.motivo.Width = 160;
            // 
            // alcance
            // 
            this.alcance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alcance.DefaultCellStyle = dataGridViewCellStyle4;
            this.alcance.Frozen = true;
            this.alcance.HeaderText = "Alcance";
            this.alcance.Name = "alcance";
            this.alcance.ReadOnly = true;
            this.alcance.Width = 310;
            // 
            // modulos_afectados
            // 
            this.modulos_afectados.HeaderText = "Módulos afectados";
            this.modulos_afectados.Name = "modulos_afectados";
            this.modulos_afectados.ReadOnly = true;
            this.modulos_afectados.Width = 300;
            // 
            // solicitado_por
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.solicitado_por.DefaultCellStyle = dataGridViewCellStyle5;
            this.solicitado_por.HeaderText = "Solicitado por";
            this.solicitado_por.Name = "solicitado_por";
            this.solicitado_por.ReadOnly = true;
            this.solicitado_por.Width = 180;
            // 
            // fecha_solicitud
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_solicitud.DefaultCellStyle = dataGridViewCellStyle6;
            this.fecha_solicitud.HeaderText = "Fecha de solicitud";
            this.fecha_solicitud.Name = "fecha_solicitud";
            this.fecha_solicitud.ReadOnly = true;
            this.fecha_solicitud.Width = 180;
            // 
            // FrmCambiosDiseno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 378);
            this.Controls.Add(this.DgvCambiosDiseno);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmCambiosDiseno";
            this.Text = "Cambios de diseño";
            this.Load += new System.EventHandler(this.FrmCambiosDiseno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCambiosDiseno)).EndInit();
            this.MenuCambiosDiseno.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridView DgvCambiosDiseno;
        private System.Windows.Forms.ContextMenuStrip MenuCambiosDiseno;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn alcance;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulos_afectados;
        private System.Windows.Forms.DataGridViewTextBoxColumn solicitado_por;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_solicitud;
    }
}
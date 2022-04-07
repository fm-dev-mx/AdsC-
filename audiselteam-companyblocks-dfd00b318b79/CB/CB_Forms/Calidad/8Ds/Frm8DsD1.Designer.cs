namespace CB
{
    partial class Frm8DsD1
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
            this.DgvEquipo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.causa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuEquipo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TooltipAyuda = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.CmbUsuario = new System.Windows.Forms.ComboBox();
            this.CmbRol = new System.Windows.Forms.ComboBox();
            this.quitarIntegranteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEquipo)).BeginInit();
            this.MenuEquipo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvEquipo
            // 
            this.DgvEquipo.AllowUserToAddRows = false;
            this.DgvEquipo.AllowUserToDeleteRows = false;
            this.DgvEquipo.AllowUserToResizeRows = false;
            this.DgvEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEquipo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.rol,
            this.causa});
            this.DgvEquipo.ContextMenuStrip = this.MenuEquipo;
            this.DgvEquipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvEquipo.Location = new System.Drawing.Point(0, 105);
            this.DgvEquipo.Name = "DgvEquipo";
            this.DgvEquipo.ReadOnly = true;
            this.DgvEquipo.RowHeadersVisible = false;
            this.DgvEquipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEquipo.Size = new System.Drawing.Size(1006, 286);
            this.DgvEquipo.TabIndex = 36;
            this.DgvEquipo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvEquipo_MouseDown);
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 60;
            // 
            // rol
            // 
            this.rol.HeaderText = "Rol";
            this.rol.Name = "rol";
            this.rol.ReadOnly = true;
            this.rol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rol.Width = 250;
            // 
            // causa
            // 
            this.causa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.causa.DefaultCellStyle = dataGridViewCellStyle2;
            this.causa.HeaderText = "Nombre";
            this.causa.Name = "causa";
            this.causa.ReadOnly = true;
            this.causa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MenuEquipo
            // 
            this.MenuEquipo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitarIntegranteToolStripMenuItem});
            this.MenuEquipo.Name = "MenuEquipo";
            this.MenuEquipo.Size = new System.Drawing.Size(165, 26);
            this.MenuEquipo.Opening += new System.ComponentModel.CancelEventHandler(this.MenuEquipo_Opening);
            // 
            // TooltipAyuda
            // 
            this.TooltipAyuda.IsBalloon = true;
            this.TooltipAyuda.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TooltipAyuda.ToolTipTitle = "D1- Establece un grupo para solucionar el problema";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BtnAgregar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Controls.Add(this.CmbUsuario);
            this.panel1.Controls.Add(this.CmbRol);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 105);
            this.panel1.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1006, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "SELECCIONAR NUEVO INTEGRANTE:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Rol:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.Black;
            this.LblTitulo.Location = new System.Drawing.Point(0, 85);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1006, 20);
            this.LblTitulo.TabIndex = 44;
            this.LblTitulo.Text = "INTEGRANTES SELECCIONADOS EN EL GRUPO PARA SOLUCIONAR EL PROBLEMA::";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbUsuario
            // 
            this.CmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUsuario.FormattingEnabled = true;
            this.CmbUsuario.Location = new System.Drawing.Point(358, 46);
            this.CmbUsuario.Name = "CmbUsuario";
            this.CmbUsuario.Size = new System.Drawing.Size(409, 28);
            this.CmbUsuario.TabIndex = 1;
            this.CmbUsuario.SelectedIndexChanged += new System.EventHandler(this.CmbUsuario_SelectedIndexChanged);
            // 
            // CmbRol
            // 
            this.CmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRol.FormattingEnabled = true;
            this.CmbRol.Location = new System.Drawing.Point(12, 46);
            this.CmbRol.Name = "CmbRol";
            this.CmbRol.Size = new System.Drawing.Size(326, 28);
            this.CmbRol.TabIndex = 0;
            this.CmbRol.SelectedIndexChanged += new System.EventHandler(this.CmbRol_SelectedIndexChanged);
            // 
            // quitarIntegranteToolStripMenuItem
            // 
            this.quitarIntegranteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.quitarIntegranteToolStripMenuItem.Name = "quitarIntegranteToolStripMenuItem";
            this.quitarIntegranteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.quitarIntegranteToolStripMenuItem.Text = "Quitar integrante";
            this.quitarIntegranteToolStripMenuItem.Click += new System.EventHandler(this.quitarIntegranteToolStripMenuItem_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Enabled = false;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(785, 28);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(146, 46);
            this.BtnAgregar.TabIndex = 47;
            this.BtnAgregar.Text = "Seleccionar  ";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // Frm8DsD1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 391);
            this.ControlBox = false;
            this.Controls.Add(this.DgvEquipo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm8DsD1";
            this.Text = "Metodología 8D - D1 Establecer un grupo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm8DsD1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEquipo)).EndInit();
            this.MenuEquipo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvEquipo;
        private System.Windows.Forms.ToolTip TooltipAyuda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CmbUsuario;
        private System.Windows.Forms.ComboBox CmbRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn causa;
        private System.Windows.Forms.ContextMenuStrip MenuEquipo;
        private System.Windows.Forms.ToolStripMenuItem quitarIntegranteToolStripMenuItem;
    }
}
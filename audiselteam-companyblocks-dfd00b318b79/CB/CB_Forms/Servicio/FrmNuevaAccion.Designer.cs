namespace CB
{
    partial class FrmNuevaAccion
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
            this.LblEstatus = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDetalles = new System.Windows.Forms.TextBox();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DateFechaPromesa = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DgvResponsable = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuResponsables = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DgvResponsable)).BeginInit();
            this.MenuResponsables.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblEstatus
            // 
            this.LblEstatus.AutoSize = true;
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.ForeColor = System.Drawing.Color.Red;
            this.LblEstatus.Location = new System.Drawing.Point(9, 350);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(80, 16);
            this.LblEstatus.TabIndex = 50;
            this.LblEstatus.Text = "LblEstatus";
            this.LblEstatus.Visible = false;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(397, 350);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 40);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Enabled = false;
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(567, 350);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(155, 40);
            this.BtnRegistrar.TabIndex = 6;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Nombre:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(12, 99);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(372, 30);
            this.TxtNombre.TabIndex = 2;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Detalles:";
            // 
            // TxtDetalles
            // 
            this.TxtDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtDetalles.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDetalles.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDetalles.Location = new System.Drawing.Point(12, 149);
            this.TxtDetalles.Multiline = true;
            this.TxtDetalles.Name = "TxtDetalles";
            this.TxtDetalles.Size = new System.Drawing.Size(372, 140);
            this.TxtDetalles.TabIndex = 3;
            this.TxtDetalles.TextChanged += new System.EventHandler(this.TxtDetalles_TextChanged);
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Items.AddRange(new object[] {
            "CONTENCION",
            "CORRECTIVA",
            "PREVENTIVA"});
            this.CmbTipo.Location = new System.Drawing.Point(12, 48);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(212, 28);
            this.CmbTipo.TabIndex = 1;
            this.CmbTipo.SelectedIndexChanged += new System.EventHandler(this.CmbTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tipo de acción: ";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(734, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "NUEVA ACCION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Fecha promesa:";
            // 
            // DateFechaPromesa
            // 
            this.DateFechaPromesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFechaPromesa.Location = new System.Drawing.Point(13, 312);
            this.DateFechaPromesa.Name = "DateFechaPromesa";
            this.DateFechaPromesa.Size = new System.Drawing.Size(371, 26);
            this.DateFechaPromesa.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(394, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Responsables:";
            // 
            // DgvResponsable
            // 
            this.DgvResponsable.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.DgvResponsable.AllowUserToAddRows = false;
            this.DgvResponsable.AllowUserToResizeColumns = false;
            this.DgvResponsable.AllowUserToResizeRows = false;
            this.DgvResponsable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvResponsable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.responsable});
            this.DgvResponsable.ContextMenuStrip = this.MenuResponsables;
            this.DgvResponsable.Location = new System.Drawing.Point(397, 48);
            this.DgvResponsable.Name = "DgvResponsable";
            this.DgvResponsable.RowHeadersVisible = false;
            this.DgvResponsable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvResponsable.Size = new System.Drawing.Size(325, 290);
            this.DgvResponsable.TabIndex = 4;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // responsable
            // 
            this.responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.responsable.HeaderText = "Nombre";
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            // 
            // MenuResponsables
            // 
            this.MenuResponsables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarToolStripMenuItem});
            this.MenuResponsables.Name = "MenuResponsables";
            this.MenuResponsables.Size = new System.Drawing.Size(144, 26);
            // 
            // seleccionarToolStripMenuItem
            // 
            this.seleccionarToolStripMenuItem.Name = "seleccionarToolStripMenuItem";
            this.seleccionarToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.seleccionarToolStripMenuItem.Text = "Seleccionar...";
            this.seleccionarToolStripMenuItem.Click += new System.EventHandler(this.seleccionarToolStripMenuItem_Click);
            // 
            // FrmNuevaAccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 398);
            this.Controls.Add(this.DgvResponsable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DateFechaPromesa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblEstatus);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDetalles);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaAccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva accion";
            this.Load += new System.EventHandler(this.FrmNuevaAccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvResponsable)).EndInit();
            this.MenuResponsables.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDetalles;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DateFechaPromesa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DgvResponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.ContextMenuStrip MenuResponsables;
        private System.Windows.Forms.ToolStripMenuItem seleccionarToolStripMenuItem;
    }
}
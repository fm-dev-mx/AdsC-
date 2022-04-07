namespace CB
{
    partial class FrmAsignarHabilidad
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
            this.DgvPrivilegios = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAsignar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbCategorias = new System.Windows.Forms.ComboBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrivilegios)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPrivilegios
            // 
            this.DgvPrivilegios.AllowUserToAddRows = false;
            this.DgvPrivilegios.AllowUserToDeleteRows = false;
            this.DgvPrivilegios.AllowUserToResizeColumns = false;
            this.DgvPrivilegios.AllowUserToResizeRows = false;
            this.DgvPrivilegios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPrivilegios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column1});
            this.DgvPrivilegios.Location = new System.Drawing.Point(13, 92);
            this.DgvPrivilegios.Name = "DgvPrivilegios";
            this.DgvPrivilegios.ReadOnly = true;
            this.DgvPrivilegios.RowHeadersVisible = false;
            this.DgvPrivilegios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPrivilegios.Size = new System.Drawing.Size(310, 219);
            this.DgvPrivilegios.TabIndex = 18;
            this.DgvPrivilegios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPrivilegios_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Privilegio";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 310;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(13, 317);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(150, 40);
            this.BtnCancelar.TabIndex = 17;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Enabled = false;
            this.BtnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsignar.Location = new System.Drawing.Point(173, 317);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(150, 40);
            this.BtnAsignar.TabIndex = 16;
            this.BtnAsignar.Text = "Asignar";
            this.BtnAsignar.UseVisualStyleBackColor = true;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Categoría:";
            // 
            // CmbCategorias
            // 
            this.CmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategorias.FormattingEnabled = true;
            this.CmbCategorias.Location = new System.Drawing.Point(12, 54);
            this.CmbCategorias.Name = "CmbCategorias";
            this.CmbCategorias.Size = new System.Drawing.Size(311, 32);
            this.CmbCategorias.TabIndex = 14;
            this.CmbCategorias.SelectedIndexChanged += new System.EventHandler(this.CmbCategorias_SelectedIndexChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(343, 23);
            this.LblTitulo.TabIndex = 13;
            this.LblTitulo.Text = "ASIGNAR HABILIDAD";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmAsignarHabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 382);
            this.Controls.Add(this.DgvPrivilegios);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAsignar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbCategorias);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAsignarHabilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAsignarHabilidad";
            this.Load += new System.EventHandler(this.FrmAsignarHabilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrivilegios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPrivilegios;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAsignar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbCategorias;
        private System.Windows.Forms.Label LblTitulo;

    }
}
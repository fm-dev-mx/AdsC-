namespace CB
{
    partial class FrmNuevoPasoModulo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtAccion = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvElementos = new System.Windows.Forms.DataGridView();
            this.id_elemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvElementos)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(12, 326);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 40);
            this.BtnCancelar.TabIndex = 41;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Enabled = false;
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Location = new System.Drawing.Point(176, 326);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(176, 40);
            this.BtnRegistrar.TabIndex = 40;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Acción *";
            // 
            // TxtAccion
            // 
            this.TxtAccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAccion.Location = new System.Drawing.Point(13, 200);
            this.TxtAccion.Multiline = true;
            this.TxtAccion.Name = "TxtAccion";
            this.TxtAccion.Size = new System.Drawing.Size(339, 117);
            this.TxtAccion.TabIndex = 38;
            this.TxtAccion.TextChanged += new System.EventHandler(this.TxtAccion_TextChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(364, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "NUEVO PASO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // DgvElementos
            // 
            this.DgvElementos.AllowUserToAddRows = false;
            this.DgvElementos.AllowUserToDeleteRows = false;
            this.DgvElementos.AllowUserToResizeRows = false;
            this.DgvElementos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvElementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvElementos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_elemento,
            this.elemento});
            this.DgvElementos.Location = new System.Drawing.Point(12, 34);
            this.DgvElementos.MultiSelect = false;
            this.DgvElementos.Name = "DgvElementos";
            this.DgvElementos.ReadOnly = true;
            this.DgvElementos.RowHeadersVisible = false;
            this.DgvElementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvElementos.Size = new System.Drawing.Size(340, 143);
            this.DgvElementos.TabIndex = 42;
            // 
            // id_elemento
            // 
            this.id_elemento.HeaderText = "ID";
            this.id_elemento.Name = "id_elemento";
            this.id_elemento.ReadOnly = true;
            this.id_elemento.Visible = false;
            // 
            // elemento
            // 
            this.elemento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.elemento.DefaultCellStyle = dataGridViewCellStyle3;
            this.elemento.HeaderText = "Elemento";
            this.elemento.Name = "elemento";
            this.elemento.ReadOnly = true;
            // 
            // FrmNuevoPasoModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 378);
            this.Controls.Add(this.DgvElementos);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtAccion);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoPasoModulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevoPasoModulo";
            this.Load += new System.EventHandler(this.FrmNuevoPasoModulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvElementos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtAccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.DataGridView DgvElementos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_elemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn elemento;
    }
}
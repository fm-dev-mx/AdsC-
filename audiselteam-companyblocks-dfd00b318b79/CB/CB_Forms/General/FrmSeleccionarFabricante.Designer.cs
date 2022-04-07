namespace CB
{
    partial class FrmSeleccionarFabricante
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.DgvFabricantes = new System.Windows.Forms.DataGridView();
            this.fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFabricantes)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(448, 23);
            this.LblTitulo.TabIndex = 87;
            this.LblTitulo.Text = "SELECCIONAR FABRICANTE";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(288, 277);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 40);
            this.BtnCancelar.TabIndex = 89;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // DgvFabricantes
            // 
            this.DgvFabricantes.AllowUserToAddRows = false;
            this.DgvFabricantes.AllowUserToDeleteRows = false;
            this.DgvFabricantes.AllowUserToResizeColumns = false;
            this.DgvFabricantes.AllowUserToResizeRows = false;
            this.DgvFabricantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFabricantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fabricante});
            this.DgvFabricantes.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvFabricantes.Location = new System.Drawing.Point(0, 23);
            this.DgvFabricantes.Name = "DgvFabricantes";
            this.DgvFabricantes.RowHeadersVisible = false;
            this.DgvFabricantes.Size = new System.Drawing.Size(448, 253);
            this.DgvFabricantes.TabIndex = 90;
            this.DgvFabricantes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFabricantes_CellDoubleClick);
            // 
            // fabricante
            // 
            this.fabricante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fabricante.DefaultCellStyle = dataGridViewCellStyle3;
            this.fabricante.HeaderText = "Fabricante";
            this.fabricante.Name = "fabricante";
            // 
            // FrmSeleccionarFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 317);
            this.Controls.Add(this.DgvFabricantes);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeleccionarFabricante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSeleccionarFabricante";
            this.Load += new System.EventHandler(this.FrmSeleccionarFabricante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFabricantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridView DgvFabricantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricante;
    }
}
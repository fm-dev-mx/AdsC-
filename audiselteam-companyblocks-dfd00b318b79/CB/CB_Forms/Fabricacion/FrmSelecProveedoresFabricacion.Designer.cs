namespace CB
{
    partial class FrmSelecProveedoresFabricacion
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
            this.DgvProveedores = new System.Windows.Forms.DataGridView();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCotizar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvProveedores
            // 
            this.DgvProveedores.AllowUserToAddRows = false;
            this.DgvProveedores.AllowUserToDeleteRows = false;
            this.DgvProveedores.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccion,
            this.id_proveedor,
            this.nombre});
            this.DgvProveedores.Location = new System.Drawing.Point(11, 32);
            this.DgvProveedores.Name = "DgvProveedores";
            this.DgvProveedores.RowHeadersVisible = false;
            this.DgvProveedores.Size = new System.Drawing.Size(365, 204);
            this.DgvProveedores.TabIndex = 0;
            // 
            // seleccion
            // 
            this.seleccion.HeaderText = "";
            this.seleccion.Name = "seleccion";
            this.seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seleccion.Width = 50;
            // 
            // id_proveedor
            // 
            this.id_proveedor.HeaderText = "ID";
            this.id_proveedor.Name = "id_proveedor";
            this.id_proveedor.Width = 70;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.Width = 230;
            // 
            // BtnCotizar
            // 
            this.BtnCotizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCotizar.Location = new System.Drawing.Point(186, 279);
            this.BtnCotizar.Name = "BtnCotizar";
            this.BtnCotizar.Size = new System.Drawing.Size(177, 42);
            this.BtnCotizar.TabIndex = 1;
            this.BtnCotizar.Text = "Cotizar";
            this.BtnCotizar.UseVisualStyleBackColor = true;
            this.BtnCotizar.Click += new System.EventHandler(this.BtnCotizar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(15, 279);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(165, 42);
            this.BtnCancelar.TabIndex = 2;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(376, 23);
            this.LblTitulo.TabIndex = 3;
            this.LblTitulo.Text = "PROVEEDORES A COTIZAR";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblError
            // 
            this.LblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.Red;
            this.LblError.Location = new System.Drawing.Point(12, 249);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(351, 27);
            this.LblError.TabIndex = 4;
            this.LblError.Text = "Error";
            this.LblError.Visible = false;
            // 
            // FrmSelecProveedoresFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 333);
            this.Controls.Add(this.BtnCotizar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.DgvProveedores);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSelecProveedoresFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.DgvProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvProveedores;
        private System.Windows.Forms.Button BtnCotizar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblError;
    }
}
namespace CB
{
    partial class FrmFiltrarDatos
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
            this.LblTituloComponente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbColumnas = new System.Windows.Forms.ComboBox();
            this.DgvValores = new System.Windows.Forms.DataGridView();
            this.filtro = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAplicar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSeleccionarNada = new System.Windows.Forms.Button();
            this.BtnSeleccionarTodos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DgvValores)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTituloComponente
            // 
            this.LblTituloComponente.BackColor = System.Drawing.Color.Black;
            this.LblTituloComponente.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTituloComponente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloComponente.ForeColor = System.Drawing.Color.White;
            this.LblTituloComponente.Location = new System.Drawing.Point(0, 0);
            this.LblTituloComponente.Name = "LblTituloComponente";
            this.LblTituloComponente.Size = new System.Drawing.Size(429, 23);
            this.LblTituloComponente.TabIndex = 34;
            this.LblTituloComponente.Text = "FILTRAR DATOS";
            this.LblTituloComponente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTituloComponente.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTituloComponente_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Columna:";
            // 
            // CmbColumnas
            // 
            this.CmbColumnas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbColumnas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbColumnas.FormattingEnabled = true;
            this.CmbColumnas.Location = new System.Drawing.Point(12, 51);
            this.CmbColumnas.Name = "CmbColumnas";
            this.CmbColumnas.Size = new System.Drawing.Size(404, 32);
            this.CmbColumnas.TabIndex = 35;
            this.CmbColumnas.SelectedIndexChanged += new System.EventHandler(this.CmbColumnas_SelectedIndexChanged);
            // 
            // DgvValores
            // 
            this.DgvValores.AllowUserToAddRows = false;
            this.DgvValores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvValores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filtro,
            this.valor});
            this.DgvValores.Location = new System.Drawing.Point(13, 89);
            this.DgvValores.MultiSelect = false;
            this.DgvValores.Name = "DgvValores";
            this.DgvValores.RowHeadersVisible = false;
            this.DgvValores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvValores.Size = new System.Drawing.Size(404, 241);
            this.DgvValores.TabIndex = 37;
            this.DgvValores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvValores_CellContentClick);
            // 
            // filtro
            // 
            this.filtro.FalseValue = "false";
            this.filtro.HeaderText = "";
            this.filtro.Name = "filtro";
            this.filtro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.filtro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.filtro.TrueValue = "true";
            this.filtro.Width = 30;
            // 
            // valor
            // 
            this.valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valor.HeaderText = "";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // BtnAplicar
            // 
            this.BtnAplicar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAplicar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAplicar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAplicar.Location = new System.Drawing.Point(283, 0);
            this.BtnAplicar.Name = "BtnAplicar";
            this.BtnAplicar.Size = new System.Drawing.Size(146, 64);
            this.BtnAplicar.TabIndex = 41;
            this.BtnAplicar.Text = "Aplicar";
            this.BtnAplicar.UseVisualStyleBackColor = true;
            this.BtnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(0, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(136, 64);
            this.BtnCancelar.TabIndex = 42;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnSeleccionarNada
            // 
            this.BtnSeleccionarNada.Location = new System.Drawing.Point(295, 336);
            this.BtnSeleccionarNada.Name = "BtnSeleccionarNada";
            this.BtnSeleccionarNada.Size = new System.Drawing.Size(121, 27);
            this.BtnSeleccionarNada.TabIndex = 79;
            this.BtnSeleccionarNada.Text = "Seleccionar nada";
            this.BtnSeleccionarNada.UseVisualStyleBackColor = true;
            this.BtnSeleccionarNada.Click += new System.EventHandler(this.BtnSeleccionarNada_Click);
            // 
            // BtnSeleccionarTodos
            // 
            this.BtnSeleccionarTodos.Location = new System.Drawing.Point(174, 336);
            this.BtnSeleccionarTodos.Name = "BtnSeleccionarTodos";
            this.BtnSeleccionarTodos.Size = new System.Drawing.Size(121, 27);
            this.BtnSeleccionarTodos.TabIndex = 78;
            this.BtnSeleccionarTodos.Text = "Seleccionar todos";
            this.BtnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.BtnSeleccionarTodos.Click += new System.EventHandler(this.BtnSeleccionarTodos_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnAplicar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 64);
            this.panel1.TabIndex = 80;
            // 
            // FrmFiltrarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 436);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnSeleccionarNada);
            this.Controls.Add(this.BtnSeleccionarTodos);
            this.Controls.Add(this.DgvValores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbColumnas);
            this.Controls.Add(this.LblTituloComponente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFiltrarDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFiltrar";
            this.Load += new System.EventHandler(this.FrmFiltrarDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvValores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTituloComponente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbColumnas;
        private System.Windows.Forms.DataGridView DgvValores;
        private System.Windows.Forms.Button BtnAplicar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn filtro;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.Button BtnSeleccionarNada;
        private System.Windows.Forms.Button BtnSeleccionarTodos;
        private System.Windows.Forms.Panel panel1;
    }
}
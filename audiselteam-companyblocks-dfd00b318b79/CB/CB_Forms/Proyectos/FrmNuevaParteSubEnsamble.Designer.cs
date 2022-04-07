namespace CB
{
    partial class FrmNuevaParteSubensamble
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvNuevaParte = new System.Windows.Forms.DataGridView();
            this.id_elemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNuevaParte)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(12, 380);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 40);
            this.BtnCancelar.TabIndex = 58;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Location = new System.Drawing.Point(178, 380);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(176, 40);
            this.BtnRegistrar.TabIndex = 57;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Tipo";
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Items.AddRange(new object[] {
            "COMPONENTE",
            "SUBENSAMBLE"});
            this.CmbTipo.Location = new System.Drawing.Point(12, 55);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(342, 32);
            this.CmbTipo.TabIndex = 54;
            this.CmbTipo.SelectedIndexChanged += new System.EventHandler(this.CmbTipo_SelectedIndexChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(368, 23);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "NUEVA PARTE SUBENSAMBLE";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // DgvNuevaParte
            // 
            this.DgvNuevaParte.AllowUserToAddRows = false;
            this.DgvNuevaParte.AllowUserToDeleteRows = false;
            this.DgvNuevaParte.AllowUserToResizeRows = false;
            this.DgvNuevaParte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvNuevaParte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvNuevaParte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvNuevaParte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_elemento,
            this.numero_proyecto,
            this.componente});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvNuevaParte.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvNuevaParte.Location = new System.Drawing.Point(14, 107);
            this.DgvNuevaParte.MultiSelect = false;
            this.DgvNuevaParte.Name = "DgvNuevaParte";
            this.DgvNuevaParte.ReadOnly = true;
            this.DgvNuevaParte.RowHeadersVisible = false;
            this.DgvNuevaParte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvNuevaParte.Size = new System.Drawing.Size(342, 256);
            this.DgvNuevaParte.TabIndex = 56;
            this.DgvNuevaParte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNuevaParte_CellClick);
            // 
            // id_elemento
            // 
            this.id_elemento.HeaderText = "ID";
            this.id_elemento.Name = "id_elemento";
            this.id_elemento.ReadOnly = true;
            this.id_elemento.Visible = false;
            // 
            // numero_proyecto
            // 
            this.numero_proyecto.HeaderText = "Proyecto";
            this.numero_proyecto.Name = "numero_proyecto";
            this.numero_proyecto.ReadOnly = true;
            this.numero_proyecto.Visible = false;
            // 
            // componente
            // 
            this.componente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.componente.DefaultCellStyle = dataGridViewCellStyle2;
            this.componente.HeaderText = "Componentes";
            this.componente.Name = "componente";
            this.componente.ReadOnly = true;
            // 
            // FrmNuevaParteSubEnsamble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(368, 429);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.DgvNuevaParte);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaParteSubEnsamble";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevaParteSubEnsamble";
            this.Load += new System.EventHandler(this.FrmNuevaParteSubensamble_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvNuevaParte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn elemento;
        private System.Windows.Forms.DataGridView DgvNuevaParte;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_elemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn componente;
    }
}
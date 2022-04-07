namespace CB
{
    partial class FrmVacante
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbPuesto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.DgvVacante = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vacante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVacante)).BeginInit();
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
            this.LblTitulo.Size = new System.Drawing.Size(915, 23);
            this.LblTitulo.TabIndex = 105;
            this.LblTitulo.Text = "VACANTES";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbPuesto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 69);
            this.panel1.TabIndex = 106;
            // 
            // CmbPuesto
            // 
            this.CmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPuesto.FormattingEnabled = true;
            this.CmbPuesto.Location = new System.Drawing.Point(12, 28);
            this.CmbPuesto.Name = "CmbPuesto";
            this.CmbPuesto.Size = new System.Drawing.Size(302, 32);
            this.CmbPuesto.TabIndex = 108;
            this.CmbPuesto.SelectedIndexChanged += new System.EventHandler(this.CmbPuesto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 107;
            this.label1.Text = "Filtrar por puesto:";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CB_Base.Properties.Resources.exit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(786, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 69);
            this.button2.TabIndex = 106;
            this.button2.Text = "          Salir   ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DgvVacante
            // 
            this.DgvVacante.AllowUserToAddRows = false;
            this.DgvVacante.AllowUserToResizeRows = false;
            this.DgvVacante.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvVacante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvVacante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVacante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.puesto,
            this.nivel,
            this.vacante,
            this.estatus});
            this.DgvVacante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvVacante.Location = new System.Drawing.Point(0, 92);
            this.DgvVacante.Name = "DgvVacante";
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvVacante.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvVacante.RowHeadersVisible = false;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvVacante.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvVacante.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvVacante.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvVacante.Size = new System.Drawing.Size(915, 388);
            this.DgvVacante.TabIndex = 107;
            this.DgvVacante.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvVacante_CellFormatting);
            // 
            // id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 70;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // puesto
            // 
            this.puesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.puesto.DefaultCellStyle = dataGridViewCellStyle3;
            this.puesto.HeaderText = "Puesto";
            this.puesto.Name = "puesto";
            this.puesto.ReadOnly = true;
            // 
            // nivel
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nivel.DefaultCellStyle = dataGridViewCellStyle4;
            this.nivel.HeaderText = "Nivel";
            this.nivel.MinimumWidth = 90;
            this.nivel.Name = "nivel";
            this.nivel.ReadOnly = true;
            this.nivel.Width = 90;
            // 
            // vacante
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vacante.DefaultCellStyle = dataGridViewCellStyle5;
            this.vacante.HeaderText = "Vacantes";
            this.vacante.MinimumWidth = 90;
            this.vacante.Name = "vacante";
            this.vacante.ReadOnly = true;
            this.vacante.Width = 90;
            // 
            // estatus
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.estatus.HeaderText = "Estatus";
            this.estatus.MinimumWidth = 120;
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Width = 120;
            // 
            // FrmVacante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 480);
            this.Controls.Add(this.DgvVacante);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVacante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVacante";
            this.Load += new System.EventHandler(this.FrmVacante_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVacante)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvVacante;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox CmbPuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn puesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn vacante;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
    }
}
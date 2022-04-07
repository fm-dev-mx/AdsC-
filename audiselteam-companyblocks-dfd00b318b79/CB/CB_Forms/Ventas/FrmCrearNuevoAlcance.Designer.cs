namespace CB
{
    partial class FrmCrearNuevoAlcance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.CmbProcesos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvAlcance = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtAlcance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.NumHoras = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NumPersonas = new System.Windows.Forms.NumericUpDown();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alcance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlcance)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(494, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "NUEVO ALCANCE";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 59);
            this.panel1.TabIndex = 1;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(218, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(138, 59);
            this.BtnCancelar.TabIndex = 1;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(356, 0);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(138, 59);
            this.BtnAceptar.TabIndex = 0;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // CmbProcesos
            // 
            this.CmbProcesos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProcesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProcesos.FormattingEnabled = true;
            this.CmbProcesos.Location = new System.Drawing.Point(3, 18);
            this.CmbProcesos.Name = "CmbProcesos";
            this.CmbProcesos.Size = new System.Drawing.Size(210, 24);
            this.CmbProcesos.TabIndex = 2;
            this.CmbProcesos.SelectedIndexChanged += new System.EventHandler(this.CmbProcesos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccionar proceso";
            // 
            // DgvAlcance
            // 
            this.DgvAlcance.AllowUserToAddRows = false;
            this.DgvAlcance.AllowUserToDeleteRows = false;
            this.DgvAlcance.AllowUserToOrderColumns = true;
            this.DgvAlcance.AllowUserToResizeRows = false;
            this.DgvAlcance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAlcance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvAlcance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlcance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.chk,
            this.alcance});
            this.DgvAlcance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAlcance.Location = new System.Drawing.Point(0, 129);
            this.DgvAlcance.Name = "DgvAlcance";
            this.DgvAlcance.RowHeadersVisible = false;
            this.DgvAlcance.Size = new System.Drawing.Size(494, 193);
            this.DgvAlcance.TabIndex = 4;
            this.DgvAlcance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAlcance_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtAlcance);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CmbProcesos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 106);
            this.panel2.TabIndex = 5;
            // 
            // TxtAlcance
            // 
            this.TxtAlcance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAlcance.Location = new System.Drawing.Point(3, 63);
            this.TxtAlcance.Multiline = true;
            this.TxtAlcance.Name = "TxtAlcance";
            this.TxtAlcance.ReadOnly = true;
            this.TxtAlcance.Size = new System.Drawing.Size(488, 35);
            this.TxtAlcance.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Alcance";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.NumHoras);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.NumPersonas);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 275);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(494, 47);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Horas requeridas";
            // 
            // NumHoras
            // 
            this.NumHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumHoras.Location = new System.Drawing.Point(137, 20);
            this.NumHoras.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.NumHoras.Name = "NumHoras";
            this.NumHoras.Size = new System.Drawing.Size(120, 22);
            this.NumHoras.TabIndex = 10;
            this.NumHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumHoras.ValueChanged += new System.EventHandler(this.NumHoras_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Personas requeridas";
            // 
            // NumPersonas
            // 
            this.NumPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPersonas.Location = new System.Drawing.Point(8, 20);
            this.NumPersonas.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumPersonas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPersonas.Name = "NumPersonas";
            this.NumPersonas.Size = new System.Drawing.Size(120, 22);
            this.NumPersonas.TabIndex = 8;
            this.NumPersonas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPersonas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // chk
            // 
            this.chk.FalseValue = "false";
            this.chk.HeaderText = "";
            this.chk.MinimumWidth = 75;
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.TrueValue = "true";
            this.chk.Width = 75;
            // 
            // alcance
            // 
            this.alcance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alcance.DefaultCellStyle = dataGridViewCellStyle6;
            this.alcance.HeaderText = "Alcance";
            this.alcance.Name = "alcance";
            this.alcance.ReadOnly = true;
            this.alcance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.alcance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmCrearNuevoAlcance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 381);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.DgvAlcance);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCrearNuevoAlcance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear nuevo alcance";
            this.Load += new System.EventHandler(this.FrmCrearNuevoAlcance_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlcance)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPersonas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.ComboBox CmbProcesos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvAlcance;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxtAlcance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumHoras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn alcance;
    }
}
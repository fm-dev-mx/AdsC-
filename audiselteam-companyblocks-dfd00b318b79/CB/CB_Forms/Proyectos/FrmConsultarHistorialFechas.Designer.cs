namespace CB
{
    partial class FrmConsultarHistorialFechas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbRazon = new System.Windows.Forms.ComboBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvHistorial = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_entrega_anterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_entrega_nueva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_ajuste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_ajuste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbRazon);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 92);
            this.panel1.TabIndex = 16;
            // 
            // CmbRazon
            // 
            this.CmbRazon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRazon.FormattingEnabled = true;
            this.CmbRazon.Location = new System.Drawing.Point(10, 49);
            this.CmbRazon.Name = "CmbRazon";
            this.CmbRazon.Size = new System.Drawing.Size(266, 28);
            this.CmbRazon.TabIndex = 20;
            this.CmbRazon.SelectedIndexChanged += new System.EventHandler(this.CmbRazon_SelectedIndexChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(864, 23);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 69);
            this.BtnSalir.TabIndex = 18;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Filtrar por razón:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(999, 23);
            this.LblTitulo.TabIndex = 15;
            this.LblTitulo.Text = "HISTORIAL DE FECHAS DEL PROYECTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // DgvHistorial
            // 
            this.DgvHistorial.AllowUserToAddRows = false;
            this.DgvHistorial.AllowUserToDeleteRows = false;
            this.DgvHistorial.AllowUserToResizeRows = false;
            this.DgvHistorial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.razon,
            this.fecha_entrega_anterior,
            this.fecha_entrega_nueva,
            this.tipo_ajuste,
            this.responsable,
            this.fecha_ajuste});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvHistorial.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHistorial.Location = new System.Drawing.Point(0, 92);
            this.DgvHistorial.MultiSelect = false;
            this.DgvHistorial.Name = "DgvHistorial";
            this.DgvHistorial.RowHeadersVisible = false;
            this.DgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHistorial.Size = new System.Drawing.Size(999, 397);
            this.DgvHistorial.TabIndex = 17;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // razon
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.razon.DefaultCellStyle = dataGridViewCellStyle2;
            this.razon.HeaderText = "Razón";
            this.razon.MinimumWidth = 310;
            this.razon.Name = "razon";
            this.razon.ReadOnly = true;
            this.razon.Width = 310;
            // 
            // fecha_entrega_anterior
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_entrega_anterior.DefaultCellStyle = dataGridViewCellStyle3;
            this.fecha_entrega_anterior.HeaderText = "Fecha anterior";
            this.fecha_entrega_anterior.MinimumWidth = 100;
            this.fecha_entrega_anterior.Name = "fecha_entrega_anterior";
            this.fecha_entrega_anterior.ReadOnly = true;
            // 
            // fecha_entrega_nueva
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_entrega_nueva.DefaultCellStyle = dataGridViewCellStyle4;
            this.fecha_entrega_nueva.HeaderText = "Fecha actual";
            this.fecha_entrega_nueva.MinimumWidth = 100;
            this.fecha_entrega_nueva.Name = "fecha_entrega_nueva";
            this.fecha_entrega_nueva.ReadOnly = true;
            // 
            // tipo_ajuste
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tipo_ajuste.DefaultCellStyle = dataGridViewCellStyle5;
            this.tipo_ajuste.HeaderText = "Tipo de ajuste";
            this.tipo_ajuste.MinimumWidth = 235;
            this.tipo_ajuste.Name = "tipo_ajuste";
            this.tipo_ajuste.ReadOnly = true;
            this.tipo_ajuste.Width = 235;
            // 
            // responsable
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable.DefaultCellStyle = dataGridViewCellStyle6;
            this.responsable.HeaderText = "Responsable";
            this.responsable.MinimumWidth = 150;
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            this.responsable.Width = 150;
            // 
            // fecha_ajuste
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_ajuste.DefaultCellStyle = dataGridViewCellStyle7;
            this.fecha_ajuste.HeaderText = "Fecha de ajuste";
            this.fecha_ajuste.MinimumWidth = 100;
            this.fecha_ajuste.Name = "fecha_ajuste";
            this.fecha_ajuste.ReadOnly = true;
            // 
            // FrmConsultarHistorialFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 489);
            this.Controls.Add(this.DgvHistorial);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultarHistorialFechas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar historial de fechas";
            this.Load += new System.EventHandler(this.FrmConsultarHistorialMetas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvHistorial;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbRazon;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn razon;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_entrega_anterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_entrega_nueva;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_ajuste;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_ajuste;

    }
}
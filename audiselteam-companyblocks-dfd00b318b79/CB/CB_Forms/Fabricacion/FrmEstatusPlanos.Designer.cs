namespace CB_Base.CB_Forms.Fabricacion
{
    partial class FrmEstatusPlanos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvMaterial = new System.Windows.Forms.DataGridView();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.subensamble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planos_entregados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planos_fabricados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvMaterial
            // 
            this.DgvMaterial.AllowUserToAddRows = false;
            this.DgvMaterial.AllowUserToDeleteRows = false;
            this.DgvMaterial.AllowUserToResizeRows = false;
            this.DgvMaterial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMaterial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subensamble,
            this.nombre,
            this.descripcion,
            this.planos_entregados,
            this.planos_fabricados});
            this.DgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMaterial.Location = new System.Drawing.Point(0, 387);
            this.DgvMaterial.Name = "DgvMaterial";
            this.DgvMaterial.RowHeadersVisible = false;
            this.DgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMaterial.Size = new System.Drawing.Size(952, 244);
            this.DgvMaterial.TabIndex = 7;
            // 
            // pieChart1
            // 
            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart1.Location = new System.Drawing.Point(0, 0);
            this.pieChart1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Padding = new System.Windows.Forms.Padding(0, 50, 0, 50);
            this.pieChart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pieChart1.Size = new System.Drawing.Size(952, 314);
            this.pieChart1.TabIndex = 14;
            this.pieChart1.Text = "pieChart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pieChart1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 314);
            this.panel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 50);
            this.panel1.TabIndex = 5;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exitMenuIcon;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(805, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(147, 50);
            this.BtnSalir.TabIndex = 0;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(952, 23);
            this.audiselTituloForm1.TabIndex = 4;
            this.audiselTituloForm1.Text = "ESTATUS DE FABRICACION DEL PROYECTO";
            // 
            // subensamble
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subensamble.DefaultCellStyle = dataGridViewCellStyle2;
            this.subensamble.HeaderText = "Módulo";
            this.subensamble.MinimumWidth = 200;
            this.subensamble.Name = "subensamble";
            this.subensamble.ReadOnly = true;
            this.subensamble.Width = 200;
            // 
            // nombre
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 300;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 300;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle4;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 150;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // planos_entregados
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.planos_entregados.DefaultCellStyle = dataGridViewCellStyle5;
            this.planos_entregados.HeaderText = "Planos entregados";
            this.planos_entregados.MinimumWidth = 280;
            this.planos_entregados.Name = "planos_entregados";
            this.planos_entregados.ReadOnly = true;
            this.planos_entregados.Width = 280;
            // 
            // planos_fabricados
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.planos_fabricados.DefaultCellStyle = dataGridViewCellStyle6;
            this.planos_fabricados.HeaderText = "Planos fabricados";
            this.planos_fabricados.MinimumWidth = 280;
            this.planos_fabricados.Name = "planos_fabricados";
            this.planos_fabricados.ReadOnly = true;
            this.planos_fabricados.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.planos_fabricados.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.planos_fabricados.Width = 280;
            // 
            // FrmEstatusPlanos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 631);
            this.Controls.Add(this.DgvMaterial);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEstatusPlanos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEstatusPlanos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEstatusPlanos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.DataGridView DgvMaterial;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn subensamble;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn planos_entregados;
        private System.Windows.Forms.DataGridViewTextBoxColumn planos_fabricados;
    }
}
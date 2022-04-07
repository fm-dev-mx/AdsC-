namespace CB
{
    partial class FrmAsignarMultiplesProcesosFabricacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblProyecto = new System.Windows.Forms.Label();
            this.BtnAsignar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.DgvProceso = new System.Windows.Forms.DataGridView();
            this.proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramentista = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.maquina = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProceso)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblProyecto);
            this.panel1.Controls.Add(this.BtnAsignar);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 86);
            this.panel1.TabIndex = 0;
            // 
            // LblProyecto
            // 
            this.LblProyecto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProyecto.Location = new System.Drawing.Point(0, 23);
            this.LblProyecto.Name = "LblProyecto";
            this.LblProyecto.Size = new System.Drawing.Size(503, 63);
            this.LblProyecto.TabIndex = 110;
            this.LblProyecto.Text = "Proyecto 54.00 Nombre del proyecto";
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsignar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAsignar.Location = new System.Drawing.Point(503, 23);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(126, 63);
            this.BtnAsignar.TabIndex = 108;
            this.BtnAsignar.Text = "     Asignar";
            this.BtnAsignar.UseVisualStyleBackColor = true;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(629, 23);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(126, 63);
            this.BtnSalir.TabIndex = 111;
            this.BtnSalir.Text = "     Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(755, 23);
            this.LblTitulo.TabIndex = 109;
            this.LblTitulo.Text = "ASIGNAR MULTIPLES PROCESOS";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // DgvProceso
            // 
            this.DgvProceso.AllowUserToAddRows = false;
            this.DgvProceso.AllowUserToDeleteRows = false;
            this.DgvProceso.AllowUserToResizeRows = false;
            this.DgvProceso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProceso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proceso,
            this.herramentista,
            this.maquina});
            this.DgvProceso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProceso.Location = new System.Drawing.Point(0, 86);
            this.DgvProceso.Name = "DgvProceso";
            this.DgvProceso.RowHeadersVisible = false;
            this.DgvProceso.Size = new System.Drawing.Size(755, 317);
            this.DgvProceso.TabIndex = 1;
            this.DgvProceso.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvProceso_CellFormatting);
            // 
            // proceso
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.proceso.DefaultCellStyle = dataGridViewCellStyle1;
            this.proceso.HeaderText = "Proceso";
            this.proceso.MinimumWidth = 250;
            this.proceso.Name = "proceso";
            this.proceso.ReadOnly = true;
            this.proceso.Width = 250;
            // 
            // herramentista
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.herramentista.DefaultCellStyle = dataGridViewCellStyle2;
            this.herramentista.HeaderText = "Herramentista";
            this.herramentista.MinimumWidth = 250;
            this.herramentista.Name = "herramentista";
            this.herramentista.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.herramentista.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.herramentista.Width = 250;
            // 
            // maquina
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maquina.DefaultCellStyle = dataGridViewCellStyle3;
            this.maquina.HeaderText = "Maquinaria";
            this.maquina.MinimumWidth = 250;
            this.maquina.Name = "maquina";
            this.maquina.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.maquina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.maquina.Width = 250;
            // 
            // FrmAsignarMultiplesProcesosFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 403);
            this.Controls.Add(this.DgvProceso);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAsignarMultiplesProcesosFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar multiples procesos de fabricación";
            this.Load += new System.EventHandler(this.FrmAsignarMultiplesProcesosFabricacion_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProceso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvProceso;
        private System.Windows.Forms.Button BtnAsignar;
        private System.Windows.Forms.Label LblProyecto;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn proceso;
        private System.Windows.Forms.DataGridViewComboBoxColumn herramentista;
        private System.Windows.Forms.DataGridViewComboBoxColumn maquina;
        private System.Windows.Forms.Button BtnSalir;
    }
}
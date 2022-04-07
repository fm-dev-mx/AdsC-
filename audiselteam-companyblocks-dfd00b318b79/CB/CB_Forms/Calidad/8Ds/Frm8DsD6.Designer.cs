namespace CB
{
    partial class Frm8DsD6
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvAcciones = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_implementacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.efectividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcciones)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvAcciones
            // 
            this.DgvAcciones.AllowUserToAddRows = false;
            this.DgvAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAcciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.responsable,
            this.fecha_promesa,
            this.estatus_implementacion,
            this.efectividad});
            this.DgvAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAcciones.Location = new System.Drawing.Point(0, 110);
            this.DgvAcciones.Name = "DgvAcciones";
            this.DgvAcciones.RowHeadersVisible = false;
            this.DgvAcciones.Size = new System.Drawing.Size(1037, 263);
            this.DgvAcciones.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 90);
            this.panel1.TabIndex = 40;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1037, 70);
            this.textBox1.TabIndex = 15;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.Black;
            this.LblTitulo.Location = new System.Drawing.Point(0, 90);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1037, 20);
            this.LblTitulo.TabIndex = 43;
            this.LblTitulo.Text = "ACCIONES CORRECTIVAS A IMPLEMENTAR PARA ELIMINAR Y/O MITIGAR PERMANENTEMENTE LA C" +
    "AUSA RAIZ DEL PROBLEMA:";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Acción";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // responsable
            // 
            this.responsable.HeaderText = "Responsable";
            this.responsable.Name = "responsable";
            this.responsable.Width = 200;
            // 
            // fecha_promesa
            // 
            this.fecha_promesa.HeaderText = "Fecha promesa";
            this.fecha_promesa.Name = "fecha_promesa";
            this.fecha_promesa.Width = 180;
            // 
            // estatus_implementacion
            // 
            this.estatus_implementacion.HeaderText = "Estatus de implementación";
            this.estatus_implementacion.Name = "estatus_implementacion";
            this.estatus_implementacion.Width = 150;
            // 
            // efectividad
            // 
            this.efectividad.HeaderText = "Efectividad";
            this.efectividad.Name = "efectividad";
            this.efectividad.Width = 150;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1037, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "CAUSA RAIZ DEL PROBLEMA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm8DsD6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 373);
            this.ControlBox = false;
            this.Controls.Add(this.DgvAcciones);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm8DsD6";
            this.Text = "Metodología 8D - D6";
            this.Load += new System.EventHandler(this.Frm8DsD6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvAcciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_implementacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn efectividad;
        private System.Windows.Forms.Label label2;

    }
}
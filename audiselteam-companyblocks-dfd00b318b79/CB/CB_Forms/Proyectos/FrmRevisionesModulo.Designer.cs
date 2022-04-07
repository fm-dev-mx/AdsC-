namespace CB
{
    partial class FrmRevisionesModulo
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
            this.DgvRevisiones = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblNombre = new System.Windows.Forms.Label();
            this.LblProyecto = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRevisiones)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvRevisiones
            // 
            this.DgvRevisiones.AllowUserToAddRows = false;
            this.DgvRevisiones.AllowUserToDeleteRows = false;
            this.DgvRevisiones.AllowUserToResizeRows = false;
            this.DgvRevisiones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvRevisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRevisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.revision,
            this.comentarios,
            this.usuario,
            this.fecha});
            this.DgvRevisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvRevisiones.Location = new System.Drawing.Point(0, 80);
            this.DgvRevisiones.Name = "DgvRevisiones";
            this.DgvRevisiones.ReadOnly = true;
            this.DgvRevisiones.RowHeadersVisible = false;
            this.DgvRevisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRevisiones.Size = new System.Drawing.Size(788, 334);
            this.DgvRevisiones.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 59);
            this.panel1.TabIndex = 28;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(666, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(122, 59);
            this.BtnSalir.TabIndex = 19;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblNombre
            // 
            this.LblNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.Location = new System.Drawing.Point(0, 46);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(788, 34);
            this.LblNombre.TabIndex = 26;
            this.LblNombre.Text = "NOMBRE DEL MODULO";
            this.LblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblProyecto
            // 
            this.LblProyecto.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProyecto.Location = new System.Drawing.Point(0, 23);
            this.LblProyecto.Name = "LblProyecto";
            this.LblProyecto.Size = new System.Drawing.Size(788, 23);
            this.LblProyecto.TabIndex = 27;
            this.LblProyecto.Text = "PROYECTO";
            this.LblProyecto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(788, 23);
            this.LblTitulo.TabIndex = 5;
            this.LblTitulo.Text = "REVISIONES DEL MODULO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // revision
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revision.DefaultCellStyle = dataGridViewCellStyle1;
            this.revision.HeaderText = "Rev.";
            this.revision.Name = "revision";
            this.revision.ReadOnly = true;
            this.revision.Width = 40;
            // 
            // comentarios
            // 
            this.comentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.comentarios.HeaderText = "Comentarios";
            this.comentarios.Name = "comentarios";
            this.comentarios.ReadOnly = true;
            // 
            // usuario
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuario.DefaultCellStyle = dataGridViewCellStyle3;
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            this.usuario.Width = 170;
            // 
            // fecha
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha.DefaultCellStyle = dataGridViewCellStyle4;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 170;
            // 
            // FrmRevisionesModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 473);
            this.Controls.Add(this.DgvRevisiones);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.LblProyecto);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRevisionesModulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRevisionesModulo";
            this.Load += new System.EventHandler(this.FrmRevisionesModulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRevisiones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Label LblProyecto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView DgvRevisiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
    }
}
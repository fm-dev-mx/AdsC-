namespace CB
{
    partial class FrmMostrarMaterialCancelado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DgvMaterialCancelado = new System.Windows.Forms.DataGridView();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.id_req = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_cancelacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_cancelacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterialCancelado)).BeginInit();
            this.SuspendLayout();
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(1187, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "MATERIAL CANCELADO DEL  PROYECTO ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 570);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 70);
            this.panel1.TabIndex = 1;
            // 
            // DgvMaterialCancelado
            // 
            this.DgvMaterialCancelado.AllowUserToAddRows = false;
            this.DgvMaterialCancelado.AllowUserToDeleteRows = false;
            this.DgvMaterialCancelado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMaterialCancelado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvMaterialCancelado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMaterialCancelado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_req,
            this.numero_parte,
            this.descripcion,
            this.requisitor,
            this.fecha_cancelacion,
            this.usuario_cancelacion});
            this.DgvMaterialCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMaterialCancelado.Location = new System.Drawing.Point(0, 23);
            this.DgvMaterialCancelado.Name = "DgvMaterialCancelado";
            this.DgvMaterialCancelado.RowHeadersVisible = false;
            this.DgvMaterialCancelado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMaterialCancelado.Size = new System.Drawing.Size(1187, 547);
            this.DgvMaterialCancelado.TabIndex = 2;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1023, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(164, 70);
            this.BtnSalir.TabIndex = 0;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // id_req
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id_req.DefaultCellStyle = dataGridViewCellStyle9;
            this.id_req.HeaderText = "Req #";
            this.id_req.MinimumWidth = 90;
            this.id_req.Name = "id_req";
            this.id_req.ReadOnly = true;
            this.id_req.Width = 90;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle10;
            this.numero_parte.HeaderText = "Num. Parte";
            this.numero_parte.MinimumWidth = 150;
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            this.numero_parte.Width = 150;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle11;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 290;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // requisitor
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requisitor.DefaultCellStyle = dataGridViewCellStyle12;
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.MinimumWidth = 250;
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            this.requisitor.Width = 250;
            // 
            // fecha_cancelacion
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_cancelacion.DefaultCellStyle = dataGridViewCellStyle13;
            this.fecha_cancelacion.HeaderText = "Fecha de cancelación";
            this.fecha_cancelacion.MinimumWidth = 90;
            this.fecha_cancelacion.Name = "fecha_cancelacion";
            this.fecha_cancelacion.ReadOnly = true;
            this.fecha_cancelacion.Width = 90;
            // 
            // usuario_cancelacion
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usuario_cancelacion.DefaultCellStyle = dataGridViewCellStyle14;
            this.usuario_cancelacion.HeaderText = "Usuario que canceló";
            this.usuario_cancelacion.MinimumWidth = 250;
            this.usuario_cancelacion.Name = "usuario_cancelacion";
            this.usuario_cancelacion.ReadOnly = true;
            this.usuario_cancelacion.Width = 250;
            // 
            // FrmMostrarMaterialCancelado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 640);
            this.Controls.Add(this.DgvMaterialCancelado);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMostrarMaterialCancelado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMostrarMaterialCancelado";
            this.Load += new System.EventHandler(this.FrmMostrarMaterialCancelado_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterialCancelado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView DgvMaterialCancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_req;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_cancelacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_cancelacion;
    }
}
namespace CB
{
    partial class FrmMovimientosAlmacen
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCambiarEstatus = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.CmbMovimientosAlmacen = new System.Windows.Forms.ComboBox();
            this.DgvMovimeintosAlmacen = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORIGEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROYECTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMENTARIOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO_PARTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO_CREACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO_MOVIMIENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMovimeintosAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.BtnCambiarEstatus);
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer1.Panel1.Controls.Add(this.LblTitulo);
            this.splitContainer1.Panel1.Controls.Add(this.CmbMovimientosAlmacen);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvMovimeintosAlmacen);
            this.splitContainer1.Size = new System.Drawing.Size(1083, 620);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Estatus:";
            // 
            // BtnCambiarEstatus
            // 
            this.BtnCambiarEstatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCambiarEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarEstatus.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnCambiarEstatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCambiarEstatus.Location = new System.Drawing.Point(779, 25);
            this.BtnCambiarEstatus.Name = "BtnCambiarEstatus";
            this.BtnCambiarEstatus.Size = new System.Drawing.Size(189, 68);
            this.BtnCambiarEstatus.TabIndex = 36;
            this.BtnCambiarEstatus.Text = "Realizar movimiento";
            this.BtnCambiarEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCambiarEstatus.UseVisualStyleBackColor = true;
            this.BtnCambiarEstatus.Click += new System.EventHandler(this.BtnCambiarEstatus_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(968, 25);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(115, 68);
            this.BtnSalir.TabIndex = 35;
            this.BtnSalir.Text = "    Salir";
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
            this.LblTitulo.Size = new System.Drawing.Size(1083, 25);
            this.LblTitulo.TabIndex = 33;
            this.LblTitulo.Text = "MOVIMIENTOS ALMACEN";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbMovimientosAlmacen
            // 
            this.CmbMovimientosAlmacen.BackColor = System.Drawing.SystemColors.Menu;
            this.CmbMovimientosAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMovimientosAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMovimientosAlmacen.FormattingEnabled = true;
            this.CmbMovimientosAlmacen.Items.AddRange(new object[] {
            "PENDIENTE",
            "REALIZADO"});
            this.CmbMovimientosAlmacen.Location = new System.Drawing.Point(12, 50);
            this.CmbMovimientosAlmacen.Name = "CmbMovimientosAlmacen";
            this.CmbMovimientosAlmacen.Size = new System.Drawing.Size(424, 32);
            this.CmbMovimientosAlmacen.TabIndex = 0;
            this.CmbMovimientosAlmacen.SelectedIndexChanged += new System.EventHandler(this.CmbMovimientosAlmacen_SelectedIndexChanged);
            // 
            // DgvMovimeintosAlmacen
            // 
            this.DgvMovimeintosAlmacen.AllowUserToAddRows = false;
            this.DgvMovimeintosAlmacen.AllowUserToDeleteRows = false;
            this.DgvMovimeintosAlmacen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvMovimeintosAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMovimeintosAlmacen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ORIGEN,
            this.DESTINO,
            this.PROYECTO,
            this.ESTATUS,
            this.COMENTARIOS,
            this.NUMERO_PARTE,
            this.CANTIDAD,
            this.USUARIO_CREACION,
            this.USUARIO_MOVIMIENTO});
            this.DgvMovimeintosAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMovimeintosAlmacen.Location = new System.Drawing.Point(0, 0);
            this.DgvMovimeintosAlmacen.Name = "DgvMovimeintosAlmacen";
            this.DgvMovimeintosAlmacen.RowHeadersVisible = false;
            this.DgvMovimeintosAlmacen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMovimeintosAlmacen.Size = new System.Drawing.Size(1083, 523);
            this.DgvMovimeintosAlmacen.TabIndex = 0;
            this.DgvMovimeintosAlmacen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMovimeintosAlmacen_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "Id";
            this.ID.Name = "ID";
            // 
            // ORIGEN
            // 
            this.ORIGEN.HeaderText = "Origen";
            this.ORIGEN.Name = "ORIGEN";
            // 
            // DESTINO
            // 
            this.DESTINO.HeaderText = "Destino";
            this.DESTINO.Name = "DESTINO";
            // 
            // PROYECTO
            // 
            this.PROYECTO.HeaderText = "Proyecto";
            this.PROYECTO.Name = "PROYECTO";
            // 
            // ESTATUS
            // 
            this.ESTATUS.HeaderText = "Estatus";
            this.ESTATUS.Name = "ESTATUS";
            // 
            // COMENTARIOS
            // 
            this.COMENTARIOS.HeaderText = "Comentarios";
            this.COMENTARIOS.Name = "COMENTARIOS";
            // 
            // NUMERO_PARTE
            // 
            this.NUMERO_PARTE.HeaderText = "Numero de Parte";
            this.NUMERO_PARTE.Name = "NUMERO_PARTE";
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.HeaderText = "Cantidad";
            this.CANTIDAD.Name = "CANTIDAD";
            // 
            // USUARIO_CREACION
            // 
            this.USUARIO_CREACION.HeaderText = "Usuario Creacion";
            this.USUARIO_CREACION.Name = "USUARIO_CREACION";
            // 
            // USUARIO_MOVIMIENTO
            // 
            this.USUARIO_MOVIMIENTO.HeaderText = "Usuario Moviento";
            this.USUARIO_MOVIMIENTO.Name = "USUARIO_MOVIMIENTO";
            // 
            // FrmMovimientosAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 620);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMovimientosAlmacen";
            this.Text = "Movimientos ";
            this.Load += new System.EventHandler(this.FrmMovimientosAlmacen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMovimeintosAlmacen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox CmbMovimientosAlmacen;
        private System.Windows.Forms.DataGridView DgvMovimeintosAlmacen;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORIGEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROYECTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMENTARIOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO_PARTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO_CREACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO_MOVIMIENTO;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnCambiarEstatus;
        private System.Windows.Forms.Label label3;
    }
}
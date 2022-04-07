namespace CB
{
    partial class FrmDesglosarPartidaPO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvDesglose = new System.Windows.Forms.DataGridView();
            this.numero_requisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piezas_requeridas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.str_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piezas_paquete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnModificarCotizacion = new System.Windows.Forms.Button();
            this.BtnModificarCantidad = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblNumeroDeParte = new System.Windows.Forms.Label();
            this.LblPO = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDesglose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvDesglose
            // 
            this.DgvDesglose.AllowUserToAddRows = false;
            this.DgvDesglose.AllowUserToDeleteRows = false;
            this.DgvDesglose.AllowUserToResizeRows = false;
            this.DgvDesglose.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvDesglose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDesglose.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero_requisicion,
            this.requisitor,
            this.proyecto,
            this.cliente,
            this.piezas_requeridas,
            this.tipo_venta,
            this.str_total,
            this.estatus,
            this.comentarios_requisitor,
            this.piezas_paquete,
            this.total,
            this.precio_unitario});
            this.DgvDesglose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDesglose.Location = new System.Drawing.Point(0, 0);
            this.DgvDesglose.MultiSelect = false;
            this.DgvDesglose.Name = "DgvDesglose";
            this.DgvDesglose.ReadOnly = true;
            this.DgvDesglose.RowHeadersVisible = false;
            this.DgvDesglose.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDesglose.Size = new System.Drawing.Size(1005, 559);
            this.DgvDesglose.TabIndex = 10;
            this.DgvDesglose.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDesglose_CellClick);
            this.DgvDesglose.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDesglose_CellContentClick);
            // 
            // numero_requisicion
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numero_requisicion.DefaultCellStyle = dataGridViewCellStyle1;
            this.numero_requisicion.Frozen = true;
            this.numero_requisicion.HeaderText = "Req. #";
            this.numero_requisicion.Name = "numero_requisicion";
            this.numero_requisicion.ReadOnly = true;
            this.numero_requisicion.Width = 70;
            // 
            // requisitor
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requisitor.DefaultCellStyle = dataGridViewCellStyle2;
            this.requisitor.Frozen = true;
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            this.requisitor.Width = 160;
            // 
            // proyecto
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proyecto.DefaultCellStyle = dataGridViewCellStyle3;
            this.proyecto.HeaderText = "Proyecto";
            this.proyecto.Name = "proyecto";
            this.proyecto.ReadOnly = true;
            this.proyecto.Width = 160;
            // 
            // cliente
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cliente.DefaultCellStyle = dataGridViewCellStyle4;
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Visible = false;
            this.cliente.Width = 200;
            // 
            // piezas_requeridas
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.piezas_requeridas.DefaultCellStyle = dataGridViewCellStyle5;
            this.piezas_requeridas.HeaderText = "Piezas requeridas";
            this.piezas_requeridas.Name = "piezas_requeridas";
            this.piezas_requeridas.ReadOnly = true;
            this.piezas_requeridas.Width = 150;
            // 
            // tipo_venta
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipo_venta.DefaultCellStyle = dataGridViewCellStyle6;
            this.tipo_venta.HeaderText = "Tipo de venta";
            this.tipo_venta.Name = "tipo_venta";
            this.tipo_venta.ReadOnly = true;
            // 
            // str_total
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.str_total.DefaultCellStyle = dataGridViewCellStyle7;
            this.str_total.HeaderText = "Total";
            this.str_total.Name = "str_total";
            this.str_total.ReadOnly = true;
            this.str_total.Width = 200;
            // 
            // estatus
            // 
            this.estatus.HeaderText = "Estatus compra";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            // 
            // comentarios_requisitor
            // 
            this.comentarios_requisitor.HeaderText = "Comentarios del requisitor";
            this.comentarios_requisitor.Name = "comentarios_requisitor";
            this.comentarios_requisitor.ReadOnly = true;
            this.comentarios_requisitor.Width = 400;
            // 
            // piezas_paquete
            // 
            this.piezas_paquete.HeaderText = "Piezas por paquete";
            this.piezas_paquete.Name = "piezas_paquete";
            this.piezas_paquete.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Total a ordenar";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Visible = false;
            this.total.Width = 200;
            // 
            // precio_unitario
            // 
            this.precio_unitario.HeaderText = "Precio unitario";
            this.precio_unitario.Name = "precio_unitario";
            this.precio_unitario.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 86);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvDesglose);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BtnEliminar);
            this.splitContainer1.Panel2.Controls.Add(this.BtnModificarCotizacion);
            this.splitContainer1.Panel2.Controls.Add(this.BtnModificarCantidad);
            this.splitContainer1.Panel2.Controls.Add(this.BtnCancelar);
            this.splitContainer1.Size = new System.Drawing.Size(1231, 559);
            this.splitContainer1.SplitterDistance = 1005;
            this.splitContainer1.TabIndex = 11;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnEliminar.Enabled = false;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(0, 501);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(222, 58);
            this.BtnEliminar.TabIndex = 58;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnModificarCotizacion
            // 
            this.BtnModificarCotizacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnModificarCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarCotizacion.Image = global::CB_Base.Properties.Resources.Edit;
            this.BtnModificarCotizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnModificarCotizacion.Location = new System.Drawing.Point(0, 108);
            this.BtnModificarCotizacion.Name = "BtnModificarCotizacion";
            this.BtnModificarCotizacion.Size = new System.Drawing.Size(222, 54);
            this.BtnModificarCotizacion.TabIndex = 60;
            this.BtnModificarCotizacion.Text = "Modificar cotización  ";
            this.BtnModificarCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnModificarCotizacion.UseVisualStyleBackColor = true;
            this.BtnModificarCotizacion.Click += new System.EventHandler(this.BtnModificarCotizacion_Click);
            // 
            // BtnModificarCantidad
            // 
            this.BtnModificarCantidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnModificarCantidad.Enabled = false;
            this.BtnModificarCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarCantidad.Image = global::CB_Base.Properties.Resources.Edit;
            this.BtnModificarCantidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnModificarCantidad.Location = new System.Drawing.Point(0, 54);
            this.BtnModificarCantidad.Name = "BtnModificarCantidad";
            this.BtnModificarCantidad.Size = new System.Drawing.Size(222, 54);
            this.BtnModificarCantidad.TabIndex = 59;
            this.BtnModificarCantidad.Text = "Modificar cantidad     ";
            this.BtnModificarCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnModificarCantidad.UseVisualStyleBackColor = true;
            this.BtnModificarCantidad.Click += new System.EventHandler(this.BtnModificarCantidad_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(0, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(222, 54);
            this.BtnCancelar.TabIndex = 57;
            this.BtnCancelar.Text = "Salir                              ";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1231, 23);
            this.LblTitulo.TabIndex = 12;
            this.LblTitulo.Text = "DESGLOSE DE PARTIDA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblNumeroDeParte
            // 
            this.LblNumeroDeParte.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroDeParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroDeParte.Location = new System.Drawing.Point(0, 56);
            this.LblNumeroDeParte.Name = "LblNumeroDeParte";
            this.LblNumeroDeParte.Size = new System.Drawing.Size(1231, 30);
            this.LblNumeroDeParte.TabIndex = 15;
            this.LblNumeroDeParte.Text = "NUMERO DE PARTE:";
            this.LblNumeroDeParte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPO
            // 
            this.LblPO.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPO.Location = new System.Drawing.Point(0, 23);
            this.LblPO.Name = "LblPO";
            this.LblPO.Size = new System.Drawing.Size(1231, 33);
            this.LblPO.TabIndex = 16;
            this.LblPO.Text = "DESGLOSE PARA PO # - PROVEEDOR";
            this.LblPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDesglosarPartidaPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 645);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblNumeroDeParte);
            this.Controls.Add(this.LblPO);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDesglosarPartidaPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desglosar partida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDesglosarPartidaPO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDesglose)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvDesglose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblNumeroDeParte;
        private System.Windows.Forms.Label LblPO;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnModificarCantidad;
        private System.Windows.Forms.Button BtnModificarCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_requisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn piezas_requeridas;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn str_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn piezas_paquete;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_unitario;
    }
}
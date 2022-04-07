namespace CB
{
    partial class FrmRealizarMantenimientoPreventivo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtIdMantenimiento = new System.Windows.Forms.TextBox();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEquipo = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvMantenimiento = new System.Windows.Forms.DataGridView();
            this.id_topico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DgvMaterial = new System.Windows.Forms.DataGridView();
            this.id_requisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_compras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.MenuMaterial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarDelCatálogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbResponsable = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimiento)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).BeginInit();
            this.MenuMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbResponsable);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtIdMantenimiento);
            this.panel1.Controls.Add(this.BtnFinalizar);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtEquipo);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 87);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 127;
            this.label3.Text = "ID Mantenimiento:";
            // 
            // TxtIdMantenimiento
            // 
            this.TxtIdMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdMantenimiento.Location = new System.Drawing.Point(10, 46);
            this.TxtIdMantenimiento.Name = "TxtIdMantenimiento";
            this.TxtIdMantenimiento.ReadOnly = true;
            this.TxtIdMantenimiento.Size = new System.Drawing.Size(109, 29);
            this.TxtIdMantenimiento.TabIndex = 126;
            this.TxtIdMantenimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(887, 23);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(124, 64);
            this.BtnFinalizar.TabIndex = 125;
            this.BtnFinalizar.Text = "      Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1011, 23);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 64);
            this.BtnSalir.TabIndex = 124;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Equipo:";
            // 
            // TxtEquipo
            // 
            this.TxtEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEquipo.Location = new System.Drawing.Point(125, 46);
            this.TxtEquipo.Name = "TxtEquipo";
            this.TxtEquipo.ReadOnly = true;
            this.TxtEquipo.Size = new System.Drawing.Size(422, 29);
            this.TxtEquipo.TabIndex = 13;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1148, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "REALIZAR MANTENIMIENTO PREVENTIVO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1148, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "PUNTOS DE REVISION DEL MANTENIMIENTO PREVENTIVO:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvMantenimiento
            // 
            this.DgvMantenimiento.AllowUserToAddRows = false;
            this.DgvMantenimiento.AllowUserToDeleteRows = false;
            this.DgvMantenimiento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvMantenimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMantenimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_topico,
            this.id_item,
            this.topico,
            this.estatus,
            this.comentarios,
            this.accion,
            this.responsable});
            this.DgvMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMantenimiento.Location = new System.Drawing.Point(0, 110);
            this.DgvMantenimiento.Name = "DgvMantenimiento";
            this.DgvMantenimiento.RowHeadersVisible = false;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMantenimiento.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvMantenimiento.Size = new System.Drawing.Size(1148, 155);
            this.DgvMantenimiento.TabIndex = 8;
            this.DgvMantenimiento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMantenimiento_CellClick);
            this.DgvMantenimiento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMantenimiento_CellEndEdit);
            this.DgvMantenimiento.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvMantenimiento_EditingControlShowing);
            // 
            // id_topico
            // 
            this.id_topico.HeaderText = "ID";
            this.id_topico.Name = "id_topico";
            this.id_topico.Visible = false;
            // 
            // id_item
            // 
            this.id_item.HeaderText = "Id Item";
            this.id_item.Name = "id_item";
            this.id_item.ReadOnly = true;
            this.id_item.Visible = false;
            // 
            // topico
            // 
            this.topico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.topico.DefaultCellStyle = dataGridViewCellStyle1;
            this.topico.HeaderText = "Punto de revisión";
            this.topico.Name = "topico";
            this.topico.ReadOnly = true;
            // 
            // estatus
            // 
            this.estatus.HeaderText = "Estatus";
            this.estatus.Items.AddRange(new object[] {
            "NO APLICA",
            "BIEN",
            "MAL"});
            this.estatus.Name = "estatus";
            this.estatus.Width = 120;
            // 
            // comentarios
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.comentarios.HeaderText = "Comentarios";
            this.comentarios.Name = "comentarios";
            this.comentarios.Width = 300;
            // 
            // accion
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.accion.DefaultCellStyle = dataGridViewCellStyle3;
            this.accion.HeaderText = "Acción tomada";
            this.accion.Name = "accion";
            this.accion.Width = 300;
            // 
            // responsable
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable.DefaultCellStyle = dataGridViewCellStyle4;
            this.responsable.HeaderText = "Responsable";
            this.responsable.Name = "responsable";
            this.responsable.Width = 230;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgvMaterial);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1148, 149);
            this.panel2.TabIndex = 9;
            // 
            // DgvMaterial
            // 
            this.DgvMaterial.AllowUserToAddRows = false;
            this.DgvMaterial.AllowUserToDeleteRows = false;
            this.DgvMaterial.AllowUserToResizeRows = false;
            this.DgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_requisicion,
            this.requisitor,
            this.numero_parte,
            this.descripcion,
            this.cantidad,
            this.estatus_compras,
            this.estatus_almacen});
            this.DgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMaterial.Location = new System.Drawing.Point(0, 23);
            this.DgvMaterial.Name = "DgvMaterial";
            this.DgvMaterial.ReadOnly = true;
            this.DgvMaterial.RowHeadersVisible = false;
            this.DgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMaterial.Size = new System.Drawing.Size(1148, 126);
            this.DgvMaterial.TabIndex = 2;
            this.DgvMaterial.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMaterial_CellMouseDown);
            this.DgvMaterial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvMaterial_MouseClick);
            // 
            // id_requisicion
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_requisicion.DefaultCellStyle = dataGridViewCellStyle6;
            this.id_requisicion.Frozen = true;
            this.id_requisicion.HeaderText = "# Req.";
            this.id_requisicion.Name = "id_requisicion";
            this.id_requisicion.ReadOnly = true;
            this.id_requisicion.Width = 70;
            // 
            // requisitor
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.requisitor.DefaultCellStyle = dataGridViewCellStyle7;
            this.requisitor.Frozen = true;
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            this.requisitor.Width = 150;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle8;
            this.numero_parte.Frozen = true;
            this.numero_parte.HeaderText = "Número de parte";
            this.numero_parte.Name = "numero_parte";
            this.numero_parte.ReadOnly = true;
            this.numero_parte.Width = 150;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle9;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // estatus_compras
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_compras.DefaultCellStyle = dataGridViewCellStyle10;
            this.estatus_compras.HeaderText = "Estatus compra";
            this.estatus_compras.Name = "estatus_compras";
            this.estatus_compras.ReadOnly = true;
            this.estatus_compras.Width = 150;
            // 
            // estatus_almacen
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_almacen.DefaultCellStyle = dataGridViewCellStyle11;
            this.estatus_almacen.HeaderText = "Estatus almacén";
            this.estatus_almacen.Name = "estatus_almacen";
            this.estatus_almacen.ReadOnly = true;
            this.estatus_almacen.Width = 150;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1148, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "MATERIAL Y REFACCIONES:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuMaterial
            // 
            this.MenuMaterial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarDelCatálogoToolStripMenuItem,
            this.cancelarToolStripMenuItem});
            this.MenuMaterial.Name = "MenuMaterial";
            this.MenuMaterial.Size = new System.Drawing.Size(203, 48);
            // 
            // seleccionarDelCatálogoToolStripMenuItem
            // 
            this.seleccionarDelCatálogoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.seleccionarDelCatálogoToolStripMenuItem.Name = "seleccionarDelCatálogoToolStripMenuItem";
            this.seleccionarDelCatálogoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.seleccionarDelCatálogoToolStripMenuItem.Text = "Seleccionar del catálogo";
            this.seleccionarDelCatálogoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarDelCatálogoToolStripMenuItem_Click);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.cancelarToolStripMenuItem.Text = "Cancelar";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 13);
            this.label5.TabIndex = 128;
            this.label5.Text = "Seleccionar a un solo responsable:";
            // 
            // CmbResponsable
            // 
            this.CmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.CmbResponsable.FormattingEnabled = true;
            this.CmbResponsable.Location = new System.Drawing.Point(553, 46);
            this.CmbResponsable.Name = "CmbResponsable";
            this.CmbResponsable.Size = new System.Drawing.Size(275, 28);
            this.CmbResponsable.TabIndex = 129;
            this.CmbResponsable.SelectedIndexChanged += new System.EventHandler(this.CmbResponsable_SelectedIndexChanged);
            // 
            // FrmRealizarMantenimientoPreventivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 414);
            this.Controls.Add(this.DgvMantenimiento);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRealizarMantenimientoPreventivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Realizar mantenimiento preventivo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMantenimientoPreventivo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimiento)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).EndInit();
            this.MenuMaterial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEquipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvMantenimiento;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgvMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_requisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_compras;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_almacen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtIdMantenimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip MenuMaterial;
        private System.Windows.Forms.ToolStripMenuItem seleccionarDelCatálogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_topico;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn topico;
        private System.Windows.Forms.DataGridViewComboBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn accion;
        private System.Windows.Forms.DataGridViewComboBoxColumn responsable;
        private System.Windows.Forms.ComboBox CmbResponsable;
        private System.Windows.Forms.Label label5;
    }
}
namespace CB
{
    partial class FrmNuevoProyecto
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
            this.MenuTerminoPago = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOrdenCompra = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvOrdenCompra = new System.Windows.Forms.DataGridView();
            this.id_orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbLiderProyecto = new System.Windows.Forms.ComboBox();
            this.DgvTerminoPago = new System.Windows.Forms.DataGridView();
            this.id_termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblTerminosPago = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblCliente = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.TxtProyectoNombre = new System.Windows.Forms.TextBox();
            this.CmbCliente = new System.Windows.Forms.ComboBox();
            this.CmbContacto = new System.Windows.Forms.ComboBox();
            this.LblContacto = new System.Windows.Forms.Label();
            this.FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.NumSemana = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MenuTerminoPago.SuspendLayout();
            this.MenuOrdenCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdenCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTerminoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSemana)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuTerminoPago
            // 
            this.MenuTerminoPago.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuTerminoPago.Name = "MenuTerminoPago";
            this.MenuTerminoPago.Size = new System.Drawing.Size(118, 70);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.modificarToolStripMenuItem.Text = "Editar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // MenuOrdenCompra
            // 
            this.MenuOrdenCompra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem1,
            this.eliminarToolStripMenuItem1});
            this.MenuOrdenCompra.Name = "MenuOrdenCompra";
            this.MenuOrdenCompra.Size = new System.Drawing.Size(118, 48);
            // 
            // agregarToolStripMenuItem1
            // 
            this.agregarToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarToolStripMenuItem1.Name = "agregarToolStripMenuItem1";
            this.agregarToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.agregarToolStripMenuItem1.Text = "Agregar";
            this.agregarToolStripMenuItem1.Click += new System.EventHandler(this.agregarToolStripMenuItem1_Click);
            // 
            // eliminarToolStripMenuItem1
            // 
            this.eliminarToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            this.eliminarToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem1.Text = "Eliminar";
            this.eliminarToolStripMenuItem1.Click += new System.EventHandler(this.eliminarToolStripMenuItem1_Click);
            // 
            // DgvOrdenCompra
            // 
            this.DgvOrdenCompra.AllowUserToAddRows = false;
            this.DgvOrdenCompra.AllowUserToResizeRows = false;
            this.DgvOrdenCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvOrdenCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_orden,
            this.orden_compra});
            this.DgvOrdenCompra.Location = new System.Drawing.Point(388, 46);
            this.DgvOrdenCompra.Name = "DgvOrdenCompra";
            this.DgvOrdenCompra.RowHeadersVisible = false;
            this.DgvOrdenCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvOrdenCompra.Size = new System.Drawing.Size(315, 176);
            this.DgvOrdenCompra.TabIndex = 85;
            this.DgvOrdenCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrdenCompra_CellClick);
            this.DgvOrdenCompra.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrdenCompra_CellDoubleClick);
            this.DgvOrdenCompra.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.DgvOrdenCompra.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvOrdenCompra_MouseClick);
            // 
            // id_orden
            // 
            this.id_orden.HeaderText = "ID";
            this.id_orden.Name = "id_orden";
            this.id_orden.ReadOnly = true;
            this.id_orden.Visible = false;
            // 
            // orden_compra
            // 
            this.orden_compra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.orden_compra.HeaderText = "Ordenes de compra";
            this.orden_compra.Name = "orden_compra";
            this.orden_compra.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Lider de proyecto:";
            // 
            // CmbLiderProyecto
            // 
            this.CmbLiderProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLiderProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CmbLiderProyecto.FormattingEnabled = true;
            this.CmbLiderProyecto.Location = new System.Drawing.Point(9, 215);
            this.CmbLiderProyecto.Name = "CmbLiderProyecto";
            this.CmbLiderProyecto.Size = new System.Drawing.Size(373, 32);
            this.CmbLiderProyecto.TabIndex = 82;
            // 
            // DgvTerminoPago
            // 
            this.DgvTerminoPago.AllowUserToAddRows = false;
            this.DgvTerminoPago.AllowUserToResizeRows = false;
            this.DgvTerminoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTerminoPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_termino,
            this.porcentaje,
            this.termino});
            this.DgvTerminoPago.Location = new System.Drawing.Point(388, 242);
            this.DgvTerminoPago.Name = "DgvTerminoPago";
            this.DgvTerminoPago.RowHeadersVisible = false;
            this.DgvTerminoPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTerminoPago.Size = new System.Drawing.Size(314, 176);
            this.DgvTerminoPago.TabIndex = 81;
            this.DgvTerminoPago.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTerminoPago_CellClick);
            this.DgvTerminoPago.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTerminoPago_CellMouseDown);
            this.DgvTerminoPago.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DgvTerminoPago_RowsRemoved);
            this.DgvTerminoPago.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvTerminoPago_MouseClick);
            // 
            // id_termino
            // 
            this.id_termino.HeaderText = "ID";
            this.id_termino.Name = "id_termino";
            this.id_termino.ReadOnly = true;
            this.id_termino.Visible = false;
            // 
            // porcentaje
            // 
            this.porcentaje.HeaderText = "Prorcentaje";
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.ReadOnly = true;
            // 
            // termino
            // 
            this.termino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.termino.HeaderText = "Término";
            this.termino.Name = "termino";
            this.termino.ReadOnly = true;
            // 
            // LblTerminosPago
            // 
            this.LblTerminosPago.AutoSize = true;
            this.LblTerminosPago.Location = new System.Drawing.Point(385, 226);
            this.LblTerminosPago.Name = "LblTerminosPago";
            this.LblTerminosPago.Size = new System.Drawing.Size(92, 13);
            this.LblTerminosPago.TabIndex = 80;
            this.LblTerminosPago.Text = "Términos de pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre del proyecto:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(388, 426);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(155, 40);
            this.BtnCancelar.TabIndex = 15;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Location = new System.Drawing.Point(10, 82);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(42, 13);
            this.LblCliente.TabIndex = 12;
            this.LblCliente.Text = "Cliente:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(713, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "NUEVO PROYECTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown_1);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRegistrar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(551, 426);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(152, 40);
            this.btnRegistrar.TabIndex = 14;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // TxtProyectoNombre
            // 
            this.TxtProyectoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtProyectoNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtProyectoNombre.Location = new System.Drawing.Point(9, 46);
            this.TxtProyectoNombre.MaxLength = 60;
            this.TxtProyectoNombre.Name = "TxtProyectoNombre";
            this.TxtProyectoNombre.Size = new System.Drawing.Size(373, 29);
            this.TxtProyectoNombre.TabIndex = 9;
            this.TxtProyectoNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CmbCliente
            // 
            this.CmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CmbCliente.FormattingEnabled = true;
            this.CmbCliente.Location = new System.Drawing.Point(10, 100);
            this.CmbCliente.Name = "CmbCliente";
            this.CmbCliente.Size = new System.Drawing.Size(372, 32);
            this.CmbCliente.TabIndex = 10;
            this.CmbCliente.SelectedIndexChanged += new System.EventHandler(this.CmbCliente_SelectedIndexChanged);
            this.CmbCliente.Click += new System.EventHandler(this.CmbCliente_Click);
            // 
            // CmbContacto
            // 
            this.CmbContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CmbContacto.FormattingEnabled = true;
            this.CmbContacto.Location = new System.Drawing.Point(10, 156);
            this.CmbContacto.Name = "CmbContacto";
            this.CmbContacto.Size = new System.Drawing.Size(372, 32);
            this.CmbContacto.TabIndex = 11;
            this.CmbContacto.SelectedIndexChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // LblContacto
            // 
            this.LblContacto.AutoSize = true;
            this.LblContacto.Location = new System.Drawing.Point(7, 138);
            this.LblContacto.Name = "LblContacto";
            this.LblContacto.Size = new System.Drawing.Size(53, 13);
            this.LblContacto.TabIndex = 13;
            this.LblContacto.Text = "Contácto:";
            // 
            // FechaInicio
            // 
            this.FechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaInicio.Location = new System.Drawing.Point(9, 277);
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Size = new System.Drawing.Size(291, 26);
            this.FechaInicio.TabIndex = 87;
            this.FechaInicio.ValueChanged += new System.EventHandler(this.FechaInicio_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = "Inicio del proyecto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "Entrega del proyecto:";
            // 
            // FechaEntrega
            // 
            this.FechaEntrega.Enabled = false;
            this.FechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaEntrega.Location = new System.Drawing.Point(10, 388);
            this.FechaEntrega.Name = "FechaEntrega";
            this.FechaEntrega.Size = new System.Drawing.Size(291, 26);
            this.FechaEntrega.TabIndex = 88;
            // 
            // NumSemana
            // 
            this.NumSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumSemana.Location = new System.Drawing.Point(9, 334);
            this.NumSemana.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumSemana.Name = "NumSemana";
            this.NumSemana.Size = new System.Drawing.Size(85, 26);
            this.NumSemana.TabIndex = 90;
            this.NumSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSemana.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumSemana.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 91;
            this.label5.Text = "Semanas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Duración:";
            // 
            // FrmNuevoProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(713, 478);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NumSemana);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FechaEntrega);
            this.Controls.Add(this.FechaInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DgvOrdenCompra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbLiderProyecto);
            this.Controls.Add(this.DgvTerminoPago);
            this.Controls.Add(this.LblTerminosPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LblCliente);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.TxtProyectoNombre);
            this.Controls.Add(this.CmbCliente);
            this.Controls.Add(this.CmbContacto);
            this.Controls.Add(this.LblContacto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevoProyecto";
            this.MenuTerminoPago.ResumeLayout(false);
            this.MenuOrdenCompra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdenCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTerminoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSemana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.ComboBox CmbCliente;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label LblContacto;
        private System.Windows.Forms.ComboBox CmbContacto;
        private System.Windows.Forms.TextBox TxtProyectoNombre;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvTerminoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn termino;
        private System.Windows.Forms.Label LblTerminosPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbLiderProyecto;
        private System.Windows.Forms.DataGridView DgvOrdenCompra;
        private System.Windows.Forms.ContextMenuStrip MenuTerminoPago;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuOrdenCompra;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden_compra;
        private System.Windows.Forms.DateTimePicker FechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker FechaEntrega;
        private System.Windows.Forms.NumericUpDown NumSemana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
namespace CB
{
    partial class FrmRealizarMantenimientoCorrectivo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtSolicitadoPor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtOrdenTrabajo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtIdMantenimiento = new System.Windows.Forms.TextBox();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEquipo = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxtPuntosReparar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DgvActividades = new System.Windows.Forms.DataGridView();
            this.id_actividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_finalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_actividad = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.comentarios_actividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgvMaterial = new System.Windows.Forms.DataGridView();
            this.id_requisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_compras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.MenuMaterial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarDelCatálogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuActividad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevaActividadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActividades)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).BeginInit();
            this.MenuMaterial.SuspendLayout();
            this.MenuActividad.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TxtSolicitadoPor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtOrdenTrabajo);
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
            this.panel1.Size = new System.Drawing.Size(974, 87);
            this.panel1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 131;
            this.label6.Text = "Solicitado por:";
            // 
            // TxtSolicitadoPor
            // 
            this.TxtSolicitadoPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSolicitadoPor.Location = new System.Drawing.Point(455, 46);
            this.TxtSolicitadoPor.Name = "TxtSolicitadoPor";
            this.TxtSolicitadoPor.ReadOnly = true;
            this.TxtSolicitadoPor.Size = new System.Drawing.Size(234, 29);
            this.TxtSolicitadoPor.TabIndex = 130;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "Orden de trabajo:";
            // 
            // TxtOrdenTrabajo
            // 
            this.TxtOrdenTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOrdenTrabajo.Location = new System.Drawing.Point(363, 46);
            this.TxtOrdenTrabajo.Name = "TxtOrdenTrabajo";
            this.TxtOrdenTrabajo.ReadOnly = true;
            this.TxtOrdenTrabajo.Size = new System.Drawing.Size(86, 29);
            this.TxtOrdenTrabajo.TabIndex = 128;
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
            this.TxtIdMantenimiento.Size = new System.Drawing.Size(90, 29);
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
            this.BtnFinalizar.Location = new System.Drawing.Point(713, 23);
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
            this.BtnSalir.Location = new System.Drawing.Point(837, 23);
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
            this.label1.Location = new System.Drawing.Point(106, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Equipo:";
            // 
            // TxtEquipo
            // 
            this.TxtEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEquipo.Location = new System.Drawing.Point(106, 46);
            this.TxtEquipo.Name = "TxtEquipo";
            this.TxtEquipo.ReadOnly = true;
            this.TxtEquipo.Size = new System.Drawing.Size(251, 29);
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
            this.LblTitulo.Size = new System.Drawing.Size(974, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "REALIZAR MANTENIMIENTO CORRECTIVO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtPuntosReparar
            // 
            this.TxtPuntosReparar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtPuntosReparar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPuntosReparar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPuntosReparar.Enabled = false;
            this.TxtPuntosReparar.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPuntosReparar.Location = new System.Drawing.Point(0, 110);
            this.TxtPuntosReparar.Multiline = true;
            this.TxtPuntosReparar.Name = "TxtPuntosReparar";
            this.TxtPuntosReparar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtPuntosReparar.Size = new System.Drawing.Size(974, 342);
            this.TxtPuntosReparar.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(974, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "PUNTOS A REPARAR:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 262);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 190);
            this.panel2.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(974, 167);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgvActividades);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(966, 141);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Actividades realizadas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DgvActividades
            // 
            this.DgvActividades.AllowUserToAddRows = false;
            this.DgvActividades.AllowUserToDeleteRows = false;
            this.DgvActividades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvActividades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_actividad,
            this.actividad,
            this.fecha_registro,
            this.fecha_finalizacion,
            this.estatus_actividad,
            this.comentarios_actividad});
            this.DgvActividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvActividades.Location = new System.Drawing.Point(3, 3);
            this.DgvActividades.MultiSelect = false;
            this.DgvActividades.Name = "DgvActividades";
            this.DgvActividades.RowHeadersVisible = false;
            this.DgvActividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvActividades.Size = new System.Drawing.Size(960, 135);
            this.DgvActividades.TabIndex = 0;
            this.DgvActividades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvActividades_CellClick);
            this.DgvActividades.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvActividades_CellEndEdit);
            this.DgvActividades.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvActividades_CellMouseDown);
            this.DgvActividades.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvActividades_CellMouseLeave);
            this.DgvActividades.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvActividades_EditingControlShowing);
            this.DgvActividades.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvActividades_MouseClick);
            // 
            // id_actividad
            // 
            this.id_actividad.Frozen = true;
            this.id_actividad.HeaderText = "ID";
            this.id_actividad.Name = "id_actividad";
            this.id_actividad.Visible = false;
            // 
            // actividad
            // 
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.actividad.DefaultCellStyle = dataGridViewCellStyle9;
            this.actividad.Frozen = true;
            this.actividad.HeaderText = "Actividad";
            this.actividad.Name = "actividad";
            this.actividad.ReadOnly = true;
            this.actividad.Width = 200;
            // 
            // fecha_registro
            // 
            this.fecha_registro.Frozen = true;
            this.fecha_registro.HeaderText = "Fecha de registro";
            this.fecha_registro.MinimumWidth = 180;
            this.fecha_registro.Name = "fecha_registro";
            this.fecha_registro.ReadOnly = true;
            this.fecha_registro.Width = 180;
            // 
            // fecha_finalizacion
            // 
            this.fecha_finalizacion.Frozen = true;
            this.fecha_finalizacion.HeaderText = "Fecha de finalización";
            this.fecha_finalizacion.MinimumWidth = 180;
            this.fecha_finalizacion.Name = "fecha_finalizacion";
            this.fecha_finalizacion.ReadOnly = true;
            this.fecha_finalizacion.Width = 180;
            // 
            // estatus_actividad
            // 
            this.estatus_actividad.Frozen = true;
            this.estatus_actividad.HeaderText = "Estatus actual";
            this.estatus_actividad.Items.AddRange(new object[] {
            "PENDIENTE",
            "DETENIDO",
            "TERMINADO"});
            this.estatus_actividad.Name = "estatus_actividad";
            // 
            // comentarios_actividad
            // 
            this.comentarios_actividad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios_actividad.DefaultCellStyle = dataGridViewCellStyle10;
            this.comentarios_actividad.HeaderText = "Comentarios";
            this.comentarios_actividad.Name = "comentarios_actividad";
            this.comentarios_actividad.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgvMaterial);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(966, 141);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Material y refacciones";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.DgvMaterial.Location = new System.Drawing.Point(3, 3);
            this.DgvMaterial.Name = "DgvMaterial";
            this.DgvMaterial.ReadOnly = true;
            this.DgvMaterial.RowHeadersVisible = false;
            this.DgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMaterial.Size = new System.Drawing.Size(960, 135);
            this.DgvMaterial.TabIndex = 2;
            this.DgvMaterial.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMaterial_CellMouseDown);
            this.DgvMaterial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvMaterial_MouseClick);
            // 
            // id_requisicion
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_requisicion.DefaultCellStyle = dataGridViewCellStyle11;
            this.id_requisicion.Frozen = true;
            this.id_requisicion.HeaderText = "# Req.";
            this.id_requisicion.Name = "id_requisicion";
            this.id_requisicion.ReadOnly = true;
            this.id_requisicion.Width = 70;
            // 
            // requisitor
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.requisitor.DefaultCellStyle = dataGridViewCellStyle12;
            this.requisitor.Frozen = true;
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            this.requisitor.Width = 150;
            // 
            // numero_parte
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numero_parte.DefaultCellStyle = dataGridViewCellStyle13;
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
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle14;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // estatus_compras
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_compras.DefaultCellStyle = dataGridViewCellStyle15;
            this.estatus_compras.HeaderText = "Estatus compra";
            this.estatus_compras.Name = "estatus_compras";
            this.estatus_compras.ReadOnly = true;
            this.estatus_compras.Width = 150;
            // 
            // estatus_almacen
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_almacen.DefaultCellStyle = dataGridViewCellStyle16;
            this.estatus_almacen.HeaderText = "Estatus almacén";
            this.estatus_almacen.Name = "estatus_almacen";
            this.estatus_almacen.ReadOnly = true;
            this.estatus_almacen.Width = 150;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(974, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "ACTIVIDADES Y MATERIALES:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // MenuActividad
            // 
            this.MenuActividad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaActividadToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminiarToolStripMenuItem});
            this.MenuActividad.Name = "MenuActividad";
            this.MenuActividad.Size = new System.Drawing.Size(160, 70);
            // 
            // nuevaActividadToolStripMenuItem
            // 
            this.nuevaActividadToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevaActividadToolStripMenuItem.Name = "nuevaActividadToolStripMenuItem";
            this.nuevaActividadToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nuevaActividadToolStripMenuItem.Text = "Nueva actividad";
            this.nuevaActividadToolStripMenuItem.Click += new System.EventHandler(this.nuevaActividadToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminiarToolStripMenuItem
            // 
            this.eliminiarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminiarToolStripMenuItem.Name = "eliminiarToolStripMenuItem";
            this.eliminiarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eliminiarToolStripMenuItem.Text = "Eliminiar";
            this.eliminiarToolStripMenuItem.Click += new System.EventHandler(this.eliminiarToolStripMenuItem_Click);
            // 
            // FrmRealizarMantenimientoCorrectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 452);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TxtPuntosReparar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRealizarMantenimientoCorrectivo";
            this.Text = "Realizar mantenimiento correctivo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRealizarMantenimientoCorrectivo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvActividades)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMaterial)).EndInit();
            this.MenuMaterial.ResumeLayout(false);
            this.MenuActividad.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtIdMantenimiento;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEquipo;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtOrdenTrabajo;
        private System.Windows.Forms.TextBox TxtPuntosReparar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtSolicitadoPor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DgvActividades;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DgvMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_requisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_compras;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_almacen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip MenuMaterial;
        private System.Windows.Forms.ToolStripMenuItem seleccionarDelCatálogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuActividad;
        private System.Windows.Forms.ToolStripMenuItem eliminiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaActividadToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_actividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn actividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_finalizacion;
        private System.Windows.Forms.DataGridViewComboBoxColumn estatus_actividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_actividad;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;

    }
}
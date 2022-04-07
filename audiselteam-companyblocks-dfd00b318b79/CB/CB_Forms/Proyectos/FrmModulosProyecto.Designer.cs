namespace CB
{
    partial class FrmModulosProyecto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diseñadorMecánicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diseñadorEléctricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verDetallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aceptarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diseñoDeConceptoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diseñoFinalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnOpciones = new System.Windows.Forms.Button();
            this.LblUltimaActualizacion = new System.Windows.Forms.Label();
            this.DgvModulos = new System.Windows.Forms.DataGridView();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subensamble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promesa_fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mecanico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.electrico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elementos = new System.Windows.Forms.DataGridViewImageColumn();
            this.secuencia = new System.Windows.Forms.DataGridViewImageColumn();
            this.modo_falla = new System.Windows.Forms.DataGridViewImageColumn();
            this.menuOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModulos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuOpciones
            // 
            this.menuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.borrarToolStripMenuItem,
            this.asignarToolStripMenuItem,
            this.verDetallesToolStripMenuItem,
            this.aceptarToolStripMenuItem});
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Size = new System.Drawing.Size(134, 136);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Enabled = false;
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Enabled = false;
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // asignarToolStripMenuItem
            // 
            this.asignarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diseñadorMecánicoToolStripMenuItem,
            this.diseñadorEléctricoToolStripMenuItem,
            this.programadorToolStripMenuItem});
            this.asignarToolStripMenuItem.Enabled = false;
            this.asignarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.user_checked;
            this.asignarToolStripMenuItem.Name = "asignarToolStripMenuItem";
            this.asignarToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.asignarToolStripMenuItem.Text = "Asignar";
            // 
            // diseñadorMecánicoToolStripMenuItem
            // 
            this.diseñadorMecánicoToolStripMenuItem.Name = "diseñadorMecánicoToolStripMenuItem";
            this.diseñadorMecánicoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.diseñadorMecánicoToolStripMenuItem.Text = "Diseñador mecánico";
            this.diseñadorMecánicoToolStripMenuItem.Click += new System.EventHandler(this.diseñadorMecánicoToolStripMenuItem_Click);
            // 
            // diseñadorEléctricoToolStripMenuItem
            // 
            this.diseñadorEléctricoToolStripMenuItem.Name = "diseñadorEléctricoToolStripMenuItem";
            this.diseñadorEléctricoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.diseñadorEléctricoToolStripMenuItem.Text = "Diseñador eléctrico";
            this.diseñadorEléctricoToolStripMenuItem.Click += new System.EventHandler(this.diseñadorEléctricoToolStripMenuItem_Click);
            // 
            // programadorToolStripMenuItem
            // 
            this.programadorToolStripMenuItem.Name = "programadorToolStripMenuItem";
            this.programadorToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.programadorToolStripMenuItem.Text = "Programador";
            this.programadorToolStripMenuItem.Click += new System.EventHandler(this.programadorToolStripMenuItem_Click);
            // 
            // verDetallesToolStripMenuItem
            // 
            this.verDetallesToolStripMenuItem.Enabled = false;
            this.verDetallesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.details;
            this.verDetallesToolStripMenuItem.Name = "verDetallesToolStripMenuItem";
            this.verDetallesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.verDetallesToolStripMenuItem.Text = "Ver detalles";
            this.verDetallesToolStripMenuItem.Click += new System.EventHandler(this.verDetallesToolStripMenuItem_Click);
            // 
            // aceptarToolStripMenuItem
            // 
            this.aceptarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diseñoDeConceptoToolStripMenuItem,
            this.diseñoFinalToolStripMenuItem});
            this.aceptarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.aceptarToolStripMenuItem.Name = "aceptarToolStripMenuItem";
            this.aceptarToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.aceptarToolStripMenuItem.Text = "Aceptar";
            // 
            // diseñoDeConceptoToolStripMenuItem
            // 
            this.diseñoDeConceptoToolStripMenuItem.Name = "diseñoDeConceptoToolStripMenuItem";
            this.diseñoDeConceptoToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.diseñoDeConceptoToolStripMenuItem.Text = "Concepto";
            this.diseñoDeConceptoToolStripMenuItem.Click += new System.EventHandler(this.diseñoDeConceptoToolStripMenuItem_Click);
            // 
            // diseñoFinalToolStripMenuItem
            // 
            this.diseñoFinalToolStripMenuItem.Name = "diseñoFinalToolStripMenuItem";
            this.diseñoFinalToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.diseñoFinalToolStripMenuItem.Text = "Diseño";
            this.diseñoFinalToolStripMenuItem.Click += new System.EventHandler(this.diseñoFinalToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvModulos);
            this.splitContainer1.Size = new System.Drawing.Size(976, 458);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(692, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BtnActualizar);
            this.splitContainer2.Panel1.Controls.Add(this.BtnOpciones);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LblUltimaActualizacion);
            this.splitContainer2.Size = new System.Drawing.Size(284, 89);
            this.splitContainer2.SplitterDistance = 58;
            this.splitContainer2.TabIndex = 27;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.update;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(47, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(118, 58);
            this.BtnActualizar.TabIndex = 10;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnOpciones
            // 
            this.BtnOpciones.ContextMenuStrip = this.menuOpciones;
            this.BtnOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpciones.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnOpciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpciones.Location = new System.Drawing.Point(165, 0);
            this.BtnOpciones.Name = "BtnOpciones";
            this.BtnOpciones.Size = new System.Drawing.Size(119, 58);
            this.BtnOpciones.TabIndex = 1;
            this.BtnOpciones.Text = "Opciones";
            this.BtnOpciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpciones.UseVisualStyleBackColor = true;
            this.BtnOpciones.Click += new System.EventHandler(this.BtnOpciones_Click);
            // 
            // LblUltimaActualizacion
            // 
            this.LblUltimaActualizacion.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblUltimaActualizacion.Location = new System.Drawing.Point(0, 0);
            this.LblUltimaActualizacion.Name = "LblUltimaActualizacion";
            this.LblUltimaActualizacion.Size = new System.Drawing.Size(284, 27);
            this.LblUltimaActualizacion.TabIndex = 11;
            this.LblUltimaActualizacion.Text = "Ultima actualización: XXYY";
            this.LblUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DgvModulos
            // 
            this.DgvModulos.AllowUserToAddRows = false;
            this.DgvModulos.AllowUserToDeleteRows = false;
            this.DgvModulos.AllowUserToResizeRows = false;
            this.DgvModulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvModulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.subensamble,
            this.nombre,
            this.descripcion,
            this.fecha_promesa_fabricacion,
            this.mecanico,
            this.electrico,
            this.programador,
            this.elementos,
            this.secuencia,
            this.modo_falla});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvModulos.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvModulos.Location = new System.Drawing.Point(0, 0);
            this.DgvModulos.Name = "DgvModulos";
            this.DgvModulos.ReadOnly = true;
            this.DgvModulos.RowHeadersVisible = false;
            this.DgvModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvModulos.Size = new System.Drawing.Size(976, 365);
            this.DgvModulos.TabIndex = 1;
            this.DgvModulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvModulos_CellClick);
            this.DgvModulos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvModulos_CellDoubleClick);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(976, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "MODULOS DEL PROYECTO XXX.YY - NOMBRE";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // id
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 70;
            // 
            // subensamble
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subensamble.DefaultCellStyle = dataGridViewCellStyle2;
            this.subensamble.Frozen = true;
            this.subensamble.HeaderText = "Subensamble";
            this.subensamble.MinimumWidth = 100;
            this.subensamble.Name = "subensamble";
            this.subensamble.ReadOnly = true;
            // 
            // nombre
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombre.Frozen = true;
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 160;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 160;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle4;
            this.descripcion.Frozen = true;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 150;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 150;
            // 
            // fecha_promesa_fabricacion
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha_promesa_fabricacion.DefaultCellStyle = dataGridViewCellStyle5;
            this.fecha_promesa_fabricacion.Frozen = true;
            this.fecha_promesa_fabricacion.HeaderText = "Fecha promesa fabricación";
            this.fecha_promesa_fabricacion.Name = "fecha_promesa_fabricacion";
            this.fecha_promesa_fabricacion.ReadOnly = true;
            this.fecha_promesa_fabricacion.Width = 150;
            // 
            // mecanico
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mecanico.DefaultCellStyle = dataGridViewCellStyle6;
            this.mecanico.Frozen = true;
            this.mecanico.HeaderText = "Diseñador mecánico";
            this.mecanico.MinimumWidth = 150;
            this.mecanico.Name = "mecanico";
            this.mecanico.ReadOnly = true;
            this.mecanico.Width = 150;
            // 
            // electrico
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.electrico.DefaultCellStyle = dataGridViewCellStyle7;
            this.electrico.Frozen = true;
            this.electrico.HeaderText = "Diseñador eléctrico";
            this.electrico.MinimumWidth = 150;
            this.electrico.Name = "electrico";
            this.electrico.ReadOnly = true;
            this.electrico.Width = 150;
            // 
            // programador
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.programador.DefaultCellStyle = dataGridViewCellStyle8;
            this.programador.Frozen = true;
            this.programador.HeaderText = "Programador";
            this.programador.MinimumWidth = 150;
            this.programador.Name = "programador";
            this.programador.ReadOnly = true;
            this.programador.Width = 150;
            // 
            // elementos
            // 
            this.elementos.HeaderText = "Elemento";
            this.elementos.MinimumWidth = 100;
            this.elementos.Name = "elementos";
            this.elementos.ReadOnly = true;
            this.elementos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.elementos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.elementos.Width = 150;
            // 
            // secuencia
            // 
            this.secuencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.secuencia.HeaderText = "Secuencia";
            this.secuencia.MinimumWidth = 100;
            this.secuencia.Name = "secuencia";
            this.secuencia.ReadOnly = true;
            this.secuencia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.secuencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // modo_falla
            // 
            this.modo_falla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.modo_falla.HeaderText = "Modo de falla";
            this.modo_falla.MinimumWidth = 100;
            this.modo_falla.Name = "modo_falla";
            this.modo_falla.ReadOnly = true;
            this.modo_falla.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.modo_falla.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FrmModulosProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 481);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmModulosProyecto";
            this.Text = "Módulos del proyecto";
            this.Load += new System.EventHandler(this.FrmModulosProyecto_Load);
            this.menuOpciones.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvModulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnOpciones;
        private System.Windows.Forms.Label LblUltimaActualizacion;
        private System.Windows.Forms.DataGridView DgvModulos;
        private System.Windows.Forms.ContextMenuStrip menuOpciones;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diseñadorMecánicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diseñadorEléctricoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aceptarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diseñoFinalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diseñoDeConceptoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn subensamble;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promesa_fabricacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn mecanico;
        private System.Windows.Forms.DataGridViewTextBoxColumn electrico;
        private System.Windows.Forms.DataGridViewTextBoxColumn programador;
        private System.Windows.Forms.DataGridViewImageColumn elementos;
        private System.Windows.Forms.DataGridViewImageColumn secuencia;
        private System.Windows.Forms.DataGridViewImageColumn modo_falla;
    }
}
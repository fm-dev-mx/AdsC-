namespace CB
{
    partial class FrmDetallesMaterialProyecto
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("General", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Requisición", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Revisión técnica", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Revisión financiera", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Compra", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Almacén", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Ensamble", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Mantenimiento", System.Windows.Forms.HorizontalAlignment.Left);
            this.saveDXF = new System.Windows.Forms.SaveFileDialog();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LvInfoMaterial = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TxtComentariosAutorizacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtComentariosRequisitor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DgvArchivos = new System.Windows.Forms.DataGridView();
            this.id_archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_previa = new System.Windows.Forms.DataGridViewImageColumn();
            this.LblEstatusAsignaciones = new System.Windows.Forms.Label();
            this.BarraProgresoAsignaciones = new System.Windows.Forms.ProgressBar();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BkgSubirArchivo = new System.ComponentModel.BackgroundWorker();
            this.MenuOpciones.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArchivos)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.borrarToolStripMenuItem});
            this.MenuOpciones.Name = "BtnOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(117, 48);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Enabled = false;
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 463);
            this.tabControl1.TabIndex = 42;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LvInfoMaterial);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(568, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Información general";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LvInfoMaterial
            // 
            this.LvInfoMaterial.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LvInfoMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "General";
            listViewGroup1.Name = "General";
            listViewGroup1.Tag = "General";
            listViewGroup2.Header = "Requisición";
            listViewGroup2.Name = "Requisicion";
            listViewGroup2.Tag = "Requisicion";
            listViewGroup3.Header = "Revisión técnica";
            listViewGroup3.Name = "Autorizacion";
            listViewGroup3.Tag = "Autorizacion";
            listViewGroup4.Header = "Revisión financiera";
            listViewGroup4.Name = "Finanzas";
            listViewGroup5.Header = "Compra";
            listViewGroup5.Name = "Compra";
            listViewGroup5.Tag = "Compra";
            listViewGroup6.Header = "Almacén";
            listViewGroup6.Name = "Almacen";
            listViewGroup6.Tag = "Almacen";
            listViewGroup7.Header = "Ensamble";
            listViewGroup7.Name = "Ensamble";
            listViewGroup7.Tag = "Ensamble";
            listViewGroup8.Header = "Mantenimiento";
            listViewGroup8.Name = "Mantenimiento";
            listViewGroup8.Tag = "Mantenimiento";
            this.LvInfoMaterial.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8});
            this.LvInfoMaterial.HideSelection = false;
            this.LvInfoMaterial.Location = new System.Drawing.Point(3, 3);
            this.LvInfoMaterial.Name = "LvInfoMaterial";
            this.LvInfoMaterial.Size = new System.Drawing.Size(562, 431);
            this.LvInfoMaterial.TabIndex = 29;
            this.LvInfoMaterial.UseCompatibleStateImageBehavior = false;
            this.LvInfoMaterial.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Propiedad";
            this.columnHeader1.Width = 176;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Valor";
            this.columnHeader2.Width = 446;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TxtComentariosAutorizacion);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.TxtComentariosRequisitor);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(568, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Comentarios";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TxtComentariosAutorizacion
            // 
            this.TxtComentariosAutorizacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtComentariosAutorizacion.Location = new System.Drawing.Point(3, 173);
            this.TxtComentariosAutorizacion.Multiline = true;
            this.TxtComentariosAutorizacion.Name = "TxtComentariosAutorizacion";
            this.TxtComentariosAutorizacion.ReadOnly = true;
            this.TxtComentariosAutorizacion.Size = new System.Drawing.Size(562, 120);
            this.TxtComentariosAutorizacion.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(562, 25);
            this.label1.TabIndex = 39;
            this.label1.Text = "Comentarios de autorización:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtComentariosRequisitor
            // 
            this.TxtComentariosRequisitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtComentariosRequisitor.Location = new System.Drawing.Point(3, 28);
            this.TxtComentariosRequisitor.Multiline = true;
            this.TxtComentariosRequisitor.Name = "TxtComentariosRequisitor";
            this.TxtComentariosRequisitor.ReadOnly = true;
            this.TxtComentariosRequisitor.Size = new System.Drawing.Size(562, 120);
            this.TxtComentariosRequisitor.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(562, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Comentarios del requisitor:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DgvArchivos);
            this.tabPage3.Controls.Add(this.LblEstatusAsignaciones);
            this.tabPage3.Controls.Add(this.BarraProgresoAsignaciones);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(568, 437);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Archivos adjuntos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DgvArchivos
            // 
            this.DgvArchivos.AllowUserToAddRows = false;
            this.DgvArchivos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_archivo,
            this.nombre_archivo,
            this.vista_previa});
            this.DgvArchivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvArchivos.Location = new System.Drawing.Point(3, 3);
            this.DgvArchivos.Name = "DgvArchivos";
            this.DgvArchivos.RowHeadersVisible = false;
            this.DgvArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvArchivos.Size = new System.Drawing.Size(562, 383);
            this.DgvArchivos.TabIndex = 0;
            this.DgvArchivos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArchivos_CellClick);
            this.DgvArchivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArchivos_CellDoubleClick);
            this.DgvArchivos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvArchivos_CellMouseDown);
            this.DgvArchivos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvArchivos_MouseClick);
            // 
            // id_archivo
            // 
            this.id_archivo.HeaderText = "ID";
            this.id_archivo.Name = "id_archivo";
            this.id_archivo.ReadOnly = true;
            this.id_archivo.Visible = false;
            // 
            // nombre_archivo
            // 
            this.nombre_archivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_archivo.HeaderText = "Nombre del archivo";
            this.nombre_archivo.Name = "nombre_archivo";
            this.nombre_archivo.ReadOnly = true;
            // 
            // vista_previa
            // 
            this.vista_previa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vista_previa.HeaderText = "Vista previa";
            this.vista_previa.Name = "vista_previa";
            this.vista_previa.ReadOnly = true;
            this.vista_previa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LblEstatusAsignaciones
            // 
            this.LblEstatusAsignaciones.BackColor = System.Drawing.Color.Black;
            this.LblEstatusAsignaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusAsignaciones.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusAsignaciones.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusAsignaciones.Location = new System.Drawing.Point(3, 386);
            this.LblEstatusAsignaciones.Name = "LblEstatusAsignaciones";
            this.LblEstatusAsignaciones.Size = new System.Drawing.Size(562, 25);
            this.LblEstatusAsignaciones.TabIndex = 114;
            this.LblEstatusAsignaciones.Text = "Estatus...";
            this.LblEstatusAsignaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarraProgresoAsignaciones
            // 
            this.BarraProgresoAsignaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraProgresoAsignaciones.Location = new System.Drawing.Point(3, 411);
            this.BarraProgresoAsignaciones.Name = "BarraProgresoAsignaciones";
            this.BarraProgresoAsignaciones.Size = new System.Drawing.Size(562, 23);
            this.BarraProgresoAsignaciones.TabIndex = 113;
            this.BarraProgresoAsignaciones.Visible = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(382, 496);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(199, 41);
            this.BtnSalir.TabIndex = 40;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(600, 23);
            this.LblTitulo.TabIndex = 39;
            this.LblTitulo.Text = "DETALLES DE LA REQUISICION DE COMPRA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BkgSubirArchivo
            // 
            this.BkgSubirArchivo.WorkerReportsProgress = true;
            this.BkgSubirArchivo.WorkerSupportsCancellation = true;
            this.BkgSubirArchivo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubirArchivo_DoWork);
            this.BkgSubirArchivo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubirArchivo_ProgressChanged);
            this.BkgSubirArchivo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubirArchivo_RunWorkerCompleted);
            // 
            // FrmDetallesMaterialProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 548);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetallesMaterialProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetallesMaterialProyecto";
            this.MenuOpciones.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvArchivos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView LvInfoMaterial;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtComentariosRequisitor;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SaveFileDialog saveDXF;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtComentariosAutorizacion;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView DgvArchivos;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BkgSubirArchivo;
        private System.Windows.Forms.Label LblEstatusAsignaciones;
        private System.Windows.Forms.ProgressBar BarraProgresoAsignaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_archivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_archivo;
        private System.Windows.Forms.DataGridViewImageColumn vista_previa;
    }
}
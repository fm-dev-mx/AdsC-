namespace CB
{
    partial class FrmDetallesBug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetallesBug));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GuardarAdjunto = new System.Windows.Forms.SaveFileDialog();
            this.SeleccionarAdjunto = new System.Windows.Forms.OpenFileDialog();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImagenesTabs = new System.Windows.Forms.ImageList(this.components);
            this.BtnSalir = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LblNombre = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BtnOpciones = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblOrigen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblCategoria = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DgvResponsables = new System.Windows.Forms.DataGridView();
            this.id_responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.DgvNotas = new System.Windows.Forms.DataGridView();
            this.id_nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtNota = new System.Windows.Forms.TextBox();
            this.LblNotaSeleccionada = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.DgvAdjuntos = new System.Windows.Forms.DataGridView();
            this.id_adjunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_adjunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_adjunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_adjunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_adjunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.MenuOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvResponsables)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNotas)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdjuntos)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.borrarToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(110, 70);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Enabled = false;
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Enabled = false;
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // ImagenesTabs
            // 
            this.ImagenesTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesTabs.ImageStream")));
            this.ImagenesTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesTabs.Images.SetKeyName(0, "details.ico");
            this.ImagenesTabs.Images.SetKeyName(1, "important-icon-16.png");
            this.ImagenesTabs.Images.SetKeyName(2, "Block-icon.png");
            this.ImagenesTabs.Images.SetKeyName(3, "Groups-Meeting-Dark-icon.png");
            this.ImagenesTabs.Images.SetKeyName(4, "Nota.png");
            this.ImagenesTabs.Images.SetKeyName(5, "Attach-icon.png");
            this.ImagenesTabs.Images.SetKeyName(6, "Search-icon1.png");
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(277, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(122, 55);
            this.BtnSalir.TabIndex = 18;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.LblNombre);
            this.splitContainer1.Panel1.Controls.Add(this.TxtDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Tabs);
            this.splitContainer1.Size = new System.Drawing.Size(1160, 671);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 10;
            // 
            // LblNombre
            // 
            this.LblNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.Location = new System.Drawing.Point(0, 0);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(761, 36);
            this.LblNombre.TabIndex = 52;
            this.LblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtDescripcion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtDescripcion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.Location = new System.Drawing.Point(0, 39);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(761, 143);
            this.TxtDescripcion.TabIndex = 51;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(761, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BtnOpciones);
            this.splitContainer2.Panel1.Controls.Add(this.BtnSalir);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(399, 182);
            this.splitContainer2.SplitterDistance = 55;
            this.splitContainer2.TabIndex = 22;
            // 
            // BtnOpciones
            // 
            this.BtnOpciones.ContextMenuStrip = this.MenuOpciones;
            this.BtnOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpciones.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnOpciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpciones.Location = new System.Drawing.Point(158, 0);
            this.BtnOpciones.Name = "BtnOpciones";
            this.BtnOpciones.Size = new System.Drawing.Size(119, 55);
            this.BtnOpciones.TabIndex = 19;
            this.BtnOpciones.Text = "Opciones";
            this.BtnOpciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpciones.UseVisualStyleBackColor = true;
            this.BtnOpciones.Click += new System.EventHandler(this.BtnOpciones_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.LblEstatus);
            this.splitContainer3.Panel1.Controls.Add(this.label7);
            this.splitContainer3.Panel1.Controls.Add(this.LblOrigen);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.LblCategoria);
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Size = new System.Drawing.Size(399, 123);
            this.splitContainer3.SplitterDistance = 193;
            this.splitContainer3.TabIndex = 0;
            // 
            // LblEstatus
            // 
            this.LblEstatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.Location = new System.Drawing.Point(0, 56);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(193, 30);
            this.LblEstatus.TabIndex = 15;
            this.LblEstatus.Text = "SIN RESOLVER";
            this.LblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Estatus:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblOrigen
            // 
            this.LblOrigen.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOrigen.Location = new System.Drawing.Point(0, 13);
            this.LblOrigen.Name = "LblOrigen";
            this.LblOrigen.Size = new System.Drawing.Size(193, 30);
            this.LblOrigen.TabIndex = 13;
            this.LblOrigen.Text = "EXTERNO";
            this.LblOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Origen:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCategoria
            // 
            this.LblCategoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCategoria.Location = new System.Drawing.Point(0, 13);
            this.LblCategoria.Name = "LblCategoria";
            this.LblCategoria.Size = new System.Drawing.Size(202, 30);
            this.LblCategoria.TabIndex = 11;
            this.LblCategoria.Text = "MECANICO";
            this.LblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Categoria:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabPage4);
            this.Tabs.Controls.Add(this.tabPage5);
            this.Tabs.Controls.Add(this.tabPage6);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.ImageList = this.ImagenesTabs;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1160, 485);
            this.Tabs.TabIndex = 0;
            this.Tabs.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DgvResponsables);
            this.tabPage4.ImageIndex = 3;
            this.tabPage4.Location = new System.Drawing.Point(4, 39);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1152, 442);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Responsables";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DgvResponsables
            // 
            this.DgvResponsables.AllowUserToAddRows = false;
            this.DgvResponsables.AllowUserToDeleteRows = false;
            this.DgvResponsables.AllowUserToResizeRows = false;
            this.DgvResponsables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvResponsables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvResponsables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_responsable,
            this.responsable});
            this.DgvResponsables.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DgvResponsables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvResponsables.Location = new System.Drawing.Point(3, 3);
            this.DgvResponsables.Name = "DgvResponsables";
            this.DgvResponsables.ReadOnly = true;
            this.DgvResponsables.RowHeadersVisible = false;
            this.DgvResponsables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvResponsables.Size = new System.Drawing.Size(1146, 436);
            this.DgvResponsables.TabIndex = 4;
            this.DgvResponsables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvResponsables_CellClick);
            // 
            // id_responsable
            // 
            this.id_responsable.HeaderText = "ID";
            this.id_responsable.Name = "id_responsable";
            this.id_responsable.ReadOnly = true;
            this.id_responsable.Visible = false;
            // 
            // responsable
            // 
            this.responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.responsable.HeaderText = "";
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.splitContainer4);
            this.tabPage5.ImageIndex = 4;
            this.tabPage5.Location = new System.Drawing.Point(4, 39);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1152, 442);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Notas";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.DgvNotas);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.TxtNota);
            this.splitContainer4.Panel2.Controls.Add(this.LblNotaSeleccionada);
            this.splitContainer4.Size = new System.Drawing.Size(1152, 442);
            this.splitContainer4.SplitterDistance = 390;
            this.splitContainer4.TabIndex = 0;
            // 
            // DgvNotas
            // 
            this.DgvNotas.AllowUserToAddRows = false;
            this.DgvNotas.AllowUserToDeleteRows = false;
            this.DgvNotas.AllowUserToResizeRows = false;
            this.DgvNotas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_nota,
            this.fecha_nota,
            this.usuario_nota});
            this.DgvNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvNotas.Location = new System.Drawing.Point(0, 0);
            this.DgvNotas.Name = "DgvNotas";
            this.DgvNotas.ReadOnly = true;
            this.DgvNotas.RowHeadersVisible = false;
            this.DgvNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvNotas.Size = new System.Drawing.Size(390, 442);
            this.DgvNotas.TabIndex = 1;
            this.DgvNotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNotas_CellClick);
            this.DgvNotas.Click += new System.EventHandler(this.DgvNotas_Click);
            // 
            // id_nota
            // 
            this.id_nota.HeaderText = "ID";
            this.id_nota.Name = "id_nota";
            this.id_nota.ReadOnly = true;
            this.id_nota.Visible = false;
            // 
            // fecha_nota
            // 
            this.fecha_nota.HeaderText = "Fecha";
            this.fecha_nota.Name = "fecha_nota";
            this.fecha_nota.ReadOnly = true;
            this.fecha_nota.Width = 180;
            // 
            // usuario_nota
            // 
            this.usuario_nota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usuario_nota.DefaultCellStyle = dataGridViewCellStyle1;
            this.usuario_nota.HeaderText = "Usuario";
            this.usuario_nota.Name = "usuario_nota";
            this.usuario_nota.ReadOnly = true;
            // 
            // TxtNota
            // 
            this.TxtNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtNota.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNota.Location = new System.Drawing.Point(0, 23);
            this.TxtNota.Multiline = true;
            this.TxtNota.Name = "TxtNota";
            this.TxtNota.ReadOnly = true;
            this.TxtNota.Size = new System.Drawing.Size(758, 419);
            this.TxtNota.TabIndex = 1;
            this.TxtNota.MouseLeave += new System.EventHandler(this.TxtNota_MouseLeave);
            // 
            // LblNotaSeleccionada
            // 
            this.LblNotaSeleccionada.BackColor = System.Drawing.Color.Black;
            this.LblNotaSeleccionada.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNotaSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNotaSeleccionada.ForeColor = System.Drawing.Color.White;
            this.LblNotaSeleccionada.Location = new System.Drawing.Point(0, 0);
            this.LblNotaSeleccionada.Name = "LblNotaSeleccionada";
            this.LblNotaSeleccionada.Size = new System.Drawing.Size(758, 23);
            this.LblNotaSeleccionada.TabIndex = 8;
            this.LblNotaSeleccionada.Text = "SELECCIONA UNA NOTA";
            this.LblNotaSeleccionada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.DgvAdjuntos);
            this.tabPage6.ImageIndex = 5;
            this.tabPage6.Location = new System.Drawing.Point(4, 39);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1152, 442);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Adjuntos";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // DgvAdjuntos
            // 
            this.DgvAdjuntos.AllowUserToAddRows = false;
            this.DgvAdjuntos.AllowUserToDeleteRows = false;
            this.DgvAdjuntos.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAdjuntos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvAdjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAdjuntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_adjunto,
            this.usuario_adjunto,
            this.fecha_adjunto,
            this.nombre_adjunto,
            this.tipo_adjunto});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAdjuntos.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvAdjuntos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAdjuntos.Location = new System.Drawing.Point(3, 3);
            this.DgvAdjuntos.Name = "DgvAdjuntos";
            this.DgvAdjuntos.ReadOnly = true;
            this.DgvAdjuntos.RowHeadersVisible = false;
            this.DgvAdjuntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAdjuntos.Size = new System.Drawing.Size(1146, 436);
            this.DgvAdjuntos.TabIndex = 0;
            this.DgvAdjuntos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdjuntos_CellClick);
            this.DgvAdjuntos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdjuntos_CellDoubleClick);
            // 
            // id_adjunto
            // 
            this.id_adjunto.HeaderText = "ID";
            this.id_adjunto.Name = "id_adjunto";
            this.id_adjunto.ReadOnly = true;
            this.id_adjunto.Visible = false;
            // 
            // usuario_adjunto
            // 
            this.usuario_adjunto.HeaderText = "Usuario";
            this.usuario_adjunto.Name = "usuario_adjunto";
            this.usuario_adjunto.ReadOnly = true;
            this.usuario_adjunto.Width = 200;
            // 
            // fecha_adjunto
            // 
            this.fecha_adjunto.HeaderText = "Fecha";
            this.fecha_adjunto.Name = "fecha_adjunto";
            this.fecha_adjunto.ReadOnly = true;
            this.fecha_adjunto.Width = 200;
            // 
            // nombre_adjunto
            // 
            this.nombre_adjunto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre_adjunto.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombre_adjunto.HeaderText = "Nombre del archivo";
            this.nombre_adjunto.Name = "nombre_adjunto";
            this.nombre_adjunto.ReadOnly = true;
            // 
            // tipo_adjunto
            // 
            this.tipo_adjunto.HeaderText = "Tipo";
            this.tipo_adjunto.Name = "tipo_adjunto";
            this.tipo_adjunto.ReadOnly = true;
            this.tipo_adjunto.Width = 150;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1160, 23);
            this.LblTitulo.TabIndex = 9;
            this.LblTitulo.Text = "DETALLES DEL BUG";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmDetallesBug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(1160, 694);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetallesBug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles Bug";
            this.Load += new System.EventHandler(this.FrmDetallesBug_Load);
            this.MenuOpciones.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvResponsables)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvNotas)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdjuntos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView DgvNotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_nota;
        private System.Windows.Forms.TextBox TxtNota;
        private System.Windows.Forms.Label LblNotaSeleccionada;
        private System.Windows.Forms.SaveFileDialog GuardarAdjunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_adjunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_adjunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_adjunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_adjunto;
        private System.Windows.Forms.DataGridView DgvAdjuntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_adjunto;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.OpenFileDialog SeleccionarAdjunto;
        private System.Windows.Forms.Button BtnOpciones;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblOrigen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.ImageList ImagenesTabs;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.DataGridView DgvResponsables;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
    }
}
namespace CB
{
    partial class FrmDetallesTopico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetallesTopico));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TvImage = new System.Windows.Forms.ImageList(this.components);
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevaTareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaSubtareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.planificarTiempoExtraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarRevisadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarRevisadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool = new System.Windows.Forms.ToolTip(this.components);
            this.MenuResponsable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.TxtNotas = new System.Windows.Forms.TextBox();
            this.LblNombre = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.BtnTerminarJunta = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.NumHoras = new System.Windows.Forms.NumericUpDown();
            this.LblEstatuslabel = new System.Windows.Forms.Label();
            this.LblFecha = new System.Windows.Forms.Label();
            this.LblFechaCreacion = new System.Windows.Forms.Label();
            this.LblCreadoPor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TvTareas = new System.Windows.Forms.TreeView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.CmbHoras = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbPrioridad = new System.Windows.Forms.ComboBox();
            this.LblTarea = new System.Windows.Forms.Label();
            this.LblEstatusTiempo = new System.Windows.Forms.Label();
            this.LblEstatusActual = new System.Windows.Forms.Label();
            this.CmbEstatus = new System.Windows.Forms.ComboBox();
            this.DtpFechaPromesa = new System.Windows.Forms.DateTimePicker();
            this.LblFechaPromesa = new System.Windows.Forms.Label();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.TxtDescripcion_tarea = new System.Windows.Forms.TextBox();
            this.LblDescripcionTarea = new System.Windows.Forms.Label();
            this.DgvInvolucrados = new System.Windows.Forms.DataGridView();
            this.id_involucrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_involucrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo_alterno_involucrados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvResponsable = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo_alterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblResponsables = new System.Windows.Forms.Label();
            this.DgvSeguimiento = new System.Windows.Forms.DataGridView();
            this.id_seguimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblSeguimiento = new System.Windows.Forms.Label();
            this.tabJuntas = new System.Windows.Forms.TabPage();
            this.DgvJunta = new System.Windows.Forms.DataGridView();
            this.id_DgvJunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invitados_eventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageTab = new System.Windows.Forms.ImageList(this.components);
            this.MenuJuntas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeguimiento = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.TPDgvSeguimiento = new System.Windows.Forms.ToolTip(this.components);
            this.MenuEstatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pendienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enProcesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detenidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descartadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuInvolucrado = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.correoAlternoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpciones.SuspendLayout();
            this.MenuResponsable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoras)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvolucrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvResponsable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSeguimiento)).BeginInit();
            this.tabJuntas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvJunta)).BeginInit();
            this.MenuJuntas.SuspendLayout();
            this.MenuSeguimiento.SuspendLayout();
            this.MenuEstatus.SuspendLayout();
            this.MenuInvolucrado.SuspendLayout();
            this.SuspendLayout();
            // 
            // TvImage
            // 
            this.TvImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TvImage.ImageStream")));
            this.TvImage.TransparentColor = System.Drawing.Color.Transparent;
            this.TvImage.Images.SetKeyName(0, "detenido-a-tiempo.png");
            this.TvImage.Images.SetKeyName(1, "detenido-limite.png");
            this.TvImage.Images.SetKeyName(2, "detenido-tarde.png");
            this.TvImage.Images.SetKeyName(3, "en-proceso-a-tiempo-24.png");
            this.TvImage.Images.SetKeyName(4, "en-proceso-limite-24.png");
            this.TvImage.Images.SetKeyName(5, "en-proceso-tarde-24.png");
            this.TvImage.Images.SetKeyName(6, "pendiente-a-tiempo-24.png");
            this.TvImage.Images.SetKeyName(7, "pendiente-limite-24.png");
            this.TvImage.Images.SetKeyName(8, "pendiente-tarde-24.png");
            this.TvImage.Images.SetKeyName(9, "terminado-a-tiempo-24.png");
            this.TvImage.Images.SetKeyName(10, "terminado-limite-24.png");
            this.TvImage.Images.SetKeyName(11, "terminado-tarde-24.png");
            this.TvImage.Images.SetKeyName(12, "Button_icon_lightGray.jpg");
            this.TvImage.Images.SetKeyName(13, "correct_48.png");
            this.TvImage.Images.SetKeyName(14, "delete-48.png");
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaTareaToolStripMenuItem,
            this.nuevaSubtareaToolStripMenuItem,
            this.editarToolStripMenuItem1,
            this.eliminarToolStripMenuItem1,
            this.planificarTiempoExtraToolStripMenuItem,
            this.mostrarRevisadosToolStripMenuItem,
            this.ocultarRevisadosToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(194, 158);
            this.MenuOpciones.Opening += new System.ComponentModel.CancelEventHandler(this.MenuOpciones_Opening);
            // 
            // nuevaTareaToolStripMenuItem
            // 
            this.nuevaTareaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevaTareaToolStripMenuItem.Name = "nuevaTareaToolStripMenuItem";
            this.nuevaTareaToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.nuevaTareaToolStripMenuItem.Text = "Nueva tarea";
            this.nuevaTareaToolStripMenuItem.Click += new System.EventHandler(this.nuevaTareaToolStripMenuItem_Click);
            // 
            // nuevaSubtareaToolStripMenuItem
            // 
            this.nuevaSubtareaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevaSubtareaToolStripMenuItem.Name = "nuevaSubtareaToolStripMenuItem";
            this.nuevaSubtareaToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.nuevaSubtareaToolStripMenuItem.Text = "Nueva subtarea";
            this.nuevaSubtareaToolStripMenuItem.Click += new System.EventHandler(this.nuevaSubtareaToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.editarToolStripMenuItem1.Text = "Editar";
            this.editarToolStripMenuItem1.Click += new System.EventHandler(this.editarToolStripMenuItem1_Click);
            // 
            // eliminarToolStripMenuItem1
            // 
            this.eliminarToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            this.eliminarToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.eliminarToolStripMenuItem1.Text = "Eliminar";
            this.eliminarToolStripMenuItem1.Click += new System.EventHandler(this.eliminarToolStripMenuItem1_Click);
            // 
            // planificarTiempoExtraToolStripMenuItem
            // 
            this.planificarTiempoExtraToolStripMenuItem.Image = global::CB_Base.Properties.Resources.drawing;
            this.planificarTiempoExtraToolStripMenuItem.Name = "planificarTiempoExtraToolStripMenuItem";
            this.planificarTiempoExtraToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.planificarTiempoExtraToolStripMenuItem.Text = "Planificar tiempo extra";
            this.planificarTiempoExtraToolStripMenuItem.Click += new System.EventHandler(this.planificarTiempoExtraToolStripMenuItem_Click);
            // 
            // mostrarRevisadosToolStripMenuItem
            // 
            this.mostrarRevisadosToolStripMenuItem.CheckOnClick = true;
            this.mostrarRevisadosToolStripMenuItem.Name = "mostrarRevisadosToolStripMenuItem";
            this.mostrarRevisadosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.mostrarRevisadosToolStripMenuItem.Text = "Mostrar revisados";
            this.mostrarRevisadosToolStripMenuItem.Click += new System.EventHandler(this.mostrarRevisadosToolStripMenuItem_Click);
            // 
            // ocultarRevisadosToolStripMenuItem
            // 
            this.ocultarRevisadosToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Block_icon;
            this.ocultarRevisadosToolStripMenuItem.Name = "ocultarRevisadosToolStripMenuItem";
            this.ocultarRevisadosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.ocultarRevisadosToolStripMenuItem.Text = "Ocultar Revisados";
            // 
            // Tool
            // 
            this.Tool.BackColor = System.Drawing.Color.Gold;
            this.Tool.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tool.ToolTipTitle = "Descripción guardada";
            // 
            // MenuResponsable
            // 
            this.MenuResponsable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.borrarToolStripMenuItem,
            this.toolStripMenuItem3});
            this.MenuResponsable.Name = "MenuResponsable";
            this.MenuResponsable.Size = new System.Drawing.Size(151, 70);
            this.MenuResponsable.Opening += new System.ComponentModel.CancelEventHandler(this.MenuResponsable_Opening);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::CB_Base.Properties.Resources.mail_send_icon48;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem3.Text = "Correo alterno";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer1.Panel1.Controls.Add(this.LblTitulo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1522, 788);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 23);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.TxtNotas);
            this.splitContainer4.Panel1.Controls.Add(this.LblNombre);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(1522, 160);
            this.splitContainer4.SplitterDistance = 1045;
            this.splitContainer4.TabIndex = 9;
            // 
            // TxtNotas
            // 
            this.TxtNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtNotas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNotas.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.TxtNotas.Location = new System.Drawing.Point(7, 36);
            this.TxtNotas.Multiline = true;
            this.TxtNotas.Name = "TxtNotas";
            this.TxtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtNotas.Size = new System.Drawing.Size(1035, 124);
            this.TxtNotas.TabIndex = 59;
            this.TxtNotas.TextChanged += new System.EventHandler(this.TxtNotas_TextChanged);
            // 
            // LblNombre
            // 
            this.LblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.Location = new System.Drawing.Point(7, 0);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(1149, 36);
            this.LblNombre.TabIndex = 58;
            this.LblNombre.Text = "NOTAS";
            this.LblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer5.IsSplitterFixed = true;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.BtnTerminarJunta);
            this.splitContainer5.Panel1.Controls.Add(this.BtnSalir);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.LblEstatus);
            this.splitContainer5.Panel2.Controls.Add(this.NumHoras);
            this.splitContainer5.Panel2.Controls.Add(this.LblEstatuslabel);
            this.splitContainer5.Panel2.Controls.Add(this.LblFecha);
            this.splitContainer5.Panel2.Controls.Add(this.LblFechaCreacion);
            this.splitContainer5.Panel2.Controls.Add(this.LblCreadoPor);
            this.splitContainer5.Panel2.Controls.Add(this.label1);
            this.splitContainer5.Size = new System.Drawing.Size(473, 160);
            this.splitContainer5.SplitterDistance = 47;
            this.splitContainer5.TabIndex = 0;
            // 
            // BtnTerminarJunta
            // 
            this.BtnTerminarJunta.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnTerminarJunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTerminarJunta.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnTerminarJunta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTerminarJunta.Location = new System.Drawing.Point(167, 0);
            this.BtnTerminarJunta.Name = "BtnTerminarJunta";
            this.BtnTerminarJunta.Size = new System.Drawing.Size(153, 47);
            this.BtnTerminarJunta.TabIndex = 20;
            this.BtnTerminarJunta.Text = "     Enviar minuta";
            this.BtnTerminarJunta.UseVisualStyleBackColor = true;
            this.BtnTerminarJunta.Click += new System.EventHandler(this.BtnTerminarJunta_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(320, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(153, 47);
            this.BtnSalir.TabIndex = 19;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblEstatus
            // 
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.LblEstatus.Location = new System.Drawing.Point(267, 21);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(202, 30);
            this.LblEstatus.TabIndex = 31;
            this.LblEstatus.Text = "PENDIENTE";
            this.LblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblEstatus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblEstatus_MouseUp);
            // 
            // NumHoras
            // 
            this.NumHoras.DecimalPlaces = 2;
            this.NumHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumHoras.Location = new System.Drawing.Point(220, 67);
            this.NumHoras.Name = "NumHoras";
            this.NumHoras.Size = new System.Drawing.Size(168, 26);
            this.NumHoras.TabIndex = 13;
            this.NumHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumHoras.Visible = false;
            this.NumHoras.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // LblEstatuslabel
            // 
            this.LblEstatuslabel.Location = new System.Drawing.Point(267, 8);
            this.LblEstatuslabel.Name = "LblEstatuslabel";
            this.LblEstatuslabel.Size = new System.Drawing.Size(202, 13);
            this.LblEstatuslabel.TabIndex = 30;
            this.LblEstatuslabel.Text = "Estatus:";
            this.LblEstatuslabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblFecha
            // 
            this.LblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.LblFecha.Location = new System.Drawing.Point(3, 21);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(229, 30);
            this.LblFecha.TabIndex = 29;
            this.LblFecha.Text = "FECHA";
            this.LblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblFechaCreacion
            // 
            this.LblFechaCreacion.Location = new System.Drawing.Point(3, 8);
            this.LblFechaCreacion.Name = "LblFechaCreacion";
            this.LblFechaCreacion.Size = new System.Drawing.Size(202, 13);
            this.LblFechaCreacion.TabIndex = 28;
            this.LblFechaCreacion.Text = "Fecha creación:";
            this.LblFechaCreacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCreadoPor
            // 
            this.LblCreadoPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.LblCreadoPor.Location = new System.Drawing.Point(3, 67);
            this.LblCreadoPor.Name = "LblCreadoPor";
            this.LblCreadoPor.Size = new System.Drawing.Size(229, 30);
            this.LblCreadoPor.TabIndex = 27;
            this.LblCreadoPor.Text = "NOMBRE";
            this.LblCreadoPor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Creado por:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1522, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "DETALLES JUNTAS DE SINCRONIZACION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabJuntas);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.ImageTab;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1522, 601);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1514, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tareas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TvTareas);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1508, 552);
            this.splitContainer2.SplitterDistance = 305;
            this.splitContainer2.TabIndex = 0;
            // 
            // TvTareas
            // 
            this.TvTareas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvTareas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TvTareas.HideSelection = false;
            this.TvTareas.ImageIndex = 0;
            this.TvTareas.ImageList = this.TvImage;
            this.TvTareas.Location = new System.Drawing.Point(0, 0);
            this.TvTareas.Name = "TvTareas";
            this.TvTareas.SelectedImageIndex = 0;
            this.TvTareas.Size = new System.Drawing.Size(305, 552);
            this.TvTareas.TabIndex = 0;
            this.TvTareas.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvTareas_BeforeCollapse);
            this.TvTareas.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvTareas_NodeMouseDoubleClick);
            this.TvTareas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TvTareas_MouseUp);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.CmbHoras);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.CmbPrioridad);
            this.splitContainer3.Panel1.Controls.Add(this.LblTarea);
            this.splitContainer3.Panel1.Controls.Add(this.LblEstatusTiempo);
            this.splitContainer3.Panel1.Controls.Add(this.LblEstatusActual);
            this.splitContainer3.Panel1.Controls.Add(this.CmbEstatus);
            this.splitContainer3.Panel1.Controls.Add(this.DtpFechaPromesa);
            this.splitContainer3.Panel1.Controls.Add(this.LblFechaPromesa);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer3.Panel2.Controls.Add(this.DgvSeguimiento);
            this.splitContainer3.Panel2.Controls.Add(this.LblSeguimiento);
            this.splitContainer3.Size = new System.Drawing.Size(1199, 552);
            this.splitContainer3.SplitterDistance = 86;
            this.splitContainer3.TabIndex = 0;
            // 
            // CmbHoras
            // 
            this.CmbHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbHoras.FormattingEnabled = true;
            this.CmbHoras.Items.AddRange(new object[] {
            "15 minutos",
            "30 minutos",
            "45 minutos",
            "1:00 hora",
            "1:15 horas",
            "1.30 horas",
            "1.45 horas",
            "2:00 horas",
            "2:15 horas",
            "2.30 horas",
            "2.45 horas",
            "3:00 horas",
            "3.15 horas",
            "3.30 horas",
            "3.45 horas",
            "4:00 horas",
            "4:15 horas",
            "4:30 horas",
            "4.45 horas",
            "5:00 horas",
            "5:15 horas",
            "5:30 horas",
            "5:45 horas",
            "6:00 horas",
            "6:15 horas",
            "6:30 horas",
            "6:45 horas",
            "7:00 horas",
            "7:15 horas",
            "7:30 horas",
            "7:45 horas",
            "8:00 horas"});
            this.CmbHoras.Location = new System.Drawing.Point(1021, 47);
            this.CmbHoras.Name = "CmbHoras";
            this.CmbHoras.Size = new System.Drawing.Size(161, 28);
            this.CmbHoras.TabIndex = 14;
            this.CmbHoras.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1021, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Horas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Prioridad";
            // 
            // CmbPrioridad
            // 
            this.CmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrioridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.CmbPrioridad.FormattingEnabled = true;
            this.CmbPrioridad.Items.AddRange(new object[] {
            "URGENTE",
            "REQUIERE ATENCION",
            "REGULAR"});
            this.CmbPrioridad.Location = new System.Drawing.Point(321, 45);
            this.CmbPrioridad.Name = "CmbPrioridad";
            this.CmbPrioridad.Size = new System.Drawing.Size(243, 28);
            this.CmbPrioridad.TabIndex = 10;
            this.CmbPrioridad.SelectedIndexChanged += new System.EventHandler(this.CmbPrioridad_SelectedIndexChanged);
            // 
            // LblTarea
            // 
            this.LblTarea.BackColor = System.Drawing.Color.Black;
            this.LblTarea.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTarea.ForeColor = System.Drawing.Color.White;
            this.LblTarea.Location = new System.Drawing.Point(0, 0);
            this.LblTarea.Name = "LblTarea";
            this.LblTarea.Size = new System.Drawing.Size(1199, 23);
            this.LblTarea.TabIndex = 9;
            this.LblTarea.Text = "TAREA";
            this.LblTarea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblEstatusTiempo
            // 
            this.LblEstatusTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.LblEstatusTiempo.Location = new System.Drawing.Point(819, 43);
            this.LblEstatusTiempo.Name = "LblEstatusTiempo";
            this.LblEstatusTiempo.Size = new System.Drawing.Size(196, 30);
            this.LblEstatusTiempo.TabIndex = 4;
            this.LblEstatusTiempo.Text = "EstatusTiempo";
            this.LblEstatusTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblEstatusActual
            // 
            this.LblEstatusActual.AutoSize = true;
            this.LblEstatusActual.Location = new System.Drawing.Point(567, 29);
            this.LblEstatusActual.Name = "LblEstatusActual";
            this.LblEstatusActual.Size = new System.Drawing.Size(105, 16);
            this.LblEstatusActual.TabIndex = 3;
            this.LblEstatusActual.Text = "Estatus actual";
            // 
            // CmbEstatus
            // 
            this.CmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.CmbEstatus.FormattingEnabled = true;
            this.CmbEstatus.Items.AddRange(new object[] {
            "PENDIENTE",
            "DETENIDO",
            "EN PROCESO",
            "TERMINADO",
            "REVISADO"});
            this.CmbEstatus.Location = new System.Drawing.Point(570, 45);
            this.CmbEstatus.Name = "CmbEstatus";
            this.CmbEstatus.Size = new System.Drawing.Size(243, 28);
            this.CmbEstatus.TabIndex = 2;
            this.CmbEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbEstatus_SelectedIndexChanged);
            this.CmbEstatus.SelectionChangeCommitted += new System.EventHandler(this.CmbEstatus_SelectionChangeCommitted);
            // 
            // DtpFechaPromesa
            // 
            this.DtpFechaPromesa.CustomFormat = "MMM dd, yyyy";
            this.DtpFechaPromesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.DtpFechaPromesa.Location = new System.Drawing.Point(18, 47);
            this.DtpFechaPromesa.Name = "DtpFechaPromesa";
            this.DtpFechaPromesa.Size = new System.Drawing.Size(297, 26);
            this.DtpFechaPromesa.TabIndex = 1;
            this.DtpFechaPromesa.CloseUp += new System.EventHandler(this.DtpFechaPromesa_CloseUp);
            // 
            // LblFechaPromesa
            // 
            this.LblFechaPromesa.AutoSize = true;
            this.LblFechaPromesa.Location = new System.Drawing.Point(15, 31);
            this.LblFechaPromesa.Name = "LblFechaPromesa";
            this.LblFechaPromesa.Size = new System.Drawing.Size(116, 16);
            this.LblFechaPromesa.TabIndex = 0;
            this.LblFechaPromesa.Text = "Fecha promesa";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer6.IsSplitterFixed = true;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.TxtDescripcion_tarea);
            this.splitContainer6.Panel1.Controls.Add(this.LblDescripcionTarea);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.DgvInvolucrados);
            this.splitContainer6.Panel2.Controls.Add(this.label3);
            this.splitContainer6.Panel2.Controls.Add(this.DgvResponsable);
            this.splitContainer6.Panel2.Controls.Add(this.LblResponsables);
            this.splitContainer6.Size = new System.Drawing.Size(1199, 272);
            this.splitContainer6.SplitterDistance = 620;
            this.splitContainer6.TabIndex = 13;
            // 
            // TxtDescripcion_tarea
            // 
            this.TxtDescripcion_tarea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtDescripcion_tarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion_tarea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDescripcion_tarea.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.TxtDescripcion_tarea.Location = new System.Drawing.Point(0, 20);
            this.TxtDescripcion_tarea.Multiline = true;
            this.TxtDescripcion_tarea.Name = "TxtDescripcion_tarea";
            this.TxtDescripcion_tarea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDescripcion_tarea.Size = new System.Drawing.Size(620, 252);
            this.TxtDescripcion_tarea.TabIndex = 7;
            this.TxtDescripcion_tarea.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDescripcion_tarea_Validating);
            // 
            // LblDescripcionTarea
            // 
            this.LblDescripcionTarea.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblDescripcionTarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescripcionTarea.Location = new System.Drawing.Point(0, 0);
            this.LblDescripcionTarea.Name = "LblDescripcionTarea";
            this.LblDescripcionTarea.Size = new System.Drawing.Size(620, 20);
            this.LblDescripcionTarea.TabIndex = 5;
            this.LblDescripcionTarea.Text = "Descripción de la tarea";
            this.LblDescripcionTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvInvolucrados
            // 
            this.DgvInvolucrados.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.DgvInvolucrados.AllowUserToAddRows = false;
            this.DgvInvolucrados.AllowUserToResizeColumns = false;
            this.DgvInvolucrados.AllowUserToResizeRows = false;
            this.DgvInvolucrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvInvolucrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_involucrado,
            this.nombre_involucrado,
            this.correo_alterno_involucrados});
            this.DgvInvolucrados.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvInvolucrados.Location = new System.Drawing.Point(0, 157);
            this.DgvInvolucrados.Name = "DgvInvolucrados";
            this.DgvInvolucrados.RowHeadersVisible = false;
            this.DgvInvolucrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvInvolucrados.Size = new System.Drawing.Size(575, 112);
            this.DgvInvolucrados.TabIndex = 11;
            this.DgvInvolucrados.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvInvolucrados_CellMouseDown);
            this.DgvInvolucrados.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // id_involucrado
            // 
            this.id_involucrado.HeaderText = "Id";
            this.id_involucrado.Name = "id_involucrado";
            this.id_involucrado.ReadOnly = true;
            this.id_involucrado.Visible = false;
            // 
            // nombre_involucrado
            // 
            this.nombre_involucrado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_involucrado.HeaderText = "Nombre";
            this.nombre_involucrado.Name = "nombre_involucrado";
            this.nombre_involucrado.ReadOnly = true;
            // 
            // correo_alterno_involucrados
            // 
            this.correo_alterno_involucrados.HeaderText = "Correo alterno";
            this.correo_alterno_involucrados.MinimumWidth = 80;
            this.correo_alterno_involucrados.Name = "correo_alterno_involucrados";
            this.correo_alterno_involucrados.ReadOnly = true;
            this.correo_alterno_involucrados.Width = 200;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(0, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(575, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Involucrados";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // DgvResponsable
            // 
            this.DgvResponsable.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.DgvResponsable.AllowUserToAddRows = false;
            this.DgvResponsable.AllowUserToResizeColumns = false;
            this.DgvResponsable.AllowUserToResizeRows = false;
            this.DgvResponsable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvResponsable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.responsable,
            this.correo_alterno});
            this.DgvResponsable.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvResponsable.Location = new System.Drawing.Point(0, 20);
            this.DgvResponsable.Name = "DgvResponsable";
            this.DgvResponsable.RowHeadersVisible = false;
            this.DgvResponsable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvResponsable.Size = new System.Drawing.Size(575, 116);
            this.DgvResponsable.TabIndex = 9;
            this.DgvResponsable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvResponsable_CellMouseDown);
            this.DgvResponsable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvResponsable_MouseClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 80;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 150;
            // 
            // responsable
            // 
            this.responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.responsable.HeaderText = "Nombre";
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            // 
            // correo_alterno
            // 
            this.correo_alterno.HeaderText = "Correo alterno";
            this.correo_alterno.MinimumWidth = 80;
            this.correo_alterno.Name = "correo_alterno";
            this.correo_alterno.ReadOnly = true;
            this.correo_alterno.Width = 200;
            // 
            // LblResponsables
            // 
            this.LblResponsables.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblResponsables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblResponsables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblResponsables.Location = new System.Drawing.Point(0, 0);
            this.LblResponsables.Name = "LblResponsables";
            this.LblResponsables.Size = new System.Drawing.Size(575, 20);
            this.LblResponsables.TabIndex = 8;
            this.LblResponsables.Text = "Responsables";
            this.LblResponsables.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvSeguimiento
            // 
            this.DgvSeguimiento.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.DgvSeguimiento.AllowUserToAddRows = false;
            this.DgvSeguimiento.AllowUserToResizeColumns = false;
            this.DgvSeguimiento.AllowUserToResizeRows = false;
            this.DgvSeguimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvSeguimiento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvSeguimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSeguimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_seguimiento,
            this.fecha,
            this.usuario,
            this.comentarios,
            this.editable});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSeguimiento.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvSeguimiento.Location = new System.Drawing.Point(0, 298);
            this.DgvSeguimiento.Name = "DgvSeguimiento";
            this.DgvSeguimiento.RowHeadersVisible = false;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSeguimiento.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvSeguimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSeguimiento.Size = new System.Drawing.Size(1199, 159);
            this.DgvSeguimiento.TabIndex = 12;
            this.DgvSeguimiento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSeguimiento_CellClick);
            this.DgvSeguimiento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSeguimiento_CellEndEdit);
            this.DgvSeguimiento.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvSeguimiento_CellMouseDown);
            this.DgvSeguimiento.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSeguimiento_CellMouseLeave);
            this.DgvSeguimiento.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvSeguimiento_EditingControlShowing);
            // 
            // id_seguimiento
            // 
            this.id_seguimiento.FillWeight = 50F;
            this.id_seguimiento.HeaderText = "Id";
            this.id_seguimiento.Name = "id_seguimiento";
            this.id_seguimiento.ReadOnly = true;
            this.id_seguimiento.Width = 50;
            // 
            // fecha
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecha.HeaderText = "Fecha";
            this.fecha.MinimumWidth = 130;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 180;
            // 
            // usuario
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usuario.DefaultCellStyle = dataGridViewCellStyle2;
            this.usuario.HeaderText = "Usuario";
            this.usuario.MinimumWidth = 100;
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            this.usuario.Width = 180;
            // 
            // comentarios
            // 
            this.comentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios.DefaultCellStyle = dataGridViewCellStyle3;
            this.comentarios.HeaderText = "Comentarios";
            this.comentarios.Name = "comentarios";
            // 
            // editable
            // 
            this.editable.HeaderText = "Editable";
            this.editable.Name = "editable";
            this.editable.ReadOnly = true;
            this.editable.Visible = false;
            // 
            // LblSeguimiento
            // 
            this.LblSeguimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSeguimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblSeguimiento.Location = new System.Drawing.Point(0, 275);
            this.LblSeguimiento.Name = "LblSeguimiento";
            this.LblSeguimiento.Size = new System.Drawing.Size(1057, 20);
            this.LblSeguimiento.TabIndex = 10;
            this.LblSeguimiento.Text = "Seguimiento";
            // 
            // tabJuntas
            // 
            this.tabJuntas.Controls.Add(this.DgvJunta);
            this.tabJuntas.ImageIndex = 1;
            this.tabJuntas.Location = new System.Drawing.Point(4, 39);
            this.tabJuntas.Name = "tabJuntas";
            this.tabJuntas.Padding = new System.Windows.Forms.Padding(3);
            this.tabJuntas.Size = new System.Drawing.Size(1514, 558);
            this.tabJuntas.TabIndex = 1;
            this.tabJuntas.Text = "Juntas";
            this.tabJuntas.UseVisualStyleBackColor = true;
            // 
            // DgvJunta
            // 
            this.DgvJunta.AllowUserToAddRows = false;
            this.DgvJunta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvJunta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvJunta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_DgvJunta,
            this.Evento,
            this.descripcion_evento,
            this.fecha_evento,
            this.invitados_eventos,
            this.tipo_evento});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvJunta.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvJunta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvJunta.Location = new System.Drawing.Point(3, 3);
            this.DgvJunta.Name = "DgvJunta";
            this.DgvJunta.RowHeadersVisible = false;
            this.DgvJunta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvJunta.Size = new System.Drawing.Size(1508, 552);
            this.DgvJunta.TabIndex = 0;
            this.DgvJunta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJunta_CellClick);
            this.DgvJunta.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvJunta_CellMouseDown);
            this.DgvJunta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvJunta_MouseClick);
            // 
            // id_DgvJunta
            // 
            this.id_DgvJunta.HeaderText = "id";
            this.id_DgvJunta.Name = "id_DgvJunta";
            this.id_DgvJunta.ReadOnly = true;
            this.id_DgvJunta.Visible = false;
            this.id_DgvJunta.Width = 40;
            // 
            // Evento
            // 
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Evento.DefaultCellStyle = dataGridViewCellStyle6;
            this.Evento.HeaderText = "Nombre";
            this.Evento.MinimumWidth = 200;
            this.Evento.Name = "Evento";
            this.Evento.ReadOnly = true;
            this.Evento.Width = 250;
            // 
            // descripcion_evento
            // 
            this.descripcion_evento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion_evento.DefaultCellStyle = dataGridViewCellStyle7;
            this.descripcion_evento.HeaderText = "Descripción";
            this.descripcion_evento.Name = "descripcion_evento";
            this.descripcion_evento.ReadOnly = true;
            // 
            // fecha_evento
            // 
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fecha_evento.DefaultCellStyle = dataGridViewCellStyle8;
            this.fecha_evento.HeaderText = "Fecha";
            this.fecha_evento.MinimumWidth = 150;
            this.fecha_evento.Name = "fecha_evento";
            this.fecha_evento.ReadOnly = true;
            this.fecha_evento.Width = 200;
            // 
            // invitados_eventos
            // 
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.invitados_eventos.DefaultCellStyle = dataGridViewCellStyle9;
            this.invitados_eventos.HeaderText = "Invitados";
            this.invitados_eventos.MinimumWidth = 100;
            this.invitados_eventos.Name = "invitados_eventos";
            this.invitados_eventos.ReadOnly = true;
            this.invitados_eventos.Width = 200;
            // 
            // tipo_evento
            // 
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tipo_evento.DefaultCellStyle = dataGridViewCellStyle10;
            this.tipo_evento.HeaderText = "Tipo";
            this.tipo_evento.MinimumWidth = 100;
            this.tipo_evento.Name = "tipo_evento";
            this.tipo_evento.ReadOnly = true;
            this.tipo_evento.Width = 180;
            // 
            // ImageTab
            // 
            this.ImageTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageTab.ImageStream")));
            this.ImageTab.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageTab.Images.SetKeyName(0, "order.ico");
            this.ImageTab.Images.SetKeyName(1, "meeting.png");
            // 
            // MenuJuntas
            // 
            this.MenuJuntas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.nuevaToolStripMenuItem});
            this.MenuJuntas.Name = "MenuJuntas";
            this.MenuJuntas.Size = new System.Drawing.Size(133, 70);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.nuevaToolStripMenuItem.Text = "Crear junta";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // MenuSeguimiento
            // 
            this.MenuSeguimiento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem2});
            this.MenuSeguimiento.Name = "MenuSeguimiento";
            this.MenuSeguimiento.Size = new System.Drawing.Size(105, 26);
            // 
            // editarToolStripMenuItem2
            // 
            this.editarToolStripMenuItem2.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem2.Name = "editarToolStripMenuItem2";
            this.editarToolStripMenuItem2.Size = new System.Drawing.Size(104, 22);
            this.editarToolStripMenuItem2.Text = "Editar";
            this.editarToolStripMenuItem2.Click += new System.EventHandler(this.editarToolStripMenuItem2_Click);
            // 
            // MenuEstatus
            // 
            this.MenuEstatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendienteToolStripMenuItem,
            this.enProcesoToolStripMenuItem,
            this.detenidoToolStripMenuItem,
            this.terminadoToolStripMenuItem,
            this.descartadoToolStripMenuItem});
            this.MenuEstatus.Name = "contextMenuStrip1";
            this.MenuEstatus.Size = new System.Drawing.Size(134, 114);
            // 
            // pendienteToolStripMenuItem
            // 
            this.pendienteToolStripMenuItem.Image = global::CB_Base.Properties.Resources.pendiente_a_tiempo_24;
            this.pendienteToolStripMenuItem.Name = "pendienteToolStripMenuItem";
            this.pendienteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.pendienteToolStripMenuItem.Text = "Pendiente";
            this.pendienteToolStripMenuItem.Click += new System.EventHandler(this.pendienteToolStripMenuItem_Click);
            // 
            // enProcesoToolStripMenuItem
            // 
            this.enProcesoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.en_proceso_a_tiempo_24;
            this.enProcesoToolStripMenuItem.Name = "enProcesoToolStripMenuItem";
            this.enProcesoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.enProcesoToolStripMenuItem.Text = "En proceso";
            this.enProcesoToolStripMenuItem.Click += new System.EventHandler(this.enProcesoToolStripMenuItem_Click);
            // 
            // detenidoToolStripMenuItem
            // 
            this.detenidoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.detenido_a_tiempo;
            this.detenidoToolStripMenuItem.Name = "detenidoToolStripMenuItem";
            this.detenidoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.detenidoToolStripMenuItem.Text = "Detenido";
            this.detenidoToolStripMenuItem.Click += new System.EventHandler(this.detenidoToolStripMenuItem_Click);
            // 
            // terminadoToolStripMenuItem
            // 
            this.terminadoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.terminado_a_tiempo_24;
            this.terminadoToolStripMenuItem.Name = "terminadoToolStripMenuItem";
            this.terminadoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.terminadoToolStripMenuItem.Text = "Terminado";
            this.terminadoToolStripMenuItem.Click += new System.EventHandler(this.terminadoToolStripMenuItem_Click);
            // 
            // descartadoToolStripMenuItem
            // 
            this.descartadoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Button_icon_lightGray;
            this.descartadoToolStripMenuItem.Name = "descartadoToolStripMenuItem";
            this.descartadoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.descartadoToolStripMenuItem.Text = "Descartado";
            this.descartadoToolStripMenuItem.Click += new System.EventHandler(this.descartadoToolStripMenuItem_Click);
            // 
            // MenuInvolucrado
            // 
            this.MenuInvolucrado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.correoAlternoToolStripMenuItem});
            this.MenuInvolucrado.Name = "MenuResponsable";
            this.MenuInvolucrado.Size = new System.Drawing.Size(151, 70);
            this.MenuInvolucrado.Opening += new System.ComponentModel.CancelEventHandler(this.MenuInvolucrado_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem1.Text = "Agregar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::CB_Base.Properties.Resources.close;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem2.Text = "Borrar";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // correoAlternoToolStripMenuItem
            // 
            this.correoAlternoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.mail_send_icon48;
            this.correoAlternoToolStripMenuItem.Name = "correoAlternoToolStripMenuItem";
            this.correoAlternoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.correoAlternoToolStripMenuItem.Text = "Correo alterno";
            this.correoAlternoToolStripMenuItem.Click += new System.EventHandler(this.correoAlternoToolStripMenuItem_Click);
            // 
            // FrmDetallesTopico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 788);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetallesTopico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles del tópico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDetallesTopico_FormClosing);
            this.Load += new System.EventHandler(this.FrmDetallesTopico_Load);
            this.MenuOpciones.ResumeLayout(false);
            this.MenuResponsable.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumHoras)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvolucrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvResponsable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSeguimiento)).EndInit();
            this.tabJuntas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvJunta)).EndInit();
            this.MenuJuntas.ResumeLayout(false);
            this.MenuSeguimiento.ResumeLayout(false);
            this.MenuEstatus.ResumeLayout(false);
            this.MenuInvolucrado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView TvTareas;
        private System.Windows.Forms.TabPage tabJuntas;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label LblEstatusTiempo;
        private System.Windows.Forms.Label LblEstatusActual;
        private System.Windows.Forms.ComboBox CmbEstatus;
        private System.Windows.Forms.DateTimePicker DtpFechaPromesa;
        private System.Windows.Forms.Label LblFechaPromesa;
        private System.Windows.Forms.Label LblResponsables;
        private System.Windows.Forms.TextBox TxtDescripcion_tarea;
        private System.Windows.Forms.Label LblDescripcionTarea;
        private System.Windows.Forms.Label LblSeguimiento;
        private System.Windows.Forms.DataGridView DgvResponsable;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TextBox TxtNotas;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.Label LblEstatuslabel;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label LblFechaCreacion;
        private System.Windows.Forms.Label LblCreadoPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem nuevaTareaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaSubtareaToolStripMenuItem;
        private System.Windows.Forms.ImageList TvImage;
        private System.Windows.Forms.ToolTip Tool;
        private System.Windows.Forms.ContextMenuStrip MenuResponsable;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.Label LblTarea;
        private System.Windows.Forms.DataGridView DgvSeguimiento;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.DataGridView DgvJunta;
        private System.Windows.Forms.ContextMenuStrip MenuJuntas;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ImageList ImageTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_DgvJunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn invitados_eventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_evento;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip MenuSeguimiento;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem2;
        private System.Windows.Forms.ToolTip TPDgvSeguimiento;
        private System.Windows.Forms.ContextMenuStrip MenuEstatus;
        private System.Windows.Forms.ToolStripMenuItem pendienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enProcesoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detenidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descartadoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_seguimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn editable;
        private System.Windows.Forms.ToolStripMenuItem planificarTiempoExtraToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbPrioridad;
        private System.Windows.Forms.ToolStripMenuItem mostrarRevisadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocultarRevisadosToolStripMenuItem;
        private System.Windows.Forms.Button BtnTerminarJunta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvInvolucrados;
        private System.Windows.Forms.ContextMenuStrip MenuInvolucrado;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.NumericUpDown NumHoras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem correoAlternoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_involucrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_involucrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo_alterno_involucrados;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo_alterno;
        private System.Windows.Forms.ComboBox CmbHoras;
    }
}
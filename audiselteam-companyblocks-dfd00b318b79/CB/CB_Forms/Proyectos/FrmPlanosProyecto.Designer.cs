namespace CB
{
    partial class FrmPlanosProyecto
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
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanosProyecto));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CmbFiltroModulo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnDefinirUniverso = new System.Windows.Forms.Button();
            this.MenuSubirPlano = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSubirDesdePDF = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSubirPlano = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbFiltroEstatus = new System.Windows.Forms.ComboBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.DgvPlanos = new System.Windows.Forms.DataGridView();
            this.id_plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_ensamble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miniatura = new System.Windows.Forms.DataGridViewImageColumn();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.BtnOcultarDetalles = new System.Windows.Forms.Button();
            this.LblCargandoPlano = new System.Windows.Forms.Label();
            this.LblNumeroPlano = new System.Windows.Forms.Label();
            this.BtnOpcionesPlano = new System.Windows.Forms.Button();
            this.GrupoInfoPlano = new System.Windows.Forms.GroupBox();
            this.LblMaterial = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblTratamiento = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblRecibido = new System.Windows.Forms.Label();
            this.LblProveedor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblFechaPlano = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.SeleccionarArchivo = new System.Windows.Forms.OpenFileDialog();
            this.MenuOpcionesPlanoSinRevisar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDetallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpcionesPlanoRevisado = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuActualizarPlano = new System.Windows.Forms.ToolStripMenuItem();
            this.verDetallesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CargarPartes = new System.Windows.Forms.OpenFileDialog();
            this.MenuOpcionesPlanoSinDocumentar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.documentarPlanoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReporte = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MenuReportes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.estatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.MenuSubirPlano.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlanos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.GrupoInfoPlano.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.MenuOpcionesPlanoSinRevisar.SuspendLayout();
            this.MenuOpcionesPlanoRevisado.SuspendLayout();
            this.MenuOpcionesPlanoSinDocumentar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MenuReportes.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.CmbFiltroModulo);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.LblTitulo);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.CmbFiltroEstatus);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1197, 566);
            this.splitContainer2.SplitterDistance = 89;
            this.splitContainer2.TabIndex = 5;
            // 
            // CmbFiltroModulo
            // 
            this.CmbFiltroModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroModulo.FormattingEnabled = true;
            this.CmbFiltroModulo.Location = new System.Drawing.Point(391, 48);
            this.CmbFiltroModulo.Name = "CmbFiltroModulo";
            this.CmbFiltroModulo.Size = new System.Drawing.Size(332, 28);
            this.CmbFiltroModulo.TabIndex = 24;
            this.CmbFiltroModulo.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroModulo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(389, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Modulo:";
            // 
            // BtnDefinirUniverso
            // 
            this.BtnDefinirUniverso.ContextMenuStrip = this.MenuSubirPlano;
            this.BtnDefinirUniverso.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnDefinirUniverso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDefinirUniverso.Image = global::CB_Base.Properties.Resources.sun;
            this.BtnDefinirUniverso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDefinirUniverso.Location = new System.Drawing.Point(0, 0);
            this.BtnDefinirUniverso.Name = "BtnDefinirUniverso";
            this.BtnDefinirUniverso.Size = new System.Drawing.Size(165, 55);
            this.BtnDefinirUniverso.TabIndex = 5;
            this.BtnDefinirUniverso.Text = "Definir universo";
            this.BtnDefinirUniverso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDefinirUniverso.UseVisualStyleBackColor = true;
            this.BtnDefinirUniverso.Click += new System.EventHandler(this.BtnDefinirUniverso_Click);
            // 
            // MenuSubirPlano
            // 
            this.MenuSubirPlano.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuSubirPlano.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSubirDesdePDF});
            this.MenuSubirPlano.Name = "contextSubirPlano";
            this.MenuSubirPlano.Size = new System.Drawing.Size(135, 30);
            // 
            // menuSubirDesdePDF
            // 
            this.menuSubirDesdePDF.Image = global::CB_Base.Properties.Resources.pdf_icon_png_pdf_zum_download_2;
            this.menuSubirDesdePDF.Name = "menuSubirDesdePDF";
            this.menuSubirDesdePDF.Size = new System.Drawing.Size(134, 26);
            this.menuSubirDesdePDF.Text = "Desde PDF";
            this.menuSubirDesdePDF.Click += new System.EventHandler(this.menuSubirDesdePDF_Click);
            // 
            // BtnSubirPlano
            // 
            this.BtnSubirPlano.ContextMenuStrip = this.MenuSubirPlano;
            this.BtnSubirPlano.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSubirPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubirPlano.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.BtnSubirPlano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubirPlano.Location = new System.Drawing.Point(165, 0);
            this.BtnSubirPlano.Name = "BtnSubirPlano";
            this.BtnSubirPlano.Size = new System.Drawing.Size(144, 55);
            this.BtnSubirPlano.TabIndex = 2;
            this.BtnSubirPlano.Text = "Subir plano";
            this.BtnSubirPlano.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSubirPlano.UseVisualStyleBackColor = true;
            this.BtnSubirPlano.Click += new System.EventHandler(this.BtnSubirPlano_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1197, 23);
            this.LblTitulo.TabIndex = 4;
            this.LblTitulo.Text = "PLANOS DEL PROYECTO XXX.YY - NOMBRE";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Estatus:";
            // 
            // CmbFiltroEstatus
            // 
            this.CmbFiltroEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroEstatus.FormattingEnabled = true;
            this.CmbFiltroEstatus.Items.AddRange(new object[] {
            "TODOS",
            "SIN DOCUMENTAR",
            "PRELIMINAR",
            "RECHAZADO",
            "PENDIENTE",
            "EN PREPARACION",
            "EN FABRICACION",
            "TERMINADO",
            "ENTREGADO"});
            this.CmbFiltroEstatus.Location = new System.Drawing.Point(12, 48);
            this.CmbFiltroEstatus.Name = "CmbFiltroEstatus";
            this.CmbFiltroEstatus.Size = new System.Drawing.Size(371, 28);
            this.CmbFiltroEstatus.TabIndex = 1;
            this.CmbFiltroEstatus.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroEstatus_SelectedIndexChanged);
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
            this.splitContainer3.Panel1.Controls.Add(this.DgvPlanos);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1197, 473);
            this.splitContainer3.SplitterDistance = 836;
            this.splitContainer3.TabIndex = 1;
            // 
            // DgvPlanos
            // 
            this.DgvPlanos.AllowUserToAddRows = false;
            this.DgvPlanos.AllowUserToResizeRows = false;
            this.DgvPlanos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPlanos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DgvPlanos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlanos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_plano,
            this.plano,
            this.tipo_plano,
            this.estatus_fabricacion,
            this.estatus_ensamble,
            this.miniatura});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPlanos.DefaultCellStyle = dataGridViewCellStyle21;
            this.DgvPlanos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPlanos.Location = new System.Drawing.Point(0, 0);
            this.DgvPlanos.MultiSelect = false;
            this.DgvPlanos.Name = "DgvPlanos";
            this.DgvPlanos.ReadOnly = true;
            this.DgvPlanos.RowHeadersVisible = false;
            this.DgvPlanos.RowHeadersWidth = 51;
            this.DgvPlanos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPlanos.Size = new System.Drawing.Size(836, 473);
            this.DgvPlanos.TabIndex = 0;
            this.DgvPlanos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlanos_CellDoubleClick);
            this.DgvPlanos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvPlanos_CellMouseDown);
            this.DgvPlanos.SelectionChanged += new System.EventHandler(this.DgvPlanos_SelectionChanged);
            // 
            // id_plano
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_plano.DefaultCellStyle = dataGridViewCellStyle16;
            this.id_plano.Frozen = true;
            this.id_plano.HeaderText = "ID";
            this.id_plano.MinimumWidth = 6;
            this.id_plano.Name = "id_plano";
            this.id_plano.ReadOnly = true;
            this.id_plano.Width = 70;
            // 
            // plano
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plano.DefaultCellStyle = dataGridViewCellStyle17;
            this.plano.Frozen = true;
            this.plano.HeaderText = "Plano";
            this.plano.MinimumWidth = 6;
            this.plano.Name = "plano";
            this.plano.ReadOnly = true;
            this.plano.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.plano.Width = 190;
            // 
            // tipo_plano
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipo_plano.DefaultCellStyle = dataGridViewCellStyle18;
            this.tipo_plano.HeaderText = "Tipo de trabajo";
            this.tipo_plano.MinimumWidth = 6;
            this.tipo_plano.Name = "tipo_plano";
            this.tipo_plano.ReadOnly = true;
            this.tipo_plano.Width = 170;
            // 
            // estatus_fabricacion
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_fabricacion.DefaultCellStyle = dataGridViewCellStyle19;
            this.estatus_fabricacion.HeaderText = "Estatus fabricación";
            this.estatus_fabricacion.MinimumWidth = 6;
            this.estatus_fabricacion.Name = "estatus_fabricacion";
            this.estatus_fabricacion.ReadOnly = true;
            this.estatus_fabricacion.Width = 170;
            // 
            // estatus_ensamble
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_ensamble.DefaultCellStyle = dataGridViewCellStyle20;
            this.estatus_ensamble.HeaderText = "Estatus ensamble";
            this.estatus_ensamble.MinimumWidth = 6;
            this.estatus_ensamble.Name = "estatus_ensamble";
            this.estatus_ensamble.ReadOnly = true;
            this.estatus_ensamble.Width = 170;
            // 
            // miniatura
            // 
            this.miniatura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.miniatura.HeaderText = "Vista previa";
            this.miniatura.MinimumWidth = 6;
            this.miniatura.Name = "miniatura";
            this.miniatura.ReadOnly = true;
            this.miniatura.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.miniatura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer4.Panel1.Controls.Add(this.BtnOcultarDetalles);
            this.splitContainer4.Panel1.Controls.Add(this.LblCargandoPlano);
            this.splitContainer4.Panel1.Controls.Add(this.LblNumeroPlano);
            this.splitContainer4.Panel1.Controls.Add(this.BtnOpcionesPlano);
            this.splitContainer4.Panel1.Controls.Add(this.GrupoInfoPlano);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer4.Size = new System.Drawing.Size(357, 473);
            this.splitContainer4.SplitterDistance = 117;
            this.splitContainer4.TabIndex = 1;
            // 
            // BtnOcultarDetalles
            // 
            this.BtnOcultarDetalles.Location = new System.Drawing.Point(1, 95);
            this.BtnOcultarDetalles.Name = "BtnOcultarDetalles";
            this.BtnOcultarDetalles.Size = new System.Drawing.Size(117, 23);
            this.BtnOcultarDetalles.TabIndex = 2;
            this.BtnOcultarDetalles.Text = "Ocultar";
            this.BtnOcultarDetalles.UseVisualStyleBackColor = true;
            this.BtnOcultarDetalles.Click += new System.EventHandler(this.BtnOcultarDetalles_Click);
            // 
            // LblCargandoPlano
            // 
            this.LblCargandoPlano.AutoSize = true;
            this.LblCargandoPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCargandoPlano.Location = new System.Drawing.Point(5, 76);
            this.LblCargandoPlano.Name = "LblCargandoPlano";
            this.LblCargandoPlano.Size = new System.Drawing.Size(108, 13);
            this.LblCargandoPlano.TabIndex = 1;
            this.LblCargandoPlano.Text = "Cargando plano...";
            this.LblCargandoPlano.Visible = false;
            // 
            // LblNumeroPlano
            // 
            this.LblNumeroPlano.BackColor = System.Drawing.Color.Black;
            this.LblNumeroPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNumeroPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroPlano.ForeColor = System.Drawing.Color.White;
            this.LblNumeroPlano.Location = new System.Drawing.Point(0, 0);
            this.LblNumeroPlano.Name = "LblNumeroPlano";
            this.LblNumeroPlano.Size = new System.Drawing.Size(357, 23);
            this.LblNumeroPlano.TabIndex = 1;
            this.LblNumeroPlano.Text = "DETALLES DEL PLANO";
            this.LblNumeroPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnOpcionesPlano
            // 
            this.BtnOpcionesPlano.Enabled = false;
            this.BtnOpcionesPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpcionesPlano.Image = global::CB_Base.Properties.Resources.Options;
            this.BtnOpcionesPlano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpcionesPlano.Location = new System.Drawing.Point(2, 26);
            this.BtnOpcionesPlano.Name = "BtnOpcionesPlano";
            this.BtnOpcionesPlano.Size = new System.Drawing.Size(115, 45);
            this.BtnOpcionesPlano.TabIndex = 1;
            this.BtnOpcionesPlano.Text = "Opciones";
            this.BtnOpcionesPlano.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpcionesPlano.UseVisualStyleBackColor = true;
            this.BtnOpcionesPlano.Click += new System.EventHandler(this.BtnOpcionesPlano_Click);
            // 
            // GrupoInfoPlano
            // 
            this.GrupoInfoPlano.Controls.Add(this.LblMaterial);
            this.GrupoInfoPlano.Controls.Add(this.label2);
            this.GrupoInfoPlano.Controls.Add(this.LblTratamiento);
            this.GrupoInfoPlano.Controls.Add(this.label9);
            this.GrupoInfoPlano.Controls.Add(this.label8);
            this.GrupoInfoPlano.Controls.Add(this.label7);
            this.GrupoInfoPlano.Controls.Add(this.LblRecibido);
            this.GrupoInfoPlano.Controls.Add(this.LblProveedor);
            this.GrupoInfoPlano.Controls.Add(this.label4);
            this.GrupoInfoPlano.Controls.Add(this.LblEstatus);
            this.GrupoInfoPlano.Controls.Add(this.label6);
            this.GrupoInfoPlano.Controls.Add(this.LblCantidad);
            this.GrupoInfoPlano.Controls.Add(this.label5);
            this.GrupoInfoPlano.Controls.Add(this.label3);
            this.GrupoInfoPlano.Controls.Add(this.LblFechaPlano);
            this.GrupoInfoPlano.Controls.Add(this.LblUsuario);
            this.GrupoInfoPlano.Location = new System.Drawing.Point(119, 20);
            this.GrupoInfoPlano.Name = "GrupoInfoPlano";
            this.GrupoInfoPlano.Size = new System.Drawing.Size(1197, 104);
            this.GrupoInfoPlano.TabIndex = 1;
            this.GrupoInfoPlano.TabStop = false;
            this.GrupoInfoPlano.Visible = false;
            // 
            // LblMaterial
            // 
            this.LblMaterial.AutoSize = true;
            this.LblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMaterial.Location = new System.Drawing.Point(121, 75);
            this.LblMaterial.Name = "LblMaterial";
            this.LblMaterial.Size = new System.Drawing.Size(56, 16);
            this.LblMaterial.TabIndex = 21;
            this.LblMaterial.Text = "Material";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Material:";
            // 
            // LblTratamiento
            // 
            this.LblTratamiento.AutoSize = true;
            this.LblTratamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTratamiento.Location = new System.Drawing.Point(436, 75);
            this.LblTratamiento.Name = "LblTratamiento";
            this.LblTratamiento.Size = new System.Drawing.Size(80, 16);
            this.LblTratamiento.TabIndex = 14;
            this.LblTratamiento.Text = "Tratamiento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(347, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tratamiento:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(332, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Fabricado por:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(367, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Recibido:";
            // 
            // LblRecibido
            // 
            this.LblRecibido.AutoSize = true;
            this.LblRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRecibido.Location = new System.Drawing.Point(438, 33);
            this.LblRecibido.Name = "LblRecibido";
            this.LblRecibido.Size = new System.Drawing.Size(63, 16);
            this.LblRecibido.TabIndex = 3;
            this.LblRecibido.Text = "Recibido";
            // 
            // LblProveedor
            // 
            this.LblProveedor.AutoSize = true;
            this.LblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProveedor.Location = new System.Drawing.Point(438, 53);
            this.LblProveedor.Name = "LblProveedor";
            this.LblProveedor.Size = new System.Drawing.Size(72, 16);
            this.LblProveedor.TabIndex = 5;
            this.LblProveedor.Text = "Proveedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(379, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Estatus:";
            // 
            // LblEstatus
            // 
            this.LblEstatus.AutoSize = true;
            this.LblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.Location = new System.Drawing.Point(438, 12);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(52, 16);
            this.LblEstatus.TabIndex = 19;
            this.LblEstatus.Text = "Estatus";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cantidad:";
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.Location = new System.Drawing.Point(121, 56);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(62, 16);
            this.LblCantidad.TabIndex = 4;
            this.LblCantidad.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha creación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Creado por:";
            // 
            // LblFechaPlano
            // 
            this.LblFechaPlano.AutoSize = true;
            this.LblFechaPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFechaPlano.Location = new System.Drawing.Point(121, 34);
            this.LblFechaPlano.Name = "LblFechaPlano";
            this.LblFechaPlano.Size = new System.Drawing.Size(46, 16);
            this.LblFechaPlano.TabIndex = 6;
            this.LblFechaPlano.Text = "Fecha";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.Location = new System.Drawing.Point(121, 12);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(55, 16);
            this.LblUsuario.TabIndex = 7;
            this.LblUsuario.Text = "Usuario";
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(357, 352);
            this.VisorPDF.TabIndex = 1;
            // 
            // SeleccionarArchivo
            // 
            this.SeleccionarArchivo.FileName = "openFileDialog1";
            // 
            // MenuOpcionesPlanoSinRevisar
            // 
            this.MenuOpcionesPlanoSinRevisar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuOpcionesPlanoSinRevisar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetallesToolStripMenuItem});
            this.MenuOpcionesPlanoSinRevisar.Name = "MenuOpcionesPlanoSinRevisar";
            this.MenuOpcionesPlanoSinRevisar.Size = new System.Drawing.Size(138, 30);
            // 
            // verDetallesToolStripMenuItem
            // 
            this.verDetallesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.details;
            this.verDetallesToolStripMenuItem.Name = "verDetallesToolStripMenuItem";
            this.verDetallesToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.verDetallesToolStripMenuItem.Text = "Ver detalles";
            this.verDetallesToolStripMenuItem.Click += new System.EventHandler(this.verDetallesToolStripMenuItem_Click);
            // 
            // MenuOpcionesPlanoRevisado
            // 
            this.MenuOpcionesPlanoRevisado.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuOpcionesPlanoRevisado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuActualizarPlano,
            this.verDetallesToolStripMenuItem1});
            this.MenuOpcionesPlanoRevisado.Name = "MenuOpcionesPlanoRevisado";
            this.MenuOpcionesPlanoRevisado.Size = new System.Drawing.Size(138, 56);
            // 
            // menuActualizarPlano
            // 
            this.menuActualizarPlano.Image = global::CB_Base.Properties.Resources.Edit;
            this.menuActualizarPlano.Name = "menuActualizarPlano";
            this.menuActualizarPlano.Size = new System.Drawing.Size(137, 26);
            this.menuActualizarPlano.Text = "Actualizar";
            this.menuActualizarPlano.Click += new System.EventHandler(this.menuActualizarPlano_Click);
            // 
            // verDetallesToolStripMenuItem1
            // 
            this.verDetallesToolStripMenuItem1.Image = global::CB_Base.Properties.Resources.details;
            this.verDetallesToolStripMenuItem1.Name = "verDetallesToolStripMenuItem1";
            this.verDetallesToolStripMenuItem1.Size = new System.Drawing.Size(137, 26);
            this.verDetallesToolStripMenuItem1.Text = "Ver detalles";
            this.verDetallesToolStripMenuItem1.Click += new System.EventHandler(this.verDetallesToolStripMenuItem1_Click);
            // 
            // CargarPartes
            // 
            this.CargarPartes.Filter = "SolidWorks Assembly|*.sldasm|SolidWorks Parts|*.sldprt";
            this.CargarPartes.Multiselect = true;
            // 
            // MenuOpcionesPlanoSinDocumentar
            // 
            this.MenuOpcionesPlanoSinDocumentar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuOpcionesPlanoSinDocumentar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentarPlanoToolStripMenuItem,
            this.borrarToolStripMenuItem});
            this.MenuOpcionesPlanoSinDocumentar.Name = "MenuOpcionesPlanoSinDocumentar";
            this.MenuOpcionesPlanoSinDocumentar.Size = new System.Drawing.Size(178, 56);
            // 
            // documentarPlanoToolStripMenuItem
            // 
            this.documentarPlanoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.documentarPlanoToolStripMenuItem.Name = "documentarPlanoToolStripMenuItem";
            this.documentarPlanoToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.documentarPlanoToolStripMenuItem.Text = "Documentar plano";
            this.documentarPlanoToolStripMenuItem.Click += new System.EventHandler(this.documentarPlanoToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Block_icon;
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.cancelarToolStripMenuItem.Text = "Cancelar";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.ContextMenuStrip = this.MenuReportes;
            this.btnReporte.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Image = global::CB_Base.Properties.Resources.Paste_32;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.Location = new System.Drawing.Point(309, 0);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(144, 55);
            this.btnReporte.TabIndex = 25;
            this.btnReporte.Text = "      Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReporte);
            this.panel1.Controls.Add(this.BtnSubirPlano);
            this.panel1.Controls.Add(this.BtnDefinirUniverso);
            this.panel1.Location = new System.Drawing.Point(729, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 55);
            this.panel1.TabIndex = 26;
            // 
            // MenuReportes
            // 
            this.MenuReportes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estatusToolStripMenuItem});
            this.MenuReportes.Name = "MenuReportes";
            this.MenuReportes.Size = new System.Drawing.Size(112, 26);
            // 
            // estatusToolStripMenuItem
            // 
            this.estatusToolStripMenuItem.Image = global::CB_Base.Properties.Resources.about_icon_48;
            this.estatusToolStripMenuItem.Name = "estatusToolStripMenuItem";
            this.estatusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.estatusToolStripMenuItem.Text = "Estatus";
            this.estatusToolStripMenuItem.Click += new System.EventHandler(this.estatusToolStripMenuItem_Click);
            // 
            // FrmPlanosProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 566);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FrmPlanosProyecto";
            this.Text = "Planos del proyecto";
            this.Load += new System.EventHandler(this.FrmPlanosProyecto_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.MenuSubirPlano.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlanos)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.GrupoInfoPlano.ResumeLayout(false);
            this.GrupoInfoPlano.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.MenuOpcionesPlanoSinRevisar.ResumeLayout(false);
            this.MenuOpcionesPlanoRevisado.ResumeLayout(false);
            this.MenuOpcionesPlanoSinDocumentar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.MenuReportes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbFiltroEstatus;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView DgvPlanos;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label LblCargandoPlano;
        private System.Windows.Forms.Label LblNumeroPlano;
        private System.Windows.Forms.Button BtnOpcionesPlano;
        private System.Windows.Forms.GroupBox GrupoInfoPlano;
        private System.Windows.Forms.Label LblTratamiento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblRecibido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblFechaPlano;
        private System.Windows.Forms.Label LblUsuario;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnSubirPlano;
        private System.Windows.Forms.ContextMenuStrip MenuSubirPlano;
        private System.Windows.Forms.ToolStripMenuItem menuSubirDesdePDF;
        private System.Windows.Forms.ContextMenuStrip MenuOpcionesPlanoSinRevisar;
        private System.Windows.Forms.ContextMenuStrip MenuOpcionesPlanoRevisado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.Label LblMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuActualizarPlano;
        private System.Windows.Forms.Button BtnDefinirUniverso;
        private System.Windows.Forms.OpenFileDialog CargarPartes;
        private System.Windows.Forms.ContextMenuStrip MenuOpcionesPlanoSinDocumentar;
        private System.Windows.Forms.ToolStripMenuItem documentarPlanoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.Button BtnOcultarDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_fabricacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_ensamble;
        private System.Windows.Forms.DataGridViewImageColumn miniatura;
        private System.Windows.Forms.OpenFileDialog SeleccionarArchivo;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CmbFiltroModulo;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip MenuReportes;
        private System.Windows.Forms.ToolStripMenuItem estatusToolStripMenuItem;
    }
}
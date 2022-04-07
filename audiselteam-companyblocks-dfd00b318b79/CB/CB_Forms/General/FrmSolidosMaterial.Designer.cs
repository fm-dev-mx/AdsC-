namespace CB
{
    partial class FrmSolidosMaterial
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
            this.DgvSolido = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icono = new System.Windows.Forms.DataGridViewImageColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.ProgresoDescarga = new System.Windows.Forms.ProgressBar();
            this.BkgSubirSolido = new System.ComponentModel.BackgroundWorker();
            this.BkgBorrar = new System.ComponentModel.BackgroundWorker();
            this.BkgExportar = new System.ComponentModel.BackgroundWorker();
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.LblCategoria = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BkgDescargarSolidos = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSolido)).BeginInit();
            this.MenuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvSolido
            // 
            this.DgvSolido.AllowUserToAddRows = false;
            this.DgvSolido.AllowUserToOrderColumns = true;
            this.DgvSolido.AllowUserToResizeRows = false;
            this.DgvSolido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvSolido.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvSolido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSolido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.icono,
            this.nombre,
            this.tamano});
            this.DgvSolido.Location = new System.Drawing.Point(0, 243);
            this.DgvSolido.Name = "DgvSolido";
            this.DgvSolido.RowHeadersVisible = false;
            this.DgvSolido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSolido.Size = new System.Drawing.Size(964, 360);
            this.DgvSolido.TabIndex = 2;
            this.DgvSolido.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvSolido_CellMouseDown);
            this.DgvSolido.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvSolido_MouseDown);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 300;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 300;
            // 
            // icono
            // 
            this.icono.HeaderText = "";
            this.icono.MinimumWidth = 50;
            this.icono.Name = "icono";
            this.icono.ReadOnly = true;
            this.icono.Width = 50;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 200;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // tamano
            // 
            this.tamano.FillWeight = 300F;
            this.tamano.HeaderText = "Tamaño Kb";
            this.tamano.MinimumWidth = 300;
            this.tamano.Name = "tamano";
            this.tamano.ReadOnly = true;
            this.tamano.Width = 300;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Location = new System.Drawing.Point(1, 99);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.LblDescripcion.TabIndex = 5;
            this.LblDescripcion.Text = "Descripción";
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subirToolStripMenuItem,
            this.borrarToolStripMenuItem});
            this.MenuOpciones.Name = "contextMenuStrip1";
            this.MenuOpciones.Size = new System.Drawing.Size(107, 48);
            // 
            // subirToolStripMenuItem
            // 
            this.subirToolStripMenuItem.Image = global::CB_Base.Properties.Resources.upload;
            this.subirToolStripMenuItem.Name = "subirToolStripMenuItem";
            this.subirToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.subirToolStripMenuItem.Text = "Subir";
            this.subirToolStripMenuItem.Click += new System.EventHandler(this.subirToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TxtDescripcion.Location = new System.Drawing.Point(4, 115);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtDescripcion.Size = new System.Drawing.Size(787, 65);
            this.TxtDescripcion.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Fabricante *";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFabricante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFabricante.Location = new System.Drawing.Point(419, 64);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.ReadOnly = true;
            this.TxtFabricante.Size = new System.Drawing.Size(372, 29);
            this.TxtFabricante.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Número de parte *";
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(4, 64);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.ReadOnly = true;
            this.TxtNumeroParte.Size = new System.Drawing.Size(409, 29);
            this.TxtNumeroParte.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Image = global::CB_Base.Properties.Resources.exit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(797, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "      Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnExportar.Image = global::CB_Base.Properties.Resources.export2;
            this.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExportar.Location = new System.Drawing.Point(797, 118);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(165, 48);
            this.BtnExportar.TabIndex = 0;
            this.BtnExportar.Text = "         Exportar";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // LblEstatus
            // 
            this.LblEstatus.BackColor = System.Drawing.Color.Black;
            this.LblEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatus.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatus.Location = new System.Drawing.Point(0, 607);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(964, 29);
            this.LblEstatus.TabIndex = 16;
            this.LblEstatus.Text = "Estatus...";
            this.LblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoDescarga
            // 
            this.ProgresoDescarga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoDescarga.Location = new System.Drawing.Point(0, 636);
            this.ProgresoDescarga.Name = "ProgresoDescarga";
            this.ProgresoDescarga.Size = new System.Drawing.Size(964, 23);
            this.ProgresoDescarga.TabIndex = 15;
            // 
            // BkgSubirSolido
            // 
            this.BkgSubirSolido.WorkerReportsProgress = true;
            this.BkgSubirSolido.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgSubirSolido_DoWork);
            this.BkgSubirSolido.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgSubirSolido_ProgressChanged);
            this.BkgSubirSolido.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgSubirSolido_RunWorkerCompleted);
            // 
            // BkgBorrar
            // 
            this.BkgBorrar.WorkerReportsProgress = true;
            this.BkgBorrar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgBorrar_DoWork);
            this.BkgBorrar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgBorrar_ProgressChanged);
            this.BkgBorrar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgBorrar_RunWorkerCompleted);
            // 
            // BkgExportar
            // 
            this.BkgExportar.WorkerReportsProgress = true;
            this.BkgExportar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgExportar_DoWork);
            this.BkgExportar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgExportar_ProgressChanged);
            this.BkgExportar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgExportar_RunWorkerCompleted);
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(4, 199);
            this.CmbCategoria.MaxLength = 60;
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(476, 32);
            this.CmbCategoria.TabIndex = 17;
            this.CmbCategoria.SelectedIndexChanged += new System.EventHandler(this.CmbCategoria_SelectedIndexChanged);
            this.CmbCategoria.TextChanged += new System.EventHandler(this.CmbCategoria_TextChanged);
            this.CmbCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbCategoria_KeyPress);
            // 
            // LblCategoria
            // 
            this.LblCategoria.AutoSize = true;
            this.LblCategoria.Location = new System.Drawing.Point(1, 183);
            this.LblCategoria.Name = "LblCategoria";
            this.LblCategoria.Size = new System.Drawing.Size(79, 13);
            this.LblCategoria.TabIndex = 18;
            this.LblCategoria.Text = "Configuración *";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(964, 23);
            this.LblTitulo.TabIndex = 19;
            this.LblTitulo.Text = "SOLIDOS DEL MATERIAL";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // BkgDescargarSolidos
            // 
            this.BkgDescargarSolidos.WorkerReportsProgress = true;
            this.BkgDescargarSolidos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarSolidos_DoWork);
            this.BkgDescargarSolidos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarSolidos_ProgressChanged);
            this.BkgDescargarSolidos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarSolidos_RunWorkerCompleted);
            // 
            // FrmSolidosMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 659);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblCategoria);
            this.Controls.Add(this.CmbCategoria);
            this.Controls.Add(this.LblEstatus);
            this.Controls.Add(this.ProgresoDescarga);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtFabricante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNumeroParte);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.DgvSolido);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnExportar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSolidosMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sólidos de material";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSolidosMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSolido)).EndInit();
            this.MenuOpciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DgvSolido;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem subirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.ProgressBar ProgresoDescarga;
        private System.ComponentModel.BackgroundWorker BkgSubirSolido;
        private System.ComponentModel.BackgroundWorker BkgBorrar;
        private System.ComponentModel.BackgroundWorker BkgExportar;
        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.Label LblCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewImageColumn icono;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamano;
        private System.Windows.Forms.Label LblTitulo;
        private System.ComponentModel.BackgroundWorker BkgDescargarSolidos;
    }
}
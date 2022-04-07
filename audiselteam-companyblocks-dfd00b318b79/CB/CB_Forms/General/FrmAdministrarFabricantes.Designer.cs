namespace CB
{
    partial class FrmAdministrarFabricantes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DgvFabricantes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logo = new System.Windows.Forms.DataGridViewImageColumn();
            this.logo_en_ftp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuArchivos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgDescargarFabricante = new System.ComponentModel.BackgroundWorker();
            this.LblEstatus = new System.Windows.Forms.Label();
            this.ProgresoDescarga = new System.Windows.Forms.ProgressBar();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.BkgRemoverDocumento = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFabricantes)).BeginInit();
            this.MenuArchivos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnActualizar);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 54);
            this.panel1.TabIndex = 0;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.update;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(391, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(134, 54);
            this.BtnActualizar.TabIndex = 1;
            this.BtnActualizar.Text = "    Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(525, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(134, 54);
            this.BtnSalir.TabIndex = 0;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // DgvFabricantes
            // 
            this.DgvFabricantes.AllowUserToAddRows = false;
            this.DgvFabricantes.AllowUserToDeleteRows = false;
            this.DgvFabricantes.AllowUserToResizeRows = false;
            this.DgvFabricantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvFabricantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFabricantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.logo,
            this.logo_en_ftp});
            this.DgvFabricantes.ContextMenuStrip = this.MenuArchivos;
            this.DgvFabricantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvFabricantes.Location = new System.Drawing.Point(0, 77);
            this.DgvFabricantes.MultiSelect = false;
            this.DgvFabricantes.Name = "DgvFabricantes";
            this.DgvFabricantes.RowHeadersVisible = false;
            this.DgvFabricantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFabricantes.Size = new System.Drawing.Size(659, 396);
            this.DgvFabricantes.TabIndex = 1;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 40;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle1;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // logo
            // 
            this.logo.HeaderText = "Logo";
            this.logo.Name = "logo";
            this.logo.ReadOnly = true;
            this.logo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.logo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.logo.Width = 164;
            // 
            // logo_en_ftp
            // 
            this.logo_en_ftp.HeaderText = "logo";
            this.logo_en_ftp.Name = "logo_en_ftp";
            this.logo_en_ftp.ReadOnly = true;
            this.logo_en_ftp.Visible = false;
            // 
            // MenuArchivos
            // 
            this.MenuArchivos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProveedorToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuArchivos.Name = "contextMenuStrip1";
            this.MenuArchivos.Size = new System.Drawing.Size(166, 70);
            this.MenuArchivos.Opening += new System.ComponentModel.CancelEventHandler(this.MenuArchivos_Opening);
            // 
            // nuevoProveedorToolStripMenuItem
            // 
            this.nuevoProveedorToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevoProveedorToolStripMenuItem.Name = "nuevoProveedorToolStripMenuItem";
            this.nuevoProveedorToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.nuevoProveedorToolStripMenuItem.Text = "Nuevo fabricante";
            this.nuevoProveedorToolStripMenuItem.Click += new System.EventHandler(this.nuevoProveedorToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // BkgDescargarFabricante
            // 
            this.BkgDescargarFabricante.WorkerReportsProgress = true;
            this.BkgDescargarFabricante.WorkerSupportsCancellation = true;
            this.BkgDescargarFabricante.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarFabricante_DoWork);
            this.BkgDescargarFabricante.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarFabricante_ProgressChanged);
            this.BkgDescargarFabricante.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarFabricante_RunWorkerCompleted);
            // 
            // LblEstatus
            // 
            this.LblEstatus.BackColor = System.Drawing.Color.Black;
            this.LblEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatus.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatus.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatus.Location = new System.Drawing.Point(0, 473);
            this.LblEstatus.Name = "LblEstatus";
            this.LblEstatus.Size = new System.Drawing.Size(659, 25);
            this.LblEstatus.TabIndex = 112;
            this.LblEstatus.Text = "Estatus...";
            this.LblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgresoDescarga
            // 
            this.ProgresoDescarga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgresoDescarga.Location = new System.Drawing.Point(0, 498);
            this.ProgresoDescarga.Name = "ProgresoDescarga";
            this.ProgresoDescarga.Size = new System.Drawing.Size(659, 23);
            this.ProgresoDescarga.TabIndex = 111;
            this.ProgresoDescarga.Visible = false;
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(659, 23);
            this.audiselTituloForm1.TabIndex = 2;
            this.audiselTituloForm1.Text = "ADMINISTRAR FABRICANTES";
            // 
            // BkgRemoverDocumento
            // 
            this.BkgRemoverDocumento.WorkerReportsProgress = true;
            this.BkgRemoverDocumento.WorkerSupportsCancellation = true;
            this.BkgRemoverDocumento.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgRemoverDocumento_DoWork);
            this.BkgRemoverDocumento.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgRemoverDocumento_ProgressChanged);
            this.BkgRemoverDocumento.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgRemoverDocumento_RunWorkerCompleted);
            // 
            // FrmAdministrarFabricantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 521);
            this.Controls.Add(this.DgvFabricantes);
            this.Controls.Add(this.LblEstatus);
            this.Controls.Add(this.ProgresoDescarga);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAdministrarFabricantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar fabricantes";
            this.Load += new System.EventHandler(this.FrmAdministrarFabricantes_Load);
            this.Shown += new System.EventHandler(this.FrmAdministrarFabricantes_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFabricantes)).EndInit();
            this.MenuArchivos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvFabricantes;
        private System.Windows.Forms.ContextMenuStrip MenuArchivos;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ToolStripMenuItem nuevoProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.ComponentModel.BackgroundWorker BkgDescargarFabricante;
        private System.Windows.Forms.Label LblEstatus;
        private System.Windows.Forms.ProgressBar ProgresoDescarga;
        private System.ComponentModel.BackgroundWorker BkgRemoverDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewImageColumn logo;
        private System.Windows.Forms.DataGridViewTextBoxColumn logo_en_ftp;
        private System.Windows.Forms.Button BtnActualizar;
    }
}
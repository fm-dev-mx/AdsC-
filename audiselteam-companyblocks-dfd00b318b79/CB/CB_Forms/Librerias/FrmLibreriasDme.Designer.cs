namespace CB
{
    partial class FrmLibreriasDme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLibreriasDme));
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.TvLibrerias = new System.Windows.Forms.TreeView();
            this.MenuLibreria = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.registrarLibreríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarRemotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImgList = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.BkgConectarFtp = new System.ComponentModel.BackgroundWorker();
            this.PanelPrincipal.SuspendLayout();
            this.MenuLibreria.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.Controls.Add(this.TvLibrerias);
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(327, 441);
            this.PanelPrincipal.TabIndex = 0;
            // 
            // TvLibrerias
            // 
            this.TvLibrerias.ContextMenuStrip = this.MenuLibreria;
            this.TvLibrerias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvLibrerias.ImageIndex = 0;
            this.TvLibrerias.ImageList = this.ImgList;
            this.TvLibrerias.Location = new System.Drawing.Point(0, 0);
            this.TvLibrerias.Name = "TvLibrerias";
            this.TvLibrerias.SelectedImageIndex = 0;
            this.TvLibrerias.Size = new System.Drawing.Size(327, 441);
            this.TvLibrerias.TabIndex = 1;
            this.TvLibrerias.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvLibrerias_NodeMouseDoubleClick);
            // 
            // MenuLibreria
            // 
            this.MenuLibreria.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurarToolStripMenuItem,
            this.registrarLibreríaToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.actualizarToolStripMenuItem,
            this.eliminarRemotoToolStripMenuItem,
            this.eliminarLocalToolStripMenuItem});
            this.MenuLibreria.Name = "MenuLibreria";
            this.MenuLibreria.Size = new System.Drawing.Size(160, 136);
            this.MenuLibreria.Opening += new System.ComponentModel.CancelEventHandler(this.MenuLibreria_Opening);
            // 
            // registrarLibreríaToolStripMenuItem
            // 
            this.registrarLibreríaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.registrarLibreríaToolStripMenuItem.Name = "registrarLibreríaToolStripMenuItem";
            this.registrarLibreríaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.registrarLibreríaToolStripMenuItem.Text = "Registrar librería";
            this.registrarLibreríaToolStripMenuItem.Click += new System.EventHandler(this.registrarLibreríaToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.editarToolStripMenuItem.Text = "Editar librería";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.update;
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // configurarToolStripMenuItem
            // 
            this.configurarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Options;
            this.configurarToolStripMenuItem.Name = "configurarToolStripMenuItem";
            this.configurarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.configurarToolStripMenuItem.Text = "Configurar";
            this.configurarToolStripMenuItem.Click += new System.EventHandler(this.configurarToolStripMenuItem_Click);
            // 
            // eliminarRemotoToolStripMenuItem
            // 
            this.eliminarRemotoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarRemotoToolStripMenuItem.Name = "eliminarRemotoToolStripMenuItem";
            this.eliminarRemotoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eliminarRemotoToolStripMenuItem.Text = "Eliminar remoto";
            this.eliminarRemotoToolStripMenuItem.Click += new System.EventHandler(this.eliminarRemotoToolStripMenuItem_Click);
            // 
            // eliminarLocalToolStripMenuItem
            // 
            this.eliminarLocalToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarLocalToolStripMenuItem.Name = "eliminarLocalToolStripMenuItem";
            this.eliminarLocalToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eliminarLocalToolStripMenuItem.Text = "Eliminar local";
            this.eliminarLocalToolStripMenuItem.Click += new System.EventHandler(this.eliminarLocalToolStripMenuItem_Click);
            // 
            // ImgList
            // 
            this.ImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgList.ImageStream")));
            this.ImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgList.Images.SetKeyName(0, "index_48.png");
            this.ImgList.Images.SetKeyName(1, "sldprt-32.png");
            this.ImgList.Images.SetKeyName(2, "sldasm.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(327, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 441);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // FrmLibreriasDme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 441);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.PanelPrincipal);
            this.IsMdiContainer = true;
            this.Name = "FrmLibreriasDme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Librerías de diseño mecánico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLibreriasDme_Load);
            this.PanelPrincipal.ResumeLayout(false);
            this.MenuLibreria.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Splitter splitter1;
        private System.ComponentModel.BackgroundWorker BkgConectarFtp;
        private System.Windows.Forms.TreeView TvLibrerias;
        private System.Windows.Forms.ContextMenuStrip MenuLibreria;
        private System.Windows.Forms.ToolStripMenuItem registrarLibreríaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarRemotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarLocalToolStripMenuItem;
        private System.Windows.Forms.ImageList ImgList;
        private System.Windows.Forms.ToolStripMenuItem configurarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
    }
}
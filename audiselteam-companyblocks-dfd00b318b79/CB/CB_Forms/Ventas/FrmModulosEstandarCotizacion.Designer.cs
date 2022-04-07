namespace CB
{
    partial class FrmModulosEstandarCotizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModulosEstandarCotizacion));
            this.TvModulos = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MenuCaracteristicas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCaracteristicasEliminar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPrincipal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarMóduloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarDeMóduloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCaracterísticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarCaracterísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.MenuCaracteristicas.SuspendLayout();
            this.MenuCaracteristicasEliminar.SuspendLayout();
            this.MenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TvModulos
            // 
            this.TvModulos.Dock = System.Windows.Forms.DockStyle.Left;
            this.TvModulos.ImageIndex = 0;
            this.TvModulos.ImageList = this.imageList1;
            this.TvModulos.Location = new System.Drawing.Point(0, 23);
            this.TvModulos.Name = "TvModulos";
            this.TvModulos.SelectedImageIndex = 0;
            this.TvModulos.Size = new System.Drawing.Size(281, 601);
            this.TvModulos.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "gray-button-24.png");
            this.imageList1.Images.SetKeyName(1, "index_48.png");
            this.imageList1.Images.SetKeyName(2, "modelos.jpg");
            this.imageList1.Images.SetKeyName(3, "apple-icon-60x60.png");
            this.imageList1.Images.SetKeyName(4, "task-icon.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(281, 23);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 601);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // MenuCaracteristicas
            // 
            this.MenuCaracteristicas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaToolStripMenuItem});
            this.MenuCaracteristicas.Name = "MenuCaracteristicas";
            this.MenuCaracteristicas.Size = new System.Drawing.Size(112, 26);
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.nuevaToolStripMenuItem.Text = "Nueva ";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // MenuCaracteristicasEliminar
            // 
            this.MenuCaracteristicasEliminar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem});
            this.MenuCaracteristicasEliminar.Name = "contextMenuStrip1";
            this.MenuCaracteristicasEliminar.Size = new System.Drawing.Size(118, 26);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarMóduloToolStripMenuItem,
            this.quitarDeMóduloToolStripMenuItem,
            this.nuevaCaracterísticaToolStripMenuItem,
            this.eliminarCaracterísticasToolStripMenuItem});
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(195, 114);
            this.MenuPrincipal.Opening += new System.ComponentModel.CancelEventHandler(this.MenuPrincipal_Opening);
            // 
            // agregarMóduloToolStripMenuItem
            // 
            this.agregarMóduloToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarMóduloToolStripMenuItem.Name = "agregarMóduloToolStripMenuItem";
            this.agregarMóduloToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.agregarMóduloToolStripMenuItem.Text = "Agregar módulo";
            this.agregarMóduloToolStripMenuItem.Click += new System.EventHandler(this.agregarMóduloToolStripMenuItem_Click);
            // 
            // quitarDeMóduloToolStripMenuItem
            // 
            this.quitarDeMóduloToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.quitarDeMóduloToolStripMenuItem.Name = "quitarDeMóduloToolStripMenuItem";
            this.quitarDeMóduloToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.quitarDeMóduloToolStripMenuItem.Text = "Quitar módulo";
            this.quitarDeMóduloToolStripMenuItem.Click += new System.EventHandler(this.quitarDeMóduloToolStripMenuItem_Click);
            // 
            // nuevaCaracterísticaToolStripMenuItem
            // 
            this.nuevaCaracterísticaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevaCaracterísticaToolStripMenuItem.Name = "nuevaCaracterísticaToolStripMenuItem";
            this.nuevaCaracterísticaToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.nuevaCaracterísticaToolStripMenuItem.Text = "Nueva característica";
            this.nuevaCaracterísticaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // eliminarCaracterísticasToolStripMenuItem
            // 
            this.eliminarCaracterísticasToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarCaracterísticasToolStripMenuItem.Name = "eliminarCaracterísticasToolStripMenuItem";
            this.eliminarCaracterísticasToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.eliminarCaracterísticasToolStripMenuItem.Text = "Eliminar características";
            this.eliminarCaracterísticasToolStripMenuItem.Click += new System.EventHandler(this.eliminarCaracterísticasToolStripMenuItem_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(795, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "MODULOS ESTANDAR";
            // 
            // FrmModulosEstandarCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 624);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TvModulos);
            this.Controls.Add(this.audiselTituloForm1);
            this.Name = "FrmModulosEstandarCotizacion";
            this.Text = "FrmModulosEstandarCotizacion";
            this.Load += new System.EventHandler(this.FrmModulosEstandarCotizacion_Load);
            this.MenuCaracteristicas.ResumeLayout(false);
            this.MenuCaracteristicasEliminar.ResumeLayout(false);
            this.MenuPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.TreeView TvModulos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip MenuCaracteristicas;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuCaracteristicasEliminar;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem agregarMóduloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaCaracterísticaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarCaracterísticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitarDeMóduloToolStripMenuItem;
    }
}
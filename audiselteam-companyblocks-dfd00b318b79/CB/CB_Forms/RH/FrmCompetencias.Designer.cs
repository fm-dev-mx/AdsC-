namespace CB
{
    partial class FrmCompetencias
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
            this.TvCompetencias = new System.Windows.Forms.TreeView();
            this.MenuAgregar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.audiselBotonSalida1 = new CB_Base.CB_Controles.AudiselBotonSalida();
            this.LblTitulo = new CB_Base.CB_Controles.AudiselTituloForm();
            this.MenuAgregar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TvCompetencias
            // 
            this.TvCompetencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvCompetencias.Location = new System.Drawing.Point(0, 96);
            this.TvCompetencias.Name = "TvCompetencias";
            this.TvCompetencias.Size = new System.Drawing.Size(605, 292);
            this.TvCompetencias.TabIndex = 0;
            this.TvCompetencias.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TvCompetencias_AfterCollapse);
            this.TvCompetencias.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvCompetencias_BeforeExpand);
            this.TvCompetencias.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvCompetencias_NodeMouseClick);
            this.TvCompetencias.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvCompetencias_NodeMouseDoubleClick);
            // 
            // MenuAgregar
            // 
            this.MenuAgregar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuAgregar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(147, 82);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.audiselBotonSalida1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 73);
            this.panel1.TabIndex = 2;
            // 
            // audiselBotonSalida1
            // 
            this.audiselBotonSalida1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.audiselBotonSalida1.Location = new System.Drawing.Point(439, 3);
            this.audiselBotonSalida1.Name = "audiselBotonSalida1";
            this.audiselBotonSalida1.Size = new System.Drawing.Size(163, 66);
            this.audiselBotonSalida1.TabIndex = 1;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AlturaFija = 23;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(605, 23);
            this.LblTitulo.TabIndex = 2;
            this.LblTitulo.Text = "ADMINISTRADOR DE COMPETENCIAS";
            // 
            // FrmCompetencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 388);
            this.Controls.Add(this.TvCompetencias);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCompetencias";
            this.Text = "Administrador de competencias";
            this.Load += new System.EventHandler(this.FrmCompetencias_Load);
            this.MenuAgregar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TvCompetencias;
        private System.Windows.Forms.ContextMenuStrip MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private CB_Base.CB_Controles.AudiselBotonSalida audiselBotonSalida1;
        private System.Windows.Forms.Panel panel1;
        private CB_Base.CB_Controles.AudiselTituloForm LblTitulo;
    }
}
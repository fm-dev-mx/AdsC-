namespace CB
{
    partial class FrmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Mi perfil de puesto", 5, 5);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Mi equipo de cómputo", 0, 0);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Mi equipo", 1, 1);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Mis evaluaciones", 2, 2);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Mis encuestas", 9, 9);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Mis acciones 5S\'s", 10, 10);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Mi monitor", 11, 11);
            this.label4 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.LblPuestoEmpleado = new System.Windows.Forms.Label();
            this.LblNombreEmpleado = new System.Windows.Forms.Label();
            this.ImagenesPuesto = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PicEmpleado = new System.Windows.Forms.PictureBox();
            this.TvMenuEmpleado = new System.Windows.Forms.TreeView();
            this.PanelInformacion = new System.Windows.Forms.Panel();
            this.MenuIntegranteEquipo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.evaluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evaluacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiempoExtraPlanificadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelWindows = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicEmpleado)).BeginInit();
            this.PanelInformacion.SuspendLayout();
            this.MenuIntegranteEquipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1353, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "MI INFORMACION";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(249, 23);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 667);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // LblPuestoEmpleado
            // 
            this.LblPuestoEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblPuestoEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPuestoEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuestoEmpleado.ForeColor = System.Drawing.Color.White;
            this.LblPuestoEmpleado.Location = new System.Drawing.Point(0, 23);
            this.LblPuestoEmpleado.Name = "LblPuestoEmpleado";
            this.LblPuestoEmpleado.Size = new System.Drawing.Size(249, 23);
            this.LblPuestoEmpleado.TabIndex = 85;
            this.LblPuestoEmpleado.Text = "PUESTO DEL EMPLEADO";
            this.LblPuestoEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblNombreEmpleado
            // 
            this.LblNombreEmpleado.BackColor = System.Drawing.Color.Navy;
            this.LblNombreEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNombreEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreEmpleado.ForeColor = System.Drawing.Color.White;
            this.LblNombreEmpleado.Location = new System.Drawing.Point(0, 0);
            this.LblNombreEmpleado.Name = "LblNombreEmpleado";
            this.LblNombreEmpleado.Size = new System.Drawing.Size(249, 23);
            this.LblNombreEmpleado.TabIndex = 84;
            this.LblNombreEmpleado.Text = "NOMBRE DEL EMPLEADO";
            this.LblNombreEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImagenesPuesto
            // 
            this.ImagenesPuesto.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesPuesto.ImageStream")));
            this.ImagenesPuesto.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesPuesto.Images.SetKeyName(0, "laptop-icon.png");
            this.ImagenesPuesto.Images.SetKeyName(1, "team-work-icon-48.png");
            this.ImagenesPuesto.Images.SetKeyName(2, "evaluation-48.png");
            this.ImagenesPuesto.Images.SetKeyName(3, "warning-48.png");
            this.ImagenesPuesto.Images.SetKeyName(4, "delete-48.png");
            this.ImagenesPuesto.Images.SetKeyName(5, "profile-icon-48.png");
            this.ImagenesPuesto.Images.SetKeyName(6, "details.ico");
            this.ImagenesPuesto.Images.SetKeyName(7, "lider24.png");
            this.ImagenesPuesto.Images.SetKeyName(8, "collaboration24.png");
            this.ImagenesPuesto.Images.SetKeyName(9, "complete-48.png");
            this.ImagenesPuesto.Images.SetKeyName(10, "checklist-48.png");
            this.ImagenesPuesto.Images.SetKeyName(11, "order.ico");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PicEmpleado);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TvMenuEmpleado);
            this.splitContainer1.Panel2.Controls.Add(this.LblPuestoEmpleado);
            this.splitContainer1.Panel2.Controls.Add(this.LblNombreEmpleado);
            this.splitContainer1.Size = new System.Drawing.Size(249, 667);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 0;
            // 
            // PicEmpleado
            // 
            this.PicEmpleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicEmpleado.Image = global::CB_Base.Properties.Resources.person_icon_256;
            this.PicEmpleado.Location = new System.Drawing.Point(0, 0);
            this.PicEmpleado.Name = "PicEmpleado";
            this.PicEmpleado.Size = new System.Drawing.Size(249, 244);
            this.PicEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicEmpleado.TabIndex = 1;
            this.PicEmpleado.TabStop = false;
            // 
            // TvMenuEmpleado
            // 
            this.TvMenuEmpleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvMenuEmpleado.ImageIndex = 0;
            this.TvMenuEmpleado.ImageList = this.ImagenesPuesto;
            this.TvMenuEmpleado.Location = new System.Drawing.Point(0, 46);
            this.TvMenuEmpleado.Name = "TvMenuEmpleado";
            treeNode1.ImageIndex = 5;
            treeNode1.Name = "Node9";
            treeNode1.SelectedImageIndex = 5;
            treeNode1.Text = "Mi perfil de puesto";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "Node0";
            treeNode2.SelectedImageIndex = 0;
            treeNode2.Text = "Mi equipo de cómputo";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "Node5";
            treeNode3.SelectedImageIndex = 1;
            treeNode3.Text = "Mi equipo";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "Node6";
            treeNode4.SelectedImageIndex = 2;
            treeNode4.Text = "Mis evaluaciones";
            treeNode5.ImageIndex = 9;
            treeNode5.Name = "encuestas";
            treeNode5.SelectedImageIndex = 9;
            treeNode5.Text = "Mis encuestas";
            treeNode6.ImageIndex = 10;
            treeNode6.Name = "acciones";
            treeNode6.SelectedImageIndex = 10;
            treeNode6.Text = "Mis acciones 5S\'s";
            treeNode7.ImageIndex = 11;
            treeNode7.Name = "Mi monitor";
            treeNode7.SelectedImageIndex = 11;
            treeNode7.Text = "Mi monitor";
            this.TvMenuEmpleado.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.TvMenuEmpleado.SelectedImageIndex = 0;
            this.TvMenuEmpleado.Size = new System.Drawing.Size(249, 373);
            this.TvMenuEmpleado.TabIndex = 0;
            this.TvMenuEmpleado.DoubleClick += new System.EventHandler(this.TvMenuEmpleado_DoubleClick);
            this.TvMenuEmpleado.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TvMenuEmpleado_MouseUp);
            // 
            // PanelInformacion
            // 
            this.PanelInformacion.Controls.Add(this.splitContainer1);
            this.PanelInformacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelInformacion.Location = new System.Drawing.Point(0, 23);
            this.PanelInformacion.Name = "PanelInformacion";
            this.PanelInformacion.Size = new System.Drawing.Size(249, 667);
            this.PanelInformacion.TabIndex = 20;
            this.PanelInformacion.Visible = false;
            // 
            // MenuIntegranteEquipo
            // 
            this.MenuIntegranteEquipo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluarToolStripMenuItem,
            this.evaluacionesToolStripMenuItem,
            this.tiempoExtraPlanificadoToolStripMenuItem});
            this.MenuIntegranteEquipo.Name = "MenuEvaluacion";
            this.MenuIntegranteEquipo.Size = new System.Drawing.Size(144, 70);
            // 
            // evaluarToolStripMenuItem
            // 
            this.evaluarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Nota;
            this.evaluarToolStripMenuItem.Name = "evaluarToolStripMenuItem";
            this.evaluarToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.evaluarToolStripMenuItem.Text = "Evaluar";
            this.evaluarToolStripMenuItem.Click += new System.EventHandler(this.evaluarToolStripMenuItem_Click);
            // 
            // evaluacionesToolStripMenuItem
            // 
            this.evaluacionesToolStripMenuItem.Image = global::CB_Base.Properties.Resources.details;
            this.evaluacionesToolStripMenuItem.Name = "evaluacionesToolStripMenuItem";
            this.evaluacionesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.evaluacionesToolStripMenuItem.Text = "Evaluaciones";
            this.evaluacionesToolStripMenuItem.Click += new System.EventHandler(this.evaluacionesToolStripMenuItem_Click);
            // 
            // tiempoExtraPlanificadoToolStripMenuItem
            // 
            this.tiempoExtraPlanificadoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.calendar_48;
            this.tiempoExtraPlanificadoToolStripMenuItem.Name = "tiempoExtraPlanificadoToolStripMenuItem";
            this.tiempoExtraPlanificadoToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.tiempoExtraPlanificadoToolStripMenuItem.Text = "Tiempo extra";
            this.tiempoExtraPlanificadoToolStripMenuItem.Click += new System.EventHandler(this.tiempoExtraPlanificadoToolStripMenuItem_Click);
            // 
            // panelWindows
            // 
            this.panelWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWindows.Location = new System.Drawing.Point(252, 23);
            this.panelWindows.Name = "panelWindows";
            this.panelWindows.Size = new System.Drawing.Size(1101, 667);
            this.panelWindows.TabIndex = 22;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 690);
            this.Controls.Add(this.panelWindows);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.PanelInformacion);
            this.Controls.Add(this.label4);
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.Shown += new System.EventHandler(this.FrmInicio_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicEmpleado)).EndInit();
            this.PanelInformacion.ResumeLayout(false);
            this.MenuIntegranteEquipo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox PicEmpleado;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label LblPuestoEmpleado;
        private System.Windows.Forms.Label LblNombreEmpleado;
        private System.Windows.Forms.ImageList ImagenesPuesto;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TvMenuEmpleado;
        private System.Windows.Forms.Panel PanelInformacion;
        private System.Windows.Forms.ContextMenuStrip MenuIntegranteEquipo;
        private System.Windows.Forms.ToolStripMenuItem evaluarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evaluacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiempoExtraPlanificadoToolStripMenuItem;
        private System.Windows.Forms.Panel panelWindows;
    }
}
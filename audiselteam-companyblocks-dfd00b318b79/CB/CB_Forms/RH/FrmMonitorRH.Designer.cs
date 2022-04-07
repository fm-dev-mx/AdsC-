namespace CB
{
    partial class FrmMonitorRH
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Información", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Perfil de puesto", 5, 5);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Equipo de cómputo asignado", 0, 0);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Evaluaciones de desempeño", 2, 2);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Amonestaciones escritas", 3, 3);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Actas administrativas", 4, 4);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitorRH));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCapacitacion = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BtnProduccion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbPuestos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbEmpleados = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelInformacion = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PicEmpleado = new System.Windows.Forms.PictureBox();
            this.TvMenuEmpleado = new System.Windows.Forms.TreeView();
            this.ImagenesPuesto = new System.Windows.Forms.ImageList(this.components);
            this.LblPuestoEmpleado = new System.Windows.Forms.Label();
            this.LblNombreEmpleado = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.PanelInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCapacitacion);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.BtnProduccion);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CmbPuestos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbEmpleados);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 90);
            this.panel1.TabIndex = 1;
            // 
            // BtnCapacitacion
            // 
            this.BtnCapacitacion.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCapacitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCapacitacion.Image = global::CB_Base.Properties.Resources.courses_48;
            this.BtnCapacitacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCapacitacion.Location = new System.Drawing.Point(678, 23);
            this.BtnCapacitacion.Name = "BtnCapacitacion";
            this.BtnCapacitacion.Size = new System.Drawing.Size(159, 67);
            this.BtnCapacitacion.TabIndex = 106;
            this.BtnCapacitacion.Text = "            Capacitación";
            this.BtnCapacitacion.UseVisualStyleBackColor = true;
            this.BtnCapacitacion.Click += new System.EventHandler(this.BtnCapacitacion_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CB_Base.Properties.Resources.polls_48;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(837, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 67);
            this.button2.TabIndex = 105;
            this.button2.Text = "          Encuestas   ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::CB_Base.Properties.Resources.search_icon_48;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(978, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 67);
            this.button3.TabIndex = 103;
            this.button3.Text = "           Vacantes   ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BtnProduccion
            // 
            this.BtnProduccion.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProduccion.Image = global::CB_Base.Properties.Resources.team_work_icon_48;
            this.BtnProduccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProduccion.Location = new System.Drawing.Point(1117, 23);
            this.BtnProduccion.Name = "BtnProduccion";
            this.BtnProduccion.Size = new System.Drawing.Size(129, 67);
            this.BtnProduccion.TabIndex = 98;
            this.BtnProduccion.Text = "Equipos ";
            this.BtnProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProduccion.UseVisualStyleBackColor = true;
            this.BtnProduccion.Click += new System.EventHandler(this.BtnProduccion_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CB_Base.Properties.Resources.Add_icon1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1246, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 67);
            this.button1.TabIndex = 101;
            this.button1.Text = "           Alta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "Puesto:";
            // 
            // CmbPuestos
            // 
            this.CmbPuestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPuestos.FormattingEnabled = true;
            this.CmbPuestos.Items.AddRange(new object[] {
            "SIN ENVIAR",
            "ENVIADO"});
            this.CmbPuestos.Location = new System.Drawing.Point(15, 47);
            this.CmbPuestos.Name = "CmbPuestos";
            this.CmbPuestos.Size = new System.Drawing.Size(282, 32);
            this.CmbPuestos.TabIndex = 99;
            this.CmbPuestos.SelectedIndexChanged += new System.EventHandler(this.CmbPuestos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Empleado:";
            // 
            // CmbEmpleados
            // 
            this.CmbEmpleados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEmpleados.FormattingEnabled = true;
            this.CmbEmpleados.Items.AddRange(new object[] {
            "SIN ENVIAR",
            "ENVIADO"});
            this.CmbEmpleados.Location = new System.Drawing.Point(312, 47);
            this.CmbEmpleados.Name = "CmbEmpleados";
            this.CmbEmpleados.Size = new System.Drawing.Size(311, 32);
            this.CmbEmpleados.TabIndex = 14;
            this.CmbEmpleados.SelectedIndexChanged += new System.EventHandler(this.CmbEmpleados_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1370, 23);
            this.label4.TabIndex = 104;
            this.label4.Text = "MONITOR DE RECURSOS HUMANOS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelInformacion
            // 
            this.PanelInformacion.Controls.Add(this.splitContainer1);
            this.PanelInformacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelInformacion.Location = new System.Drawing.Point(0, 90);
            this.PanelInformacion.Name = "PanelInformacion";
            this.PanelInformacion.Size = new System.Drawing.Size(249, 493);
            this.PanelInformacion.TabIndex = 3;
            this.PanelInformacion.Visible = false;
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
            this.splitContainer1.Size = new System.Drawing.Size(249, 493);
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
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Node5";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "Información";
            treeNode2.ImageIndex = 5;
            treeNode2.Name = "Node9";
            treeNode2.SelectedImageIndex = 5;
            treeNode2.Text = "Perfil de puesto";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "Node0";
            treeNode3.SelectedImageIndex = 0;
            treeNode3.Text = "Equipo de cómputo asignado";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "Node6";
            treeNode4.SelectedImageIndex = 2;
            treeNode4.Text = "Evaluaciones de desempeño";
            treeNode5.ImageIndex = 3;
            treeNode5.Name = "Node7";
            treeNode5.SelectedImageIndex = 3;
            treeNode5.Text = "Amonestaciones escritas";
            treeNode6.ImageIndex = 4;
            treeNode6.Name = "Node8";
            treeNode6.SelectedImageIndex = 4;
            treeNode6.Text = "Actas administrativas";
            this.TvMenuEmpleado.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.TvMenuEmpleado.SelectedImageIndex = 0;
            this.TvMenuEmpleado.Size = new System.Drawing.Size(249, 199);
            this.TvMenuEmpleado.TabIndex = 0;
            this.TvMenuEmpleado.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvMenuEmpleado_AfterSelect);
            this.TvMenuEmpleado.DoubleClick += new System.EventHandler(this.TvMenuEmpleado_DoubleClick);
            // 
            // ImagenesPuesto
            // 
            this.ImagenesPuesto.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenesPuesto.ImageStream")));
            this.ImagenesPuesto.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenesPuesto.Images.SetKeyName(0, "laptop-icon.png");
            this.ImagenesPuesto.Images.SetKeyName(1, "details.ico");
            this.ImagenesPuesto.Images.SetKeyName(2, "evaluation-48.png");
            this.ImagenesPuesto.Images.SetKeyName(3, "warning-48.png");
            this.ImagenesPuesto.Images.SetKeyName(4, "delete-48.png");
            this.ImagenesPuesto.Images.SetKeyName(5, "profile-icon-48.png");
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
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(249, 90);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 493);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // FrmMonitorRH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 583);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.PanelInformacion);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "FrmMonitorRH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de Recursos Humanos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMonitorRH_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelInformacion.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicEmpleado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbEmpleados;
        private System.Windows.Forms.Button BtnProduccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbPuestos;
        private System.Windows.Forms.Panel PanelInformacion;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox PicEmpleado;
        private System.Windows.Forms.TreeView TvMenuEmpleado;
        private System.Windows.Forms.Label LblNombreEmpleado;
        private System.Windows.Forms.ImageList ImagenesPuesto;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label LblPuestoEmpleado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnCapacitacion;
    }
}
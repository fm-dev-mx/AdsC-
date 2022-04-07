namespace CB
{
    partial class FrmManualDeCalidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManualDeCalidad));
            this.ImagenNodo = new System.Windows.Forms.ImageList(this.components);
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuPoliticaCalidad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtPolitica = new System.Windows.Forms.TextBox();
            this.LblPolitica = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TvDepartamentos = new System.Windows.Forms.TreeView();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblArchivo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.registrarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarEnEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPoíticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarPolíticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarPolíticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.MenuPoliticaCalidad.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagenNodo
            // 
            this.ImagenNodo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagenNodo.ImageStream")));
            this.ImagenNodo.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagenNodo.Images.SetKeyName(0, "folder_24px.png");
            this.ImagenNodo.Images.SetKeyName(1, "pdf-icon24px.png");
            this.ImagenNodo.Images.SetKeyName(2, "Word-icon 24px.png");
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarArchivoToolStripMenuItem,
            this.actualizarToolStripMenuItem,
            this.guardarEnEquipoToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.Menu.Name = "contextMenuStrip1";
            this.Menu.Size = new System.Drawing.Size(173, 92);
            // 
            // MenuPoliticaCalidad
            // 
            this.MenuPoliticaCalidad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPoíticaToolStripMenuItem,
            this.editarPolíticaToolStripMenuItem,
            this.eliminarPolíticaToolStripMenuItem});
            this.MenuPoliticaCalidad.Name = "MenuPoliticaCalidad";
            this.MenuPoliticaCalidad.Size = new System.Drawing.Size(160, 70);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtPolitica);
            this.panel1.Controls.Add(this.LblPolitica);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 138);
            this.panel1.TabIndex = 0;
            // 
            // TxtPolitica
            // 
            this.TxtPolitica.BackColor = System.Drawing.Color.Black;
            this.TxtPolitica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPolitica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPolitica.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TxtPolitica.Location = new System.Drawing.Point(323, 47);
            this.TxtPolitica.Multiline = true;
            this.TxtPolitica.Name = "TxtPolitica";
            this.TxtPolitica.Size = new System.Drawing.Size(541, 91);
            this.TxtPolitica.TabIndex = 16;
            this.TxtPolitica.Text = "POLITICA";
            this.TxtPolitica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtPolitica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxtPolitica_MouseDown);
            // 
            // LblPolitica
            // 
            this.LblPolitica.BackColor = System.Drawing.Color.Black;
            this.LblPolitica.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPolitica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPolitica.ForeColor = System.Drawing.Color.White;
            this.LblPolitica.Location = new System.Drawing.Point(323, 24);
            this.LblPolitica.Name = "LblPolitica";
            this.LblPolitica.Size = new System.Drawing.Size(541, 23);
            this.LblPolitica.TabIndex = 15;
            this.LblPolitica.Text = "Política de calidad | Rev. 0 | Fecha";
            this.LblPolitica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(323, 114);
            this.panel5.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 38);
            this.label2.TabIndex = 14;
            this.label2.Text = "AUTOMATIZACION Y DISEÑO ELECTRONICO DE CONTROL S.A. DE C.V.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(864, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 114);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.BtnActualizar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(245, 64);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1109, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "RESUMEN DEL SGC ACORDE A LA NORMA ISO 9001:2015";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 138);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TvDepartamentos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(1109, 435);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.TabIndex = 1;
            // 
            // TvDepartamentos
            // 
            this.TvDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvDepartamentos.ImageIndex = 0;
            this.TvDepartamentos.ImageList = this.ImagenNodo;
            this.TvDepartamentos.Location = new System.Drawing.Point(0, 0);
            this.TvDepartamentos.Name = "TvDepartamentos";
            this.TvDepartamentos.SelectedImageIndex = 0;
            this.TvDepartamentos.Size = new System.Drawing.Size(306, 435);
            this.TvDepartamentos.TabIndex = 0;
            this.TvDepartamentos.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvDepartamentos_BeforeCollapse);
            this.TvDepartamentos.DoubleClick += new System.EventHandler(this.TvDepartamentos_DoubleClick);
            this.TvDepartamentos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TvDepartamentos_MouseUp);
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(799, 405);
            this.VisorPDF.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.LblArchivo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 405);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(799, 30);
            this.panel4.TabIndex = 0;
            // 
            // LblArchivo
            // 
            this.LblArchivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArchivo.Location = new System.Drawing.Point(0, 0);
            this.LblArchivo.Name = "LblArchivo";
            this.LblArchivo.Size = new System.Drawing.Size(799, 30);
            this.LblArchivo.TabIndex = 0;
            this.LblArchivo.Text = "Archivo";
            this.LblArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::CB_Base.Properties.Resources.Logo_mirror;
            this.pictureBox1.Location = new System.Drawing.Point(11, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CB_Base.Properties.Resources.order;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(9, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 64);
            this.button1.TabIndex = 12;
            this.button1.Text = "     Listado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(127, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(118, 64);
            this.BtnActualizar.TabIndex = 11;
            this.BtnActualizar.Text = "     Salir";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // registrarArchivoToolStripMenuItem
            // 
            this.registrarArchivoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.registrarArchivoToolStripMenuItem.Name = "registrarArchivoToolStripMenuItem";
            this.registrarArchivoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.registrarArchivoToolStripMenuItem.Text = "Registrar archivo";
            this.registrarArchivoToolStripMenuItem.Click += new System.EventHandler(this.registrarArchivoToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.update;
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // guardarEnEquipoToolStripMenuItem
            // 
            this.guardarEnEquipoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.download_file_48;
            this.guardarEnEquipoToolStripMenuItem.Name = "guardarEnEquipoToolStripMenuItem";
            this.guardarEnEquipoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.guardarEnEquipoToolStripMenuItem.Text = "Guardar en equipo";
            this.guardarEnEquipoToolStripMenuItem.Click += new System.EventHandler(this.guardarEnEquipoToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // nuevaPoíticaToolStripMenuItem
            // 
            this.nuevaPoíticaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.nuevaPoíticaToolStripMenuItem.Name = "nuevaPoíticaToolStripMenuItem";
            this.nuevaPoíticaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nuevaPoíticaToolStripMenuItem.Text = "Nueva poítica";
            this.nuevaPoíticaToolStripMenuItem.Click += new System.EventHandler(this.nuevaPoíticaToolStripMenuItem_Click);
            // 
            // editarPolíticaToolStripMenuItem
            // 
            this.editarPolíticaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.editarPolíticaToolStripMenuItem.Name = "editarPolíticaToolStripMenuItem";
            this.editarPolíticaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.editarPolíticaToolStripMenuItem.Text = "Editar política";
            this.editarPolíticaToolStripMenuItem.Click += new System.EventHandler(this.editarPolíticaToolStripMenuItem_Click);
            // 
            // eliminarPolíticaToolStripMenuItem
            // 
            this.eliminarPolíticaToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarPolíticaToolStripMenuItem.Name = "eliminarPolíticaToolStripMenuItem";
            this.eliminarPolíticaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eliminarPolíticaToolStripMenuItem.Text = "Eliminar política";
            this.eliminarPolíticaToolStripMenuItem.Click += new System.EventHandler(this.eliminarPolíticaToolStripMenuItem_Click);
            // 
            // FrmManualDeCalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 573);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManualDeCalidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual de calidad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmManualDeCalidad_Load);
            this.Menu.ResumeLayout(false);
            this.MenuPoliticaCalidad.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TvDepartamentos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.TextBox TxtPolitica;
        private System.Windows.Forms.Label LblPolitica;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem registrarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarEnEquipoToolStripMenuItem;
        private System.Windows.Forms.ImageList ImagenNodo;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuPoliticaCalidad;
        private System.Windows.Forms.ToolStripMenuItem nuevaPoíticaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarPolíticaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarPolíticaToolStripMenuItem;
        private System.Windows.Forms.Label LblArchivo;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}
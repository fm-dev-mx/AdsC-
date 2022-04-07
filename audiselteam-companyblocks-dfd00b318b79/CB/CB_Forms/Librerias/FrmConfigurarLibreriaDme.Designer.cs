namespace CB
{
    partial class FrmConfigurarLibreriaDme
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
            this.ContenedorPrincipal = new System.Windows.Forms.SplitContainer();
            this.CmbTipoAccesorio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.DgvTipoAccesorio = new System.Windows.Forms.DataGridView();
            this.idAccesorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccionAccesorio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nombreAccesorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicVistaPrevia = new System.Windows.Forms.PictureBox();
            this.MenuImagen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.isometricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inferiorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superiorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posteriorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izquierdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.derechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbConfiguracion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTerminal = new System.Windows.Forms.TextBox();
            this.BkgCargarSolidWorks = new System.ComponentModel.BackgroundWorker();
            this.BkgCargarModelo = new System.ComponentModel.BackgroundWorker();
            this.BkgMostrarConfiguracion = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ContenedorPrincipal)).BeginInit();
            this.ContenedorPrincipal.Panel1.SuspendLayout();
            this.ContenedorPrincipal.Panel2.SuspendLayout();
            this.ContenedorPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTipoAccesorio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVistaPrevia)).BeginInit();
            this.MenuImagen.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContenedorPrincipal
            // 
            this.ContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorPrincipal.Location = new System.Drawing.Point(0, 0);
            this.ContenedorPrincipal.Name = "ContenedorPrincipal";
            this.ContenedorPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ContenedorPrincipal.Panel1
            // 
            this.ContenedorPrincipal.Panel1.Controls.Add(this.CmbTipoAccesorio);
            this.ContenedorPrincipal.Panel1.Controls.Add(this.label2);
            this.ContenedorPrincipal.Panel1.Controls.Add(this.button1);
            this.ContenedorPrincipal.Panel1.Controls.Add(this.DgvTipoAccesorio);
            this.ContenedorPrincipal.Panel1.Controls.Add(this.PicVistaPrevia);
            this.ContenedorPrincipal.Panel1.Controls.Add(this.panel1);
            // 
            // ContenedorPrincipal.Panel2
            // 
            this.ContenedorPrincipal.Panel2.Controls.Add(this.TxtTerminal);
            this.ContenedorPrincipal.Size = new System.Drawing.Size(784, 572);
            this.ContenedorPrincipal.SplitterDistance = 480;
            this.ContenedorPrincipal.TabIndex = 0;
            // 
            // CmbTipoAccesorio
            // 
            this.CmbTipoAccesorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoAccesorio.Enabled = false;
            this.CmbTipoAccesorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoAccesorio.FormattingEnabled = true;
            this.CmbTipoAccesorio.Location = new System.Drawing.Point(387, 92);
            this.CmbTipoAccesorio.Name = "CmbTipoAccesorio";
            this.CmbTipoAccesorio.Size = new System.Drawing.Size(385, 28);
            this.CmbTipoAccesorio.TabIndex = 2;
            this.CmbTipoAccesorio.SelectedIndexChanged += new System.EventHandler(this.CmbTipoAccesorio_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de accesorio:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Integrar en mi diseño";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DgvTipoAccesorio
            // 
            this.DgvTipoAccesorio.AllowUserToAddRows = false;
            this.DgvTipoAccesorio.AllowUserToResizeRows = false;
            this.DgvTipoAccesorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTipoAccesorio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAccesorio,
            this.seleccionAccesorio,
            this.nombreAccesorio});
            this.DgvTipoAccesorio.Location = new System.Drawing.Point(387, 126);
            this.DgvTipoAccesorio.Name = "DgvTipoAccesorio";
            this.DgvTipoAccesorio.RowHeadersVisible = false;
            this.DgvTipoAccesorio.Size = new System.Drawing.Size(385, 308);
            this.DgvTipoAccesorio.TabIndex = 4;
            this.DgvTipoAccesorio.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTipoAccesorio_CellMouseUp);
            this.DgvTipoAccesorio.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTipoAccesorio_CellValueChanged);
            // 
            // idAccesorio
            // 
            this.idAccesorio.HeaderText = "ID";
            this.idAccesorio.Name = "idAccesorio";
            this.idAccesorio.ReadOnly = true;
            this.idAccesorio.Visible = false;
            // 
            // seleccionAccesorio
            // 
            this.seleccionAccesorio.HeaderText = "";
            this.seleccionAccesorio.Name = "seleccionAccesorio";
            this.seleccionAccesorio.Width = 20;
            // 
            // nombreAccesorio
            // 
            this.nombreAccesorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreAccesorio.DefaultCellStyle = dataGridViewCellStyle1;
            this.nombreAccesorio.HeaderText = "Nombre del accesorio";
            this.nombreAccesorio.Name = "nombreAccesorio";
            this.nombreAccesorio.ReadOnly = true;
            // 
            // PicVistaPrevia
            // 
            this.PicVistaPrevia.ContextMenuStrip = this.MenuImagen;
            this.PicVistaPrevia.Location = new System.Drawing.Point(12, 76);
            this.PicVistaPrevia.Name = "PicVistaPrevia";
            this.PicVistaPrevia.Size = new System.Drawing.Size(358, 358);
            this.PicVistaPrevia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicVistaPrevia.TabIndex = 2;
            this.PicVistaPrevia.TabStop = false;
            // 
            // MenuImagen
            // 
            this.MenuImagen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.isometricoToolStripMenuItem,
            this.frontalToolStripMenuItem,
            this.inferiorToolStripMenuItem,
            this.superiorToolStripMenuItem,
            this.posteriorToolStripMenuItem,
            this.izquierdaToolStripMenuItem,
            this.derechaToolStripMenuItem});
            this.MenuImagen.Name = "MenuImagen";
            this.MenuImagen.Size = new System.Drawing.Size(131, 158);
            // 
            // isometricoToolStripMenuItem
            // 
            this.isometricoToolStripMenuItem.Name = "isometricoToolStripMenuItem";
            this.isometricoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.isometricoToolStripMenuItem.Text = "Isometrico";
            this.isometricoToolStripMenuItem.Click += new System.EventHandler(this.isometricoToolStripMenuItem_Click);
            // 
            // frontalToolStripMenuItem
            // 
            this.frontalToolStripMenuItem.Name = "frontalToolStripMenuItem";
            this.frontalToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.frontalToolStripMenuItem.Text = "Frontal";
            this.frontalToolStripMenuItem.Click += new System.EventHandler(this.frontalToolStripMenuItem_Click);
            // 
            // inferiorToolStripMenuItem
            // 
            this.inferiorToolStripMenuItem.Name = "inferiorToolStripMenuItem";
            this.inferiorToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.inferiorToolStripMenuItem.Text = "Inferior";
            this.inferiorToolStripMenuItem.Click += new System.EventHandler(this.inferiorToolStripMenuItem_Click);
            // 
            // superiorToolStripMenuItem
            // 
            this.superiorToolStripMenuItem.Name = "superiorToolStripMenuItem";
            this.superiorToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.superiorToolStripMenuItem.Text = "Superior";
            this.superiorToolStripMenuItem.Click += new System.EventHandler(this.superiorToolStripMenuItem_Click);
            // 
            // posteriorToolStripMenuItem
            // 
            this.posteriorToolStripMenuItem.Name = "posteriorToolStripMenuItem";
            this.posteriorToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.posteriorToolStripMenuItem.Text = "Posterior";
            this.posteriorToolStripMenuItem.Click += new System.EventHandler(this.posteriorToolStripMenuItem_Click);
            // 
            // izquierdaToolStripMenuItem
            // 
            this.izquierdaToolStripMenuItem.Name = "izquierdaToolStripMenuItem";
            this.izquierdaToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.izquierdaToolStripMenuItem.Text = "Izquierda";
            this.izquierdaToolStripMenuItem.Click += new System.EventHandler(this.izquierdaToolStripMenuItem_Click);
            // 
            // derechaToolStripMenuItem
            // 
            this.derechaToolStripMenuItem.Name = "derechaToolStripMenuItem";
            this.derechaToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.derechaToolStripMenuItem.Text = "Derecha";
            this.derechaToolStripMenuItem.Click += new System.EventHandler(this.derechaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbConfiguracion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 70);
            this.panel1.TabIndex = 3;
            // 
            // CmbConfiguracion
            // 
            this.CmbConfiguracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbConfiguracion.Enabled = false;
            this.CmbConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbConfiguracion.FormattingEnabled = true;
            this.CmbConfiguracion.Location = new System.Drawing.Point(12, 29);
            this.CmbConfiguracion.Name = "CmbConfiguracion";
            this.CmbConfiguracion.Size = new System.Drawing.Size(358, 28);
            this.CmbConfiguracion.TabIndex = 1;
            this.CmbConfiguracion.SelectedIndexChanged += new System.EventHandler(this.CmbConfiguracion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuración:";
            // 
            // TxtTerminal
            // 
            this.TxtTerminal.BackColor = System.Drawing.Color.Black;
            this.TxtTerminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtTerminal.ForeColor = System.Drawing.Color.Cyan;
            this.TxtTerminal.Location = new System.Drawing.Point(0, 0);
            this.TxtTerminal.Multiline = true;
            this.TxtTerminal.Name = "TxtTerminal";
            this.TxtTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtTerminal.Size = new System.Drawing.Size(784, 88);
            this.TxtTerminal.TabIndex = 1;
            // 
            // BkgCargarSolidWorks
            // 
            this.BkgCargarSolidWorks.WorkerReportsProgress = true;
            this.BkgCargarSolidWorks.WorkerSupportsCancellation = true;
            this.BkgCargarSolidWorks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgCargarSolidWorks_DoWork);
            this.BkgCargarSolidWorks.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgCargarSolidWorks_ProgressChanged);
            this.BkgCargarSolidWorks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgCargarSolidWorks_RunWorkerCompleted);
            // 
            // BkgCargarModelo
            // 
            this.BkgCargarModelo.WorkerReportsProgress = true;
            this.BkgCargarModelo.WorkerSupportsCancellation = true;
            this.BkgCargarModelo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgCargarModelo_DoWork);
            this.BkgCargarModelo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgCargarModelo_ProgressChanged);
            this.BkgCargarModelo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgCargarModelo_RunWorkerCompleted);
            // 
            // BkgMostrarConfiguracion
            // 
            this.BkgMostrarConfiguracion.WorkerReportsProgress = true;
            this.BkgMostrarConfiguracion.WorkerSupportsCancellation = true;
            this.BkgMostrarConfiguracion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgMostrarConfiguracion_DoWork);
            this.BkgMostrarConfiguracion.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgMostrarConfiguracion_ProgressChanged);
            this.BkgMostrarConfiguracion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgMostrarConfiguracion_RunWorkerCompleted);
            // 
            // FrmConfigurarLibreriaDme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 572);
            this.Controls.Add(this.ContenedorPrincipal);
            this.Name = "FrmConfigurarLibreriaDme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar librería de diseño mecánico";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLibreriasDisenoMecanico_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLibreriasDisenoMecanico_FormClosed);
            this.Load += new System.EventHandler(this.FrmLibreriasDisenoMecanico_Load);
            this.Shown += new System.EventHandler(this.FrmConfigurarLibreriaDme_Shown);
            this.ContenedorPrincipal.Panel1.ResumeLayout(false);
            this.ContenedorPrincipal.Panel1.PerformLayout();
            this.ContenedorPrincipal.Panel2.ResumeLayout(false);
            this.ContenedorPrincipal.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContenedorPrincipal)).EndInit();
            this.ContenedorPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTipoAccesorio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVistaPrevia)).EndInit();
            this.MenuImagen.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ContenedorPrincipal;
        private System.Windows.Forms.TextBox TxtTerminal;
        private System.ComponentModel.BackgroundWorker BkgCargarSolidWorks;
        private System.Windows.Forms.ComboBox CmbConfiguracion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicVistaPrevia;
        private System.ComponentModel.BackgroundWorker BkgCargarModelo;
        private System.ComponentModel.BackgroundWorker BkgMostrarConfiguracion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip MenuImagen;
        private System.Windows.Forms.ToolStripMenuItem isometricoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inferiorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superiorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posteriorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izquierdaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem derechaToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DgvTipoAccesorio;
        private System.Windows.Forms.ComboBox CmbTipoAccesorio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAccesorio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionAccesorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreAccesorio;
    }
}
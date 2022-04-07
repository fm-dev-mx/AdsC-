namespace CB
{
    partial class FrmAprobarDisenoModulo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BkgAprobar = new System.ComponentModel.BackgroundWorker();
            this.SplitEstatus = new System.Windows.Forms.SplitContainer();
            this.DgvPorAprobar = new System.Windows.Forms.DataGridView();
            this.nombre_plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus_plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LblModulo = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnAprobar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.LblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SplitEstatus)).BeginInit();
            this.SplitEstatus.Panel1.SuspendLayout();
            this.SplitEstatus.Panel2.SuspendLayout();
            this.SplitEstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPorAprobar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BkgAprobar
            // 
            this.BkgAprobar.WorkerReportsProgress = true;
            this.BkgAprobar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgAprobar_DoWork);
            this.BkgAprobar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgAprobar_ProgressChanged);
            this.BkgAprobar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgAprobar_RunWorkerCompleted);
            // 
            // SplitEstatus
            // 
            this.SplitEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitEstatus.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitEstatus.Location = new System.Drawing.Point(0, 23);
            this.SplitEstatus.Name = "SplitEstatus";
            this.SplitEstatus.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitEstatus.Panel1
            // 
            this.SplitEstatus.Panel1.Controls.Add(this.DgvPorAprobar);
            this.SplitEstatus.Panel1.Controls.Add(this.panel1);
            // 
            // SplitEstatus.Panel2
            // 
            this.SplitEstatus.Panel2.Controls.Add(this.TxtEstatus);
            this.SplitEstatus.Panel2.Controls.Add(this.Progreso);
            this.SplitEstatus.Size = new System.Drawing.Size(606, 407);
            this.SplitEstatus.SplitterDistance = 278;
            this.SplitEstatus.TabIndex = 0;
            // 
            // DgvPorAprobar
            // 
            this.DgvPorAprobar.AllowUserToAddRows = false;
            this.DgvPorAprobar.AllowUserToDeleteRows = false;
            this.DgvPorAprobar.AllowUserToResizeRows = false;
            this.DgvPorAprobar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPorAprobar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre_plano,
            this.estatus_plano});
            this.DgvPorAprobar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPorAprobar.Location = new System.Drawing.Point(0, 134);
            this.DgvPorAprobar.Name = "DgvPorAprobar";
            this.DgvPorAprobar.ReadOnly = true;
            this.DgvPorAprobar.RowHeadersVisible = false;
            this.DgvPorAprobar.Size = new System.Drawing.Size(606, 144);
            this.DgvPorAprobar.TabIndex = 4;
            // 
            // nombre_plano
            // 
            this.nombre_plano.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_plano.HeaderText = "Nombre del plano";
            this.nombre_plano.Name = "nombre_plano";
            this.nombre_plano.ReadOnly = true;
            // 
            // estatus_plano
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estatus_plano.DefaultCellStyle = dataGridViewCellStyle1;
            this.estatus_plano.HeaderText = "Estatus";
            this.estatus_plano.Name = "estatus_plano";
            this.estatus_plano.ReadOnly = true;
            this.estatus_plano.Width = 300;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LblModulo);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.BtnAprobar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 134);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Planos por congelar:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblModulo
            // 
            this.LblModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblModulo.Location = new System.Drawing.Point(3, 3);
            this.LblModulo.Name = "LblModulo";
            this.LblModulo.Size = new System.Drawing.Size(376, 40);
            this.LblModulo.TabIndex = 3;
            this.LblModulo.Text = "SUB - NOMBRE DEL MODULO";
            this.LblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(439, 62);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(164, 55);
            this.BtnCancelar.TabIndex = 24;
            this.BtnCancelar.Text = "         Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CB_Base.Properties.Resources.ice_48;
            this.pictureBox1.Location = new System.Drawing.Point(6, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BtnAprobar
            // 
            this.BtnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAprobar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAprobar.Location = new System.Drawing.Point(439, 3);
            this.BtnAprobar.Name = "BtnAprobar";
            this.BtnAprobar.Size = new System.Drawing.Size(164, 56);
            this.BtnAprobar.TabIndex = 23;
            this.BtnAprobar.Text = "         Congelar";
            this.BtnAprobar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAprobar.UseVisualStyleBackColor = true;
            this.BtnAprobar.Click += new System.EventHandler(this.BtnAprobar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seguro que quieres congelar el diseño mecánico del módulo para enviar los planos " +
    "a fabricación?\r\n\r\n";
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEstatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 0);
            this.TxtEstatus.Multiline = true;
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(606, 102);
            this.TxtEstatus.TabIndex = 10;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 102);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(606, 23);
            this.Progreso.TabIndex = 9;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(606, 23);
            this.LblTitulo.TabIndex = 12;
            this.LblTitulo.Text = "CONGELAR DISEÑO MECANICO DEL MODULO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblArchivosServidor_MouseDown);
            // 
            // FrmAprobarDisenoModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 430);
            this.Controls.Add(this.SplitEstatus);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAprobarDisenoModulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aprobar diseño del módulo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAprobarDisenoModulo_FormClosing);
            this.Load += new System.EventHandler(this.FrmAprobarDisenoModulo_Load);
            this.SplitEstatus.Panel1.ResumeLayout(false);
            this.SplitEstatus.Panel2.ResumeLayout(false);
            this.SplitEstatus.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitEstatus)).EndInit();
            this.SplitEstatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPorAprobar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitEstatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAprobar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblModulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvPorAprobar;
        private System.ComponentModel.BackgroundWorker BkgAprobar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus_plano;
    }
}
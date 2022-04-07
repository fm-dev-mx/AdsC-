namespace CB
{
    partial class FrmRegistrarLibreriaDme
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
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbSubcategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbFabricante = new System.Windows.Forms.ComboBox();
            this.TxtFamilia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCarpeta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.DgvArchivos = new System.Windows.Forms.DataGridView();
            this.archivos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.LblProgreso = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BkgRegistrarLibreria = new System.ComponentModel.BackgroundWorker();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BkgEditarLibreria = new System.ComponentModel.BackgroundWorker();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArchivos)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(12, 50);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(368, 28);
            this.CmbCategoria.TabIndex = 0;
            this.CmbCategoria.SelectedIndexChanged += new System.EventHandler(this.CmbCategoria_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categoría";
            // 
            // CmbSubcategoria
            // 
            this.CmbSubcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSubcategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSubcategoria.FormattingEnabled = true;
            this.CmbSubcategoria.Location = new System.Drawing.Point(12, 100);
            this.CmbSubcategoria.Name = "CmbSubcategoria";
            this.CmbSubcategoria.Size = new System.Drawing.Size(368, 28);
            this.CmbSubcategoria.TabIndex = 2;
            this.CmbSubcategoria.SelectedIndexChanged += new System.EventHandler(this.CmbSubcategoria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subcategoría";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fabricante";
            // 
            // CmbFabricante
            // 
            this.CmbFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFabricante.FormattingEnabled = true;
            this.CmbFabricante.Location = new System.Drawing.Point(12, 150);
            this.CmbFabricante.Name = "CmbFabricante";
            this.CmbFabricante.Size = new System.Drawing.Size(368, 28);
            this.CmbFabricante.TabIndex = 4;
            this.CmbFabricante.SelectedIndexChanged += new System.EventHandler(this.CmbFabricante_SelectedIndexChanged);
            // 
            // TxtFamilia
            // 
            this.TxtFamilia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFamilia.Location = new System.Drawing.Point(12, 200);
            this.TxtFamilia.Name = "TxtFamilia";
            this.TxtFamilia.Size = new System.Drawing.Size(368, 26);
            this.TxtFamilia.TabIndex = 6;
            this.TxtFamilia.TextChanged += new System.EventHandler(this.TxtFamilia_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Familia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Carpeta con archivos:";
            // 
            // TxtCarpeta
            // 
            this.TxtCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCarpeta.Location = new System.Drawing.Point(12, 248);
            this.TxtCarpeta.Name = "TxtCarpeta";
            this.TxtCarpeta.ReadOnly = true;
            this.TxtCarpeta.Size = new System.Drawing.Size(368, 26);
            this.TxtCarpeta.TabIndex = 9;
            this.TxtCarpeta.TextChanged += new System.EventHandler(this.TxtCarpeta_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::CB_Base.Properties.Resources.search_icon_48;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(264, 280);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(116, 46);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // DgvArchivos
            // 
            this.DgvArchivos.AllowUserToAddRows = false;
            this.DgvArchivos.AllowUserToDeleteRows = false;
            this.DgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.archivos});
            this.DgvArchivos.Location = new System.Drawing.Point(12, 332);
            this.DgvArchivos.Name = "DgvArchivos";
            this.DgvArchivos.RowHeadersVisible = false;
            this.DgvArchivos.Size = new System.Drawing.Size(368, 150);
            this.DgvArchivos.TabIndex = 11;
            // 
            // archivos
            // 
            this.archivos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.archivos.HeaderText = "Archivos";
            this.archivos.Name = "archivos";
            this.archivos.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Archivos encontrados:";
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.ok_48;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(219, 539);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(161, 50);
            this.BtnRegistrar.TabIndex = 13;
            this.BtnRegistrar.Text = "     Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(12, 539);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(159, 50);
            this.BtnCancelar.TabIndex = 14;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.button3_Click);
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(12, 510);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(368, 23);
            this.Progreso.TabIndex = 15;
            // 
            // LblProgreso
            // 
            this.LblProgreso.AutoSize = true;
            this.LblProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProgreso.Location = new System.Drawing.Point(12, 491);
            this.LblProgreso.Name = "LblProgreso";
            this.LblProgreso.Size = new System.Drawing.Size(64, 16);
            this.LblProgreso.TabIndex = 16;
            this.LblProgreso.Text = "Progreso";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BkgRegistrarLibreria
            // 
            this.BkgRegistrarLibreria.WorkerReportsProgress = true;
            this.BkgRegistrarLibreria.WorkerSupportsCancellation = true;
            this.BkgRegistrarLibreria.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgRegistrarLibreria_DoWork);
            this.BkgRegistrarLibreria.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgRegistrarLibreria_ProgressChanged);
            this.BkgRegistrarLibreria.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgRegistrarLibreria_RunWorkerCompleted);
            // 
            // BkgEditarLibreria
            // 
            this.BkgEditarLibreria.WorkerReportsProgress = true;
            this.BkgEditarLibreria.WorkerSupportsCancellation = true;
            this.BkgEditarLibreria.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgEditarLibreria_DoWork);
            this.BkgEditarLibreria.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgEditarLibreria_ProgressChanged);
            this.BkgEditarLibreria.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgEditarLibreria_RunWorkerCompleted);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(392, 23);
            this.audiselTituloForm1.TabIndex = 17;
            this.audiselTituloForm1.Text = "REGISTRAR LIBERIA DE DISEÑO MECANICO";
            // 
            // FrmRegistrarLibreriaDme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 599);
            this.Controls.Add(this.audiselTituloForm1);
            this.Controls.Add(this.LblProgreso);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DgvArchivos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.TxtCarpeta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtFamilia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbFabricante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbSubcategoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbCategoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistrarLibreriaDme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar librería de diseño mecánico";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvArchivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbSubcategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbFabricante;
        private System.Windows.Forms.TextBox TxtFamilia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCarpeta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView DgvArchivos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.Label LblProgreso;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker BkgRegistrarLibreria;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn archivos;
        private System.ComponentModel.BackgroundWorker BkgEditarLibreria;
    }
}
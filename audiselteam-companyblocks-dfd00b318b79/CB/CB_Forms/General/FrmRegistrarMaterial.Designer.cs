namespace CB
{
    partial class FrmRegistrarMaterial
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxtNumeroParte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.CmbUnidades = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NumPiezasPaquete = new System.Windows.Forms.NumericUpDown();
            this.LblEtiquetaPiezasPorPaquete = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.LblInfo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtLink = new System.Windows.Forms.TextBox();
            this.CmbFabricante = new System.Windows.Forms.ComboBox();
            this.PnlMinMax = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.NumMaximo = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.NumMinimo = new System.Windows.Forms.NumericUpDown();
            this.btnRegstrarFabricante = new System.Windows.Forms.Button();
            this.ImagenMaterial = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BkgRegistrarMaterial = new System.ComponentModel.BackgroundWorker();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.ChkIva = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumPiezasPaquete)).BeginInit();
            this.PnlMinMax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(671, 23);
            this.LblTitulo.TabIndex = 29;
            this.LblTitulo.Text = "REGISTRAR MATERIAL";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // TxtNumeroParte
            // 
            this.TxtNumeroParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumeroParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParte.Location = new System.Drawing.Point(132, 47);
            this.TxtNumeroParte.Name = "TxtNumeroParte";
            this.TxtNumeroParte.Size = new System.Drawing.Size(247, 29);
            this.TxtNumeroParte.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Número de parte *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Fabricante *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Descripción *";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.Location = new System.Drawing.Point(4, 187);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(661, 66);
            this.TxtDescripcion.TabIndex = 34;
            // 
            // CmbUnidades
            // 
            this.CmbUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUnidades.FormattingEnabled = true;
            this.CmbUnidades.Items.AddRange(new object[] {
            "POR PIEZA",
            "POR PAQUETE"});
            this.CmbUnidades.Location = new System.Drawing.Point(132, 103);
            this.CmbUnidades.Name = "CmbUnidades";
            this.CmbUnidades.Size = new System.Drawing.Size(247, 32);
            this.CmbUnidades.TabIndex = 36;
            this.CmbUnidades.SelectedIndexChanged += new System.EventHandler(this.CmbUnidades_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Tipo de venta *";
            // 
            // NumPiezasPaquete
            // 
            this.NumPiezasPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPiezasPaquete.Location = new System.Drawing.Point(385, 103);
            this.NumPiezasPaquete.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPiezasPaquete.Name = "NumPiezasPaquete";
            this.NumPiezasPaquete.Size = new System.Drawing.Size(102, 29);
            this.NumPiezasPaquete.TabIndex = 38;
            this.NumPiezasPaquete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPiezasPaquete.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPiezasPaquete.Visible = false;
            // 
            // LblEtiquetaPiezasPorPaquete
            // 
            this.LblEtiquetaPiezasPorPaquete.AutoSize = true;
            this.LblEtiquetaPiezasPorPaquete.Location = new System.Drawing.Point(382, 87);
            this.LblEtiquetaPiezasPorPaquete.Name = "LblEtiquetaPiezasPorPaquete";
            this.LblEtiquetaPiezasPorPaquete.Size = new System.Drawing.Size(105, 13);
            this.LblEtiquetaPiezasPorPaquete.TabIndex = 39;
            this.LblEtiquetaPiezasPorPaquete.Text = "Piezas por paquete *";
            this.LblEtiquetaPiezasPorPaquete.Visible = false;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(283, 346);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(190, 40);
            this.BtnCancelar.TabIndex = 41;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.ok_48;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(479, 346);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(186, 40);
            this.BtnRegistrar.TabIndex = 40;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.ForeColor = System.Drawing.Color.Red;
            this.LblInfo.Location = new System.Drawing.Point(4, 295);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(401, 25);
            this.LblInfo.TabIndex = 42;
            this.LblInfo.Text = "Info";
            this.LblInfo.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Enlace de información";
            // 
            // TxtLink
            // 
            this.TxtLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLink.Location = new System.Drawing.Point(4, 272);
            this.TxtLink.Name = "TxtLink";
            this.TxtLink.Size = new System.Drawing.Size(661, 20);
            this.TxtLink.TabIndex = 43;
            // 
            // CmbFabricante
            // 
            this.CmbFabricante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CmbFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFabricante.FormattingEnabled = true;
            this.CmbFabricante.Items.AddRange(new object[] {
            "POR PIEZA",
            "POR PAQUETE"});
            this.CmbFabricante.Location = new System.Drawing.Point(385, 47);
            this.CmbFabricante.Name = "CmbFabricante";
            this.CmbFabricante.Size = new System.Drawing.Size(238, 32);
            this.CmbFabricante.TabIndex = 45;
            this.CmbFabricante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbFabricante_KeyPress);
            // 
            // PnlMinMax
            // 
            this.PnlMinMax.Controls.Add(this.label5);
            this.PnlMinMax.Controls.Add(this.NumMaximo);
            this.PnlMinMax.Controls.Add(this.label7);
            this.PnlMinMax.Controls.Add(this.NumMinimo);
            this.PnlMinMax.Location = new System.Drawing.Point(496, 84);
            this.PnlMinMax.Name = "PnlMinMax";
            this.PnlMinMax.Size = new System.Drawing.Size(169, 53);
            this.PnlMinMax.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Máximo";
            // 
            // NumMaximo
            // 
            this.NumMaximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumMaximo.Location = new System.Drawing.Point(88, 19);
            this.NumMaximo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumMaximo.Name = "NumMaximo";
            this.NumMaximo.Size = new System.Drawing.Size(75, 29);
            this.NumMaximo.TabIndex = 53;
            this.NumMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumMaximo.ValueChanged += new System.EventHandler(this.NumMaximo_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Mínimo";
            // 
            // NumMinimo
            // 
            this.NumMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumMinimo.Location = new System.Drawing.Point(4, 19);
            this.NumMinimo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumMinimo.Name = "NumMinimo";
            this.NumMinimo.Size = new System.Drawing.Size(78, 29);
            this.NumMinimo.TabIndex = 51;
            this.NumMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumMinimo.ValueChanged += new System.EventHandler(this.NumMinimo_ValueChanged);
            // 
            // btnRegstrarFabricante
            // 
            this.btnRegstrarFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegstrarFabricante.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.btnRegstrarFabricante.Location = new System.Drawing.Point(629, 47);
            this.btnRegstrarFabricante.Name = "btnRegstrarFabricante";
            this.btnRegstrarFabricante.Size = new System.Drawing.Size(36, 32);
            this.btnRegstrarFabricante.TabIndex = 58;
            this.btnRegstrarFabricante.UseVisualStyleBackColor = true;
            this.btnRegstrarFabricante.Click += new System.EventHandler(this.btnRegstrarFabricante_Click);
            // 
            // ImagenMaterial
            // 
            this.ImagenMaterial.Location = new System.Drawing.Point(7, 26);
            this.ImagenMaterial.Name = "ImagenMaterial";
            this.ImagenMaterial.Size = new System.Drawing.Size(120, 108);
            this.ImagenMaterial.TabIndex = 59;
            this.ImagenMaterial.TabStop = false;
            this.ImagenMaterial.Click += new System.EventHandler(this.ImagenMaterial_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 21);
            this.button1.TabIndex = 60;
            this.button1.Text = "Pegar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BkgRegistrarMaterial
            // 
            this.BkgRegistrarMaterial.WorkerReportsProgress = true;
            this.BkgRegistrarMaterial.WorkerSupportsCancellation = true;
            this.BkgRegistrarMaterial.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgRegistrarMaterial_DoWork);
            this.BkgRegistrarMaterial.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgRegistrarMaterial_ProgressChanged);
            this.BkgRegistrarMaterial.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgRegistrarMaterial_RunWorkerCompleted);
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(4, 313);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(661, 23);
            this.Progreso.TabIndex = 61;
            // 
            // ChkIva
            // 
            this.ChkIva.AutoSize = true;
            this.ChkIva.Checked = true;
            this.ChkIva.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkIva.Location = new System.Drawing.Point(136, 141);
            this.ChkIva.Name = "ChkIva";
            this.ChkIva.Size = new System.Drawing.Size(78, 17);
            this.ChkIva.TabIndex = 62;
            this.ChkIva.Text = "Aplicar IVA";
            this.ChkIva.UseVisualStyleBackColor = true;
            // 
            // FrmRegistrarMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 392);
            this.Controls.Add(this.ChkIva);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ImagenMaterial);
            this.Controls.Add(this.btnRegstrarFabricante);
            this.Controls.Add(this.PnlMinMax);
            this.Controls.Add(this.CmbFabricante);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtLink);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.LblEtiquetaPiezasPorPaquete);
            this.Controls.Add(this.NumPiezasPaquete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbUnidades);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNumeroParte);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistrarMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegistrarMaterial";
            this.Load += new System.EventHandler(this.FrmRegistrarMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumPiezasPaquete)).EndInit();
            this.PnlMinMax.ResumeLayout(false);
            this.PnlMinMax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtNumeroParte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.ComboBox CmbUnidades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumPiezasPaquete;
        private System.Windows.Forms.Label LblEtiquetaPiezasPorPaquete;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtLink;
        private System.Windows.Forms.ComboBox CmbFabricante;
        private System.Windows.Forms.Panel PnlMinMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumMaximo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NumMinimo;
        private System.Windows.Forms.Button btnRegstrarFabricante;
        private System.Windows.Forms.PictureBox ImagenMaterial;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker BkgRegistrarMaterial;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.CheckBox ChkIva;

    }
}
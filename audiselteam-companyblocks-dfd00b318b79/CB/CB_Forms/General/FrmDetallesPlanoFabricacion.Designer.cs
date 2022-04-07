namespace CB
{
    partial class FrmDetallesPlanoFabricacion
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("General", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Revisión", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Fabricación", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Ensamble", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LvInfoPieza = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnDescargarDXF = new System.Windows.Forms.Button();
            this.saveDXF = new System.Windows.Forms.SaveFileDialog();
            this.TxtComentariosEnsamble = new System.Windows.Forms.TextBox();
            this.TxtComentariosRetrabajo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtComentariosRevision = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DgvDimensiones = new System.Windows.Forms.DataGridView();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDimensiones)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(442, 23);
            this.LblTitulo.TabIndex = 28;
            this.LblTitulo.Text = "DETALLES DEL PLANO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LvInfoPieza
            // 
            this.LvInfoPieza.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LvInfoPieza.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "General";
            listViewGroup1.Name = "General";
            listViewGroup1.Tag = "General";
            listViewGroup2.Header = "Revisión";
            listViewGroup2.Name = "Revision";
            listViewGroup2.Tag = "Revision";
            listViewGroup3.Header = "Fabricación";
            listViewGroup3.Name = "Fabricacion";
            listViewGroup3.Tag = "Fabricacion";
            listViewGroup4.Header = "Ensamble";
            listViewGroup4.Name = "Ensamble";
            listViewGroup4.Tag = "Ensamble";
            this.LvInfoPieza.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.LvInfoPieza.Location = new System.Drawing.Point(3, 3);
            this.LvInfoPieza.Name = "LvInfoPieza";
            this.LvInfoPieza.Size = new System.Drawing.Size(404, 431);
            this.LvInfoPieza.TabIndex = 29;
            this.LvInfoPieza.UseCompatibleStateImageBehavior = false;
            this.LvInfoPieza.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Propiedad";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Valor";
            this.columnHeader2.Width = 200;
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(230, 495);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(199, 41);
            this.BtnSalir.TabIndex = 30;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnDescargarDXF
            // 
            this.BtnDescargarDXF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDescargarDXF.Location = new System.Drawing.Point(16, 495);
            this.BtnDescargarDXF.Name = "BtnDescargarDXF";
            this.BtnDescargarDXF.Size = new System.Drawing.Size(196, 41);
            this.BtnDescargarDXF.TabIndex = 31;
            this.BtnDescargarDXF.Text = "Descargar DXF";
            this.BtnDescargarDXF.UseVisualStyleBackColor = true;
            this.BtnDescargarDXF.Click += new System.EventHandler(this.BtnDescargarDXF_Click);
            // 
            // TxtComentariosEnsamble
            // 
            this.TxtComentariosEnsamble.Location = new System.Drawing.Point(19, 130);
            this.TxtComentariosEnsamble.Multiline = true;
            this.TxtComentariosEnsamble.Name = "TxtComentariosEnsamble";
            this.TxtComentariosEnsamble.ReadOnly = true;
            this.TxtComentariosEnsamble.Size = new System.Drawing.Size(370, 81);
            this.TxtComentariosEnsamble.TabIndex = 32;
            // 
            // TxtComentariosRetrabajo
            // 
            this.TxtComentariosRetrabajo.Location = new System.Drawing.Point(19, 234);
            this.TxtComentariosRetrabajo.Multiline = true;
            this.TxtComentariosRetrabajo.Name = "TxtComentariosRetrabajo";
            this.TxtComentariosRetrabajo.ReadOnly = true;
            this.TxtComentariosRetrabajo.Size = new System.Drawing.Size(370, 88);
            this.TxtComentariosRetrabajo.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Comentarios de ensamble:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Comentarios de retrabajo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Comentarios de revisión:";
            // 
            // TxtComentariosRevision
            // 
            this.TxtComentariosRevision.Location = new System.Drawing.Point(19, 28);
            this.TxtComentariosRevision.Multiline = true;
            this.TxtComentariosRevision.Name = "TxtComentariosRevision";
            this.TxtComentariosRevision.ReadOnly = true;
            this.TxtComentariosRevision.Size = new System.Drawing.Size(370, 81);
            this.TxtComentariosRevision.TabIndex = 36;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(418, 463);
            this.tabControl1.TabIndex = 38;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LvInfoPieza);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(410, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Información general";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TxtComentariosRetrabajo);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.TxtComentariosEnsamble);
            this.tabPage2.Controls.Add(this.TxtComentariosRevision);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(410, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Comentarios";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DgvDimensiones);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(410, 437);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dimensiones críticas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DgvDimensiones
            // 
            this.DgvDimensiones.AllowUserToAddRows = false;
            this.DgvDimensiones.AllowUserToDeleteRows = false;
            this.DgvDimensiones.AllowUserToResizeRows = false;
            this.DgvDimensiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDimensiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcion,
            this.nominal,
            this.minimo,
            this.maximo,
            this.instrumento});
            this.DgvDimensiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDimensiones.Location = new System.Drawing.Point(0, 0);
            this.DgvDimensiones.MultiSelect = false;
            this.DgvDimensiones.Name = "DgvDimensiones";
            this.DgvDimensiones.ReadOnly = true;
            this.DgvDimensiones.RowHeadersVisible = false;
            this.DgvDimensiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDimensiones.Size = new System.Drawing.Size(410, 437);
            this.DgvDimensiones.TabIndex = 0;
            // 
            // descripcion
            // 
            this.descripcion.Frozen = true;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 285;
            // 
            // nominal
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nominal.DefaultCellStyle = dataGridViewCellStyle1;
            this.nominal.HeaderText = "Nominal";
            this.nominal.Name = "nominal";
            this.nominal.ReadOnly = true;
            this.nominal.Width = 120;
            // 
            // minimo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.minimo.DefaultCellStyle = dataGridViewCellStyle2;
            this.minimo.HeaderText = "Minimo";
            this.minimo.Name = "minimo";
            this.minimo.ReadOnly = true;
            this.minimo.Width = 120;
            // 
            // maximo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.maximo.DefaultCellStyle = dataGridViewCellStyle3;
            this.maximo.HeaderText = "Máximo";
            this.maximo.Name = "maximo";
            this.maximo.ReadOnly = true;
            this.maximo.Width = 120;
            // 
            // instrumento
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.instrumento.DefaultCellStyle = dataGridViewCellStyle4;
            this.instrumento.HeaderText = "Instrumento de medición";
            this.instrumento.Name = "instrumento";
            this.instrumento.ReadOnly = true;
            this.instrumento.Width = 120;
            // 
            // FrmDetallesPlanoFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(442, 548);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BtnDescargarDXF);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetallesPlanoFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles de plano";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDimensiones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ListView LvInfoPieza;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnDescargarDXF;
        private System.Windows.Forms.SaveFileDialog saveDXF;
        private System.Windows.Forms.TextBox TxtComentariosEnsamble;
        private System.Windows.Forms.TextBox TxtComentariosRetrabajo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtComentariosRevision;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView DgvDimensiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn minimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn maximo;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumento;
    }
}
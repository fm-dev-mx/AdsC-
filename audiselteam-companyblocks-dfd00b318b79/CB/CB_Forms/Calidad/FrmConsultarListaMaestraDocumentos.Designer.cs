namespace CB
{
    partial class FrmConsultarListaMaestraDocumentos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbFiltroDepartamento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvListadoMaestro = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable_revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fehca_aprovacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListadoMaestro)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.CmbFiltroDepartamento);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 63);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(947, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 63);
            this.panel2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CB_Base.Properties.Resources.exit;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 63);
            this.button1.TabIndex = 14;
            this.button1.Text = "     Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbFiltroDepartamento
            // 
            this.CmbFiltroDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltroDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltroDepartamento.FormattingEnabled = true;
            this.CmbFiltroDepartamento.Location = new System.Drawing.Point(6, 23);
            this.CmbFiltroDepartamento.Name = "CmbFiltroDepartamento";
            this.CmbFiltroDepartamento.Size = new System.Drawing.Size(202, 32);
            this.CmbFiltroDepartamento.TabIndex = 14;
            this.CmbFiltroDepartamento.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroDepartamento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtrar por departamento:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1091, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "LISTA MAESTRA DE DOCUMENTOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
            // 
            // DgvListadoMaestro
            // 
            this.DgvListadoMaestro.AllowUserToAddRows = false;
            this.DgvListadoMaestro.AllowUserToDeleteRows = false;
            this.DgvListadoMaestro.AllowUserToResizeRows = false;
            this.DgvListadoMaestro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListadoMaestro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvListadoMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListadoMaestro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipo,
            this.departamento,
            this.documento,
            this.revision,
            this.creador,
            this.responsable_revision,
            this.responsable,
            this.fehca_aprovacion});
            this.DgvListadoMaestro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvListadoMaestro.Location = new System.Drawing.Point(0, 85);
            this.DgvListadoMaestro.Name = "DgvListadoMaestro";
            this.DgvListadoMaestro.ReadOnly = true;
            this.DgvListadoMaestro.RowHeadersVisible = false;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListadoMaestro.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvListadoMaestro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListadoMaestro.Size = new System.Drawing.Size(1091, 420);
            this.DgvListadoMaestro.TabIndex = 4;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 22;
            // 
            // tipo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tipo.DefaultCellStyle = dataGridViewCellStyle2;
            this.tipo.HeaderText = "Tipo";
            this.tipo.MinimumWidth = 38;
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 38;
            // 
            // departamento
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.departamento.DefaultCellStyle = dataGridViewCellStyle3;
            this.departamento.HeaderText = "Departamento";
            this.departamento.MinimumWidth = 80;
            this.departamento.Name = "departamento";
            this.departamento.ReadOnly = true;
            this.departamento.Width = 80;
            // 
            // documento
            // 
            this.documento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.documento.FillWeight = 445.3608F;
            this.documento.HeaderText = "Documento";
            this.documento.MinimumWidth = 350;
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            // 
            // revision
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.revision.DefaultCellStyle = dataGridViewCellStyle4;
            this.revision.FillWeight = 30.92783F;
            this.revision.HeaderText = "Revisión";
            this.revision.MinimumWidth = 55;
            this.revision.Name = "revision";
            this.revision.ReadOnly = true;
            this.revision.Width = 55;
            // 
            // creador
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.creador.DefaultCellStyle = dataGridViewCellStyle5;
            this.creador.FillWeight = 30.92783F;
            this.creador.HeaderText = "Responsable";
            this.creador.MinimumWidth = 130;
            this.creador.Name = "creador";
            this.creador.ReadOnly = true;
            this.creador.Width = 130;
            // 
            // responsable_revision
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable_revision.DefaultCellStyle = dataGridViewCellStyle6;
            this.responsable_revision.HeaderText = "Responsable revisión";
            this.responsable_revision.MinimumWidth = 130;
            this.responsable_revision.Name = "responsable_revision";
            this.responsable_revision.ReadOnly = true;
            this.responsable_revision.Width = 130;
            // 
            // responsable
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable.DefaultCellStyle = dataGridViewCellStyle7;
            this.responsable.FillWeight = 30.92783F;
            this.responsable.HeaderText = "Responsable de aprobación";
            this.responsable.MinimumWidth = 130;
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            this.responsable.Width = 130;
            // 
            // fehca_aprovacion
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fehca_aprovacion.DefaultCellStyle = dataGridViewCellStyle8;
            this.fehca_aprovacion.FillWeight = 30.92783F;
            this.fehca_aprovacion.HeaderText = "Fecha de aprobación";
            this.fehca_aprovacion.MinimumWidth = 155;
            this.fehca_aprovacion.Name = "fehca_aprovacion";
            this.fehca_aprovacion.ReadOnly = true;
            this.fehca_aprovacion.Width = 155;
            // 
            // FrmConsultarListaMaestraDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 505);
            this.Controls.Add(this.DgvListadoMaestro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultarListaMaestraDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado maestro de documentos";
            this.Load += new System.EventHandler(this.FrmConsultarListaMaestraDocumentos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListadoMaestro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbFiltroDepartamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvListadoMaestro;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn creador;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable_revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fehca_aprovacion;
    }
}
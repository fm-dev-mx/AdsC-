namespace CB
{
    partial class FrmAgregarProcesoPlano
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerPrincipal = new System.Windows.Forms.SplitContainer();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.splitContainerProcesoDgv = new System.Windows.Forms.SplitContainer();
            this.ChkDependencia = new System.Windows.Forms.CheckBox();
            this.LblPlano = new System.Windows.Forms.Label();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.CmbAsignacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbProcesos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbCategorias = new System.Windows.Forms.ComboBox();
            this.LblProveedor = new System.Windows.Forms.Label();
            this.DgvProcesoAnterior = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblProcesoAnterior = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPrincipal)).BeginInit();
            this.splitContainerPrincipal.Panel1.SuspendLayout();
            this.splitContainerPrincipal.Panel2.SuspendLayout();
            this.splitContainerPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerProcesoDgv)).BeginInit();
            this.splitContainerProcesoDgv.Panel1.SuspendLayout();
            this.splitContainerProcesoDgv.Panel2.SuspendLayout();
            this.splitContainerProcesoDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesoAnterior)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerPrincipal
            // 
            this.splitContainerPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainerPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPrincipal.Location = new System.Drawing.Point(0, 0);
            this.splitContainerPrincipal.Name = "splitContainerPrincipal";
            this.splitContainerPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerPrincipal.Panel1
            // 
            this.splitContainerPrincipal.Panel1.Controls.Add(this.LblTitulo);
            // 
            // splitContainerPrincipal.Panel2
            // 
            this.splitContainerPrincipal.Panel2.Controls.Add(this.splitContainerProcesoDgv);
            this.splitContainerPrincipal.Size = new System.Drawing.Size(816, 526);
            this.splitContainerPrincipal.SplitterDistance = 26;
            this.splitContainerPrincipal.TabIndex = 29;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(816, 30);
            this.LblTitulo.TabIndex = 84;
            this.LblTitulo.Text = "AGREGAR PROCESO AL PLANO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // splitContainerProcesoDgv
            // 
            this.splitContainerProcesoDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerProcesoDgv.Location = new System.Drawing.Point(0, 0);
            this.splitContainerProcesoDgv.Name = "splitContainerProcesoDgv";
            // 
            // splitContainerProcesoDgv.Panel1
            // 
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.ChkDependencia);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.LblPlano);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.TxtComentarios);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.label3);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.BtnCancelar);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.BtnAgregar);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.CmbAsignacion);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.label2);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.CmbProcesos);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.label1);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.CmbCategorias);
            this.splitContainerProcesoDgv.Panel1.Controls.Add(this.LblProveedor);
            // 
            // splitContainerProcesoDgv.Panel2
            // 
            this.splitContainerProcesoDgv.Panel2.Controls.Add(this.DgvProcesoAnterior);
            this.splitContainerProcesoDgv.Panel2.Controls.Add(this.LblProcesoAnterior);
            this.splitContainerProcesoDgv.Size = new System.Drawing.Size(816, 496);
            this.splitContainerProcesoDgv.SplitterDistance = 364;
            this.splitContainerProcesoDgv.TabIndex = 0;
            // 
            // ChkDependencia
            // 
            this.ChkDependencia.AutoSize = true;
            this.ChkDependencia.Checked = true;
            this.ChkDependencia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDependencia.Enabled = false;
            this.ChkDependencia.Location = new System.Drawing.Point(13, 391);
            this.ChkDependencia.Name = "ChkDependencia";
            this.ChkDependencia.Size = new System.Drawing.Size(162, 17);
            this.ChkDependencia.TabIndex = 84;
            this.ChkDependencia.Text = "Marcar como dependencia 0";
            this.ChkDependencia.UseVisualStyleBackColor = true;
            this.ChkDependencia.Visible = false;
            this.ChkDependencia.CheckedChanged += new System.EventHandler(this.ChkDependencia_CheckedChanged);
            // 
            // LblPlano
            // 
            this.LblPlano.BackColor = System.Drawing.Color.Black;
            this.LblPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPlano.ForeColor = System.Drawing.Color.White;
            this.LblPlano.Location = new System.Drawing.Point(0, 0);
            this.LblPlano.Name = "LblPlano";
            this.LblPlano.Size = new System.Drawing.Size(364, 23);
            this.LblPlano.TabIndex = 83;
            this.LblPlano.Text = "PLANO";
            this.LblPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Location = new System.Drawing.Point(13, 261);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(337, 123);
            this.TxtComentarios.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 81;
            this.label3.Text = "Comentarios:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(64, 425);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(140, 41);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Enabled = false;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(210, 425);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(140, 41);
            this.BtnAgregar.TabIndex = 6;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // CmbAsignacion
            // 
            this.CmbAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAsignacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAsignacion.FormattingEnabled = true;
            this.CmbAsignacion.Items.AddRange(new object[] {
            "LOCAL",
            "PROVEEDOR"});
            this.CmbAsignacion.Location = new System.Drawing.Point(13, 188);
            this.CmbAsignacion.Name = "CmbAsignacion";
            this.CmbAsignacion.Size = new System.Drawing.Size(337, 32);
            this.CmbAsignacion.TabIndex = 2;
            this.CmbAsignacion.SelectedIndexChanged += new System.EventHandler(this.CmbMaquinas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 24);
            this.label2.TabIndex = 77;
            this.label2.Text = "Tipo de asignación:";
            // 
            // CmbProcesos
            // 
            this.CmbProcesos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProcesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProcesos.FormattingEnabled = true;
            this.CmbProcesos.Location = new System.Drawing.Point(12, 118);
            this.CmbProcesos.Name = "CmbProcesos";
            this.CmbProcesos.Size = new System.Drawing.Size(338, 32);
            this.CmbProcesos.TabIndex = 1;
            this.CmbProcesos.SelectedIndexChanged += new System.EventHandler(this.CmbProcesos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 75;
            this.label1.Text = "Tipo de proceso:";
            // 
            // CmbCategorias
            // 
            this.CmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategorias.FormattingEnabled = true;
            this.CmbCategorias.Location = new System.Drawing.Point(12, 52);
            this.CmbCategorias.Name = "CmbCategorias";
            this.CmbCategorias.Size = new System.Drawing.Size(338, 32);
            this.CmbCategorias.TabIndex = 0;
            this.CmbCategorias.SelectedIndexChanged += new System.EventHandler(this.CmbCategorias_SelectedIndexChanged);
            // 
            // LblProveedor
            // 
            this.LblProveedor.AutoSize = true;
            this.LblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProveedor.Location = new System.Drawing.Point(8, 25);
            this.LblProveedor.Name = "LblProveedor";
            this.LblProveedor.Size = new System.Drawing.Size(95, 24);
            this.LblProveedor.TabIndex = 73;
            this.LblProveedor.Text = "Categoría:";
            // 
            // DgvProcesoAnterior
            // 
            this.DgvProcesoAnterior.AllowUserToAddRows = false;
            this.DgvProcesoAnterior.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesoAnterior.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesoAnterior.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvProcesoAnterior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProcesoAnterior.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipo});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesoAnterior.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvProcesoAnterior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProcesoAnterior.Location = new System.Drawing.Point(0, 23);
            this.DgvProcesoAnterior.Name = "DgvProcesoAnterior";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesoAnterior.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvProcesoAnterior.RowHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcesoAnterior.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvProcesoAnterior.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProcesoAnterior.Size = new System.Drawing.Size(448, 473);
            this.DgvProcesoAnterior.TabIndex = 4;
            this.DgvProcesoAnterior.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProcesoAnterior_CellClick);
            // 
            // id
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            this.id.HeaderText = "#";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tipo.DefaultCellStyle = dataGridViewCellStyle4;
            this.tipo.HeaderText = "Tipo de proceso";
            this.tipo.MinimumWidth = 180;
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // LblProcesoAnterior
            // 
            this.LblProcesoAnterior.BackColor = System.Drawing.Color.Black;
            this.LblProcesoAnterior.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblProcesoAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProcesoAnterior.ForeColor = System.Drawing.Color.White;
            this.LblProcesoAnterior.Location = new System.Drawing.Point(0, 0);
            this.LblProcesoAnterior.Name = "LblProcesoAnterior";
            this.LblProcesoAnterior.Size = new System.Drawing.Size(448, 23);
            this.LblProcesoAnterior.TabIndex = 84;
            this.LblProcesoAnterior.Text = "SELECCIONE EL PROCESO ANTERIOR";
            this.LblProcesoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmAgregarProcesoPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 526);
            this.Controls.Add(this.splitContainerPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarProcesoPlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar proceso al plano";
            this.splitContainerPrincipal.Panel1.ResumeLayout(false);
            this.splitContainerPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPrincipal)).EndInit();
            this.splitContainerPrincipal.ResumeLayout(false);
            this.splitContainerProcesoDgv.Panel1.ResumeLayout(false);
            this.splitContainerProcesoDgv.Panel1.PerformLayout();
            this.splitContainerProcesoDgv.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerProcesoDgv)).EndInit();
            this.splitContainerProcesoDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcesoAnterior)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerPrincipal;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainerProcesoDgv;
        private System.Windows.Forms.Label LblPlano;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.ComboBox CmbAsignacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbProcesos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbCategorias;
        private System.Windows.Forms.Label LblProveedor;
        private System.Windows.Forms.DataGridView DgvProcesoAnterior;
        private System.Windows.Forms.Label LblProcesoAnterior;
        private System.Windows.Forms.CheckBox ChkDependencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;

    }
}
namespace CB
{
    partial class FrmSeleccionarTipoExtrawork
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.DgvPlanos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoExtrawork = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlanos)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(281, 213);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(86, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // DgvPlanos
            // 
            this.DgvPlanos.AllowUserToAddRows = false;
            this.DgvPlanos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlanos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.plano,
            this.tipo});
            this.DgvPlanos.Location = new System.Drawing.Point(11, 82);
            this.DgvPlanos.Name = "DgvPlanos";
            this.DgvPlanos.ReadOnly = true;
            this.DgvPlanos.RowHeadersVisible = false;
            this.DgvPlanos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPlanos.Size = new System.Drawing.Size(356, 125);
            this.DgvPlanos.TabIndex = 4;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // plano
            // 
            this.plano.HeaderText = "Plano";
            this.plano.Name = "plano";
            this.plano.ReadOnly = true;
            this.plano.Width = 200;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 150;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selecciona el plano de corte WATER JET al que corresponde el EXTRA WORK:";
            // 
            // cmbTipoExtrawork
            // 
            this.cmbTipoExtrawork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoExtrawork.FormattingEnabled = true;
            this.cmbTipoExtrawork.Items.AddRange(new object[] {
            "CORTE WATER JET",
            "PARTE COMPRADA"});
            this.cmbTipoExtrawork.Location = new System.Drawing.Point(133, 12);
            this.cmbTipoExtrawork.Name = "cmbTipoExtrawork";
            this.cmbTipoExtrawork.Size = new System.Drawing.Size(234, 21);
            this.cmbTipoExtrawork.TabIndex = 6;
            this.cmbTipoExtrawork.SelectedIndexChanged += new System.EventHandler(this.cmbTipoExtrawork_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tipo de EXTRA WORK:";
            // 
            // FrmSeleccionarTipoExtrawork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 248);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipoExtrawork);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvPlanos);
            this.Controls.Add(this.BtnCancelar);
            this.Name = "FrmSeleccionarTipoExtrawork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar tipo de EXTRA WORK";
            this.Load += new System.EventHandler(this.FrmSeleccionarTipoExtrawork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlanos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridView DgvPlanos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoExtrawork;
        private System.Windows.Forms.Label label2;
    }
}
namespace CB
{
    partial class FrmRegistrarPlanoFueraDelSistema
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
            this.TxtNombrePlano = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbSolicitante = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvHerramentistas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.herramentista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_trabajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHerramentistas)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNombrePlano
            // 
            this.TxtNombrePlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombrePlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombrePlano.Location = new System.Drawing.Point(3, 27);
            this.TxtNombrePlano.MaxLength = 65;
            this.TxtNombrePlano.Name = "TxtNombrePlano";
            this.TxtNombrePlano.Size = new System.Drawing.Size(415, 29);
            this.TxtNombrePlano.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbSolicitante);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtNombrePlano);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 61);
            this.panel1.TabIndex = 3;
            // 
            // CmbSolicitante
            // 
            this.CmbSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSolicitante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSolicitante.FormattingEnabled = true;
            this.CmbSolicitante.Location = new System.Drawing.Point(424, 24);
            this.CmbSolicitante.Name = "CmbSolicitante";
            this.CmbSolicitante.Size = new System.Drawing.Size(415, 32);
            this.CmbSolicitante.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(421, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione quién lo solicita";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(415, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ingrese el nombre del plano (Ej. M120-01-02-03)";
            // 
            // DgvHerramentistas
            // 
            this.DgvHerramentistas.AllowUserToAddRows = false;
            this.DgvHerramentistas.AllowUserToDeleteRows = false;
            this.DgvHerramentistas.AllowUserToResizeRows = false;
            this.DgvHerramentistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHerramentistas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.check,
            this.herramentista,
            this.tiempo_trabajo});
            this.DgvHerramentistas.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvHerramentistas.Location = new System.Drawing.Point(0, 108);
            this.DgvHerramentistas.Name = "DgvHerramentistas";
            this.DgvHerramentistas.RowHeadersVisible = false;
            this.DgvHerramentistas.Size = new System.Drawing.Size(841, 311);
            this.DgvHerramentistas.TabIndex = 17;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 50;
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.MinimumWidth = 50;
            this.check.Name = "check";
            this.check.Width = 50;
            // 
            // herramentista
            // 
            this.herramentista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.herramentista.DefaultCellStyle = dataGridViewCellStyle1;
            this.herramentista.HeaderText = "Herramentista";
            this.herramentista.Name = "herramentista";
            this.herramentista.ReadOnly = true;
            // 
            // tiempo_trabajo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_trabajo.DefaultCellStyle = dataGridViewCellStyle2;
            this.tiempo_trabajo.HeaderText = "Tiempo de trabajo";
            this.tiempo_trabajo.MinimumWidth = 150;
            this.tiempo_trabajo.Name = "tiempo_trabajo";
            this.tiempo_trabajo.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Seleccione a los herramentistas involucrados en el proceso";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(567, 425);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(128, 47);
            this.BtnCancelar.TabIndex = 16;
            this.BtnCancelar.Text = "   Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(701, 425);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(128, 47);
            this.BtnAceptar.TabIndex = 15;
            this.BtnAceptar.Text = "    Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Margin = new System.Windows.Forms.Padding(6);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(841, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "REGISTRAR PLANO FUERA DEL SISTEMA";
            // 
            // FrmRegistrarPlanoFueraDelSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 484);
            this.Controls.Add(this.DgvHerramentistas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistrarPlanoFueraDelSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar plano fuera del sistema";
            this.Load += new System.EventHandler(this.FrmRegistrarPlanoFueraDelSistema_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHerramentistas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.TextBox TxtNombrePlano;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvHerramentistas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramentista;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_trabajo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.ComboBox CmbSolicitante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
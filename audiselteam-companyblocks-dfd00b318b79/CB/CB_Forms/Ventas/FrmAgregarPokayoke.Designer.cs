namespace CB
{
    partial class FrmAgregarPokayoke
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAcepatr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbObjetivo = new System.Windows.Forms.ComboBox();
            this.CmbMetodos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvAlcance = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alcance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlcance)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnAcepatr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 49);
            this.panel1.TabIndex = 1;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(291, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(111, 49);
            this.BtnCancelar.TabIndex = 0;
            this.BtnCancelar.Text = "        Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAcepatr
            // 
            this.BtnAcepatr.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAcepatr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAcepatr.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAcepatr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAcepatr.Location = new System.Drawing.Point(402, 0);
            this.BtnAcepatr.Name = "BtnAcepatr";
            this.BtnAcepatr.Size = new System.Drawing.Size(111, 49);
            this.BtnAcepatr.TabIndex = 1;
            this.BtnAcepatr.Text = "     Aceptar";
            this.BtnAcepatr.UseVisualStyleBackColor = true;
            this.BtnAcepatr.Click += new System.EventHandler(this.BtnAcepatr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Objetivo";
            // 
            // CmbObjetivo
            // 
            this.CmbObjetivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbObjetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbObjetivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbObjetivo.FormattingEnabled = true;
            this.CmbObjetivo.Location = new System.Drawing.Point(0, 16);
            this.CmbObjetivo.Name = "CmbObjetivo";
            this.CmbObjetivo.Size = new System.Drawing.Size(513, 23);
            this.CmbObjetivo.TabIndex = 3;
            this.CmbObjetivo.SelectedIndexChanged += new System.EventHandler(this.CmbObjetivo_SelectedIndexChanged);
            // 
            // CmbMetodos
            // 
            this.CmbMetodos.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbMetodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMetodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMetodos.FormattingEnabled = true;
            this.CmbMetodos.Location = new System.Drawing.Point(0, 55);
            this.CmbMetodos.Name = "CmbMetodos";
            this.CmbMetodos.Size = new System.Drawing.Size(513, 23);
            this.CmbMetodos.TabIndex = 5;
            this.CmbMetodos.SelectedIndexChanged += new System.EventHandler(this.CmbMetodos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Método";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(513, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Alcance";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvAlcance
            // 
            this.DgvAlcance.AllowUserToAddRows = false;
            this.DgvAlcance.AllowUserToDeleteRows = false;
            this.DgvAlcance.AllowUserToResizeRows = false;
            this.DgvAlcance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvAlcance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlcance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.id,
            this.alcance});
            this.DgvAlcance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAlcance.Location = new System.Drawing.Point(0, 123);
            this.DgvAlcance.Name = "DgvAlcance";
            this.DgvAlcance.RowHeadersVisible = false;
            this.DgvAlcance.Size = new System.Drawing.Size(513, 138);
            this.DgvAlcance.TabIndex = 7;
            this.DgvAlcance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAlcance_CellClick);
            // 
            // check
            // 
            this.check.FalseValue = "false";
            this.check.HeaderText = "";
            this.check.MinimumWidth = 50;
            this.check.Name = "check";
            this.check.TrueValue = "true";
            this.check.Width = 50;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // alcance
            // 
            this.alcance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alcance.DefaultCellStyle = dataGridViewCellStyle1;
            this.alcance.HeaderText = "Alcance";
            this.alcance.Name = "alcance";
            this.alcance.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.CmbMetodos);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CmbObjetivo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 100);
            this.panel2.TabIndex = 8;
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(513, 23);
            this.audiselTituloForm1.TabIndex = 9;
            this.audiselTituloForm1.Text = "AGREGAR POKA-YOKE";
            // 
            // FrmAgregarPokayoke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 310);
            this.Controls.Add(this.DgvAlcance);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarPokayoke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar poka-yoke";
            this.Load += new System.EventHandler(this.FrmAgregarPokayoke_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlcance)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbObjetivo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAcepatr;
        private System.Windows.Forms.ComboBox CmbMetodos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvAlcance;
        private System.Windows.Forms.Panel panel2;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn alcance;
    }
}
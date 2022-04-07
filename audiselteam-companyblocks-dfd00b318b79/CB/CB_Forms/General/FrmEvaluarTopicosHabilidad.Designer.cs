namespace CB
{
    partial class FrmEvaluarTopicosHabilidad
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTipoHabilidad = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblAvance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblPuntuacion = new System.Windows.Forms.Label();
            this.TxtHabilidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DgvHabilidades = new System.Windows.Forms.DataGridView();
            this.id_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios_habilidad_personal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_habilidad_personal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(917, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "EVALUAR COMPETENCIA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtTipoHabilidad);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.TxtHabilidad);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 66);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 123;
            this.label1.Text = "Tipo de competencia:";
            // 
            // TxtTipoHabilidad
            // 
            this.TxtTipoHabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTipoHabilidad.Location = new System.Drawing.Point(338, 24);
            this.TxtTipoHabilidad.Multiline = true;
            this.TxtTipoHabilidad.Name = "TxtTipoHabilidad";
            this.TxtTipoHabilidad.ReadOnly = true;
            this.TxtTipoHabilidad.Size = new System.Drawing.Size(312, 29);
            this.TxtTipoHabilidad.TabIndex = 122;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LblAvance);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.LblPuntuacion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(656, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 66);
            this.panel3.TabIndex = 120;
            // 
            // LblAvance
            // 
            this.LblAvance.AutoSize = true;
            this.LblAvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAvance.Location = new System.Drawing.Point(31, 24);
            this.LblAvance.Name = "LblAvance";
            this.LblAvance.Size = new System.Drawing.Size(71, 37);
            this.LblAvance.TabIndex = 119;
            this.LblAvance.Text = "0/N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "Puntuación actual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 118;
            this.label5.Text = "Tópicos evaluados:";
            // 
            // LblPuntuacion
            // 
            this.LblPuntuacion.AutoSize = true;
            this.LblPuntuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuntuacion.ForeColor = System.Drawing.Color.Red;
            this.LblPuntuacion.Location = new System.Drawing.Point(155, 24);
            this.LblPuntuacion.Name = "LblPuntuacion";
            this.LblPuntuacion.Size = new System.Drawing.Size(65, 37);
            this.LblPuntuacion.TabIndex = 117;
            this.LblPuntuacion.Text = "0%";
            // 
            // TxtHabilidad
            // 
            this.TxtHabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHabilidad.Location = new System.Drawing.Point(12, 24);
            this.TxtHabilidad.Name = "TxtHabilidad";
            this.TxtHabilidad.ReadOnly = true;
            this.TxtHabilidad.Size = new System.Drawing.Size(312, 29);
            this.TxtHabilidad.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 114;
            this.label3.Text = "Competencia:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnFinalizar);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 382);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(917, 59);
            this.panel2.TabIndex = 21;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(656, 0);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(124, 59);
            this.BtnFinalizar.TabIndex = 125;
            this.BtnFinalizar.Text = "      Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(780, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 59);
            this.BtnSalir.TabIndex = 124;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // DgvHabilidades
            // 
            this.DgvHabilidades.AllowUserToAddRows = false;
            this.DgvHabilidades.AllowUserToDeleteRows = false;
            this.DgvHabilidades.AllowUserToResizeRows = false;
            this.DgvHabilidades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvHabilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHabilidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_habilidad_personal,
            this.habilidad_personal,
            this.descripcion_habilidad_personal,
            this.comentarios_habilidad_personal,
            this.nivel_habilidad_personal});
            this.DgvHabilidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHabilidades.Location = new System.Drawing.Point(0, 89);
            this.DgvHabilidades.Name = "DgvHabilidades";
            this.DgvHabilidades.RowHeadersVisible = false;
            this.DgvHabilidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHabilidades.Size = new System.Drawing.Size(917, 293);
            this.DgvHabilidades.TabIndex = 22;
            this.DgvHabilidades.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHabilidades_CellValueChangeds);
            this.DgvHabilidades.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvHabilidades_EditingControlShowing);
            // 
            // id_habilidad_personal
            // 
            this.id_habilidad_personal.HeaderText = "ID Habilidad Personal";
            this.id_habilidad_personal.Name = "id_habilidad_personal";
            this.id_habilidad_personal.ReadOnly = true;
            this.id_habilidad_personal.Visible = false;
            this.id_habilidad_personal.Width = 50;
            // 
            // habilidad_personal
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.habilidad_personal.DefaultCellStyle = dataGridViewCellStyle1;
            this.habilidad_personal.HeaderText = "Tópico";
            this.habilidad_personal.Name = "habilidad_personal";
            this.habilidad_personal.ReadOnly = true;
            this.habilidad_personal.Width = 320;
            // 
            // descripcion_habilidad_personal
            // 
            this.descripcion_habilidad_personal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle2;
            this.descripcion_habilidad_personal.HeaderText = "Descripción de la habilidad";
            this.descripcion_habilidad_personal.Name = "descripcion_habilidad_personal";
            this.descripcion_habilidad_personal.ReadOnly = true;
            this.descripcion_habilidad_personal.Visible = false;
            // 
            // comentarios_habilidad_personal
            // 
            this.comentarios_habilidad_personal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comentarios_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle3;
            this.comentarios_habilidad_personal.HeaderText = "Comentarios";
            this.comentarios_habilidad_personal.Name = "comentarios_habilidad_personal";
            // 
            // nivel_habilidad_personal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nivel_habilidad_personal.DefaultCellStyle = dataGridViewCellStyle4;
            this.nivel_habilidad_personal.HeaderText = "Nivel de desempeño observado";
            this.nivel_habilidad_personal.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.nivel_habilidad_personal.Name = "nivel_habilidad_personal";
            this.nivel_habilidad_personal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nivel_habilidad_personal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nivel_habilidad_personal.Width = 180;
            // 
            // FrmEvaluarTopicosHabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 441);
            this.Controls.Add(this.DgvHabilidades);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEvaluarTopicosHabilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluar topicos de habilidad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEvaluarTopicosHabilidad_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTipoHabilidad;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblAvance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblPuntuacion;
        private System.Windows.Forms.TextBox TxtHabilidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgvHabilidades;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_habilidad_personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios_habilidad_personal;
        private System.Windows.Forms.DataGridViewComboBoxColumn nivel_habilidad_personal;
    }
}
namespace CB
{
    partial class FrmRealizarEncuesta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtUsuarioEncuestado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxttDescripcion = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblAvance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtRealizadaPor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFechaCaducidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtEncuesta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DgvPreguntas = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pregunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.respuesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rango_minimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rango_maximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPreguntas)).BeginInit();
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
            this.label4.Size = new System.Drawing.Size(1191, 23);
            this.label4.TabIndex = 105;
            this.label4.Text = " ENCUESTA ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtUsuarioEncuestado);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TxttDescripcion);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.TxtRealizadaPor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtFechaCaducidad);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtEncuesta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1191, 159);
            this.panel1.TabIndex = 106;
            // 
            // TxtUsuarioEncuestado
            // 
            this.TxtUsuarioEncuestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtUsuarioEncuestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuarioEncuestado.Location = new System.Drawing.Point(105, 49);
            this.TxtUsuarioEncuestado.Name = "TxtUsuarioEncuestado";
            this.TxtUsuarioEncuestado.ReadOnly = true;
            this.TxtUsuarioEncuestado.Size = new System.Drawing.Size(372, 29);
            this.TxtUsuarioEncuestado.TabIndex = 140;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 139;
            this.label6.Text = "Aplicada a:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1191, 23);
            this.label5.TabIndex = 138;
            this.label5.Text = "DESCRIPCION:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxttDescripcion
            // 
            this.TxttDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxttDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxttDescripcion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxttDescripcion.Enabled = false;
            this.TxttDescripcion.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.TxttDescripcion.Location = new System.Drawing.Point(0, 108);
            this.TxttDescripcion.Multiline = true;
            this.TxttDescripcion.Name = "TxttDescripcion";
            this.TxttDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxttDescripcion.Size = new System.Drawing.Size(1191, 51);
            this.TxttDescripcion.TabIndex = 110;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.LblAvance);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(1035, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(153, 52);
            this.panel3.TabIndex = 137;
            // 
            // LblAvance
            // 
            this.LblAvance.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblAvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAvance.Location = new System.Drawing.Point(0, 16);
            this.LblAvance.Name = "LblAvance";
            this.LblAvance.Size = new System.Drawing.Size(153, 41);
            this.LblAvance.TabIndex = 137;
            this.LblAvance.Text = "0/N";
            this.LblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 16);
            this.label7.TabIndex = 138;
            this.label7.Text = "Avance";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtRealizadaPor
            // 
            this.TxtRealizadaPor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtRealizadaPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRealizadaPor.Location = new System.Drawing.Point(576, 49);
            this.TxtRealizadaPor.Name = "TxtRealizadaPor";
            this.TxtRealizadaPor.ReadOnly = true;
            this.TxtRealizadaPor.Size = new System.Drawing.Size(372, 29);
            this.TxtRealizadaPor.TabIndex = 135;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(483, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 134;
            this.label3.Text = "Aplicada por:";
            // 
            // TxtFechaCaducidad
            // 
            this.TxtFechaCaducidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFechaCaducidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaCaducidad.Location = new System.Drawing.Point(576, 14);
            this.TxtFechaCaducidad.Name = "TxtFechaCaducidad";
            this.TxtFechaCaducidad.ReadOnly = true;
            this.TxtFechaCaducidad.Size = new System.Drawing.Size(372, 29);
            this.TxtFechaCaducidad.TabIndex = 133;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(488, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 132;
            this.label2.Text = "Vencimiento:";
            // 
            // TxtEncuesta
            // 
            this.TxtEncuesta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtEncuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEncuesta.Location = new System.Drawing.Point(105, 14);
            this.TxtEncuesta.Name = "TxtEncuesta";
            this.TxtEncuesta.ReadOnly = true;
            this.TxtEncuesta.Size = new System.Drawing.Size(372, 29);
            this.TxtEncuesta.TabIndex = 131;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encuesta:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnFinalizar);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 520);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1191, 69);
            this.panel2.TabIndex = 107;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(930, 0);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(124, 69);
            this.BtnFinalizar.TabIndex = 133;
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
            this.BtnSalir.Location = new System.Drawing.Point(1054, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 69);
            this.BtnSalir.TabIndex = 132;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // DgvPreguntas
            // 
            this.DgvPreguntas.AllowUserToAddRows = false;
            this.DgvPreguntas.AllowUserToResizeRows = false;
            this.DgvPreguntas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPreguntas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPreguntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.pregunta,
            this.tipo,
            this.respuesta,
            this.rango_minimo,
            this.rango_maximo});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPreguntas.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvPreguntas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPreguntas.Location = new System.Drawing.Point(0, 211);
            this.DgvPreguntas.Name = "DgvPreguntas";
            this.DgvPreguntas.RowHeadersVisible = false;
            this.DgvPreguntas.Size = new System.Drawing.Size(1191, 309);
            this.DgvPreguntas.TabIndex = 108;
            this.DgvPreguntas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPreguntas_CellEndEdit);
            this.DgvPreguntas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvPreguntas_EditingControlShowing);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Navy;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1191, 29);
            this.label8.TabIndex = 109;
            this.label8.Text = "PREGUNTAS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 60;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 60;
            // 
            // pregunta
            // 
            this.pregunta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pregunta.HeaderText = "Pregunta";
            this.pregunta.Name = "pregunta";
            this.pregunta.ReadOnly = true;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Visible = false;
            // 
            // respuesta
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.respuesta.DefaultCellStyle = dataGridViewCellStyle3;
            this.respuesta.HeaderText = "Respuesta";
            this.respuesta.MinimumWidth = 350;
            this.respuesta.Name = "respuesta";
            this.respuesta.Width = 350;
            // 
            // rango_minimo
            // 
            this.rango_minimo.HeaderText = "Rango mínimo";
            this.rango_minimo.Name = "rango_minimo";
            this.rango_minimo.ReadOnly = true;
            this.rango_minimo.Visible = false;
            // 
            // rango_maximo
            // 
            this.rango_maximo.HeaderText = "Rango máximo";
            this.rango_maximo.Name = "rango_maximo";
            this.rango_maximo.ReadOnly = true;
            this.rango_maximo.Visible = false;
            // 
            // FrmRealizarEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 589);
            this.Controls.Add(this.DgvPreguntas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Name = "FrmRealizarEncuesta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Realizar encuesta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRealizarEncuesta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPreguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtEncuesta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRealizadaPor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFechaCaducidad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgvPreguntas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblAvance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxttDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtUsuarioEncuestado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pregunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn respuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn rango_minimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rango_maximo;
    }
}
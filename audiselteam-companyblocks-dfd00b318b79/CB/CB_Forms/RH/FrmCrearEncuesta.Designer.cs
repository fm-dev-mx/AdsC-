namespace CB
{
    partial class FrmCrearEncuesta
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
            this.components = new System.ComponentModel.Container();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtFechaCaducidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumDiasCaducidad = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbPlantillas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DgvUsuarios = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnGlobal = new System.Windows.Forms.Button();
            this.BtnUsuario = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.ToolTipGeneral = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDiasCaducidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(862, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "CREAR NUEVA ENCUESTA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtFechaCaducidad);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NumDiasCaducidad);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CmbPlantillas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 64);
            this.panel1.TabIndex = 7;
            // 
            // TxtFechaCaducidad
            // 
            this.TxtFechaCaducidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFechaCaducidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaCaducidad.Location = new System.Drawing.Point(576, 26);
            this.TxtFechaCaducidad.Name = "TxtFechaCaducidad";
            this.TxtFechaCaducidad.ReadOnly = true;
            this.TxtFechaCaducidad.Size = new System.Drawing.Size(240, 29);
            this.TxtFechaCaducidad.TabIndex = 130;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(573, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 129;
            this.label2.Text = "La encuesta termina el:";
            // 
            // NumDiasCaducidad
            // 
            this.NumDiasCaducidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumDiasCaducidad.Location = new System.Drawing.Point(416, 27);
            this.NumDiasCaducidad.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.NumDiasCaducidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumDiasCaducidad.Name = "NumDiasCaducidad";
            this.NumDiasCaducidad.Size = new System.Drawing.Size(108, 29);
            this.NumDiasCaducidad.TabIndex = 128;
            this.NumDiasCaducidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumDiasCaducidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumDiasCaducidad.ValueChanged += new System.EventHandler(this.NumDiasCaducidad_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(413, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 127;
            this.label7.Text = "Caducidad (días)";
            // 
            // CmbPlantillas
            // 
            this.CmbPlantillas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPlantillas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPlantillas.FormattingEnabled = true;
            this.CmbPlantillas.Location = new System.Drawing.Point(12, 26);
            this.CmbPlantillas.Name = "CmbPlantillas";
            this.CmbPlantillas.Size = new System.Drawing.Size(350, 32);
            this.CmbPlantillas.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una plantilla";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(862, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "DETALLES DE LA ENCUESTA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvUsuarios
            // 
            this.DgvUsuarios.AllowUserToAddRows = false;
            this.DgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre});
            this.DgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvUsuarios.Location = new System.Drawing.Point(0, 75);
            this.DgvUsuarios.Name = "DgvUsuarios";
            this.DgvUsuarios.RowHeadersVisible = false;
            this.DgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvUsuarios.Size = new System.Drawing.Size(439, 192);
            this.DgvUsuarios.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 70;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtComentarios);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(445, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 267);
            this.panel2.TabIndex = 18;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtComentarios.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(0, 23);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentarios.Size = new System.Drawing.Size(417, 244);
            this.TxtComentarios.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(417, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "COMENTARIOS:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(862, 267);
            this.panel3.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DgvUsuarios);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(439, 267);
            this.panel4.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BtnLimpiar);
            this.panel6.Controls.Add(this.BtnGlobal);
            this.panel6.Controls.Add(this.BtnUsuario);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 23);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(439, 52);
            this.panel6.TabIndex = 22;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnLimpiar.Image = global::CB_Base.Properties.Resources.clean_image;
            this.BtnLimpiar.Location = new System.Drawing.Point(134, 0);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(67, 52);
            this.BtnLimpiar.TabIndex = 19;
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnGlobal
            // 
            this.BtnGlobal.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnGlobal.Image = global::CB_Base.Properties.Resources.allUser_32;
            this.BtnGlobal.Location = new System.Drawing.Point(67, 0);
            this.BtnGlobal.Name = "BtnGlobal";
            this.BtnGlobal.Size = new System.Drawing.Size(67, 52);
            this.BtnGlobal.TabIndex = 18;
            this.BtnGlobal.UseVisualStyleBackColor = true;
            this.BtnGlobal.Click += new System.EventHandler(this.BtnGlobal_Click);
            this.BtnGlobal.MouseHover += new System.EventHandler(this.BtnGlobal_MouseHover);
            // 
            // BtnUsuario
            // 
            this.BtnUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnUsuario.Image = global::CB_Base.Properties.Resources.user_checked;
            this.BtnUsuario.Location = new System.Drawing.Point(0, 0);
            this.BtnUsuario.Name = "BtnUsuario";
            this.BtnUsuario.Size = new System.Drawing.Size(67, 52);
            this.BtnUsuario.TabIndex = 17;
            this.BtnUsuario.UseVisualStyleBackColor = true;
            this.BtnUsuario.Click += new System.EventHandler(this.BtnUsuario_Click);
            this.BtnUsuario.MouseHover += new System.EventHandler(this.BtnUsuario_MouseHover);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Navy;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(439, 23);
            this.label6.TabIndex = 21;
            this.label6.Text = "APLICAR ENCUESTA A:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.BtnFinalizar);
            this.panel5.Controls.Add(this.BtnSalir);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 377);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(862, 67);
            this.panel5.TabIndex = 20;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(601, 0);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(124, 67);
            this.BtnFinalizar.TabIndex = 131;
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
            this.BtnSalir.Location = new System.Drawing.Point(725, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 67);
            this.BtnSalir.TabIndex = 130;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmCrearEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 444);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCrearEncuesta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear encuesta";
            this.Load += new System.EventHandler(this.FrmCrearEncuesta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDiasCaducidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CmbPlantillas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumDiasCaducidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnUsuario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.TextBox TxtFechaCaducidad;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button BtnGlobal;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.ToolTip ToolTipGeneral;
    }
}
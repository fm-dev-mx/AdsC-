namespace CB
{
    partial class FrmSeguimientoEnsamble
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TxtTecnicoAsignado = new System.Windows.Forms.TextBox();
            this.LblTecnicoAsignado = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.DtFechaPromesa = new System.Windows.Forms.DateTimePicker();
            this.LblInformacion = new System.Windows.Forms.Label();
            this.LblFechaPromesa = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.LblComentarios = new System.Windows.Forms.Label();
            this.LblEstatusActual = new System.Windows.Forms.Label();
            this.CmbEstatusActual = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Location = new System.Drawing.Point(22, 332);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(152, 40);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LblTitulo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(706, 414);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(706, 23);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "SEGUIMIENTO DE ACTIVIDAD";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer2.Panel1.Controls.Add(this.TxtTecnicoAsignado);
            this.splitContainer2.Panel1.Controls.Add(this.LblTecnicoAsignado);
            this.splitContainer2.Panel1.Controls.Add(this.TxtDescripcion);
            this.splitContainer2.Panel1.Controls.Add(this.LblDescripcion);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer2.Panel2.Controls.Add(this.DtFechaPromesa);
            this.splitContainer2.Panel2.Controls.Add(this.LblInformacion);
            this.splitContainer2.Panel2.Controls.Add(this.LblFechaPromesa);
            this.splitContainer2.Panel2.Controls.Add(this.BtnGuardar);
            this.splitContainer2.Panel2.Controls.Add(this.BtnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.TxtComentarios);
            this.splitContainer2.Panel2.Controls.Add(this.LblComentarios);
            this.splitContainer2.Panel2.Controls.Add(this.LblEstatusActual);
            this.splitContainer2.Panel2.Controls.Add(this.CmbEstatusActual);
            this.splitContainer2.Size = new System.Drawing.Size(706, 385);
            this.splitContainer2.SplitterDistance = 348;
            this.splitContainer2.TabIndex = 0;
            // 
            // TxtTecnicoAsignado
            // 
            this.TxtTecnicoAsignado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTecnicoAsignado.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.TxtTecnicoAsignado.Location = new System.Drawing.Point(12, 192);
            this.TxtTecnicoAsignado.Name = "TxtTecnicoAsignado";
            this.TxtTecnicoAsignado.ReadOnly = true;
            this.TxtTecnicoAsignado.Size = new System.Drawing.Size(321, 24);
            this.TxtTecnicoAsignado.TabIndex = 2;
            // 
            // LblTecnicoAsignado
            // 
            this.LblTecnicoAsignado.AutoSize = true;
            this.LblTecnicoAsignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblTecnicoAsignado.Location = new System.Drawing.Point(12, 176);
            this.LblTecnicoAsignado.Name = "LblTecnicoAsignado";
            this.LblTecnicoAsignado.Size = new System.Drawing.Size(95, 13);
            this.LblTecnicoAsignado.TabIndex = 2;
            this.LblTecnicoAsignado.Text = "Técnico asignado:";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.TxtDescripcion.Location = new System.Drawing.Point(12, 32);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ReadOnly = true;
            this.TxtDescripcion.Size = new System.Drawing.Size(324, 120);
            this.TxtDescripcion.TabIndex = 0;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblDescripcion.Location = new System.Drawing.Point(12, 16);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.LblDescripcion.TabIndex = 0;
            this.LblDescripcion.Text = "Descripción:";
            // 
            // DtFechaPromesa
            // 
            this.DtFechaPromesa.CustomFormat = "MMM dd, yyyy hh:mm:ss tt";
            this.DtFechaPromesa.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.DtFechaPromesa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFechaPromesa.Location = new System.Drawing.Point(22, 250);
            this.DtFechaPromesa.Name = "DtFechaPromesa";
            this.DtFechaPromesa.Size = new System.Drawing.Size(318, 24);
            this.DtFechaPromesa.TabIndex = 11;
            // 
            // LblInformacion
            // 
            this.LblInformacion.AutoSize = true;
            this.LblInformacion.Enabled = false;
            this.LblInformacion.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.LblInformacion.ForeColor = System.Drawing.Color.Red;
            this.LblInformacion.Location = new System.Drawing.Point(19, 288);
            this.LblInformacion.Name = "LblInformacion";
            this.LblInformacion.Size = new System.Drawing.Size(76, 16);
            this.LblInformacion.TabIndex = 10;
            this.LblInformacion.Text = "Información";
            this.LblInformacion.Visible = false;
            // 
            // LblFechaPromesa
            // 
            this.LblFechaPromesa.AutoSize = true;
            this.LblFechaPromesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblFechaPromesa.Location = new System.Drawing.Point(19, 233);
            this.LblFechaPromesa.Name = "LblFechaPromesa";
            this.LblFechaPromesa.Size = new System.Drawing.Size(86, 13);
            this.LblFechaPromesa.TabIndex = 7;
            this.LblFechaPromesa.Text = "Fecha promesa: ";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnGuardar.Location = new System.Drawing.Point(188, 332);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(152, 40);
            this.BtnGuardar.TabIndex = 6;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.TxtComentarios.Location = new System.Drawing.Point(16, 92);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(324, 120);
            this.TxtComentarios.TabIndex = 4;
            // 
            // LblComentarios
            // 
            this.LblComentarios.AutoSize = true;
            this.LblComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblComentarios.Location = new System.Drawing.Point(19, 76);
            this.LblComentarios.Name = "LblComentarios";
            this.LblComentarios.Size = new System.Drawing.Size(142, 13);
            this.LblComentarios.TabIndex = 2;
            this.LblComentarios.Text = "Comentarios de seguimiento:";
            // 
            // LblEstatusActual
            // 
            this.LblEstatusActual.AutoSize = true;
            this.LblEstatusActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblEstatusActual.Location = new System.Drawing.Point(19, 16);
            this.LblEstatusActual.Name = "LblEstatusActual";
            this.LblEstatusActual.Size = new System.Drawing.Size(77, 13);
            this.LblEstatusActual.TabIndex = 1;
            this.LblEstatusActual.Text = "Estatus actual:";
            // 
            // CmbEstatusActual
            // 
            this.CmbEstatusActual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstatusActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CmbEstatusActual.FormattingEnabled = true;
            this.CmbEstatusActual.Items.AddRange(new object[] {
            "PENDIENTE",
            "EN PROCESO",
            "TERMINADO",
            "DETENIDO"});
            this.CmbEstatusActual.Location = new System.Drawing.Point(16, 32);
            this.CmbEstatusActual.Name = "CmbEstatusActual";
            this.CmbEstatusActual.Size = new System.Drawing.Size(318, 32);
            this.CmbEstatusActual.TabIndex = 3;
            // 
            // FrmSeguimientoEnsamble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(706, 414);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeguimientoEnsamble";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSeguimientoEnsamble";
            this.Load += new System.EventHandler(this.FrmSeguimientoEnsamble_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox TxtTecnicoAsignado;
        private System.Windows.Forms.Label LblTecnicoAsignado;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label LblComentarios;
        private System.Windows.Forms.Label LblEstatusActual;
        private System.Windows.Forms.ComboBox CmbEstatusActual;
        private System.Windows.Forms.Label LblFechaPromesa;
        private System.Windows.Forms.Label LblInformacion;
        private System.Windows.Forms.DateTimePicker DtFechaPromesa;
    }
}
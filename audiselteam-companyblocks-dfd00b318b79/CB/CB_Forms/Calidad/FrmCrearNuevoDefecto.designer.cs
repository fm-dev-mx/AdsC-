namespace CB
{
    partial class FrmCrearNuevoDefecto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CmbTipoDefecto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbProceso = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NumOK = new System.Windows.Forms.NumericUpDown();
            this.NumNOK = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnRechazar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumNOK)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtComentarios);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.audiselTituloForm1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 464);
            this.panel1.TabIndex = 0;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(0, 228);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TxtComentarios.Size = new System.Drawing.Size(489, 185);
            this.TxtComentarios.TabIndex = 2;
            this.TxtComentarios.TextChanged += new System.EventHandler(this.TxtComentarios_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CmbTipoDefecto);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.CmbProceso);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.NumOK);
            this.panel2.Controls.Add(this.NumNOK);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(489, 205);
            this.panel2.TabIndex = 15;
            // 
            // CmbTipoDefecto
            // 
            this.CmbTipoDefecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoDefecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoDefecto.FormattingEnabled = true;
            this.CmbTipoDefecto.Location = new System.Drawing.Point(190, 53);
            this.CmbTipoDefecto.Name = "CmbTipoDefecto";
            this.CmbTipoDefecto.Size = new System.Drawing.Size(287, 28);
            this.CmbTipoDefecto.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tipo de defecto encontrado:";
            // 
            // CmbProceso
            // 
            this.CmbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProceso.FormattingEnabled = true;
            this.CmbProceso.Location = new System.Drawing.Point(190, 9);
            this.CmbProceso.Name = "CmbProceso";
            this.CmbProceso.Size = new System.Drawing.Size(287, 28);
            this.CmbProceso.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Seleccionar proceso:";
            // 
            // NumOK
            // 
            this.NumOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NumOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOK.Location = new System.Drawing.Point(357, 98);
            this.NumOK.Name = "NumOK";
            this.NumOK.Size = new System.Drawing.Size(120, 29);
            this.NumOK.TabIndex = 17;
            this.NumOK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NumNOK
            // 
            this.NumNOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.NumNOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumNOK.Location = new System.Drawing.Point(357, 144);
            this.NumNOK.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumNOK.Name = "NumNOK";
            this.NumNOK.Size = new System.Drawing.Size(120, 29);
            this.NumNOK.TabIndex = 16;
            this.NumNOK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumNOK.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkRed;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(489, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "DETALLES DEL DEFECTO ENCONTRADO:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cantidad de piezas aceptadas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Cantidad de piezas rechazadas:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnRechazar);
            this.panel3.Controls.Add(this.BtnAceptar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 413);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(489, 51);
            this.panel3.TabIndex = 2;
            // 
            // BtnRechazar
            // 
            this.BtnRechazar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRechazar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnRechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRechazar.Location = new System.Drawing.Point(231, 0);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(129, 51);
            this.BtnRechazar.TabIndex = 3;
            this.BtnRechazar.Text = "     Cancelar";
            this.BtnRechazar.UseVisualStyleBackColor = true;
            this.BtnRechazar.Click += new System.EventHandler(this.BtnRechazar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Enabled = false;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(360, 0);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(129, 51);
            this.BtnAceptar.TabIndex = 4;
            this.BtnAceptar.Text = "    Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(489, 23);
            this.audiselTituloForm1.TabIndex = 16;
            this.audiselTituloForm1.Text = "CREAR NUEVO DEFECTO";
            // 
            // FrmCrearNuevoDefecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 464);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCrearNuevoDefecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cantidad";
            this.Load += new System.EventHandler(this.FrmAgregarProcesoNoConforme_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumNOK)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnRechazar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumOK;
        private System.Windows.Forms.NumericUpDown NumNOK;
        private System.Windows.Forms.ComboBox CmbTipoDefecto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbProceso;
        private System.Windows.Forms.Label label5;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
    }
}
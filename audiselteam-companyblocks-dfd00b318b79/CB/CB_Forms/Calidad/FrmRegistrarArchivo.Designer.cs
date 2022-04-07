namespace CB
{
    partial class FrmRegistrarArchivo
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblNombreArchivo = new System.Windows.Forms.Label();
            this.BtnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtRevision = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCreador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FDArchivo = new System.Windows.Forms.OpenFileDialog();
            this.BtnRevision = new System.Windows.Forms.Button();
            this.BtnCreador = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(639, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "REGISTRAR DOCUMENTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // LblNombreArchivo
            // 
            this.LblNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreArchivo.Location = new System.Drawing.Point(121, 38);
            this.LblNombreArchivo.Name = "LblNombreArchivo";
            this.LblNombreArchivo.Size = new System.Drawing.Size(509, 24);
            this.LblNombreArchivo.TabIndex = 12;
            this.LblNombreArchivo.Text = "archivo";
            // 
            // BtnSeleccionarArchivo
            // 
            this.BtnSeleccionarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarArchivo.Location = new System.Drawing.Point(7, 34);
            this.BtnSeleccionarArchivo.Name = "BtnSeleccionarArchivo";
            this.BtnSeleccionarArchivo.Size = new System.Drawing.Size(108, 32);
            this.BtnSeleccionarArchivo.TabIndex = 11;
            this.BtnSeleccionarArchivo.Text = "Abrir";
            this.BtnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.BtnSeleccionarArchivo.Click += new System.EventHandler(this.BtnSeleccionarArchivo_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(633, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "Seleccionar documento:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnSeleccionarArchivo);
            this.panel1.Controls.Add(this.LblNombreArchivo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 69);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtRevision);
            this.panel2.Controls.Add(this.BtnRevision);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TxtCreador);
            this.panel2.Controls.Add(this.BtnCreador);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(639, 125);
            this.panel2.TabIndex = 16;
            // 
            // TxtRevision
            // 
            this.TxtRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRevision.Location = new System.Drawing.Point(63, 93);
            this.TxtRevision.Name = "TxtRevision";
            this.TxtRevision.Size = new System.Drawing.Size(567, 26);
            this.TxtRevision.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(635, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Seleccionar usuario de revisión:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtCreador
            // 
            this.TxtCreador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCreador.Location = new System.Drawing.Point(63, 31);
            this.TxtCreador.Name = "TxtCreador";
            this.TxtCreador.Size = new System.Drawing.Size(567, 26);
            this.TxtCreador.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(632, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Seleccionar creador del documento:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TxtComentarios);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 217);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(639, 100);
            this.panel3.TabIndex = 17;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(7, 23);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(623, 77);
            this.TxtComentarios.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(635, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Comentarios de revisión:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FDArchivo
            // 
            this.FDArchivo.FileName = "openFileDialog1";
            // 
            // BtnRevision
            // 
            this.BtnRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRevision.Image = global::CB_Base.Properties.Resources.user_checked;
            this.BtnRevision.Location = new System.Drawing.Point(7, 88);
            this.BtnRevision.Name = "BtnRevision";
            this.BtnRevision.Size = new System.Drawing.Size(51, 34);
            this.BtnRevision.TabIndex = 21;
            this.BtnRevision.UseVisualStyleBackColor = true;
            this.BtnRevision.Click += new System.EventHandler(this.BtnRevision_Click);
            // 
            // BtnCreador
            // 
            this.BtnCreador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreador.Image = global::CB_Base.Properties.Resources.user_checked;
            this.BtnCreador.Location = new System.Drawing.Point(7, 26);
            this.BtnCreador.Name = "BtnCreador";
            this.BtnCreador.Size = new System.Drawing.Size(51, 34);
            this.BtnCreador.TabIndex = 18;
            this.BtnCreador.UseVisualStyleBackColor = true;
            this.BtnCreador.Click += new System.EventHandler(this.BtnCreador_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(382, 327);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(121, 53);
            this.BtnCancelar.TabIndex = 10;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(509, 327);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(121, 53);
            this.BtnAceptar.TabIndex = 9;
            this.BtnAceptar.Text = "     Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // FrmRegistrarArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 384);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistrarArchivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar documento";
            this.Load += new System.EventHandler(this.FrmRegistrarArchivo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label LblNombreArchivo;
        private System.Windows.Forms.Button BtnSeleccionarArchivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxtRevision;
        private System.Windows.Forms.Button BtnRevision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCreador;
        private System.Windows.Forms.Button BtnCreador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog FDArchivo;
    }
}
namespace CB
{
    partial class FrmAgregarPoliticaCalidad
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
            this.FDArchivo = new System.Windows.Forms.OpenFileDialog();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtRevision = new System.Windows.Forms.TextBox();
            this.BtnRevision = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCreador = new System.Windows.Forms.TextBox();
            this.BtnCreador = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtPolitica = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FDArchivo
            // 
            this.FDArchivo.FileName = "openFileDialog1";
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(509, 370);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(121, 53);
            this.BtnAceptar.TabIndex = 19;
            this.BtnAceptar.Text = "     Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TxtComentarios);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 264);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(636, 100);
            this.panel3.TabIndex = 23;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(6, 23);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(624, 77);
            this.TxtComentarios.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(630, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Comentarios de revisión:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 125);
            this.panel2.TabIndex = 22;
            // 
            // TxtRevision
            // 
            this.TxtRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRevision.Location = new System.Drawing.Point(63, 93);
            this.TxtRevision.Name = "TxtRevision";
            this.TxtRevision.Size = new System.Drawing.Size(567, 26);
            this.TxtRevision.TabIndex = 20;
            // 
            // BtnRevision
            // 
            this.BtnRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRevision.Image = global::CB_Base.Properties.Resources.user_checked;
            this.BtnRevision.Location = new System.Drawing.Point(6, 88);
            this.BtnRevision.Name = "BtnRevision";
            this.BtnRevision.Size = new System.Drawing.Size(51, 34);
            this.BtnRevision.TabIndex = 21;
            this.BtnRevision.UseVisualStyleBackColor = true;
            this.BtnRevision.Click += new System.EventHandler(this.BtnRevision_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(636, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Seleccionar usuario de revisión:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtCreador
            // 
            this.TxtCreador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCreador.Location = new System.Drawing.Point(61, 31);
            this.TxtCreador.Name = "TxtCreador";
            this.TxtCreador.Size = new System.Drawing.Size(569, 26);
            this.TxtCreador.TabIndex = 17;
            // 
            // BtnCreador
            // 
            this.BtnCreador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreador.Image = global::CB_Base.Properties.Resources.user_checked;
            this.BtnCreador.Location = new System.Drawing.Point(4, 26);
            this.BtnCreador.Name = "BtnCreador";
            this.BtnCreador.Size = new System.Drawing.Size(51, 34);
            this.BtnCreador.TabIndex = 18;
            this.BtnCreador.UseVisualStyleBackColor = true;
            this.BtnCreador.Click += new System.EventHandler(this.BtnCreador_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(636, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Seleccionar creador de la política";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtPolitica);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 116);
            this.panel1.TabIndex = 21;
            // 
            // TxtPolitica
            // 
            this.TxtPolitica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtPolitica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPolitica.Location = new System.Drawing.Point(6, 34);
            this.TxtPolitica.Multiline = true;
            this.TxtPolitica.Name = "TxtPolitica";
            this.TxtPolitica.Size = new System.Drawing.Size(624, 77);
            this.TxtPolitica.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(630, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "Política de calidad:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(382, 370);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(121, 53);
            this.BtnCancelar.TabIndex = 20;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(636, 23);
            this.LblTitulo.TabIndex = 18;
            this.LblTitulo.Text = "REGISTRAR POLITICA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmAgregarPoliticaCalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 425);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarPoliticaCalidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Política de calidad";
            this.Load += new System.EventHandler(this.FrmAgregarPoliticaCalidad_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnRevision;
        private System.Windows.Forms.OpenFileDialog FDArchivo;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TxtRevision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCreador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnCreador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtPolitica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblTitulo;
    }
}
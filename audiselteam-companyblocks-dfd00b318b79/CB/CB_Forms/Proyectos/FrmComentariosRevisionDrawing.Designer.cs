namespace CB
{
    partial class FrmComentariosRevisionDrawing
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
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblUsuarioRevision = new System.Windows.Forms.Label();
            this.LblPlano = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PicImagenRevision = new System.Windows.Forms.PictureBox();
            this.ChkMostrarImagen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicImagenRevision)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtComentarios.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(0, 0);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ReadOnly = true;
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentarios.Size = new System.Drawing.Size(253, 441);
            this.TxtComentarios.TabIndex = 10;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(830, 23);
            this.LblTitulo.TabIndex = 9;
            this.LblTitulo.Text = "COMENTARIOS DE REVISION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseMove);
            // 
            // LblUsuarioRevision
            // 
            this.LblUsuarioRevision.BackColor = System.Drawing.SystemColors.Control;
            this.LblUsuarioRevision.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblUsuarioRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioRevision.ForeColor = System.Drawing.Color.Black;
            this.LblUsuarioRevision.Location = new System.Drawing.Point(0, 46);
            this.LblUsuarioRevision.Name = "LblUsuarioRevision";
            this.LblUsuarioRevision.Size = new System.Drawing.Size(830, 23);
            this.LblUsuarioRevision.TabIndex = 24;
            this.LblUsuarioRevision.Text = "REVISADO POR";
            this.LblUsuarioRevision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPlano
            // 
            this.LblPlano.BackColor = System.Drawing.SystemColors.Control;
            this.LblPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPlano.ForeColor = System.Drawing.Color.Black;
            this.LblPlano.Location = new System.Drawing.Point(0, 23);
            this.LblPlano.Name = "LblPlano";
            this.LblPlano.Size = new System.Drawing.Size(830, 23);
            this.LblPlano.TabIndex = 25;
            this.LblPlano.Text = "PLANO";
            this.LblPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(830, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "Comentarios de la última revisión:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 92);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TxtComentarios);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PicImagenRevision);
            this.splitContainer1.Size = new System.Drawing.Size(830, 441);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 27;
            // 
            // PicImagenRevision
            // 
            this.PicImagenRevision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicImagenRevision.Location = new System.Drawing.Point(0, 0);
            this.PicImagenRevision.Name = "PicImagenRevision";
            this.PicImagenRevision.Size = new System.Drawing.Size(573, 441);
            this.PicImagenRevision.TabIndex = 0;
            this.PicImagenRevision.TabStop = false;
            // 
            // ChkMostrarImagen
            // 
            this.ChkMostrarImagen.AutoSize = true;
            this.ChkMostrarImagen.Checked = true;
            this.ChkMostrarImagen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkMostrarImagen.Location = new System.Drawing.Point(280, 72);
            this.ChkMostrarImagen.Name = "ChkMostrarImagen";
            this.ChkMostrarImagen.Size = new System.Drawing.Size(90, 17);
            this.ChkMostrarImagen.TabIndex = 28;
            this.ChkMostrarImagen.Text = "Mostrar plano";
            this.ChkMostrarImagen.UseVisualStyleBackColor = true;
            this.ChkMostrarImagen.Visible = false;
            this.ChkMostrarImagen.CheckedChanged += new System.EventHandler(this.ChkMostrarImagen_CheckedChanged);
            // 
            // FrmComentariosRevisionDrawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 533);
            this.Controls.Add(this.ChkMostrarImagen);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblUsuarioRevision);
            this.Controls.Add(this.LblPlano);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmComentariosRevisionDrawing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comentarios de revision";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicImagenRevision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label LblUsuarioRevision;
        private System.Windows.Forms.Label LblPlano;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox PicImagenRevision;
        private System.Windows.Forms.CheckBox ChkMostrarImagen;
    }
}
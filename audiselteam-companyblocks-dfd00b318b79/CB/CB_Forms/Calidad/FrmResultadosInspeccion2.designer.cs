namespace CB
{
    partial class FrmResultadosInspeccion2
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
            this.ChkMostrarPlano = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.PicImagenRevision = new System.Windows.Forms.PictureBox();
            this.LblPlano = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.ChkMostrarImagen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicImagenRevision)).BeginInit();
            this.SuspendLayout();
            // 
            // ChkMostrarPlano
            // 
            this.ChkMostrarPlano.AutoSize = true;
            this.ChkMostrarPlano.Checked = true;
            this.ChkMostrarPlano.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkMostrarPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChkMostrarPlano.Location = new System.Drawing.Point(0, 46);
            this.ChkMostrarPlano.Name = "ChkMostrarPlano";
            this.ChkMostrarPlano.Size = new System.Drawing.Size(839, 17);
            this.ChkMostrarPlano.TabIndex = 35;
            this.ChkMostrarPlano.Text = "Mostrar plano";
            this.ChkMostrarPlano.UseVisualStyleBackColor = true;
            this.ChkMostrarPlano.Visible = false;
            this.ChkMostrarPlano.CheckedChanged += new System.EventHandler(this.ChkMostrarPlano_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TxtComentarios);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PicImagenRevision);
            this.splitContainer1.Size = new System.Drawing.Size(839, 382);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.TabIndex = 33;
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
            this.TxtComentarios.Size = new System.Drawing.Size(279, 382);
            this.TxtComentarios.TabIndex = 10;
            // 
            // PicImagenRevision
            // 
            this.PicImagenRevision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicImagenRevision.Location = new System.Drawing.Point(0, 0);
            this.PicImagenRevision.Name = "PicImagenRevision";
            this.PicImagenRevision.Size = new System.Drawing.Size(556, 382);
            this.PicImagenRevision.TabIndex = 0;
            this.PicImagenRevision.TabStop = false;
            // 
            // LblPlano
            // 
            this.LblPlano.BackColor = System.Drawing.SystemColors.Control;
            this.LblPlano.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPlano.ForeColor = System.Drawing.Color.Black;
            this.LblPlano.Location = new System.Drawing.Point(0, 23);
            this.LblPlano.Name = "LblPlano";
            this.LblPlano.Size = new System.Drawing.Size(839, 23);
            this.LblPlano.TabIndex = 31;
            this.LblPlano.Text = "PROCESO";
            this.LblPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(839, 23);
            this.LblTitulo.TabIndex = 29;
            this.LblTitulo.Text = "RESULTADO DE LA INSPECCION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChkMostrarImagen
            // 
            this.ChkMostrarImagen.AutoSize = true;
            this.ChkMostrarImagen.Checked = true;
            this.ChkMostrarImagen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkMostrarImagen.Location = new System.Drawing.Point(280, 72);
            this.ChkMostrarImagen.Name = "ChkMostrarImagen";
            this.ChkMostrarImagen.Size = new System.Drawing.Size(90, 17);
            this.ChkMostrarImagen.TabIndex = 34;
            this.ChkMostrarImagen.Text = "Mostrar plano";
            this.ChkMostrarImagen.UseVisualStyleBackColor = true;
            this.ChkMostrarImagen.Visible = false;
            // 
            // FrmResultadosInspeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 428);
            this.Controls.Add(this.ChkMostrarPlano);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LblPlano);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.ChkMostrarImagen);
            this.Name = "FrmResultadosInspeccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultado de la inspección";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmConsultarNoConformancia_Load);
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

        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox PicImagenRevision;
        private System.Windows.Forms.Label LblPlano;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.CheckBox ChkMostrarImagen;
        private System.Windows.Forms.CheckBox ChkMostrarPlano;
    }
}
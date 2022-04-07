namespace CB
{
    partial class FrmLiberarNoConformidad
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbDisposicion = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnLiberar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LblDetallesNC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(461, 23);
            this.LblTitulo.TabIndex = 12;
            this.LblTitulo.Text = "LIBERAR NO CONFORMIDAD INTERNA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CB_Base.Properties.Resources.glossy_red_icon_angle_md;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 100);
            this.label1.TabIndex = 14;
            this.label1.Text = "Asegúrate de colocar una etiqueta roja en el producto no conforme, incluyendo el " +
    "ID de trazabilidad correspondiente.\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbDisposicion
            // 
            this.CmbDisposicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDisposicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDisposicion.FormattingEnabled = true;
            this.CmbDisposicion.Items.AddRange(new object[] {
            "SCRAP",
            "REPARACION",
            "DESVIACION"});
            this.CmbDisposicion.Location = new System.Drawing.Point(27, 219);
            this.CmbDisposicion.Name = "CmbDisposicion";
            this.CmbDisposicion.Size = new System.Drawing.Size(410, 32);
            this.CmbDisposicion.TabIndex = 0;
            this.CmbDisposicion.SelectedIndexChanged += new System.EventHandler(this.CmbDisposicion_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnLiberar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 67);
            this.panel1.TabIndex = 16;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(0, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(174, 67);
            this.BtnCancelar.TabIndex = 32;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnLiberar
            // 
            this.BtnLiberar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnLiberar.Enabled = false;
            this.BtnLiberar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLiberar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnLiberar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLiberar.Location = new System.Drawing.Point(286, 0);
            this.BtnLiberar.Name = "BtnLiberar";
            this.BtnLiberar.Size = new System.Drawing.Size(175, 67);
            this.BtnLiberar.TabIndex = 31;
            this.BtnLiberar.Text = "Liberar";
            this.BtnLiberar.UseVisualStyleBackColor = true;
            this.BtnLiberar.Click += new System.EventHandler(this.BtnLiberar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 100);
            this.panel2.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Disposición del producto no conforme:";
            // 
            // LblDetallesNC
            // 
            this.LblDetallesNC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDetallesNC.Location = new System.Drawing.Point(24, 130);
            this.LblDetallesNC.Name = "LblDetallesNC";
            this.LblDetallesNC.Size = new System.Drawing.Size(413, 64);
            this.LblDetallesNC.TabIndex = 19;
            this.LblDetallesNC.Text = "DETALLES NC";
            // 
            // FrmLiberarNoConformidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 329);
            this.Controls.Add(this.LblDetallesNC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbDisposicion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLiberarNoConformidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liberar no conformidad interna";
            this.Load += new System.EventHandler(this.FrmLiberarNoConformidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbDisposicion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnLiberar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblDetallesNC;
    }
}
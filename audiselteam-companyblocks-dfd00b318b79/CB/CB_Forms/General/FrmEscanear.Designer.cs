namespace CB
{
    partial class FrmEscanear
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtEscaner = new System.Windows.Forms.TextBox();
            this.LblInstrucciones = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnSalir);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TxtEscaner);
            this.splitContainer1.Panel2.Controls.Add(this.LblInstrucciones);
            this.splitContainer1.Size = new System.Drawing.Size(807, 490);
            this.splitContainer1.SplitterDistance = 399;
            this.splitContainer1.TabIndex = 0;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(117, 45);
            this.BtnSalir.TabIndex = 1;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Visible = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::CB_Base.Properties.Resources.terminal;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(807, 399);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // TxtEscaner
            // 
            this.TxtEscaner.BackColor = System.Drawing.Color.Black;
            this.TxtEscaner.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtEscaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEscaner.ForeColor = System.Drawing.Color.Yellow;
            this.TxtEscaner.Location = new System.Drawing.Point(0, 39);
            this.TxtEscaner.Name = "TxtEscaner";
            this.TxtEscaner.Size = new System.Drawing.Size(807, 44);
            this.TxtEscaner.TabIndex = 1;
            this.TxtEscaner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtEscaner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEscaner_KeyDown);
            this.TxtEscaner.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEscaner_KeyPress);
            // 
            // LblInstrucciones
            // 
            this.LblInstrucciones.BackColor = System.Drawing.Color.Black;
            this.LblInstrucciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblInstrucciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInstrucciones.ForeColor = System.Drawing.Color.White;
            this.LblInstrucciones.Location = new System.Drawing.Point(0, 0);
            this.LblInstrucciones.Name = "LblInstrucciones";
            this.LblInstrucciones.Size = new System.Drawing.Size(807, 39);
            this.LblInstrucciones.TabIndex = 0;
            this.LblInstrucciones.Text = "ESCANEA TU GAFETE PARA CONTINUAR...";
            this.LblInstrucciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmEscanear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(807, 490);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEscanear";
            this.Text = "FrmEscanear";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEscanear_FormClosing);
            this.Load += new System.EventHandler(this.FrmEscanear_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TxtEscaner;
        private System.Windows.Forms.Label LblInstrucciones;
        private System.Windows.Forms.Button BtnSalir;
    }
}
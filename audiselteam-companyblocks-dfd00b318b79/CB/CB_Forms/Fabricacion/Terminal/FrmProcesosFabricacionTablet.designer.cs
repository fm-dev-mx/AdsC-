namespace CB_Base.CB_Forms.Fabricacion.Terminal
{
    partial class FrmProcesosFabricacionTablet
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CmbProcesos = new System.Windows.Forms.ComboBox();
            this.lblComboBox = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.LblOperador = new System.Windows.Forms.Label();
            this.TxtEscanearPlano = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PicPlano = new System.Windows.Forms.PictureBox();
            this.LblEstatusProgreso = new System.Windows.Forms.Label();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(649, 27);
            this.LblTitulo.TabIndex = 3;
            this.LblTitulo.Text = "PROCESOS DE FABRICACION ASIGNADOS";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 131);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CmbProcesos);
            this.panel3.Controls.Add(this.lblComboBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(649, 78);
            this.panel3.TabIndex = 23;
            // 
            // CmbProcesos
            // 
            this.CmbProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbProcesos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbProcesos.DropDownHeight = 206;
            this.CmbProcesos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProcesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProcesos.FormattingEnabled = true;
            this.CmbProcesos.IntegralHeight = false;
            this.CmbProcesos.ItemHeight = 42;
            this.CmbProcesos.Location = new System.Drawing.Point(0, 20);
            this.CmbProcesos.Name = "CmbProcesos";
            this.CmbProcesos.Size = new System.Drawing.Size(649, 48);
            this.CmbProcesos.TabIndex = 0;
            // 
            // lblComboBox
            // 
            this.lblComboBox.AutoSize = true;
            this.lblComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComboBox.Location = new System.Drawing.Point(0, 0);
            this.lblComboBox.Name = "lblComboBox";
            this.lblComboBox.Size = new System.Drawing.Size(190, 20);
            this.lblComboBox.TabIndex = 1;
            this.lblComboBox.Text = "Seleccione el proceso:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.LblOperador);
            this.splitContainer2.Panel1.Controls.Add(this.TxtEscanearPlano);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.BtnSalir);
            this.splitContainer2.Size = new System.Drawing.Size(649, 53);
            this.splitContainer2.SplitterDistance = 526;
            this.splitContainer2.TabIndex = 22;
            // 
            // LblOperador
            // 
            this.LblOperador.BackColor = System.Drawing.SystemColors.Control;
            this.LblOperador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOperador.ForeColor = System.Drawing.Color.Black;
            this.LblOperador.Location = new System.Drawing.Point(0, 18);
            this.LblOperador.Name = "LblOperador";
            this.LblOperador.Size = new System.Drawing.Size(526, 35);
            this.LblOperador.TabIndex = 22;
            this.LblOperador.Text = "10021 | MANUEL MARTINEZ";
            // 
            // TxtEscanearPlano
            // 
            this.TxtEscanearPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEscanearPlano.Location = new System.Drawing.Point(0, 18);
            this.TxtEscanearPlano.Name = "TxtEscanearPlano";
            this.TxtEscanearPlano.Size = new System.Drawing.Size(193, 40);
            this.TxtEscanearPlano.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Escanear plano";
            this.label3.Visible = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(119, 53);
            this.BtnSalir.TabIndex = 19;
            this.BtnSalir.Text = "       Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PicPlano);
            this.panel1.Controls.Add(this.LblEstatusProgreso);
            this.panel1.Controls.Add(this.Progreso);
            this.panel1.Location = new System.Drawing.Point(22, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 269);
            this.panel1.TabIndex = 6;
            // 
            // PicPlano
            // 
            this.PicPlano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPlano.Location = new System.Drawing.Point(0, 0);
            this.PicPlano.Name = "PicPlano";
            this.PicPlano.Size = new System.Drawing.Size(615, 217);
            this.PicPlano.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicPlano.TabIndex = 21;
            this.PicPlano.TabStop = false;
            // 
            // LblEstatusProgreso
            // 
            this.LblEstatusProgreso.BackColor = System.Drawing.Color.Black;
            this.LblEstatusProgreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblEstatusProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstatusProgreso.ForeColor = System.Drawing.Color.Lime;
            this.LblEstatusProgreso.Location = new System.Drawing.Point(0, 217);
            this.LblEstatusProgreso.Name = "LblEstatusProgreso";
            this.LblEstatusProgreso.Size = new System.Drawing.Size(615, 25);
            this.LblEstatusProgreso.TabIndex = 20;
            this.LblEstatusProgreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Progreso
            // 
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.Location = new System.Drawing.Point(0, 242);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(615, 27);
            this.Progreso.TabIndex = 19;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(121, 471);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(318, 100);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.TabIndex = 7;
            // 
            // FrmProcesosFabricacionTablet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 583);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmProcesosFabricacionTablet";
            this.Text = "Procesos de fabricación";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox CmbProcesos;
        private System.Windows.Forms.Label lblComboBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label LblOperador;
        private System.Windows.Forms.TextBox TxtEscanearPlano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblEstatusProgreso;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.PictureBox PicPlano;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
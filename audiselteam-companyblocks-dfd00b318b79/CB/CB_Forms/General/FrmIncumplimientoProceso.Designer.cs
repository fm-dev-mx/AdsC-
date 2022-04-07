namespace CB
{
    partial class FrmIncumplimientoProceso
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblMaterial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtProceso = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCodigoIncumplimiento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDetalles = new System.Windows.Forms.TextBox();
            this.BtnAsignar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CB_Base.Properties.Resources.failure_icon_23216;
            this.pictureBox1.Location = new System.Drawing.Point(10, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LblMaterial
            // 
            this.LblMaterial.BackColor = System.Drawing.Color.Maroon;
            this.LblMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMaterial.ForeColor = System.Drawing.Color.White;
            this.LblMaterial.Location = new System.Drawing.Point(0, 0);
            this.LblMaterial.Name = "LblMaterial";
            this.LblMaterial.Size = new System.Drawing.Size(728, 23);
            this.LblMaterial.TabIndex = 8;
            this.LblMaterial.Text = "INCUMPLIMIENTO EN EL PROCESO";
            this.LblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblMaterial.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblMaterial_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Proceso donde ocurre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Usuario que lo ocasiona:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(141, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(503, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Se detectó un incumplimiento dentro del proceso establecido:";
            // 
            // TxtProceso
            // 
            this.TxtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProceso.Location = new System.Drawing.Point(145, 80);
            this.TxtProceso.Name = "TxtProceso";
            this.TxtProceso.ReadOnly = true;
            this.TxtProceso.Size = new System.Drawing.Size(279, 29);
            this.TxtProceso.TabIndex = 13;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(430, 80);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.ReadOnly = true;
            this.TxtUsuario.Size = new System.Drawing.Size(291, 29);
            this.TxtUsuario.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Código del incumplimiento:";
            // 
            // TxtCodigoIncumplimiento
            // 
            this.TxtCodigoIncumplimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoIncumplimiento.Location = new System.Drawing.Point(145, 132);
            this.TxtCodigoIncumplimiento.Name = "TxtCodigoIncumplimiento";
            this.TxtCodigoIncumplimiento.ReadOnly = true;
            this.TxtCodigoIncumplimiento.Size = new System.Drawing.Size(576, 29);
            this.TxtCodigoIncumplimiento.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Detalles del incumplimiento:";
            // 
            // TxtDetalles
            // 
            this.TxtDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDetalles.Location = new System.Drawing.Point(10, 186);
            this.TxtDetalles.Multiline = true;
            this.TxtDetalles.Name = "TxtDetalles";
            this.TxtDetalles.ReadOnly = true;
            this.TxtDetalles.Size = new System.Drawing.Size(711, 111);
            this.TxtDetalles.TabIndex = 18;
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnAsignar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAsignar.Location = new System.Drawing.Point(559, 303);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(160, 53);
            this.BtnAsignar.TabIndex = 52;
            this.BtnAsignar.Text = "    Enterado";
            this.BtnAsignar.UseVisualStyleBackColor = true;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // FrmIncumplimientoProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 363);
            this.Controls.Add(this.BtnAsignar);
            this.Controls.Add(this.TxtDetalles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtCodigoIncumplimiento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.TxtProceso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblMaterial);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmIncumplimientoProceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmIncumplimientoSistema";
            this.Load += new System.EventHandler(this.FrmIncumplimientoProceso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtProceso;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCodigoIncumplimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDetalles;
        private System.Windows.Forms.Button BtnAsignar;
    }
}
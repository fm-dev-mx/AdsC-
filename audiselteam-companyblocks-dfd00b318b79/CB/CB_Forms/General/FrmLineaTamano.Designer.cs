namespace CB
{
    partial class FrmLineaTamano
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumPixeles = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.BtnSize4 = new System.Windows.Forms.Button();
            this.BtnSize3 = new System.Windows.Forms.Button();
            this.BtnSize2 = new System.Windows.Forms.Button();
            this.BtnSize1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumPixeles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Personalizar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tamaño";
            // 
            // NumPixeles
            // 
            this.NumPixeles.Location = new System.Drawing.Point(64, 269);
            this.NumPixeles.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.NumPixeles.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPixeles.Name = "NumPixeles";
            this.NumPixeles.Size = new System.Drawing.Size(78, 20);
            this.NumPixeles.TabIndex = 6;
            this.NumPixeles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Px";
            // 
            // button6
            // 
            this.button6.Image = global::CB_Base.Properties.Resources.close;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(15, 304);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 39);
            this.button6.TabIndex = 9;
            this.button6.Text = "        Cancelar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(120, 304);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 39);
            this.button5.TabIndex = 8;
            this.button5.Text = "      Aceptar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // BtnSize4
            // 
            this.BtnSize4.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSize4.Image = global::CB_Base.Properties.Resources.size4;
            this.BtnSize4.Location = new System.Drawing.Point(0, 174);
            this.BtnSize4.Name = "BtnSize4";
            this.BtnSize4.Size = new System.Drawing.Size(236, 58);
            this.BtnSize4.TabIndex = 3;
            this.BtnSize4.UseVisualStyleBackColor = true;
            this.BtnSize4.Click += new System.EventHandler(this.BtnSize4_Click);
            // 
            // BtnSize3
            // 
            this.BtnSize3.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSize3.Image = global::CB_Base.Properties.Resources.size3;
            this.BtnSize3.Location = new System.Drawing.Point(0, 116);
            this.BtnSize3.Name = "BtnSize3";
            this.BtnSize3.Size = new System.Drawing.Size(236, 58);
            this.BtnSize3.TabIndex = 2;
            this.BtnSize3.Text = "button3";
            this.BtnSize3.UseVisualStyleBackColor = true;
            this.BtnSize3.Click += new System.EventHandler(this.BtnSize3_Click);
            // 
            // BtnSize2
            // 
            this.BtnSize2.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSize2.Image = global::CB_Base.Properties.Resources.size2;
            this.BtnSize2.Location = new System.Drawing.Point(0, 58);
            this.BtnSize2.Name = "BtnSize2";
            this.BtnSize2.Size = new System.Drawing.Size(236, 58);
            this.BtnSize2.TabIndex = 1;
            this.BtnSize2.UseVisualStyleBackColor = true;
            this.BtnSize2.Click += new System.EventHandler(this.BtnSize2_Click);
            // 
            // BtnSize1
            // 
            this.BtnSize1.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSize1.Image = global::CB_Base.Properties.Resources.size1;
            this.BtnSize1.Location = new System.Drawing.Point(0, 0);
            this.BtnSize1.Name = "BtnSize1";
            this.BtnSize1.Size = new System.Drawing.Size(236, 58);
            this.BtnSize1.TabIndex = 0;
            this.BtnSize1.UseVisualStyleBackColor = true;
            this.BtnSize1.Click += new System.EventHandler(this.BtnSize1_Click);
            // 
            // FrmLineaTamano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 355);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumPixeles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSize4);
            this.Controls.Add(this.BtnSize3);
            this.Controls.Add(this.BtnSize2);
            this.Controls.Add(this.BtnSize1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(252, 394);
            this.MinimumSize = new System.Drawing.Size(252, 394);
            this.Name = "FrmLineaTamano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tamaño";
            this.Load += new System.EventHandler(this.FrmLineaTamano_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumPixeles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSize1;
        private System.Windows.Forms.Button BtnSize2;
        private System.Windows.Forms.Button BtnSize3;
        private System.Windows.Forms.Button BtnSize4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumPixeles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}
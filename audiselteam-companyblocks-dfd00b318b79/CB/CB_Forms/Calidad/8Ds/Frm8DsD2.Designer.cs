namespace CB
{
    partial class Frm8DsD2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm8DsD2));
            this.TxtCuando = new System.Windows.Forms.TextBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.TxtComo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDonde = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtCuando
            // 
            this.TxtCuando.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtCuando.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCuando.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCuando.Location = new System.Drawing.Point(12, 111);
            this.TxtCuando.Multiline = true;
            this.TxtCuando.Name = "TxtCuando";
            this.TxtCuando.Size = new System.Drawing.Size(1226, 67);
            this.TxtCuando.TabIndex = 1;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "help_icon_48.png");
            this.imageList2.Images.SetKeyName(1, "correct_48.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "¿Cómo ocurre?";
            // 
            // TxtComo
            // 
            this.TxtComo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComo.Location = new System.Drawing.Point(12, 24);
            this.TxtComo.Multiline = true;
            this.TxtComo.Name = "TxtComo";
            this.TxtComo.Size = new System.Drawing.Size(1226, 67);
            this.TxtComo.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "¿Cuándo ocurre?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "¿Dónde ocurre?";
            // 
            // TxtDonde
            // 
            this.TxtDonde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtDonde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDonde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDonde.Location = new System.Drawing.Point(12, 200);
            this.TxtDonde.Multiline = true;
            this.TxtDonde.Name = "TxtDonde";
            this.TxtDonde.Size = new System.Drawing.Size(1226, 67);
            this.TxtDonde.TabIndex = 42;
            // 
            // Frm8DsD2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 643);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDonde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtCuando);
            this.Controls.Add(this.TxtComo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm8DsD2";
            this.Text = "Metodología 8D - D2 Describir el problema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCuando;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtComo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDonde;
    }
}
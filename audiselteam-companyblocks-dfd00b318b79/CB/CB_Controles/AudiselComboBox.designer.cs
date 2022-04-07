namespace CB_Base.CB_Controles
{
    partial class AudiselComboBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CmbDatos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CmbDatos
            // 
            this.CmbDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbDatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDatos.FormattingEnabled = true;
            this.CmbDatos.Items.AddRange(new object[] {
            "TODOS"});
            this.CmbDatos.Location = new System.Drawing.Point(0, 0);
            this.CmbDatos.Name = "CmbDatos";
            this.CmbDatos.Size = new System.Drawing.Size(271, 32);
            this.CmbDatos.TabIndex = 0;
            // 
            // AudiselComboBox
            // 
            this.AlturaFija = 32;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CmbDatos);
            this.Name = "AudiselComboBox";
            this.Size = new System.Drawing.Size(271, 32);
            this.Load += new System.EventHandler(this.AudiselComboBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbDatos;
    }
}

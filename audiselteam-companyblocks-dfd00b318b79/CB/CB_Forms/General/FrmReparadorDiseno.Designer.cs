namespace CB
{
    partial class FrmReparadorDiseno
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
            this.TxtCarpetaSeleccionada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BuscadorCarpeta = new System.Windows.Forms.FolderBrowserDialog();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnReparar = new System.Windows.Forms.Button();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.CmbNivel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumProyecto = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.NumModulo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumProyecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumModulo)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCarpetaSeleccionada
            // 
            this.TxtCarpetaSeleccionada.Location = new System.Drawing.Point(12, 28);
            this.TxtCarpetaSeleccionada.Name = "TxtCarpetaSeleccionada";
            this.TxtCarpetaSeleccionada.Size = new System.Drawing.Size(377, 20);
            this.TxtCarpetaSeleccionada.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Carpeta:";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(396, 28);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(115, 23);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar carpeta";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnReparar
            // 
            this.BtnReparar.Location = new System.Drawing.Point(396, 57);
            this.BtnReparar.Name = "BtnReparar";
            this.BtnReparar.Size = new System.Drawing.Size(115, 23);
            this.BtnReparar.TabIndex = 3;
            this.BtnReparar.Text = "Reparar";
            this.BtnReparar.UseVisualStyleBackColor = true;
            this.BtnReparar.Click += new System.EventHandler(this.BtnReparar_Click);
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.BackColor = System.Drawing.Color.Black;
            this.TxtEstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtEstatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEstatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtEstatus.Location = new System.Drawing.Point(0, 164);
            this.TxtEstatus.Multiline = true;
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtEstatus.Size = new System.Drawing.Size(528, 73);
            this.TxtEstatus.TabIndex = 7;
            // 
            // CmbNivel
            // 
            this.CmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNivel.FormattingEnabled = true;
            this.CmbNivel.Items.AddRange(new object[] {
            "MODULO",
            "PROYECTO"});
            this.CmbNivel.Location = new System.Drawing.Point(12, 75);
            this.CmbNivel.Name = "CmbNivel";
            this.CmbNivel.Size = new System.Drawing.Size(188, 21);
            this.CmbNivel.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nivel:";
            // 
            // NumProyecto
            // 
            this.NumProyecto.DecimalPlaces = 2;
            this.NumProyecto.Location = new System.Drawing.Point(13, 131);
            this.NumProyecto.Name = "NumProyecto";
            this.NumProyecto.Size = new System.Drawing.Size(80, 20);
            this.NumProyecto.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Proyecto:";
            // 
            // NumModulo
            // 
            this.NumModulo.Location = new System.Drawing.Point(99, 131);
            this.NumModulo.Name = "NumModulo";
            this.NumModulo.Size = new System.Drawing.Size(80, 20);
            this.NumModulo.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Modulo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(198, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(317, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "USAR CON CUIDADO! SE PUEDE CORROMPER EL DISENO!!!";
            // 
            // FrmReparadorDiseno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 237);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumModulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumProyecto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbNivel);
            this.Controls.Add(this.TxtEstatus);
            this.Controls.Add(this.BtnReparar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCarpetaSeleccionada);
            this.Name = "FrmReparadorDiseno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reparador de diseno mecanico";
            this.Load += new System.EventHandler(this.FrmReparadorDiseno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumProyecto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumModulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCarpetaSeleccionada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog BuscadorCarpeta;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnReparar;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.Windows.Forms.ComboBox CmbNivel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumProyecto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumModulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
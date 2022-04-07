namespace CB
{
    partial class FrmNuevoPuntoInspeccion5s
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.TxtPuntoInspeccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbEtapa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbArea = new System.Windows.Forms.ComboBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnFinalizar);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 66);
            this.panel1.TabIndex = 22;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(156, 0);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(124, 66);
            this.BtnFinalizar.TabIndex = 135;
            this.BtnFinalizar.Text = "      Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(280, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 66);
            this.BtnSalir.TabIndex = 134;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // TxtPuntoInspeccion
            // 
            this.TxtPuntoInspeccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtPuntoInspeccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPuntoInspeccion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPuntoInspeccion.Location = new System.Drawing.Point(12, 167);
            this.TxtPuntoInspeccion.Multiline = true;
            this.TxtPuntoInspeccion.Name = "TxtPuntoInspeccion";
            this.TxtPuntoInspeccion.Size = new System.Drawing.Size(394, 147);
            this.TxtPuntoInspeccion.TabIndex = 19;
            this.TxtPuntoInspeccion.TextChanged += new System.EventHandler(this.TxtPuntoInspeccion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Punto de inspección:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Etapa:";
            // 
            // CmbEtapa
            // 
            this.CmbEtapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEtapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEtapa.FormattingEnabled = true;
            this.CmbEtapa.Items.AddRange(new object[] {
            "CLASIFICAR",
            "ORDENAR",
            "LIMPIAR",
            "ESTANDARIZAR",
            "MANTENER LA DISCIPLINA"});
            this.CmbEtapa.Location = new System.Drawing.Point(12, 106);
            this.CmbEtapa.Name = "CmbEtapa";
            this.CmbEtapa.Size = new System.Drawing.Size(394, 32);
            this.CmbEtapa.TabIndex = 16;
            this.CmbEtapa.SelectedIndexChanged += new System.EventHandler(this.CmbEtapa_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Área:";
            // 
            // CmbArea
            // 
            this.CmbArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbArea.FormattingEnabled = true;
            this.CmbArea.Location = new System.Drawing.Point(12, 50);
            this.CmbArea.Name = "CmbArea";
            this.CmbArea.Size = new System.Drawing.Size(394, 32);
            this.CmbArea.TabIndex = 14;
            this.CmbArea.SelectedIndexChanged += new System.EventHandler(this.CmbArea_SelectedIndexChanged);
            this.CmbArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbArea_KeyPress);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(417, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "NUEVO PUNTO DE INSPECCION PARA 5S\'s";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmNuevoPuntoInspeccion5s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 391);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtPuntoInspeccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbEtapa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbArea);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoPuntoInspeccion5s";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo punto de inspección 5S\'s";
            this.Load += new System.EventHandler(this.FrmNuevoPuntoInspeccion5s_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbEtapa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPuntoInspeccion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
    }
}
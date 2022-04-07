namespace CB
{
    partial class FrmAuditar5S
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
            this.BtnUsuario = new System.Windows.Forms.Button();
            this.CmbResultado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtResponsable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtEtapa = new System.Windows.Forms.TextBox();
            this.TxtArea = new System.Windows.Forms.TextBox();
            this.TxtComentariosAuditor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPuntoInspeccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnFinalizar);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 60);
            this.panel1.TabIndex = 60;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(560, 0);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(124, 60);
            this.BtnFinalizar.TabIndex = 133;
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
            this.BtnSalir.Location = new System.Drawing.Point(684, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 60);
            this.BtnSalir.TabIndex = 132;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnUsuario
            // 
            this.BtnUsuario.Image = global::CB_Base.Properties.Resources.user_checked;
            this.BtnUsuario.Location = new System.Drawing.Point(764, 102);
            this.BtnUsuario.Name = "BtnUsuario";
            this.BtnUsuario.Size = new System.Drawing.Size(47, 41);
            this.BtnUsuario.TabIndex = 59;
            this.BtnUsuario.UseVisualStyleBackColor = true;
            this.BtnUsuario.Click += new System.EventHandler(this.BtnUsuario_Click);
            // 
            // CmbResultado
            // 
            this.CmbResultado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbResultado.FormattingEnabled = true;
            this.CmbResultado.Items.AddRange(new object[] {
            "BIEN",
            "MAL",
            "NO APLICA"});
            this.CmbResultado.Location = new System.Drawing.Point(417, 49);
            this.CmbResultado.Name = "CmbResultado";
            this.CmbResultado.Size = new System.Drawing.Size(192, 28);
            this.CmbResultado.TabIndex = 58;
            this.CmbResultado.SelectedIndexChanged += new System.EventHandler(this.CmbResultado_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Responsable:";
            // 
            // TxtResponsable
            // 
            this.TxtResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtResponsable.Location = new System.Drawing.Point(417, 105);
            this.TxtResponsable.Name = "TxtResponsable";
            this.TxtResponsable.ReadOnly = true;
            this.TxtResponsable.Size = new System.Drawing.Size(341, 29);
            this.TxtResponsable.TabIndex = 56;
            this.TxtResponsable.TextChanged += new System.EventHandler(this.TxtResponsable_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Resultado:";
            // 
            // TxtEtapa
            // 
            this.TxtEtapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEtapa.Location = new System.Drawing.Point(12, 105);
            this.TxtEtapa.Name = "TxtEtapa";
            this.TxtEtapa.ReadOnly = true;
            this.TxtEtapa.Size = new System.Drawing.Size(394, 29);
            this.TxtEtapa.TabIndex = 54;
            // 
            // TxtArea
            // 
            this.TxtArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtArea.Location = new System.Drawing.Point(12, 49);
            this.TxtArea.Name = "TxtArea";
            this.TxtArea.ReadOnly = true;
            this.TxtArea.Size = new System.Drawing.Size(394, 29);
            this.TxtArea.TabIndex = 53;
            // 
            // TxtComentariosAuditor
            // 
            this.TxtComentariosAuditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentariosAuditor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentariosAuditor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentariosAuditor.Location = new System.Drawing.Point(417, 161);
            this.TxtComentariosAuditor.Multiline = true;
            this.TxtComentariosAuditor.Name = "TxtComentariosAuditor";
            this.TxtComentariosAuditor.Size = new System.Drawing.Size(394, 147);
            this.TxtComentariosAuditor.TabIndex = 25;
            this.TxtComentariosAuditor.TextChanged += new System.EventHandler(this.TxtComentariosAuditor_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Notas del inspector:";
            // 
            // TxtPuntoInspeccion
            // 
            this.TxtPuntoInspeccion.BackColor = System.Drawing.SystemColors.Control;
            this.TxtPuntoInspeccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPuntoInspeccion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPuntoInspeccion.Location = new System.Drawing.Point(12, 161);
            this.TxtPuntoInspeccion.Multiline = true;
            this.TxtPuntoInspeccion.Name = "TxtPuntoInspeccion";
            this.TxtPuntoInspeccion.ReadOnly = true;
            this.TxtPuntoInspeccion.Size = new System.Drawing.Size(394, 147);
            this.TxtPuntoInspeccion.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Punto de inspección:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Etapa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Área:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(821, 23);
            this.LblTitulo.TabIndex = 9;
            this.LblTitulo.Text = "REVISAR 5S\'s";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmAuditar5S
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 377);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnUsuario);
            this.Controls.Add(this.CmbResultado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtResponsable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtEtapa);
            this.Controls.Add(this.TxtArea);
            this.Controls.Add(this.TxtComentariosAuditor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtPuntoInspeccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAuditar5S";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInspeccionar5s";
            this.Load += new System.EventHandler(this.FrmAuditar5S_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPuntoInspeccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtComentariosAuditor;
        private System.Windows.Forms.TextBox TxtArea;
        private System.Windows.Forms.TextBox TxtEtapa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtResponsable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbResultado;
        private System.Windows.Forms.Button BtnUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
    }
}
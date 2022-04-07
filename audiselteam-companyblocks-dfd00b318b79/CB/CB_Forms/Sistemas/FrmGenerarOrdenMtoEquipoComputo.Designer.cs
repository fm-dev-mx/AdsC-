namespace CB
{
    partial class FrmGenerarOrdenMtoEquipoComputo
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtPuntosReparar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CmbTiposMantenimiento = new System.Windows.Forms.ComboBox();
            this.CmbEquipos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChkBUsuarioActual = new System.Windows.Forms.CheckBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BtnSalir);
            this.panel4.Controls.Add(this.BtnFinalizar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 413);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(746, 59);
            this.panel4.TabIndex = 24;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(485, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 59);
            this.BtnSalir.TabIndex = 127;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(622, 0);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(124, 59);
            this.BtnFinalizar.TabIndex = 126;
            this.BtnFinalizar.Text = "      Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TxtPuntosReparar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 212);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(746, 260);
            this.panel3.TabIndex = 23;
            // 
            // TxtPuntosReparar
            // 
            this.TxtPuntosReparar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtPuntosReparar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPuntosReparar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPuntosReparar.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPuntosReparar.Location = new System.Drawing.Point(0, 0);
            this.TxtPuntosReparar.Multiline = true;
            this.TxtPuntosReparar.Name = "TxtPuntosReparar";
            this.TxtPuntosReparar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtPuntosReparar.Size = new System.Drawing.Size(746, 260);
            this.TxtPuntosReparar.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(746, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "DESCRIPCION DEL PROBLEMA:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CmbTiposMantenimiento);
            this.panel2.Controls.Add(this.CmbEquipos);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(746, 65);
            this.panel2.TabIndex = 21;
            // 
            // CmbTiposMantenimiento
            // 
            this.CmbTiposMantenimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTiposMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTiposMantenimiento.FormattingEnabled = true;
            this.CmbTiposMantenimiento.Location = new System.Drawing.Point(9, 25);
            this.CmbTiposMantenimiento.Name = "CmbTiposMantenimiento";
            this.CmbTiposMantenimiento.Size = new System.Drawing.Size(344, 28);
            this.CmbTiposMantenimiento.TabIndex = 18;
            this.CmbTiposMantenimiento.SelectedIndexChanged += new System.EventHandler(this.CmbTiposMantenimiento_SelectedIndexChanged);
            // 
            // CmbEquipos
            // 
            this.CmbEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEquipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEquipos.FormattingEnabled = true;
            this.CmbEquipos.Location = new System.Drawing.Point(376, 25);
            this.CmbEquipos.Name = "CmbEquipos";
            this.CmbEquipos.Size = new System.Drawing.Size(344, 28);
            this.CmbEquipos.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tipo de equipo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Seleccione el equipo:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(746, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "DATOS DEL LA ORDEN:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChkBUsuarioActual);
            this.panel1.Controls.Add(this.TxtUsuario);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 55);
            this.panel1.TabIndex = 15;
            // 
            // ChkBUsuarioActual
            // 
            this.ChkBUsuarioActual.AutoSize = true;
            this.ChkBUsuarioActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBUsuarioActual.Location = new System.Drawing.Point(576, 14);
            this.ChkBUsuarioActual.Name = "ChkBUsuarioActual";
            this.ChkBUsuarioActual.Size = new System.Drawing.Size(132, 24);
            this.ChkBUsuarioActual.TabIndex = 17;
            this.ChkBUsuarioActual.Text = "Usuario Actual";
            this.ChkBUsuarioActual.UseVisualStyleBackColor = true;
            this.ChkBUsuarioActual.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Enabled = false;
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(59, 12);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(511, 26);
            this.TxtUsuario.TabIndex = 16;
            this.TxtUsuario.TextChanged += new System.EventHandler(this.TxtUsuario_TextChanged);
            // 
            // button1
            // 
            this.button1.Image = global::CB_Base.Properties.Resources.user_checked;
            this.button1.Location = new System.Drawing.Point(9, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 46);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(746, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "QUIEN SOLICITA LA ORDEN DE TRABAJO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(746, 23);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "GENERAR ORDEN DE TRABAJO DE MANTENIMIENTO CORRECTIVO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmOrdenesTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 472);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrdenesTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de trabajo";
            this.Load += new System.EventHandler(this.FrmOrdenesTrabajo_Load);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ChkBUsuarioActual;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbTiposMantenimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbEquipos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TextBox TxtPuntosReparar;
    }
}
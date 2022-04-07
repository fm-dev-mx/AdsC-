namespace CB
{
    partial class FrmAjustarFechasProyecto
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.NuevaFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbRazonAjuste = new System.Windows.Forms.ComboBox();
            this.TxtTipoAjuste = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(12, 205);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(141, 51);
            this.BtnCancelar.TabIndex = 39;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Enabled = false;
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(480, 205);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(141, 51);
            this.BtnRegistrar.TabIndex = 38;
            this.BtnRegistrar.Text = "      Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Nueva fecha de entrega:";
            // 
            // NuevaFechaEntrega
            // 
            this.NuevaFechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NuevaFechaEntrega.Location = new System.Drawing.Point(12, 103);
            this.NuevaFechaEntrega.Name = "NuevaFechaEntrega";
            this.NuevaFechaEntrega.Size = new System.Drawing.Size(297, 26);
            this.NuevaFechaEntrega.TabIndex = 23;
            this.NuevaFechaEntrega.ValueChanged += new System.EventHandler(this.NuevaFechaEntrega_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Razón del ajuste:";
            // 
            // CmbRazonAjuste
            // 
            this.CmbRazonAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRazonAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRazonAjuste.FormattingEnabled = true;
            this.CmbRazonAjuste.Location = new System.Drawing.Point(12, 157);
            this.CmbRazonAjuste.Name = "CmbRazonAjuste";
            this.CmbRazonAjuste.Size = new System.Drawing.Size(609, 32);
            this.CmbRazonAjuste.TabIndex = 21;
            this.CmbRazonAjuste.SelectedIndexChanged += new System.EventHandler(this.CmbRazonAjuste_SelectedIndexChanged);
            // 
            // TxtTipoAjuste
            // 
            this.TxtTipoAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTipoAjuste.Location = new System.Drawing.Point(324, 103);
            this.TxtTipoAjuste.Name = "TxtTipoAjuste";
            this.TxtTipoAjuste.ReadOnly = true;
            this.TxtTipoAjuste.Size = new System.Drawing.Size(297, 26);
            this.TxtTipoAjuste.TabIndex = 20;
            this.TxtTipoAjuste.Text = "RETRASO DE N DIAS NATURALES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tipo de ajuste:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Fecha de entrega actual:";
            // 
            // FechaEntrega
            // 
            this.FechaEntrega.Enabled = false;
            this.FechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaEntrega.Location = new System.Drawing.Point(324, 51);
            this.FechaEntrega.Name = "FechaEntrega";
            this.FechaEntrega.Size = new System.Drawing.Size(297, 26);
            this.FechaEntrega.TabIndex = 17;
            // 
            // FechaInicio
            // 
            this.FechaInicio.Enabled = false;
            this.FechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaInicio.Location = new System.Drawing.Point(12, 51);
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Size = new System.Drawing.Size(297, 26);
            this.FechaInicio.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Inicio del proyecto:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(634, 23);
            this.LblTitulo.TabIndex = 14;
            this.LblTitulo.Text = "AJUSTAR FECHAS DEL PROYECTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmAjustarFechasProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 268);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NuevaFechaEntrega);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbRazonAjuste);
            this.Controls.Add(this.TxtTipoAjuste);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FechaEntrega);
            this.Controls.Add(this.FechaInicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAjustarFechasProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAjustarFechasProyecto";
            this.Load += new System.EventHandler(this.FrmAjustarFechasProyecto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaEntrega;
        private System.Windows.Forms.DateTimePicker FechaInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTipoAjuste;
        private System.Windows.Forms.ComboBox CmbRazonAjuste;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker NuevaFechaEntrega;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
    }
}
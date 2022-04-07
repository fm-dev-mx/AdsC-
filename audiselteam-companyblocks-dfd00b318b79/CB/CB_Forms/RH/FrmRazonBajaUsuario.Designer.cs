namespace CB
{
    partial class FrmRazonBajaUsuario
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
            this.BtnAsignar = new System.Windows.Forms.Button();
            this.TxtDetalles = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblMaterial = new System.Windows.Forms.Label();
            this.CmbRazonBaja = new System.Windows.Forms.ComboBox();
            this.TxtComentariosBaja = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblUsuarioBaja = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnAsignar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAsignar.Location = new System.Drawing.Point(536, 314);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(160, 53);
            this.BtnAsignar.TabIndex = 65;
            this.BtnAsignar.Text = "   Aceptar";
            this.BtnAsignar.UseVisualStyleBackColor = true;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // TxtDetalles
            // 
            this.TxtDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDetalles.Location = new System.Drawing.Point(8, 102);
            this.TxtDetalles.Multiline = true;
            this.TxtDetalles.Name = "TxtDetalles";
            this.TxtDetalles.ReadOnly = true;
            this.TxtDetalles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDetalles.Size = new System.Drawing.Size(688, 93);
            this.TxtDetalles.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Descripción de la razón de baja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 55;
            // 
            // LblMaterial
            // 
            this.LblMaterial.BackColor = System.Drawing.Color.Black;
            this.LblMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMaterial.ForeColor = System.Drawing.Color.White;
            this.LblMaterial.Location = new System.Drawing.Point(0, 0);
            this.LblMaterial.Name = "LblMaterial";
            this.LblMaterial.Size = new System.Drawing.Size(702, 23);
            this.LblMaterial.TabIndex = 54;
            this.LblMaterial.Text = "MOTIVO DE BAJA DE EMPLEADOS";
            this.LblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblMaterial.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblMaterial_MouseDown);
            // 
            // CmbRazonBaja
            // 
            this.CmbRazonBaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRazonBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRazonBaja.FormattingEnabled = true;
            this.CmbRazonBaja.Location = new System.Drawing.Point(8, 49);
            this.CmbRazonBaja.Name = "CmbRazonBaja";
            this.CmbRazonBaja.Size = new System.Drawing.Size(688, 32);
            this.CmbRazonBaja.TabIndex = 66;
            this.CmbRazonBaja.SelectedIndexChanged += new System.EventHandler(this.CmbRazonBaja_SelectedIndexChanged);
            // 
            // TxtComentariosBaja
            // 
            this.TxtComentariosBaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentariosBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentariosBaja.Location = new System.Drawing.Point(8, 216);
            this.TxtComentariosBaja.Multiline = true;
            this.TxtComentariosBaja.Name = "TxtComentariosBaja";
            this.TxtComentariosBaja.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentariosBaja.Size = new System.Drawing.Size(688, 93);
            this.TxtComentariosBaja.TabIndex = 68;
            this.TxtComentariosBaja.TextChanged += new System.EventHandler(this.TxtComentariosBaja_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Comentarios de la razón de baja:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(370, 314);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 53);
            this.BtnCancelar.TabIndex = 69;
            this.BtnCancelar.Text = "   Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblUsuarioBaja
            // 
            this.LblUsuarioBaja.AutoSize = true;
            this.LblUsuarioBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioBaja.Location = new System.Drawing.Point(5, 31);
            this.LblUsuarioBaja.Name = "LblUsuarioBaja";
            this.LblUsuarioBaja.Size = new System.Drawing.Size(258, 15);
            this.LblUsuarioBaja.TabIndex = 70;
            this.LblUsuarioBaja.Text = "Motivo por la cual se da de baja al empleado: ";
            // 
            // FrmRazonBajaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 373);
            this.Controls.Add(this.LblUsuarioBaja);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TxtComentariosBaja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbRazonBaja);
            this.Controls.Add(this.BtnAsignar);
            this.Controls.Add(this.TxtDetalles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRazonBajaUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Razones de baja de empleados";
            this.Load += new System.EventHandler(this.FrmRazonBajaUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAsignar;
        private System.Windows.Forms.TextBox TxtDetalles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblMaterial;
        private System.Windows.Forms.ComboBox CmbRazonBaja;
        private System.Windows.Forms.TextBox TxtComentariosBaja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblUsuarioBaja;
    }
}
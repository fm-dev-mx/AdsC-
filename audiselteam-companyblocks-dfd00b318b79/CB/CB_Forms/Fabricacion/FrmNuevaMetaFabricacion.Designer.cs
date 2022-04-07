namespace CB
{
    partial class FrmNuevaMetaFabricacion
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.CmbTipoEntregable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbEntregable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbProyecto = new System.Windows.Forms.ComboBox();
            this.DateFechaPromesa = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbResponsable = new System.Windows.Forms.ComboBox();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(568, 23);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "NUEVA META DE FABRICACION";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // CmbTipoEntregable
            // 
            this.CmbTipoEntregable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoEntregable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoEntregable.FormattingEnabled = true;
            this.CmbTipoEntregable.Items.AddRange(new object[] {
            "MODULO",
            "PLANO"});
            this.CmbTipoEntregable.Location = new System.Drawing.Point(11, 103);
            this.CmbTipoEntregable.Name = "CmbTipoEntregable";
            this.CmbTipoEntregable.Size = new System.Drawing.Size(244, 32);
            this.CmbTipoEntregable.TabIndex = 8;
            this.CmbTipoEntregable.SelectedIndexChanged += new System.EventHandler(this.CmbTipoEntregable_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tipo de entregable:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Entregable:";
            // 
            // CmbEntregable
            // 
            this.CmbEntregable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEntregable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEntregable.FormattingEnabled = true;
            this.CmbEntregable.Items.AddRange(new object[] {
            "MODULO",
            "PLANO"});
            this.CmbEntregable.Location = new System.Drawing.Point(11, 158);
            this.CmbEntregable.Name = "CmbEntregable";
            this.CmbEntregable.Size = new System.Drawing.Size(545, 32);
            this.CmbEntregable.TabIndex = 10;
            this.CmbEntregable.SelectedIndexChanged += new System.EventHandler(this.CmbEntregable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Proyecto:";
            // 
            // CmbProyecto
            // 
            this.CmbProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProyecto.FormattingEnabled = true;
            this.CmbProyecto.Items.AddRange(new object[] {
            "MODULO",
            "PLANO"});
            this.CmbProyecto.Location = new System.Drawing.Point(11, 47);
            this.CmbProyecto.Name = "CmbProyecto";
            this.CmbProyecto.Size = new System.Drawing.Size(545, 32);
            this.CmbProyecto.TabIndex = 12;
            this.CmbProyecto.SelectedIndexChanged += new System.EventHandler(this.CmbProyecto_SelectedIndexChanged);
            // 
            // DateFechaPromesa
            // 
            this.DateFechaPromesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFechaPromesa.Location = new System.Drawing.Point(11, 275);
            this.DateFechaPromesa.Name = "DateFechaPromesa";
            this.DateFechaPromesa.Size = new System.Drawing.Size(327, 29);
            this.DateFechaPromesa.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Responsable:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Fecha promesa:";
            // 
            // CmbResponsable
            // 
            this.CmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbResponsable.FormattingEnabled = true;
            this.CmbResponsable.Items.AddRange(new object[] {
            "MODULO",
            "PLANO"});
            this.CmbResponsable.Location = new System.Drawing.Point(11, 214);
            this.CmbResponsable.Name = "CmbResponsable";
            this.CmbResponsable.Size = new System.Drawing.Size(545, 32);
            this.CmbResponsable.TabIndex = 17;
            this.CmbResponsable.SelectedIndexChanged += new System.EventHandler(this.CmbResponsable_SelectedIndexChanged);
            // 
            // BtnCrear
            // 
            this.BtnCrear.Enabled = false;
            this.BtnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCrear.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCrear.Location = new System.Drawing.Point(396, 327);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(160, 53);
            this.BtnCrear.TabIndex = 30;
            this.BtnCrear.Text = "     Crear";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(11, 329);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 53);
            this.BtnCancelar.TabIndex = 31;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmNuevaMetaFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 389);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnCrear);
            this.Controls.Add(this.CmbResponsable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DateFechaPromesa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbProyecto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbEntregable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbTipoEntregable);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaMetaFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva meta de fabricacion";
            this.Load += new System.EventHandler(this.FrmNuevaMetaFabricacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ComboBox CmbTipoEntregable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbEntregable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbProyecto;
        private System.Windows.Forms.DateTimePicker DateFechaPromesa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbResponsable;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.Button BtnCancelar;

    }
}
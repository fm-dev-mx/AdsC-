namespace CB
{
    partial class FrmAgregarDocumento
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
            this.LblNombreArchivo = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NumMesesVencimiento = new System.Windows.Forms.NumericUpDown();
            this.BtnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.LblTipoDocumento = new System.Windows.Forms.Label();
            this.CmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.FDArchivo = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMesesVencimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblNombreArchivo);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnAceptar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NumMesesVencimiento);
            this.panel1.Controls.Add(this.BtnSeleccionarArchivo);
            this.panel1.Controls.Add(this.LblTipoDocumento);
            this.panel1.Controls.Add(this.CmbTipoDocumento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 212);
            this.panel1.TabIndex = 0;
            // 
            // LblNombreArchivo
            // 
            this.LblNombreArchivo.AutoSize = true;
            this.LblNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreArchivo.Location = new System.Drawing.Point(129, 90);
            this.LblNombreArchivo.Name = "LblNombreArchivo";
            this.LblNombreArchivo.Size = new System.Drawing.Size(71, 24);
            this.LblNombreArchivo.TabIndex = 8;
            this.LblNombreArchivo.Text = "archivo";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(200, 147);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(121, 53);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(327, 147);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(121, 53);
            this.BtnAceptar.TabIndex = 6;
            this.BtnAceptar.Text = "     Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seleccionar documento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Meses de vigencia:";
            // 
            // NumMesesVencimiento
            // 
            this.NumMesesVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.NumMesesVencimiento.Location = new System.Drawing.Point(349, 30);
            this.NumMesesVencimiento.Name = "NumMesesVencimiento";
            this.NumMesesVencimiento.Size = new System.Drawing.Size(99, 29);
            this.NumMesesVencimiento.TabIndex = 3;
            // 
            // BtnSeleccionarArchivo
            // 
            this.BtnSeleccionarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarArchivo.Location = new System.Drawing.Point(11, 88);
            this.BtnSeleccionarArchivo.Name = "BtnSeleccionarArchivo";
            this.BtnSeleccionarArchivo.Size = new System.Drawing.Size(112, 32);
            this.BtnSeleccionarArchivo.TabIndex = 2;
            this.BtnSeleccionarArchivo.Text = "Abrir";
            this.BtnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.BtnSeleccionarArchivo.Click += new System.EventHandler(this.BtnSeleccionarArchivo_Click_1);
            // 
            // LblTipoDocumento
            // 
            this.LblTipoDocumento.AutoSize = true;
            this.LblTipoDocumento.Location = new System.Drawing.Point(8, 11);
            this.LblTipoDocumento.Name = "LblTipoDocumento";
            this.LblTipoDocumento.Size = new System.Drawing.Size(165, 13);
            this.LblTipoDocumento.TabIndex = 1;
            this.LblTipoDocumento.Text = "Seleccione el tipo de documento:";
            // 
            // CmbTipoDocumento
            // 
            this.CmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CmbTipoDocumento.FormattingEnabled = true;
            this.CmbTipoDocumento.Location = new System.Drawing.Point(11, 27);
            this.CmbTipoDocumento.Name = "CmbTipoDocumento";
            this.CmbTipoDocumento.Size = new System.Drawing.Size(332, 32);
            this.CmbTipoDocumento.TabIndex = 0;
            this.CmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.CmbTipoDocumento_SelectedIndexChanged);
            this.CmbTipoDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbTipoDocumento_KeyDown);
            this.CmbTipoDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbTipoDocumento_KeyPress);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(460, 23);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "NUEVO DOCUMENTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FDArchivo
            // 
            this.FDArchivo.FileName = "openFileDialog1";
            // 
            // FrmAgregarDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 235);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarDocumento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMesesVencimiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblTipoDocumento;
        private System.Windows.Forms.ComboBox CmbTipoDocumento;
        private System.Windows.Forms.Button BtnSeleccionarArchivo;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.OpenFileDialog FDArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumMesesVencimiento;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblNombreArchivo;
    }
}
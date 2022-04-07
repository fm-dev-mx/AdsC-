namespace CB
{
    partial class FrmNuevaActividadMantenimiento
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
            this.TxtActividad = new System.Windows.Forms.TextBox();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            this.LblTitulo.Size = new System.Drawing.Size(681, 23);
            this.LblTitulo.TabIndex = 7;
            this.LblTitulo.Text = "NUEVA ACTIVIDAD";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // TxtActividad
            // 
            this.TxtActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtActividad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtActividad.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtActividad.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtActividad.Location = new System.Drawing.Point(0, 46);
            this.TxtActividad.Multiline = true;
            this.TxtActividad.Name = "TxtActividad";
            this.TxtActividad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtActividad.Size = new System.Drawing.Size(681, 110);
            this.TxtActividad.TabIndex = 1;
            this.TxtActividad.TextChanged += new System.EventHandler(this.TxtActividad_TextChanged);
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFinalizar.Location = new System.Drawing.Point(443, 3);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(108, 50);
            this.BtnFinalizar.TabIndex = 3;
            this.BtnFinalizar.Text = "      Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(557, 3);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(121, 50);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.BtnFinalizar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 56);
            this.panel1.TabIndex = 128;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(681, 23);
            this.label1.TabIndex = 129;
            this.label1.Text = "COMENTARIOS:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtComentarios.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(0, 179);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentarios.Size = new System.Drawing.Size(681, 110);
            this.TxtComentarios.TabIndex = 2;
            this.TxtComentarios.TextChanged += new System.EventHandler(this.TxtComentarios_TextChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(681, 23);
            this.label2.TabIndex = 131;
            this.label2.Text = "DESCRIPCION DE LA ACTIVIDAD:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmNuevaActividadMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 345);
            this.Controls.Add(this.TxtComentarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtActividad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaActividadMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevaActividadMantenimiento";
            this.Load += new System.EventHandler(this.FrmNuevaActividadMantenimiento_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtActividad;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label label2;
    }
}
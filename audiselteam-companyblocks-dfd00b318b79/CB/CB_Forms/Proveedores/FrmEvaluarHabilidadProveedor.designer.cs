namespace CB
{
    partial class FrmEvaluarHabilidadProveedor
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
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.LblHabilidad = new System.Windows.Forms.Label();
            this.NumCalificacion = new System.Windows.Forms.NumericUpDown();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblComentarios = new System.Windows.Forms.Label();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumCalificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(137, 176);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(131, 50);
            this.BtnCancelar.TabIndex = 18;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(274, 176);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(131, 50);
            this.BtnAceptar.TabIndex = 17;
            this.BtnAceptar.Text = "    Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // LblHabilidad
            // 
            this.LblHabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHabilidad.Location = new System.Drawing.Point(6, 35);
            this.LblHabilidad.Name = "LblHabilidad";
            this.LblHabilidad.Size = new System.Drawing.Size(202, 29);
            this.LblHabilidad.TabIndex = 16;
            this.LblHabilidad.Text = "Habilidad";
            this.LblHabilidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumCalificacion
            // 
            this.NumCalificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumCalificacion.Location = new System.Drawing.Point(289, 32);
            this.NumCalificacion.Name = "NumCalificacion";
            this.NumCalificacion.Size = new System.Drawing.Size(116, 35);
            this.NumCalificacion.TabIndex = 15;
            this.NumCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumCalificacion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(409, 23);
            this.LblTitulo.TabIndex = 14;
            this.LblTitulo.Text = "EVALUACION DE COMPETENCIA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // LblComentarios
            // 
            this.LblComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblComentarios.BackColor = System.Drawing.Color.Navy;
            this.LblComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblComentarios.ForeColor = System.Drawing.Color.White;
            this.LblComentarios.Location = new System.Drawing.Point(0, 73);
            this.LblComentarios.Name = "LblComentarios";
            this.LblComentarios.Size = new System.Drawing.Size(409, 23);
            this.LblComentarios.TabIndex = 20;
            this.LblComentarios.Text = "Comentarios:";
            this.LblComentarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.TxtComentarios.Location = new System.Drawing.Point(2, 99);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentarios.Size = new System.Drawing.Size(407, 71);
            this.TxtComentarios.TabIndex = 60;
            // 
            // FrmEvaluarHabilidadProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 230);
            this.Controls.Add(this.TxtComentarios);
            this.Controls.Add(this.LblComentarios);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.LblHabilidad);
            this.Controls.Add(this.NumCalificacion);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEvaluarHabilidadProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluar proveedor";
            this.Load += new System.EventHandler(this.FrmEvaluarHabilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumCalificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label LblHabilidad;
        private System.Windows.Forms.NumericUpDown NumCalificacion;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblComentarios;
        private System.Windows.Forms.TextBox TxtComentarios;

    }
}
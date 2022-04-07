namespace CB
{
    partial class FrmNuevaActividad
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.CmbNumProyecto = new System.Windows.Forms.ComboBox();
            this.LblInformacion = new System.Windows.Forms.Label();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.LblTipo = new System.Windows.Forms.Label();
            this.TxtDescripcionActividad = new System.Windows.Forms.TextBox();
            this.LblProyecto = new System.Windows.Forms.Label();
            this.CmbTipoActividad = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Location = new System.Drawing.Point(20, 420);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(252, 49);
            this.BtnCancelar.TabIndex = 4;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.LblTitulo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.CmbNumProyecto);
            this.splitContainer2.Panel2.Controls.Add(this.LblInformacion);
            this.splitContainer2.Panel2.Controls.Add(this.LblDescripcion);
            this.splitContainer2.Panel2.Controls.Add(this.BtnRegistrar);
            this.splitContainer2.Panel2.Controls.Add(this.LblTipo);
            this.splitContainer2.Panel2.Controls.Add(this.BtnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.TxtDescripcionActividad);
            this.splitContainer2.Panel2.Controls.Add(this.LblProyecto);
            this.splitContainer2.Panel2.Controls.Add(this.CmbTipoActividad);
            this.splitContainer2.Size = new System.Drawing.Size(555, 526);
            this.splitContainer2.SplitterDistance = 33;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(555, 28);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "NUEVA ACTIVIDAD";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // CmbNumProyecto
            // 
            this.CmbNumProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNumProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CmbNumProyecto.FormattingEnabled = true;
            this.CmbNumProyecto.Location = new System.Drawing.Point(16, 42);
            this.CmbNumProyecto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmbNumProyecto.Name = "CmbNumProyecto";
            this.CmbNumProyecto.Size = new System.Drawing.Size(526, 37);
            this.CmbNumProyecto.TabIndex = 10;
            // 
            // LblInformacion
            // 
            this.LblInformacion.AutoSize = true;
            this.LblInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInformacion.ForeColor = System.Drawing.Color.Red;
            this.LblInformacion.Location = new System.Drawing.Point(16, 380);
            this.LblInformacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblInformacion.Name = "LblInformacion";
            this.LblInformacion.Size = new System.Drawing.Size(92, 17);
            this.LblInformacion.TabIndex = 9;
            this.LblInformacion.Text = "Información";
            this.LblInformacion.Visible = false;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Location = new System.Drawing.Point(16, 172);
            this.LblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(86, 17);
            this.LblDescripcion.TabIndex = 8;
            this.LblDescripcion.Text = "Descripción:";
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnRegistrar.Location = new System.Drawing.Point(297, 420);
            this.BtnRegistrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(245, 49);
            this.BtnRegistrar.TabIndex = 7;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // LblTipo
            // 
            this.LblTipo.AutoSize = true;
            this.LblTipo.Location = new System.Drawing.Point(16, 97);
            this.LblTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Size = new System.Drawing.Size(40, 17);
            this.LblTipo.TabIndex = 6;
            this.LblTipo.Text = "Tipo:";
            // 
            // TxtDescripcionActividad
            // 
            this.TxtDescripcionActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtDescripcionActividad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcionActividad.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.TxtDescripcionActividad.Location = new System.Drawing.Point(16, 192);
            this.TxtDescripcionActividad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtDescripcionActividad.Multiline = true;
            this.TxtDescripcionActividad.Name = "TxtDescripcionActividad";
            this.TxtDescripcionActividad.Size = new System.Drawing.Size(526, 147);
            this.TxtDescripcionActividad.TabIndex = 3;
            // 
            // LblProyecto
            // 
            this.LblProyecto.AutoSize = true;
            this.LblProyecto.Location = new System.Drawing.Point(16, 22);
            this.LblProyecto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblProyecto.Name = "LblProyecto";
            this.LblProyecto.Size = new System.Drawing.Size(68, 17);
            this.LblProyecto.TabIndex = 2;
            this.LblProyecto.Text = "Proyecto:";
            // 
            // CmbTipoActividad
            // 
            this.CmbTipoActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CmbTipoActividad.FormattingEnabled = true;
            this.CmbTipoActividad.Location = new System.Drawing.Point(16, 117);
            this.CmbTipoActividad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmbTipoActividad.Name = "CmbTipoActividad";
            this.CmbTipoActividad.Size = new System.Drawing.Size(526, 37);
            this.CmbTipoActividad.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(555, 526);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // FrmNuevaActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(555, 526);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmNuevaActividad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva actividad";
            this.Load += new System.EventHandler(this.FrmNuevaActividad_Load_1);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtDescripcionActividad;
        private System.Windows.Forms.Label LblProyecto;
        private System.Windows.Forms.ComboBox CmbTipoActividad;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblTipo;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label LblInformacion;
        private System.Windows.Forms.ComboBox CmbNumProyecto;
    }
}
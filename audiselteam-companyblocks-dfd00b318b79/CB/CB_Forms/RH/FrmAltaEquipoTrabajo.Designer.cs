namespace CB
{
    partial class FrmAltaEquipoTrabajo
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
            this.PanelIntegrantes = new System.Windows.Forms.Panel();
            this.PanelUsuarioLista = new System.Windows.Forms.Panel();
            this.ChkBListaUsuarios = new System.Windows.Forms.CheckedListBox();
            this.PanelListaIntegrantes = new System.Windows.Forms.Panel();
            this.LBIntegrantes = new System.Windows.Forms.ListBox();
            this.LblIntegrantes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblLider = new System.Windows.Forms.Label();
            this.CmbLider = new System.Windows.Forms.ComboBox();
            this.LblDepartamento = new System.Windows.Forms.Label();
            this.CmbDepartamentos = new System.Windows.Forms.ComboBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.PanelBotones = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.PanelIntegrantes.SuspendLayout();
            this.PanelUsuarioLista.SuspendLayout();
            this.PanelListaIntegrantes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelIntegrantes
            // 
            this.PanelIntegrantes.Controls.Add(this.PanelUsuarioLista);
            this.PanelIntegrantes.Controls.Add(this.PanelListaIntegrantes);
            this.PanelIntegrantes.Controls.Add(this.LblIntegrantes);
            this.PanelIntegrantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelIntegrantes.Location = new System.Drawing.Point(0, 93);
            this.PanelIntegrantes.Name = "PanelIntegrantes";
            this.PanelIntegrantes.Size = new System.Drawing.Size(791, 287);
            this.PanelIntegrantes.TabIndex = 9;
            // 
            // PanelUsuarioLista
            // 
            this.PanelUsuarioLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelUsuarioLista.Controls.Add(this.ChkBListaUsuarios);
            this.PanelUsuarioLista.Location = new System.Drawing.Point(13, 23);
            this.PanelUsuarioLista.Name = "PanelUsuarioLista";
            this.PanelUsuarioLista.Size = new System.Drawing.Size(377, 264);
            this.PanelUsuarioLista.TabIndex = 10;
            // 
            // ChkBListaUsuarios
            // 
            this.ChkBListaUsuarios.CheckOnClick = true;
            this.ChkBListaUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkBListaUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBListaUsuarios.FormattingEnabled = true;
            this.ChkBListaUsuarios.IntegralHeight = false;
            this.ChkBListaUsuarios.Location = new System.Drawing.Point(0, 0);
            this.ChkBListaUsuarios.Name = "ChkBListaUsuarios";
            this.ChkBListaUsuarios.Size = new System.Drawing.Size(377, 264);
            this.ChkBListaUsuarios.TabIndex = 0;
            this.ChkBListaUsuarios.ThreeDCheckBoxes = true;
            this.ChkBListaUsuarios.SelectedIndexChanged += new System.EventHandler(this.ChkBListaUsuarios_SelectedIndexChanged);
            // 
            // PanelListaIntegrantes
            // 
            this.PanelListaIntegrantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelListaIntegrantes.Controls.Add(this.LBIntegrantes);
            this.PanelListaIntegrantes.Location = new System.Drawing.Point(400, 23);
            this.PanelListaIntegrantes.Name = "PanelListaIntegrantes";
            this.PanelListaIntegrantes.Size = new System.Drawing.Size(377, 264);
            this.PanelListaIntegrantes.TabIndex = 11;
            // 
            // LBIntegrantes
            // 
            this.LBIntegrantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBIntegrantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBIntegrantes.FormattingEnabled = true;
            this.LBIntegrantes.ItemHeight = 20;
            this.LBIntegrantes.Location = new System.Drawing.Point(0, 0);
            this.LBIntegrantes.Name = "LBIntegrantes";
            this.LBIntegrantes.Size = new System.Drawing.Size(377, 264);
            this.LBIntegrantes.TabIndex = 0;
            // 
            // LblIntegrantes
            // 
            this.LblIntegrantes.BackColor = System.Drawing.Color.Black;
            this.LblIntegrantes.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblIntegrantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIntegrantes.ForeColor = System.Drawing.Color.White;
            this.LblIntegrantes.Location = new System.Drawing.Point(0, 0);
            this.LblIntegrantes.Name = "LblIntegrantes";
            this.LblIntegrantes.Size = new System.Drawing.Size(791, 23);
            this.LblIntegrantes.TabIndex = 9;
            this.LblIntegrantes.Text = "SELECCION DE LOS INTEGRANTES DEL EQUIPO";
            this.LblIntegrantes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblLider);
            this.panel1.Controls.Add(this.CmbLider);
            this.panel1.Controls.Add(this.LblDepartamento);
            this.panel1.Controls.Add(this.CmbDepartamentos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 70);
            this.panel1.TabIndex = 0;
            // 
            // LblLider
            // 
            this.LblLider.AutoSize = true;
            this.LblLider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLider.Location = new System.Drawing.Point(397, 10);
            this.LblLider.Name = "LblLider";
            this.LblLider.Size = new System.Drawing.Size(188, 16);
            this.LblLider.TabIndex = 3;
            this.LblLider.Text = "Seleccione al lídel del equipo:";
            // 
            // CmbLider
            // 
            this.CmbLider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLider.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLider.FormattingEnabled = true;
            this.CmbLider.Location = new System.Drawing.Point(400, 29);
            this.CmbLider.Name = "CmbLider";
            this.CmbLider.Size = new System.Drawing.Size(377, 32);
            this.CmbLider.TabIndex = 2;
            this.CmbLider.SelectedIndexChanged += new System.EventHandler(this.CmbLider_SelectedIndexChanged);
            // 
            // LblDepartamento
            // 
            this.LblDepartamento.AutoSize = true;
            this.LblDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDepartamento.Location = new System.Drawing.Point(10, 10);
            this.LblDepartamento.Name = "LblDepartamento";
            this.LblDepartamento.Size = new System.Drawing.Size(180, 16);
            this.LblDepartamento.TabIndex = 1;
            this.LblDepartamento.Text = "Seleccione el departamento:";
            // 
            // CmbDepartamentos
            // 
            this.CmbDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDepartamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDepartamentos.FormattingEnabled = true;
            this.CmbDepartamentos.Location = new System.Drawing.Point(13, 29);
            this.CmbDepartamentos.Name = "CmbDepartamentos";
            this.CmbDepartamentos.Size = new System.Drawing.Size(377, 32);
            this.CmbDepartamentos.TabIndex = 0;
            this.CmbDepartamentos.SelectedIndexChanged += new System.EventHandler(this.CmbDepartamentos_SelectedIndexChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(791, 23);
            this.LblTitulo.TabIndex = 8;
            this.LblTitulo.Text = "NUEVO EQUIPO DE TRABAJO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // PanelBotones
            // 
            this.PanelBotones.Controls.Add(this.BtnCancelar);
            this.PanelBotones.Controls.Add(this.BtnAceptar);
            this.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBotones.Location = new System.Drawing.Point(0, 380);
            this.PanelBotones.Name = "PanelBotones";
            this.PanelBotones.Size = new System.Drawing.Size(791, 58);
            this.PanelBotones.TabIndex = 11;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(513, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(129, 55);
            this.BtnCancelar.TabIndex = 103;
            this.BtnCancelar.Text = "     Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(648, 0);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(129, 55);
            this.BtnAceptar.TabIndex = 102;
            this.BtnAceptar.Text = "   Guardar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // FrmAltaEquipoTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 438);
            this.Controls.Add(this.PanelIntegrantes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.PanelBotones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAltaEquipoTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de equipos de trabajo";
            this.Load += new System.EventHandler(this.FrmAltaEquipoTrabajo_Load);
            this.PanelIntegrantes.ResumeLayout(false);
            this.PanelUsuarioLista.ResumeLayout(false);
            this.PanelListaIntegrantes.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblDepartamento;
        private System.Windows.Forms.ComboBox CmbDepartamentos;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblLider;
        private System.Windows.Forms.ComboBox CmbLider;
        private System.Windows.Forms.Panel PanelIntegrantes;
        private System.Windows.Forms.Panel PanelListaIntegrantes;
        private System.Windows.Forms.Panel PanelUsuarioLista;
        private System.Windows.Forms.Label LblIntegrantes;
        private System.Windows.Forms.Panel PanelBotones;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.CheckedListBox ChkBListaUsuarios;
        private System.Windows.Forms.ListBox LBIntegrantes;
    }
}
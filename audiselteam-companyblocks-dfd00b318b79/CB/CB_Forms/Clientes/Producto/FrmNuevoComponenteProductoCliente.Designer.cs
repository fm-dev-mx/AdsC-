namespace CB
{
    partial class FrmNuevoComponenteProductoCliente
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
            this.components = new System.ComponentModel.Container();
            this.MenuVariantes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarNadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.MenuVariantes.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuVariantes
            // 
            this.MenuVariantes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarTodoToolStripMenuItem,
            this.seleccionarNadaToolStripMenuItem});
            this.MenuVariantes.Name = "MenuVariantes";
            this.MenuVariantes.Size = new System.Drawing.Size(164, 48);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo";
            // 
            // seleccionarNadaToolStripMenuItem
            // 
            this.seleccionarNadaToolStripMenuItem.Name = "seleccionarNadaToolStripMenuItem";
            this.seleccionarNadaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seleccionarNadaToolStripMenuItem.Text = "Seleccionar nada";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(12, 97);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 53);
            this.BtnCancelar.TabIndex = 47;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnCrear
            // 
            this.BtnCrear.Enabled = false;
            this.BtnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCrear.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCrear.Location = new System.Drawing.Point(266, 97);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(160, 53);
            this.BtnCrear.TabIndex = 48;
            this.BtnCrear.Text = "     Crear";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Nombre del componente:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(12, 48);
            this.TxtNombre.MaxLength = 60;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(414, 29);
            this.TxtNombre.TabIndex = 41;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(437, 23);
            this.LblTitulo.TabIndex = 37;
            this.LblTitulo.Text = "NUEVO COMPONENTE";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmNuevoComponenteProductoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 160);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnCrear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevoComponenteProductoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo componente";
            this.Load += new System.EventHandler(this.FrmNuevoComponenteProductoCliente_Load);
            this.MenuVariantes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.ContextMenuStrip MenuVariantes;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarNadaToolStripMenuItem;
    }
}
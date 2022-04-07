namespace CB
{
    partial class FrmAsignarProcesoFabricacion2
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
            this.LblMaterial = new System.Windows.Forms.Label();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustarTiemposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaOperaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BkgDescargarPlano = new System.ComponentModel.BackgroundWorker();
            this.LblTiempoEstimadoTotal = new System.Windows.Forms.Label();
            this.LblTiempoEstimado = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAsignar = new System.Windows.Forms.Button();
            this.NumProceso = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtProceso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.CmbHerramentista = new System.Windows.Forms.ComboBox();
            this.CmbMaquinas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MenuOpciones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumProceso)).BeginInit();
            this.SuspendLayout();
            // 
            // LblMaterial
            // 
            this.LblMaterial.BackColor = System.Drawing.Color.Black;
            this.LblMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMaterial.ForeColor = System.Drawing.Color.White;
            this.LblMaterial.Location = new System.Drawing.Point(0, 0);
            this.LblMaterial.Name = "LblMaterial";
            this.LblMaterial.Size = new System.Drawing.Size(426, 23);
            this.LblMaterial.TabIndex = 7;
            this.LblMaterial.Text = "ASIGNAR PROCESO DE FABRICACION";
            this.LblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblMaterial.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblMaterial_MouseDown);
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem,
            this.ajustarTiemposToolStripMenuItem,
            this.nuevaOperaciToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(165, 70);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // ajustarTiemposToolStripMenuItem
            // 
            this.ajustarTiemposToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Edit;
            this.ajustarTiemposToolStripMenuItem.Name = "ajustarTiemposToolStripMenuItem";
            this.ajustarTiemposToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.ajustarTiemposToolStripMenuItem.Text = "Ajustar tiempos";
            // 
            // nuevaOperaciToolStripMenuItem
            // 
            this.nuevaOperaciToolStripMenuItem.Image = global::CB_Base.Properties.Resources._1497748151_plus;
            this.nuevaOperaciToolStripMenuItem.Name = "nuevaOperaciToolStripMenuItem";
            this.nuevaOperaciToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.nuevaOperaciToolStripMenuItem.Text = "Nueva operación";
            // 
            // BkgDescargarPlano
            // 
            this.BkgDescargarPlano.WorkerReportsProgress = true;
            this.BkgDescargarPlano.WorkerSupportsCancellation = true;
            // 
            // LblTiempoEstimadoTotal
            // 
            this.LblTiempoEstimadoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTiempoEstimadoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTiempoEstimadoTotal.Location = new System.Drawing.Point(153, 225);
            this.LblTiempoEstimadoTotal.Name = "LblTiempoEstimadoTotal";
            this.LblTiempoEstimadoTotal.Size = new System.Drawing.Size(251, 22);
            this.LblTiempoEstimadoTotal.TabIndex = 70;
            this.LblTiempoEstimadoTotal.Text = "30 días 10 horas 15 minutos 00 segundos";
            this.LblTiempoEstimadoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTiempoEstimado
            // 
            this.LblTiempoEstimado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTiempoEstimado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTiempoEstimado.Location = new System.Drawing.Point(153, 199);
            this.LblTiempoEstimado.Name = "LblTiempoEstimado";
            this.LblTiempoEstimado.Size = new System.Drawing.Size(256, 22);
            this.LblTiempoEstimado.TabIndex = 68;
            this.LblTiempoEstimado.Text = "30 días 10 horas 30 minutos 00 segundos";
            this.LblTiempoEstimado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 22);
            this.label8.TabIndex = 72;
            this.label8.Text = "Tiempo total: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 22);
            this.label2.TabIndex = 71;
            this.label2.Text = "Tiempo por pieza:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnAsignar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 406);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 65);
            this.panel1.TabIndex = 69;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(18, 0);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(160, 53);
            this.BtnCancelar.TabIndex = 49;
            this.BtnCancelar.Text = "      Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click_1);
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Enabled = false;
            this.BtnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnAsignar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAsignar.Location = new System.Drawing.Point(254, 0);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(160, 53);
            this.BtnAsignar.TabIndex = 50;
            this.BtnAsignar.Text = "     Asignar";
            this.BtnAsignar.UseVisualStyleBackColor = true;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click_1);
            // 
            // NumProceso
            // 
            this.NumProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumProceso.Location = new System.Drawing.Point(14, 50);
            this.NumProceso.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.NumProceso.Name = "NumProceso";
            this.NumProceso.Size = new System.Drawing.Size(93, 26);
            this.NumProceso.TabIndex = 58;
            this.NumProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Tipo de proceso:";
            // 
            // TxtProceso
            // 
            this.TxtProceso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProceso.Location = new System.Drawing.Point(113, 50);
            this.TxtProceso.Name = "TxtProceso";
            this.TxtProceso.ReadOnly = true;
            this.TxtProceso.Size = new System.Drawing.Size(298, 29);
            this.TxtProceso.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 258);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Comentarios del supervisor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "Herramentista:";
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComentarios.Location = new System.Drawing.Point(14, 274);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtComentarios.Size = new System.Drawing.Size(398, 126);
            this.TxtComentarios.TabIndex = 63;
            this.TxtComentarios.TextChanged += new System.EventHandler(this.TxtComentarios_TextChanged);
            // 
            // CmbHerramentista
            // 
            this.CmbHerramentista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbHerramentista.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbHerramentista.FormattingEnabled = true;
            this.CmbHerramentista.Items.AddRange(new object[] {
            "POR PIEZA",
            "POR PAQUETE"});
            this.CmbHerramentista.Location = new System.Drawing.Point(14, 100);
            this.CmbHerramentista.Name = "CmbHerramentista";
            this.CmbHerramentista.Size = new System.Drawing.Size(397, 32);
            this.CmbHerramentista.TabIndex = 66;
            this.CmbHerramentista.SelectedIndexChanged += new System.EventHandler(this.CmbHerramentista_SelectedIndexChanged);
            // 
            // CmbMaquinas
            // 
            this.CmbMaquinas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMaquinas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMaquinas.FormattingEnabled = true;
            this.CmbMaquinas.Items.AddRange(new object[] {
            "POR PIEZA",
            "POR PAQUETE"});
            this.CmbMaquinas.Location = new System.Drawing.Point(14, 154);
            this.CmbMaquinas.Name = "CmbMaquinas";
            this.CmbMaquinas.Size = new System.Drawing.Size(397, 32);
            this.CmbMaquinas.TabIndex = 64;
            this.CmbMaquinas.SelectedIndexChanged += new System.EventHandler(this.CmbMaquinas_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Máquina herramienta:";
            // 
            // FrmAsignarProcesoFabricacion2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 471);
            this.Controls.Add(this.LblTiempoEstimadoTotal);
            this.Controls.Add(this.LblTiempoEstimado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NumProceso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtProceso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtComentarios);
            this.Controls.Add(this.CmbHerramentista);
            this.Controls.Add(this.CmbMaquinas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmAsignarProcesoFabricacion2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar proceso fabricacion";
            this.Load += new System.EventHandler(this.FrmActualizarProcesoFabricacion_Load);
            this.MenuOpciones.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumProceso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlano;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajustarTiemposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaOperaciToolStripMenuItem;
        private System.Windows.Forms.Label LblTiempoEstimadoTotal;
        private System.Windows.Forms.Label LblTiempoEstimado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAsignar;
        private System.Windows.Forms.NumericUpDown NumProceso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtProceso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.ComboBox CmbHerramentista;
        private System.Windows.Forms.ComboBox CmbMaquinas;
        private System.Windows.Forms.Label label5;
    }
}
namespace CB
{
    partial class FrmAgregarProcesoPlano2
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
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbAsignacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbProcesos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbCategorias = new System.Windows.Forms.ComboBox();
            this.LblProveedor = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BkgCrearRequisicionCompra = new System.ComponentModel.BackgroundWorker();
            this.LblStatus = new System.Windows.Forms.Label();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Location = new System.Drawing.Point(12, 243);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(337, 123);
            this.TxtComentarios.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 91;
            this.label3.Text = "Comentarios:";
            // 
            // CmbAsignacion
            // 
            this.CmbAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAsignacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAsignacion.FormattingEnabled = true;
            this.CmbAsignacion.Items.AddRange(new object[] {
            "LOCAL",
            "PROVEEDOR"});
            this.CmbAsignacion.Location = new System.Drawing.Point(12, 170);
            this.CmbAsignacion.Name = "CmbAsignacion";
            this.CmbAsignacion.Size = new System.Drawing.Size(337, 32);
            this.CmbAsignacion.TabIndex = 86;
            this.CmbAsignacion.SelectedIndexChanged += new System.EventHandler(this.CmbAsignacion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 24);
            this.label2.TabIndex = 90;
            this.label2.Text = "Tipo de asignación:";
            // 
            // CmbProcesos
            // 
            this.CmbProcesos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProcesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProcesos.FormattingEnabled = true;
            this.CmbProcesos.Location = new System.Drawing.Point(11, 100);
            this.CmbProcesos.Name = "CmbProcesos";
            this.CmbProcesos.Size = new System.Drawing.Size(338, 32);
            this.CmbProcesos.TabIndex = 85;
            this.CmbProcesos.SelectedIndexChanged += new System.EventHandler(this.CmbProcesos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 89;
            this.label1.Text = "Tipo de proceso:";
            // 
            // CmbCategorias
            // 
            this.CmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategorias.FormattingEnabled = true;
            this.CmbCategorias.Location = new System.Drawing.Point(11, 34);
            this.CmbCategorias.Name = "CmbCategorias";
            this.CmbCategorias.Size = new System.Drawing.Size(338, 32);
            this.CmbCategorias.TabIndex = 84;
            this.CmbCategorias.SelectedIndexChanged += new System.EventHandler(this.CmbCategorias_SelectedIndexChanged);
            // 
            // LblProveedor
            // 
            this.LblProveedor.AutoSize = true;
            this.LblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProveedor.Location = new System.Drawing.Point(7, 7);
            this.LblProveedor.Name = "LblProveedor";
            this.LblProveedor.Size = new System.Drawing.Size(95, 24);
            this.LblProveedor.TabIndex = 88;
            this.LblProveedor.Text = "Categoría:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(11, 438);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(157, 41);
            this.BtnCancelar.TabIndex = 93;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Enabled = false;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(186, 438);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(163, 41);
            this.BtnAgregar.TabIndex = 94;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BkgCrearRequisicionCompra
            // 
            this.BkgCrearRequisicionCompra.WorkerReportsProgress = true;
            this.BkgCrearRequisicionCompra.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgCrearRequisicionCompra_DoWork);
            this.BkgCrearRequisicionCompra.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgCrearRequisicionCompra_ProgressChanged);
            this.BkgCrearRequisicionCompra.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgCrearRequisicionCompra_RunWorkerCompleted);
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus.Location = new System.Drawing.Point(7, 373);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(71, 20);
            this.LblStatus.TabIndex = 95;
            this.LblStatus.Text = "Estatus";
            this.LblStatus.Visible = false;
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(13, 397);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(335, 23);
            this.Progreso.TabIndex = 96;
            this.Progreso.Visible = false;
            // 
            // FrmAgregarProcesoPlano2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 491);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.TxtComentarios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbAsignacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbProcesos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbCategorias);
            this.Controls.Add(this.LblProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAgregarProcesoPlano2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar proceso al plano";
            this.Load += new System.EventHandler(this.FrmAgregarProcesoPlano2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbAsignacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbProcesos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbCategorias;
        private System.Windows.Forms.Label LblProveedor;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.ComponentModel.BackgroundWorker BkgCrearRequisicionCompra;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.ProgressBar Progreso;

    }
}
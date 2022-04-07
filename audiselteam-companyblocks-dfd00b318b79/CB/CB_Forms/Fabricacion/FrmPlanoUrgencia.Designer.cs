namespace CB
{
    partial class FrmPlanoUrgencia
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
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombreArchivo = new System.Windows.Forms.TextBox();
            this.TxtEstatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.DateUrgencia = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DgvAutorizados = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_promesa_urgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicPlano = new System.Windows.Forms.PictureBox();
            this.BkgDescargarPlano = new System.ComponentModel.BackgroundWorker();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAutorizados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtId
            // 
            this.TxtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtId.Location = new System.Drawing.Point(12, 48);
            this.TxtId.Name = "TxtId";
            this.TxtId.ReadOnly = true;
            this.TxtId.Size = new System.Drawing.Size(91, 26);
            this.TxtId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Plano";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre de archivo";
            // 
            // TxtNombreArchivo
            // 
            this.TxtNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreArchivo.Location = new System.Drawing.Point(109, 48);
            this.TxtNombreArchivo.Name = "TxtNombreArchivo";
            this.TxtNombreArchivo.ReadOnly = true;
            this.TxtNombreArchivo.Size = new System.Drawing.Size(440, 26);
            this.TxtNombreArchivo.TabIndex = 3;
            // 
            // TxtEstatus
            // 
            this.TxtEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEstatus.Location = new System.Drawing.Point(342, 93);
            this.TxtEstatus.Name = "TxtEstatus";
            this.TxtEstatus.ReadOnly = true;
            this.TxtEstatus.Size = new System.Drawing.Size(207, 26);
            this.TxtEstatus.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estatus";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vista previa";
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Enabled = false;
            this.BtnConfirmar.Location = new System.Drawing.Point(442, 560);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(107, 49);
            this.BtnConfirmar.TabIndex = 7;
            this.BtnConfirmar.Text = "Solicitar urgencia";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(329, 560);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(107, 49);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // DateUrgencia
            // 
            this.DateUrgencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateUrgencia.Location = new System.Drawing.Point(12, 93);
            this.DateUrgencia.Name = "DateUrgencia";
            this.DateUrgencia.Size = new System.Drawing.Size(324, 26);
            this.DateUrgencia.TabIndex = 8;
            this.DateUrgencia.ValueChanged += new System.EventHandler(this.DateUrgencia_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "PARA CUANDO DEBE FABRICARSE EL PLANO";
            // 
            // DgvAutorizados
            // 
            this.DgvAutorizados.AllowUserToAddRows = false;
            this.DgvAutorizados.AllowUserToDeleteRows = false;
            this.DgvAutorizados.AllowUserToResizeColumns = false;
            this.DgvAutorizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAutorizados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.requisitor,
            this.fecha_promesa_urgencia});
            this.DgvAutorizados.Location = new System.Drawing.Point(12, 366);
            this.DgvAutorizados.Name = "DgvAutorizados";
            this.DgvAutorizados.RowHeadersVisible = false;
            this.DgvAutorizados.Size = new System.Drawing.Size(537, 188);
            this.DgvAutorizados.TabIndex = 10;
            // 
            // id
            // 
            this.id.HeaderText = "Plano";
            this.id.MinimumWidth = 80;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 80;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // requisitor
            // 
            this.requisitor.HeaderText = "Requisitor";
            this.requisitor.MinimumWidth = 120;
            this.requisitor.Name = "requisitor";
            this.requisitor.ReadOnly = true;
            this.requisitor.Width = 120;
            // 
            // fecha_promesa_urgencia
            // 
            this.fecha_promesa_urgencia.HeaderText = "Fecha promesa urgencia";
            this.fecha_promesa_urgencia.MinimumWidth = 120;
            this.fecha_promesa_urgencia.Name = "fecha_promesa_urgencia";
            this.fecha_promesa_urgencia.ReadOnly = true;
            this.fecha_promesa_urgencia.Width = 120;
            // 
            // PicPlano
            // 
            this.PicPlano.Location = new System.Drawing.Point(12, 138);
            this.PicPlano.Name = "PicPlano";
            this.PicPlano.Size = new System.Drawing.Size(537, 222);
            this.PicPlano.TabIndex = 11;
            this.PicPlano.TabStop = false;
            // 
            // BkgDescargarPlano
            // 
            this.BkgDescargarPlano.WorkerReportsProgress = true;
            this.BkgDescargarPlano.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgDescargarPlano_DoWork);
            this.BkgDescargarPlano.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgDescargarPlano_ProgressChanged);
            this.BkgDescargarPlano.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgDescargarPlano_RunWorkerCompleted);
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(561, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "SOLICITUD DE URGENCIA";
            // 
            // FrmPlanoUrgencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 621);
            this.Controls.Add(this.PicPlano);
            this.Controls.Add(this.DgvAutorizados);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DateUrgencia);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtEstatus);
            this.Controls.Add(this.TxtNombreArchivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPlanoUrgencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitar plano urgente";
            this.Load += new System.EventHandler(this.FrmPlanoUrgencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAutorizados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlano)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNombreArchivo;
        private System.Windows.Forms.TextBox TxtEstatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DateTimePicker DateUrgencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DgvAutorizados;
        private System.Windows.Forms.PictureBox PicPlano;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_promesa_urgencia;
    }
}
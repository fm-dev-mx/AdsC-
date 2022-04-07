namespace CB
{
    partial class FrmEnviarRFQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnviarRFQ));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CmbFormato = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbContacto = new System.Windows.Forms.ComboBox();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtProveedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDe = new System.Windows.Forms.TextBox();
            this.TxtNotas = new System.Windows.Forms.TextBox();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkEnviarCorreo = new System.Windows.Forms.CheckBox();
            this.DgvAdjuntos = new System.Windows.Forms.DataGridView();
            this.nombre_archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.BtnBorrarAdjunto = new System.Windows.Forms.Button();
            this.BtnAdjuntar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.DgvContactosCopia = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.TxtCuerpoCorreo = new System.Windows.Forms.TextBox();
            this.SeleccionarAdjunto = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdjuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvContactosCopia)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CmbFormato);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.CmbContacto);
            this.splitContainer1.Panel1.Controls.Add(this.BtnActualizar);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.TxtProveedor);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.TxtDe);
            this.splitContainer1.Panel1.Controls.Add(this.TxtNotas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1152, 741);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 0;
            // 
            // CmbFormato
            // 
            this.CmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFormato.FormattingEnabled = true;
            this.CmbFormato.Items.AddRange(new object[] {
            "ESTADOS UNIDOS",
            "MEXICO"});
            this.CmbFormato.Location = new System.Drawing.Point(11, 134);
            this.CmbFormato.Name = "CmbFormato";
            this.CmbFormato.Size = new System.Drawing.Size(284, 32);
            this.CmbFormato.TabIndex = 72;
            this.CmbFormato.SelectedIndexChanged += new System.EventHandler(this.CmbFormato_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Formato:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CmbContacto
            // 
            this.CmbContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContacto.FormattingEnabled = true;
            this.CmbContacto.Location = new System.Drawing.Point(12, 190);
            this.CmbContacto.Name = "CmbContacto";
            this.CmbContacto.Size = new System.Drawing.Size(283, 32);
            this.CmbContacto.TabIndex = 58;
            this.CmbContacto.SelectedIndexChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Enabled = false;
            this.BtnActualizar.Location = new System.Drawing.Point(200, 389);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(95, 23);
            this.BtnActualizar.TabIndex = 57;
            this.BtnActualizar.Text = "Actualizar PDF";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Proveedor:";
            // 
            // TxtProveedor
            // 
            this.TxtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProveedor.Location = new System.Drawing.Point(11, 84);
            this.TxtProveedor.Name = "TxtProveedor";
            this.TxtProveedor.ReadOnly = true;
            this.TxtProveedor.Size = new System.Drawing.Size(284, 29);
            this.TxtProveedor.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Comentarios / notas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contacto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Solicitante:";
            // 
            // TxtDe
            // 
            this.TxtDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDe.Location = new System.Drawing.Point(11, 31);
            this.TxtDe.Name = "TxtDe";
            this.TxtDe.ReadOnly = true;
            this.TxtDe.Size = new System.Drawing.Size(284, 29);
            this.TxtDe.TabIndex = 1;
            // 
            // TxtNotas
            // 
            this.TxtNotas.Location = new System.Drawing.Point(11, 248);
            this.TxtNotas.Multiline = true;
            this.TxtNotas.Name = "TxtNotas";
            this.TxtNotas.Size = new System.Drawing.Size(284, 135);
            this.TxtNotas.TabIndex = 0;
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(534, 741);
            this.VisorPDF.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkEnviarCorreo);
            this.panel1.Controls.Add(this.DgvAdjuntos);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.BtnBorrarAdjunto);
            this.panel1.Controls.Add(this.BtnAdjuntar);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.DgvContactosCopia);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.BtnEnviar);
            this.panel1.Controls.Add(this.TxtCuerpoCorreo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(534, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 741);
            this.panel1.TabIndex = 2;
            // 
            // chkEnviarCorreo
            // 
            this.chkEnviarCorreo.AutoSize = true;
            this.chkEnviarCorreo.Checked = true;
            this.chkEnviarCorreo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnviarCorreo.Location = new System.Drawing.Point(191, 11);
            this.chkEnviarCorreo.Name = "chkEnviarCorreo";
            this.chkEnviarCorreo.Size = new System.Drawing.Size(107, 17);
            this.chkEnviarCorreo.TabIndex = 86;
            this.chkEnviarCorreo.Text = "Enviar por correo";
            this.chkEnviarCorreo.UseVisualStyleBackColor = true;
            this.chkEnviarCorreo.CheckedChanged += new System.EventHandler(this.chkEnviarCorreo_CheckedChanged);
            // 
            // DgvAdjuntos
            // 
            this.DgvAdjuntos.AllowUserToAddRows = false;
            this.DgvAdjuntos.AllowUserToResizeRows = false;
            this.DgvAdjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAdjuntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre_archivo});
            this.DgvAdjuntos.Location = new System.Drawing.Point(14, 415);
            this.DgvAdjuntos.MultiSelect = false;
            this.DgvAdjuntos.Name = "DgvAdjuntos";
            this.DgvAdjuntos.ReadOnly = true;
            this.DgvAdjuntos.RowHeadersVisible = false;
            this.DgvAdjuntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAdjuntos.Size = new System.Drawing.Size(284, 168);
            this.DgvAdjuntos.TabIndex = 85;
            this.DgvAdjuntos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdjuntos_CellClick);
            this.DgvAdjuntos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdjuntos_CellDoubleClick);
            // 
            // nombre_archivo
            // 
            this.nombre_archivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_archivo.HeaderText = "Archivo";
            this.nombre_archivo.Name = "nombre_archivo";
            this.nombre_archivo.ReadOnly = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 399);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 84;
            this.label15.Text = "Archivos adjuntos:";
            // 
            // BtnBorrarAdjunto
            // 
            this.BtnBorrarAdjunto.Enabled = false;
            this.BtnBorrarAdjunto.Location = new System.Drawing.Point(159, 589);
            this.BtnBorrarAdjunto.Name = "BtnBorrarAdjunto";
            this.BtnBorrarAdjunto.Size = new System.Drawing.Size(139, 23);
            this.BtnBorrarAdjunto.TabIndex = 83;
            this.BtnBorrarAdjunto.Text = "Borrar";
            this.BtnBorrarAdjunto.UseVisualStyleBackColor = true;
            this.BtnBorrarAdjunto.Click += new System.EventHandler(this.BtnBorrarAdjunto_Click);
            // 
            // BtnAdjuntar
            // 
            this.BtnAdjuntar.Location = new System.Drawing.Point(14, 589);
            this.BtnAdjuntar.Name = "BtnAdjuntar";
            this.BtnAdjuntar.Size = new System.Drawing.Size(139, 23);
            this.BtnAdjuntar.TabIndex = 82;
            this.BtnAdjuntar.Text = "Adjuntar";
            this.BtnAdjuntar.UseVisualStyleBackColor = true;
            this.BtnAdjuntar.Click += new System.EventHandler(this.BtnAdjuntar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 227);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 13);
            this.label16.TabIndex = 81;
            this.label16.Text = "Contactos en copia:";
            // 
            // DgvContactosCopia
            // 
            this.DgvContactosCopia.AllowUserToAddRows = false;
            this.DgvContactosCopia.AllowUserToResizeRows = false;
            this.DgvContactosCopia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvContactosCopia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.seleccion,
            this.contacto,
            this.correo});
            this.DgvContactosCopia.Location = new System.Drawing.Point(14, 244);
            this.DgvContactosCopia.MultiSelect = false;
            this.DgvContactosCopia.Name = "DgvContactosCopia";
            this.DgvContactosCopia.RowHeadersVisible = false;
            this.DgvContactosCopia.Size = new System.Drawing.Size(284, 150);
            this.DgvContactosCopia.TabIndex = 83;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // seleccion
            // 
            this.seleccion.HeaderText = "";
            this.seleccion.Name = "seleccion";
            this.seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seleccion.Width = 30;
            // 
            // contacto
            // 
            this.contacto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.contacto.HeaderText = "Contacto";
            this.contacto.Name = "contacto";
            this.contacto.ReadOnly = true;
            // 
            // correo
            // 
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            this.correo.ReadOnly = true;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(15, 687);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(139, 42);
            this.BtnCancelar.TabIndex = 53;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 82;
            this.label14.Text = "Cuerpo del correo:";
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Enabled = false;
            this.BtnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviar.Location = new System.Drawing.Point(159, 687);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(139, 42);
            this.BtnEnviar.TabIndex = 52;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // TxtCuerpoCorreo
            // 
            this.TxtCuerpoCorreo.Location = new System.Drawing.Point(14, 31);
            this.TxtCuerpoCorreo.Multiline = true;
            this.TxtCuerpoCorreo.Name = "TxtCuerpoCorreo";
            this.TxtCuerpoCorreo.Size = new System.Drawing.Size(284, 188);
            this.TxtCuerpoCorreo.TabIndex = 80;
            // 
            // SeleccionarAdjunto
            // 
            this.SeleccionarAdjunto.FileName = "openFileDialog1";
            // 
            // FrmEnviarRFQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 741);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEnviarRFQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar RFQ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPruebaPDF_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdjuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvContactosCopia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.TextBox TxtNotas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDe;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtProveedor;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.ComboBox CmbContacto;
        private System.Windows.Forms.ComboBox CmbFormato;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView DgvContactosCopia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtCuerpoCorreo;
        private System.Windows.Forms.Button BtnBorrarAdjunto;
        private System.Windows.Forms.Button BtnAdjuntar;
        private System.Windows.Forms.OpenFileDialog SeleccionarAdjunto;
        private System.Windows.Forms.DataGridView DgvAdjuntos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkEnviarCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_archivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;

    }
}
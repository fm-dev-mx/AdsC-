namespace CB
{
    partial class FrmReportarRequerimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportarRequerimientos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChkIncluirInternos = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNotas = new System.Windows.Forms.TextBox();
            this.CmbContacto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtGeneradoPor = new System.Windows.Forms.TextBox();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DateFiltro = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnEnviar = new System.Windows.Forms.Button();
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
            this.label14 = new System.Windows.Forms.Label();
            this.TxtCuerpoCorreo = new System.Windows.Forms.TextBox();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.SeleccionarAdjunto = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdjuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvContactosCopia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChkIncluirInternos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtNotas);
            this.panel1.Controls.Add(this.CmbContacto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtGeneradoPor);
            this.panel1.Controls.Add(this.BtnActualizar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DateFiltro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 741);
            this.panel1.TabIndex = 0;
            // 
            // ChkIncluirInternos
            // 
            this.ChkIncluirInternos.AutoSize = true;
            this.ChkIncluirInternos.Location = new System.Drawing.Point(13, 375);
            this.ChkIncluirInternos.Name = "ChkIncluirInternos";
            this.ChkIncluirInternos.Size = new System.Drawing.Size(165, 17);
            this.ChkIncluirInternos.TabIndex = 65;
            this.ChkIncluirInternos.Text = "Incluir requerimientos internos";
            this.ChkIncluirInternos.UseVisualStyleBackColor = true;
            this.ChkIncluirInternos.CheckedChanged += new System.EventHandler(this.ChkIncluirInternos_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Comentarios / notas:";
            // 
            // TxtNotas
            // 
            this.TxtNotas.Location = new System.Drawing.Point(13, 188);
            this.TxtNotas.Multiline = true;
            this.TxtNotas.Name = "TxtNotas";
            this.TxtNotas.Size = new System.Drawing.Size(284, 135);
            this.TxtNotas.TabIndex = 63;
            // 
            // CmbContacto
            // 
            this.CmbContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContacto.Enabled = false;
            this.CmbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContacto.FormattingEnabled = true;
            this.CmbContacto.Location = new System.Drawing.Point(13, 131);
            this.CmbContacto.Name = "CmbContacto";
            this.CmbContacto.Size = new System.Drawing.Size(284, 32);
            this.CmbContacto.TabIndex = 62;
            this.CmbContacto.SelectedIndexChanged += new System.EventHandler(this.CmbContacto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Contacto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Generado por:";
            // 
            // TxtGeneradoPor
            // 
            this.TxtGeneradoPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGeneradoPor.Location = new System.Drawing.Point(13, 78);
            this.TxtGeneradoPor.Name = "TxtGeneradoPor";
            this.TxtGeneradoPor.ReadOnly = true;
            this.TxtGeneradoPor.Size = new System.Drawing.Size(284, 29);
            this.TxtGeneradoPor.TabIndex = 59;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Location = new System.Drawing.Point(202, 329);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(95, 23);
            this.BtnActualizar.TabIndex = 58;
            this.BtnActualizar.Text = "Actualizar PDF";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "A partir de:";
            // 
            // DateFiltro
            // 
            this.DateFiltro.Location = new System.Drawing.Point(13, 29);
            this.DateFiltro.Name = "DateFiltro";
            this.DateFiltro.Size = new System.Drawing.Size(284, 20);
            this.DateFiltro.TabIndex = 0;
            this.DateFiltro.ValueChanged += new System.EventHandler(this.DateFiltro_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnCancelar);
            this.panel2.Controls.Add(this.BtnEnviar);
            this.panel2.Controls.Add(this.DgvAdjuntos);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.BtnBorrarAdjunto);
            this.panel2.Controls.Add(this.BtnAdjuntar);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.DgvContactosCopia);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.TxtCuerpoCorreo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(836, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 741);
            this.panel2.TabIndex = 1;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(15, 629);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(139, 42);
            this.BtnCancelar.TabIndex = 95;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Enabled = false;
            this.BtnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviar.Location = new System.Drawing.Point(160, 629);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(139, 42);
            this.BtnEnviar.TabIndex = 94;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // DgvAdjuntos
            // 
            this.DgvAdjuntos.AllowUserToAddRows = false;
            this.DgvAdjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAdjuntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre_archivo});
            this.DgvAdjuntos.Location = new System.Drawing.Point(15, 413);
            this.DgvAdjuntos.MultiSelect = false;
            this.DgvAdjuntos.Name = "DgvAdjuntos";
            this.DgvAdjuntos.ReadOnly = true;
            this.DgvAdjuntos.RowHeadersVisible = false;
            this.DgvAdjuntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAdjuntos.Size = new System.Drawing.Size(284, 168);
            this.DgvAdjuntos.TabIndex = 93;
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
            this.label15.Location = new System.Drawing.Point(12, 397);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 92;
            this.label15.Text = "Archivos adjuntos:";
            // 
            // BtnBorrarAdjunto
            // 
            this.BtnBorrarAdjunto.Enabled = false;
            this.BtnBorrarAdjunto.Location = new System.Drawing.Point(160, 587);
            this.BtnBorrarAdjunto.Name = "BtnBorrarAdjunto";
            this.BtnBorrarAdjunto.Size = new System.Drawing.Size(139, 23);
            this.BtnBorrarAdjunto.TabIndex = 90;
            this.BtnBorrarAdjunto.Text = "Borrar";
            this.BtnBorrarAdjunto.UseVisualStyleBackColor = true;
            this.BtnBorrarAdjunto.Click += new System.EventHandler(this.BtnBorrarAdjunto_Click);
            // 
            // BtnAdjuntar
            // 
            this.BtnAdjuntar.Location = new System.Drawing.Point(15, 587);
            this.BtnAdjuntar.Name = "BtnAdjuntar";
            this.BtnAdjuntar.Size = new System.Drawing.Size(139, 23);
            this.BtnAdjuntar.TabIndex = 88;
            this.BtnAdjuntar.Text = "Adjuntar";
            this.BtnAdjuntar.UseVisualStyleBackColor = true;
            this.BtnAdjuntar.Click += new System.EventHandler(this.BtnAdjuntar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 225);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 13);
            this.label16.TabIndex = 87;
            this.label16.Text = "Contactos en copia:";
            // 
            // DgvContactosCopia
            // 
            this.DgvContactosCopia.AllowUserToAddRows = false;
            this.DgvContactosCopia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvContactosCopia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.seleccion,
            this.contacto,
            this.correo});
            this.DgvContactosCopia.Location = new System.Drawing.Point(15, 242);
            this.DgvContactosCopia.MultiSelect = false;
            this.DgvContactosCopia.Name = "DgvContactosCopia";
            this.DgvContactosCopia.RowHeadersVisible = false;
            this.DgvContactosCopia.Size = new System.Drawing.Size(284, 150);
            this.DgvContactosCopia.TabIndex = 91;
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
            // 
            // correo
            // 
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 89;
            this.label14.Text = "Cuerpo del correo:";
            // 
            // TxtCuerpoCorreo
            // 
            this.TxtCuerpoCorreo.Location = new System.Drawing.Point(15, 29);
            this.TxtCuerpoCorreo.Multiline = true;
            this.TxtCuerpoCorreo.Name = "TxtCuerpoCorreo";
            this.TxtCuerpoCorreo.Size = new System.Drawing.Size(284, 188);
            this.TxtCuerpoCorreo.TabIndex = 86;
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(308, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(528, 741);
            this.VisorPDF.TabIndex = 2;
            // 
            // SeleccionarAdjunto
            // 
            this.SeleccionarAdjunto.FileName = "openFileDialog1";
            // 
            // FrmReportarRequerimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 741);
            this.Controls.Add(this.VisorPDF);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReportarRequerimientos";
            this.Text = "Reportar requerimientos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportarRequerimientos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdjuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvContactosCopia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateFiltro;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtGeneradoPor;
        private System.Windows.Forms.ComboBox CmbContacto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtNotas;
        private System.Windows.Forms.DataGridView DgvAdjuntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_archivo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button BtnBorrarAdjunto;
        private System.Windows.Forms.Button BtnAdjuntar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView DgvContactosCopia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtCuerpoCorreo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.OpenFileDialog SeleccionarAdjunto;
        private System.Windows.Forms.CheckBox ChkIncluirInternos;
    }
}
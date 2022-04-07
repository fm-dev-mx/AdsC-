namespace CB
{
    partial class FrmImprimirFormatoLiberacionDiseno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImprimirFormatoLiberacionDiseno));
            this.LblTitulo = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbLiderDeProyecto = new System.Windows.Forms.ComboBox();
            this.CmbContactoCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbDisenadorMecanico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbLiderMecanico = new System.Windows.Forms.ComboBox();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.PicSubensamble = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSubensamble)).BeginInit();
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
            this.LblTitulo.Size = new System.Drawing.Size(969, 23);
            this.LblTitulo.TabIndex = 6;
            this.LblTitulo.Text = "IMPRIMIR FORMATO DE VALIDACION DE DISEÑO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 23);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.VisorPDF);
            this.splitContainer2.Panel2.Controls.Add(this.PicSubensamble);
            this.splitContainer2.Size = new System.Drawing.Size(969, 416);
            this.splitContainer2.SplitterDistance = 300;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.CmbLiderDeProyecto);
            this.splitContainer3.Panel1.Controls.Add(this.CmbContactoCliente);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.CmbDisenadorMecanico);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            this.splitContainer3.Panel1.Controls.Add(this.CmbLiderMecanico);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.TxtComentarios);
            this.splitContainer3.Panel2.Controls.Add(this.panel1);
            this.splitContainer3.Size = new System.Drawing.Size(300, 416);
            this.splitContainer3.SplitterDistance = 250;
            this.splitContainer3.TabIndex = 121;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 121;
            this.label5.Text = "Comentarios:";
            // 
            // CmbLiderDeProyecto
            // 
            this.CmbLiderDeProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLiderDeProyecto.Enabled = false;
            this.CmbLiderDeProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLiderDeProyecto.FormattingEnabled = true;
            this.CmbLiderDeProyecto.Location = new System.Drawing.Point(12, 138);
            this.CmbLiderDeProyecto.Name = "CmbLiderDeProyecto";
            this.CmbLiderDeProyecto.Size = new System.Drawing.Size(278, 32);
            this.CmbLiderDeProyecto.TabIndex = 118;
            this.CmbLiderDeProyecto.SelectedIndexChanged += new System.EventHandler(this.CmbLiderDeProyecto_SelectedIndexChanged);
            // 
            // CmbContactoCliente
            // 
            this.CmbContactoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContactoCliente.Enabled = false;
            this.CmbContactoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContactoCliente.FormattingEnabled = true;
            this.CmbContactoCliente.Location = new System.Drawing.Point(12, 191);
            this.CmbContactoCliente.Name = "CmbContactoCliente";
            this.CmbContactoCliente.Size = new System.Drawing.Size(278, 32);
            this.CmbContactoCliente.TabIndex = 120;
            this.CmbContactoCliente.SelectedIndexChanged += new System.EventHandler(this.CmbContactoCliente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Diseñador mecánico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 119;
            this.label4.Text = "Contacto del cliente:";
            // 
            // CmbDisenadorMecanico
            // 
            this.CmbDisenadorMecanico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDisenadorMecanico.Enabled = false;
            this.CmbDisenadorMecanico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDisenadorMecanico.FormattingEnabled = true;
            this.CmbDisenadorMecanico.Location = new System.Drawing.Point(12, 30);
            this.CmbDisenadorMecanico.Name = "CmbDisenadorMecanico";
            this.CmbDisenadorMecanico.Size = new System.Drawing.Size(278, 32);
            this.CmbDisenadorMecanico.TabIndex = 114;
            this.CmbDisenadorMecanico.SelectedIndexChanged += new System.EventHandler(this.CmbDisenadorMecanico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 115;
            this.label2.Text = "Líder mecánico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 117;
            this.label3.Text = "Líder de proyecto:";
            // 
            // CmbLiderMecanico
            // 
            this.CmbLiderMecanico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLiderMecanico.Enabled = false;
            this.CmbLiderMecanico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLiderMecanico.FormattingEnabled = true;
            this.CmbLiderMecanico.Location = new System.Drawing.Point(12, 85);
            this.CmbLiderMecanico.Name = "CmbLiderMecanico";
            this.CmbLiderMecanico.Size = new System.Drawing.Size(278, 32);
            this.CmbLiderMecanico.TabIndex = 116;
            this.CmbLiderMecanico.SelectedIndexChanged += new System.EventHandler(this.CmbLiderMecanico_SelectedIndexChanged);
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtComentarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtComentarios.Location = new System.Drawing.Point(0, 0);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(300, 119);
            this.TxtComentarios.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnActualizar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 43);
            this.panel1.TabIndex = 1;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::CB_Base.Properties.Resources.update;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(182, 0);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(118, 43);
            this.BtnActualizar.TabIndex = 2;
            this.BtnActualizar.Text = "     Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // VisorPDF
            // 
            this.VisorPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(0, 0);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(665, 416);
            this.VisorPDF.TabIndex = 2;
            // 
            // PicSubensamble
            // 
            this.PicSubensamble.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicSubensamble.Location = new System.Drawing.Point(0, 0);
            this.PicSubensamble.Name = "PicSubensamble";
            this.PicSubensamble.Size = new System.Drawing.Size(665, 416);
            this.PicSubensamble.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSubensamble.TabIndex = 0;
            this.PicSubensamble.TabStop = false;
            // 
            // FrmImprimirFormatoLiberacionDiseno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 439);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmImprimirFormatoLiberacionDiseno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir formato de validación de diseño";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmImprimirFormatoLiberacionDiseno_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSubensamble)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbLiderMecanico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbDisenadorMecanico;
        private System.Windows.Forms.ComboBox CmbLiderDeProyecto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbContactoCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.PictureBox PicSubensamble;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnActualizar;
    }
}
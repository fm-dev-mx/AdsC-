namespace CB
{
    partial class FrmNuevaCaracteristica
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
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbCaracteristica = new System.Windows.Forms.ComboBox();
            this.CmbOpciones = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NumCosto = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumCosto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(335, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "NUEVA CARACTERISTICA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // CmbCaracteristica
            // 
            this.CmbCaracteristica.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbCaracteristica.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCaracteristica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCaracteristica.FormattingEnabled = true;
            this.CmbCaracteristica.Location = new System.Drawing.Point(0, 36);
            this.CmbCaracteristica.Name = "CmbCaracteristica";
            this.CmbCaracteristica.Size = new System.Drawing.Size(323, 28);
            this.CmbCaracteristica.TabIndex = 3;
            this.CmbCaracteristica.SelectedIndexChanged += new System.EventHandler(this.CmbCaracteristica_SelectedIndexChanged);
            this.CmbCaracteristica.TextChanged += new System.EventHandler(this.CmbCaracteristica_TextChanged);
            this.CmbCaracteristica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbCaracteristica_KeyPress);
            // 
            // CmbOpciones
            // 
            this.CmbOpciones.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbOpciones.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbOpciones.FormattingEnabled = true;
            this.CmbOpciones.Location = new System.Drawing.Point(3, 80);
            this.CmbOpciones.Name = "CmbOpciones";
            this.CmbOpciones.Size = new System.Drawing.Size(320, 28);
            this.CmbOpciones.TabIndex = 4;
            this.CmbOpciones.SelectedIndexChanged += new System.EventHandler(this.CmbOpciones_SelectedIndexChanged);
            this.CmbOpciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbOpciones_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Costo";
            // 
            // NumCosto
            // 
            this.NumCosto.DecimalPlaces = 2;
            this.NumCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumCosto.Location = new System.Drawing.Point(6, 127);
            this.NumCosto.Name = "NumCosto";
            this.NumCosto.Size = new System.Drawing.Size(120, 26);
            this.NumCosto.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.BtnAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 42);
            this.panel1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CB_Base.Properties.Resources.close;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(84, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "    Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(214, 0);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(121, 42);
            this.BtnAceptar.TabIndex = 0;
            this.BtnAceptar.Text = "Crear";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // FrmNuevaCaracteristica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 212);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NumCosto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbOpciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbCaracteristica);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaCaracteristica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva característica";
            this.Load += new System.EventHandler(this.FrmNuevaCaracteristica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumCosto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbCaracteristica;
        private System.Windows.Forms.ComboBox CmbOpciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumCosto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnAceptar;
    }
}
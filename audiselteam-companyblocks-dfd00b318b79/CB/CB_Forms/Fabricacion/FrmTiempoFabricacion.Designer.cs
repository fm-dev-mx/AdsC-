namespace CB
{
    partial class FrmTiempoFabricacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.LblProceso = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.DgvHerramentistas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.herramentista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo_trabajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbHerramentista = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NumTiempo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHerramentistas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTiempo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(491, 407);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(128, 47);
            this.BtnAceptar.TabIndex = 7;
            this.BtnAceptar.Text = "    Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // LblProceso
            // 
            this.LblProceso.BackColor = System.Drawing.SystemColors.ControlDark;
            this.LblProceso.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProceso.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblProceso.Location = new System.Drawing.Point(0, 23);
            this.LblProceso.Name = "LblProceso";
            this.LblProceso.Size = new System.Drawing.Size(631, 26);
            this.LblProceso.TabIndex = 9;
            this.LblProceso.Text = "PROCESO";
            this.LblProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CB_Base.Properties.Resources.close;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(357, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 47);
            this.button2.TabIndex = 10;
            this.button2.Text = "   Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DgvHerramentistas
            // 
            this.DgvHerramentistas.AllowUserToAddRows = false;
            this.DgvHerramentistas.AllowUserToDeleteRows = false;
            this.DgvHerramentistas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvHerramentistas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvHerramentistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHerramentistas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.check,
            this.herramentista,
            this.tiempo_trabajo});
            this.DgvHerramentistas.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvHerramentistas.Location = new System.Drawing.Point(0, 166);
            this.DgvHerramentistas.Name = "DgvHerramentistas";
            this.DgvHerramentistas.RowHeadersVisible = false;
            this.DgvHerramentistas.Size = new System.Drawing.Size(631, 235);
            this.DgvHerramentistas.TabIndex = 11;
            this.DgvHerramentistas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvHerramentistas_EditingControlShowing);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 50;
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.MinimumWidth = 50;
            this.check.Name = "check";
            this.check.Width = 50;
            // 
            // herramentista
            // 
            this.herramentista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.herramentista.DefaultCellStyle = dataGridViewCellStyle2;
            this.herramentista.HeaderText = "Herramentista";
            this.herramentista.Name = "herramentista";
            this.herramentista.ReadOnly = true;
            // 
            // tiempo_trabajo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tiempo_trabajo.DefaultCellStyle = dataGridViewCellStyle3;
            this.tiempo_trabajo.HeaderText = "Tiempo de trabajo";
            this.tiempo_trabajo.MinimumWidth = 150;
            this.tiempo_trabajo.Name = "tiempo_trabajo";
            this.tiempo_trabajo.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Seleccione al  herramentista que fabricó la pieza";
            // 
            // CmbHerramentista
            // 
            this.CmbHerramentista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbHerramentista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbHerramentista.FormattingEnabled = true;
            this.CmbHerramentista.Location = new System.Drawing.Point(-4, 32);
            this.CmbHerramentista.Name = "CmbHerramentista";
            this.CmbHerramentista.Size = new System.Drawing.Size(489, 23);
            this.CmbHerramentista.TabIndex = 13;
            this.CmbHerramentista.SelectedIndexChanged += new System.EventHandler(this.CmbHerramentista_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Seleccione a los herramentistas involucrados en el proceso";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NumTiempo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CmbHerramentista);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 69);
            this.panel1.TabIndex = 15;
            // 
            // NumTiempo
            // 
            this.NumTiempo.DecimalPlaces = 2;
            this.NumTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumTiempo.Location = new System.Drawing.Point(491, 32);
            this.NumTiempo.Name = "NumTiempo";
            this.NumTiempo.Size = new System.Drawing.Size(137, 22);
            this.NumTiempo.TabIndex = 18;
            this.NumTiempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(506, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Tiempo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Herramentista";
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(631, 23);
            this.audiselTituloForm1.TabIndex = 8;
            this.audiselTituloForm1.Text = "TIEMPO DE FABRICACIÓN";
            // 
            // FrmTiempoFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 459);
            this.Controls.Add(this.DgvHerramentistas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LblProceso);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTiempoFabricacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTiempoFabricacion";
            this.Load += new System.EventHandler(this.FrmTiempoFabricacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHerramentistas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTiempo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnAceptar;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Label LblProceso;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DgvHerramentistas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbHerramentista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramentista;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo_trabajo;
        private System.Windows.Forms.NumericUpDown NumTiempo;
    }
}
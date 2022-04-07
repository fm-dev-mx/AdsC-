namespace CB
{
    partial class FrmRegistrarSubensamble
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgvSubensamble = new System.Windows.Forms.DataGridView();
            this.check_subensamble = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_subensamble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subensmable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.DgvComponentes = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblIndustria = new System.Windows.Forms.Label();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubensamble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvComponentes)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 432);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 60);
            this.panel3.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Image = global::CB_Base.Properties.Resources.close;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(539, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 60);
            this.button3.TabIndex = 6;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(670, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 60);
            this.button2.TabIndex = 5;
            this.button2.Text = "Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 119);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvSubensamble);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvComponentes);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(806, 313);
            this.splitContainer1.SplitterDistance = 383;
            this.splitContainer1.TabIndex = 3;
            // 
            // DgvSubensamble
            // 
            this.DgvSubensamble.AllowUserToAddRows = false;
            this.DgvSubensamble.AllowUserToDeleteRows = false;
            this.DgvSubensamble.AllowUserToResizeRows = false;
            this.DgvSubensamble.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvSubensamble.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSubensamble.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check_subensamble,
            this.id_subensamble,
            this.subensmable});
            this.DgvSubensamble.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSubensamble.Location = new System.Drawing.Point(0, 24);
            this.DgvSubensamble.Name = "DgvSubensamble";
            this.DgvSubensamble.RowHeadersVisible = false;
            this.DgvSubensamble.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSubensamble.Size = new System.Drawing.Size(383, 289);
            this.DgvSubensamble.TabIndex = 1;
            this.DgvSubensamble.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSubensamble_CellClick);
            // 
            // check_subensamble
            // 
            this.check_subensamble.FalseValue = "false";
            this.check_subensamble.HeaderText = "";
            this.check_subensamble.MinimumWidth = 25;
            this.check_subensamble.Name = "check_subensamble";
            this.check_subensamble.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check_subensamble.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check_subensamble.TrueValue = "true";
            this.check_subensamble.Width = 25;
            // 
            // id_subensamble
            // 
            this.id_subensamble.HeaderText = "Id";
            this.id_subensamble.MinimumWidth = 55;
            this.id_subensamble.Name = "id_subensamble";
            this.id_subensamble.ReadOnly = true;
            this.id_subensamble.Width = 55;
            // 
            // subensmable
            // 
            this.subensmable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.subensmable.DefaultCellStyle = dataGridViewCellStyle1;
            this.subensmable.HeaderText = "Subensamble";
            this.subensmable.Name = "subensmable";
            this.subensmable.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(383, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "Subensambles";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvComponentes
            // 
            this.DgvComponentes.AllowUserToAddRows = false;
            this.DgvComponentes.AllowUserToDeleteRows = false;
            this.DgvComponentes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvComponentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvComponentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.id,
            this.producto,
            this.descripcion});
            this.DgvComponentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvComponentes.Location = new System.Drawing.Point(0, 24);
            this.DgvComponentes.Name = "DgvComponentes";
            this.DgvComponentes.RowHeadersVisible = false;
            this.DgvComponentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvComponentes.Size = new System.Drawing.Size(419, 289);
            this.DgvComponentes.TabIndex = 0;
            this.DgvComponentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvComponentes_CellClick);
            // 
            // check
            // 
            this.check.FalseValue = "false";
            this.check.HeaderText = "";
            this.check.MinimumWidth = 25;
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.TrueValue = "true";
            this.check.Width = 25;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 55;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 55;
            // 
            // producto
            // 
            this.producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.producto.DefaultCellStyle = dataGridViewCellStyle3;
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcion.DefaultCellStyle = dataGridViewCellStyle4;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(419, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Componentes";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.TxtNombre);
            this.panel4.Controls.Add(this.LblCliente);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.LblIndustria);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(806, 96);
            this.panel4.TabIndex = 4;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNombre.Location = new System.Drawing.Point(6, 46);
            this.TxtNombre.Multiline = true;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ReadOnly = true;
            this.TxtNombre.Size = new System.Drawing.Size(797, 44);
            this.TxtNombre.TabIndex = 6;
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCliente.Location = new System.Drawing.Point(387, 3);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(52, 16);
            this.LblCliente.TabIndex = 5;
            this.LblCliente.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre subensamble:";
            // 
            // LblIndustria
            // 
            this.LblIndustria.AutoSize = true;
            this.LblIndustria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIndustria.Location = new System.Drawing.Point(3, 3);
            this.LblIndustria.Name = "LblIndustria";
            this.LblIndustria.Size = new System.Drawing.Size(61, 16);
            this.LblIndustria.TabIndex = 2;
            this.LblIndustria.Text = "Industria:";
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(806, 23);
            this.audiselTituloForm1.TabIndex = 5;
            this.audiselTituloForm1.Text = "REGISTRAR SUBENSAMBLE";
            // 
            // FrmRegistrarSubensamble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 492);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.audiselTituloForm1);
            this.Name = "FrmRegistrarSubensamble";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar subensamble";
            this.Load += new System.EventHandler(this.FrmSeleccionarComponentes_Load);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubensamble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvComponentes)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvSubensamble;
        private System.Windows.Forms.DataGridView DgvComponentes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LblIndustria;
        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_subensamble;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_subensamble;
        private System.Windows.Forms.DataGridViewTextBoxColumn subensmable;
    }
}
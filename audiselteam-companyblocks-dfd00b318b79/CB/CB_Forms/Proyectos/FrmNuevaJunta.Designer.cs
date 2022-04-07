namespace CB
{
    partial class FrmNuevaJunta
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblNombre = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.ChkTodoElDia = new System.Windows.Forms.CheckBox();
            this.DtpHora = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.CmbTipoJunta = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpFechaJunta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvInvitados = new System.Windows.Forms.DataGridView();
            this.id_invitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_invitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.invitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvitados)).BeginInit();
            this.MenuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TxtNombre);
            this.splitContainer1.Panel1.Controls.Add(this.LblNombre);
            this.splitContainer1.Panel1.Controls.Add(this.LblTitulo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ChkTodoElDia);
            this.splitContainer1.Panel2.Controls.Add(this.DtpHora);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.BtnGuardar);
            this.splitContainer1.Panel2.Controls.Add(this.CmbTipoJunta);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.DtpFechaJunta);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(680, 420);
            this.splitContainer1.SplitterDistance = 81;
            this.splitContainer1.TabIndex = 0;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.TxtNombre.Location = new System.Drawing.Point(15, 44);
            this.TxtNombre.MaxLength = 50;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(649, 28);
            this.TxtNombre.TabIndex = 69;
            // 
            // LblNombre
            // 
            this.LblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.LblNombre.Location = new System.Drawing.Point(15, 23);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(657, 19);
            this.LblNombre.TabIndex = 68;
            this.LblNombre.Text = "Nombre:";
            this.LblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(680, 23);
            this.LblTitulo.TabIndex = 67;
            this.LblTitulo.Text = "NUEVO EVENTO";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // ChkTodoElDia
            // 
            this.ChkTodoElDia.AutoSize = true;
            this.ChkTodoElDia.Location = new System.Drawing.Point(356, 170);
            this.ChkTodoElDia.Name = "ChkTodoElDia";
            this.ChkTodoElDia.Size = new System.Drawing.Size(81, 17);
            this.ChkTodoElDia.TabIndex = 78;
            this.ChkTodoElDia.Text = "Todo el día";
            this.ChkTodoElDia.UseVisualStyleBackColor = true;
            this.ChkTodoElDia.CheckedChanged += new System.EventHandler(this.ChkTodoElDia_CheckedChanged);
            // 
            // DtpHora
            // 
            this.DtpHora.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.DtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpHora.Location = new System.Drawing.Point(356, 191);
            this.DtpHora.Name = "DtpHora";
            this.DtpHora.ShowUpDown = true;
            this.DtpHora.Size = new System.Drawing.Size(146, 28);
            this.DtpHora.TabIndex = 77;
            this.DtpHora.ValueChanged += new System.EventHandler(this.DtpHora_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CB_Base.Properties.Resources.exit;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(414, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 47);
            this.button1.TabIndex = 76;
            this.button1.Text = "      Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(542, 282);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(122, 47);
            this.BtnGuardar.TabIndex = 75;
            this.BtnGuardar.Text = "    Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // CmbTipoJunta
            // 
            this.CmbTipoJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoJunta.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.CmbTipoJunta.FormattingEnabled = true;
            this.CmbTipoJunta.Location = new System.Drawing.Point(15, 251);
            this.CmbTipoJunta.Name = "CmbTipoJunta";
            this.CmbTipoJunta.Size = new System.Drawing.Size(337, 29);
            this.CmbTipoJunta.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(15, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 20);
            this.label5.TabIndex = 73;
            this.label5.Text = "Tipo de evento:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DtpFechaJunta
            // 
            this.DtpFechaJunta.CustomFormat = "MMM dd, yyyy";
            this.DtpFechaJunta.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.DtpFechaJunta.Location = new System.Drawing.Point(15, 191);
            this.DtpFechaJunta.Name = "DtpFechaJunta";
            this.DtpFechaJunta.Size = new System.Drawing.Size(334, 28);
            this.DtpFechaJunta.TabIndex = 72;
            this.DtpFechaJunta.ValueChanged += new System.EventHandler(this.DtpFechaJunta_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 20);
            this.label3.TabIndex = 71;
            this.label3.Text = "Programar fecha y hora:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TxtDescripcion);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.DgvInvitados);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(680, 164);
            this.splitContainer2.SplitterDistance = 352;
            this.splitContainer2.TabIndex = 1;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.TxtDescripcion.Location = new System.Drawing.Point(15, 20);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDescripcion.Size = new System.Drawing.Size(334, 135);
            this.TxtDescripcion.TabIndex = 71;
            this.TxtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 20);
            this.label1.TabIndex = 70;
            this.label1.Text = "Descripción:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(-3, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 20);
            this.label4.TabIndex = 73;
            this.label4.Text = "Programar hora:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvInvitados
            // 
            this.DgvInvitados.AllowUserToAddRows = false;
            this.DgvInvitados.AllowUserToResizeColumns = false;
            this.DgvInvitados.AllowUserToResizeRows = false;
            this.DgvInvitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvInvitados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_invitado,
            this.nombre_invitado});
            this.DgvInvitados.Location = new System.Drawing.Point(0, 20);
            this.DgvInvitados.Name = "DgvInvitados";
            this.DgvInvitados.RowHeadersVisible = false;
            this.DgvInvitados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvInvitados.Size = new System.Drawing.Size(308, 135);
            this.DgvInvitados.TabIndex = 74;
            this.DgvInvitados.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.DgvInvitados.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvInvitados_MouseClick);
            // 
            // id_invitado
            // 
            this.id_invitado.HeaderText = "Id";
            this.id_invitado.Name = "id_invitado";
            this.id_invitado.ReadOnly = true;
            this.id_invitado.Visible = false;
            // 
            // nombre_invitado
            // 
            this.nombre_invitado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_invitado.HeaderText = "Nombre";
            this.nombre_invitado.Name = "nombre_invitado";
            this.nombre_invitado.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 20);
            this.label2.TabIndex = 73;
            this.label2.Text = "Invitados";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invitarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(118, 48);
            // 
            // invitarToolStripMenuItem
            // 
            this.invitarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Awicons_Vista_Artistic_Add;
            this.invitarToolStripMenuItem.Name = "invitarToolStripMenuItem";
            this.invitarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.invitarToolStripMenuItem.Text = "Invitar";
            this.invitarToolStripMenuItem.Click += new System.EventHandler(this.invitarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.close;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // FrmNuevaJunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 420);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaJunta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuevaJunta";
            this.Load += new System.EventHandler(this.FrmNuevaJunta_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvitados)).EndInit();
            this.MenuOpciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbTipoJunta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtpFechaJunta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DgvInvitados;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem invitarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.DateTimePicker DtpHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_invitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_invitado;
        private System.Windows.Forms.CheckBox ChkTodoElDia;

    }
}
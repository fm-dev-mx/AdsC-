namespace CB
{
    partial class FrmCalendario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvCalendario = new System.Windows.Forms.DataGridView();
            this.MenuOpcionesCalendario = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.programarEventoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbTipoEvento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.CmbMes = new System.Windows.Forms.ComboBox();
            this.LblMes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbVisualizar = new System.Windows.Forms.ComboBox();
            this.DgvEventos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invitados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblEventosProgramados = new System.Windows.Forms.Label();
            this.DivisorPrincipal = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCalendario)).BeginInit();
            this.MenuOpcionesCalendario.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEventos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DivisorPrincipal)).BeginInit();
            this.DivisorPrincipal.Panel1.SuspendLayout();
            this.DivisorPrincipal.Panel2.SuspendLayout();
            this.DivisorPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvCalendario
            // 
            this.DgvCalendario.AllowUserToAddRows = false;
            this.DgvCalendario.AllowUserToResizeRows = false;
            this.DgvCalendario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvCalendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCalendario.ContextMenuStrip = this.MenuOpcionesCalendario;
            this.DgvCalendario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCalendario.Location = new System.Drawing.Point(0, 0);
            this.DgvCalendario.Name = "DgvCalendario";
            this.DgvCalendario.ReadOnly = true;
            this.DgvCalendario.RowHeadersVisible = false;
            this.DgvCalendario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvCalendario.Size = new System.Drawing.Size(951, 165);
            this.DgvCalendario.TabIndex = 0;
            this.DgvCalendario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCalendario_CellClick);
            // 
            // MenuOpcionesCalendario
            // 
            this.MenuOpcionesCalendario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programarEventoToolStripMenuItem});
            this.MenuOpcionesCalendario.Name = "MenuOpcionesCalendario";
            this.MenuOpcionesCalendario.Size = new System.Drawing.Size(170, 48);
            this.MenuOpcionesCalendario.Opening += new System.ComponentModel.CancelEventHandler(this.MenuOpcionesCalendario_Opening);
            // 
            // programarEventoToolStripMenuItem
            // 
            this.programarEventoToolStripMenuItem.Name = "programarEventoToolStripMenuItem";
            this.programarEventoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.programarEventoToolStripMenuItem.Text = "Programar evento";
            this.programarEventoToolStripMenuItem.Click += new System.EventHandler(this.programarEventoToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbTipoEvento);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Controls.Add(this.CmbMes);
            this.panel1.Controls.Add(this.LblMes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CmbYear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbVisualizar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 87);
            this.panel1.TabIndex = 1;
            // 
            // CmbTipoEvento
            // 
            this.CmbTipoEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoEvento.FormattingEnabled = true;
            this.CmbTipoEvento.Location = new System.Drawing.Point(586, 47);
            this.CmbTipoEvento.Name = "CmbTipoEvento";
            this.CmbTipoEvento.Size = new System.Drawing.Size(320, 28);
            this.CmbTipoEvento.TabIndex = 70;
            this.CmbTipoEvento.SelectedIndexChanged += new System.EventHandler(this.CmbTipoEvento_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Tipo de evento";
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(951, 23);
            this.LblTitulo.TabIndex = 68;
            this.LblTitulo.Text = "CALENDARIO DE EVENTOS";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbMes
            // 
            this.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMes.FormattingEnabled = true;
            this.CmbMes.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.CmbMes.Location = new System.Drawing.Point(403, 47);
            this.CmbMes.Name = "CmbMes";
            this.CmbMes.Size = new System.Drawing.Size(173, 28);
            this.CmbMes.TabIndex = 5;
            this.CmbMes.SelectedIndexChanged += new System.EventHandler(this.CmbMes_SelectedIndexChanged);
            // 
            // LblMes
            // 
            this.LblMes.AutoSize = true;
            this.LblMes.Location = new System.Drawing.Point(400, 31);
            this.LblMes.Name = "LblMes";
            this.LblMes.Size = new System.Drawing.Size(27, 13);
            this.LblMes.TabIndex = 4;
            this.LblMes.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Año";
            // 
            // CmbYear
            // 
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.FormattingEnabled = true;
            this.CmbYear.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.CmbYear.Location = new System.Drawing.Point(221, 47);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.Size = new System.Drawing.Size(173, 28);
            this.CmbYear.TabIndex = 2;
            this.CmbYear.SelectedIndexChanged += new System.EventHandler(this.CmbYear_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Visualizar";
            // 
            // CmbVisualizar
            // 
            this.CmbVisualizar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbVisualizar.Enabled = false;
            this.CmbVisualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbVisualizar.FormattingEnabled = true;
            this.CmbVisualizar.Items.AddRange(new object[] {
            "DIAS",
            "SEMANAS"});
            this.CmbVisualizar.Location = new System.Drawing.Point(12, 47);
            this.CmbVisualizar.Name = "CmbVisualizar";
            this.CmbVisualizar.Size = new System.Drawing.Size(203, 28);
            this.CmbVisualizar.TabIndex = 0;
            this.CmbVisualizar.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DgvEventos
            // 
            this.DgvEventos.AllowUserToAddRows = false;
            this.DgvEventos.AllowUserToResizeRows = false;
            this.DgvEventos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEventos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.tipo,
            this.hora,
            this.invitados});
            this.DgvEventos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvEventos.Location = new System.Drawing.Point(0, 21);
            this.DgvEventos.Name = "DgvEventos";
            this.DgvEventos.ReadOnly = true;
            this.DgvEventos.RowHeadersVisible = false;
            this.DgvEventos.Size = new System.Drawing.Size(951, 121);
            this.DgvEventos.TabIndex = 70;
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nombre del evento";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo de evento";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 220;
            // 
            // hora
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hora.DefaultCellStyle = dataGridViewCellStyle2;
            this.hora.HeaderText = "Hora";
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            // 
            // invitados
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.invitados.DefaultCellStyle = dataGridViewCellStyle3;
            this.invitados.HeaderText = "Invitados";
            this.invitados.Name = "invitados";
            this.invitados.ReadOnly = true;
            this.invitados.Width = 300;
            // 
            // LblEventosProgramados
            // 
            this.LblEventosProgramados.BackColor = System.Drawing.Color.Black;
            this.LblEventosProgramados.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblEventosProgramados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEventosProgramados.ForeColor = System.Drawing.Color.White;
            this.LblEventosProgramados.Location = new System.Drawing.Point(0, 0);
            this.LblEventosProgramados.Name = "LblEventosProgramados";
            this.LblEventosProgramados.Size = new System.Drawing.Size(951, 21);
            this.LblEventosProgramados.TabIndex = 69;
            this.LblEventosProgramados.Text = "EVENTOS PROGRAMADOS";
            this.LblEventosProgramados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DivisorPrincipal
            // 
            this.DivisorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DivisorPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.DivisorPrincipal.Location = new System.Drawing.Point(0, 87);
            this.DivisorPrincipal.Name = "DivisorPrincipal";
            this.DivisorPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // DivisorPrincipal.Panel1
            // 
            this.DivisorPrincipal.Panel1.Controls.Add(this.DgvCalendario);
            // 
            // DivisorPrincipal.Panel2
            // 
            this.DivisorPrincipal.Panel2.Controls.Add(this.DgvEventos);
            this.DivisorPrincipal.Panel2.Controls.Add(this.LblEventosProgramados);
            this.DivisorPrincipal.Size = new System.Drawing.Size(951, 311);
            this.DivisorPrincipal.SplitterDistance = 165;
            this.DivisorPrincipal.TabIndex = 71;
            // 
            // FrmCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 398);
            this.Controls.Add(this.DivisorPrincipal);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCalendario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendario de eventos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCalendario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCalendario)).EndInit();
            this.MenuOpcionesCalendario.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEventos)).EndInit();
            this.DivisorPrincipal.Panel1.ResumeLayout(false);
            this.DivisorPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DivisorPrincipal)).EndInit();
            this.DivisorPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvCalendario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbVisualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbYear;
        private System.Windows.Forms.ComboBox CmbMes;
        private System.Windows.Forms.Label LblMes;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ContextMenuStrip MenuOpcionesCalendario;
        private System.Windows.Forms.ToolStripMenuItem programarEventoToolStripMenuItem;
        private System.Windows.Forms.Label LblEventosProgramados;
        private System.Windows.Forms.DataGridView DgvEventos;
        private System.Windows.Forms.SplitContainer DivisorPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn invitados;
        private System.Windows.Forms.ComboBox CmbTipoEvento;
        private System.Windows.Forms.Label label3;
    }
}
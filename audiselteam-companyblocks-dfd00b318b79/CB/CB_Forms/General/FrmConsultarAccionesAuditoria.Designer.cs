namespace CB
{
    partial class FrmConsultarAccionesAuditoria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarAccionesAuditoria));
            this.label4 = new System.Windows.Forms.Label();
            this.DgvChecklist5S = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.punto_inspeccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notas_auditor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MenuPuntosInspeccion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enProcesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DgvChecklist5S)).BeginInit();
            this.MenuPuntosInspeccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(994, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "MIS ACCIONES 5S\'S";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvChecklist5S
            // 
            this.DgvChecklist5S.AllowUserToAddRows = false;
            this.DgvChecklist5S.AllowUserToDeleteRows = false;
            this.DgvChecklist5S.AllowUserToResizeRows = false;
            this.DgvChecklist5S.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvChecklist5S.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DgvChecklist5S.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvChecklist5S.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.area,
            this.punto_inspeccion,
            this.etapa,
            this.resultado,
            this.notas_auditor,
            this.responsable,
            this.avance});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvChecklist5S.DefaultCellStyle = dataGridViewCellStyle20;
            this.DgvChecklist5S.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvChecklist5S.Location = new System.Drawing.Point(0, 23);
            this.DgvChecklist5S.MultiSelect = false;
            this.DgvChecklist5S.Name = "DgvChecklist5S";
            this.DgvChecklist5S.ReadOnly = true;
            this.DgvChecklist5S.RowHeadersVisible = false;
            this.DgvChecklist5S.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvChecklist5S.Size = new System.Drawing.Size(994, 374);
            this.DgvChecklist5S.TabIndex = 9;
            this.DgvChecklist5S.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvChecklist5S_CellClick);
            this.DgvChecklist5S.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvChecklist5S_CellFormatting);
            this.DgvChecklist5S.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvChecklist5S_CellMouseDown);
            this.DgvChecklist5S.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvChecklist5S_MouseClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle12;
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // area
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.area.DefaultCellStyle = dataGridViewCellStyle13;
            this.area.Frozen = true;
            this.area.HeaderText = "Area";
            this.area.Name = "area";
            this.area.ReadOnly = true;
            // 
            // punto_inspeccion
            // 
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.punto_inspeccion.DefaultCellStyle = dataGridViewCellStyle14;
            this.punto_inspeccion.Frozen = true;
            this.punto_inspeccion.HeaderText = "Punto de inspección";
            this.punto_inspeccion.Name = "punto_inspeccion";
            this.punto_inspeccion.ReadOnly = true;
            this.punto_inspeccion.Width = 300;
            // 
            // etapa
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.etapa.DefaultCellStyle = dataGridViewCellStyle15;
            this.etapa.Frozen = true;
            this.etapa.HeaderText = "Etapa";
            this.etapa.Name = "etapa";
            this.etapa.ReadOnly = true;
            // 
            // resultado
            // 
            this.resultado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultado.DefaultCellStyle = dataGridViewCellStyle16;
            this.resultado.Frozen = true;
            this.resultado.HeaderText = "Resultado";
            this.resultado.Name = "resultado";
            this.resultado.ReadOnly = true;
            this.resultado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.resultado.Width = 80;
            // 
            // notas_auditor
            // 
            this.notas_auditor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.notas_auditor.DefaultCellStyle = dataGridViewCellStyle17;
            this.notas_auditor.HeaderText = "Notas del auditor";
            this.notas_auditor.Name = "notas_auditor";
            this.notas_auditor.ReadOnly = true;
            // 
            // responsable
            // 
            this.responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable.DefaultCellStyle = dataGridViewCellStyle18;
            this.responsable.HeaderText = "Responsable";
            this.responsable.MinimumWidth = 120;
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            this.responsable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.responsable.Width = 120;
            // 
            // avance
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.avance.DefaultCellStyle = dataGridViewCellStyle19;
            this.avance.HeaderText = "Estatus";
            this.avance.MinimumWidth = 90;
            this.avance.Name = "avance";
            this.avance.ReadOnly = true;
            this.avance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.avance.Width = 90;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "external_icon_48.png");
            this.imageList1.Images.SetKeyName(1, "internal_icon_48.png");
            this.imageList1.Images.SetKeyName(2, "checklist-48.png");
            this.imageList1.Images.SetKeyName(3, "piezas_fabricadas.png");
            // 
            // MenuPuntosInspeccion
            // 
            this.MenuPuntosInspeccion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enProcesoToolStripMenuItem,
            this.terminarToolStripMenuItem});
            this.MenuPuntosInspeccion.Name = "MenuPuntosInspeccion";
            this.MenuPuntosInspeccion.Size = new System.Drawing.Size(133, 48);
            // 
            // enProcesoToolStripMenuItem
            // 
            this.enProcesoToolStripMenuItem.Image = global::CB_Base.Properties.Resources.en_proceso_a_tiempo_24;
            this.enProcesoToolStripMenuItem.Name = "enProcesoToolStripMenuItem";
            this.enProcesoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.enProcesoToolStripMenuItem.Text = "En proceso";
            this.enProcesoToolStripMenuItem.Click += new System.EventHandler(this.enProcesoToolStripMenuItem_Click);
            // 
            // terminarToolStripMenuItem
            // 
            this.terminarToolStripMenuItem.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.terminarToolStripMenuItem.Name = "terminarToolStripMenuItem";
            this.terminarToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.terminarToolStripMenuItem.Text = "Terminar";
            this.terminarToolStripMenuItem.Click += new System.EventHandler(this.terminarToolStripMenuItem_Click);
            // 
            // FrmConsultarAccionesAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 397);
            this.Controls.Add(this.DgvChecklist5S);
            this.Controls.Add(this.label4);
            this.Name = "FrmConsultarAccionesAuditoria";
            this.Text = "Consultar acciones 5S\'s";
            this.Load += new System.EventHandler(this.FrmTerminarAccionesAuditoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvChecklist5S)).EndInit();
            this.MenuPuntosInspeccion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DgvChecklist5S;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip MenuPuntosInspeccion;
        private System.Windows.Forms.ToolStripMenuItem terminarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn area;
        private System.Windows.Forms.DataGridViewTextBoxColumn punto_inspeccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn notas_auditor;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn avance;
        private System.Windows.Forms.ToolStripMenuItem enProcesoToolStripMenuItem;
    }
}
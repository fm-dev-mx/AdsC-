namespace CB
{
    partial class FrmSeleccionarCompetencia
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
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgvHabilidadesPersonales = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.habilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvHabilidadesTecnicas = new System.Windows.Forms.DataGridView();
            this.id_habilidad_tecnica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccion_tecnicas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.habilidad_tecnica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.LblPlanoCargado = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesPersonales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesTecnicas)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.close;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(352, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 64);
            this.BtnSalir.TabIndex = 122;
            this.BtnSalir.Text = "    Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSeleccionar.Location = new System.Drawing.Point(489, 0);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(137, 64);
            this.BtnSeleccionar.TabIndex = 123;
            this.BtnSeleccionar.Text = "      Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.BtnSeleccionar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 64);
            this.panel1.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvHabilidadesPersonales);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvHabilidadesTecnicas);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(626, 274);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 12;
            // 
            // DgvHabilidadesPersonales
            // 
            this.DgvHabilidadesPersonales.AllowUserToAddRows = false;
            this.DgvHabilidadesPersonales.AllowUserToDeleteRows = false;
            this.DgvHabilidadesPersonales.AllowUserToResizeColumns = false;
            this.DgvHabilidadesPersonales.AllowUserToResizeRows = false;
            this.DgvHabilidadesPersonales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHabilidadesPersonales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.seleccion,
            this.habilidad});
            this.DgvHabilidadesPersonales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHabilidadesPersonales.Location = new System.Drawing.Point(0, 23);
            this.DgvHabilidadesPersonales.Name = "DgvHabilidadesPersonales";
            this.DgvHabilidadesPersonales.RowHeadersVisible = false;
            this.DgvHabilidadesPersonales.Size = new System.Drawing.Size(318, 251);
            this.DgvHabilidadesPersonales.TabIndex = 8;
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
            this.seleccion.Width = 50;
            // 
            // habilidad
            // 
            this.habilidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.habilidad.HeaderText = "";
            this.habilidad.Name = "habilidad";
            this.habilidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.habilidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "PERSONALES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvHabilidadesTecnicas
            // 
            this.DgvHabilidadesTecnicas.AllowUserToAddRows = false;
            this.DgvHabilidadesTecnicas.AllowUserToDeleteRows = false;
            this.DgvHabilidadesTecnicas.AllowUserToResizeColumns = false;
            this.DgvHabilidadesTecnicas.AllowUserToResizeRows = false;
            this.DgvHabilidadesTecnicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHabilidadesTecnicas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_habilidad_tecnica,
            this.seleccion_tecnicas,
            this.habilidad_tecnica});
            this.DgvHabilidadesTecnicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHabilidadesTecnicas.Location = new System.Drawing.Point(0, 23);
            this.DgvHabilidadesTecnicas.Name = "DgvHabilidadesTecnicas";
            this.DgvHabilidadesTecnicas.RowHeadersVisible = false;
            this.DgvHabilidadesTecnicas.Size = new System.Drawing.Size(304, 251);
            this.DgvHabilidadesTecnicas.TabIndex = 8;
            // 
            // id_habilidad_tecnica
            // 
            this.id_habilidad_tecnica.HeaderText = "ID";
            this.id_habilidad_tecnica.Name = "id_habilidad_tecnica";
            this.id_habilidad_tecnica.Visible = false;
            // 
            // seleccion_tecnicas
            // 
            this.seleccion_tecnicas.HeaderText = "";
            this.seleccion_tecnicas.Name = "seleccion_tecnicas";
            this.seleccion_tecnicas.Width = 50;
            // 
            // habilidad_tecnica
            // 
            this.habilidad_tecnica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.habilidad_tecnica.HeaderText = "";
            this.habilidad_tecnica.Name = "habilidad_tecnica";
            this.habilidad_tecnica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.habilidad_tecnica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "TECNICAS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPlanoCargado
            // 
            this.LblPlanoCargado.BackColor = System.Drawing.Color.Black;
            this.LblPlanoCargado.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPlanoCargado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPlanoCargado.ForeColor = System.Drawing.Color.White;
            this.LblPlanoCargado.Location = new System.Drawing.Point(0, 0);
            this.LblPlanoCargado.Name = "LblPlanoCargado";
            this.LblPlanoCargado.Size = new System.Drawing.Size(626, 23);
            this.LblPlanoCargado.TabIndex = 9;
            this.LblPlanoCargado.Text = "SELECCIONAR COMPETENCIAS";
            this.LblPlanoCargado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblPlanoCargado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblPlanoCargado_MouseDown);
            // 
            // FrmSeleccionarCompetencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 361);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblPlanoCargado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeleccionarCompetencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de competencias";
            this.Load += new System.EventHandler(this.SeleccionarCompetencia_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesPersonales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidadesTecnicas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnSeleccionar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvHabilidadesPersonales;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvHabilidadesTecnicas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblPlanoCargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_habilidad_tecnica;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion_tecnicas;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilidad_tecnica;
    }
}
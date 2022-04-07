namespace CB
{
    partial class FrmSeleccionarHabilidades
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
            this.DgvHabilidades = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.habilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblPlanoCargado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidades)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvHabilidades
            // 
            this.DgvHabilidades.AllowUserToAddRows = false;
            this.DgvHabilidades.AllowUserToDeleteRows = false;
            this.DgvHabilidades.AllowUserToResizeColumns = false;
            this.DgvHabilidades.AllowUserToResizeRows = false;
            this.DgvHabilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHabilidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.seleccion,
            this.habilidad});
            this.DgvHabilidades.Location = new System.Drawing.Point(0, 23);
            this.DgvHabilidades.Name = "DgvHabilidades";
            this.DgvHabilidades.RowHeadersVisible = false;
            this.DgvHabilidades.Size = new System.Drawing.Size(455, 271);
            this.DgvHabilidades.TabIndex = 7;
            this.DgvHabilidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHabilidades_CellContentClick);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSeleccionar);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 64);
            this.panel1.TabIndex = 8;
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSeleccionar.Location = new System.Drawing.Point(318, 0);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(137, 64);
            this.BtnSeleccionar.TabIndex = 123;
            this.BtnSeleccionar.Text = "      Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.close;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 64);
            this.BtnSalir.TabIndex = 122;
            this.BtnSalir.Text = "      Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblPlanoCargado
            // 
            this.LblPlanoCargado.BackColor = System.Drawing.Color.Black;
            this.LblPlanoCargado.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPlanoCargado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPlanoCargado.ForeColor = System.Drawing.Color.White;
            this.LblPlanoCargado.Location = new System.Drawing.Point(0, 0);
            this.LblPlanoCargado.Name = "LblPlanoCargado";
            this.LblPlanoCargado.Size = new System.Drawing.Size(455, 23);
            this.LblPlanoCargado.TabIndex = 6;
            this.LblPlanoCargado.Text = "SELECCIONAR COMPETENCIAS";
            this.LblPlanoCargado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblPlanoCargado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblPlanoCargado_MouseDown);
            // 
            // FrmSeleccionarHabilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 358);
            this.Controls.Add(this.DgvHabilidades);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblPlanoCargado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeleccionarHabilidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar habilidades";
            this.Load += new System.EventHandler(this.FrmSeleccionarHabilidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHabilidades)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblPlanoCargado;
        private System.Windows.Forms.DataGridView DgvHabilidades;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSeleccionar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilidad;
    }
}
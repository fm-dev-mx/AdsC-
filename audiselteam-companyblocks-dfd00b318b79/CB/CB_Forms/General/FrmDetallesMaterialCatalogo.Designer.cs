namespace CB
{
    partial class FrmDetallesMaterialCatalogo
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("General", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Requisición", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Registro", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Compra", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Almacén", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Ensamble", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Mantenimiento", System.Windows.Forms.HorizontalAlignment.Left);
            this.saveDXF = new System.Windows.Forms.SaveFileDialog();
            this.LvInfoMaterial = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LvInfoMaterial
            // 
            this.LvInfoMaterial.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            listViewGroup1.Header = "General";
            listViewGroup1.Name = "General";
            listViewGroup1.Tag = "General";
            listViewGroup2.Header = "Requisición";
            listViewGroup2.Name = "Requisicion";
            listViewGroup2.Tag = "Requisicion";
            listViewGroup3.Header = "Registro";
            listViewGroup3.Name = "Registro";
            listViewGroup3.Tag = "Registro";
            listViewGroup4.Header = "Compra";
            listViewGroup4.Name = "Compra";
            listViewGroup4.Tag = "Compra";
            listViewGroup5.Header = "Almacén";
            listViewGroup5.Name = "Almacen";
            listViewGroup5.Tag = "Almacen";
            listViewGroup6.Header = "Ensamble";
            listViewGroup6.Name = "Ensamble";
            listViewGroup6.Tag = "Ensamble";
            listViewGroup7.Header = "Mantenimiento";
            listViewGroup7.Name = "Mantenimiento";
            listViewGroup7.Tag = "Mantenimiento";
            this.LvInfoMaterial.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7});
            this.LvInfoMaterial.Location = new System.Drawing.Point(19, 41);
            this.LvInfoMaterial.Name = "LvInfoMaterial";
            this.LvInfoMaterial.Size = new System.Drawing.Size(562, 441);
            this.LvInfoMaterial.TabIndex = 29;
            this.LvInfoMaterial.UseCompatibleStateImageBehavior = false;
            this.LvInfoMaterial.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Propiedad";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Valor";
            this.columnHeader2.Width = 446;
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(382, 496);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(199, 41);
            this.BtnSalir.TabIndex = 40;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(600, 23);
            this.LblTitulo.TabIndex = 39;
            this.LblTitulo.Text = "DETALLES DE LA REQUISICION DE COMPRA";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // FrmDetallesMaterialCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 548);
            this.Controls.Add(this.LvInfoMaterial);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetallesMaterialCatalogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetallesMaterialProyecto";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LvInfoMaterial;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.SaveFileDialog saveDXF;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblTitulo;

    }
}
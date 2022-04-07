namespace CB
{
    partial class FrmCapturarCotizacionMaterial
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
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblNumeroDeParte = new System.Windows.Forms.Label();
            this.NumPrecioUnitario = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumTiempoEntrega = new System.Windows.Forms.NumericUpDown();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnCapturar = new System.Windows.Forms.Button();
            this.LblError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NumCorroborarPrecio = new System.Windows.Forms.NumericUpDown();
            this.CmbMoneda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NumCantidadDisponible = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.LblTipoVenta = new System.Windows.Forms.Label();
            this.CmbTiempo = new System.Windows.Forms.ComboBox();
            this.BtnResetear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrecioUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTiempoEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumCorroborarPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidadDisponible)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Black;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(501, 23);
            this.LblTitulo.TabIndex = 4;
            this.LblTitulo.Text = "CAPTURAR COTIZACION DE MATERIAL";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblNumeroDeParte
            // 
            this.LblNumeroDeParte.AutoSize = true;
            this.LblNumeroDeParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroDeParte.Location = new System.Drawing.Point(12, 38);
            this.LblNumeroDeParte.Name = "LblNumeroDeParte";
            this.LblNumeroDeParte.Size = new System.Drawing.Size(231, 25);
            this.LblNumeroDeParte.TabIndex = 5;
            this.LblNumeroDeParte.Text = "NUMERO DE PARTE";
            // 
            // NumPrecioUnitario
            // 
            this.NumPrecioUnitario.DecimalPlaces = 2;
            this.NumPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPrecioUnitario.Location = new System.Drawing.Point(17, 109);
            this.NumPrecioUnitario.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.NumPrecioUnitario.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.NumPrecioUnitario.Name = "NumPrecioUnitario";
            this.NumPrecioUnitario.Size = new System.Drawing.Size(226, 40);
            this.NumPrecioUnitario.TabIndex = 1;
            this.NumPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPrecioUnitario.ValueChanged += new System.EventHandler(this.NumPrecioUnitario_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Precio unitario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tiempo de entrega:";
            // 
            // NumTiempoEntrega
            // 
            this.NumTiempoEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumTiempoEntrega.Location = new System.Drawing.Point(17, 184);
            this.NumTiempoEntrega.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumTiempoEntrega.Name = "NumTiempoEntrega";
            this.NumTiempoEntrega.Size = new System.Drawing.Size(226, 40);
            this.NumTiempoEntrega.TabIndex = 3;
            this.NumTiempoEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumTiempoEntrega.ValueChanged += new System.EventHandler(this.NumTiempoEntrega_ValueChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = global::CB_Base.Properties.Resources.close;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(170, 447);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(159, 42);
            this.BtnCancelar.TabIndex = 6;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnCapturar
            // 
            this.BtnCapturar.Enabled = false;
            this.BtnCapturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCapturar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnCapturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCapturar.Location = new System.Drawing.Point(335, 447);
            this.BtnCapturar.Name = "BtnCapturar";
            this.BtnCapturar.Size = new System.Drawing.Size(146, 42);
            this.BtnCapturar.TabIndex = 7;
            this.BtnCapturar.Text = "Capturar";
            this.BtnCapturar.UseVisualStyleBackColor = true;
            this.BtnCapturar.Click += new System.EventHandler(this.BtnCapturar_Click);
            // 
            // LblError
            // 
            this.LblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.Red;
            this.LblError.Location = new System.Drawing.Point(14, 392);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(468, 42);
            this.LblError.TabIndex = 58;
            this.LblError.Text = "Error";
            this.LblError.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 60;
            this.label4.Text = "Corroborar precio:";
            // 
            // NumCorroborarPrecio
            // 
            this.NumCorroborarPrecio.DecimalPlaces = 2;
            this.NumCorroborarPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumCorroborarPrecio.Location = new System.Drawing.Point(255, 109);
            this.NumCorroborarPrecio.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.NumCorroborarPrecio.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.NumCorroborarPrecio.Name = "NumCorroborarPrecio";
            this.NumCorroborarPrecio.Size = new System.Drawing.Size(226, 40);
            this.NumCorroborarPrecio.TabIndex = 2;
            this.NumCorroborarPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumCorroborarPrecio.ValueChanged += new System.EventHandler(this.NumCorroborarPrecio_ValueChanged);
            // 
            // CmbMoneda
            // 
            this.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMoneda.FormattingEnabled = true;
            this.CmbMoneda.Items.AddRange(new object[] {
            "MXN",
            "USD",
            "EUR"});
            this.CmbMoneda.Location = new System.Drawing.Point(17, 259);
            this.CmbMoneda.Name = "CmbMoneda";
            this.CmbMoneda.Size = new System.Drawing.Size(226, 37);
            this.CmbMoneda.TabIndex = 4;
            this.CmbMoneda.SelectedIndexChanged += new System.EventHandler(this.CmbMoneda_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 62;
            this.label1.Text = "Moneda:";
            // 
            // NumCantidadDisponible
            // 
            this.NumCantidadDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumCantidadDisponible.Location = new System.Drawing.Point(16, 331);
            this.NumCantidadDisponible.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.NumCantidadDisponible.Name = "NumCantidadDisponible";
            this.NumCantidadDisponible.Size = new System.Drawing.Size(226, 40);
            this.NumCantidadDisponible.TabIndex = 5;
            this.NumCantidadDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumCantidadDisponible.ValueChanged += new System.EventHandler(this.NumCantidadDisponible_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 20);
            this.label6.TabIndex = 64;
            this.label6.Text = "Cantidad disponible:";
            // 
            // LblTipoVenta
            // 
            this.LblTipoVenta.AutoSize = true;
            this.LblTipoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipoVenta.Location = new System.Drawing.Point(248, 337);
            this.LblTipoVenta.Name = "LblTipoVenta";
            this.LblTipoVenta.Size = new System.Drawing.Size(192, 29);
            this.LblTipoVenta.TabIndex = 65;
            this.LblTipoVenta.Text = "PAQ. C/50 PZAS";
            // 
            // CmbTiempo
            // 
            this.CmbTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTiempo.FormattingEnabled = true;
            this.CmbTiempo.Items.AddRange(new object[] {
            "DIAS",
            "SEMANAS"});
            this.CmbTiempo.Location = new System.Drawing.Point(255, 184);
            this.CmbTiempo.Name = "CmbTiempo";
            this.CmbTiempo.Size = new System.Drawing.Size(226, 37);
            this.CmbTiempo.TabIndex = 66;
            // 
            // BtnResetear
            // 
            this.BtnResetear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnResetear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnResetear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResetear.Image = global::CB_Base.Properties.Resources.clean_image;
            this.BtnResetear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnResetear.Location = new System.Drawing.Point(16, 447);
            this.BtnResetear.Name = "BtnResetear";
            this.BtnResetear.Size = new System.Drawing.Size(148, 42);
            this.BtnResetear.TabIndex = 67;
            this.BtnResetear.Text = "    Limpiar";
            this.BtnResetear.UseVisualStyleBackColor = true;
            this.BtnResetear.Click += new System.EventHandler(this.BtnResetear_Click);
            // 
            // FrmCapturarCotizacionMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 504);
            this.Controls.Add(this.BtnResetear);
            this.Controls.Add(this.CmbTiempo);
            this.Controls.Add(this.LblTipoVenta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NumCantidadDisponible);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbMoneda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumCorroborarPrecio);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnCapturar);
            this.Controls.Add(this.NumTiempoEntrega);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumPrecioUnitario);
            this.Controls.Add(this.LblNumeroDeParte);
            this.Controls.Add(this.LblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCapturarCotizacionMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCapturarCotizacionMaterial";
            this.Load += new System.EventHandler(this.FrmCapturarCotizacionMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumPrecioUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTiempoEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumCorroborarPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidadDisponible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblNumeroDeParte;
        private System.Windows.Forms.NumericUpDown NumPrecioUnitario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumTiempoEntrega;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnCapturar;
        private System.Windows.Forms.Label LblError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumCorroborarPrecio;
        private System.Windows.Forms.ComboBox CmbMoneda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumCantidadDisponible;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblTipoVenta;
        private System.Windows.Forms.ComboBox CmbTiempo;
        private System.Windows.Forms.Button BtnResetear;
    }
}
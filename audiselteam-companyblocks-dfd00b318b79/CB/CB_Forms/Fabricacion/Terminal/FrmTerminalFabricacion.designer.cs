namespace CB
{
    partial class FrmTerminalFabricacion
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
            this.PanelVentana = new System.Windows.Forms.Panel();
            this.BkgConectarFtp = new System.ComponentModel.BackgroundWorker();
            this.BkgDescargarPlanos = new System.ComponentModel.BackgroundWorker();
            this.TimerRefrescarPlanos = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PanelVentana
            // 
            this.PanelVentana.BackColor = System.Drawing.Color.Black;
            this.PanelVentana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelVentana.Location = new System.Drawing.Point(0, 0);
            this.PanelVentana.Name = "PanelVentana";
            this.PanelVentana.Size = new System.Drawing.Size(896, 526);
            this.PanelVentana.TabIndex = 2;
            this.PanelVentana.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelVentana_Paint);
            // 
            // BkgConectarFtp
            // 
            this.BkgConectarFtp.WorkerReportsProgress = true;
            this.BkgConectarFtp.WorkerSupportsCancellation = true;
            this.BkgConectarFtp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgConectarFtp_DoWork);
            this.BkgConectarFtp.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkgConectarFtp_ProgressChanged);
            this.BkgConectarFtp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgConectarFtp_RunWorkerCompleted);
            // 
            // BkgDescargarPlanos
            // 
            this.BkgDescargarPlanos.WorkerReportsProgress = true;
            this.BkgDescargarPlanos.WorkerSupportsCancellation = true;
            // 
            // FrmTerminalFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 526);
            this.ControlBox = false;
            this.Controls.Add(this.PanelVentana);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "FrmTerminalFabricacion";
            this.Text = "Consola de fabricacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTerminalFabricacion_FormClosing);
            this.Load += new System.EventHandler(this.FrmTerminalFabricacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelVentana;
        private System.ComponentModel.BackgroundWorker BkgConectarFtp;
        private System.ComponentModel.BackgroundWorker BkgDescargarPlanos;
        private System.Windows.Forms.Timer TimerRefrescarPlanos;


    }
}
namespace CB
{
    partial class FrmSeleccionarProveedorMultiplesRequisiciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionarProveedorMultiplesRequisiciones));
            this.TvConceptos = new System.Windows.Forms.TestTreeView();//new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnSeleccionarNada = new System.Windows.Forms.Button();
            this.BtnSeleccionarTodo = new System.Windows.Forms.Button();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.audiselTituloForm1 = new CB_Base.CB_Controles.AudiselTituloForm();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TvConceptos
            // 
            this.TvConceptos.CheckBoxes = true;
            this.TvConceptos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvConceptos.ImageIndex = 0;
            this.TvConceptos.ImageList = this.imageList1;
            this.TvConceptos.Location = new System.Drawing.Point(0, 79);
            this.TvConceptos.Name = "TvConceptos";
            this.TvConceptos.SelectedImageIndex = 0;
            this.TvConceptos.Size = new System.Drawing.Size(680, 438);
            this.TvConceptos.TabIndex = 1;
            this.TvConceptos.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvConceptos_BeforeCheck);
            this.TvConceptos.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvConceptos_AfterCheck);
            this.TvConceptos.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvConceptos_NodeMouseClick);
            this.TvConceptos.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvConceptos_NodeMouseDoubleClick);
            this.TvConceptos.DoubleClick += new System.EventHandler(this.TvConceptos_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "marker_icon_32.png");
            this.imageList1.Images.SetKeyName(1, "index_48.png");
            this.imageList1.Images.SetKeyName(2, "rfq (1).png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.BtnAceptar);
            this.panel1.Controls.Add(this.BtnSeleccionarNada);
            this.panel1.Controls.Add(this.BtnSeleccionarTodo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 517);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 67);
            this.panel1.TabIndex = 2;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::CB_Base.Properties.Resources.exit;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(374, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(153, 67);
            this.BtnSalir.TabIndex = 3;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Image = global::CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(527, 0);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(153, 67);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnSeleccionarNada
            // 
            this.BtnSeleccionarNada.Location = new System.Drawing.Point(156, 16);
            this.BtnSeleccionarNada.Name = "BtnSeleccionarNada";
            this.BtnSeleccionarNada.Size = new System.Drawing.Size(138, 26);
            this.BtnSeleccionarNada.TabIndex = 1;
            this.BtnSeleccionarNada.Text = "Seleccionar nada";
            this.BtnSeleccionarNada.UseVisualStyleBackColor = true;
            this.BtnSeleccionarNada.Click += new System.EventHandler(this.BtnSeleccionarNada_Click);
            // 
            // BtnSeleccionarTodo
            // 
            this.BtnSeleccionarTodo.Location = new System.Drawing.Point(12, 16);
            this.BtnSeleccionarTodo.Name = "BtnSeleccionarTodo";
            this.BtnSeleccionarTodo.Size = new System.Drawing.Size(138, 26);
            this.BtnSeleccionarTodo.TabIndex = 0;
            this.BtnSeleccionarTodo.Text = "Seleccionar todo";
            this.BtnSeleccionarTodo.UseVisualStyleBackColor = true;
            this.BtnSeleccionarTodo.Click += new System.EventHandler(this.BtnSeleccionarTodo_Click);
            // 
            // lblProveedor
            // 
            this.lblProveedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(0, 25);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(680, 25);
            this.lblProveedor.TabIndex = 3;
            this.lblProveedor.Text = "Proveedor seleccionado:";
            this.lblProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // audiselTituloForm1
            // 
            this.audiselTituloForm1.AlturaFija = 23;
            this.audiselTituloForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.audiselTituloForm1.Location = new System.Drawing.Point(0, 0);
            this.audiselTituloForm1.Name = "audiselTituloForm1";
            this.audiselTituloForm1.Size = new System.Drawing.Size(680, 23);
            this.audiselTituloForm1.TabIndex = 0;
            this.audiselTituloForm1.Text = "SELECCIONAR PROVEEDOR";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(680, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Partidas seleccionadas con precio capturado.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblProveedor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 56);
            this.panel2.TabIndex = 5;
            // 
            // FrmSeleccionarProveedorMultiplesRequisiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 584);
            this.Controls.Add(this.TvConceptos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.audiselTituloForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeleccionarProveedorMultiplesRequisiciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar proveedor";
            this.Load += new System.EventHandler(this.FrmSeleccionarProveedorMultiplesRequisiciones_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CB_Base.CB_Controles.AudiselTituloForm audiselTituloForm1;
        private System.Windows.Forms.TreeView TvConceptos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSeleccionarNada;
        private System.Windows.Forms.Button BtnSeleccionarTodo;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}

namespace System.Windows.Forms
{
    public class TestTreeView : TreeView
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203) // identified double click
                m.Result = IntPtr.Zero;
            else
                base.WndProc(ref m);
        }
    }
}
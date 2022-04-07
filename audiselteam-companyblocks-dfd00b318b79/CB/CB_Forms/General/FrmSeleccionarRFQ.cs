using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmSeleccionarRFQ : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public int RfqSeleccionado = 0;
        string prov = "";
        string estatus = "";

        public FrmSeleccionarRFQ(string proveedor="TODOS", string estatus="TODOS")
        {
            InitializeComponent();
            this.prov = proveedor;
            this.estatus = estatus;
        }

        private void FrmSeleccionarRFQ_Load(object sender, EventArgs e)
        {
            CmbProveedor.Items.Clear();
            CmbProveedor.Items.Add("TODOS");
            Proveedor.Modelo().Todos().ForEach(delegate(Fila f)
            {
                CmbProveedor.Items.Add(f.Celda("nombre"));
            });

            CmbProveedor.Text = prov;
            CmbEstatus.Text = estatus;

            if(prov != "TODOS")
                CmbProveedor.Enabled = false;

            if(estatus != "TODOS")
                CmbEstatus.Enabled = false;

            CargarRFQs(prov, estatus);
        }

        public void CargarRFQs(string proveedor="TODOS", string estatus="TODOS")
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            string filtroProveedor = "";
            if (proveedor != "TODOS")
            {
                filtroProveedor = " AND proveedor=@proveedor";

                Proveedor p = new Proveedor();
                p.SeleccionarPorNombre(proveedor);
                if (p.TieneFilas())
                    parametros.Add("@proveedor", p.Fila().Celda("id"));
            }
            
            string filtroEstatus = "";
            if (estatus != "TODOS")
            {
                filtroEstatus = " AND estatus=@estatus";
                parametros.Add("@estatus", estatus);
            }
            
            DgvRFQ.Rows.Clear();
            RfqMaterial.Modelo().SeleccionarDatos("0<1" + filtroProveedor + filtroEstatus + " ORDER BY id DESC", parametros).ForEach(delegate(Fila rfq) 
            {
                Proveedor prov = new Proveedor();
                prov.CargarDatos(Convert.ToInt32(rfq.Celda("proveedor")));

                DgvRFQ.Rows.Add(rfq.Celda("id"), prov.Fila().Celda("nombre"), rfq.Celda("usuario"), rfq.Celda("fecha_creacion") );
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRFQs(CmbProveedor.Text, CmbEstatus.Text);
        }

        private void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRFQs(CmbProveedor.Text, CmbEstatus.Text);
        }

        private void DgvRFQ_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvRFQ.SelectedRows.Count <= 0)
                return;

            RfqSeleccionado = Convert.ToInt32(DgvRFQ.SelectedRows[0].Cells["id"].Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

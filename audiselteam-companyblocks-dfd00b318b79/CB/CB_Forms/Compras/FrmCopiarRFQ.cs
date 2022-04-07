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

    public partial class FrmCopiarRFQ : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        int idRfq = 0;

        public FrmCopiarRFQ(int idRfq=0)
        {
            InitializeComponent();
            this.idRfq = idRfq;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnBuscarRFQ_Click(object sender, EventArgs e)
        {
            FrmSeleccionarRFQ selRfq = new FrmSeleccionarRFQ();

            if (selRfq.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NumRFQ.Value = Convert.ToDecimal(selRfq.RfqSeleccionado);
            }
        }

        public void CargarRFQ(int id)
        {
            RfqMaterial rfq = new RfqMaterial();
            rfq.CargarDatos(idRfq);
            LblUsuarioRFQ.Text = rfq.Fila().Celda("usuario").ToString();

            Proveedor prov = new Proveedor();
            prov.CargarDatos(Convert.ToInt32(rfq.Fila().Celda("proveedor")));
            LblProveedorRFQ.Text = prov.Fila().Celda("nombre").ToString();

            DgvPartidas.Rows.Clear();

            RfqConcepto.Modelo().SeleccionarRfq(id).ForEach(delegate(Fila f)
            {
                DgvPartidas.Rows.Add(f.Celda("id"), true, f.Celda("numero_parte"), f.Celda("fabricante"), f.Celda("descripcion"));
            });
            BtnCopiar.Enabled = true;
        }

        private void FrmCopiarRFQ_Load(object sender, EventArgs e)
        {
            if(idRfq > 0)
            {
                NumRFQ.Value = Convert.ToDecimal(idRfq);
                NumRFQ.Enabled = false;
                BtnBuscarRFQ.Enabled = false;
            }
        }

        private void NumRFQ_ValueChanged(object sender, EventArgs e)
        {
            CargarRFQ( Convert.ToInt32(NumRFQ.Value) );
        }



        private void BtnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in DgvPartidas.Rows)
            {
                row.Cells["seleccion"].Value = true;
            }
        }

        private void BtnSeleccionarNada_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in DgvPartidas.Rows)
            {
                row.Cells["seleccion"].Value = false;
            }
        }

        public void CopiarRFQ(int idRfqDestino=0)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres copiar las partidas seleccionadas a otro RFQ?", "Copiar partidas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (idRfqDestino == 0)
            {
                FrmSeleccionarProveedor selProv = new FrmSeleccionarProveedor();

                if (selProv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Fila rfq = new Fila();
                    rfq.AgregarCelda("fecha_creacion", DateTime.Now);
                    rfq.AgregarCelda("usuario", Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno"));
                    rfq.AgregarCelda("proveedor", selProv.IdProveedor);
                    rfq.AgregarCelda("contacto", 0);
                    rfq.AgregarCelda("fecha_envio", DateTime.Now);
                    rfq.AgregarCelda("estatus", "SIN ENVIAR");

                    rfq = RfqMaterial.Modelo().Insertar(rfq);

                    idRfqDestino = Convert.ToInt32(rfq.Celda("id"));
                }
            }

            foreach (DataGridViewRow row in DgvPartidas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["seleccion"].Value) == true)
                {
                    RfqConcepto concepto = new RfqConcepto();
                    concepto.CargarDatos(Convert.ToInt32(row.Cells["id"].Value));

                    Fila f = new Fila();
                    f.AgregarCelda("rfq", idRfqDestino);
                    f.AgregarCelda("numero_parte", concepto.Fila().Celda("numero_parte"));
                    f.AgregarCelda("fabricante", concepto.Fila().Celda("fabricante"));
                    f.AgregarCelda("descripcion", concepto.Fila().Celda("descripcion"));
                    f.AgregarCelda("precio_unitario", 0);
                    f.AgregarCelda("tiempo_entrega", 0);
                    f.AgregarCelda("moneda", "");
                    f.AgregarCelda("cantidad_disponible", 0);
                    f.AgregarCelda("cantidad_estimada", concepto.Fila().Celda("cantidad_estimada"));
                    f.AgregarCelda("tipo_venta", concepto.Fila().Celda("tipo_venta"));

                    RfqConcepto.Modelo().Insertar(f);
                    }
             }
             MessageBox.Show("Se han copiado las partidas en el RFQ #" + idRfqDestino.ToString());
             DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnCopiar_Click(object sender, EventArgs e)
        {
            if (BtnCopiar.ContextMenuStrip != null)
                BtnCopiar.ContextMenuStrip.Show(BtnCopiar, BtnCopiar.PointToClient(Cursor.Position));      
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void nuevoRFQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopiarRFQ();
        }

        private void RFQExistenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarRFQ selRfq = new FrmSeleccionarRFQ("TODOS", "SIN ENVIAR");

            if( selRfq.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                CopiarRFQ(selRfq.RfqSeleccionado);
            }
        }
    }
}

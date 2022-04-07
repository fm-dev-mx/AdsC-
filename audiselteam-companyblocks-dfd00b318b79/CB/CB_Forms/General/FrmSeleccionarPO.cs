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
    public partial class FrmSeleccionarPO : Ventana
    {
        public int PoSeleccionado = 0;
        string prov = "";
        string estatus = "";
        string moneda = "";

        public FrmSeleccionarPO(string proveedor="TODOS", string estatus="TODOS", string moneda="TODOS")
        {
            InitializeComponent();
            this.prov = proveedor;
            this.estatus = estatus;
            this.moneda = moneda;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public void CargarPOs(string proveedor = "TODOS", string estatus = "TODOS", string moneda = "TODOS")
        {
            Proveedor p = new Proveedor();
            p.SeleccionarPorNombre(proveedor);

            string filtroProveedor = "";
            if (proveedor != "TODOS")
                filtroProveedor = " AND proveedor=@proveedor";

            string filtroEstatus = "";
            if (estatus != "TODOS")
                filtroEstatus = " AND estatus=@estatus";

            string filtroMoneda = "";
            if(moneda != "TODOS")
                filtroMoneda = " AND moneda=@moneda";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            if(p.TieneFilas())
                parametros.Add("@proveedor", p.Fila().Celda("id"));
            parametros.Add("@estatus", estatus);
            parametros.Add("@moneda", moneda);

            DgvPO.Rows.Clear();
            PoMaterial.Modelo().SeleccionarDatos("0<1" + filtroProveedor + filtroEstatus + filtroMoneda + " ORDER BY id DESC", parametros).ForEach(delegate(Fila po)
            {
                Proveedor prov = new Proveedor();
                prov.CargarDatos(Convert.ToInt32(po.Celda("proveedor")));

                DgvPO.Rows.Add(po.Celda("id"), prov.Fila().Celda("nombre"), po.Celda("usuario"), po.Celda("fecha_creacion"), po.Celda("moneda"));
            });
        }

        private void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPOs(CmbProveedor.Text, CmbEstatus.Text, CmbMoneda.Text);
            BtnNuevo.Enabled = CmbProveedor.Text != "TODOS";
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPOs(CmbProveedor.Text, CmbEstatus.Text, CmbMoneda.Text);
        }

        private void FrmSeleccionarPO_Load(object sender, EventArgs e)
        {
            CmbProveedor.Items.Clear();
            CmbProveedor.Items.Add("TODOS");
            Proveedor.Modelo().Todos().ForEach(delegate(Fila f)
            {
                CmbProveedor.Items.Add(f.Celda("nombre"));
            });

            CmbProveedor.Text = prov;
            CmbEstatus.Text = estatus;
            CmbMoneda.Text = moneda;

            if (prov != "TODOS")
                CmbProveedor.Enabled = false;

            if (estatus != "TODOS")
                CmbEstatus.Enabled = false;

            if (moneda != "TODOS")
                CmbMoneda.Enabled = false;

            CargarPOs(prov, estatus);
        }

        private void DgvPO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPO.SelectedRows.Count <= 0)
                return;

            PoSeleccionado = Convert.ToInt32(DgvPO.SelectedRows[0].Cells["id"].Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void CmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPOs(CmbProveedor.Text, CmbEstatus.Text, CmbMoneda.Text);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e); 
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que deseas crear una nueva orden de compra?", "Crear PO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if( resp == System.Windows.Forms.DialogResult.Yes )
            {
                Fila po = new Fila();

                Proveedor prov = new Proveedor();
                prov.SeleccionarPorNombre(CmbProveedor.Text);

                po.AgregarCelda("fecha_creacion", DateTime.Now);
                po.AgregarCelda("usuario", Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno"));
                po.AgregarCelda("proveedor", Convert.ToInt32(prov.Fila().Celda("id") ));
                po.AgregarCelda("contacto", 0);
                po.AgregarCelda("estatus", "SIN ENVIAR");

                po = PoMaterial.Modelo().Insertar(po);
                MessageBox.Show("Se ha creado la orden de compra " + po.Celda("id").ToString() + ".");

                CargarPOs(CmbProveedor.Text, CmbEstatus.Text, CmbMoneda.Text);
            }
        }
    }
}

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
    public partial class FrmSeleccionarProveedor : Form
    {
        public int IdProveedor = 0;
        public string NombreProveedor = string.Empty;
        public Proveedor ProveedorSeleccionado = new Proveedor();

        public FrmSeleccionarProveedor()
        {
            InitializeComponent();
        }

        private void FrmSeleccionarProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores(TxtFiltro.Text);
        }

        public void CargarProveedores(string filtro)
        {
            DgvProveedores.Rows.Clear();

            Proveedor.Modelo().Buscar(filtro).ForEach(delegate(Fila prov)
            {
                DgvProveedores.Rows.Add(prov.Celda("id"), prov.Celda("nombre"), prov.Celda("categoria"));
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void DgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             if (DgvProveedores.SelectedRows.Count <= 0)
                return;

            IdProveedor = Convert.ToInt32(DgvProveedores.SelectedRows[0].Cells[0].Value);
            NombreProveedor = DgvProveedores.SelectedRows[0].Cells[1].Value.ToString();
            ProveedorSeleccionado.CargarDatos(IdProveedor);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarProveedores(TxtFiltro.Text);
        }

    }
}

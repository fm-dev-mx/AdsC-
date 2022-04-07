using CB_Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmNuevoProductoCliente : Ventana
    {
        int IdCliente = 0;
        int IdIndustria = 0;
        public Fila NuevoProducto = new Fila();

        public FrmNuevoProductoCliente()
        {
            InitializeComponent();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void CmbClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void FrmNuevoProductoCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        public void CargarClientes()
        {
            CmbCliente.Items.Clear();
            Cliente.Modelo().Activos().ForEach(delegate(Fila f)
            {
                CmbCliente.Items.Add(f.Celda("id") + " - " + f.Celda("nombre"));
            });
        }

        public void CargarIndustrias(int idCliente)
        {
            CmbIndustria.Items.Clear();
            ClienteIndustria.Modelo().SeleccionarCliente(idCliente).ForEach(delegate(Fila f)
            {
                CmbIndustria.Items.Add(f.Celda("id").ToString().PadLeft(3, '0') + " - " + f.Celda("industria"));
            });
        }

        private void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCliente.Text == string.Empty)
                return;

            IdCliente = Convert.ToInt32(CmbCliente.Text.Split('-')[0]);
            CargarIndustrias(IdCliente);
            ValidarDatos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CmbIndustria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIndustria.Text == string.Empty || CmbCliente.Text == string.Empty)
                return;

            IdCliente = Convert.ToInt32(CmbCliente.Text.Split('-')[0]);
            IdIndustria = Convert.ToInt32(CmbIndustria.Text.Split('-')[0]);

            CmbClase.Items.Clear();
            ClienteProducto.Modelo().Clases(IdCliente, IdIndustria).ForEach(delegate(Fila f)
            {
                CmbClase.Items.Add(f.Celda("clase"));
            });
            ValidarDatos();
        }

        public void ValidarDatos()
        {
            BtnCrear.Enabled = CmbCliente.Text != string.Empty && CmbIndustria.Text != string.Empty && TxtNombre.Text != string.Empty && 
                               CmbClase.Text != string.Empty && TxtDescripcion.Text != string.Empty;
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Seguro que quieres crear el producto?", "Crear producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            NuevoProducto.AgregarCelda("cliente", IdCliente);
            NuevoProducto.AgregarCelda("industria", IdIndustria);
            NuevoProducto.AgregarCelda("nombre", TxtNombre.Text);
            NuevoProducto.AgregarCelda("clase", CmbClase.Text);
            NuevoProducto.AgregarCelda("descripcion", TxtDescripcion.Text);

            NuevoProducto = ClienteProducto.Modelo().Insertar(NuevoProducto);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void CmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }
    }
}

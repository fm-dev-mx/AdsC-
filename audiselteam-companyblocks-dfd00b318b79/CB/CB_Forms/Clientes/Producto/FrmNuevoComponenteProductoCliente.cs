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
    public partial class FrmNuevoComponenteProductoCliente : Ventana
    {
        ClienteProducto Producto = new ClienteProducto();
        ClienteProductoComponente Componente = new ClienteProductoComponente();

        public FrmNuevoComponenteProductoCliente(int idProducto, int idComponente=0)
        {
            InitializeComponent();
            Producto.CargarDatos(idProducto);
            Componente.CargarDatos(idComponente);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if(Componente.TieneFilas())
            {
                Componente.Fila().ModificarCelda("nombre", TxtNombre.Text);
                Componente.GuardarDatos();
            }
            else
            {
                InsertarNuevoComponente();
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public void InsertarNuevoComponente()
        {
            Fila componente = new Fila();
            componente.AgregarCelda("producto", Producto.Fila().Celda("id"));
            componente.AgregarCelda("nombre", TxtNombre.Text);
            ClienteProductoComponente.Modelo().Insertar(componente);
        }

        private void FrmNuevoComponenteProductoCliente_Load(object sender, EventArgs e)
        {
            if(Componente.TieneFilas())
            {
                LblTitulo.Text = "EDITAR COMPONENTE";
                TxtNombre.Text = Componente.Fila().Celda("nombre").ToString();
                BtnCrear.Text = "Guardar";
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            BtnCrear.Enabled = TxtNombre.Text != string.Empty;
        }
    }
}

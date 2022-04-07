using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB_Base.Classes
{
    public partial class FrmRegistrarProductoComponente : Form
    {
        int IdCliente = 0;
        int IdComponente = 0;
        int IdProducto = 0;
        int IdCotizacion = 0;

        public FrmRegistrarProductoComponente(int idCliente, int idCotizacion, int idProducto = 0, int idComponente = 0)
        {
            InitializeComponent();
            IdCliente = idCliente;
            IdComponente = idComponente;
            IdProducto = idProducto;
            IdCotizacion = idCotizacion;
        }

        private void FrmRegistrarProductoComponente_Load(object sender, EventArgs e)
        {
            CargarProducto();

            if(IdComponente > 0)
            {
                ProductoComponente componente = new ProductoComponente();
                componente.CargarDatos(IdComponente);

                if (componente.TieneFilas())
                {
                    TxtNombre.Text = componente.Fila().Celda("nombre").ToString();
                    Producto producto = new Producto();
                    producto.CargarDatos(componente.Fila().Celda<int>("producto"));
                    if (producto.TieneFilas())
                        CmbProducto.Text = componente.Fila().Celda("producto").ToString() + " - " + producto.Fila().Celda("nombre").ToString();

                    TxtDescripcion.Text = componente.Fila().Celda("descripcion").ToString();
                }
            }
        }

        private void CargarProducto()
        {
            CmbProducto.Items.Clear();
            CmbProducto.Items.Add("N/A");

            Producto.Modelo().SeleccionarProducto(IdCliente).ForEach(delegate(Fila f)
            {
                CmbProducto.Items.Add(f.Celda<int>("id").ToString() + " - " + f.Celda("nombre").ToString());
            });

            Producto prod = new Producto();
            prod.CargarDatos(IdProducto);
            if (prod.TieneFilas())
            {
                CmbProducto.Text = prod.Fila().Celda<int>("id").ToString() + " - " + prod.Fila().Celda("nombre").ToString();
                CmbProducto.Enabled = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (IdComponente > 0)
            {
                ProductoComponente componente = new ProductoComponente();
                componente.CargarDatos(IdComponente);

                if (componente.TieneFilas())
                {
                    componente.Fila().ModificarCelda("nombre", TxtNombre.Text);
                    componente.Fila().ModificarCelda("producto", CmbProducto.Text.Split('-')[0].TrimEnd());
                    componente.Fila().ModificarCelda("descripcion", TxtDescripcion.Text);
                    componente.GuardarDatos();
                    MessageBox.Show("El Componente " + TxtNombre.Text + " fue actualizado correctamente", "Componente creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Fila insertarModelo = new Fila();
                insertarModelo.AgregarCelda("nombre", TxtNombre.Text);
                insertarModelo.AgregarCelda("producto", CmbProducto.Text.Split('-')[0].TrimEnd());
                insertarModelo.AgregarCelda("descripcion", TxtDescripcion.Text);
                insertarModelo.AgregarCelda("usuario_registro", Global.UsuarioActual.Fila().Celda<int>("id"));
                insertarModelo.AgregarCelda("fecha_registro", DateTime.Now);
                insertarModelo.AgregarCelda("id_cotizacion", IdCotizacion);
                ProductoComponente.Modelo().Insertar(insertarModelo);
                MessageBox.Show("El componente " + TxtNombre.Text + " fue creado correctamente", "Componente creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtDescripcion.Text != "" && !CmbProducto.Text.Contains("N/A"));
        }

        private void CmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtDescripcion.Text != "" && !CmbProducto.Text.Contains("N/A"));
        }
    }
}

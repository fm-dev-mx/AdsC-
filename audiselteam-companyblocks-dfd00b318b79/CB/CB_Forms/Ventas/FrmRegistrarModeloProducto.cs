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
    public partial class FrmRegistrarModeloProducto : Form
    {
        int IdModelo = 0;
        int IdCliente = 0;
        int IdIndustria = 0;
        int IdProducto = 0;
        int IdCotizacion = 0;

        public FrmRegistrarModeloProducto(int idCliente, int idCotizacion, int idIndustria = 0, int idProducto = 0, int idModelo = 0)
        {
            InitializeComponent();
            IdCliente = idCliente;
            IdModelo = idModelo;
            IdProducto = idProducto;
            IdCotizacion = idCotizacion;
        }

        private void FrmRegistrarModeloProducto_Load(object sender, EventArgs e)
        {
            CargarProducto();

            if(IdModelo > 0)
            {
                ProductoModelo productoModelo = new ProductoModelo();
                productoModelo.CargarDatos(IdModelo);

                if (productoModelo.TieneFilas())
                {
                    TxtNombre.Text = productoModelo.Fila().Celda("nombre").ToString();
                    Producto producto = new Producto();
                    producto.CargarDatos(productoModelo.Fila().Celda<int>("producto"));
                    if(producto.TieneFilas())
                        CmbProducto.Text = productoModelo.Fila().Celda("producto").ToString() + " - " + producto.Fila().Celda("nombre").ToString();
                    
                    TxtDescripcion.Text = productoModelo.Fila().Celda("descripcion").ToString();                   
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
            if(prod.TieneFilas())
            {
                CmbProducto.Text =  prod.Fila().Celda<int>("id").ToString() + " - " + prod.Fila().Celda("nombre").ToString();
                CmbProducto.Enabled = false;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (IdModelo > 0)
            {
                ProductoModelo productoModelo = new ProductoModelo();
                productoModelo.CargarDatos(IdModelo);

                if(productoModelo.TieneFilas())
                {
                    productoModelo.Fila().ModificarCelda("nombre", TxtNombre.Text);
                    productoModelo.Fila().ModificarCelda("producto", CmbProducto.Text.Split('-')[0].TrimEnd());
                    productoModelo.Fila().ModificarCelda("descripcion", TxtDescripcion.Text);
                    productoModelo.GuardarDatos();
                    MessageBox.Show("El modelo " + TxtNombre.Text + " fue actualizado correctamente", "Modelo creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ProductoModelo.Modelo().Insertar(insertarModelo);
                MessageBox.Show("El modelo " + TxtNombre.Text + " fue creado correctamente", "Modelo creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

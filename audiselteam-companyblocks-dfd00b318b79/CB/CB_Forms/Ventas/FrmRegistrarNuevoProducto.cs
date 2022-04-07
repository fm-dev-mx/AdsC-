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
    public partial class FrmRegistrarNuevoProducto : Form
    {
        int IdProducto = 0;
        int IdCliente = 0;
        int IdIndustria = 0;

        public FrmRegistrarNuevoProducto(int idProducto = 0, int idCliente = 0, int idIndustria = 0)
        {
            InitializeComponent();
            IdProducto = idProducto;
            IdCliente = idCliente;
            IdIndustria = idIndustria;
        }

        private void FrmRegistrarNuevoProducto_Load(object sender, EventArgs e)
        {
            CargarClientes();          

            if(IdProducto > 0)
            {
                Producto.Modelo().CargarDatos(IdProducto).ForEach(delegate(Fila f)
                {
                    TxtNombre.Text = f.Celda("nombre").ToString();

                    Cliente cliente = new Cliente();
                    cliente.CargarDatos(f.Celda<int>("cliente"));
                    if (cliente.TieneFilas())
                        CmbCliente.Text = cliente.Fila().Celda("id").ToString() + " - " + cliente.Fila().Celda("nombre").ToString();
                    
                    Industria industria = new Industria();
                    industria.CargarDatos(f.Celda<int>("industria"));
                    if(industria.TieneFilas())
                        CmbIndustria.Text = industria.Fila().Celda("id").ToString() + " - " + industria.Fila().Celda("nombre").ToString();

                    TxtDescripcion.Text = f.Celda("descripcion").ToString();

                    BtnAceptar.Text = "Guardar";
                });
            }
        }

        private void CargarClientes()
        {
            CmbCliente.Items.Clear();
            Cliente cliente = new Cliente();
            cliente.Activos().ForEach(delegate(Fila f)
            {
                CmbCliente.Items.Add(f.Celda<int>("id") + " - " + f.Celda("nombre"));
            });
            
            if(IdCliente > 0)
            {
                
                cliente.CargarDatos(IdCliente);

                if (cliente.TieneFilas())
                    CmbCliente.Text = IdCliente + " - " + cliente.Fila().Celda("nombre").ToString();

                CmbCliente.Enabled = false;
            }
        }

        private void CargarIndustrias(int idCliente)
        {
            CmbIndustria.Items.Clear();

            Industria.Modelo().SeleccionarIndustriaOrdenAlfabetico(idCliente).ForEach(delegate(Fila f)
            {
                CmbIndustria.Items.Add(f.Celda<int>("id") + " - " + f.Celda("nombre"));
            });

            Industria industria = new Industria();
            industria.CargarDatos(IdIndustria);
            if (industria.TieneFilas())
            {
                CmbIndustria.Text = industria.Fila().Celda("id").ToString() + " - " + industria.Fila().Celda("nombre").ToString();
                CmbIndustria.Enabled = false;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (CmbCliente.Text.Contains("N/A") || CmbCliente.Text.Contains("N/A") || TxtDescripcion.Text == "")
            {
                MessageBox.Show("Debe proporcionar todos los datos requeridos", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IdProducto > 0)
            {
                Producto producto = new Producto();
                producto.CargarDatos(IdProducto);
                {
                    producto.Fila().ModificarCelda("descripcion", TxtDescripcion.Text);
                    producto.Fila().ModificarCelda("nombre", TxtNombre.Text);
                    producto.Fila().ModificarCelda("cliente", CmbCliente.Text.Split('-')[0].TrimEnd());
                    producto.Fila().ModificarCelda("industria", CmbIndustria.Text.Split('-')[0].TrimEnd());
                    producto.Fila().ModificarCelda("usuario_registro", Global.UsuarioActual.Fila().Celda<int>("id"));
                    producto.Fila().ModificarCelda("fecha_registro", DateTime.Now);
                    producto.GuardarDatos();

                    MessageBox.Show("El producto " + TxtNombre.Text + " fue actualizado correctamente", "Producto actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }                     
            else
            {
                Fila insertarProducto = new Fila();
                insertarProducto.AgregarCelda("descripcion", TxtDescripcion.Text);
                insertarProducto.AgregarCelda("nombre", TxtNombre.Text);
                insertarProducto.AgregarCelda("cliente", CmbCliente.Text.Split('-')[0].TrimEnd());
                insertarProducto.AgregarCelda("industria", CmbIndustria.Text.Split('-')[0].TrimEnd());
                insertarProducto.AgregarCelda("usuario_registro", Global.UsuarioActual.Fila().Celda<int>("id"));
                insertarProducto.AgregarCelda("fecha_registro", DateTime.Now);
                Producto.Modelo().Insertar(insertarProducto);

                MessageBox.Show("El producto " + TxtNombre.Text + " fue creado correctamente", "Producto creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtDescripcion.Text != "" && !CmbCliente.Text.Contains("N/A") && !CmbIndustria.Text.Contains("N/A"));
        }

        private void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CmbCliente.Text.Contains("N/A"))
                CargarIndustrias(Convert.ToInt32(CmbCliente.Text.Split('-')[0].TrimEnd()));

            BtnAceptar.Enabled = (TxtDescripcion.Text != "" && !CmbCliente.Text.Contains("N/A") && !CmbIndustria.Text.Contains("N/A"));
        }
    }
}

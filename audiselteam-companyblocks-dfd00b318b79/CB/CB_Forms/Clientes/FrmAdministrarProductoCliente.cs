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
    public partial class FrmAdministrarProductoCliente : Form
    {
        int IdCliente = 0;

        public FrmAdministrarProductoCliente(int idCliente=0)
        {
            InitializeComponent();
            IdCliente = idCliente;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarClientes();

            if(IdCliente > 0)
            {
                Cliente cli = new Cliente();
                cli.CargarDatos(IdCliente);

                if (cli.TieneFilas())
                {
                    CmbFiltroCliente.Text = cli.Fila().Celda("id") + " - " + cli.Fila().Celda("nombre");
                }
            }
            else CmbFiltroCliente.Text = "TODOS";
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoProductoCliente nuevoProducto = new FrmNuevoProductoCliente();
            
            if(nuevoProducto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int idProducto = Convert.ToInt32(nuevoProducto.NuevoProducto.Celda("id"));

                FrmEditarProductoCliente editarProducto = new FrmEditarProductoCliente(idProducto);
                editarProducto.Show();
            }
        }

        public void MostrarProductos()
        {
            int idCliente = 0;
            string sql = "SELECT clientes_productos.*, clientes.nombre AS nombre_cliente, clientes_industrias.industria AS nombre_industria FROM clientes_productos";
            sql += " INNER JOIN clientes ON clientes.id=clientes_productos.cliente";
            sql += " INNER JOIN clientes_industrias ON clientes_industrias.id=clientes_productos.industria";

            if (CmbFiltroCliente.Text == string.Empty)
                return;

            if (CmbFiltroCliente.Text != "TODOS")
            {
                sql += " WHERE clientes_productos.cliente=@cliente";
                idCliente = Convert.ToInt32(CmbFiltroCliente.Text.Split('-')[0]);
            }

            ClienteProducto buscadorProducto = new ClienteProducto();
            buscadorProducto.ConstruirQuery(sql);
            buscadorProducto.AgregarParametro("@cliente", idCliente);
            buscadorProducto.EjecutarQuery();

            DgvProducto.Rows.Clear();
            buscadorProducto.LeerFilas().ForEach(delegate(Fila f)
            {
                DgvProducto.Rows.Add(f.Celda("id").ToString().PadLeft(3, '0'), 
                                     f.Celda("cliente") + " - " + f.Celda("nombre_cliente"), 
                                     f.Celda("industria").ToString().PadLeft(4, '0') + " - " + f.Celda("nombre_industria"), 
                                     f.Celda("nombre"),
                                     f.Celda("clase"),
                                     f.Celda("descripcion")
                                     );
            });
        }

        private void CmbFiltroCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        public void CargarClientes()
        {
            CmbFiltroCliente.Items.Clear();

            CmbFiltroCliente.Items.Add("TODOS");
            Cliente.Modelo().Todos().ForEach(delegate(Fila f)
            {
                CmbFiltroCliente.Items.Add(f.Celda("id").ToString() + " - " + f.Celda("nombre"));
            }); 
        }

        private void editarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvProducto.SelectedRows.Count <= 0)
                return;

            int idCliente = Convert.ToInt32(DgvProducto.SelectedRows[0].Cells[0].Value);

            FrmEditarProductoCliente editarProducto = new FrmEditarProductoCliente(idCliente);
            editarProducto.Show();
        }

        private void MenuProducto_Opening(object sender, CancelEventArgs e)
        {
            editarProductoToolStripMenuItem.Enabled = DgvProducto.SelectedRows.Count > 0;
            eliminarProductoToolStripMenuItem.Enabled = DgvProducto.SelectedRows.Count > 0;
        }
    }
}
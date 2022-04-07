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
    public partial class FrmMonitorVentas : Form
    {
        Cotizacion BuscadorCotizacion = new Cotizacion();

        public FrmMonitorVentas()
        {
            InitializeComponent();
        }

        private void nuevaCotizaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaCotizacion nc = new FrmNuevaCotizacion();
            
            if(nc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CmbEstatus.Text = "SIN ENVIAR";

                int idCliente = Convert.ToInt32(nc.FilaCotizacion.Celda("cliente"));

                Cliente cli = new Cliente();
                cli.CargarDatos(idCliente);

                string clienteSeleccionado = idCliente + " - " + cli.Fila().Celda("nombre"); 

                CargarClientes(clienteSeleccionado);
                CargarVendedores();
                CargarCotizaciones();
            }
        }

        public void CargarCotizaciones()
        {
            int idCliente = 0;
            int idVendedor = 0;
            string[] partesCliente = CmbCliente.Text.Split('-');
            string[] partesVendedor = CmbVendedor.Text.Split('-');
            
            if(partesCliente.Count() == 2)
                idCliente = Convert.ToInt32(partesCliente[0]);

            if(partesVendedor.Count() == 2)
                idVendedor = Convert.ToInt32(partesVendedor[0]);

            string sql = "SELECT cotizaciones.*, CONCAT(clientes_contactos.nombre, ' ', clientes_contactos.apellidos) AS nombre_contacto_cliente FROM cotizaciones INNER JOIN clientes_contactos ON cotizaciones.contacto=clientes_contactos.id";

            sql += " WHERE cotizaciones.estatus=@estatus";

            if(CmbCliente.Text != "TODOS")
                sql += " AND cotizaciones.cliente=@cliente";

            if (CmbVendedor.Text != "TODOS")
                sql += " AND cotizaciones.usuario_creacion=@vendedor";

            BuscadorCotizacion.ConstruirQuery(sql);
            BuscadorCotizacion.AgregarParametro("@estatus", CmbEstatus.Text);
            BuscadorCotizacion.AgregarParametro("@cliente", idCliente);
            BuscadorCotizacion.AgregarParametro("@vendedor", idVendedor);
            BuscadorCotizacion.EjecutarQuery();

            int filaGuardada = Global.GuardarFilaSeleccionada(DgvCotizaciones);
            DgvCotizaciones.Rows.Clear();

            BuscadorCotizacion.LeerFilas().ForEach(delegate(Fila f)
            {
                DgvCotizaciones.Rows.Add(f.Celda("id").ToString().PadLeft(5, '0'), 
                                         f.Celda("titulo"), 
                                         f.Celda("nombre_contacto_cliente"), 
                                         Global.FechaATexto(f.Celda("fecha_limite"), false) 
                                        );
            });

            Global.RecuperarFilaSeleccionada(DgvCotizaciones, filaGuardada);
        }

        public void CargarClientes(string preseleccion="")
        {
            string clienteSeleccionado = string.Empty;
            
            if(preseleccion != "")
                clienteSeleccionado = preseleccion;
            else
                clienteSeleccionado = CmbCliente.Text;

            CmbCliente.Items.Clear();
            CmbCliente.Items.Add("TODOS");
            Cotizacion.Modelo().Clientes().ForEach(delegate(Fila f)
            {
                CmbCliente.Items.Add(f.Celda("id") + " - " + f.Celda("nombre"));
            });

            if (CmbCliente.Items.Contains(clienteSeleccionado))
                CmbCliente.Text = clienteSeleccionado;
        }

        public void CargarVendedores()
        {
            CmbVendedor.Items.Clear();
            CmbVendedor.Items.Add("TODOS");
            Cotizacion.Modelo().Vendedores().ForEach(delegate(Fila f)
            {
                CmbVendedor.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });

            string vendedorActual = Global.UsuarioActual.Fila().Celda("id") + " - " + Global.UsuarioActual.NombreCompleto();

            if (CmbVendedor.Items.Contains(vendedorActual))
                CmbVendedor.Text = vendedorActual;
            else
                CmbVendedor.Text = "TODOS";
        }

        private void FrmMonitorVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarVendedores();
            CmbEstatus.Text = "SIN ENVIAR";
            CmbCliente.Text = "TODOS";
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCotizaciones();
        }

        private void CmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCotizaciones();
        }

        private void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCotizaciones();
        }

        private void editarCotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvCotizaciones.SelectedRows.Count <= 0)
                return;

            int idCotizacion = Convert.ToInt32(DgvCotizaciones.SelectedRows[0].Cells[0].Value);

            FrmEditarCotizacion editar = new FrmEditarCotizacion(idCotizacion);
            editar.Show();
        }

    }
}

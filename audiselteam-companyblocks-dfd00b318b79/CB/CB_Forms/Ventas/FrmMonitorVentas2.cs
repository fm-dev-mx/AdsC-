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
    public partial class FrmMonitorVentas2 : Form
    {
        public FrmMonitorVentas2()
        {
            InitializeComponent();
        }

        private void FrmMonitorVentas2_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarUsuarios();
            CargarEstatusCotizacion();
            CargarFechaLimiteEnviar();
            CargarFechaCreacion();
        }

        private void CargarClientes()
        {
            CmbClientes.Items.Clear();
            CmbClientes.Items.Add("N/A");
            Cliente clientes = new Cliente();
            clientes.Todos().ForEach(delegate(Fila f)
            {
                CmbClientes.Items.Add(f.Celda("id") + "-" + f.Celda("nombre"));
            });
            CmbClientes.SelectedIndex = 0;
        }

        private void CargarClienteContacto()
        {
            CmbContectoTecnico.Items.Clear();
            CmbContectoTecnico.Items.Add("TODOS");
            ClienteContacto contacto = new ClienteContacto();
            contacto.SeleccionarDeCliente(Convert.ToInt32(CmbClientes.Text.Split('-')[0])).ForEach(delegate(Fila f)
            {
                CmbContectoTecnico.Items.Add(f.Celda("id") + "-" + f.Celda("nombre") + " " + f.Celda("apellidos"));
            });

            CmbContectoTecnico.SelectedIndex = 0;
        }

        private void CargarUsuarios()
        {
            CmbUsuario.Items.Clear();
            CmbUsuario.Items.Add("TODOS");

            CotizacionClinte cotizacion = new CotizacionClinte();
            cotizacion.SeleccionarUsuariosCreacion().ForEach(delegate(Fila f)
            {
                CmbUsuario.Items.Add(f.Celda("id") + "-" + f.Celda("nombre") + " " + f.Celda("paterno"));
            });
            CmbUsuario.SelectedIndex = 0;

        }

        private void CargarEstatusCotizacion()
        {
            CmbEstatusCotizacion.Items.Clear();
            CmbEstatusCotizacion.Items.AddRange(new string[]{
                "PENDIENTE",
                "EN PROCESO",
                "ACEPTADO",
                "RECHAZADO"
            });

            CmbEstatusCotizacion.SelectedIndex = 0;
        }

        private void CargarFechaCreacion()
        {
            CmbFechaCreacion.Items.Clear();
            CmbFechaCreacion.Items.Add("TODAS");
            CotizacionClinte cotizacion = new CotizacionClinte();
            cotizacion.SeleccionarFechaCreacion().ForEach(delegate(Fila f)
            {
                if (f.Celda("fecha") != null)
                    CmbFechaCreacion.Items.Add(Global.FechaATexto(f.Celda("fecha"), false));
            });

            CmbFechaCreacion.SelectedIndex = 0;
        }

        private void CargarFechaLimiteEnviar()
        {
            CmbFechaLimite.Items.Clear();
            CmbFechaLimite.Items.Add("TODAS");
            CotizacionClinte.Modelo().SeleccionarFechaLimiteEnviar().ForEach(delegate(Fila f)
            {
                if (f.Celda("fecha_limite") != null)
                    CmbFechaLimite.Items.Add(Global.FechaATexto(f.Celda("fecha_limite"), false));
            });
            CmbFechaLimite.SelectedIndex = 0;
        }

        private void CargarCotizaciones()
        {
            if (CmbClientes.Text == "" || CmbContectoTecnico.Text == "")
                return;

            DgvVentas.Rows.Clear();
            Fila filaFiltro = new Fila();
            filaFiltro.AgregarCelda("cliente", CmbClientes.Text.Split('-')[0]);
            filaFiltro.AgregarCelda("cliente_contacto_tecnico", CmbContectoTecnico.Text.Split('-')[0]);
            filaFiltro.AgregarCelda("usuario_creacion", CmbUsuario.Text.Split('-')[0]);
            filaFiltro.AgregarCelda("fecha_creacion", CmbFechaCreacion.Text);
            filaFiltro.AgregarCelda("estatus_cotizacion", CmbEstatusCotizacion.Text);
            filaFiltro.AgregarCelda("fecha_limite_enviar", CmbFechaLimite.Text);

            CotizacionClinte cotizacion = new CotizacionClinte();
            cotizacion.SeleccionarCotizaciones(filaFiltro).ForEach(delegate(Fila f)
            {
                Usuario usuario = new Usuario();
                usuario.CargarDatos(Convert.ToInt32(f.Celda("usuario_creacion")));

                DgvVentas.Rows.Add
                (
                    f.Celda("id").ToString().PadLeft(4, '0'), 
                    f.Celda("nombre_cotizacion"),
                    usuario.Fila().Celda("nombre").ToString() + " " + usuario.Fila().Celda("paterno").ToString(),
                    Global.FechaATexto(f.Celda("fecha_creacion"), false),
                    Global.FechaATexto(f.Celda("fecha_limite_enviar"), false),
                    f.Celda("estatus_cotizacion"),
                    f.Celda("estatus_evaluacion")
                );

            });
        }

        private void CmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbClientes.Text == "" || CmbClientes.Text == "N/A")
                return;

            CargarClienteContacto();
        }

        private void nuevaCotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaCotizacion2 nuevaCotizacion = new FrmNuevaCotizacion2();
            if (nuevaCotizacion.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarCotizaciones();
        }

        private void CmbContectoTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCotizaciones();
        }

        private void MenuVentas_Opening(object sender, CancelEventArgs e)
        {
            editarToolStripMenuItem.Enabled = (DgvVentas.SelectedRows.Count > 0);
            eliminarToolStripMenuItem.Enabled = (DgvVentas.SelectedRows.Count > 0);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditarCotizacion2 editar = new FrmEditarCotizacion2(Convert.ToInt32(DgvVentas.SelectedRows[0].Cells["id"].Value));
            editar.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar la cotización seleccionada?", "Eliminar cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                int idCotizacion = Convert.ToInt32(DgvVentas.SelectedRows[0].Cells["id"].Value);
                CotizacionClinte cotizacion = new CotizacionClinte();
                cotizacion.CargarDatos(idCotizacion);
                cotizacion.BorrarDatos();
                cotizacion.GuardarDatos();
                CargarCotizaciones();
            }
        }

        private void DgvVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string estatus = DgvVentas.Rows[e.RowIndex].Cells["estatus_cotizacion"].Value.ToString();

            switch (estatus)
            {
                case "PENDIENTE":
                    DgvVentas.Rows[e.RowIndex].Cells["estatus_cotizacion"].Style.BackColor = Color.Yellow;
                    break;
                case "EN PROCESO":
                    DgvVentas.Rows[e.RowIndex].Cells["estatus_cotizacion"].Style.BackColor = Color.LightGreen;
                    break;
                case "ACEPTADO":
                    DgvVentas.Rows[e.RowIndex].Cells["estatus_cotizacion"].Style.BackColor = Color.Green;
                    break;
                case "RECHAZADO":
                    DgvVentas.Rows[e.RowIndex].Cells["estatus_cotizacion"].Style.BackColor = Color.Coral;
                    break;
                default:
                    break;
            }

        }
    }
}

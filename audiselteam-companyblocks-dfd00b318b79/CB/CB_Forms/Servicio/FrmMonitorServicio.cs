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
    public partial class FrmMonitorServicio : Form
    {
        public FrmMonitorServicio()
        {
            InitializeComponent();
        }

        private void FrmMonitorServicio_Load(object sender, EventArgs e)
        {
            CmbTipo.Text = "TODOS";
            CmbEstatus.Text = "ABIERTO";
        }

        public void CargarTickets()
        {
            DgvTickets.Rows.Clear();
            TicketServicio.Modelo().SeleccionarTipoEstatus(CmbTipo.Text, CmbEstatus.Text, "EXTERNA").ForEach(delegate(Fila f)
            {
                Usuario usuarioCreacion = new Usuario();
                usuarioCreacion.CargarDatos(Convert.ToInt32(f.Celda("usuario_creacion")));

                string strFechaCreacion = Global.FechaATexto(f.Celda("fecha_creacion"));

                DgvTickets.Rows.Add(f.Celda("id").ToString().PadLeft(4, '0'), f.Celda("tipo"), Convert.ToDecimal(f.Celda("proyecto")).ToString("F2").PadLeft(5, '0'), 
                                    usuarioCreacion.NombreCompleto(), strFechaCreacion, f.Celda("estatus"), f.Celda("detalles"));
            });
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoTicketServicio ticket = new FrmNuevoTicketServicio();
            
            if(ticket.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarTickets();
            }
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTickets();
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTickets();
        }

        private void DgvTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvTickets.SelectedRows.Count == 0) return;

            int idTicket = Convert.ToInt32(DgvTickets.SelectedRows[0].Cells["id"].Value);

            FrmDetallesTicketServicio detalles = new FrmDetallesTicketServicio(idTicket);
            detalles.Show();
        }
    }
}

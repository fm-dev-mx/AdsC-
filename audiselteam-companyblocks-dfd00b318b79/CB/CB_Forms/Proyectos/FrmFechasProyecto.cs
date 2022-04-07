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
    public partial class FrmFechasProyecto : Form
    {
        decimal IdProyecto = 0;
        int IdEtapa = 0;
        Proyecto ProyectoCargado = new Proyecto();
        public FrmFechasProyecto(decimal proyecto)
        {
            InitializeComponent();
            IdProyecto = proyecto;
            ProyectoCargado.CargarDatos(IdProyecto);
        }

        private void FrmFechasProyecto_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            LblTitulo.Text = "FECHAS PROYECTO ";
            LblTitulo.Text += Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2");
            LblTitulo.Text += " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            CargarFechas(IdProyecto);
        }

        private void CargarFechas(decimal proyecto)
        {
            DgvFechasProyecto.Columns["inicio_etapa"].DefaultCellStyle.Format = "MMM dd yyy";
            DgvFechasProyecto.Columns["cierre_etapa"].DefaultCellStyle.Format = "MMM dd yyy";

            int filaSeleccion = Global.GuardarFilaSeleccionada(DgvFechasProyecto);
            DgvFechasProyecto.Rows.Clear();
            EtapaProyecto.Modelo().SeleccionarProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                DgvFechasProyecto.Rows.Add(f.Celda("id"), f.Celda("nombre"), f.Celda("inicio"), f.Celda("cierre"));
            });

            nuevoToolStripMenuItem.Enabled = true;
            editarToolStripMenuItem.Enabled = false;
            borrarToolStripMenuItem.Enabled = false;

        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void DgvFechasProyecto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvFechasProyecto.SelectedRows.Count <= 0)
                return;

            IdEtapa = Convert.ToInt32(DgvFechasProyecto.SelectedRows[0].Cells["id"].Value);
            editarToolStripMenuItem.Enabled = true;
            borrarToolStripMenuItem.Enabled = true;
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IdEtapa > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro que desea borrar esta etapa?", "Eliminar etapa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    EtapaProyecto borrarEtapa = new EtapaProyecto();
                    borrarEtapa.CargarDatos(IdEtapa);
                    borrarEtapa.BorrarDatos();
                    CargarFechas(IdProyecto);
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarEtapa etapa = new FrmAgregarEtapa(IdProyecto);
            if (etapa.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarFechas(IdProyecto);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarEtapa etapa = new FrmAgregarEtapa(IdProyecto, IdEtapa);
            if (etapa.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarFechas(IdProyecto);
        }
    }
}

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
    public partial class FrmConsultarEncuesta : Form
    {
        int EncuestaSeleccionada = 0;
        int PlantillaSeleccionada = 0;
        string Estatus = string.Empty;

        public FrmConsultarEncuesta()
        {
            InitializeComponent();
        }

        private void FrmConsultarEncuesta_Load(object sender, EventArgs e)
        {            
            CmbEstatus.SelectedIndex = 0;
        }

        private void CargarEncuestas()
        {
            DgvEncuestas.Rows.Clear();

            Encuesta encuesta = new Encuesta();
            encuesta.SeleccionarEncuesta("", CmbEstatus.Text, Global.UsuarioActual.Fila().Celda("id").ToString()).ForEach(delegate(Fila f)
            {
                DateTime fechaCreacion = Convert.ToDateTime(f.Celda("fecha_creacion"));
                int diasCaducidad = Convert.ToInt32(Global.ObjetoATexto(f.Celda("caducidad"), "0"));
                DateTime fechaCaducidad = fechaCreacion.AddDays(diasCaducidad);
                string strEstatus = string.Empty;

                if (fechaCaducidad <= DateTime.Now && Global.ObjetoATexto(f.Celda("estatus"), "") == "PENDIENTE")
                    strEstatus = "TARDE";
                else
                    strEstatus = Global.ObjetoATexto(f.Celda("estatus"), "");

                if (strEstatus == CmbEstatus.Text || CmbEstatus.Text == "TODOS")
                {

                    DgvEncuestas.Rows.Add(f.Celda("id").ToString(),
                        Global.ObjetoATexto(f.Celda("plantilla"), ""),
                        Global.ObjetoATexto(f.Celda("nombreEncuesta"), ""),
                        Global.ObjetoATexto(f.Celda("encuestadoNombre"), "") + " " + Global.ObjetoATexto(f.Celda("encuestadoPaterno"), ""),
                        Global.ObjetoATexto(f.Celda("nombreCreador"), "") + " " + Global.ObjetoATexto(f.Celda("paternoCreador"), ""),
                        Global.ObjetoATexto(f.Celda("comentarios"), ""),
                        Global.FechaATexto(f.Celda("fecha_creacion")),
                        strEstatus);
                }
            });

            if (DgvEncuestas.Rows.Count > 0)
                DgvEncuestas.ClearSelection();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void irAEncuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRealizarEncuesta realizarEncuesta = new FrmRealizarEncuesta(PlantillaSeleccionada, EncuestaSeleccionada);
            if (realizarEncuesta.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                Encuesta encuesta = new Encuesta();
                encuesta.CargarDatos(EncuestaSeleccionada);
                if(encuesta.TieneFilas())
                {
                    encuesta.Fila().ModificarCelda("fecha_completa", DateTime.Now);
                    encuesta.Fila().ModificarCelda("estatus", "CONTESTADA");
                    encuesta.GuardarDatos();
                }
                CargarEncuestas();
            }
        }

        private void DgvEncuestas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            EncuestaSeleccionada = Convert.ToInt32(DgvEncuestas.SelectedRows[0].Cells["id"].Value);
            PlantillaSeleccionada = Convert.ToInt32(DgvEncuestas.SelectedRows[0].Cells["plantilla"].Value);
            Estatus = DgvEncuestas.SelectedRows[0].Cells["status"].Value.ToString();

            if (Estatus == "PENDIENTE")
            {
                irAEncuestaToolStripMenuItem.Visible = true;
                verEncuestaToolStripMenuItem.Visible = false;
            }
            else
            {
                verEncuestaToolStripMenuItem.Visible = true;
                irAEncuestaToolStripMenuItem.Visible = false;
            }
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEncuestas();
        }

        private void DgvEncuestas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvEncuestas.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    irAEncuestaToolStripMenuItem.Visible = false;
                    MenuEncuesta.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvEncuestas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {          
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)    
                    if(DgvEncuestas.SelectedRows.Count > 0)
                        MenuEncuesta.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void verEncuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRealizarEncuesta realizarEncuesta = new FrmRealizarEncuesta(PlantillaSeleccionada, EncuestaSeleccionada, true);
            realizarEncuesta.ShowDialog();
        }

        private void DgvEncuestas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string estatus = DgvEncuestas.Rows[e.RowIndex].Cells["status"].Value.ToString();
            if (estatus == "PENDIENTE")
                DgvEncuestas.Rows[e.RowIndex].Cells["status"].Style.BackColor = Color.Yellow;
            else if (estatus == "TARDE")
                DgvEncuestas.Rows[e.RowIndex].Cells["status"].Style.BackColor = Color.Red;
        }
    }
}

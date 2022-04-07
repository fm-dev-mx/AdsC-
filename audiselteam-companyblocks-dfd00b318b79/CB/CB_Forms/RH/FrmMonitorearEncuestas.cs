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
    public partial class FrmMonitorearEncuestas : Form
    {
        List<Fila> Encuestas = new List<Fila>();
        string Estatus = string.Empty;
        int EncuestaSeleccionada = 0;
        int PlantillaSeleccionada = 0;

        public FrmMonitorearEncuestas()
        {
            InitializeComponent();
        }

        private void FrmMonitorearEncuestas_Load(object sender, EventArgs e)
        {
            CargarPlantillas();
            CmbEstatus.SelectedIndex = 0;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            CmbUsuario.Items.Clear();

            CmbUsuario.Items.Add("TODOS");

            Usuario usuario = new Usuario();
            usuario.Activos().ForEach(delegate(Fila f)
            {
                CmbUsuario.Items.Add(f.Celda("id").ToString() + " - " + Global.ObjetoATexto(f.Celda("nombre"), "") + " " + Global.ObjetoATexto(f.Celda("paterno"), ""));
            });

            CmbUsuario.SelectedIndex = 0;
        }

        private void CargarPlantillas()
        {
            CmbPlantilla.Items.Clear();

            PlantillaEncuesta encuesta = new PlantillaEncuesta();
            encuesta.SeleccionarPlantillas().ForEach(delegate(Fila f)
            {
                CmbPlantilla.Items.Add(f.Celda("id").ToString() + " - " + f.Celda("nombre").ToString());
            });

            if(CmbPlantilla.Items.Count > 0)
                CmbPlantilla.SelectedIndex = 0;
        }

        private void CargarEncuestas()
        {
            DgvEncuestas.Rows.Clear();

            Encuestas.ForEach(delegate(Fila f)
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
                        Global.ObjetoATexto(f.Celda("usuario_encuestado"), "") + " - " + Global.ObjetoATexto(f.Celda("encuestadoNombre"), "") + 
                        " " + Global.ObjetoATexto(f.Celda("encuestadoPaterno"), ""),
                        Global.ObjetoATexto(f.Celda("usuario_creacion"), "") + " - " + Global.ObjetoATexto(f.Celda("nombreCreador"), "") + " " +
                        Global.ObjetoATexto(f.Celda("paternoCreador"), ""),
                        Global.ObjetoATexto(f.Celda("comentarios"), ""),
                        Global.FechaATexto(f.Celda("fecha_creacion")),
                        strEstatus);
                }
            });

            if (DgvEncuestas.Rows.Count > 0)
                DgvEncuestas.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCrearEncuesta crearEncuesta = new FrmCrearEncuesta(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));
            if(crearEncuesta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!BkgCargarEncuestas.IsBusy)
                {
                    string usuario = string.Empty;
                    if (CmbUsuario.Text != "TODOS")
                    {
                        usuario = CmbUsuario.Text.Split('-')[0].Trim();
                    }
                    else
                        usuario = CmbUsuario.Text;

                    BkgCargarEncuestas.RunWorkerAsync(new string[] { CmbPlantilla.Text, CmbEstatus.Text, usuario });
                }
            }
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BkgCargarEncuestas.IsBusy)
            {
                string usuario = string.Empty;
                if (CmbUsuario.Text != "TODOS")
                {
                    usuario = CmbUsuario.Text.Split('-')[0].Trim();
                }
                else
                    usuario = CmbUsuario.Text;

                BkgCargarEncuestas.RunWorkerAsync(new string[] { CmbPlantilla.Text, CmbEstatus.Text, usuario });
            }
        }

        private void BkgCargarEncuestas_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] argumentos = (string[])e.Argument;
            string plantilla = argumentos[0].Split('-')[0].Trim();
            string estatus = argumentos[1];
            string usuario = argumentos[2];

            Encuesta encuesta = new Encuesta();
            Encuestas = encuesta.SeleccionarEncuesta(plantilla, estatus, usuario, BkgCargarEncuestas);
        }

        private void BkgCargarEncuestas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            Fila lafila = (Fila)e.UserState;

            LblEstatus.Text = "Descargando encuestas... [" + e.ProgressPercentage + "%]";
        }

        private void BkgCargarEncuestas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Encuestas descargadas!";
            CargarEncuestas();
        }

        private void CmbEstatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!BkgCargarEncuestas.IsBusy)
            {
                string usuario = string.Empty;
                if (CmbUsuario.Text != "TODOS")
                {
                    usuario = CmbUsuario.Text.Split('-')[0].Trim();
                }
                else
                    usuario = CmbUsuario.Text;

                BkgCargarEncuestas.RunWorkerAsync(new string[] { CmbPlantilla.Text, CmbEstatus.Text, usuario });
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ProgresoDescarga.Value = 0;
            ProgresoDescarga.Visible = true;
            LblEstatus.Text = "Estatus";
            if (!BkgCargarEncuestas.IsBusy)
            {
                string usuario = string.Empty;
                if (CmbUsuario.Text != "TODOS")
                {
                    usuario = CmbUsuario.Text.Split('-')[0].Trim();
                }
                else
                    usuario = CmbUsuario.Text;

                BkgCargarEncuestas.RunWorkerAsync(new string[] { CmbPlantilla.Text, CmbEstatus.Text, usuario });
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvEncuestas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvEncuestas.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    verEncuestaToolStripMenuItem.Visible = false;
                    MenuEncuesta.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvEncuestas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (DgvEncuestas.SelectedRows.Count > 0)
                    {
                        verEncuestaToolStripMenuItem.Visible = true;
                        MenuEncuesta.Show(Cursor.Position.X, Cursor.Position.Y);
                    }
                }
            }
        }

        private void DgvEncuestas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            EncuestaSeleccionada = Convert.ToInt32(DgvEncuestas.SelectedRows[0].Cells["id"].Value);
            PlantillaSeleccionada = Convert.ToInt32(DgvEncuestas.SelectedRows[0].Cells["plantilla"].Value);
            Estatus = DgvEncuestas.SelectedRows[0].Cells["status"].Value.ToString();
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
            else if (estatus == "CONTESTADA")
                DgvEncuestas.Rows[e.RowIndex].Cells["status"].Style.BackColor = Color.LightGreen;
            else if (estatus == "TARDE")
                DgvEncuestas.Rows[e.RowIndex].Cells["status"].Style.BackColor = Color.Red;
        }

        private void CmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BkgCargarEncuestas.IsBusy)
            {
                string usuario = string.Empty;
                if (CmbUsuario.Text != "TODOS")
                {
                    usuario = CmbUsuario.Text.Split('-')[0].Trim();
                }
                else
                    usuario = CmbUsuario.Text;

                BkgCargarEncuestas.RunWorkerAsync(new string[] { CmbPlantilla.Text, CmbEstatus.Text, usuario });
            }
        }

        private void CmbPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BkgCargarEncuestas.IsBusy)
            {
                string usuario = string.Empty;
                if (CmbUsuario.Text != "TODOS")
                {
                    usuario = CmbUsuario.Text.Split('-')[0].Trim();
                }
                else
                    usuario = CmbUsuario.Text;

                BkgCargarEncuestas.RunWorkerAsync(new string[] { CmbPlantilla.Text, CmbEstatus.Text, usuario });
            }
        }
    }
}

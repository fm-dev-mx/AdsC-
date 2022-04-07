using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CB_Base.Classes;
using System.Windows.Shell;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace CB
{
    public partial class FrmTopicosProyecto : Form
    {
        decimal Proyecto = 0;
        int IdTopico = 0;
        Proyecto ProyectoCargado = new Proyecto();
        List<Fila> CargarTopico = new List<Fila>();
        Topico topico = new Topico();

        public FrmTopicosProyecto(decimal proyecto)
        {
            InitializeComponent();
            Proyecto = proyecto;
        }

        private void FrmTopicosProyecto_Load(object sender, EventArgs e)
        {
            ProyectoCargado.CargarDatos(Proyecto);
            LblTitulo.Text = "JUNTAS DE SINCRONIZACION DEL PROYECTO ";
            LblTitulo.Text += Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2");
            LblTitulo.Text += " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            
            LblUltimaActualizacion.Text = "";
            CargarCmbUsuarioCreador();

            CmbFiltroEstatus.SelectedIndex = 0;

            DescargarTopicos();
            CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);
            WindowState = FormWindowState.Maximized;
        }

        public void DescargarTopicos()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", Proyecto.ToString("F2"));
            CargarTopico = topico.SeleccionarDatos("proyecto=@proyecto", parametros);
        }

        public void CargarTopicosEnDgv(string filtroStatus, string filtroUsuarioCreador)
        {
            string estatusFiltro = CmbFiltroEstatus.Text;
            string usuarioFiltro = CmbFiltroOrigen.Text;

            if (filtroStatus == "TODOS")
                filtroStatus = "";

            if (filtroUsuarioCreador == "TODOS")
                filtroUsuarioCreador = "";

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvTopicos);
            DgvTopicos.Rows.Clear();

            CargarTopico.FindAll(s => s.Celda("estatus").ToString().Contains(filtroStatus) && s.Celda("usuario_creacion").ToString().Contains(filtroUsuarioCreador)).ForEach(delegate(Fila f)
            {
                DgvTopicos.Rows.Add(f.Celda("id"), 
                    Convert.ToDateTime(f.Celda("fecha_creacion")).ToString("MMM dd yyyy, hh:mm tt"), 
                    f.Celda("usuario_creacion"), 
                    f.Celda("descripcion"), 
                    f.Celda("estatus"),
                    f.Celda("fecha_creacion"));
            });

            LblUltimaActualizacion.Text = "Ultima actualización: " + DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
            ConfiguracionDataGridView.Recuperar(cfg, DgvTopicos);
        }

        private void DgvTopicos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = DgvTopicos.Rows[e.RowIndex].Cells["estatus"];

            switch (cell.Value.ToString())
            {
                case "PENDIENTE":
                    cell.Style.BackColor = Color.Yellow;
                    break;
                case "TERMINADO":
                     cell.Style.BackColor = Color.LightGreen;
                    break;
                case "EN PROCESO":
                    cell.Style.BackColor = Color.DarkBlue;
                    cell.Style.ForeColor = Color.White;
                    break;
                case "DETENIDO":
                    cell.Style.BackColor = Color.Coral;
                    break;
                case "DESCARTADO":
                    cell.Style.BackColor = Color.LightGray;
                    break;
                default:
                    break;
            }
        }

        private void DgvTopicos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                    MenuOpciones.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void DgvTopicos_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvTopicos.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    editarToolStripMenuItem.Enabled = false;
                    borrarToolStripMenuItem.Enabled = false;

                    MenuOpciones.Show(Cursor.Position.X, Cursor.Position.Y);
               }
            }
        }

        private void DgvTopicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1)
                return;

            IdTopico = Convert.ToInt32(DgvTopicos.SelectedRows[0].Cells["id"].Value.ToString());
            editarToolStripMenuItem.Enabled = true;
            borrarToolStripMenuItem.Enabled = true;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarTopico.Clear();
            CargarCmbUsuarioCreador();
            DescargarTopicos();
            CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);
        }

        private void CmbFiltroEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);
        }

        private void CmbFiltroOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);
        }

        public void CargarCmbUsuarioCreador()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", Proyecto.ToString("F2"));

            CmbFiltroOrigen.Items.Clear();
            CmbFiltroOrigen.Items.Add("TODOS");

            topico.SeleccionarDatos("proyecto=@proyecto", parametros, "distinct(usuario_creacion)").ForEach(delegate(Fila f)
            {
                CmbFiltroOrigen.Items.Add(f.Celda("usuario_creacion").ToString());
            });

            CmbFiltroOrigen.SelectedIndex = 0;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoTopico nuevoTopic = new FrmNuevoTopico(Proyecto, 0);
            if (nuevoTopic.ShowDialog() == DialogResult.OK)
            {
                CargarCmbUsuarioCreador();
                DescargarTopicos();
                CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoTopico editarTopico = new FrmNuevoTopico(Proyecto, IdTopico, true);
            if(editarTopico.ShowDialog() == DialogResult.OK)
            {
                DescargarTopicos();
                CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los tópicos que son borrados no pueden ser recuperados en el futuro. ¿Desea continuar?", "Borrar tópico", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(result == DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvTopicos.SelectedRows)
                {
                    int idTopico = Convert.ToInt32(row.Cells["id"].Value.ToString());
                    topico.BorrarDatos(idTopico);
                    topico.GuardarDatos();
                }

                CargarCmbUsuarioCreador();
                DescargarTopicos();
                CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);
            }
        }

        private void DgvTopicos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmDetallesTopico detallesTopico = new FrmDetallesTopico(IdTopico, Proyecto);
            if (detallesTopico.ShowDialog() == DialogResult.OK) 
            {
                DescargarTopicos();
                CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void reporteDeSincronizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteSincronizacion sincronizacion = new FrmReporteSincronizacion(Proyecto);
            sincronizacion.Show();
        }

        private void MenuOpciones_Opening(object sender, CancelEventArgs e)
        {
            nuevoToolStripMenuItem.Visible = false;
            editarToolStripMenuItem.Visible = false;
            borrarToolStripMenuItem.Visible = false;
            reporteDeSincronizaciónToolStripMenuItem.Visible = false;
        }

        private void nuevaTareaTool_Click(object sender, EventArgs e)
        {
            if(DgvTopicos.Rows.Count > 0)
            {
                DateTime fechaUltimaJunta = Convert.ToDateTime(DgvTopicos.Rows[DgvTopicos.Rows.Count - 1].Cells["fecha_creacion_junta"].Value);
                if(fechaUltimaJunta.Date == DateTime.Today.Date)
                {
                    MessageBox.Show("La junta del día de hoy ya fue creada");
                    return;
                }
            }

            DialogResult result = MessageBox.Show("¿Está seguro de crear una nueva junta de sincronización?", "Nueva junta de sincronización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DgvTopicos.Rows)
                {
                    int idTopico = Convert.ToInt32(row.Cells["id"].Value);
                    string estatus = row.Cells["estatus"].Value.ToString();

                    if (estatus != "TERMINADO")
                    {
                        Topico junta = new Topico();
                        junta.CargarDatos(idTopico);
                        if (junta.TieneFilas())
                        {
                            junta.Fila().ModificarCelda("estatus", "TERMINADO");
                            junta.GuardarDatos();
                        }
                    }
                }

                Fila req = new Fila();
                req.AgregarCelda("estatus", "PENDIENTE");
                req.AgregarCelda("proyecto", Proyecto);
                req.AgregarCelda("descripcion", "JUNTA DE SINCRONIZACION PROYECTO " + Proyecto.ToString("F2") + " - " + ProyectoCargado.Fila().Celda("nombre").ToString() + " " +  Global.FechaATexto(DateTime.Today.Date, false));
                req.AgregarCelda("fecha_creacion", DateTime.Now);
                req.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
                Fila topico = Topico.Modelo().Insertar(req);

                CargarCmbUsuarioCreador();
                DescargarTopicos();
                CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);

                FrmDetallesTopico detallesTopico = new FrmDetallesTopico(Convert.ToInt32(topico.Celda("id")), Proyecto);
                if (detallesTopico.ShowDialog() == DialogResult.OK)
                {
                    DescargarTopicos();
                    CargarTopicosEnDgv(CmbFiltroEstatus.Text, CmbFiltroOrigen.Text);
                }
            }
        }

        private void DgvTopicos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}

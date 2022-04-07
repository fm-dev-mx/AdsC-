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
    public partial class FrmCalendario : Form
    {
        public FrmCalendario()
        {
            InitializeComponent();
        }

        public void CargarCalendario(string visualizar)
        {
            DivisorPrincipal.Panel2Collapsed = true;
            if (visualizar == "DIAS")
                CargarDias();
            else if (visualizar == "SEMANAS")
                CargarSemanas();
        }

        public void CargarDias()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvCalendario);

            int year = Convert.ToInt32(CmbYear.Text);
            int mes = CmbMes.SelectedIndex + 1;
            DateTime iteracion = new DateTime(year, mes, 1);
            DateTime hasta = new DateTime(year, mes, DateTime.DaysInMonth(year, mes));

            DgvCalendario.Columns.Clear();
            DgvCalendario.Columns.Add("horario", "Horario");
            DgvCalendario.Columns[0].Frozen = true;
            DgvCalendario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvCalendario.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            
            for (int hora = 7; hora <= 18; hora++)
            {
                DgvCalendario.Rows.Add(hora + ":00");
            }

            while(iteracion <= hasta)
            {
                DataGridViewImageColumn col = new DataGridViewImageColumn();
                col.DefaultCellStyle.NullValue = null;
                col.Name = iteracion.Date.ToString();
                col.HeaderText = iteracion.Date.ToString("ddd MMM dd");

                DgvCalendario.Columns.Add(col);

                if (iteracion.DayOfWeek == DayOfWeek.Saturday || iteracion.DayOfWeek == DayOfWeek.Sunday)
                {
                    DgvCalendario.Columns[DgvCalendario.Columns.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                }

                if(iteracion.Date == DateTime.Now.Date)
                {
                    DgvCalendario.Columns[DgvCalendario.Columns.Count - 1].DefaultCellStyle.BackColor = Color.LightYellow;
                    DgvCalendario.FirstDisplayedScrollingColumnIndex = DgvCalendario.Columns[DgvCalendario.Columns.Count - 1].Index;
                }

                CargarEventosDia(iteracion);
                iteracion = iteracion.AddDays(1);
            }
            ConfiguracionDataGridView.Recuperar(cfg, DgvCalendario);
        }

        public void CargarSemanas()
        {
            int semanaActual = 1;

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvCalendario);

            DgvCalendario.Columns.Clear(); 
            DgvCalendario.Columns.Add("horario", "Horario");
            DgvCalendario.Columns[0].Frozen = true;
            DgvCalendario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int hora = 7; hora <= 18; hora++)
            {
                DgvCalendario.Rows.Add(hora + ":00");
            }

            while (semanaActual <= 52)
            {
                DgvCalendario.Columns.Add("semana-" + semanaActual, "Semana " + semanaActual.ToString().PadLeft(2, '0') );
                semanaActual++;
            }
            ConfiguracionDataGridView.Recuperar(cfg, DgvCalendario);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivisorPrincipal.Panel2Collapsed = true;
            CargarCalendario(CmbVisualizar.Text);

            LblMes.Visible = CmbVisualizar.Text == "DIAS";
            CmbMes.Visible = CmbVisualizar.Text == "DIAS";
        }

        private void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCalendario(CmbVisualizar.Text);
        }

        private void CmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCalendario(CmbVisualizar.Text);
        }

        private void FrmCalendario_Load(object sender, EventArgs e)
        {
            CmbMes.SelectedIndex = DateTime.Now.Month - 1;
            CmbYear.Text = DateTime.Now.Year.ToString();
            DivisorPrincipal.Panel2Collapsed = true;
            CargarTiposEventos();
            CmbVisualizar.Text = "DIAS";
        }

        public void CargarTiposEventos()
        {
            CmbTipoEvento.Items.Clear();
            CmbTipoEvento.Items.Add("TODOS");
            JuntaEvento.Modelo().Tipos().ForEach(delegate(Fila f)
            {
                CmbTipoEvento.Items.Add(f.Celda("tipo"));
            });
            CmbTipoEvento.Text = "TODOS";
        }

        private void programarEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvCalendario.SelectedCells.Count == 0)
                return;

            DataGridViewCell celdaSeleccionada = DgvCalendario.SelectedCells[0];

            if (celdaSeleccionada == null)
                return;

            DateTime fechaSeleccionada = Convert.ToDateTime(DgvCalendario.Columns[celdaSeleccionada.ColumnIndex].Name);
            int horaSeleccionada = celdaSeleccionada.RowIndex + 7;

            List<string> tiposEventos = new List<string>();
            tiposEventos.Add("REVISION DEL SGC POR LA DIRECCION");
            tiposEventos.Add("REVISION DE INDICADORES");
            tiposEventos.Add("AUDITORIA INTERNA");
            tiposEventos.Add("AUDITORIA EXTERNA");
            tiposEventos.Add("CAPACITACION");
            tiposEventos.Add("JUNTA DE PLANEACION");
            tiposEventos.Add("JUNTA TECNICA");
            tiposEventos.Add("FESTEJO");
            tiposEventos.Add("SIMULACRO");
            tiposEventos.Add("DIA INHABIL");
            tiposEventos.Add("TOMA DE CONCIENCIA");
            FrmNuevaJunta nuevaJunta = new FrmNuevaJunta(tiposEventos, string.Empty, "NUEVO EVENTO", string.Empty, 0, null, null, false, fechaSeleccionada, fechaSeleccionada, horaSeleccionada);
            
            if(nuevaJunta.ShowDialog() == DialogResult.OK)
            {
                DialogResult resp = MessageBox.Show("Seguro que quieres programar el evento?", "Programar evento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == System.Windows.Forms.DialogResult.No)
                    return;

                Fila insertarJunta = new Fila();
                insertarJunta.AgregarCelda("nombre", nuevaJunta.Nombre);
                insertarJunta.AgregarCelda("descripcion", nuevaJunta.Descripcion);
                insertarJunta.AgregarCelda("fecha", DateTime.Parse(nuevaJunta.FechaJunta));
                insertarJunta.AgregarCelda("topico", 0);
                insertarJunta.AgregarCelda("tipo", nuevaJunta.TipoDeJunta);
                int idEvento = Convert.ToInt32(JuntaEvento.Modelo().Insertar(insertarJunta).Celda("id"));

                foreach (string idUsuario in nuevaJunta.Invitados)
                {
                    Fila insertarInvitados = new Fila();
                    insertarInvitados.AgregarCelda("evento", idEvento);
                    insertarInvitados.AgregarCelda("usuario", idUsuario);
                    JuntaInvitado.Modelo().Insertar(insertarInvitados);
                }

                MessageBox.Show("El evento fue programado correctamente.", "Evento programado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTiposEventos();
                CargarCalendario(CmbVisualizar.Text);
            }
        }

        private void MenuOpcionesCalendario_Opening(object sender, CancelEventArgs e)
        {
            if (DgvCalendario.SelectedCells.Count == 0)
                return;

            DataGridViewCell celdaSeleccionada = DgvCalendario.SelectedCells[0];

            if (celdaSeleccionada == null)
                return;

            DateTime fechaSeleccionada = Convert.ToDateTime(DgvCalendario.Columns[celdaSeleccionada.ColumnIndex].Name);
            int horaSeleccionada = celdaSeleccionada.RowIndex + 7;
            programarEventoToolStripMenuItem.Enabled = (fechaSeleccionada.Date > DateTime.Now.Date || (fechaSeleccionada.Date == DateTime.Now.Date && horaSeleccionada > DateTime.Now.Hour));
        }

        public void CargarEventosDia(DateTime dia)
        {
            JuntaEvento.Modelo().SeleccionarFecha(dia, CmbTipoEvento.Text).ForEach(delegate(Fila f)
            {
                DateTime fechaHoraJunta = Convert.ToDateTime(f.Celda("fecha"));
                int indiceFila = 0;
                if (fechaHoraJunta.TimeOfDay.Hours == 0)
                    indiceFila = 1;
                else
                    indiceFila = fechaHoraJunta.TimeOfDay.Hours - 7;

                DgvCalendario.Rows[indiceFila].Cells[fechaHoraJunta.Date.ToString()].Value = (Image)CB_Base.Properties.Resources.marker_icon_32;

            });
        }

        public void MostrarEventosDia(DateTime dia)
        {
            LblEventosProgramados.Text = "EVENTOS PROGRAMADOS PARA EL DIA " + dia.ToString("MMM dd, yyyy").ToUpper();
            DgvEventos.Rows.Clear();
            JuntaEvento.Modelo().SeleccionarFecha(dia).ForEach(delegate(Fila f)
            {
                DateTime fechaHoraJunta = Convert.ToDateTime(f.Celda("fecha"));

                string strHora = string.Empty;
                string strInvitados = string.Empty;

                if (fechaHoraJunta.Hour == 0)
                    strHora = "TODO EL DIA";
                else
                    strHora = fechaHoraJunta.TimeOfDay.Hours.ToString().PadLeft(2, '0') + ":" + fechaHoraJunta.TimeOfDay.Minutes.ToString().PadLeft(2, '0');


                List<Fila> invitados = JuntaInvitado.Modelo().SeleccionaInvitado(Convert.ToInt32(f.Celda("id")));

                for(int i=0; i<invitados.Count; i++)
                {
                    strInvitados += invitados[i].Celda("nombre") + " " + invitados[i].Celda("paterno");
                    if (i < invitados.Count - 1)
                        strInvitados += ", " + Environment.NewLine; 
                }


                DgvEventos.Rows.Add(f.Celda("id"), f.Celda("nombre"), f.Celda("tipo"), strHora, strInvitados);

            });
            DivisorPrincipal.Panel2Collapsed = DgvEventos.Rows.Count == 0;
        }

        private void DgvCalendario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(CmbVisualizar.Text == "DIAS")
                MostrarEventosDia(Convert.ToDateTime(DgvCalendario.Columns[e.ColumnIndex].Name));
        }

        private void CmbTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCalendario(CmbVisualizar.Text);
        }
    }
}

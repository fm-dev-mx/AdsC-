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
    public partial class FrmMiMonitor : Form
    {
        public FrmMiMonitor()
        {
            InitializeComponent();
        }

        private void FrmMiMonitor_Load(object sender, EventArgs e)
        {
            CargarMetricos();
            CargarInformacion();
        }
         private void CargarInformacion()
        {
            TareasResponsables responsables = new TareasResponsables();
            responsables.SeleccionarTareasDeUsuario(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")), false).ForEach(delegate (Fila f)
            {
                string prioridad = f.Celda("prioridad").ToString();
                switch (prioridad)
                {
                    case "URGENTE":
                        DgvUrgentes.Rows.Add
                        (
                            f.Celda("id"),
                            Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                            f.Celda("nombre"),
                            f.Celda("descripcion"),
                            Global.FechaATexto(f.Celda("fecha_promesa"), false)
                        );
                        break;
                    case "REQUIERE ATENCION":
                        DgvRequiereAtencion.Rows.Add
                        (
                            f.Celda("id"),
                            Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                            f.Celda("nombre"),
                            f.Celda("descripcion"),
                            Global.FechaATexto(f.Celda("fecha_promesa"), false)
                        );
                       
                        break;
                    case "REGULAR":
                        DgvRegular.Rows.Add
                        (
                            f.Celda("id"),
                            Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                            f.Celda("nombre"),
                            f.Celda("descripcion"),
                            Global.FechaATexto(f.Celda("fecha_promesa"), false)
                        );

                        break;
                    default:
                        break;
                }
            });

            DgvRegular.ClearSelection();
            DgvRequiereAtencion.ClearSelection();
            DgvUrgentes.ClearSelection();

            responsables.HorasTrabajo(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")), false);
            if(responsables.TieneFilas())
            {
                TimeSpan tiempo = TimeSpan.FromHours(Convert.ToDouble(responsables.Fila().Celda("horas")));
                LblHorasTrabajo.Text = "Horas de trabajo: " + tiempo.ToString("hh\\:mm");
            }

        }

        private void CargarMetricos()
        {
            TareasTopico tareas = new TareasTopico();

            List<Fila> tareasCompletadasEsteMes = tareas.TareasTerminadasEnElMes(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));
            if (tareasCompletadasEsteMes.Count > 0)
                LblCompletasEsteMes.Text = "Completadas este mes: " + tareasCompletadasEsteMes.Count;
            else
                LblCompletasEsteMes.Text = "Completadas este mes: " + 0;

            List<Fila> tareasCompletadasenSemana = tareas.TareasTerminadasEnLaSemana(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));
            if (tareasCompletadasenSemana.Count > 0)
               LblCompletadasSemana.Text = "Completadas esta semana: " + tareasCompletadasenSemana.Count;
            else
                LblCompletadasSemana.Text = "Completadas esta semana: " + 0;

            List<Fila> tareasCompletadasEnMesATiempo = tareas.TareasTerminadasEnMesConEstatus(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")), "TERMINADO A TIEMPO");
            if (tareasCompletadasEnMesATiempo.Count > 0)
                LblAtiempoElMes.Text = "Completadas a tiempo(mes): " + tareasCompletadasEnMesATiempo.Count;
            else
                LblAtiempoElMes.Text = "Completadas a tiempo(mes): " + 0;

            List<Fila> tareasCompletadasEnMesTarde = tareas.TareasTerminadasEnMesConEstatus(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")), "TERMINADO TARDE");
            if (tareasCompletadasEnMesTarde.Count > 0)
                lblTardesEnMes.Text = "Completadas tarde(mes): " + tareasCompletadasEnMesTarde.Count;
            else
                lblTardesEnMes.Text = "Completadas tarde(mes): " + 0;

        }

        private void MenuUrgentes_Opening(object sender, CancelEventArgs e)
        {
            //mostrarTerminadosToolStripMenuItemUrgentes.Visible = (DgvUrgentes.Rows.Count > 0 || DgvUrgentes.SelectedRows.Count > 0);    
        }

        private void MenuRequiereAtencion_Opening(object sender, CancelEventArgs e)
        {
          // mostrarTerminadosItemRequiereAtencion.Visible = (DgvRequiereAtencion.Rows.Count > 0 || DgvRequiereAtencion.SelectedRows.Count > 0);
        }

        private void MenuRegular_Opening(object sender, CancelEventArgs e)
        {
          // mostrarTerminadosItemRegular.Visible = (DgvRegular.Rows.Count > 0 || DgvRegular.SelectedRows.Count > 0);
        }

        private void mostrarTerminadosToolStripMenuItemUrgentes_Click(object sender, EventArgs e)
        {
            CargarDataGridView(DgvUrgentes, mostrarTerminadosToolStripMenuItemUrgentes,"URGENTE");
        }

        private void mostrarTerminadosItemRequiereAtencion_Click(object sender, EventArgs e)
        {
            CargarDataGridView(DgvRequiereAtencion, mostrarTerminadosItemRequiereAtencion, "REQUIERE ATENCION");
        }

        private void mostrarTerminadosItemRegular_Click(object sender, EventArgs e)
        {
            CargarDataGridView(DgvRegular, mostrarTerminadosItemRegular, "REGULAR");

           /* TareasResponsables responsables = new TareasResponsables();
            responsables.HorasTrabajo(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")), mostrarTerminadosToolStripMenuItemUrgentes.Checked);
            if (responsables.TieneFilas())
            {
                TimeSpan tiempo = TimeSpan.FromHours(Convert.ToDouble(responsables.Fila().Celda("horas")));
                LblHorasTrabajo.Text = "Horas de trabajo: " + tiempo.ToString("hh\\:mm");
            }*/
        }

        private void CargarDataGridView(DataGridView dgv, ToolStripMenuItem itemMenu, string strPrioridad)
        {
            dgv.Rows.Clear();
            TareasResponsables responsables = new TareasResponsables();
            responsables.SeleccionarTareasDeUsuario(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")), itemMenu.Checked).ForEach(delegate (Fila f)
            {
                string prioridad = f.Celda("prioridad").ToString();
                if (strPrioridad == prioridad)
                {
                    dgv.Rows.Add
                    (
                        f.Celda("id"),
                        Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                        f.Celda("nombre"),
                        f.Celda("descripcion"),
                        Global.FechaATexto(f.Celda("fecha_promesa"), false)
                    );
                }
            });

            dgv.ClearSelection();
        }
    }
}

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
using LiveCharts.Helpers;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;

namespace CB
{
    public partial class FrmTareas : Form
    {
        decimal Proyecto = 0;
        Proyecto ProyectoCargado = new Proyecto();

        public FrmTareas(Decimal proyecto)
        {
            Proyecto = proyecto;
            InitializeComponent();
        }

        private void FrmTareas_Load(object sender, EventArgs e)
        {
            ProyectoCargado.CargarDatos(Proyecto);
            audiselTituloForm1.Text = "TAREAS DEL PROYECTO " + Proyecto.ToString("F2") + " - " + ProyectoCargado.Fila().Celda("nombre");
            CargarTareas();
        }

        private void CargarTareas()
        {
            DgvTareas.Rows.Clear();

            Topico topicos = new Topico();
            topicos.CargarTareasDeProyecto(Proyecto, mostrarRevisadosToolStripMenuItem.Checked).ForEach(delegate (Fila f)
            {
                bool limpiarResponsable = true;
                string responsable = "SIN DEFINIR";
                TareasResponsables responsables = new TareasResponsables();
                responsables.SeleccionarTarea(Convert.ToInt32(f.Celda("id"))).ForEach(delegate (Fila filaResp)
                {
                    if (limpiarResponsable)
                        responsable = string.Empty;

                    responsable += filaResp.Celda("responsable").ToString() + ", " + Environment.NewLine;
                    limpiarResponsable = false;
                });

                responsable = responsable.TrimEnd();
                if (responsable.EndsWith(","))
                    responsable = responsable.Remove(responsable.Length - 1, 1);

                
                DgvTareas.Rows.Add
                (
                    f.Celda("id"),
                    "Sync-" + Global.FechaATexto(f.Celda("Junta_sinc"), false),
                    responsable,
                    f.Celda("tarea_nombre"),
                    f.Celda("estatus"),
                    f.Celda("prioridad"),
                    Global.FechaATexto(f.Celda("fecha_promesa"), false),
                    f.Celda("estatus_tiempo"),
                    f.Celda("id_topico")                    
                ); 
            });
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvTareas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string estatus = DgvTareas.Rows[e.RowIndex].Cells["estatus"].Value.ToString();
            string prioridad = DgvTareas.Rows[e.RowIndex].Cells["estatus"].Value.ToString();
            string estatusTiempo = DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Value.ToString();
            DateTime fechaPromesa = Convert.ToDateTime(DgvTareas.Rows[e.RowIndex].Cells["fecha_promesa"].Value);

            if(fechaPromesa.Date < DateTime.Today.Date)
                DgvTareas.Rows[e.RowIndex].Cells["fecha_promesa"].Style.BackColor = Color.Coral;

            switch (estatus)
            {
                case "PENDIENTE":
                    DgvTareas.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.Yellow;
                    break;
                case "EN PROCESO":
                    DgvTareas.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.LightGreen;
                    break;
                case "DETENIDO":
                    DgvTareas.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.Coral;
                    break;
                case "REVISADO":
                    DgvTareas.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.ForestGreen;
                    break;
                case "TERMINADO":
                    DgvTareas.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.ForestGreen;
                    break;
            }

            switch (prioridad)
            {
                case "URGENTE":
                    DgvTareas.Rows[e.RowIndex].Cells["prioridad"].Style.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    DgvTareas.Rows[e.RowIndex].Cells["prioridad"].Style.ForeColor = Color.Coral;
                    break;
                case "REQUIERE ATENCION":
                    DgvTareas.Rows[e.RowIndex].Cells["prioridad"].Style.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    break;
            }

            switch (estatus)
            {
                case "DETENIDO":
                    if (estatusTiempo == "A TIEMPO" || estatusTiempo == "DETENIDO A TIEMPO")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.LightGreen;
                    else if (estatusTiempo == "LIMITE" || estatusTiempo == "DETENIDO LIMITE")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.Yellow;
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "DETENIDO TARDE")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.Coral;
                    break;

                case "EN PROCESO":
                    if (estatusTiempo == "A TIEMPO" || estatusTiempo == "EN PROCESO A TIEMPO")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.LightGreen;
                    else if (estatusTiempo == "LIMITE" || estatusTiempo == "EN PROCESO LIMITE")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.Yellow;
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "EN PROCESO TARDE")

                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.Coral;
                    break;

                case "PENDIENTE":
                    if (estatusTiempo == "A TIEMPO" || estatusTiempo == "PENDIENTE A TIEMPO")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.LightGreen;
                    else if (estatusTiempo == "LIMITE" || estatusTiempo == "PENDIENTE LIMITE")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.Yellow;
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "PENDIENTE TARDE")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.Coral;
                    break;

                case "TERMINADO":
                    if (estatusTiempo == "A TIEMPO" || estatusTiempo == "TERMINADO A TIEMPO")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.LightGreen;
                    else if (estatusTiempo == "LIMITE" || estatusTiempo == "TERMINADO LIMITE")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.Yellow;
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "TERMINADO TARDE")
                        DgvTareas.Rows[e.RowIndex].Cells["estatus_tiempo"].Style.BackColor = Color.Coral;
                    break;
                default:
                    break;
            }

        }

        private void editarEstatusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuTareas_Opening(object sender, CancelEventArgs e)
        {
            if (DgvTareas.SelectedRows.Count < 0)
                return;

            string estatus = DgvTareas.SelectedRows[0].Cells["estatus"].Value.ToString();

            List<string> listaResponsables = DgvTareas.SelectedRows[0].Cells["responsable"].Value.ToString().Split(',').ToList();
            string nombreResponsable = listaResponsables.FirstOrDefault(s => s.Contains(Global.UsuarioActual.NombreCompleto()));
            editarEstatusToolStripMenuItem.Enabled =(nombreResponsable != null);
            editarPrioridadToolStripMenuItem.Enabled = Global.PrivilegioPorRol("LIDER DE PROYECTO");
            switch (estatus)
            {
                case "TERMINADO":
                    pendienteToolStripMenuItem.Enabled = false; 
                    enProcesoToolStripMenuItem.Enabled = false;
                    terminadoToolStripMenuItem.Enabled = false;
                    detenidoToolStripMenuItem.Enabled = false;
                    revisadoToolStripMenuItem.Enabled = true;

                    urgenteToolStripMenuItem.Enabled = false;
                    requiereAtenciónToolStripMenuItem.Enabled = false;
                    regularToolStripMenuItem.Enabled = false;
                    break;
                case "REVISADO":
                    pendienteToolStripMenuItem.Enabled = false;
                    enProcesoToolStripMenuItem.Enabled = false;
                    terminadoToolStripMenuItem.Enabled = false;
                    detenidoToolStripMenuItem.Enabled = false;
                    revisadoToolStripMenuItem.Enabled = false;

                    urgenteToolStripMenuItem.Enabled = false;
                    requiereAtenciónToolStripMenuItem.Enabled = false;
                    regularToolStripMenuItem.Enabled = false;
                    break;
                default:
                    pendienteToolStripMenuItem.Enabled = true;
                    enProcesoToolStripMenuItem.Enabled = true;
                    terminadoToolStripMenuItem.Enabled = true;
                    detenidoToolStripMenuItem.Enabled = true;
                    revisadoToolStripMenuItem.Enabled = true;

                    urgenteToolStripMenuItem.Enabled = true;
                    requiereAtenciónToolStripMenuItem.Enabled = true;
                    regularToolStripMenuItem.Enabled = true;
                    break;
            }

            /*pendienteToolStripMenuItem.Enabled = (estatus != "TERMINADO" && estatus != "REVISADO");
            enProcesoToolStripMenuItem.Enabled = (estatus != "TERMINADO" && estatus != "REVISADO");
            terminadoToolStripMenuItem.Enabled = (estatus != "TERMINADO" && estatus != "REVISADO");
            detenidoToolStripMenuItem.Enabled =  (estatus != "TERMINADO" && estatus != "REVISADO");
            revisadoToolStripMenuItem.Enabled =  (estatus != "TERMINADO" && estatus != "REVISADO");

            urgenteToolStripMenuItem.Enabled = (estatus != "TERMINADO" && estatus != "REVISADO"); ;
            requiereAtenciónToolStripMenuItem.Enabled = (estatus != "TERMINADO" && estatus != "REVISADO"); ;
            regularToolStripMenuItem.Enabled = (estatus != "TERMINADO" && estatus != "REVISADO"); */
        }                                        

        private void urgenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DgvTareas.Rows.Count >= 10)
            {
                int totalRows = DgvTareas.Rows.Count;
                int contadorTareasUrgentes = 0;
                foreach (DataGridViewRow row in DgvTareas.Rows)
                {
                    if (row.Cells["prioridad"].Value.ToString() == "URGENTE")
                        contadorTareasUrgentes++;
                }

                //no debe exceder el 20%
                decimal porcentaje = (contadorTareasUrgentes * 100) / totalRows;
                if(porcentaje >= 20)
                {
                    MessageBox.Show("No puede haber más del 20% con prioridad URGENTE", "No se puede editar la prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DialogResult result = MessageBox.Show("¿Desea cambiar la prioridad de la tarea seleccionada?", "Caambiar prioridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            int idTarea = Convert.ToInt32(DgvTareas.SelectedRows[0].Cells["id"].Value);
            TareasTopico tarea = new TareasTopico();
            tarea.CargarDatos(idTarea);

            if (tarea.TieneFilas())
            {
                tarea.Fila().ModificarCelda("prioridad", "URGENTE");
                tarea.GuardarDatos();

                //seguimiento
                Fila insertarSeguimiento = new Fila();
                insertarSeguimiento.AgregarCelda("tarea", idTarea);
                insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
                insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
                insertarSeguimiento.AgregarCelda("comentario", "CAMBIO DE PRIORIDAD A URGENTE");
                insertarSeguimiento.AgregarCelda("editable", "0");
                TareasSeguimiento.Modelo().Insertar(insertarSeguimiento);
            }

            CargarTareas();
        }

        private void requiereAtenciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvTareas.Rows.Count >= 10)
            {
                int totalRows = DgvTareas.Rows.Count;
                int contadorTareasUrgentes = 0;
                foreach (DataGridViewRow row in DgvTareas.Rows)
                {
                    if (row.Cells["prioridad"].Value.ToString() == "URGENTE")
                        contadorTareasUrgentes++;
                }

                //no debe exceder el 30%
                decimal porcentaje = (contadorTareasUrgentes * 100) / totalRows;
                if (porcentaje >= 30)
                {
                    MessageBox.Show("No puede haber más del 30% con prioridad REQUIERE ATENCION", "No se puede editar la prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DialogResult result = MessageBox.Show("¿Desea cambiar la prioridad de la tarea seleccionada?", "Caambiar prioridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            int idTarea = Convert.ToInt32(DgvTareas.SelectedRows[0].Cells["id"].Value);
            TareasTopico tarea = new TareasTopico();
            tarea.CargarDatos(idTarea);

            if (tarea.TieneFilas())
            {
                tarea.Fila().ModificarCelda("prioridad", "REQUIERE ATENCION");
                tarea.GuardarDatos();

                //seguimiento
                Fila insertarSeguimiento = new Fila();
                insertarSeguimiento.AgregarCelda("tarea", idTarea);
                insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
                insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
                insertarSeguimiento.AgregarCelda("comentario", "CAMBIO DE PRIORIDAD A REQUIERE ATENCION");
                insertarSeguimiento.AgregarCelda("editable", "0");
                TareasSeguimiento.Modelo().Insertar(insertarSeguimiento);
            }

            CargarTareas();
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cambiar la prioridad de la tarea seleccionada?", "Caambiar prioridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            int idTarea = Convert.ToInt32(DgvTareas.SelectedRows[0].Cells["id"].Value);
            TareasTopico tarea = new TareasTopico();
            tarea.CargarDatos(idTarea);

            if (tarea.TieneFilas())
            {
                tarea.Fila().ModificarCelda("prioridad", "URGENTE");
                tarea.GuardarDatos();

                //seguimiento
                Fila insertarSeguimiento = new Fila();
                insertarSeguimiento.AgregarCelda("tarea", idTarea);
                insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
                insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
                insertarSeguimiento.AgregarCelda("comentario", "CAMBIO DE PRIORIDAD A URGENTE");
                insertarSeguimiento.AgregarCelda("editable", "0");
                TareasSeguimiento.Modelo().Insertar(insertarSeguimiento);

                CargarTareas();
            }
        }

        public void ModificarTareasTopico(int idTarea, string columnaValor, string columna = "estatus")
        {
            int idTopico = Convert.ToInt32(DgvTareas.SelectedRows[0].Cells["id_topico"].Value);
            DateTime fehcaPromesa = Convert.ToDateTime(DgvTareas.SelectedRows[0].Cells["fecha_promesa"].Value);
           
            TareasTopico tareaTopico = new TareasTopico();
            tareaTopico.CargarDatos(idTarea);
            tareaTopico.Fila().ModificarCelda("estatus", columnaValor);
            tareaTopico.Fila().ModificarCelda("estatus_tiempo", columnaValor + " " + CalcularEstatusTiempo(fehcaPromesa));

            if(columnaValor == "TERMINADO")
                tareaTopico.Fila().ModificarCelda("fecha_tarea_terminada", DateTime.Now);
            else if(columna != "REVISADO")
                tareaTopico.Fila().ModificarCelda("fecha_tarea_terminada", null);

            tareaTopico.GuardarDatos();

            //seguimiento
            Fila insertarSeguimiento = new Fila();
            insertarSeguimiento.AgregarCelda("tarea", idTarea);
            insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
            insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
            insertarSeguimiento.AgregarCelda("comentario", "CAMBIO DE ESTATUS " + columnaValor.ToUpper());
            insertarSeguimiento.AgregarCelda("editable", "0");
            TareasSeguimiento.Modelo().Insertar(insertarSeguimiento);
        }

        public string CalcularEstatusTiempo(DateTime fecha)
        {
            if (Convert.ToDateTime(fecha).Date > DateTime.Now.Date)
                return "A TIEMPO";
            else if (Convert.ToDateTime(fecha).Date == DateTime.Now.Date)
                return "LIMITE";
            else
                return "TARDE";
        }

        private void pendienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cambiar el estatus de la tarea seleccionada?", "Cambiar estatus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            int idTarea = Convert.ToInt32(DgvTareas.SelectedRows[0].Cells["id"].Value);
            ModificarTareasTopico(idTarea, "PENDIENTE");
            CargarTareas();
        }

        private void enProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cambiar el estatus de la tarea seleccionada?", "Cambiar estatus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            int idTarea = Convert.ToInt32(DgvTareas.SelectedRows[0].Cells["id"].Value);
            ModificarTareasTopico(idTarea, "EN PROCESO");
            CargarTareas();
        }

        private void detenidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cambiar el estatus de la tarea seleccionada?", "Cambiar estatus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            int idTarea = Convert.ToInt32(DgvTareas.SelectedRows[0].Cells["id"].Value);
            ModificarTareasTopico(idTarea, "DETENIDO");
            CargarTareas();
        }

        private void terminadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idTarea = Convert.ToInt32(DgvTareas.SelectedRows[0].Cells["id"].Value);
            ModificarTareasTopico(idTarea, "TERMINADO");
            CargarTareas();
        }

        private void revisadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idTarea = Convert.ToInt32(DgvTareas.SelectedRows[0].Cells["id"].Value);
            ModificarTareasTopico(idTarea, "REVISADO");
            CargarTareas();
        }

        private void editarPrioridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mostrarRevisadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarTareas();
        }
    }
}

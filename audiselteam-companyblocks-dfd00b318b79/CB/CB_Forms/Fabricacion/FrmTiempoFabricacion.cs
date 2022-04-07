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
    public partial class FrmTiempoFabricacion : Form
    {
        int IdProceso = 0;
        PlanoProceso ProcesoSeleccionado = new PlanoProceso();
        Usuario Herramentistas = new Usuario();

        public FrmTiempoFabricacion(int idProceso)
        {
            IdProceso = idProceso;
            InitializeComponent();
            Herramentistas.SeleccionarRolActivos("TECNICO HERRAMENTISTA");
        }

        private void FrmTiempoFabricacion_Load(object sender, EventArgs e)
        {
            ProcesoSeleccionado.CargarDatos(IdProceso);
            LblProceso.Text = ProcesoSeleccionado.Fila().Celda("proceso").ToString();
            CargarHerramentista();
        }

        private void CargarHerramentista()
        {
            Herramentistas.Filas().ForEach(delegate (Fila f)
            {
                CmbHerramentista.Items.Add(f.Celda("id") + " - " + f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString());
            });

            if (CmbHerramentista.Items.Count > 0)
                CmbHerramentista.SelectedIndex = 0;
        }

        private void CargarHerramentistasInvolucrados(int idHerramentista)
        {
            DgvHerramentistas.Rows.Clear();
            Herramentistas.Filas().ForEach(delegate (Fila f)
            {
                if(idHerramentista != Convert.ToInt32(f.Celda("id")))
                    DgvHerramentistas.Rows.Add(f.Celda("id"), false, f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString());
            });

            DgvHerramentistas.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            //checar que no haya nulos en la hora de trabajo
            foreach (DataGridViewRow row in DgvHerramentistas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check"].Value))
                {
                    if (row.Cells["tiempo_trabajo"].Value == null)
                    {
                        MessageBox.Show("Favor de colocar las horas trabajadas de herramentistas seleccionados", "Falta horas trabajadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if(row.Cells["tiempo_trabajo"].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Favor de colocar las horas trabajadas de herramentistas seleccionados", "Falta horas trabajadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            if(NumTiempo.Value <= 0)
            {
                MessageBox.Show("El tiempo debe ser mayor a 0", "Tiempo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Está seguro que desea guardar los datos de los herramentistas?", "Guardar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;


            

            // Calcular costo real fabricacion = tiempoTrabajoReal * sueldoHrDelHerramentistaAsignado
            Sueldo sueldo = new Sueldo();
            decimal sueldoHora = 0;
            

            foreach (DataGridViewRow row in DgvHerramentistas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check"].Value))
                {
                    int idHerramentista = 0;
                    string nombreHerramentista = string.Empty;

                    idHerramentista = Convert.ToInt32(row.Cells["id"].Value);
                    nombreHerramentista = row.Cells["herramentista"].Value.ToString();

                    // tiempoTrabajoReal está expresado en horas totales en decimal ej 0.10219117997222221
                    // para calcular las hrs = 0.10219117997222221 * hrs de trabajo del herramentista asignado
                    double CostoRealFabricacion = Convert.ToDouble(row.Cells["tiempo_trabajo"].Value) * Convert.ToDouble(sueldoHora);

                    Fila insertarHerramentista = new Fila();
                    insertarHerramentista.AgregarCelda("herramentista", idHerramentista);
                    insertarHerramentista.AgregarCelda("nombre_herramentista", nombreHerramentista);
                    insertarHerramentista.AgregarCelda("proceso", IdProceso);
                    insertarHerramentista.AgregarCelda("nombre_proceso", ProcesoSeleccionado.Fila().Celda("proceso").ToString());
                    insertarHerramentista.AgregarCelda("tiempo_trabajo", row.Cells["tiempo_trabajo"].Value);
                    insertarHerramentista.AgregarCelda("fecha_creacion", DateTime.Now.Date);
                    insertarHerramentista.AgregarCelda("costo_fabricacion", CostoRealFabricacion);
                    ProcesoHerramentista.Modelo().Insertar(insertarHerramentista);
                }
            }


            int idHerramentistaSeleccionado = Convert.ToInt32(CmbHerramentista.Text.Split('-')[0].Trim());
            string nombreHerramentistaSeleccionado = CmbHerramentista.Text.Split('-')[1].TrimStart();
            double CostoRealFabricacionHerramentistaSeleccionado = Convert.ToDouble(NumTiempo.Value) * Convert.ToDouble(sueldoHora);

            sueldo.BuscarSueldo(idHerramentistaSeleccionado);
            if (sueldo.TieneFilas())
                sueldoHora = Convert.ToDecimal(sueldo.Fila().Celda("sueldo_hora"));

            ProcesoSeleccionado.CargarDatos(IdProceso);
            ProcesoSeleccionado.Fila().ModificarCelda("estatus", "TERMINADO");
            ProcesoSeleccionado.Fila().ModificarCelda("fecha_termino", DateTime.Today);
            ProcesoSeleccionado.Fila().ModificarCelda("herramentista", idHerramentistaSeleccionado);
            ProcesoSeleccionado.Fila().ModificarCelda("operador", nombreHerramentistaSeleccionado);

            if (Convert.ToDouble(ProcesoSeleccionado.Fila().Celda("tiempo_trabajo_estimado")) <= 0)
                ProcesoSeleccionado.Fila().ModificarCelda("tiempo_trabajo_estimado", NumTiempo.Value);

            ProcesoSeleccionado.Fila().ModificarCelda("tiempo_trabajo_real", NumTiempo.Value);
            ProcesoSeleccionado.Fila().ModificarCelda("costo_real_fabricacion", CostoRealFabricacionHerramentistaSeleccionado.ToString("F2"));

            if (Convert.ToDouble(ProcesoSeleccionado.Fila().Celda("costo_estimado_fabricacion")) <= 0)
                ProcesoSeleccionado.Fila().ModificarCelda("costo_estimado_fabricacion", CostoRealFabricacionHerramentistaSeleccionado.ToString("F2"));

            TimeSpan horasFabricacion = TimeSpan.Parse("00:00:00");
            TiempoFabricacion tiempoFabricacion = new TiempoFabricacion();

            foreach (Fila f in tiempoFabricacion.CargarTiempoFabricacion(IdProceso))
            {
                TimeSpan tiempoTranscurrido = DateTime.Now - Convert.ToDateTime(ProcesoSeleccionado.Fila().Celda("fecha_inicio"));
                DateTime fechaInicio = Convert.ToDateTime(f.Celda("fecha_inicio").ToString());
                DateTime fechaParo;
                double tiempoTotal = (tiempoTranscurrido.TotalHours * 100) / Convert.ToDouble(ProcesoSeleccionado.Fila().Celda("tiempo_trabajo_estimado"));

                if (Global.ObjetoATexto(f.Celda("fecha_paro"), "N/A") != "N/A")
                    fechaParo = Convert.ToDateTime(f.Celda("fecha_paro").ToString());
                else
                    fechaParo = DateTime.Now;

                TimeSpan diferenciaHoras = fechaParo - fechaInicio;
                horasFabricacion = horasFabricacion.Add(diferenciaHoras);
                f.ModificarCelda("fecha_paro", fechaParo);
            }
            tiempoFabricacion.GuardarDatos(); 

            ProcesoSeleccionado.GuardarDatos();

            DialogResult = DialogResult.OK;

        }

        private void CmbHerramentista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idHerramentistaSeleccionado = Convert.ToInt32(CmbHerramentista.SelectedItem.ToString().Split('-')[0].Trim());
            CargarHerramentistasInvolucrados(idHerramentistaSeleccionado);
        }

        private void DgvHerramentistas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.DgvHerramentistas.CurrentCell.ColumnIndex == DgvHerramentistas.Columns["tiempo_trabajo"].Index & (e.Control != null))
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += Tb_KeyPress;
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //---if textbox is empty and user pressed a decimal char---
            if (((TextBox)sender).Text == string.Empty & e.KeyChar == (char)58) //46 = .
            {
                e.Handled = true;
                return;
            }
            //---if textbox already has a decimal point---
            if (((TextBox)sender).Text.Contains(Convert.ToString((char)46)) & e.KeyChar == (char)46)
            {
                e.Handled = true;
                return;
            }
            //if (!(char.IsDigit(e.KeyChar).ToString() ==","))
            if (!(e.KeyChar == 44) & !(e.KeyChar == 45))
            {
                if ((!(char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar) | (e.KeyChar == (char)46))))
                {
                    e.Handled = true;
                }
            }
        }

        private void NumTrabajo_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}

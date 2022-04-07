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
    public partial class FrmPlanificarTiempoExtra : Ventana
    {
        PerfilPuesto Perfil = new PerfilPuesto();
        Usuario UsuarioActual = Global.UsuarioActual;
        int NivelUsuarioActual = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("nivel"));
        EquipoTrabajo Equipo = new EquipoTrabajo();
        EquipoTrabajoIntegrantes Integrantes = new EquipoTrabajoIntegrantes(); 
        int IdProcesoFabricacion = 0;
        int IdTarea = 0;

        public FrmPlanificarTiempoExtra(int idProcesoFabricacion, int idTarea=0)
        {
            InitializeComponent();
            IdProcesoFabricacion = idProcesoFabricacion;
            IdTarea = idTarea;
            Perfil.Cargar(Global.UsuarioActual.Fila().Celda("rol").ToString(), Convert.ToInt32(Global.UsuarioActual.Fila().Celda("nivel")));
        }

        public void CargarDatos()
        {
            if(NivelUsuarioActual != 0 && NivelUsuarioActual != 3)
            {
                MessageBox.Show("Para planificar tiempo extra debes ser lider o supervisor.", "Imposible planificar tiempo extra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            Equipo.BuscarEquipoPorLider(Convert.ToInt32(UsuarioActual.Fila().Celda("id")));
            if(!Equipo.TieneFilas())
            {
                MessageBox.Show("Para planificar tiempo extra debes tener asignado un equipo.", "Imposible planificar tiempo extra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if(IdProcesoFabricacion > 0 && ActividadesTiempoExtra.Modelo().BuscarProcesoFabricacion(IdProcesoFabricacion).Count > 0)
            {
                DialogResult resp = MessageBox.Show("Este proceso ya fue programado anteriormente para tiempo extra, seguro que quieres volver a programarlo?", "Proceso programado anteriormente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(resp != System.Windows.Forms.DialogResult.Yes)
                {
                    Close();
                    return;
                }
            } 
            else if (IdTarea > 0 && ActividadesTiempoExtra.Modelo().BuscarTarea(IdTarea).Count > 0)
            {
                DialogResult resp = MessageBox.Show("Esta tarea ya fue programado anteriormente para tiempo extra, seguro que quieres volver a programarla?", "Tarea programada anteriormente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp != System.Windows.Forms.DialogResult.Yes)
                {
                    Close();
                    return;
                }
            }
                
            TxtNombreSupervisor.Text = UsuarioActual.Fila().Celda("id").ToString() + " - " + UsuarioActual.NombreCompleto();
            TxtEquipo.Text = Convert.ToInt32(Equipo.Fila().Celda("id")).ToString().PadLeft(2, '0');
            TxtDepartamento.Text = Perfil.Fila().Celda("departamento").ToString();
            Integrantes.CargarEquipo(Convert.ToInt32(Equipo.Fila().Celda("id")));

            CmbEmpleado.Items.Clear();
            CmbEmpleado.Items.Add(TxtNombreSupervisor.Text);
            Integrantes.Filas().ForEach(delegate(Fila f)
            {
                CmbEmpleado.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });

            if(IdProcesoFabricacion != 0)
            {
                PlanoProceso proceso = new PlanoProceso();
                proceso.CargarDatos(IdProcesoFabricacion);

                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(Convert.ToInt32(proceso.Fila().Celda("plano")));

                if(plano.TieneFilas())
                    TxtActividad.Text = "PROC. FAB. #" + proceso.Fila().Celda("id").ToString() + " " + proceso.Fila().Celda("proceso").ToString() + " | " + plano.Fila().Celda("id").ToString() + " " + plano.Fila().Celda("nombre_archivo");
                else
                    TxtActividad.Text = "N/A";
            }
            else if(IdTarea != 0)
            {
                TareasTopico tarea = new TareasTopico();
                tarea.CargarDatos(IdTarea);

                if (tarea.TieneFilas())
                    TxtActividad.Text = "TAREA #" + tarea.Fila().Celda("id").ToString() + " " + tarea.Fila().Celda("nombre").ToString();
                else
                    TxtActividad.Text = "N/A";
            }

            DateTiempoExtra.MinDate = DateTime.Now;
            DateTiempoExtra.MaxDate = DateTime.Now.AddDays(6);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void FrmPlanificarTiempoExtra_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void BtnPlanificar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres planificar esta actividad en tiempo extra?", "Planificar tiempo extra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != System.Windows.Forms.DialogResult.Yes) return;

            int idEmpleado = Convert.ToInt32(CmbEmpleado.Text.Split('-')[0]);

            Fila f = new Fila();
            f.AgregarCelda("actividad", TxtActividad.Text);
            f.AgregarCelda("fecha", DateTiempoExtra.Value);
            f.AgregarCelda("supervisor", UsuarioActual.Fila().Celda("id"));
            f.AgregarCelda("usuario", idEmpleado);
            f.AgregarCelda("proceso_fabricacion", IdProcesoFabricacion);
            f.AgregarCelda("tarea", IdTarea);
            f.AgregarCelda("comentarios", TxtComentarios.Text);
            f.AgregarCelda("tiempo_requerido", NumHoras.Value);
            f.AgregarCelda("estatus_cumplimiento", "PENDIENTE");
            f.AgregarCelda("comentarios_cumplimiento", string.Empty);
            f.AgregarCelda("usuario_autorizacion", 0);


            ActividadesTiempoExtra.Modelo().Insertar(f);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnPlanificar.Enabled = CmbEmpleado.Text != string.Empty && NumHoras.Value > 0;
        }

        private void NumHoras_ValueChanged(object sender, EventArgs e)
        {
            if (NumHoras.Value >= 3 && NumHoras.Value <= 5)
                NumHoras.ForeColor = Color.Orange;
            else if (NumHoras.Value > 5)
                NumHoras.ForeColor = Color.Red;
            else
                NumHoras.ForeColor = Color.Black;

            BtnPlanificar.Enabled = CmbEmpleado.Text != string.Empty && NumHoras.Value > 0;
        }
    }
}

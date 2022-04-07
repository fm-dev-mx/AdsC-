using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentFTP;
using System.Net;
using System.IO;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmAsignarProcesoFabricacion2 : Ventana
    {
        public int IdProceso = 0;
        public int IdPlano = 0;

        public double TotalTiempoEstandar = 0;
        public string ComentariosSupervisor = string.Empty;
        public string Proceso = string.Empty;
        public string Herramenstista = string.Empty;
        public string MaquinaHerramienta = string.Empty;
        public string Complejidad = string.Empty;

        public List<Fila> DatosOperacion = new List<Fila>();
        PlanoProyecto Plano = new PlanoProyecto();

        public FrmAsignarProcesoFabricacion2(int idProceso = 0, int idPlano = 0)
        {
            InitializeComponent();
            IdPlano = idPlano;

            if(idProceso > 0)
            {
                LblTiempoEstimado.Text = "";
                LblTiempoEstimadoTotal.Text = "";
                NumProceso.Value = idProceso;
                NumProceso.ReadOnly = true;
                NumProceso.Enabled = false;
                CargarProceso(idProceso);
                ComentariosSupervisor = TxtComentarios.Text;
            }
        }

        private void FrmActualizarProcesoFabricacion_Load(object sender, EventArgs e)
        {
            Plano.CargarDatos(IdPlano);
            CmbMaquinas.SelectedIndex = 0;
        }

        public void CargarProceso(int idProceso)
        {
            PlanoProceso proc = new PlanoProceso();
            proc.CargarDatos(idProceso);
            IdProceso = idProceso;

            if(proc.TieneFilas())
            {
                PlanoProceso anterior = new PlanoProceso();
                anterior.CargarDatos(Convert.ToInt32(proc.Fila().Celda("proceso_anterior")));

                int idReq = Convert.ToInt32(proc.Fila().Celda("requisicion_compra"));

                TxtProceso.Text = proc.Fila().Celda("proceso").ToString();
                TxtComentarios.Text = proc.Fila().Celda("comentarios").ToString();
                double tiempoTotalEstimado = Convert.ToDouble(Global.ObjetoATexto(proc.Fila().Celda("tiempo_trabajo_estimado"), "0"));

                if (tiempoTotalEstimado > 0)
                {
                    int cantidadPiezas = 1;
                    PlanoProyecto proyecto = new PlanoProyecto();
                    proyecto.CargarDatos(IdPlano);

                    if(proyecto.TieneFilas())
                        cantidadPiezas = Convert.ToInt32(Global.ObjetoATexto(proyecto.Fila().Celda("cantidad"), "1"));

                    TimeSpan horasTotales  = TimeSpan.FromHours(tiempoTotalEstimado);
                    TimeSpan horasXPieza = TimeSpan.FromHours((tiempoTotalEstimado / cantidadPiezas));

                    LblTiempoEstimado.Text = horasXPieza.Hours + " horas " + horasXPieza.Minutes + " minutos " + horasXPieza.Seconds + " segundos";
                    LblTiempoEstimadoTotal.Text = horasTotales.Hours + " horas " + horasTotales.Minutes + " minutos " + horasTotales.Seconds + " segundos";
                }

                CargarHerramentistas();
                CmbHerramentista.SelectedItem = CmbHerramentista.FindString(proc.Fila().Celda("operador").ToString());

                Usuario usuario = new Usuario();
                usuario.BuscarPorNombre(proc.Fila().Celda("operador").ToString());
                if (usuario.TieneFilas())
                    CmbHerramentista.Text = usuario.Fila().Celda("id") + " - " + usuario.Fila().Celda("nombre").ToString() + " " + usuario.Fila().Celda("paterno").ToString();
                else
                    CmbHerramentista.Text = "N/A";

                CargarMaquinas(TxtProceso.Text);
                CmbMaquinas.Text = Global.ObjetoATexto(proc.Fila().Celda("maquina"), "N/A");
            }
            else
            {
                TxtProceso.Text = "";
                TxtComentarios.Text = "";

                CmbHerramentista.Items.Clear();
                CmbMaquinas.Items.Clear();

                MessageBox.Show("El proceso de fabricación no existe!", "Imposible cargar proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        public void CargarHerramentistas()
        {
            CmbHerramentista.Items.Clear();
            CmbHerramentista.Items.Add("N/A");
            Usuario.Modelo().SeleccionarDepartamento("FABRICACION").ForEach(delegate(Fila f)
            {
                CmbHerramentista.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });

        }

        public void CargarMaquinas(string proceso)
        {
            CmbMaquinas.Items.Clear();
            CmbMaquinas.Items.Add("N/A");

            MaquinaHerramientaProceso.Modelo().TodasDeProceso(proceso).ForEach(delegate(Fila f)
            {
                MaquinaHerramienta mh = new MaquinaHerramienta();
                mh.CargarDatos(Convert.ToInt32(f.Celda("maquina_herramienta")));
                CmbMaquinas.Items.Add(mh.Fila().Celda("nombre"));
            });
        }

        private void HabilitarBotonAsignar()
        {
            BtnAsignar.Enabled = (CmbHerramentista.Text != "N/A" && CmbMaquinas.Text != "N/A" );
        }

        private void NumProceso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CargarProceso(Convert.ToInt32(NumProceso.Value));
        }

        private void LblMaterial_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnAsignar_Click_1(object sender, EventArgs e)
        {
            ComentariosSupervisor = TxtComentarios.Text; ;
            Proceso = TxtProceso.Text; ;
            Herramenstista = CmbHerramentista.Text;
            MaquinaHerramienta = CmbMaquinas.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void CmbHerramentista_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarBotonAsignar();
        }

        private void CmbMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarBotonAsignar();
        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

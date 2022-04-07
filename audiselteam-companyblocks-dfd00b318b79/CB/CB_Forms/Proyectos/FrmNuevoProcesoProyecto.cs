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
    public partial class FrmNuevoProcesoProyecto : Ventana
    {
        decimal IdProyecto = 0;
        int IdProcesoSeleccionado = 0;
        DateTime InicioProyecto;
        DateTime EntregaProyecto;

        public FrmNuevoProcesoProyecto(decimal idProyecto, DateTime inicioProyecto, DateTime entregaProyecto, ProyectoProceso procesoAnterior=null)
        {
            InitializeComponent();
            IdProyecto = idProyecto;

            InicioProyecto = inicioProyecto;
            EntregaProyecto = entregaProyecto;

            FechaInicio.MinDate = inicioProyecto.Date;
            FechaInicio.MaxDate = entregaProyecto.Date;
            FechaFin.MaxDate = entregaProyecto.Date;

            if (procesoAnterior == null)
            {
                FechaInicio.Value = inicioProyecto.Date;
                FechaFin.Value = entregaProyecto.Date;
            }
            else if(procesoAnterior.TieneFilas())
            {
                DateTime fechaFinProcesoAnterior = Convert.ToDateTime(procesoAnterior.Fila().Celda("fecha_fin"));
                FechaInicio.Value = fechaFinProcesoAnterior.Date;
                FechaFin.Value = entregaProyecto.Date;
            }
            else
            {
                FechaInicio.Value = inicioProyecto.Date;
                FechaFin.Value = entregaProyecto.Date;
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            ProyectoProceso pp = new ProyectoProceso();
            pp.SeleccionarProyectoProceso(IdProyecto, IdProcesoSeleccionado);
            
            if(pp.TieneFilas())
            {
                MessageBox.Show("El proceso ya fue registrado anteriormente en este proyecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Fila proceso = new Fila();
            proceso.AgregarCelda("proyecto", IdProyecto);
            proceso.AgregarCelda("proceso", IdProcesoSeleccionado);
            proceso.AgregarCelda("fecha_inicio", FechaInicio.Value.Date);
            proceso.AgregarCelda("fecha_fin", FechaFin.Value.Date);
            pp.Insertar(proceso);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public void CargarProcesos()
        {
            CmbProceso.Items.Clear();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@bIngles", 0);
            Proceso.Modelo().SeleccionarDatos("ingles=@bIngles", parametros).ForEach(delegate(Fila f)
            {
                CmbProceso.Items.Add(Convert.ToInt32(f.Celda("id")).ToString().PadLeft(2, '0') + " - " + f.Celda("nombre"));
            });
        }

        private void FrmNuevoProcesoProyecto_Load(object sender, EventArgs e)
        {
            CargarProcesos();
        }

        public void AjustarFechas()
        {
            DateTime fechaFinProceso = FechaFin.MaxDate;

            switch(CmbIntervaloDuracion.Text)
            {
                case "DIAS NATURALES":
                    fechaFinProceso = FechaInicio.Value.AddDays((int)NumDuracion.Value - 1);
                    break;

                case "DIAS HABILES":
                    fechaFinProceso = Global.AgregarDiasHabiles(FechaInicio.Value, (int)NumDuracion.Value - 1);
                    break;

                case "SEMANAS":
                    fechaFinProceso = FechaInicio.Value.AddDays((int)NumDuracion.Value * 7);
                    break;
            }

            if(fechaFinProceso.Date <= FechaFin.MaxDate)
                FechaFin.Value = fechaFinProceso.Date;
            else
                FechaFin.Value = FechaFin.MaxDate;
        }

        private void CmbProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProceso.Text == string.Empty)
                IdProcesoSeleccionado = 0;
            else
                IdProcesoSeleccionado = Convert.ToInt32(CmbProceso.Text.Split('-')[0]);

            ValidarDatos();
        }

        private void FechaFin_ValueChanged(object sender, EventArgs e)
        {
        }

        private void FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            AjustarFechas();
        }

        private void NumDuracion_ValueChanged(object sender, EventArgs e)
        {
            AjustarFechas();
        }

        private void CmbIntervaloDuracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal duracionMaxima = 0;

            switch(CmbIntervaloDuracion.Text)
            {
                case "DIAS NATURALES":
                    duracionMaxima = Global.CalcularDiasNaturales(FechaInicio.Value, EntregaProyecto);
                    break;

                case "DIAS HABILES":
                    duracionMaxima = Global.CalcularDiasHabiles(FechaInicio.Value, EntregaProyecto);
                    break;

                case "SEMANAS":
                    duracionMaxima = Global.CalcularSemanas(FechaInicio.Value, EntregaProyecto);
                    break;
            }

            if (duracionMaxima > NumDuracion.Maximum)
                NumDuracion.Maximum = duracionMaxima;

            NumDuracion.Maximum = duracionMaxima;
            AjustarFechas();
            ValidarDatos();
        }
        
        public void ValidarDatos()
        {
            BtnRegistrar.Enabled = CmbProceso.Text != string.Empty && CmbIntervaloDuracion.Text != string.Empty;
        }

    }
}

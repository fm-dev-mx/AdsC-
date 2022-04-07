using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;
using System.Windows.Forms;

namespace CB
{

    public partial class FrmBuscadorKPIs : Form
    {
        public Proceso ProcesoSeleccionado = new Proceso();
        public IndicadorProceso IndicadorSeleccionado = new IndicadorProceso();
        protected Form Contenido = null;
        int IdProceso = 0;
        DateTime FechaInicio = new DateTime();
        DateTime FechaFin = new DateTime();

        public FrmBuscadorKPIs(int idProceso = 0)
        {
            InitializeComponent();
            if (idProceso > 0)
                IdProceso = idProceso;
        }

        private void FrmKPIs_Load(object sender, EventArgs e)
        {
            CargarProcesos();
            CmbIntervalo.SelectedIndex = 0;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CmbIndicador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIndicador.Text == string.Empty)
                return;

            MostrarIndicador();
        }

        private void CargarProcesos()
        {
            CmbProceso.Items.Clear();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@bIngles", 0);
            Proceso.Modelo().SeleccionarDatos("ingles=@bIngles", parametros).ForEach(delegate(Fila f)
            {
                CmbProceso.Items.Add(f.Celda("id").ToString().PadLeft(3, '0') + " - " + f.Celda("nombre"));
            });

            if (IdProceso > 0)
            {
                ProcesoSeleccionado.CargarDatos(IdProceso);

                if(ProcesoSeleccionado.TieneFilas())
                {
                    CmbProceso.Text = ProcesoSeleccionado.Fila().Celda("id").ToString().PadLeft(3, '0') + " - " + ProcesoSeleccionado.Fila().Celda("nombre");
                    CmbProceso.Enabled = false;
                }
            }
        }

        private void CargarIndicadores(int proceso)
        {
            CmbIndicador.Items.Clear();
            IndicadorProceso indicadores = new IndicadorProceso();
            indicadores.SeleccionarIndicadoresDelProceso(Convert.ToInt32(CmbProceso.Text.Split('-')[0].Trim())).ForEach(delegate(Fila f)
            {
                CmbIndicador.Items.Add(f.Celda("nombre"));
            });          
        }

        private void CmbProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarIndicadores(IdProceso);
        }

        private void MostrarIndicador()
        {
            if (CmbIndicador.Text == string.Empty || IdProceso == 0)
                return;

            IndicadorSeleccionado.SeleccionarNombre(Convert.ToInt32(ProcesoSeleccionado.Fila().Celda("id")), CmbIndicador.Text);

            DatosKPI datosDelIndicador = new DatosKPI(Convert.ToInt32(IndicadorSeleccionado.Fila().Celda("id")), FechaInicio, FechaFin);
            FrmVisorKPILinea kpi = new FrmVisorKPILinea(datosDelIndicador);
            MostrarContenido(kpi);
        }

        public void CalcularFechas()
        {
            switch (CmbIntervalo.Text)
            {
                case "DIA":
                    FechaInicio = DateFechaSeleccionada.Value;
                    FechaFin = FechaInicio;
                    break;

                case "SEMANA":
                    FechaInicio = Global.InicioSemana(DateFechaSeleccionada.Value);
                    FechaFin = FechaInicio.AddDays(6);
                    break;

                case "MES":
                    FechaInicio = new DateTime(DateFechaSeleccionada.Value.Year, DateFechaSeleccionada.Value.Month, 1);
                    FechaFin = FechaInicio.AddMonths(1).AddDays(-1);
                    break;

                case "AÑO":
                    FechaInicio = new DateTime(DateFechaSeleccionada.Value.Year, 1, 1);
                    FechaFin = FechaInicio.AddMonths(12).AddDays(-1);
                    break;
            }
        }

        private void CmbIntervalo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularFechas();
            MostrarIndicador();
        }

        private void DateFechaSeleccionada_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechas();
            MostrarIndicador();
        }

        public void MostrarContenido(Form contenido)
        {
            if (!(this.Contenido == null))
            {
                this.Contenido.Close();
            }

            Contenido = contenido;
            Contenido.MdiParent = this;
            Contenido.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace CB
{

    public partial class FrmVisorKPILinea : Form
    {
        decimal Meta = 0;
        decimal Alerta = 0;
        decimal Incumplimiento = 0;

        DatosKPI Datos = null;
        List<double> PuntosEjeY = new List<double>();

        public FrmVisorKPILinea(DatosKPI datos)
        {
            InitializeComponent();
            Datos = datos;

            Meta = Convert.ToDecimal(Datos.Indicador.Fila().Celda("meta"));
            Alerta = Convert.ToDecimal(Datos.Indicador.Fila().Celda("alerta"));
            Incumplimiento = Convert.ToDecimal(Datos.Indicador.Fila().Celda("incumplimiento"));
            ConfigurarLeyendasGrafica();
            MostrarEstatusActual(Datos.ValorIndicador);
        }

        public void ConfigurarLeyendasGrafica()
        {
            ChartIndicadores.Titles[0].Text = Datos.TituloGrafica();
            ChartIndicadores.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            ChartIndicadores.Series[0].LegendText = Datos.TituloSeriePrincipal();
            ChartIndicadores.ChartAreas[0].AxisX.Title = Datos.TituloEjeX();
            ChartIndicadores.ChartAreas[0].AxisY.Title = Datos.TituloEjeY();

            ChartIndicadores.Series[1].LegendText = "TENDENCIA";
            ChartIndicadores.Series[2].LegendText = "META " + Meta + " " + Datos.Indicador.Fila().Celda("unidades").ToString().Trim();
            ChartIndicadores.Series[3].LegendText = "ALERTA " + Alerta + " " + Datos.Indicador.Fila().Celda("unidades").ToString().Trim();
            ChartIndicadores.Series[4].LegendText = "INCUMPLIMIENTO " + Incumplimiento + " " + Datos.Indicador.Fila().Celda("unidades").ToString().Trim();
            ChartIndicadores.ChartAreas[0].AxisY.LabelStyle.Format = "##.##";
        }

        private void FrmVisorKPILinea_Load(object sender, EventArgs e)
        {
            ChartIndicadores.ChartAreas[0].AxisY.Interval = 0.10;
            CargarPuntosGrafica();

            if (Datos.RolResponsableProceso.Fila().Celda("rol").ToString() == Global.UsuarioActual.Fila().Celda("rol").ToString() || 
                Global.UsuarioActual.Fila().Celda("rol").ToString() == "SUPERUSER")
                BtnAcciones.Enabled = true;
            else
                BtnAcciones.Enabled = false;
        }    

        private void CargarEstadisticas(DateTime fechaInicio, DateTime fechaFin)
        {
            string categoria = string.Empty;
            string descripcion = string.Empty;
            object valor = null;
            ListaEstadisticas.Items.Clear();

            foreach (EstadisticaKPI datosEstadisticas in Datos.Estadisticas)
            {
                foreach(KeyValuePair<string, object> estadistica in datosEstadisticas.Valores)
                {
                    categoria = datosEstadisticas.Categoria;
                    descripcion = estadistica.Key;
                    valor = estadistica.Value;
                    InsertarEstadistica(categoria, descripcion, valor);
                }
            }
        }

        private void MostrarEstatusActual(decimal valorIndicador)
        {
            LblEstatus.Visible = true;

            string polaridad = Datos.Indicador.Fila().Celda("polaridad").ToString();

            if(polaridad == "POSITIVA")
            {
                if (valorIndicador <= Incumplimiento)
                {
                    LblEstatus.BackColor = Color.Crimson;
                    LblEstatus.ForeColor = Color.White;
                    LblEstatus.Text = "EN INCUMPLIMIENTO";
                }
                else if(valorIndicador > Incumplimiento && valorIndicador <= Alerta)
                {
                    LblEstatus.BackColor = Color.Gold;
                    LblEstatus.ForeColor = Color.Black;
                    LblEstatus.Text = "EN ALERTA";
                }
                else if (valorIndicador > Alerta && valorIndicador < Meta)
                {
                    LblEstatus.BackColor = Color.LightGreen;
                    LblEstatus.ForeColor = Color.Black;
                    LblEstatus.Text = "META CERCANA";
                }
                else if (valorIndicador >= Meta)
                {
                    LblEstatus.BackColor = Color.ForestGreen;
                    LblEstatus.ForeColor = Color.White;
                    LblEstatus.Text = "META ALCANZADA";
                }
            }
            else if (polaridad == "NEGATIVA")
            {
                if (valorIndicador >= Incumplimiento)
                {
                    LblEstatus.BackColor = Color.Crimson;
                    LblEstatus.ForeColor = Color.White;
                    LblEstatus.Text = "EN INCUMPLIMIENTO";
                }
                else if (valorIndicador < Incumplimiento && valorIndicador >= Alerta)
                {
                    LblEstatus.BackColor = Color.Gold;
                    LblEstatus.ForeColor = Color.Black;
                    LblEstatus.Text = "EN ALERTA";
                }
                else if (valorIndicador < Alerta && valorIndicador > Meta)
                {
                    LblEstatus.BackColor = Color.LightGreen;
                    LblEstatus.ForeColor = Color.Black;
                    LblEstatus.Text = "META CERCANA";
                }
                else if (valorIndicador <= Meta)
                {
                    LblEstatus.BackColor = Color.ForestGreen;
                    LblEstatus.ForeColor = Color.White;
                    LblEstatus.Text = "META ALCANZADA";
                }
            }
        }

        private void AgregarLineaTendencia()
        {
            if (ChartIndicadores.Series[0].Points.Count <= 1)
                return;

            string typeRegression = "Linear";
            string forecasting = "1";
            string error = "false";
            string forecastingError = "false";
            string parameters = typeRegression + ',' + forecasting + ',' + error + ',' + forecastingError;

            ChartIndicadores.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, parameters, ChartIndicadores.Series[0], ChartIndicadores.Series[1]);
        }

        private void AjustarEscalaEjes()
        {
            //if (PuntosEjeY.Count > 0)
            //{
            //    if (PuntosEjeY.Max() < (double)Meta)
            //        ChartIndicadores.ChartAreas[0].AxisY.Maximum = ((double)Meta + 0.10);
            //    else
            //        ChartIndicadores.ChartAreas[0].AxisY.Maximum = (PuntosEjeY.Max() + 0.10);

            //    ChartIndicadores.ChartAreas[0].AxisY.Minimum = (PuntosEjeY.Min() - 0.10);
            //    if (PuntosEjeY.Count > 1)
            //        ChartIndicadores.ChartAreas[0].AxisX.Maximum = PuntosEjeY.Count;
            //    else
            //        ChartIndicadores.ChartAreas[0].AxisX.Maximum = Double.NaN;
            //}

            double max = 0; 
            double min = 0;
            string polaridad = Datos.Indicador.Fila().Celda("polaridad").ToString();

            if(polaridad == "POSITIVA")
            {
                max = (double)Meta + ((double)Meta * (double)NumFactorEscala.Value);
                min = (double)Incumplimiento - ((double)Incumplimiento * (double)NumFactorEscala.Value);

                ChartIndicadores.ChartAreas[0].AxisY.Maximum = max;
                ChartIndicadores.ChartAreas[0].AxisY.Minimum = min;
            }
            else if(polaridad == "NEGATIVA")
            {
                max = (double)Incumplimiento + ((double)Incumplimiento * (double)NumFactorEscala.Value);
                min = (double)Meta - ((double)Meta * (double)NumFactorEscala.Value);

                ChartIndicadores.ChartAreas[0].AxisY.Maximum = max;
                ChartIndicadores.ChartAreas[0].AxisY.Minimum = min;
            }
            ChartIndicadores.ChartAreas[0].AxisY.Interval = (max - min) / 10;

            if (PuntosEjeY.Count > 1)
                ChartIndicadores.ChartAreas[0].AxisX.Maximum = PuntosEjeY.Count;
            else
                ChartIndicadores.ChartAreas[0].AxisX.Maximum = Double.NaN;

            ChartIndicadores.ChartAreas[0].RecalculateAxesScale();
        }

        private void CargarPuntosGrafica()
        {
            foreach (string xy in Datos.PuntosGrafica)
            {
                string[] coordenada = xy.Split('|');

                int punto = ChartIndicadores.Series[0].Points.AddXY(coordenada[0], coordenada[1]);
                ChartIndicadores.Series[0].Points[punto].Label = Convert.ToDecimal(coordenada[1]).ToString("F2");

                //meta
                ChartIndicadores.Series[2].Points.AddXY(coordenada[0], Meta);
                //alerta
                ChartIndicadores.Series[3].Points.AddXY(coordenada[0], Alerta);
                //incumplimiento
                ChartIndicadores.Series[4].Points.AddXY(coordenada[0], Incumplimiento);
                PuntosEjeY.Add(Convert.ToDouble(coordenada[1]));

                if (Convert.ToDecimal(coordenada[1]) > Meta)
                {
                    ChartIndicadores.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                    ChartIndicadores.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 25;
                }
            }

            AgregarLineaTendencia();
            AjustarEscalaEjes();
            CargarEstadisticas(Datos.FechaInicio, Datos.FechaFin);
        }

        private void InsertarEstadistica(string categoria, string descripcion, object valor)
        {
            
            ListViewItem itemEstadistica = new ListViewItem(descripcion);
            ListViewGroup gupoCategoria = ListaEstadisticas.Groups[categoria];

            if (gupoCategoria == null)
            {
                ListViewGroup grupo = new ListViewGroup();
                grupo.Name = categoria;
                grupo.Header = categoria;
                grupo.Tag = categoria;
                ListaEstadisticas.Groups.Add(grupo);
                itemEstadistica.Group = grupo;
            }
            else
                itemEstadistica.Group = ListaEstadisticas.Groups[categoria];

            itemEstadistica.SubItems.Add(valor.ToString());
            ListaEstadisticas.Items.Add(itemEstadistica);  
        }

        private void BtnAcciones_Click(object sender, EventArgs e)
        {
            int idProceso = Convert.ToInt32(Datos.ProcesoDelIndicador.Fila().Celda("id"));

            FrmAccionesKPIs acciones = new FrmAccionesKPIs(idProceso, Datos.Indicador.Fila().Celda("nombre").ToString());
            acciones.Show();
        }

        private void NumFactorEscala_ValueChanged(object sender, EventArgs e)
        {
            AjustarEscalaEjes();
        }

        private void BtnEscalaAuto_Click(object sender, EventArgs e)
        {
            BtnEscalaAuto.Enabled = false;
            while(  (ChartIndicadores.ChartAreas[0].AxisX.Maximum < PuntosEjeY.Max() ||
                     ChartIndicadores.ChartAreas[0].AxisX.Minimum > PuntosEjeY.Min() ) &&
                     NumFactorEscala.Value < (decimal)600
                 )
            {
                NumFactorEscala.Value = NumFactorEscala.Value + (decimal)2;
                Application.DoEvents();
            }
            BtnEscalaAuto.Enabled = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Forms;
using CB_Base.Classes;

namespace CB_Base.CB_Forms.Fabricacion
{
    public partial class FrmEstatusPlanos : Form
    {
        decimal Proyecto = 0;

        public FrmEstatusPlanos(decimal proyecto)
        {
            Proyecto = proyecto;
            InitializeComponent();
        }

        private void FrmEstatusPlanos_Load(object sender, EventArgs e)
        {
            PlanoProyecto proy = new PlanoProyecto();

            audiselTituloForm1.Text += " " + Proyecto.ToString().PadLeft(2, '0');
            CargarGrafica(proy.EstatusPlanosPorProyecto(Proyecto));
            CargarMaterial();
        }

        private void CargarMaterial()
        {
            PlanoProyecto proyecto = new PlanoProyecto();
            proyecto.EstatusPlanosProyectosPorModulos(Proyecto).ForEach(delegate (Fila f)
            {
                DgvMaterial.Rows.Add
                (
                    f.Celda("subensamble").ToString().PadLeft(2,'0'),
                    f.Celda("nombre"),
                    f.Celda("descripcion"),
                    f.Celda("planos_entregados") + "/" + f.Celda("planosTotales"),
                    f.Celda("planos_fabricados") + "/" + f.Celda("planosTotales")
                );
            });

            DgvMaterial.ClearSelection();
        }

        private void CargarGrafica(List<Fila> datosGrafica)
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0:f2}%", chartPoint.Y, chartPoint.Participation);
            pieChart1.Series = new SeriesCollection();

            foreach (Fila f in datosGrafica)
            {
                pieChart1.Series.Add(new PieSeries
                {
                    Title = f.Celda("estatus").ToString() + " " + Convert.ToDecimal(f.Celda("promedio")).ToString("f2") + "%" + " [" + f.Celda("totales") + " PLANOS] ",
                    Values = new ChartValues<decimal> { Convert.ToDecimal(f.Celda("promedio")) },
                    DataLabels = true,
                    LabelPosition = PieLabelPosition.OutsideSlice,
                    LabelPoint = labelPoint,
                    Foreground = System.Windows.Media.Brushes.Black
                });
            }

            pieChart1.LegendLocation = LegendLocation.Top;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmEstatusComprasProyecto : Form
    {
        decimal Proyecto = 0;
        public FrmEstatusComprasProyecto(decimal proyecto)
        {
            InitializeComponent();
            Proyecto = proyecto;
        }

        private void FrmEstatusComprasProyecto_Load(object sender, EventArgs e)
        {
            MaterialProyecto material = new MaterialProyecto();

            audiselTituloForm1.Text += " " + Proyecto.ToString().PadLeft(2, '0');
            CargarGrafica(material.CalcularEstatusCompraPorProyecto(Proyecto));
            CargarMaterial();
        }

        private void CargarMaterial()
        {
            List<string> categoria = new List<string>();
            categoria.Add("PROCESO DE FABRICACION");
            categoria.Add("MATERIAL DE FABRICACION");

            MaterialProyecto material = new MaterialProyecto();
            material.MaterialDeCompraPorProyectoSinCategorias(Proyecto, categoria).ForEach(delegate(Fila f)
            {
                string formatoCantidad = string.Empty;

                switch (f.Celda("tipo_venta").ToString())
                {
                    case "POR PIEZA":
                        formatoCantidad = f.Celda("total") + " PIEZA(S)";
                        break;
                    case "POR PAQUETE":
                        formatoCantidad = f.Celda("total") + " PAQUETES CON " + f.Celda("piezas_paquete") + "PIEZA(S) C/U";
                        break;
                }

                string strEta = string.Empty;
                string modulo = string.Empty;
                object eta = f.Celda("eta");
                object subensamble = f.Celda("subensamble");

                if (eta != null)
                    strEta = Global.FechaATexto(f.Celda("eta"), false);
                else
                    strEta = "";

                if (subensamble != null)
                    modulo = subensamble.ToString().PadLeft(2, '0');
                else
                    modulo = "";



                DgvMaterial.Rows.Add
                (
                    f.Celda("id"),
                    f.Celda("numero_parte"),
                    f.Celda("fabricante"),
                    f.Celda("descripcion"),
                    modulo,
                    formatoCantidad,
                    f.Celda("tiempo_entrega") + " DIAS",
                    f.Celda("estatus_seleccion"),
                    f.Celda("estatus_autorizacion"),
                    f.Celda("estatus_compra"),
                    f.Celda("estatus_financiero"),
                    strEta                 
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
                    Title = f.Celda("estatus_compra").ToString() + " " + Convert.ToDecimal(f.Celda("promedio")).ToString("f2") + "%" + " [" + f.Celda("totales") + " REQUISICIONES] ",
                    Values = new ChartValues<decimal> { Convert.ToDecimal(f.Celda("promedio")) },
                    DataLabels = true,
                    LabelPosition = PieLabelPosition.OutsideSlice,
                    LabelPoint = labelPoint,
                    Foreground = System.Windows.Media.Brushes.Black
                    //ToolTip = LiveCharts.TooltipSelectionMode.OnlySender,
                    //PushOut = 15
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

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
using System.Windows.Forms.DataVisualization.Charting;

namespace CB
{
    public partial class FrmEstadisticasMaterial : Ventana
    {
        CatalogoMaterial Material = new CatalogoMaterial();

        public FrmEstadisticasMaterial(string numeroParte)
        {
            InitializeComponent();
            Material.SeleccionarNumeroDeParte(numeroParte);

            if(!Material.TieneFilas())
            {
                MessageBox.Show("El material no fue encontrado en el catálogo.", "Material no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
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

        private void FrmEstadisticasMaterial_Load(object sender, EventArgs e)
        {
            TxtNumeroParte.Text = Material.Fila().Celda("numero_parte").ToString();
            TxtFabricante.Text = Material.Fila().Celda("fabricante").ToString();
            TxtDescripcion.Text = Material.Fila().Celda("descripcion").ToString();
            CargarHistorialCompra(Convert.ToInt32(NumYear.Value));
        }


        public void CargarHistorialCompra(int year)
        {
            MaterialProyecto buscador = new MaterialProyecto();

            string sql = "SELECT piezas_paquete, month(fecha_compra) as mes, SUM(total) AS total_ordenado FROM audisel.material_proyecto WHERE numero_parte=@numero_parte AND YEAR(fecha_compra)=@fecha_creacion group by month(fecha_compra);";

            buscador.ConstruirQuery(sql);
            buscador.AgregarParametro("@numero_parte", Material.Fila().Celda("numero_parte"));
            buscador.AgregarParametro("@fecha_creacion", year);
            buscador.EjecutarQuery();

            
            Axis XA = ChartCompras.ChartAreas[0].AxisX;
            Axis YA = ChartCompras.ChartAreas[0].AxisY;
            Series S1 = ChartCompras.Series[0];
            S1.Points.Clear();

            List<DateTime> dates = new List<DateTime>();
            DateTime dt = DateTime.Now;
            for (int i = 1; i <= 12; i++)
                dates.Add(new DateTime(dt.Year, i, 1));

            foreach (DateTime d in dates)
                S1.Points.AddXY(d, 0);

            // show the year in the legend:
            S1.LegendText = "Year " + dt.Year;
            // move to the bottom center:
            ChartCompras.Legends[0].Docking = Docking.Bottom;
            ChartCompras.Legends[0].Alignment = StringAlignment.Center;

            S1.XValueType = ChartValueType.Date;  // set the type
            XA.MajorGrid.Enabled = false;         // no gridlines
            XA.LabelStyle.Format = "MMM";         // show months as names

            XA.IntervalType = DateTimeIntervalType.Months;  // show axis labels.. 
            XA.Interval = 1;                                // ..every 1 months

            if(Material.Fila().Celda("tipo_venta").ToString() == "POR PIEZA")
                YA.LabelStyle.Format = "### Pieza(s)";
            else
                YA.LabelStyle.Format = "### Paq.";
            
            buscador.LeerFilas().ForEach(delegate(Fila f)
            {
                S1.Points.ElementAt(Convert.ToInt32(f.Celda("mes"))-1).SetValueY(Convert.ToInt32(f.Celda("total_ordenado")));
            });

            ChartCompras.ChartAreas[0].RecalculateAxesScale();
        }

        private void NumYear_ValueChanged(object sender, EventArgs e)
        {
            CargarHistorialCompra(Convert.ToInt32(NumYear.Value));
        }
    }
}

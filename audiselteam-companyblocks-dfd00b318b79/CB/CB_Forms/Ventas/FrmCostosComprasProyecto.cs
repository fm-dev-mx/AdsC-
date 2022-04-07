using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmCostosComprasProyecto : Form
    {
        BindingSource ComprasTipoSource = new BindingSource();        
        Proyecto ProyectoCargado = new Proyecto();
        decimal IdProyecto = 0;
        decimal TipoCambio = 0;

        public FrmCostosComprasProyecto(decimal idProyecto)
        {
            InitializeComponent();            
            IdProyecto = idProyecto;            
        }

        private void FrmCostosComprasProyecto_Load(object sender, EventArgs e)
        {                       
            TipoCambio = CargarTipoCambio();
            LblTipoCambio.Text = "Tipo de cambio: $" + TipoCambio.ToString("F2") + " pesos por dólar";
            ProyectoCargado.CargarDatos(IdProyecto);
            LblTitulo.Text = "COSTOS DE COMPRAS DEL PROYECTO " + IdProyecto.ToString("F2");

            CargarTipoCompra();

            CmbComprasTipos.SelectedIndex = 0;
            CargarCostos(CmbComprasTipos.Text, CmbCategoria.Text, Convert.ToInt32(CmbModulo.SelectedValue));
        }

        private void FrmCostosComprasProyecto_Shown(object sender, EventArgs e)
        {
            
        }

        private void CargarTipoCompra()
        {
            ComprasTipoSource.Add(new 
            {
                Text = "TODOS",
                Value = Convert.ToInt32("0")
            });

            ComprasTipos ccomprasTipos = new ComprasTipos();
            ccomprasTipos.SeleccionarTodo().ForEach(delegate(Fila f)
            {
                ComprasTipoSource.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = f.Celda<int>("id")
                });
            });

            CmbComprasTipos.DataSource = ComprasTipoSource;
            CmbComprasTipos.DisplayMember = "Text";
            CmbComprasTipos.ValueMember = "Value";
        }

        private void CargarCategorias()
        {
            BindingSource categoriaSource = new BindingSource();
            categoriaSource.Add
            (
                new
                {
                    Value = 0,
                    Text = "TODOS"
                }
            );

            CategoriaMaterial categoria = new CategoriaMaterial();
            categoria.SeleccionCategoriasDeTipoCompra(Convert.ToInt32(CmbComprasTipos.SelectedValue)).ForEach(delegate(Fila f)
            {
                categoriaSource.Add(new
                {
                    Value = f.Celda<int>("id"),
                    Text = f.Celda("categoria").ToString()
                });
            });

            CmbCategoria.DataSource = categoriaSource;
            CmbCategoria.DisplayMember = "Text";
            CmbCategoria.ValueMember = "Value";
        }

        private void CargarModulos()
        {
            BindingSource moduloSource = new BindingSource();
            moduloSource.Add(new
            {
                Value = -1,
                Text = "TODOS"
            });

            moduloSource.Add(new
            {
                Value = -2,
                Text = "GENERAL"
            });

            int ban = 0;
            CatalogoMaterial.Modelo().ModulosCostos(IdProyecto).ForEach(delegate (Fila modulo)
            {
                if (modulo.Celda("subensamble").ToString() == "0")
                    ban++;
            });

            if (ban <= 0)
            {
                moduloSource.Add(new
                {
                    Value = 0,
                    Text = "00 - COMPRAS GENERALES"
                });        }                

            CatalogoMaterial.Modelo().ModulosCostos(IdProyecto).ForEach(delegate (Fila modulo)
            {
                moduloSource.Add(new
                {
                    Value = modulo.Celda<int>("subensamble"),
                    Text = modulo.Celda("subensamble").ToString().PadLeft(2, '0') + " - " + modulo.Celda("nombre").ToString()
                });
            });            

            CmbModulo.DataSource = moduloSource;
            CmbModulo.DisplayMember = "Text";
            CmbModulo.ValueMember = "Value";           
        }

        private decimal CargarTipoCambio()
        {
            return Convert.ToDecimal(Global.ObtenerTipoCambio("USD"));
        }


        private void CargarCostos(string tipoCompra = "TODOS", string categoria = "TODOS", int modulo = -1)
        {            
            DgvCostosCompras.Rows.Clear();

            decimal valor = 0;
            decimal valorEnDolares = 0;
            decimal totalEnDolares = 0;
            decimal sumaGastada = 0;

            Dictionary<string, decimal> datosGrafica = new Dictionary<string, decimal>();
            Dictionary<string, decimal> costos = new Dictionary<string, decimal>();

            Proyecto proyecto = new Proyecto();

            //USD
            proyecto.SeleccionarCostosGeneral(IdProyecto, tipoCompra, categoria, modulo, "USD").ForEach(delegate (Fila f)
            {
                costos.Add(f.Celda("nombre").ToString(), Convert.ToDecimal(f.Celda("suma_gastada")));
            });

            //MXN
            proyecto.SeleccionarCostosGeneral(IdProyecto, tipoCompra, categoria, modulo, "MXN").ForEach(delegate (Fila f)
            {
                if (costos.ContainsKey(f.Celda("nombre").ToString()))
                {
                    costos.TryGetValue(f.Celda("nombre").ToString(), out valor);
                    valorEnDolares = Convert.ToDecimal(f.Celda("suma_gastada")) / TipoCambio;
                    totalEnDolares = valor + valorEnDolares;
                    costos[f.Celda("nombre").ToString()] = totalEnDolares;
                }
                else
                {
                    valorEnDolares = Convert.ToDecimal(f.Celda("suma_gastada")) / TipoCambio;
                    costos.Add(f.Celda("nombre").ToString(), valorEnDolares);
                }
            });

            //se ordena diccionario para cargarlo en el grid en orden descendente segun la suma gastada            
            var sortedCostos = from entry in costos orderby entry.Value descending select entry;

            foreach (var key in sortedCostos)
            {
                DgvCostosCompras.Rows.Add(key.Key.ToString(), key.Value.ToString("C", CultureInfo.CurrentCulture));
                sumaGastada += key.Value;
                datosGrafica.Add(key.Key.ToString(), Math.Round(Convert.ToDecimal(key.Value)));
            }

            DgvCostosCompras.Rows.Add("SUBTOTAL", sumaGastada.ToString("C", CultureInfo.CurrentCulture));           

            CargarGrafica(datosGrafica);
        }        
        

        private void DgvCostosCompras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string subtotal = DgvCostosCompras.Rows[e.RowIndex].Cells[0].Value.ToString();

            if(subtotal == "SUBTOTAL")
            {
                DataGridViewRow row = DgvCostosCompras.Rows[e.RowIndex];
                row.Cells["tipo_compra"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                row.Cells["tipo_compra"].Style.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }

        private void CargarGrafica(Dictionary<string, decimal> datosGrafica)
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{1:P}", chartPoint.Y, chartPoint.Participation); //("{0} ({1:P})"

            var sortedDatosGrafica = from entry in datosGrafica orderby entry.Value descending select entry;
            bool banPrimero = true;
            pieChart1.Series = new SeriesCollection();

            decimal total = 0;

            foreach (KeyValuePair<string, decimal> datos in sortedDatosGrafica)
            {
                total += datos.Value;
            }

            foreach (KeyValuePair<string, decimal> datos in sortedDatosGrafica)
            {
                if (banPrimero)
                {
                    pieChart1.Series.Add(new PieSeries
                    {
                        Title = datos.Key + " " + ((datos.Value  * 100)/total).ToString("f2") + "% [" +datos.Value.ToString("C2") +"]",
                        Values = new ChartValues<decimal> { datos.Value },
                        DataLabels = true,
                        LabelPosition = PieLabelPosition.OutsideSlice,
                        LabelPoint = labelPoint,
                        PushOut = 15,
                        Foreground = System.Windows.Media.Brushes.Black
                    });
                    banPrimero = false;
                }
                else
                {
                    pieChart1.Series.Add(new PieSeries
                    {
                        Title = datos.Key + " " + ((datos.Value * 100) / total).ToString("f2") + "% [" + datos.Value.ToString("C2") + "]",
                        Values = new ChartValues<decimal> { datos.Value },
                        DataLabels = true,
                        LabelPosition = PieLabelPosition.OutsideSlice,
                        LabelPoint = labelPoint,
                        Foreground = System.Windows.Media.Brushes.Black
                    });
                }
            }

            pieChart1.LegendLocation = LegendLocation.Top;
        }

        private void LblTipoCambio_Click(object sender, EventArgs e)
        {

        }

        private void CmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbModulo.SelectedIndex != 0)
            {
                CargarCostos(CmbComprasTipos.Text, CmbCategoria.Text, Convert.ToInt32(CmbModulo.SelectedValue));
            }
            else
            {
                CargarCostos(CmbComprasTipos.Text, CmbCategoria.Text, -1);
            }
        }

        private void CmbComprasTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbComprasTipos.SelectedIndex != 0)
            {                
                CargarCategorias();
                CmbCategoria.Enabled = true;
            }
            else
            {
                CmbCategoria.Enabled = false;
                CmbModulo.Enabled = false;
            }

            CargarCostos(CmbComprasTipos.Text, CmbCategoria.Text, Convert.ToInt32(CmbModulo.SelectedValue));
        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCategoria.SelectedIndex != 0)
            {
                CargarModulos();
                CmbModulo.Enabled = true;
            }
            else
            {
                CmbModulo.Enabled = false;
            }

            CargarCostos(CmbComprasTipos.Text, CmbCategoria.Text, Convert.ToInt32(CmbModulo.SelectedValue));
        }

        private void DgvCostosCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

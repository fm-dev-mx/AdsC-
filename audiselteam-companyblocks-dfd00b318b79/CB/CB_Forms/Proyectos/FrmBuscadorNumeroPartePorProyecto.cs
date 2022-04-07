using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmBuscadorNumeroPartePorProyecto : Form
    {
        public FrmBuscadorNumeroPartePorProyecto()
        {
            InitializeComponent();
            this.DgvMaterial.DoubleBuffered(true);
        }

        private void FrmBuscadorNumeroPartePorProyecto_Load(object sender, EventArgs e)
        {
            

        }

        private void CargarTabla()
        {
            DgvMaterial.Rows.Clear();
            string numeroParte = TxtNumeroParte.Text;
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@numeroParte", numeroParte);
            parametros.Add("@estatusSeleccion", "DEFINIDO");

            MaterialProyecto material = new MaterialProyecto();
            material.BuscarMaterialPorNumeroParte(numeroParte);

            if (material.TieneFilas())
            {
                material.Filas().ForEach(delegate (Fila mat)
                {
                    string strTotal = "";

                    if (mat.Celda("tipo_venta").ToString() == "POR PIEZA")
                        strTotal = mat.Celda("total").ToString() + " pieza(s)";
                    else
                        strTotal = mat.Celda("total").ToString() + " paquete(s) con " + mat.Celda("piezas_paquete").ToString() + " piezas c/u";

                    int accesorioPara = Convert.ToInt32(mat.Celda("accesorio_para"));
                    string strAccesorioPara = "";
                    if (accesorioPara > 0)
                        strAccesorioPara = "Req. #" + accesorioPara;
                    else
                        strAccesorioPara = "N/A";

                    Object fc = mat.Celda("fecha_creacion");
                    string fechaCreacion = "N/A";

                    if (fc != null)
                        fechaCreacion = Convert.ToDateTime(fc).ToString("MMM dd, yyyy hh:mm:ss tt");

                    Object te = mat.Celda("tiempo_entrega_estimado");
                    int iTiempoEstimadoEntrega = 0;
                    string tiempoEstimadoEntrega = "N/A";

                    Object obSubensamble = mat.Celda("subensamble");
                    string subensamble = "";
                    if (obSubensamble != null)
                        subensamble = Convert.ToInt32(mat.Celda("subensamble")).ToString("D2");

                    if (te != null)
                    {
                        iTiempoEstimadoEntrega = Convert.ToInt32(te);

                        if (iTiempoEstimadoEntrega > 0)
                            tiempoEstimadoEntrega = te.ToString();
                    }

                    string tiempoEntregaReal = "N/A";


                    if (Convert.ToInt32(mat.Celda("rfq_concepto")) > 0)
                    {
                        RfqConcepto materialConcepto = new RfqConcepto();
                        materialConcepto.CargarDatos(Convert.ToInt32(mat.Celda("rfq_concepto")));

                        if (materialConcepto.TieneFilas())
                        {
                            if (materialConcepto.Fila().Celda<int>("tiempo_entrega") > 0)
                                tiempoEntregaReal = materialConcepto.Fila().Celda("tiempo_entrega").ToString();
                        }
                    }

                    string precioSumaFinal = "SIN CAPTURAR";

                    object objPrecioSumaFinal = mat.Celda("precio_suma_final");
                    object objPrecioMoneda = mat.Celda("precio_moneda");

                    if (objPrecioSumaFinal != null)
                    {
                        if (Convert.ToDecimal(objPrecioSumaFinal) > 0)
                        {
                            precioSumaFinal = Convert.ToDouble(objPrecioSumaFinal).ToString("C2") + " " + objPrecioMoneda.ToString();
                        }
                    }

                    Object eta = mat.Celda("eta");
                    string fechaEstimadaEntrega = "N/A";

                    if (eta != null)
                        fechaEstimadaEntrega = Convert.ToDateTime(eta).ToString("MMM dd, yyyy");

                DgvMaterial.Rows.Add
                (
                     Convert.ToDecimal(mat.Celda("proyecto")).ToString("F2"),
                     mat.Celda("id"),
                     fechaCreacion,
                     mat.Celda("requisitor"),
                     mat.Celda("categoria_real"),
                     mat.Celda("numero_parte"),
                     mat.Celda("fabricante"),
                     mat.Celda("descripcion"),
                     mat.Celda("piezas_requeridas"),
                     strTotal,
                     precioSumaFinal,
                     strAccesorioPara,
                     mat.Celda("estatus_seleccion"),
                     mat.Celda("estatus_compra"),
                     mat.Celda("estatus_autorizacion"),
                     mat.Celda("estatus_financiero"),
                     mat.Celda("estatus_almacen"),
                     tiempoEstimadoEntrega,
                     tiempoEntregaReal,
                     fechaEstimadaEntrega,
                     subensamble,
                     mat.Celda("accesorio_para")
                    );

                    string estatusCompra = mat.Celda("estatus_compra").ToString();
                    DataGridViewCell celdaCompra = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_compra"];

                    if (estatusCompra.Contains("CANCELADO") || estatusCompra.Contains("RECHAZADA") || estatusCompra.Contains("DETENIDA") || estatusCompra.Contains("DESCARTADO"))
                    {
                        celdaCompra.Style.BackColor = Color.Coral;
                    }
                    else if (estatusCompra.Contains("ENTREGADO"))
                    {
                        celdaCompra.Style.BackColor = Color.LightGreen;
                    }
                });
            }
            else
            {
                MessageBox.Show
                (
                    "No se encontró el material solicitado en algún proyecto",
                    "Material no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void TxtNumeroParte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarTabla();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvMaterial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmVerCotizacionesMaterial : Ventana
    {
        string numero_parte;

        public FrmVerCotizacionesMaterial(string numero_parte)
        {
            InitializeComponent();
            this.numero_parte = numero_parte;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmVerCotizacionesMaterial_Load(object sender, EventArgs e)
        {
            LblNumeroParte.Text = numero_parte;
            CargarCotizaciones(numero_parte);
        }

        void CargarCotizaciones(string numero_parte)
        {
            DgvCotizaciones.Rows.Clear();

            RfqConcepto.Modelo().SeleccionarNumeroDeParte(numero_parte).ForEach(delegate(Fila partida)
            {
                decimal precio = Convert.ToDecimal(partida.Celda("precio_unitario"));
                string strPrecio = "";
                string strUnidades = "?";

                int tiempo_entrega = Convert.ToInt32(partida.Celda("tiempo_entrega"));
                string strTiempo = "";


                if (precio <= 0)
                    strPrecio = "?";
                else
                    strPrecio = String.Format( "{0:C}", precio) + " " + partida.Celda("moneda").ToString();

                if (tiempo_entrega <= 0)
                    strTiempo = "?";
                else
                    strTiempo = tiempo_entrega.ToString() + " día(s)";

                List<Fila> mat = new List<Fila>();
                Dictionary<string, object> parametros = new Dictionary<string,object>();
                parametros.Add("@numero_parte", numero_parte);
                mat = MaterialProyecto.Modelo().SeleccionarDatos("numero_parte=@numero_parte", parametros);

                if(mat.Count > 0)
                {
                    strUnidades = mat[0].Celda("tipo_venta").ToString();
                }

                DgvCotizaciones.Rows.Add( partida.Celda("rfq"), partida.Celda("nombre_proveedor"), strPrecio, strTiempo, partida.Celda("cantidad_disponible").ToString(), strUnidades, partida.Celda("estatus") );
            });
        }

        private void DgvCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idRfq = Convert.ToInt32(DgvCotizaciones.Rows[e.RowIndex].Cells[0].Value);
            string estatus = DgvCotizaciones.Rows[e.RowIndex].Cells[6].Value.ToString();

            if (estatus != "ENVIADO")
                return;

            ArchivoRfq rfqPdf = new ArchivoRfq();
            rfqPdf.SeleccionarRfq(idRfq);

            if (rfqPdf.TieneFilas())
            {
                FrmVisorPDF visor = new FrmVisorPDF((byte[])rfqPdf.Fila().Celda("archivo"), "AUD-RFQ-" + idRfq.ToString());
                visor.ShowDialog();
            }
            else
            {
                MessageBox.Show("El archivo PDF no fue encontrado");
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}

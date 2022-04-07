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
    public partial class FrmCapturarCotizacionMaterial : Form
    {
        public Decimal PrecioUnitario = 0;
        public Decimal TiempoEntrega = 0;
        public string Moneda = "";
        public int CantidadDisponible = 0;
        public RfqConcepto Concepto = new RfqConcepto();        

        public FrmCapturarCotizacionMaterial(int IdConcepto)
        {
            InitializeComponent();
            Concepto.CargarDatos(IdConcepto);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnCapturar_Click(object sender, EventArgs e)
        {
            PrecioUnitario = NumPrecioUnitario.Value;

            if (CmbTiempo.Text == "DIAS")
                TiempoEntrega = NumTiempoEntrega.Value;
            else if(CmbTiempo.Text == "SEMANAS")
                TiempoEntrega = NumTiempoEntrega.Value * 7;

            Moneda = CmbMoneda.Text;
            CantidadDisponible = Convert.ToInt32(NumCantidadDisponible.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;            
        }

        private void FrmCapturarCotizacionMaterial_Load(object sender, EventArgs e)
        {
            CargarCotizacion();
        }

        private void CargarCotizacion()
        {
            LblNumeroDeParte.Text = "NUMERO DE PARTE: " + Concepto.Fila().Celda("numero_parte").ToString();
            NumPrecioUnitario.Value = Convert.ToDecimal(Concepto.Fila().Celda("precio_unitario"));
            NumCorroborarPrecio.Value = Convert.ToDecimal(Concepto.Fila().Celda("precio_unitario"));
            NumTiempoEntrega.Value = Convert.ToInt32(Concepto.Fila().Celda("tiempo_entrega"));
            CmbMoneda.Text = Concepto.Fila().Celda("moneda").ToString();
            NumCantidadDisponible.Value = Convert.ToInt32(Concepto.Fila().Celda("cantidad_disponible"));
            CmbTiempo.Text = "DIAS";

            switch (Concepto.Fila().Celda("tipo_venta").ToString())
            {
                case "POR PAQUETE":
                    LblTipoVenta.Text = "PAQUETES";
                    break;
                case "POR PIEZA":
                    LblTipoVenta.Text = "PIEZAS";
                    break;
            }

            MaterialProyecto mat = new MaterialProyecto();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@numero_parte", LblNumeroDeParte.Text.Split(':')[1]);
            mat.SeleccionarDatos("numero_parte=@numero_parte", parametros);

            if (mat.TieneFilas())
            {
                string tipo_venta = mat.Fila().Celda("tipo_venta").ToString();
                string piezas_paquete = mat.Fila().Celda("piezas_paquete").ToString();

                if (tipo_venta == "POR PIEZA") LblTipoVenta.Text = "PIEZAS";
                else if (tipo_venta == "POR PAQUETE") LblTipoVenta.Text = "PAQ. C/" + piezas_paquete.ToString() + "PZAS.";
            }
        }

        private void NumPrecioUnitario_ValueChanged(object sender, EventArgs e)
        {
            BtnCapturar.Enabled = NumPrecioUnitario.Value > 0 && NumTiempoEntrega.Value > 0 && (Convert.ToDecimal(NumPrecioUnitario.Value) == Convert.ToDecimal(NumCorroborarPrecio.Value)) && CmbMoneda.Text != "";
        }

        private void NumTiempoEntrega_ValueChanged(object sender, EventArgs e)
        {
            BtnCapturar.Enabled = NumPrecioUnitario.Value > 0 && NumTiempoEntrega.Value > 0 && (Convert.ToDecimal(NumPrecioUnitario.Value) == Convert.ToDecimal(NumCorroborarPrecio.Value)) && CmbMoneda.Text != ""; 
        }

        private void NumCorroborarPrecio_ValueChanged(object sender, EventArgs e)
        {
            BtnCapturar.Enabled = NumPrecioUnitario.Value > 0 && NumTiempoEntrega.Value > 0 && (Convert.ToDecimal(NumPrecioUnitario.Value) == Convert.ToDecimal(NumCorroborarPrecio.Value)) && CmbMoneda.Text != "";
        }

        private void BtnResetear_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("La información de cotización se perderá de forma permanente, ¿Está seguro de continuar?", "Limpiar cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(resul == System.Windows.Forms.DialogResult.Yes)
            {
                PrecioUnitario = 0;
                TiempoEntrega = 0;
                Moneda = "";
                CantidadDisponible = 0;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void CmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnCapturar.Enabled = NumPrecioUnitario.Value > 0 && NumTiempoEntrega.Value > 0 && (Convert.ToDecimal(NumPrecioUnitario.Value) == Convert.ToDecimal(NumCorroborarPrecio.Value)) && CmbMoneda.Text != "";
        }

        private void NumCantidadDisponible_ValueChanged(object sender, EventArgs e)
        {
            BtnCapturar.Enabled = NumPrecioUnitario.Value > 0 && NumTiempoEntrega.Value > 0 && (Convert.ToDecimal(NumPrecioUnitario.Value) == Convert.ToDecimal(NumCorroborarPrecio.Value)) && CmbMoneda.Text != "";
        }
    }
}

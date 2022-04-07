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
    public partial class FrmVincularRequisicionesRfq : Form
    {
        public FrmVincularRequisicionesRfq()
        {
            InitializeComponent();
        }

        static public FrmVincularRequisicionesRfq Modelo()
        {
            return new FrmVincularRequisicionesRfq();
        }

        private void BtnValesSalida_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void MostrarVincularRquisicionRfq(string num_parte)
        {
             DgvVincularReqRfq.Rows.Clear();

            MaterialProyecto vincularRequisicionRfq = new MaterialProyecto();
            vincularRequisicionRfq.RequisicionesVinculadasARfq(num_parte).ForEach(delegate (Fila concepto)
            {
                TxtNumeroParte.Text = num_parte;
                TxtFabricante.Text = Convert.ToString(concepto.Celda("fabricante"));
                txtTipoVenta.Text = Convert.ToString(concepto.Celda("tipo_venta"));
                TxtDescripcion.Text = Convert.ToString(concepto.Celda("descripcion"));

                DgvVincularReqRfq.Rows.Add(
                    concepto.Celda("proyecto"),
                    concepto.Celda("id"),
                    concepto.Celda("requisitor"),                    
                    concepto.Celda("total"),
                    concepto.Celda("estatus_compra")
                    );

            });        
        }
    }
}

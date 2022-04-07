using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmDesglosarPO : Ventana
    {
        int Po;
        string Proveedor;
        public FrmDesglosarPO(int po, string proveedor)
        {
            InitializeComponent();
            Po = po;
            Proveedor = proveedor;
        }

        private void FrmDesglosarPO_Load(object sender, EventArgs e)
        {
            LblPO.Text = "PO # " + Po + "- " + Proveedor;
            RBRequisicion.Checked = true;
            CargarDatos();
        }

        private void CargarDatos()
        {
            DgvDesglose.Rows.Clear();

            string tipo = this.splitContainer1.Panel1.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked).Name.ToString();
            DgvDesglose.Rows.Clear();

            bool porRequisiciones = (tipo == "RBRequisicion");
            DgvDesglose.Columns["numero_parte"].Visible = porRequisiciones;
            DgvDesglose.Columns["precio_unitario"].Visible = porRequisiciones;
            DgvDesglose.Columns["cantidad"].Visible = porRequisiciones;

            MaterialProyecto.Modelo().DesgosarPO(Po, porRequisiciones).ForEach(delegate(Fila f) 
            {
                if (porRequisiciones)
                {
                    string cantidad = string.Empty;
                    if (f.Celda("tipo_venta").ToString() == "POR PAQUETE")
                        cantidad = f.Celda("total").ToString() + " PAQUETE(S) CON " + f.Celda("piezas_paquete").ToString() + " PIEZA(S) C/U";
                    else
                        cantidad = f.Celda("total").ToString() + " PIEZA(S)";

                    DgvDesglose.Rows.Add
                    (
                        f.Celda("proyecto"),
                        f.Celda("numero_parte"),
                        Convert.ToDecimal(f.Celda("precio_unitario")).ToString("C", CultureInfo.CurrentCulture) + " " + f.Celda("precio_moneda").ToString(),
                        cantidad,
                        Convert.ToDecimal(f.Celda("precio_suma_final")).ToString("C", CultureInfo.CurrentCulture) + " " + f.Celda("precio_moneda").ToString()
                    );
                }
                else
                {
                    DgvDesglose.Rows.Add
                    (
                        f.Celda("proyecto"),
                        "N/A",
                        "N/A",
                        "N/A",
                        Convert.ToDecimal(f.Celda("suma_proyecto")).ToString("C", CultureInfo.CurrentCulture)
                    );
                }
               
            });
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RBRequisicion_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}

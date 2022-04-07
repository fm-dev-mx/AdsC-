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
    public partial class FrmNuevoFactorValor : Ventana
    {
        public string ValorFactor = string.Empty;
        public decimal Porcentaje = 0;

        public FrmNuevoFactorValor(string factor, int idFactor=0)
        {
            InitializeComponent();
            ActiveControl = TxtValorFactor;
            TxtValorFactor.Focus();
            TxtFactor.Text = factor;

            if (idFactor > 0)
            {
                FactorProcesoFabricacion buscarFactor = new FactorProcesoFabricacion();
                buscarFactor.CargarDatos(idFactor);
                if(buscarFactor.TieneFilas())
                {
                    TxtValorFactor.Text = Global.ObjetoATexto(buscarFactor.Fila().Celda("factor_valor"), "");
                    NumPorcentaje.Value = Convert.ToDecimal(Global.ObjetoATexto(buscarFactor.Fila().Celda("factor_porcentaje"), "0"));
                    BtnCrear.Text = "Guardar";
                }
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            ValorFactor = TxtValorFactor.Text;
            Porcentaje = NumPorcentaje.Value;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtValorFactor_TextChanged(object sender, EventArgs e)
        {
            BtnCrear.Enabled = (TxtFactor.Text != "" && NumPorcentaje.Value > 0);
        }

        private void NumPorcentaje_ValueChanged(object sender, EventArgs e)
        {
            BtnCrear.Enabled = (TxtFactor.Text != "" && NumPorcentaje.Value > 0);
        }
    }
}

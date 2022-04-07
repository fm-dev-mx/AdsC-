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
    public partial class FrmNuevoFactor : Ventana
    {
        string Proceso = string.Empty;
        public string NombreFactor = string.Empty;

        public FrmNuevoFactor(string proceso, string factor = "")
        {
            InitializeComponent();
            ActiveControl = TxtNombreOperacion;
            TxtNombreOperacion.Focus();

            Proceso = proceso;
            TxtProceso.Text = Proceso;

            if(factor != "")
            {
                LblTitulo.Text = "EDITAR FACTOR";
                BtnCrear.Text = "Guardar";
                TxtNombreOperacion.Text = factor;
            }
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            NombreFactor = TxtNombreOperacion.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void TxtNombreOperacion_TextChanged(object sender, EventArgs e)
        {
            if (TxtNombreOperacion.Text != "")
                BtnCrear.Enabled = true;
            else
                BtnCrear.Enabled = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtProceso_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

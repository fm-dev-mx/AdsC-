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
    public partial class FrmCantidadMaterial : Ventana
    {
        public int Piezas;
        public int Minimo;
        public int Maximo;

        public FrmCantidadMaterial(int piezas=0, int minimo=1, int maximo=100000000, bool permitirReduccion = false)
        {
            InitializeComponent();
            Piezas = piezas;
            Minimo = (permitirReduccion)? 1: minimo;
            Maximo = maximo;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Piezas = Convert.ToInt32(NumPiezas.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmCantidadMaterial_Load(object sender, EventArgs e)
        {
            if (Piezas > 0)
                NumPiezas.Value = Piezas;
            else
                NumPiezas.Value = 1;

            NumPiezas.Minimum = Minimo;
            NumPiezas.Maximum = Maximo;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}

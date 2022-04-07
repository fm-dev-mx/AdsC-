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
    public partial class FrmIngresarSubEnsamble : Ventana
    {
        public int Subensamble = 0;
        public FrmIngresarSubEnsamble(bool editar = false, int valor = 0)
        {
            InitializeComponent();
            NumSubEnsamble.Value = Convert.ToInt32("00");
            if(editar)
            {
                LblTitulo.Text = "EDITE EL SUBENSAMBLE";
                NumSubEnsamble.Value = valor;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Subensamble = Convert.ToInt32(NumSubEnsamble.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

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
    public partial class FrmElementoModoFalla : Ventana
    {
        public string Descripcion = "";
        string Modo = "";
        public FrmElementoModoFalla(string modo, string descripcion = "")
        {
            InitializeComponent();
            Modo = modo;
            Descripcion = descripcion;
            LblTitulo.Text = "AGREGAR " + modo;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmElementoModoFalla_Load(object sender, EventArgs e)
        {
            if (Descripcion != "")
            {
                TxtDescripcion.Text = Descripcion;
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (TxtDescripcion.Text != "")
            {
                Descripcion = TxtDescripcion.Text;
                DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else
            {
                LblInfo.Visible = true;
                LblInfo.Text = "Debe agregar " + Modo;
            }
        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}

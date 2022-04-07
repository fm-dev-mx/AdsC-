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
    public partial class FrmIngresarComentario : Ventana
    {
        public string Comentarios;

        public FrmIngresarComentario(string titulo="", int limiteCaracteres=0)
        {
            InitializeComponent();

            if (titulo != "")
                LblTitulo.Text = titulo;

            if (limiteCaracteres > 0)
                TxtComentarios.MaxLength = limiteCaracteres;
        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = TxtComentarios.Text != "";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Comentarios = TxtComentarios.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}

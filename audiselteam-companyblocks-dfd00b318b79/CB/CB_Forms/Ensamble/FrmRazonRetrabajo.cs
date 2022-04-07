using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmRazonRetrabajo : Form
    {
        public string Razon = "";

        public FrmRazonRetrabajo(string razon="")
        {
            InitializeComponent();
            Razon = razon;
        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = TxtComentarios.Text != "";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Razon = TxtComentarios.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmRazonRetrabajo_Load(object sender, EventArgs e)
        {
            if (Razon != "")
                TxtComentarios.Text = Razon;
        }
    }
}

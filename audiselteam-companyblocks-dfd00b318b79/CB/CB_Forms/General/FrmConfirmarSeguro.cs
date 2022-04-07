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
    public partial class FrmConfirmarSeguro : Form
    {
        string PalabraVerificacion = "CANCELAR";

        public FrmConfirmarSeguro()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void TxtConfirmar_TextChanged(object sender, EventArgs e)
        {
            BtnConfirmar.Enabled = TxtConfirmar.Text == PalabraVerificacion;
        }
    }
}

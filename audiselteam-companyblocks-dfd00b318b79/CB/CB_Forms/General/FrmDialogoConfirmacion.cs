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
    public partial class FrmDialogoConfirmacion : Form
    {
        public string Confirmar = string.Empty;
        public FrmDialogoConfirmacion()
        {
            InitializeComponent();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            Confirmar = TxtConfirmar.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtConfirmar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Confirmar = TxtConfirmar.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}

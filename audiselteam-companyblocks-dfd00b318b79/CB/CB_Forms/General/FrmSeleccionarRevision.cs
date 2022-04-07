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
    public partial class FrmSeleccionarRevision : Form
    {
        protected decimal Maximo = 100000000000;
        public decimal RevisionSeleccionada = 0;

        public FrmSeleccionarRevision(decimal maximo=10000000000)
        {
            InitializeComponent();
            Maximo = maximo;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            RevisionSeleccionada = NumRevision.Value;
            DialogResult = DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmSeleccionarRevision_Load(object sender, EventArgs e)
        {
            NumRevision.Maximum = Maximo;
        }
    }
}

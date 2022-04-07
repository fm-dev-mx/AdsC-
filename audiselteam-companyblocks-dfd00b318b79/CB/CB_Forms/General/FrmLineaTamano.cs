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
    public partial class FrmLineaTamano : Form
    {
        public int Linea = 0;
        public FrmLineaTamano()
        {
            InitializeComponent();
        }

        private void FrmLineaTamano_Load(object sender, EventArgs e)
        {

        }

        private void BtnSize1_Click(object sender, EventArgs e)
        {
            Linea = 2;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnSize2_Click(object sender, EventArgs e)
        {
            Linea = 8;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnSize3_Click(object sender, EventArgs e)
        {
            Linea = 15;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnSize4_Click(object sender, EventArgs e)
        {
            Linea = 25;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Linea = (int)NumPixeles.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

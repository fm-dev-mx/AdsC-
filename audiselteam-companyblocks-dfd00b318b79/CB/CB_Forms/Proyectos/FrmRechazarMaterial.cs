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
    public partial class FrmRechazarMaterial : Form
    {
        public string Comentarios;

        public FrmRechazarMaterial()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            Comentarios = TxtComentarios.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {
            BtnRechazar.Enabled = TxtComentarios.Text != "";
        }
    }
}

using CB_Base.Classes;
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
    public partial class FrmProgramaDeCapacitacion : Ventana
    {
        public FrmProgramaDeCapacitacion()
        {
            InitializeComponent();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
        }

        private void FrmProgramaDeCapacitacion_Load(object sender, EventArgs e)
        {
        }

    }
}

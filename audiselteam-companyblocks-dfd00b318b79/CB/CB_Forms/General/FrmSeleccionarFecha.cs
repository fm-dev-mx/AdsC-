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
    public partial class FrmSeleccionarFecha : Form
    {
        public DateTime FechaSeleccionada;

        public FrmSeleccionarFecha(bool permitirFechasAnteriores=true, object fecha = null, object maxFecha = null)
        {
            InitializeComponent();

            if (!permitirFechasAnteriores)
                Fecha.MinDate = DateTime.Now.Date;

            if (fecha != null)
            {
                Fecha.MinDate = Convert.ToDateTime(fecha);
                Fecha.MaxDate = Convert.ToDateTime(maxFecha);
                Fecha.Value = Convert.ToDateTime(fecha);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            FechaSeleccionada = Fecha.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

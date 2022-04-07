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
    public partial class FrmResumenProyecto : Form
    {
        Proyecto ProyectoCargado = new Proyecto();

        public FrmResumenProyecto(decimal id)
        {
            InitializeComponent();
            ProyectoCargado.CargarDatos(id);
        }

        private void FrmResumenProyecto_Load(object sender, EventArgs e)
        {
            FondoProyecto.BackColor = Color.FromArgb(190, 0, 0, 0);
            this.WindowState = FormWindowState.Maximized;


            FondoProyecto.Text = Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2") + " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
        }
    }
}

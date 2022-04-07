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
    public partial class FrmAlcanceProyecto : Form
    {
        int IdCotizacion = 0;
        public FrmAlcanceProyecto(int idCotizacion = 0)
        {
            InitializeComponent();
            IdCotizacion = idCotizacion;
        }

        private void FrmAlcanceProyecto_Load(object sender, EventArgs e)
        {
            CargarAlcance();
        }

        private void CargarAlcance()
        {
            DgvAlcance.Rows.Clear();

            CotizacionAlcance alcance = new CotizacionAlcance();
            alcance.AlcanceCotizacion(IdCotizacion).ForEach(delegate(Fila f)
            {
                string strProceso = "";
                Proceso proceso = new Proceso();
                proceso.CargarDatos(f.Celda<int>("proceso"));

                if (proceso.TieneFilas())
                    strProceso = proceso.Fila().Celda("nombre").ToString(); ;

                DgvAlcance.Rows.Add
                (
                    f.Celda("id"),
                    strProceso,
                    f.Celda("alcance"),
                    f.Celda<int>("personas"),
                    Convert.ToDouble(f.Celda("horas"))
                );
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nuevoAlcanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrearNuevoAlcance nuevo = new FrmCrearNuevoAlcance(IdCotizacion);
            if(nuevo.ShowDialog() == DialogResult.OK)
                CargarAlcance();
        }

        private void Menu_Opening(object sender, CancelEventArgs e)
        {
            eliminarToolStripMenuItem.Enabled = (DgvAlcance.SelectedRows.Count > 0);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.sh
        }
    }
}

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
using CB_Base.CB_Controles;

namespace CB
{
    public partial class FrmIngresarSubensamble2 : Form
    {
        decimal Proyecto = 0;
        public int Subensamble = 0;

        public FrmIngresarSubensamble2(decimal proyecto, int subensamble = 0)
        {
            InitializeComponent();
            Proyecto = proyecto;
            Subensamble = subensamble;
        }

        private void FrmIngresarSubensamble2_Load(object sender, EventArgs e)
        {
            CmbSubensamble.Items.Clear();
            CmbSubensamble.Items.Add("00 GENERAL");

            int indiceActual = 0;
           
            Modulo.Modelo().SeleccionarProyecto(Proyecto).ForEach(delegate(Fila f)
            {
                int subTemporal = f.Celda<int>("subensamble");
                CmbSubensamble.Items.Add(subTemporal.ToString().PadLeft(2, '0') + " " + f.Celda("nombre").ToString());

                if(subTemporal == Subensamble)
                {
                    indiceActual = CmbSubensamble.Items.Count - 1;
                }
            });

            if (CmbSubensamble.Items.Count > 0)
                CmbSubensamble.SelectedIndex = indiceActual;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Subensamble = Convert.ToInt32(CmbSubensamble.Text.Split(' ')[0]);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}

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
    public partial class FrmAgregarTermino : Ventana
    {
        public int IdTermino = 0;
        public int PorcentajeVal = 0;
        public string Termino = "";

        public FrmAgregarTermino(int valorMaximo, int idTermino = 0, string sPorcentaje = "", string sTermino = "")
        {
            InitializeComponent();
            IdTermino = idTermino;
            
            if(idTermino != 0)
            {
                LblDescripcion.Text = "Edite el valor del porcentaje y concepto del término en un rango de 1 a " + ((100 - valorMaximo) + Convert.ToInt32(sPorcentaje)).ToString() + ".";
                NumPorcentaje.Value = Convert.ToInt32(sPorcentaje);
                NumPorcentaje.Maximum = (100 - valorMaximo) + Convert.ToInt32(sPorcentaje);
                TxtTermino.Text = sTermino; 
            }
            else
            {
                LblDescripcion.Text = "Agregue el valor del porcentaje y concepto del término en un rango de 1 a " + (100 - valorMaximo).ToString() + ".";
                NumPorcentaje.Maximum = (100 - valorMaximo);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if(TxtTermino.Text !="" && NumPorcentaje.Value != 0)
            {
                Termino = TxtTermino.Text;
                PorcentajeVal = Convert.ToInt32(NumPorcentaje.Value);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }               
            else
            {
                LblInformacion.Text = "Favor de llenar correctamente cada campo";
                LblInformacion.Visible = true;
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}

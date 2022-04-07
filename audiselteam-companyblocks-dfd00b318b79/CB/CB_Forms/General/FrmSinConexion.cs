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
    public partial class FrmSinConexion : Form
    {
        int TiempoReintento = 60;

        public FrmSinConexion()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnReintentar_Click(object sender, EventArgs e)
        {
            Segundero.Enabled = false;
            ReintentarConexion();
        }

        bool ReintentarConexion()
        {
            //return Redes.ExisteConexion(Global.ServidorDB);
            return false;
        }

        private void Segundero_Tick(object sender, EventArgs e)
        {
            if(TiempoReintento>0)
                TiempoReintento--;
            else
            {
                Segundero.Enabled = false;

                if (!ReintentarConexion())
                {
                    TiempoReintento = 60;
                    Segundero.Enabled = true;
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }

            LblDetalles.Text = "No ha sido posible conectarse con la base de datos, se reintentará en " + TiempoReintento.ToString() + " segundos."; 
        }
    }
}

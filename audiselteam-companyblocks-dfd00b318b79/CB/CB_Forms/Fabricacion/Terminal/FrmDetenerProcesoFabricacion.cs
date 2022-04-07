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
    public partial class FrmDetenerProcesoFabricacion : Ventana
    {
        public string Razon = string.Empty;
        public FrmDetenerProcesoFabricacion()
        {
            InitializeComponent();
        }

        private void FrmSeleccionarRazon_Load(object sender, EventArgs e)
        {
            CargarRazones();
        }

        private void CargarRazones()
        {
            RazonTiempoMuerto razones = new RazonTiempoMuerto();
            razones.SeleccionarDatos("", null).ForEach(delegate(Fila f)
            {
                CmbRazonTiempoMuerto.Items.Add(f.Celda("id").ToString() + " - " + f.Celda("razon").ToString());
            });

            if (CmbRazonTiempoMuerto.Items.Count > 0)
                CmbRazonTiempoMuerto.SelectedIndex = 0;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Razon = CmbRazonTiempoMuerto.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}

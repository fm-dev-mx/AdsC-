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
    public partial class FrmNuevoRol : Form
    {
        public FrmNuevoRol()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if( Rol.Modelo().SeleccionarRol(TxtRol.Text).Count > 0 )
            {
                MessageBox.Show("El rol " + TxtRol.Text + " ya existe!");
            }
            else
            {
                Fila datosrol = new Fila();
                datosrol.AgregarCelda("rol", TxtRol.Text);
                Rol.Modelo().Insertar(datosrol);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void TxtRol_TextChanged(object sender, EventArgs e)
        {
            BtnCrear.Enabled = TxtRol.Text != "";
        }
    }
}

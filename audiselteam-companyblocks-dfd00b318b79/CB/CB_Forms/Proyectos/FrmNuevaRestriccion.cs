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
    public partial class FrmNuevaRestriccion : Ventana
    {
        protected int IdRequerimiento = 0;

        public FrmNuevaRestriccion(int idRequerimiento)
        {
            InitializeComponent();
            IdRequerimiento = idRequerimiento;
        }

        private void FrmNuevaRestriccion_Load(object sender, EventArgs e)
        {

        }

        private void TxtRestriccion_TextChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = CmbTipo.Text != "" && TxtRestriccion.Text != "";
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Fila restriccion = new Fila();
            restriccion.AgregarCelda("requerimiento", IdRequerimiento);
            restriccion.AgregarCelda("tipo", CmbTipo.Text);
            restriccion.AgregarCelda("restriccion", TxtRestriccion.Text);

            RequerimientoRestriccion.Modelo().Insertar(restriccion);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(CmbTipo.Text)
            {
                case "FABRICANTE":
                    FrmSeleccionarFabricante fab = new FrmSeleccionarFabricante();

                    if( fab.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                    {
                        TxtRestriccion.Text = fab.NombreFabricante;
                        TxtRestriccion.ReadOnly = true;
                    }
                    break;
            }
        }
    }
}

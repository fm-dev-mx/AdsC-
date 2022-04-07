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
    public partial class FrmEscanearPlano : Ventana
    {
        public int Id = 0;
        public FrmEscanearPlano()
        {
            InitializeComponent();
        }

        public void EscanearId()
        {
            PlanoProyecto plano = new PlanoProyecto();
            if (plano.ExistePlano(Id))
            {
                plano.CargarDatos(Id);
                Id = Convert.ToInt32(plano.Fila().Celda("id"));
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("El archivo ingresado no a sido encontrado, favor de ingresar un ID valido", "ID no valido", MessageBoxButtons.OK);
                
        }

        private void EscanearNombre(string nombrePlano)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.SeleccionarPlano(nombrePlano);
            if (plano.TieneFilas())
            {
                Id = Convert.ToInt32(plano.Fila().Celda("id"));
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("El archivo ingresado no a sido encontrado, favor de ingresar un nombre valido", "Archivo no encontrado", MessageBoxButtons.OK);
        }

        private void RealizarEscaneo()
        {
            if (RButtonIDPlano.Checked)
            {
                if (!String.IsNullOrWhiteSpace(TxtScaner.Text.Trim()))
                {
                    if (int.TryParse(TxtScaner.Text, out Id))
                        EscanearId();

                    else
                        MessageBox.Show("El archivo ingresado no a sido encontrado, favor de ingresar un nombre valido", "Archivo no encontrado", MessageBoxButtons.OK);
                }
                
            }
            else if (RButtonNombrePlano.Checked)
            {
                if (!String.IsNullOrWhiteSpace(TxtScaner.Text.Trim()))
                    EscanearNombre(TxtScaner.Text);
            }    
        }

        private void LblNumeroPlano_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e); 
        }

        private void TxtScaner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RealizarEscaneo();
        }

        private void FrmEscanearPlano_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Cancel)
                Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            RealizarEscaneo();
        }

        private void FrmEscanearPlano_Load(object sender, EventArgs e)
        {
            RButtonIDPlano.Checked = true;
        }
    }
}

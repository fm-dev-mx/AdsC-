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
    public partial class FrmBuscarMaterial : Form
    {
        public string MaterialABuscar = string.Empty;
        public bool EsParteInterna = false;

        public FrmBuscarMaterial()
        {
            InitializeComponent();
        }

        private void FrmBuscarMaterial_Load(object sender, EventArgs e)
        {

        }

        private void RealizarEscaneo()
        {
            if (!String.IsNullOrWhiteSpace(TxtScaner.Text.Trim()))
            {
                EsParteInterna = RdbParteAudisel.Checked;

                if(RdbParteProveedor.Checked)
                    MaterialABuscar = TxtScaner.Text;
                else
                {
                    try 
                    {
                        MaterialABuscar = Convert.ToInt32(TxtScaner.Text.Split('-')[1]).ToString();
                    }
                    catch
                    {
                        MaterialABuscar = "0";
                    }
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                MessageBox.Show("El número de parte ingresado no ha sido encontrado, favor de ingresar un número de parte válido", "Número de parte no encontrado", MessageBoxButtons.OK);
            
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            RealizarEscaneo();
        }

        private void TxtScaner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RealizarEscaneo();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}

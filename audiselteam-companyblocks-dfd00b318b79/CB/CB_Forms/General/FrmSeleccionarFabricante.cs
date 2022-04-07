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
    public partial class FrmSeleccionarFabricante : Ventana
    {
        public string NombreFabricante = "";

        public FrmSeleccionarFabricante()
        {
            InitializeComponent();
        }

        private void FrmSeleccionarFabricante_Load(object sender, EventArgs e)
        {
            CargarFabricantes();
        }

        public void CargarFabricantes()
        {
            LlenarDataGridView(CatalogoMaterial.Modelo().Fabricantes(), DgvFabricantes);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void DgvFabricantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NombreFabricante = DgvFabricantes.Rows[e.RowIndex].Cells["fabricante"].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

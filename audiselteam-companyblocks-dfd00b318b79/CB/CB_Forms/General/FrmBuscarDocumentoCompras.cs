using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmBuscarDocumentoCompras : Form
    {
        public string Tipo = string.Empty;
        public int IdRequisicion = -1;
        bool BusquedaCompras = false;

        public FrmBuscarDocumentoCompras(bool busquedaCompras = false)
        {
            InitializeComponent();
            BusquedaCompras = busquedaCompras;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Finalizar();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void TxtScaner_TextChanged(object sender, EventArgs e)
        {
            BtnBuscar.Enabled = TxtScaner.Text.Trim() != String.Empty;
        }

        private void TxtScaner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Finalizar
                    ();
        }

        private void Finalizar()
        {
            try
            {
                IdRequisicion = Convert.ToInt32(TxtScaner.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Ingrese un número de requisición válido", "Número de requisición no válido", MessageBoxButtons.OK);
            }

            if (IdRequisicion > 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }

           Tipo = this.panel1.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked).Name.ToString();
        }

        private void FrmBuscarRequisicion_Load(object sender, EventArgs e)
        {
            RBPo.Visible = BusquedaCompras;
            RBRfq.Visible = BusquedaCompras;
            RBRequisicion.Checked = true;
            ActiveControl = TxtScaner;
            TxtScaner.Focus();
        }
    }
}

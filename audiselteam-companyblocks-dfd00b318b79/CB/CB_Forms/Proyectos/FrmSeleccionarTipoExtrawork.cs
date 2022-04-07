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
    public partial class FrmSeleccionarTipoExtrawork : Form
    {
        public string NombrePlano;
        public string IdPlano;

        public FrmSeleccionarTipoExtrawork()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cmbTipoExtrawork_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( cmbTipoExtrawork.Text == "PARTE COMPRADA" )
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void FrmSeleccionarTipoExtrawork_Load(object sender, EventArgs e)
        {
            cmbTipoExtrawork.Text = "CORTE WATER JET";
        }


    }
}

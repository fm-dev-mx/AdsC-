using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB_Base.CB_Controles
{
    public partial class AudiselBotonSalida : UserControl
    {
        public AudiselBotonSalida()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Form formContenedor = ((Form)this.TopLevelControl);
            formContenedor.DialogResult = DialogResult.Cancel;
            formContenedor.Close();
        }
    }
}

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
    public partial class FrmNuevoSubproyecto : Ventana
    {
        public string NombreSubproyecto = "";
        public FrmNuevoSubproyecto(string subproyectoNombre = "")
        {
            InitializeComponent();
            if(subproyectoNombre != "")
            {
                LblTitulo.Text = "EDITAR SUBPROYECTO";
                BtnRegistrar.Text = "Editar";
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            NombreSubproyecto = TxtSubproyectoNombre.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void TxtSubproyectoNombre_TextChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = (TxtSubproyectoNombre.Text != "");
        }
    }
}

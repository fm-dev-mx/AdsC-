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
    public partial class FrmNuevaTarea : Ventana
    {
        public string Nuevo = string.Empty;

        public FrmNuevaTarea(string titulo, string nombre = "")
        {
            InitializeComponent();
            LblTitulo.Text = titulo;
            TxtSubproyectoNombre.Text = nombre;
            TxtSubproyectoNombre.Focus();
            ActiveControl = TxtSubproyectoNombre;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Nuevo = TxtSubproyectoNombre.Text;
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

        private void TxtSubproyectoNombre_TextChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = (TxtSubproyectoNombre.Text != "");
        }

        private void TxtSubproyectoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Nuevo = TxtSubproyectoNombre.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}

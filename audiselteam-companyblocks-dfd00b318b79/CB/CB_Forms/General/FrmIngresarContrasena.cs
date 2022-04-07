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
    public partial class FrmIngresarContrasena : Form
    {
        public FrmIngresarContrasena()
        {
            InitializeComponent();
        }

        private void FrmIngresarContrasena_Load(object sender, EventArgs e)
        {
            txtCorreo.Text = Global.UsuarioActual.Fila().Celda("correo").ToString();
            txtPassword.Focus();           
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idUsuario = Usuario.Modelo().ValidarCredenciales(txtCorreo.Text, txtPassword.Text);
                if (idUsuario > 0)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                {
                    LblEstatus.Visible = true;
                    LblEstatus.Text = "Contraseña inválida";
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

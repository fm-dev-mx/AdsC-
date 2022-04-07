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
    public partial class FrmEditarContacto : Ventana
    {
        public string nombre = "";
        public string apellido = "";
        public string numeroCelular = "";
        public string numeroTel1 = "";
        public string numeroTel2 = "";
        public string correo = "";
        public string EditarTitulo = "";
        public string EditarBoton = "";
        public FrmEditarContacto()
        {
            InitializeComponent();
            
        }

        public void EnviarDatos()
        {
            
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmEditarContacto_Load(object sender, EventArgs e)
        {
            TxtNombreContacto.Text = nombre;
            TxtApellidoCantacto.Text = apellido;
            TxtNumeroCelular.Text = numeroCelular;
            TxtNumeroTelefono.Text = numeroTel1;
            TxtNumeroTelefono2.Text = numeroTel2;
            TxtCorreo.Text = correo;
            editarEtiquestas();
        }

        private bool validarCampos()
        {
            if (String.IsNullOrWhiteSpace(TxtNombreContacto.Text) || String.IsNullOrWhiteSpace(TxtApellidoCantacto.Text) || String.IsNullOrWhiteSpace(TxtNumeroCelular.Text) || String.IsNullOrWhiteSpace(TxtNumeroTelefono.Text) || String.IsNullOrWhiteSpace(TxtCorreo.Text))
                return true;
            else
                return false;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                nombre = TxtNombreContacto.Text.Trim();
                apellido = TxtApellidoCantacto.Text.Trim();
                numeroCelular = TxtNumeroCelular.Text.Trim();
                numeroTel1 = TxtNumeroTelefono.Text.Trim();
                numeroTel2 = TxtNumeroTelefono2.Text.Trim();
                correo = TxtCorreo.Text.Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Ingresa todos lo campos marcados con * ");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void editarEtiquestas()
        {
            if (EditarTitulo != "")
                LblTitulo.Text = EditarTitulo;
            if (EditarBoton != "")
                BtnRegistrar.Text = EditarBoton;
        }
    }
}

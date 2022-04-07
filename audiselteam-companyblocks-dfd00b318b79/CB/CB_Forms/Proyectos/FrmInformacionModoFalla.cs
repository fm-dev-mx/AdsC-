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
    public partial class FrmInformacionModoFalla : Ventana
    {
        string CausaEfecto;
        public string Descripcion;
        public string Nombre;
        public FrmInformacionModoFalla(string causaEfecto, string nombre="", string descripcion ="")
        {
            InitializeComponent();
            CausaEfecto = causaEfecto;
            Descripcion = descripcion;
            Nombre = nombre;
        }
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (CausaEfecto == "MODO DE FALLA")
            {
                if(String.IsNullOrWhiteSpace(TxtNombre.Text) || String.IsNullOrWhiteSpace(TxtDescripcion.Text))
                {
                    LblInfo.Visible = true;
                    LblInfo.Text = "Capture los datos Completos";
                }
                    
                else
                {
                    Descripcion = TxtDescripcion.Text;
                    Nombre = TxtNombre.Text;
                    DialogResult = DialogResult.Yes;
                }
            }
            if (String.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                LblInfo.Visible = true;
                LblInfo.Text = "Capture los datos completos";
            }
                
            else
            {
                Descripcion = TxtDescripcion.Text;
                DialogResult = DialogResult.Yes;
            } 
        }

        private void frmInformacionModoFalla_Load(object sender, EventArgs e)
        {
            if (Descripcion != "")
                LblTitulo.Text = "EDITAR " + CausaEfecto;
            else
                LblTitulo.Text = "AGREGAR " + CausaEfecto;
            
            if (Nombre == "" && CausaEfecto != "MODO DE FALLA")
                TxtNombre.Enabled = false;
            TxtNombre.Text = Nombre;
            TxtDescripcion.Text = Descripcion;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

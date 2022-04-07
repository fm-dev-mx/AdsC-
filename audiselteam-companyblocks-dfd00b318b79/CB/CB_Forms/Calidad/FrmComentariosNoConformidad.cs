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
    public partial class FrmComentariosNoConformidad : Ventana
    {
        public int CantidadOk = 0;
        public int CantidadNoOk = 0;
        public string Comentarios = string.Empty;

        public FrmComentariosNoConformidad(int cantidadNoOk = 1, string comentarios = "")
        {
            InitializeComponent();
            TxtComentarios.Text = comentarios;
            NumNOK.Value = Convert.ToDecimal(cantidadNoOk);
        }

        private void FrmAgregarProcesoNoConforme_Load(object sender, EventArgs e)
        {
            
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            CantidadOk = Convert.ToInt32(NumOK.Value);
            CantidadNoOk = Convert.ToInt32(NumNOK.Value);
            Comentarios = TxtComentarios.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TxTCantidadNoOk_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtComentarios.Text != string.Empty);
        }

        private void TxTCantidadOk_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtComentarios.Text != string.Empty);
        }


        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtComentarios.Text != string.Empty);
        }
    }
}

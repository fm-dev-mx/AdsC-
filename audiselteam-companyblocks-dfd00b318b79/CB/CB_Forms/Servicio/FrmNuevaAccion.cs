using CB_Base.Classes;
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
    public partial class FrmNuevaAccion : Ventana
    {
        public string Tipo = string.Empty;
        public string Nombre = string.Empty;
        public string Detalles = string.Empty;
        public DateTime FechaPromesa;
        public List<Usuario> UsuariosSeleccionados;

        public FrmNuevaAccion()
        {
            InitializeComponent();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        public void ValidarDatos()
        {
            bool datosCompletos = CmbTipo.Text != string.Empty && TxtNombre.Text != string.Empty && TxtDetalles.Text != string.Empty && DgvResponsable.Rows.Count > 0;

            LblEstatus.Text = "Ingresa al menos 50 caracteres en los detalles.";
            LblEstatus.Visible = datosCompletos && TxtDetalles.TextLength < 50;

            BtnRegistrar.Enabled = datosCompletos && TxtDetalles.TextLength >= 50;
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void TxtDetalles_TextChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Tipo = CmbTipo.Text;
            Nombre = TxtNombre.Text;
            Detalles = TxtDetalles.Text;
            FechaPromesa = DateFechaPromesa.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void FrmNuevaAccion_Load(object sender, EventArgs e)
        {
            DateFechaPromesa.MinDate = DateTime.Now;
        }

        private void seleccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario selUsr = new FrmSeleccionarUsuario(string.Empty, true);

            DgvResponsable.Rows.Clear();
            if(selUsr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UsuariosSeleccionados = selUsr.UsuariosSeleccionados;

                UsuariosSeleccionados.ForEach(delegate(Usuario usr)
                {
                    DgvResponsable.Rows.Add(usr.Fila().Celda("id"), usr.NombreCompleto());
                });
            }
            ValidarDatos();
        }
    }
}

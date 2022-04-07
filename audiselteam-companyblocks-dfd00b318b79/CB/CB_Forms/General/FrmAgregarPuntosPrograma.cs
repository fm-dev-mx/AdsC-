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
    public partial class FrmAgregarPuntosPrograma : Ventana
    {
        public int Duracion = 1;
        public string Texto = string.Empty;
        string Titulo = string.Empty;
        string Tipo = string.Empty;
        int HorasDisponibles = 0;

        public FrmAgregarPuntosPrograma(string titulo, string tipo, int horasDisponibles, string texto = "", int duracion = 60)
        {
            InitializeComponent();
            Titulo = titulo;
            Tipo = tipo;
            Texto = texto;
            Duracion = duracion;
            HorasDisponibles = horasDisponibles;
        }

        private void FrmAgregarPuntosPrograma_Load(object sender, EventArgs e)
        {
            LblTitulo.Text = Titulo;
            LblDescripcion.Text = Tipo.ToTitleCase();
            TxtTema.Text = Texto;
            NumDuracion.Value = Duracion;
            NumDuracion.Maximum = HorasDisponibles;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            Texto = TxtTema.Text;
            Duracion = Convert.ToInt32(NumDuracion.Value);

            DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void TxtTema_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtTema.Text != "");
        }
    }
}

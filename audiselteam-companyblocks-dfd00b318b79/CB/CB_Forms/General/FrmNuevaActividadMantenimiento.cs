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
    public partial class FrmNuevaActividadMantenimiento : Ventana
    {
        public string Actividad = string.Empty;
        public string Comentarios = string.Empty;
        int IdActividad = 0;

        public FrmNuevaActividadMantenimiento(int idActividad = 0)
        {
            InitializeComponent();
            IdActividad = idActividad;
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (TxtActividad.Text == "")
                return;

            Actividad = TxtActividad.Text.ToUpper();
            Comentarios = TxtComentarios.Text.ToUpper();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmNuevaActividadMantenimiento_Load(object sender, EventArgs e)
        {
            if (IdActividad > 0)
                CargarInformacion();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void CargarInformacion()
        {
            ActividadMantenimiento mantenimiento = new ActividadMantenimiento();
            mantenimiento.CargarDatos(IdActividad).ForEach(delegate(Fila f)
            {
                object objComentarios = f.Celda("comentarios");
                string strComentarios = string.Empty;

                if (objComentarios != null)
                    strComentarios = objComentarios.ToString();

                TxtActividad.Text = f.Celda("actividad").ToString();
                TxtComentarios.Text = strComentarios;

                LblTitulo.Text = "EDITAR ACTIVIDAD";
            });
        }

        private void TxtActividad_TextChanged(object sender, EventArgs e)
        {
            if (TxtActividad.Text != "" && TxtComentarios.Text != "")
                BtnFinalizar.Enabled = true;
            else
                BtnFinalizar.Enabled = false;
        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {
            if (TxtActividad.Text != "" && TxtComentarios.Text != "")
                BtnFinalizar.Enabled = true;
            else
                BtnFinalizar.Enabled = false;
        }
    }
}

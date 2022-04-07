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
    public partial class FrmEvaluarHabilidadProveedor : Ventana
    {
        public int Calificacion = 0;
        public string Comentarios = string.Empty;
        string Habilidad = string.Empty;
        
        public FrmEvaluarHabilidadProveedor(string habilidad, string comentario, int puntuacion)
        {
            InitializeComponent();
            Habilidad = habilidad;
            TxtComentarios.Text = comentario;

            if (puntuacion > 0)
                NumCalificacion.Value = puntuacion;
        }

        private void FrmEvaluarHabilidad_Load(object sender, EventArgs e)
        {
            LblHabilidad.Text = Habilidad;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Calificacion = Convert.ToInt32(NumCalificacion.Value);
            Comentarios = TxtComentarios.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
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

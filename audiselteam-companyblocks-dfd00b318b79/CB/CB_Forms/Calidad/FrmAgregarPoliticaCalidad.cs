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
    public partial class FrmAgregarPoliticaCalidad : Ventana
    {
        public string CreadorPolitica = string.Empty;
        public string Politica = string.Empty;
        public string Revisa = string.Empty;
        public string Comentarios = string.Empty;
        public string UsuarioAprobacion = string.Empty;
        public int Revision = 0;
        string StrPolitica = "";
        public int IdPolitica = 0;

        public FrmAgregarPoliticaCalidad( string politica = "")
        {
            InitializeComponent();
            StrPolitica = politica;
        }

        private void FrmAgregarPoliticaCalidad_Load(object sender, EventArgs e)
        {
            TxtCreador.Enabled = false;
            TxtRevision.Enabled = false;

            if(StrPolitica == "")
            {
                Revision = 0;
            }
            else if(StrPolitica != "")
            {
                PoliticaCalidad politicaCalidad = new PoliticaCalidad();
                politicaCalidad.SeleccionarPolitica(StrPolitica).ForEach(delegate(Fila f)
                {
                    TxtComentarios.Text = f.Celda("comentarios_revision").ToString();
                    TxtCreador.Text = f.Celda("usuario_creacion").ToString();
                    TxtRevision.Text = f.Celda("usuario_revision").ToString();
                    TxtPolitica.Text = f.Celda("politica").ToString();
                    Revision = Convert.ToInt32(f.Celda("revision")) + 1;
                    IdPolitica = Convert.ToInt32(f.Celda("id"));
                });
            }
        }

        private void BtnCreador_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if (usuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                TxtCreador.Text = usuario.UsuarioSeleccionado.Fila().Celda("nombre").ToString() + " " + usuario.UsuarioSeleccionado.Fila().Celda("paterno").ToString();
       
        }

        private void BtnRevision_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if (usuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                TxtRevision.Text = usuario.UsuarioSeleccionado.Fila().Celda("nombre").ToString() + " " + usuario.UsuarioSeleccionado.Fila().Celda("paterno").ToString();
    
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TxtPolitica.Text == "" || TxtComentarios.Text == "" || TxtRevision.Text == "")
                return;

            CreadorPolitica = TxtCreador.Text;
            Comentarios = TxtComentarios.Text;
            Politica = TxtPolitica.Text;
            Revisa = TxtRevision.Text;
            UsuarioAprobacion = Global.UsuarioActual.NombreCompleto();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}

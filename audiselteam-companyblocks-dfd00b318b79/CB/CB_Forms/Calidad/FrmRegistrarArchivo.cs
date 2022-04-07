using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmRegistrarArchivo : Ventana
    {
        public byte[] Documento = null;
        public string CreadorDocumento = string.Empty;
        public string Revisa = string.Empty;
        public string Comentarios = string.Empty;
        public string NombreDocumento = string.Empty;
        public string Departamento = string.Empty;
        public string TipoArchivo = string.Empty;
        public string Consecutivo = string.Empty;
        public string UsuarioAprobacion = string.Empty;
        public string Extension = string.Empty;
        public int Revision = 0;
        int IdDocumento = 0;

        public FrmRegistrarArchivo(int idDocumento = 0)
        {
            InitializeComponent();
            IdDocumento = idDocumento;
        }

        private void FrmRegistrarArchivo_Load(object sender, EventArgs e)
        {
            TxtCreador.Enabled = false;
            TxtRevision.Enabled = false;

            if(IdDocumento == 0)
            {
                TxtComentarios.Text = "REVISION INICIAL";
            }
            else
            {
                LblTitulo.Text = "EDITAR DOCUMENTO";
                DocumentoSgc.Modelo().CargarDatos(IdDocumento).ForEach(delegate(Fila f)
                {
                    Departamento = f.Celda("departamento").ToString();
                    TipoArchivo = f.Celda("tipo_archivo").ToString();
                    Consecutivo = f.Celda("consecutivo").ToString();
                    Revision = Convert.ToInt32(f.Celda("revision")) + 1;
                    LblNombreArchivo.Text = f.Celda("titulo").ToString();
                    TxtCreador.Text = f.Celda("usuario_creacion").ToString();
                    TxtRevision.Text = f.Celda("usuario_revision").ToString();
                    TxtComentarios.Text = f.Celda("comentarios_revision").ToString();
                    NombreDocumento = f.Celda("titulo").ToString();
                    Extension = f.Celda("extension").ToString();
                });
            }
        }
        
        private void BtnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            FDArchivo.Filter = "archivos pdf|*.pdf|Word 2003 y anteriores|*.doc|Word 2007 y posteriores (*.docx)|*.docx";
            FDArchivo.DefaultExt = "pdf";
            FDArchivo.FileName = "";
            FDArchivo.Title = "Seleccionar documento";
            if (FDArchivo.ShowDialog() == DialogResult.OK)
            {
                string nombreArchivo = FDArchivo.FileName;
                string[] partesArchivo = FDArchivo.SafeFileName.Split('-');
                int consecutivo = 0;

                if(partesArchivo.Length < 2)
                {
                    MessageBox.Show("El archivo que intenta subir no es un tipo de documento válido", "Documento no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(partesArchivo[0].Length < 2)
                {
                    MessageBox.Show("El archivo que intenta subir no es un tipo de documento válido", "Documento no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (partesArchivo[1].Length < 1)
                {
                    MessageBox.Show("El archivo que intenta subir no es un tipo de documento válido", "Documento no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(!int.TryParse(partesArchivo[2],out consecutivo))
                {
                    MessageBox.Show("El archivo que intenta subir no es un tipo de documento válido", "Documento no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Departamento = partesArchivo[0].ToUpper().Trim();
                TipoArchivo = partesArchivo[1].ToUpper().Trim();
                Consecutivo = partesArchivo[2].ToUpper().Trim();
               
                Extension = Path.GetExtension(FDArchivo.SafeFileName);
                NombreDocumento = FDArchivo.SafeFileName.ToUpper().Trim();
                Documento = File.ReadAllBytes(nombreArchivo);
                BtnAceptar.Enabled = true;
            }
            LblNombreArchivo.Text = FDArchivo.SafeFileName;
        }

        private void BtnCreador_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if(usuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                TxtCreador.Text = usuario.UsuarioSeleccionado.Fila().Celda("nombre").ToString() + " " + usuario.UsuarioSeleccionado.Fila().Celda("paterno").ToString();
        }

        private void BtnRevision_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if (usuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                TxtRevision.Text = usuario.UsuarioSeleccionado.Fila().Celda("nombre").ToString() + " " + usuario.UsuarioSeleccionado.Fila().Celda("paterno").ToString();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TxtCreador.Text == "" || TxtRevision.Text == "" || Documento == null)
                return;

            CreadorDocumento = TxtCreador.Text;
            Comentarios = TxtComentarios.Text;
            Revisa = TxtRevision.Text;
            UsuarioAprobacion = Global.UsuarioActual.NombreCompleto();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

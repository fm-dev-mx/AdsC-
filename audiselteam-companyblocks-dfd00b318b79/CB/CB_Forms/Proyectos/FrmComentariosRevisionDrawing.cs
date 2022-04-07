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
using System.IO;
using FluentFTP;
using System.Net;

namespace CB
{
    public partial class FrmComentariosRevisionDrawing : Ventana
    {
        byte[] PlanoImagen = null;
        public FrmComentariosRevisionDrawing(int idDrawing)
        {
            InitializeComponent();

            SolidWorksProyecto drw = new SolidWorksProyecto();
             FtpClient ClienteFTP = new FtpClient();
            string raizFtp = "";
            decimal IdProyecto = 0;
            drw.CargarDatos(idDrawing);
            string estatusRevision = drw.Fila().Celda("estatus_revision").ToString();
            string nombreArchivo = drw.Fila().Celda("nombre_archivo").ToString();
            IdProyecto = Convert.ToDecimal(drw.Fila().Celda("proyecto"));
            
            splitContainer1.Panel2Collapsed = true;

            LblPlano.Text = Path.GetFileName(nombreArchivo);

            TxtComentarios.Text = drw.Fila().Celda("comentarios_revision").ToString();

            // Realizar conexion FTP
            string strProyecto = IdProyecto.ToString("F2").PadLeft(6, '0').Replace(".", "_");
            raizFtp = strProyecto + "/M" + strProyecto + "/";


            if (Global.TipoConexion == "LOCAL")
            {
                ClienteFTP.Host = Global.ConfiguracionActual.FtpServidorLocal;
                ClienteFTP.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
            }
            else
            {
                ClienteFTP.Host = Global.ConfiguracionActual.FtpServidorRemoto;
                ClienteFTP.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
            }

            // Verificar conexion con servidor FTP
            try
            {
                ClienteFTP.Connect();
            }
            catch 
            {
                MessageBox.Show("No se pudo comunicar con el servidor FTP", "Error de conexión con FTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(ClienteFTP.IsConnected)
            {
                string pathDirectorio = Path.GetDirectoryName(raizFtp + nombreArchivo);
                string[] listaArchivosEnServidor = ClienteFTP.GetNameListing(pathDirectorio);

                string archivo = Path.GetFileNameWithoutExtension(nombreArchivo);
                 if (listaArchivosEnServidor.Length > 0)
                 {
                     string strIdEspacioPlano = Array.Find(listaArchivosEnServidor, x => x.Contains(Path.GetFileName(archivo) + "_REV.PNG") && !x.ToUpper().EndsWith(".SLDPRT") && !x.ToUpper().EndsWith(".SLDDRW"));

                     if (strIdEspacioPlano != null)
                     {
                         strIdEspacioPlano = Path.GetFileName(strIdEspacioPlano);
                         if (strIdEspacioPlano.Contains(" "))
                         {
                             string[] partesIdEspacioPlano = strIdEspacioPlano.Split(' ');

                             if (partesIdEspacioPlano[0].All(char.IsDigit))
                             {
                                 splitContainer1.Panel2Collapsed = false;
                                 ChkMostrarImagen.Visible = true;

                                 ClienteFTP.Download(out PlanoImagen, pathDirectorio + "\\" + strIdEspacioPlano);
                                 PicImagenRevision.SizeMode = PictureBoxSizeMode.StretchImage;

                                 if (ImagenValida(PlanoImagen))
                                     PicImagenRevision.Image = ByteToImage(PlanoImagen);
                                 else
                                 {
                                     PicImagenRevision.Image = CB_Base.Properties.Resources.image_not_found;
                                     MessageBox.Show("No fue posible cargar la imagen de revisión", "Error al obtener la imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 }
                             }
                         }
                         else
                         {
                             splitContainer1.Panel2Collapsed = false;
                             ChkMostrarImagen.Visible = true;

                             ClienteFTP.Download(out PlanoImagen, pathDirectorio + "\\" + strIdEspacioPlano);
                             PicImagenRevision.SizeMode = PictureBoxSizeMode.StretchImage;

                             if(ImagenValida(PlanoImagen))
                                PicImagenRevision.Image = ByteToImage(PlanoImagen);
                             else
                             {
                                 PicImagenRevision.Image = CB_Base.Properties.Resources.image_not_found;
                                 MessageBox.Show("No fue posible cargar la imagen de revisión","Error al obtener la imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             } 
                         }
                     }
                 }
            }

            if(estatusRevision == "PENDIENTE")
            {
                LblUsuarioRevision.Text = "PLANO SIN REVISAR";
            }
            else if(estatusRevision == "RECHAZADO")
            {
                TxtComentarios.BackColor = Color.PaleVioletRed;
                TxtComentarios.ForeColor = Color.Black;
                LblUsuarioRevision.Text = "REVISADO POR " + drw.Fila().Celda("usuario_revision").ToString();
                LblUsuarioRevision.Text += " @ " + Convert.ToDateTime(drw.Fila().Celda("fecha_revision")).ToString("MMM dd, yyyy hh:mm:ss tt");
            }
            else if(estatusRevision == "ACEPTADO")
            {
                TxtComentarios.BackColor = Color.LightGreen;
                TxtComentarios.ForeColor = Color.Black;
                LblUsuarioRevision.Text = "REVISADO POR " + drw.Fila().Celda("usuario_revision").ToString();
                LblUsuarioRevision.Text += " @ " + Convert.ToDateTime(drw.Fila().Celda("fecha_revision")).ToString("MMM dd, yyyy hh:mm:ss tt");
            }
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        public static bool ImagenValida(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                    Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        private void LblTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if(WindowState != FormWindowState.Maximized)
                Mover(sender, e);
        }


        private void ChkMostrarImagen_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkMostrarImagen.Checked)
            {
                splitContainer1.Panel2Collapsed = false;
                ChkMostrarImagen.Visible = true;
                PicImagenRevision.SizeMode = PictureBoxSizeMode.StretchImage;

                PicImagenRevision.Image = ByteToImage(PlanoImagen);
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
            }
        }
    }
}

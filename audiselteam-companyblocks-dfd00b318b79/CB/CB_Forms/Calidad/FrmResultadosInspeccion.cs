using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using FluentFTP;
using System.Net;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmResultadosInspeccion : Ventana
    {
        int IdPlano = 0;
        int IdProceso = 0;
        byte[] PlanoImagen = null;

        public FrmResultadosInspeccion(int idPlano, int idpProceso)
        {
            InitializeComponent();
            IdPlano = idPlano;
            IdProceso = idpProceso;
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

        private void ChkMostrarPlano_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkMostrarImagen.Checked)
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

        private void FrmConsultarNoConformancia_Load(object sender, EventArgs e)
        {
            FtpClient ClienteFTP = new FtpClient();
            string raizFtp = "";
            string subensamble = string.Empty;

            NoConformidad noConformidad = new NoConformidad();
                       
            //   string estatusRevision = noConformidad.Fila().Celda("estatus_revision").ToString();
            PlanoProyecto proyecto = new PlanoProyecto();
            string nombreArchivo = string.Empty;

            proyecto.CargarDatos(IdPlano);
            if (proyecto.TieneFilas())
            {
                nombreArchivo = proyecto.Fila().Celda("nombre_archivo").ToString();
                splitContainer1.Panel2Collapsed = true;
                LblPlano.Text = Path.GetFileName(nombreArchivo);
                
                // Realizar conexion FTP
                string strProyecto = Convert.ToDecimal(proyecto.Fila().Celda("proyecto")).ToString("F2").PadLeft(6, '0').Replace(".", "_");
                raizFtp = strProyecto + "/M" + strProyecto + "/";
                subensamble = proyecto.Fila().Celda("subensamble").ToString().PadLeft(2,'0');

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

                if (ClienteFTP.IsConnected)
                {
                    string pathDirectorio = Path.GetDirectoryName(raizFtp + nombreArchivo);
                    
                    string[] listaArchivosEnServidor = new string[20];

                    if(ClienteFTP.DirectoryExists(pathDirectorio + "\\" + subensamble + "\\CP\\"))
                        listaArchivosEnServidor = ClienteFTP.GetNameListing(pathDirectorio + "\\" + subensamble + "\\CP\\");
                    else
                    {
                        MessageBox.Show("Este proceso de inspección aún esta pendiente, imposible mostrar resultados.", "Imposible mostrar resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Close();
                        return;
                    }

                    string archivo = Path.GetFileNameWithoutExtension(nombreArchivo);
                    if (listaArchivosEnServidor.Length > 0)
                    {
                        string strIdEspacioPlano = Array.Find(listaArchivosEnServidor, x => x.Contains(Path.GetFileName(archivo) + "_INS.PNG"));

                        if (strIdEspacioPlano != null)
                        {
                            strIdEspacioPlano = Path.GetFileName(strIdEspacioPlano);
                            
                            splitContainer1.Panel2Collapsed = false;
                            ChkMostrarImagen.Visible = true;

                            ClienteFTP.Download(out PlanoImagen, pathDirectorio + "\\" + subensamble + "\\CP\\"  + strIdEspacioPlano);
                            PicImagenRevision.SizeMode = PictureBoxSizeMode.StretchImage;

                            if (ImagenValida(PlanoImagen))
                                PicImagenRevision.Image = ByteToImage(PlanoImagen);
                            else
                            {
                                PicImagenRevision.Image = CB_Base.Properties.Resources.image_not_found;
                                MessageBox.Show("No fue posible cargar la imagen de revisión", "Error al obtener la imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }   
                        }
                        else
                        {                            
                            splitContainer1.Panel2Collapsed = false;
                            ChkMostrarImagen.Visible = true;

                            string pathImagenInspeccion = pathDirectorio + "\\" + subensamble + "\\CP\\" + IdPlano + " " + archivo + "_INS.PNG";


                            if(!ClienteFTP.FileExists(pathImagenInspeccion))
                            {
                                MessageBox.Show("No se encontró la imagen de revisión en el servidor.", "Imposible mostrar resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Close();
                                return;
                            }

                            ClienteFTP.Download(out PlanoImagen, pathImagenInspeccion);
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
                }

                int count = 0;
                List<Fila> ListaNoConformidades = noConformidad.SeleccionarNoConformidad(IdPlano, IdProceso);
                if(ListaNoConformidades.Count > 0)
                {
                    ListaNoConformidades.ForEach(delegate(Fila f)
                    {
                        count++;
                        PlanoProceso planoProceso = new PlanoProceso();
                        planoProceso.CargarDatos(Convert.ToInt32(f.Celda("proceso_fabricacion_rechazado")));

                        if (TxtComentarios.Text != "")
                            TxtComentarios.Text += Environment.NewLine;

                        TxtComentarios.Text += "(" + count + ").-PROCESO RECHAZADO: " + f.Celda("proceso_fabricacion_rechazado").ToString() + " " + planoProceso.Fila().Celda("proceso").ToString();
                        TxtComentarios.Text += Environment.NewLine + f.Celda("comentarios");

                        Usuario usuario = new Usuario();
                        usuario.CargarDatos(Convert.ToInt32(f.Celda("usuario_creacion")));

                        TxtComentarios.Text += Environment.NewLine + "REVISADO POR: " + Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");
                        TxtComentarios.Text += Environment.NewLine + "FECHA DE RECHAZO: " + Global.FechaATexto(f.Celda("fecha_creacion"));
                        TxtComentarios.Text += Environment.NewLine;
                    });  
                }
                else
                {
                    PlanoProceso.Modelo().CargarDatos(IdProceso).ForEach(delegate(Fila f)
                    {
                        TxtComentarios.Text = Global.ObjetoATexto(f.Celda("comentarios"), "");
                    });
                }
            }            
        }
    }
}

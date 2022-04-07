using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmVisorImagen : Form
    {
        //mover
        Point UltimoPunto = Point.Empty;
        bool MouseClickMover = new Boolean();
        bool ModoEditar = false;

        //zoom in out
        bool Editar = false;
        int ImageWidth, ImageHeight;
        int imgWEscalado, imgHEscalado;
        float Escala = 1.0f;

        public FrmVisorImagen(byte[] datosImagen, string tituloImagen="Imagen")
        {
            InitializeComponent();
            Text = tituloImagen;
            LblTitulo.Text = tituloImagen;

            using (var ms = new MemoryStream(datosImagen))
            {
                PicImagen.Image = Image.FromStream(ms);
            }
        }

        private void FrmVisorImagen_Load(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(PicPlano_MouseWheel);
            Editar = false;
        }

        //zoom
        private void PicPlano_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!Editar)
            {
                if (PicImagen.Dock != DockStyle.None)
                    PicImagen.Dock = DockStyle.None;

                ImageWidth = PicImagen.Image.Width;
                ImageHeight = PicImagen.Image.Height;
                PicImagen.SizeMode = PictureBoxSizeMode.Zoom;
                PicImagen.Size = new System.Drawing.Size(ImageWidth, ImageHeight);
                //panel1.AutoScroll = false;

                Editar = true;
            }
            ZoomInZoomOut(e, PicImagen);
        }

        private void ZoomInZoomOut(MouseEventArgs e, PictureBox picture)
        {
            if (Editar)
            {
                // Escala al hacer scroll
                const float nuevaEscala = 0.1f / 120;

                // actualizamos en base a la nueva escala
                Escala += e.Delta * nuevaEscala;

                if (Escala < 0)
                    Escala = 0;

                imgWEscalado = (int)(ImageWidth * Escala);
                imgHEscalado = (int)(ImageHeight * Escala);

                // aplicamos la escala al picturebox.
                if (imgHEscalado > 0 && imgWEscalado > 0 && imgHEscalado < 9000 && imgWEscalado < 9000)
                {
                    Control contenedor = PicImagen.Parent;
                    picture.Size = new Size((int)(ImageWidth * Escala), (int)(ImageHeight * Escala));
                    if (PicImagen.Width < contenedor.Width && PicImagen.Location.X <= 0 && PicImagen.Location.Y <= 0)
                    {
                        picture.Location = new Point(0, 0);
                    }
                }
                else
                    Escala -= (e.Delta * nuevaEscala);
            }
        }

        public Point ZoomPuntos(Point p)
        {
            Point puntoEscalado = new Point();

            int imagenW = PicImagen.Image.Width;
            int imagenH = PicImagen.Image.Height;
            int pictureBoxW = PicImagen.Width;
            int pictureBoxH = PicImagen.Height;

            float ratio = imagenW / (float)imagenH;
            float containerRatio = pictureBoxW / (float)pictureBoxH;

            if (ratio >= containerRatio)
            {
                // imagen horizontal
                float escalaW = pictureBoxW / (float)imagenW;
                float escalaH = imagenH * escalaW;
                float filler = Math.Abs(pictureBoxH - escalaH) / 2;
                puntoEscalado.X = (int)(p.X / escalaW);
                puntoEscalado.Y = (int)((p.Y - filler) / escalaW);
            }
            else
            {
                // imagen vertical
                float escalaH = pictureBoxH / (float)imagenH;
                float escalaW = imagenW * escalaH;
                float filler = Math.Abs(pictureBoxW - escalaW) / 2;
                puntoEscalado.X = (int)((p.X - filler) / escalaH);
                puntoEscalado.Y = (int)(p.Y / escalaH);
            }
            return new Point((int)puntoEscalado.X, (int)puntoEscalado.Y);
        }

        //Mover
        public void MoverPictureBox(MouseEventArgs evento, PictureBox picture)
        {
            if (evento.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (picture.SizeMode != PictureBoxSizeMode.StretchImage)
                {
                    if (UltimoPunto != Point.Empty)
                    {
                        Point nuevaCoordenada = picture.Location;
                        nuevaCoordenada.X += evento.X - UltimoPunto.X;
                        nuevaCoordenada.Y += evento.Y - UltimoPunto.Y;
                        Control contenedor = PicImagen.Parent;
                        int ParentXImagenPos = (contenedor.Width - 100) + PicImagen.Width;
                        int posW = nuevaCoordenada.X + PicImagen.Width;
                        int negW = nuevaCoordenada.X - PicImagen.Width;
                        int ParentXImagenNeg = (contenedor.Width + 100) - PicImagen.Width;

                        if (PicImagen.Width < contenedor.Width)
                        {
                            if (nuevaCoordenada.X + PicImagen.Width > contenedor.Width)
                                nuevaCoordenada.X = contenedor.Width - PicImagen.Width;
                            else if (nuevaCoordenada.X < 0)
                                nuevaCoordenada.X = 0;

                            if (nuevaCoordenada.Y + PicImagen.Height > contenedor.Height)
                                nuevaCoordenada.Y = contenedor.Height - PicImagen.Height;
                            else if (nuevaCoordenada.Y < 0)
                                nuevaCoordenada.Y = 0;

                            if (PicImagen.Location != nuevaCoordenada)
                                PicImagen.Location = nuevaCoordenada;
                        }
                        else
                        {
                            picture.Location = nuevaCoordenada;
                        }
                    }
                }
            }
        }

        private void PicImagen_MouseMove(object sender, MouseEventArgs e)
        {
            MoverPictureBox(e, PicImagen);
        }

        private void PicImagen_MouseUp(object sender, MouseEventArgs e)
        {
            MouseClickMover = false;
            UltimoPunto = Point.Empty;
            Cursor = Cursors.Default;
        }

        private void PicImagen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {              
                Cursor = Cursors.Hand;
                UltimoPunto = new Point(e.X, e.Y);
            }
        }
    }
}

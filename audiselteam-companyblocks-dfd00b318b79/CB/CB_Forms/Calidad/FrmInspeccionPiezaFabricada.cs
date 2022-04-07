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
using FluentFTP;
using System.Net;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmInspeccionPiezaFabricada : Form
    {       
        Decimal Proyecto;
        FtpClient ClienteFtp = new FtpClient();
        
        string StrComentarios = string.Empty;
        string StrCantidadOk = string.Empty;
        string StrCantidadNok = string.Empty;
        string StrTipoNoConformidad = string.Empty;
        byte[] PlanoImagen;    
        bool PlanoDescargado = false;
        bool DgvCheckBox = false;
        bool ImagenSubida = false;
        bool Aceptar = false;
        int IdProceso = 0;

        public List<Fila> NoConformidades = new List<Fila>();
        public int IdPlano = 0;
        public string Comentarios = string.Empty;
        public string Proceso = string.Empty;
        public string RutaParcialSinExtension = string.Empty;
        public string Subensamble = string.Empty;
        public string RaizFtp = string.Empty;
        public bool RechazarPlano = false;
        public byte[] ImagenBytes = null;

        //pintar y mover imagen
        Point UltimoPunto = Point.Empty;
        bool UndoClick = false;
        bool MouseClickMover = new Boolean();
        bool ModoEditar = false;
        List<byte[]> ListaImagenes = new List<byte[]>();
        Color ColorLinea = Color.Black;
        int GruesoLinea = 8;

        //zoom in out
        bool Editar = false;
        int ImageWidth, ImageHeight;
        int imgWEscalado, imgHEscalado;
        float Escala = 1.0f;
        int CantidadPiezas = 0;

        public FrmInspeccionPiezaFabricada(int plano, string proceso, int idProceso)
        {
            InitializeComponent();

            MouseWheel += new MouseEventHandler(PicPlano_MouseWheel);
            KeyPreview = true;
            IdPlano = plano;
            Proceso = proceso;
            IdProceso = idProceso;
        }

        private void FrmInspeccionPiezaFabricada_Load(object sender, EventArgs e)
        {
            ColorLinea = Color.FromArgb(100, Color.Red);

            BkgDescargarPlano.RunWorkerAsync();
            LblInspeccion.Text = Proceso;
            Editar = false;
            BtnRechazar.Enabled = false;
            BtnAceptar.Enabled = false;
            BtnColorPicker.Enabled = false;
            BtnSizePicker.Enabled = false;
            BtnClean.Enabled = false;
            BtnEditar.Enabled = false;

            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(IdPlano);
            CantidadPiezas = Convert.ToInt32(plano.Fila().Celda("cantidad"));

            LblTitulo.Text += " | " + plano.Fila().Celda("id") + " " + plano.Fila().Celda("nombre_archivo") + " | " + CantidadPiezas + " PIEZA(S)";
        }

        private void BkgDescargarPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgDescargarPlano.ReportProgress(0, "Conectando con servidor FTP... ");
            if (Global.TipoConexion == "LOCAL")
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
            else
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;

            ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                           Global.UsuarioActual.Fila().Celda("password").ToString());

            // Verificar conexion con servidor FTP
            try
            {
                ClienteFtp.Connect();
                BkgDescargarPlano.ReportProgress(40, "Conectando con servidor FTP... [OK]");
                
            }
            catch //(Exception ex)
            {
                BkgDescargarPlano.ReportProgress(100, "Error de conexión con servidor FTP");
                return;
            }

            BkgDescargarPlano.ReportProgress(50, "Descargando imagen...");

            int idPlano = Convert.ToInt32(IdPlano);
            PlanoProyecto planoProyecto = new PlanoProyecto();
            planoProyecto.CargarDatos(idPlano);

            if (planoProyecto.TieneFilas())
            {
                RutaParcialSinExtension = Path.ChangeExtension(planoProyecto.Fila().Celda("nombre_archivo").ToString(), null);
                Proyecto = Convert.ToDecimal(planoProyecto.Fila().Celda("proyecto"));
                Subensamble = planoProyecto.Fila().Celda("subensamble").ToString();

                BkgDescargarPlano.ReportProgress(60, "Descargando imagen...");
            }

            string strProyecto = Proyecto.ToString("F2").PadLeft(6, '0').Replace(".", "_");
            RaizFtp = strProyecto + "/M" + strProyecto + "/";
            BkgDescargarPlano.ReportProgress(70, "Descargando imagen...");

            // Si existe el archivo cache de la imagen, lo descargamos para mostrarlo en el picturebox
            // En caso contrario:
            //    - convertimos a pdf
            //    - convertimos a imagen
            //    - convertimos a imagen miniatura
            // Luego enviamos los archivos a la carpeta ftp

            //string[] subensamble = RutaParcialSinExtension.Split('-');

            if (ClienteFtp.FileExists(RaizFtp + Subensamble + "\\CP\\" + idPlano + " " + RutaParcialSinExtension + ".PDF"))
            {
                BkgDescargarPlano.ReportProgress(80, "Descargando imagen...");
                PlanoImagen = null;
                
                ClienteFtp.Download(out PlanoImagen, RaizFtp + Subensamble + "\\CP\\" + idPlano + " " + RutaParcialSinExtension + ".PDF");

                PlanoDescargado = true;
                BkgDescargarPlano.ReportProgress(100, "Procesando imagen");
               // ListaImagenes.Add(PlanoImagen);
            }
            else
            {
                ArchivoPlano archivo = new ArchivoPlano();
                archivo.SeleccionarDePlano(IdPlano);
                if(archivo.TieneFilas())
                {
                    PlanoDescargado = true;
                    PlanoImagen = (byte[])archivo.Fila().Celda("archivo");

                    BkgDescargarPlano.ReportProgress(100, "Procesando imagen");
                   // ListaImagenes.Add(PlanoImagen);
                }
                else
                {
                    BkgDescargarPlano.ReportProgress(100, "Error al descargar la imagen");
                    PlanoImagen = null;
                    PlanoDescargado = false;
                   // ListaImagenes.Add(PlanoImagen);
                }
            }
        }

        private void BkgDescargarPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtEstatus.Text = (e.UserState.ToString());
            TxtComentarios.Refresh();
            Progreso.Value = e.ProgressPercentage;
            Progreso.Refresh();
        }

        private void BkgDescargarPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (PlanoDescargado)
            {
                if (PlanoImagen == null)
                {
                    PicPlano.Image = CB_Base.Properties.Resources.downloadPdf_gray;
                }
                else
                {
                    // convertir pdf a imagen
                    string pathPdfTemp = Path.GetTempFileName();
                    if (File.Exists(pathPdfTemp))
                    {
                        File.Delete(pathPdfTemp);
                    }
                    File.WriteAllBytes(pathPdfTemp, PlanoImagen);
                    PlanoImagen = FormatosPDF.MiniaturaPDF(pathPdfTemp, 0, 0, 150);

                    // mostrar la imagen en el picturebox
                    MemoryStream ms = new MemoryStream(PlanoImagen);
                    Image img = Image.FromStream(ms);
                    PicPlano.Image = img;
                    ListaImagenes.Add(PlanoImagen);
                }
                CargarProcesos();
                BtnAceptar.Enabled = true;
                BtnRechazar.Enabled = true;
                BtnColorPicker.Enabled = true;
                BtnSizePicker.Enabled = true;
                BtnClean.Enabled = true;
                BtnEditar.Enabled = true;
                Progreso.Visible = false;
                TxtEstatus.Text = "Imagen procesada correctamente";
            }
            else
            {
                string msg = "Ocurrio un error al descargar los archivos.";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #region Dibujar
        public static Bitmap ByteImagen(byte[] imagenEnByte)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] datos = imagenEnByte;
            mStream.Write(datos, 0, Convert.ToInt32(datos.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        public void GuardarImagen(byte[] imageIn)
        {
            string tempPath = Path.GetTempPath() + "AudiselDrawingTemp";
            if (File.Exists(tempPath))
                File.Delete(tempPath);

            File.WriteAllBytes(tempPath, imageIn);
        }

        //Cntrl Z
        private void FrmInspeccionPiezaFabricada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (ListaImagenes.Count > 1)
                {
                    ListaImagenes.Remove(ListaImagenes.Last());
                    if (ListaImagenes.Count > 0)
                    {
                        PicPlano.Image.Dispose();
                        PicPlano.Image = ByteImagen(ListaImagenes.Last());
                        GuardarImagen(ListaImagenes.Last());
                    }
                    UndoClick = true;
                }

                if (ListaImagenes.Count == 0)
                {
                    limpiar();
                    UndoClick = false;
                }
            }
        }

        //Mover
        private void PicPlano_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (ModoEditar)
                {
                    Cursor = Cursors.Cross;
                    UltimoPunto = e.Location;
                    MouseClickMover = true;
                }
            }
            else
            {
                Cursor = Cursors.Hand;
                UltimoPunto = new Point(e.X, e.Y);
            }
        }
        
        private void PicPlano_MouseUp(object sender, MouseEventArgs e)
        {
            MouseClickMover = false;
            UltimoPunto = Point.Empty;
            CrearLista(e);
            Cursor = Cursors.Default;
        }

        private void PicPlano_MouseMove(object sender, MouseEventArgs e)
        {
            if (ModoEditar)
                Dibujar(e, PicPlano);

            MoverPictureBox(e, PicPlano);
        }

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
                        Control contenedor = PicPlano.Parent;
                        int ParentXImagenPos = (contenedor.Width - 100) + PicPlano.Width;
                        int posW = nuevaCoordenada.X + PicPlano.Width;
                        int negW = nuevaCoordenada.X - PicPlano.Width;
                        int ParentXImagenNeg = (contenedor.Width + 100) - PicPlano.Width;

                        if (PicPlano.Width < contenedor.Width)
                        {
                            if (nuevaCoordenada.X + PicPlano.Width > contenedor.Width)
                                nuevaCoordenada.X = contenedor.Width - PicPlano.Width;
                            else if (nuevaCoordenada.X < 0)
                                nuevaCoordenada.X = 0;

                            if (nuevaCoordenada.Y + PicPlano.Height > contenedor.Height)
                                nuevaCoordenada.Y = contenedor.Height - PicPlano.Height;
                            else if (nuevaCoordenada.Y < 0)
                                nuevaCoordenada.Y = 0;

                            if (PicPlano.Location != nuevaCoordenada)
                                PicPlano.Location = nuevaCoordenada;
                        }
                        else
                        {
                            picture.Location = nuevaCoordenada;
                        }
                    }
                }
            }
        }


        //drawing
        public void Dibujar(MouseEventArgs eventoMouse, PictureBox picture)
        {
            if (eventoMouse.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (!MouseClickMover || UltimoPunto == null)
                    return;

                if (picture.Image == null)
                {
                    //crear nueva imagen
                    Bitmap bmp = new Bitmap(picture.Width, picture.Height);
                    picture.Image = bmp;
                }
                Graphics g = Graphics.FromImage(picture.Image);

                //se dibuja la linea del ultimo punto del mouse hasta la posicion actual del mouse
                if (picture.SizeMode == PictureBoxSizeMode.Zoom)
                    g.DrawLine(new Pen(ColorLinea, GruesoLinea), ZoomPuntos(UltimoPunto), ZoomPuntos(eventoMouse.Location));

                else if (picture.SizeMode == PictureBoxSizeMode.StretchImage)
                    g.DrawLine(new Pen(ColorLinea, GruesoLinea), PuntosModoStretch(UltimoPunto, picture), PuntosModoStretch(eventoMouse.Location, picture));

                else if (picture.SizeMode != PictureBoxSizeMode.StretchImage)
                    g.DrawLine(new Pen(ColorLinea, GruesoLinea), UltimoPunto, eventoMouse.Location);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                //actyualiza el pictureBox                    
                picture.Invalidate();

                //se asigna la coordenada actual del mouse al ultimo punto
                UltimoPunto = eventoMouse.Location;
            }
        }

        //Cntrl Z
        public void CrearLista(MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left && ModoEditar)
                {
                    ImageConverter converter = new ImageConverter();
                    string tempPath = Path.GetTempPath() + "AudiselDrawingTemp";

                    if (ListaImagenes.Count > 0 && UndoClick)
                    {
                        ListaImagenes.Clear();
                        byte[] datos = File.ReadAllBytes(tempPath);
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                        Bitmap temporal = (Bitmap)tc.ConvertFrom(datos);
                        ListaImagenes.Add((byte[])converter.ConvertTo(temporal, typeof(byte[])));
                        UndoClick = false;
                    }

                    if (ListaImagenes.Count == 0 && File.Exists(tempPath))
                    {
                        byte[] datos = File.ReadAllBytes(tempPath);
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                        Bitmap temporal = (Bitmap)tc.ConvertFrom(datos);

                        ListaImagenes.Add(PlanoImagen);
                        ListaImagenes.Add((byte[])converter.ConvertTo(temporal, typeof(byte[])));
                    }
                    else if (ListaImagenes.Count == 0)
                        ListaImagenes.Add(PlanoImagen);

                    if (ListaImagenes.Count > 0)
                        ListaImagenes.Add((byte[])converter.ConvertTo(PicPlano.Image, typeof(byte[])));
                }
            }
            catch { }
        }

        private Point PuntosModoStretch(Point coordenadas, PictureBox picture)
        {
            float ratioWidth = (float)picture.Image.Width / picture.ClientSize.Width;
            float ratioHeight = (float)picture.Image.Height / picture.ClientSize.Height;

            float puntoX = coordenadas.X;
            float puntoY = coordenadas.Y;
            puntoX *= ratioWidth;
            puntoY *= ratioHeight;
            return new Point((int)puntoX, (int)puntoY);
        }

        //zoom
        private void PicPlano_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!Editar)
            {
                if (PicPlano.Dock != DockStyle.None)
                    PicPlano.Dock = DockStyle.None;

                ImageWidth = PicPlano.Image.Width;
                ImageHeight = PicPlano.Image.Height;
                PicPlano.SizeMode = PictureBoxSizeMode.Zoom;
                PicPlano.Size = new System.Drawing.Size(ImageWidth, ImageHeight);
                panel1.AutoScroll = false;

                Editar = true;
            }
            ZoomInZoomOut(e, PicPlano);
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
                    Control contenedor = PicPlano.Parent;
                    picture.Size = new Size((int)(ImageWidth * Escala), (int)(ImageHeight * Escala));
                    if (PicPlano.Width < contenedor.Width && PicPlano.Location.X <= 0 && PicPlano.Location.Y <= 0)
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

            int imagenW = PicPlano.Image.Width;
            int imagenH = PicPlano.Image.Height;
            int pictureBoxW = PicPlano.Width;
            int pictureBoxH = PicPlano.Height;

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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!ModoEditar)
            {
                ModoEditar = true;
                LblEditar.Text = "Terminar";
                BtnEditar.Image = CB_Base.Properties.Resources.drawing;
            }
            else if (ModoEditar)
            {
                ModoEditar = false;
                LblEditar.Text = "Editar";
                BtnEditar.Image = CB_Base.Properties.Resources.Edit;
            }
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void BtnSizePicker_Click(object sender, EventArgs e)
        {
            FrmLineaTamano linea = new FrmLineaTamano();
            if (linea.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                GruesoLinea = linea.Linea;
        }

        private void BtnColorPicker_Click(object sender, EventArgs e)
        {
            DialogResult color = colorDialog1.ShowDialog();
            if (color == System.Windows.Forms.DialogResult.OK)
            {
                //ColorLinea = colorDialog1.Color;
                ColorLinea = Color.FromArgb(100, colorDialog1.Color);
                BtnColorPicker.BackColor = colorDialog1.Color;
            }
        }

        public void limpiar()
        {
            MemoryStream ms = new MemoryStream(PlanoImagen);
            Image img = Image.FromStream(ms);
            PicPlano.Image = img;
            ListaImagenes.Clear();
            UndoClick = false;

            string tempPath = Path.GetTempPath() + "AudiselDrawingTemp";
            if (File.Exists(tempPath))
                File.Delete(tempPath);
        }

#endregion

        private void CargarProcesos()
        {
            PlanoProceso planoProceso = new PlanoProceso();
            string filtro = "";

            if (Proceso == "INSPECCION DE FABRICACION")
                filtro = "INTERNA";
            else
                filtro = "PROVEEDOR";


            planoProceso.CargarDePlano(IdPlano).ForEach(delegate(Fila f)
            {
                if (Proceso != f.Celda("proceso").ToString())
                {
                    string tipo = string.Empty;

                    if(Convert.ToInt32(Global.ObjetoATexto(f.Celda("requisicion_compra"),"0")) > 0)
                        tipo = "PROVEEDOR";
                    else
                        tipo = "INTERNA";

                    if(filtro == tipo)
                        DgvProcesos.Rows.Add(f.Celda("id"), false, f.Celda("proceso"), "","","", tipo);
                }
            });

            if (DgvProcesos.Rows.Count > 0)
                DgvProcesos.ClearSelection();
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            
            DialogResult result =  MessageBox.Show("¿Estás seguro de rechazar la pieza?", "Rechazar pieza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;


            //12/13/2018 Clara Laborde
            BtnAceptar.Enabled = false;
            BtnRechazar.Enabled = false;

            Image img = PicPlano.Image as Image; 
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ImagenBytes = ms.ToArray();
            }

            if (!ImagenValida(ImagenBytes))
            {
                MessageBox.Show("Ha ocurrido un problema al tratar de crear la imagen de inspección, intente de nuevo", "Error al crear imagen de inspección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnRechazar.Enabled = true;
                return;
            }
              
            int checkCount = 0;
            foreach (DataGridViewRow row in DgvProcesos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check"].Value))
                {
                    string comentarios = row.Cells["comentario"].Value.ToString();
                    string cantidadOk =  row.Cells["cantidad_ok"].Value.ToString();
                    string cantidadNok = row.Cells["cantidad_nok"].Value.ToString();
                    string tipoNoConformidad = row.Cells["tipo"].Value.ToString();

                    if(comentarios == "" || cantidadOk == "" || cantidadNok == "")
                    {
                        MessageBox.Show("Favor de llenar la información de los procesos no conformes");
                        NoConformidades.Clear();
                        BtnRechazar.Enabled = true;
                        return;
                    }

                    Fila noConformidades = new Fila();
                    noConformidades.AgregarCelda("comentarios", comentarios);
                    noConformidades.AgregarCelda("cantidad_ok", cantidadOk);
                    noConformidades.AgregarCelda("cantidad_nok", cantidadNok);
                    noConformidades.AgregarCelda("proceso", row.Cells["id"].Value);
                    noConformidades.AgregarCelda("tipo", tipoNoConformidad);
                    NoConformidades.Add(noConformidades);
                    checkCount++;
                }
            }

            if (checkCount == 0)
            {
                MessageBox.Show("Si existe un rechazo debes seleccionar el proceso afectado.", "Seleccionar proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NoConformidades.Clear();
                BtnRechazar.Enabled = true;
                return;
            }

            Comentarios = TxtComentarios.Text;
            RechazarPlano = true;

            //metodo anterior posible falla al crear los bytes de la imagen 12/13/2018 Clara Laborde
            //ImageConverter _imageConverter = new ImageConverter();
            //ImagenBytes = (byte[])_imageConverter.ConvertTo(PicPlano.Image, typeof(byte[]));           

            if(Comentarios == "")
            {
                MessageBox.Show("Debes proporcionar un comentario de revisión", "Comentario de revisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NoConformidades.Clear();
                BtnRechazar.Enabled = true;
                return;
            }

            Progreso.Value = 0;
            Progreso.Visible = true;
            BkgSubirPlano.RunWorkerAsync();
            //DialogResult = System.Windows.Forms.DialogResult.OK;
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

        public void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("¿Estás seguro de aceptar la pieza?", "Aceptar pieza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                BtnAceptar.Enabled = false;
                BtnRechazar.Enabled = false;
                RechazarPlano = false;
                Aceptar = true;

                ImageConverter _imageConverter = new ImageConverter();
                ImagenBytes = (byte[])_imageConverter.ConvertTo(PicPlano.Image, typeof(byte[]));
                Comentarios = TxtComentarios.Text;
                if (Comentarios == "")
                {
                    MessageBox.Show("Debe hacer un comentario de revisión", "comentario de revisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnAceptar.Enabled = true;
                    BtnRechazar.Enabled = true;
                    return;
                }

                BkgSubirPlano.RunWorkerAsync();
            }
        }

        private void FrmInspeccionPiezaFabricada_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string tempPath = Path.GetTempPath() + "AudiselDrawingTemp";
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
            catch// (Exception ex)
            {
            }
        }

        private void DgvProcesos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 1 || DgvProcesos.SelectedRows.Count == 0)
                return;

            DgvCheckBox = Convert.ToBoolean(DgvProcesos.SelectedRows[0].Cells["check"].EditedFormattedValue);

            StrComentarios = DgvProcesos.SelectedRows[0].Cells["comentario"].Value.ToString();
            StrCantidadOk = DgvProcesos.SelectedRows[0].Cells["cantidad_ok"].Value.ToString();
            StrCantidadNok = DgvProcesos.SelectedRows[0].Cells["cantidad_nok"].Value.ToString();
            StrTipoNoConformidad = DgvProcesos.SelectedRows[0].Cells["tipo"].Value.ToString();

            if (DgvCheckBox)
            {
                FrmComentariosNoConformidad nc = new FrmComentariosNoConformidad(CantidadPiezas);
                if (nc.ShowDialog() == DialogResult.OK)
                {
                    DgvProcesos.SelectedRows[0].Cells["comentario"].Value = nc.Comentarios;
                    DgvProcesos.SelectedRows[0].Cells["cantidad_ok"].Value = nc.CantidadOk;
                    DgvProcesos.SelectedRows[0].Cells["cantidad_nok"].Value = nc.CantidadNoOk;
                }
                else
                {
                    DgvProcesos.SelectedRows[0].Cells["comentario"].Value = string.Empty;
                    DgvProcesos.SelectedRows[0].Cells["cantidad_ok"].Value = string.Empty;
                    DgvProcesos.SelectedRows[0].Cells["cantidad_nok"].Value = string.Empty;
                    DgvProcesos.CancelEdit();
                }
                BtnAceptar.Enabled = false;
            }
            else
            {
                foreach (DataGridViewRow fila in DgvProcesos.Rows)
                {
                    bool check = Convert.ToBoolean(fila.Cells["check"].Value);
                    BtnAceptar.Enabled = !check;
                }
            }
        }

        private void BkgSubirPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            string raizFtp = RaizFtp;
            string rutaParcialSinExtension = RutaParcialSinExtension;
            int idPlano = Convert.ToInt32(IdPlano);
            byte[] datosImagen = ImagenBytes;

            BkgSubirPlano.ReportProgress(40, "Conectando con servidor FTP... ");
            if (!ClienteFtp.IsConnected)
            {
                if (Global.TipoConexion == "LOCAL")
                    ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
                else
                    ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;

                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());

                // Verificar conexion con servidor FTP

                try
                {
                    ClienteFtp.Connect();
                }
                catch //(Exception ex)
                {
                    BkgDescargarPlano.ReportProgress(100, "Error de conexión con servidor FTP");
                    return;
                }
            }

            BkgSubirPlano.ReportProgress(40, "Conectando con servidor FTP... [OK]");

            //string[] subensamble = rutaParcialSinExtension.Split('-');
            string rutaRemotaImagenRevision = raizFtp + Subensamble + "\\CP\\" + idPlano + " " + rutaParcialSinExtension + "_INS.PNG";

            if (ClienteFtp.DirectoryExists(raizFtp + Subensamble + "\\CP"))
            {
                ClienteFtp.Upload((byte[])datosImagen, rutaRemotaImagenRevision, FtpExists.Overwrite);
            }
            else
            {
                ClienteFtp.CreateDirectory(raizFtp + Subensamble + "\\CP");
                ClienteFtp.Upload((byte[])datosImagen, rutaRemotaImagenRevision, FtpExists.Overwrite);
            }
            BkgSubirPlano.ReportProgress(40, "Subiendo imagen...");

            if (ClienteFtp.FileExists(raizFtp + Subensamble + "\\CP\\" + idPlano + " " + rutaParcialSinExtension + "_INS.PNG"))
                ImagenSubida = true;
        }

        private void BkgSubirPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progreso.Visible = false;
            //BtnAceptar.Enabled = true;
            //BtnRechazar.Enabled = true;

            if (ImagenSubida)
            {
                TxtEstatus.Text = "Imagen subida " + IdPlano + " " + RutaParcialSinExtension + "_INS.PNG";

                //Cambiar estatus del proceso de inspeccion
                PlanoProceso proceso = new PlanoProceso();
                proceso.CargarDatos(IdProceso);
                if (proceso.TieneFilas())
                {
                    proceso.Fila().ModificarCelda("maquina", "LABORATORIO DE CALIDAD");
                    proceso.Fila().ModificarCelda("operador", Global.UsuarioActual.NombreCompleto());
                    proceso.Fila().ModificarCelda("estatus", "TERMINADO");
                    proceso.Fila().ModificarCelda("fecha_inicio", DateTime.Now);
                    proceso.Fila().ModificarCelda("fecha_termino", DateTime.Now);
                    proceso.GuardarDatos();
                }

                // MessageBox.Show();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                TxtEstatus.Text = "La imagen " + IdPlano + " " + RutaParcialSinExtension + "_INS.PNG no pudo ser subida al servidor";
                if (!Aceptar)
                    BtnRechazar.Enabled = true;
                else
                {
                    BtnAceptar.Enabled = true;
                    BtnRechazar.Enabled = true;
                }
                //MessageBox.Show();
            }
        }

        private void BkgSubirPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtEstatus.Text = (e.UserState.ToString());
            TxtComentarios.Refresh();
            Progreso.Value = e.ProgressPercentage;
            Progreso.Refresh();
        }
    }
}

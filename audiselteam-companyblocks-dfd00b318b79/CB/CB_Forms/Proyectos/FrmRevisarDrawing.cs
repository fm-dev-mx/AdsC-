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
using System.Text.RegularExpressions;
using SolidWorks.Interop.swconst;

namespace CB
{
    public partial class FrmRevisarDrawing : Form
    {
        SolidWorksProyecto ListaParteYDrawing = new SolidWorksProyecto();
        SolidWorksAPI SW = null;
        Dictionary<string, string> CustomProperties = new Dictionary<string, string>();
        FtpClient ClienteFtp = new FtpClient();
        Decimal Proyecto;
        string PathParteCarpetaTemporal = string.Empty;
        string PathDrawingCarpetaTemporal = string.Empty;
        string NombreArchivoSinExtension = "";
        string RutaParcialSinExtension = "";
        string ErrorGuardandoImagen = "";
        string RaizFtp = string.Empty;
        byte[] PlanoImagen;
        bool PlanoDescargado = false;
        bool CerrarSesionSW = false;
        int CustomPropertiesInvalidas = 0;
        int IdDrawing = 0;

        Fila Parte = null;
        Fila Drawing = null;

        //pintar y mover imagen
        List<byte[]> ListaImagenes = new List<byte[]>();
        Point UltimoPunto = Point.Empty;
        Color ColorLinea = Color.Black;
        bool UndoClick = false;
        bool MouseClickMover = new Boolean();
        bool ModoEditar = false;
        int GruesoLinea = 8;

        //zoom in out
        float Escala = 1.0f;
        bool Editar = false;
        int ImageWidth, ImageHeight;
        int imgWEscalado, imgHEscalado;

        public FrmRevisarDrawing(decimal proyecto, int subensamble, string nombreArchivo, SolidWorksAPI sw=null)
        {
            InitializeComponent();
            
            SW = sw;
            MouseWheel += new MouseEventHandler(PicPlano_MouseWheel);
            KeyPreview = true;
            KeyDown += FrmRevisarDrawing_KeyDown;

            Proyecto = proyecto;
            NombreArchivoSinExtension = Path.GetFileNameWithoutExtension(nombreArchivo);

            string nombreSubensamblePrincipal = "M" + proyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0') + "-" + subensamble.ToString().PadLeft(2, '0');

            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);

            string condiciones = "";
            condiciones += "proyecto=@proyecto AND subensamble=@subensamble AND ";
            condiciones += "(nombre_archivo LIKE '%" + NombreArchivoSinExtension + ".%')";
 
            ListaParteYDrawing.SeleccionarDatos(condiciones, parametros);

            ListaParteYDrawing.Filas().ForEach(delegate(Fila f)
            {
                string extensionArchivo = Path.GetExtension(f.Celda("nombre_archivo").ToString()).ToUpper();

                if( extensionArchivo == ".SLDPRT" || extensionArchivo == ".SLDASM" )
                    Parte = f;
                else if ( extensionArchivo == ".SLDDRW" )
                {
                    Drawing = f;
                    IdDrawing = Convert.ToInt32(f.Celda("id"));
                }
            });
            if (Parte != null)
                RutaParcialSinExtension = Path.ChangeExtension(Parte.Celda("nombre_archivo").ToString(), null);
        }

        private void FrmRevisarDrawing_Load(object sender, EventArgs e)
        {
            string strProyecto = Proyecto.ToString("F2").PadLeft(6, '0').Replace(".", "_");
            RaizFtp = strProyecto + "/M" + strProyecto + "/";

            SplitEstatus.Panel1Collapsed = true;
            BkgDescargarPlano.RunWorkerAsync();
            Editar = false;
            BtnSalir.Enabled = false;
        }

        private void FrmRevisarDrawing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SW != null && CerrarSesionSW)
                SW.Terminar();

            try
            {
                string tempPath = Path.GetTempPath() + "AudiselDrawingTemp";
                if (File.Exists(tempPath))
                    File.Delete(tempPath);

                File.Delete(PathDrawingCarpetaTemporal);
                File.Delete(PathParteCarpetaTemporal);
            }
            catch// (Exception ex)
            {
            }
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
                BkgDescargarPlano.ReportProgress(40, "[OK]" + System.Environment.NewLine);
            }
            catch (Exception ex)
            {
                BkgDescargarPlano.ReportProgress(100, "[ERROR]" + Environment.NewLine + ex.ToString() + Environment.NewLine);
                return;
            }

            BkgDescargarPlano.ReportProgress(20, "Conectando con SolidWorks... ");
            if (SW == null)
            {
                SW = new SolidWorksAPI();
                CerrarSesionSW = true;
            }

            if(SW.Aplicacion == null)
            {
                BkgDescargarPlano.ReportProgress(100, "[ERROR]" + Environment.NewLine);
                return;
            }
            else
                BkgDescargarPlano.ReportProgress(100, "[OK]" + Environment.NewLine);

            // iteramos por las filas encontradas en el indice que corresponden con el nombre de archivo sin extension
            int i = 1;
            ListaParteYDrawing.Filas().ForEach(delegate(Fila f)
            {
                // descargamos el archivo a la carpeta temporal
                string archivoRemoto = f.Celda("nombre_archivo").ToString();
                string archivoLocal = Path.GetTempPath() + Path.GetFileName(archivoRemoto);
                BkgDescargarPlano.ReportProgress(40 + (i * 10), "Descargando archivo '" + archivoRemoto + "'... ");
                ClienteFtp.DownloadFile(archivoLocal, RaizFtp + archivoRemoto, true, FtpVerify.Retry);
               
                BkgDescargarPlano.ReportProgress(40 + (i * 10), "[OK]" + Environment.NewLine);

                if (Path.GetExtension(archivoLocal).ToUpper() == ".SLDDRW")
                    PathDrawingCarpetaTemporal = archivoLocal;
                else if (Path.GetExtension(archivoLocal).ToUpper() == ".SLDPRT")
                    PathParteCarpetaTemporal = archivoLocal;
                else if (Path.GetExtension(archivoLocal).ToUpper() == ".SLDASM")
                    PathParteCarpetaTemporal = archivoLocal;

                i++;
            });
            // Si existe el archivo cache de la imagen, lo descargamos para mostrarlo en el picturebox
            // En caso contrario:
            //    - convertimos a pdf
            //    - convertimos a imagen
            //    - convertimos a imagen miniatura
            // Luego enviamos los archivos a la carpeta ftp
            if (ClienteFtp.FileExists(RaizFtp + RutaParcialSinExtension + ".PNG"))
            {
                BkgDescargarPlano.ReportProgress(80, "Descargando imagen... ");
                PlanoImagen = null;
                ClienteFtp.Download(out PlanoImagen, RaizFtp + RutaParcialSinExtension + ".PNG");
                BkgDescargarPlano.ReportProgress(80, "[OK]" + Environment.NewLine);
                MemoryStream ms = new MemoryStream(PlanoImagen);
                Image img = Image.FromStream(ms);
                PicPlano.Image = img;
                ListaImagenes.Add(PlanoImagen);
            }
            else if (PathDrawingCarpetaTemporal != string.Empty)
            {
                // convertir drawing de solidworks a pdf
                byte[] planoPDF;

                BkgDescargarPlano.ReportProgress(70, "Convirtiendo archivo a PDF... ");

                try
                {
                    SW.DrawingAPDF(PathDrawingCarpetaTemporal, out planoPDF);
                }
                catch (Exception ex)
                {
                    BkgDescargarPlano.ReportProgress(100, "[ERROR]" + Environment.NewLine + ex.ToString() + Environment.NewLine);
                    return;
                }
                BkgDescargarPlano.ReportProgress(70, "[OK]" + Environment.NewLine);
                //BkgDescargarPlano.ReportProgress(75, "Extrayendo vista isométrica... ");
                //try
                //{
                //    swDocumentTypes_e tipoParte = swDocumentTypes_e.swDocNONE;

                //    if (Path.GetExtension(PathParteCarpetaTemporal).ToUpper() == ".SLDPRT")
                //        tipoParte = swDocumentTypes_e.swDocPART;
                //    else if (Path.GetExtension(PathParteCarpetaTemporal).ToUpper() == ".SLDASM")
                //        tipoParte = swDocumentTypes_e.swDocASSEMBLY;

                //    //generar vista isometrica a partir del solido
                //    SW.VistaPrevia(PathParteCarpetaTemporal, tipoParte, out vistaIsometrica);
                //}
                //catch
                //{
                //    BkgDescargarPlano.ReportProgress(100, "[ERROR AL GENERAR VISTA ISOMETRICA]" + Environment.NewLine);
                //    return;
                ////}
                //BkgDescargarPlano.ReportProgress(75, "[OK]" + Environment.NewLine);
                //ClienteFtp.Upload(vistaIsometrica, RaizFtp + RutaParcialSinExtension + "_ISO.PNG", FtpExists.Overwrite);

                // convertir pdf a imagen
                string pathPdfTemp = Path.GetTempFileName();
                try
                {
                    if (File.Exists(pathPdfTemp))
                    {
                        File.Delete(pathPdfTemp);
                    }
                    File.WriteAllBytes(pathPdfTemp, planoPDF);
                }
                catch(Exception ex)
                {
                    BkgDescargarPlano.ReportProgress(80, ex.ToString());
                }


                BkgDescargarPlano.ReportProgress(80, "Convirtiendo PDF a imagen... ");
                try
                {
                    PlanoImagen = FormatosPDF.MiniaturaPDF(pathPdfTemp, 0, 0, 150);
                    BkgDescargarPlano.ReportProgress(80, "[OK]" + Environment.NewLine);
                }
                catch(Exception ex)
                {
                    BkgDescargarPlano.ReportProgress(80, ex.ToString());
                }


                // enviar archivos a carpeta ftp
                try
                {
                    BkgDescargarPlano.ReportProgress(90, "Subiendo imaganes a servidor...");
                    ClienteFtp.Upload(PlanoImagen, RaizFtp + RutaParcialSinExtension + ".PNG");
                    ClienteFtp.Upload(planoPDF, RaizFtp + RutaParcialSinExtension + ".PDF");
                    ClienteFtp.Upload(CrearMiniatura(PlanoImagen), RaizFtp + RutaParcialSinExtension + "_MIN.PNG");
                    BkgDescargarPlano.ReportProgress(90, "[OK]" + Environment.NewLine);
                }
                catch(Exception ex)
                {
                    BkgDescargarPlano.ReportProgress(90, ex.ToString());
                }

               /* // mostrar la imagen en el picturebox
                MemoryStream ms = new MemoryStream(PlanoImagen);
                Image img = Image.FromStream(ms);
                PicPlano.Image = img;
                ListaImagenes.Add(PlanoImagen);*/
            }
            PlanoDescargado = true;
        }

        private void BkgDescargarPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtEstatus.AppendText(e.UserState.ToString());
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgDescargarPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(PlanoDescargado)
            {
                // mostrar la imagen en el picturebox
                MemoryStream ms = new MemoryStream(PlanoImagen);
                Image img = Image.FromStream(ms);
                PicPlano.Image = img;
                ListaImagenes.Add(PlanoImagen);

                SplitEstatus.Panel1Collapsed = false;
                SplitEstatus.Panel2Collapsed = true;
                WindowState = FormWindowState.Maximized;
                BkgDescargarCP.RunWorkerAsync();
            }
            else
            {
                string msg = "Ocurrio un error al descargar los archivos.";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void vistaGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicPlano.Dock = DockStyle.Fill;
            PicPlano.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void vistaDetalladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicPlano.Dock = DockStyle.None;
            PicPlano.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtComentarios.Text != string.Empty && CustomPropertiesInvalidas == 0) || Global.UsuarioActual.Fila().Celda("rol").ToString() == "SUPERUSER";
            BtnRechazar.Enabled = TxtComentarios.Text != string.Empty;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres aceptar este plano?", "Aceptar plano", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            // cargamos el drawing
            SolidWorksProyecto drw = new SolidWorksProyecto();
            drw.CargarDatos(IdDrawing);

            // si el drawing fue encontrado
            if(drw.TieneFilas())
            {
                // asignamos los datos basicos del drawing
                drw.Fila().ModificarCelda("estatus_revision", "ACEPTADO");
                drw.Fila().ModificarCelda("estatus_aprobacion", "PENDIENTE");
                drw.Fila().ModificarCelda("comentarios_revision", TxtComentarios.Text);
                drw.Fila().ModificarCelda("usuario_revision", Global.UsuarioActual.NombreCompleto());
                drw.Fila().ModificarCelda("fecha_revision", DateTime.Now);
                drw.GuardarDatos();

                // busca si el drawing ya tiene vinculadas custom properties en la base de datos y
                // las borra para no duplicar
                SolidworksCp propiedades = new SolidworksCp();
                propiedades.SeleccionarDrawing(Convert.ToInt32(drw.Fila().Celda("id")));
                if(propiedades.TieneFilas())
                {
                    propiedades.BorrarDatos();
                }

                // creamos e insertamos la fila de las nuevas custom properties
                Fila cp = new Fila();
                cp.AgregarCelda("drawing", drw.Fila().Celda("id"));

                if(CustomProperties.ContainsKey("MATERIAL"))
                    cp.AgregarCelda("MATERIAL", CustomProperties["MATERIAL"]);
                if(CustomProperties.ContainsKey("TREATMENT"))
                    cp.AgregarCelda("TREATMENT", CustomProperties["TREATMENT"]);
                if(CustomProperties.ContainsKey("THICKNESS"))
                    cp.AgregarCelda("THICKNESS", CustomProperties["THICKNESS"]);
                if (CustomProperties.ContainsKey("WIDTH"))
                    cp.AgregarCelda("WIDTH", CustomProperties["WIDTH"]);
                if (CustomProperties.ContainsKey("LENGTH"))
                    cp.AgregarCelda("LENGTH", CustomProperties["LENGTH"]);
                if (CustomProperties.ContainsKey("CYL DIA"))
                    cp.AgregarCelda("CYL_DIA", CustomProperties["CYL DIA"]);
                if (CustomProperties.ContainsKey("CYL LENGTH"))
                    cp.AgregarCelda("CYL_LENGTH", CustomProperties["CYL LENGTH"]);
                if (CustomProperties.ContainsKey("FINISH"))
                    cp.AgregarCelda("FINISH", CustomProperties["FINISH"]);
                if (CustomProperties.ContainsKey("HARDNESS"))
                    cp.AgregarCelda("HARDNESS", CustomProperties["HARDNESS"]);
                if (CustomProperties.ContainsKey("QTY"))
                    cp.AgregarCelda("QTY", CustomProperties["QTY"]);
                if (CustomProperties.ContainsKey("WORK TYPE"))
                    cp.AgregarCelda("WORK_TYPE", CustomProperties["WORK TYPE"]);
                if (CustomProperties.ContainsKey("DESIGNED BY"))
                    cp.AgregarCelda("DESIGNED_BY", CustomProperties["DESIGNED BY"]);
                if (CustomProperties.ContainsKey("DRAWN BY"))
                    cp.AgregarCelda("DRAWN_BY", CustomProperties["DRAWN BY"]);
                if (CustomProperties.ContainsKey("REVIEWED BY"))
                    cp.AgregarCelda("REVIEWED_BY", CustomProperties["REVIEWED BY"]);
                if (CustomProperties.ContainsKey("APPROVED BY"))
                    cp.AgregarCelda("APPROVED_BY", CustomProperties["APPROVED BY"]);
                if (CustomProperties.ContainsKey("DESCRIPTION"))
                    cp.AgregarCelda("DESCRIPTION", CustomProperties["DESCRIPTION"]); 
                if (CustomProperties.ContainsKey("PROJECT NUMBER"))
                    cp.AgregarCelda("PROJECT_NUMBER", CustomProperties["PROJECT NUMBER"]);

                propiedades.Insertar(cp);
                ImageConverter converter = new ImageConverter();

                if (ClienteFtp.FileExists(RaizFtp + RutaParcialSinExtension + "_REV.PNG"))
                    ClienteFtp.DeleteFile(RaizFtp + RutaParcialSinExtension + "_REV.PNG");

                ClienteFtp.Upload((byte[])converter.ConvertTo(PicPlano.Image, typeof(byte[])), RaizFtp + RutaParcialSinExtension + "_REV.PNG");

                if (ClienteFtp.FileExists(RaizFtp + RutaParcialSinExtension + "_MIN.PNG"))
                    ClienteFtp.DeleteFile(RaizFtp + RutaParcialSinExtension + "_MIN.PNG");

                ClienteFtp.Upload(CrearMiniatura((byte[])converter.ConvertTo(PicPlano.Image, typeof(byte[]))), RaizFtp + RutaParcialSinExtension + "_MIN.PNG");
                
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("El plano no fue encontrado", "Plano no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres rechazar este plano?", "Rechazar plano", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            SolidWorksProyecto drw = new SolidWorksProyecto();
            drw.CargarDatos(IdDrawing);

            if (drw.TieneFilas())
            {
                drw.Fila().ModificarCelda("estatus_revision", "RECHAZADO");
                drw.Fila().ModificarCelda("comentarios_revision", TxtComentarios.Text);
                drw.Fila().ModificarCelda("usuario_revision", Global.UsuarioActual.NombreCompleto());
                drw.Fila().ModificarCelda("fecha_revision", DateTime.Now);
                drw.GuardarDatos();

                DialogResult = DialogResult.OK;

                ErrorGuardandoImagen = "";
                Cursor = Cursors.WaitCursor;
                BtnSalir.Enabled = false;
                BkgGuardarImagen.RunWorkerAsync();             
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BkgDescargarCP_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!File.Exists(PathParteCarpetaTemporal))
                return;
            SW.ExtraerPropiedadesParte(PathParteCarpetaTemporal, out CustomProperties);
        }

        private void BkgDescargarCP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // MATERIAL
            if(CustomProperties.ContainsKey("MATERIAL"))
                DgvCustomProperties.Rows.Add("MATERIAL", CustomProperties["MATERIAL"]);
            else
                DgvCustomProperties.Rows.Add("MATERIAL", "NO EXISTE");
            if (!ValidarCustomProperty())
                CustomPropertiesInvalidas++;

            bool piezaCilindrica = false;

            // CYL DIA
            if (CustomProperties.ContainsKey("CYL DIA"))
            {
                DgvCustomProperties.Rows.Add("CYL DIA", CustomProperties["CYL DIA"]);
                piezaCilindrica = true;
            }
            else
            {
                DgvCustomProperties.Rows.Add("CYL DIA", "NO EXISTE");
                piezaCilindrica = false;
            }
            if(!ValidarCustomProperty(piezaCilindrica))
                CustomPropertiesInvalidas++;

            // CYL LENGTH
            if (CustomProperties.ContainsKey("CYL LENGTH"))
            {
                DgvCustomProperties.Rows.Add("CYL LENGTH", CustomProperties["CYL LENGTH"]);
                piezaCilindrica = true;
            }
            else
            {
                DgvCustomProperties.Rows.Add("CYL LENGTH", "NO EXISTE");
                piezaCilindrica = false;
            }
            if (!ValidarCustomProperty(piezaCilindrica))
                CustomPropertiesInvalidas++;

            //THICKNESS
            if (CustomProperties.ContainsKey("THICKNESS"))
                DgvCustomProperties.Rows.Add("THICKNESS", CustomProperties["THICKNESS"]);
            else
                DgvCustomProperties.Rows.Add("THICKNESS", "NO EXISTE");
            if (!ValidarCustomProperty(!piezaCilindrica))
                CustomPropertiesInvalidas++;

            //WIDTH
            if (CustomProperties.ContainsKey("WIDTH"))
                DgvCustomProperties.Rows.Add("WIDTH", CustomProperties["WIDTH"]);
            else
                DgvCustomProperties.Rows.Add("WIDTH", "NO EXISTE");
            if (!ValidarCustomProperty(!piezaCilindrica))
                CustomPropertiesInvalidas++;

            //LENGTH 
            if (CustomProperties.ContainsKey("LENGTH"))
                DgvCustomProperties.Rows.Add("LENGTH", CustomProperties["LENGTH"]);
            else
                DgvCustomProperties.Rows.Add("LENGTH", "NO EXISTE");
            if (!ValidarCustomProperty(!piezaCilindrica))
                CustomPropertiesInvalidas++;

            //FINISH 
            if (CustomProperties.ContainsKey("FINISH"))
                DgvCustomProperties.Rows.Add("FINISH", CustomProperties["FINISH"]);
            else
                DgvCustomProperties.Rows.Add("FINISH", "NO EXISTE");
            if (!ValidarCustomProperty(false))
                CustomPropertiesInvalidas++;

            //HARDNESS
            if (CustomProperties.ContainsKey("HARDNESS"))
                DgvCustomProperties.Rows.Add("HARDNESS", CustomProperties["HARDNESS"]);
            else
                DgvCustomProperties.Rows.Add("HARDNESS", "NO EXISTE");
            if (!ValidarCustomProperty(false))
                CustomPropertiesInvalidas++;

            //QTY
            if (CustomProperties.ContainsKey("QTY"))
                DgvCustomProperties.Rows.Add("QTY", CustomProperties["QTY"]);
            else
                DgvCustomProperties.Rows.Add("QTY", "NO EXISTE");
            if (!ValidarCustomProperty())
                CustomPropertiesInvalidas++;

            //WORK TYPE
            if (CustomProperties.ContainsKey("WORK TYPE"))
                DgvCustomProperties.Rows.Add("WORK TYPE", CustomProperties["WORK TYPE"]);
            else
                DgvCustomProperties.Rows.Add("WORK TYPE", "NO EXISTE");
            if (!ValidarCustomProperty())
                CustomPropertiesInvalidas++;

            //DESIGNED BY
            if (CustomProperties.ContainsKey("DESIGNED BY"))
                DgvCustomProperties.Rows.Add("DESIGNED BY", CustomProperties["DESIGNED BY"]);
            else
                DgvCustomProperties.Rows.Add("DESIGNED BY", "NO EXISTE");
            if (!ValidarCustomProperty())
                CustomPropertiesInvalidas++;

            //DRAWN BY
            if (CustomProperties.ContainsKey("DRAWN BY"))
                DgvCustomProperties.Rows.Add("DRAWN BY", CustomProperties["DRAWN BY"]);
            else
                DgvCustomProperties.Rows.Add("DRAWN BY", "NO EXISTE");
            if (!ValidarCustomProperty())
                CustomPropertiesInvalidas++;

            //APPROVED BY
            if (CustomProperties.ContainsKey("APPROVED BY"))
                DgvCustomProperties.Rows.Add("APPROVED BY", CustomProperties["APPROVED BY"]);
            else
                DgvCustomProperties.Rows.Add("APPROVED BY", "NO EXISTE");
            if (!ValidarCustomProperty())
                CustomPropertiesInvalidas++;

            //REVIEWED BY
            if (CustomProperties.ContainsKey("REVIEWED BY"))
                DgvCustomProperties.Rows.Add("REVIEWED BY", CustomProperties["REVIEWED BY"]);
            else
                DgvCustomProperties.Rows.Add("REVIEWED BY", "NO EXISTE");
            if (!ValidarCustomProperty())
                CustomPropertiesInvalidas++;

            //DESCRIPTION
            if (CustomProperties.ContainsKey("DESCRIPTION"))
                DgvCustomProperties.Rows.Add("DESCRIPTION", CustomProperties["DESCRIPTION"]);
            else
                DgvCustomProperties.Rows.Add("DESCRIPTION", "NO EXISTE");
            if (!ValidarCustomProperty(false))
                CustomPropertiesInvalidas++;

            //PROJECT NUMBER            
            if (CustomProperties.ContainsKey("PROJECT NUMBER"))
                DgvCustomProperties.Rows.Add("PROJECT NUMBER", CustomProperties["PROJECT NUMBER"]);
            else
                DgvCustomProperties.Rows.Add("PROJECT NUMBER", "NO EXISTE");
            if (!ValidarCustomProperty(false))
                CustomPropertiesInvalidas++;

            if(CustomPropertiesInvalidas == 0)
            {
                TxtComentarios.Enabled = true;
                TxtComentarios.ReadOnly = false;
            }
            else
            {
                TxtComentarios.Text = CustomPropertiesInvalidas + " CUSTOM PROPERTIES INCOMPLETAS O INVALIDAS";
            }
            BtnSalir.Enabled = true;
        }

        public bool ValidarCustomProperty(bool obligatoria=true)
        {
            DataGridViewCell celda = DgvCustomProperties.Rows[DgvCustomProperties.Rows.Count - 1].Cells["valor"];
            string valor = celda.Value.ToString();

            if (!obligatoria || (obligatoria && valor != "NO EXISTE" && valor.Trim() != string.Empty) )
            {
                celda.Style.BackColor = Color.LightGreen;
                celda.Style.ForeColor = Color.Black;
                return true;
            }
            else
            {
                celda.Style.BackColor = Color.Red;
                celda.Style.ForeColor = Color.White;
                return false;
            }
        }

        private void BtnComentarios_Click(object sender, EventArgs e)
        {
            SolidWorksProyecto drw = new SolidWorksProyecto();
            drw.CargarDatos(IdDrawing);
            
            if (drw.TieneFilas())
            {
                FrmComentariosRevisionDrawing comentarios = new FrmComentariosRevisionDrawing(Convert.ToInt32(drw.Fila().Celda("id")));
                comentarios.Show();
            }
            else
            {
                MessageBox.Show("Error: el drawing no fue encontrado!", "Drawing no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //paint 
        void FrmRevisarDrawing_KeyDown(object sender, KeyEventArgs e)
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

        private void PicPlano_MouseWheel(object sender, MouseEventArgs e)
        {
            if(!Editar)
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

        private void PicPlano_MouseMove(object sender, MouseEventArgs e)
        {
            if(ModoEditar)
                Dibujar(e, PicPlano);

            MoverPictureBox(e, PicPlano);
        }

        private void PicPlano_MouseUp(object sender, MouseEventArgs e)
        {
            MouseClickMover = false;
            UltimoPunto = Point.Empty;
            CrearLista(e);
            Cursor = Cursors.Default;
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

        private void BtnColorPicker_Click(object sender, EventArgs e)
        {
            DialogResult color =  colorDialog1.ShowDialog();
            if (color == System.Windows.Forms.DialogResult.OK)
            {
                //ColorLinea = colorDialog1.Color;
                ColorLinea = Color.FromArgb(100, colorDialog1.Color);
                BtnColorPicker.BackColor = colorDialog1.Color;
            }
        }

        private void BtnSizePicker_Click(object sender, EventArgs e)
        {
            FrmLineaTamano linea = new FrmLineaTamano();
            if (linea.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                GruesoLinea = linea.Linea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void BkgGuardarImagen_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!ClienteFtp.IsConnected)
            {
                ErrorGuardandoImagen = "Error de conexión con el servidor FTP";
                return;
            }

            string rutaRemotaImagenRevision = RaizFtp + RutaParcialSinExtension + "_REV.PNG";
            string rutaRemotaImagenMiniatura = RaizFtp + RutaParcialSinExtension + "_MIN.PNG";
   
            ImageConverter converter = new ImageConverter();
            ClienteFtp.Upload((byte[])converter.ConvertTo(PicPlano.Image, typeof(byte[])), rutaRemotaImagenRevision, FtpExists.Overwrite);

            ClienteFtp.Upload(CrearMiniatura((byte[])converter.ConvertTo(PicPlano.Image, typeof(byte[]))), rutaRemotaImagenMiniatura, FtpExists.Overwrite);
        }

        public byte[] CrearMiniatura(byte[] imagen, int width = 264, int height = 204)
        {
            using (var stream = new System.IO.MemoryStream(imagen))
            {
                var img = Image.FromStream(stream);
                var thumbnail = img.GetThumbnailImage(width, height, () => false, IntPtr.Zero);

                using (var thumbStream = new System.IO.MemoryStream())
                {
                    thumbnail.Save(thumbStream, System.Drawing.Imaging.ImageFormat.Png);
                    return thumbStream.GetBuffer();
                }
            }
        } 

        private void BkgGuardarImagen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            BtnSalir.Enabled = true;
            if (ClienteFtp.FileExists(RaizFtp + RutaParcialSinExtension + "_REV.PNG"))          
                Close();
            else
                MessageBox.Show("La imagen '" + RutaParcialSinExtension + "' no pudo ser guardada de forma correcta, intente de nuevo, si el error continua contacte al administrador del sistema." + Environment.NewLine + ErrorGuardandoImagen, "Error al guardar la imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if(!ModoEditar)
            {
                ModoEditar = true;
                LblEditar.Text = "Terminar";
                BtnEditar.Image = CB_Base.Properties.Resources.drawing;
            }
            else if(ModoEditar)
            {
                ModoEditar = false;
                LblEditar.Text = "Editar";
                BtnEditar.Image = CB_Base.Properties.Resources.Edit;
            }
        }        
    }
}

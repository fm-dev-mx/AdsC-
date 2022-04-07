using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using iTextSharp.tool.xml;
using System.IO;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.parser;
using System.Text.RegularExpressions;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmProcesoManufactura2 : Form
    {
        int IdProducto = 0;
        int IdCotizacion = 0;
        bool ListaActiva = false;
        string PathRemoto = string.Empty;
        FrmEditarCotizacion2 FormPadre = null;

        public FrmProcesoManufactura2(int idProducto, int idCotizacion, string pathRemoto, FrmEditarCotizacion2 formPadre)
        {
            InitializeComponent();
            IdProducto = idProducto;
            IdCotizacion = idCotizacion;
            PathRemoto = pathRemoto;
            FormPadre = formPadre;
        }

        private void FrmProcesoManufactura2_Load(object sender, EventArgs e)
        {
            CambiarTamanoEntradas();
            CambiarTamanoSalidas();
            CambiarTamanoModelos();

            CargarEntradas();
            CargarSalidas();
            CargarModelos();

            LblEstatus.Visible = false;
            Progress.Visible = false;

            //descargar descripcion
            byte[]  byteRichText = DescargarRTF(PathRemoto + "\\DESCRIPCION\\");
            if (byteRichText != null)
            {
                string originalRtf = System.Text.Encoding.UTF8.GetString(byteRichText);
                RtfDescripcion.Rtf = originalRtf;
            }
        }

        public byte[] DescargarRTF(string pathRemoto)
        {
            return ServidorFtp.DescargarArchivo(IdCotizacion, FormatoArchivo.Rtf, pathRemoto);
        }

        private void CambiarTamanoEntradas()
        {
            int width = this.Size.Width / 3;
            int height = DgvEntradas.Height;//this.Size.Height - panel1.Size.Height;
            DgvEntradas.Size = new Size(width, height);
            DgvEntradas.Location = new Point(0, audiselTituloForm1.Size.Height);
        }

        private void CambiarTamanoSalidas()
        {
            int width = this.Size.Width / 3;
            int height = DgvSalidas.Height;//this.Size.Height - panel1.Size.Height;
            DgvSalidas.Size = new Size(width, height);
            DgvSalidas.Location = new Point((DgvEntradas.Width + 1), audiselTituloForm1.Size.Height);
        }

        private void CambiarTamanoModelos()
        {
            int width = this.Size.Width / 3;
            int height = DgvModelos.Height;//this.Size.Height - panel1.Size.Height;
            DgvModelos.Size = new Size(width, height);
            DgvModelos.Location = new Point((this.Width - width + 2), audiselTituloForm1.Size.Height);
        }

        private void CambiarColorALetra(Color color)
        {
            RtfDescripcion.SelectionColor = color;
        }

        private void TsbBold_Click(object sender, EventArgs e)
        {
            ActivarEstilo(FontStyle.Bold);
        }

        private void TsbItalika_Click(object sender, EventArgs e)
        {
            ActivarEstilo(FontStyle.Italic);

        }

        private void TsbSubrayar_Click(object sender, EventArgs e)
        {
            ActivarEstilo(FontStyle.Underline);

        }

        private void ActivarEstilo(FontStyle estilo)
        {
            RtfDescripcion.SelectionFont = new System.Drawing.Font(
                RtfDescripcion.SelectionFont, RtfDescripcion.SelectionFont.Style ^ estilo
                );
        }

        private void CargarEntradas()
        {
            DgvEntradas.Rows.Clear();
            ProductoComponente componentes = new ProductoComponente();
            componentes.SeleccionarComponentesParaEntradasProducto(IdProducto, IdCotizacion).ForEach(delegate(Fila f)
            {
                bool checkComponente = false;

                CotizacionComponenteEntrada cotizacionComponenteEntrada = new CotizacionComponenteEntrada();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idComponente", f.Celda<int>("id"));
                parametros.Add("@idCotizacion", IdCotizacion);
                cotizacionComponenteEntrada.SeleccionarDatos("id_componente=@idComponente AND id_cotizacion=@idCotizacion", parametros);

                if (cotizacionComponenteEntrada.TieneFilas())
                    checkComponente = true;

                DgvEntradas.Rows.Add
                (
                    f.Celda("id"),
                    checkComponente,
                    f.Celda("nombre").ToString(),
                    "COMPONENTE"
                );
            });

            ProductoSubensamble subensambles = new ProductoSubensamble();
            subensambles.SeleccionarSubensamblesEntradasProducto(IdProducto, IdCotizacion).ForEach(delegate(Fila f)
            {
                bool CheckSubensamble = false;

                CotizacionSubensambleEntrada cotizacionComponenteEntrada = new CotizacionSubensambleEntrada();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idSubensamble", f.Celda<int>("id"));
                parametros.Add("@idCotizacion", IdCotizacion);
                cotizacionComponenteEntrada.SeleccionarDatos("id_subensamble=@idSubensamble AND id_cotizacion=@idCotizacion", parametros);

                if (cotizacionComponenteEntrada.TieneFilas())
                    CheckSubensamble = true;

                DgvEntradas.Rows.Add
                (
                    f.Celda("id"),
                    CheckSubensamble,
                    f.Celda("nombre").ToString(),
                    "SUBENSAMBLE"
                );
            });
        }

        private void CargarSalidas()
        {
            DgvSalidas.Rows.Clear();
            ProductoComponente componentes = new ProductoComponente();
            componentes.SeleccionarComponentesParaSalidasProducto(IdProducto, IdCotizacion).ForEach(delegate(Fila f)
            {
                bool checkComponente = false;

                CotizacionComponenteSalida cotizacionComponenteEntrada = new CotizacionComponenteSalida();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idComponente", f.Celda<int>("id"));
                parametros.Add("@idCotizacion", IdCotizacion);
                cotizacionComponenteEntrada.SeleccionarDatos("id_componente=@idComponente AND id_cotizacion=@idCotizacion", parametros);

                if (cotizacionComponenteEntrada.TieneFilas())
                    checkComponente = true;

                DgvSalidas.Rows.Add
                (
                    f.Celda("id"),
                    checkComponente,
                    f.Celda("nombre").ToString(),
                    "COMPONENTE"
                );
            });

            ProductoSubensamble subensambles = new ProductoSubensamble();
            subensambles.SeleccionarSubensamblesSalidasProducto(IdProducto, IdCotizacion).ForEach(delegate(Fila f)
            {
                bool CheckSubensamble = false;

                CotizacionSubensambleSalida cotizacionComponenteEntrada = new CotizacionSubensambleSalida();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idSubensamble", f.Celda<int>("id"));
                parametros.Add("@idCotizacion", IdCotizacion);
                cotizacionComponenteEntrada.SeleccionarDatos("id_subensamble=@idSubensamble AND id_cotizacion=@idCotizacion", parametros);

                if (cotizacionComponenteEntrada.TieneFilas())
                    CheckSubensamble = true;

                DgvSalidas.Rows.Add
                (
                    f.Celda("id"),
                    CheckSubensamble,
                    f.Celda("nombre").ToString(),
                    "SUBENSAMBLE"
                );
            });
        }

        private void CargarModelos()
        {
            DgvModelos.Rows.Clear();
            ProductoModelo modelos = new ProductoModelo();
            modelos.SeleccionarModelos(IdProducto, IdCotizacion).ForEach(delegate(Fila f)
            {
                bool checkModelos = false;

                CotizacionModelos cotizacionModelos = new CotizacionModelos();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idModelo", f.Celda<int>("id"));
                parametros.Add("@idCotizacion", IdCotizacion);
                cotizacionModelos.SeleccionarDatos("id_modelo=@idModelo and id_cotizacion=@idCotizacion", parametros);

                if (cotizacionModelos.TieneFilas())
                    checkModelos = true;

                DgvModelos.Rows.Add
                (
                    f.Celda("id"),
                    checkModelos,
                    f.Celda("nombre")
                );
            });
        }

        private string CalcularNombre(DataGridView Dgv)
        {
            string nombre = string.Empty;

            if (Dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[1].Value))
                        nombre += row.Cells[2].Value.ToString() + "|";
                }
            }

            if (nombre != "")
                nombre = nombre.Remove(nombre.Length - 1);

            return nombre;
        }

        private void DgvEntradas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvEntradas.Rows[e.RowIndex].Cells["check_entrada"];
            string strCheck = DgvEntradas.Rows[e.RowIndex].Cells["check_entrada"].Value.ToString().ToLower();
            if (strCheck == chk.TrueValue.ToString().ToLower())
            {
                //borrar
                if (DgvEntradas.Rows[e.RowIndex].Cells["tipo_entrada"].Value.ToString() == "COMPONENTE")
                    CotizacionComponenteEntrada.Modelo().BorrarEntrada(IdCotizacion, Convert.ToInt32(DgvEntradas.Rows[e.RowIndex].Cells["id_entrada"].Value));
                else
                    CotizacionSubensambleEntrada.Modelo().BorrarEntrada(IdCotizacion, Convert.ToInt32(DgvEntradas.Rows[e.RowIndex].Cells["id_entrada"].Value));

                CotizacionEntrada.Modelo().BorrarEntrada(IdCotizacion, DgvEntradas.Rows[e.RowIndex].Cells["entrada"].Value.ToString());

                chk.Value = chk.FalseValue;
            }
            else
            {
                //guardar
                Fila insertarCotizacionesEntradas = new Fila();
                insertarCotizacionesEntradas.AgregarCelda("producto", IdProducto);
                insertarCotizacionesEntradas.AgregarCelda("nombre", DgvEntradas.Rows[e.RowIndex].Cells["entrada"].Value);
                insertarCotizacionesEntradas.AgregarCelda("id_cotizacion", IdCotizacion);
                int idCotizacionEntrada = Convert.ToInt32(CotizacionEntrada.Modelo().Insertar(insertarCotizacionesEntradas).Celda("id"));

                Fila insertarComponentesEntradas = new Fila();
                if (DgvEntradas.Rows[e.RowIndex].Cells["tipo_entrada"].Value.ToString() == "COMPONENTE")
                {
                    insertarComponentesEntradas.AgregarCelda("id_componente", DgvEntradas.Rows[e.RowIndex].Cells["id_entrada"].Value);
                    insertarComponentesEntradas.AgregarCelda("id_cotizaciones_entrada", idCotizacionEntrada);
                    insertarComponentesEntradas.AgregarCelda("id_cotizacion", IdCotizacion);
                    CotizacionComponenteEntrada.Modelo().Insertar(insertarComponentesEntradas);
                }
                else
                {
                    insertarComponentesEntradas.AgregarCelda("id_subensamble", DgvEntradas.Rows[e.RowIndex].Cells["id_entrada"].Value);
                    insertarComponentesEntradas.AgregarCelda("id_cotizaciones_entrada", idCotizacionEntrada);
                    insertarComponentesEntradas.AgregarCelda("id_cotizacion", IdCotizacion);
                    CotizacionSubensambleEntrada.Modelo().Insertar(insertarComponentesEntradas);
                }
                chk.Value = chk.TrueValue;
            }
        }

        private void DgvSalidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvSalidas.Rows[e.RowIndex].Cells["check_salidas"];
            if (chk.Value.ToString().ToLower() == chk.TrueValue.ToString().ToLower())
            {
                //borrar
                if (DgvEntradas.Rows[e.RowIndex].Cells["tipo_entrada"].Value.ToString() == "COMPONENTE")
                    CotizacionComponenteSalida.Modelo().BorrarSalida(IdCotizacion, Convert.ToInt32(DgvSalidas.Rows[e.RowIndex].Cells["id_salida"].Value));
                else
                    CotizacionSubensambleSalida.Modelo().BorrarSalida(IdCotizacion, Convert.ToInt32(DgvSalidas.Rows[e.RowIndex].Cells["id_salida"].Value));

                CotizacionSalida.Modelo().BorrarSalida(IdCotizacion, DgvSalidas.Rows[e.RowIndex].Cells["salidas"].Value.ToString());

                chk.Value = chk.FalseValue;
            }
            else
            {
                Fila insertarCotizacionesSalidas = new Fila();
                insertarCotizacionesSalidas.AgregarCelda("producto", IdProducto);
                insertarCotizacionesSalidas.AgregarCelda("nombre", DgvSalidas.Rows[e.RowIndex].Cells["salidas"].Value);
                insertarCotizacionesSalidas.AgregarCelda("id_cotizacion", IdCotizacion);
                int idCotizacionEntrada = Convert.ToInt32(CotizacionSalida.Modelo().Insertar(insertarCotizacionesSalidas).Celda("id"));

                Fila insertarComponentesSalidas = new Fila();
                if (DgvEntradas.Rows[e.RowIndex].Cells["tipo_entrada"].Value.ToString() == "COMPONENTE")
                {
                    insertarComponentesSalidas.AgregarCelda("id_componente", DgvSalidas.Rows[e.RowIndex].Cells["id_salida"].Value);
                    insertarComponentesSalidas.AgregarCelda("id_cotizaciones_salida", idCotizacionEntrada);
                    insertarComponentesSalidas.AgregarCelda("id_cotizacion", IdCotizacion);
                    CotizacionComponenteSalida.Modelo().Insertar(insertarComponentesSalidas);
                }
                else
                {
                    insertarComponentesSalidas.AgregarCelda("id_subensamble", DgvSalidas.Rows[e.RowIndex].Cells["id_salida"].Value);
                    insertarComponentesSalidas.AgregarCelda("id_cotizaciones_salidas", idCotizacionEntrada);
                    insertarComponentesSalidas.AgregarCelda("id_cotizacion", IdCotizacion);
                    CotizacionSubensambleSalida.Modelo().Insertar(insertarComponentesSalidas);
                }
                chk.Value = chk.TrueValue;
            }
        }

        private void DgvModelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvModelos.Rows[e.RowIndex].Cells["check_Modelos"];
            if (chk.Value.ToString().ToLower() == chk.TrueValue.ToString().ToLower())
            {
                //borrar
                CotizacionModelos.Modelo().BorrarModelos(IdCotizacion, Convert.ToInt32(DgvModelos.Rows[e.RowIndex].Cells["id_modelo"].Value));

                chk.Value = chk.FalseValue;     
            }
            else
            {
                Fila insertarCotizacinesModelos = new Fila();
                insertarCotizacinesModelos.AgregarCelda("id_cotizacion", IdCotizacion);
                insertarCotizacinesModelos.AgregarCelda("id_modelo", DgvModelos.Rows[e.RowIndex].Cells["id_modelo"].Value);
                int idCotizacionModelo = Convert.ToInt32(CotizacionModelos.Modelo().Insertar(insertarCotizacinesModelos).Celda("id"));

                chk.Value = chk.TrueValue;
            }
        }

        private void FrmProcesoManufactura2_Resize(object sender, EventArgs e)
        {
            CambiarTamanoEntradas();
            CambiarTamanoSalidas();
            CambiarTamanoModelos();
        }

        private void TsbAlignLeft_Click(object sender, EventArgs e)
        {
            RtfDescripcion.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void TsbAlignRight_Click(object sender, EventArgs e)
        {
            RtfDescripcion.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void TsbAlignCenter_Click(object sender, EventArgs e)
        {
            RtfDescripcion.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void audiselColorSelector1_ButtonClick(object sender, EventArgs e)
        {
            CambiarColorALetra(audiselColorSelector1.Color);
        }

        private void TsbTachar_Click(object sender, EventArgs e)
        {
            ActivarEstilo(FontStyle.Strikeout);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            ListaActiva = RtfDescripcion.SelectionBullet;

            if (!ListaActiva)
            {
                RtfDescripcion.SelectionBullet = true;
                ListaActiva = true;
            }
            else
            {
                RtfDescripcion.SelectionBullet = false;
                ListaActiva = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RtfDescripcion.ZoomFactor += 0.1f;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (RtfDescripcion.ZoomFactor >= 1.1f)
            {
                RtfDescripcion.ZoomFactor -= 0.1f;
            }
        }

        private void BtnHazAlgo_Click(object sender, EventArgs e)
        {
            string localPathRecursos = Directory.GetCurrentDirectory() + "\\SGC\\COTIZACIONES\\RECURSOS";
            string newRTF = localPathRecursos + "\\DESCRIPCION" + "\\" + IdCotizacion + ".rtf";
            string pathRemoto = PathRemoto;

            toolStrip1.Enabled = false;
            LblEstatus.Visible = true;
            Progress.Visible = true;
            FormPadre.HabilitarTreeview(false);
            btnCancelar.Enabled = false;
            DgvEntradas.Enabled = false;
            DgvModelos.Enabled = false;
            DgvSalidas.Enabled = false;
            BtnHazAlgo.Enabled = false;

            if (!Directory.Exists(localPathRecursos + "\\DESCRIPCION"))
                Directory.CreateDirectory(localPathRecursos + "\\DESCRIPCION");

            RtfDescripcion.SaveFile(newRTF, RichTextBoxStreamType.RichText);
            string[] parametros = new string[] { localPathRecursos + "\\DESCRIPCION", pathRemoto + "\\DESCRIPCION\\" };

            if (!BkgGuardarArchivo.IsBusy)
                BkgGuardarArchivo.RunWorkerAsync(parametros);
        }

        private void GuardarRTF(string localPath, string pathRemoto, BackgroundWorker bkgWorker)
        {
            if (!Directory.Exists(localPath))
                Directory.CreateDirectory(localPath);

            bkgWorker.ReportProgress(10, "Guardando documento...");

            string newRTF = localPath + "\\" + IdCotizacion + ".rtf";
            string newHTML = localPath + "\\" + IdCotizacion + ".html";
            string targetPDF = localPath + "\\" + IdCotizacion + ".pdf";

          //  rtfText.SaveFile(newRTF, RichTextBoxStreamType.RichText);

            // Conversión a HTML
            Spire.Doc.Document doc = new Spire.Doc.Document();
            doc.HtmlExportOptions.ImageEmbedded = true;
            doc.LoadFromFile(newRTF);
            doc.SaveToFile(newHTML, FileFormat.Html);
            doc.Close();

            bkgWorker.ReportProgress(20, "Guardando documento...");

            string htmlContent = File.ReadAllText(newHTML);
            // MessageBox.Show(htmlContent);

            iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 80, 50, 30, 65);
            try
            {
                using (FileStream fs = new FileStream(targetPDF, FileMode.Create))
                {

                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    bkgWorker.ReportProgress(30, "Guardando documento...");

                    using (StringReader stringReader = new StringReader(htmlContent))
                    {
                        //create the default CSS Resolver
                        XMLWorkerHelper helperInstance = XMLWorkerHelper.GetInstance();
                        CssFilesImpl cssFiles = new CssFilesImpl();
                        cssFiles.Add(helperInstance.GetDefaultCSS());
                        StyleAttrCSSResolver cssRevolver = new StyleAttrCSSResolver(cssFiles);

                        bkgWorker.ReportProgress(40, "Guardando documento...");

                        //create the default Font provider
                        XMLWorkerFontProvider xmlWorkerFontProvider = new XMLWorkerFontProvider();
                        HtmlPipelineContext htmlContext = new HtmlPipelineContext(new CssAppliersImpl(xmlWorkerFontProvider));

                        bkgWorker.ReportProgress(50, "Guardando documento...");

                        //create the default tag provider
                        ITagProcessorFactory tpf = Tags.GetHtmlTagProcessorFactory();
                        htmlContext.SetTagFactory(tpf);

                        bkgWorker.ReportProgress(60, "Guardando documento...");

                        //set the image provider, in my case a blank image provider as my docs have no images
                        htmlContext.SetImageProvider(new BlankImageProvider(document));

                        //create the Pipeline
                        IPipeline pipeline = new CssResolverPipeline(cssRevolver, new
                           HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));

                        bkgWorker.ReportProgress(70, "Guardando documento...");

                        //parse the XHTML
                        XMLWorker worker = new XMLWorker(pipeline, true);
                        XMLParser p = new XMLParser(worker);
                        p.Parse(stringReader);

                        bkgWorker.ReportProgress(80, "Guardando documento...");
                    }

                    document.Close();
                }
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine(exc.Message);
                bkgWorker.ReportProgress(100, "Error");
            }

            //guardar rtf en servidor
            byte[] bytes = File.ReadAllBytes(localPath + "\\" + IdCotizacion + ".rtf");
            ServidorFtp.SubirDocumento(bytes, IdCotizacion, FormatoArchivo.Rtf, pathRemoto);

            //guardar html
            bytes = File.ReadAllBytes(localPath + "\\" + IdCotizacion + ".html");
            ServidorFtp.SubirDocumento(bytes, IdCotizacion, FormatoArchivo.html, pathRemoto);

            //guardar css
            bytes = File.ReadAllBytes(localPath + "\\" + IdCotizacion + "_styles.css");
            ServidorFtp.SubirDocumento(bytes, IdCotizacion, FormatoArchivo.css, pathRemoto);

            bkgWorker.ReportProgress(90, "Guardando documento...");
            // Guardar imagenes

            if (Directory.Exists(localPath + "\\" + IdCotizacion + "_images\\"))
            {
                string[] imagenesPath = Directory.GetFiles(localPath + "\\" + IdCotizacion + "_images\\");
                foreach (string path in imagenesPath)
                {
                    ServidorFtp.SubirImagenesHtml(File.ReadAllBytes(path), Path.GetFileName(path), pathRemoto + IdCotizacion + "_images" + "\\");
                }
            }

            if (Directory.Exists(localPath))
                Directory.Delete(localPath, true);

            bkgWorker.ReportProgress(100, "Guardando documento...OK");
        }

        private void BkgGuardarArchivo_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] parametro = (string[])e.Argument;
            GuardarRTF(parametro[0], parametro[1], BkgGuardarArchivo);
        }

        private void BkgGuardarArchivo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progress.Value = e.ProgressPercentage;
        }

        private void BkgGuardarArchivo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Su documento ha sido guardado", "Documento guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStrip1.Enabled = true;
            LblEstatus.Visible = false;
            Progress.Visible = false;
            DgvEntradas.Enabled = true;
            DgvModelos.Enabled = true;
            DgvSalidas.Enabled = true;
            btnCancelar.Enabled = true;
            Progress.Value = 0;
            BtnHazAlgo.Enabled = true;
            FormPadre.HabilitarTreeview(true);
        }

    }
}

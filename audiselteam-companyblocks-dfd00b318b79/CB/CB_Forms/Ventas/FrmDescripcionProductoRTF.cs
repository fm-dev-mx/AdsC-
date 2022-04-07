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
    public partial class FrmDescripcionProductoRTF : Form
    {
        int IdCotizacion = 0;
        string PathRemoto = string.Empty;
        public string Titulo = string.Empty;
        bool ListaActiva = false;

        public FrmDescripcionProductoRTF(int idCotizacion, string pathRemoto)
        {
            InitializeComponent();
            IdCotizacion = idCotizacion;
            PathRemoto = pathRemoto;
            audiselTituloForm1.Text = Titulo;
        }

        private void FrmRTF_Load(object sender, EventArgs e)
        {
            // Asignación de eventos
            byte[] byteRichText = ServidorFtp.DescargarArchivo(IdCotizacion, FormatoArchivo.Rtf, PathRemoto);
            if (byteRichText != null)
            {
                string originalRtf = System.Text.Encoding.UTF8.GetString(byteRichText);
                RTBcaja.Rtf = originalRtf;
            }

        }

        private void BtnHazAlgo_Click(object sender, EventArgs e)
        {
            string localPath = Directory.GetCurrentDirectory() + "\\SGC\\COTIZACIONES\\RECURSOS";

            if(!Directory.Exists(localPath))
                Directory.CreateDirectory(localPath);

            string newRTF = localPath + "\\" + IdCotizacion + ".rtf"; //"C:\\Users\\Eilean Laborde\\Desktop\\Document1.rtf";
            string newHTML = localPath + "\\" + IdCotizacion + ".html";//"C:\\Users\\Eilean Laborde\\Desktop\\Document1.html";
            string targetPDF = localPath + "\\" + IdCotizacion + ".pdf";//= "C:\\Users\\Eilean Laborde\\Desktop\\ParsedPDF.pdf";

             RTBcaja.SaveFile(newRTF, RichTextBoxStreamType.RichText);

            // Conversión a HTML
            Spire.Doc.Document doc = new Spire.Doc.Document();
            doc.HtmlExportOptions.ImageEmbedded = true;
            doc.LoadFromFile(newRTF);
            doc.SaveToFile(newHTML, FileFormat.Html);
            doc.Close();

            string htmlContent = File.ReadAllText(newHTML);
            // MessageBox.Show(htmlContent);

            iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 80, 50, 30, 65);
            try
            {
                using (FileStream fs = new FileStream(targetPDF, FileMode.Create))
                {

                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    using (StringReader stringReader = new StringReader(htmlContent))
                    {
                        //create the default CSS Resolver
                        XMLWorkerHelper helperInstance = XMLWorkerHelper.GetInstance();
                        CssFilesImpl cssFiles = new CssFilesImpl();
                        cssFiles.Add(helperInstance.GetDefaultCSS());
                        StyleAttrCSSResolver cssRevolver = new StyleAttrCSSResolver(cssFiles);

                        //create the default Font provider
                        XMLWorkerFontProvider xmlWorkerFontProvider = new XMLWorkerFontProvider();
                        HtmlPipelineContext htmlContext = new HtmlPipelineContext(new CssAppliersImpl(xmlWorkerFontProvider));

                        //create the default tag provider
                        ITagProcessorFactory tpf = Tags.GetHtmlTagProcessorFactory();
                        htmlContext.SetTagFactory(tpf);

                        //set the image provider, in my case a blank image provider as my docs have no images
                        htmlContext.SetImageProvider(new BlankImageProvider(document));

                        //create the Pipeline
                        IPipeline pipeline = new CssResolverPipeline(cssRevolver, new
                           HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));

                        //parse the XHTML
                        XMLWorker worker = new XMLWorker(pipeline, true);
                        XMLParser p = new XMLParser(worker);
                        p.Parse(stringReader);

                        // iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, stringReader);
                    }

                    document.Close();
                }
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine(exc.Message);
            }

            //guardar rtf en servidor
            byte[] bytes = File.ReadAllBytes(localPath + "\\" + IdCotizacion + ".rtf"); //System.Text.Encoding.UTF8.GetBytes(textoRtf);
            ServidorFtp.SubirDocumento(bytes, IdCotizacion, FormatoArchivo.Rtf, PathRemoto);
            
            //guardar html
            bytes = File.ReadAllBytes(localPath + "\\" + IdCotizacion + ".html");
            ServidorFtp.SubirDocumento(bytes, IdCotizacion, FormatoArchivo.html, PathRemoto);

            //guardar css
            bytes = File.ReadAllBytes(localPath + "\\" + IdCotizacion + "_styles.css");
            ServidorFtp.SubirDocumento(bytes, IdCotizacion, FormatoArchivo.css, PathRemoto);

            string[] imagenesPath = Directory.GetFiles(localPath + "\\" + IdCotizacion + "_images\\");
            foreach (string path in imagenesPath)
	        {
                //ServidorFtp.SubirDocumento(File.ReadAllBytes(path), IdCotizacion, FormatoArchivo.Png, PathRemoto + IdCotizacion + "_images" + "\\");
                ServidorFtp.SubirImagenesHtml(File.ReadAllBytes(path), Path.GetFileName(path), PathRemoto + IdCotizacion + "_images" + "\\");
	        }

            if (Directory.Exists(localPath))
                Directory.Delete(localPath, true);
            
            MessageBox.Show("Su documento ha sido guardado", "Documento guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
           // Global.RftAPdf(newRTF);
            // recuperar rtf
            //string originalRtf = System.Text.Encoding.UTF8.GetString(bytes);
        }

        private void TsbAlignLeft_Click(object sender, EventArgs e)
        {
            RTBcaja.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void TsbAlignCenter_Click(object sender, EventArgs e)
        {
            RTBcaja.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void TsbAlignRight_Click(object sender, EventArgs e)
        {
            RTBcaja.SelectionAlignment = HorizontalAlignment.Right;
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

        private void TsbTachar_Click(object sender, EventArgs e)
        {
            ActivarEstilo(FontStyle.Strikeout);

        }

        private void ActivarEstilo(FontStyle estilo)
        {
            RTBcaja.SelectionFont = new System.Drawing.Font(
                RTBcaja.SelectionFont, RTBcaja.SelectionFont.Style ^ estilo
                );
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            RTBcaja.ZoomFactor += 0.1f;
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            if(RTBcaja.ZoomFactor >= 1.1f)
            { 
                RTBcaja.ZoomFactor -= 0.1f;
            }
        }

        private void CambiarColorALetra(Color color)
        {
            RTBcaja.SelectionColor = color;
        }

        private void audiselColorSelector1_DropDownOpening(object sender, EventArgs e)
        {
            ColorDialog dialogoColor = new ColorDialog();
            if(dialogoColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                audiselColorSelector1.Color = dialogoColor.Color;
                CambiarColorALetra(audiselColorSelector1.Color);
            }
        }

        private void audiselColorSelector1_ButtonClick(object sender, EventArgs e)
        {
            CambiarColorALetra(audiselColorSelector1.Color);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PDFMakerNovo gestorPdf = new PDFMakerNovo();
            gestorPdf.CrearFormatoCotizacion(IdCotizacion, @"SGC\COTIZACIONES\SECUENCIAOPERACIONES\");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ListaActiva = RTBcaja.SelectionBullet;

            if (!ListaActiva)
            {
                RTBcaja.SelectionBullet = true;
                ListaActiva = true;
            }
            else
            {
                RTBcaja.SelectionBullet = false;
                ListaActiva = false;
            }
        }      
    }

    public class BlankImageProvider : IImageProvider 
    {
        public string ImagenPth { get;  set ;  } 
        //Store a reference to the main document so that we can access the page size and margins
        private iTextSharp.text.Document MainDoc;
        //Constructor
        public BlankImageProvider(iTextSharp.text.Document doc)
        {
            this.MainDoc = doc;
        }

        public string GetImageRootPath()
        {
            return Directory.GetCurrentDirectory() + "\\SGC\\COTIZACIONES\\RECURSOS\\"; //C:\\Users\\Eilean Laborde\\Desktop\\";
        }

        public void Reset()
        {
            return;
        }

        public iTextSharp.text.Image Retrieve(string src)
        {
            return null;
        }

        public void Store(string src, iTextSharp.text.Image img)
        {
            return;
        }
    }
}

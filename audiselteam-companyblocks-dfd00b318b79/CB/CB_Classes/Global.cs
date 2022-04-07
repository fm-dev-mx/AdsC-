using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using AxAcroPDFLib;
using System.Net.Mail;
using System.Globalization;
using System.Management;
using FluentFTP;
using System.Net;
using System.IO;
using System.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.html;
using CB;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.parser;
using iTextSharp.text;
using iTextSharp.tool.xml.pipeline;
using System.Diagnostics;
using System.Drawing.Printing;

namespace CB_Base.Classes
{
    public static class Global
    {
        public static string ConnectionString = "";
        public static Usuario UsuarioActual = new Usuario();
        public static Privilegio PrivilegiosActuales = new Privilegio();
        public static Configuracion ConfiguracionActual = new Configuracion();
        public static string TipoConexion;

        // Extrae elementos de PDF a partir de un RTF. Permite incrustar el contenido RTF dentro de celdas iTextSharp
        public static List<IElement> ElementosPdfDesdeRtf(string pathRtf)
        {
            string newHTML = System.IO.Path.ChangeExtension(pathRtf, ".html");
            string targetPDF = System.IO.Path.ChangeExtension(pathRtf, ".pdf");

            // Conversión a HTML
            Spire.Doc.Document doc = new Spire.Doc.Document();
            doc.HtmlExportOptions.ImageEmbedded = true;
            doc.LoadFromFile(pathRtf);
            doc.SaveToFile(newHTML, Spire.Doc.FileFormat.Html);
            doc.Close();

            string htmlContent = File.ReadAllText(newHTML);
            // MessageBox.Show(htmlContent);

            SampleHandler handler = new SampleHandler();

            using(TextReader sr = new StringReader(htmlContent))
            {
                
                XMLWorkerHelper.GetInstance().ParseXHtml(handler, sr);
            }

            return handler.elements;
        }

        public static List<IElement> ElementosPdfDesdeRtf2(string pathRtf)
        {
            string newHTML = System.IO.Path.ChangeExtension(pathRtf, ".html");
            string targetPDF = System.IO.Path.ChangeExtension(pathRtf, ".pdf");

            string htmlContent = File.ReadAllText(targetPDF);
            // MessageBox.Show(htmlContent);

            SampleHandler handler = new SampleHandler();

            using (TextReader sr = new StringReader(htmlContent))
            {

                XMLWorkerHelper.GetInstance().ParseXHtml(handler, sr);
            }

            return handler.elements;
        }

        // Convierte un RTF a formato PDF
        public static void RftAPdf2(string pathRtf)
        {
            string newHTML = System.IO.Path.ChangeExtension(pathRtf, ".html");
            string targetPDF = System.IO.Path.ChangeExtension(pathRtf, ".pdf");

            // Conversión a HTML
            Spire.Doc.Document doc = new Spire.Doc.Document();
            doc.HtmlExportOptions.ImageEmbedded = true;
            doc.LoadFromFile(pathRtf);
            doc.SaveToFile(newHTML, Spire.Doc.FileFormat.Html);
            doc.Close();

            string htmlContent = File.ReadAllText(newHTML);
            // MessageBox.Show(htmlContent);

            // Conversión a PDF
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
        }

        public static void RftAPdf(string pathRtf)
        {
            string newHTML = System.IO.Path.ChangeExtension(pathRtf, ".html");
            string targetPDF = System.IO.Path.ChangeExtension(pathRtf, ".pdf");

            // Conversión a HTML
            Spire.Doc.Document doc = new Spire.Doc.Document();
            doc.HtmlExportOptions.ImageEmbedded = true;
            doc.LoadFromFile(pathRtf);
            doc.SaveToFile(newHTML, Spire.Doc.FileFormat.Html);
            doc.Close();
            
            string htmlContent = File.ReadAllText(newHTML);
            // MessageBox.Show(htmlContent);

            // Conversión a PDF
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
        }

        public class SampleHandler : IElementHandler
        {
            //Generic list of elements
            public List<IElement> elements = new List<IElement>();
            //Add the supplied item to the list
            public void Add(IWritable w)
            {
                if (w is WritableElement)
                {
                    elements.AddRange(((WritableElement)w).Elements());
                }
            }
        }

        public static bool VerificarPrivilegio(string categoria, string priv)
        {
            if (UsuarioActual.Fila().Celda("rol").ToString() == "SUPERUSER" || UsuarioActual.Fila().Celda("rol").ToString() == "COORDINADOR DE PROCESOS" ) 
                return true;

            foreach(Fila privilegio in PrivilegiosActuales.Filas() )
            {
                if( privilegio.Celda("categoria").ToString() == categoria && privilegio.Celda("privilegio").ToString() == priv )
                {
                    return true;
                }
            }
            return false;
        }

        public static bool PrivilegioPorRol(string rol)
        {
            if (UsuarioActual.Fila().Celda("rol").ToString() == "SUPERUSER" || UsuarioActual.Fila().Celda("rol").ToString() == "COORDINADOR DE PROCESOS")
                return true;

                if (Global.UsuarioActual.Fila().Celda("rol").ToString() == rol)
                {
                    return true;
                }
            return false;
        }

        public static void AgregarConteoMaterialNodo(TreeNode nodoTemporal, int conteo)
        {
            if (conteo <= 0)
            {
                nodoTemporal.ForeColor = Color.Gray;
            }
            else
            {
                nodoTemporal.ForeColor = Color.Black;
            }
            nodoTemporal.Text += " (" + conteo + ")";
        }

        public static void ClearListView(ListView lv)
        {
            foreach (ListViewItem it in lv.Items)
            {
                it.Remove();
            }
        }

        static public string CrearNumeroParteAudisel(int id)
        {
            return "PP-" + id.ToString().PadLeft(6, '0');
        }

        static public string CalcularHashMD5(string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        static public void MostrarPDF(byte[] datos, string nombre, WebBrowser visorWeb=null, AxAcroPDFLib.AxAcroPDF visorPDF=null)
        {
            var tempFolder = System.IO.Path.GetTempPath();
            nombre = System.IO.Path.Combine(tempFolder, nombre);

            try
            {
                System.IO.File.WriteAllBytes(nombre, datos);
            }
            catch/*(Exception ex)*/ { }

            if( visorWeb == null && visorPDF == null )
            {
                System.Diagnostics.Process.Start(nombre);
            }
            else
            {
                if (visorWeb != null)
                {
                    visorWeb.Navigate(@nombre);
                    visorWeb.TabIndex = 0;
                    //SendKeys.Send("CTRL^H");
                }

                if (visorPDF != null)
                {
                    visorPDF.LoadFile(nombre);
                    visorPDF.src = @nombre; // +".pdf#toolbar=0";
                    visorPDF.setShowToolbar(false);
                    visorPDF.setView("FitH");
                    visorPDF.setPageMode("none");
                    visorPDF.Show();
                }
            }
        }

        static public void MostrarPDFWebBrowser(byte[] archivo, string tipoImpresion, string nombreArchivo)
        {
            string directorio = Directory.GetCurrentDirectory() + "//IMPRIMIR//" + "//" + tipoImpresion;
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            string pathFile = directorio + "//" + nombreArchivo + ".pdf";

            if (File.Exists(pathFile))
                File.Delete(pathFile);

            try
            {
                System.IO.File.WriteAllBytes(pathFile, archivo);
            }
            catch
            {
                MessageBox.Show("Error al generar el archivo");
                return;
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "";
            info.FileName = pathFile;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Normal;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();
        }

        static public bool EnviarCorreo(string asunto, string contenido, string para, List<string> copiasVisibles = null, List<Attachment> adjuntos = null, List<string> copiasOcultas = null)
        {    
            //con oauth 2.0
            string msg = string.Empty;
            string titulo = string.Empty;
            contenido = contenido + "<br><br>" + ConfiguracionActual.CorreoFirma;
            MessageBoxIcon habilitarIcon = MessageBoxIcon.None;

            int idError = GmailAuth2.EnviarCorreoConOAuth2(asunto, contenido, para, copiasVisibles, adjuntos, copiasOcultas);
            bool correoEnviado = false;

            //Control de errores
            switch (idError)
            {
                case 0:
                    msg = "Su mensaje ha sido enviado a los destinatarios correspondientes";
                    titulo = "Correo enviado";
                    habilitarIcon = MessageBoxIcon.Information;
                    correoEnviado = true;
                    break;
                case 1:
                    msg = "No se ha podido comprobar la configuración de correo, favor de ponerse en contacto con sistemas";
                    titulo = "Correo no enviado";
                    habilitarIcon = MessageBoxIcon.Warning;
                    correoEnviado = false;
                    break;
                case 2:
                    //token refrescado debe de intentar de nuevo enviar el correo
                    int nuevoError = GmailAuth2.EnviarCorreoConOAuth2(asunto, contenido, para, copiasVisibles, adjuntos, copiasOcultas);
                    if (nuevoError != 0)
                    {
                        msg = "No fue posible enviar el correo";
                        titulo = "Correo no enviado";
                        habilitarIcon = MessageBoxIcon.Warning;
                        correoEnviado = false;
                    }
                    else
                    {
                        msg = "Su mensaje ha sido enviado a los destinatarios correspondientes";
                        titulo = "Correo enviado";
                        habilitarIcon = MessageBoxIcon.Information;
                        correoEnviado = true;
                    }
                    break;
                case 3:
                    msg = "El token ha expirado y no ha podido ser actualizado";
                    titulo = "Token expirado";
                    habilitarIcon = MessageBoxIcon.Warning;
                    correoEnviado = false;
                    break;
                case 4:
                    msg = "No fue posible enviar el correo, error general de smtp";
                    titulo = "Correo no enviado";
                    habilitarIcon = MessageBoxIcon.Warning;
                    correoEnviado = false;
                    break;
                case 5:
                    msg = "Las credenciales de gmail no corresponden con el correo configurado, favor de verificar su correo y cerrar la sesión de Gmail de forma manual";
                    titulo = "Correo no enviado";
                    habilitarIcon = MessageBoxIcon.Warning;
                    correoEnviado = false;
                    break;
                case 6:
                    msg = "Ha excedido el límite de tiempo para iniciar sesión o lo ha cancelado";
                    titulo = "Correo no enviado";
                    habilitarIcon = MessageBoxIcon.Warning;
                    correoEnviado = false;
                    break;
                case 7:

                    string mensaje = string.Empty;
                    foreach (string item in GmailAuth2.SmtpInformacion)
                    {
                        mensaje += item + Environment.NewLine;
                    }

                    msg = "Verificar correo, contraseña y puerto, no se puede establecer la conección con oAuth o está siendo rechazada por gmail" + Environment.NewLine + mensaje;
                    titulo = "Correo no enviado";
                    habilitarIcon = MessageBoxIcon.Warning;
                    correoEnviado = false;
                    break; 
                case 8:
                    msg = "no se puede autenticar el token, reinicie el token";
                    titulo = "Correo no enviado";
                    habilitarIcon = MessageBoxIcon.Warning;
                    correoEnviado = false;
                    break;
                default:
                    correoEnviado = false;
                    break;
            }

            MessageBox.Show(msg, titulo, MessageBoxButtons.OK, habilitarIcon);
            return correoEnviado;
        }

        public static string ToTitleCase(this string s)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }

        static public int GuardarFilaSeleccionada(DataGridView DgvFila)
        {
            int FilaSeleccionada = -1;

            if (DgvFila.SelectedRows.Count > 0)
                FilaSeleccionada = DgvFila.SelectedRows[0].Index;

            return FilaSeleccionada;
        }

        static public void RecuperarFilaSeleccionada(DataGridView DgvFila, int FilaSeleccionada)
        {
            if (FilaSeleccionada >= 0 && (FilaSeleccionada < DgvFila.Rows.Count))
            {
                //int PosicionScroll = DgvFila.FirstDisplayedScrollingRowIndex;
                DgvFila.ClearSelection();
                DgvFila.Rows[FilaSeleccionada].Selected = true;
                //DgvFila.FirstDisplayedScrollingRowIndex = PosicionScroll;
            }
        }

        static public int MySqlMaxAllowedPackets()
        {
            ModeloMySql mod = new ModeloMySql();
            string sql = "SHOW VARIABLES WHERE variable_name = 'max_allowed_packet'";
            mod.ConstruirQuery(sql);
            mod.EjecutarQuery();
            List<Fila> resp = mod.LeerFilas();

            if(resp.Count > 0)
            {
                return Convert.ToInt32(resp[0].Celda("Value")) / (1024*1024);
            }
            return 0;
        }

        static public void MoverFilaArriba(DataGridView dgv)
        {
            if (dgv.SelectedRows[0].Index != 0)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    object tmp = dgv[j, dgv.SelectedRows[0].Index].Value;
                    dgv[j, dgv.SelectedRows[0].Index].Value = dgv[j, dgv.SelectedRows[0].Index - 1].Value;
                    dgv[j, dgv.SelectedRows[0].Index - 1].Value = tmp;
                }
                int a = dgv.SelectedRows[0].Index;
                dgv.ClearSelection();
                dgv.Rows[a - 1].Selected = true;
            }
        }

        static public void MoverFilaAbajo(DataGridView dgv)
        {
            if (dgv.SelectedRows[0].Index != dgv.Rows.Count - 1)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    object tmp = dgv[j, dgv.SelectedRows[0].Index].Value;
                    dgv[j, dgv.SelectedRows[0].Index].Value = dgv[j, dgv.SelectedRows[0].Index + 1].Value;
                    dgv[j, dgv.SelectedRows[0].Index + 1].Value = tmp;
                }
                int i = dgv.SelectedRows[0].Index;
                dgv.ClearSelection();
                dgv.Rows[i + 1].Selected = true;
            }
        }

        public static DateTime SiguienteDiaSemana(DateTime inicio, DayOfWeek diaSemana)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int diasParaSumar = ((int)diaSemana - (int)inicio.DayOfWeek + 7) % 7;
            return inicio.AddDays(diasParaSumar);
        }

        public static double MillisegundosEpoch()
        {
            return DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds;
        }

        public static int CalcularPorcentaje(int avance, int total)
        {
            double dPorcentaje = ((double)avance / (double)total) * 100.0;
            int iPorcentaje = (int)Math.Ceiling(dPorcentaje);
            return iPorcentaje;
        }

        public static string CrearConexion(string servidor)
        {
            string ServidorDB = "";
            TipoConexion = servidor;
            ConfiguracionActual.CargarConfiguracionBd();
            ConfiguracionActual.CargarConfiguracionFtp();

            if (ConfiguracionActual.BdConfiguracionValida)
            {
                if(servidor == "REMOTA")
                    ServidorDB = ConfiguracionActual.BdServidorRemoto;
                else if(servidor == "LOCAL")
                    ServidorDB = ConfiguracionActual.BdServidorLocal;

                    return "server=" + ServidorDB + ";user=" + ConfiguracionActual.BdUsuario + ";database=" + ConfiguracionActual.BdNombre + ";port=" + Convert.ToInt32(ConfiguracionActual.BdPuerto) + ";password=" + ConfiguracionActual.BdPassword + ";Allow User Variables=True";
            }
            else
                return "Error";
        }

        public static bool CrearConexionFTP(FtpClient ClienteFtp)
        {
            if (ClienteFtp == null || !ClienteFtp.IsConnected)
            {
                if (TipoConexion == "LOCAL")
                    ClienteFtp.Host = ConfiguracionActual.FtpServidorLocal;
                else
                    ClienteFtp.Host = ConfiguracionActual.FtpServidorRemoto;

                ClienteFtp.Credentials = new NetworkCredential(UsuarioActual.Fila().Celda("correo").ToString(),
                                                               UsuarioActual.Fila().Celda("password").ToString());

                // Verificar conexion con servidor FTP
                try
                {
                    ClienteFtp.Connect();
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
            else
                return true;
        }

        public static bool CrearArchivosCacheAutomaticamente()
        {
            ConfiguracionActual.CargarConfiguracionDiseno();
            if (ConfiguracionActual.DisenoConfiguracionValida)
            {
                string valorActual = ConfiguracionActual.DisenoArchivosCache;
                if (valorActual.ToUpper() == "TRUE")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static string FechaATexto(object fecha, bool incluirTiempo=true)
        {
            if (fecha == null)
                return "N/A";

            try
            {
                if (incluirTiempo)
                    return Convert.ToDateTime(fecha).ToString("MMM dd, yyyy hh:mm:ss tt");
                else
                    return Convert.ToDateTime(fecha).ToString("MMM dd, yyyy");
            }
            catch
            {
                return "N/A";
            }
        }

        public static string ObjetoATexto(object objeto, string valorRetorno)
        {
            if (objeto != null)
                valorRetorno = objeto.ToString();

            return valorRetorno;
        }

        public static List<ManagementObject> BuscarProcesos(string nombre = "sldworks")
        {
            List<ManagementObject> procesosEncontrados = new List<ManagementObject>();
            ManagementClass MgmtClass = new ManagementClass("Win32_Process");

            foreach (ManagementObject mo in MgmtClass.GetInstances())
            {
                string nombreProceso = mo["Name"].ToString().ToLower();

                if (nombreProceso.Contains("sldworks"))
                {
                    procesosEncontrados.Add(mo);
                }
            }
            return procesosEncontrados;
        }

        public static void TerminarProcesos(List<ManagementObject> procesos)
        {
            foreach (ManagementObject mo in procesos)
            {
                mo.InvokeMethod("Terminate", null);
            }
        }

        static public DateTime InicioSemana(DateTime fecha, DayOfWeek inicioSemana = DayOfWeek.Monday)
        {
            while (fecha.DayOfWeek != inicioSemana)
                fecha = fecha.AddDays(-1);

            return fecha;
        }

        static public DateTime InicioSemanaPasada(DayOfWeek inicioSemana=DayOfWeek.Monday)
        {
            DateTime startingDate = DateTime.Today;

            while(startingDate.DayOfWeek != inicioSemana)
                startingDate = startingDate.AddDays(-1);

            return startingDate.AddDays(-7);
        }

        static public DateTime FinSemanaPasada(DayOfWeek inicioSemana=DayOfWeek.Monday)
        {
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != inicioSemana)
                startingDate = startingDate.AddDays(-1);

            return startingDate.AddDays(-1);
        }

        public static DateTime FechaIncialSemanaYear(int year, int semanaYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);

            int daysOffset = (int)DayOfWeek.Monday - (int)jan1.DayOfWeek;

            DateTime firstMonday = jan1.AddDays(daysOffset);

            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(jan1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

            if (firstWeek <= 1)
            {
                semanaYear -= 1;
            }

            return firstMonday.AddDays(semanaYear * 7);
        }

        public static DateTime FechaInicialMes(DateTime mes)
        {
            DateTime firstDay = new DateTime(mes.Year, mes.Month, 1);
            return firstDay.Date;
            //string dayOfFirstDay = firstDay.DayOfWeek.ToString();
        }

        public static int CalcularNumeroSemana(DateTime fecha)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(fecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public static int NumeroSemanaYear()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public static int CalcularDiasNaturales(DateTime fechaInicio, DateTime fechaFin)
        {
            return (int)Math.Abs((fechaFin - fechaInicio).Days) + 1;
        }

        public static int CalcularSemanas(DateTime fechaInicio, DateTime fechaFin)
        {
            return (int)Math.Abs(((fechaFin - fechaInicio).Days + 1) / 7);
        }

        public static int CalcularDiasHabiles(DateTime fechaInicio, DateTime fechaFin)
        {
            int calcBusinessDays =
                1 + ((fechaFin - fechaInicio).Days * 5 -
                (fechaInicio.DayOfWeek - fechaFin.DayOfWeek) * 2) / 7;

            if (fechaFin.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (fechaInicio.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

            return calcBusinessDays;
        }

        public static DateTime AgregarDiasHabiles(DateTime fecha, int diasHabiles)
        {
            if (diasHabiles < 0)
            {
                diasHabiles = diasHabiles * -1;
            }

            if (diasHabiles == 0) return fecha;

            if (fecha.DayOfWeek == DayOfWeek.Saturday)
            {
                fecha = fecha.AddDays(2);
                diasHabiles -= 1;
            }
            else if (fecha.DayOfWeek == DayOfWeek.Sunday)
            {
                fecha = fecha.AddDays(1);
                diasHabiles -= 1;
            }

            fecha = fecha.AddDays(diasHabiles / 5 * 7);
            int extraDays = diasHabiles % 5;

            if ((int)fecha.DayOfWeek + extraDays > 5)
            {
                extraDays += 2;
            }

            return fecha.AddDays(extraDays);
        }

        public static TreeNode CrearNodo(string nombre, string texto, int imagenIndice = 0, ContextMenuStrip menu = null, string toolTip = "")
        {
            TreeNode nodoTemp = new TreeNode();
            nodoTemp.Name = nombre;
            nodoTemp.Text = texto;
            nodoTemp.ImageIndex = 0;
            nodoTemp.SelectedImageIndex = 0;
            nodoTemp.ImageIndex = imagenIndice;
            nodoTemp.SelectedImageIndex = imagenIndice; 

            if(toolTip != null)
                nodoTemp.ToolTipText = toolTip;

            if (menu != null)
                nodoTemp.ContextMenuStrip = menu;

            return nodoTemp;
        }

        public static System.Drawing.Image ByteAImagen(Byte[] arregloDeBytes)
        {
            using (var ms = new MemoryStream(arregloDeBytes))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        public static double ObtenerTipoCambio(string divisaEntrada = "USD",string divisaSalida = "MXN")
        {
            string url = "https://api.exchangeratesapi.io/latest?base=" + divisaEntrada;

            List<string> divisaLista = new List<string>();
            string response = new WebClient().DownloadString(url);
            foreach (string moneda in response.Split(','))
            {
                divisaLista.Add(moneda);
            }

            string[] valor = divisaLista.Find(x => x.Contains(divisaSalida)).Split(':');
            if (valor.Length > 0)
                return Convert.ToDouble(valor[1]);
            else
                return 0;
        }

        public static byte[] CambiarTamanoImagen(System.Drawing.Image imgToResize, Size size)
        {
            System.Drawing.Image nuevaImagen = (System.Drawing.Image)(new Bitmap(imgToResize, size));
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(nuevaImagen, typeof(byte[]));
        }

        public static byte[] ImagenByte(System.Drawing.Image imagen)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(imagen, typeof(byte[]));
        }

        public static byte[] ImagenAPDF(byte[] datosImagen)
        {
            byte[] datosPDF = null;
            string nombreTemporalPdf = Path.GetTempFileName();

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(nombreTemporalPdf, FileMode.Create));
            doc.Open();
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(datosImagen);
            png.ScaleAbsoluteHeight(doc.PageSize.Height);
            png.ScaleAbsoluteWidth(doc.PageSize.Width);
            png.SetAbsolutePosition(0, 0);
            doc.Add(png);
            doc.Close();

            datosPDF = File.ReadAllBytes(nombreTemporalPdf);
            File.Delete(nombreTemporalPdf);
            return datosPDF;
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }


        public override string ToString()
        {
            return Text;
        }
    }

    public class CheckBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }


        public override string ToString()
        {
            return Text;
        }
    }
}

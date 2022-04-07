using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using ImageMagick;
using CB_Base.Classes;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.parser;
using System.Collections;
using System.Text.RegularExpressions;
using CB;

namespace CB_Base.Classes
{
    class PDFMakerNovo
    {
        public enum ColorBase
        {
            NEGRO,
            AZUL,
            CYAN,
            GRIS,
            VERDE,
            GRIS_CLARO,
            MAGENTA,
            NARANJA,
            ROSA,
            ROJO,
            BLANCO
        }

        public enum TipoFuente
        {
            CALIBRI
        }

        public enum AlinearFuente
        {
            ALIGN_BASELINE,
            ALIGN_BOTTOM,
            ALIGN_LEFT,
            ALIGN_CENTER
        }

        public void CrearFormatoCotizacion(int idCotizacion, string PathRemoto)
        {
            string pathRemoto = "\\SGC\\COTIZACIONES\\SECUENCIAOPERACIONES\\";
            string pathLocal = Directory.GetCurrentDirectory() + "\\SGC\\COTIZACIONES\\RECURSOS\\";
            string contenidoOriginalHtml = string.Empty;
            string pattern = string.Empty;
            string replace = string.Empty;
            string result = string.Empty;
            string nombreCliente = "N/A";
            int idCliente = 0;
            List<IElement> htmlarraylist = new List<IElement>();

            //Alcance y recursos
            List<CotizacionScopeRecursos> recursos = new List<CotizacionScopeRecursos>();
            CotizacionAlcance.Modelo().SeleccionarProcesosCotizaciones(idCotizacion).ForEach(delegate(Fila f)
            {
                List<string> stringAlcance = new List<string>();
                CotizacionAlcance .Modelo().SeleccionarAlcancePorProcesoCotizacion(idCotizacion, f.Celda<int>("proceso")).ForEach(delegate(Fila filaAlcance)
                {
                    stringAlcance.Add(filaAlcance.Celda("alcance").ToString());
                });

                CotizacionAlcance alcanceSumas = new CotizacionAlcance();
                alcanceSumas.SumarHorasPersonasCotizacion(idCotizacion, f.Celda<int>("proceso"));

                recursos.Add
                (
                    new CotizacionScopeRecursos(f.Celda("nombre").ToString(), Convert.ToInt32(Global.ObjetoATexto(alcanceSumas.Fila().Celda("personas"), "0")), Convert.ToDouble(Global.ObjetoATexto(alcanceSumas.Fila().Celda("horas"), "0").ToString()), stringAlcance)
                );
            });

            //Lista de pokayokes
            List<CotizacionPokaYokes> pokayokes = new List<CotizacionPokaYokes>();
            CotizacionPokayoke.Modelo().SeleccionarPokayokesDeCotizacion(idCotizacion).ForEach(delegate(Fila f)
            {
                pokayokes.Add
                (
                    new CotizacionPokaYokes(f.Celda("target").ToString(), f.Celda("alcance").ToString(), f.Celda("metodo").ToString())
                );
            });

            //Lista de proveedores
            List<CotizacionProveedor> proveedores = new List<CotizacionProveedor>() 
            {
                new CotizacionProveedor("SIEMENS", "6AV2-124-2DC01-0AX0", "SIMATIC HMI KTP400 COMFORT, COMFORT PANEL sfhsadfwerwqerqwerqRW"),
                new CotizacionProveedor("SIEMENS", "6ES75152AM010AB0", "SIMATIC S7-1500, CPU 1515-2 PN, CENTRAL PROCESSING"),
                new CotizacionProveedor("SIEMENS", "6ES75152AM010AB0", "SIMATIC S7-1500, CPU 1515-2 PN, CENTRAL PROCESSING")
            };

            //Lista de limitaciones
            List<string> limitaciones = new List<string>() 
            {
                "Software development for part numbers not listed in this quote is not included.",
                "Software development for part numbers not listed in this quote is not included.",
                "Software development for part numbers not listed in this quote is not included."
            };

           // Document doc = new Document(PageSize.LETTER);
            MyHeaderFooterEvent1 evento = new MyHeaderFooterEvent1();
            Document doc = new Document(PageSize.LETTER, 36, 36, 70 + evento.getTableHeight(), 56);

            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(NombreArchivoTemporal(), FileMode.Create));

            CotizacionClinte cotizacionCliente = new CotizacionClinte();
            cotizacionCliente.CargarDatos(idCotizacion);

            if (cotizacionCliente.TieneFilas())
            {
                idCliente = cotizacionCliente.Fila().Celda<int>("cliente");
                nombreCliente = cotizacionCliente.Fila().Celda("nombre_cotizacion").ToString();
            }

            writer.PageEvent = new MyHeaderFooterEvent1()
            {
                headerTexto = "Business solution proposal for:",
                ImagenLogoAudisel = CB_Base.Properties.Resources.audisel_logo_grande_test,
                ImagenLogoCliente = CB_Base.Properties.Resources.icono_pdf_down_48,
                FooterTexto = "T1XX MY2020 ASSEMBLY LINE",
                ClienteId = idCliente,
                NombreCliente = nombreCliente
            };

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("COTIZACION #" + idCotizacion.ToString().PadLeft(4,'0'));
            doc.AddCreator("Audisel Inc.");

            // Abrimos el archivo
            doc.Open();

            Font fuenteNormal = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);
            Font fuenteNormalPequena = new Font(Font.FontFamily.HELVETICA, 6, Font.NORMAL, BaseColor.BLACK);
            Font fuenteTitulosCelda = new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD, BaseColor.WHITE);
            Font fuenteSubtitulosTabla = new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD, BaseColor.BLACK);
            Font fuenteNormalNegritas = new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD, BaseColor.BLACK);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(8);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clScopeCabecera = new PdfPCell(new Phrase("Project scope", fuenteTitulosCelda));
            clScopeCabecera.BackgroundColor = new BaseColor(5, 44, 113);
            clScopeCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clScopeCabecera.Colspan = 8;

            // =======================

            PdfPTable tblProjectScope = new PdfPTable(1);
            tblPrueba.WidthPercentage = 100;

            // -----------------------

            PdfPTable tblListadoProyecto = new PdfPTable(4);
            tblListadoProyecto.WidthPercentage = 90;
            float[] widths = new float[] { 25, 54, 10,10 };
            tblListadoProyecto.SetWidths(widths);

            PdfPCell clProcessCabecera = new PdfPCell(new Phrase("Process", fuenteSubtitulosTabla));
            clProcessCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clProcessCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            PdfPCell clWorkspaceCabecera = new PdfPCell(new Phrase("Work scope", fuenteSubtitulosTabla));
            clWorkspaceCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clWorkspaceCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            PdfPCell clManCabecera = new PdfPCell(new Phrase("Man", fuenteSubtitulosTabla));
            clManCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clManCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            PdfPCell clHoursCabecera = new PdfPCell(new Phrase("Hours", fuenteSubtitulosTabla));
            clHoursCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clHoursCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            tblListadoProyecto.AddCell(clProcessCabecera);
            tblListadoProyecto.AddCell(clWorkspaceCabecera);
            tblListadoProyecto.AddCell(clManCabecera);
            tblListadoProyecto.AddCell(clHoursCabecera);

            foreach(CotizacionScopeRecursos recurso in recursos)
            { 
                PdfPCell clProcessContenido = new PdfPCell(new Phrase(recurso.Proceso, fuenteNormal));
                PdfPCell clWorkspaceContenido = new PdfPCell(new Phrase(recurso.AlcanceTrabajoString, fuenteNormal));
                PdfPCell clManContenido = new PdfPCell(new Phrase(recurso.Personas.ToString(), fuenteNormal));
                clManContenido.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                PdfPCell clHoursContenido = new PdfPCell(new Phrase(recurso.Horas.ToString(), fuenteNormal));
                clHoursContenido.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                tblListadoProyecto.AddCell(clProcessContenido);
                tblListadoProyecto.AddCell(clWorkspaceContenido);
                tblListadoProyecto.AddCell(clManContenido);
                tblListadoProyecto.AddCell(clHoursContenido);
            }

            // -----------------------

            PdfPCell clProjectLeyenda = new PdfPCell(new Phrase("Audisel will assign human resources to cover the technical specifications stated in this quotation, according to the following work scope:", fuenteNormal));
            clProjectLeyenda.BorderWidth = 0;

            PdfPCell clListadoProyecto = new PdfPCell(tblListadoProyecto);

            tblProjectScope.AddCell(clProjectLeyenda);
            tblProjectScope.AddCell(clListadoProyecto);

            // =======================

            PdfPCell clScopeContenido = new PdfPCell(tblProjectScope);
            clScopeContenido.Colspan = 8;
            clScopeContenido.Padding = 10f;

            tblPrueba.AddCell(clScopeCabecera);
            tblPrueba.AddCell(clScopeContenido);
            
            // Manufacturing process overview
            PdfPCell clManufacturingCabecera = new PdfPCell(new Phrase("Manufacturinng process overview", fuenteTitulosCelda));
            clManufacturingCabecera.BackgroundColor = new BaseColor(5, 44, 113);
            clManufacturingCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clManufacturingCabecera.Colspan = 8;

            PdfPCell clInputsCabecera = new PdfPCell(new Phrase("Inputs", fuenteSubtitulosTabla));
            clInputsCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clInputsCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clInputsCabecera.Colspan = 2;

            PdfPCell clOutputsCabecera = new PdfPCell(new Phrase("Outputs", fuenteSubtitulosTabla));
            clOutputsCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clOutputsCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clOutputsCabecera.Colspan = 2;

            PdfPCell clModelsCabecera = new PdfPCell(new Phrase("Models to run", fuenteSubtitulosTabla));
            clModelsCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clModelsCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clModelsCabecera.Colspan = 4;

            //Elementos de entradas
            string elementosEntradas = string.Empty;
            CotizacionEntrada entradas = new CotizacionEntrada();
            entradas.SeleccionarEntradasDeCotizacion(idCotizacion).ForEach(delegate(Fila f)
            {
                elementosEntradas += f.Celda("nombre").ToString() + System.Environment.NewLine;
            });

            PdfPCell clInputs = new PdfPCell(new Phrase(elementosEntradas, fuenteNormal));
            clInputs.Colspan = 2;

            //Elementos de salida
            string elementosSalida= string.Empty;
            CotizacionSalida salidas = new CotizacionSalida();
            salidas.SeleccionarSalidasDeCotizacion(idCotizacion).ForEach(delegate(Fila f)
            {
                elementosSalida += f.Celda("nombre").ToString() + System.Environment.NewLine;
            });

            PdfPCell clOutputs = new PdfPCell(new Phrase(elementosSalida, fuenteNormal));
            clOutputs.Colspan = 2;

            //Modelos a correr
            string listaModelos = string.Empty;
            CotizacionModelos modelos = new CotizacionModelos();
            modelos.SeleccionarModelosDeCotizacion(idCotizacion).ForEach(delegate(Fila f)
            {
                listaModelos += f.Celda("nombre").ToString() + ", ";
            });

            if(listaModelos != "")
                listaModelos = listaModelos.Remove(listaModelos.Length - 2);

            PdfPCell clModels = new PdfPCell(new Phrase(listaModelos, fuenteNormal));
            clModels.Colspan = 4;

            tblPrueba.AddCell(clManufacturingCabecera);
            tblPrueba.AddCell(clInputsCabecera);
            tblPrueba.AddCell(clOutputsCabecera);
            tblPrueba.AddCell(clModelsCabecera);
            tblPrueba.AddCell(clInputs);
            tblPrueba.AddCell(clOutputs);
            tblPrueba.AddCell(clModels);

            //INICIO DESCRIPCION DEL PRODUCTO RTF
            #region DESCRIPCION DEL PRODUCTO RTF
            PdfPCell clDescripcionContenido = new PdfPCell();
            clDescripcionContenido.Colspan = 8;

            //Bajar todo al current directory
            byte[] datos = ServidorFtp.DescargarArchivo(idCotizacion, FormatoArchivo.Rtf, PathRemoto + "DESCRIPCION\\");

            if (!Directory.Exists(pathLocal))
                Directory.CreateDirectory(pathLocal);

            if (datos != null)
            {
                
                File.WriteAllBytes(pathLocal + idCotizacion + ".rtf", datos);

                //descargamos html
                datos = ServidorFtp.DescargarArchivo(idCotizacion, FormatoArchivo.html, pathRemoto + "DESCRIPCION\\");
                File.WriteAllBytes(pathLocal + idCotizacion + ".html", datos);

                //descargamos css
                datos = ServidorFtp.DescargarArchivo(idCotizacion, FormatoArchivo.css, pathRemoto + "DESCRIPCION\\");
                File.WriteAllBytes(pathLocal + idCotizacion + "_STYLES.CSS".ToLower(), datos);
                //descargamos imagenes
                if (!Directory.Exists(pathLocal + idCotizacion + "_images\\"))
                    Directory.CreateDirectory(pathLocal + idCotizacion + "_images\\");

                ServidorFtp.DescargarDirectorio(pathRemoto + "DESCRIPCION\\" + idCotizacion + "_images\\", pathLocal + idCotizacion + "_images\\", idCotizacion);
                contenidoOriginalHtml = File.ReadAllText(pathLocal + idCotizacion + ".html");

                pattern = idCotizacion + "_images/";
                replace = pathLocal + idCotizacion + "_images/";
                result = Regex.Replace(contenidoOriginalHtml, pattern, replace);

                // var parsedHtmlElements = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmlText), null);
                htmlarraylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(result), null);

                //add the collection to the document
                for (int k = 0; k < htmlarraylist.Count; k++)
                {
                    //document.Add((IElement)htmlarraylist[k]);
                    clDescripcionContenido.AddElement((IElement)htmlarraylist[k]);
                }
            }

            tblPrueba.AddCell(clDescripcionContenido);

            if(Directory.Exists(pathLocal))
                Directory.Delete(pathLocal, true);

            #endregion DESCRIPCION RTF
            // FIN DESCRIPCION DEL PRODUCTO

            // INICIO SECUENCIA DE OPERACIONES
            #region SECUENCIA DE OPERACIONES
            PdfPCell clOpseqCabecera = new PdfPCell(new Phrase("Operation sequence", fuenteTitulosCelda));
            clOpseqCabecera.BackgroundColor = new BaseColor(5, 44, 113);
            clOpseqCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clOpseqCabecera.Colspan = 8;

            PdfPCell clOpseqContenido = new PdfPCell();
            clOpseqContenido.Colspan = 8;

            //Bajar todo al current directory
            datos = ServidorFtp.DescargarArchivo(idCotizacion, FormatoArchivo.Rtf, PathRemoto);

            if (datos != null)
            {
                if (!Directory.Exists(pathLocal))
                    Directory.CreateDirectory(pathLocal);

                File.WriteAllBytes(pathLocal + idCotizacion + ".rtf", datos);

                //descargamos html
                datos = ServidorFtp.DescargarArchivo(idCotizacion, FormatoArchivo.html, pathRemoto);
                File.WriteAllBytes(pathLocal + idCotizacion + ".html", datos);

                //descargamos css
                datos = ServidorFtp.DescargarArchivo(idCotizacion, FormatoArchivo.css, pathRemoto);
                File.WriteAllBytes(pathLocal + idCotizacion + "_STYLES.CSS".ToLower(), datos);

                //descargamos imagenes
                if (!Directory.Exists(pathLocal + idCotizacion + "_images\\"))
                    Directory.CreateDirectory(pathLocal + idCotizacion + "_images\\");

                ServidorFtp.DescargarDirectorio(pathRemoto + idCotizacion + "_images\\", pathLocal + idCotizacion + "_images\\", idCotizacion);

                //SECUENCIA DE OPERACIONES RTF
                contenidoOriginalHtml = File.ReadAllText(pathLocal + idCotizacion + ".html");

                pattern = idCotizacion + "_images/";
                replace = pathLocal + idCotizacion + "_images/";
                result = Regex.Replace(contenidoOriginalHtml, pattern, replace);

                // var parsedHtmlElements = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmlText), null);
                htmlarraylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(result), null);

                //add the collection to the document
                for (int k = 0; k < htmlarraylist.Count; k++)
                {
                    //document.Add((IElement)htmlarraylist[k]);
                    clOpseqContenido.AddElement((IElement)htmlarraylist[k]);
                }
            }

            if (Directory.Exists(pathLocal))
                Directory.Delete(pathLocal, true);

            tblPrueba.AddCell(clOpseqCabecera);
            tblPrueba.AddCell(clOpseqContenido);
            #endregion FINALIZA SECUENCIA DE OPERACIONES
            //FIN DE SECUENCIA DE OPERACIONES RTF

            // Pokayoka
            PdfPCell clPokayokaCabecera = new PdfPCell(new Phrase("List of Poka-yokes", fuenteTitulosCelda));
            clPokayokaCabecera.BackgroundColor = new BaseColor(5, 44, 113);
            clPokayokaCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clPokayokaCabecera.Colspan = 8;

            PdfPCell clTargetCabecera = new PdfPCell(new Phrase("Target", fuenteSubtitulosTabla));
            clTargetCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clTargetCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clTargetCabecera.Colspan = 2;

            PdfPCell clScope2Cabecera = new PdfPCell(new Phrase("Scope", fuenteSubtitulosTabla));
            clScope2Cabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clScope2Cabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clScope2Cabecera.Colspan = 4;

            PdfPCell clMethodCabecera = new PdfPCell(new Phrase("Method", fuenteSubtitulosTabla));
            clMethodCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clMethodCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clMethodCabecera.Colspan = 2;

            tblPrueba.AddCell(clPokayokaCabecera);
            tblPrueba.AddCell(clTargetCabecera);
            tblPrueba.AddCell(clScope2Cabecera);
            tblPrueba.AddCell(clMethodCabecera);

            foreach (CotizacionPokaYokes poka in pokayokes)
            {
                PdfPCell clTargetContenido = new PdfPCell(new Phrase(poka.Target, fuenteNormal));
                clTargetContenido.Colspan = 2;

                PdfPCell clScope2Contenido = new PdfPCell(new Phrase(poka.Alcance, fuenteNormal));
                clScope2Contenido.Colspan = 4;

                PdfPCell clMethodContenido = new PdfPCell(new Phrase(poka.Metodo, fuenteNormal));
                clMethodContenido.Colspan = 2;

                tblPrueba.AddCell(clTargetContenido);
                tblPrueba.AddCell(clScope2Contenido);
                tblPrueba.AddCell(clMethodContenido);
            }

            // Equipment requirements
            PdfPCell clEqreqCabecera = new PdfPCell(new Phrase("Equipment requirements", fuenteTitulosCelda));
            clEqreqCabecera.BackgroundColor = new BaseColor(5, 44, 113);
            clEqreqCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clEqreqCabecera.Colspan = 8;

            PdfPCell clStandardCabecera = new PdfPCell(new Phrase("Standard machine modules", fuenteSubtitulosTabla));
            clStandardCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clStandardCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clStandardCabecera.Colspan = 4;

            PdfPCell clCustomCabecera = new PdfPCell(new Phrase("Custom machine systems", fuenteSubtitulosTabla));
            clCustomCabecera.BackgroundColor = new BaseColor(197, 197, 199);
            clCustomCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clCustomCabecera.Colspan = 4;


            Phrase phrModulosEstandar = new Phrase();
            

            ModuloEstandar.Modelo().SeleccionarDatos("", null).ForEach(delegate(Fila filaModulo)
            {
                int contador = 0;
                ModuloEstandarCotizacion.Modelo().SeleccionarCaracteristicaYOpciones(Convert.ToInt32(filaModulo.Celda("id")), idCotizacion).ForEach(delegate(Fila filaCaracteristicas)
                {
                    if(contador == 0)
                        phrModulosEstandar.Add(new Chunk(" \u2022   " + filaModulo.Celda("nombre").ToString() + Environment.NewLine, fuenteNormalNegritas));
                    phrModulosEstandar.Add(new Chunk("          " + filaCaracteristicas.Celda("caracteristica").ToString() + ": " + filaCaracteristicas.Celda("opcion").ToString() + Environment.NewLine, fuenteNormal));
                    contador++;
                });
            });





            //MOdulos estandar
            PdfPCell clStandardContenido = new PdfPCell(phrModulosEstandar); //PdfPCell(new Phrase("- LOWER STRUCTURE.\n- MAIN TOOLING PLATE.\n- UPPER STRUCTURE.\n- DIAL INDEX SYSTEM.", fuenteNormal));
            clStandardContenido.Colspan = 4;

            PdfPCell clCustomContenido = new PdfPCell(new Phrase("- FIXTURES\n- PNEUMATIC ASSEMBLY SYSTEM", fuenteNormal));
            clCustomContenido.Colspan = 4;

            tblPrueba.AddCell(clEqreqCabecera);
            tblPrueba.AddCell(clStandardCabecera);
            tblPrueba.AddCell(clCustomCabecera);
            tblPrueba.AddCell(clStandardContenido);
            tblPrueba.AddCell(clCustomContenido);

            // Purchased part numbers
            PdfPCell clPurchasedCabecera = new PdfPCell(new Phrase("Purchased part numbers", fuenteTitulosCelda));
            clPurchasedCabecera.BackgroundColor = new BaseColor(5, 44, 113);
            clPurchasedCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clPurchasedCabecera.Colspan = 8;

            tblPrueba.AddCell(clPurchasedCabecera);
            
            foreach(CotizacionProveedor prov in proveedores)
            {
                PdfPCell clLogo1 = new PdfPCell(new Phrase("Logo", fuenteNormal));
                clLogo1.Colspan = 1;
                PdfPCell clInfo1 = new PdfPCell(new Phrase(prov.InfoDespliegue, fuenteNormal));
                clInfo1.Colspan = 3;

                tblPrueba.AddCell(clLogo1);
                tblPrueba.AddCell(clInfo1);
            }

            if(proveedores.Count % 2 != 0)
            {
                PdfPCell clLogo1 = new PdfPCell();
                clLogo1.Colspan = 1;
                PdfPCell clInfo1 = new PdfPCell();
                clInfo1.Colspan = 3;

                tblPrueba.AddCell(clLogo1);
                tblPrueba.AddCell(clInfo1);
            }

            // Exclusions and limitations
            PdfPCell clExclusionsCabecera = new PdfPCell(new Phrase("Exclusions and limitations", fuenteTitulosCelda));
            clExclusionsCabecera.BackgroundColor = new BaseColor(5, 44, 113);
            clExclusionsCabecera.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            clExclusionsCabecera.Colspan = 8;

            tblPrueba.AddCell(clExclusionsCabecera);

            string limitacionesString = "";

            for(int l = 0; l < limitaciones.Count; l++)
            {
                limitacionesString += (l + 1).ToString() + ". " + limitaciones[l];

                if(l < limitaciones.Count - 1)
                {
                    limitacionesString += "\n";
                }
            }

            PdfPCell clExclusionsContenido = new PdfPCell(new Phrase(limitacionesString, fuenteNormal));
            clExclusionsContenido.Colspan = 8;
            
            tblPrueba.AddCell(clExclusionsContenido);

            // Cierre de documento
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();
            
        }

        public void CrearPDF()
        {
            // ===========================================

            ResumenCostoCotizacion cotizacionADesplegar1 = new ResumenCostoCotizacion(
                "Primera cotización",
                5,
                new List<ResumenCostoCategoria>() {
                    new ResumenCostoCategoria {
                        nombre = "Labor (HR)",
                        conceptos = new List<ResumenCostoConcepto>() {
                            new ResumenCostoConcepto("Mecánico", 5f, 5),
                            new ResumenCostoConcepto("Eléctrico", 5f, 6),
                            new ResumenCostoConcepto("Fabricación", 5f, 9)
                            }
                    },
                    new ResumenCostoCategoria {
                        nombre = "Inversión",
                        conceptos = new List<ResumenCostoConcepto>() {
                            new ResumenCostoConcepto("Mecánico", 5f, 5),
                            new ResumenCostoConcepto("Eléctrico", 5f, 6),
                            new ResumenCostoConcepto("Fabricación", 5f, 9)
                            }
                    }
                });

            ResumenCostoCotizacion cotizacionADesplegar2 = new ResumenCostoCotizacion(
                "Segunda cotización",
                5,
                new List<ResumenCostoCategoria>() {
                    new ResumenCostoCategoria {
                        nombre = "Labor (HR)",
                        conceptos = new List<ResumenCostoConcepto>() {
                            new ResumenCostoConcepto("Mecánico", 5f, 5),
                            new ResumenCostoConcepto("Eléctrico", 5f, 6),
                            new ResumenCostoConcepto("Fabricación", 5f, 9)
                            }
                    },
                    new ResumenCostoCategoria {
                        nombre = "Inversión",
                        conceptos = new List<ResumenCostoConcepto>() {
                            new ResumenCostoConcepto("Mecánico", 5f, 5),
                            new ResumenCostoConcepto("Eléctrico", 5f, 6),
                            new ResumenCostoConcepto("Fabricación", 5f, 9)
                            }
                    }
                });

            ResumenCostoDesglose desglose = new ResumenCostoDesglose(new List<ResumenCostoCotizacion>()
            {
                cotizacionADesplegar1,
                cotizacionADesplegar2
            }, 0.1f);

            // ===========================================

            Document doc = new Document(PageSize.LETTER); 
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(NombreArchivoTemporal(), FileMode.Create, FileAccess.Write));

            writer.PageEvent = new MyHeaderFooterEvent1()
            {
                headerTexto = "Business solution proposal for:",
                ImagenLogoAudisel = CB_Base.Properties.Resources.audisel_logo_grande_test,
                ImagenLogoCliente = CB_Base.Properties.Resources.icono_pdf_down_48,
                FooterTexto = "T1XX MY2020 ASSEMBLY LINE"
            };


            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Salvador Nevarez Castellanos");

            // Abrimos el archivo
            doc.Open();

           // jj

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            // doc.Add(new Paragraph("Mi primer documento PDF"));
            // doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(8);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clItem = new PdfPCell(new Phrase("Item", _standardFont));

            PdfPCell clSummary = new PdfPCell(new Phrase("SUMMARY COST", _standardFont));
            clSummary.Colspan = 7;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clItem);
            tblPrueba.AddCell(clSummary);

            #region Conceptos

            for (int k = 0; k < desglose.cotizaciones.Count; k++)
            {
                // Imprimir conceptos
                PdfPTable tblCategoria = new PdfPTable(7);
                tblCategoria.WidthPercentage = 100;

                // Cabeceras de la tabla
                PdfPCell clHeadCotizacion = new PdfPCell(new Phrase(desglose.cotizaciones[k].nombre, _standardFont));
                clHeadCotizacion.Colspan = 2;

                PdfPCell clHeadEntrega = new PdfPCell(new Phrase("Tiempo de Entrega", _standardFont));
                PdfPCell clHeadPrecioUnidad = new PdfPCell(new Phrase("Precio Unidad", _standardFont));
                PdfPCell clHeadQty = new PdfPCell(new Phrase("Qty", _standardFont));
                PdfPCell clHeadExtPrice = new PdfPCell(new Phrase("Ext. Price", _standardFont));
                PdfPCell clHeadPrecioTotal = new PdfPCell(new Phrase("Precio Total", _standardFont));

                tblCategoria.AddCell(clHeadCotizacion);
                tblCategoria.AddCell(clHeadEntrega);
                tblCategoria.AddCell(clHeadPrecioUnidad);
                tblCategoria.AddCell(clHeadQty);
                tblCategoria.AddCell(clHeadExtPrice);

                tblCategoria.AddCell(clHeadPrecioTotal);
                // Información procedural

                PdfPCell clTituloCategoria = new PdfPCell();
                PdfPCell clTiempoEntrega = new PdfPCell();
                PdfPCell clPrecioTotal = new PdfPCell();
            
                PdfPCell clTituloConcepto = new PdfPCell();
                PdfPCell clPrecioUnidad = new PdfPCell();
                PdfPCell clQty = new PdfPCell();
                PdfPCell clExPrice = new PdfPCell();

                for (int i = 0; i < desglose.cotizaciones[k].categorias.Count; i++)
                {

                    clTituloCategoria = new PdfPCell(new Phrase(desglose.cotizaciones[k].categorias[i].nombre, _standardFont));
                    clTituloCategoria.Rowspan = desglose.cotizaciones[k].categorias[i].conceptos.Count;
                    clTituloCategoria.VerticalAlignment = Element.ALIGN_CENTER;

                    clTiempoEntrega = new PdfPCell(new Phrase(desglose.cotizaciones[k].tiempoEntrega.ToString(), _standardFont));
                    clTiempoEntrega.Rowspan = desglose.cotizaciones[k].TotalConceptos;
                    clTiempoEntrega.VerticalAlignment = Element.ALIGN_CENTER;

                    clPrecioTotal = new PdfPCell(new Phrase(desglose.cotizaciones[k].PrecioTotal.ToString(), _standardFont));
                    clPrecioTotal.Rowspan = desglose.cotizaciones[k].TotalConceptos;
                    clPrecioTotal.VerticalAlignment = Element.ALIGN_CENTER;

                    // Imprimir conceptos

                    for (int j = 0; j < desglose.cotizaciones[k].categorias[i].conceptos.Count; j++)
                    {
                        ResumenCostoConcepto concepto = desglose.cotizaciones[k].categorias[i].conceptos[j];

                        clTituloConcepto = new PdfPCell(new Phrase(concepto.nombre, _standardFont));
                        clPrecioUnidad = new PdfPCell(new Phrase(concepto.precioUnidad.ToString(), _standardFont));
                        clQty = new PdfPCell(new Phrase(concepto.qty.ToString(), _standardFont));
                        clExPrice = new PdfPCell(new Phrase(concepto.PrecioTotal.ToString(), _standardFont));

                        if(j == 0)
                            tblCategoria.AddCell(clTituloCategoria);
                        tblCategoria.AddCell(clTituloConcepto);

                        if (i == 0 && j == 0)
                            tblCategoria.AddCell(clTiempoEntrega);

                        tblCategoria.AddCell(clPrecioUnidad);
                        tblCategoria.AddCell(clQty);
                        tblCategoria.AddCell(clExPrice);

                        if (i == 0 && j == 0)
                            tblCategoria.AddCell(clPrecioTotal);
                    }
                }

                PdfPCell clNumCategoria = new PdfPCell(new Phrase((k + 1).ToString(), _standardFont));

                PdfPCell clTablaConceptos = new PdfPCell(tblCategoria);
                clTablaConceptos.Colspan = 7;

                // tblPrueba.AddCell(clItem);
                tblPrueba.AddCell(clNumCategoria);
                tblPrueba.AddCell(clTablaConceptos);

            }

            #endregion /Conceptos

            // Agregar totales
            PdfPCell clTituloSubtotal = new PdfPCell(new Phrase("SUB TOTAL", _standardFont));
            clTituloSubtotal.Colspan = 4;

            PdfPCell clSubtotal = new PdfPCell(new Phrase(desglose.SubTotal.ToString(), _standardFont));
            clSubtotal.Colspan = 4;

            tblPrueba.AddCell(clTituloSubtotal);
            tblPrueba.AddCell(clSubtotal);

            PdfPCell clTituloTotal = new PdfPCell(new Phrase("TOTAL", _standardFont)); ;
            clTituloTotal.Colspan = 4;

            PdfPCell clDescuento = new PdfPCell(new Phrase("Con " + (desglose.descuento * 100) + "% de descuento", _standardFont));
            clDescuento.Colspan = 2;

            PdfPCell clTotal = new PdfPCell(new Phrase(desglose.PrecioTotal.ToString(), _standardFont));
            clTotal.Colspan = 2;

            tblPrueba.AddCell(clTituloTotal);

            tblPrueba.AddCell(clDescuento);
            tblPrueba.AddCell(clTotal);

            doc.Add(tblPrueba);
            // doc.Add(tblCategoria);

            doc.Close();
            writer.Close();
        }

        public string NombreArchivoTemporal()
        {
            return /*System.IO.Path.GetTempPath()*/@"C:/Users/Eilean Laborde/Desktop/" + Guid.NewGuid().ToString() + ".pdf";
        }

        /// <summary>
        /// Agregar párrafo
        /// </summary>
        /// <param name="texto">Texto del párrafo</param>
        /// <returns>Paragraph</returns>
        public Paragraph Parrafo(Phrase texto)
        {
            Paragraph parrafo = new Paragraph();
            parrafo.Add(texto);
            return parrafo;
        }

        public Phrase Frases(string texto, Font fuente)
        {
            Phrase p = new Phrase(texto, fuente);
            return p;
        }

        public Font Fuente(TipoFuente fuente = TipoFuente.CALIBRI, int tamano = 11, ColorBase color = ColorBase.NEGRO, bool negritas = false)
        {
            Font normal;

            if (negritas)
                normal = FontFactory.GetFont(fuente.ToString().ToLower(), tamano, 1, ColorBaseM(color));
            else
                normal = FontFactory.GetFont(fuente.ToString().ToLower(), tamano, ColorBaseM(color));
            return normal;
        }

        public BaseColor ColorBaseM(ColorBase colorBase)
        {
            BaseColor color = BaseColor.BLACK;
            switch (colorBase.ToString())
            {
                case "NEGRO":
                    color = BaseColor.BLACK;
                    break;
                case "AZUL":
                    color = BaseColor.BLUE;
                    break;
                case "CYAN":
                    color = BaseColor.CYAN;
                    break;
                case "GRIS_OSCURO":
                    color = BaseColor.DARK_GRAY;
                    break;
                case "MAGENTA":
                    color = BaseColor.MAGENTA;
                    break;
                case "VERDE":
                    color = BaseColor.GREEN;
                    break;
                case "GRIS_CLARO":
                    color = BaseColor.LIGHT_GRAY;
                    break;
                case "NARANJA":
                    color = BaseColor.ORANGE;
                    break;
                case "ROSA":
                    color = BaseColor.PINK;
                    break;
                case "ROJO":
                    color = BaseColor.RED;
                    break;
                case "BLANCO":
                    color = BaseColor.WHITE;
                    break;
            }

            return color;
        }

        byte[] CrearArchivo(string temp)
        {
            byte[] datosPDF;

            using (FileStream pdf = File.OpenRead(temp + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }
    }

    public class MyHeaderFooterEvent1 : PdfPageEventHelper
    {
        Font ColorFuenteHeader = FontFactory.GetFont("Calibri Light (Headings)", 8, new BaseColor(46, 116, 181));
        Font ColorFuenteFooter = FontFactory.GetFont("Calibri Light (Headings)", 8, new BaseColor(46, 116, 181));
        Font Font = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD);

        public string headerTexto { get; set; }
        public string FooterTexto { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }

        public System.Drawing.Bitmap ImagenLogoAudisel { get; set; }
        public System.Drawing.Bitmap ImagenLogoCliente { get; set; }

        protected PdfPTable table;
        protected float tableHeight;
        protected string PathRemoto = "SGC\\CLIENTES\\";
        public PdfPTable HeaderTable()
        {
            table = new PdfPTable(1);
            table.TotalWidth = 523;
            table.LockedWidth = true;
            table.AddCell("Header row 1");
            table.AddCell("Header row 2");
            table.AddCell("Header row 3");
            tableHeight = table.TotalHeight;
            return table;
        }

        public float getTableHeight() 
        {
            return tableHeight;
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            //crear tabla de encabezado
            PdfPTable tbHeader = new PdfPTable(3);
            tbHeader.DefaultCell.Border = 0;
            tbHeader.HeaderRows = 1;
            int[] intTblWidth = { 33, 33, 33 };
            tbHeader.SetWidths(intTblWidth);
            tbHeader.DefaultCell.FixedHeight = 36;
            tbHeader.TotalWidth = document.PageSize.Width - (document.RightMargin + document.LeftMargin);

            //agregar logo Audisel
            Image logoAudisel = Image.GetInstance(CB_Base.Properties.Resources.audisel_logo_grande_test, BaseColor.WHITE);
            logoAudisel.ScaleToFit(90, 50);
            logoAudisel.Alignment = Image.ALIGN_LEFT;

            Image logoCliente = null;

            //agregar logo Cliente
            if (ClienteId > 0)
            {
                byte[] datos = ServidorFtp.DescargarArchivo(ClienteId, FormatoArchivo.Png, PathRemoto);
                System.Drawing.Image imagen = Global.ByteAImagen(datos);

                logoCliente = Image.GetInstance(imagen, BaseColor.WHITE);//(CB_Base.Properties.Resources.audisel_logo_grande_test, BaseColor.WHITE);
                logoCliente.ScaleToFit(90, 50);
                logoCliente.Alignment = Image.ALIGN_RIGHT;
            }
            else
            {
                logoCliente = Image.GetInstance(CB_Base.Properties.Resources.audisel_logo_grande_test, BaseColor.WHITE);
                logoCliente.ScaleToFit(90, 50);
                logoCliente.Alignment = Image.ALIGN_RIGHT;
            }

            PdfPCell celdaLogoAudisel = new PdfPCell(logoAudisel);
            celdaLogoAudisel.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            celdaLogoAudisel.Border = 0;

            PdfPCell celdaLogoCliente = new PdfPCell(logoCliente);
            celdaLogoCliente.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            celdaLogoCliente.Border = 0;

            PdfPCell celdaTexto = new PdfPCell(new Phrase("Business solution proposal:" + Environment.NewLine + NombreCliente + Environment.NewLine + "www.audisel.com", ColorFuenteHeader));
            celdaTexto.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celdaTexto.Border = 0;

            //se agregan las celdas
            tbHeader.AddCell(celdaLogoAudisel);
            tbHeader.AddCell(celdaTexto);
            tbHeader.AddCell(celdaLogoCliente);

            tbHeader.WriteSelectedRows(0, -1,
            document.LeftMargin,
            document.Top + ((document.TopMargin + tableHeight) / 2),
            writer.DirectContent);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte canvas = writer.DirectContent;

            PdfPTable tbFooter = new PdfPTable(2);
            tbFooter.DefaultCell.Border = Rectangle.NO_BORDER;
            tbFooter.FooterRows = 1;
            int[] intTblWidth = { 50, 50};
            tbFooter.SetWidths(intTblWidth);
            tbFooter.DefaultCell.FixedHeight = 30;
            tbFooter.TotalWidth = document.PageSize.Width - (document.RightMargin + document.LeftMargin);

            //agregar logo iso
            Image logoIso = Image.GetInstance(CB_Base.Properties.Resources.iso9000, BaseColor.WHITE);
            logoIso.ScaleToFit(40, 40);
            logoIso.Alignment = Image.ALIGN_CENTER;

            PdfPCell piePagina = new PdfPCell(logoIso);
            piePagina.HorizontalAlignment = Element.ALIGN_RIGHT;
            piePagina.VerticalAlignment = Element.ALIGN_CENTER;
            piePagina.BorderWidth = 0;

            PdfPCell ImagenPiePagina = new PdfPCell(new Phrase(Environment.NewLine + FooterTexto + Environment.NewLine + "Page " + writer.CurrentPageNumber.ToString(), ColorFuenteFooter)); 
            //+ " of " + writer.PageNumber, ColorFuenteFooter));
            ImagenPiePagina.HorizontalAlignment = Element.ALIGN_LEFT;
            ImagenPiePagina.VerticalAlignment = Element.ALIGN_CENTER;
            ImagenPiePagina.BorderWidth = 0;

            tbFooter.AddCell(ImagenPiePagina);
            tbFooter.AddCell(piePagina);

            tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin -3, writer.DirectContent);
        }
    }   
}

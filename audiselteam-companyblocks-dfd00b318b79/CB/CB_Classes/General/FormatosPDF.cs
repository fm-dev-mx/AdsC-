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
using System.ComponentModel;
using ImageMagick;
using System.Threading;
using CB_Base.Classes;
using CB;

namespace CB_Base.Classes
{
    public static class FormatosPDF
    {
        public static byte[] RFQMaterial_MX(int IdUsuario, int IdContacto, string notas, RfqMaterial material)
        {
            //if(!material.TieneFilas()) return;
            byte[] datosPDF;

            // Define el nombre del archivo temporal
            int IdRfq = Convert.ToInt32(material.Fila().Celda("id"));
            int IdProveedor = Convert.ToInt32(material.Fila().Celda("proveedor"));

            string nombreContacto = "";
            string correoContacto = "";

            Proveedor proveedor = new Proveedor();
            proveedor.CargarDatos(IdProveedor);

            ProveedorContacto contacto = new ProveedorContacto();
            contacto.CargarDatos(IdContacto);

            if (contacto.TieneFilas())
            {
                nombreContacto = contacto.Fila().Celda("nombre").ToString() + " " + contacto.Fila().Celda("apellidos").ToString();
                correoContacto = contacto.Fila().Celda("correo").ToString();
            }

            Usuario usr = new Usuario();
            usr.CargarDatos(IdUsuario);

            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 11, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 11, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 11, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 16, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 14, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(170, 78);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
            logo.IndentationLeft = 9;
            logo.SpacingAfter = 30;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("SOLICITUD DE COTIZACION" + Environment.NewLine, title));
            titulo.Add(new Phrase("RFQ #" + IdRfq.ToString() + Environment.NewLine + Environment.NewLine, negrita));

            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), normal));
            titulo.Alignment = Element.ALIGN_RIGHT;

            // Tabla de datos
            Paragraph ptablaDatos = new Paragraph();
            ptablaDatos.SpacingBefore = 20;
            ptablaDatos.Alignment = Element.ALIGN_LEFT;
            PdfPTable tablaDatos = new PdfPTable(2);
            tablaDatos.WidthPercentage = 100;

            // Header datos del solicitante
            PdfPCell headerSolicitante = new PdfPCell(new Phrase("DATOS DEL SOLICITANTE", tableHeader));
            headerSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.VerticalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del proveedor
            PdfPCell headerProveedor = new PdfPCell(new Phrase("DATOS DEL PROVEEDOR", tableHeader));
            headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProveedor.VerticalAlignment = Element.ALIGN_CENTER;
            headerProveedor.BackgroundColor = new BaseColor(16, 5, 92);

            // Datos del solicitante
            PdfPCell datosSolicitante = new PdfPCell();
            p = new Paragraph(usr.Fila().Celda("nombre").ToString() + " " + usr.Fila().Celda("paterno").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 10;
            datosSolicitante.AddElement(p);
            p = new Paragraph(usr.Fila().Celda("correo").ToString() + Environment.NewLine, smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosSolicitante.AddElement(p);

            // Datos del proveedor
            PdfPCell datosProveedor = new PdfPCell();
            p = new Paragraph(proveedor.Fila().Celda("nombre").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            p = new Paragraph(proveedor.Fila().Celda("razon_social").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            p = new Paragraph(nombreContacto + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            p = new Paragraph(correoContacto, smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosProveedor.AddElement(p);

            PdfPRow row = new PdfPRow(new PdfPCell[] { headerSolicitante, headerProveedor });
            tablaDatos.Rows.Add(row);

            row = new PdfPRow(new PdfPCell[] { datosSolicitante, datosProveedor });
            tablaDatos.Rows.Add(row);

            // Mensaje del solicitante
            Paragraph pmensaje = new Paragraph("Estimado proveedor favor de cotizar los siguientes números de parte:", normal);
            pmensaje.SpacingBefore = 10;

            // Agrega la tabla de partidas

            // Partidas
            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(5);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 10, 20, 15, 40, 15 };
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("#", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

            // Header numero de parte
            PdfPCell headerNumeroDeParte = new PdfPCell(new Phrase("NUM. DE PARTE", tableHeader));
            headerNumeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fabricante
            PdfPCell headerFabricante = new PdfPCell(new Phrase("FABRICANTE", tableHeader));
            headerFabricante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFabricante.VerticalAlignment = Element.ALIGN_CENTER;
            headerFabricante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPCION", tableHeader));
            headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad estimada
            PdfPCell headerCantidadEstimada = new PdfPCell(new Phrase("CANTIDAD ESTIMADA", tableHeader));
            headerCantidadEstimada.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidadEstimada.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidadEstimada.BackgroundColor = new BaseColor(16, 5, 92);

            row = new PdfPRow(new PdfPCell[] { headerPartida, headerNumeroDeParte, headerFabricante, headerDescripcion, headerCantidadEstimada });
            tablaPartidas.Rows.Add(row);


            int numPartida = 1;
            RfqConcepto.Modelo().SeleccionarRfq(IdRfq).ForEach(delegate(Fila concepto)
            {
                string strCantidadEstimada = concepto.Celda("total_estimada").ToString();//concepto.Celda("cantidad_estimada").ToString();

                if (concepto.Celda("tipo_venta").ToString() == "POR PIEZA")
                {
                    strCantidadEstimada += " PZS.";
                }
                else if (concepto.Celda("tipo_venta").ToString() == "POR PAQUETE")
                {
                    strCantidadEstimada += " PAQ.";
                }

                // partida
                PdfPCell partida = new PdfPCell(new Phrase("Partida " + numPartida.ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;

                // numero de parte
                PdfPCell numeroDeParte = new PdfPCell(new Phrase(concepto.Celda("numero_parte").ToString(), smallNegrita));
                numeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
                numeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell fabricante = new PdfPCell(new Phrase(concepto.Celda("fabricante").ToString(), small));
                fabricante.HorizontalAlignment = Element.ALIGN_CENTER;
                fabricante.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell descripcion = new PdfPCell(new Phrase(concepto.Celda("descripcion").ToString(), small));
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                descripcion.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad estimada
                PdfPCell cantidad_estimada = new PdfPCell(new Phrase(strCantidadEstimada, small));
                cantidad_estimada.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad_estimada.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad_estimada });
                tablaPartidas.Rows.Add(row);

                numPartida++;
            });

            // Comentarios / notas
            Paragraph pcomentarios = new Paragraph();
            if (notas != "")
            {
                pcomentarios.Add(new Phrase("Notas:\n", negrita));
                pcomentarios.Add(new Phrase(notas, normal));
                pcomentarios.SpacingBefore = 10;
            }

            ptablaPartidas.Add(tablaPartidas);
            ptablaDatos.Add(tablaDatos);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaDatos);
            doc.Add(pmensaje);
            doc.Add(ptablaPartidas);
            doc.Add(pcomentarios);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] RFQMaterial_US(int IdUsuario, int IdContacto, string notas, RfqMaterial material)
        {
            //if(!material.TieneFilas()) return;
            byte[] datosPDF;

            // Define el nombre del archivo temporal
            int IdRfq = Convert.ToInt32(material.Fila().Celda("id"));
            int IdProveedor = Convert.ToInt32(material.Fila().Celda("proveedor"));

            Proveedor proveedor = new Proveedor();
            proveedor.CargarDatos(IdProveedor);

            ProveedorContacto contacto = new ProveedorContacto();
            contacto.CargarDatos(IdContacto);

            Usuario usr = new Usuario();
            usr.CargarDatos(IdUsuario);

            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 11, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font verySmall = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 11, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 11, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 16, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 14, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_audisel_inc_white, BaseColor.WHITE);
            logo.ScaleToFit(225, 80);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("REQUEST FOR QUOTE" + Environment.NewLine, title));
            titulo.Add(new Phrase("RFQ #" + IdRfq.ToString() + Environment.NewLine + Environment.NewLine, negrita));
            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), normal));
            titulo.Alignment = Element.ALIGN_RIGHT;

            // Tabla de datos
            Paragraph ptablaDatos = new Paragraph();
            ptablaDatos.SpacingBefore = 20;
            PdfPTable tablaDatos = new PdfPTable(2);
            tablaDatos.WidthPercentage = 100;

            // Header datos del solicitante
            PdfPCell headerSolicitante = new PdfPCell(new Phrase("REQUESTED BY", tableHeader));
            headerSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.VerticalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del proveedor
            PdfPCell headerProveedor = new PdfPCell(new Phrase("SUPPLIER INFORMATION", tableHeader));
            headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProveedor.VerticalAlignment = Element.ALIGN_CENTER;
            headerProveedor.BackgroundColor = new BaseColor(16, 5, 92);

            // Datos del solicitante
            PdfPCell datosSolicitante = new PdfPCell();
            p = new Paragraph(usr.Fila().Celda("nombre").ToString() + " " + usr.Fila().Celda("paterno").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 10;
            datosSolicitante.AddElement(p);
            p = new Paragraph(usr.Fila().Celda("correo").ToString() + Environment.NewLine, smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosSolicitante.AddElement(p);

            // Datos del proveedor
            PdfPCell datosProveedor = new PdfPCell();
            p = new Paragraph(proveedor.Fila().Celda("nombre").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            p = new Paragraph(proveedor.Fila().Celda("razon_social").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            p = new Paragraph(contacto.Fila().Celda("nombre").ToString() + " " + contacto.Fila().Celda("apellidos").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            p = new Paragraph(contacto.Fila().Celda("correo").ToString(), smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosProveedor.AddElement(p);

            PdfPRow row = new PdfPRow(new PdfPCell[] { headerSolicitante, headerProveedor });
            tablaDatos.Rows.Add(row);

            row = new PdfPRow(new PdfPCell[] { datosSolicitante, datosProveedor });
            tablaDatos.Rows.Add(row);

            // Mensaje del solicitante
            Paragraph pmensaje = new Paragraph("Dear supplier, please quote the following part numbers:", normal);
            pmensaje.SpacingBefore = 10;

            // Agrega la tabla de partidas

            // Partidas
            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(5);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 5, 25, 15, 40, 15 };
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("#", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

            // Header numero de parte
            PdfPCell headerNumeroDeParte = new PdfPCell(new Phrase("PART NUMBER", tableHeader));
            headerNumeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fabricante
            PdfPCell headerFabricante = new PdfPCell(new Phrase("BRAND", tableHeader));
            headerFabricante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFabricante.VerticalAlignment = Element.ALIGN_CENTER;
            headerFabricante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPTION", tableHeader));
            headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad estimada
            PdfPCell headerCantidadEstimada = new PdfPCell(new Phrase("ESTIMATED QTY.", tableHeader));
            headerCantidadEstimada.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidadEstimada.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidadEstimada.BackgroundColor = new BaseColor(16, 5, 92);

            row = new PdfPRow(new PdfPCell[] { headerPartida, headerNumeroDeParte, headerFabricante, headerDescripcion, headerCantidadEstimada });
            tablaPartidas.Rows.Add(row);

            int numPartida = 1;
            RfqConcepto.Modelo().SeleccionarRfq(IdRfq).ForEach(delegate(Fila concepto)
            {
                string strCantidadEstimada = concepto.Celda("total_estimada").ToString();//concepto.Celda("cantidad_estimada").ToString();

                if (concepto.Celda("tipo_venta").ToString() == "POR PIEZA")
                {
                    strCantidadEstimada += " PCS.";
                }
                else if (concepto.Celda("tipo_venta").ToString() == "POR PAQUETE")
                {
                    strCantidadEstimada += " PKG.";
                }

                // partida
                PdfPCell partida = new PdfPCell(new Phrase("Item " + numPartida.ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;

                // numero de parte
                PdfPCell numeroDeParte = new PdfPCell(new Phrase(concepto.Celda("numero_parte").ToString(), smallNegrita));
                numeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
                numeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell fabricante = new PdfPCell(new Phrase(concepto.Celda("fabricante").ToString(), small));
                fabricante.HorizontalAlignment = Element.ALIGN_CENTER;
                fabricante.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell descripcion = new PdfPCell(new Phrase(concepto.Celda("descripcion").ToString(), small));
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                descripcion.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad estimada
                PdfPCell cantidad_estimada = new PdfPCell(new Phrase(strCantidadEstimada, small));
                cantidad_estimada.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad_estimada.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad_estimada });
                tablaPartidas.Rows.Add(row);

                numPartida++;
            });

            // Comentarios / notas
            Paragraph pcomentarios = new Paragraph();
            if (notas != "")
            {
                pcomentarios.Add(new Phrase("Notes:\n", negrita));
                pcomentarios.Add(new Phrase(notas, normal));
                pcomentarios.SpacingBefore = 10;
            }
            ptablaPartidas.Add(tablaPartidas);
            ptablaDatos.Add(tablaDatos);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaDatos);
            doc.Add(pmensaje);
            doc.Add(ptablaPartidas);
            doc.Add(pcomentarios);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] POMaterial_MX(int IdUsuario, int IdContacto, string direccionEntrega, string direccionFacturacion, string notas, PoMaterial po, decimal impuestos = 0, decimal descuento = 0, decimal otrosCargos = 0, string moneda = "USD")
        {
            //if(!material.TieneFilas()) return;
            byte[] datosPDF;

            // Define el nombre del archivo temporal
            int IdPO = Convert.ToInt32(po.Fila().Celda("id"));
            int revision = Convert.ToInt32(po.Fila().Celda("revision"));
            int IdProveedor = Convert.ToInt32(po.Fila().Celda("proveedor"));
            decimal subtotal = 0;

            Direccion dirFact = new Direccion();
            dirFact.SeleccionarNombre(direccionFacturacion);

            Direccion dirEntr = new Direccion();
            dirEntr.SeleccionarNombre(direccionEntrega);

            Proveedor proveedor = new Proveedor();
            proveedor.CargarDatos(IdProveedor);

            ProveedorContacto contacto = new ProveedorContacto();
            contacto.CargarDatos(IdContacto);

            Usuario usr = new Usuario();
            usr.CargarDatos(IdUsuario);

            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font verySmall = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 9, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(170, 78);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
            logo.IndentationLeft = 9;
            logo.SpacingAfter = 30;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("ORDEN DE COMPRA" + Environment.NewLine, title));
            titulo.Add(new Phrase("PO #" + IdPO.ToString() + Environment.NewLine + Environment.NewLine, negrita));

            if (revision > 0)
                titulo.Add(new Phrase("Revisión " + revision.ToString() + Environment.NewLine + Environment.NewLine, negrita));

            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), normal));
            titulo.Alignment = Element.ALIGN_RIGHT;

            // Tabla de datos
            Paragraph ptablaDatos = new Paragraph();
            ptablaDatos.SpacingBefore = 20;
            PdfPTable tablaDatos = new PdfPTable(4);
            tablaDatos.WidthPercentage = 100;

            // Header datos del solicitante
            PdfPCell headerSolicitante = new PdfPCell(new Phrase("EMITIDA POR", tableHeader));
            headerSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.VerticalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del proveedor
            PdfPCell headerProveedor = new PdfPCell(new Phrase("DATOS DEL PROVEEDOR", tableHeader));
            headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProveedor.VerticalAlignment = Element.ALIGN_CENTER;
            headerProveedor.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de facturacion
            PdfPCell headerFacturacion = new PdfPCell(new Phrase("DIRECCION DE FACTURACION", tableHeader));
            headerFacturacion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.VerticalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de entrega
            PdfPCell headerEntrega = new PdfPCell(new Phrase("DIRECCION DE ENTREGA", tableHeader));
            headerEntrega.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEntrega.VerticalAlignment = Element.ALIGN_CENTER;
            headerEntrega.BackgroundColor = new BaseColor(16, 5, 92);

            // Datos del solicitante
            PdfPCell datosSolicitante = new PdfPCell();
            p = new Paragraph(usr.Fila().Celda("nombre").ToString() + " " + usr.Fila().Celda("paterno").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 10;
            datosSolicitante.AddElement(p);
            p = new Paragraph(usr.Fila().Celda("correo").ToString() + Environment.NewLine, smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosSolicitante.AddElement(p);

            // Datos del proveedor
            PdfPCell datosProveedor = new PdfPCell();
            string dp = proveedor.Fila().Celda("razon_social").ToString() + Environment.NewLine;
            dp += proveedor.Fila().Celda("calle").ToString() + " #" + proveedor.Fila().Celda("numero").ToString() + ", " + proveedor.Fila().Celda("colonia").ToString() + Environment.NewLine;
            dp += proveedor.Fila().Celda("cp").ToString() + " " + proveedor.Fila().Celda("ciudad").ToString() + ", " + proveedor.Fila().Celda("estado").ToString();

            p = new Paragraph(dp, verySmall);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            // datos facturacion
            PdfPCell datosFacturacion = new PdfPCell();
            p = new Paragraph(dirFact.EnTexto("MX") + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosFacturacion.AddElement(p);

            // datos entrega
            PdfPCell datosEntrega = new PdfPCell();
            p = new Paragraph(dirEntr.EnTexto("MX") + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosEntrega.AddElement(p);


            PdfPRow row = new PdfPRow(new PdfPCell[] { headerSolicitante, headerProveedor, headerFacturacion, headerEntrega });
            tablaDatos.Rows.Add(row);

            row = new PdfPRow(new PdfPCell[] { datosSolicitante, datosProveedor, datosFacturacion, datosEntrega });
            tablaDatos.Rows.Add(row);

            // Mensaje del solicitante
            Paragraph pmensaje = new Paragraph();
            pmensaje.Add(new Phrase("Términos de pago: ", negrita));
            int num = 1;
            TerminoPagoProveedor.Modelo().CargarDatosPO(IdPO, IdProveedor).ForEach(delegate(Fila f)
            {
                string terminosPago = f.Celda("porcentaje").ToString() + "% " + f.Celda("terminos").ToString();
                pmensaje.Add(new Phrase(terminosPago, smallNegrita));
                if (num < TerminoPagoProveedor.Modelo().CargarDatosPO(IdPO, IdProveedor).Count)
                    pmensaje.Add(new Phrase(" | ", smallNegrita));
                num++;
            });
            // Agrega la tabla de partidas

            // Partidas
            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(7);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 10, 15, 15, 30, 10, 10, 10 };
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("#", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

            // Header numero de parte
            PdfPCell headerNumeroDeParte = new PdfPCell(new Phrase("NUM. DE PARTE", tableHeader));
            headerNumeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fabricante
            PdfPCell headerFabricante = new PdfPCell(new Phrase("FABRICANTE", tableHeader));
            headerFabricante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFabricante.VerticalAlignment = Element.ALIGN_CENTER;
            headerFabricante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPCION", tableHeader));
            headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad
            PdfPCell headerCantidad = new PdfPCell(new Phrase("CANTIDAD", tableHeader));
            headerCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidad.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidad.BackgroundColor = new BaseColor(16, 5, 92);

            // Header precio
            PdfPCell headerPrecio = new PdfPCell(new Phrase("PRECIO UNITARIO", tableHeader));
            headerPrecio.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPrecio.VerticalAlignment = Element.ALIGN_CENTER;
            headerPrecio.BackgroundColor = new BaseColor(16, 5, 92);

            // Header suma
            PdfPCell headerSuma = new PdfPCell(new Phrase("SUMA", tableHeader));
            headerSuma.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSuma.VerticalAlignment = Element.ALIGN_CENTER;
            headerSuma.BackgroundColor = new BaseColor(16, 5, 92);

            row = new PdfPRow(new PdfPCell[] { headerPartida, headerNumeroDeParte, headerFabricante, headerDescripcion, headerCantidad, headerPrecio, headerSuma });
            tablaPartidas.Rows.Add(row);
            decimal descuentoIva = 0;

            int numPartida = 1;
            PoMaterial.Modelo().Conceptos(IdPO, false, false, "MEXICO").ForEach(delegate(Fila concepto)
            {
                // partida
                PdfPCell partida = new PdfPCell(new Phrase("Partida " + numPartida.ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;

                // numero de parte
                PdfPCell numeroDeParte = new PdfPCell(new Phrase(concepto.Celda("numero_parte").ToString(), smallNegrita));
                numeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
                numeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell fabricante = new PdfPCell(new Phrase(concepto.Celda("fabricante").ToString(), small));
                fabricante.HorizontalAlignment = Element.ALIGN_CENTER;
                fabricante.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell descripcion = new PdfPCell(new Phrase(concepto.Celda("descripcion").ToString(), small));
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                descripcion.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad
                PdfPCell cantidad = new PdfPCell(new Phrase(concepto.Celda("texto_cantidad").ToString(), small));
                cantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad.VerticalAlignment = Element.ALIGN_CENTER;

                // precio unitario
                PdfPCell precio = new PdfPCell(new Phrase(concepto.Celda("texto_precio_unitario").ToString(), small));
                precio.HorizontalAlignment = Element.ALIGN_CENTER;
                precio.VerticalAlignment = Element.ALIGN_CENTER;

                // suma
                PdfPCell suma = new PdfPCell(new Phrase(concepto.Celda("texto_suma").ToString(), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;
                suma.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);

                numPartida++;

                CatalogoMaterial catalogo = new CatalogoMaterial();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@numeroParte", concepto.Celda("numero_parte"));

                catalogo.SeleccionarDatos("numero_parte=@numeroParte", parametros, "aplicar_iva");
                if (catalogo.TieneFilas())
                {
                    if (Convert.ToInt32(catalogo.Fila().Celda("aplicar_iva")) == 0)
                    {
                        decimal calculoDescuento = (impuestos * Convert.ToDecimal(concepto.Celda("suma"))) / 100;
                        descuentoIva += calculoDescuento;
                    }
                }

                subtotal += Convert.ToDecimal(concepto.Celda("suma"));
            });

            if (tablaPartidas.Rows.Count > 0)
            {
                PdfPCell partida = new PdfPCell(new Phrase("", small));
                PdfPCell numeroDeParte = new PdfPCell(new Phrase("", small));
                PdfPCell fabricante = new PdfPCell(new Phrase("", small));
                PdfPCell descripcion = new PdfPCell(new Phrase("", small));
                PdfPCell cantidad = new PdfPCell(new Phrase("", small));

                // Subtotal
                PdfPCell precio = new PdfPCell(new Phrase("Sub-total:", smallNegrita));
                precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                PdfPCell suma = new PdfPCell(new Phrase(String.Format("{0:C}", subtotal), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);

                // Descuento
                if (descuento > 0)
                {
                    precio = new PdfPCell(new Phrase("Descuento (-" + descuento.ToString() + "%):", smallNegrita));
                    precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                    decimal numDescuento = subtotal * (descuento / 100);
                    subtotal -= numDescuento;

                    suma = new PdfPCell(new Phrase("-" + String.Format("{0:C}", numDescuento), small));
                    suma.HorizontalAlignment = Element.ALIGN_CENTER;

                    row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                    tablaPartidas.Rows.Add(row);
                }

                // Otros cargos
                if (otrosCargos > 0)
                {
                    precio = new PdfPCell(new Phrase("Otros cargos:", smallNegrita));
                    precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                    subtotal += otrosCargos;

                    suma = new PdfPCell(new Phrase("+" + String.Format("{0:C}", otrosCargos), small));
                    suma.HorizontalAlignment = Element.ALIGN_CENTER;

                    row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                    tablaPartidas.Rows.Add(row);
                }

                // Impuestos
                decimal numImpuestos = subtotal * (impuestos / 100);
                numImpuestos = numImpuestos - descuentoIva;
                subtotal += numImpuestos;

                //if( numImpuestos > 0 )
                //{
                precio = new PdfPCell(new Phrase("Impuestos (+" + impuestos.ToString() + "%):", smallNegrita));
                precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                suma = new PdfPCell(new Phrase("+" + String.Format("{0:C}", numImpuestos), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);
                //}

                // Total
                precio = new PdfPCell(new Phrase("Total (" + moneda + "):", smallNegrita));
                precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                suma = new PdfPCell(new Phrase(String.Format("{0:C}", subtotal), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);
            }


            // Comentarios / notas
            Paragraph pcomentarios = new Paragraph();
            if (notas != "")
            {
                pcomentarios.Add(new Phrase("Notas:\n", negrita));
                pcomentarios.Add(new Phrase(notas, normal));
                pcomentarios.SpacingBefore = 10;
            }

            ptablaPartidas.Add(tablaPartidas);
            ptablaDatos.Add(tablaDatos);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaDatos);
            doc.Add(pmensaje);
            doc.Add(ptablaPartidas);
            doc.Add(pcomentarios);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] POMaterial_US(int IdUsuario, int IdContacto, string direccionEntrega, string direccionFacturacion, string notas, PoMaterial po, decimal impuestos = 0, decimal descuento = 0, decimal otrosCargos = 0, string moneda = "USD")
        {
            //if(!material.TieneFilas()) return;
            byte[] datosPDF;

            // Define el nombre del archivo temporal
            int IdPO = Convert.ToInt32(po.Fila().Celda("id"));
            int revision = Convert.ToInt32(po.Fila().Celda("revision"));
            int IdProveedor = Convert.ToInt32(po.Fila().Celda("proveedor"));
            decimal subtotal = 0;

            Direccion dirFact = new Direccion();
            dirFact.SeleccionarNombre(direccionFacturacion);

            Direccion dirEntr = new Direccion();
            dirEntr.SeleccionarNombre(direccionEntrega);

            Proveedor proveedor = new Proveedor();
            proveedor.CargarDatos(IdProveedor);

            ProveedorContacto contacto = new ProveedorContacto();
            contacto.CargarDatos(IdContacto);

            Usuario usr = new Usuario();
            usr.CargarDatos(IdUsuario);

            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font verySmall = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 9, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_audisel_inc_white, BaseColor.WHITE);
            logo.ScaleToFit(225, 80);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("PURCHASE ORDER" + Environment.NewLine, title));
            titulo.Add(new Phrase("PO #" + IdPO.ToString() + Environment.NewLine + Environment.NewLine, negrita));

            if (revision > 0)
                titulo.Add(new Phrase("Revision " + revision.ToString() + Environment.NewLine + Environment.NewLine, negrita));

            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), normal));
            titulo.Alignment = Element.ALIGN_RIGHT;

            // Tabla de datos
            Paragraph ptablaDatos = new Paragraph();
            ptablaDatos.SpacingBefore = 20;
            PdfPTable tablaDatos = new PdfPTable(4);
            tablaDatos.WidthPercentage = 100;

            // Header datos del solicitante
            PdfPCell headerSolicitante = new PdfPCell(new Phrase("GENERATED BY", tableHeader));
            headerSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.VerticalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del proveedor
            PdfPCell headerProveedor = new PdfPCell(new Phrase("SUPPLIER", tableHeader));
            headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProveedor.VerticalAlignment = Element.ALIGN_CENTER;
            headerProveedor.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de facturacion
            PdfPCell headerFacturacion = new PdfPCell(new Phrase("BILLING ADDRESS", tableHeader));
            headerFacturacion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.VerticalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de entrega
            PdfPCell headerEntrega = new PdfPCell(new Phrase("SHIPPING ADDRESS", tableHeader));
            headerEntrega.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEntrega.VerticalAlignment = Element.ALIGN_CENTER;
            headerEntrega.BackgroundColor = new BaseColor(16, 5, 92);

            // Datos del solicitante
            PdfPCell datosSolicitante = new PdfPCell();
            p = new Paragraph(usr.Fila().Celda("nombre").ToString() + " " + usr.Fila().Celda("paterno").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 10;
            datosSolicitante.AddElement(p);
            p = new Paragraph(usr.Fila().Celda("correo").ToString() + Environment.NewLine, smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosSolicitante.AddElement(p);

            // Datos del proveedor
            PdfPCell datosProveedor = new PdfPCell();
            string dp = proveedor.Fila().Celda("razon_social").ToString() + Environment.NewLine;
            dp += proveedor.Fila().Celda("numero").ToString() + " " + proveedor.Fila().Celda("calle").ToString() + Environment.NewLine;
            dp += proveedor.Fila().Celda("ciudad").ToString() + ", " + proveedor.Fila().Celda("estado").ToString() + " " + proveedor.Fila().Celda("cp").ToString();

            p = new Paragraph(dp, verySmall);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            // datos facturacion
            PdfPCell datosFacturacion = new PdfPCell();
            p = new Paragraph(dirFact.EnTexto("US") + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosFacturacion.AddElement(p);

            // datos entrega
            PdfPCell datosEntrega = new PdfPCell();
            p = new Paragraph(dirEntr.EnTexto("US") + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosEntrega.AddElement(p);


            PdfPRow row = new PdfPRow(new PdfPCell[] { headerSolicitante, headerProveedor, headerFacturacion, headerEntrega });
            tablaDatos.Rows.Add(row);

            row = new PdfPRow(new PdfPCell[] { datosSolicitante, datosProveedor, datosFacturacion, datosEntrega });
            tablaDatos.Rows.Add(row);

            Paragraph pmensaje = new Paragraph();
            pmensaje.Add(new Phrase("Payment terms: ", negrita));
            int num = 1;
            TerminoPagoProveedor.Modelo().CargarDatosPO(IdPO, IdProveedor).ForEach(delegate(Fila f)
            {
                string terminosPago = f.Celda("porcentaje").ToString() + "% " + f.Celda("terminos").ToString();
                pmensaje.Add(new Phrase(terminosPago, smallNegrita));
                if (num < TerminoPagoProveedor.Modelo().CargarDatosPO(IdPO, IdProveedor).Count)
                    pmensaje.Add(new Phrase(" | ", smallNegrita));
                num++;
            });
            // Agrega la tabla de partidas

            // Partidas
            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(7);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 5, 20, 15, 30, 10, 10, 10 };
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("#", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

            // Header numero de parte
            PdfPCell headerNumeroDeParte = new PdfPCell(new Phrase("PART NUMBER", tableHeader));
            headerNumeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fabricante
            PdfPCell headerFabricante = new PdfPCell(new Phrase("BRAND", tableHeader));
            headerFabricante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFabricante.VerticalAlignment = Element.ALIGN_CENTER;
            headerFabricante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPTION", tableHeader));
            headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad
            PdfPCell headerCantidad = new PdfPCell(new Phrase("QUANTITY", tableHeader));
            headerCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidad.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidad.BackgroundColor = new BaseColor(16, 5, 92);

            // Header precio
            PdfPCell headerPrecio = new PdfPCell(new Phrase("UNIT PRICE", tableHeader));
            headerPrecio.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPrecio.VerticalAlignment = Element.ALIGN_CENTER;
            headerPrecio.BackgroundColor = new BaseColor(16, 5, 92);

            // Header suma
            PdfPCell headerSuma = new PdfPCell(new Phrase("AMOUNT", tableHeader));
            headerSuma.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSuma.VerticalAlignment = Element.ALIGN_CENTER;
            headerSuma.BackgroundColor = new BaseColor(16, 5, 92);

            row = new PdfPRow(new PdfPCell[] { headerPartida, headerNumeroDeParte, headerFabricante, headerDescripcion, headerCantidad, headerPrecio, headerSuma });
            tablaPartidas.Rows.Add(row);

            decimal descuentoIva = 0;

            int numPartida = 1;
            PoMaterial.Modelo().Conceptos(IdPO, false, false, "ESTADOS UNIDOS").ForEach(delegate(Fila concepto)
            {
                // partida
                PdfPCell partida = new PdfPCell(new Phrase("Item " + numPartida.ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;

                // numero de parte
                PdfPCell numeroDeParte = new PdfPCell(new Phrase(concepto.Celda("numero_parte").ToString(), smallNegrita));
                numeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
                numeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell fabricante = new PdfPCell(new Phrase(concepto.Celda("fabricante").ToString(), small));
                fabricante.HorizontalAlignment = Element.ALIGN_CENTER;
                fabricante.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell descripcion = new PdfPCell(new Phrase(concepto.Celda("descripcion").ToString(), small));
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                descripcion.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad
                PdfPCell cantidad = new PdfPCell(new Phrase(concepto.Celda("texto_cantidad").ToString(), small));
                cantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad.VerticalAlignment = Element.ALIGN_CENTER;

                // precio unitario
                PdfPCell precio = new PdfPCell(new Phrase(concepto.Celda("texto_precio_unitario").ToString(), small));
                precio.HorizontalAlignment = Element.ALIGN_CENTER;
                precio.VerticalAlignment = Element.ALIGN_CENTER;

                // suma
                PdfPCell suma = new PdfPCell(new Phrase(concepto.Celda("texto_suma").ToString(), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;
                suma.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);

                numPartida++;
                
                CatalogoMaterial catalogo = new CatalogoMaterial();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@numeroParte", concepto.Celda("numero_parte"));

                catalogo.SeleccionarDatos("numero_parte=@numeroParte", parametros, "aplicar_iva");
                if (catalogo.TieneFilas())
                {
                    if (Convert.ToInt32(catalogo.Fila().Celda("aplicar_iva")) == 0)
                    {
                        decimal calculoDescuento = (impuestos * Convert.ToDecimal(concepto.Celda("suma"))) /100;
                        descuentoIva += calculoDescuento;
                    }
                }
                subtotal += Convert.ToDecimal(concepto.Celda("suma"));
            });

            if (tablaPartidas.Rows.Count > 0)
            {

                PdfPCell partida = new PdfPCell(new Phrase("", small));
                PdfPCell numeroDeParte = new PdfPCell(new Phrase("", small));
                PdfPCell fabricante = new PdfPCell(new Phrase("", small));
                PdfPCell descripcion = new PdfPCell(new Phrase("", small));
                PdfPCell cantidad = new PdfPCell(new Phrase("", small));

                // Subtotal
                PdfPCell precio = new PdfPCell(new Phrase("Sub-total:", smallNegrita));
                precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                PdfPCell suma = new PdfPCell(new Phrase(String.Format("{0:C}", subtotal), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);

                // Descuento
                decimal numDescuento = subtotal * (descuento / 100);
                subtotal -= numDescuento;

                if (numDescuento > 0)
                {
                    precio = new PdfPCell(new Phrase("Discount (-" + descuento.ToString() + "%):", smallNegrita));
                    precio.HorizontalAlignment = Element.ALIGN_RIGHT;


                    suma = new PdfPCell(new Phrase("-" + String.Format("{0:C}", numDescuento), small));
                    suma.HorizontalAlignment = Element.ALIGN_CENTER;

                    row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                    tablaPartidas.Rows.Add(row);
                }

                // Otros cargos
                if (otrosCargos > 0)
                {
                    precio = new PdfPCell(new Phrase("Other charges:", smallNegrita));
                    precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                    subtotal += otrosCargos;

                    suma = new PdfPCell(new Phrase("+" + String.Format("{0:C}", otrosCargos), small));
                    suma.HorizontalAlignment = Element.ALIGN_CENTER;

                    row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                    tablaPartidas.Rows.Add(row);
                }

                // Impuestos
                decimal numImpuestos = subtotal * (impuestos / 100);
                numImpuestos = numImpuestos - descuentoIva;

                subtotal += numImpuestos;

                //if( numImpuestos > 0 )
                //{
                precio = new PdfPCell(new Phrase("Tax (+" + impuestos.ToString() + "%):", smallNegrita));
                precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                suma = new PdfPCell(new Phrase("+" + String.Format("{0:C}", numImpuestos), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);
                //}

                // Total
                precio = new PdfPCell(new Phrase("Total (" + moneda + "):", smallNegrita));
                precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                suma = new PdfPCell(new Phrase(String.Format("{0:C}", subtotal), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);
            }


            // Comentarios / notas
            Paragraph pcomentarios = new Paragraph();
            if (notas != "")
            {
                pcomentarios.Add(new Phrase("Notes:\n", negrita));
                pcomentarios.Add(new Phrase(notas, normal));
                pcomentarios.SpacingBefore = 10;
            }

            ptablaPartidas.Add(tablaPartidas);
            ptablaDatos.Add(tablaDatos);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaDatos);
            doc.Add(pmensaje);
            doc.Add(ptablaPartidas);
            doc.Add(pcomentarios);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] POMaterial_EUR(int IdUsuario, int IdContacto, string direccionEntrega, string direccionFacturacion, string notas, PoMaterial po, decimal impuestos = 0, decimal descuento = 0, decimal otrosCargos = 0, string moneda = "EUR")
        {
            //if(!material.TieneFilas()) return;
            byte[] datosPDF;

            // Define el nombre del archivo temporal
            int IdPO = Convert.ToInt32(po.Fila().Celda("id"));
            int revision = Convert.ToInt32(po.Fila().Celda("revision"));
            int IdProveedor = Convert.ToInt32(po.Fila().Celda("proveedor"));
            decimal subtotal = 0;

            Direccion dirFact = new Direccion();
            dirFact.SeleccionarNombre(direccionFacturacion);

            Direccion dirEntr = new Direccion();
            dirEntr.SeleccionarNombre(direccionEntrega);

            Proveedor proveedor = new Proveedor();
            proveedor.CargarDatos(IdProveedor);

            ProveedorContacto contacto = new ProveedorContacto();
            contacto.CargarDatos(IdContacto);

            Usuario usr = new Usuario();
            usr.CargarDatos(IdUsuario);

            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font verySmall = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 9, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_audisel_inc_white, BaseColor.WHITE);
            logo.ScaleToFit(225, 80);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("PURCHASE ORDER" + Environment.NewLine, title));
            titulo.Add(new Phrase("PO #" + IdPO.ToString() + Environment.NewLine + Environment.NewLine, negrita));

            if (revision > 0)
                titulo.Add(new Phrase("Revision " + revision.ToString() + Environment.NewLine + Environment.NewLine, negrita));

            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), normal));
            titulo.Alignment = Element.ALIGN_RIGHT;

            // Tabla de datos
            Paragraph ptablaDatos = new Paragraph();
            ptablaDatos.SpacingBefore = 20;
            PdfPTable tablaDatos = new PdfPTable(4);
            tablaDatos.WidthPercentage = 100;

            // Header datos del solicitante
            PdfPCell headerSolicitante = new PdfPCell(new Phrase("GENERATED BY", tableHeader));
            headerSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.VerticalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del proveedor
            PdfPCell headerProveedor = new PdfPCell(new Phrase("SUPPLIER", tableHeader));
            headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProveedor.VerticalAlignment = Element.ALIGN_CENTER;
            headerProveedor.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de facturacion
            PdfPCell headerFacturacion = new PdfPCell(new Phrase("BILLING ADDRESS", tableHeader));
            headerFacturacion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.VerticalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de entrega
            PdfPCell headerEntrega = new PdfPCell(new Phrase("SHIPPING ADDRESS", tableHeader));
            headerEntrega.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEntrega.VerticalAlignment = Element.ALIGN_CENTER;
            headerEntrega.BackgroundColor = new BaseColor(16, 5, 92);

            // Datos del solicitante
            PdfPCell datosSolicitante = new PdfPCell();
            p = new Paragraph(usr.Fila().Celda("nombre").ToString() + " " + usr.Fila().Celda("paterno").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 10;
            datosSolicitante.AddElement(p);
            p = new Paragraph(usr.Fila().Celda("correo").ToString() + Environment.NewLine, smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosSolicitante.AddElement(p);

            // Datos del proveedor
            PdfPCell datosProveedor = new PdfPCell();
            string dp = proveedor.Fila().Celda("razon_social").ToString() + Environment.NewLine;
            dp += proveedor.Fila().Celda("numero").ToString() + " " + proveedor.Fila().Celda("calle").ToString() + Environment.NewLine;
            dp += proveedor.Fila().Celda("ciudad").ToString() + ", " + proveedor.Fila().Celda("estado").ToString() + " " + proveedor.Fila().Celda("cp").ToString();

            p = new Paragraph(dp, verySmall);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            // datos facturacion
            PdfPCell datosFacturacion = new PdfPCell();
            p = new Paragraph(dirFact.EnTexto("US") + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosFacturacion.AddElement(p);

            // datos entrega
            PdfPCell datosEntrega = new PdfPCell();
            p = new Paragraph(dirEntr.EnTexto("US") + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosEntrega.AddElement(p);


            PdfPRow row = new PdfPRow(new PdfPCell[] { headerSolicitante, headerProveedor, headerFacturacion, headerEntrega });
            tablaDatos.Rows.Add(row);

            row = new PdfPRow(new PdfPCell[] { datosSolicitante, datosProveedor, datosFacturacion, datosEntrega });
            tablaDatos.Rows.Add(row);

            Paragraph pmensaje = new Paragraph();
            pmensaje.Add(new Phrase("Payment terms: ", negrita));
            int num = 1;
            TerminoPagoProveedor.Modelo().CargarDatosPO(IdPO, IdProveedor).ForEach(delegate (Fila f)
            {
                string terminosPago = f.Celda("porcentaje").ToString() + "% " + f.Celda("terminos").ToString();
                pmensaje.Add(new Phrase(terminosPago, smallNegrita));
                if (num < TerminoPagoProveedor.Modelo().CargarDatosPO(IdPO, IdProveedor).Count)
                    pmensaje.Add(new Phrase(" | ", smallNegrita));
                num++;
            });
            // Agrega la tabla de partidas

            // Partidas
            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(7);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 5, 20, 15, 30, 10, 10, 10 };
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("#", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

            // Header numero de parte
            PdfPCell headerNumeroDeParte = new PdfPCell(new Phrase("PART NUMBER", tableHeader));
            headerNumeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fabricante
            PdfPCell headerFabricante = new PdfPCell(new Phrase("BRAND", tableHeader));
            headerFabricante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFabricante.VerticalAlignment = Element.ALIGN_CENTER;
            headerFabricante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPTION", tableHeader));
            headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad
            PdfPCell headerCantidad = new PdfPCell(new Phrase("QUANTITY", tableHeader));
            headerCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidad.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidad.BackgroundColor = new BaseColor(16, 5, 92);

            // Header precio
            PdfPCell headerPrecio = new PdfPCell(new Phrase("UNIT PRICE", tableHeader));
            headerPrecio.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPrecio.VerticalAlignment = Element.ALIGN_CENTER;
            headerPrecio.BackgroundColor = new BaseColor(16, 5, 92);

            // Header suma
            PdfPCell headerSuma = new PdfPCell(new Phrase("AMOUNT", tableHeader));
            headerSuma.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSuma.VerticalAlignment = Element.ALIGN_CENTER;
            headerSuma.BackgroundColor = new BaseColor(16, 5, 92);

            row = new PdfPRow(new PdfPCell[] { headerPartida, headerNumeroDeParte, headerFabricante, headerDescripcion, headerCantidad, headerPrecio, headerSuma });
            tablaPartidas.Rows.Add(row);

            decimal descuentoIva = 0;

            int numPartida = 1;
            PoMaterial.Modelo().Conceptos(IdPO, false, false, "EUROPA").ForEach(delegate (Fila concepto)
            {
                // partida
                PdfPCell partida = new PdfPCell(new Phrase("Item " + numPartida.ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;

                // numero de parte
                PdfPCell numeroDeParte = new PdfPCell(new Phrase(concepto.Celda("numero_parte").ToString(), smallNegrita));
                numeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
                numeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell fabricante = new PdfPCell(new Phrase(concepto.Celda("fabricante").ToString(), small));
                fabricante.HorizontalAlignment = Element.ALIGN_CENTER;
                fabricante.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell descripcion = new PdfPCell(new Phrase(concepto.Celda("descripcion").ToString(), small));
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                descripcion.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad
                PdfPCell cantidad = new PdfPCell(new Phrase(concepto.Celda("texto_cantidad").ToString(), small));
                cantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad.VerticalAlignment = Element.ALIGN_CENTER;

                // precio unitario
                PdfPCell precio = new PdfPCell(new Phrase(concepto.Celda("texto_precio_unitario").ToString(), small));
                precio.HorizontalAlignment = Element.ALIGN_CENTER;
                precio.VerticalAlignment = Element.ALIGN_CENTER;

                // suma
                PdfPCell suma = new PdfPCell(new Phrase(concepto.Celda("texto_suma").ToString(), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;
                suma.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);

                numPartida++;

                CatalogoMaterial catalogo = new CatalogoMaterial();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@numeroParte", concepto.Celda("numero_parte"));

                catalogo.SeleccionarDatos("numero_parte=@numeroParte", parametros, "aplicar_iva");
                if (catalogo.TieneFilas())
                {
                    if (Convert.ToInt32(catalogo.Fila().Celda("aplicar_iva")) == 0)
                    {
                        decimal calculoDescuento = (impuestos * Convert.ToDecimal(concepto.Celda("suma"))) / 100;
                        descuentoIva += calculoDescuento;
                    }
                }
                subtotal += Convert.ToDecimal(concepto.Celda("suma"));
            });

            if (tablaPartidas.Rows.Count > 0)
            {

                PdfPCell partida = new PdfPCell(new Phrase("", small));
                PdfPCell numeroDeParte = new PdfPCell(new Phrase("", small));
                PdfPCell fabricante = new PdfPCell(new Phrase("", small));
                PdfPCell descripcion = new PdfPCell(new Phrase("", small));
                PdfPCell cantidad = new PdfPCell(new Phrase("", small));

                // Subtotal
                PdfPCell precio = new PdfPCell(new Phrase("Sub-total:", smallNegrita));
                precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                PdfPCell suma = new PdfPCell(new Phrase(String.Format("€{0:N2}", subtotal), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);

                // Descuento
                decimal numDescuento = subtotal * (descuento / 100);
                subtotal -= numDescuento;

                if (numDescuento > 0)
                {
                    precio = new PdfPCell(new Phrase("Discount (-" + descuento.ToString() + "%):", smallNegrita));
                    precio.HorizontalAlignment = Element.ALIGN_RIGHT;


                    suma = new PdfPCell(new Phrase("-" + String.Format("€{0:N2}", numDescuento), small));
                    suma.HorizontalAlignment = Element.ALIGN_CENTER;

                    row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                    tablaPartidas.Rows.Add(row);
                }

                // Otros cargos
                if (otrosCargos > 0)
                {
                    precio = new PdfPCell(new Phrase("Other charges:", smallNegrita));
                    precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                    subtotal += otrosCargos;

                    suma = new PdfPCell(new Phrase("+" + String.Format("€{0:N2}", otrosCargos), small));
                    suma.HorizontalAlignment = Element.ALIGN_CENTER;

                    row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                    tablaPartidas.Rows.Add(row);
                }

                // Impuestos
                decimal numImpuestos = subtotal * (impuestos / 100);
                numImpuestos = numImpuestos - descuentoIva;

                subtotal += numImpuestos;

                //if( numImpuestos > 0 )
                //{
                precio = new PdfPCell(new Phrase("Tax (+" + impuestos.ToString() + "%):", smallNegrita));
                precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                suma = new PdfPCell(new Phrase("+" + String.Format("€{0:N2}", numImpuestos), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);
                //}

                // Total
                precio = new PdfPCell(new Phrase("Total (" + moneda + "):", smallNegrita));
                precio.HorizontalAlignment = Element.ALIGN_RIGHT;

                suma = new PdfPCell(new Phrase(String.Format("€{0:N2}", subtotal), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad, precio, suma });
                tablaPartidas.Rows.Add(row);
            }


            // Comentarios / notas
            Paragraph pcomentarios = new Paragraph();
            if (notas != "")
            {
                pcomentarios.Add(new Phrase("Notes:\n", negrita));
                pcomentarios.Add(new Phrase(notas, normal));
                pcomentarios.SpacingBefore = 10;
            }

            ptablaPartidas.Add(tablaPartidas);
            ptablaDatos.Add(tablaDatos);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaDatos);
            doc.Add(pmensaje);
            doc.Add(ptablaPartidas);
            doc.Add(pcomentarios);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }


        public static byte[] ReporteCompra_Material(int IdUsuario, int IdContacto, string direccionEntrega, string direccionFacturacion, string notas, PoMaterial po, decimal impuestos = 0, decimal descuento = 0, decimal otrosCargos = 0, string moneda = "USD")
        {
            //if(!material.TieneFilas()) return;
            byte[] datosPDF;

            // Define el nombre del archivo temporal
            int IdPO = Convert.ToInt32(po.Fila().Celda("id"));
            int revision = Convert.ToInt32(po.Fila().Celda("revision"));
            int IdProveedor = Convert.ToInt32(po.Fila().Celda("proveedor"));
            decimal subtotal = 0;

            Direccion dirFact = new Direccion();
            dirFact.SeleccionarNombre(direccionFacturacion);

            Direccion dirEntr = new Direccion();
            dirEntr.SeleccionarNombre(direccionEntrega);

            Proveedor proveedor = new Proveedor();
            proveedor.CargarDatos(IdProveedor);

            ProveedorContacto contacto = new ProveedorContacto();
            contacto.CargarDatos(IdContacto);

            Usuario usr = new Usuario();
            usr.CargarDatos(IdUsuario);

            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font verySmall = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 7, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 8, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(170, 78);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
            logo.IndentationLeft = 9;
            logo.SpacingAfter = 30;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("REPORTE DE COMPRA" + Environment.NewLine, title));
            titulo.Add(new Phrase("PO #" + IdPO.ToString() + Environment.NewLine + Environment.NewLine, negrita));

            if (revision > 0)
                titulo.Add(new Phrase("Revisión " + revision.ToString() + Environment.NewLine + Environment.NewLine, negrita));

            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), normal));
            titulo.Alignment = Element.ALIGN_RIGHT;

            // Tabla de datos
            Paragraph ptablaDatos = new Paragraph();
            ptablaDatos.SpacingBefore = 20;
            PdfPTable tablaDatos = new PdfPTable(4);
            tablaDatos.WidthPercentage = 100;

            // Header datos del solicitante
            PdfPCell headerSolicitante = new PdfPCell(new Phrase("EMITIDA POR", tableHeader));
            headerSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.VerticalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del proveedor
            PdfPCell headerProveedor = new PdfPCell(new Phrase("DATOS DEL PROVEEDOR", tableHeader));
            headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProveedor.VerticalAlignment = Element.ALIGN_CENTER;
            headerProveedor.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de facturacion
            PdfPCell headerFacturacion = new PdfPCell(new Phrase("DIRECCION DE FACTURACION", tableHeader));
            headerFacturacion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.VerticalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de entrega
            PdfPCell headerEntrega = new PdfPCell(new Phrase("DIRECCION DE ENTREGA", tableHeader));
            headerEntrega.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEntrega.VerticalAlignment = Element.ALIGN_CENTER;
            headerEntrega.BackgroundColor = new BaseColor(16, 5, 92);

            // Datos del solicitante
            PdfPCell datosSolicitante = new PdfPCell();
            p = new Paragraph(usr.Fila().Celda("nombre").ToString() + " " + usr.Fila().Celda("paterno").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 10;
            datosSolicitante.AddElement(p);
            p = new Paragraph(usr.Fila().Celda("correo").ToString() + Environment.NewLine, smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosSolicitante.AddElement(p);

            // Datos del proveedor
            PdfPCell datosProveedor = new PdfPCell();
            string dp = proveedor.Fila().Celda("razon_social").ToString() + Environment.NewLine;
            dp += proveedor.Fila().Celda("calle").ToString() + " #" + proveedor.Fila().Celda("numero").ToString() + ", " + proveedor.Fila().Celda("colonia").ToString() + Environment.NewLine;
            dp += proveedor.Fila().Celda("cp").ToString() + " " + proveedor.Fila().Celda("ciudad").ToString() + ", " + proveedor.Fila().Celda("estado").ToString();

            p = new Paragraph(dp, verySmall);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            // datos facturacion
            PdfPCell datosFacturacion = new PdfPCell();
            p = new Paragraph(dirFact.EnTexto("MX") + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosFacturacion.AddElement(p);

            // datos entrega
            PdfPCell datosEntrega = new PdfPCell();
            p = new Paragraph(dirEntr.EnTexto("MX") + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosEntrega.AddElement(p);


            PdfPRow row = new PdfPRow(new PdfPCell[] { headerSolicitante, headerProveedor, headerFacturacion, headerEntrega });
            tablaDatos.Rows.Add(row);

            row = new PdfPRow(new PdfPCell[] { datosSolicitante, datosProveedor, datosFacturacion, datosEntrega });
            tablaDatos.Rows.Add(row);

            // Mensaje del solicitante
            Paragraph pmensaje = new Paragraph();
            pmensaje.Add(new Phrase("Términos de pago: ", negrita));
            int num = 1;
            TerminoPagoProveedor.Modelo().CargarDatosPO(IdPO, IdProveedor).ForEach(delegate (Fila f)
            {
                string terminosPago = f.Celda("porcentaje").ToString() + "% " + f.Celda("terminos").ToString();
                pmensaje.Add(new Phrase(terminosPago, smallNegrita));
                if (num < TerminoPagoProveedor.Modelo().CargarDatosPO(IdPO, IdProveedor).Count)
                    pmensaje.Add(new Phrase(" | ", smallNegrita));
                num++;
            });
            // Agrega la tabla de partidas

            // Partidas
            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(9);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 8, 10, 8, 8, 8, 10, 25, 10, 8 };
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("#", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);


            // Header proyecto
            PdfPCell headerProyecto = new PdfPCell(new Phrase("PROYECTO", tableHeader));
            headerProyecto.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProyecto.VerticalAlignment = Element.ALIGN_CENTER;
            headerProyecto.BackgroundColor = new BaseColor(16, 5, 92);

            // Header requi
            PdfPCell headerRequi = new PdfPCell(new Phrase("REQUI.", tableHeader));
            headerRequi.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRequi.VerticalAlignment = Element.ALIGN_CENTER;
            headerRequi.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fea
            PdfPCell headerFEA = new PdfPCell(new Phrase("FEA", tableHeader));
            headerFEA.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFEA.VerticalAlignment = Element.ALIGN_CENTER;
            headerFEA.BackgroundColor = new BaseColor(16, 5, 92);


            // Header numero de parte
            PdfPCell headerNumeroDeParte = new PdfPCell(new Phrase("NUM. DE PARTE", tableHeader));
            headerNumeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fabricante
            PdfPCell headerFabricante = new PdfPCell(new Phrase("FABRICANTE", tableHeader));
            headerFabricante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFabricante.VerticalAlignment = Element.ALIGN_CENTER;
            headerFabricante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPCION", tableHeader));
            headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad
            PdfPCell headerCantidad = new PdfPCell(new Phrase("CANTIDAD", tableHeader));
            headerCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidad.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidad.BackgroundColor = new BaseColor(16, 5, 92);

            // Header suma
            PdfPCell headerSuma = new PdfPCell(new Phrase("PRECIO", tableHeader));
            headerSuma.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSuma.VerticalAlignment = Element.ALIGN_CENTER;
            headerSuma.BackgroundColor = new BaseColor(16, 5, 92);

            row = new PdfPRow(new PdfPCell[] { headerPartida, headerProyecto, headerRequi, headerFEA, headerNumeroDeParte, headerFabricante, headerDescripcion, headerCantidad, headerSuma });
            tablaPartidas.Rows.Add(row);
            decimal descuentoIva = 0;

            int numPartida = 1;
            PoMaterial.Modelo().Conceptos(IdPO, false, false, "MEXICO").ForEach(delegate (Fila concepto)
            {
                // partida
                PdfPCell partida = new PdfPCell(new Phrase("Partida " + numPartida.ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;


                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@rfqConcepto", concepto.Celda("rfq_concepto"));
                parametros.Add("@numeroParte", concepto.Celda("numero_parte"));
                parametros.Add("@po", concepto.Celda("po"));

                string strProyecto = string.Empty;
                string strRequi = string.Empty;
                string strFea = string.Empty;

                MaterialProyecto matProyecto = new MaterialProyecto();
                matProyecto.SeleccionarDatos("numero_parte = @numeroParte and po =@po", parametros).ForEach(delegate (Fila filaProy)
                {
                    strProyecto += Convert.ToDecimal(filaProy.Celda("proyecto")).ToString("f2") + Environment.NewLine;
                    strRequi += filaProy.Celda("id").ToString() + Environment.NewLine;
                    strFea +=Global.FechaATexto(filaProy.Celda("eta"), false) + Environment.NewLine;
                });


                // proyecto
                PdfPCell proyecto = new PdfPCell(new Phrase(strProyecto.TrimEnd(), smallNegrita));
                proyecto.HorizontalAlignment = Element.ALIGN_CENTER;
                proyecto.VerticalAlignment = Element.ALIGN_CENTER;

                // requi
                PdfPCell requi = new PdfPCell(new Phrase(strRequi.TrimEnd(), small));
                requi.HorizontalAlignment = Element.ALIGN_CENTER;
                requi.VerticalAlignment = Element.ALIGN_CENTER;

                // fea
                PdfPCell fea = new PdfPCell(new Phrase(strFea.TrimEnd(), small));
                fea.HorizontalAlignment = Element.ALIGN_CENTER;
                fea.VerticalAlignment = Element.ALIGN_CENTER;

                // numero de parte
                PdfPCell numeroDeParte = new PdfPCell(new Phrase(concepto.Celda("numero_parte").ToString(), smallNegrita));
                numeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
                numeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell fabricante = new PdfPCell(new Phrase(concepto.Celda("fabricante").ToString(), small));
                fabricante.HorizontalAlignment = Element.ALIGN_CENTER;
                fabricante.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell descripcion = new PdfPCell(new Phrase(concepto.Celda("descripcion").ToString(), small));
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                descripcion.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad
                PdfPCell cantidad = new PdfPCell(new Phrase(concepto.Celda("texto_cantidad").ToString(), small));
                cantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad.VerticalAlignment = Element.ALIGN_CENTER;

                // suma
                PdfPCell suma = new PdfPCell(new Phrase(concepto.Celda("texto_suma").ToString(), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;
                suma.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, proyecto, requi, fea, numeroDeParte, fabricante, descripcion, cantidad, suma });
                tablaPartidas.Rows.Add(row);

                numPartida++;

                CatalogoMaterial catalogo = new CatalogoMaterial();
                parametros = new Dictionary<string, object>();
                parametros.Add("@numeroParte", concepto.Celda("numero_parte"));

                catalogo.SeleccionarDatos("numero_parte=@numeroParte", parametros, "aplicar_iva");
                if (catalogo.TieneFilas())
                {
                    if (Convert.ToInt32(catalogo.Fila().Celda("aplicar_iva")) == 0)
                    {
                        decimal calculoDescuento = (impuestos * Convert.ToDecimal(concepto.Celda("suma"))) / 100;
                        descuentoIva += calculoDescuento;
                    }
                }

                subtotal += Convert.ToDecimal(concepto.Celda("suma"));
            });

            if (tablaPartidas.Rows.Count > 0)
            {
                PdfPCell partida = new PdfPCell(new Phrase("", small));
                PdfPCell celdaProy = new PdfPCell(new Phrase("", small));
                PdfPCell requi = new PdfPCell(new Phrase("", small));
                PdfPCell fea = new PdfPCell(new Phrase("", small));
                PdfPCell numeroDeParte = new PdfPCell(new Phrase("", small));
                PdfPCell fabricante = new PdfPCell(new Phrase("", small));
                PdfPCell descripcion = new PdfPCell(new Phrase("", small));
                PdfPCell cantidad = new PdfPCell(new Phrase("", small));

                // Subtotal
                cantidad = new PdfPCell(new Phrase("Sub-total:", smallNegrita));
                cantidad.HorizontalAlignment = Element.ALIGN_RIGHT;

                PdfPCell suma = new PdfPCell(new Phrase(String.Format("{0:C}", subtotal), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, celdaProy, requi, fea, numeroDeParte, fabricante, descripcion, cantidad, suma });
                tablaPartidas.Rows.Add(row);

                // Descuento
                if (descuento > 0)
                {
                    cantidad = new PdfPCell(new Phrase("Descuento (-" + descuento.ToString() + "%):", smallNegrita));
                    cantidad.HorizontalAlignment = Element.ALIGN_RIGHT;

                    decimal numDescuento = subtotal * (descuento / 100);
                    subtotal -= numDescuento;

                    suma = new PdfPCell(new Phrase("-" + String.Format("{0:C}", numDescuento), small));
                    suma.HorizontalAlignment = Element.ALIGN_CENTER;

                    row = new PdfPRow(new PdfPCell[] { partida, celdaProy, requi, fea, numeroDeParte, fabricante, descripcion, cantidad, suma });
                    tablaPartidas.Rows.Add(row);
                }

                // Otros cargos
                if (otrosCargos > 0)
                {
                    cantidad = new PdfPCell(new Phrase("Otros cargos:", smallNegrita));
                    cantidad.HorizontalAlignment = Element.ALIGN_RIGHT;

                    subtotal += otrosCargos;

                    suma = new PdfPCell(new Phrase("+" + String.Format("{0:C}", otrosCargos), small));
                    suma.HorizontalAlignment = Element.ALIGN_CENTER;

                    row = new PdfPRow(new PdfPCell[] { partida, celdaProy, requi, fea, numeroDeParte, fabricante, descripcion, cantidad, suma });
                    tablaPartidas.Rows.Add(row);
                }

                // Impuestos
                decimal numImpuestos = subtotal * (impuestos / 100);
                numImpuestos = numImpuestos - descuentoIva;
                subtotal += numImpuestos;

                //if( numImpuestos > 0 )
                //{
                cantidad = new PdfPCell(new Phrase("Impuestos (+" + impuestos.ToString() + "%):", smallNegrita));
                cantidad.HorizontalAlignment = Element.ALIGN_RIGHT;

                suma = new PdfPCell(new Phrase("+" + String.Format("{0:C}", numImpuestos), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, celdaProy, requi, fea, numeroDeParte, fabricante, descripcion, cantidad, suma });
                tablaPartidas.Rows.Add(row);
                //}

                // Total
                cantidad = new PdfPCell(new Phrase("Total (" + moneda + "):", smallNegrita));
                cantidad.HorizontalAlignment = Element.ALIGN_RIGHT;

                suma = new PdfPCell(new Phrase(String.Format("{0:C}", subtotal), small));
                suma.HorizontalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, celdaProy, requi, fea, numeroDeParte, fabricante, descripcion, cantidad, suma });
                tablaPartidas.Rows.Add(row);
            }


            // Comentarios / notas
            Paragraph pcomentarios = new Paragraph();
            if (notas != "")
            {
                pcomentarios.Add(new Phrase("Notas:\n", negrita));
                pcomentarios.Add(new Phrase(notas, normal));
                pcomentarios.SpacingBefore = 10;
            }

            ptablaPartidas.Add(tablaPartidas);
            ptablaDatos.Add(tablaDatos);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaDatos);
            doc.Add(pmensaje);
            doc.Add(ptablaPartidas);
            doc.Add(pcomentarios);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

       



        public static byte[] DimensionesCriticas(int plano, string proveedor)
        {
            PlanoProyecto datosPlano = new PlanoProyecto();
            datosPlano.CargarDatos(plano);

            int cantidad = Convert.ToInt32(datosPlano.Fila().Celda("cantidad"));
            byte[] datosPDF = null;
            string NombrePlano = datosPlano.Fila().Celda("nombre_archivo").ToString();
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 11, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 11, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 9, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 16, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 14, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            Paragraph p = new Paragraph();
            doc.Open();


            for (int i = 1; i <= cantidad; i++)
            {
                // Agregar logo
                Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv, BaseColor.WHITE);
                logo.ScaleToFit(170, 78);
                logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
                logo.IndentationLeft = 9;
                logo.SpacingAfter = 30;

                // Agregar titulo
                Paragraph titulo = new Paragraph();
                titulo.Add(new Phrase("REPORTE DE DIMENSIONES CRITICAS" + Environment.NewLine, title));
                titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), normal));
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 15;

                // Tabla de datos
                Paragraph ptablaDatos = new Paragraph();
                ptablaDatos.SpacingBefore = 30;
                PdfPTable tablaDatos = new PdfPTable(2);
                tablaDatos.WidthPercentage = 100;

                // Header datos del plano
                PdfPCell headerPlano = new PdfPCell(new Phrase("DATOS DEL PLANO", tableHeader));
                headerPlano.HorizontalAlignment = Element.ALIGN_CENTER;
                headerPlano.VerticalAlignment = Element.ALIGN_CENTER;
                headerPlano.BackgroundColor = new BaseColor(16, 5, 92);

                // Header datos del proveedor
                PdfPCell headerProveedor = new PdfPCell(new Phrase("FABRICACION A CARGO DE", tableHeader));
                headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
                headerProveedor.VerticalAlignment = Element.ALIGN_CENTER;
                headerProveedor.BackgroundColor = new BaseColor(16, 5, 92);

                // Datos del plano
                PdfPCell celdaDatosPlano = new PdfPCell();
                p = new Paragraph(NombrePlano + Environment.NewLine, small);
                p.Alignment = Element.ALIGN_CENTER;
                p.SpacingBefore = 10;
                celdaDatosPlano.AddElement(p);
                p = new Paragraph("Pieza " + i.ToString() + " de " + cantidad.ToString() + Environment.NewLine, smallNegrita);
                p.Alignment = Element.ALIGN_CENTER;
                p.SpacingAfter = 10;
                celdaDatosPlano.AddElement(p);

                // Datos del proveedor
                PdfPCell datosProveedor = new PdfPCell();
                p = new Paragraph(proveedor + Environment.NewLine, small);
                p.Alignment = Element.ALIGN_CENTER;
                datosProveedor.AddElement(p);

                p = new Paragraph("Máquina: " + Environment.NewLine + "Herramentista: " + Environment.NewLine + Environment.NewLine, small);
                p.Alignment = Element.ALIGN_LEFT;
                datosProveedor.AddElement(p);

                PdfPRow row = new PdfPRow(new PdfPCell[] { headerPlano, headerProveedor });
                tablaDatos.Rows.Add(row);

                row = new PdfPRow(new PdfPCell[] { celdaDatosPlano, datosProveedor });
                tablaDatos.Rows.Add(row);

                DimensionCritica dim = new DimensionCritica();
                dim.SeleccionarPlano(plano);

                // Agrega la tabla de partidas

                // Partidas
                Paragraph ptablaPartidas = new Paragraph();
                ptablaPartidas.SpacingBefore = 5;
                PdfPTable tablaPartidas = new PdfPTable(7);
                tablaPartidas.WidthPercentage = 100;

                int[] intTblWidth = { 5, 35, 10, 10, 10, 15, 15 };
                tablaPartidas.SetWidths(intTblWidth);

                if (dim.TieneFilas())
                {
                    ptablaPartidas.Add(new Paragraph("Estimado proveedor, favor de llenar la siguiente tabla de dimensiones críticas realizando las mediciones necesarias al terminar la fabricación de la pieza.", small));
                    ptablaPartidas.Add(new Paragraph("El reporte deberá ser entregado correctamente para proceder con el proceso de facturación." + Environment.NewLine + Environment.NewLine, small));

                    // Header partida
                    PdfPCell headerPartida = new PdfPCell(new Phrase("#", tableHeader));
                    headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
                    headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

                    // Header descripcion
                    PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPCION", tableHeader));
                    headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
                    headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

                    // Header nominal
                    PdfPCell headerNominal = new PdfPCell(new Phrase("NOMINAL", tableHeader));
                    headerNominal.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerNominal.VerticalAlignment = Element.ALIGN_CENTER;
                    headerNominal.BackgroundColor = new BaseColor(16, 5, 92);

                    // Header minimo
                    PdfPCell headerMinimo = new PdfPCell(new Phrase("MINIMO", tableHeader));
                    headerMinimo.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerMinimo.VerticalAlignment = Element.ALIGN_CENTER;
                    headerMinimo.BackgroundColor = new BaseColor(16, 5, 92);

                    // Header maximo
                    PdfPCell headerMaximo = new PdfPCell(new Phrase("MAXIMO", tableHeader));
                    headerMaximo.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerMaximo.VerticalAlignment = Element.ALIGN_CENTER;
                    headerMaximo.BackgroundColor = new BaseColor(16, 5, 92);

                    // Header instrumento
                    PdfPCell headerInstrumento = new PdfPCell(new Phrase("INSTRUMENTO DE MEDICION", tableHeader));
                    headerInstrumento.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerInstrumento.VerticalAlignment = Element.ALIGN_CENTER;
                    headerInstrumento.BackgroundColor = new BaseColor(16, 5, 92);

                    // Header medicion
                    PdfPCell headerMedicion = new PdfPCell(new Phrase("MEDICION", tableHeader));
                    headerMedicion.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerMedicion.VerticalAlignment = Element.ALIGN_CENTER;
                    headerMedicion.BackgroundColor = new BaseColor(16, 5, 92);


                    row = new PdfPRow(new PdfPCell[] { headerPartida, headerDescripcion, headerNominal, headerMinimo, headerMaximo, headerInstrumento, headerMedicion });
                    tablaPartidas.Rows.Add(row);

                    int numPartida = 1;
                    DimensionCritica.Modelo().SeleccionarPlano(plano).ForEach(delegate(Fila dimension)
                    {
                        // partida
                        PdfPCell partida = new PdfPCell(new Phrase(numPartida.ToString(), smallNegrita));
                        partida.HorizontalAlignment = Element.ALIGN_CENTER;
                        partida.VerticalAlignment = Element.ALIGN_CENTER;

                        // descripcion
                        PdfPCell descripcion = new PdfPCell(new Phrase(dimension.Celda("descripcion").ToString(), small));
                        descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                        descripcion.VerticalAlignment = Element.ALIGN_CENTER;

                        // nominal
                        PdfPCell nominal = new PdfPCell(new Phrase(Convert.ToDouble(dimension.Celda("nominal")).ToString("F4"), small));
                        nominal.HorizontalAlignment = Element.ALIGN_CENTER;
                        nominal.VerticalAlignment = Element.ALIGN_CENTER;

                        // minimo
                        PdfPCell minimo = new PdfPCell(new Phrase(Convert.ToDouble(dimension.Celda("minimo")).ToString("F4"), small));
                        minimo.HorizontalAlignment = Element.ALIGN_CENTER;
                        minimo.VerticalAlignment = Element.ALIGN_CENTER;

                        // maximo
                        PdfPCell maximo = new PdfPCell(new Phrase(Convert.ToDouble(dimension.Celda("maximo")).ToString("F4"), small));
                        maximo.HorizontalAlignment = Element.ALIGN_CENTER;
                        maximo.VerticalAlignment = Element.ALIGN_CENTER;

                        // instrumento
                        PdfPCell instrumento = new PdfPCell(new Phrase((dimension.Celda("instrumento_medicion").ToString()), small));
                        instrumento.HorizontalAlignment = Element.ALIGN_CENTER;
                        instrumento.VerticalAlignment = Element.ALIGN_CENTER;

                        // medicion
                        PdfPCell medicion = new PdfPCell(new Phrase("", small));
                        medicion.HorizontalAlignment = Element.ALIGN_CENTER;
                        medicion.VerticalAlignment = Element.ALIGN_CENTER;

                        row = new PdfPRow(new PdfPCell[] { partida, descripcion, nominal, minimo, maximo, instrumento, medicion });
                        tablaPartidas.Rows.Add(row);

                        numPartida++;
                    });

                    ptablaPartidas.Add(tablaPartidas);
                }
                else
                {
                    ptablaPartidas.Add(new Paragraph("Esta pieza no cuenta con dimensiones críticas"));
                }

                ptablaDatos.Add(tablaDatos);

                // Contruye el archivo parte por parte
                doc.Add(logo);
                doc.Add(titulo);
                doc.Add(ptablaDatos);
                doc.Add(ptablaPartidas);
                doc.NewPage();
            }

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] AnalisisDeRequerimientos(Proyecto proyecto, DateTime fechaFiltro, string comentarios = "", bool incluirInternos = false)
        {
            Cliente cliente = new Cliente();
            cliente.CargarDatos((int)proyecto.Fila().Celda("cliente"));

            ClienteContacto contacto = new ClienteContacto();
            contacto.CargarDatos((int)proyecto.Fila().Celda("contacto"));

            byte[] datosPDF = null;
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font verySmall = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font verySmallNegrita = FontFactory.GetFont("Calibri", 7, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 9, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_audisel_inc_white, BaseColor.WHITE);
            logo.ScaleToFit(225, 80);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("ANALISIS DE REQUERIMIENTOS" + Environment.NewLine, title));
            titulo.Alignment = Element.ALIGN_RIGHT;

            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), normal));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.SpacingAfter = 30;


            // Tabla de datos
            Paragraph ptablaDatos = new Paragraph();
            ptablaDatos.SpacingBefore = 30;
            PdfPTable tablaDatos = new PdfPTable(3);
            tablaDatos.WidthPercentage = 100;

            // Header datos de la persona que reporta
            PdfPCell headerReportadoPor = new PdfPCell(new Phrase("GENERADO POR", tableHeader));
            headerReportadoPor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerReportadoPor.VerticalAlignment = Element.ALIGN_CENTER;
            headerReportadoPor.BackgroundColor = new BaseColor(16, 5, 92);

            // Header proyecto
            PdfPCell headerProyecto = new PdfPCell(new Phrase("PROYECTO", tableHeader));
            headerProyecto.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProyecto.VerticalAlignment = Element.ALIGN_CENTER;
            headerProyecto.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del cliente
            PdfPCell headerCliente = new PdfPCell(new Phrase("CLIENTE", tableHeader));
            headerCliente.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCliente.VerticalAlignment = Element.ALIGN_CENTER;
            headerCliente.BackgroundColor = new BaseColor(16, 5, 92);


            // Reportado por
            PdfPCell datosReportadoPor = new PdfPCell();
            p = new Paragraph(Global.UsuarioActual.NombreCompleto() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 10;
            datosReportadoPor.AddElement(p);
            p = new Paragraph(Global.UsuarioActual.Fila().Celda("correo").ToString() + Environment.NewLine, smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosReportadoPor.AddElement(p);

            // Proyecto
            PdfPCell datosProyecto = new PdfPCell();
            p = new Paragraph(Convert.ToDecimal(proyecto.Fila().Celda("id")).ToString("F2") + " - " + proyecto.Fila().Celda("nombre") + Environment.NewLine, negrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 10;
            datosProyecto.AddElement(p);

            // Datos del cliente
            PdfPCell datosCliente = new PdfPCell();
            p = new Paragraph(cliente.Fila().Celda("nombre").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosCliente.AddElement(p);

            p = new Paragraph(contacto.Fila().Celda("nombre").ToString() + " " + contacto.Fila().Celda("apellidos").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosCliente.AddElement(p);

            p = new Paragraph(contacto.Fila().Celda("correo").ToString(), smallNegrita);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 10;
            datosCliente.AddElement(p);

            string msg = "En este documento se muestran los requerimientos identificados por el lider de proyecto a partir de " + fechaFiltro.ToString("MMM dd, yyyy");
            msg += ", utilizando como fuente de información la cotización, los documentos, planos, esquemas, correos electrónicos y toda la retroalimentación del cliente recibida por correo electrónico o durante las revisiones de diseño." + Environment.NewLine;
            msg += "Los requerimientos identificados como NO DEFINIDOS en color AMARILLO deberán ser revisados por el cliente, el cual enviará a la brevedad la información faltante para evitar retrasos en el desarrollo del proyecto." + Environment.NewLine;
            msg += "Los requerimientos identificados como DEFINIDOS en color VERDE serán utilizados como referencia durante los procesos de diseño para asegurar la calidad del proyecto.";


            Paragraph pmensaje = new Paragraph(msg, verySmall);
            pmensaje.SpacingBefore = 10;
            pmensaje.Alignment = Element.ALIGN_JUSTIFIED;

            PdfPRow row = new PdfPRow(new PdfPCell[] { headerReportadoPor, headerProyecto, headerCliente });
            tablaDatos.Rows.Add(row);

            row = new PdfPRow(new PdfPCell[] { datosReportadoPor, datosProyecto, datosCliente });
            tablaDatos.Rows.Add(row);



            // Partidas
            Paragraph ptablaRequerimientos = new Paragraph();
            ptablaRequerimientos.SpacingBefore = 5;
            PdfPTable tablaRequerimientos = new PdfPTable(5);
            tablaRequerimientos.WidthPercentage = 100;

            int[] intTblWidth = { 15, 30, 35, 10, 10 };
            tablaRequerimientos.SetWidths(intTblWidth);

            // Header nombre
            PdfPCell headerNombre = new PdfPCell(new Phrase("REQUERIMIENTO", tableHeader));
            headerNombre.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNombre.VerticalAlignment = Element.ALIGN_CENTER;
            headerNombre.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPCION", tableHeader));
            headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header parametros
            PdfPCell headerParametros = new PdfPCell(new Phrase("PARAMETROS / KEY ITEMS", tableHeader));
            headerParametros.HorizontalAlignment = Element.ALIGN_CENTER;
            headerParametros.VerticalAlignment = Element.ALIGN_CENTER;
            headerParametros.BackgroundColor = new BaseColor(16, 5, 92);

            // Header origen
            PdfPCell headerOrigen = new PdfPCell(new Phrase("ORIGEN", tableHeader));
            headerOrigen.HorizontalAlignment = Element.ALIGN_CENTER;
            headerOrigen.VerticalAlignment = Element.ALIGN_CENTER;
            headerOrigen.BackgroundColor = new BaseColor(16, 5, 92);

            // Estatus
            PdfPCell headerEstatus = new PdfPCell(new Phrase("ESTATUS", tableHeader));
            headerEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEstatus.VerticalAlignment = Element.ALIGN_CENTER;
            headerEstatus.BackgroundColor = new BaseColor(16, 5, 92);

            /*
            // Nivel de revision
            PdfPCell headerNivelDeRevision = new PdfPCell(new Phrase("NIVEL DE REVISION", tableHeader));
            headerNivelDeRevision.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNivelDeRevision.VerticalAlignment = Element.ALIGN_CENTER;
            headerNivelDeRevision.BackgroundColor = new BaseColor(16, 5, 92);

            // Estatus revisión
            PdfPCell headerEstatusRevision = new PdfPCell(new Phrase("ESTATUS REVISION", tableHeader));
            headerEstatusRevision.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEstatusRevision.VerticalAlignment = Element.ALIGN_CENTER;
            headerEstatusRevision.BackgroundColor = new BaseColor(16, 5, 92);
            */

            row = new PdfPRow(new PdfPCell[] { headerNombre, headerDescripcion, headerParametros, headerOrigen, headerEstatus });
            tablaRequerimientos.Rows.Add(row);

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto.Fila().Celda("id"));
            parametros.Add("@fecha", fechaFiltro);
            parametros.Add("@cliente", "CLIENTE");

            string filtroOrigen = "";
            if (!incluirInternos)
                filtroOrigen = " AND origen=@cliente";

            Requerimiento.Modelo().SeleccionarDatos("proyecto=@proyecto AND DATE(fecha_creacion)>=DATE(@fecha)" + filtroOrigen, parametros).ForEach(delegate(Fila f)
            {
                Phrase phrNombre = new Phrase();
                phrNombre.Add(new Chunk("#" + f.Celda("id").ToString() + Environment.NewLine + Environment.NewLine, smallNegrita));
                phrNombre.Add(new Chunk(f.Celda("nombre").ToString(), verySmall));
                PdfPCell nombre = new PdfPCell(phrNombre);

                PdfPCell descripcion = new PdfPCell(new Phrase(f.Celda("descripcion").ToString(), verySmall));

                Phrase phrParams = new Phrase();
                PdfPCell dparametros = new PdfPCell(phrParams);
                //string paramStr = "";
                RequerimientoParametro.Modelo().SeleccionarRequerimiento((int)f.Celda("id")).ForEach(delegate(Fila param)
                {
                    phrParams.Add(new Chunk(param.Celda("parametro").ToString() + ": ", verySmallNegrita));
                    phrParams.Add(new Chunk(param.Celda("valor").ToString() + Environment.NewLine, verySmall));

                    //paramStr += param.Celda("parametro") + ": " + param.Celda("valor") + Environment.NewLine;
                });

                List<Fila> keyitems = RequerimientoKeyitem.Modelo().SeleccionarRequerimiento((int)f.Celda("id"));

                if (keyitems.Count > 0)
                {
                    phrParams.Add(new Chunk(Environment.NewLine + "Key items: " + Environment.NewLine, verySmallNegrita));

                    keyitems.ForEach(delegate(Fila ki)
                    {
                        phrParams.Add(new Chunk(ki.Celda("numero_parte").ToString() + " / " + ki.Celda("fabricante") + " / " + ki.Celda("piezas_requeridas") + " pcs." + Environment.NewLine, verySmall));
                    });
                }

                PdfPCell origen = new PdfPCell(new Phrase(f.Celda("origen").ToString(), verySmall));
                origen.HorizontalAlignment = Element.ALIGN_CENTER;
                origen.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell estatus = new PdfPCell(new Phrase(f.Celda("estatus").ToString(), verySmall));
                estatus.HorizontalAlignment = Element.ALIGN_CENTER;
                estatus.VerticalAlignment = Element.ALIGN_CENTER;

                if (f.Celda("origen").ToString() == "CLIENTE")
                {
                    switch (f.Celda("estatus").ToString())
                    {
                        case "DEFINIDO":
                            estatus.BackgroundColor = new BaseColor(172, 249, 181);
                            break;

                        case "NO DEFINIDO":
                            estatus.BackgroundColor = new BaseColor(255, 255, 170);
                            break;

                        case "EN EVALUACION":
                            estatus.BackgroundColor = new BaseColor(242, 242, 230);
                            break;

                        case "DESCARTADO":
                            estatus.BackgroundColor = new BaseColor(255, 122, 122);
                            break;
                    }
                }

                /*
                PdfPCell nivelRevision = new PdfPCell(new Phrase(f.Celda("nivel_revision").ToString(), small));
                nivelRevision.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell estatusRevision = new PdfPCell(new Phrase(f.Celda("estatus_revision").ToString(), small));
                estatusRevision.HorizontalAlignment = Element.ALIGN_CENTER;
                */

                row = new PdfPRow(new PdfPCell[] { nombre, descripcion, dparametros, origen, estatus });
                tablaRequerimientos.Rows.Add(row);
            });

            ptablaDatos.Add(tablaDatos);
            ptablaRequerimientos.Add(tablaRequerimientos);

            Phrase phrComentarios = new Phrase();
            phrComentarios.Add(new Chunk("Comentarios:" + Environment.NewLine, smallNegrita));
            phrComentarios.Add(new Chunk(comentarios, verySmall));


            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaDatos);
            doc.Add(ptablaRequerimientos);
            if (comentarios != "")
                doc.Add(phrComentarios);
            doc.Add(pmensaje);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] IncrustarQR(byte[] DocumentoPDF, string nombrePlano, string idPlano, int posicionX, int posicionY, int tamanoX = 70, int tamanoY = 70, bool enTodasPaginas = false)
        {
            if (DocumentoPDF == null)
                return DocumentoPDF;

            string subirPdf = Path.GetTempPath() + nombrePlano + "temp" + ".pdf";
            string guardarPDF = Path.GetTempPath() + nombrePlano + ".pdf";
            File.WriteAllBytes(subirPdf, DocumentoPDF);

            PdfReader leerPDf = new PdfReader(subirPdf);
            FileStream fs = new FileStream(guardarPDF, FileMode.Create, FileAccess.Write);
            PdfStamper stamper = new PdfStamper(leerPDf, fs);

            if (enTodasPaginas)
            {
                int PageCount = leerPDf.NumberOfPages;

                for (int i = 1; i <= PageCount; i++)
                {
                    PdfContentByte cb = stamper.GetOverContent(i);
                    BarcodeQRCode qrcode = new BarcodeQRCode(idPlano.ToString(), tamanoX, tamanoY, null);
                    Image imagen = qrcode.GetImage();
                    imagen.SetAbsolutePosition(posicionX, posicionY);
                    cb.AddImage(imagen);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12f);
                    cb.BeginText();
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Id: " + idPlano, posicionX, posicionY - 3, 0);
                }
            }
            else
            {
                PdfContentByte cb = stamper.GetOverContent(1);
                BarcodeQRCode qrcode = new BarcodeQRCode(idPlano.ToString(), tamanoX, tamanoY, null);
                Image imagen = qrcode.GetImage();
                imagen.SetAbsolutePosition(posicionX, posicionY);
                cb.AddImage(imagen);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12f);
                cb.BeginText();
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Id: " + idPlano, posicionX, posicionY-3, 0);
                cb.EndText();
            }

            stamper.Close();
            leerPDf.Close();
            fs.Close();
            byte[] docNuevo = File.ReadAllBytes(guardarPDF);

            return docNuevo;
        }

        public static byte[] PlanDeActividadesEnsamble(decimal proyecto, string responsable)
        {

            ActividadEnsamble Actividad = new ActividadEnsamble();

            #region Inicializar PDF
            byte[] datosPDF = null;
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font verySmall = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font verySmallNegrita = FontFactory.GetFont("Calibri", 7, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 9, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            #endregion

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_audisel_inc_white, BaseColor.WHITE);
            logo.ScaleToFit(225, 80);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("PLAN DE ACTIVIDADES DE ENSAMBLE" + Environment.NewLine, title));
            titulo.Alignment = Element.ALIGN_RIGHT;

            titulo.Add(new Phrase("Fecha de impresión: " + DateTime.Now.ToString("MMM dd, yyyy hh:mm tt") + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;

            titulo.Add(new Phrase("Técnico asignado: " + responsable + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.SpacingAfter = 30;

            // Partidas
            Paragraph ptablaActividad = new Paragraph();
            ptablaActividad.SpacingBefore = 5;
            PdfPTable tablaActividad = new PdfPTable(7);
            tablaActividad.WidthPercentage = 100;

            int[] intTblWidth = { 5, 5, 25, 10, 15, 15, 25 };
            tablaActividad.SetWidths(intTblWidth);

            // Header #
            PdfPCell headerNumero = new PdfPCell(new Phrase("#", tableHeader));
            headerNumero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumero.VerticalAlignment = Element.ALIGN_CENTER;
            headerNumero.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell headerProyecto = new PdfPCell(new Phrase("PROYECTO", tableHeader));
            headerProyecto.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProyecto.VerticalAlignment = Element.ALIGN_CENTER;
            headerProyecto.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion de la actividad
            PdfPCell headerDescripcionActividad = new PdfPCell(new Phrase("DESCRIPCION DE LA ACTIVIDAD", tableHeader));
            headerDescripcionActividad.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcionActividad.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcionActividad.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del estatus inicial
            PdfPCell headerEstatusInicial = new PdfPCell(new Phrase("ESTATUS INICIAL", tableHeader));
            headerEstatusInicial.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEstatusInicial.VerticalAlignment = Element.ALIGN_CENTER;
            headerEstatusInicial.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos de la fecha promesa
            PdfPCell headerFechaPromesa = new PdfPCell(new Phrase("FECHA PROMESA", tableHeader));
            headerFechaPromesa.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFechaPromesa.VerticalAlignment = Element.ALIGN_CENTER;
            headerFechaPromesa.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del estatus actual
            PdfPCell headerEstatusActual = new PdfPCell(new Phrase("ESTATUS ACTUAL", tableHeader));
            headerEstatusActual.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEstatusActual.VerticalAlignment = Element.ALIGN_CENTER;
            headerEstatusActual.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos comentarios
            PdfPCell headerComentarios = new PdfPCell(new Phrase("COMENTARIOS", tableHeader));
            headerComentarios.HorizontalAlignment = Element.ALIGN_CENTER;
            headerComentarios.VerticalAlignment = Element.ALIGN_CENTER;
            headerComentarios.BackgroundColor = new BaseColor(16, 5, 92);



            PdfPRow row = new PdfPRow(new PdfPCell[] { headerNumero, headerProyecto, headerDescripcionActividad, headerEstatusInicial, headerFechaPromesa, headerEstatusActual, headerComentarios });
            tablaActividad.Rows.Add(row);


            ActividadEnsamble.Modelo().ResponsableActividad(responsable, proyecto).ForEach(delegate(Fila f)
            {
                Phrase phrId = new Phrase();
                phrId.Add(new Chunk(f.Celda("id").ToString() + Environment.NewLine + Environment.NewLine, smallNegrita));
                PdfPCell idTabla = new PdfPCell(phrId);
                idTabla.HorizontalAlignment = Element.ALIGN_CENTER;
                idTabla.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell prj = new PdfPCell(new Phrase(Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"), verySmall));
                prj.HorizontalAlignment = Element.ALIGN_CENTER;
                prj.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell descripcion = new PdfPCell(new Phrase(f.Celda("descripcion_actividad").ToString(), verySmall));
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell estatusInicial = new PdfPCell(new Phrase(f.Celda("estatus").ToString(), verySmall));
                estatusInicial.HorizontalAlignment = Element.ALIGN_CENTER;
                estatusInicial.HorizontalAlignment = Element.ALIGN_CENTER;

                Object fp = f.Celda("fecha_promesa");
                string fPromesa = "N/A";
                if (fp != null)
                    fPromesa = Convert.ToDateTime(f.Celda("fecha_promesa")).ToString("MMM dd, yyyy hh:mm:ss tt");

                PdfPCell fechaPromesa = new PdfPCell(new Phrase(fPromesa, verySmall));
                fechaPromesa.HorizontalAlignment = Element.ALIGN_CENTER;
                fechaPromesa.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell estatusActual = new PdfPCell(new Phrase(""));
                PdfPCell comentarios = new PdfPCell(new Phrase(""));

                row = new PdfPRow(new PdfPCell[] { idTabla, prj, descripcion, estatusInicial, fechaPromesa, estatusActual, comentarios });
                tablaActividad.Rows.Add(row);

                switch (f.Celda("estatus").ToString())
                {
                    case "DETENIDO":
                        estatusInicial.BackgroundColor = new BaseColor(255, 122, 122);
                        break;
                }
            });

            ptablaActividad.Add(tablaActividad);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaActividad);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] MiniaturaPDF(string archivoPdf, int width = 264, int height = 204, int dpi=91)
        {
            MagickReadSettings settings = new MagickReadSettings();
            // Settings the density to 300 dpi will create an image with a better quality
            settings.Density = new Density(dpi);

            using (MagickImageCollection images = new MagickImageCollection())
            {
                // Add all the pages of the pdf file to the collection
                images.Read(archivoPdf, settings);

                if (images.Count == 0)
                    return null;

                // Create new image that appends all the pages horizontally
                using (IMagickImage horizontal = images.AppendHorizontally())
                {
                    horizontal.BackgroundColor = new MagickColor(System.Drawing.Color.White);
                    horizontal.Settings.FillColor = new MagickColor(System.Drawing.Color.White);

                    if(width>0 && height>0)
                        horizontal.Resize(width, height);

                    System.Drawing.ImageConverter imgConverter = new System.Drawing.ImageConverter();
                    return (byte[])imgConverter.ConvertTo(horizontal.ToBitmap(), typeof(byte[]));
                }
            }
        }

        public static byte[] MiniaturaPDFByte(byte[] archivoPdf, int width = 264, int height = 204, int dpi = 91)
        {
            MagickReadSettings settings = new MagickReadSettings();
            // Settings the density to 300 dpi will create an image with a better quality
            settings.Density = new Density(dpi);

            using (MagickImageCollection images = new MagickImageCollection())
            {
                // Add all the pages of the pdf file to the collection
                images.Read(archivoPdf, settings);

                if (images.Count == 0)
                    return null;

                // Create new image that appends all the pages horizontally
                using (IMagickImage horizontal = images.AppendHorizontally())
                {
                    horizontal.BackgroundColor = new MagickColor(System.Drawing.Color.White);
                    horizontal.Settings.FillColor = new MagickColor(System.Drawing.Color.White);

                    if (width > 0 && height > 0)
                        horizontal.Resize(width, height);

                    System.Drawing.ImageConverter imgConverter = new System.Drawing.ImageConverter();
                    return (byte[])imgConverter.ConvertTo(horizontal.ToBitmap(), typeof(byte[]));
                }
            }
        }

        public static byte[] PlanTrabajoFabricacion(int plano)
        {
            return new byte[8];
        }

        public static byte[] OrdenDeTratamiento(int idTratamiento, int idPlano, bool visualizar = false)
        {
            byte[] datosPDF = null;

            string calle = "";
            string ciudad = "";
            string estado = "";
            string numero = "";
            string colonia = "";
            string factDir = "";
            string proveedor = "";
            string entregaDir = "";
            string nombreArchivo = "";

            Usuario usr = new Usuario();
            Direccion dir = new Direccion();
            Dictionary<string, object> parametros;

            Proveedor sProveedor = new Proveedor();
            PlanoProyecto plano = new PlanoProyecto();
            OrdenTratamiento tratamiento = new OrdenTratamiento();

            #region Inicializar PDF
            parametros = new Dictionary<string, object>();
            parametros.Add("@id", idTratamiento);
            tratamiento.SeleccionarDatos("id=@id", parametros);
            proveedor = tratamiento.Fila().Celda("proveedor").ToString();
            entregaDir = tratamiento.Fila().Celda("direccion_entrega").ToString();
            factDir = tratamiento.Fila().Celda("direccion_factura").ToString();

            sProveedor.Buscar(proveedor).ForEach(delegate(Fila f)
            {
                calle = f.Celda("calle").ToString();
                ciudad = f.Celda("ciudad").ToString();
                estado = f.Celda("estado").ToString();
                numero = f.Celda("numero").ToString();
                colonia = f.Celda("colonia").ToString();
            });

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font verySmall = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 9, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(170, 78);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
            logo.IndentationLeft = 9;
            logo.SpacingAfter = 30;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("ORDEN DE TRATAMIENTO" + Environment.NewLine, title));
            tratamiento.CargarDatos(idTratamiento).ForEach(delegate(Fila f)
            {
                titulo.Add(new Phrase("Orden: " + idTratamiento.ToString() + Environment.NewLine + Environment.NewLine, negrita));
                titulo.Add(new Phrase("Categoría: " + f.Celda("categoria") + Environment.NewLine, negrita));
                titulo.Add(new Phrase("Tratamiento: " + f.Celda("tratamiento") + Environment.NewLine, negrita));
                titulo.Add(new Phrase("Total estimado: " + f.Celda("precio") + " " + f.Celda("moneda") + Environment.NewLine, negrita));
                Object fecha = f.Celda("fecha_envio");
                string fechaEnvio = "";
                if (fecha != null)
                    fechaEnvio = Convert.ToDateTime(f.Celda("fecha_envio")).ToString("MMM dd, yyyy hh:mm tt");
                else
                    fechaEnvio = DateTime.Now.ToString("MMM dd, yyyy hh:mm tt");
                titulo.Add(new Phrase(fechaEnvio, negrita));
                titulo.Alignment = Element.ALIGN_RIGHT;
            });

            // Tabla de datos
            Paragraph ptablaDatos = new Paragraph();
            ptablaDatos.SpacingBefore = 20;
            PdfPTable tablaDatos = new PdfPTable(4);
            tablaDatos.WidthPercentage = 100;

            // Header datos del solicitante
            PdfPCell headerSolicitante = new PdfPCell(new Phrase("EMITIDA POR", tableHeader));
            headerSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.VerticalAlignment = Element.ALIGN_CENTER;
            headerSolicitante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header datos del proveedor
            PdfPCell headerProveedor = new PdfPCell(new Phrase("DATOS DEL PROVEEDOR", tableHeader));
            headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProveedor.VerticalAlignment = Element.ALIGN_CENTER;
            headerProveedor.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de facturacion
            PdfPCell headerFacturacion = new PdfPCell(new Phrase("DIRECCION DE FACTURACION", tableHeader));
            headerFacturacion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.VerticalAlignment = Element.ALIGN_CENTER;
            headerFacturacion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header direccion de entrega
            PdfPCell headerEntrega = new PdfPCell(new Phrase("DIRECCION DE ENTREGA", tableHeader));
            headerEntrega.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEntrega.VerticalAlignment = Element.ALIGN_CENTER;
            headerEntrega.BackgroundColor = new BaseColor(16, 5, 92);

            // Datos del solicitante
            PdfPCell datosSolicitante = new PdfPCell();
            p = new Paragraph(Global.UsuarioActual.NombreCompleto() + " " + Global.UsuarioActual.Fila().Celda("correo").ToString() + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 10;
            datosSolicitante.AddElement(p);


            // Datos del proveedor
            PdfPCell datosProveedor = new PdfPCell();
            p = new Paragraph(calle + " " + numero + " " + colonia, verySmall);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);
            p = new Paragraph(ciudad + " " + estado, verySmall);
            p.Alignment = Element.ALIGN_CENTER;
            datosProveedor.AddElement(p);

            //datos de facturacion
            parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", factDir);
            dir.SeleccionarDatos("nombre=@nombre", parametros);
            factDir = dir.Fila().Celda("calle").ToString() + " " + dir.Fila().Celda("numero").ToString() + " " + dir.Fila().Celda("colonia").ToString() + " " + dir.Fila().Celda("ciudad").ToString() + " " + dir.Fila().Celda("estado").ToString() + " " + dir.Fila().Celda("pais").ToString();
            PdfPCell datosFacturacion = new PdfPCell();
            p = new Paragraph(factDir + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosFacturacion.AddElement(p);

            // datos entrega
            PdfPCell datosEntrega = new PdfPCell();
            parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", entregaDir);
            dir.SeleccionarDatos("nombre=@nombre", parametros);
            entregaDir = dir.Fila().Celda("calle").ToString() + " " + dir.Fila().Celda("numero").ToString() + " " + dir.Fila().Celda("colonia").ToString() + " " + dir.Fila().Celda("ciudad").ToString() + " " + dir.Fila().Celda("estado").ToString() + " " + dir.Fila().Celda("pais").ToString();
            p = new Paragraph(entregaDir + Environment.NewLine, small);
            p.Alignment = Element.ALIGN_CENTER;
            datosEntrega.AddElement(p);

            PdfPRow row = new PdfPRow(new PdfPCell[] { headerSolicitante, headerProveedor, headerFacturacion, headerEntrega });
            tablaDatos.Rows.Add(row);

            row = new PdfPRow(new PdfPCell[] { datosSolicitante, datosProveedor, datosFacturacion, datosEntrega });
            tablaDatos.Rows.Add(row);

            // Partidas
            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(6);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 10, 20, 20, 20, 20, 20 };
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("#", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

            // Header numero de parte
            PdfPCell headerArchivo = new PdfPCell(new Phrase("NOMBRE DEL ARCHIVO", tableHeader));
            headerArchivo.HorizontalAlignment = Element.ALIGN_CENTER;
            headerArchivo.VerticalAlignment = Element.ALIGN_CENTER;
            headerArchivo.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fabricante
            PdfPCell headerPresentacion = new PdfPCell(new Phrase("PRESENTACION", tableHeader));
            headerPresentacion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPresentacion.VerticalAlignment = Element.ALIGN_CENTER;
            headerPresentacion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerEstatus = new PdfPCell(new Phrase("MATERIAL", tableHeader));
            headerEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
            headerEstatus.VerticalAlignment = Element.ALIGN_CENTER;
            headerEstatus.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad
            PdfPCell headerTratamiento = new PdfPCell(new Phrase("TRATAMIENTO", tableHeader));
            headerTratamiento.HorizontalAlignment = Element.ALIGN_CENTER;
            headerTratamiento.VerticalAlignment = Element.ALIGN_CENTER;
            headerTratamiento.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad
            PdfPCell headerCantidad = new PdfPCell(new Phrase("CANTIDAD", tableHeader));
            headerCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidad.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidad.BackgroundColor = new BaseColor(16, 5, 92);

            row = new PdfPRow(new PdfPCell[] { headerPartida, headerArchivo, headerPresentacion, headerEstatus, headerTratamiento, headerCantidad });
            tablaPartidas.Rows.Add(row);
            #endregion

            parametros = new Dictionary<string, object>();
            parametros.Add("@id", idPlano);

            plano.SeleccionarDatos("id=@id", parametros).ForEach(delegate(Fila f)
            {

                // partida
                PdfPCell partida = new PdfPCell(new Phrase(f.Celda("id").ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;

                // nombre de archivo
                PdfPCell nombreDeArchivo = new PdfPCell(new Phrase(f.Celda("nombre_archivo").ToString(), smallNegrita));
                nombreDeArchivo.HorizontalAlignment = Element.ALIGN_CENTER;
                nombreDeArchivo.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell sPresentacion = new PdfPCell(new Phrase(f.Celda("presentacion").ToString(), small));
                sPresentacion.HorizontalAlignment = Element.ALIGN_CENTER;
                sPresentacion.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell sMaterial = new PdfPCell(new Phrase(f.Celda("material").ToString(), small));
                sMaterial.HorizontalAlignment = Element.ALIGN_CENTER;
                sMaterial.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad
                PdfPCell sTratamiento = new PdfPCell(new Phrase(f.Celda("tratamiento").ToString(), small));
                sTratamiento.HorizontalAlignment = Element.ALIGN_CENTER;
                sTratamiento.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad
                PdfPCell sCantidad = new PdfPCell(new Phrase(f.Celda("cantidad").ToString(), small));
                sCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                sCantidad.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, nombreDeArchivo, sPresentacion, sMaterial, sTratamiento, sCantidad });
                tablaPartidas.Rows.Add(row);
            });

            ptablaPartidas.Add(tablaPartidas);
            ptablaDatos.Add(tablaDatos);

            // Construye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaDatos);
            doc.Add(ptablaPartidas);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] BajaMaterialAlmacen(List<int> idMateriales, string nombreSolicitante)
        {

            #region inicializar PDF
            //if(!material.TieneFilas()) return;
            byte[] datosPDF;
            MaterialProyecto material = new MaterialProyecto();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 11, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(170, 78);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
            logo.IndentationLeft = 9;
            logo.SpacingAfter = 30;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("VALE DE SALIDA DE MATERIAL" + Environment.NewLine, title));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt") + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase("Recibe: " + nombreSolicitante + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase("Entrega: " + Global.UsuarioActual.NombreCompleto() + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.SpacingAfter = 50;

            // Partidas
            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(7);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 20, 50, 50, 50, 40, 30, 40 };
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("No", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

            // Header numero de parte
            PdfPCell headerNumeroDeParte = new PdfPCell(new Phrase("NUM. DE PARTE", tableHeader));
            headerNumeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fabricante
            PdfPCell headerFabricante = new PdfPCell(new Phrase("FABRICANTE", tableHeader));
            headerFabricante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFabricante.VerticalAlignment = Element.ALIGN_CENTER;
            headerFabricante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPCION", tableHeader));
            headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad
            PdfPCell headerCantidadEstimada = new PdfPCell(new Phrase("CANTIDAD", tableHeader));
            headerCantidadEstimada.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidadEstimada.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidadEstimada.BackgroundColor = new BaseColor(16, 5, 92);

            // Header PO
            PdfPCell headerPO = new PdfPCell(new Phrase("PO", tableHeader));
            headerPO.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPO.VerticalAlignment = Element.ALIGN_CENTER;
            headerPO.BackgroundColor = new BaseColor(16, 5, 92);

            // Header proyecto
            PdfPCell headerProyecto = new PdfPCell(new Phrase("PROYECTO", tableHeader));
            headerProyecto.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProyecto.VerticalAlignment = Element.ALIGN_CENTER;
            headerProyecto.BackgroundColor = new BaseColor(16, 5, 92);

            #endregion
            PdfPRow row = new PdfPRow(new PdfPCell[] { headerPartida, headerNumeroDeParte, headerFabricante, headerDescripcion, headerCantidadEstimada, headerPO, headerProyecto });
            tablaPartidas.Rows.Add(row);

            Paragraph ptablaFirmas = new Paragraph();
            ptablaFirmas.SpacingBefore = 5;
            PdfPTable tablaFirmas = new PdfPTable(2);
            tablaFirmas.WidthPercentage = 100;

            int[] intTblWidthFirmas = { 50, 50 };
            tablaFirmas.SetWidths(intTblWidthFirmas);

            // Header firma entregado
            PdfPCell headerFirmaEntrega = new PdfPCell(new Phrase("FIRMA ENTREGA", tableHeader));
            headerFirmaEntrega.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaEntrega.VerticalAlignment = Element.ALIGN_CENTER;
            headerFirmaEntrega.BackgroundColor = new BaseColor(16, 5, 92);

            // Header firma recibido
            PdfPCell headerFirmaRecibe = new PdfPCell(new Phrase("FIRMA RECIBE", tableHeader));
            headerFirmaRecibe.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaRecibe.VerticalAlignment = Element.ALIGN_CENTER;
            headerFirmaRecibe.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPRow rowFirma = new PdfPRow(new PdfPCell[] { headerFirmaRecibe, headerFirmaEntrega });
            tablaFirmas.Rows.Add(rowFirma);

            // partida
            PdfPCell espacioBlanco = new PdfPCell(new Phrase("" + Environment.NewLine + Environment.NewLine + Environment.NewLine, smallNegrita));
            espacioBlanco.HorizontalAlignment = Element.ALIGN_CENTER;
            espacioBlanco.VerticalAlignment = Element.ALIGN_CENTER;

            // numero de parte
            PdfPCell espacioBlancoRecibe = new PdfPCell(new Phrase("" + Environment.NewLine + Environment.NewLine + Environment.NewLine, smallNegrita));
            espacioBlancoRecibe.HorizontalAlignment = Element.ALIGN_CENTER;
            espacioBlancoRecibe.VerticalAlignment = Element.ALIGN_CENTER;

            rowFirma = new PdfPRow(new PdfPCell[] { espacioBlanco, espacioBlancoRecibe });
            tablaFirmas.Rows.Add(rowFirma);


            int numPartida = 1;
            foreach (int FilaActual in idMateriales)
            {
                material.CargarDatos(FilaActual);

                // partida
                PdfPCell partida = new PdfPCell(new Phrase("# " + numPartida.ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;

                // numero de parte
                PdfPCell numeroDeParte = new PdfPCell(new Phrase(material.Fila().Celda("numero_parte").ToString(), smallNegrita));
                numeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
                numeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell fabricante = new PdfPCell(new Phrase(material.Fila().Celda("fabricante").ToString(), small));
                fabricante.HorizontalAlignment = Element.ALIGN_CENTER;
                fabricante.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell descripcion = new PdfPCell(new Phrase(material.Fila().Celda("descripcion").ToString(), small));
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                descripcion.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad almacen/ entregada
                 PdfPCell cantidad_estimada;
                object cantidadEntregada = material.Fila().Celda("cantidad_entregada");
                int pzasEntregas = 0;
                if(cantidadEntregada != null)
                    pzasEntregas = Convert.ToInt32(cantidadEntregada);

                if(pzasEntregas == 0)
                    cantidad_estimada = new PdfPCell(new Phrase(material.Fila().Celda("cantidad_almacen").ToString(), small));
                else
                    cantidad_estimada = new PdfPCell(new Phrase(material.Fila().Celda("cantidad_entregada").ToString(), small));
                
                cantidad_estimada.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad_estimada.VerticalAlignment = Element.ALIGN_CENTER;

                string strPlano = string.Empty;
                object plano =material.Fila().Celda("plano");
                if (plano == null)
                    plano = 0;
                if(Convert.ToInt32(plano) <= 0)
                    strPlano = material.Fila().Celda("po").ToString();
                else
                    strPlano = material.Fila().Celda("po").ToString() + Environment.NewLine + "plano: " + plano.ToString();
                //PO
                PdfPCell PO = new PdfPCell(new Phrase(strPlano, small));
                PO.HorizontalAlignment = Element.ALIGN_CENTER;
                PO.VerticalAlignment = Element.ALIGN_CENTER;

                //proyecto
                PdfPCell proyecto = new PdfPCell(new Phrase(material.Fila().Celda("proyecto").ToString(), small));
                proyecto.HorizontalAlignment = Element.ALIGN_CENTER;
                proyecto.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad_estimada, PO, proyecto });
                tablaPartidas.Rows.Add(row);

                numPartida++;
            }

            tablaPartidas.SpacingAfter = 50;
            ptablaPartidas.Add(tablaPartidas);
            ptablaFirmas.Add(tablaFirmas);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaPartidas);
            doc.Add(ptablaFirmas);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] BajaMaterialStock(List<int> idMateriales, string nombreSolicitante)
        {
            #region inicializar PDF
            //if(!material.TieneFilas()) return;
            byte[] datosPDF;
            MaterialStock material = new MaterialStock();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 11, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(170, 78);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
            logo.IndentationLeft = 9;
            logo.SpacingAfter = 30;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("VALE DE SALIDA DE MATERIAL" + Environment.NewLine, title));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt") + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase("Recibe: " + nombreSolicitante + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase("Entrega: " + Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno") + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.SpacingAfter = 50;

            // Partidas
            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(5);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 20, 50, 50, 50, 40};
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("No", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

            // Header numero de parte
            PdfPCell headerNumeroDeParte = new PdfPCell(new Phrase("NUM. DE PARTE", tableHeader));
            headerNumeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;
            headerNumeroDeParte.BackgroundColor = new BaseColor(16, 5, 92);

            // Header fabricante
            PdfPCell headerFabricante = new PdfPCell(new Phrase("FABRICANTE", tableHeader));
            headerFabricante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFabricante.VerticalAlignment = Element.ALIGN_CENTER;
            headerFabricante.BackgroundColor = new BaseColor(16, 5, 92);

            // Header descripcion
            PdfPCell headerDescripcion = new PdfPCell(new Phrase("DESCRIPCION", tableHeader));
            headerDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcion.BackgroundColor = new BaseColor(16, 5, 92);

            // Header cantidad
            PdfPCell headerCantidadEstimada = new PdfPCell(new Phrase("CANTIDAD", tableHeader));
            headerCantidadEstimada.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidadEstimada.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidadEstimada.BackgroundColor = new BaseColor(16, 5, 92);

            #endregion
            PdfPRow row = new PdfPRow(new PdfPCell[] { headerPartida, headerNumeroDeParte, headerFabricante, headerDescripcion, headerCantidadEstimada});
            tablaPartidas.Rows.Add(row);

            Paragraph ptablaFirmas = new Paragraph();
            ptablaFirmas.SpacingBefore = 5;
            PdfPTable tablaFirmas = new PdfPTable(2);
            tablaFirmas.WidthPercentage = 100;

            int[] intTblWidthFirmas = { 50, 50 };
            tablaFirmas.SetWidths(intTblWidthFirmas);

            // Header firma entregado
            PdfPCell headerFirmaEntrega = new PdfPCell(new Phrase("FIRMA ENTREGA", tableHeader));
            headerFirmaEntrega.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaEntrega.VerticalAlignment = Element.ALIGN_CENTER;
            headerFirmaEntrega.BackgroundColor = new BaseColor(16, 5, 92);

            // Header firma recibido
            PdfPCell headerFirmaRecibe = new PdfPCell(new Phrase("FIRMA RECIBE", tableHeader));
            headerFirmaRecibe.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaRecibe.VerticalAlignment = Element.ALIGN_CENTER;
            headerFirmaRecibe.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPRow rowFirma = new PdfPRow(new PdfPCell[] { headerFirmaRecibe, headerFirmaEntrega });
            tablaFirmas.Rows.Add(rowFirma);

            // partida
            PdfPCell espacioBlanco = new PdfPCell(new Phrase("" + Environment.NewLine + Environment.NewLine + Environment.NewLine, smallNegrita));
            espacioBlanco.HorizontalAlignment = Element.ALIGN_CENTER;
            espacioBlanco.VerticalAlignment = Element.ALIGN_CENTER;

            // numero de parte
            PdfPCell espacioBlancoRecibe = new PdfPCell(new Phrase("" + Environment.NewLine + Environment.NewLine + Environment.NewLine, smallNegrita));
            espacioBlancoRecibe.HorizontalAlignment = Element.ALIGN_CENTER;
            espacioBlancoRecibe.VerticalAlignment = Element.ALIGN_CENTER;

            rowFirma = new PdfPRow(new PdfPCell[] { espacioBlanco, espacioBlancoRecibe });
            tablaFirmas.Rows.Add(rowFirma);

            int numPartida = 1;
            foreach (int FilaActual in idMateriales)
            {
                material.CargarDatos(FilaActual);

                // partida
                PdfPCell partida = new PdfPCell(new Phrase("# " + numPartida.ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;

                // numero de parte
                PdfPCell numeroDeParte = new PdfPCell(new Phrase(material.Fila().Celda("numero_parte").ToString(), smallNegrita));
                numeroDeParte.HorizontalAlignment = Element.ALIGN_CENTER;
                numeroDeParte.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell fabricante = new PdfPCell(new Phrase(material.Fila().Celda("fabricante").ToString(), small));
                fabricante.HorizontalAlignment = Element.ALIGN_CENTER;
                fabricante.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell descripcion = new PdfPCell(new Phrase(material.Fila().Celda("descripcion").ToString(), small));
                descripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                descripcion.VerticalAlignment = Element.ALIGN_CENTER;

                // cantidad almacen/ entregada
                PdfPCell cantidad_estimada;
                object cantidadEntregada = material.Fila().Celda("cantidad_entregada");
                int pzasEntregas = 0;
                if (cantidadEntregada != null)
                    pzasEntregas = Convert.ToInt32(cantidadEntregada);

                if (pzasEntregas == 0)
                    cantidad_estimada = new PdfPCell(new Phrase(material.Fila().Celda("cantidad_disponible").ToString(), small));
                else
                    cantidad_estimada = new PdfPCell(new Phrase(material.Fila().Celda("cantidad_entregada").ToString(), small));

                cantidad_estimada.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad_estimada.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, numeroDeParte, fabricante, descripcion, cantidad_estimada});
                tablaPartidas.Rows.Add(row);

                numPartida++;

            }

            tablaPartidas.SpacingAfter = 50;
            ptablaPartidas.Add(tablaPartidas);
            ptablaFirmas.Add(tablaFirmas);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaPartidas);
            doc.Add(ptablaFirmas);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] BajaPlanoFabricacion(List<int> idMateriales, string nombreSolicitante, string siguienteProceso)
        {
            #region inicializar PDF
            //if(!material.TieneFilas()) return;
            byte[] datosPDF;
            PlanoProyecto plano = new PlanoProyecto();

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 11, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(170, 78);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
            logo.IndentationLeft = 9;
            logo.SpacingAfter = 30;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("VALE DE ENTREGA DE PIEZAS FABRICADAS" + Environment.NewLine, title));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt") + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase("Recibe: " + nombreSolicitante + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase("Entrega: " + Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno") + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.Add(new Phrase("Siguiente proceso: " + siguienteProceso + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.SpacingAfter = 50;

            // Partidas


            Paragraph ptablaPartidas = new Paragraph();
            ptablaPartidas.SpacingBefore = 5;
            PdfPTable tablaPartidas = new PdfPTable(5);
            tablaPartidas.WidthPercentage = 100;

            int[] intTblWidth = { 20, 40, 50, 40, 50 };
            tablaPartidas.SetWidths(intTblWidth);

            // Header partida
            PdfPCell headerPartida = new PdfPCell(new Phrase("ID", tableHeader));
            headerPartida.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPartida.VerticalAlignment = Element.ALIGN_CENTER;
            headerPartida.BackgroundColor = new BaseColor(16, 5, 92);

            // Header proyecto
            PdfPCell headerProyecto = new PdfPCell(new Phrase("PROYECTO", tableHeader));
            headerProyecto.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProyecto.VerticalAlignment = Element.ALIGN_CENTER;
            headerProyecto.BackgroundColor = new BaseColor(16, 5, 92);

            // Header nombre plano
            PdfPCell headerArchivo = new PdfPCell(new Phrase("PLANO", tableHeader));
            headerArchivo.HorizontalAlignment = Element.ALIGN_CENTER;
            headerArchivo.VerticalAlignment = Element.ALIGN_CENTER;
            headerArchivo.BackgroundColor = new BaseColor(16, 5, 92);

            // Header size
            PdfPCell headerCantidad = new PdfPCell(new Phrase("CANTIDAD", tableHeader));
            headerCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidad.VerticalAlignment = Element.ALIGN_CENTER;
            headerCantidad.BackgroundColor = new BaseColor(16, 5, 92);

            // Header size
            PdfPCell headerSize = new PdfPCell(new Phrase("STOCK SIZE", tableHeader));
            headerSize.HorizontalAlignment = Element.ALIGN_CENTER;
            headerSize.VerticalAlignment = Element.ALIGN_CENTER;
            headerSize.BackgroundColor = new BaseColor(16, 5, 92);
            
            #endregion
            PdfPRow row = new PdfPRow(new PdfPCell[] { headerPartida, headerProyecto, headerArchivo, headerCantidad, headerSize });
            tablaPartidas.Rows.Add(row);

            Paragraph ptablaFirmas = new Paragraph();
            ptablaFirmas.SpacingBefore = 5;
            PdfPTable tablaFirmas = new PdfPTable(2);
            tablaFirmas.WidthPercentage = 100;

            int[] intTblWidthFirmas = { 50, 50 };
            tablaFirmas.SetWidths(intTblWidthFirmas);

            // Header Firma
            PdfPCell headerFirmaEntrega = new PdfPCell(new Phrase("FIRMA ENTREGA", tableHeader));
            headerFirmaEntrega.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaEntrega.VerticalAlignment = Element.ALIGN_CENTER;
            headerFirmaEntrega.BackgroundColor = new BaseColor(16, 5, 92);


            PdfPCell headerFirmaRecibe = new PdfPCell(new Phrase("FIRMA RECIBE", tableHeader));
            headerFirmaRecibe.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaRecibe.VerticalAlignment = Element.ALIGN_CENTER;
            headerFirmaRecibe.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPRow rowFirma = new PdfPRow(new PdfPCell[] { headerFirmaRecibe, headerFirmaEntrega });
            tablaFirmas.Rows.Add(rowFirma);
            
            PdfPCell espacioBlanco = new PdfPCell(new Phrase("" + Environment.NewLine + Environment.NewLine + Environment.NewLine, smallNegrita));
            espacioBlanco.HorizontalAlignment = Element.ALIGN_CENTER;
            espacioBlanco.VerticalAlignment = Element.ALIGN_CENTER;
            
            PdfPCell espacioBlancoRecibe = new PdfPCell(new Phrase("" + Environment.NewLine + Environment.NewLine + Environment.NewLine, smallNegrita));
            espacioBlancoRecibe.HorizontalAlignment = Element.ALIGN_CENTER;
            espacioBlancoRecibe.VerticalAlignment = Element.ALIGN_CENTER;

            rowFirma = new PdfPRow(new PdfPCell[] { espacioBlanco, espacioBlancoRecibe });
            tablaFirmas.Rows.Add(rowFirma);
            
            int numPartida = 1;
            foreach (int FilaActual in idMateriales)
            {
                plano.CargarDatos(FilaActual);

                // partida
                PdfPCell partida = new PdfPCell(new Phrase(plano.Fila().Celda("id").ToString(), smallNegrita));
                partida.HorizontalAlignment = Element.ALIGN_CENTER;
                partida.VerticalAlignment = Element.ALIGN_CENTER;

                // numero de proyecto
                PdfPCell proyecto = new PdfPCell(new Phrase(plano.Fila().Celda("proyecto").ToString(), smallNegrita));
                proyecto.HorizontalAlignment = Element.ALIGN_CENTER;
                proyecto.VerticalAlignment = Element.ALIGN_CENTER;

                // fabricante
                PdfPCell archivo = new PdfPCell(new Phrase(plano.Fila().Celda("nombre_archivo").ToString(), small));
                archivo.HorizontalAlignment = Element.ALIGN_CENTER;
                archivo.VerticalAlignment = Element.ALIGN_CENTER;

                // descripcion
                PdfPCell proveedorMaquinado = new PdfPCell(new Phrase(plano.Fila().Celda("proveedor_maquinado").ToString(), small));
                proveedorMaquinado.HorizontalAlignment = Element.ALIGN_CENTER;
                proveedorMaquinado.VerticalAlignment = Element.ALIGN_CENTER;

                //material
                PdfPCell material = new PdfPCell(new Phrase(plano.Fila().Celda("material").ToString(), small));
                material.HorizontalAlignment = Element.ALIGN_CENTER;
                material.VerticalAlignment = Element.ALIGN_CENTER;

                //tamaño
                PdfPCell size = new PdfPCell(new Phrase(plano.Fila().Celda("size").ToString(), small));
                size.HorizontalAlignment = Element.ALIGN_CENTER;
                size.VerticalAlignment = Element.ALIGN_CENTER;

                //tratamiento
                PdfPCell tratamiento = new PdfPCell(new Phrase(plano.Fila().Celda("tratamiento").ToString(), small));
                tratamiento.HorizontalAlignment = Element.ALIGN_CENTER;
                tratamiento.VerticalAlignment = Element.ALIGN_CENTER;

                //cantidad
                PdfPCell cantidad = new PdfPCell(new Phrase(plano.Fila().Celda("cantidad").ToString(), small));
                cantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                cantidad.VerticalAlignment = Element.ALIGN_CENTER;

                row = new PdfPRow(new PdfPCell[] { partida, proyecto, archivo, cantidad, size });
                tablaPartidas.Rows.Add(row);

                numPartida++;

            }

            tablaPartidas.SpacingAfter = 50;
            ptablaPartidas.Add(tablaPartidas);
            ptablaFirmas.Add(tablaFirmas);

            // Contruye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(ptablaPartidas);
            doc.Add(ptablaFirmas);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] AceptacionDisenoFinal(decimal proyecto, List<int> vista, List<int> requerimiento, List<int> elementos, List<int> secuencia, List<int> fallas, int idModulo, int subensambleId, bool concepto = false)
        {
            #region inicializar PDF

            bool isometrico = false;
            bool frontal = false;
            bool lateralDerecha = false;
            bool lateralIzquierda = false;
            bool req = false;
            bool bElemento = false;
            bool bSecuencia = false;
            bool bFallas = false;

            Cliente cCliente = new Cliente();
            Proyecto cProyecto = new Proyecto();
            ImagenModulo imagenModulo = new ImagenModulo();
            ClienteContacto cClienteContacto = new ClienteContacto();

            byte[] datosPDF;
            int idCliente = 0;
            int idContacto = 0;
            string contenido = "";
            string sTitulo = "";
            if (!concepto)
            {
                contenido = "According to the meetings with %CLIENTE% (represented by %CONTACTO%)"
                                    + " and previous concept and design reviews on Audisel site, this document"
                                    + " shows the final design of one module or subassembly, the scope is to "
                                    + "validate its final design, as soon as it is approved we will start the "
                                    + "manufacturing and purchasing of parts.";

                sTitulo = "FINAL DESIGN APPROVAL";
            }
            else
            {
                contenido = "According to %CLIENTE% (represented by %CONTACTO%)"
                                    + " this document shows the concept design of one module or subassembly, the scope is to "
                                    + "validate its concept design.";

                sTitulo = "CONCEPT DESIGN APPROVAL";
            }



            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font normalSmall = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font headers = FontFactory.GetFont("Calibri", 9, 1, BaseColor.WHITE);
            Font tableHeader = FontFactory.GetFont("Calibri", 11, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();
            #endregion

            #region Título y headers

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(170, 78);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
            logo.IndentationLeft = 9;
            logo.SpacingAfter = 15;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            // Agregar texto
            Paragraph texto = new Paragraph();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            //inforacion
            Paragraph ptablaInformacion = new Paragraph();
            ptablaInformacion.SpacingBefore = 5;
            PdfPTable tablaInformacion = new PdfPTable(3);
            tablaInformacion.WidthPercentage = 100;

            Modulo modulo = new Modulo();

            modulo.SeleccionarDatos("proyecto=@proyecto", parametros);
            if (modulo.TieneFilas())
            {
                titulo.Add(new Phrase(sTitulo + Environment.NewLine, title));
                titulo.Alignment = Element.ALIGN_RIGHT;
                titulo.Add(new Phrase("DATE: " + DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt") + Environment.NewLine, negrita));
                titulo.Alignment = Element.ALIGN_RIGHT;

                int[] intTblWidthInformacion = { 50, 50, 50 };
                tablaInformacion.SetWidths(intTblWidthInformacion);

                PdfPCell informacionProyectoHeader = new PdfPCell(new Phrase("PROJECT INFORMATION", headers));
                informacionProyectoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                informacionProyectoHeader.VerticalAlignment = Element.ALIGN_CENTER;
                informacionProyectoHeader.BackgroundColor = new BaseColor(16, 5, 92);

                PdfPCell personalAsignadoHeader = new PdfPCell(new Phrase("ASSIGNED PERSONNEL", headers));
                personalAsignadoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                personalAsignadoHeader.VerticalAlignment = Element.ALIGN_CENTER;
                personalAsignadoHeader.BackgroundColor = new BaseColor(16, 5, 92);

                PdfPCell ordenCompraHeader = new PdfPCell(new Phrase("PURCHASE ORDER(S)", headers));
                ordenCompraHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                ordenCompraHeader.VerticalAlignment = Element.ALIGN_CENTER;
                ordenCompraHeader.BackgroundColor = new BaseColor(16, 5, 92);

                PdfPRow rowInformacion = new PdfPRow(new PdfPCell[] { informacionProyectoHeader, personalAsignadoHeader, ordenCompraHeader });
                tablaInformacion.Rows.Add(rowInformacion);

                Proyecto proy = new Proyecto();
                proy.CargarDatos(Convert.ToDecimal(Convert.ToInt32(proyecto).ToString("F2")));
                string strProyecto = "";
                if (proy.TieneFilas())
                    strProyecto = proy.Fila().Celda("nombre").ToString();

                Proyecto subProy = new Proyecto();
                subProy.CargarDatos(proyecto);
                string strSubproy = "";
                if (subProy.TieneFilas())
                    strSubproy = subProy.Fila().Celda("nombre").ToString();

                Phrase phProyecto = new Phrase();
                Phrase phProyectoNombre = new Phrase("PROJECT: ", normalSmall);
                Phrase phProyectoNombreValor = new Phrase(Convert.ToInt32(proyecto).ToString("F2") + " - " + strProyecto + "\r\n", small);
                Phrase phSubproyecto = new Phrase("SUBPROJECT: ", normalSmall);
                Phrase phSubproyectoValor = new Phrase(Convert.ToDecimal(modulo.Fila().Celda("proyecto")).ToString("F2") + " - " + strSubproy + "\r\n", small);
                Phrase phModulo = new Phrase("MODULE: ", normalSmall);
                Phrase phModuloValor = new Phrase(subensambleId + " - " + modulo.Fila().Celda("nombre"), small);

                phProyecto.Add(phProyectoNombre);
                phProyecto.Add(phProyectoNombreValor);
                phProyecto.Add(phSubproyecto);
                phProyecto.Add(phSubproyectoValor);
                phProyecto.Add(phModulo);
                phProyecto.Add(phModuloValor);

                PdfPCell informacion = new PdfPCell(phProyecto);
                informacion.HorizontalAlignment = Element.ALIGN_LEFT;
                informacion.VerticalAlignment = Element.ALIGN_LEFT;

                parametros = new Dictionary<string, object>();
                parametros.Add("@id", Convert.ToDecimal(proyecto).ToString("F2"));
                cProyecto.SeleccionarDatos("id=@id", parametros);

                Phrase personalDoc = new Phrase();
                Phrase personalLider = new Phrase();
                Phrase personalLiderValor = new Phrase();
                Phrase personalDisenador;
                Phrase peronalDisenoValor;

                if (cProyecto.TieneFilas())
                {
                    Usuario.Modelo().CargarDatos(Convert.ToInt32(cProyecto.Fila().Celda("liderproyecto"))).ForEach(delegate(Fila usuario)
                    {
                        personalLider = new Phrase("PROJECT LEADER: ", normalSmall);
                        personalLiderValor = new Phrase(usuario.Celda("nombre") + " " + usuario.Celda("paterno") + "\r\n", small);
                    });

                    idCliente = Convert.ToInt32(cProyecto.Fila().Celda("cliente"));
                    idContacto = Convert.ToInt32(cProyecto.Fila().Celda("contacto"));
                }
                else
                {
                    personalLider = new Phrase("PROJECT LEADER: ", normalSmall);
                    personalLiderValor = new Phrase("N/A \r\n", small);
                }

                personalDisenador = new Phrase("MECHANICAL DESIGNER: ", normalSmall);
                peronalDisenoValor = new Phrase(modulo.Fila().Celda("mecanico").ToString(), small);

                personalDoc.Add(personalLider);
                personalDoc.Add(personalLiderValor);
                personalDoc.Add(personalDisenador);
                personalDoc.Add(peronalDisenoValor);

                PdfPCell informacionSubproyecto = new PdfPCell(personalDoc);
                informacionSubproyecto.HorizontalAlignment = Element.ALIGN_LEFT;
                informacionSubproyecto.VerticalAlignment = Element.ALIGN_LEFT;

                parametros = new Dictionary<string, object>();
                parametros.Add("@idProyecto", Convert.ToInt32(proyecto));
                string poLista = "";

                PoProyecto.Modelo().SeleccionarDatos("proyecto=@idProyecto", parametros).ForEach(delegate(Fila orden)
                {
                    string archivo = orden.Celda("nombre_archivo").ToString();
                    int index = archivo.LastIndexOf(".");
                    string po = archivo.Substring(0, index);
                    poLista += po + "\r\n";

                });

                PdfPCell poHeader = new PdfPCell(new Phrase(poLista, normalSmall));
                poHeader.HorizontalAlignment = Element.ALIGN_LEFT;
                poHeader.VerticalAlignment = Element.ALIGN_LEFT;

                rowInformacion = new PdfPRow(new PdfPCell[] { informacion, informacionSubproyecto, poHeader });
                tablaInformacion.Rows.Add(rowInformacion);

                titulo.Alignment = Element.ALIGN_RIGHT;
                titulo.SpacingAfter = 50;
                cCliente.CargarDatos(idCliente);
                if (cCliente.TieneFilas())
                {
                    contenido = contenido.Replace("%CLIENTE%", cCliente.Fila().Celda("nombre").ToString());
                }
                else
                {
                    contenido = contenido.Replace("%CLIENTE%", "N/A");
                }

                cClienteContacto.CargarDatos(idContacto);
                if (cClienteContacto.TieneFilas())
                {
                    contenido = contenido.Replace("%CONTACTO%", cClienteContacto.Fila().Celda("nombre") + " " + cClienteContacto.Fila().Celda("apellidos"));
                }
                else
                {
                    contenido = contenido.Replace("%CONTACTO%", "N/A");
                }
                // Agregar texto
                texto.Add(new Phrase(contenido + Environment.NewLine, normal));
                texto.Alignment = Element.ALIGN_LEFT;
                texto.SpacingAfter = 5;
                texto.SpacingBefore = 20;
            }
            #endregion

            #region Vistas

            //vista isometrica
            Paragraph ptablaIsometrico = new Paragraph();
            ptablaIsometrico.SpacingBefore = 5;

            PdfPTable tablaIsometrico = new PdfPTable(2);
            tablaIsometrico.WidthPercentage = 100;
            tablaIsometrico.SpacingBefore = 5;

            Dictionary<string, object> tablaParametros;

            int[] intTblWidthIsometrico = { 35, 65 };
            tablaIsometrico.SetWidths(intTblWidthIsometrico);

            PdfPCell isometricViewHeader = new PdfPCell(new Phrase("ISOMETRIC VIEW", headers));
            isometricViewHeader.Colspan = tablaIsometrico.NumberOfColumns;
            isometricViewHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            isometricViewHeader.VerticalAlignment = Element.ALIGN_CENTER;
            isometricViewHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell isometricViewHeader2 = new PdfPCell(new Phrase("", headers));

            PdfPRow rowIsometrico = new PdfPRow(new PdfPCell[] { isometricViewHeader, isometricViewHeader2 });
            tablaIsometrico.Rows.Add(rowIsometrico);

            foreach (var item in vista)
            {
                int idImagenModulo = item;

                tablaParametros = new Dictionary<string, object>();
                tablaParametros.Add("@id", idImagenModulo);
                tablaParametros.Add("@vista", "ISOMETRICO");
                imagenModulo.SeleccionarDatos("id=@id AND vista=@vista", tablaParametros);

                PdfPCell isometricoImage;
                PdfPCell isometricoDescrip;

                if (imagenModulo.TieneFilas())
                {
                    byte[] imagen = (byte[])imagenModulo.Fila().Celda("archivo");
                    Image min = Image.GetInstance(imagen);
                    min.ScaleToFit(190, 130);
                    min.Alignment = Image.ALIGN_RIGHT;

                    isometricoImage = new PdfPCell(min);
                    isometricoImage.HorizontalAlignment = Element.ALIGN_CENTER;
                    isometricoImage.VerticalAlignment = Element.ALIGN_CENTER;
                    isometricoImage.ExtraParagraphSpace = 1;

                    isometricoDescrip = new PdfPCell(new Phrase(imagenModulo.Fila().Celda("descripcion").ToString(), small));
                    isometricoDescrip.HorizontalAlignment = Element.ALIGN_LEFT;
                    isometricoDescrip.VerticalAlignment = Element.ALIGN_LEFT;
                    isometrico = true;

                    rowIsometrico = new PdfPRow(new PdfPCell[] { isometricoImage, isometricoDescrip });
                    tablaIsometrico.Rows.Add(rowIsometrico);
                }
            }

            //vista frontal
            Paragraph ptablaFrontal = new Paragraph();
            ptablaFrontal.SpacingBefore = 5;
            PdfPTable tablaFrontal = new PdfPTable(2);
            tablaFrontal.WidthPercentage = 100;

            int[] intTblWidthFrontal = { 35, 65 };
            tablaFrontal.SetWidths(intTblWidthFrontal);

            PdfPCell frontalViewHeader = new PdfPCell(new Phrase("FRONT VIEW", headers));
            frontalViewHeader.Colspan = tablaFrontal.NumberOfColumns;
            frontalViewHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            frontalViewHeader.VerticalAlignment = Element.ALIGN_CENTER;
            frontalViewHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell frontalViewHeader2 = new PdfPCell(new Phrase("", tableHeader));

            PdfPRow rowFrontal = new PdfPRow(new PdfPCell[] { frontalViewHeader, frontalViewHeader2 });
            tablaFrontal.Rows.Add(rowFrontal);

            foreach (var item in vista)
            {
                int idImagenModulo = item;

                tablaParametros = new Dictionary<string, object>();
                tablaParametros.Add("@id", idImagenModulo);
                tablaParametros.Add("@vista", "FRONTAL");
                imagenModulo.SeleccionarDatos("id=@id AND vista=@vista", tablaParametros);

                if (imagenModulo.TieneFilas())
                {
                    byte[] imagen = (byte[])imagenModulo.Fila().Celda("archivo");
                    Image min = Image.GetInstance(imagen);
                    min.ScaleToFit(80, 80);
                    min.Alignment = Image.ALIGN_RIGHT;

                    PdfPCell FrontcoImage = new PdfPCell(min);
                    FrontcoImage.HorizontalAlignment = Element.ALIGN_CENTER;
                    FrontcoImage.VerticalAlignment = Element.ALIGN_CENTER;
                    FrontcoImage.ExtraParagraphSpace = 1;

                    PdfPCell frontalDescrip = new PdfPCell(new Phrase(imagenModulo.Fila().Celda("descripcion").ToString(), small));
                    frontalDescrip.HorizontalAlignment = Element.ALIGN_LEFT;
                    frontalDescrip.VerticalAlignment = Element.ALIGN_LEFT;
                    frontal = true;

                    rowFrontal = new PdfPRow(new PdfPCell[] { FrontcoImage, frontalDescrip });
                    tablaFrontal.Rows.Add(rowFrontal);
                }
            }

            //vista lateral derecha
            Paragraph ptablaLateral = new Paragraph();
            ptablaLateral.SpacingBefore = 5;
            PdfPTable tablaLateral = new PdfPTable(2);
            tablaLateral.WidthPercentage = 100;

            int[] intTblWidthLateral = { 35, 65 };
            tablaLateral.SetWidths(intTblWidthLateral);

            PdfPCell lateralViewHeader = new PdfPCell(new Phrase("RIGHT SIDE VIEW", headers));
            lateralViewHeader.Colspan = tablaLateral.NumberOfColumns;
            lateralViewHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            lateralViewHeader.VerticalAlignment = Element.ALIGN_CENTER;
            lateralViewHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell lateralViewHeader2 = new PdfPCell(new Phrase("", tableHeader));

            PdfPRow rowLateral = new PdfPRow(new PdfPCell[] { lateralViewHeader, lateralViewHeader2 });
            tablaLateral.Rows.Add(rowLateral);

            foreach (var item in vista)
            {
                int idImagenModulo = item;

                tablaParametros = new Dictionary<string, object>();
                tablaParametros.Add("@id", idImagenModulo);
                tablaParametros.Add("@vista", "LATERAL DERECHA");
                imagenModulo.SeleccionarDatos("id=@id AND vista=@vista", tablaParametros);

                if (imagenModulo.TieneFilas())
                {
                    byte[] imagen = (byte[])imagenModulo.Fila().Celda("archivo");
                    Image min = Image.GetInstance(imagen);
                    min.ScaleToFit(80, 80);
                    min.Alignment = Image.ALIGN_RIGHT;

                    PdfPCell lateralcoImage = new PdfPCell(min);
                    lateralcoImage.HorizontalAlignment = Element.ALIGN_CENTER;
                    lateralcoImage.VerticalAlignment = Element.ALIGN_CENTER;
                    lateralcoImage.ExtraParagraphSpace = 1;

                    PdfPCell lateralDescrip = new PdfPCell(new Phrase(imagenModulo.Fila().Celda("descripcion").ToString(), small));
                    lateralDescrip.HorizontalAlignment = Element.ALIGN_LEFT;
                    lateralDescrip.VerticalAlignment = Element.ALIGN_LEFT;
                    lateralDerecha = true;

                    rowLateral = new PdfPRow(new PdfPCell[] { lateralcoImage, lateralDescrip });
                    tablaLateral.Rows.Add(rowLateral);
                }
            }

            //vista lateral izquierda
            Paragraph ptablaLateralIzquierda = new Paragraph();
            ptablaLateralIzquierda.SpacingBefore = 5;

            PdfPTable tablaLateralIzquierda = new PdfPTable(2);
            tablaLateralIzquierda.WidthPercentage = 100;

            int[] intTblWidthLateralIzquierda = { 35, 65 };
            tablaLateralIzquierda.SetWidths(intTblWidthLateralIzquierda);

            PdfPCell lateralIzquierdaViewHeader = new PdfPCell(new Phrase("LEFT SIDE VIEW", headers));
            lateralIzquierdaViewHeader.Colspan = tablaLateral.NumberOfColumns;
            lateralIzquierdaViewHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            lateralIzquierdaViewHeader.VerticalAlignment = Element.ALIGN_CENTER;
            lateralIzquierdaViewHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell lateralIzquierdaViewHeader2 = new PdfPCell(new Phrase("", tableHeader));

            PdfPRow rowLateralIzquierda = new PdfPRow(new PdfPCell[] { lateralIzquierdaViewHeader, lateralIzquierdaViewHeader2 });
            tablaLateralIzquierda.Rows.Add(rowLateralIzquierda);

            foreach (var item in vista)
            {
                int idImagenModulo = item;

                tablaParametros = new Dictionary<string, object>();
                tablaParametros.Add("@id", idImagenModulo);
                tablaParametros.Add("@vista", "LATERAL IZQUIERDA");
                imagenModulo.SeleccionarDatos("id=@id AND vista=@vista", tablaParametros);

                if (imagenModulo.TieneFilas())
                {
                    byte[] imagen = (byte[])imagenModulo.Fila().Celda("archivo");
                    Image min = Image.GetInstance(imagen);
                    min.ScaleToFit(80, 80);
                    min.Alignment = Image.ALIGN_RIGHT;

                    PdfPCell lateralIzquierdacoImage = new PdfPCell(min);
                    lateralIzquierdacoImage.HorizontalAlignment = Element.ALIGN_CENTER;
                    lateralIzquierdacoImage.VerticalAlignment = Element.ALIGN_CENTER;
                    lateralIzquierdacoImage.ExtraParagraphSpace = 1;

                    PdfPCell lateralIzquierdaDescrip = new PdfPCell(new Phrase(imagenModulo.Fila().Celda("descripcion").ToString(), small));
                    lateralIzquierdaDescrip.HorizontalAlignment = Element.ALIGN_LEFT;
                    lateralIzquierdaDescrip.VerticalAlignment = Element.ALIGN_LEFT;
                    lateralIzquierda = true;

                    rowLateralIzquierda = new PdfPRow(new PdfPCell[] { lateralIzquierdacoImage, lateralIzquierdaDescrip });
                    tablaLateralIzquierda.Rows.Add(rowLateralIzquierda);
                }
            }
            #endregion vistas

            #region Requerimientos

            //Requerimientos
            Paragraph requerimientosTitulo = new Paragraph(new Paragraph("MODULE REQUIREMENTS", negrita));
            requerimientosTitulo.SpacingAfter = 5;

            Paragraph ptablaRequerimiento = new Paragraph();
            ptablaRequerimiento.SpacingBefore = 5;
            PdfPTable tablaRequerimiento = new PdfPTable(2);
            tablaRequerimiento.WidthPercentage = 100;

            int[] intTblWidthRequerimiento = { 35, 65 };
            tablaRequerimiento.SetWidths(intTblWidthRequerimiento);

            PdfPCell requerimientoHeader = new PdfPCell(new Phrase("NAME", headers));
            requerimientoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            requerimientoHeader.VerticalAlignment = Element.ALIGN_CENTER;
            requerimientoHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell requerimientoHeader2 = new PdfPCell(new Phrase("DESCRIPTION", headers));
            requerimientoHeader2.HorizontalAlignment = Element.ALIGN_CENTER;
            requerimientoHeader2.VerticalAlignment = Element.ALIGN_CENTER;
            requerimientoHeader2.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell requerimientoHeader3 = new PdfPCell(new Phrase("", tableHeader));

            PdfPRow rowRequerimiento = new PdfPRow(new PdfPCell[] { requerimientoHeader, requerimientoHeader2 });
            tablaRequerimiento.Rows.Add(rowRequerimiento);

            PdfPCell requerimientosDescripcion;
            PdfPCell requerimientosNombre;

            foreach (var item in requerimiento)
            {
                int requerimientoId = item;
                Requerimiento.Modelo().CargarDatos(requerimientoId).ForEach(delegate(Fila f)
                {
                    requerimientosNombre = new PdfPCell(new Phrase(f.Celda("nombre").ToString(), small));
                    requerimientosNombre.HorizontalAlignment = Element.ALIGN_LEFT;
                    requerimientosNombre.VerticalAlignment = Element.ALIGN_LEFT;

                    requerimientosDescripcion = new PdfPCell(new Phrase(f.Celda("descripcion").ToString(), small));
                    requerimientosDescripcion.HorizontalAlignment = Element.ALIGN_LEFT;
                    requerimientosDescripcion.VerticalAlignment = Element.ALIGN_LEFT;
                    req = true;

                    rowRequerimiento = new PdfPRow(new PdfPCell[] { requerimientosNombre, requerimientosDescripcion });
                    tablaRequerimiento.Rows.Add(rowRequerimiento);
                });
            }

            #endregion

            #region Elementos

            //Elementos
            Paragraph elementoTitulo = new Paragraph(new Paragraph("MODULE ELEMENTS", negrita));
            elementoTitulo.SpacingAfter = 5;

            Paragraph ptablaElemento = new Paragraph();
            ptablaElemento.SpacingBefore = 15;

            PdfPTable tablaElemento = new PdfPTable(3);
            tablaElemento.WidthPercentage = 100;

            int[] intTblWidthElemento = { 50, 50, 50 };
            tablaElemento.SetWidths(intTblWidthElemento);

            PdfPCell ElementoHeader = new PdfPCell(new Phrase("NAME", headers));
            ElementoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            ElementoHeader.VerticalAlignment = Element.ALIGN_CENTER;
            ElementoHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell ElementoTipoHeader = new PdfPCell(new Phrase("TYPE", headers));
            ElementoTipoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            ElementoTipoHeader.VerticalAlignment = Element.ALIGN_CENTER;
            ElementoTipoHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell elementoDescripcionHeader = new PdfPCell(new Phrase("DESCRIPTION", headers));
            elementoDescripcionHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            elementoDescripcionHeader.VerticalAlignment = Element.ALIGN_CENTER;
            elementoDescripcionHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPRow rowElemento = new PdfPRow(new PdfPCell[] { ElementoHeader, ElementoTipoHeader, elementoDescripcionHeader });
            tablaElemento.Rows.Add(rowElemento);

            PdfPCell elementoDescripcion;
            PdfPCell elementoNombre;
            PdfPCell elementoTipo;

            foreach (var item in elementos)
            {
                int elementoId = item;

                Elemento.Modelo().CargarDatos(elementoId).ForEach(delegate(Fila f)
                {
                    elementoNombre = new PdfPCell(new Phrase(f.Celda("nombre").ToString(), small));
                    elementoNombre.HorizontalAlignment = Element.ALIGN_LEFT;
                    elementoNombre.VerticalAlignment = Element.ALIGN_LEFT;

                    elementoTipo = new PdfPCell(new Phrase(f.Celda("tipo").ToString(), small));
                    elementoTipo.HorizontalAlignment = Element.ALIGN_LEFT;
                    elementoTipo.VerticalAlignment = Element.ALIGN_LEFT;

                    elementoDescripcion = new PdfPCell(new Phrase(f.Celda("descripcion").ToString(), small));
                    elementoDescripcion.HorizontalAlignment = Element.ALIGN_LEFT;
                    elementoDescripcion.VerticalAlignment = Element.ALIGN_LEFT;
                    bElemento = true;

                    rowElemento = new PdfPRow(new PdfPCell[] { elementoNombre, elementoTipo, elementoDescripcion });
                    tablaElemento.Rows.Add(rowElemento);
                });
            }

            #endregion

            #region Secuencia

            //Secuencia
            Paragraph secuenciaTitulo = new Paragraph(new Paragraph("MODULE SEQUENCE", negrita));
            secuenciaTitulo.SpacingAfter = 5;

            Paragraph ptablaSecuencia = new Paragraph();
            ptablaSecuencia.SpacingBefore = 15;

            PdfPTable tablaSecuencia = new PdfPTable(3);
            tablaSecuencia.WidthPercentage = 100;

            int[] intTblWidthSecuencia = { 13, 43, 44 };
            tablaSecuencia.SetWidths(intTblWidthSecuencia);

            PdfPCell SecuenciaHeader = new PdfPCell(new Phrase("STEP #", headers));
            SecuenciaHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            SecuenciaHeader.VerticalAlignment = Element.ALIGN_CENTER;
            SecuenciaHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell secuenciaElementoHeader = new PdfPCell(new Phrase("ELEMENT", headers));
            secuenciaElementoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            secuenciaElementoHeader.VerticalAlignment = Element.ALIGN_CENTER;
            secuenciaElementoHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell secuenciaDescripcionHeader = new PdfPCell(new Phrase("ACTION", headers));
            secuenciaDescripcionHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            secuenciaDescripcionHeader.VerticalAlignment = Element.ALIGN_CENTER;
            secuenciaDescripcionHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPRow rowSecuencia = new PdfPRow(new PdfPCell[] { SecuenciaHeader, secuenciaElementoHeader, secuenciaDescripcionHeader });
            tablaSecuencia.Rows.Add(rowSecuencia);

            PdfPCell secuenciaPaso;
            PdfPCell secuenciaElemento;
            PdfPCell secuenciaAccion;

            Elemento elem = new Elemento();
            int stepCuenta = 1;

            foreach (var item in secuencia)
            {
                int secuenciaId = item;
                ModuloPaso.Modelo().CargarDatos(secuenciaId).ForEach(delegate(Fila f)
                {
                    secuenciaPaso = new PdfPCell(new Phrase(stepCuenta.ToString(), normal));
                    secuenciaPaso.HorizontalAlignment = Element.ALIGN_CENTER;
                    secuenciaPaso.VerticalAlignment = Element.ALIGN_CENTER;

                    elem.CargarDatos(Convert.ToInt32(f.Celda("elemento").ToString()));

                    if (elem.TieneFilas())
                        secuenciaElemento = new PdfPCell(new Phrase(elem.Fila().Celda("tipo").ToString(), small));
                    else
                        secuenciaElemento = new PdfPCell(new Phrase("N/A", normal));

                    secuenciaElemento.HorizontalAlignment = Element.ALIGN_LEFT;
                    secuenciaElemento.VerticalAlignment = Element.ALIGN_LEFT;

                    secuenciaAccion = new PdfPCell(new Phrase(f.Celda("accion").ToString(), small));
                    secuenciaAccion.HorizontalAlignment = Element.ALIGN_LEFT;
                    secuenciaAccion.VerticalAlignment = Element.ALIGN_LEFT;
                    bSecuencia = true;

                    rowSecuencia = new PdfPRow(new PdfPCell[] { secuenciaPaso, secuenciaElemento, secuenciaAccion });
                    tablaSecuencia.Rows.Add(rowSecuencia);
                });
                stepCuenta++;
            }

            #endregion

            #region Fallas

            //Elementos
            Paragraph fallasTitulo = new Paragraph(new Paragraph("MODULE FAILURE MODE EFFECT ANALYSIS (FMEA)", negrita));
            fallasTitulo.SpacingAfter = 5;

            Paragraph ptablaFalla = new Paragraph();
            ptablaFalla.SpacingBefore = 15;

            PdfPTable tablaFalla = new PdfPTable(4);
            tablaFalla.WidthPercentage = 100;

            int[] intTblWidthFalla = { 25, 25, 25, 25 };
            tablaFalla.SetWidths(intTblWidthFalla);

            PdfPCell FallaHeader = new PdfPCell(new Phrase("FAILURE MODE", headers));
            FallaHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            FallaHeader.VerticalAlignment = Element.ALIGN_CENTER;
            FallaHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell fallaCausasnHeader = new PdfPCell(new Phrase("CAUSES", headers));
            fallaCausasnHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            fallaCausasnHeader.VerticalAlignment = Element.ALIGN_CENTER;
            fallaCausasnHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell fallaEfectosnHeader = new PdfPCell(new Phrase("EFFECT", headers));
            fallaEfectosnHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            fallaEfectosnHeader.VerticalAlignment = Element.ALIGN_CENTER;
            fallaEfectosnHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPCell fallaControlnHeader = new PdfPCell(new Phrase("CONTROL", headers));
            fallaControlnHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            fallaControlnHeader.VerticalAlignment = Element.ALIGN_CENTER;
            fallaControlnHeader.BackgroundColor = new BaseColor(16, 5, 92);

            PdfPRow rowFalla = new PdfPRow(new PdfPCell[] { FallaHeader, fallaCausasnHeader, fallaEfectosnHeader, fallaControlnHeader });
            tablaFalla.Rows.Add(rowFalla);

            PdfPCell fallaCausa;
            PdfPCell fallaEfecto;
            PdfPCell fallaControl;
            PdfPCell fallaNombre;

            foreach (var item in fallas)
            {
                int fallaId = item;

                ModoFalla.Modelo().CargarDatos(fallaId).ForEach(delegate(Fila f)
                {
                    string srtCausa = "";
                    string strEfectos = "";
                    string strControles = "";


                    Phrase name = new Phrase(f.Celda("nombre").ToString(), smallNegrita);
                    Phrase description = new Phrase("\r\n" + f.Celda("descripcion").ToString(), small);
                    Phrase contenidoCelda = new Phrase();
                    contenidoCelda.Add(name);
                    contenidoCelda.Add(description);

                    fallaNombre = new PdfPCell(contenidoCelda);
                    fallaNombre.HorizontalAlignment = Element.ALIGN_LEFT;
                    fallaNombre.VerticalAlignment = Element.ALIGN_LEFT;

                    Dictionary<string, object> parametrosFallas = new Dictionary<string, object>();
                    parametrosFallas.Add("@falla", fallaId);

                    FallaCausa.Modelo().SeleccionarDatos("modo_falla=@falla", parametrosFallas).ForEach(delegate(Fila causa)
                    {
                        srtCausa += "\u2022 " + causa.Celda("descripcion").ToString() + "\r\n";
                    });

                    FallaEfecto.Modelo().SeleccionarDatos("modo_falla=@falla", parametrosFallas).ForEach(delegate(Fila efectos)
                    {
                        strEfectos += "\u2022 " + efectos.Celda("descripcion").ToString() + "\r\n";
                    });

                    FallaControles.Modelo().SeleccionarDatos("modo_falla=@falla", parametrosFallas).ForEach(delegate(Fila efectos)
                    {
                        strControles += "\u2022 " + efectos.Celda("descripcion").ToString() + "\r\n";
                    });

                    fallaCausa = new PdfPCell(new Phrase(srtCausa, small));
                    fallaCausa.HorizontalAlignment = Element.ALIGN_LEFT;
                    fallaCausa.VerticalAlignment = Element.ALIGN_LEFT;

                    fallaEfecto = new PdfPCell(new Phrase(strEfectos, small));
                    fallaEfecto.HorizontalAlignment = Element.ALIGN_LEFT;
                    fallaEfecto.VerticalAlignment = Element.ALIGN_LEFT;

                    fallaControl = new PdfPCell(new Phrase(strControles, small));
                    fallaControl.HorizontalAlignment = Element.ALIGN_LEFT;
                    fallaControl.VerticalAlignment = Element.ALIGN_LEFT;

                    rowFalla = new PdfPRow(new PdfPCell[] { fallaNombre, fallaCausa, fallaEfecto, fallaControl });
                    tablaFalla.Rows.Add(rowFalla);

                    bFallas = true;
                });
            }

            #endregion

            // Construye el archivo parte por parte
            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(tablaInformacion);
            doc.Add(texto);
            if (isometrico)
                doc.Add(tablaIsometrico);
            if (frontal)
                doc.Add(tablaFrontal);
            if (lateralDerecha)
                doc.Add(tablaLateral);
            if (lateralIzquierda)
                doc.Add(tablaLateralIzquierda);
            if (req)
            {
                doc.Add(requerimientosTitulo);
                doc.Add(tablaRequerimiento);
            }
            if (bElemento)
            {
                doc.Add(elementoTitulo);
                doc.Add(tablaElemento);
            }
            if (bSecuencia)
            {
                doc.Add(secuenciaTitulo);
                doc.Add(tablaSecuencia);
            }
            if (bFallas)
            {
                doc.Add(fallasTitulo);
                doc.Add(tablaFalla);
            }

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);

                }
            }

            return datosPDF;
        }

        public static byte[] ReporteSincronizacion(decimal Proyecto, string estatus, DateTime desde, DateTime hasta, bool incluirPrincipal, BackgroundWorker bkg = null)
        {
            #region Variables de DB
            Topico topico = new Topico();
            Proyecto proyecto = new Proyecto();
            List<Fila> listaTopico = new List<Fila>();
            List<Fila> listaProyectos = new List<Fila>();
            TareasTopico tarea = new TareasTopico();
            Cliente cliente = new Cliente();
            ClienteContacto contacto = new ClienteContacto();
            TareasResponsables responsable = new TareasResponsables();
            TareasSeguimiento seguimiento = new TareasSeguimiento();

            string IdProyecto = Convert.ToDecimal(Proyecto).ToString("F2");
            string proyectoPrincipal = IdProyecto.Split('.')[0] + ".00";
            string topicosQuery = "proyecto=@proyecto and date(fecha_creacion) between @desde and @hasta";
            string query = "id=@proyecto";
            string idProyectonombreReporte = IdProyecto;
            int avance = 0;
            int total = 0;

            if (incluirPrincipal)
            {
                query = "id Like '%" + Proyecto.ToString().Split('.')[0] + "%'";
                idProyectonombreReporte = proyectoPrincipal;
            }

            string proyectoNombre = "";

            proyecto.CargarDatos(Convert.ToDecimal(idProyectonombreReporte)).ForEach(delegate(Fila f)
            {
                object objProyectoNombre = f.Celda("id") + " - " + f.Celda("nombre");
                if (objProyectoNombre != null)
                    proyectoNombre += Convert.ToDecimal(f.Celda("id")).ToString("F2") + " - " + f.Celda("nombre") + Environment.NewLine;
            });
           
            if (!proyecto.TieneFilas())
                return null;

            cliente.CargarDatos(Convert.ToInt32(proyecto.Fila().Celda("cliente").ToString()));
            object clienteNombre = cliente.Fila().Celda("nombre");

            contacto.CargarDatos(Convert.ToInt32(cliente.Fila().Celda("contacto").ToString()));
            object clienteContactoNombre = contacto.Fila().Celda("nombre");
            object clienteContactoApellido = contacto.Fila().Celda("apellidos");
            string fechaDesde = Convert.ToDateTime(desde).ToString("yyyy/MM/dd");
            string fechaHasta = Convert.ToDateTime(hasta).ToString("yyyy/MM/dd"); 

            byte[] datosPDF = null;
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            #endregion

            #region Inicializar PDF

            // Definir estilos
            Font normal = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font verySmall = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font small = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font smallNegrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
            Font verySmallNegrita = FontFactory.GetFont("Calibri", 7, 1, BaseColor.BLACK);
            Font tableHeader = FontFactory.GetFont("Calibri", 9, 1, BaseColor.WHITE);
            Font tableElement = FontFactory.GetFont("Calibri", 9, BaseColor.BLACK);
            Font title = FontFactory.GetFont("Calibri", 14, 1, BaseColor.BLACK);
            Font parrafo = FontFactory.GetFont("Calibri", 12, 1, BaseColor.BLACK);
            Font link = FontFactory.GetFont("Calibri", 11, 4, BaseColor.BLUE);

            // Crea el archivo temporal
            FileStream fs = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Paragraph p = new Paragraph();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_audisel_inc_white, BaseColor.WHITE);
            logo.ScaleToFit(225, 80);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;

            // Agregar titulo
            Paragraph titulo = new Paragraph();
            titulo.Add(new Phrase("REPORTE DE SINCRONIZACION" + Environment.NewLine, title));
            titulo.Alignment = Element.ALIGN_RIGHT;

            titulo.Add(new Phrase("Proyecto: " + proyectoNombre, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;

            titulo.Add(new Phrase("Cliente: " + clienteNombre + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;

            titulo.Add(new Phrase("Contácto: " + clienteContactoNombre + " " + clienteContactoApellido + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;

            titulo.Add(new Phrase("Desde: " + Convert.ToDateTime(fechaDesde).ToString("MMM dd, yyyy") + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;

            titulo.Add(new Phrase("Hasta: " + Convert.ToDateTime(fechaHasta).ToString("MMM dd, yyyy") + Environment.NewLine, negrita));
            titulo.Alignment = Element.ALIGN_RIGHT;
            titulo.SpacingAfter = 30;

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            byte[] miniatrura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.downloadPdf_gray, typeof(byte[]));

            Image min = Image.GetInstance(miniatrura);
            min.ScaleToFit(264, 204);
            min.Alignment = Image.ALIGN_LEFT;
            min.SpacingAfter = 10;

            doc.Add(logo);
            doc.Add(titulo);

            Dictionary<string, object> parametrosProyecto = new Dictionary<string, object>();
            parametrosProyecto.Add("@proyecto", IdProyecto);
            #endregion

            listaProyectos = proyecto.SeleccionarDatos(query, parametrosProyecto);
            total += listaProyectos.Count;
            listaProyectos.ForEach(delegate(Fila f)
            {              
                //buscamos los proyectos
                Dictionary<string, object> parametrosTopicos = new Dictionary<string, object>();
                parametrosTopicos.Add("@proyecto", f.Celda("id"));
                parametrosTopicos.Add("@desde", fechaDesde);
                parametrosTopicos.Add("@hasta", fechaHasta);

                //Si no existen topicos relacionados al proyecto no agregamos la tabla
                topico.CargarTareasTopicosEnTopicos(f.Celda("id").ToString(), estatus, fechaDesde, fechaHasta);
                if (!topico.TieneFilas())
                    return;

                #region Headers tabla
                //headers
                Paragraph header = new Paragraph();
                header.Add(new Phrase("Proyecto: " + Convert.ToDecimal(f.Celda("id")).ToString("F2"), negrita));
                header.Alignment = Element.ALIGN_LEFT;
                header.SpacingBefore = 5;
                header.SpacingAfter = 2;
                doc.Add(header);

                // Partidas
                Paragraph ptablaActividad = new Paragraph();
                PdfPTable tablaActividad = new PdfPTable(6);
                tablaActividad.WidthPercentage = 100;

                int[] intTblWidth = { 15, 15, 19, 15, 25, 15 };
                tablaActividad.SetWidths(intTblWidth);

                // Header tópico
                PdfPCell headerTopico = new PdfPCell(new Phrase("TOPICO", tableHeader));
                headerTopico.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTopico.VerticalAlignment = Element.ALIGN_CENTER;
                headerTopico.BackgroundColor = new BaseColor(16, 5, 92);

                // Header tareas
                PdfPCell headerTareas = new PdfPCell(new Phrase("TAREA(S)", tableHeader));
                headerTareas.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTareas.VerticalAlignment = Element.ALIGN_CENTER;
                headerTareas.BackgroundColor = new BaseColor(16, 5, 92);

                // Header responsables
                PdfPCell headerResponsable = new PdfPCell(new Phrase("RESPONSABLE(S)", tableHeader));
                headerResponsable.HorizontalAlignment = Element.ALIGN_CENTER;
                headerResponsable.VerticalAlignment = Element.ALIGN_CENTER;
                headerResponsable.BackgroundColor = new BaseColor(16, 5, 92);

                // Header estatus
                PdfPCell headerEstatus = new PdfPCell(new Phrase("ESTATUS", tableHeader));
                headerEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
                headerEstatus.VerticalAlignment = Element.ALIGN_CENTER;
                headerEstatus.BackgroundColor = new BaseColor(16, 5, 92);

                // Header del proceso actual
                PdfPCell headerSeguimiento = new PdfPCell(new Phrase("SEGUIMIENTO", tableHeader));
                headerSeguimiento.HorizontalAlignment = Element.ALIGN_CENTER;
                headerSeguimiento.VerticalAlignment = Element.ALIGN_CENTER;
                headerSeguimiento.BackgroundColor = new BaseColor(16, 5, 92);

                // Header del proceso actual
                PdfPCell headerFechaPromesa = new PdfPCell(new Phrase("FECHA PROMESA", tableHeader));
                headerFechaPromesa.HorizontalAlignment = Element.ALIGN_CENTER;
                headerFechaPromesa.VerticalAlignment = Element.ALIGN_CENTER;
                headerFechaPromesa.BackgroundColor = new BaseColor(16, 5, 92);

               
                PdfPRow row = new PdfPRow(new PdfPCell[] { headerTopico, headerTareas, headerResponsable, headerEstatus, headerSeguimiento, headerFechaPromesa });
                tablaActividad.Rows.Add(row);
                #endregion

                listaTopico = topico.SeleccionarDatos(topicosQuery, parametrosTopicos);
                total += listaTopico.Count;
                listaTopico.ForEach(delegate(Fila filaTopico)
                {
                    List<Fila> tareas = tarea.SeleccionarRangoFecha(estatus, fechaDesde, fechaHasta, filaTopico.Celda("id").ToString());
                    if (tareas.Count <= 0)
                        return;

                    PdfPCell celdaPrincipalConRowSpan = new PdfPCell(new Phrase(filaTopico.Celda("descripcion").ToString(), verySmall));
                    celdaPrincipalConRowSpan.Rowspan = tareas.Count;
                    celdaPrincipalConRowSpan.HorizontalAlignment = Element.ALIGN_CENTER;
                    celdaPrincipalConRowSpan.VerticalAlignment = Element.ALIGN_CENTER;
                    tablaActividad.AddCell(celdaPrincipalConRowSpan);

                    total += tareas.Count;
                    tareas.ForEach(delegate(Fila filaTareas)
                    {
                        //se agrega la celda de tareas
                        PdfPCell cellTareas = new PdfPCell(new Phrase(filaTareas.Celda("nombre").ToString(), verySmall));
                        cellTareas.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellTareas.HorizontalAlignment = Element.ALIGN_CENTER;
                        tablaActividad.AddCell(cellTareas);

                        //celda de responsables de a cuerdo con el id de la tarea
                        Dictionary<string, object> parametrosmetrosResponsable = new Dictionary<string, object>();
                        parametrosmetrosResponsable.Add("@tarea", filaTareas.Celda("id").ToString());
                        string responsables = "";

                        responsable.SeleccionarDatos("tarea=@tarea", parametrosmetrosResponsable).ForEach(delegate(Fila nombreResponsable)
                        {
                            responsables += nombreResponsable.Celda("responsable").ToString() + Environment.NewLine;
                        });

                        responsables = responsables.TrimEnd(Environment.NewLine.ToCharArray());
                        PdfPCell cellResponsables = new PdfPCell(new Phrase(responsables, verySmall));
                        cellResponsables.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellResponsables.HorizontalAlignment = Element.ALIGN_CENTER;
                        tablaActividad.AddCell(cellResponsables);

                        string strestatus = "";
                        object objEstatus = filaTareas.Celda("estatus");

                        if (objEstatus != null)
                            strestatus = filaTareas.Celda("estatus").ToString();

                        //se agrega la celda de estatus de la actividad
                        PdfPCell cellEstatus = new PdfPCell(new Phrase(strestatus, verySmall));
                        cellEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
                        tablaActividad.AddCell(cellEstatus);

                        //se agrega la celda del ultimo seguimiento de la tarea
                        Dictionary<string, object> parametrosSeguimiento = new Dictionary<string, object>();
                        parametrosSeguimiento.Add("@tarea", filaTareas.Celda("id").ToString());
                        string comentarioSeguimiento = "";

                        seguimiento.SeleccionarDatos("tarea=@tarea order by id desc limit 1", parametrosSeguimiento).ForEach(delegate(Fila nombreSeguimiento)
                        {
                            comentarioSeguimiento = nombreSeguimiento.Celda("comentario").ToString();
                        });

                        PdfPCell cellSeguimiento = new PdfPCell(new Phrase(comentarioSeguimiento, verySmall));
                        cellSeguimiento.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellSeguimiento.HorizontalAlignment = Element.ALIGN_CENTER;
                        tablaActividad.AddCell(cellSeguimiento);

                        string strFechaPromesa = "";
                        object objFechaPromesa = filaTareas.Celda("fecha_promesa");
                        if (objFechaPromesa != null)
                            strFechaPromesa = filaTareas.Celda("fecha_promesa").ToString();
                        //se agrega la celda fecha promesa
                        PdfPCell cellFechaPromesa = new PdfPCell(new Phrase(Convert.ToDateTime(strFechaPromesa).ToString("MMM dd, yyyy"), verySmall));
                        cellFechaPromesa.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellFechaPromesa.HorizontalAlignment = Element.ALIGN_CENTER;
                        tablaActividad.AddCell(cellFechaPromesa);
                        avance++;
                        bkg.ReportProgress(Global.CalcularPorcentaje(avance, total));
                    });
                    avance++;
                    bkg.ReportProgress(Global.CalcularPorcentaje(avance, total));
                });
                avance++;
                ptablaActividad.Add(tablaActividad);              
                doc.Add(ptablaActividad);
                Thread.Sleep(1200);

                bkg.ReportProgress(Global.CalcularPorcentaje(avance, total));
                
            });
            
            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] PerfilPuesto(Fila PerfilDelPuesto,List<Fila> Subordinados, List<Fila> Habilidades)
        {
            #region inicializar PDF

            byte[] datosPDF;

            #region Fuentes
            Font small = FontFactory.GetFont("Calibri", 7, BaseColor.BLACK);
            Font normal = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negritasBlanca = FontFactory.GetFont("Calibri", 8, 1, BaseColor.WHITE);

            #endregion

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            string strHeaderNivel = string.Empty;
            if (Convert.ToInt32(PerfilDelPuesto.Celda("nivel")) > 0)
                strHeaderNivel += PerfilDelPuesto.Celda("nivel").ToString();

            writer.PageEvent = new MyHeaderFooterEvent() { headerTexto = "PERFIL DE PUESTO | " + PerfilDelPuesto.Celda("rol").ToString() + " " + strHeaderNivel + @"\" + Convert.ToDateTime(PerfilDelPuesto.Celda("ultima_modificacion")).ToString("MMMM dd, yyyy")};
            
            doc.Open();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            //logo.ScaleToFit(162, 54);
            logo.ScaleToFit(164, 76);
            logo.SpacingAfter = 10;
            logo.SpacingBefore = 10;
            #endregion

            //Nested table para la información general del formato

            PdfPCell cell = new PdfPCell();

            PdfPTable table2 = new PdfPTable(2);
            cell = new PdfPCell(new Phrase("PERFIL DE PUESTO", negrita));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.Colspan = 2;
            table2.AddCell(cell);

            //Nombre del puesto
            table2.DefaultCell.MinimumHeight = 10;
            table2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table2.AddCell(new Phrase("NOMBRE DEL PUESTO", negrita));
            table2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            int intNivelPuesto = Convert.ToInt32(PerfilDelPuesto.Celda("nivel").ToString());
            table2.AddCell(new Phrase(PerfilDelPuesto.Celda("rol").ToString().ToUpper(), normal));
            
            //departamento
            table2.DefaultCell.MinimumHeight = 10;
            table2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table2.DefaultCell.BackgroundColor = BaseColor.WHITE;
            table2.AddCell(new Phrase("DEPARTAMENTO",negrita));
            table2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            table2.AddCell(new Phrase(PerfilDelPuesto.Celda("departamento").ToString().ToUpper(), normal));

            //Nivel
            table2.DefaultCell.MinimumHeight = 10;
            table2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table2.DefaultCell.BackgroundColor = BaseColor.WHITE;
            table2.AddCell(new Phrase("NIVEL", negrita));          
            int nivelPuesto = Convert.ToInt32(PerfilDelPuesto.Celda("nivel").ToString());
            string strNivel = "";

            if (nivelPuesto == 1)
            {
                strNivel = nivelPuesto.ToString();
                table2.DefaultCell.BackgroundColor = BaseColor.WHITE;
                table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.AddCell(new Phrase(strNivel, negrita));
            }
            else if (nivelPuesto == 2)
            {
                strNivel = nivelPuesto.ToString();
                table2.DefaultCell.BackgroundColor = BaseColor.GRAY;
                table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.AddCell(new Phrase(strNivel, negrita));
            }
            else if (nivelPuesto == 3)
            {
                strNivel = nivelPuesto.ToString();
                table2.DefaultCell.BackgroundColor = BaseColor.BLACK;
                table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.AddCell(new Phrase(strNivel, negritasBlanca));               
            }
            else if (nivelPuesto == 0)
            {
                strNivel = "N/A";
                table2.DefaultCell.BackgroundColor = BaseColor.WHITE;
                table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.AddCell(new Phrase(strNivel, negrita));               
            }

            //tabla principal

            //crear espacio de la tabla
            Paragraph ptablaPrincipalPerfilUsuario = new Paragraph();
            ptablaPrincipalPerfilUsuario.SpacingBefore = 5;

            //inicializar tabla
            PdfPTable tablaPerfilUsuario = new PdfPTable(4);
            tablaPerfilUsuario.WidthPercentage = 100;
            tablaPerfilUsuario.SpacingBefore = 5;

            int[] intTblWidthIsometrico = { 30, 30, 30, 30 };
            tablaPerfilUsuario.SetWidths(intTblWidthIsometrico);

            PdfPCell columna1 = new PdfPCell();
            PdfPCell columna2 = new PdfPCell();
            PdfPCell columna3 = new PdfPCell();
            PdfPCell columna4 = new PdfPCell();

            PdfPRow rowInformacionGeneral = new PdfPRow(new PdfPCell[] { columna1, columna2, columna3, columna4 });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            //renglones

            PdfPCell perfilLogo;
            PdfPCell TablaContenidoGeneral;
            PdfPCell FilaCoordinacionCon;
            PdfPCell FilaCordinaConRespuesta;
            PdfPCell FilaCoordinaA;
            PdfPCell FilaCoordinaARespuesta;
            PdfPCell DescripcionPrincipal;
            PdfPCell ActividadesPrincipales;
            PdfPCell ActividadesAdicionales;
            PdfPCell Responsables;
            PdfPCell headerDescripcionPrincipal;
            PdfPCell headerActividadesPrincipales;
            PdfPCell headerActividadesAdicionales;
            PdfPCell headerResponsables;
            PdfPCell headerHabilidadesPersonales;
            PdfPCell headerHabilidadesTecnicas;
            PdfPCell habilidadesPersonales;
            PdfPCell habilidadesTecnicas;
            PdfPCell headerRecursosRequeridos;
            PdfPCell recursosRequeridos;
            PdfPCell headerExperiencia;
            PdfPCell headerNivelAcademico;
            PdfPCell experiencia;
            PdfPCell nivelAcademico;
            PdfPCell headerFlexibilidadHorario;
            PdfPCell flexibilidadHorario;

            perfilLogo = new PdfPCell(logo);
            perfilLogo.HorizontalAlignment = Element.ALIGN_CENTER;
            perfilLogo.VerticalAlignment = Element.ALIGN_CENTER;
            perfilLogo.ExtraParagraphSpace = 1;
            perfilLogo.Colspan = 2;

            TablaContenidoGeneral = new PdfPCell(new PdfPCell(table2));
            TablaContenidoGeneral.HorizontalAlignment = Element.ALIGN_LEFT;
            TablaContenidoGeneral.VerticalAlignment = Element.ALIGN_LEFT;
            TablaContenidoGeneral.Colspan = 2;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { perfilLogo, null,TablaContenidoGeneral, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            FilaCoordinacionCon = new PdfPCell(new Phrase("SE COORDINA CON", negrita));
            FilaCoordinacionCon.HorizontalAlignment = Element.ALIGN_RIGHT;
            FilaCoordinacionCon.VerticalAlignment = Element.ALIGN_CENTER;
            FilaCoordinacionCon.ExtraParagraphSpace = 1;

            object objcoordenador = PerfilDelPuesto.Celda("coordinador");
            string coordinador = "";
            if (objcoordenador != null)
                coordinador = objcoordenador.ToString();

            FilaCordinaConRespuesta = new PdfPCell(new Phrase(coordinador, small));
            FilaCordinaConRespuesta.HorizontalAlignment = Element.ALIGN_LEFT;
            FilaCordinaConRespuesta.VerticalAlignment = Element.ALIGN_CENTER;
            FilaCordinaConRespuesta.ExtraParagraphSpace = 1;

            FilaCoordinaA = new PdfPCell(new Phrase("COORDINA A", negrita));
            FilaCoordinaA.HorizontalAlignment = Element.ALIGN_RIGHT;
            FilaCoordinaA.VerticalAlignment = Element.ALIGN_CENTER;
            FilaCoordinaA.ExtraParagraphSpace = 1;

            string coordinaA = string.Empty;
            Subordinados.ForEach(delegate(Fila f)
            {
                coordinaA += "• " + f.Celda("rol").ToString();

                if (Convert.ToInt32(f.Celda("nivel")) > 0)
                    coordinaA += " " + f.Celda("nivel").ToString();

                coordinaA += Environment.NewLine;
            });
            if (coordinaA == string.Empty)
                coordinaA = "NADIE";

            coordinaA = coordinaA.TrimEnd();

            FilaCoordinaARespuesta = new PdfPCell(new Phrase(coordinaA, small));
            FilaCoordinaARespuesta.HorizontalAlignment = Element.ALIGN_LEFT;
            FilaCoordinaARespuesta.VerticalAlignment = Element.ALIGN_LEFT;
            FilaCoordinaARespuesta.ExtraParagraphSpace = 1;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { FilaCoordinacionCon, FilaCordinaConRespuesta, FilaCoordinaA, FilaCoordinaARespuesta });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerDescripcionPrincipal = new PdfPCell(new Phrase("DESCRIPCION GENERAL", negritasBlanca));
            headerDescripcionPrincipal.HorizontalAlignment = Element.ALIGN_CENTER;
            headerDescripcionPrincipal.VerticalAlignment = Element.ALIGN_CENTER;
            headerDescripcionPrincipal.ExtraParagraphSpace = 1;
            headerDescripcionPrincipal.BackgroundColor = new BaseColor(16, 5, 92);
            headerDescripcionPrincipal.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerDescripcionPrincipal, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            object objGeneral = PerfilDelPuesto.Celda("descripcion");
            string general = "";
            if (objGeneral != null)
                general = objGeneral.ToString();

            DescripcionPrincipal = new PdfPCell(new Phrase(general, small));
            DescripcionPrincipal.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            DescripcionPrincipal.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            DescripcionPrincipal.ExtraParagraphSpace = 1;
            DescripcionPrincipal.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { DescripcionPrincipal, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerActividadesPrincipales = new PdfPCell(new Phrase("ACTIVIDADES PRINCIPALES", negritasBlanca));
            headerActividadesPrincipales.HorizontalAlignment = Element.ALIGN_CENTER;
            headerActividadesPrincipales.VerticalAlignment = Element.ALIGN_CENTER;
            headerActividadesPrincipales.ExtraParagraphSpace = 1;
            headerActividadesPrincipales.BackgroundColor = new BaseColor(16, 5, 92);
            headerActividadesPrincipales.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerActividadesPrincipales, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            object objPrincipal = PerfilDelPuesto.Celda("actividades_principales");
            string principal = "";
            if (objPrincipal != null)
                principal = objPrincipal.ToString();

            ActividadesPrincipales = new PdfPCell(new Phrase(principal, small));
            ActividadesPrincipales.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            ActividadesPrincipales.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            ActividadesPrincipales.ExtraParagraphSpace = 1;
            ActividadesPrincipales.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { ActividadesPrincipales, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerActividadesAdicionales = new PdfPCell(new Phrase("ACTIVIDADES ADICIONALES", negritasBlanca));
            headerActividadesAdicionales.HorizontalAlignment = Element.ALIGN_CENTER;
            headerActividadesAdicionales.VerticalAlignment = Element.ALIGN_CENTER;
            headerActividadesAdicionales.ExtraParagraphSpace = 1;
            headerActividadesAdicionales.BackgroundColor = new BaseColor(16, 5, 92);
            headerActividadesAdicionales.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerActividadesAdicionales, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            object objAdicional = PerfilDelPuesto.Celda("actividades_adicionales");
            string adicional = "";
            if (objAdicional != null)
                adicional = objAdicional.ToString();

            ActividadesAdicionales = new PdfPCell(new Phrase(adicional, small));
            ActividadesAdicionales.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            ActividadesAdicionales.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            ActividadesAdicionales.ExtraParagraphSpace = 1;
            ActividadesAdicionales.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { ActividadesAdicionales, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerResponsables = new PdfPCell(new Phrase("RESPONSABILIDADES", negritasBlanca));
            headerResponsables.HorizontalAlignment = Element.ALIGN_CENTER;
            headerResponsables.VerticalAlignment = Element.ALIGN_CENTER;
            headerResponsables.ExtraParagraphSpace = 1;
            headerResponsables.BackgroundColor = new BaseColor(16, 5, 92);
            headerResponsables.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerResponsables, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            object objResponsabilidades = PerfilDelPuesto.Celda("responsabilidades");
            string responsabilidades = "";
            if (objResponsabilidades != null)
                responsabilidades = objResponsabilidades.ToString();

            Responsables = new PdfPCell(new Phrase(responsabilidades, small));
            Responsables.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            Responsables.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            Responsables.ExtraParagraphSpace = 1;
            Responsables.Colspan = 4;
           
            rowInformacionGeneral = new PdfPRow(new PdfPCell[] {Responsables, null,null,null});
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerHabilidadesPersonales = new PdfPCell(new Phrase("COMPETENCIAS PERSONALES", negritasBlanca));
            headerHabilidadesPersonales.HorizontalAlignment = Element.ALIGN_CENTER;
            headerHabilidadesPersonales.VerticalAlignment = Element.ALIGN_CENTER;
            headerHabilidadesPersonales.ExtraParagraphSpace = 1;
            headerHabilidadesPersonales.Colspan = 2;
            headerHabilidadesPersonales.BackgroundColor = new BaseColor(16, 5, 92);

            headerHabilidadesTecnicas = new PdfPCell(new Phrase("COMPETENCIAS TECNICAS", negritasBlanca));
            headerHabilidadesTecnicas.HorizontalAlignment = Element.ALIGN_CENTER;
            headerHabilidadesTecnicas.VerticalAlignment = Element.ALIGN_CENTER;
            headerHabilidadesTecnicas.ExtraParagraphSpace = 1;
            headerHabilidadesTecnicas.Colspan = 2;
            headerHabilidadesTecnicas.BackgroundColor = new BaseColor(16, 5, 92);

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerHabilidadesPersonales, null, headerHabilidadesTecnicas, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            string strHabilidadesPersonales = "";
            string strHabilidadesTecnicas = "";

            Habilidades.ForEach(delegate(Fila f)
            {
                if(f.Celda("tipo").ToString() == "PERSONAL")
                    strHabilidadesPersonales += "• " + f.Celda("habilidad").ToString() + Environment.NewLine;
                else if(f.Celda("tipo").ToString() == "TECNICA")
                    strHabilidadesTecnicas += "• " + f.Celda("habilidad").ToString() + Environment.NewLine;
            });

            habilidadesPersonales = new PdfPCell(new Phrase(strHabilidadesPersonales, small));
            habilidadesPersonales.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            habilidadesPersonales.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            habilidadesPersonales.ExtraParagraphSpace = 1;
            habilidadesPersonales.Colspan = 2;

            habilidadesTecnicas = new PdfPCell(new Phrase(strHabilidadesTecnicas, small));
            habilidadesTecnicas.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            habilidadesTecnicas.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            habilidadesTecnicas.ExtraParagraphSpace = 1;
            habilidadesTecnicas.Colspan = 2;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { habilidadesPersonales, null, habilidadesTecnicas, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerRecursosRequeridos = new PdfPCell(new Phrase("PRINCIPALES RESCURSOS REQUERIDOS", negritasBlanca));
            headerRecursosRequeridos.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRecursosRequeridos.VerticalAlignment = Element.ALIGN_CENTER;
            headerRecursosRequeridos.ExtraParagraphSpace = 1;
            headerRecursosRequeridos.Colspan = 4;
            headerRecursosRequeridos.BackgroundColor = new BaseColor(16, 5, 92);

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerRecursosRequeridos, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            object objRecursosRequeridos = PerfilDelPuesto.Celda("recursos_requeridos");
            string strRecursosRequeridos = "";
            if (objRecursosRequeridos != null)
                strRecursosRequeridos = objRecursosRequeridos.ToString();

            recursosRequeridos = new PdfPCell(new Phrase(strRecursosRequeridos, small));
            recursosRequeridos.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            recursosRequeridos.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            recursosRequeridos.Colspan = 4;
            recursosRequeridos.ExtraParagraphSpace = 1;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { recursosRequeridos, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerExperiencia = new PdfPCell(new Phrase("EXPERIENCIA", negritasBlanca));
            headerExperiencia.HorizontalAlignment = Element.ALIGN_CENTER;
            headerExperiencia.VerticalAlignment = Element.ALIGN_CENTER;
            headerExperiencia.ExtraParagraphSpace = 1;
            headerExperiencia.Colspan = 2;
            headerExperiencia.BackgroundColor = new BaseColor(16, 5, 92);

            headerNivelAcademico = new PdfPCell(new Phrase("NIVEL ACADEMICO", negritasBlanca));
            headerNivelAcademico.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNivelAcademico.VerticalAlignment = Element.ALIGN_CENTER;
            headerNivelAcademico.ExtraParagraphSpace = 1;
            headerNivelAcademico.Colspan = 2;
            headerNivelAcademico.BackgroundColor = new BaseColor(16, 5, 92);

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerExperiencia, null, headerNivelAcademico, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            object objExperiencia = PerfilDelPuesto.Celda("experiencia");
            string strExperiencia = "";
            if (objExperiencia != null)
                strExperiencia = objExperiencia.ToString();

            object objNivelAcademico = PerfilDelPuesto.Celda("nivel_academico");
            string strNivelAcademico = "";
            if (objNivelAcademico != null)
                strNivelAcademico = objNivelAcademico.ToString();

            experiencia = new PdfPCell(new Phrase(strExperiencia,small));
            experiencia.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            experiencia.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            experiencia.ExtraParagraphSpace = 1;
            experiencia.Colspan = 2;

            nivelAcademico = new PdfPCell(new Phrase(strNivelAcademico, small));
            nivelAcademico.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            nivelAcademico.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            nivelAcademico.ExtraParagraphSpace = 1;
            nivelAcademico.Colspan = 2;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { experiencia, null, nivelAcademico, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerFlexibilidadHorario = new PdfPCell(new Phrase("FLEXIBILIDAD DE HORARIO", negritasBlanca));
            headerFlexibilidadHorario.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFlexibilidadHorario.VerticalAlignment = Element.ALIGN_CENTER;
            headerFlexibilidadHorario.ExtraParagraphSpace = 1;
            headerFlexibilidadHorario.Colspan = 4;
            headerFlexibilidadHorario.BackgroundColor = new BaseColor(16, 5, 92);

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerFlexibilidadHorario, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            object objTiempoCompleto = PerfilDelPuesto.Celda("tiempo_completo");
            string tiempoCompleto = "NO REQUIERE TIEMPO COMPLETO";
            if (objTiempoCompleto != null)
            {
                if (Convert.ToInt32(objTiempoCompleto) > 0)
                    tiempoCompleto = "TIEMPO COMPLETO"; ;
            }

            object objDisponibilidadViaje = PerfilDelPuesto.Celda("disponibilidad_viajar");
            string disponibilidadViaje = "NO REQUIERE DISPONIBILIDAD PARA VIAJAR";
            if (objDisponibilidadViaje != null)
            {
                if(Convert.ToInt32(objDisponibilidadViaje) > 0)
                    disponibilidadViaje = "DISPONIBILIDAD PARA VIAJAR OCASIONALMENTE A LAS INSTALACIONES DEL CLIENTE A NIVEL NACIONAL O INTERNACIONAL"; ;
            }

            flexibilidadHorario = new PdfPCell(new Phrase(tiempoCompleto + Environment.NewLine + disponibilidadViaje.CapitalizeFirst(), small));
            flexibilidadHorario.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            flexibilidadHorario.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            flexibilidadHorario.ExtraParagraphSpace = 1;
            flexibilidadHorario.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { flexibilidadHorario, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            Paragraph lineaFirma = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            lineaFirma.SpacingBefore = 30;

            Paragraph firma = new Paragraph("Nombre y firma del empleado", negrita);
            firma.Alignment = Element.ALIGN_CENTER;




            ptablaPrincipalPerfilUsuario.Add(tablaPerfilUsuario);
            doc.Add(ptablaPrincipalPerfilUsuario);
            doc.Add(lineaFirma);
            doc.Add(firma);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] ReporteDeValidacionDiseno(byte[] imagenVistaBytes, decimal IdProyecto, List<string> Usuarios, string documentoIdentificador, string descripcion, string comentarios, bool boolParcial = false, int modulo=0)
        {
            Proyecto proyectoTbl = new Proyecto();
            Modulo modulosTbl = new Modulo();
            Cliente clienteTbl = new Cliente();
            //string IdProyectoIdModulo = IdProyecto.ToString().Split('.')[0] + "." + modulo;
            proyectoTbl.CargarDatos(IdProyecto);
            clienteTbl.CargarDatos(Convert.ToInt32(proyectoTbl.Fila().Celda("cliente")));
            
            #region inicializar PDF

            byte[] datosPDF;

            #region Fuentes
            Font tituloH1 = FontFactory.GetFont("Calibri", 12, 1, BaseColor.BLACK);
            Font tituloH2 = FontFactory.GetFont("Calibri", 10, 1, BaseColor.BLACK);
            Font normal = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negritasBlanca = FontFactory.GetFont("Calibri", 8, 1, BaseColor.WHITE);

            #endregion

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            //writer.PageEvent = new MyHeaderFooterEvent() { headerTexto = "PERFIL DE PUESTO | LALA ST"};

            doc.Open();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(144, 56);
            logo.SpacingAfter = 10;
            logo.SpacingBefore = 5;

            Image imagenVista;
            if (imagenVistaBytes == null)
                imagenVista = Image.GetInstance(CB_Base.Properties.Resources.image_not_found, BaseColor.WHITE);

            else
            {
               
                imagenVista =Image.GetInstance(imagenVistaBytes);
            }

          //  imagenVista.ScaleToFit(144, 56);
            imagenVista.SpacingAfter = 10;
            imagenVista.ScaleToFit(490, 430);
            imagenVista.SpacingBefore = 10;
            
            #endregion

            //Nested table para la información general del formato
            #region NestedTable
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            int[] intRow = { 7, 7, 7, 7 };
            table.SetWidths(intRow);

            PdfPCell left = new PdfPCell(new Paragraph(documentoIdentificador, tituloH2));
            left.HorizontalAlignment = Element.ALIGN_CENTER;
            left.VerticalAlignment = Element.ALIGN_MIDDLE;
            left.Colspan = 4;
            table.AddCell(left);

            PdfPCell iso = new PdfPCell(new Paragraph("DME-FO-800", negrita));
            iso.Colspan = 4;
            iso.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(iso);

            PdfPCell middle = new PdfPCell(new Paragraph("TIPO DE VALIDACION:", negrita));
            middle.Colspan = 4;
            middle.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(middle);

            PdfPCell total = new PdfPCell(new Paragraph("TOTAL", negrita));
            table.AddCell(total);

            string marcarTotal = "";
            string marcarParcial = "";
            string strModulosLiberados = "";

            if (boolParcial)
            {
                marcarParcial = "X";
                strModulosLiberados = modulo.ToString().PadLeft(2,'0');
            }
            else
            {
                marcarTotal = "X";
                modulosTbl.SeleccionarModulos(IdProyecto).ForEach(delegate(Fila f)
                {
                    strModulosLiberados += f.Celda("subensamble").ToString().PadLeft(2, '0') + ", ";
                });
                strModulosLiberados = strModulosLiberados.TrimEnd().TrimEnd(',');
            }

            PdfPCell totalResultado = new PdfPCell(new Paragraph(marcarTotal, negrita));
            table.AddCell(totalResultado);

            PdfPCell parcial = new PdfPCell(new Paragraph("PARCIAL", negrita));
            table.AddCell(parcial);

            PdfPCell parcialResultado = new PdfPCell(new Paragraph(marcarParcial, negrita));
            table.AddCell(parcialResultado);
            #endregion

            //TABLA PRINCIPAL
            #region Tabla principal
            //crear espacio de la tabla
            Paragraph ptablaPrincipalPerfilUsuario = new Paragraph();
            ptablaPrincipalPerfilUsuario.SpacingBefore = 5;

            //inicializar tabla
            PdfPTable tablaPerfilUsuario = new PdfPTable(4);
            tablaPerfilUsuario.WidthPercentage = 100;
            tablaPerfilUsuario.SpacingBefore = 5;

            int[] intTblWidthIsometrico = { 28, 28, 18, 18 };
            tablaPerfilUsuario.SetWidths(intTblWidthIsometrico);

            PdfPCell columna1 = new PdfPCell();
            PdfPCell columna2 = new PdfPCell();
            PdfPCell columna3 = new PdfPCell();
            PdfPCell columna4 = new PdfPCell();


            PdfPRow rowInformacionGeneral = new PdfPRow(new PdfPCell[] { columna1, columna2, columna3, columna4 });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            #endregion

            //Declaración de celdas
            #region Celdas
            PdfPCell perfilLogo;
            PdfPCell TablaMezclada;
            PdfPCell titulo;
            PdfPCell proyectos;
            PdfPCell modulos;
            PdfPCell proyectoResultado;
            PdfPCell modulosResultado;
            PdfPCell cliente;
            PdfPCell clienteResultado;
            PdfPCell fecha;
            PdfPCell fechaResultado;
            PdfPCell descripcionCelda;
            PdfPCell headerImagen;
            PdfPCell imagen;
            PdfPCell headerNombresFirmas;
            PdfPCell headerComentarios;
            PdfPCell headerFirmaDisenadoMecanico;
            PdfPCell headerFirmaLiderMecanico;
            PdfPCell headerFirmaLiderProyecto;
            PdfPCell headerFirmaContacto;
            PdfPCell firmaDisenadoMecanico;
            PdfPCell firmaLiderMecanico;
            PdfPCell firmaLiderProyecto;
            PdfPCell firmaContacto;
            PdfPCell nombreDisenadoMecanico;
            PdfPCell nombreLiderMecanico;
            PdfPCell nombreLiderProyecto;
            PdfPCell nombreContacto;
            PdfPCell comentariosCelda;

            #endregion

            #region Contenido de celdas

            perfilLogo = new PdfPCell(logo);
            perfilLogo.HorizontalAlignment = Element.ALIGN_CENTER;
            perfilLogo.VerticalAlignment = Element.ALIGN_CENTER;
            perfilLogo.ExtraParagraphSpace = 1;

            titulo = new PdfPCell(new Phrase("VALIDACION DE DISEÑO MECANICO", tituloH1));
            titulo.HorizontalAlignment = Element.ALIGN_CENTER;
            titulo.VerticalAlignment = Element.ALIGN_MIDDLE;

            TablaMezclada = new PdfPCell(new PdfPCell(table));
            TablaMezclada.HorizontalAlignment = Element.ALIGN_LEFT;
            TablaMezclada.VerticalAlignment = Element.ALIGN_LEFT;
            TablaMezclada.Colspan = 2;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { perfilLogo, titulo, TablaMezclada, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            proyectos = new PdfPCell(new Phrase("PROYECTO", negrita));
            proyectos.HorizontalAlignment = Element.ALIGN_RIGHT;
            proyectos.VerticalAlignment = Element.ALIGN_RIGHT;

            string[] spProyecto = IdProyecto.ToString().Split('.');
            string strProyecto = "";
            object nombreProyecto = proyectoTbl.Fila().Celda("nombre");
            if (nombreProyecto != null)
                strProyecto = nombreProyecto.ToString();

            proyectoResultado = new PdfPCell(new Phrase(IdProyecto + " - " + strProyecto, negrita));
            proyectoResultado.HorizontalAlignment = Element.ALIGN_LEFT;
            proyectoResultado.VerticalAlignment = Element.ALIGN_LEFT;

            cliente = new PdfPCell(new Phrase("CLIENTE", negrita));
            cliente.HorizontalAlignment = Element.ALIGN_RIGHT;
            cliente.VerticalAlignment = Element.ALIGN_RIGHT;

            string strClienteResultado = "";
            object objCliente = clienteTbl.Fila().Celda("nombre");
            if (objCliente != null)
                strClienteResultado = objCliente.ToString();
            

            clienteResultado = new PdfPCell(new Phrase(strClienteResultado, negrita));
            clienteResultado.HorizontalAlignment = Element.ALIGN_LEFT;
            clienteResultado.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { proyectos, proyectoResultado, cliente, clienteResultado });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            modulos = new PdfPCell(new Phrase("MODULO(S) VALIDADO(S)", negrita));
            modulos.HorizontalAlignment = Element.ALIGN_RIGHT;
            modulos.VerticalAlignment = Element.ALIGN_RIGHT;

            modulosResultado = new PdfPCell(new Phrase(strModulosLiberados, negrita));
            modulosResultado.HorizontalAlignment = Element.ALIGN_LEFT;
            modulosResultado.VerticalAlignment = Element.ALIGN_LEFT;

            fecha = new PdfPCell(new Phrase("FECHA", negrita));
            fecha.HorizontalAlignment = Element.ALIGN_RIGHT;
            fecha.VerticalAlignment = Element.ALIGN_RIGHT;

            fechaResultado = new PdfPCell(new Phrase(Global.FechaATexto(DateTime.Now).ToUpper(), negrita));
            fechaResultado.HorizontalAlignment = Element.ALIGN_LEFT;
            fechaResultado.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { modulos, modulosResultado, fecha, fechaResultado });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            descripcionCelda = new PdfPCell(new Phrase(descripcion, normal));
            descripcionCelda.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.Colspan = 4;
            

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { descripcionCelda, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerImagen = new PdfPCell(new Phrase("IMAGEN DE REFERENCIA DEL DISEÑO VALIDADO", negritasBlanca));
            headerImagen.HorizontalAlignment = Element.ALIGN_CENTER;
            headerImagen.VerticalAlignment = Element.ALIGN_CENTER;
            headerImagen.BackgroundColor = new BaseColor(16, 5, 92);
            headerImagen.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerImagen, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            imagen = new PdfPCell(imagenVista);
            imagen.HorizontalAlignment = Element.ALIGN_CENTER;
            imagen.VerticalAlignment = Element.ALIGN_CENTER;
            imagen.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { imagen, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerComentarios = new PdfPCell(new Phrase("COMENTARIOS", negritasBlanca));
            headerComentarios.HorizontalAlignment = Element.ALIGN_CENTER;
            headerComentarios.VerticalAlignment = Element.ALIGN_CENTER;
            headerComentarios.BackgroundColor = new BaseColor(16, 5, 92);
            headerComentarios.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerComentarios, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            if (comentarios == "")
                comentarios = "N/A";

            comentariosCelda = new PdfPCell(new Phrase(comentarios, normal));
            comentariosCelda.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            comentariosCelda.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            comentariosCelda.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { comentariosCelda, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerNombresFirmas = new PdfPCell(new Phrase("NOMBRES Y FIRMAS", negritasBlanca));
            headerNombresFirmas.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNombresFirmas.VerticalAlignment = Element.ALIGN_CENTER;
            headerNombresFirmas.BackgroundColor = new BaseColor(16, 5, 92);
            headerNombresFirmas.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNombresFirmas, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerFirmaDisenadoMecanico = new PdfPCell(new Phrase("DISEÑADOR MECANICO", negrita));
            headerFirmaDisenadoMecanico.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaDisenadoMecanico.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerFirmaDisenadoMecanico.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerFirmaLiderMecanico = new PdfPCell(new Phrase("LIDER MECANICO", negrita));
            headerFirmaLiderMecanico.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaLiderMecanico.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerFirmaLiderMecanico.BackgroundColor = BaseColor.LIGHT_GRAY;
           

            headerFirmaLiderProyecto = new PdfPCell(new Phrase("LIDER DE PROYECTO", negrita));
            headerFirmaLiderProyecto.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaLiderProyecto.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerFirmaLiderProyecto.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerFirmaContacto = new PdfPCell(new Phrase("CONTACTO DEL CLIENTE", negrita));
            headerFirmaContacto.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFirmaContacto.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerFirmaContacto.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerFirmaDisenadoMecanico, headerFirmaLiderMecanico, headerFirmaLiderProyecto, headerFirmaContacto });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            firmaDisenadoMecanico = new PdfPCell(new Phrase(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine, negrita));
            firmaDisenadoMecanico.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaDisenadoMecanico.VerticalAlignment = Element.ALIGN_MIDDLE;

            firmaLiderMecanico = new PdfPCell(new Phrase(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine, negrita));
            firmaLiderMecanico.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaLiderMecanico.VerticalAlignment = Element.ALIGN_MIDDLE;

            firmaLiderProyecto = new PdfPCell(new Phrase(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine, negrita));
            firmaLiderProyecto.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaLiderProyecto.VerticalAlignment = Element.ALIGN_MIDDLE;

            firmaContacto = new PdfPCell(new Phrase(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine, negrita));
            firmaContacto.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaContacto.VerticalAlignment = Element.ALIGN_MIDDLE;
            
            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { firmaDisenadoMecanico, firmaLiderMecanico, firmaLiderProyecto, firmaContacto });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            nombreDisenadoMecanico = new PdfPCell(new Phrase(Usuarios[0].ToString(), negrita));
            nombreDisenadoMecanico.HorizontalAlignment = Element.ALIGN_CENTER;
            nombreDisenadoMecanico.VerticalAlignment = Element.ALIGN_MIDDLE;
            
            nombreLiderMecanico = new PdfPCell(new Phrase(Usuarios[1].ToString(), negrita));
            nombreLiderMecanico.HorizontalAlignment = Element.ALIGN_CENTER;
            nombreLiderMecanico.VerticalAlignment = Element.ALIGN_MIDDLE;

            nombreLiderProyecto = new PdfPCell(new Phrase(Usuarios[2].ToString(), negrita));
            nombreLiderProyecto.HorizontalAlignment = Element.ALIGN_CENTER;
            nombreLiderProyecto.VerticalAlignment = Element.ALIGN_MIDDLE;
            
            nombreContacto = new PdfPCell(new Phrase(Usuarios[3].ToString(), negrita));
            nombreContacto.HorizontalAlignment = Element.ALIGN_CENTER;
            nombreContacto.VerticalAlignment = Element.ALIGN_MIDDLE;
            
            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { nombreDisenadoMecanico, nombreLiderMecanico, nombreLiderProyecto, nombreContacto });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

#endregion

            ptablaPrincipalPerfilUsuario.Add(tablaPerfilUsuario);
            doc.Add(ptablaPrincipalPerfilUsuario);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] ReporteDeMantenimientoPreventivoEquipoComputo(int idEquipo, string tipoEquipo, string tipoMantenimiento, bool ultimoMantenimiento = false)
        {
            byte[] datosPDF;

            Usuario usuario = new Usuario();
            Mantenimiento mantenimiento = new Mantenimiento();
            EquipoComputo equipoComputo = new EquipoComputo();
            EquipoComputoUsuario equipoUsuario = new EquipoComputoUsuario();
            CheckitemsMantenimiento listaMantenimiento = new CheckitemsMantenimiento();
            MantenimientoTopico topicos = new MantenimientoTopico();
            MaterialProyecto materialProyecto = new MaterialProyecto();

            mantenimiento.CargarUltimoMantenimientoTerminado(idEquipo, tipoEquipo, tipoMantenimiento);
            if (!mantenimiento.TieneFilas())
                return null;

            equipoComputo.CargarDatos(idEquipo);
            

            #region inicializar PDF

            #region Fuentes
            Font tituloH1 = FontFactory.GetFont("Calibri", 12, 1, BaseColor.BLACK);
            Font tituloH2 = FontFactory.GetFont("Calibri", 10, 1, BaseColor.BLACK);
            Font normal = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negritasBlanca = FontFactory.GetFont("Calibri", 8, 1, BaseColor.WHITE);

            #endregion

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(144, 56);
            logo.SpacingAfter = 10;
            logo.SpacingBefore = 5;

            #endregion  

            //TABLA PRINCIPAL
            #region Tabla principal
            //crear espacio de la tabla
            Paragraph ptablaPrincipalPerfilUsuario = new Paragraph();
            ptablaPrincipalPerfilUsuario.SpacingBefore = 5;

            //inicializar tabla
            PdfPTable tablaPerfilUsuario = new PdfPTable(4);
            tablaPerfilUsuario.WidthPercentage = 100;
            tablaPerfilUsuario.SpacingBefore = 5;

            int[] intTblWidthIsometrico = { 25, 25, 25, 25 };
            tablaPerfilUsuario.SetWidths(intTblWidthIsometrico);

            PdfPCell columna1 = new PdfPCell();
            PdfPCell columna2 = new PdfPCell();
            PdfPCell columna3 = new PdfPCell();
            PdfPCell columna4 = new PdfPCell();


            PdfPRow rowInformacionGeneral = new PdfPRow(new PdfPCell[] { columna1, columna2, columna3, columna4 });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            #endregion

            //Declaración de celdas
            #region Celdas
            PdfPCell perfilLogo;
            PdfPCell titulo;
            PdfPCell tipoEquipoCelda;
            PdfPCell equipoCelda;
            PdfPCell tipoEquipoResultado;
            PdfPCell equipoResultadoCelda;
            PdfPCell fechaCelda;
            PdfPCell fechaResultadoCelda;
            PdfPCell responsableMantenimiento;
            PdfPCell descripcionCelda;
            PdfPCell headerCostoMantenimiento;
            PdfPCell headerComentarios;
            PdfPCell headerNumeroParte;
            PdfPCell headerMaterialDescripcion;
            PdfPCell headerMaterialPrecioTotal;
            PdfPCell headerMaterialSolicitante;
            PdfPCell materialSolicitante;
            PdfPCell numeroParte;
            PdfPCell materialDescripcion;
            PdfPCell materialPrecioTotal;
            PdfPCell total;
            PdfPCell celdaTopicos;
            PdfPCell celdaEstatus;
            PdfPCell resultadoEspacio1;
            PdfPCell celdaAccion;
            PdfPCell celdaComentariosAccion;
            PdfPCell comentariosCelda;

            #endregion

            #region Contenido de celdas

            perfilLogo = new PdfPCell(logo);
            perfilLogo.HorizontalAlignment = Element.ALIGN_CENTER;
            perfilLogo.VerticalAlignment = Element.ALIGN_CENTER;
            perfilLogo.ExtraParagraphSpace = 1;
            perfilLogo.Colspan = 2;

            titulo = new PdfPCell(new Phrase("REPORTE DE MANTENIMIENTO " + tipoMantenimiento.ToUpper(), tituloH1));
            titulo.HorizontalAlignment = Element.ALIGN_CENTER;
            titulo.VerticalAlignment = Element.ALIGN_MIDDLE;
            titulo.Colspan = 2;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { perfilLogo, null, titulo, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            tipoEquipoCelda = new PdfPCell(new Phrase("A", negrita));
            tipoEquipoCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            tipoEquipoCelda.VerticalAlignment = Element.ALIGN_RIGHT;

            tipoEquipoResultado = new PdfPCell(new Phrase(tipoEquipo.ToUpper(), negrita));
            tipoEquipoResultado.HorizontalAlignment = Element.ALIGN_LEFT;
            tipoEquipoResultado.VerticalAlignment = Element.ALIGN_LEFT;

            string fechaMantenimiento = string.Empty;
            object objFecha = equipoComputo.Fila().Celda("ultimo_mantenimiento");
            if(objFecha != null)
                fechaMantenimiento = Global.FechaATexto(objFecha);
            else
                fechaMantenimiento = Global.FechaATexto(equipoComputo.Fila().Celda("fecha_alta"));

            fechaCelda = new PdfPCell(new Phrase("FECHA", negrita));
            fechaCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            fechaCelda.VerticalAlignment = Element.ALIGN_RIGHT;

            fechaResultadoCelda = new PdfPCell(new Phrase(fechaMantenimiento, negrita));
            fechaResultadoCelda.HorizontalAlignment = Element.ALIGN_LEFT;
            fechaResultadoCelda.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { tipoEquipoCelda, tipoEquipoResultado, fechaCelda, fechaResultadoCelda });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            string strEquipo = string.Empty;
            object objEquipo = equipoComputo.Fila().Celda("numero_serie");
            if (objEquipo != null)
                strEquipo = idEquipo + " - " + objEquipo.ToString();
            else
                strEquipo = Global.FechaATexto(equipoComputo.Fila().Celda("fecha_alta"));

            equipoCelda = new PdfPCell(new Phrase("EQUIPO", negrita));
            equipoCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            equipoCelda.VerticalAlignment = Element.ALIGN_RIGHT;

            equipoResultadoCelda = new PdfPCell(new Phrase(strEquipo, negrita));
            equipoResultadoCelda.HorizontalAlignment = Element.ALIGN_LEFT;
            equipoResultadoCelda.VerticalAlignment = Element.ALIGN_LEFT;

            resultadoEspacio1 = new PdfPCell(new Phrase("RESPONSABLE", negrita));
            resultadoEspacio1.HorizontalAlignment = Element.ALIGN_RIGHT;
            resultadoEspacio1.VerticalAlignment = Element.ALIGN_RIGHT;

            responsableMantenimiento = new PdfPCell(new Phrase(Global.ObjetoATexto(equipoComputo.Fila().Celda("responsable_mantenimiento"),"N/A"), negrita));
            responsableMantenimiento.HorizontalAlignment = Element.ALIGN_LEFT;
            responsableMantenimiento.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { equipoCelda, equipoResultadoCelda, resultadoEspacio1, responsableMantenimiento });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerComentarios = new PdfPCell(new Phrase("PLAN DE MANTENIMIENTO", negritasBlanca));
            headerComentarios.HorizontalAlignment = Element.ALIGN_CENTER;
            headerComentarios.VerticalAlignment = Element.ALIGN_CENTER;
            headerComentarios.BackgroundColor = new BaseColor(16, 5, 92);
            headerComentarios.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerComentarios, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            string descripcion = "EL PRESENTE DOCUMENTO AVALA QUE EL MANTENIMIENTO " + tipoMantenimiento + " DEL " + tipoEquipo + " " + strEquipo + ": FUE REALIZADO EN " + fechaMantenimiento +
                                ", CUMPLIENDO CON LOS SIGUIENTES REQUERIMIENTOS:" + Environment.NewLine + Environment.NewLine;

            descripcionCelda = new PdfPCell(new Phrase(descripcion, normal));
            descripcionCelda.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { descripcionCelda, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            comentariosCelda = new PdfPCell(new Phrase("LISTA DE PUNTOS DE REVISION", negrita));
            comentariosCelda.HorizontalAlignment = Element.ALIGN_CENTER;
            comentariosCelda.VerticalAlignment = Element.ALIGN_CENTER;
            comentariosCelda.Colspan = 4;
            comentariosCelda.ExtraParagraphSpace = 3;
            comentariosCelda.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { comentariosCelda, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            celdaTopicos = new PdfPCell(new Phrase("PUNTO DE REVISION", negrita));
            celdaTopicos.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTopicos.VerticalAlignment = Element.ALIGN_CENTER;
            celdaTopicos.BackgroundColor = BaseColor.LIGHT_GRAY;

            celdaEstatus = new PdfPCell(new Phrase("ESTATUS", negrita));
            celdaEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaEstatus.VerticalAlignment = Element.ALIGN_CENTER;
            celdaEstatus.BackgroundColor = BaseColor.LIGHT_GRAY;

            celdaAccion = new PdfPCell(new Phrase("ACCION TOMADA", negrita));
            celdaAccion.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaAccion.VerticalAlignment = Element.ALIGN_CENTER;
            celdaAccion.BackgroundColor = BaseColor.LIGHT_GRAY;

            celdaComentariosAccion = new PdfPCell(new Phrase("COMENTARIOS", negrita));
            celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;
            celdaComentariosAccion.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaTopicos, celdaEstatus, celdaComentariosAccion, celdaAccion });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            int topicoCount = 0;
            
            
            listaMantenimiento.CargarMantenimiento(Convert.ToInt32(mantenimiento.Fila().Celda("id"))).ForEach(delegate(Fila f)
            {
                topicoCount++;
                topicos.CargarDatos(Convert.ToInt32(f.Celda("topico")));
                celdaTopicos = new PdfPCell(new Phrase(topicoCount + " -. " + topicos.Fila().Celda("topico").ToString(), normal));
                celdaTopicos.HorizontalAlignment = Element.ALIGN_LEFT;
                celdaTopicos.VerticalAlignment = Element.ALIGN_LEFT;

                celdaEstatus = new PdfPCell(new Phrase(f.Celda("estatus").ToString(), normal));
                celdaEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaEstatus.VerticalAlignment = Element.ALIGN_CENTER;

                string accionTomada = "N/A";
                object objAccionTomada = f.Celda("accion_tomada");
                if (objAccionTomada != null)
                    accionTomada = objAccionTomada.ToString();

                celdaAccion = new PdfPCell(new Phrase(accionTomada, normal));
                celdaAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaAccion.VerticalAlignment = Element.ALIGN_CENTER;

                string comentarios = "N/A";
                object objComentarios = f.Celda("comentarios");
                if (objComentarios != null)
                    comentarios = objComentarios.ToString();

                celdaComentariosAccion = new PdfPCell(new Phrase(comentarios, normal));
                celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaTopicos, celdaEstatus, celdaComentariosAccion, celdaAccion });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            });

            #region Costo en dolares
            headerCostoMantenimiento = new PdfPCell(new Phrase("COSTO DE MANTENIMIENTO EN DOLARES", negritasBlanca));
            headerCostoMantenimiento.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.VerticalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.BackgroundColor = new BaseColor(16, 5, 92);
            headerCostoMantenimiento.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerCostoMantenimiento, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerNumeroParte = new PdfPCell(new Phrase("REQUISICION", negrita));
            headerNumeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerNumeroParte.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialDescripcion = new PdfPCell(new Phrase("DESCRIPCION", negrita));
            headerMaterialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialDescripcion.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialSolicitante = new PdfPCell(new Phrase("SOLICITADO POR", negrita));
            headerMaterialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialSolicitante.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialPrecioTotal = new PdfPCell(new Phrase("PRECIO TOTAL", negrita));
            headerMaterialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialPrecioTotal.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNumeroParte, headerMaterialDescripcion, headerMaterialSolicitante, headerMaterialPrecioTotal });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            List<Fila> materialesMantenimiento = materialProyecto.SeleccionarMaterialMantenimiento(Convert.ToInt32(mantenimiento.Fila().Celda("id")), "USD");

            if (materialesMantenimiento.Count > 0)
            {
                double sumaTotal = 0.0;
                materialesMantenimiento.ForEach(delegate(Fila filaMaterial)
                {
                    numeroParte = new PdfPCell(new Phrase(filaMaterial.Celda("id").ToString(), normal));
                    numeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                    numeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;

                    string strDescripcion = "NUMERO DE PARTE: " + Global.ObjetoATexto(filaMaterial.Celda("numero_parte"), "N/A") + Environment.NewLine + Environment.NewLine + Global.ObjetoATexto(filaMaterial.Celda("descripcion"), "N/A")
                        + Environment.NewLine + Environment.NewLine + "CANTIDAD REQUERIDA: " + filaMaterial.Celda("piezas_requeridas");

                    materialDescripcion = new PdfPCell(new Phrase(strDescripcion, normal));
                    materialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;

                    materialSolicitante = new PdfPCell(new Phrase(Global.ObjetoATexto(filaMaterial.Celda("requisitor"), "N/A"), normal));
                    materialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
            

                    double precio = Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0"));

                    materialPrecioTotal = new PdfPCell(new Phrase(String.Format("{0:C}", precio) + " " + filaMaterial.Celda("precio_moneda"), normal));                 
                    materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
         

                    sumaTotal += Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0.0"));

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { numeroParte, materialDescripcion, materialSolicitante, materialPrecioTotal });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                });

                total = new PdfPCell(new Phrase("COSTO TOTAL: " + String.Format("{0:C}", sumaTotal) + " USD", negrita));
                total.HorizontalAlignment = Element.ALIGN_CENTER;
                total.VerticalAlignment = Element.ALIGN_MIDDLE;
                total.BorderColorTop = BaseColor.WHITE;
                total.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { total, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            else
            {
                materialPrecioTotal = new PdfPCell(new Phrase("DURANTE ESTE MANTENIMIENTO NO SE ORDENARON MATERIALES", negrita));
                materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                materialPrecioTotal.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { materialPrecioTotal, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            #endregion

            #region Costo en pesos
            headerCostoMantenimiento = new PdfPCell(new Phrase("COSTO DE MANTENIMIENTO EN PESOS", negritasBlanca));
            headerCostoMantenimiento.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.VerticalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.BackgroundColor = new BaseColor(16, 5, 92);
            headerCostoMantenimiento.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerCostoMantenimiento, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerNumeroParte = new PdfPCell(new Phrase("REQUISICION", negrita));
            headerNumeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerNumeroParte.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialDescripcion = new PdfPCell(new Phrase("DESCRIPCION", negrita));
            headerMaterialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialDescripcion.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialSolicitante = new PdfPCell(new Phrase("SOLICITADO POR", negrita));
            headerMaterialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialSolicitante.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialPrecioTotal = new PdfPCell(new Phrase("PRECIO TOTAL", negrita));
            headerMaterialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialPrecioTotal.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNumeroParte, headerMaterialDescripcion, headerMaterialSolicitante, headerMaterialPrecioTotal });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            materialesMantenimiento = materialProyecto.SeleccionarMaterialMantenimiento(Convert.ToInt32(mantenimiento.Fila().Celda("id")), "MXN");

            if (materialesMantenimiento.Count > 0)
            {
                double sumaTotal = 0.0;
                materialesMantenimiento.ForEach(delegate(Fila filaMaterial)
                {
                    numeroParte = new PdfPCell(new Phrase(filaMaterial.Celda("id").ToString(), normal));
                    numeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                    numeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;

                    string strDescripcion = "NUMERO DE PARTE: " + Global.ObjetoATexto(filaMaterial.Celda("numero_parte"), "N/A") + Environment.NewLine + Environment.NewLine + Global.ObjetoATexto(filaMaterial.Celda("descripcion"), "N/A")
                        + Environment.NewLine + Environment.NewLine + "CANTIDAD REQUERIDA: " + filaMaterial.Celda("piezas_requeridas");

                    materialDescripcion = new PdfPCell(new Phrase(strDescripcion, normal));
                    materialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;

                    materialSolicitante = new PdfPCell(new Phrase(Global.ObjetoATexto(filaMaterial.Celda("requisitor"), "N/A"), normal));
                    materialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
              

                    double precio = Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0"));

                    materialPrecioTotal = new PdfPCell(new Phrase(String.Format("{0:C}", precio) +  " " + filaMaterial.Celda("precio_moneda"), normal));
                    materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                 

                    sumaTotal += Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0.0"));

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { numeroParte, materialDescripcion, materialSolicitante, materialPrecioTotal });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                });

                total = new PdfPCell(new Phrase("COSTO TOTAL: " + String.Format("{0:C}", sumaTotal) + " MXN", negrita));
                total.HorizontalAlignment = Element.ALIGN_CENTER;
                total.VerticalAlignment = Element.ALIGN_MIDDLE;
                total.BorderColorTop = BaseColor.WHITE;
                total.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { total, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            else
            {
                materialPrecioTotal = new PdfPCell(new Phrase("DURANTE ESTE MANTENIMIENTO NO SE ORDENARON MATERIALES", negrita));
                materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                materialPrecioTotal.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { materialPrecioTotal, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            #endregion

            #endregion

            ptablaPrincipalPerfilUsuario.Add(tablaPerfilUsuario);
            doc.Add(ptablaPrincipalPerfilUsuario);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] ReporteDeMantenimientoPreventivo(int idEquipo, string tipoEquipo, string tipoMantenimiento, List<Fila> FilasTipoMantenimiento)
        {
            byte[] datosPDF;
            string fechaMantenimiento = string.Empty;
            string strEquipo = string.Empty;
            object objFecha = null;
            object objEquipo = null;
            object obFechaAlta = null;
            object objResponsableMantenimiento = null;
            DateTime fechaAlta = fechaAlta = DateTime.Now.AddMonths(-7); 
            
            Mantenimiento mantenimiento = new Mantenimiento();
            mantenimiento.CargarUltimoMantenimientoTerminado(idEquipo, tipoEquipo, tipoMantenimiento);
            if (!mantenimiento.TieneFilas())
                return null;
            
            Usuario usuario = new Usuario();
            CheckitemsMantenimiento listaMantenimiento = new CheckitemsMantenimiento();
            MantenimientoTopico topicos = new MantenimientoTopico();
            MaterialProyecto materialProyecto = new MaterialProyecto();

            FilasTipoMantenimiento.ForEach(delegate (Fila f)
	        {
		        objFecha = f.Celda("ultimo_mantenimiento");
                objEquipo = f.Celda("numero_serie");
                obFechaAlta = f.Celda("fecha_alta");
                objResponsableMantenimiento = f.Celda("responsable_mantenimiento");

                if (obFechaAlta != null)
                    fechaAlta = Convert.ToDateTime(obFechaAlta);
                    
	        });

            #region inicializar PDF

            #region Fuentes
            Font tituloH1 = FontFactory.GetFont("Calibri", 12, 1, BaseColor.BLACK);
            Font tituloH2 = FontFactory.GetFont("Calibri", 10, 1, BaseColor.BLACK);
            Font normal = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negritasBlanca = FontFactory.GetFont("Calibri", 8, 1, BaseColor.WHITE);

            #endregion

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(144, 56);
            logo.SpacingAfter = 10;
            logo.SpacingBefore = 5;

            #endregion

            //TABLA PRINCIPAL
            #region Tabla principal
            //crear espacio de la tabla
            Paragraph ptablaPrincipalPerfilUsuario = new Paragraph();
            ptablaPrincipalPerfilUsuario.SpacingBefore = 5;

            //inicializar tabla
            PdfPTable tablaPerfilUsuario = new PdfPTable(4);
            tablaPerfilUsuario.WidthPercentage = 100;
            tablaPerfilUsuario.SpacingBefore = 5;

            int[] intTblWidthIsometrico = { 25, 25, 25, 25 };
            tablaPerfilUsuario.SetWidths(intTblWidthIsometrico);

            PdfPCell columna1 = new PdfPCell();
            PdfPCell columna2 = new PdfPCell();
            PdfPCell columna3 = new PdfPCell();
            PdfPCell columna4 = new PdfPCell();


            PdfPRow rowInformacionGeneral = new PdfPRow(new PdfPCell[] { columna1, columna2, columna3, columna4 });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            #endregion

            //Declaración de celdas
            #region Celdas
            PdfPCell perfilLogo;
            PdfPCell titulo;
            PdfPCell tipoEquipoCelda;
            PdfPCell equipoCelda;
            PdfPCell tipoEquipoResultado;
            PdfPCell equipoResultadoCelda;
            PdfPCell fechaCelda;
            PdfPCell fechaResultadoCelda;
            PdfPCell responsableMantenimiento;
            PdfPCell descripcionCelda;
            PdfPCell headerCostoMantenimiento;
            PdfPCell headerComentarios;
            PdfPCell headerNumeroParte;
            PdfPCell headerMaterialDescripcion;
            PdfPCell headerMaterialPrecioTotal;
            PdfPCell headerMaterialSolicitante;
            PdfPCell materialSolicitante;
            PdfPCell numeroParte;
            PdfPCell materialDescripcion;
            PdfPCell materialPrecioTotal;
            PdfPCell total;
            PdfPCell celdaTopicos;
            PdfPCell celdaEstatus;
            PdfPCell resultadoEspacio1;
            PdfPCell celdaAccion;
            PdfPCell celdaComentariosAccion;
            PdfPCell comentariosCelda;

            #endregion

            #region Contenido de celdas

            perfilLogo = new PdfPCell(logo);
            perfilLogo.HorizontalAlignment = Element.ALIGN_CENTER;
            perfilLogo.VerticalAlignment = Element.ALIGN_CENTER;
            perfilLogo.ExtraParagraphSpace = 1;
            perfilLogo.Colspan = 2;

            titulo = new PdfPCell(new Phrase("REPORTE DE MANTENIMIENTO " + tipoMantenimiento.ToUpper(), tituloH1));
            titulo.HorizontalAlignment = Element.ALIGN_CENTER;
            titulo.VerticalAlignment = Element.ALIGN_MIDDLE;
            titulo.Colspan = 2;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { perfilLogo, null, titulo, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            tipoEquipoCelda = new PdfPCell(new Phrase("A", negrita));
            tipoEquipoCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            tipoEquipoCelda.VerticalAlignment = Element.ALIGN_RIGHT;

            tipoEquipoResultado = new PdfPCell(new Phrase(tipoEquipo.ToUpper(), negrita));
            tipoEquipoResultado.HorizontalAlignment = Element.ALIGN_LEFT;
            tipoEquipoResultado.VerticalAlignment = Element.ALIGN_LEFT;         
            
            if (objFecha != null)
                fechaMantenimiento = Global.FechaATexto(objFecha);
            else
                fechaMantenimiento = Global.FechaATexto(FilasTipoMantenimiento.Find(x => x.Celda("fecha_alta") == x.Celda("fecha_alta")));

            fechaCelda = new PdfPCell(new Phrase("FECHA", negrita));
            fechaCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            fechaCelda.VerticalAlignment = Element.ALIGN_RIGHT;

            fechaResultadoCelda = new PdfPCell(new Phrase(fechaMantenimiento, negrita));
            fechaResultadoCelda.HorizontalAlignment = Element.ALIGN_LEFT;
            fechaResultadoCelda.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { tipoEquipoCelda, tipoEquipoResultado, fechaCelda, fechaResultadoCelda });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);          
           
            if (objEquipo != null)
                strEquipo = idEquipo + " - " + objEquipo.ToString();
            else
                strEquipo = Global.FechaATexto(fechaAlta);

            equipoCelda = new PdfPCell(new Phrase(tipoEquipo.ToUpper(), negrita));
            equipoCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            equipoCelda.VerticalAlignment = Element.ALIGN_RIGHT;

            equipoResultadoCelda = new PdfPCell(new Phrase(strEquipo, negrita));
            equipoResultadoCelda.HorizontalAlignment = Element.ALIGN_LEFT;
            equipoResultadoCelda.VerticalAlignment = Element.ALIGN_LEFT;

            resultadoEspacio1 = new PdfPCell(new Phrase("RESPONSABLE", negrita));
            resultadoEspacio1.HorizontalAlignment = Element.ALIGN_RIGHT;
            resultadoEspacio1.VerticalAlignment = Element.ALIGN_RIGHT;

            responsableMantenimiento = new PdfPCell(new Phrase(Global.ObjetoATexto(objResponsableMantenimiento, "N/A"), negrita));
            responsableMantenimiento.HorizontalAlignment = Element.ALIGN_LEFT;
            responsableMantenimiento.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { equipoCelda, equipoResultadoCelda, resultadoEspacio1, responsableMantenimiento });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerComentarios = new PdfPCell(new Phrase("PLAN DE MANTENIMIENTO", negritasBlanca));
            headerComentarios.HorizontalAlignment = Element.ALIGN_CENTER;
            headerComentarios.VerticalAlignment = Element.ALIGN_CENTER;
            headerComentarios.BackgroundColor = new BaseColor(16, 5, 92);
            headerComentarios.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerComentarios, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            string descripcion = "EL PRESENTE DOCUMENTO AVALA QUE EL MANTENIMIENTO " + tipoMantenimiento + " DEL " + tipoEquipo + " " + strEquipo + ": FUE REALIZADO EN " + fechaMantenimiento +
                                ", CUMPLIENDO CON LOS SIGUIENTES REQUERIMIENTOS:" + Environment.NewLine + Environment.NewLine;

            descripcionCelda = new PdfPCell(new Phrase(descripcion, normal));
            descripcionCelda.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { descripcionCelda, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            comentariosCelda = new PdfPCell(new Phrase("LISTA DE PUNTOS DE REVISION", negrita));
            comentariosCelda.HorizontalAlignment = Element.ALIGN_CENTER;
            comentariosCelda.VerticalAlignment = Element.ALIGN_CENTER;
            comentariosCelda.Colspan = 4;
            comentariosCelda.ExtraParagraphSpace = 3;
            comentariosCelda.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { comentariosCelda, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            celdaTopicos = new PdfPCell(new Phrase("PUNTO DE REVISION", negrita));
            celdaTopicos.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTopicos.VerticalAlignment = Element.ALIGN_CENTER;
            celdaTopicos.BackgroundColor = BaseColor.LIGHT_GRAY;

            celdaEstatus = new PdfPCell(new Phrase("ESTATUS", negrita));
            celdaEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaEstatus.VerticalAlignment = Element.ALIGN_CENTER;
            celdaEstatus.BackgroundColor = BaseColor.LIGHT_GRAY;

            celdaAccion = new PdfPCell(new Phrase("ACCION TOMADA", negrita));
            celdaAccion.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaAccion.VerticalAlignment = Element.ALIGN_CENTER;
            celdaAccion.BackgroundColor = BaseColor.LIGHT_GRAY;

            celdaComentariosAccion = new PdfPCell(new Phrase("COMENTARIOS", negrita));
            celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;
            celdaComentariosAccion.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaTopicos, celdaEstatus, celdaComentariosAccion, celdaAccion });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            int topicoCount = 0;

            listaMantenimiento.CargarMantenimiento(Convert.ToInt32(mantenimiento.Fila().Celda("id"))).ForEach(delegate(Fila f)
            {
                topicoCount++;
                topicos.CargarDatos(Convert.ToInt32(f.Celda("topico")));
                celdaTopicos = new PdfPCell(new Phrase(topicoCount + " -. " + topicos.Fila().Celda("topico").ToString(), normal));
                celdaTopicos.HorizontalAlignment = Element.ALIGN_LEFT;
                celdaTopicos.VerticalAlignment = Element.ALIGN_LEFT;

                celdaEstatus = new PdfPCell(new Phrase(f.Celda("estatus").ToString(), normal));
                celdaEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaEstatus.VerticalAlignment = Element.ALIGN_CENTER;

                string accionTomada = "N/A";
                object objAccionTomada = f.Celda("accion_tomada");
                if (objAccionTomada != null)
                    accionTomada = objAccionTomada.ToString();

                celdaAccion = new PdfPCell(new Phrase(accionTomada, normal));
                celdaAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaAccion.VerticalAlignment = Element.ALIGN_CENTER;

                string comentarios = "N/A";
                object objComentarios = f.Celda("comentarios");
                if (objComentarios != null)
                    comentarios = objComentarios.ToString();

                celdaComentariosAccion = new PdfPCell(new Phrase(comentarios, normal));
                celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaTopicos, celdaEstatus, celdaComentariosAccion, celdaAccion });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            });

            #region Costo en dolares
            headerCostoMantenimiento = new PdfPCell(new Phrase("COSTO DE MANTENIMIENTO EN DOLARES", negritasBlanca));
            headerCostoMantenimiento.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.VerticalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.BackgroundColor = new BaseColor(16, 5, 92);
            headerCostoMantenimiento.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerCostoMantenimiento, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerNumeroParte = new PdfPCell(new Phrase("REQUISICION", negrita));
            headerNumeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerNumeroParte.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialDescripcion = new PdfPCell(new Phrase("DESCRIPCION", negrita));
            headerMaterialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialDescripcion.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialSolicitante = new PdfPCell(new Phrase("SOLICITADO POR", negrita));
            headerMaterialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialSolicitante.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialPrecioTotal = new PdfPCell(new Phrase("PRECIO TOTAL", negrita));
            headerMaterialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialPrecioTotal.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNumeroParte, headerMaterialDescripcion, headerMaterialSolicitante, headerMaterialPrecioTotal });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            List<Fila> materialesMantenimiento = materialProyecto.SeleccionarMaterialMantenimiento(Convert.ToInt32(mantenimiento.Fila().Celda("id")), "USD");

            if (materialesMantenimiento.Count > 0)
            {
                double sumaTotal = 0.0;
                materialesMantenimiento.ForEach(delegate(Fila filaMaterial)
                {
                    numeroParte = new PdfPCell(new Phrase(filaMaterial.Celda("id").ToString(), normal));
                    numeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                    numeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;

                    string strDescripcion = "NUMERO DE PARTE: " + Global.ObjetoATexto(filaMaterial.Celda("numero_parte"), "N/A") + Environment.NewLine + Environment.NewLine + Global.ObjetoATexto(filaMaterial.Celda("descripcion"), "N/A")
                        + Environment.NewLine + Environment.NewLine + "CANTIDAD REQUERIDA: " + filaMaterial.Celda("piezas_requeridas");

                    materialDescripcion = new PdfPCell(new Phrase(strDescripcion, normal));
                    materialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;

                    materialSolicitante = new PdfPCell(new Phrase(Global.ObjetoATexto(filaMaterial.Celda("requisitor"), "N/A"), normal));
                    materialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
               

                    double precio = Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0"));

                    materialPrecioTotal = new PdfPCell(new Phrase(String.Format("{0:C}", precio) + " " + filaMaterial.Celda("precio_moneda"), normal));
                    materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
           

                    sumaTotal += Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0.0"));

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { numeroParte, materialDescripcion, materialSolicitante, materialPrecioTotal });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                });

                total = new PdfPCell(new Phrase("COSTO TOTAL: " + String.Format("{0:C}", sumaTotal) + " USD", negrita));
                total.HorizontalAlignment = Element.ALIGN_CENTER;
                total.VerticalAlignment = Element.ALIGN_MIDDLE;
                total.BorderColorTop = BaseColor.WHITE;
                total.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { total, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            else
            {
                materialPrecioTotal = new PdfPCell(new Phrase("DURANTE ESTE MANTENIMIENTO NO SE ORDENARON MATERIALES", negrita));
                materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                materialPrecioTotal.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { materialPrecioTotal, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            #endregion

            #region Costo en pesos
            headerCostoMantenimiento = new PdfPCell(new Phrase("COSTO DE MANTENIMIENTO EN PESOS", negritasBlanca));
            headerCostoMantenimiento.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.VerticalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.BackgroundColor = new BaseColor(16, 5, 92);
            headerCostoMantenimiento.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerCostoMantenimiento, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerNumeroParte = new PdfPCell(new Phrase("REQUISICION", negrita));
            headerNumeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerNumeroParte.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialDescripcion = new PdfPCell(new Phrase("DESCRIPCION", negrita));
            headerMaterialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialDescripcion.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialSolicitante = new PdfPCell(new Phrase("SOLICITADO POR", negrita));
            headerMaterialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialSolicitante.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialPrecioTotal = new PdfPCell(new Phrase("PRECIO TOTAL", negrita));
            headerMaterialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialPrecioTotal.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNumeroParte, headerMaterialDescripcion, headerMaterialSolicitante, headerMaterialPrecioTotal });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            materialesMantenimiento = materialProyecto.SeleccionarMaterialMantenimiento(Convert.ToInt32(mantenimiento.Fila().Celda("id")), "MXN");

            if (materialesMantenimiento.Count > 0)
            {
                double sumaTotal = 0.0;
                materialesMantenimiento.ForEach(delegate(Fila filaMaterial)
                {
                    numeroParte = new PdfPCell(new Phrase(filaMaterial.Celda("id").ToString(), normal));
                    numeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                    numeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;

                    string strDescripcion = "NUMERO DE PARTE: " + Global.ObjetoATexto(filaMaterial.Celda("numero_parte"), "N/A") + Environment.NewLine + Environment.NewLine + Global.ObjetoATexto(filaMaterial.Celda("descripcion"), "N/A")
                        + Environment.NewLine + Environment.NewLine + "CANTIDAD REQUERIDA: " + filaMaterial.Celda("piezas_requeridas");

                    materialDescripcion = new PdfPCell(new Phrase(strDescripcion, normal));
                    materialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;

                    materialSolicitante = new PdfPCell(new Phrase(Global.ObjetoATexto(filaMaterial.Celda("requisitor"), "N/A"), normal));
                    materialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
           

                    double precio = Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0"));

                    materialPrecioTotal = new PdfPCell(new Phrase(String.Format("{0:C}", precio) + " " + filaMaterial.Celda("precio_moneda"), normal));
                    materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                    

                    sumaTotal += Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0.0"));

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { numeroParte, materialDescripcion, materialSolicitante, materialPrecioTotal });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                });

                total = new PdfPCell(new Phrase("COSTO TOTAL: " + String.Format("{0:C}", sumaTotal) + " MXN", negrita));
                total.HorizontalAlignment = Element.ALIGN_CENTER;
                total.VerticalAlignment = Element.ALIGN_MIDDLE;
                total.BorderColorTop = BaseColor.WHITE;
                total.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { total, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            else
            {
                materialPrecioTotal = new PdfPCell(new Phrase("DURANTE ESTE MANTENIMIENTO NO SE ORDENARON MATERIALES", negrita));
                materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                materialPrecioTotal.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { materialPrecioTotal, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            #endregion


            #endregion

            ptablaPrincipalPerfilUsuario.Add(tablaPerfilUsuario);
            doc.Add(ptablaPrincipalPerfilUsuario);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] ReporteDeMantenimientoCorrectivo(int idEquipo, string tipoEquipo, string tipoMantenimiento, int idOrdenTrabajo, List<Fila> EquipoFilas)
        {
            Usuario usuario = new Usuario();
            Mantenimiento mantenimiento = new Mantenimiento();
            ActividadMantenimiento actividadMantenimiento = new ActividadMantenimiento();
            OrdenTrabajoMantenimiento ordenTrabajo = new OrdenTrabajoMantenimiento();
            MaterialProyecto materialProyecto = new MaterialProyecto();

            
            if (EquipoFilas.Count <= 0)
                return null;

            mantenimiento.CargarMantenimientoCorrectivoOrdenTrabajo(idEquipo, tipoEquipo, tipoMantenimiento, idOrdenTrabajo);
            if (!mantenimiento.TieneFilas())
                return null;

            byte[] datosPDF;
            string strUltimoMantenimiento = string.Empty;
            string strNumeroSerie = string.Empty;
            string strResponsableMantenimiento = string.Empty;
            string strSolicitado = string.Empty;

            EquipoFilas.ForEach(delegate(Fila f)
            {
                strNumeroSerie = Global.ObjetoATexto(f.Celda("numero_serie"), "N/A");
            });

            ordenTrabajo.MantenimientoCorrectivo(idOrdenTrabajo).ForEach(delegate(Fila f)
            {
                strUltimoMantenimiento = Global.FechaATexto(f.Celda("fecha_terminado"));
                strResponsableMantenimiento = Global.ObjetoATexto(f.Celda("usuario_terminado"), "N/A");
                strSolicitado = Global.ObjetoATexto(f.Celda("solicitado_por"), "N/A");
            });
            

            //equipoComputo.CargarDatos(idEquipo);

            #region inicializar PDF

            #region Fuentes
            Font tituloH1 = FontFactory.GetFont("Calibri", 12, 1, BaseColor.BLACK);
            Font tituloH2 = FontFactory.GetFont("Calibri", 10, 1, BaseColor.BLACK);
            Font normal = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negritasBlanca = FontFactory.GetFont("Calibri", 8, 1, BaseColor.WHITE);
            #endregion

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(144, 56);
            logo.SpacingAfter = 10;
            logo.SpacingBefore = 5;

            #endregion

            //TABLA PRINCIPAL
            #region Tabla principal
            //crear espacio de la tabla
            Paragraph ptablaPrincipalPerfilUsuario = new Paragraph();
            ptablaPrincipalPerfilUsuario.SpacingBefore = 5;

            //inicializar tabla
            PdfPTable tablaPerfilUsuario = new PdfPTable(4);
            tablaPerfilUsuario.WidthPercentage = 100;
            tablaPerfilUsuario.SpacingBefore = 5;

            int[] intTblWidthIsometrico = { 25, 25, 25, 25 };
            tablaPerfilUsuario.SetWidths(intTblWidthIsometrico);

            PdfPCell columna1 = new PdfPCell();
            PdfPCell columna2 = new PdfPCell();
            PdfPCell columna3 = new PdfPCell();
            PdfPCell columna4 = new PdfPCell();


            PdfPRow rowInformacionGeneral = new PdfPRow(new PdfPCell[] { columna1, columna2, columna3, columna4 });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            #endregion

            //Declaración de celdas
            #region Celdas
            PdfPCell perfilLogo;
            PdfPCell titulo;
            PdfPCell tipoEquipoCelda;
            PdfPCell equipoCelda;
            PdfPCell tipoEquipoResultado;
            PdfPCell equipoResultadoCelda;
            PdfPCell tipoEquipos;
            PdfPCell resultadoTipoEquipos;
            PdfPCell descripcionCelda;
            PdfPCell headerComentarios;
            PdfPCell celdaTopicos;
            PdfPCell celdaEstatus;
            PdfPCell resultadoEspacio1;
            PdfPCell espacio1;
            PdfPCell celdaAccion;
            PdfPCell celdaComentariosAccion;
            PdfPCell comentariosCelda;
            PdfPCell headerCostoMantenimiento;
            PdfPCell headerNumeroParte;
            PdfPCell headerMaterialDescripcion;
            PdfPCell headerMaterialPrecioTotal;
            PdfPCell headerMaterialSolicitante;
            PdfPCell materialSolicitante;
            PdfPCell numeroParte;
            PdfPCell materialDescripcion;
            PdfPCell materialPrecioTotal;
            PdfPCell total;

            #endregion

            #region Contenido de celdas

            perfilLogo = new PdfPCell(logo);
            perfilLogo.HorizontalAlignment = Element.ALIGN_CENTER;
            perfilLogo.VerticalAlignment = Element.ALIGN_CENTER;
            perfilLogo.ExtraParagraphSpace = 1;
            perfilLogo.Colspan = 2;

            titulo = new PdfPCell(new Phrase("MANTENIMIENTO CORRECTIVO", tituloH1));
            titulo.HorizontalAlignment = Element.ALIGN_CENTER;
            titulo.VerticalAlignment = Element.ALIGN_MIDDLE;
            titulo.Colspan = 2;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { perfilLogo, null, titulo, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            tipoEquipoCelda = new PdfPCell(new Phrase("A:", negrita));
            tipoEquipoCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            tipoEquipoCelda.VerticalAlignment = Element.ALIGN_RIGHT;

            string strEquipo = idEquipo.ToString() + " - " + strNumeroSerie;

            tipoEquipoResultado = new PdfPCell(new Phrase(tipoEquipo + Environment.NewLine + strEquipo, negrita));
            tipoEquipoResultado.HorizontalAlignment = Element.ALIGN_LEFT;
            tipoEquipoResultado.VerticalAlignment = Element.ALIGN_LEFT;

            tipoEquipos = new PdfPCell(new Phrase("FECHA:", negrita));
            tipoEquipos.HorizontalAlignment = Element.ALIGN_RIGHT;
            tipoEquipos.VerticalAlignment = Element.ALIGN_RIGHT;
            
            resultadoTipoEquipos = new PdfPCell(new Phrase(strUltimoMantenimiento, negrita));
            resultadoTipoEquipos.HorizontalAlignment = Element.ALIGN_LEFT;
            resultadoTipoEquipos.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { tipoEquipoCelda, tipoEquipoResultado, tipoEquipos, resultadoTipoEquipos });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            equipoCelda = new PdfPCell(new Phrase("SOLICITADO POR:", negrita));
            equipoCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            equipoCelda.VerticalAlignment = Element.ALIGN_RIGHT;
           
            equipoResultadoCelda = new PdfPCell(new Phrase(strSolicitado, negrita));
            equipoResultadoCelda.HorizontalAlignment = Element.ALIGN_LEFT;
            equipoResultadoCelda.VerticalAlignment = Element.ALIGN_LEFT;

            espacio1 = new PdfPCell(new Phrase("RESPONSABLE:", negrita));
            espacio1.HorizontalAlignment = Element.ALIGN_RIGHT;
            espacio1.VerticalAlignment = Element.ALIGN_RIGHT;

            resultadoEspacio1 = new PdfPCell(new Phrase(strResponsableMantenimiento, negrita));
            resultadoEspacio1.HorizontalAlignment = Element.ALIGN_LEFT;
            resultadoEspacio1.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { equipoCelda, equipoResultadoCelda, espacio1, resultadoEspacio1 });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerComentarios = new PdfPCell(new Phrase("HISTORIAL DE MANTENIMIENTO", negritasBlanca));
            headerComentarios.HorizontalAlignment = Element.ALIGN_CENTER;
            headerComentarios.VerticalAlignment = Element.ALIGN_CENTER;
            headerComentarios.BackgroundColor = new BaseColor(16, 5, 92);
            headerComentarios.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerComentarios, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            string descripcion = "EN EL PRESENTE DOCUMENTO SE ENLISTAN LAS ESPECIFICACIONES DEl MANTENIMIENTO CORRECTIVO  AL " + tipoEquipo + " " + strEquipo + "CONFORME A LA FECHA DE REALIZACION DEL MANTENIMIENTO:" + Environment.NewLine + Environment.NewLine;

            descripcionCelda = new PdfPCell(new Phrase(descripcion, normal));
            descripcionCelda.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { descripcionCelda, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            string fechaMantenimientoActividad = "";

            fechaMantenimientoActividad = Global.FechaATexto(mantenimiento.Fila().Celda("fecha"));

            comentariosCelda = new PdfPCell(new Phrase("MANTENIMIENTO " + mantenimiento.Fila().Celda("tipo_mantenimiento").ToString() + ". FECHA: " + fechaMantenimientoActividad, negrita));
            comentariosCelda.HorizontalAlignment = Element.ALIGN_CENTER;
            comentariosCelda.VerticalAlignment = Element.ALIGN_CENTER;
            comentariosCelda.Colspan = 4;
            comentariosCelda.ExtraParagraphSpace = 3;
            comentariosCelda.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { comentariosCelda, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            celdaTopicos = new PdfPCell(new Phrase("PUNTO DE REVISION", negrita));
            celdaTopicos.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTopicos.VerticalAlignment = Element.ALIGN_CENTER;
            celdaTopicos.BackgroundColor = BaseColor.LIGHT_GRAY;

            celdaEstatus = new PdfPCell(new Phrase("ESTATUS", negrita));
            celdaEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaEstatus.VerticalAlignment = Element.ALIGN_CENTER;
            celdaEstatus.BackgroundColor = BaseColor.LIGHT_GRAY;

            celdaAccion = new PdfPCell(new Phrase("ACCION TOMADA", negrita));
            celdaAccion.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaAccion.VerticalAlignment = Element.ALIGN_CENTER;
            celdaAccion.BackgroundColor = BaseColor.LIGHT_GRAY;

            celdaComentariosAccion = new PdfPCell(new Phrase("COMENTARIOS", negrita));
            celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;
            celdaComentariosAccion.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaTopicos, celdaComentariosAccion, celdaAccion, celdaEstatus });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            int topicoCount = 0;
            string actividad = "";
            string comentarios = "";
            string strTopicos = "";
            string estatus = "";


            string a = mantenimiento.Fila().Celda("id").ToString();
            List<Fila> ListaCorrectivo = actividadMantenimiento.CargarActividades(Convert.ToInt32(mantenimiento.Fila().Celda("id")));
            if (ListaCorrectivo.Count > 0)
            {
                ListaCorrectivo.ForEach(delegate(Fila filaCorrectivo)
                {
                    topicoCount++;
                    actividad += topicoCount + " -. " + filaCorrectivo.Celda("actividad").ToString() + Environment.NewLine;
                    comentarios += filaCorrectivo.Celda("comentarios").ToString() + Environment.NewLine;
                });
            }

            if (actividad == "")
                actividad = "SIN ACTIVIDADES";

            ordenTrabajo.CargarDatos(Convert.ToInt32(mantenimiento.Fila().Celda("orden_trabajo")));
            strTopicos = ordenTrabajo.Fila().Celda("puntos_reparacion").ToString();
            estatus = ordenTrabajo.Fila().Celda("estatus").ToString();

            celdaTopicos = new PdfPCell(new Phrase(strTopicos, normal));
            celdaTopicos.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaTopicos.VerticalAlignment = Element.ALIGN_LEFT;

            celdaEstatus = new PdfPCell(new Phrase(estatus, normal));
            celdaEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaEstatus.VerticalAlignment = Element.ALIGN_CENTER;

            celdaAccion = new PdfPCell(new Phrase(actividad, normal));
            celdaAccion.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaAccion.VerticalAlignment = Element.ALIGN_CENTER;

            celdaComentariosAccion = new PdfPCell(new Phrase(comentarios, normal));
            celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaTopicos, celdaComentariosAccion, celdaAccion, celdaEstatus });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            #region Costo en dolares
            headerCostoMantenimiento = new PdfPCell(new Phrase("COSTO DE MANTENIMIENTO EN DOLARES", negritasBlanca));
            headerCostoMantenimiento.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.VerticalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.BackgroundColor = new BaseColor(16, 5, 92);
            headerCostoMantenimiento.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerCostoMantenimiento, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerNumeroParte = new PdfPCell(new Phrase("REQUISICION", negrita));
            headerNumeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerNumeroParte.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialDescripcion = new PdfPCell(new Phrase("DESCRIPCION", negrita));
            headerMaterialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialDescripcion.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialSolicitante = new PdfPCell(new Phrase("SOLICITADO POR", negrita));
            headerMaterialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialSolicitante.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialPrecioTotal = new PdfPCell(new Phrase("PRECIO TOTAL", negrita));
            headerMaterialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialPrecioTotal.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNumeroParte, headerMaterialDescripcion, headerMaterialSolicitante, headerMaterialPrecioTotal });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            List<Fila> materialesMantenimiento = materialProyecto.SeleccionarMaterialMantenimiento(Convert.ToInt32(mantenimiento.Fila().Celda("id")), "USD");

            if (materialesMantenimiento.Count > 0)
            {
                double sumaTotal = 0.0;
                materialesMantenimiento.ForEach(delegate(Fila filaMaterial)
                {
                    numeroParte = new PdfPCell(new Phrase(filaMaterial.Celda("id").ToString(), normal));
                    numeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                    numeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;

                    string strDescripcion = "NUMERO DE PARTE: " + Global.ObjetoATexto(filaMaterial.Celda("numero_parte"), "N/A") + Environment.NewLine + Environment.NewLine + Global.ObjetoATexto(filaMaterial.Celda("descripcion"), "N/A")
                        + Environment.NewLine + Environment.NewLine + "CANTIDAD REQUERIDA: " + filaMaterial.Celda("piezas_requeridas");

                    materialDescripcion = new PdfPCell(new Phrase(strDescripcion, normal));
                    materialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;

                    materialSolicitante = new PdfPCell(new Phrase(Global.ObjetoATexto(filaMaterial.Celda("requisitor"), "N/A"), normal));
                    materialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
                   

                    double precio = Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0"));

                    materialPrecioTotal = new PdfPCell(new Phrase(String.Format("{0:C}", precio) + " " + filaMaterial.Celda("precio_moneda"), normal));
                    materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                   

                    sumaTotal += Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0.0"));

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { numeroParte, materialDescripcion, materialSolicitante, materialPrecioTotal });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                });

                total = new PdfPCell(new Phrase("COSTO TOTAL: " + String.Format("{0:C}", sumaTotal) + " USD", negrita));
                total.HorizontalAlignment = Element.ALIGN_CENTER;
                total.VerticalAlignment = Element.ALIGN_MIDDLE;
                total.BorderColorTop = BaseColor.WHITE;
                total.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { total, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            else
            {
                materialPrecioTotal = new PdfPCell(new Phrase("DURANTE ESTE MANTENIMIENTO NO SE ORDENARON MATERIALES", negrita));
                materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                materialPrecioTotal.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { materialPrecioTotal, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            #endregion

            #region Costo en pesos
            headerCostoMantenimiento = new PdfPCell(new Phrase("COSTO DE MANTENIMIENTO EN PESOS", negritasBlanca));
            headerCostoMantenimiento.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.VerticalAlignment = Element.ALIGN_CENTER;
            headerCostoMantenimiento.BackgroundColor = new BaseColor(16, 5, 92);
            headerCostoMantenimiento.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerCostoMantenimiento, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerNumeroParte = new PdfPCell(new Phrase("REQUISICION", negrita));
            headerNumeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerNumeroParte.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialDescripcion = new PdfPCell(new Phrase("DESCRIPCION", negrita));
            headerMaterialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialDescripcion.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialSolicitante = new PdfPCell(new Phrase("SOLICITADO POR", negrita));
            headerMaterialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialSolicitante.BackgroundColor = BaseColor.LIGHT_GRAY;

            headerMaterialPrecioTotal = new PdfPCell(new Phrase("PRECIO TOTAL", negrita));
            headerMaterialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            headerMaterialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerMaterialPrecioTotal.BackgroundColor = BaseColor.LIGHT_GRAY;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNumeroParte, headerMaterialDescripcion, headerMaterialSolicitante, headerMaterialPrecioTotal });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            materialesMantenimiento = materialProyecto.SeleccionarMaterialMantenimiento(Convert.ToInt32(mantenimiento.Fila().Celda("id")), "MXN");

            if (materialesMantenimiento.Count > 0)
            {
                double sumaTotal = 0.0;
                materialesMantenimiento.ForEach(delegate(Fila filaMaterial)
                {
                    numeroParte = new PdfPCell(new Phrase(filaMaterial.Celda("id").ToString(), normal));
                    numeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                    numeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;

                    string strDescripcion = "NUMERO DE PARTE: " + Global.ObjetoATexto(filaMaterial.Celda("numero_parte"), "N/A") + Environment.NewLine + Environment.NewLine + Global.ObjetoATexto(filaMaterial.Celda("descripcion"), "N/A")
                        + Environment.NewLine + Environment.NewLine + "CANTIDAD REQUERIDA: " + filaMaterial.Celda("piezas_requeridas");

                    materialDescripcion = new PdfPCell(new Phrase(strDescripcion, normal));
                    materialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;

                    materialSolicitante = new PdfPCell(new Phrase(Global.ObjetoATexto(filaMaterial.Celda("requisitor"), "N/A"), normal));
                    materialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;


                    double precio = Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0"));

                    materialPrecioTotal = new PdfPCell(new Phrase(String.Format("{0:C}", precio) + " " + filaMaterial.Celda("precio_moneda"), normal));
                    materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
               

                    sumaTotal += Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0.0"));

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { numeroParte, materialDescripcion, materialSolicitante, materialPrecioTotal });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                });

                total = new PdfPCell(new Phrase("COSTO TOTAL: " + String.Format("{0:C}", sumaTotal) + " MXN", negrita));
                total.HorizontalAlignment = Element.ALIGN_CENTER;
                total.VerticalAlignment = Element.ALIGN_MIDDLE;
                total.BorderColorTop = BaseColor.WHITE;
                total.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { total, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            else
            {
                materialPrecioTotal = new PdfPCell(new Phrase("DURANTE ESTE MANTENIMIENTO NO SE ORDENARON MATERIALES", negrita));
                materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                materialPrecioTotal.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { materialPrecioTotal, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }
            #endregion


            #endregion

            ptablaPrincipalPerfilUsuario.Add(tablaPerfilUsuario);
            doc.Add(ptablaPrincipalPerfilUsuario);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] HistorialMantenimiento(int idEquipo, string tipoEquipo, string tipoMantenimiento, List<Fila> EquipoFilas)
        {
           
            if(EquipoFilas.Count <= 0)
                return null;

            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.CargarHistorialMantenimientoEquipo(tipoMantenimiento, tipoEquipo, idEquipo);
            if (!mantenimiento.TieneFilas())
                return null;

            Usuario usuario = new Usuario();
            CheckitemsMantenimiento listaMantenimiento = new CheckitemsMantenimiento();
            MantenimientoTopico topicos = new MantenimientoTopico();
            ActividadMantenimiento actividadMantenimiento = new ActividadMantenimiento();   
            OrdenTrabajoMantenimiento ordenTrabajo = new OrdenTrabajoMantenimiento();
            MaterialProyecto materialProyecto = new MaterialProyecto();

            byte[] datosPDF;
            string strUltimoMantenimiento = string.Empty;
            string strNumeroSerie = string.Empty;
            string strResponsableMantenimiento = string.Empty;
            string strSolicitado = string.Empty;

            EquipoFilas.ForEach(delegate(Fila f)
            {
                strNumeroSerie = Global.ObjetoATexto(f.Celda("numero_serie"), "N/A");
                strUltimoMantenimiento = Global.FechaATexto(f.Celda("ultimo_mantenimiento"));
                strResponsableMantenimiento = Global.ObjetoATexto(f.Celda("responsable_mantenimiento"), "N/A");
            });

            #region inicializar PDF

            #region Fuentes
            Font tituloH1 = FontFactory.GetFont("Calibri", 12, 1, BaseColor.BLACK);
            Font tituloH2 = FontFactory.GetFont("Calibri", 10, 1, BaseColor.BLACK);
            Font normal = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negritasBlanca = FontFactory.GetFont("Calibri", 8, 1, BaseColor.WHITE);

            #endregion

            // Crea el archivo temporal
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(144, 56);
            logo.SpacingAfter = 10;
            logo.SpacingBefore = 5;

            #endregion

            //TABLA PRINCIPAL
            #region Tabla principal
            //crear espacio de la tabla
            Paragraph ptablaPrincipalPerfilUsuario = new Paragraph();
            ptablaPrincipalPerfilUsuario.SpacingBefore = 5;

            //inicializar tabla
            PdfPTable tablaPerfilUsuario = new PdfPTable(4);
            tablaPerfilUsuario.WidthPercentage = 100;
            tablaPerfilUsuario.SpacingBefore = 5;

            int[] intTblWidthIsometrico = { 25, 25, 25, 25 };
            tablaPerfilUsuario.SetWidths(intTblWidthIsometrico);

            PdfPCell columna1 = new PdfPCell();
            PdfPCell columna2 = new PdfPCell();
            PdfPCell columna3 = new PdfPCell();
            PdfPCell columna4 = new PdfPCell();


            PdfPRow rowInformacionGeneral = new PdfPRow(new PdfPCell[] { columna1, columna2, columna3, columna4 });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            #endregion

            //Declaración de celdas
            #region Celdas
            PdfPCell perfilLogo;
            PdfPCell titulo;
            PdfPCell tipoEquipoCelda;
            PdfPCell equipoCelda;
            PdfPCell tipoEquipoResultado;
            PdfPCell equipoResultadoCelda;
            PdfPCell tipoEquipos;
            PdfPCell resultadoTipoEquipos;
            PdfPCell descripcionCelda;
            PdfPCell headerComentarios;
            PdfPCell celdaTopicos;
            PdfPCell celdaEstatus;
            PdfPCell resultadoEspacio1;
            PdfPCell espacio1;
            PdfPCell espacio2;
            PdfPCell celdaAccion;
            PdfPCell celdaComentariosAccion;
            PdfPCell comentariosCelda;
            PdfPCell headerCostoMantenimiento;
            PdfPCell headerNumeroParte;
            PdfPCell headerMaterialDescripcion;
            PdfPCell headerMaterialPrecioTotal;
            PdfPCell headerMaterialSolicitante;
            PdfPCell materialSolicitante;
            PdfPCell numeroParte;
            PdfPCell materialDescripcion;
            PdfPCell materialPrecioTotal;
            PdfPCell total;

            #endregion

            #region Contenido de celdas

            perfilLogo = new PdfPCell(logo);
            perfilLogo.HorizontalAlignment = Element.ALIGN_CENTER;
            perfilLogo.VerticalAlignment = Element.ALIGN_CENTER;
            perfilLogo.ExtraParagraphSpace = 1;
            perfilLogo.Colspan = 2;

            titulo = new PdfPCell(new Phrase("HISTORIAL DE MANTENIMIENTO", tituloH1));
            titulo.HorizontalAlignment = Element.ALIGN_CENTER;
            titulo.VerticalAlignment = Element.ALIGN_MIDDLE;
            titulo.Colspan = 2;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { perfilLogo, null, titulo, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            tipoEquipoCelda = new PdfPCell(new Phrase("TIPO DE MANTENIMIENTO", negrita));
            tipoEquipoCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            tipoEquipoCelda.VerticalAlignment = Element.ALIGN_RIGHT;

            string strTitulo = "";
            if (tipoMantenimiento == "TODOS")
                strTitulo = "PREVENTIVO Y CORRECTIVO";
            else
                strTitulo = tipoMantenimiento;

            tipoEquipoResultado = new PdfPCell(new Phrase(strTitulo, negrita));
            tipoEquipoResultado.HorizontalAlignment = Element.ALIGN_LEFT;
            tipoEquipoResultado.VerticalAlignment = Element.ALIGN_LEFT;

            tipoEquipos = new PdfPCell(new Phrase("TIPO DE EQUIPO", negrita));
            tipoEquipos.HorizontalAlignment = Element.ALIGN_RIGHT;
            tipoEquipos.VerticalAlignment = Element.ALIGN_RIGHT;

            resultadoTipoEquipos = new PdfPCell(new Phrase(tipoEquipo.ToUpper(), negrita));
            resultadoTipoEquipos.HorizontalAlignment = Element.ALIGN_LEFT;
            resultadoTipoEquipos.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { tipoEquipoCelda, tipoEquipoResultado, tipoEquipos, resultadoTipoEquipos });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            equipoCelda = new PdfPCell(new Phrase("EQUIPO", negrita));
            equipoCelda.HorizontalAlignment = Element.ALIGN_RIGHT;
            equipoCelda.VerticalAlignment = Element.ALIGN_RIGHT;

            string strEquipo = idEquipo.ToString() + " - " + Global.ObjetoATexto(strNumeroSerie, "N/A");


            equipoResultadoCelda = new PdfPCell(new Phrase(strEquipo, negrita));
            equipoResultadoCelda.HorizontalAlignment = Element.ALIGN_LEFT;
            equipoResultadoCelda.VerticalAlignment = Element.ALIGN_LEFT;

            espacio1 = new PdfPCell(new Phrase("FECHA DEL ULTIMO MANTENIMIENTO", negrita));
            espacio1.HorizontalAlignment = Element.ALIGN_RIGHT;
            espacio1.VerticalAlignment = Element.ALIGN_RIGHT;

            resultadoEspacio1 = new PdfPCell(new Phrase(strUltimoMantenimiento, negrita));
            resultadoEspacio1.HorizontalAlignment = Element.ALIGN_LEFT;
            resultadoEspacio1.VerticalAlignment = Element.ALIGN_LEFT;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { equipoCelda, equipoResultadoCelda, espacio1, resultadoEspacio1 });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            headerComentarios = new PdfPCell(new Phrase("HISTORIAL DE MANTENIMIENTO", negritasBlanca));
            headerComentarios.HorizontalAlignment = Element.ALIGN_CENTER;
            headerComentarios.VerticalAlignment = Element.ALIGN_CENTER;
            headerComentarios.BackgroundColor = new BaseColor(16, 5, 92);
            headerComentarios.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerComentarios, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            string descripcion = "EN EL PRESENTE DOCUMENTO SE ENLISTAN LAS ESPECIFICACIONES DE LOS MANTENIMIENTOS " + strTitulo  + " CONFORME A LA FECHA DE REALIZACION DEL MANTENIMIENTO:" + Environment.NewLine + Environment.NewLine;

            descripcionCelda = new PdfPCell(new Phrase(descripcion, normal));
            descripcionCelda.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            descripcionCelda.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { descripcionCelda, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            string fechaMantenimientoActividad = "";

            //Cargamos los mantenimientos en un ciclo
            mantenimiento.CargarHistorialMantenimientoEquipo(tipoMantenimiento, tipoEquipo, idEquipo).ForEach(delegate(Fila f) //SeleccionarMantenimientoSinEstatus
            {
                fechaMantenimientoActividad = Global.FechaATexto(f.Celda("fecha"));

                comentariosCelda = new PdfPCell(new Phrase("MANTENIMIENTO " + f.Celda("tipo_mantenimiento").ToString() + ". FECHA: " + fechaMantenimientoActividad, negrita));
                comentariosCelda.HorizontalAlignment = Element.ALIGN_CENTER;
                comentariosCelda.VerticalAlignment = Element.ALIGN_CENTER;
                comentariosCelda.Colspan = 4;
                comentariosCelda.ExtraParagraphSpace = 3;
                comentariosCelda.BackgroundColor = BaseColor.LIGHT_GRAY;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { comentariosCelda, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

                celdaTopicos = new PdfPCell(new Phrase("PUNTO DE REVISION", negrita));
                celdaTopicos.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaTopicos.VerticalAlignment = Element.ALIGN_CENTER;
                celdaTopicos.BackgroundColor = BaseColor.LIGHT_GRAY;

                celdaEstatus = new PdfPCell(new Phrase("ESTATUS", negrita));
                celdaEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaEstatus.VerticalAlignment = Element.ALIGN_CENTER;
                celdaEstatus.BackgroundColor = BaseColor.LIGHT_GRAY;

                celdaAccion = new PdfPCell(new Phrase("ACCION TOMADA", negrita));
                celdaAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaAccion.VerticalAlignment = Element.ALIGN_CENTER;
                celdaAccion.BackgroundColor = BaseColor.LIGHT_GRAY;

                celdaComentariosAccion = new PdfPCell(new Phrase("COMENTARIOS", negrita));
                celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;
                celdaComentariosAccion.BackgroundColor = BaseColor.LIGHT_GRAY;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaTopicos, celdaEstatus, celdaComentariosAccion, celdaAccion });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

                int topicoCount = 0;
                string actividad = "";
                string comentarios = "";
                string strTopicos = "";
                string estatus = "";

                if (f.Celda("tipo_mantenimiento").ToString() == "PREVENTIVO")
                {
                    List<Fila> mantenimientoLista = listaMantenimiento.CargarMantenimiento(Convert.ToInt32(mantenimiento.Fila().Celda("id")));
                    if (mantenimientoLista.Count > 0)
                    {
                        mantenimientoLista.ForEach(delegate(Fila filaPreventivo)
                        {
                            actividad = "N/A";
                            object objAccionTomada = filaPreventivo.Celda("accion_tomada");
                            if (objAccionTomada != null)
                                actividad = objAccionTomada.ToString();

                            comentarios = "N/A";
                            object objComentarios = filaPreventivo.Celda("comentarios");
                            if (objComentarios != null)
                                comentarios = objComentarios.ToString();

                            estatus = filaPreventivo.Celda("estatus").ToString();

                            topicoCount++;
                            topicos.CargarDatos(Convert.ToInt32(filaPreventivo.Celda("topico")));
                            strTopicos = topicoCount + " -. " + topicos.Fila().Celda("topico").ToString();

                            celdaTopicos = new PdfPCell(new Phrase(strTopicos, normal));
                            celdaTopicos.HorizontalAlignment = Element.ALIGN_LEFT;
                            celdaTopicos.VerticalAlignment = Element.ALIGN_LEFT;

                            celdaEstatus = new PdfPCell(new Phrase(estatus, normal));
                            celdaEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
                            celdaEstatus.VerticalAlignment = Element.ALIGN_CENTER;

                            celdaAccion = new PdfPCell(new Phrase(actividad, normal));
                            celdaAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                            celdaAccion.VerticalAlignment = Element.ALIGN_CENTER;

                            celdaComentariosAccion = new PdfPCell(new Phrase(comentarios, normal));
                            celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                            celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;

                            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaTopicos, celdaEstatus, celdaComentariosAccion, celdaAccion });
                            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                        });
                    }
                    else
                    {
                        celdaComentariosAccion = new PdfPCell(new Phrase("NO EXISTE UN PLAN DE MANTENIMIENTO", normal));
                        celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                        celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;
                        celdaComentariosAccion.Colspan = 4;

                        rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaComentariosAccion, null, null, null });
                        tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                    }
                }

                if (f.Celda("tipo_mantenimiento").ToString() == "CORRECTIVO")
                {
                    string a = mantenimiento.Fila().Celda("id").ToString();
                    List<Fila> ListaCorrectivo = actividadMantenimiento.CargarActividades(Convert.ToInt32(mantenimiento.Fila().Celda("id")));
                    if (ListaCorrectivo.Count > 0)
                    {
                        ListaCorrectivo.ForEach(delegate(Fila filaCorrectivo)
                        {
                            topicoCount++;
                            actividad += topicoCount + " -. " + filaCorrectivo.Celda("actividad").ToString() + Environment.NewLine;
                            comentarios += filaCorrectivo.Celda("comentarios").ToString() + Environment.NewLine;
                        });
                    }

                    if (actividad == "")
                        actividad = "SIN ACTIVIDADES";

                    ordenTrabajo.CargarDatos(Convert.ToInt32(f.Celda("orden_trabajo")));
                    strTopicos = ordenTrabajo.Fila().Celda("puntos_reparacion").ToString();
                    estatus = ordenTrabajo.Fila().Celda("estatus").ToString();

                    celdaTopicos = new PdfPCell(new Phrase(strTopicos, normal));
                    celdaTopicos.HorizontalAlignment = Element.ALIGN_LEFT;
                    celdaTopicos.VerticalAlignment = Element.ALIGN_LEFT;

                    celdaEstatus = new PdfPCell(new Phrase(estatus, normal));
                    celdaEstatus.HorizontalAlignment = Element.ALIGN_CENTER;
                    celdaEstatus.VerticalAlignment = Element.ALIGN_CENTER;

                    celdaAccion = new PdfPCell(new Phrase(actividad, normal));
                    celdaAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                    celdaAccion.VerticalAlignment = Element.ALIGN_CENTER;

                    celdaComentariosAccion = new PdfPCell(new Phrase(comentarios, normal));
                    celdaComentariosAccion.HorizontalAlignment = Element.ALIGN_CENTER;
                    celdaComentariosAccion.VerticalAlignment = Element.ALIGN_CENTER;

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { celdaTopicos, celdaEstatus, celdaComentariosAccion, celdaAccion });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

                    
                }

                #region Costo en dolares
                headerCostoMantenimiento = new PdfPCell(new Phrase("COSTO DE MANTENIMIENTO EN DOLARES", negritasBlanca));
                headerCostoMantenimiento.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCostoMantenimiento.VerticalAlignment = Element.ALIGN_CENTER;
                headerCostoMantenimiento.BackgroundColor = new BaseColor(16, 5, 92);
                headerCostoMantenimiento.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerCostoMantenimiento, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

                headerNumeroParte = new PdfPCell(new Phrase("REQUISICION", negrita));
                headerNumeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                headerNumeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;
                headerNumeroParte.BackgroundColor = BaseColor.LIGHT_GRAY;

                headerMaterialDescripcion = new PdfPCell(new Phrase("DESCRIPCION", negrita));
                headerMaterialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                headerMaterialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;
                headerMaterialDescripcion.BackgroundColor = BaseColor.LIGHT_GRAY;

                headerMaterialSolicitante = new PdfPCell(new Phrase("SOLICITADO POR", negrita));
                headerMaterialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                headerMaterialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
                headerMaterialSolicitante.BackgroundColor = BaseColor.LIGHT_GRAY;

                headerMaterialPrecioTotal = new PdfPCell(new Phrase("PRECIO TOTAL", negrita));
                headerMaterialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                headerMaterialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                headerMaterialPrecioTotal.BackgroundColor = BaseColor.LIGHT_GRAY;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNumeroParte, headerMaterialDescripcion, headerMaterialSolicitante, headerMaterialPrecioTotal });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);


                List<Fila> materialesMantenimiento = materialProyecto.SeleccionarMaterialMantenimiento(Convert.ToInt32(f.Celda("id")), "USD");

                if (materialesMantenimiento.Count > 0)
                {
                    double sumaTotal = 0.0;
                    materialesMantenimiento.ForEach(delegate(Fila filaMaterial)
                    {
                        numeroParte = new PdfPCell(new Phrase(filaMaterial.Celda("id").ToString(), normal));
                        numeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                        numeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;

                        string strDescripcion = "NUMERO DE PARTE: " + Global.ObjetoATexto(filaMaterial.Celda("numero_parte"), "N/A") + Environment.NewLine + Environment.NewLine + Global.ObjetoATexto(filaMaterial.Celda("descripcion"), "N/A")
                        + Environment.NewLine + Environment.NewLine + "CANTIDAD REQUERIDA: " + filaMaterial.Celda("piezas_requeridas");

                        materialDescripcion = new PdfPCell(new Phrase(strDescripcion, normal));
                        materialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                        materialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;

                        materialSolicitante = new PdfPCell(new Phrase(Global.ObjetoATexto(filaMaterial.Celda("requisitor"), "N/A"), normal));
                        materialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                        materialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;

                        double precio = Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0"));

                        materialPrecioTotal = new PdfPCell(new Phrase(String.Format("{0:C}", precio) + " " + filaMaterial.Celda("precio_moneda"), normal));
                        materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                        materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;

                        sumaTotal += Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0.0"));

                        rowInformacionGeneral = new PdfPRow(new PdfPCell[] { numeroParte, materialDescripcion, materialSolicitante, materialPrecioTotal });
                        tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                    });

                    total = new PdfPCell(new Phrase("COSTO TOTAL: " + String.Format("{0:C}", sumaTotal) + " USD", negrita));
                    total.HorizontalAlignment = Element.ALIGN_CENTER;
                    total.VerticalAlignment = Element.ALIGN_MIDDLE;
                    total.BorderColorTop = BaseColor.WHITE;
                    total.Colspan = 4;

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { total, null, null, null });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

                }
                else
                {
                    materialPrecioTotal = new PdfPCell(new Phrase("DURANTE ESTE MANTENIMIENTO NO SE ORDENARON MATERIALES", negrita));
                    materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                    materialPrecioTotal.Colspan = 4;

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { materialPrecioTotal, null, null, null });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                }

                #endregion

                #region Costo en pesos
                headerCostoMantenimiento = new PdfPCell(new Phrase("COSTO DE MANTENIMIENTO EN PESOS", negritasBlanca));
                headerCostoMantenimiento.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCostoMantenimiento.VerticalAlignment = Element.ALIGN_CENTER;
                headerCostoMantenimiento.BackgroundColor = new BaseColor(16, 5, 92);
                headerCostoMantenimiento.Colspan = 4;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerCostoMantenimiento, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

                headerNumeroParte = new PdfPCell(new Phrase("REQUISICION", negrita));
                headerNumeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                headerNumeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;
                headerNumeroParte.BackgroundColor = BaseColor.LIGHT_GRAY;

                headerMaterialDescripcion = new PdfPCell(new Phrase("DESCRIPCION", negrita));
                headerMaterialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                headerMaterialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;
                headerMaterialDescripcion.BackgroundColor = BaseColor.LIGHT_GRAY;

                headerMaterialSolicitante = new PdfPCell(new Phrase("SOLICITADO POR", negrita));
                headerMaterialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                headerMaterialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;
                headerMaterialSolicitante.BackgroundColor = BaseColor.LIGHT_GRAY;

                headerMaterialPrecioTotal = new PdfPCell(new Phrase("PRECIO TOTAL", negrita));
                headerMaterialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                headerMaterialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                headerMaterialPrecioTotal.BackgroundColor = BaseColor.LIGHT_GRAY;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNumeroParte, headerMaterialDescripcion, headerMaterialSolicitante, headerMaterialPrecioTotal });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);


                materialesMantenimiento = materialProyecto.SeleccionarMaterialMantenimiento(Convert.ToInt32(f.Celda("id")), "MXN");

                if (materialesMantenimiento.Count > 0)
                {
                    double sumaTotal = 0.0;
                    materialesMantenimiento.ForEach(delegate(Fila filaMaterial)
                    {
                        numeroParte = new PdfPCell(new Phrase(filaMaterial.Celda("id").ToString(), normal));
                        numeroParte.HorizontalAlignment = Element.ALIGN_CENTER;
                        numeroParte.VerticalAlignment = Element.ALIGN_MIDDLE;

                        string strDescripcion = "NUMERO DE PARTE: " + Global.ObjetoATexto(filaMaterial.Celda("numero_parte"), "N/A") + Environment.NewLine + Environment.NewLine + Global.ObjetoATexto(filaMaterial.Celda("descripcion"), "N/A")
                        + Environment.NewLine + Environment.NewLine + "CANTIDAD REQUERIDA: " + filaMaterial.Celda("piezas_requeridas");

                        materialDescripcion = new PdfPCell(new Phrase(strDescripcion, normal));
                        materialDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                        materialDescripcion.VerticalAlignment = Element.ALIGN_MIDDLE;

                        materialSolicitante = new PdfPCell(new Phrase(Global.ObjetoATexto(filaMaterial.Celda("requisitor"), "N/A"), normal));
                        materialSolicitante.HorizontalAlignment = Element.ALIGN_CENTER;
                        materialSolicitante.VerticalAlignment = Element.ALIGN_MIDDLE;

                        double precio = Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0"));

                        materialPrecioTotal = new PdfPCell(new Phrase(String.Format("{0:C}", precio) + " " + filaMaterial.Celda("precio_moneda"), normal));
                        materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                        materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;

                        sumaTotal += Convert.ToDouble(Global.ObjetoATexto(filaMaterial.Celda("precio_suma_final"), "0.0"));

                        rowInformacionGeneral = new PdfPRow(new PdfPCell[] { numeroParte, materialDescripcion, materialSolicitante, materialPrecioTotal });
                        tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                    });

                    total = new PdfPCell(new Phrase("COSTO TOTAL: " + String.Format("{0:C}", sumaTotal) + " MXN", negrita));
                    total.HorizontalAlignment = Element.ALIGN_CENTER;
                    total.VerticalAlignment = Element.ALIGN_MIDDLE;
                    total.BorderColorTop = BaseColor.WHITE;
                    total.Colspan = 4;

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { total, null, null, null });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

                }
                else
                {
                    materialPrecioTotal = new PdfPCell(new Phrase("DURANTE ESTE MANTENIMIENTO NO SE ORDENARON MATERIALES", negrita));
                    materialPrecioTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    materialPrecioTotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                    materialPrecioTotal.Colspan = 4;

                    rowInformacionGeneral = new PdfPRow(new PdfPCell[] { materialPrecioTotal, null, null, null });
                    tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                }

                #endregion

            });
                
           
            espacio2 = new PdfPCell(new Phrase("EL HISTORIAL DE MANTENIMIENTO GARANTIZA EL CORRECTO FUNCIONAMIENTO DEL EQUIPO " + strEquipo, normal));
            espacio2.HorizontalAlignment = Element.ALIGN_LEFT;
            espacio2.VerticalAlignment = Element.ALIGN_LEFT;
            espacio2.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { espacio2, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                #endregion 

            ptablaPrincipalPerfilUsuario.Add(tablaPerfilUsuario);
            doc.Add(ptablaPrincipalPerfilUsuario);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            return datosPDF;
        }

        public static byte[] ValeSalidaPiezasATratamiento( List<int> idProceso, string strProveedor, int idVale)
        {
            #region inicializar PDF

            #region Fuentes
            Font tituloH1 = FontFactory.GetFont("Calibri", 12, 1, BaseColor.BLACK);
            Font tituloH2 = FontFactory.GetFont("Calibri", 10, 1, BaseColor.BLACK);
            Font normal = FontFactory.GetFont("Calibri", 8, BaseColor.BLACK);
            Font negrita = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
            Font negritasBlanca = FontFactory.GetFont("Calibri", 8, 1, BaseColor.WHITE);
            Font normalChica = FontFactory.GetFont("Calibri", 6, BaseColor.BLACK);

            #endregion

            // Crea el archivo temporal
            byte[] datosPDF;
            string nombreArchivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            FileStream fs = new FileStream(nombreArchivo + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            // Agregar logo
            Image logo = Image.GetInstance(CB_Base.Properties.Resources.Logo_Audisel_sa_de_cv_white, BaseColor.WHITE);
            logo.ScaleToFit(140, 52);
            logo.SpacingAfter = 10;
            logo.SpacingBefore = 5;

            #endregion

            //TABLA header
            #region NestedTable
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            int[] intRow = { 7, 7 };
            table.SetWidths(intRow);

            table.DefaultCell.MinimumHeight = 7;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.DefaultCell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(new Phrase("DEPARTAMENTO", negrita));
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(new Phrase("CALIDAD", normal));

            table.DefaultCell.MinimumHeight = 7;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.DefaultCell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(new Phrase("CODIGO", negrita));
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(new Phrase("CAL-FO-800", normal));

            table.DefaultCell.MinimumHeight = 7;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.DefaultCell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(new Phrase("ELABORADO POR", negrita));
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(new Phrase("SERGIO CAZARES", normal));

            table.DefaultCell.MinimumHeight = 7;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.DefaultCell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(new Phrase("REVISADO POR", negrita));
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(new Phrase("PABLO HOLGUIN", normal));

            table.DefaultCell.MinimumHeight = 7;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.DefaultCell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(new Phrase("AUTORIZADO POR", negrita));
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(new Phrase("RAUL HOLGUIN", normal));

            table.DefaultCell.MinimumHeight = 7;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BackgroundColor = BaseColor.WHITE;
            table.DefaultCell.Colspan = 2;
            table.AddCell(new Phrase("Copia impresa sin control de revisión", normalChica));
            
            Paragraph ptablaPrincipalHeader = new Paragraph();
            ptablaPrincipalHeader.SpacingBefore = 5;

            //inicializar tabla
            PdfPTable tablaPerfilHeader = new PdfPTable(3);
            tablaPerfilHeader.WidthPercentage = 100;
            tablaPerfilHeader.SpacingBefore = 5;

            int[] intTblWidthHeader = { 33, 33, 33 };
            tablaPerfilHeader.SetWidths(intTblWidthHeader);

            PdfPCell headerlogo = new PdfPCell(logo);
            headerlogo.HorizontalAlignment = Element.ALIGN_CENTER;
            headerlogo.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell nombreVale = new PdfPCell(new Phrase("VALE DE SALIDA DE PIEZAS A TRATAMIENTO", tituloH1));
            nombreVale.HorizontalAlignment = Element.ALIGN_CENTER;
            nombreVale.VerticalAlignment = Element.ALIGN_CENTER;

            PdfPCell nested = new PdfPCell(table);
            nested.HorizontalAlignment = Element.ALIGN_CENTER;
            nested.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPRow rowInformacionHeader = new PdfPRow(new PdfPCell[] { headerlogo, nombreVale, nested });
            tablaPerfilHeader.Rows.Add(rowInformacionHeader);
            #endregion

            //TABLA PRINCIPAL
            #region Tabla principal
            //crear espacio de la tabla
            Paragraph ptablaPrincipalPerfilUsuario = new Paragraph();
            ptablaPrincipalPerfilUsuario.SpacingBefore = 5;

            //inicializar tabla
            PdfPTable tablaPerfilUsuario = new PdfPTable(6);
            tablaPerfilUsuario.WidthPercentage = 100;
            tablaPerfilUsuario.SpacingBefore = 5;

            int[] intTblWidthIsometrico = { 10, 13, 20, 20, 25, 25};
            tablaPerfilUsuario.SetWidths(intTblWidthIsometrico);
            PdfPRow rowInformacionGeneral;

            PdfPCell headerNumeroVale = new PdfPCell(new Phrase("NUMERO DE VALE", negrita));
            headerNumeroVale.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroVale.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumeroVale.Colspan = 2;

            PdfPCell numeroVale = new PdfPCell(new Phrase(idVale.ToString().PadLeft(4,'0'), normal));
            numeroVale.HorizontalAlignment = Element.ALIGN_CENTER;
            numeroVale.HorizontalAlignment = Element.ALIGN_CENTER;
            numeroVale.Colspan = 2;

            PdfPCell headerFechaHora = new PdfPCell(new Phrase("FECHA Y HORA", negrita));
            headerFechaHora.HorizontalAlignment = Element.ALIGN_CENTER;
            headerFechaHora.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell fechaHora = new PdfPCell(new Phrase(Global.FechaATexto(DateTime.Now), normal));
            fechaHora.HorizontalAlignment = Element.ALIGN_CENTER;
            fechaHora.HorizontalAlignment = Element.ALIGN_CENTER;
            fechaHora.Colspan = 1;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerNumeroVale, null, numeroVale,null ,headerFechaHora , fechaHora });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            PdfPCell headerProveedor = new PdfPCell(new Phrase("PROVEEDOR", negrita));
            headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProveedor.Colspan = 2;

            PdfPCell proveedor = new PdfPCell(new Phrase(strProveedor.Split('-')[1].TrimStart(), normal));
            proveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            proveedor.Colspan = 4;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerProveedor, null, proveedor, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            PdfPCell colPiezasAluminio = new PdfPCell(new Phrase("PIEZAS DE ALUMINIO", negritasBlanca));
            colPiezasAluminio.HorizontalAlignment = Element.ALIGN_CENTER;
            colPiezasAluminio.HorizontalAlignment = Element.ALIGN_CENTER;
            colPiezasAluminio.BackgroundColor = BaseColor.BLACK;
            colPiezasAluminio.Colspan = 6;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { colPiezasAluminio, null, null, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            PdfPCell headerId = new PdfPCell();
            headerId.BackgroundColor = BaseColor.BLACK;

            PdfPCell headerCantidad = new PdfPCell(new Phrase("CANTIDAD", negritasBlanca));
            headerCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidad.BackgroundColor = BaseColor.BLACK;

            PdfPCell headerNumParte = new PdfPCell(new Phrase("ID PLANO", negritasBlanca));
            headerNumParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumParte.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumParte.BackgroundColor = BaseColor.BLACK;

            PdfPCell headerPlano = new PdfPCell(new Phrase("PLANO", negritasBlanca));
            headerPlano.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPlano.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPlano.BackgroundColor = BaseColor.BLACK;

            PdfPCell headerRequisicion = new PdfPCell(new Phrase("REQUISICIÓN DE COMPRA", negritasBlanca));
            headerRequisicion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRequisicion.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRequisicion.BackgroundColor = BaseColor.BLACK;

            PdfPCell headerProceso = new PdfPCell(new Phrase("PROCESO DE TRATAMIENTO", negritasBlanca));
            headerProceso.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProceso.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProceso.BackgroundColor = BaseColor.BLACK;


            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerId, headerCantidad, headerNumParte, headerPlano, headerRequisicion, headerProceso });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            PdfPCell idItem = new PdfPCell();
            PdfPCell cantidad = new PdfPCell();
            PdfPCell idPlano = new PdfPCell();
            PdfPCell nombrePlano = new PdfPCell();
            PdfPCell requisicion = new PdfPCell();
            PdfPCell numProceso = new PdfPCell();
            PlanoProceso proceso = new PlanoProceso();

            int piezasAluminio = 1;
            int piezasAcero = 1;
            bool tienePiezasAluminio = false;
            bool tienePiezasAcero = false;

            foreach (int item in idProceso)
            {
                proceso.BuscarCategoriaMaterial(item, "PENDIENTE").ForEach(delegate(Fila f)
                {
                    if (Global.ObjetoATexto(f.Celda("categoria"), "") == "ALUMINIO")
                    {
                        idItem = new PdfPCell(new Phrase("I" + piezasAluminio, normal));
                        idItem.HorizontalAlignment = Element.ALIGN_CENTER;
                        idItem.VerticalAlignment = Element.ALIGN_CENTER;

                        cantidad = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("cantidad"), ""), normal));
                        cantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                        cantidad.VerticalAlignment = Element.ALIGN_CENTER;

                        idPlano = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("idPlano"), ""), normal));
                        idPlano.HorizontalAlignment = Element.ALIGN_CENTER;
                        idPlano.VerticalAlignment = Element.ALIGN_CENTER;

                        nombrePlano = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("nombre_archivo"), ""), normal));
                        nombrePlano.HorizontalAlignment = Element.ALIGN_CENTER;
                        nombrePlano.VerticalAlignment = Element.ALIGN_CENTER;

                        requisicion = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("requisicion_compra"), ""), normal));
                        requisicion.HorizontalAlignment = Element.ALIGN_CENTER;
                        requisicion.VerticalAlignment = Element.ALIGN_CENTER;

                        numProceso = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("idProceso"), "") + " - " + Global.ObjetoATexto(f.Celda("proceso"),""), normal));
                        numProceso.HorizontalAlignment = Element.ALIGN_CENTER;
                        numProceso.VerticalAlignment = Element.ALIGN_CENTER;

                        piezasAluminio++;
                        rowInformacionGeneral = new PdfPRow(new PdfPCell[] { idItem, cantidad, idPlano, nombrePlano, requisicion, numProceso });
                        tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                        tienePiezasAluminio = true;
                    }
                });
            }

            if(!tienePiezasAluminio)
            {
                PdfPCell sinPiezas= new PdfPCell(new Phrase("SIN PIEZAS DE ALUMINIO", normal));
                sinPiezas.HorizontalAlignment = Element.ALIGN_CENTER;
                sinPiezas.VerticalAlignment = Element.ALIGN_CENTER;
                sinPiezas.Colspan = 6;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { sinPiezas, null, null, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }

            PdfPCell colPiezasAcero = new PdfPCell(new Phrase("PIEZAS DE ACERO", negritasBlanca));
            colPiezasAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            colPiezasAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            colPiezasAcero.BackgroundColor = BaseColor.BLACK;
            colPiezasAcero.Colspan = 6;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { colPiezasAcero, null, null, null, null, null });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);

            PdfPCell headerIdAcero = new PdfPCell();
            headerIdAcero.BackgroundColor = BaseColor.BLACK;
            

            PdfPCell headerCantidadAcero = new PdfPCell(new Phrase("CANTIDAD", negritasBlanca));
            headerCantidadAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidadAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerCantidadAcero.BackgroundColor = BaseColor.BLACK;

            PdfPCell headerNumParteAcero = new PdfPCell(new Phrase("ID PLANO", negritasBlanca));
            headerNumParteAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumParteAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerNumParteAcero.BackgroundColor = BaseColor.BLACK;

            PdfPCell headerPlanoAcero = new PdfPCell(new Phrase("PLANO", negritasBlanca));
            headerPlanoAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPlanoAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerPlanoAcero.BackgroundColor = BaseColor.BLACK;

            PdfPCell headerRequisicionAcero = new PdfPCell(new Phrase("REQUISICIÓN DE COMPRA", negritasBlanca));
            headerRequisicionAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRequisicionAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRequisicionAcero.BackgroundColor = BaseColor.BLACK;

            PdfPCell headerProcesoAcero = new PdfPCell(new Phrase("PROCESO DE TRATAMIENTO", negritasBlanca));
            headerProcesoAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProcesoAcero.HorizontalAlignment = Element.ALIGN_CENTER;
            headerProcesoAcero.BackgroundColor = BaseColor.BLACK;

            rowInformacionGeneral = new PdfPRow(new PdfPCell[] { headerIdAcero, headerCantidadAcero, headerNumParteAcero, headerPlanoAcero, headerRequisicionAcero, headerProcesoAcero });
            tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
 

            foreach (int item in idProceso)
            {
                proceso.BuscarCategoriaMaterial(item, "PENDIENTE").ForEach(delegate(Fila f)
                {
                    if (Global.ObjetoATexto(f.Celda("categoria"), "") == "ACERO")
                    {
                        idItem = new PdfPCell(new Phrase("I" + piezasAcero, normal));
                        idItem.HorizontalAlignment = Element.ALIGN_CENTER;
                        idItem.VerticalAlignment = Element.ALIGN_CENTER;

                        cantidad = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("cantidad"), ""), normal));
                        cantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                        cantidad.VerticalAlignment = Element.ALIGN_CENTER;

                        idPlano = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("idPlano"), ""), normal));
                        idPlano.HorizontalAlignment = Element.ALIGN_CENTER;
                        idPlano.VerticalAlignment = Element.ALIGN_CENTER;

                        nombrePlano = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("nombre_archivo"), ""), normal));
                        nombrePlano.HorizontalAlignment = Element.ALIGN_CENTER;
                        nombrePlano.VerticalAlignment = Element.ALIGN_CENTER;

                        requisicion = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("requisicion_compra"), ""), normal));
                        requisicion.HorizontalAlignment = Element.ALIGN_CENTER;
                        requisicion.VerticalAlignment = Element.ALIGN_CENTER;

                        numProceso = new PdfPCell(new Phrase(Global.ObjetoATexto(f.Celda("idProceso"), "") + " - " + Global.ObjetoATexto(f.Celda("proceso"), ""), normal));
                        numProceso.HorizontalAlignment = Element.ALIGN_CENTER;
                        numProceso.VerticalAlignment = Element.ALIGN_CENTER;

                        piezasAcero++;

                        rowInformacionGeneral = new PdfPRow(new PdfPCell[] { idItem, cantidad, idPlano, nombrePlano, requisicion, numProceso });
                        tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
                        tienePiezasAcero = true;
                    }
                });
            }

            if (!tienePiezasAcero)
            {
                PdfPCell sinPiezas = new PdfPCell(new Phrase("SIN PIEZAS DE ACERO", normal));
                sinPiezas.HorizontalAlignment = Element.ALIGN_CENTER;
                sinPiezas.VerticalAlignment = Element.ALIGN_CENTER;
                sinPiezas.Colspan = 6;

                rowInformacionGeneral = new PdfPRow(new PdfPCell[] { sinPiezas, null, null, null, null, null });
                tablaPerfilUsuario.Rows.Add(rowInformacionGeneral);
            }

            #endregion

            //tabla firmas
            #region firmas
            Paragraph ptablaFirmas = new Paragraph();
            ptablaFirmas.SpacingBefore = 5;


            //inicializar tabla
            PdfPTable tablaPrincipalFirmas = new PdfPTable(4);
            tablaPrincipalFirmas.WidthPercentage = 100;
            tablaPrincipalFirmas.SpacingBefore = 5;

            int[] intTblWidthFirmas = { 25, 25, 25, 25 };
            tablaPrincipalFirmas.SetWidths(intTblWidthFirmas);

            PdfPCell headersalida = new PdfPCell(new Phrase("SALIDA DE LAS PIEZAS", negritasBlanca));
            headersalida.HorizontalAlignment = Element.ALIGN_CENTER;
            headersalida.HorizontalAlignment = Element.ALIGN_CENTER;
            headersalida.BackgroundColor = BaseColor.BLACK;
            headersalida.Colspan = 2;

            PdfPCell headerRegreso = new PdfPCell(new Phrase("REGRESO DE LAS PIEZAS", negritasBlanca));
            headerRegreso.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRegreso.VerticalAlignment = Element.ALIGN_CENTER;
            headerRegreso.BackgroundColor = BaseColor.BLACK;
            headerRegreso.Colspan = 2;

            PdfPRow rowIFirmas = new PdfPRow(new PdfPCell[] { headersalida, null, headerRegreso, null });
            tablaPrincipalFirmas.Rows.Add(rowIFirmas);

            PdfPCell firmaContactoProveedor = new PdfPCell(new Phrase(".", negritasBlanca));
            firmaContactoProveedor.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaContactoProveedor.VerticalAlignment = Element.ALIGN_CENTER;
            firmaContactoProveedor.ExtraParagraphSpace = 38;

            PdfPCell firmaEntregaAudisel = new PdfPCell(new Phrase( Global.UsuarioActual.NombreCompleto(), normal));
            firmaEntregaAudisel.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaEntregaAudisel.VerticalAlignment = Element.ALIGN_CENTER;
            firmaEntregaAudisel.ExtraParagraphSpace = 38;

            PdfPCell firmaContactoProveedorRegreso = new PdfPCell(new Phrase("", negritasBlanca));
            firmaContactoProveedorRegreso.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaContactoProveedorRegreso.VerticalAlignment = Element.ALIGN_BOTTOM;
            firmaContactoProveedorRegreso.ExtraParagraphSpace = 38;

            PdfPCell firmaEntregaAudiselRegreso = new PdfPCell(new Phrase("", negritasBlanca));
            firmaEntregaAudiselRegreso.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaEntregaAudiselRegreso.VerticalAlignment = Element.ALIGN_BOTTOM;
            firmaEntregaAudiselRegreso.ExtraParagraphSpace = 38;

            rowIFirmas = new PdfPRow(new PdfPCell[] { firmaContactoProveedor, firmaEntregaAudisel, firmaContactoProveedorRegreso, firmaEntregaAudiselRegreso });
            tablaPrincipalFirmas.Rows.Add(rowIFirmas);

            PdfPCell firmaContactoProveedorTitulo = new PdfPCell(new Phrase("CONTACTO PROVEEDOR", normal));
            firmaContactoProveedorTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaContactoProveedorTitulo.VerticalAlignment = Element.ALIGN_BOTTOM;
            firmaContactoProveedorTitulo.BackgroundColor = BaseColor.LIGHT_GRAY;

            PdfPCell firmaEntregaAudiselTitulo = new PdfPCell(new Phrase("ENTREGA (AUDISEL)", normal));
            firmaEntregaAudiselTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaEntregaAudiselTitulo.VerticalAlignment = Element.ALIGN_BOTTOM;
            firmaEntregaAudiselTitulo.BackgroundColor = BaseColor.LIGHT_GRAY;

            PdfPCell firmaContactoProveedorRegresoTitulo = new PdfPCell(new Phrase("CONTACTO PROVEEDOR", normal));
            firmaContactoProveedorRegresoTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaContactoProveedorRegresoTitulo.VerticalAlignment = Element.ALIGN_BOTTOM;
            firmaContactoProveedorRegresoTitulo.BackgroundColor = BaseColor.LIGHT_GRAY;

            PdfPCell firmaEntregaAudiselRegresoTitulo = new PdfPCell(new Phrase("RECIBE (AUDISEL)", normal));
            firmaEntregaAudiselRegresoTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            firmaEntregaAudiselRegresoTitulo.VerticalAlignment = Element.ALIGN_BOTTOM;
            firmaEntregaAudiselRegresoTitulo.BackgroundColor = BaseColor.LIGHT_GRAY;


            rowIFirmas = new PdfPRow(new PdfPCell[] { firmaContactoProveedorTitulo, firmaEntregaAudiselTitulo, firmaContactoProveedorRegresoTitulo, firmaEntregaAudiselRegresoTitulo });
            tablaPrincipalFirmas.Rows.Add(rowIFirmas);
            #endregion

            ptablaPrincipalHeader.Add(tablaPerfilHeader);
            ptablaPrincipalPerfilUsuario.Add(tablaPerfilUsuario);
            ptablaFirmas.Add(tablaPrincipalFirmas);

            doc.Add(ptablaPrincipalHeader);
            doc.Add(ptablaPrincipalPerfilUsuario);
            doc.Add(ptablaFirmas);

            // Cierra el archivo
            doc.Close();
            fs.Close();

            // Abre el archivo creado, lo carga en un arreglo de bytes y lo usa como 
            // valor de retorno de la funcion (util para mostrarlo en un control de PDF o guardarlo como BLOB)
            using (FileStream pdf = File.OpenRead(nombreArchivo + ".pdf"))
            {
                using (BinaryReader reader = new BinaryReader(pdf))
                {
                    datosPDF = reader.ReadBytes((int)pdf.Length);
                }
            }
            if (tienePiezasAcero || tienePiezasAluminio)
                return datosPDF;
            else
                return null;
        }
    }

    public class MyHeaderFooterEvent : PdfPageEventHelper
    {
        Font ColorHeader = FontFactory.GetFont("Calibri Light (Headings)", 12, new BaseColor(46, 116, 181));
        Font FONT = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD);

        public string headerTexto { get; set; }
        public string FooterTexto { get; set; }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            string[] encabezado = headerTexto.Split('\\');
            
            PdfContentByte canvas = writer.DirectContent;
            ColumnText.ShowTextAligned(
              canvas, Element.ALIGN_LEFT,
              new Phrase(encabezado[0], ColorHeader), 34, 770, 0
            );

            ColumnText.ShowTextAligned(
              canvas, Element.ALIGN_RIGHT,
              new Phrase(encabezado[1], ColorHeader), 575, 770, 0
            );

            ColumnText.ShowTextAligned(
              canvas, Element.ALIGN_RIGHT,
              new Phrase("Página " + writer.CurrentPageNumber.ToString(), ColorHeader), 575, 10, 0
            );      
        }
    }

    public static class StringExtension
    {
        public static string CapitalizeFirst(this string s)
        {
            bool IsNewSentense = true;
            var result = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (IsNewSentense && char.IsLetter(s[i]))
                {
                    result.Append(char.ToUpper(s[i]));
                    IsNewSentense = false;
                }
                else
                    result.Append(s[i]);

                if (s[i] == '!' || s[i] == '?' || s[i] == '.')
                {
                    IsNewSentense = true;
                }
            }

            return result.ToString();
        }
    }
}

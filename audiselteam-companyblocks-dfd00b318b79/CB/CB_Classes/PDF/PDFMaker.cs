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
using CB;

namespace CB_Base.Classes
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
    class PDFMaker
    {
        public byte[] CrearPDF()
        {
            string temp = nombreArchivoTemporal();
            FileStream fs = new FileStream(temp + ".pdf", FileMode.Create, FileAccess.Write);
            Rectangle cuadro = new Rectangle(PageSize.LETTER);
            Document doc = new Document(cuadro);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            Parrafo(Frases("", Fuente(TipoFuente.CALIBRI, 11, ColorBase.BLANCO))).SpacingBefore = 5;
            List<string> header = new List<string>();
            header.Add("HEADER TEST");
            header.Add("HEADER2 TEST2");
            int[] width = { 50,50 };


            doc.Add(Parrafo(Frases("test", Fuente(TipoFuente.CALIBRI, 11, ColorBase.MAGENTA))));
            PdfPTable tabla1 = Tabla(2, width, AgregarTablaHeader(2, header));
            tabla1.AddCell(Celda("row1",Fuente()));
            tabla1.AddCell(Celda("row2", Fuente(TipoFuente.CALIBRI,9,ColorBase.ROJO,true)));


            doc.Add(tabla1);
            doc.Close();
            fs.Close();

            return CrearArchivo(temp);
        }

        public string  nombreArchivoTemporal()
        {
            return  System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
        }

        public void AgregarLogo(System.Drawing.Image imagenLogo, ColorBase color, int espacio, int escalaX, int escalaY)
        {
            Image logo = Image.GetInstance(imagenLogo, ColorBaseM(color));
            logo.ScaleToFit(escalaX, escalaY);
            logo.Alignment = Image.TEXTWRAP | Image.ALIGN_BOTTOM;
            logo.IndentationLeft = 9;
            logo.SpacingAfter = espacio;
        }

        public Phrase Frases(string texto,Font fuente)
        {
            Phrase p = new Phrase(texto,fuente);
            return p;
        }

        /// <summary>
        /// Crear tabla
        /// </summary>
        /// <param name="ColumnasCantidad">Cantidad de columnas</param>
        /// <param name="tblWidth">Tamaño de las columnas</param>
        /// <param name="row">Renglón con el contenido de los headers de la tabla</param>
        /// <returns>PdfPTable</returns>
        public PdfPTable Tabla(int ColumnasCantidad, int[] tblWidth, PdfPRow row)
        {
            PdfPTable tabla = new PdfPTable(ColumnasCantidad);
            tabla.SetWidths(tblWidth);
            tabla.Rows.Add(row);
            return tabla;
        }

        /// <summary>
        /// Agrega celdas
        /// </summary>
        /// <param name="texto">Header</param>
        /// <param name="fuente">Tipo de fuente</param>
        /// <param name="horizontal">Alineación horizontal</param>
        /// <param name="vertical">Alineación vertical</param>
        /// <param name="color">Color de fondo</param>
        /// <returns>PdfPCell</returns>
        public PdfPCell Celda(string texto, Font fuente, AlinearFuente horizontal = AlinearFuente.ALIGN_CENTER, AlinearFuente vertical= AlinearFuente.ALIGN_CENTER, ColorBase color = ColorBase.BLANCO)
        {
            PdfPCell celda = new PdfPCell(Frases(texto, fuente));
            celda.HorizontalAlignment = (int)horizontal;
            celda.VerticalAlignment = (int)vertical;
            celda.BackgroundColor = ColorBaseM(color);
            return celda;
        }

        /// <summary>
        /// Agrega Headers a la tabla
        /// </summary>
        /// <param name="numeroColumnas">Número de columnas</param>
        /// <param name="headerNombre">Texto con el nombre del header</param>
        /// <param name="fuenteLetra">TIpo de fuente de letra</param>
        /// <param name="fuenteTamano">Tamaño de la fuente</param>
        /// <param name="fuenteColor">Color de la fuente del texto</param>
        /// <param name="alinearFuenteX">Alinear el texto en el eje X</param>
        /// <param name="alinearFuenteY">Alinear el texto en el eje Y</param>
        /// <param name="colorFondo">Color de fondo del texto</param>
        /// <returns>PdfPRow</returns>
        public PdfPRow AgregarTablaHeader(int numeroColumnas, List<string> headerNombre, TipoFuente fuenteLetra = TipoFuente.CALIBRI, int fuenteTamano = 11, ColorBase fuenteColor = ColorBase.NEGRO, AlinearFuente alinearFuenteX = AlinearFuente.ALIGN_CENTER, AlinearFuente alinearFuenteY = AlinearFuente.ALIGN_CENTER, ColorBase colorFondo = ColorBase.BLANCO)
        {
            PdfPCell[] cellArray = new PdfPCell[numeroColumnas];
            
            for (int i = 0; i < numeroColumnas ; i++)
            {
                PdfPCell celdas = Celda(headerNombre[i].ToString(), Fuente(fuenteLetra, fuenteTamano, fuenteColor), alinearFuenteX, alinearFuenteY, colorFondo);
                cellArray[i] = celdas;
            }

            PdfPRow row = new PdfPRow(cellArray);
            return row;
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

        public Font Fuente(TipoFuente fuente = TipoFuente.CALIBRI, int tamano = 11, ColorBase color = ColorBase.NEGRO, bool negritas = false)
        {
            Font normal; 

            if(negritas)
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

        public byte[] CrearArchivo(string temp)
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
}

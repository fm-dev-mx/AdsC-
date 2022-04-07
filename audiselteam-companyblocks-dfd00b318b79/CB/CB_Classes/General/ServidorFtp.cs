using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public enum FormatoArchivo
    {
        Pdf,
        Png,
        Step,
        Rtf,
        css,
        html,
        sldprt,
        sldasm
    }

    public enum TipoArchivo
    { 
        Todo,
        Imagen,
        Documento,
        Video
    }

    public class ServidorFtp
    {
        static string fullPath = string.Empty;

        public static List<string> ExtensionesImagenes = new List<string>() 
        {
            ".png", ".jpg", ".jpeg"
        };

        public static List<string> ExtensionesVideo = new List<string>() 
        {
            ".mov", ".mp4", ".mkv"
        };

        public static List<string> ExtensionesDocumentos = new List<string>()
        {
            ".xlsx", ".docx", ".txt"
        };

        public static Dictionary<TipoArchivo, List<string>> DefinicionesExtensiones = new Dictionary<TipoArchivo, List<string>>()
        {
            { TipoArchivo.Imagen, ExtensionesImagenes },
            { TipoArchivo.Video, ExtensionesVideo },
            { TipoArchivo.Documento, ExtensionesDocumentos }
        };

        static public byte[] DescargarPlano(int idPlano, FormatoArchivo formato, BackgroundWorker bkg, out string rutaFtp)
        {
            rutaFtp = string.Empty;
            FtpClient ClienteFtp = new FtpClient();

            if (!ClienteFtp.IsConnected)
            {
                if (!Global.CrearConexionFTP(ClienteFtp))
                {
                    bkg.ReportProgress(100, "Error");
                    return null;
                }
            }
            bkg.ReportProgress(30, "Descargando imagen...");

            byte[] DatosPlano = null;
            rutaFtp = SolidWorksProyecto.Modelo().RutaFtpPlano(idPlano);
            string extensionPlano = string.Empty;

            
            switch(formato)
            {
                case FormatoArchivo.Pdf:
                    extensionPlano = ".PDF";
                    break;

                case FormatoArchivo.Png:
                    extensionPlano = ".PNG";
                    break;
            }

            bkg.ReportProgress(80, "Procesando imagen...");

            if (ClienteFtp.FileExists(rutaFtp + extensionPlano))
            {
                bkg.ReportProgress(80, "Descargando plano...");
                DatosPlano = null;

                ClienteFtp.Download(out DatosPlano, rutaFtp + extensionPlano);

                bkg.ReportProgress(100, "Procesando plano");
            }
            return DatosPlano;
        }

        static public bool SubirImagen(byte[] datos, string rutaFtpDestino, string nombreImagen)
        {
            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
            {
                return false;
            }

            if (!ClienteFtp.DirectoryExists(rutaFtpDestino))
                ClienteFtp.CreateDirectory(rutaFtpDestino);

            ClienteFtp.Upload(datos, System.IO.Path.Combine(rutaFtpDestino, nombreImagen), FtpExists.Overwrite);

            return ClienteFtp.FileExists(System.IO.Path.Combine(rutaFtpDestino, nombreImagen));
        }

        static public bool SubirImagen(byte[] datos, string rutaFtpDestino, string nombreImagen, BackgroundWorker worker)
        {
            FtpClient ClienteFtp = new FtpClient();

            worker.ReportProgress(10, "Subiendo imagen");

            if (!Global.CrearConexionFTP(ClienteFtp))
            {
                return false;
            }

            worker.ReportProgress(35, "Subiendo imagen");

            if (!ClienteFtp.DirectoryExists(rutaFtpDestino))
                ClienteFtp.CreateDirectory(rutaFtpDestino);

            worker.ReportProgress(70, "Subiendo imagen");

            ClienteFtp.Upload(datos, System.IO.Path.Combine(rutaFtpDestino, nombreImagen), FtpExists.Overwrite);

            worker.ReportProgress(90, "Subiendo imagen");

            return ClienteFtp.FileExists(System.IO.Path.Combine(rutaFtpDestino, nombreImagen));
        }

        static public bool SubirDocumento(byte[] datos, int idDocumento, FormatoArchivo formato, string rutaFtpDestino)
        {
            string extension = string.Empty;
            switch (formato)
            {
                case FormatoArchivo.Pdf:
                    extension = ".PDF";
                    break;
                case FormatoArchivo.Png:
                    extension = ".PNG";
                    break;
                case FormatoArchivo.Step:
                    extension = ".STEP";
                    break;
                case FormatoArchivo.Rtf:
                    extension = ".RTF";
                    break;
                case FormatoArchivo.css:
                    extension = "_STYLES.CSS";
                    break;
                case FormatoArchivo.html:
                    extension = ".HTML";
                    break;
                case FormatoArchivo.sldprt:
                    extension = ".SLDPRT";
                    break;
                case FormatoArchivo.sldasm:
                    extension = ".SLDASM";
                    break;
            }

            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
                return false;

            if (!ClienteFtp.DirectoryExists(rutaFtpDestino))
                ClienteFtp.CreateDirectory(rutaFtpDestino);

            ClienteFtp.Upload(datos, rutaFtpDestino + "\\" + idDocumento + extension, FtpExists.Overwrite);

            if (ClienteFtp.FileExists(rutaFtpDestino + "\\" + idDocumento + extension))
                return true;
            else
                return false;
        }

        static public bool SubirDocumento(byte[] datos, string nombreArchivo, FormatoArchivo formato, string rutaFtpDestino)
        {
            string extension = string.Empty;
            switch (formato)
            {
                case FormatoArchivo.Pdf:
                    extension = ".PDF";
                    break;
                case FormatoArchivo.Png:
                    extension = ".PNG";
                    break;
                case FormatoArchivo.Step:
                    extension = ".STEP";
                    break;
                case FormatoArchivo.Rtf:
                    extension = ".RTF";
                    break;
                case FormatoArchivo.css:
                    extension = "_STYLES.CSS";
                    break;
                case FormatoArchivo.html:
                    extension = ".HTML";
                    break;
                case FormatoArchivo.sldprt:
                    extension = ".SLDPRT";
                    break;
                case FormatoArchivo.sldasm:
                    extension = ".SLDASM";
                    break;
            }

            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
                return false;

            if (!ClienteFtp.DirectoryExists(rutaFtpDestino))
                ClienteFtp.CreateDirectory(rutaFtpDestino);

            ClienteFtp.Upload(datos, rutaFtpDestino + "\\" + nombreArchivo + extension, FtpExists.Overwrite);

            if (ClienteFtp.FileExists(rutaFtpDestino + "\\" + nombreArchivo + extension))
                return true;
            else
                return false;
        }

        static public bool SubirImagenesHtml(byte[] datos, string nombreArchivo, string rutaFtpDestino)
        {
            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
                return false;

            if (!ClienteFtp.DirectoryExists(rutaFtpDestino))
                ClienteFtp.CreateDirectory(rutaFtpDestino);

            ClienteFtp.Upload(datos, rutaFtpDestino + "\\" + nombreArchivo, FtpExists.Overwrite);

            if (ClienteFtp.FileExists(rutaFtpDestino + "\\" + nombreArchivo))
                return true;
            else
                return false;
        }

        static public bool SubirDocumento(byte[] datos, int idDocumento, FormatoArchivo formato, BackgroundWorker bkg, string rutaFtpDestino)
        {
            string extension = string.Empty;
            switch (formato)
            {
                case FormatoArchivo.Pdf:
                    extension = ".PDF";
                    break;
                case FormatoArchivo.Png:
                    extension = ".PNG";
                    break;
                case FormatoArchivo.Step:
                    extension = ".STEP";
                    break;
                case FormatoArchivo.Rtf:
                    extension = ".RTF";
                    break;
            }

            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
                return false;

            if(!ClienteFtp.DirectoryExists(rutaFtpDestino))
                ClienteFtp.CreateDirectory(rutaFtpDestino);

            ClienteFtp.Upload(datos, rutaFtpDestino + "\\" + idDocumento + extension, FtpExists.Overwrite);

            if (ClienteFtp.FileExists(rutaFtpDestino + "\\" + idDocumento + extension))
                return true;
            else
                return false;
        }

        static public Dictionary<string, byte[]> DescargarImagenesVideosEnDirectorio(string path, TipoArchivo filtroTipo = TipoArchivo.Todo)
        {
            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
                return null;

            Dictionary<string, byte[]> bytesArchivos = new Dictionary<string, byte[]>();
            
            if (ClienteFtp.DirectoryExists(path))
            {
                string[] archivos = ClienteFtp.GetNameListing(path);

                for (int i = 0; i < archivos.Length; i++)
                {
                    string extension = System.IO.Path.GetExtension(archivos[i]).ToLower();

                    if(filtroTipo == TipoArchivo.Todo || (DefinicionesExtensiones[filtroTipo].Contains(extension)))
                    {
                        byte[] archivoDescargado = null;

                        if (ExtensionesImagenes.Contains(extension))
                        {
                            ClienteFtp.Download(out archivoDescargado, archivos[i]);
                            bytesArchivos.Add(archivos[i], archivoDescargado);
                        }
                        else 
                        {
                            bytesArchivos.Add(archivos[i], new byte[0]);                
                        }
                    }
                }
            }

            return bytesArchivos;
        }

        static public List<byte[]> DescargarArchivos(List<string> archivos)
        {
            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
                return null;

            List<byte[]> bytesArchivos = new List<byte[]>();

            for (int i = 0; i < archivos.Count; i++)
            {
                byte[] archivoDescargado = null;
                ClienteFtp.Download(out archivoDescargado, archivos[i]);
                bytesArchivos.Add(archivoDescargado);
            }

            return bytesArchivos;
        }

        static public byte[] DescargarArchivo(int idDocumento, FormatoArchivo formato, string rutaFtp)
        {
            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
                return null;


            string extensionPlano = string.Empty;
            switch (formato)
            {
                case FormatoArchivo.Pdf:
                    extensionPlano = ".PDF";
                    break;

                case FormatoArchivo.Png:
                    extensionPlano = ".PNG";
                    break;
                case FormatoArchivo.Step:
                    extensionPlano = ".STEP";
                    break;
                case FormatoArchivo.Rtf:
                    extensionPlano = ".RTF";
                    break;
                case FormatoArchivo.css:
                    extensionPlano = "_STYLES.CSS";
                    break;
                case FormatoArchivo.html:
                    extensionPlano = ".HTML";
                    break;
            }


            byte[] DatosArchivos = null;

            string extencionDocumento = extensionPlano;

            if (ClienteFtp.FileExists(rutaFtp + idDocumento + extensionPlano))
            {
                DatosArchivos = null;
                ClienteFtp.Download(out DatosArchivos, rutaFtp + idDocumento + extensionPlano);
              //  ClienteFtp.Download(out DatosArchivos, rutaFtp + idDocumento + extensionPlano);              
            }
            return DatosArchivos;
        }

        static public byte[] DescargarArchivo(int idDocumento, FormatoArchivo formato, string rutaFtp, BackgroundWorker worker)
        {
            FtpClient ClienteFtp = new FtpClient();
            worker.ReportProgress(30, "Descargando archivo");

            if (!Global.CrearConexionFTP(ClienteFtp))
                return null;

            worker.ReportProgress(50, "Descargando archivo");

            string extensionPlano = string.Empty;
            switch (formato)
            {
                case FormatoArchivo.Pdf:
                    extensionPlano = ".PDF";
                    break;

                case FormatoArchivo.Png:
                    extensionPlano = ".PNG";
                    break;
                case FormatoArchivo.Step:
                    extensionPlano = ".STEP";
                    break;
                case FormatoArchivo.Rtf:
                    extensionPlano = ".RTF";
                    break;
                case FormatoArchivo.css:
                    extensionPlano = "_STYLES.CSS";
                    break;
                case FormatoArchivo.html:
                    extensionPlano = ".HTML";
                    break;
            }


            byte[] DatosArchivos = null;
            worker.ReportProgress(70, "Descargando archivo");

            string extencionDocumento = extensionPlano;

            if (ClienteFtp.FileExists(rutaFtp + idDocumento + extensionPlano))
            {
                DatosArchivos = null;
                ClienteFtp.Download(out DatosArchivos, rutaFtp + idDocumento + extensionPlano);

                worker.ReportProgress(90, "Descargando archivo");
                //  ClienteFtp.Download(out DatosArchivos, rutaFtp + idDocumento + extensionPlano);              
            }
            return DatosArchivos;
        }

        static public void DescargarDirectorio(string PathDirectorioRemoto,  string PathDirectorioLocal, int idDocumento)
        {
            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
                return;

            if (!ClienteFtp.DirectoryExists(@PathDirectorioRemoto))
                return;

            var archivos = ClienteFtp.GetListing(@PathDirectorioRemoto);
            byte[] DatosArchivos = null;

            foreach (var nombreArchivo in archivos)
            {
                string path = PathDirectorioRemoto + nombreArchivo.Name.ToString();
                if (ClienteFtp.FileExists(path))
                {
                    DatosArchivos = null;
                    ClienteFtp.Download(out DatosArchivos, PathDirectorioRemoto + nombreArchivo.Name.ToString());
                    File.WriteAllBytes(PathDirectorioLocal + nombreArchivo.Name, DatosArchivos);
                }      
            }         
        }

        static public string DescargarDirectorio(string PathDirectorioRemoto, string nombreArchivoABajar, BackgroundWorker worker, DoWorkEventArgs e, string pathEspecifico = null)
        {
            int avance = 0;
            byte[] datosArchivos = null;
            string pathLibreria = string.Empty;

            FtpClient ClienteFtp = new FtpClient();
            if (!Global.CrearConexionFTP(ClienteFtp))
                return null;

            if (!ClienteFtp.DirectoryExists(@PathDirectorioRemoto))
                return null;

            fullPath = string.Empty;
            var listaArchivosFullPath = getDirPath(ClienteFtp, @PathDirectorioRemoto);
            listaArchivosFullPath.RemoveAll(item => item == null || item == "");

            if(worker.CancellationPending)
                return null;

            foreach (var PathABajar in listaArchivosFullPath)
            {
                if (!worker.CancellationPending)
                {
                    if (nombreArchivoABajar.ToUpper() == Path.GetFileName(PathABajar).ToUpper())
                        pathLibreria = PathABajar;

                    datosArchivos = null;
                    ClienteFtp.Download(out datosArchivos, PathABajar);

                    string localPath = string.Empty;

                    if (pathEspecifico != null)
                        localPath = pathEspecifico + Path.GetDirectoryName(PathABajar);
                    else
                        localPath = Directory.GetCurrentDirectory() + Path.GetDirectoryName(PathABajar);

                    if (!Directory.Exists(localPath))
                        Directory.CreateDirectory(localPath);

                    File.WriteAllBytes(localPath + "\\" + Path.GetFileName(PathABajar), datosArchivos);
                    avance++;

                    int porcentaje = Global.CalcularPorcentaje(avance, listaArchivosFullPath.Count);
                    worker.ReportProgress(porcentaje, "Descargando archivos...");
                }
                else
                {
                    e.Cancel = true;
                    return null;
                }
            }

            return pathLibreria;
        }

        private static List<string> getDirPath(FtpClient ClienteFtp, string @path)
        {
            foreach (FtpListItem item in ClienteFtp.GetListing(@path))
            {
                if (item.Type == FtpFileSystemObjectType.File)
                {
                    fullPath += item.FullName + ",";
                }
                else if (item.Type == FtpFileSystemObjectType.Directory)
                {
                    getDirPath(ClienteFtp, item.FullName);
                }
            }

            return fullPath.Split(',').ToList();
        }

        static public bool RemoverArchivo(int idDocumento, FormatoArchivo formato, string rutaFtp)
        {
            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
            {
                return false;
            }

            string extensionPlano = string.Empty;
            switch (formato)
            {
                case FormatoArchivo.Pdf:
                    extensionPlano = ".PDF";
                    break;
                case FormatoArchivo.Png:
                    extensionPlano = ".PNG";
                    break;
                case FormatoArchivo.Step:
                    extensionPlano = ".STEP";
                    break;
            }

            string extencionDocumento = extensionPlano;

            if (ClienteFtp.FileExists(rutaFtp + idDocumento + extensionPlano))
                ClienteFtp.DeleteFile(rutaFtp + idDocumento + extensionPlano);
            return true;
        }

        static public bool EliminarDirectorio(string dirFtp)
        {
            FtpClient ClienteFtp = new FtpClient();

            if (!Global.CrearConexionFTP(ClienteFtp))
                return false;

            if(ClienteFtp.DirectoryExists(dirFtp))
                ClienteFtp.DeleteDirectory(dirFtp, FtpListOption.AllFiles);

            return !(ClienteFtp.DirectoryExists(dirFtp));
            
        }
    }
}
